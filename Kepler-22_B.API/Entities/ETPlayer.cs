using Microsoft.Xna.Framework;
using System;

namespace Kepler_22_B.API.Entities
{
    public class ETPlayer : ETCharateristics
    {
        Vector2 _position;
        bool _isMoving;

        
        /// <summary>
        /// Initializes a new instance of the <see cref="ETPlayer"/> class.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public ETPlayer(int x, int y)
        {
            _position = new Vector2(x, y);
        }

        public ETPlayer()
            :this(0, 0)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is moving.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is moving; otherwise, <c>false</c>.
        /// </value>
        public bool IsMoving { get { return _isMoving; } set { _isMoving = value; } }

        /// <summary>
        /// Gets or sets the position x.
        /// </summary>
        /// <value>
        /// The position x.
        /// </value>
        public int PositionX { get { return (int)_position.X; } set { _position.X = value; } }
        
        /// <summary>
        /// Gets or sets the position y.
        /// </summary>
        /// <value>
        /// The position y.
        /// </value>
        public int PositionY { get { return (int)_position.Y; } set { _position.Y = value; } }

        /// <summary>
        /// Deplacements the specified direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int Deplacement(int direction)
        {
            switch (direction)
            {
                case 0:
                    PositionY--;
                    return 0;


                case 1:
                    PositionX--;
                    return 1;


                case 2:
                    PositionY++;
                    return 2;

                case 3:
                    PositionX++;
                    return 3;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }





    }
}
