//-----------------------------------------------------------------------
// <copyright file="Timer.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Timer class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Threading;

    /// <summary>
    /// Represents a timer.
    /// </summary>
    public class Timer
    {
        /// <summary>
        /// The thread of the timer.
        /// </summary>
        private Thread timerThread;

        /// <summary>
        /// The arguments of the timer thread.
        /// </summary>
        private TimerThreadArgs timerThreadArgs;

        /// <summary>
        /// Initializes a new instance of the <see cref="Timer"/> class.
        /// </summary>
        /// <param name="limit">The limit of the timer.</param>
        /// <param name="loop">A value indicating if the timer is running in a loop.</param>
        public Timer(int limit, bool loop = true)
        {
            this.timerThreadArgs = new TimerThreadArgs(limit, loop);
            this.timerThread = new Thread(this.WatchTime);
        }

        /// <summary>
        /// The event which fires when the limit is reached.
        /// </summary>
        public event EventHandler<LimitReachedEventArgs> LimitReached;

        /// <summary>
        /// Gets a value indicating whether the timer is running in a loop.
        /// </summary>
        /// <value>A boolean value.</value>
        public bool Loop
        {
            get
            {
                return this.timerThreadArgs.Loop;
            }
        }

        /// <summary>
        /// Starts the timer.
        /// </summary>
        public void Start()
        {
            if (this.timerThread.ThreadState == ThreadState.Unstarted)
            {
                this.timerThread.Start(this.timerThreadArgs);
            }
        }

        /// <summary>
        /// Stops the timer.
        /// </summary>
        public void Stop()
        {
            this.timerThreadArgs.Stop = true;
        }

        /// <summary>
        /// Fires the <see cref="LimitReached"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireLimitReached(object sender, LimitReachedEventArgs args)
        {
            if (this.LimitReached != null)
            {
                this.LimitReached(sender, args);
            }
        }

        /// <summary>
        /// Watches if the limit is reached. This is the "worker" method of the thread.
        /// </summary>
        /// <param name="timerThreadArgs">The arguments of the timer thread.</param>
        private void WatchTime(object timerThreadArgs)
        {
            TimerThreadArgs args = (TimerThreadArgs)timerThreadArgs;

            do
            {
                Thread.Sleep(args.Limit);
                this.FireLimitReached(this, new LimitReachedEventArgs());
            }
            while (!args.Stop && args.Loop);
        }
    }
}