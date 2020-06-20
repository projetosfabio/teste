//-----------------------------------------------------------------------
// <copyright file="BattleFieldItems.xaml.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the interaction logic for the related view.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.View.Client.Partials
{
    using System.Windows.Controls;
    using System.Windows.Input;
    using ViewModel;

    /// <summary>
    /// Represents the interaction logic for the related view.
    /// </summary>
    public partial class BattleFieldItems : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BattleFieldItems"/> class.
        /// </summary>
        public BattleFieldItems()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the MouseEnter event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button button = (Button)e.Source;
            BattleFieldAreaViewModel battleFieldAreaViewModel = (BattleFieldAreaViewModel)this.DataContext;

            if (battleFieldAreaViewModel.HighlightSquaresCommand != null)
            {
                battleFieldAreaViewModel.HighlightSquaresCommand.Execute(button.CommandParameter);
            }
        }
    }
}
