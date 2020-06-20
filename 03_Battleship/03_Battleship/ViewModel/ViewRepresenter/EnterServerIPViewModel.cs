//-----------------------------------------------------------------------
// <copyright file="EnterServerIPViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the EnterServerIPViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using _03_Battleship.EnhancedNetworking;
    using _03_Battleship.Model;
    using Command.ViewChangingCommand;
    using MVVMCore;

    /// <summary>
    /// Represents the EnterServerIPViewModel class.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewRepresentingViewModel" />
    internal class EnterServerIPViewModel : ViewRepresentingViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnterServerIPViewModel"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public EnterServerIPViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
            ViewShellViewModel shell = (ViewShellViewModel)viewShell;
            shell.Client = new Client(new TcpConnection());
        }

        /// <summary>
        /// Gets the connect to server command.
        /// </summary>
        /// <value>
        /// The connect to server command.
        /// </value>
        public ConnectToServerCommand ConnectToServerCommand => new ConnectToServerCommand(this.ViewShell);
    }
}
