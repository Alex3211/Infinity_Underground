using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Kepler_22_B.Camera;
using MonoGame.Extended;

namespace Kepler_22_B.DebugGame
{
    class Debug
    {
        private Game1 _context;
        private static readonly TimeSpan IntervalBetweenF10Menu = TimeSpan.FromMilliseconds(200);
        private TimeSpan LastActiveF10Menu;
        private SpriteFont font;
        public int MousePositionY;
        public int MousePositionX;
        CameraLoader _camera;

        /// <summary>
        /// Gets or sets a value indicating whether [debug state].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [debug state]; otherwise, <c>false</c>.
        /// </value>
        public bool DebugState { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Debug"/> class.
        /// This class is used to print infos in screen. 
        /// Debug parameters is all parameters who have to be
        /// disable at final version of the game.
        /// </summary>
        /// <param name="context">The context.</param>
        public Debug(Game1 context, CameraLoader camera)
        {
            _camera = camera;
            _context = context;
            font = _context.Content.Load<SpriteFont>("debug");
            DebugState = false;


            // DEBUG PARAMETERS
            _context.MapLoad.GetLayerCollide.IsVisible = false;
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
                spriteBatch.DrawString(font, $" Camera Vector Position: X: {_camera.GetCamera.Position.X} Y: {_camera.GetCamera.Position.Y}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y), Color.White);
                spriteBatch.DrawString(font, $" Player Vector Position: X: {_context.Player.GCTPlayer.PositionX} Y: {_context.Player.GCTPlayer.PositionY}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 20), Color.White);
                spriteBatch.DrawString(font, $" Switch Room State: {TestSwitchRoom()}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 40), Color.White);
                spriteBatch.DrawString(font, $" Player Vector Position: X: {_context.WorldAPI.Player1PositionXInTile} Y: {_context.WorldAPI.Player1PositionYInTile}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 60), Color.White);
                spriteBatch.DrawString(font, $" Room Vector Position: X: {_context.WorldAPI.Level.GetRooms.PosCurrentRoom.X} Y: {_context.WorldAPI.Level.GetRooms.PosCurrentRoom.Y}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 80), Color.White);
                spriteBatch.DrawString(font, $" Switch Room State: {TestSwitchRoom()}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 100), Color.White);
                spriteBatch.DrawString(font, $" Final Room Vector Position: X: {_context.WorldAPI.Level.GetRooms.RoomOut.X} Y: {_context.WorldAPI.Level.GetRooms.RoomOut.Y}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 120), Color.White);
                spriteBatch.DrawString(font, $" Level : {_context.WorldAPI.Level.GetCurrentlevel}", new Vector2(_camera.GetCamera.Position.X, _camera.GetCamera.Position.Y + 140), Color.White);

            }

        }

        /// <summary>
        /// Determines whether [is final room].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is final room]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsFinalRoom() => (_context.WorldAPI.Level.GetRooms.PosCurrentRoom == _context.WorldAPI.Level.GetRooms.RoomOut);

        /// <summary>
        /// Tests the switch room.
        /// </summary>
        /// <returns></returns>
        public bool TestSwitchRoom() => (_context.WorldAPI.Level.GetRooms.PlayerInTheDoor() != null);
    }
}
