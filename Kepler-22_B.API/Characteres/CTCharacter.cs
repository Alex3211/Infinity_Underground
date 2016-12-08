using Kepler_22_B.Characteres;
using Microsoft.Xna.Framework;
using RandomNameGeneratorLibrary;
using System;


namespace Kepler_22_B.API.Characteres
{
    public abstract class CTCharacter
    {
        PersonNameGenerator _nameGenerator;
        string _name;
        Vector2 _position;
        CTCharacterType _characterType;
        double _spawnChance;
        World _context;
        bool _isDead;
        

        public CTCharacter(int x = 50, int y = 50)
        {
            if (x < 0 || y < 0) throw new ArgumentOutOfRangeException("The x and y position can not be negative");
            _position = new Vector2(x, y);
            _nameGenerator = new PersonNameGenerator();
            _name = _nameGenerator.GenerateRandomFirstName();
            _characterType = new CTCharacterType(this);
            _isDead = false;
        }


        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public World Context { get { return _context; } set { _context = value; } }

        /// <summary>
        /// Gets the type of the get character.
        /// </summary>
        /// <value>
        /// The type of the get character.
        /// </value>
        public CTCharacterType GetCharacterType { get { return _characterType; } }


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
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get { return _name; } }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is dead.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is dead; otherwise, <c>false</c>.
        /// </value>
        public bool IsDead { get { return _isDead; } set { _isDead = value; } }

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
                    PositionY -= _characterType.MoveSpeed;
                    return (int)Direction.Up;


                case (int)Direction.Left:
                    PositionX -= _characterType.MoveSpeed;
                    return (int)Direction.Left;


                case (int)Direction.Bottom:
                    PositionY += _characterType.MoveSpeed;
                    return (int)Direction.Bottom;

                case (int)Direction.Right:
                    PositionX += _characterType.MoveSpeed;
                    return (int)Direction.Right;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


    }
}
