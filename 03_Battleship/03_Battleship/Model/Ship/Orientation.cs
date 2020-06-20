//-----------------------------------------------------------------------
// <copyright file="Orientation.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Orientation class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents an orientation.
    /// </summary>
    [Serializable]
    public enum Orientation
    {
        /// <summary>
        /// The orientation horizontal.
        /// </summary>
        Horizontal,

        /// <summary>
        /// The orientation vertical.
        /// </summary>
        Vertical
    }
}