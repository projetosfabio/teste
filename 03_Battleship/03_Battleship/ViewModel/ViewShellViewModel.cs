//-----------------------------------------------------------------------
// <copyright file="ViewShellViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ViewShellViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using System.Net.Sockets;
    using Model;
    using MVVMCore;

    /// <summary>
    /// Represents the ViewShellViewModel class.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewShellBaseViewModel" />
    internal class ViewShellViewModel : ViewShellBaseViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewShellViewModel"/> class.
        /// </summary>
        /// <param name="tcpListener">The TCP listener.</param>
        public ViewShellViewModel(TcpListener tcpListener)
        {
            this.TcpListener = tcpListener;
        }

        /// <summary>
        /// Gets the TCP listener.
        /// </summary>
        /// <value>
        /// The TCP listener.
        /// </value>
        public TcpListener TcpListener
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        public Server Server
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the client.
        /// </summary>
        /// <value>
        /// The client.
        /// </value>
        public Client Client
        {
            get;
            set;
        }
    }
}
