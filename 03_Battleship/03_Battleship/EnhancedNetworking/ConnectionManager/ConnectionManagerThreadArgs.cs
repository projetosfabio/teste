//-----------------------------------------------------------------------
// <copyright file="ConnectionManagerThreadArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ConnectionManagerThreadArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the ConnectionManagerThreadArgs class.
    /// </summary>
    /// <seealso cref="_03_Battleship.NetworkingThreadArgs" />
    public class ConnectionManagerThreadArgs : NetworkingThreadArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionManagerThreadArgs"/> class.
        /// </summary>
        /// <param name="pollDelay">The poll delay of the listener.</param>
        public ConnectionManagerThreadArgs(int pollDelay = 200) : base(pollDelay)
        {
        }
    }
}
