//-----------------------------------------------------------------------
// <copyright file="ServerModeViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ServerModeViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using Command.ViewChangingCommand;
    using EnhancedNetworking;
    using Model;
    using MVVMCore;

    /// <summary>
    /// Represents the server mode view model.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewRepresentingViewModel" />
    internal class ServerModeViewModel : ViewRepresentingViewModel
    {
        /// <summary>
        /// The server.
        /// </summary>
        private Server server;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerModeViewModel"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public ServerModeViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
            ViewShellViewModel shell = (ViewShellViewModel)this.ViewShell;

            TcpConnectionManager tcpConnectionManager = new TcpConnectionManager(shell.TcpListener, 1600);
            this.server = new Server(tcpConnectionManager);
            shell.Server = this.server;
            this.server.Start();
        }

        /// <summary>
        /// Gets the quit server mode command.
        /// </summary>
        /// <value>
        /// The quit server mode command.
        /// </value>
        public QuitServerModeCommand QuitServerModeCommand => new QuitServerModeCommand(this.ViewShell, this.server);
    }
}
