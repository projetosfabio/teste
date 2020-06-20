//-----------------------------------------------------------------------
// <copyright file="BattleListViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BattleListViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    using _03_Battleship.Model;
    using MVVMCore;

    /// <summary>
    /// Represents the BattleListViewModel class.
    /// </summary>
    internal class BattleListViewModel : NotifyingViewModel
    {
        /// <summary>
        /// The client.
        /// </summary>
        private Client client;

        /// <summary>
        /// The list of challengers.
        /// </summary>
        private ObservableCollection<BattleListEntryViewModel> battleList;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleListViewModel"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        public BattleListViewModel(Client client)
        {
            this.BattleList = new ObservableCollection<BattleListEntryViewModel>();
            this.client = client;
            this.client.LobbyReceived += this.Client_LobbyReceived;
            this.client.StartSendingLobbyRequests();
        }

        /// <summary>
        /// Gets the list of challengers.
        /// </summary>
        /// <value>A list of battle list entries.</value>
        public ObservableCollection<BattleListEntryViewModel> BattleList
        {
            get
            {
                return this.battleList;
            }

            private set
            {
                this.battleList = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Sets the list of challengers when the lobby is received.
        /// </summary>
        /// <param name="sender">The sender of the LobbyReceived event.</param>
        /// <param name="e">The event arguments.</param>
        private void Client_LobbyReceived(object sender, LobbyReceivedEventArgs e)
        {
            this.BattleList = new ObservableCollection<BattleListEntryViewModel>();

            for (int i = 0; i < e.ClientDummies.Count; i++)
            {
                ClientDummy client = e.ClientDummies[i];
                Application.Current.Dispatcher.Invoke(() =>
                {
                    this.BattleList.Add(new BattleListEntryViewModel(client.UserName, client.IPAddress, client.InGame, client.Id, this.client));
                });
            }
        }
    }
}
