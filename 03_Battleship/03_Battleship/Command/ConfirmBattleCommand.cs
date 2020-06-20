//-----------------------------------------------------------------------
// <copyright file="ConfirmBattleCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ConfirmBattleCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using Model;
    using MVVMCore;

    /// <summary>
    /// Represents the ConfirmBattleCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class ConfirmBattleCommand : BaseCommand
    {
        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfirmBattleCommand"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public ConfirmBattleCommand(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            this.client.SendConfirmBattle();
        }
    }
}
