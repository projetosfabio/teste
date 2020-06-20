//-----------------------------------------------------------------------
// <copyright file="BattleReadyEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BattleReadyEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using EnhancedNetworking;

    /// <summary>
    /// Represents the BattleReadyEventArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class BattleReadyEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BattleReadyEventArgs"/> class.
        /// </summary>
        /// <param name="competitorA">The competitor A.</param>
        /// <param name="competitorB">The competitor B.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if ..
        /// competitorA - The value must not be null.
        /// or
        /// competitorB - The value must not be null.
        /// </exception>
        public BattleReadyEventArgs(IConnection competitorA, IConnection competitorB)
        {
            this.CompetitorA = competitorA ?? throw new ArgumentNullException(nameof(competitorA), "The value must not be null.");
            this.CompetitorB = competitorB ?? throw new ArgumentNullException(nameof(competitorB), "The value must not be null.");
        }

        /// <summary>
        /// Gets the competitor A.
        /// </summary>
        /// <value>
        /// The competitor A.
        /// </value>
        public IConnection CompetitorA
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the competitor B.
        /// </summary>
        /// <value>
        /// The competitor B.
        /// </value>
        public IConnection CompetitorB
        {
            get;
            private set;
        }
    }
}