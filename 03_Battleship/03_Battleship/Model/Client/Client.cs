//-----------------------------------------------------------------------
// <copyright file="Client.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Client class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using EnhancedNetworking;

    /// <summary>
    /// Represents the Client class.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// The connection to the server.
        /// </summary>
        private IConnection connection;

        /// <summary>
        /// The task to send lobby requests.
        /// </summary>
        private NetworkTask sendLobbyRequestTask;

        /// <summary>
        /// The task to send alive messages.
        /// </summary>
        private NetworkTask sendAliveMessageTask;

        /// <summary>
        /// Initializes a new instance of the <see cref="Client"/> class.
        /// </summary>
        /// <param name="connection">The connection to the server.</param>
        public Client(IConnection connection)
        {
            this.connection = connection ?? throw new ArgumentNullException("The value must not be null.");
            this.connection.MessageReceived += this.Connection_MessageReceived;
            this.connection.ConnectionFailed += this.FireConnectionFailed;
            this.connection.ConnectionLost += this.FireConnectionLost;
        }

        /// <summary>
        /// The event which fires when the client disconnected.
        /// </summary>
        public event EventHandler<EventArgs> ConnectionLost;

        /// <summary>
        /// The event which fires when a creating a connection to the server failed.
        /// </summary>
        public event EventHandler<EventArgs> ConnectionFailed;

        /// <summary>
        /// The event which fires when the move of the opponent is received.
        /// </summary>
        public event EventHandler<MoveReceivedEventArgs> OpponentMoveReceived;

        /// <summary>
        /// The event which fires when the report of the own move is received.
        /// </summary>
        public event EventHandler<MoveReceivedEventArgs> MoveReportReceived;

        /// <summary>
        /// The event which fires when a move request is received.
        /// </summary>
        public event EventHandler<EventArgs> MoveRequestReceived;

        /// <summary>
        /// The event which fires when the lobby is received.
        /// </summary>
        public event EventHandler<LobbyReceivedEventArgs> LobbyReceived;

        /// <summary>
        /// The event which fires when the message is received that initiates a battle.
        /// </summary>
        public event EventHandler<EventArgs> InitiateBattleReceived;

        /// <summary>
        /// The event which fires when the game is won.
        /// </summary>
        public event EventHandler<EventArgs> GameWon;

        /// <summary>
        /// The even which fires when the game is lost.
        /// </summary>
        public event EventHandler<EventArgs> GameLost;

        /// <summary>
        /// Occurs when a challenger is found.
        /// </summary>
        public event EventHandler<ChallengerFoundEventArgs> ChallengerFound;

        /// <summary>
        /// Occurs when the opponent declined a battle request.
        /// </summary>
        public event EventHandler<EventArgs> OpponentDeclined;

        /// <summary>
        /// Gets the battle field of the client.
        /// </summary>
        /// <value>The battle field.</value>
        public BattleField BattleField
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the server IP Address.
        /// </summary>
        /// <value>The IP Address of the server.</value>
        public IPAddress ServerIP
        {
            get;
            set;
        }

        /// <summary>
        /// Sends the move to the server.
        /// </summary>
        /// <param name="position">A position as move.</param>
        public void SendMove(Position position)
        {
            this.connection.SendMessage(new Message(MessageType.MoveResponse, position));
        }

        /// <summary>
        /// Sends the ship positions to the server.
        /// </summary>
        /// <param name="ships">The placed ships.</param>
        public void SendShipPositions(List<Ship> ships)
        {
            this.connection.SendMessage(new Message(MessageType.ShipPositions, ships));
        }

        /// <summary>
        /// Sends a battle request to the server.
        /// </summary>
        public void SendNewBattleRequest()
        {
            this.connection.SendMessage(new Message(MessageType.NewBattleRequest));
        }

        /// <summary>
        /// Sends a join battle request to the server.
        /// </summary>
        /// <param name="id">The ID of the opponent.</param>
        public void SendJoinBattleRequest(int id)
        {
            this.connection.SendMessage(new Message(MessageType.JoinBattleRequest, id));
        }

        /// <summary>
        /// Sends the confirm battle message to the server.
        /// </summary>
        public void SendConfirmBattle()
        {
            this.connection.SendMessage(new Message(MessageType.ConfirmBattle));
        }

        /// <summary>
        /// Sends the decline battle message.
        /// </summary>
        public void SendDeclineBattle()
        {
            this.connection.SendMessage(new Message(MessageType.DeclineBattle));
        }

        /// <summary>
        /// Connects to the server.
        /// </summary>
        public void Connect()
        {
            if (this.ServerIP == null)
            {
                throw new ArgumentNullException(nameof(this.ServerIP), "The value must not be null");
            }

            this.connection.Connect(new IPEndPoint(this.ServerIP, 1337));

            if (!this.connection.Connected)
            {
                this.FireConnectionFailed(this, EventArgs.Empty);
                return;
            }

            this.sendAliveMessageTask = new SendAliveMessageTask(this.connection);
            this.sendAliveMessageTask.Start(null, true);
            this.connection.StartListening();
        }

        /// <summary>
        /// Closes the connection to the server.
        /// </summary>
        public void Close()
        {
            if (this.connection != null)
            {
                this.connection.Close();
            }

            if (this.sendAliveMessageTask != null)
            {
                this.sendAliveMessageTask.Stop();
            }

            if (this.sendLobbyRequestTask != null)
            {
                this.sendLobbyRequestTask.Stop();
            }

            this.ConnectionLost = null;
        }

        /// <summary>
        /// Starts sending lobby requests.
        /// </summary>
        public void StartSendingLobbyRequests()
        {
            this.sendLobbyRequestTask = new SendLobbyRequestTask(this.connection);
            this.sendLobbyRequestTask.Start(null, true);
        }

        /// <summary>
        /// Stop sending lobby requests.
        /// </summary>
        public void StopSendingLobbyRequests()
        {
            this.sendLobbyRequestTask.Stop();
        }

        /// <summary>
        /// Fires the <see cref="LobbyReceived"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireLobbyReceived(object sender, LobbyReceivedEventArgs args)
        {
            this.LobbyReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Firs the <see cref="OpponentMoveReceived"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireOpponentMoveReceived(object sender, MoveReceivedEventArgs args)
        {
            this.OpponentMoveReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the <see cref="MoveRequestReceived"/> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireMoveRequestReceived(object sender, EventArgs args)
        {
            this.MoveRequestReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the <see cref="InitiateBattleReceived"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireInitiateBattleReceived(object sender, EventArgs args)
        {
            this.InitiateBattleReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the <see cref="MoveReportReceived"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireMoverReportReceived(object sender, MoveReceivedEventArgs args)
        {
            this.MoveReportReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the <see cref="GameWon"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="empty">The event arguments.</param>
        protected virtual void FireGameWon(object sender, EventArgs empty)
        {
            this.GameWon?.Invoke(sender, empty);
        }

        /// <summary>
        /// Fires the <see cref="GameLost"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="empty">The event arguments.</param>
        protected virtual void FireGameLost(object sender, EventArgs empty)
        {
            this.GameLost?.Invoke(sender, empty);
        }

        /// <summary>
        /// Fires the <see cref="ConnectionFailed"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireConnectionFailed(object sender, EventArgs args)
        {
            this.ConnectionFailed?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the <see cref="ConnectionLost"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        protected virtual void FireConnectionLost(object sender, DisconnectedEventArgs e)
        {
            this.ConnectionLost?.Invoke(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Fires the challenger found event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ChallengerFoundEventArgs"/> instance containing the event data.</param>
        protected virtual void FireChallengerFound(object sender, ChallengerFoundEventArgs e)
        {
            this.ChallengerFound?.Invoke(sender, e);
        }

        /// <summary>
        /// Fires the opponent declined event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="empty">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void FireOpponentDeclined(object sender, EventArgs empty)
        {
            this.OpponentDeclined?.Invoke(sender, empty);
        }

        /// <summary>
        /// Handles the received message.
        /// </summary>
        /// <param name="sender">The sender of the MessageReceived event.</param>
        /// <param name="args">The event arguments.</param>
        private void Connection_MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            Message message = (Message)args.Message;

            switch (message.MessageType)
            {
                case MessageType.LobbyResponse:
                    this.FireLobbyReceived(this, new LobbyReceivedEventArgs((List<ClientDummy>)message.Content));
                    return;
                case MessageType.OpponentsMove:
                    this.FireOpponentMoveReceived(sender, new MoveReceivedEventArgs((Marker)message.Content));
                    return;
                case MessageType.MoveRequest:
                    this.FireMoveRequestReceived(sender, EventArgs.Empty);
                    return;
                case MessageType.JoinBattleRequest:
                    this.FireChallengerFound(sender, new ChallengerFoundEventArgs((ClientDummy)message.Content));
                    return;
                case MessageType.DeclineBattle:
                    this.FireOpponentDeclined(sender, EventArgs.Empty);
                    return;
                case MessageType.InitiateBattle:
                    this.FireInitiateBattleReceived(sender, EventArgs.Empty);
                    return;
                case MessageType.MoveReport:
                    this.FireMoverReportReceived(sender, new MoveReceivedEventArgs((Marker)message.Content));
                    return;
                case MessageType.GameLost:
                    this.FireGameLost(sender, EventArgs.Empty);
                    return;
                case MessageType.GameWon:
                    this.FireGameWon(sender, EventArgs.Empty);
                    return;
            }
        }
    }
}