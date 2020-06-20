//-----------------------------------------------------------------------
// <copyright file="ShipMoverViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ShipMoverViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;
    using Model;
    using MVVMCore;

    /// <summary>
    /// Represents the ship mover.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.NotifyingViewModel" />
    internal class ShipMoverViewModel : NotifyingViewModel
    {
        /// <summary>
        /// The delay in milliseconds.
        /// </summary>
        private const int Delay = 100;

        /// <summary>
        /// The ship mover thread.
        /// </summary>
        private Thread shipMoverThread;

        /// <summary>
        /// The ship to move.
        /// </summary>
        private Ship ship;

        /// <summary>
        /// The squares of the field.
        /// </summary>
        private ObservableCollection<BFSquareViewModel> squares;

        /// <summary>
        /// The maximum height.
        /// </summary>
        private int maxHeight;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShipMoverViewModel"/> class.
        /// </summary>
        /// <param name="ship">The ship to move.</param>
        /// <param name="squares">The squares of the field.</param>
        /// <param name="maxHeight">The maximum height.</param>
        /// <exception cref="ArgumentNullException">
        /// Is thrown if either of the values is null:
        /// ship - The value must not be null.
        /// or
        /// squares - the value must not be null.
        /// </exception>
        public ShipMoverViewModel(Ship ship, ObservableCollection<BFSquareViewModel> squares, int maxHeight)
        {
            this.shipMoverThread = new Thread(this.Worker);
            this.ship = ship ?? throw new ArgumentNullException(nameof(ship), "The value must not be null.");
            this.squares = squares ?? throw new ArgumentNullException(nameof(squares), "the value must not be null.");
            this.maxHeight = maxHeight;
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            if (this.shipMoverThread.ThreadState == ThreadState.Unstarted)
            {
                this.shipMoverThread.Start();
            }
        }

        /// <summary>
        /// Moves the fake ship units.
        /// </summary>
        private void Worker()
        {
            bool removePrevious = false;

            for (int i = 0; i < this.ship.Length; i++)
            {
                Position squarePosition;

                if (this.ship.Orientation == Orientation.Horizontal)
                {
                    squarePosition = new Position(this.ship.Position.X + i, this.ship.Position.Y);
                }
                else
                {
                    squarePosition = new Position(this.ship.Position.X, this.ship.Position.Y + i);
                }

                this.squares.Where(square => square.Position.Equals(squarePosition)).First().RealShipUnit = true;

                for (int y = this.maxHeight - 1; y >= squarePosition.Y; y--)
                {
                    if (removePrevious && y != this.maxHeight - 1)
                    {
                        this.squares.Where(s => s.Position.Equals(new Position(squarePosition.X, y + 1))).First().FakeShipUnit = false;
                    }

                    BFSquareViewModel square = this.squares.Where(s => s.Position.Equals(new Position(squarePosition.X, y))).First();

                    if (!square.FakeShipUnit)
                    {
                        removePrevious = true;
                        square.FakeShipUnit = true;
                    }
                    else
                    {
                        removePrevious = false;
                    }

                    Thread.Sleep(Delay);
                }

                this.squares.Where(square => square.Position.Equals(squarePosition)).First().FakeShipUnit = true;
            }
        }
    }
}
