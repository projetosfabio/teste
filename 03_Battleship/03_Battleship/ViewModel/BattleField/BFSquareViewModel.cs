//-----------------------------------------------------------------------
// <copyright file="BFSquareViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BFSquareViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MVVMCore;

    /// <summary>
    /// Represents the BFSquareViewModel class.
    /// </summary>
    internal class BFSquareViewModel : NotifyingViewModel
    {
        /// <summary>
        /// A value indicating if the square is a ship unit.
        /// </summary>
        private bool shipUnit;

        /// <summary>
        /// A value indicating whether the square is clickable.
        /// </summary>
        private bool enabled;

        /// <summary>
        /// The damage state of the square.
        /// </summary>
        private SquareState squareState;

        /// <summary>
        /// The command of the square.
        /// </summary>
        private BaseCommand squareCommand;

        /// <summary>
        /// The command to execute on mouse over.
        /// </summary>
        private BaseCommand mouseOverCommand;

        /// <summary>
        /// The highlighted state of the square.
        /// </summary>
        private HighlightedState highlightedState;

        /// <summary>
        /// Initializes a new instance of the <see cref="BFSquareViewModel"/> class.
        /// </summary>
        /// <param name="shipUnit">A value indicating whether the square is a ship unit.</param>
        /// <param name="position">The position of the square.</param>
        /// <param name="squareCommand">The command of the square.</param>
        public BFSquareViewModel(bool shipUnit, Position position, BaseCommand squareCommand)
        {
            this.Position = position ?? throw new ArgumentNullException(nameof(position), "The value must not be empty.");
            this.FakeShipUnit = shipUnit;
            this.State = SquareState.Undamaged;
            this.SquareCommand = squareCommand;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the square is a ship unit.
        /// </summary>
        /// <value>A boolean value.</value>
        public bool FakeShipUnit
        {
            get
            {
                return this.shipUnit;
            }

            set
            {
                this.shipUnit = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets the damage state of the square.
        /// </summary>
        /// <value>The damage state of the square.</value>
        public SquareState State
        {
            get
            {
                return this.squareState;
            }

            set
            {
                this.squareState = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets the position of the square.
        /// </summary>
        /// <value>The position of the square.</value>
        public Position Position
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the highlighted state.
        /// </summary>
        /// <value>The highlighted state.</value>
        public HighlightedState HighlightedState
        {
            get
            {
                return this.highlightedState;
            }

            set
            {
                this.highlightedState = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets the command of the square.
        /// </summary>
        /// <value>The command of the square.</value>
        public BaseCommand SquareCommand
        {
            get
            {
                return this.squareCommand;
            }

            set
            {
                this.squareCommand = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets the command to execute on mouse over.
        /// </summary>
        /// <value>The command to execute on mouse over.</value>
        public BaseCommand MouseOverCommand
        {
            get
            {
                return this.mouseOverCommand;
            }

            set
            {
                this.mouseOverCommand = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the square is clickable.
        /// </summary>
        /// <value>A boolean value.</value>
        public bool Enabled
        {
            get
            {
                return this.enabled;
            }

            set
            {
                this.enabled = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the square is a real ship unit.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the square is a real ship unit.; otherwise, <c>false</c>.
        /// </value>
        public bool RealShipUnit
        {
            get;
            internal set;
        }
    }
}
