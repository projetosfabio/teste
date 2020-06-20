//-----------------------------------------------------------------------
// <copyright file="Competitor.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Competitor class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EnhancedNetworking;

    /// <summary>
    /// Represents the Competitor class.
    /// </summary>
    public class Competitor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Competitor"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <exception cref="ArgumentNullException">Connection - The value must not be null.</exception>
        public Competitor(IConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection), "The value must not be null.");
            this.Connection.MessageReceived += this.Connection_MoveReceived;
            this.Connection.ConnectionLost += this.FireLeftGame;
            this.Connection.TimedOut += this.FireLeftGame;
            this.BattleField = new BattleField();
        }

        /// <summary>
        /// Occurs when ships positions are received.
        /// </summary>
        public event EventHandler<ShipPositionsReceivedEventArgs> ShipPositionsReceived;

        /// <summary>
        /// Occurs when a move is received.
        /// </summary>
        public event EventHandler<MoveReceivedEventArgs> MoveReceived;

        /// <summary>
        /// Occurs when competitor left the game.
        /// </summary>
        public event EventHandler<EventArgs> LeftGame;

        /// <summary>
        /// Gets the battle field.
        /// </summary>
        /// <value>
        /// The battle field.
        /// </value>
        public BattleField BattleField
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public IConnection Connection
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the positions are ready..
        /// </summary>
        /// <value>
        ///   <c>true</c> if the positions are ready; otherwise, <c>false</c>.
        /// </value>
        public bool PositionsReady
        {
            get;
            set;
        }

        /// <summary>
        /// Sends the initiate battle message to the client.
        /// </summary>
        public void SendInitiateBattle()
        {
            this.Connection.SendMessage(new Message(MessageType.InitiateBattle));
        }

        /// <summary>
        /// Sends the move request to the client.
        /// </summary>
        public void SendMoveRequest()
        {
            this.Connection.SendMessage(new Message(MessageType.MoveRequest));
        }

        /// <summary>
        /// Sends the opponents move to the client.
        /// </summary>
        /// <param name="marker">The marker.</param>
        /// <exception cref="ArgumentNullException">Marker - The value must not be null.</exception>
        public void SendOpponentsMove(Marker marker)
        {
            if (marker == null)
            {
                throw new ArgumentNullException(nameof(marker), "The value must not be null.");
            }

            this.Connection.SendMessage(new Message(MessageType.OpponentsMove, marker));
        }

        /// <summary>
        /// Sends the move report to the client.
        /// </summary>
        /// <param name="marker">The marker.</param>
        /// <exception cref="ArgumentNullException">Marker - The value must not be null.</exception>
        public void SendMoveReport(Marker marker)
        {
            if (marker == null)
            {
                throw new ArgumentNullException(nameof(marker), "The value must not be null.");
            }

            this.Connection.SendMessage(new Message(MessageType.MoveReport, marker));
        }

        /// <summary>
        /// Sends the game lost message.
        /// </summary>
        public void SendGameLost()
        {
            this.Connection.SendMessage(new Message(MessageType.GameLost));
        }

        /// <summary>
        /// Sends the game won message to the client.
        /// </summary>
        public void SendGameWon()
        {
            this.Connection.SendMessage(new Message(MessageType.GameWon));
        }

        /// <summary>
        /// Fires the ship positions received event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="ShipPositionsReceivedEventArgs"/> instance containing the event data.</param>
        protected virtual void FireShipPositionsReceived(object sender, ShipPositionsReceivedEventArgs args)
        {
            if (this.ShipPositionsReceived != null)
            {
                this.ShipPositionsReceived(sender, args);
            }
        }

        /// <summary>
        /// Fires the move received event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="MoveReceivedEventArgs"/> instance containing the event data.</param>
        protected virtual void FireMoveReceived(object sender, MoveReceivedEventArgs args)
        {
            if (this.MoveReceived != null)
            {
                this.MoveReceived(sender, args);
            }
        }

        /// <summary>
        /// Fires the left game event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void FireLeftGame(object sender, EventArgs e)
        {
            this.LeftGame?.Invoke(this, e);
        }

        /// <summary>
        /// Handles the MoveReceived event of the Connection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MessageReceivedEventArgs"/> instance containing the event data.</param>
        private void Connection_MoveReceived(object sender, MessageReceivedEventArgs e)
        {
            Message message = (Message)e.Message;

            if (message.MessageType == MessageType.MoveResponse)
            {
                Position position = (Position)message.Content;
                this.FireMoveReceived(this, new MoveReceivedEventArgs(position));
                return;
            }

            if (message.MessageType == MessageType.ShipPositions)
            {
                List<Ship> positions = (List<Ship>)message.Content;
                this.FireShipPositionsReceived(this, new ShipPositionsReceivedEventArgs(positions));
            }
        }
    }
}