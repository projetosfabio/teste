//-----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the MainWindowViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using System.Net;
    using System.Net.Sockets;
    using ViewRepresenter;

    /// <summary>
    /// Represents the MainWindowViewModel class.
    /// </summary>
    internal class MainWindowViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        public MainWindowViewModel()
        {
            this.TcpListener = new TcpListener(IPAddress.Any, 1337);
            this.ViewShell = new ViewShellViewModel(this.TcpListener);
            this.ViewShell.View = new MainMenuViewModel(this.ViewShell);
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
        /// Gets the view shell.
        /// </summary>
        /// <value>
        /// The view shell.
        /// </value>
        public ViewShellViewModel ViewShell
        {
            get;
            private set;
        }
    }
}
