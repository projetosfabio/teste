//-----------------------------------------------------------------------
// <copyright file="BaseCommand.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BaseCommand class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.MVVMCore
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Represents the BaseCommand class.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// A event which fires when the CanExecute flag changes.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Returns a value indicating whether the command can be executed.
        /// </summary>
        /// <param name="parameter">Possible specified argument.</param>
        /// <returns>A boolean value.</returns>
        public bool CanExecute(object parameter) => true;

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Possible specified command arguments.</param>
        public abstract void Execute(object parameter);
    }
}
