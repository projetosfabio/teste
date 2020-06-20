//-----------------------------------------------------------------------
// <copyright file="Ship.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Ship class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents a ship.
    /// </summary>
    [Serializable]
    public abstract class Ship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        public Ship()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ship"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null:
        /// position - The value must not be null.
        /// </exception>
        public Ship(Position position)
        {
            this.Position = position ?? throw new ArgumentNullException(nameof(position), "The value must not be null.");
        }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets or sets the damage counter.
        /// </summary>
        /// <value>
        /// The damage counter.
        /// </value>
        public int DamageCounter
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Position Position
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the orientation.
        /// </summary>
        /// <value>
        /// The orientation.
        /// </value>
        public Orientation Orientation
        {
            get;
            set;
        }
    }
}