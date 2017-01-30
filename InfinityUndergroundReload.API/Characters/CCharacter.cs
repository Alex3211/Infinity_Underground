using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public abstract class CCharacter
    {
        bool _isDead;
        bool _isPlayer;
        Vector2 _position;
        CCharacterType _characterType;
        World _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CCharacter" /> class.
        /// </summary>
        /// <param name="pos">The position.</param>
        public CCharacter(Vector2 pos, World context)
        {
            _position = pos;
            _characterType = new CCharacterType(this);
            _context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CCharacter"/> class.
        /// </summary>
        public CCharacter(World context)
            : this(new Vector2(2000, 500), context)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CCharacter"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public CCharacter(int x, int y, World context)
            : this(new Vector2(x, y), context)
        { }

        /// <summary>
        /// Gets a value indicating whether this instance is player.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is player; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlayer
        {
            get
            {
                return _isPlayer;
            }

            set
            {
                _isPlayer = value;
            }
        }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public World Context
        {
            get
            {
                return _context;
            }

            set
            {
                _context = value;
            }
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Vector2 Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        /// <summary>
        /// Gets or sets the position x.
        /// </summary>
        /// <value>
        /// The position x.
        /// </value>
        public int PositionX
        {
            get
            {
                return (int)_position.X;
            }

            set
            {
                _position.X = value;
            }
        }

        /// <summary>
        /// Gets or sets the position y.
        /// </summary>
        /// <value>
        /// The position y.
        /// </value>
        public int PositionY
        {
            get
            {
                return (int)_position.Y;
            }

            set
            {
                _position.Y = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is dead.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is dead; otherwise, <c>false</c>.
        /// </value>
        public bool IsDead
        {
            get
            {
                return _isDead;
            }

            set
            {
                _isDead = value;
            }
        }

        /// <summary>
        /// Gets the type of the charater.
        /// </summary>
        /// <value>
        /// The type of the charater.
        /// </value>
        public CCharacterType CharacterType
        {
            get
            {
                return _characterType;
            }
        }

        /// <summary>
        /// Changes the position.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public void ChangePosition(CDirection direction)
        {
            switch (direction)
            {
                case CDirection.Top:
                    _position.Y -= _characterType.MoveSpeed;
                    break;

                case CDirection.Right:
                    _position.X += _characterType.MoveSpeed;
                    break;

                case CDirection.Bottom:
                    _position.Y += _characterType.MoveSpeed;
                    break;

                case CDirection.Left:
                    _position.X -= _characterType.MoveSpeed;
                    break;
            }
        }

    }
}
