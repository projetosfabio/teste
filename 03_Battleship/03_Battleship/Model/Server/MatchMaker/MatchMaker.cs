//-----------------------------------------------------------------------
// <copyright file="MatchMaker.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MatchMaker class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EnhancedNetworking;

    /// <summary>
    /// Represents the match maker.
    /// </summary>
    public class MatchMaker
    {
        /// <summary>
        /// The connection manager.
        /// </summary>
        private IConnectionManager connectionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchMaker"/> class.
        /// </summary>
        /// <param name="connectionManager">The connection manager.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null;
        /// connectionManager - The value must not be null.
        /// </exception>
        public MatchMaker(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager), "The value must not be null.");
            this.connectionManager.MessageReceived += this.ConnectionManager_MessageReceived;
            this.UsersInLobby = new List<IConnection>();
        }

        /// <summary>
        /// Occurs when a battle is ready.
        /// </summary>
        public event EventHandler<BattleReadyEventArgs> BattleIsReady;

        /// <summary>
        /// Gets the users in the lobby.
        /// </summary>
        /// <value>
        /// The pending users.
        /// </value>
        public List<IConnection> UsersInLobby
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the lobby.
        /// </summary>
        /// <value>
        /// The lobby.
        /// </value>
        public List<ClientDummy> Lobby
        {
            get
            {
                List<ClientDummy> clients = new List<ClientDummy>();
                for (int i = 0; i < this.UsersInLobby.Count; i++)
                {
                    IConnection client = this.UsersInLobby[i];
                    ConnectionArgs clientData = (ConnectionArgs)client.ConnectionData;
                    bool inGame = clientData.ClientState == ClientState.InGame ? true : false;
                    clients.Add(new ClientDummy(clientData.UserName, client.IPAddress, inGame, clientData.Id));
                }

                return clients;
            }
        }

        /// <summary>
        /// Fires the battle ready event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="BattleReadyEventArgs"/> instance containing the event data.</param>
        protected virtual void FireBattleReady(object sender, BattleReadyEventArgs args)
        {
            this.BattleIsReady?.Invoke(sender, args);
        }

        /// <summary>
        /// Handles the MessageReceived event of the ConnectionManager.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessageReceivedEventArgs"/> instance containing the event data.</param>
        private void ConnectionManager_MessageReceived(object sender, MessageReceivedEventArgs e)
        {
            Message message = (Message)e.Message;
            switch (message.MessageType)
            {
                case MessageType.NewBattleRequest:
                    this.NewBattle(e.Connection);
                    return;
                case MessageType.JoinBattleRequest:
                    int gameOwner = (int)message.Content;
                    this.JoinBattle(e.Connection, gameOwner);
                    return;
                case MessageType.ConfirmBattle:
                    this.BattleConfirmed(e.Connection);
                    return;
                case MessageType.DeclineBattle:
                    this.BattleDeclined(e.Connection);
                    return;
            }
        }

        /// <summary>
        /// Sends The battle declined message.
        /// </summary>
        /// <param name="gameOwner">The game owner.</param>
        private void BattleDeclined(IConnection gameOwner)
        {
            ConnectionArgs args = (ConnectionArgs)gameOwner.ConnectionData;
            IConnection challenger = args.Challenger;
            ConnectionArgs challengerArgs = (ConnectionArgs)challenger.ConnectionData;
            args.Challenger = null;
            challenger.SendMessage(new Message(MessageType.DeclineBattle));
        }

        /// <summary>
        /// Handles the BattleConfirmed message.
        /// </summary>
        /// <param name="gameOwner">The game owner.</param>
        private void BattleConfirmed(IConnection gameOwner)
        {
            ConnectionArgs args = (ConnectionArgs)gameOwner.ConnectionData;
            IConnection challenger = args.Challenger;
            ConnectionArgs challengerArgs = (ConnectionArgs)challenger.ConnectionData;
            if (args.ClientState != ClientState.WaitingForOpponent || challengerArgs.ClientState != ClientState.Inactive)
            {
                // Client is not available.
                return;
            }

            this.UsersInLobby.Add(challenger);
            this.FireBattleReady(this, new BattleReadyEventArgs(gameOwner, challenger));
        }

        /// <summary>
        /// Adds a pending user.
        /// </summary>
        /// <param name="connection">The connection.</param>
        private void NewBattle(IConnection connection)
        {
            ConnectionArgs args = (ConnectionArgs)connection.ConnectionData;

            if (args.ClientState != ClientState.Inactive)
            {
                // Client has already an open game.
                return;
            }

            args.Id = DateTime.Now.Millisecond;
            args.ClientState = ClientState.WaitingForOpponent;
            connection.ConnectionLost += this.Connection_Disconnected;
            connection.TimedOut += this.Connection_Disconnected;
            this.UsersInLobby.Add(connection);
        }

        /// <summary>
        /// Matches the users.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <param name="gameOwnerId">The game owner ID.</param>
        private void JoinBattle(IConnection connection, int gameOwnerId)
        {
            ConnectionArgs args = (ConnectionArgs)connection.ConnectionData;
            if (args.ClientState != ClientState.Inactive)
            {
                // Cant join, user has an open game.
                return;
            }

            try
            {
                IConnection gameOwner = this.UsersInLobby.Where(user => ((ConnectionArgs)user.ConnectionData).Id == gameOwnerId).First();
                if (gameOwner != connection)
                {
                    if (gameOwner.ConnectionData == null)
                    {
                        gameOwner.ConnectionData = new ConnectionArgs();
                    }

                    ConnectionArgs gameOwnerArgs = (ConnectionArgs)gameOwner.ConnectionData;
                    gameOwnerArgs.Challenger = connection;
                    gameOwner.SendMessage(new Message(MessageType.JoinBattleRequest, new ClientDummy(args.UserName, connection.IPAddress, false, args.Id)));
                }
            }
            catch
            {
                // TODO: not found.
            }
        }

        /// <summary>
        /// Handles the Disconnected event of the Connection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DisconnectedEventArgs"/> instance containing the event data.</param>
        private void Connection_Disconnected(object sender, DisconnectedEventArgs e)
        {
            if (this.UsersInLobby.Contains(e.Connection))
            {
                this.UsersInLobby.Remove(e.Connection);
            }
        }
    }
}