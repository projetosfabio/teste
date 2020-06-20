//-----------------------------------------------------------------------
// <copyright file="Battle.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Battle class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using EnhancedNetworking;

    /// <summary>
    /// Represents a battle.
    /// </summary>
    public class Battle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Battle"/> class.
        /// </summary>
        /// <param name="competitorA">The first competitor.</param>
        /// <param name="competitorB">The second competitor.</param>
        public Battle(IConnection competitorA, IConnection competitorB)
        {
            if (competitorA == null)
            {
                throw new ArgumentNullException(nameof(competitorA), "The value must not be null.");
            }

            if (competitorB == null)
            {
                throw new ArgumentNullException(nameof(competitorB), "The value must not be null.");
            }

            this.CompetitorA = new Competitor(competitorA);
            this.CompetitorB = new Competitor(competitorB);

            this.CompetitorA.ShipPositionsReceived += this.Competitor_ShipPositionsReceived;
            this.CompetitorB.ShipPositionsReceived += this.Competitor_ShipPositionsReceived;

            this.CompetitorA.LeftGame += this.Competitor_LeftGame;
            this.CompetitorB.LeftGame += this.Competitor_LeftGame;

            try
            {
                this.CompetitorA.SendInitiateBattle();
                this.CompetitorB.SendInitiateBattle();
            }
            catch
            {
                // TODO Error Handling
                throw;
            }
        }

        /// <summary>
        /// An event which wires when the game is finished.
        /// </summary>
        public event EventHandler<FinishedArgs> Finished;

        /// <summary>
        /// Gets the first competitor.
        /// </summary>
        /// <value>The first competitor.</value>
        public Competitor CompetitorA
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the second competitor.
        /// </summary>
        /// <value>The second competitor.</value>
        public Competitor CompetitorB
        {
            get;
            private set;
        }

        /// <summary>
        /// Fires the <see cref="Finished"/> event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="args">The event arguments.</param>
        protected virtual void FireFinished(object sender, FinishedArgs args)
        {
            this.CompetitorA.Connection.Close();
            this.CompetitorB.Connection.Close();

            if (this.Finished != null)
            {
                this.Finished(sender, args);
            }
        }

        /// <summary>
        /// Handles the received ship positions. Initiates shooting if positions of both players are received.
        /// </summary>
        /// <param name="sender">The sender of the ShipPositionsReceived event.</param>
        /// <param name="args">The event arguments.</param>
        private void Competitor_ShipPositionsReceived(object sender, ShipPositionsReceivedEventArgs args)
        {
            Competitor competitor = (Competitor)sender;
            competitor.BattleField.Ships = args.Ships;
            competitor.ShipPositionsReceived -= this.Competitor_ShipPositionsReceived;
            competitor.PositionsReady = true;

            if (this.CompetitorB.PositionsReady && this.CompetitorA.PositionsReady)
            {
                this.InitiateShooting();
            }
        }

        /// <summary>
        /// Initiates the actual game. Sends the move request to the first player and listens for the response.
        /// </summary>
        private void InitiateShooting()
        {
            this.CompetitorA.SendMoveRequest();
            this.CompetitorA.MoveReceived += this.Competitor_MoveReceived;
        }

        /// <summary>
        /// Evaluates a received move and and sends the information if if it hit something.
        /// Sends a new MoveRequest to the other competitor.
        /// </summary>
        /// <param name="sender">The sender of the MoveReceived event.</param>
        /// <param name="args">The event arguments.</param>
        private void Competitor_MoveReceived(object sender, MoveReceivedEventArgs args)
        {
            Competitor competitor = (Competitor)sender;
            Competitor opponent = this.Opponent(competitor);

            // Stop listening for incoming moves until the next request to this competitor is sent. 
            competitor.MoveReceived -= this.Competitor_MoveReceived;

            Marker marker;
            bool validMove;

            validMove = opponent.BattleField.AddMarker(args.Move, out marker);

            if (!validMove)
            {
                // Someone cheated.
                opponent.SendGameWon();
                competitor.Connection.Close();
                this.FireFinished(this, new FinishedArgs(this, opponent, competitor));
                return;
            }

            competitor.SendMoveReport(marker);
            opponent.SendOpponentsMove(marker);

            if (opponent.BattleField.Ships.Count == 0)
            {
                // Game finished.
                competitor.SendGameWon();
                opponent.SendGameLost();
                this.FireFinished(this, new FinishedArgs(this, competitor, opponent));
            }
            else
            {
                opponent.SendMoveRequest();
                opponent.MoveReceived += this.Competitor_MoveReceived;
            }
        }

        /// <summary>
        /// Handles the LeftGame event of the Competitor class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Competitor_LeftGame(object sender, EventArgs e)
        {
            Competitor quitter = (Competitor)sender;
            quitter.LeftGame -= this.Competitor_LeftGame;
            Competitor other = this.Opponent(quitter);
            other.SendGameWon();
            this.FireFinished(this, new FinishedArgs(this, other, quitter));
        }

        /// <summary>
        /// Returns the opponent.
        /// </summary>
        /// <param name="competitor">The competitor.</param>
        /// <returns>The opponent.</returns>
        private Competitor Opponent(Competitor competitor)
        {
            if (competitor == this.CompetitorA)
            {
                return this.CompetitorB;
            }

            return this.CompetitorA;
        }
    }
}