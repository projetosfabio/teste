//-----------------------------------------------------------------------
// <copyright file="Message.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the Message class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;

    /// <summary>
    /// Represents a message.
    /// </summary>
    [Serializable]
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="content">The content.</param>
        public Message(MessageType messageType, object content = null)
        {
            this.MessageType = messageType;
            this.Content = content;
        }

        /// <summary>
        /// Gets the type of the message.
        /// </summary>
        /// <value>
        /// The type of the message.
        /// </value>
        public MessageType MessageType
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public object Content
        {
            get;
            private set;
        }
    }
}