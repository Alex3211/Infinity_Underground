using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Maps.Tiled;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using InfinityUnderground;
using Kepler_22_B.API.Data;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using InfinityUnderground.UserInterface;
using System.Threading;

namespace InfinityUnderground.Map
{
    public class WorldControlUI : IEntity
    {


        List<Underground> _listOfUndergroundMap;
        Game1 _context;
        Random r;
        bool _IsSecretRoom = false;
        SpriteFont _font;
        Data _dataXml;
        bool _enigmState = false;
        private readonly TimeSpan IntervalBetweenF1Menu;
        private readonly TimeSpan IntervalBetweenText;
        private TimeSpan LastActiveF1Menu;
        private TimeSpan LastActiveText;
        private bool _stateSecretDoor = false;
        KeyboardHandler _handler;
        XmlNodeList tab;
        bool _stateEnigm;
        string _enigmResponse;
        int _enigmRandom;
        private string _statusEnigm = string.Empty;
        private GameTime _gametime;

        public bool GetStateEnigm { get { return _stateEnigm; } }


        /// <summary>
        /// Initializes a new instance of the <see cref="WorldControlUI"/> class.
        /// </summary>
        public WorldControlUI(Game1 context)
        {
            _enigmResponse = string.Empty;
            _dataXml = new Data("enigm");
            _listOfUndergroundMap = new List<Underground>();
            IntervalBetweenF1Menu = TimeSpan.FromMilliseconds(1000);
            IntervalBetweenText = TimeSpan.FromMilliseconds(4500);
            r = new Random();
            _context = context;
            _context.WorldControl = this;
            _handler = new KeyboardHandler(context);
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            _font = _context.Content.Load<SpriteFont>("debug");

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
        /// Gets or sets a value indicating whether [get state secret door].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [get state secret door]; otherwise, <c>false</c>.
        /// </value>
        public bool GetStateOfEnigm { get { return _enigmState; } set { _enigmState = value; } }

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
            _gametime = gameTime;
            if (!ReturnToTheSurface())
            {
                GoToNextLevel();

                SwitchTheRoomUnderground();
            }

            if (!_context.WorldAPI.IsSurface && _context.WorldAPI.Level.GetRooms.TypeOfRoom.NameOfMap == "SecretRoom")
            {
                _IsSecretRoom = true;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F1) && LastActiveF1Menu + IntervalBetweenF1Menu < gameTime.TotalGameTime && IsSecretRoom && !_stateEnigm) 
            {
                _enigmRandom = r.Next(0, 2);
                _stateEnigm = true;

                LastActiveF1Menu = gameTime.TotalGameTime;
            }
            if (_stateEnigm)
            {
                _handler.GetKeys();
                _enigmResponse = _handler.GetString;
                if (_stateEnigm && Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    if (_handler.GetString == tab.Item(_enigmRandom).Attributes["reponse"].Value)
                    {
                        OpenSecretRoom();
                        _handler.GetString = "";
                        _statusEnigm = "Quelque chose semble s'ouvrir";
                    }
                    else
                    {
                        _handler.GetString = "";
                        _statusEnigm = "Loupé !";
                    }
                    _stateEnigm = false;
                    _enigmResponse = "";
                    LastActiveText = gameTime.TotalGameTime;
                }
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
        /// Does an enigm.
        /// </summary>
        /// <returns></returns>
        public string DoAnEnigm()
        {

            tab = _dataXml.GetDataInTab("enigm");
            string toto = "Question : "+ tab.Item(_enigmRandom).FirstChild.Value+" / Réponse : "+ tab.Item(_enigmRandom).Attributes["reponse"].Value;
            return toto;

        }

        /// <summary>
        /// Draws the rectangle for enigms.
        /// </summary>
        /// <param name="coords">The coords.</param>
        /// <param name="color">The color.</param>
        /// <param name="spriteBatch">The sprite batch.</param>
        private void DrawRectangle(Rectangle coords, Color color, SpriteBatch spriteBatch)
        {

            var rect = new Texture2D(_context.GraphicsDevice, 1, 1);
            rect.SetData(new[] { color });
            spriteBatch.Draw(rect, coords, color);
        }

        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Draw(SpriteBatch spriteBatch)
        {
            if(_stateEnigm)
            {
                DrawRectangle(new Rectangle((int)_context.CameraLoader.GetCamera.Position.X, (int)_context.CameraLoader.GetCamera.Position.Y, _context.Graphics.PreferredBackBufferWidth, _context.Graphics.PreferredBackBufferHeight), Color.Chocolate, spriteBatch);
                spriteBatch.DrawString(_font, DoAnEnigm(), new Vector2((int)_context.CameraLoader.GetCamera.Position.X, (int)_context.CameraLoader.GetCamera.Position.Y), Color.White);
                spriteBatch.DrawString(_font, _enigmResponse, new Vector2((int)_context.CameraLoader.GetCamera.Position.X, (int)_context.CameraLoader.GetCamera.Position.Y+50), Color.White);
            }
            if (_statusEnigm != string.Empty && LastActiveText + IntervalBetweenText > _gametime.TotalGameTime) spriteBatch.DrawString(_font, _statusEnigm, new Vector2((int)_context.CameraLoader.GetCamera.Position.X + _context.Graphics.PreferredBackBufferWidth / 2 - (_statusEnigm.Length*2), (int)_context.CameraLoader.GetCamera.Position.Y + _context.Graphics.PreferredBackBufferHeight - 50), Color.White);
        }
    }
}
