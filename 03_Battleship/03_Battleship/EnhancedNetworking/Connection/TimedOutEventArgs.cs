//-----------------------------------------------------------------------
// <copyright file="TimedOutEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the TimedOutEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    /// <summary>
    /// Represents the TimedOutEventArgs class.
    /// </summary>
    /// <seealso cref="_03_Battleship.EnhancedNetworking.DisconnectedEventArgs" />
    public class TimedOutEventArgs : DisconnectedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimedOutEventArgs"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public TimedOutEventArgs(IConnection connection) : base(connection)
        {
        }
    }
}
