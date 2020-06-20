//-----------------------------------------------------------------------
// <copyright file="ConnectionArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ConnectionArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using EnhancedNetworking;

    /// <summary>
    /// Represents the ConnectionArgs class.
    /// </summary>
    public class ConnectionArgs
    {
        /// <summary>
        /// Gets or sets the state of the client.
        /// </summary>
        /// <value>
        /// The state of the client.
        /// </value>
        public ClientState ClientState
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the challenger.
        /// </summary>
        /// <value>
        /// The challenger.
        /// </value>
        public IConnection Challenger
        {
            get;
            set;
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