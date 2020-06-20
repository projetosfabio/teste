//-----------------------------------------------------------------------
// <copyright file="ClientState.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ClientState enumeration.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the ClientState enumeration.
    /// </summary>
    public enum ClientState
    {
        /// <summary>
        /// The state Inactive.
        /// </summary>
        Inactive,

        /// <summary>
        /// The state InGame.
        /// </summary>
        InGame,

        /// <summary>
        /// The state WaitingForOpponent.
        /// </summary>
        WaitingForOpponent
    }
}