//-----------------------------------------------------------------------
// <copyright file="QuitServerModeCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the QuitServerModeCommand class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command.ViewChangingCommand
{
    using Model;
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the QuitServerModeCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewChangingCommand" />
    internal class QuitServerModeCommand : ViewChangingCommand
    {
        /// <summary>
        /// The server.
        /// </summary>
        private Server server;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuitServerModeCommand"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        /// <param name="server">The server.</param>
        public QuitServerModeCommand(ViewShellBaseViewModel viewShell, Server server) : base(viewShell)
        {
            this.server = server;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            this.server.Shutdown();
            this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
        }
    }
}
