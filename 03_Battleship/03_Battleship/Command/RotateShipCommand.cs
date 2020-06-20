//-----------------------------------------------------------------------
// <copyright file="RotateShipCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the RotateShipCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using Model;
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the RotateShipCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class RotateShipCommand : BaseCommand
    {
        /// <summary>
        /// The battle field view model.
        /// </summary>
        private BattleFieldViewModel battleFieldViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="RotateShipCommand"/> class.
        /// </summary>
        /// <param name="battleFieldViewModel">The battle field view model.</param>
        public RotateShipCommand(BattleFieldViewModel battleFieldViewModel)
        {
            this.battleFieldViewModel = battleFieldViewModel;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            if (this.battleFieldViewModel.ShipToPlace.ShipOrientation == Orientation.Horizontal)
            {
                this.battleFieldViewModel.ShipToPlace.ShipOrientation = Orientation.Vertical;
            }
            else
            {
                this.battleFieldViewModel.ShipToPlace.ShipOrientation = Orientation.Horizontal;
            }
        }
    }
}
