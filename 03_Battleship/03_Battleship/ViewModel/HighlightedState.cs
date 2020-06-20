//-----------------------------------------------------------------------
// <copyright file="HighlightedState.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the HighlightedState enumeration.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    /// <summary>
    /// Represents the HighlightedState enumeration.
    /// </summary>
    public enum HighlightedState
    {
        /// <summary>
        /// The state not highlighted.
        /// </summary>
        NotHighlighted,

        /// <summary>
        /// The state highlighted.
        /// </summary>
        Highlighted,

        /// <summary>
        /// The state highlighted as wrong.
        /// </summary>
        HighlightedAsWrong
    }
}
