using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Maps.Tiled;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using InfinityUnderground;

namespace InfinityUnderground.Map
{
    public class WorldControlUI : IEntity
    {


        List<Underground> _listOfUndergroundMap;
        Game1 _context;
        Random r;
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

        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        /// <param name="content"></param>
        public void Unload(ContentManager content)
        {

        }

        /// <summary>
        /// Gets or sets a value indicating whether [get state secret door].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [get state secret door]; otherwise, <c>false</c>.
        /// </value>
        public bool GetStateSecretDoor { get { return _stateSecretDoor; } set { _stateSecretDoor = value; } }

        /// <summary>
        /// Determines the actual room is a secret room.
        /// </summary>
        /// <param name="room">The room.</param>
        public bool IsSecretRoom { get { return _IsSecretRoom; } set { _IsSecretRoom = value; } }
        
        ///<summary>
        /// Creates the new level.
        /// </summary>
        void GoToNextLevel()
        {
            if (_context.WorldAPI.Level.GetRooms.SwitchLevel())
            {
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
                _context.CameraLoader.GetCamera.LookAt(new Vector2(_context.WorldAPI.Players[0].PositionX+350, _context.WorldAPI.Players[0].PositionY));
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

            if (!_context.WorldAPI.IsSurface && _context.WorldAPI.Level.GetRooms.TypeOfRoom.NameOfMap == "SecretRoom")
            {
                _IsSecretRoom = true;
            }


            if(Keyboard.GetState().IsKeyDown(Keys.F1) && LastActiveF1Menu + IntervalBetweenF1Menu < gameTime.TotalGameTime && IsSecretRoom) 
            {
                OpenSecretRoom();
                LastActiveF1Menu = gameTime.TotalGameTime;
            }
        }

        /// <summary>
        /// Opens the secret room.
        /// </summary>
        public void OpenSecretRoom()
        {
            _stateSecretDoor = !_stateSecretDoor;
            _context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor").IsVisible = !_context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor").IsVisible;
        }

        /// <summary>
        /// Draws the specified sprite dragonch.
        /// </summary>
        /// <param name="spriteBatch">The sprite dragonch.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Draw(SpriteBatch spriteBatch)
        {
        }
        
    }
}
