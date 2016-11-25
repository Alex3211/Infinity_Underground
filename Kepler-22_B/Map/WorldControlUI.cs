using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Maps.Tiled;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Kepler_22_B.API.Map;
using Kepler_22_B.Camera;

namespace Kepler_22_B.Map
{
    public class WorldControlUI
    {


        List<Underground> _listOfUndergroundMap;
        Game1 _context;
        Random r;

        /// <summary>
        /// Initializes a new instance of the <see cref="WorldControlUI"/> class.
        /// </summary>
        public WorldControlUI(Game1 context)
        {
            _listOfUndergroundMap = new List<Underground>();
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
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            _context.MapLoad = new MapLoader(_context);
            _context.MapLoad.LoadContent("Surface/map", _context.Content);

            foreach (Underground map in _listOfUndergroundMap)
            {
                map.LoadContent(content);
            }
        }


        /// <summary>
        /// Selectes the between four style room.
        /// </summary>
        void SelectBetweenFourStyleRoom()
        {
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
            _context.MapLoad.GetMap = _listOfUndergroundMap[theIntOfTheList + r.Next(0, 3)].MapUnderground;
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
                SelectBetweenFourStyleRoom();
            }
        }







        /// <summary>
        /// Switches the room underground.
        /// </summary>
        void SwitchTheRoomUnderground()
        {
            if (_context.WorldAPI.Level.GetRooms.SwitchRoom())
            {
                _context.MapLoad.GetMap.Dispose();
                _context.CameraLoader.GetCamera.LookAt(new Vector2(_context.WorldAPI.Players[0].PositionX, _context.WorldAPI.Players[0].PositionY));
            }
        }

















        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            SwitchTheRoomUnderground();

            GoToNextLevel();
        }
    }
}
