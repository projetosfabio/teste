//-----------------------------------------------------------------------
// <copyright file="ShipToPlaceViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ShipToPlaceViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using System;
    using Model;
    using MVVMCore;

    /// <summary>
    /// Represents the ship to place view model.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.NotifyingViewModel" />
    internal class ShipToPlaceViewModel : NotifyingViewModel
    {
        /// <summary>
        /// The ship type.
        /// </summary>
        private ShipType shipToPlaceType;

        /// <summary>
        /// The ship to place.
        /// </summary>
        private Ship ship;

        /// <summary>
        /// The ship orientation.
        /// </summary>
        private Orientation shipOrientation;

        /// <summary>
        /// Gets or sets the type of the ship.
        /// </summary>
        /// <value>
        /// The type of the ship.
        /// </value>
        public ShipType ShipType
        {
            get
            {
                return this.shipToPlaceType;
            }

            set
            {
                this.shipToPlaceType = value;
                this.Notify(nameof(this.ShipText));
            }
        }

        /// <summary>
        /// Gets or sets the ship to place..
        /// </summary>
        /// <value>
        /// The ship to place..
        /// </value>
        public Ship Ship
        {
            get
            {
                return this.ship;
            }

            set
            {
                this.ship = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets the ship text.
        /// </summary>
        /// <value>
        /// The ship text.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Is thrown if the ShipType is Undefined.
        /// </exception>
        public string ShipText
        {
            get
            {
                switch (this.ShipType)
                {
                    case ShipType.Undefined:
                        return "Nothing selected.";
                    case ShipType.Carrier:
                        return "Flight of 5 Units";
                    case ShipType.Battleship:
                        return "Flight of 4 Units";
                    case ShipType.Cruiser:
                        return "Flight of 3 Units";
                    case ShipType.Destroyer:
                        return "Flight of 2 Units";
                    case ShipType.Sub:
                        return "Single Unit";
                    default: throw new ArgumentOutOfRangeException(nameof(this.ShipType));
                }
            }
        }

        /// <summary>
        /// Gets or sets the ship orientation.
        /// </summary>
        /// <value>
        /// The ship orientation.
        /// </value>
        public Orientation ShipOrientation
        {
            get
            {
                return this.shipOrientation;
            }

            set
            {
                this.shipOrientation = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the position of the ship is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the position of the ship is valid; otherwise, <c>false</c>.
        /// </value>
        public bool ValidPosition { get; set; }
    }
}
