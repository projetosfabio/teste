//-----------------------------------------------------------------------
// <copyright file="FinishedArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the FinishedArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents the FinishedArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class FinishedArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinishedArgs"/> class.
        /// </summary>
        /// <param name="battle">The battle.</param>
        /// <param name="winner">The winner.</param>
        /// <param name="loser">The loser.</param>
        /// <exception cref="ArgumentNullException">
        /// Battle - The value must not be null.
        /// or
        /// winner - The value must note be null.
        /// or
        /// winner - The value must note be null.
        /// </exception>
        public FinishedArgs(Battle battle, Competitor winner, Competitor loser)
        {
            this.Battle = battle ?? throw new ArgumentNullException(nameof(battle), "The value must not be null.");
            this.Winner = winner ?? throw new ArgumentNullException(nameof(winner), "The value must note be null.");
            this.Loser = loser ?? throw new ArgumentNullException(nameof(winner), "The value must note be null.");
        }

        /// <summary>
        /// Gets the battle.
        /// </summary>
        /// <value>
        /// The battle.
        /// </value>
        public Battle Battle
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the winner.
        /// </summary>
        /// <value>
        /// The winner.
        /// </value>
        public Competitor Winner
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the loser.
        /// </summary>
        /// <value>
        /// The loser.
        /// </value>
        public Competitor Loser
        {
            get;
            private set;
        }
    }
}