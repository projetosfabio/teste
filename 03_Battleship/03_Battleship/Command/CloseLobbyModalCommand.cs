//-----------------------------------------------------------------------
// <copyright file="CloseLobbyModalCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the CloseLobbyModalCommand class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the CloseLobbyCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class CloseLobbyModalCommand : BaseCommand
    {
        /// <summary>
        /// The lobby view model.
        /// </summary>
        private LobbyViewModel lobby;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloseLobbyModalCommand"/> class.
        /// </summary>
        /// <param name="lobby">The lobby view model..</param>
        public CloseLobbyModalCommand(LobbyViewModel lobby)
        {
            this.lobby = lobby;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            this.lobby.ModalVisible = false;
        }
    }
}
