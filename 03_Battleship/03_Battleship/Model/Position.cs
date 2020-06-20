//-----------------------------------------------------------------------
// <copyright file="Position.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Position class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship
{
    using System;

    /// <summary>
    /// Represents a position.
    /// </summary>
    [Serializable]
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">The horizontal offset.</param>
        /// <param name="y">The vertical offset.</param>
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets the horizontal offset.
        /// </summary>
        /// <value>
        /// The horizontal offset.
        /// </value>
        public int X
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the vertical offset.
        /// </summary>
        /// <value>
        /// The vertical offset.
        /// </value>
        public int Y
        {
            get;
            private set;
        }

        /// <summary>
        /// Checks if the positions are equal.
        /// </summary>
        /// <param name="other">The other position.</param>
        /// <returns>A value indicating whether the positions are equal.</returns>
        public bool Equals(Position other)
        {
            if (this.X != other.X || this.Y != other.Y)
            {
                return false;
            }

            return true;
        }
    }
}