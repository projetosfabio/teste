//-----------------------------------------------------------------------
// <copyright file="MessageReceiverThreadArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MessageReceiverThreadArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    /// <summary>
    /// Represents the MessageReceiverThreadArgs class.
    /// </summary>
    /// <seealso cref="_03_Battleship.NetworkingThreadArgs" />
    public class MessageReceiverThreadArgs : NetworkingThreadArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageReceiverThreadArgs"/> class.
        /// </summary>
        /// <param name="pollDelay">The poll delay of the listener.</param>
        public MessageReceiverThreadArgs(int pollDelay = 200) : base(pollDelay)
        {
        }
    }
}
