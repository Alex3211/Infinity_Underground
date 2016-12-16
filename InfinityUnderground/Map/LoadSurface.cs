using InfinityUnderground;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;

namespace InfinityUnderground.Map
{
    class LoadSurface : IEntity
    {
        Game1 _context;

        public LoadSurface(Game1 context)
        {
            _context = context;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            _context.MapLoad.GetMap = _context.Content.Load<TiledMap>("Surface/Map");
            _context.MapLoad.IdTileCollide = 645;
        }




        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
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
