//-----------------------------------------------------------------------
// <copyright file="LobbyReceivedEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the LobbyReceivedEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the LobbyReceivedEventArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class LobbyReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LobbyReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="clientDummies">The client dummies.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null:
        /// clientDummies - The value must not be null.
        /// </exception>
        public LobbyReceivedEventArgs(List<ClientDummy> clientDummies)
        {
            this.ClientDummies = clientDummies ?? throw new ArgumentNullException(nameof(clientDummies), "The value must not be null.");
        }

        /// <summary>
        /// Gets the client dummies.
        /// </summary>
        /// <value>
        /// The client dummies.
        /// </value>
        public List<ClientDummy> ClientDummies
        {
            get;
            private set;
        }
    }
}