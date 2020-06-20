//-----------------------------------------------------------------------
// <copyright file="Marker.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Marker class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents a marker.
    /// </summary>
    [Serializable]
    public abstract class Marker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Marker"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null:
        /// position - The value must not be null.
        /// </exception>
        public Marker(Position position)
        {
            this.Position = position ?? throw new ArgumentNullException(nameof(position), "The value must not be null.");
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Position Position
        {
            get;
            private set;
        }
    }
}