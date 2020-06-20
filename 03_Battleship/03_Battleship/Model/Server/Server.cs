//-----------------------------------------------------------------------
// <copyright file="Server.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Server class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using EnhancedNetworking;

    /// <summary>
    /// Represents the server class.
    /// </summary>
    public class Server
    {
        /// <summary>
        /// The battle manager.
        /// </summary>
        private BattleManager battleManager;

        /// <summary>
        /// The match maker.
        /// </summary>
        private MatchMaker matchMaker;

        /// <summary>
        /// The connection manger.
        /// </summary>
        private IConnectionManager connectionManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="Server"/> class.
        /// </summary>
        /// <param name="connectionManager">The connection manager of the server.</param>
        public Server(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager ?? throw new ArgumentNullException(nameof(connectionManager), "The value must not be null.");
            this.connectionManager.ConnectionAccepted += this.ConnectionManager_ConnectionAccepted;
            this.connectionManager.MessageReceived += this.ConnectionManager_MessageReceived;
            this.matchMaker = new MatchMaker(this.connectionManager);
            this.matchMaker.BattleIsReady += this.MatchMaker_BattleIsReady;
            this.battleManager = new BattleManager(this.matchMaker.UsersInLobby);
        }

        /// <summary>
        /// Starts the server.
        /// </summary>
        public void Start()
        {
            this.connectionManager.Start();
        }

        /// <summary>
        /// Shuts the server down.
        /// </summary>
        public void Shutdown()
        {
            this.connectionManager.Stop();
        }

        /// <summary>
        /// Sets the arguments of the connection, when a connection is accepted.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        private void ConnectionManager_ConnectionAccepted(object sender, ClientAcceptedEventArgs args)
        {
            ConnectionArgs connectionData = new ConnectionArgs();

            // TODO: Implement user name.
            connectionData.UserName = "John Doe";
            connectionData.ClientState = ClientState.Inactive;
            IConnection connection = args.Connection;
            connection.ConnectionData = connectionData;
        }

        /// <summary>
        /// Initiates a new Battle, when a new battle is ready.
        /// </summary>
        /// <param name="sender">The sender of the BattleReady event.</param>
        /// <param name="e">The event arguments.</param>
        private void MatchMaker_BattleIsReady(object sender, BattleReadyEventArgs e)
        {
            this.battleManager.InitiateBattle(e.CompetitorA, e.CompetitorB);
        }

        /// <summary>
        /// Evaluates a received message.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        private void ConnectionManager_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            Message message = (Message)args.Message;
            IConnection connection = (IConnection)args.Connection;

            switch (message.MessageType)
            {
                case MessageType.AliveMessage:
                    return;
                case MessageType.LobbyRequest:
                    this.Connection_LobbyRequestReceived(message, connection);
                    return;
            }
        }

        /// <summary>
        /// Sends a lobby response.
        /// </summary>
        /// <param name="message">The message containing the lobby request.</param>
        /// <param name="connection">The source of the message.</param>
        private void Connection_LobbyRequestReceived(Message message, IConnection connection)
        {
            List<ClientDummy> lobby = this.matchMaker.Lobby;
            connection.SendMessage(new Message(MessageType.LobbyResponse, lobby));
        }
    }
}