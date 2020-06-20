//-----------------------------------------------------------------------
// <copyright file="ShipType.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ShipType enumeration.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    /// <summary>
    /// Represents the ShipType enumeration.
    /// </summary>
    internal enum ShipType
    {
        /// <summary>
        /// The ship type undefined.
        /// </summary>
        Undefined,

        /// <summary>
        /// The ship type carrier.
        /// </summary>
        Carrier,

        /// <summary>
        /// The ship type battleship.
        /// </summary>
        Battleship,

        /// <summary>
        /// The ship type cruiser.
        /// </summary>
        Cruiser,

        /// <summary>
        /// The ship type destroyer.
        /// </summary>
        Destroyer,

        /// <summary>
        /// The ship type sub.
        /// </summary>
        Sub
    }
}
