using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Maps.Tiled;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Kepler_22_B.Map
{
    public class WorldControlUI : IEntity
    {


        List<Underground> _listOfUndergroundMap;
        Game1 _context;
        Random r;
        TiledMap _surface;
        TiledTileLayer _collideSurface;
        int random;
        bool _IsSecretRoom = false;
        SpriteFont _font;
        private readonly TimeSpan IntervalBetweenF1Menu;
        private TimeSpan LastActiveF1Menu;
        private bool _stateSecretDoor = false;
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldControlUI"/> class.
        /// </summary>
        public WorldControlUI(Game1 context)
        {
            _listOfUndergroundMap = new List<Underground>();
            IntervalBetweenF1Menu = TimeSpan.FromMilliseconds(1000);
            r = new Random();
            _context = context;
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {

        public bool GetStateSecretDoor { get { return _stateSecretDoor; } set { _stateSecretDoor = value; } }


        /// <summary>
        /// Gets the surface.
        /// </summary>
        /// <value>
        /// The surface.
        /// </value>
        public TiledMap Surface { get { return _surface; } }

        }

        /// <summary>
        /// Determines the actual room is a secret room.
        /// </summary>
        /// <param name="room">The room.</param>
        public bool IsSecretRoom { get { return _IsSecretRoom; } set { _IsSecretRoom = value; } }
        /// Creates the new level.
        /// </summary>
        void GoToNextLevel()
        {
            if (_context.WorldAPI.Level.GetRooms.SwitchLevel())
            {
                _context.MapLoad.GetMap.Dispose();
                _context.CameraLoader.GetCamera.LookAt(new Vector2(_context.WorldAPI.Players[0].PositionX, _context.WorldAPI.Players[0].PositionY));
                if (!_context.WorldAPI.IsSurface)
                {
                    _context.GetGameState = Game1.GameState.UNDERGROUND;
                    _context.LoadGameState = true;
                    
                }
            }
        }

        /// <summary>
        /// s this instance.
        /// </summary>
        /// <returns></returns>
        bool ReturnToTheSurface()
        {
            if (_context.WorldAPI.Level.GetRooms.ReturnSurface())
            {
                _context.GetGameState = Game1.GameState.SURFACE;
                _context.LoadGameState = true;
                _context.CameraLoader.GetCamera.LookAt(new Vector2(_context.WorldAPI.Players[0].PositionX+250, _context.WorldAPI.Players[0].PositionY));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Switches the room underground.
        /// </summary>
        void SwitchTheRoomUnderground()
        {
            if (_context.WorldAPI.Level.GetRooms.SwitchRoom())
            {
                _context.MapLoad.GetMap.Dispose();

                _context.LoadGameState = true;

                //if (_context.WorldAPI.Level.GetRooms.IsFinalRoom)
                //{
                //    _context.GetGameState = Game1.GameState.CHANGEROOM;
                //}
                //else if(_context.WorldAPI.Level.GetRooms.PosCurrentRoom == new Vector2(0,0))
                //{
                //    _context.GetGameState = Game1.GameState.CHANGEROOM;
                //}
                ////else
                ////{
                ////    SelectBetweenFourStyleRoom();
                //}
                _context.CameraLoader.GetCamera.LookAt(new Vector2(_context.WorldAPI.Players[0].PositionX, _context.WorldAPI.Players[0].PositionY));
            }
        }



        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            if (!ReturnToTheSurface())
            {
                GoToNextLevel();

                SwitchTheRoomUnderground();
            }

            if(Keyboard.GetState().IsKeyDown(Keys.F1) && LastActiveF1Menu + IntervalBetweenF1Menu < gameTime.TotalGameTime && IsSecretRoom) 
            {
                OpenSecretRoom();
                LastActiveF1Menu = gameTime.TotalGameTime;
            }
        }
    }
}
