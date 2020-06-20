//-----------------------------------------------------------------------
// <copyright file="Destroyer.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Destroyer class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the Destroyer class.
    /// </summary>
    /// <seealso cref="_03_Battleship.Model.Ship" />
    [Serializable]
    public class Destroyer : Ship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Destroyer"/> class.
        /// </summary>
        public Destroyer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Destroyer"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public Destroyer(Position position) : base(position)
        {
            this.Length = 2;
        }
    }
}