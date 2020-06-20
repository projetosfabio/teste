//-----------------------------------------------------------------------
// <copyright file="NetworkTask.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the NetworkTask class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Threading;

    /// <summary>
    /// Represents a network task.
    /// </summary>
    public abstract class NetworkTask
    {
        /// <summary>
        /// The network task thread.
        /// </summary>
        private Thread networkTaskThread;

        /// <summary>
        /// The network task thread arguments.
        /// </summary>
        private NetworkTaskThreadArgs networkTaskThreadArgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkTask"/> class.
        /// </summary>
        /// <param name="connection">The connection of the network task.</param>
        /// <param name="intervalTime">The interval time.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null:
        /// connection - The value must not be null.
        /// </exception>
        public NetworkTask(IConnection connection, int intervalTime = 1000)
        {
            this.Connection = connection ?? throw new ArgumentNullException(nameof(connection), "The value must not be null.");
            this.networkTaskThread = new Thread(this.Worker);
            this.networkTaskThreadArgs = new NetworkTaskThreadArgs(intervalTime);
        }

        /// <summary>
        /// Gets or sets the connection of the network task.
        /// </summary>
        /// <value>
        /// The connection of the network task.
        /// </value>
        protected IConnection Connection
        {
            get;
            set;
        }

        /// <summary>
        /// Starts the network task.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <param name="repeat">If set to <c>true</c> the task repeats within the specified interval time.</param>
        public void Start(object parameter, bool repeat)
        {
            if (!repeat)
            {
                this.Execute(parameter);
                return;
            }

            if (this.networkTaskThread.ThreadState == ThreadState.Unstarted)
            {
                this.networkTaskThreadArgs.NetworkTaskParameter = parameter;
                this.networkTaskThread.Start(this.networkTaskThreadArgs);
            }
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            this.networkTaskThreadArgs.Stop = true;
        }

        /// <summary>
        /// Executes the network task.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected abstract void Execute(object parameter);

        /// <summary>
        /// Works the specified data.
        /// </summary>
        /// <param name="data">The specified data.</param>
        private void Worker(object data)
        {
            NetworkTaskThreadArgs args = (NetworkTaskThreadArgs)data;

            while (!args.Stop)
            {
                this.Execute(args.NetworkTaskParameter);
                Thread.Sleep(args.PollDelay);
            }
        }
    }
}
