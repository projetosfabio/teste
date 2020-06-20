//-----------------------------------------------------------------------
// <copyright file="SelectShipCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the SelectShipCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the SelectShipCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class SelectShipCommand : BaseCommand
    {
        /// <summary>
        /// The battle field view model.
        /// </summary>
        private BattleFieldViewModel battleFieldViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectShipCommand"/> class.
        /// </summary>
        /// <param name="battleFieldViewModel">The battle field view model.</param>
        public SelectShipCommand(BattleFieldViewModel battleFieldViewModel)
        {
            this.battleFieldViewModel = battleFieldViewModel;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            ShipType type = (ShipType)parameter;
            this.battleFieldViewModel.ShipToPlace.ShipType = type;
        }
    }
}
