//-----------------------------------------------------------------------
// <copyright file="TcpConnection.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the TcpConnection class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Net;

    /// <summary>
    /// Represents the TCP connection class.
    /// </summary>
    public class TcpConnection : IConnection
    {
        /// <summary>
        /// A value indicating whether a message was received in time to prevent a time out.
        /// </summary>
        private bool messageInTime;

        /// <summary>
        /// The timer to check for time out.
        /// </summary>
        private Timer timeOutTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpConnection"/> class.
        /// </summary>
        public TcpConnection()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpConnection"/> class.
        /// </summary>
        /// <param name="enhancedTcpClient">An enhanced TCP client.</param>
        public TcpConnection(EnhancedTcpClient enhancedTcpClient)
        {
            this.EnhancedTcpClient = enhancedTcpClient;
            this.EnhancedTcpClient.ConnectionFailed += this.FireConnectionFailed;
            this.EnhancedTcpClient.ConnectionLost += this.FireConnectionLost;
        }

        /// <summary>
        /// The event which fires when a message is received.
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// The event which fires when raw data is received.
        /// </summary>
        public event EventHandler<DataReceivedEventArgs> RawDataReceived;

        /// <summary>
        /// The event which fires when the connection is lost.
        /// </summary>
        public event EventHandler<DisconnectedEventArgs> ConnectionLost;

        /// <summary>
        /// The event which fires when the connection failed.
        /// </summary>
        public event EventHandler<EventArgs> ConnectionFailed;

        /// <summary>
        /// The event which fires on time out.
        /// </summary>
        public event EventHandler<TimedOutEventArgs> TimedOut;

        /// <summary>
        /// Gets or sets the enhanced TCP client of the connection.
        /// </summary>
        /// <value>The enhanced TCP client of the connection.</value>
        public EnhancedTcpClient EnhancedTcpClient
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the IP Address of the connection.
        /// </summary>
        /// <value>The IP Address of the connection.</value>
        public string IPAddress
        {
            get
            {
                return this.EnhancedTcpClient.IPEndPoint.Address.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the connection arguments.
        /// </summary>
        /// <value>Possible specified connection arguments.</value>
        public object ConnectionData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the timeout limit.
        /// </summary>
        /// <value>
        /// The timeout limit.
        /// </value>
        public int TimeoutLimit
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="IConnection" /> is connected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if connected; otherwise, <c>false</c>.
        /// </value>
        public bool Connected
        {
            get
            {
                return this.EnhancedTcpClient.Connected;
            }
        }

        /// <summary>
        /// Starts listening for messages.
        /// </summary>
        public void StartListening()
        {
            // TODO: add raw data.
            this.EnhancedTcpClient.DataReceived += this.EnhancedTcpClient_DataReceived;
            this.EnhancedTcpClient.StartListening();
            this.InitializeTimeout();
        }

        /// <summary>
        /// Connects to the end point.
        /// </summary>
        /// <param name="ipEndpoint">The endpoint.</param>
        public void Connect(IPEndPoint ipEndpoint)
        {
            this.EnhancedTcpClient = new EnhancedTcpClient(ipEndpoint);
            this.EnhancedTcpClient.ConnectionFailed += this.FireConnectionFailed;
            this.EnhancedTcpClient.ConnectionLost += this.FireConnectionLost;
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void Close()
        {
            if (this.EnhancedTcpClient != null)
            {
                this.EnhancedTcpClient.Close();
            }

            if (this.timeOutTimer != null)
            {
                this.timeOutTimer.Stop();
            }
        }

        /// <summary>
        /// Sends a specified message.
        /// </summary>
        /// <param name="message">The specified message.</param>
        public void SendMessage(object message)
        {
            try
            {
                MessageHandler.Send(message, this.EnhancedTcpClient);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Sends raw data.
        /// </summary>
        /// <param name="data">The specified data.</param>
        public void SendRawData(byte[] data)
        {
            this.EnhancedTcpClient.Write(data);
        }

        /// <summary>
        /// Fires the <see cref="RawDataReceived"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireRawDataReceived(object sender, DataReceivedEventArgs args)
        {
            this.RawDataReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the <see cref="MessageReceived"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            this.MessageReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the <see cref="ConnectionLost"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireConnectionLost(object sender, EventArgs args)
        {
            this.ConnectionLost?.Invoke(sender, new DisconnectedEventArgs(this));
        }

        /// <summary>
        /// Fires the timed out event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="TimedOutEventArgs"/> instance containing the event data.</param>
        protected virtual void FireTimedOut(object sender, TimedOutEventArgs args)
        {
            this.TimedOut?.Invoke(sender, args);
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
        /// Initializes the handling of timeouts.
        /// </summary>
        private void InitializeTimeout()
        {
            if (this.TimeoutLimit > 0)
            {
                this.messageInTime = true;
                this.timeOutTimer = new Timer(this.TimeoutLimit);
                this.timeOutTimer.LimitReached += this.TimeOutTimer_LimitReached;
                this.timeOutTimer.Start();
            }
        }

        /// <summary>
        /// Handles the DataReceived event of the enhanced TCP client.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="DataReceivedEventArgs"/> instance containing the event data.</param>
        private void EnhancedTcpClient_DataReceived(object sender, DataReceivedEventArgs args)
        {
            this.messageInTime = true;
            object message = MessageHandler.Read(args.RawData);
            this.FireMessageReceived(this, new MessageReceivedEventArgs(message, this));
        }

        /// <summary>
        /// Handles the LimitReached event of the TimeOutTimer.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LimitReachedEventArgs"/> instance containing the event data.</param>
        private void TimeOutTimer_LimitReached(object sender, LimitReachedEventArgs e)
        {
            if (!this.messageInTime)
            {
                this.FireTimedOut(this, new TimedOutEventArgs(this));
            }
            else
            {
                // Reset the flag.
                this.messageInTime = false;
            }
        }
    }
}
