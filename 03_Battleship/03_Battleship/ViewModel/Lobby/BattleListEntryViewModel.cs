//-----------------------------------------------------------------------
// <copyright file="BattleListEntryViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BattleListEntryViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using Command;
    using Model;

    /// <summary>
    /// Represents the BattleListEntryViewModel class.
    /// </summary>
    internal class BattleListEntryViewModel
    {
        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleListEntryViewModel"/> class.
        /// </summary>
        /// <param name="userName">The user name of the challenger.</param>
        /// <param name="ipAddress">The IP address of the challenger.</param>
        /// <param name="inGame">A value indicating whether the challenger is in game.</param>
        /// <param name="id">The identifier of the user.</param>
        /// <param name="client">The client.</param>
        public BattleListEntryViewModel(string userName, string ipAddress, bool inGame, int id, Client client)
        {
            this.UserName = userName;
            this.IPAddress = ipAddress;
            this.InGame = inGame;
            this.Id = id;
            this.client = client;
        }

        /// <summary>
        /// Gets the user name of the challenger.
        /// </summary>
        /// <value>The user name of the challenger.</value>
        public string UserName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the IP address of the challenger.
        /// </summary>
        /// <value>The IP address of the challenger.</value>
        public string IPAddress
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the challenger is in game.
        /// </summary>
        public bool InGame
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the JoinGameCommand command.
        /// </summary>
        /// <value>A command.</value>
        public JoinGameCommand JoinGameCommand => new JoinGameCommand(this.client);
    }
}