using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;


namespace Kepler_22_B.Map
{
    class Underground
    {
        TiledMap _map;

        string _mapName;


        /// <summary>
        /// Gets the map underground.
        /// </summary>
        /// <value>
        /// The map underground.
        /// </value>
        public TiledMap MapUnderground { get { return _map; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Underground"/> class.
        /// </summary>
        /// <param name="mapName">Name of the map.</param>
        public Underground(string mapName)
        {
            _mapName = mapName;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            _map = content.Load<TiledMap>(_mapName);
        }

    }
}
