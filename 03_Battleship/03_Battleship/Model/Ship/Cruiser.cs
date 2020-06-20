//-----------------------------------------------------------------------
// <copyright file="Cruiser.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Cruiser class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the Cruiser class.
    /// </summary>
    /// <seealso cref="_03_Battleship.Model.Ship" />
    [Serializable]
    public class Cruiser : Ship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Cruiser"/> class.
        /// </summary>
        public Cruiser()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cruiser"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public Cruiser(Position position) : base(position)
        {
            this.Length = 3;
        }
    }
}