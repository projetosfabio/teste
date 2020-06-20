//-----------------------------------------------------------------------
// <copyright file="ShowMainMenuCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ShowMainMenuCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command.ViewChangingCommand
{
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the ShowMainMenuCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewChangingCommand" />
    internal class ShowMainMenuCommand : ViewChangingCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowMainMenuCommand"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public ShowMainMenuCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
        }
    }
}
