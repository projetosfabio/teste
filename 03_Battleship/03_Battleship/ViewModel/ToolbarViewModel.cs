//-----------------------------------------------------------------------
// <copyright file="ToolbarViewModel.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the ToolbarViewModel class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.ViewModel
{
    using MVVMCore;

    /// <summary>
    /// Represents the ToolbarViewModel class.
    /// </summary>
    /// <seealso cref="_03_Battleship.MVVMCore.NotifyingViewModel" />
    internal class ToolbarViewModel : NotifyingViewModel
    {
        /// <summary>
        /// A value indicating whether the carrier button is enabled.
        /// </summary>
        private bool carrierEnabled;

        /// <summary>
        /// A value indicating whether the battleship button is enabled.
        /// </summary>
        private bool battleshipEnabled;

        /// <summary>
        /// A value indicating whether the cruiser button is enabled.
        /// </summary>
        private bool cruiserEnabled;

        /// <summary>
        /// A value indicating whether the destroyer button is enabled.
        /// </summary>
        private bool destroyerEnabled;

        /// <summary>
        /// A value indicating whether the sub button is enabled.
        /// </summary>
        private bool subEnabled;

        /// <summary>
        /// A value indicating whether the button for random positioning is enabled.
        /// </summary>
        private bool randomPositionsEnabled;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolbarViewModel"/> class.
        /// </summary>
        public ToolbarViewModel()
        {
            this.CarrierEnabled = true;
            this.BattleshipEnabled = true;
            this.CruiserEnabled = true;
            this.DestroyerEnabled = true;
            this.SubEnabled = true;
            this.randomPositionsEnabled = true;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the carrier button is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the carrier button is enabled.; otherwise, <c>false</c>.
        /// </value>
        public bool CarrierEnabled
        {
            get
            {
                return this.carrierEnabled;
            }

            set
            {
                this.carrierEnabled = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether battleship button is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the battleship button is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool BattleshipEnabled
        {
            get
            {
                return this.battleshipEnabled;
            }

            set
            {
                this.battleshipEnabled = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether cruiser button is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the cruiser button is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool CruiserEnabled
        {
            get
            {
                return this.cruiserEnabled;
            }

            set
            {
                this.cruiserEnabled = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the destroyer button is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the destroyer button is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool DestroyerEnabled
        {
            get
            {
                return this.destroyerEnabled;
            }

            set
            {
                this.destroyerEnabled = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether sub button is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the sub button is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool SubEnabled
        {
            get
            {
                return this.subEnabled;
            }

            set
            {
                this.subEnabled = value;
                this.Notify();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the button for random positioning is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the button for random positioning is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool RandomPositionsEnabled
        {
            get
            {
                return this.randomPositionsEnabled;
            }

            set
            {
                this.randomPositionsEnabled = value;
                this.Notify();
            }
        }
    }
}
