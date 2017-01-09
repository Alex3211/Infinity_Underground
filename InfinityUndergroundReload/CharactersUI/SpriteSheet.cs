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
        Vector2 _fightsPosition;
        string _typeOfMonster;


        /// <summary>
        /// Initializes a new instance of the <see cref="SpriteSheet"/> class.
        /// </summary>
        public SpriteSheet()
        {
            _timeSinceLastFrame = 0;
            _millisecondsPerFrame = 80;
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
        public void Unload(ContentManager content)
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
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
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
                _positionMonster = new Vector2(_context.Random.Next(100, Context.Map.WidthInPixels - 200), _context.Random.Next(100, Context.Map.HeightInPixels - 200));

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

    }
}
