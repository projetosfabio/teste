//-----------------------------------------------------------------------
// <copyright file="JoinGameCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the JoinGameCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using Model;
    using MVVMCore;

    /// <summary>
    /// Represents the join game command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class JoinGameCommand : BaseCommand
    {
        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinGameCommand"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public JoinGameCommand(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            int id = (int)parameter;
            this.client.SendJoinBattleRequest(id);
        }
    }
}
