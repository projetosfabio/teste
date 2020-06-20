//-----------------------------------------------------------------------
// <copyright file="ChallengerFoundEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ChallengerFoundEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents the ChallengerFoundEventArgs class.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class ChallengerFoundEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChallengerFoundEventArgs"/> class.
        /// </summary>
        /// <param name="challengerInfo">The challenger information.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if the specified value is null:
        /// challengerInfo - The value must not be null.
        /// </exception>
        public ChallengerFoundEventArgs(ClientDummy challengerInfo)
        {
            this.ChallengerInfo = challengerInfo ?? throw new ArgumentNullException(nameof(challengerInfo), "The value must not be null.");
        }

        /// <summary>
        /// Gets the challenger information.
        /// </summary>
        /// <value>
        /// The challenger information.
        /// </value>
        public ClientDummy ChallengerInfo
        {
            get;
            private set;
        }
    }
}
