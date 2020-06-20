//-----------------------------------------------------------------------
// <copyright file="MessageHandler.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MessageHandler class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.EnhancedNetworking
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    /// <summary>
    /// Represents the message handler.
    /// </summary>
    public static class MessageHandler
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="enhancedTcpClient">The enhanced TCP client.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if either of the values is null:
        /// message - The value must not be null.
        /// or
        /// enhancedTCPClient - The value must not be null.
        /// </exception>
        public static void Send(object message, EnhancedTcpClient enhancedTcpClient)
        {
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message), "The value must not be null.");
            }

            if (enhancedTcpClient == null)
            {
                throw new ArgumentNullException(nameof(enhancedTcpClient), "The value must not be null.");
            }

            enhancedTcpClient.Write(Serialize(new MessageContainer(message)));
        }

        /// <summary>
        /// Reads the specified data.
        /// </summary>
        /// <param name="data">The data to read.</param>
        /// <returns>A message container.</returns>
        public static object Read(byte[] data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                try
                {
                    MessageContainer messageContainer = (MessageContainer)formatter.Deserialize(memoryStream);
                    return messageContainer.Content;
                }
                catch
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Serializes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>The serialized message.</returns>
        private static byte[] Serialize(MessageContainer message)
        {
            byte[] serialized;
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                formatter.Serialize(memoryStream, message);
                serialized = memoryStream.GetBuffer();
                return serialized;
            }
        }
    }
}