//-----------------------------------------------------------------------
// <copyright file="SendMoveCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the SendMoveCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using System;
    using System.Linq;
    using Model;
    using MVVMCore;
    using ViewModel;

    /// <summary>
    /// Represents the SendMoveCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class SendMoveCommand : BaseCommand
    {
        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// The battle field area view model.
        /// </summary>
        private BattleFieldAreaViewModel battleFieldAreaViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendMoveCommand"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="battleFieldAreaViewModel">The battle field area view model.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if either of the value is null:
        /// client - The value must not be null.
        /// or
        /// battleFieldAreaViewModel - The value must not be null.
        /// </exception>
        public SendMoveCommand(Client client, BattleFieldAreaViewModel battleFieldAreaViewModel)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client), "The value must not be null.");
            this.battleFieldAreaViewModel = battleFieldAreaViewModel ?? throw new ArgumentNullException(nameof(battleFieldAreaViewModel), "The value must not be null.");
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            Position position = (Position)parameter;

            if (this.battleFieldAreaViewModel.Squares.Where(s => s.Position.Equals(position)).First().State == SquareState.Undamaged)
            {
                this.client.SendMove(position);
                this.battleFieldAreaViewModel.DisableSquares();
            }
        }
    }
}
