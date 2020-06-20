//-----------------------------------------------------------------------
// <copyright file="Battleship.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Battleship class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents a battle ship.
    /// </summary>
    [Serializable]
    public class Battleship : Ship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Battleship"/> class.
        /// </summary>
        public Battleship()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Battleship"/> class.
        /// </summary>
        /// <param name="position">The position of the ship.</param>
        public Battleship(Position position) : base(position)
        {
            this.Length = 4;
        }
    }
}