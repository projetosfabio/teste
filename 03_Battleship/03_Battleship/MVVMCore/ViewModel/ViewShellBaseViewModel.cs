//-----------------------------------------------------------------------
// <copyright file="ViewShellBaseViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ViewShellBaseViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.MVVMCore
{
    /// <summary>
    /// Represents the ViewShellBaseViewModel class.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.NotifyingViewModel" />
    public class ViewShellBaseViewModel : NotifyingViewModel
    {
        /// <summary>
        /// The view of the shell.
        /// </summary>
        private ViewRepresentingViewModel view;

        /// <summary>
        /// Gets or sets the view of the shell.
        /// </summary>
        /// <value>
        /// The view of the shell.
        /// </value>
        public ViewRepresentingViewModel View
        {
            get
            {
                return this.view;
            }

            set
            {
                this.view = value;
                this.Notify();
            }
        }
    }
}
