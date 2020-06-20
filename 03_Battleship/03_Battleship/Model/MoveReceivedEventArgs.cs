//-----------------------------------------------------------------------
// <copyright file="MoveReceivedEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MoveReceivedEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents the MoveReceivedEventArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class MoveReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MoveReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null:
        /// position - The value must not be null.
        /// </exception>
        public MoveReceivedEventArgs(Position position)
        {
            this.Move = position ?? throw new ArgumentNullException(nameof(position), "The value must not be null.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoveReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="marker">The marker.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null.
        /// marker - The value must not be null.
        /// </exception>
        public MoveReceivedEventArgs(Marker marker)
        {
            this.Marker = marker ?? throw new ArgumentNullException(nameof(marker), "The value must not be null.");
        }

        /// <summary>
        /// Gets the marker.
        /// </summary>
        /// <value>
        /// The marker.
        /// </value>
        public Marker Marker
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the received move.
        /// </summary>
        /// <value>
        /// The received move.
        /// </value>
        public Position Move
        {
            get;
            private set;
        }
    }
}