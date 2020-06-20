//-----------------------------------------------------------------------
// <copyright file="MainMenuViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MainMenuViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using Command.ViewChangingCommand;
    using MVVMCore;

    /// <summary>
    /// Represents the MainMenuViewModel class.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewRepresentingViewModel" />
    internal class MainMenuViewModel : ViewRepresentingViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainMenuViewModel"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public MainMenuViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }

        /// <summary>
        /// Gets the start server mode command.
        /// </summary>
        /// <value>
        /// The start server mode command.
        /// </value>
        public StartServerModeCommand StartServerModeCommand => new StartServerModeCommand(this.ViewShell);

        /// <summary>
        /// Gets the ShowEnterServerIPCommand command.
        /// </summary>
        /// <value>
        /// The ShowEnterServerIPCommand command.
        /// </value>
        public ShowEnterServerIPCommand ShowEnterServerIPCommand => new ShowEnterServerIPCommand(this.ViewShell);
    }
}
