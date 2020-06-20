//-----------------------------------------------------------------------
// <copyright file="NotifyingViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the NotifyingViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.MVVMCore
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents the NotifyingViewModel class.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public abstract class NotifyingViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Notifies that the specified property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void Notify([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
