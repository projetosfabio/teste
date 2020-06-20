//-----------------------------------------------------------------------
// <copyright file="ViewChangingCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ViewChangingCommand class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.MVVMCore
{
    /// <summary>
    /// Represents the ViewChangingCommand class.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.BaseCommand" />
    public abstract class ViewChangingCommand : BaseCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewChangingCommand"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public ViewChangingCommand(ViewShellBaseViewModel viewShell)
        {
            this.ViewShell = viewShell;
        }

        /// <summary>
        /// Gets or sets the view shell.
        /// </summary>
        /// <value>The view shell.</value>
        protected ViewShellBaseViewModel ViewShell
        {
            get;
            set;
        }
    }
}
