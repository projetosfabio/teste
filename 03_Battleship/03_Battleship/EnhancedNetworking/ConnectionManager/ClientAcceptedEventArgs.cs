//-----------------------------------------------------------------------
// <copyright file="ClientAcceptedEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ClientAcceptedEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;

    /// <summary>
    /// Represents the ClientAcceptedEventArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ClientAcceptedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientAcceptedEventArgs"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public ClientAcceptedEventArgs(IConnection connection)
        {
            this.Connection = connection;
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
    }
}