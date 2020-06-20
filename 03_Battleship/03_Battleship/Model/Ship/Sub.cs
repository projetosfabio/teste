//-----------------------------------------------------------------------
// <copyright file="Sub.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Sub command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents the Sub class.
    /// </summary>
    /// <seealso cref="_03_Battleship.Model.Ship" />
    [Serializable]
    public class Sub : Ship
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sub"/> class.
        /// </summary>
        public Sub()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sub"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        public Sub(Position position) : base(position)
        {
            this.Length = 1;
        }
    }
}