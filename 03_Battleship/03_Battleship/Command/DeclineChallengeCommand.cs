//-----------------------------------------------------------------------
// <copyright file="DeclineChallengeCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the DeclineChallengeCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using Model;
    using MVVMCore;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the DeclineChallengeCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class DeclineChallengeCommand : BaseCommand
    {
        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// The lobby view model.
        /// </summary>
        private LobbyViewModel lobby;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeclineChallengeCommand"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="lobby">The lobby.</param>
        public DeclineChallengeCommand(Client client, LobbyViewModel lobby)
        {
            this.client = client;
            this.lobby = lobby;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            this.client.SendDeclineBattle();
            this.lobby.ModalVisible = false;
        }
    }
}
