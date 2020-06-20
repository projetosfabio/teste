//-----------------------------------------------------------------------
// <copyright file="ListenerThreadArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ListenerThreadArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;

    /// <summary>
    /// Represents the ListenerThreadArgs class.
    /// </summary>
    public class ListenerThreadArgs : NetworkingThreadArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListenerThreadArgs"/> class.
        /// </summary>
        /// <param name="pollDelay">The poll delay of the listener.</param>
        public ListenerThreadArgs(int pollDelay = 200) : base(pollDelay)
        {
        }
    }
}