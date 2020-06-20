//-----------------------------------------------------------------------
// <copyright file="MissedMarker.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MissedMarker class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents a missed marker.
    /// </summary>
    /// <seealso cref="_03_Battleship.Model.Marker" />
    [Serializable]
    public class MissedMarker : Marker
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MissedMarker"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public MissedMarker(Position position) : base(position)
        {
        }
    }
}