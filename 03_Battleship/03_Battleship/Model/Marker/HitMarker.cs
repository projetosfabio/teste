//-----------------------------------------------------------------------
// <copyright file="HitMarker.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the HitMarker class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents a hit marker.
    /// </summary>
    /// <seealso cref="_03_Battleship.Model.Marker" />
    [Serializable]
    public class HitMarker : Marker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HitMarker"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public HitMarker(Position position) : base(position)
        {
        }
    }
}