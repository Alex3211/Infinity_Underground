using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Kepler_22_B.Entities
{
    public class ETPlayer
    {

        readonly Texture2D _texture;
        readonly int _millisecondsPerFrame, _width, _height, _totalFrame, _columns, _rows;
        int _column, _row, _speed, _timeSinceLastFrame, _currentFrame;
        Game1 _ctx = new Game1();
        Vector2 position = new Vector2(0, 0);


        /// <summary>
        /// Initializes a new instance of the <see cref="ETPlayer"/> class.
        /// </summary>
        /// <param name="texture">The texture.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        public ETPlayer(Texture2D texture, int rows, int columns)
        {
            _texture = texture;
            _rows = rows;
            _columns = columns;
            _totalFrame = _rows * _columns;
            _width = _texture.Width / _columns;
            _height = _texture.Height / _rows;
            _currentFrame = 0;
            _timeSinceLastFrame = 0;
            _millisecondsPerFrame = 80;
            _speed = 5;
        }


        public void Update(GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds; 
            if (_timeSinceLastFrame == _millisecondsPerFrame)
            {
                _timeSinceLastFrame = 0;

                _currentFrame++;

                if (_currentFrame == _totalFrame)
                {
                    _currentFrame = 0;
                }
            }
        }

        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="location">The location.</param>
        /// <param name="row">The row.</param>
        /// <param name="isMoving">if set to <c>true</c> [is moving].</param>
        public void Draw(SpriteBatch spriteBatch,Vector2 location, int row, bool isMoving)
        {
            _row = row;

            if (isMoving)
            {
                _column = _currentFrame % _columns;
            }
            else
            {
                _column = 0;
            }

            Rectangle _sourceRectangle = new Rectangle(_width * _column, _height * _row, _width, _height);
            Rectangle _destinationRectangle = new Rectangle((int)location.X, (int) location.Y, _width, _height);

            spriteBatch.Begin();

            spriteBatch.Draw(_texture, _destinationRectangle, _sourceRectangle, Color.White);

            spriteBatch.End();

        }

        internal Vector2 MovingObject(ref int direction, ref bool isMoving, KeyboardState state, Vector2 position)
        {
            if (state.IsKeyDown(Keys.LeftShift))
                _speed = 20;
            else
                _speed = 5;

            

            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
            {
                if ((position.X <= (_ctx.WindowWidth - 65)))
                {
                    position.X += _speed;
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
                direction = 3;
                return position;
            }
            else if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.Q))
            {
                if (position.X >= 0)
                {
                    position.X -= _speed;
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
                direction = 1;
                return position;
            }
            else if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Z))
            {
                if (position.Y >= 0)
                {
                    position.Y -= _speed;
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
                direction = 0;
                return position;
            }
            else if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
            {
                if (position.Y <= (_ctx.WindowHeight - 65))
                {
                    position.Y += _speed;
                    isMoving = true;
                }
                else
                {
                    isMoving = false;
                }
                direction = 2;
                return position;
            }

            isMoving = false;
            return position;

        }

    }
}
