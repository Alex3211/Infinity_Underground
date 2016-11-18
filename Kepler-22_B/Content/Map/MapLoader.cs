using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.Map
{
    public class MapLoader
    {
        Game1 _context;
        TiledMap _getMap;
        TiledTileLayer _getLayerCollide;
        int _idTileCollide;


        /// <summary>
        /// Initializes a new instance of the <see cref="MapLoader"/> class.
        /// This class is use to use any maps and detect any collide.
        /// Collide is used with character move.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nameOfMap">The name of the map.</param>
        public MapLoader(Game1 context, string nameOfMap)
        {
            _context = context;
            _getMap = _context.Content.Load<TiledMap>("map/" + nameOfMap);
            _getLayerCollide = _getMap.GetLayer<TiledTileLayer>("Collide");
            _getLayerCollide.IsVisible = false;
            _idTileCollide = 367;
        }


        /// <summary>
        /// Gets the get layer collide.
        /// </summary>
        /// <value>
        /// The get layer collide.
        /// </value>
        public TiledTileLayer GetLayerCollide { get { return _getLayerCollide; } }


        /// <summary>
        /// Gets the get map.
        /// </summary>
        /// <value>
        /// The get map.
        /// </value>
        public TiledMap GetMap { get { return _getMap; } }



        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public void draw(SpriteBatch spriteBatch)
        {
            _getMap.Draw(spriteBatch);
        }

        /// <summary>
        /// Gets the identifier tile collide.
        /// </summary>
        /// <value>
        /// The identifier tile collide.
        /// </value>
        public int IdTileCollide { get { return _idTileCollide; } }
    }
}
