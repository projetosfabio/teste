//-----------------------------------------------------------------------
// <copyright file="BattleFieldModalViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BattleFieldModalViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using MVVMCore;

    /// <summary>
    /// Represents the BattleFieldModalViewModel class.
    /// </summary>
    internal class BattleFieldModalViewModel : NotifyingViewModel
    {
        /// <summary>
        /// The modal command.
        /// </summary>
        private BaseCommand modalCommand;

        /// <summary>
        /// The abort command.
        /// </summary>
        private BaseCommand abortCommand;

        /// <summary>
        /// The text of the modal.
        /// </summary>
        private string text;

        /// <summary>
        /// A value indicating whether the Yes and No button should be displayed.
        /// </summary>
        private bool buttonSetYesNo;

        /// <summary>
        /// A value indicating whether the ok button should be displayed.
        /// </summary>
        private bool buttonSetOK;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleFieldModalViewModel"/> class.
        /// </summary>
        /// <param name="text">The text of the modal.</param>
        public BattleFieldModalViewModel(string text)
        {
            this.Text = text;
        }

        /// <summary>
        /// Gets or sets the text of the modal.
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the buttons yes and no should be displayed.
        /// </summary>
        /// <value>
        /// A boolean value.
        /// </value>
        public bool ButtonSetYesNo
        {
            get
            {
                return this.buttonSetYesNo;
            }

            set
            {
                this.buttonSetYesNo = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the ok button should be displayed.
        /// </summary>
        /// <value>
        /// A boolean value.
        /// </value>
        public bool ButtonSetOK
        {
            get
            {
                return this.buttonSetOK;
            }

            set
            {
                this.buttonSetOK = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets the modal command.
        /// </summary>
        /// <value>
        /// The modal command.
        /// </value>
        public BaseCommand ModalCommand
        {
            get
            {
                return this.modalCommand;
            }

            set
            {
                this.modalCommand = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets the abort command.
        /// </summary>
        /// <value>
        /// The abort command.
        /// </value>
        public BaseCommand AbortCommand
        {
            get
            {
                return this.abortCommand;
            }

            set
            {
                this.abortCommand = value;
                this.Notify();
            }
        }
    }
}