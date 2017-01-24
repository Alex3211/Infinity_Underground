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
        int _width, _height;

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
        public void SetRectangle(int pourcent)
        {

            if (pourcent <= 20)
            {
                _healthBar.SetData(new Color[] { Color.Red });
            }
            else if (pourcent <= 33)
            {
                _healthBar.SetData(new Color[] { Color.OrangeRed });
            }
            else if (pourcent <= 50)
            {
                _healthBar.SetData(new Color[] { Color.Orange });
            }
            else if (pourcent <= 75)
            {
                _healthBar.SetData(new Color[] { Color.GreenYellow });
            }
            else
            {
                _healthBar.SetData(new Color[] { Color.Green });
            }

        }

        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Draw(SpriteBatch spriteBatch, int posX, int posY, int lifepoint, GraphicsDevice graphicsDevice, int maxLifepoint, int height)
        {
            if (lifepoint < 0)
            {
                lifepoint = 0;
            }
            int pourcent = CalculPourcentLifePoint(maxLifepoint, lifepoint);

            _width = 100;
            _height = height;

            if (_healthBar != null) _healthBar.Dispose();
            _healthBar = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            SetRectangle(pourcent);
            spriteBatch.Draw(_healthBar, new Rectangle(posX, posY, pourcent * 2, height), Color.White);
        }

        /// <summary>
        /// Calculs the pourcent life point.
        /// </summary>
        /// <param name="maxLifePoint">The maximum life point.</param>
        /// <param name="actualLifepoint">The actual lifepoint.</param>
        /// <returns></returns>
        public int CalculPourcentLifePoint(int maxLifePoint, int actualLifepoint)
        {
            if (actualLifepoint == maxLifePoint)
            {
                return 100;
            }
            return Math.Abs(((maxLifePoint - actualLifepoint) * 100 / maxLifePoint) - 100);
        }

        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Draw(SpriteBatch spriteBatch, int posX, int posY, int lifepoint, GraphicsDevice graphicsDevice, int maxLifepoint, int height, bool isMonster)
        {
            if (lifepoint < 0)
            {
                lifepoint = 0;
            }

            int pourcent = CalculPourcentLifePoint(maxLifepoint, lifepoint);

            _width = 100;
            _height = height;

            if (_healthBar != null) _healthBar.Dispose();
            _healthBar = new Texture2D(graphicsDevice, 1, 1, false, SurfaceFormat.Color);

            SetRectangle(pourcent);
            spriteBatch.Draw(_healthBar, new Rectangle(posX, posY, pourcent * 4, height), Color.White);
        }


    }

}
