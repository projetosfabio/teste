//-----------------------------------------------------------------------
// <copyright file="NetworkingThreadArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the NetworkingThreadArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship
{
    using System;

    /// <summary>
    /// Represents the NetworkingThreadArgs class.
    /// </summary>
    public abstract class NetworkingThreadArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkingThreadArgs"/> class.
        /// </summary>
        /// <param name="pollDelay">The poll delay of the listener.</param>
        public NetworkingThreadArgs(int pollDelay = 200)
        {
            if (pollDelay <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pollDelay), "The value must be greater than zero.");
            }

            this.PollDelay = pollDelay;
            this.Stop = false;
        }

        /// <summary>
        /// Gets or sets the poll delay of the listener thread.
        /// </summary>
        /// <value>An integer value.</value>
        public int PollDelay
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the listen should stop watching.
        /// </summary>
        /// <value>A boolean value.</value>
        public bool Stop
        {
            get;
            set;
        }
    }
}
