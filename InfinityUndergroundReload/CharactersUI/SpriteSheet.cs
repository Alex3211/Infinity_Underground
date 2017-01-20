using InfinityUndergroundReload.API.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.CharactersUI
{
    public abstract class SpriteSheet
    {
        Texture2D _flame;
        Texture2D _spriteSheet;
        InfinityUnderground _context;
        CNPC _monster;
        int _timeSinceLastFrame;
        int _currentFrame;
        int _width;
        int _height;
        int _column;
        int _millisecondsPerFrame;
        int _spriteSheetRows;
        int _spriteSheetColumns;
        int _totalFrames;
        int _currentRow;
        Vector2 _fightsPosition;
        string _typeOfMonster;
        bool _isSpell;
        string _nameSpell;
        bool _spellReapeat;
        bool _spellHitPlayer;
        bool _resetPosition;
        int _turn;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteSheet"/> class.
        /// </summary>
        public SpriteSheet()
        {
            _timeSinceLastFrame = 0;
            _millisecondsPerFrame = 80;
        }

        /// <summary>
        /// Gets the turn.
        /// </summary>
        /// <value>
        /// The turn.
        /// </value>
        public int Turn
        {
            get
            {
                return _turn;
            }

            set
            {
                _turn = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether {CC2D43FA-BBC4-448A-9D0B-7B57ADF2655C}[reset position].
        /// </summary>
        /// <value>
        /// {D255958A-8513-4226-94B9-080D98F904A1}  <c>true</c> if [reset position]; otherwise, <c>false</c>.
        /// </value>
        public bool ResetPosition
        {
            get
            {
                return _resetPosition;
            }

            set
            {
                _resetPosition = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [spell hit player].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [spell hit player]; otherwise, <c>false</c>.
        /// </value>
        public bool SpellHitPlayer
        {
            get
            {
                return _spellHitPlayer;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [spell reapeat].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [spell reapeat]; otherwise, <c>false</c>.
        /// </value>
        public bool SpellReapeat
        {
            get
            {
                return _spellReapeat;
            }

            set
            {
                _spellReapeat = value;
            }
        }

        /// <summary>
        /// Gets or sets the name spell.
        /// </summary>
        /// <value>
        /// The name spell.
        /// </value>
        public string NameSpell
        {
            get
            {
                return _nameSpell;
            }

            set
            {
                _nameSpell = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is spell.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is spell; otherwise, <c>false</c>.
        /// </value>
        public bool IsSpell
        {
            get
            {
                return _isSpell;
            }

            set
            {
                _isSpell = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of monster.
        /// </summary>
        /// <value>
        /// The type of monster.
        /// </value>
        public string TypeOfMonster
        {
            get
            {
                return _typeOfMonster;
            }

            set
            {
                _typeOfMonster = value;
            }

        }

        /// <summary>
        /// Gets or sets the current row.
        /// </summary>
        /// <value>
        /// The current row.
        /// </value>
        public int CurrentRow
        {
            get
            {
                return _currentRow;
            }

            set
            {
                _currentRow = value;
            }
        }

        /// <summary>
        /// Gets or sets the sprite sheet.
        /// </summary>
        /// <value>
        /// The sprite sheet.
        /// </value>
        internal Texture2D Spritesheet
        {
            get
            {
                return _spriteSheet;
            }

            set
            {
                _spriteSheet = value;
            }
        }

        /// <summary>
        /// Gets the monster.
        /// </summary>
        /// <value>
        /// The monster.
        /// </value>
        public CNPC Monster
        {
            get
            {
                return _monster;
            }

            set
            {
                _monster = value;
            }
        }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        internal InfinityUnderground Context
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
        /// Gets or sets the sprite sheet rows.
        /// </summary>
        /// <value>
        /// The sprite sheet rows.
        /// </value>
        internal int SpriteSheetRows
        {
            get
            {
                return _spriteSheetRows;
            }

            set
            {
                _spriteSheetRows = value;
            }
        }

        /// <summary>
        /// Gets or sets the sprite sheet column.
        /// </summary>
        /// <value>
        /// The sprite sheet column.
        /// </value>
        internal int SpriteSheetColumns
        {
            get
            {
                return _spriteSheetColumns;
            }

            set
            {
                _spriteSheetColumns = value;
            }
        }

        /// <summary>
        /// Gets or sets the total frame.
        /// </summary>
        /// <value>
        /// The total frame.
        /// </value>
        internal int TotalFrames
        {
            get
            {
                return _totalFrames;
            }

            set
            {
                _totalFrames = value;
            }
        }

        /// <summary>
        /// Gets or sets the time since last frame.
        /// </summary>
        /// <value>
        /// The time since last frame.
        /// </value>
        internal int TimeSinceLastFrame
        {
            get
            {
                return _timeSinceLastFrame;
            }

            set
            {
                _timeSinceLastFrame = value;
            }
        }

        /// <summary>
        /// Gets or sets the current frame.
        /// </summary>
        /// <value>
        /// The current frame.
        /// </value>
        internal int CurrentFrame
        {
            get
            {
                return _currentFrame;
            }

            set
            {
                _currentFrame = value;
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        internal int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        internal int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }


        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        internal int Column
        {
            get
            {
                return _column;
            }

            set
            {
                _column = value;
            }
        }

        /// <summary>
        /// Gets or sets the milliseconds per frame.
        /// </summary>
        /// <value>
        /// The milliseconds per frame.
        /// </value>
        internal int MillisecondsPerFrame
        {
            get
            {
                return _millisecondsPerFrame;
            }

            set
            {
                _millisecondsPerFrame = value;
            }
        }

        /// <summary>
        /// Gets or sets the flame.
        /// </summary>
        /// <value>
        /// The flame.
        /// </value>
        public Texture2D Flame
        {
            get
            {
                return _flame;
            }

            set
            {
                _flame = value;
            }
        }

        /// <summary>
        /// Gets the fights position.
        /// </summary>
        /// <value>
        /// The fights position.
        /// </value>
        public Vector2 FightsPosition
        {
            get
            {
                return _fightsPosition;
            }

            set
            {
                _fightsPosition = value;
            }
        }


        /// <summary>
        /// Unloads the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        public virtual void Unload(ContentManager content)
        {
            if (Spritesheet != null) Spritesheet.Dispose();
        }

        public virtual void Update(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                TimeSinceLastFrame -= MillisecondsPerFrame;

                CurrentFrame++;

                TimeSinceLastFrame = 0;
                if (CurrentFrame == TotalFrames / SpriteSheetRows && !IsSpell)
                {
                    CurrentFrame = 0;
                }
                else if (CurrentFrame == TotalFrames / SpriteSheetRows && IsSpell)
                {
                    CurrentFrame = 0;
                    
                    if (CurrentRow + 1 >= SpriteSheetRows && SpellReapeat)
                    {
                        CurrentRow = 0;
                    }
                    else
                    {
                        CurrentRow++;
                    }
                    
                    
                }
            }
            if (Monster != null && Monster.CharacterType.LifePoint <= 0)
            {
                Monster.IsDead = true;
            }
        }

        /// <summary>
        /// Sets the position.
        /// </summary>
        public void SetPosition()
        {
            bool validatePosition = true;
            Vector2 _positionMonster;

            do
            {
                _positionMonster = new Vector2(_context.WorldAPI.Random.Next(100, Context.Map.WidthInPixels - 200), _context.WorldAPI.Random.Next(100, Context.Map.HeightInPixels - 200));

                validatePosition = true;
                foreach (TiledTileLayer layer in Context.Map.CollideLayers.Values)
                {
                    for (int x = -2; x <= 2; x++)
                    {
                        for (int y = -2; y <= 2; y++)
                        {
                            if ((((int)_positionMonster.X) / Context.Map.TileSize) + x > 10 && (((int)_positionMonster.Y) / Context.Map.TileSize) + y > 10 && layer.GetTile((((int)_positionMonster.X) / Context.Map.TileSize) + x, (((int)_positionMonster.Y + y) / Context.Map.TileSize) + y).Id != 0/* && layer.GetTile(((int)_positionMonster.X + x) / Context.Map.TileSize, ((int)_positionMonster.Y + y) / Context.Map.TileSize).Id == Context.Map.IdTileCollide*/)
                            {
                                validatePosition = false;
                            }
                        }
                    }
                }

            } while ((!validatePosition));

            Monster.Position = _positionMonster;

        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public virtual void LoadContent(ContentManager content)
        {

        }


    }
}
