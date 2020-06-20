//-----------------------------------------------------------------------
// <copyright file="DisconnectedEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the DisconnectedEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;

    /// <summary>
    /// Represents the DisconnectedEventArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class DisconnectedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisconnectedEventArgs"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <exception cref="ArgumentNullException">Is thrown if the specified value is null: connection - The value must not be null.</exception>
        public DisconnectedEventArgs(IConnection connection)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection), "The value must not be null.");
        }

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public IConnection Connection
        {
            get;
            protected set;
        }
    }
}