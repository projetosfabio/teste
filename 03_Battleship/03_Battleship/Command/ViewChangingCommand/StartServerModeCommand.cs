//-----------------------------------------------------------------------
// <copyright file="StartServerModeCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the StartServerModeCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command.ViewChangingCommand
{
    using System.Windows;
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the StartServerModeCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewChangingCommand" />
    internal class StartServerModeCommand : ViewChangingCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartServerModeCommand"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public StartServerModeCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            try
            {
                this.ViewShell.View = new ServerModeViewModel(this.ViewShell);
            }
            catch
            {
                MessageBox.Show("Couldn't create a server. Be aware that you can only have one server per machine running.", "Error", MessageBoxButton.OK);
                this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
            }
        }
    }
}
