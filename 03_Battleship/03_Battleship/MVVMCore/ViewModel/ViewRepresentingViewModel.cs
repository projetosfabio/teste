//-----------------------------------------------------------------------
// <copyright file="ViewRepresentingViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ViewRepresentingViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.MVVMCore
{
    /// <summary>
    /// Represents the ViewRepresentingViewModel class.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.NotifyingViewModel" />
    public abstract class ViewRepresentingViewModel : NotifyingViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewRepresentingViewModel"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public ViewRepresentingViewModel(ViewShellBaseViewModel viewShell)
        {
            this.ViewShell = viewShell;
        }

        /// <summary>
        /// Gets or sets the view shell.
        /// </summary>
        /// <value>
        /// The view shell.
        /// </value>
        protected ViewShellBaseViewModel ViewShell
        {
            get;
            set;
        }
    }
}
