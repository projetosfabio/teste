//-----------------------------------------------------------------------
// <copyright file="SendLobbyRequestTask.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the SendLobbyRequest network task.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using EnhancedNetworking;

    /// <summary>
    /// Represents the task to send lobby requests.
    /// </summary>
    /// <seealso cref="_03_Battleship.EnhancedNetworking.NetworkTask" />
    internal class SendLobbyRequestTask : NetworkTask
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SendLobbyRequestTask"/> class.
        /// </summary>
        /// <param name="connection">The connection of the network task.</param>
        /// <param name="intervalTime">The interval time.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null:
        /// connection - The value must not be null.
        /// </exception>
        public SendLobbyRequestTask(IConnection connection, int intervalTime = 1000) : base(connection, intervalTime)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection), "The value must not be null.");
        }

        /// <summary>
        /// Executes the network task.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected override void Execute(object parameter)
        {
            this.Connection.SendMessage(new Message(MessageType.LobbyRequest));
        }
    }
}
