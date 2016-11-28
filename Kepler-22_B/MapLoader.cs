using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;

namespace Kepler_22_B
{
    public class MapLoader
    {
        private Game1 _context;
        public TiledMap GetMap { get; }

        public TiledTileLayer GetLayerCollide { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapLoader"/> class.
        /// This class is use to use any maps and detect any collide.
        /// Collide is used with character move.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nameofmap">The name of the map.</param>
        public MapLoader(Game1 context, string nameofmap)
        {
            _context = context;
            GetMap = _context.Content.Load<TiledMap>("map/" + nameofmap);
            GetLayerCollide = GetMap.GetLayer<TiledTileLayer>("Collide");
        }

        public void draw(SpriteBatch spriteBatch)
        {
            GetMap.Draw(spriteBatch);
        }

    }
}
