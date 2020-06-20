//-----------------------------------------------------------------------
// <copyright file="IConnectionManager.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the IConnectionManager interface.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the IConnectionManager interface.
    /// </summary>
    public interface IConnectionManager
    {
        /// <summary>
        /// The event which fires when a connection is accepted.
        /// </summary>
        event EventHandler<ClientAcceptedEventArgs> ConnectionAccepted;

        /// <summary>
        /// The event which fires when a message is received.
        /// </summary>
        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// The event which fires when raw data is received.
        /// </summary>
        event EventHandler<DataReceivedEventArgs> RawDataReceived;

        /// <summary>
        /// Gets the connections.
        /// </summary>
        /// <value>
        /// The connections.
        /// </value>
        List<IConnection> Connections { get; }

        /// <summary>
        /// Starts the Connection Manger.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the Connection Manger.
        /// </summary>
        void Stop();
    }
}