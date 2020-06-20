//-----------------------------------------------------------------------
// <copyright file="TimerThreadArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the TimerThreadArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    /// <summary>
    /// Represents the TimerThreadArgs class.
    /// </summary>
    public class TimerThreadArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerThreadArgs"/> class.
        /// </summary>
        /// <param name="limit">The limit of the timer.</param>
        /// <param name="loop">A value indicating whether the timer runs in a loop.</param>
        public TimerThreadArgs(int limit, bool loop)
        {
            this.Limit = limit;
            this.Loop = loop;
            this.Stop = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the timer should stop.
        /// </summary>
        /// <value>A boolean value.</value>
        public bool Stop
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the limit of the timer.
        /// </summary>
        /// <value>An integer value.</value>
        public int Limit
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the timer should run in a loop.
        /// </summary>
        /// <value>A boolean value.</value>
        public bool Loop
        {
            get;
            private set;
        }
    }
}