//-----------------------------------------------------------------------
// <copyright file="NetworkTaskThreadArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the NetworkTaskThreadArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    /// <summary>
    /// Represents the NetworkTaskThreadArgs class.
    /// </summary>
    /// <seealso cref="_03_Battleship.NetworkingThreadArgs" />
    public class NetworkTaskThreadArgs : NetworkingThreadArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NetworkTaskThreadArgs"/> class.
        /// </summary>
        /// <param name="pollDelay">The poll delay of the listener.</param>
        public NetworkTaskThreadArgs(int pollDelay) : base(pollDelay)
        {
        }

        /// <summary>
        /// Gets or sets the network task parameter.
        /// </summary>
        /// <value>
        /// The network task parameter.
        /// </value>
        public object NetworkTaskParameter
        {
            get;
            set;
        }
    }
}
