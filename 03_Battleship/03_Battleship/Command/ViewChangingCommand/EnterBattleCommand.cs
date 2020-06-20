//-----------------------------------------------------------------------
// <copyright file="EnterBattleCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the EnterBattleCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command.ViewChangingCommand
{
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the enter battle command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewChangingCommand" />
    internal class EnterBattleCommand : ViewChangingCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterBattleCommand"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public EnterBattleCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            this.ViewShell.View = new BattleFieldViewModel(this.ViewShell);
        }
    }
}
