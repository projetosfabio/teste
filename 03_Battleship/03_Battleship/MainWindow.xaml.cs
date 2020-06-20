//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the interaction for the main window.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship
{
    using System.Windows;
    using ViewModel;

    /// <summary>
    /// Represents the interaction logic for the main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        /// <summary>
        /// Handles the Closing event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindowViewModel mainWindowViewModel = (MainWindowViewModel)this.DataContext;
            if (mainWindowViewModel.ViewShell.Client != null)
            {
                mainWindowViewModel.ViewShell.Client.Close();
            }

            if (mainWindowViewModel.ViewShell.Server != null)
            {
                mainWindowViewModel.ViewShell.Server.Shutdown();
            }
        }
    }
}
