//-----------------------------------------------------------------------
// <copyright file="MessageReceivedEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MessageReceivedEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;

    /// <summary>
    /// Represents the MessageReceivedEventArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null:
        /// message - The value must not be null.
        /// </exception>
        public MessageReceivedEventArgs(object message)
        {
            this.Message = message ?? throw new ArgumentNullException(nameof(message), "The value must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="connection">The connection.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if either of the specified values is null:
        /// message - The value must not be null.
        /// or
        /// connection - The value must not be null.
        /// </exception>
        public MessageReceivedEventArgs(object message, IConnection connection)
        {
            this.Message = message ?? throw new ArgumentNullException(nameof(message), "The value must not be null.");
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection), "The value must not be null.");
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
        /// Gets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public object Message
        {
            get;
            private set;
        }
    }
}