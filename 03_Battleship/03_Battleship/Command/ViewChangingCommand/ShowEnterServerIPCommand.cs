//-----------------------------------------------------------------------
// <copyright file="ShowEnterServerIPCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ShopEnterServerIPCommand command.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Command.ViewChangingCommand
{
    using MVVMCore;
    using ViewModel;
    using ViewModel.ViewRepresenter;

    /// <summary>
    /// Represents the ShowEnterServerIPCommand command.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.ViewChangingCommand" />
    internal class ShowEnterServerIPCommand : ViewChangingCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShowEnterServerIPCommand"/> class.
        /// </summary>
        /// <param name="viewShell">The view shell.</param>
        public ShowEnterServerIPCommand(ViewShellBaseViewModel viewShell) : base(viewShell)
        {
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public override void Execute(object parameter)
        {
            this.ViewShell.View = new EnterServerIPViewModel((ViewShellViewModel)this.ViewShell);
        }
    }
}
