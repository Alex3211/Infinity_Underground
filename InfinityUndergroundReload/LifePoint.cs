using InfinityUndergroundReload.CharactersUI;
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
    class LifePoint
    {
        Texture2D _healthBar;
        Color[] data;
        Color _colorBar;
        int _width, _height;
        Texture2D _userInterface;
        SpriteSheet _context;
        Texture2D _monsterInterface;
        

        /// <summary>
        /// Initializes a new instance of the <see cref="LifePointMonster"/> class.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device.</param>
        public LifePoint(int width, int height, SpriteSheet context)
        {
            _context = context;
            _colorBar = Color.AliceBlue;
            _width = width;
            _height = height;
            data = new Color[_width * _height];
        }

        public void LoadContent(ContentManager content)
        {
            _monsterInterface = _context.Context.SongContent.Load<Texture2D>(@"UI\Baroudeur_éminent");
            _userInterface = content.Load<Texture2D>(@"UI\Srambad");
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
            if (_context.Context.LoadOrUnloadFights == FightsState.Close)
            {
                spriteBatch.Draw(_healthBar, new Rectangle(posX + 30, posY + 69, (int)(pourcent * 1.85), 49), Color.White);
            }
            else
            {
                spriteBatch.Draw(_healthBar, new Rectangle(66, 110, (int)(pourcent * 1.85), 49), Color.White);
            }

            if (_context.Context.LoadOrUnloadFights == FightsState.Close)
            {
                spriteBatch.Draw(_userInterface, new Rectangle(new Point(posX, posY - 40), new Point(250)), Color.White);
            }
            else
            {
                spriteBatch.Draw(_userInterface, new Rectangle(new Point(30, 0), new Point(250)), Color.White);
            }
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
            posY -= 600;
            posX += 360;
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

            Rectangle destinationRectangle = new Rectangle(1600 + 20, 130, (int)(pourcent * 2.08), 60);

            spriteBatch.Draw(_healthBar, destinationRectangle, Color.White);
            spriteBatch.Draw(_monsterInterface, new Rectangle(new Point(1600, 0), new Point(250)), Color.White);

        }


    }

}
