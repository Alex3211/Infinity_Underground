using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;

namespace Kepler_22_B.Map
{
    public class MapLoader
    {
        Game1 _context;
        TiledMap _getMap;
        TiledTileLayer _getLayerCollide, _couche, _couche2, _couche3, _couche4;
        int _idTileCollide;


        /// <summary>
        /// Initializes a new instance of the <see cref="MapLoader"/> class.
        /// This class is use to use any maps and detect any collide.
        /// Collide is used with character move.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nameOfMap">The name of the map.</param>
        public MapLoader(Game1 context)
        {
            _context = context;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="nameOfMap">The name of map.</param>
        /// <param name="content">The content.</param>
        public void LoadContent(string nameOfMap, ContentManager content)
        {
            _getMap = content.Load<TiledMap>(nameOfMap);
            foreach (TiledTileLayer e in _getMap.TileLayers)
            {
                if (e.Name == "Collide") _getLayerCollide = e;
                if (e.Name == "UpOne") _couche2 = e;
                if (e.Name == "UpTwo") _couche3 = e;
            }
            _getLayerCollide.IsVisible = false;
            _idTileCollide = 645;
        }

        /// <summary>
        /// Define which Layers the is visible.
        /// </summary>
        /// <param name="couche">if set to <c>true</c> [couche].</param>
        public void LayerIsVisible(bool couche)
        {
            if (couche)
            {
                _couche2.IsVisible = true;
                _couche3.IsVisible = true;
            }
            else
            {
                _couche2.IsVisible = false;
                _couche3.IsVisible = false;
            }
        }

        /// <summary>
        /// Gets the get layer collide.
        /// </summary>
        /// <value>
        /// The get layer collide.
        /// </value>
        public TiledTileLayer GetLayerCollide { get { return _getLayerCollide; } set { _getLayerCollide = value; } }


        /// <summary>
        /// Gets the get map.
        /// </summary>
        /// <value>
        /// The get map.
        /// </value>
        public TiledMap GetMap { get { return _getMap; } set { _getMap = value; } }



        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch, Game1 context)
        {
            LayerIsVisible(false);
            _getMap.Draw(spriteBatch);
            context.Player.Draw(spriteBatch);
            LayerIsVisible(true);
            _couche2.Draw(spriteBatch);
            _couche3.Draw(spriteBatch);
        }

        /// <summary>
        /// Gets the identifier tile collide.
        /// </summary>
        /// <value>
        /// The identifier tile collide.
        /// </value>
        public int IdTileCollide { get { return _idTileCollide; } set { _idTileCollide = value; } }



    }
}
