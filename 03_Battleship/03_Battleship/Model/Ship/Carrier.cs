//-----------------------------------------------------------------------
// <copyright file="Carrier.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Carrier class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the Carrier class.
    /// </summary>
    [Serializable]
    public class Carrier : Ship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Carrier"/> class.
        /// </summary>
        public Carrier()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Carrier"/> class.
        /// </summary>
        /// <param name="position">The position of the carrier.</param>
        public Carrier(Position position) : base(position)
        {
            this.Length = 5;
        }
    }
}