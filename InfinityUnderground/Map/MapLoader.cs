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
using static InfinityUnderground.Game1;

namespace InfinityUnderground.Map
{
    public class MapLoader : IEntity
    {
        Game1 _context;
        TiledMap _getMap;
        TiledTileLayer _getLayerCollide;
        TiledTileLayer _secondLayer;
        TiledTileLayer _getLayerDoorCollide;
        TiledTileLayer _firstLayer;
        TiledTileLayer _ground3;
        TiledTileLayer _ground2;
        TiledTileLayer _ground1;
        TiledTileLayer _ground;

        Dictionary<string, TiledTileLayer> _groundLayer;
        Dictionary<string, TiledTileLayer> _upLayer;
        Dictionary<string, TiledTileLayer> _collideLayer;

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

            _groundLayer = new Dictionary<string, TiledTileLayer>();
            _upLayer = new Dictionary<string, TiledTileLayer>();
            _collideLayer = new Dictionary<string, TiledTileLayer>();


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
                if (e != null)
                {
                    switch(e.Name)
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

            GetLayerCollide.IsVisible = false;
        }

        /// <summary>
        /// Define which Layers is visible.
        /// </summary>
        /// <param name="couche">if set to <c>true</c> [couche].</param>
        public void DrawLayer(bool couche, SpriteBatch spriteBatch)
        {
            if (couche)
            {
                foreach(TiledTileLayer layer in _groundLayer.Values)
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
        /// Gets the layer collide.
        /// </summary>
        /// <value>
        /// The get layer collide.
        /// </value>
        public TiledTileLayer GetLayerCollide { get { return _collideLayer["Collide"]; } }

        /// <summary>
        /// Gets the layer door collide, for secret room.
        /// </summary>
        /// <value>
        /// The get layer collide.
        /// </value>
        public TiledTileLayer GetLayerDoorCollide
        {
            get
            {
                return _collideLayer["SecretCollide"];
            }

            set
            {
                if (_collideLayer.ContainsKey("SecretCollide"))
                {
                    _collideLayer["SecretCollide"] = value;
                }
                else
                {
                    _collideLayer.Add("SecretCollide", value);
                }
            }
        }

        /// <summary>
        /// Gets the secret door.
        /// </summary>
        /// <value>
        /// The secret door.
        /// </value>
        public TiledTileLayer GetLayerSecretDoor { get { return _upLayer["SecretDoor"]; } }

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
            DrawLayer(true, spriteBatch);

            if(_context.GetCreateMonster != null) _context.GetCreateMonster.DrawDead(spriteBatch);
            _context.Player.Draw(spriteBatch);

            DrawLayer(false, spriteBatch);

            if (_context.GetGameState == GameState.UNDERGROUND)
            {
                _context.ManageUnderGroundGame.MiniMap.Draw(spriteBatch, this.GetMap.WidthInPixels, this.GetMap.HeightInPixels);
                _context.DrawMiniMap = false;
            }
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
        }


    }
}
