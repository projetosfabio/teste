//-----------------------------------------------------------------------
// <copyright file="IConnection.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the IConnection interface.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Net;

    /// <summary>
    /// Represents a connection.
    /// </summary>
    public interface IConnection
    {
        /// <summary>
        /// Occurs when creating a connection failed.
        /// </summary>
        event EventHandler<EventArgs> ConnectionFailed;

        /// <summary>
        /// Occurs when the connection is lost.
        /// </summary>
        event EventHandler<DisconnectedEventArgs> ConnectionLost;

        /// <summary>
        /// Occurs when the client timed out.
        /// </summary>
        event EventHandler<TimedOutEventArgs> TimedOut;

        /// <summary>
        /// Occurs when a message is received.
        /// </summary>
        event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// Occurs when raw data is received.
        /// </summary>
        event EventHandler<DataReceivedEventArgs> RawDataReceived;

        /// <summary>
        /// Gets the IP Address.
        /// </summary>
        /// <value>
        /// The IP Address.
        /// </value>
        string IPAddress { get; }

        /// <summary>
        /// Gets or sets the connection data.
        /// </summary>
        /// <value>
        /// The connection data.
        /// </value>
        object ConnectionData { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IConnection"/> is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if connected; otherwise, <c>false</c>.
        /// </value>
        bool Connected { get; }

        /// <summary>
        /// Connects the specified IP end point.
        /// </summary>
        /// <param name="ipEndPoint">The IP end point.</param>
        void Connect(IPEndPoint ipEndPoint);

        /// <summary>
        /// Starts listening.
        /// </summary>
        void StartListening();

        /// <summary>
        /// Closes this instance.
        /// </summary>
        void Close();

        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void SendMessage(object message);

        /// <summary>
        /// Sends the raw data.
        /// </summary>
        /// <param name="data">The raw data.</param>
        void SendRawData(byte[] data);
    }
}