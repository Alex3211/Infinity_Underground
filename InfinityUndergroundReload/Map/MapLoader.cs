using InfinityUndergroundReload.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Maps.Tiled;
using System.Collections.Generic;

namespace InfinityUndergroundReload.Map
{
    public class MapLoader : IEntity
    {
        int _idTileCollide;
        int _tileSize;
        int _heightInPixels;
        int _widthInPixel;

        InfinityUnderground _context;
        TiledMap _getMap;
        Dictionary<string, TiledTileLayer> _groundLayer;
        Dictionary<string, TiledTileLayer> _upLayer;
        Dictionary<string, TiledTileLayer> _collideLayer;


        public MapLoader(InfinityUnderground context)
        {
            _context = context;

            _groundLayer = new Dictionary<string, TiledTileLayer>();
            _upLayer = new Dictionary<string, TiledTileLayer>();
            _collideLayer = new Dictionary<string, TiledTileLayer>();
        }

        /// <summary>
        /// Gets the height in pixels.
        /// </summary>
        /// <value>
        /// The height in pixels.
        /// </value>
        public int HeightInPixels
        {
            get
            {
                return _heightInPixels;
            }
        }

        /// <summary>
        /// Gets the width in pixels.
        /// </summary>
        /// <value>
        /// The width in pixels.
        /// </value>
        public int WidthInPixels
        {
            get
            {
                return _widthInPixel;
            }
        }

        /// <summary>
        /// Gets the size of the tile.
        /// </summary>
        /// <value>
        /// The size of the tile.
        /// </value>
        public int TileSize
        {
            get
            {
                return _tileSize;
            }
        }

        /// <summary>
        /// Gets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public TiledMap GetMap
        {
            get
            {
                return _getMap;
            }
        }

        /// <summary>
        /// Gets the identifier tile collide.
        /// </summary>
        /// <value>
        /// The identifier tile collide.
        /// </value>
        public int IdTileCollide
        {
            get
            {
                return _idTileCollide;
            }
        }

        /// <summary>
        /// Gets or sets the layer collide.
        /// </summary>
        /// <value>
        /// The layer collide.
        /// </value>
        public TiledTileLayer LayerCollide
        {
            get
            {
                return _collideLayer["Collide"];
            }
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            _context.Player.LoadContent(content);
            if (_context.WorldAPI.CurrentLevel == 0)
            {
                _getMap = content.Load<TiledMap>(@"Surface\Map");
                _idTileCollide = 645;
            }
            else
            {
                _getMap = content.Load<TiledMap>(_context.WorldAPI.GetLevel.GetRoom.RoomCharateristcs.NameOfMap + @"\" + _context.WorldAPI.GetLevel.GetRoom.RoomCharateristcs.NumberOfStyleRoom);
                _idTileCollide = 3143;
            }

            foreach (TiledTileLayer e in _getMap.TileLayers)
            {
                if (e != null)
                {
                    switch (e.Name)
                    {
                        case "Collide":
                            _collideLayer.Add("Collide", e);
                            break;

                        case "SecretCollide":
                            _collideLayer.Add("SecretCollide", e);
                            break;

                        case "UpOne":
                            _upLayer.Add("UpOne", e);
                            break;

                        case "UpTwo":
                            _upLayer.Add("UpTwo", e);
                            break;

                        case "Ground +3":
                            _groundLayer.Add("Ground +3", e);
                            break;

                        case "Ground +2":
                            _groundLayer.Add("Ground +2", e);
                            break;

                        case "Ground +1":
                            _groundLayer.Add("Ground +1", e);
                            break;

                        case "Ground":
                            _groundLayer.Add("Ground", e);
                            break;

                        case "Door":
                            _groundLayer.Add("Door", e);
                            break;

                        case "RightDoorBlock":
                            _groundLayer.Add("RightDoorBlock", e);
                            break;

                        case "LeftDoorBlock":
                            _groundLayer.Add("LeftDoorBlock", e);
                            break;

                        case "TopDoorBlock":
                            _groundLayer.Add("TopDoorBlock", e);
                            break;

                        case "BottomDoorBlock":
                            _groundLayer.Add("BottomDoorBlock", e);
                            break;

                        case "Wall":
                            _groundLayer.Add("Wall", e);
                            break;

                        case "Wall +1":
                            _groundLayer.Add("Wall +1", e);
                            break;

                        case "Wall +2":
                            _groundLayer.Add("Wall +2", e);
                            break;

                        case "Decor":
                            _upLayer.Add("Decor", e);
                            break;

                        case "SecretDoor":
                            _upLayer.Add("SecretDoor", e);
                            break;
                    }
                }
            }

            _tileSize = _getMap.TileHeight;
            _heightInPixels = _getMap.HeightInPixels;
            _widthInPixel = _getMap.WidthInPixels;

            if (_getMap != null) _getMap = null;

            foreach(TiledTileLayer layer in _collideLayer.Values)
            {
                layer.IsVisible = false;
            }

        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {

        }

        /// <summary>
        /// Draws the specified sprite.
        /// </summary>
        /// <param name="spriteBatch">The sprite Batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            DrawLayer(true, spriteBatch);

            _context.Player.Draw(spriteBatch);

            DrawLayer(false, spriteBatch);

        }

        /// <summary>
        /// Draws the layer.
        /// </summary>
        /// <param name="couche">if set to <c>true</c> [couche].</param>
        /// <param name="spriteBatch">The sprite batch.</param>
        public void DrawLayer(bool couche, SpriteBatch spriteBatch)
        {
            if (couche)
            {
                foreach (TiledTileLayer layer in _groundLayer.Values)
                {
                    layer.Draw(spriteBatch);
                }
            }
            else
            {
                foreach (TiledTileLayer layer in _upLayer.Values)
                {
                    layer.Draw(spriteBatch);
                }
            }
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        /// <param name="content"></param>
        public void Unload(ContentManager content)
        {
            foreach (TiledTileLayer layer in _upLayer.Values)
            {
                layer.Dispose();
            }

            foreach (TiledTileLayer layer in _groundLayer.Values)
            {
                layer.Dispose();
            }

            foreach (TiledTileLayer layer in _collideLayer.Values)
            {
                layer.Dispose();
            }

            _collideLayer.Clear();
            _upLayer.Clear();
            _groundLayer.Clear();

            if (_getMap != null) _getMap.Dispose();

            _context.Player.Unload();
        }


    }
}
