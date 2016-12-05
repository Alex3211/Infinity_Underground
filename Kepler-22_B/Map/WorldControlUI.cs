using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Maps.Tiled;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Kepler_22_B.API.Map;
using Kepler_22_B.Camera;
using Microsoft.Xna.Framework.Input;

namespace Kepler_22_B.Map
{
    public class WorldControlUI
    {


        List<Underground> _listOfUndergroundMap;
        Game1 _context;
        Random r;
        TiledMap _surface;
        TiledTileLayer _collideSurface;
        int random;
        bool _IsSecretRoom = false;
        SpriteFont _font;
        string _textDraw;
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
            _listOfUndergroundMap.Add(new Underground("BossRoom/1"));
            _listOfUndergroundMap.Add(new Underground("BossRoom/2"));
            _listOfUndergroundMap.Add(new Underground("BossRoom/3"));
            _listOfUndergroundMap.Add(new Underground("BossRoom/4"));
            _listOfUndergroundMap.Add(new Underground("MonsterRoom/1"));
            _listOfUndergroundMap.Add(new Underground("MonsterRoom/2"));
            _listOfUndergroundMap.Add(new Underground("MonsterRoom/3"));
            _listOfUndergroundMap.Add(new Underground("MonsterRoom/4"));
            _listOfUndergroundMap.Add(new Underground("SecretRoom/1"));
            _listOfUndergroundMap.Add(new Underground("SecretRoom/2"));
            _listOfUndergroundMap.Add(new Underground("SecretRoom/3"));
            _listOfUndergroundMap.Add(new Underground("SecretRoom/4"));
            _listOfUndergroundMap.Add(new Underground("TrapRoom/1"));
            _listOfUndergroundMap.Add(new Underground("TrapRoom/2"));
            _listOfUndergroundMap.Add(new Underground("TrapRoom/3"));
            _listOfUndergroundMap.Add(new Underground("TrapRoom/4"));
            _listOfUndergroundMap.Add(new Underground("LabyrintheRoom/1"));
            _listOfUndergroundMap.Add(new Underground("LabyrintheRoom/2"));
            _listOfUndergroundMap.Add(new Underground("LabyrintheRoom/3"));
            _listOfUndergroundMap.Add(new Underground("LabyrintheRoom/4"));
            _listOfUndergroundMap.Add(new Underground("AccessRoom/1"));
            _listOfUndergroundMap.Add(new Underground("AccessRoom/2"));
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            _font = _context.Content.Load<SpriteFont>("debug");
            _context.MapLoad = new MapLoader(_context);
            _context.MapLoad.LoadContent("Surface/map", _context.Content);
            _surface = _context.MapLoad.GetMap;
            _collideSurface = _context.MapLoad.GetLayerCollide;
            foreach (Underground map in _listOfUndergroundMap)
            {
                map.LoadContent(content);
            }
        }

        public bool GetStateSecretDoor { get { return _stateSecretDoor; } set { _stateSecretDoor = value; } }


        /// <summary>
        /// Gets the surface.
        /// </summary>
        /// <value>
        /// The surface.
        /// </value>
        public TiledMap Surface { get { return _surface; } }

        /// <summary>
        /// Selectes the between four style room.
        /// And define if it's a secret room or not.
        /// </summary>
        void SelectBetweenFourStyleRoom()
        {
            IsSecretRoom = false;

            switch (_context.WorldAPI.Level.GetRooms.TypeOfRoom.Path)
            {
                case 0:
                    ChangeMap(0);
                    break;

                case 1:
                    ChangeMap(4);
                    break;

                case 2:
                    ChangeMap(8);
                    IsSecretRoom = true;
                    break;

                case 3:
                    ChangeMap(12);
                    break;

                case 4:
                    ChangeMap(16);
                    break;

                default:
                    throw new ArgumentNullException();

            }
        }


        /// <summary>
        /// Changes the map.
        /// </summary>
        /// <param name="theIntOfTheList">The int of the list.</param>
        void ChangeMap(int theIntOfTheList)
        {
            random = theIntOfTheList + r.Next(0, 3);
            _context.MapLoad.GetMap = _listOfUndergroundMap[random].MapUnderground;
            _context.MapLoad.GetLayerCollide = _context.MapLoad.GetMap.GetLayer<TiledTileLayer>("Collide");
            if (_context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor") != null) _context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor").IsVisible = true;
        }

        /// <summary>
        /// Determines the actual room is a secret room.
        /// </summary>
        /// <param name="room">The room.</param>
        public bool IsSecretRoom { get { return _IsSecretRoom; } set { _IsSecretRoom = value; } }

        /// <summary>
        /// Changes the map for access room.
        /// </summary>
        /// <param name="theIntOfTheList">The int of the list.</param>
        void ChangeMap(bool inOrOut)
        {
            _IsSecretRoom = false;
            switch (inOrOut)
            {
                case true:
                    _context.MapLoad.GetMap = _listOfUndergroundMap[20].MapUnderground;
                    break;

                case false:
                    _context.MapLoad.GetMap = _listOfUndergroundMap[21].MapUnderground;
                    break;

            }
            _context.MapLoad.GetLayerCollide = _context.MapLoad.GetMap.GetLayer<TiledTileLayer>("Collide");
        }


        /// <summary>
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
                    ChangeMap(true);
                    _context.MapLoad.IdTileCollide = 3143;
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
                _context.MapLoad.GetMap = _surface;
                _context.MapLoad.GetLayerCollide = _collideSurface;
                _context.MapLoad.IdTileCollide = 645;
                _context.CameraLoader.GetCamera.LookAt(new Vector2(_context.WorldAPI.Players[0].PositionX, _context.WorldAPI.Players[0].PositionY));
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
                if (_context.WorldAPI.Level.GetRooms.IsFinalRoom)
                {
                    ChangeMap(false);
                }
                else if (_context.WorldAPI.Level.GetRooms.PosCurrentRoom == new Vector2(0, 0))
                {
                    ChangeMap(true);
                }
                else
                {
                    SelectBetweenFourStyleRoom();
                }
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

        /// <summary>
        /// Define if the secret room is open or not.
        /// </summary>
        public void OpenSecretRoom()
        {
            _stateSecretDoor = !_stateSecretDoor;
            _context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor").IsVisible = !_context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor").IsVisible;
        }
    }
}
