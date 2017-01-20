using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload
{
    class LifePoint
    {
        Texture2D _healthBar;
        Color[] data;
        Color _colorBar;
        int _maxLifepoint, _width, _height;

        /// <summary>
        /// Initializes a new instance of the <see cref="LifePointMonster"/> class.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public LifePoint(int width, int height)
        {
            _colorBar = Color.AliceBlue;
            _width = width;
            _height = height;
            data = new Color[_width * _height];
        }

        /// <summary>
        /// Sets the rectangle.
        /// </summary>
        public void SetRectangle(int lifepoint)
        {

            if (lifepoint <= (_maxLifepoint / 5))
            {
                _healthBar.SetData(new Color[] { Color.Red });
            }
            else if (lifepoint <= (_maxLifepoint / 3))
            {
                _healthBar.SetData(new Color[] { Color.OrangeRed });
            }
            else if (lifepoint <= (_maxLifepoint / 2))
            {
                _healthBar.SetData(new Color[] { Color.Orange });
            }
            else if (lifepoint <= (_maxLifepoint / 1.5))
            {
                _healthBar.SetData(new Color[] { Color.GreenYellow });
            }
            else
            {
                _healthBar.SetData(new Color[] { Color.Green });
            }

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
        public void Draw(SpriteBatch spriteBatch, int posX, int posY, int lifepoint, GraphicsDevice graphicsDevice, int maxLifepoint, int height)
        {
            int pourcent = CalculPourcentLifePoint(maxLifepoint, lifepoint);

            _width = 100;
            _height = height;

            SetMaxLifePoint(lifepoint);

            if (_healthBar != null) _healthBar.Dispose();
            _healthBar = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            SetRectangle(lifepoint);
            spriteBatch.Draw(_healthBar, new Rectangle(posX, posY, pourcent * 2, height), Color.White);
        }

        public int CalculPourcentLifePoint(int maxLifePoint, int actualLifepoint)
        {
            return Math.Abs(((_maxLifepoint - actualLifepoint) * 100 / actualLifepoint) - 100);
        }

        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Draw(SpriteBatch spriteBatch, int posX, int posY, int lifepoint, GraphicsDevice graphicsDevice, int maxLifepoint, int height, bool isMonster)
        {
            int pourcent = CalculPourcentLifePoint(maxLifepoint, lifepoint);

            _width = 100;
            _height = height;

            SetMaxLifePoint(lifepoint);

            if (_healthBar != null) _healthBar.Dispose();
            _healthBar = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            SetRectangle(lifepoint);
            spriteBatch.Draw(_healthBar, new Rectangle(posX, posY, pourcent * 4, height), Color.White);
        }


    }

}
