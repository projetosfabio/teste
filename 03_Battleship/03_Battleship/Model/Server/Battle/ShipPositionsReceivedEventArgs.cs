//-----------------------------------------------------------------------
// <copyright file="ShipPositionsReceivedEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ShipPositionsReceivedEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the ShipPositionsReceivedEventArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ShipPositionsReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipPositionsReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="ships">The ships.</param>
        /// <exception cref="ArgumentNullException">The value must not be null.</exception>
        public ShipPositionsReceivedEventArgs(List<Ship> ships)
        {
            this.Ships = ships ?? throw new ArgumentNullException("The value must not be null.");
        }

        /// <summary>
        /// Gets the received ships.
        /// </summary>
        /// <value>
        /// The received ships.
        /// </value>
        public List<Ship> Ships
        {
            get;
            private set;
        }
    }
}