using InfinityUnderground.EntitiesUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.UserInterface
{
    class LifePointMonster 
    {
        Texture2D _healthBar;
        readonly int _height;
        Color[] data;
        Color _colorBar;
        int _maxLifepoint, _width;

        /// <summary>
        /// Initializes a new instance of the <see cref="LifePointMonster"/> class.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public LifePointMonster(int width, int height)
        {
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
                _colorBar = Color.Red;
            }
            else if (lifepoint <= (_maxLifepoint / 3))
            {
                _colorBar = Color.OrangeRed;
            }
            else if (lifepoint <= (_maxLifepoint / 2))
            {
                _colorBar = Color.Orange;
            }
            /*else if (lifepoint <= (_maxLifepoint / 1.5))
            {
                _colorBar = Color.GreenYellow;
            }*/
            else
            {
                _colorBar = Color.Green;
            }

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = _colorBar;
            }

            _healthBar.SetData(data);
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
        /// Creates the life bar.
        /// </summary>
        void CreateLifeBar(GraphicsDevice graphicsDevice)
        {
            _healthBar = new Texture2D(graphicsDevice, _width, _height);
        }

        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Draw(SpriteBatch spriteBatch, int posX, int posY, int lifepoint, GraphicsDevice graphicsDevice, int width)
        {
            _width = width;
            SetMaxLifePoint(lifepoint);
            CreateLifeBar(graphicsDevice);
            SetRectangle(lifepoint);
            spriteBatch.Draw(_healthBar, new Vector2(posX, posY), Color.White);
        }


    }
}
