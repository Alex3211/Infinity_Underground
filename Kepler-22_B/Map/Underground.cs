using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;


namespace Kepler_22_B.Map
{
    public class Underground : IEntity
    {
        Game1 _context;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Underground"/> class.
        /// </summary>
        /// <param name="mapName">Name of the map.</param>
        public Underground(Game1 context)
        {
            _context = context;
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
                _context.MapLoad.GetMap = _context.Content.Load<TiledMap>(_context.WorldAPI.Level.GetRooms.TypeOfRoom.NameOfMap + "/1"/* + r.Next(1,4)*/);
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
        public void Unload()
        {
        }

    }
}
