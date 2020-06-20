//-----------------------------------------------------------------------
// <copyright file="LobbyViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the LobbyViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using System;
    using System.Windows;
    using _03_Battleship.Model;
    using Command;
    using Command.ViewChangingCommand;
    using MVVMCore;

    /// <summary>
    /// Represents the lobby view model.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewRepresentingViewModel" />
    internal class LobbyViewModel : ViewRepresentingViewModel
    {
        /// <summary>
        /// The shell.
        /// </summary>
        private ViewShellViewModel shell;

        /// <summary>
        /// A value indicating whether the modal is visible.
        /// </summary>
        private bool modalVisible;

        /// <summary>
        /// Initializes a new instance of the <see cref="LobbyViewModel"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public LobbyViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
            this.shell = (ViewShellViewModel)this.ViewShell;
            this.BattleListVM = new BattleListViewModel(this.shell.Client);
            this.shell.Client.ChallengerFound += this.Client_ChallengerFound;
            this.shell.Client.InitiateBattleReceived += this.Client_InitiateBattleReceived;
            this.shell.Client.ConnectionLost += this.Client_ConnectionLost;
            this.shell.Client.OpponentDeclined += this.Client_OpponentDeclined;
            this.Modal = new BattleFieldModalViewModel(string.Empty);
        }

        /// <summary>
        /// Gets the modal view model.
        /// </summary>
        /// <value>
        /// The modal view model.
        /// </value>
        public BattleFieldModalViewModel Modal
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the modal is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the modal is visible; otherwise, <c>false</c>.
        /// </value>
        public bool ModalVisible
        {
            get
            {
                return this.modalVisible;
            }

            set
            {
                this.modalVisible = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets the battle list view model.
        /// </summary>
        /// <value>
        /// The battle list view model.
        /// </value>
        public BattleListViewModel BattleListVM
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the new game command.
        /// </summary>
        /// <value>
        /// The new game command.
        /// </value>
        public NewGameCommand NewGameCommand => new NewGameCommand(this.shell.Client);

        /// <summary>
        /// Handles the ConnectionLost event of the Client.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Client_ConnectionLost(object sender, EventArgs e)
        {
            this.shell.Client.ConnectionLost -= this.Client_ConnectionLost;
            MessageBox.Show("Lost connection to the server.", "Connection Lost", MessageBoxButton.OK);
            this.shell.Client.Close();
            this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
        }

        /// <summary>
        /// Handles the InitiateBattleReceived event of the Client.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Client_InitiateBattleReceived(object sender, EventArgs e)
        {
            // Start a Battle - Display the battle field.
            this.ViewShell.View = new BattleFieldViewModel(this.ViewShell);
        }

        /// <summary>
        /// Handles the ChallengerFound event of the Client.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ChallengerFoundEventArgs"/> instance containing the event data.</param>
        private void Client_ChallengerFound(object sender, ChallengerFoundEventArgs e)
        {
            this.Modal.ButtonSetOK = false;
            this.Modal.ButtonSetYesNo = true;
            this.Modal.Text = "Do you accept the challenge of \n" + e.ChallengerInfo.UserName + "?";
            this.Modal.ModalCommand = new ConfirmBattleCommand(this.shell.Client);
            this.Modal.AbortCommand = new DeclineChallengeCommand(this.shell.Client, this);
            this.ModalVisible = true;
        }

        /// <summary>
        /// Handles the OpponentDeclined event of the Client.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Client_OpponentDeclined(object sender, EventArgs e)
        {
            this.Modal.ButtonSetOK = true;
            this.Modal.ButtonSetYesNo = false;
            this.Modal.Text = "The player didn't accept your request.";
            this.Modal.ModalCommand = new CloseLobbyModalCommand(this);
            this.ModalVisible = true;
        }
    }
}
