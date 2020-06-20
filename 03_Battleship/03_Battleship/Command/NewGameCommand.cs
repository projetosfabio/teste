//-----------------------------------------------------------------------
// <copyright file="NewGameCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the NewGameCommand class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command
{
    using Model;
    using MVVMCore;

    /// <summary>
    /// Represents the NewGameCommand class.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    internal class NewGameCommand : BaseCommand
    {
        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewGameCommand"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public NewGameCommand(Client client)
        {
            this.client = client;
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            this.client.SendNewBattleRequest();
        }
    }
}
