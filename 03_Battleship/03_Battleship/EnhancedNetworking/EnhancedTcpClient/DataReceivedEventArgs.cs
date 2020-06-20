//-----------------------------------------------------------------------
// <copyright file="DataReceivedEventArgs.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the DataReceivedEventArgs class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents the DataReceivedEventArgs class.
    /// </summary>
    public class DataReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataReceivedEventArgs"/> class.
        /// </summary>
        /// <param name="rawData">The received bytes.</param>
        public DataReceivedEventArgs(byte[] rawData)
        {
            this.RawData = rawData;
        }

        /// <summary>
        /// Gets or sets the received bytes.
        /// </summary>
        /// <value>An array of bytes.</value>
        public byte[] RawData
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the received text.
        /// </summary>
        /// <value>The received text.</value>
        public string Text
        {
            get
            {
                return System.Text.Encoding.UTF8.GetString(this.RawData);
            }
        }
    }
}