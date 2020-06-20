//-----------------------------------------------------------------------
// <copyright file="LimitReachedEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the LimitReachedEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;

    /// <summary>
    /// Represents the LimitReachedEventArgs class.
    /// </summary>
    public class LimitReachedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LimitReachedEventArgs"/> class.
        /// </summary>
        public LimitReachedEventArgs()
        {
            this.Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        /// <value>The timestamp.</value>
        public DateTime Timestamp
        {
            get;
            private set;
        }
    }
}