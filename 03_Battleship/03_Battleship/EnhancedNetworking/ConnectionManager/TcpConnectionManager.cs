//-----------------------------------------------------------------------
// <copyright file="TcpConnectionManager.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the TcpConnectionManager class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------

namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    /// <summary>
    /// Represents a TCP connection manager.
    /// </summary>
    /// <seealso cref="_03_Battleship.EnhancedNetworking.IConnectionManager" />
    public class TcpConnectionManager : IConnectionManager
    {
        /// <summary>
        /// The connection manager thread.
        /// </summary>
        private Thread connectionManagerThread;

        /// <summary>
        /// The connection manager thread arguments.
        /// </summary>
        private ConnectionManagerThreadArgs connectionManagerThreadArgs;

        /// <summary>
        /// The TCP listener.
        /// </summary>
        private TcpListener tcpListener;

        /// <summary>
        /// Initializes a new instance of the <see cref="TcpConnectionManager"/> class.
        /// </summary>
        /// <param name="tcpListener">The TCP listener.</param>
        /// <param name="timeoutLimit">The timeout limit.</param>
        public TcpConnectionManager(TcpListener tcpListener, int timeoutLimit)
        {
            this.tcpListener = tcpListener;
            this.connectionManagerThread = new Thread(this.Worker);
            this.connectionManagerThreadArgs = new ConnectionManagerThreadArgs();
            this.Connections = new List<IConnection>();
            this.TimeoutLimit = timeoutLimit;
        }

        /// <summary>
        /// The event which fires when a connection is accepted.
        /// </summary>
        public event EventHandler<ClientAcceptedEventArgs> ConnectionAccepted;

        /// <summary>
        /// The event which fires when a message is received.
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// The event which fires when raw data is received.
        /// </summary>
        public event EventHandler<DataReceivedEventArgs> RawDataReceived;

        /// <summary>
        /// Gets or sets the connections.
        /// </summary>
        /// <value>
        /// The connections.
        /// </value>
        public List<IConnection> Connections
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the timeout limit.
        /// </summary>
        /// <value>
        /// The timeout limit.
        /// </value>
        public int TimeoutLimit
        {
            get;
            private set;
        }

        /// <summary>
        /// Starts the Connection Manger.
        /// </summary>
        public void Start()
        {
            this.tcpListener.Start();

            if (this.connectionManagerThread.ThreadState == ThreadState.Unstarted)
            {
                this.connectionManagerThread.Start(this.connectionManagerThreadArgs);
            }
        }

        /// <summary>
        /// Stops the Connection Manger.
        /// </summary>
        public void Stop()
        {
            this.connectionManagerThreadArgs.Stop = true;
            this.tcpListener.Stop();
            for (int i = 0; i < this.Connections.Count; i++)
            {
                this.Connections[i].Close();
            }
        }

        /// <summary>
        /// Works the specified data.
        /// </summary>
        /// <param name="data">The specified data.</param>
        protected void Worker(object data)
        {
            ConnectionManagerThreadArgs args = (ConnectionManagerThreadArgs)data;

            while (!args.Stop)
            {
                try
                {
                    EnhancedTcpClient client = new EnhancedTcpClient(this.tcpListener.AcceptTcpClient());

                    if (client.Connected)
                    {
                        TcpConnection connection = new TcpConnection(client);
                        connection.MessageReceived += this.FireMessageReceived;
                        connection.RawDataReceived += this.FireRawDataReceived;
                        connection.ConnectionLost += this.Connection_Disconnected;
                        connection.TimedOut += this.Connection_Disconnected;
                        connection.TimeoutLimit = this.TimeoutLimit;
                        this.Connections.Add(connection);
                        this.FireClientAccepted(this, new ClientAcceptedEventArgs(connection));
                        connection.StartListening();
                    }
                }
                catch (SocketException)
                {
                    // Exception occurs on closing the connection manger.
                }

                Thread.Sleep(args.PollDelay);
            }
        }

        /// <summary>
        /// Fires the client accepted event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="ClientAcceptedEventArgs"/> instance containing the event data.</param>
        protected virtual void FireClientAccepted(object sender, ClientAcceptedEventArgs args)
        {
            this.ConnectionAccepted?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the raw data received event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="DataReceivedEventArgs"/> instance containing the event data.</param>
        protected virtual void FireRawDataReceived(object sender, DataReceivedEventArgs args)
        {
            this.RawDataReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Fires the message received event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="MessageReceivedEventArgs"/> instance containing the event data.</param>
        protected virtual void FireMessageReceived(object sender, MessageReceivedEventArgs args)
        {
            this.MessageReceived?.Invoke(sender, args);
        }

        /// <summary>
        /// Handles the Disconnected event of the Connection.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="DisconnectedEventArgs"/> instance containing the event data.</param>
        private void Connection_Disconnected(object sender, DisconnectedEventArgs args)
        {
            args.Connection.Close();
            this.Connections.Remove(args.Connection);
        }
    }
}
