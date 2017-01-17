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
        public void Draw(SpriteBatch spriteBatch, int posX, int posY, int lifepoint, GraphicsDevice graphicsDevice, int width, int height)
        {
            _width = width;
            _height = height;

            SetMaxLifePoint(lifepoint);

            if (_speedBar != null) _speedBar.Dispose();
            _speedBar = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            _speedBar.SetData(new Color[] { Color.Blue });
            spriteBatch.Draw(_speedBar, new Rectangle(posX, posY, width, height), Color.White);
        }
    }
}
