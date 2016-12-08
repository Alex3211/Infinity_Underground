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
    public class WorldControlUI : IEntity
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
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {


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
            
        }





        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload()
        {
        }

    }
}
