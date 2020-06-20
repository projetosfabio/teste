//-----------------------------------------------------------------------
// <copyright file="ConnectToServerCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ConnectToServerCommand class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command.ViewChangingCommand
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using Model;
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the ConnectToServerCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewChangingCommand" />
    internal class ConnectToServerCommand : ViewChangingCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectToServerCommand"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public ConnectToServerCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            ViewShellViewModel shell = (ViewShellViewModel)this.ViewShell;
            string ip = (string)parameter;

            try
            {
                shell.Client.ServerIP = IPAddress.Parse(ip);
                shell.Client.Connect();
            }
            catch
            {
                MessageBox.Show("The entered IP Address is either invalid or the server is down!", "Failed to connect.", MessageBoxButton.OK);
                shell.View = new MainMenuViewModel(shell);
                return;
            }

            shell.View = new LobbyViewModel(shell);
        }
    }
}
