//-----------------------------------------------------------------------
// <copyright file="MessageReceiver.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MessageReceiver class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Net.Sockets;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;

    /// <summary>
    /// Represents the MessageReceiver class.
    /// </summary>
    public class MessageReceiver
    {
        /// <summary>
        /// The network stream.
        /// </summary>
        private NetworkStream networkStream;

        /// <summary>
        /// The message receiver thread.
        /// </summary>
        private Thread messageReceiverThread;

        /// <summary>
        /// The message receiver thread arguments.
        /// </summary>
        private MessageReceiverThreadArgs messageReceiverThreadArgs;

        /// <summary>
        /// The formatter.
        /// </summary>
        private BinaryFormatter formatter;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReceiver"/> class.
        /// </summary>
        /// <param name="networkStream">The network stream.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the specified value is null:
        /// networkStream - The value must not be null.
        /// </exception>
        public MessageReceiver(NetworkStream networkStream)
        {
            this.networkStream = networkStream ?? throw new ArgumentNullException(nameof(networkStream), "The value must not be null.");
            this.messageReceiverThreadArgs = new MessageReceiverThreadArgs();
            this.messageReceiverThread = new Thread(this.Worker);
            this.formatter = new BinaryFormatter();
        }

        /// <summary>
        /// Occurs when a message is received.
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            if (this.messageReceiverThread.ThreadState == ThreadState.Unstarted)
            {
                this.messageReceiverThread.Start(this.messageReceiverThreadArgs);
            }
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
        /// Works the specified data.
        /// </summary>
        /// <param name="data">The specified data.</param>
        private void Worker(object data)
        {
            MessageReceiverThreadArgs args = (MessageReceiverThreadArgs)data;

            while (!args.Stop)
            {
                ////try
                ////{

                MessageContainer messageContainer = (MessageContainer)this.formatter.Deserialize(this.networkStream);
                this.FireMessageReceived(this, new MessageReceivedEventArgs(messageContainer.Content));

                ////}
                ////catch
                ////{
                //// TODO: do something.
                ////throw;
                ////}

                ////Thread.Sleep(args.PollDelay);
            }
        }
    }
}
