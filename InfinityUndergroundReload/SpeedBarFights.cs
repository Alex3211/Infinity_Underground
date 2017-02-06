using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload
{
    class SpeedBarFights
    {
        Texture2D _speedBar;
        Color[] data;
        Color _colorBar;
        int _maxLifepoint, _width, _height;

        /// <summary>
        /// Initializes a new instance of the <see cref="LifePointMonster"/> class.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public SpeedBarFights(int width, int height)
        {
            _colorBar = Color.AliceBlue;
            _width = width;
            _height = height;
            data = new Color[_width * _height];
        }

        /// <summary>
        /// Sets the maximum life point.
        /// </summary>
        void SetMaxLifePoint(int lifepoint)
        {
            if (lifepoint > _maxLifepoint)
            {
                _maxLifepoint = lifepoint;
            }
        }



        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Draw(SpriteBatch spriteBatch, int posX, int posY, int lifepoint, GraphicsDevice graphicsDevice, int height, int width)
        {
            Vector2 _origin = new Vector2(0, 0);
            SetMaxLifePoint(lifepoint);

            if (_speedBar != null) _speedBar.Dispose();
            _speedBar = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            _speedBar.SetData(new Color[] { Color.Blue });
            spriteBatch.Draw(_speedBar, new Rectangle(46, 797, width, (int)(height * 3.55)), new Rectangle(0, 0, 100, 100), Color.White, 3.142f, _origin, SpriteEffects.FlipHorizontally, 1);
        }

        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Draw(SpriteBatch spriteBatch, int posX, int posY, int lifepoint, GraphicsDevice graphicsDevice, int height, int width, bool isMonster)
        {
            Vector2 _origin = new Vector2(0, 0);
            SetMaxLifePoint(lifepoint);

            if (_speedBar != null) _speedBar.Dispose();
            _speedBar = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            _speedBar.SetData(new Color[] { Color.Blue });
            spriteBatch.Draw(_speedBar, new Rectangle(186, 797, width, (int)(height * 3.55)), new Rectangle(0, 0, 100, 100), Color.White, 3.142f, _origin, SpriteEffects.None, 1);
        }
    }
}
