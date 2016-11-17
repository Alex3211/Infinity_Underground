using Microsoft.Xna.Framework;
using System;

namespace Kepler_22_B.API.Entities
{
    public class ETPlayer : ETCharateristics
    {
        Vector2 _position;
        bool _isMoving, _canMove;
        int _moveSpeed, _sprint;

        
        /// <summary>
        /// Initializes a new instance of the <see cref="ETPlayer"/> class.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public ETPlayer(int x, int y)
        {
            _position = new Vector2(x, y);
            _moveSpeed = 2;
            _isMoving = true;
            _canMove = true;
            _sprint = 4;
        }

        public ETPlayer()
            :this(50, 50)
        {
        }


        /// <summary>
        /// Gets or sets the sprint.
        /// </summary>
        /// <value>
        /// The sprint.
        /// </value>
        public int Sprint { get { return _sprint; } set { _sprint = value; } }

        /// <summary>
        /// Gets or sets the move speed.
        /// </summary>
        /// <value>
        /// The move speed.
        /// </value>
        public int MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can move.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the player can move; otherwise, <c>false</c>.
        /// </value>
        public bool CanMove { get { return _canMove; } set { _canMove = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is moving.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the player is moving; otherwise, <c>false</c>.
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
                case (int)Direction.Up:
                    PositionY -= _moveSpeed;
                    return (int)Direction.Up;


                case (int)Direction.Left:
                    PositionX -= _moveSpeed;
                    return (int)Direction.Left;


                case (int)Direction.Bottom:
                    PositionY += _moveSpeed;
                    return (int)Direction.Bottom;

                case (int)Direction.Right:
                    PositionX += _moveSpeed;
                    return (int)Direction.Right;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }
}
