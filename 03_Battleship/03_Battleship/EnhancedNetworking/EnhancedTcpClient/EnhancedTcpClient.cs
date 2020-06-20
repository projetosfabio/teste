//-----------------------------------------------------------------------
// <copyright file="EnhancedTcpClient.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the EnhancedTcpClient class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    /// <summary>
    /// Represents the enhanced TCP client.
    /// </summary>
    public class EnhancedTcpClient
    {
        /// <summary>
        /// The poll delay.
        /// </summary>
        private const int PollDelay = 20;

        /// <summary>
        /// The listener thread.
        /// </summary>
        private Thread listenerThread;

        /// <summary>
        /// The arguments of the <see cref="listenerThread"/>.
        /// </summary>
        private ListenerThreadArgs listenerThreadArgs;

        /// <summary>
        /// A value indicating whether the connection is lost.
        /// </summary>
        private bool connectionLost;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedTcpClient"/> class.
        /// </summary>
        public EnhancedTcpClient()
        {
            this.listenerThread = new Thread(this.ListenerWorker);
            this.listenerThreadArgs = new ListenerThreadArgs(PollDelay);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedTcpClient"/> class.
        /// </summary>
        /// <param name="client">An instance of the <see cref="TcpClient"/> class.</param>
        public EnhancedTcpClient(TcpClient client)
        {
            this.Client = client;
            this.listenerThread = new Thread(this.ListenerWorker);
            this.listenerThreadArgs = new ListenerThreadArgs(PollDelay);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnhancedTcpClient"/> class.
        /// </summary>
        /// <param name="ipEndPoint">The IPEndPoint of the client.</param>
        public EnhancedTcpClient(IPEndPoint ipEndPoint)
        {
            this.Client = new TcpClient();
            try
            {
                this.Client.Connect(ipEndPoint);
            }
            catch
            {
                this.FireConnectionFailed(this, EventArgs.Empty);
            }

            this.listenerThread = new Thread(this.ListenerWorker);
            this.listenerThreadArgs = new ListenerThreadArgs(PollDelay);
        }

        /// <summary>
        /// The event which fires when data is received.
        /// </summary>
        public event EventHandler<DataReceivedEventArgs> DataReceived;

        /// <summary>
        /// The event which fires when the connection is lost.
        /// </summary>
        public event EventHandler<EventArgs> ConnectionLost;

        /// <summary>
        /// The event which fires when connection to the client failed.
        /// </summary>
        public event EventHandler<EventArgs> ConnectionFailed;

        /// <summary>
        /// Gets the instance of the <see cref="TcpClient"/> class.
        /// </summary>
        /// <value>An instance of the <see cref="TcpClient"/> class.</value>
        public TcpClient Client
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether a connection exists.
        /// </summary>
        /// <value>A boolean value.</value>
        public bool Connected
        {
            get
            {
                if (this.Client == null)
                {
                    return false;
                }

                return this.Client.Connected;
            }
        }

        /// <summary>
        /// Gets the network stream of the TCP client.
        /// </summary>
        /// <value>An instance of the <see cref="NetworkStream"/> class.</value>
        public NetworkStream Stream
        {
            get
            {
                return this.Client.GetStream();
            }
        }

        /// <summary>
        /// Gets the IP endpoint of the TCP client.
        /// </summary>
        /// <value>The IP endpoint of the TCP client.</value>
        public IPEndPoint IPEndPoint
        {
            get
            {
                return (IPEndPoint)this.Client.Client.RemoteEndPoint;
            }
        }

        /// <summary>
        /// Creates a connection.
        /// </summary>
        /// <param name="ipEndpoint">The IPEndPoint to connect to.</param>
        public void Connect(IPEndPoint ipEndpoint)
        {
            this.Client = new TcpClient();
            try
            {
                this.Client.Connect(ipEndpoint);
            }
            catch
            {
                this.FireConnectionFailed(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        public void Close()
        {
            this.StopListening();
            this.Client.Close();
        }

        /// <summary>
        /// Writes data to the network stream.
        /// </summary>
        /// <param name="data">The data to write.</param>
        public void Write(byte[] data)
        {
            if (!this.Client.Connected)
            {
                this.FireConnectionLost(this, EventArgs.Empty);
                return;
            }

            try
            {
                this.Stream.Write(data, 0, data.Length);
            }
            catch
            {
                this.FireConnectionLost(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Writes data to the network stream.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public void Write(string text)
        {
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(text);

            try
            {
                this.Stream.Write(buffer, 0, buffer.Length);
            }
            catch
            {
                this.FireConnectionLost(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Start listening for incoming data.
        /// </summary>
        public void StartListening()
        {
            this.listenerThreadArgs.Stop = false;

            if (this.listenerThread.ThreadState == ThreadState.Unstarted)
            {
                this.listenerThread.Start(this.listenerThreadArgs);
            }
        }

        /// <summary>
        /// Stop listening for incoming data.
        /// </summary>
        public void StopListening()
        {
            this.listenerThreadArgs.Stop = true;
        }

        /// <summary>
        /// Fires the <see cref="DataReceived"/> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireDataReceived(object sender, DataReceivedEventArgs args)
        {
            if (this.DataReceived != null)
            {
                this.DataReceived(sender, args);
            }
        }

        /// <summary>
        /// Fires the <see cref="ConnectionLost"/> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireConnectionLost(object sender, EventArgs args)
        {
            this.listenerThreadArgs.Stop = true;

            if (this.ConnectionLost != null && this.connectionLost == false)
            {
                this.connectionLost = true;
                this.ConnectionLost(sender, args);
            }
        }

        /// <summary>
        /// Fires the <see cref="ConnectionFailed"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireConnectionFailed(object sender, EventArgs args)
        {
            if (this.ConnectionFailed != null)
            {
                this.ConnectionFailed(sender, args);
            }
        }

        /// <summary>
        /// The worker method of the listener thread.
        /// </summary>
        /// <param name="data">The arguments of the thread.</param>
        private void ListenerWorker(object data)
        {
            ListenerThreadArgs args = (ListenerThreadArgs)data;
            byte[] receiveBuffer = new byte[8192];
            int receivedBytes = 0;

            while (!args.Stop)
            {
                try
                {
                    receivedBytes = this.Stream.Read(receiveBuffer, 0, receiveBuffer.Length);
                }
                catch
                {
                    this.FireConnectionLost(this, EventArgs.Empty);
                    return;
                }

                if (receivedBytes > 0)
                {
                    this.FireDataReceived(this, new DataReceivedEventArgs(receiveBuffer.Take(receivedBytes).ToArray()));
                }

                Thread.Sleep(args.PollDelay);
            }
        }
    }
}
