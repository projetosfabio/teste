//-----------------------------------------------------------------------
// <copyright file="MessageContainer.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MessageContainer class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;

    /// <summary>
    /// Represents a message container.
    /// </summary>
    [Serializable]
    public class MessageContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageContainer"/> class.
        /// </summary>
        /// <param name="content">The content of the message.</param>
        public MessageContainer(object content = null)
        {
            this.Content = content;
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public object Content
        {
            get;
            protected set;
        }
    }
}