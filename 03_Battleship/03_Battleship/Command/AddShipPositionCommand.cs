//-----------------------------------------------------------------------
// <copyright file="AddShipPositionCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the AddShipPositionCommand class.</summary>
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
    /// Represents the AddShipPositionCommand command.
    /// </summary>
    internal class AddShipPositionCommand : BaseCommand
    {
        /// <summary>
        /// The battle field view model.
        /// </summary>
        private BattleFieldViewModel battleFieldViewModel;

        /// <summary>
        /// The battle field area view model.
        /// </summary>
        private BattleFieldAreaViewModel battleFieldArea;

        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddShipPositionCommand"/> class.
        /// </summary>
        /// <param name="battleFieldViewModel">The battle field view model.</param>
        /// <param name="battleFieldArea">The battle field area view model.</param>
        /// <param name="client">The client.</param>
        public AddShipPositionCommand(BattleFieldViewModel battleFieldViewModel, BattleFieldAreaViewModel battleFieldArea, Client client)
        {
            this.battleFieldViewModel = battleFieldViewModel;
            this.battleFieldArea = battleFieldArea;
            this.client = client;
        }

        /// <summary>
        /// Executes the <see cref="AddShipPositionCommand"/> command.
        /// </summary>
        /// <param name="parameter">Possible specified command argument.</param>
        public override void Execute(object parameter)
        {
            if (this.battleFieldArea.Ships.Count < 5 && this.battleFieldViewModel.ShipToPlace.ValidPosition)
            {
                switch (this.battleFieldViewModel.ShipToPlace.ShipType)
                {
                    case ShipType.Carrier:
                        this.battleFieldViewModel.Toolbar.CarrierEnabled = false;
                        break;
                    case ShipType.Battleship:
                        this.battleFieldViewModel.Toolbar.BattleshipEnabled = false;
                        break;
                    case ShipType.Cruiser:
                        this.battleFieldViewModel.Toolbar.CruiserEnabled = false;
                        break;
                    case ShipType.Destroyer:
                        this.battleFieldViewModel.Toolbar.DestroyerEnabled = false;
                        break;
                    case ShipType.Sub:
                        this.battleFieldViewModel.Toolbar.SubEnabled = false;
                        break;
                    case ShipType.Undefined:
                        return;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(this.battleFieldViewModel.ShipToPlace.ShipType));
                }

                Ship ship = this.battleFieldViewModel.ShipToPlace.Ship;
                this.battleFieldArea.AddShip(ship);
                this.battleFieldViewModel.Toolbar.RandomPositionsEnabled = false;
                this.battleFieldViewModel.ShipToPlace.ShipType = ShipType.Undefined;
                this.battleFieldArea.ClearHighlighted();

                if (this.battleFieldArea.Ships.Count == 5)
                {
                    this.client.SendShipPositions(this.battleFieldArea.Ships.ToList());
                    this.battleFieldViewModel.UserBattleFieldArea.DisableSquares();
                    this.battleFieldViewModel.OpponentFieldVisible = true;
                    this.battleFieldViewModel.ToolbarVisible = false;
                }
            }
        }
    }
}
