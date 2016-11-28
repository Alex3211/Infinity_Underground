using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Kepler_22_B
{
    public class Debug
    {
        private Game1 _context;
        private static readonly TimeSpan IntervalBetweenF10Menu = TimeSpan.FromMilliseconds(200);
        private TimeSpan LastActiveF10Menu;
        private SpriteFont font;
        public int MousePositionY;
        public int MousePositionX;

        public bool DebugState { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Debug"/> class.
        /// This class is used to print infos in screen. 
        /// Debug parameters is all parameters who have to be
        /// disable at final version of the game.
        /// </summary>
        /// <param name="context">The context.</param>
        public Debug(Game1 context)
        {
            _context = context;
            font = _context.Content.Load<SpriteFont>("debugSpriteFont");
            DebugState = false;


            // DEBUG PARAMETERS
            _context._LayerCollide.IsVisible = true;
            _context.IsMouseVisible = true;
            _context.Window.AllowAltF4 = true;
        }

        public void Update(GameTime gameTime)
        {
            MouseState Mousstate = Mouse.GetState();
            MousePositionY = Mousstate.Y;
            MousePositionX = Mousstate.X;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.F12) && LastActiveF10Menu + IntervalBetweenF10Menu < gameTime.TotalGameTime)
            {
                DebugState = !DebugState;
                LastActiveF10Menu = gameTime.TotalGameTime;
            }
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (DebugState)
            {
                spriteBatch.DrawString(font, $" Camera Vector Position: X: {_context._camera.Position.X} Y: {_context._camera.Position.Y}", new Vector2(_context._camera.Position.X, _context._camera.Position.Y + 0), Color.White);
               // spriteBatch.DrawString(font, $" Player Vector Position: X: {_context.position.X} Y: {_context.position.Y}", new Vector2(_context._camera.Position.X, _context._camera.Position.Y + 20), Color.White);
                spriteBatch.DrawString(font, $" Mouse Window Location: X: {MousePositionY} Y: {MousePositionX}", new Vector2(_context._camera.Position.X, _context._camera.Position.Y + 40), Color.White);
            }
        }
    }
}
