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
        readonly int _width, _height;
        Color[] data;

        /// <summary>
        /// Initializes a new instance of the <see cref="LifePointMonster"/> class.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public LifePointMonster(GraphicsDevice graphicsDevice, int width, int height)
        {
            _width = width;
            _height = height;
            //_healthBar = new Texture2D(graphicsDevice, _width, _height);
            data = new Color[_width * _height];
        }

        /// <summary>
        /// Sets the rectangle.
        /// </summary>
        public void  SetRectangle()
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = Color.Green;
            }
            _healthBar.SetData(data);
        }

        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Draw(SpriteBatch spriteBatch, int posX, int posY)
        {
            SetRectangle();
            spriteBatch.Draw(_healthBar, new Vector2(posX, posY), Color.Green);
        }


    }
}
