using InfinityUnderground;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;
using System;

namespace InfinityUnderground.Map
{
    public class LoadUnderground : IEntity
    {
        Game1 _context;
        string _nameOfPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadUnderground"/> class.
        /// </summary>
        /// <param name="mapName">Name of the map.</param>
        public LoadUnderground(Game1 context)
        {
            _context = context;
            _context.WorldAPI.Level.GetRooms.SetRandomNumber();
            _nameOfPath = _context.WorldAPI.Level.GetRooms.TypeOfRoom.NameOfMap + "/" + _context.WorldAPI.Level.GetRooms.NBRandom;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            if (_context.WorldAPI.Level.GetRooms.IsBeginRoom)
            {
                _context.MapLoad.GetMap = _context.Content.Load<TiledMap>("AccessRoom/1");
            }
            else if (_context.WorldAPI.Level.GetRooms.IsFinalRoom)
            {
                _context.MapLoad.GetMap = _context.Content.Load<TiledMap>("AccessRoom/2");
            }
            else
            {
                _context.MapLoad.GetMap = _context.Content.Load<TiledMap>(_nameOfPath);
            }

            _context.MapLoad.GetLayerCollide = _context.MapLoad.GetMap.GetLayer<TiledTileLayer>("Collide");
            _context.MapLoad.IdTileCollide = 3143;
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the specified sprite bach.
        /// </summary>
        /// <param name="spriteBach">The sprite bach.</param>
        public void Draw(SpriteBatch spriteBach)
        {

        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload(ContentManager content)
        {
        }

    }
}
