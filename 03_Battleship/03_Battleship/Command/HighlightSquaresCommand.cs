//-----------------------------------------------------------------------
// <copyright file="HighlightSquaresCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the HighlightSquaresCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model;
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the HighlightSquaresCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class HighlightSquaresCommand : BaseCommand
    {
        /// <summary>
        /// The battle field area view model.
        /// </summary>
        private BattleFieldAreaViewModel battleFieldAreaViewModel;

        /// <summary>
        /// The battle field view model.
        /// </summary>
        private BattleFieldViewModel battleFieldViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="HighlightSquaresCommand"/> class.
        /// </summary>
        /// <param name="battleFieldAreaViewModel">The battle field area view model.</param>
        /// <param name="battleFieldViewModel">The battle field view model.</param>
        public HighlightSquaresCommand(BattleFieldAreaViewModel battleFieldAreaViewModel, BattleFieldViewModel battleFieldViewModel)
        {
            this.battleFieldAreaViewModel = battleFieldAreaViewModel;
            this.battleFieldViewModel = battleFieldViewModel;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        /// <exception cref="ArgumentOutOfRangeException">If the ShipType is undefined.</exception>
        public override void Execute(object parameter)
        {
            if (this.battleFieldViewModel.ShipToPlace.ShipType == ShipType.Undefined)
            {
                return;
            }

            Position position = (Position)parameter;
            Ship ship;
            switch (this.battleFieldViewModel.ShipToPlace.ShipType)
            {
                case ShipType.Battleship:
                    ship = new Battleship(position);
                    break;
                case ShipType.Carrier:
                    ship = new Carrier(position);
                    break;
                case ShipType.Cruiser:
                    ship = new Cruiser(position);
                    break;
                case ShipType.Destroyer:
                    ship = new Destroyer(position);
                    break;
                case ShipType.Sub:
                    ship = new Sub(position);
                    break;
                default: throw new ArgumentOutOfRangeException(nameof(this.battleFieldViewModel.ShipToPlace.ShipType));
            }

            ship.Orientation = this.battleFieldViewModel.ShipToPlace.ShipOrientation;
            this.battleFieldViewModel.ShipToPlace.Ship = ship;
            this.battleFieldAreaViewModel.ClearHighlighted();
            bool validPosition = this.battleFieldAreaViewModel.HighlightSquares(ship);

            if (!validPosition)
            {
                this.battleFieldViewModel.ShipToPlace.ValidPosition = false;
            }
            else
            {
                this.battleFieldViewModel.ShipToPlace.ValidPosition = true;
            }
        }
    }
}
