//-----------------------------------------------------------------------
// <copyright file="BattleManager.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BattleManager class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using EnhancedNetworking;

    /// <summary>
    /// Represents the BattleManager class.
    /// </summary>
    public class BattleManager
    {
        /// <summary>
        /// The users in the lobby.
        /// </summary>
        private List<IConnection> usersInLobby;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleManager"/> class.
        /// </summary>
        /// <param name="usersInLobby">The users in the lobby.</param>
        public BattleManager(List<IConnection> usersInLobby)
        {
            this.Battles = new List<Battle>();
            this.usersInLobby = usersInLobby;
        }

        /// <summary>
        /// Gets the list of battles.
        /// </summary>
        /// <value>The list of battles.</value>
        public List<Battle> Battles
        {
            get;
            private set;
        }

        /// <summary>
        /// Initiates a battle.
        /// </summary>
        /// <param name="competitorA">The first competitor.</param>
        /// <param name="competitorB">The second competitor.</param>
        public void InitiateBattle(IConnection competitorA, IConnection competitorB)
        {
            ConnectionArgs argsA = (ConnectionArgs)competitorA.ConnectionData;
            ConnectionArgs argsB = (ConnectionArgs)competitorB.ConnectionData;
            argsA.ClientState = ClientState.InGame;
            argsB.ClientState = ClientState.InGame;
            Battle battle = new Battle(competitorA, competitorB);
            battle.Finished += this.Battle_Finished;
            this.Battles.Add(battle);
        }

        /// <summary>
        /// Removes the finished battle from the list.
        /// </summary>
        /// <param name="sender">The sender of the Finished event.</param>
        /// <param name="args">The event arguments.</param>
        private void Battle_Finished(object sender, FinishedArgs args)
        {
            if (this.usersInLobby.Contains(args.Loser.Connection))
            {
                this.usersInLobby.Remove(args.Loser.Connection);
            }

            if (this.usersInLobby.Contains(args.Winner.Connection))
            {
                this.usersInLobby.Remove(args.Winner.Connection);
            }

            this.Battles.Remove(args.Battle);
        }
    }
}