using InfinityUnderground;
using InfinityUnderground.API.Characteres;
using InfinityUnderground.EntitiesUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Maps.Tiled;
using System.Collections.Generic;

namespace InfinityUnderground.Map
{
    public class MapLoader : IEntity
    {
        Game1 _context;
        TiledMap _getMap;
        TiledTileLayer _getLayerCollide, _getLayerDoorCollide, _firstLayer, _secondLayer;
        int _idTileCollide;


        /// <summary>
        /// Initializes a new instance of the <see cref="MapLoader"/> class.
        /// This class is use to use any maps and detect any collide.
        /// Collide is used with character moves.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="nameOfMap">The name of the map.</param>
        public MapLoader(Game1 context)
        {
            _context = context;
            _context.MapLoad = this;
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="nameOfMap">The name of map.</param>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            _context.Player.LoadContent(content);
            foreach (TiledTileLayer e in _getMap.TileLayers)
            {
                if (e != null && e.Name == "Collide") _getLayerCollide = e;
                if (e != null && e.Name == "SecretCollide") _getLayerDoorCollide = e;
                if (e != null && e.Name == "UpOne") _firstLayer = e;
                if (e != null && e.Name == "UpTwo") _secondLayer = e;
            }
            _getLayerCollide.IsVisible = false;
        }

        /// <summary>
        /// Define which Layers is visible.
        /// </summary>
        /// <param name="couche">if set to <c>true</c> [couche].</param>
        public void LayerIsVisible(bool couche)
        {
            if (couche) { _firstLayer.IsVisible = true; _secondLayer.IsVisible = true; }
            else { _firstLayer.IsVisible = false; _secondLayer.IsVisible = false; }
        }

        /// <summary>
        /// Gets the layer collide.
        /// </summary>
        /// <value>
        /// The get layer collide.
        /// </value>
        public TiledTileLayer GetLayerCollide { get { return _getLayerCollide; } set { _getLayerCollide = value; } }

        /// <summary>
        /// Gets the layer door collide, for secret room.
        /// </summary>
        /// <value>
        /// The get layer collide.
        /// </value>
        public TiledTileLayer GetLayerDoorCollide { get { return _getLayerDoorCollide; } set { _getLayerDoorCollide = value; } }

        /// <summary>
        /// Gets the map.
        /// </summary>
        /// <value>
        /// The get map.
        /// </value>
        public TiledMap GetMap { get { return _getMap; } set { _getMap = value; } }

        /// <summary>
        /// Draws the specified sprite dragonch.
        /// </summary>
        /// <param name="spriteBatch">The sprite dragonch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            LayerIsVisible(false);
            _getMap.Draw(spriteBatch);
            _context.Player.Draw(spriteBatch);
            LayerIsVisible(true);
            _firstLayer.Draw(spriteBatch);
            _secondLayer.Draw(spriteBatch);
        }

        /// <summary>
        /// Update the map.
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            _context.Player.Update(gameTime);
        }

        /// <summary>
        /// Gets the identifier tile collide.
        /// </summary>
        /// <value>
        /// The identifier tile collide.
        /// </value>
        public int IdTileCollide { get { return _idTileCollide; } set { _idTileCollide = value; } }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload(ContentManager content)
        {
            if (_getLayerCollide != null) _getMap.Dispose();
            if (_getMap != null) _getLayerCollide.Dispose();
            if (_getLayerDoorCollide != null) _getLayerDoorCollide.Dispose();
            if (_firstLayer != null) _firstLayer.Dispose();
            if (_secondLayer != null) _secondLayer.Dispose();
        }


    }
}
