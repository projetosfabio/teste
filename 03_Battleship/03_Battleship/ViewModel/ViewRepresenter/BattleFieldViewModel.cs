//-----------------------------------------------------------------------
// <copyright file="BattleFieldViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BattleFieldViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel.ViewRepresenter
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Command;
    using Command.ViewChangingCommand;
    using Model;
    using MVVMCore;

    /// <summary>
    /// Represents the BattleFieldViewModel class.
    /// </summary>
    internal class BattleFieldViewModel : ViewRepresentingViewModel
    {
        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// A value indicating whether the set modal is visible.
        /// </summary>
        private bool modalVisible;

        /// <summary>
        /// The modal.
        /// </summary>
        private BattleFieldModalViewModel modal;

        /// <summary>
        /// A value indicating whether the toolbar is visible.
        /// </summary>
        private bool toolbarVisible;

        /// <summary>
        /// A value indicating whether the field of the opponent is visible.
        /// </summary>
        private bool opponentFieldVisible;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleFieldViewModel"/> class.
        /// </summary>
        /// <param name="viewShell">The shell of the view model.</param>
        public BattleFieldViewModel(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
            ViewShellViewModel viewShellVM = (ViewShellViewModel)viewShell;
            this.client = viewShellVM.Client;

            this.client.StopSendingLobbyRequests();
            this.ShipPositionsSent = false;

            this.ShipToPlace = new ShipToPlaceViewModel();

            this.UserBattleFieldArea = new BattleFieldAreaViewModel(10, 10);
            this.UserBattleFieldArea.SetSquareCommands(new AddShipPositionCommand(this, this.UserBattleFieldArea, this.client));
            this.UserBattleFieldArea.HighlightSquaresCommand = new HighlightSquaresCommand(this.UserBattleFieldArea, this);
            this.UserBattleFieldArea.EnableSquares();

            this.OpponentBattleFieldArea = new BattleFieldAreaViewModel(10, 10);
            SendMoveCommand sendMoveCommand = new SendMoveCommand(viewShellVM.Client, this.OpponentBattleFieldArea);
            this.OpponentBattleFieldArea.SetSquareCommands(sendMoveCommand);

            this.Toolbar = new ToolbarViewModel();
            this.ToolbarVisible = true;

            this.client.MoveRequestReceived += this.Client_MoveRequestReceived;
            this.client.OpponentMoveReceived += this.Client_OpponentMoveReceived;
            this.client.MoveReportReceived += this.Client_MoveReportReceived;
            this.client.GameLost += this.Client_GameLost;
            this.client.GameWon += this.Client_GameWon;
        }

        /// <summary>
        /// Gets or sets the ship to place.
        /// </summary>
        public ShipToPlaceViewModel ShipToPlace
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the ship positions are sent.
        /// </summary>
        /// <value>A boolean value.</value>
        public bool ShipPositionsSent
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the battle field of the user.
        /// </summary>
        /// <value>The battle field of the user.</value>
        public BattleFieldAreaViewModel UserBattleFieldArea
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the battle field of the opponent.
        /// </summary>
        /// <value>The battle field of the opponent.</value>
        public BattleFieldAreaViewModel OpponentBattleFieldArea
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the field of the opponent is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the field of the opponent is visible; otherwise, <c>false</c>.
        /// </value>
        public bool OpponentFieldVisible
        {
            get
            {
                return this.opponentFieldVisible;
            }

            set
            {
                this.opponentFieldVisible = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets the toolbar view model.
        /// </summary>
        /// <value>The toolbar view model.</value>
        public ToolbarViewModel Toolbar
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the toolbar is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the toolbar is visible; otherwise, <c>false</c>.
        /// </value>
        public bool ToolbarVisible
        {
            get
            {
                return this.toolbarVisible;
            }

            set
            {
                this.toolbarVisible = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the set modal is visible.
        /// </summary>
        /// <value>A boolean value.</value>
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
        /// Gets or sets the modal for notifications.
        /// </summary>
        /// <value>A modal for notifications.</value>
        public BattleFieldModalViewModel Modal
        {
            get
            {
                return this.modal;
            }

            set
            {
                this.modal = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets the SelectShipCommand command.
        /// </summary>
        /// <value>A command.</value>
        public SelectShipCommand SelectShipCommand => new SelectShipCommand(this);

        /// <summary>
        /// Gets the RotateShipCommand command.
        /// </summary>
        /// <value>A command.</value>
        public RotateShipCommand RotateShipCommand => new RotateShipCommand(this);

        /// <summary>
        /// Gets the ShowMainMenuCommand command.
        /// </summary>
        /// <value>A command.</value>
        public ShowMainMenuCommand ShowMainMenuCommand => new ShowMainMenuCommand(this.ViewShell);

        /// <summary>
        /// Gets the RandomShipPositionsCommand command.
        /// </summary>
        /// <value>A command.</value>
        public RandomPositionsCommand RandomPositionsCommand => new RandomPositionsCommand(this.UserBattleFieldArea, this, this.client);

        /// <summary>
        /// Enable the squares when a move request is received.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Client_MoveRequestReceived(object sender, EventArgs e)
        {
            this.OpponentBattleFieldArea.EnableSquares();
        }

        /// <summary>
        /// Adds a marker to the user field when the move of the opponent is received.
        /// </summary>
        /// <param name="sender">The sender of the MoveReceived event.</param>
        /// <param name="e">The event arguments.</param>
        private void Client_OpponentMoveReceived(object sender, MoveReceivedEventArgs e)
        {
            this.UserBattleFieldArea.AddMarker(e.Marker);
        }

        /// <summary>
        /// Adds a marker to the opponent field when the move information is received.
        /// </summary>
        /// <param name="sender">The sender of the MoveReceived event.</param>
        /// <param name="e">The event arguments.</param>
        private void Client_MoveReportReceived(object sender, MoveReceivedEventArgs e)
        {
            this.OpponentBattleFieldArea.AddMarker(e.Marker);
        }

        /// <summary>
        /// Closes the connection and shows information that the game is won.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Client_GameWon(object sender, EventArgs e)
        {
            this.client.Close();
            this.Modal = new BattleFieldModalViewModel("You Won!");
            this.ModalVisible = true;
        }

        /// <summary>
        /// Closes the connection and shows information that the game is lost.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Client_GameLost(object sender, EventArgs e)
        {
            this.client.Close();
            this.Modal = new BattleFieldModalViewModel("You Lost!");
            this.ModalVisible = true;
        }
    }
}
