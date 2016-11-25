using Microsoft.Xna.Framework;
using System;

namespace Kepler_22_B.API.Characteres
{
    public class CTPlayer : CTCharacter
    {
        bool _isMoving, _canMove;
        int _sprint;

        
        /// <summary>
        /// Initializes a new instance of the <see cref="CTPlayer"/> class.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public CTPlayer()
        {
            _isMoving = true;
            _canMove = true;
            _sprint = 10;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTPlayer"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public CTPlayer(int x, int y)
            : base(x, y)
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

     

    }
}
