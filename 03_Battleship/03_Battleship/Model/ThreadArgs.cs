//-----------------------------------------------------------------------
// <copyright file="ThreadArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ThreadArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    /// <summary>
    /// Represents the ThreadArgs class.
    /// </summary>
    public abstract class ThreadArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadArgs"/> class.
        /// </summary>
        public ThreadArgs()
        {
            this.PollDelay = 200;
            this.Stop = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThreadArgs"/> class.
        /// </summary>
        /// <param name="pollDelay">The poll delay.</param>
        public ThreadArgs(int pollDelay)
        {
            this.PollDelay = pollDelay;
            this.Stop = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ThreadArgs"/> is stop.
        /// </summary>
        /// <value>
        ///   <c>true</c> if stop; otherwise, <c>false</c>.
        /// </value>
        public bool Stop
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the poll delay.
        /// </summary>
        /// <value>
        /// The poll delay.
        /// </value>
        public int PollDelay
        {
            get;
            private set;
        }
    }
}