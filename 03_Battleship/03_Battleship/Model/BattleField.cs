//-----------------------------------------------------------------------
// <copyright file="BattleField.cs" company="FHWN">
//   FHWN. All rights reserved.
// </copyright>
// <summary>Contains the BattleField class.</summary>
// <author>Thomas Stranz</author>
//-----------------------------------------------------------------------
namespace _03_Battleship.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents the battle field.
    /// </summary>
    public class BattleField
    {
        /// <summary>
        /// The minimum width of the battle field.
        /// </summary>
        private const int MinWidth = 10;

        /// <summary>
        /// The minimum height of the battle field.
        /// </summary>
        private const int MinHeight = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="BattleField"/> class.
        /// </summary>
        /// <param name="width">The width of the battle field.</param>
        /// <param name="height">The height of the battle field.</param>
        public BattleField(int width = MinWidth, int height = MinHeight)
        {
            this.Width = width;
            this.Height = height;
            this.Ships = new List<Ship>();
            this.Markers = new List<Marker>();
        }

        /// <summary>
        /// Gets the height of the battle field.
        /// </summary>
        /// <value>The height of the battle field.</value>
        public int Height
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the width of the battle field.
        /// </summary>
        /// <value>The width of the battle field.</value>
        public int Width
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the ships of the battle field.
        /// </summary>
        /// <value>A list of ships.</value>
        public List<Ship> Ships
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the markers of the battle field.
        /// </summary>
        /// <value>A list of markers.</value>
        public List<Marker> Markers
        {
            get;
            set;
        }

        /// <summary>
        /// Adds a marker to the battle field.
        /// </summary>
        /// <param name="position">The position of the marker.</param>
        /// <param name="marker">The set marker.</param>
        /// <returns>A boolean value indicating whether the given position is valid.</returns>
        public bool AddMarker(Position position, out Marker marker)
        {
            if (this.Markers.Exists(m => m.Position.Equals(position))
                || position.X >= this.Width || position.Y >= this.Height)
            {
                marker = null;
                return false;
            }

            marker = new MissedMarker(position);

            for (int j = 0; j < this.Ships.Count; j++)
            {
                Ship ship = this.Ships[j];
                Position controlPosition;
                for (int i = 0; i < ship.Length; i++)
                {
                    if (ship.Orientation == Orientation.Horizontal)
                    {
                        controlPosition = new Position(ship.Position.X + i, ship.Position.Y);
                    }
                    else
                    {
                        controlPosition = new Position(ship.Position.X, ship.Position.Y + i);
                    }

                    if (position.Equals(controlPosition))
                    {
                        marker = new HitMarker(position);
                        this.Markers.Add(marker);
                        ship.DamageCounter += 1;

                        if (ship.DamageCounter == ship.Length)
                        {
                            this.Ships.Remove(ship);
                        }

                        break;
                    }
                }
            }

            return true;
        }
    }
}