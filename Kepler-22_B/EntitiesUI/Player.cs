using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Kepler_22_B.API.Entities;
using System;

namespace Kepler_22_B.EntitiesUI
{
    class Player
    {
        Texture2D _spriteSheet;
        KeyboardState _state;
        ETPlayer _player;

        int _spriteSheetRows, _spriteSheetColumns, _currentFrame, _totalFrames, _timeSinceLastFrame, _millisecondsPerFrame;

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="spriteSheetRows">The sprite sheet rows.</param>
        /// <param name="spriteSheetColumns">The sprite sheet columns.</param>
        /// <param name="spriteSheet">The sprite sheet.</param>
        public Player(int spriteSheetRows, int spriteSheetColumns, Texture2D spriteSheet)
        {
            _spriteSheet = spriteSheet;
            _spriteSheetColumns = spriteSheetColumns;
            _spriteSheetRows = spriteSheetRows;
            _timeSinceLastFrame = 0;
            _millisecondsPerFrame = 80;
            _totalFrames = _spriteSheetRows * _spriteSheetColumns;
            _player = new ETPlayer();
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            ResetCurrentFrame(gameTime);
        }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            _state = Keyboard.GetState();


            int _width = _spriteSheet.Width / _spriteSheetColumns;
            int _height = _spriteSheet.Height / _spriteSheetRows;
            int _row = UpdatePositionOfPlayer();
            int _column = _currentFrame % _spriteSheetColumns;

            Rectangle _sourceRectangle = new Rectangle(_width * _column, _height * _row, _width, _height);
            Rectangle _destinationRectangle = new Rectangle(_player.PositionX, _player.PositionY, _width, _height);

            spriteBatch.Draw(_spriteSheet, _destinationRectangle, _sourceRectangle, Color.White);

        }


        /// <summary>
        /// Updates the position of player.
        /// </summary>
        int UpdatePositionOfPlayer()
        {
            if (_state.IsKeyDown(Keys.Z) || _state.IsKeyDown(Keys.Up))
            {
                return _player.Deplacement((int)Direction.Up);
            }
            else if (_state.IsKeyDown(Keys.Q) || _state.IsKeyDown(Keys.Left))
            {
                return _player.Deplacement((int)Direction.Left);
            }
            else if (_state.IsKeyDown(Keys.S) || _state.IsKeyDown(Keys.Down))
            {
                return _player.Deplacement((int)Direction.Bottom);
            }
            else if (_state.IsKeyDown(Keys.D) || _state.IsKeyDown(Keys.Right))
            {
                return _player.Deplacement((int)Direction.Right);
            }

            // Change this with the previously move
            return 0;

        }

        /// <summary>
        /// Resets the current frame.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        void ResetCurrentFrame(GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (_timeSinceLastFrame > _millisecondsPerFrame)
            {
                _timeSinceLastFrame -= _millisecondsPerFrame;

                _currentFrame++;

                _timeSinceLastFrame = 0;
                if (_currentFrame == _totalFrames)
                {
                    _currentFrame = 0;
                }
            }
        }
    }
}
