//-----------------------------------------------------------------------
// <copyright file="ClientDummy.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ClientDummy class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the ClientDummy class.
    /// </summary>
    [Serializable]
    public class ClientDummy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClientDummy"/> class.
        /// </summary>
        /// <param name="userName">The user name.</param>
        /// <param name="ipAdress">The IP Address.</param>
        /// <param name="inGame">A value indicating whether the player is in game.</param>
        /// <param name="id">The identifier of the user.</param>
        public ClientDummy(string userName, string ipAdress, bool inGame, int id)
        {
            this.UserName = userName;
            this.IPAddress = ipAdress ?? throw new ArgumentNullException("The value must not be null.");
            this.InGame = inGame;
            this.Id = id;
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the IP Address.
        /// </summary>
        /// <value>
        /// The IP Address.
        /// </value>
        public string IPAddress
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a value indicating whether the player is in game.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the player is in game; otherwise, <c>false</c>.
        /// </value>
        public bool InGame
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id
        {
            get;
            set;
        }
    }
}
