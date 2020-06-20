//-----------------------------------------------------------------------
// <copyright file="RandomPositionsCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the RandomPositionsCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using System;
    using Model;
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the RandomPositionsCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class RandomPositionsCommand : BaseCommand
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
        /// The add ship position command.
        /// </summary>
        private AddShipPositionCommand addShipPositionCommand;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomPositionsCommand"/> class.
        /// </summary>
        /// <param name="battleFieldAreaViewModel">The battle field area view model.</param>
        /// <param name="battleFieldViewModel">The battle field view model.</param>
        /// <param name="client">The client.</param>
        public RandomPositionsCommand(BattleFieldAreaViewModel battleFieldAreaViewModel, BattleFieldViewModel battleFieldViewModel, Client client)
        {
            this.battleFieldAreaViewModel = battleFieldAreaViewModel;
            this.battleFieldViewModel = battleFieldViewModel;
            this.addShipPositionCommand = new AddShipPositionCommand(this.battleFieldViewModel, this.battleFieldAreaViewModel, client);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            ShipType[] shipTypes = new ShipType[]
            {
                ShipType.Battleship,
                ShipType.Carrier,
                ShipType.Cruiser,
                ShipType.Destroyer,
                ShipType.Sub
            };

            Random rand = new Random();

            for (int i = 0; i < shipTypes.Length; i++)
            {
                Position randPosition = new Position(0, 0);
                this.battleFieldViewModel.ShipToPlace.ValidPosition = false;

                while (!this.battleFieldViewModel.ShipToPlace.ValidPosition)
                {
                    int x = rand.Next(0, this.battleFieldAreaViewModel.Width);
                    int y = rand.Next(0, this.battleFieldAreaViewModel.Height);
                    randPosition = new Position(x, y);
                    Array orientations = Enum.GetValues(typeof(Orientation));
                    Orientation randOrientation = (Orientation)orientations.GetValue(rand.Next(orientations.Length));
                    this.battleFieldViewModel.ShipToPlace.ShipOrientation = randOrientation;
                    this.battleFieldViewModel.ShipToPlace.ShipType = shipTypes[i];
                    HighlightSquaresCommand cmd = new HighlightSquaresCommand(this.battleFieldAreaViewModel, this.battleFieldViewModel);
                    cmd.Execute(randPosition);
                }

                this.addShipPositionCommand.Execute(randPosition);
            }
        }
    }
}
