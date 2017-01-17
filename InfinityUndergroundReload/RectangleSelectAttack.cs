using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload
{
    enum SelectedAttack
    {
        First,
        Second,
        None
    }

    class RectangleSelectAttack
    {

        Texture2D _first;
        Texture2D _second;


        /// <summary>
        /// Initializes a new instance of the <see cref="LifePointMonster"/> class.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public RectangleSelectAttack()
        {
        }

        public void LoadContent(ContentManager content)
        {
            _first = content.Load<Texture2D>(@"Icons\52");
            _second = content.Load<Texture2D>(@"Icons\1");
        }

        public void Unload(ContentManager content)
        {
            if (_first != null) _first.Dispose();
            if (_first != null) _first.Dispose();

            _first = null;
            _second = null;
        }

        /// <summary>
        /// Draws the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Draw(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, SelectedAttack attack)
        {
            Rectangle _destinationRectangle = new Rectangle(650, 900, 100, 100);
            Rectangle _destinationRectangle2 = new Rectangle(800, 900, 100, 100);

            if (attack == SelectedAttack.First)
            {
                spriteBatch.Draw(_first, _destinationRectangle, Color.White);
                spriteBatch.Draw(_second, _destinationRectangle2, Color.Black);
            }
            else if (attack == SelectedAttack.Second)
            {
                spriteBatch.Draw(_first, _destinationRectangle, Color.Black);
                spriteBatch.Draw(_second, _destinationRectangle2, Color.White);
            }

        }

    }
}
