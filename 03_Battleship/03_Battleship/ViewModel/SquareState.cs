//-----------------------------------------------------------------------
// <copyright file="SquareState.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the SquareState enumeration.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    /// <summary>
    /// Represents the SquareState enumeration.
    /// </summary>
    public enum SquareState
    {
        /// <summary>
        /// The square state undamaged.
        /// </summary>
        Undamaged,

        /// <summary>
        /// The square state missed.
        /// </summary>
        Missed,

        /// <summary>
        /// The square state hit.
        /// </summary>
        Hit,

        /// <summary>
        /// The square state highlighted.
        /// </summary>
        Highlighted,

        /// <summary>
        /// The square state highlighted as wrong.
        /// </summary>
        HightlightedAsWrong
    }
}
