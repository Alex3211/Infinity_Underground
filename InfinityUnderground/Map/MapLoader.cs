using InfinityUnderground;
using InfinityUnderground.API.Characteres;
using InfinityUnderground.API.Map;
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
        TiledTileLayer _getLayerCollide, _getLayerDoorCollide, _firstLayer, _secondLayer, _LeftDoor, _RightDoor, _TopDoor, _BottomDoor;
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
                if (e != null && e.Name == "RightDoorBlock") _RightDoor = e;
                if (e != null && e.Name == "BottomDoorBlock") _BottomDoor = e;
                if (e != null && e.Name == "LeftDoorBlock") _LeftDoor = e;
                if (e != null && e.Name == "TopDoorBlock") _TopDoor = e;
            }
            if(_TopDoor != null && !_context.WorldAPI.Level.GetRooms.IsBeginRoom && !_context.WorldAPI.Level.GetRooms.IsFinalRoom) _TopDoor.IsVisible = true;
            if(_BottomDoor != null && !_context.WorldAPI.Level.GetRooms.IsBeginRoom && !_context.WorldAPI.Level.GetRooms.IsFinalRoom) _BottomDoor.IsVisible = true;
            if(_RightDoor != null && !_context.WorldAPI.Level.GetRooms.IsBeginRoom && !_context.WorldAPI.Level.GetRooms.IsFinalRoom) _RightDoor.IsVisible = true;
            if(_LeftDoor != null && !_context.WorldAPI.Level.GetRooms.IsBeginRoom && !_context.WorldAPI.Level.GetRooms.IsFinalRoom) _LeftDoor.IsVisible = true;
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
            if (_context.GetCreateMonster != null) _context.GetCreateMonster.DrawDead(spriteBatch);
            _context.Player.Draw(spriteBatch);
            LayerIsVisible(true);
            _firstLayer.Draw(spriteBatch);
            _secondLayer.Draw(spriteBatch);
            if (!_context.WorldAPI.IsSurface && !_context.WorldAPI.Level.GetRooms.IsBeginRoom && !_context.WorldAPI.Level.GetRooms.IsFinalRoom) DrawDoorOrNot();
            //if (_context.GetGameState == GameState.UNDERGROUND)
            //{
            //    _context.ManageUnderGroundGame.MiniMap.Draw(spriteBatch, this.GetMap.WidthInPixels, this.GetMap.HeightInPixels);
            //    _context.DrawMiniMap = false;
            //}
        }

        public void DrawDoorOrNot()
        {

            if (!_context.WorldAPI.IsSurface && !_context.WorldAPI.Level.GetRooms.IsBeginRoom && !_context.WorldAPI.Level.GetRooms.IsFinalRoom)
            {
                List<DoorDirection> _list = _context.WorldAPI.Level.GetRooms.DoorIsDrawable();
                foreach (DoorDirection door in _list)
                {
                    switch (door)
                    {
                        case DoorDirection.Top:
                            _TopDoor.IsVisible = false;
                            break;
                        case DoorDirection.Bottom:
                            _BottomDoor.IsVisible = false;
                            break;
                        case DoorDirection.Right:
                            _RightDoor.IsVisible = false;
                            break;
                        case DoorDirection.Left:
                            _LeftDoor.IsVisible = false;
                            break;
                    }
                }



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

        public TiledTileLayer GetRightDoor { get { return _RightDoor; } set { _RightDoor = value; } }
        public TiledTileLayer GetBottomDoor { get { return _BottomDoor; } set { _BottomDoor = value; } }
        public TiledTileLayer GetLeftDoor { get { return _LeftDoor; } set { _LeftDoor = value; } }
        public TiledTileLayer GetTopDoor { get { return _TopDoor; } set { _TopDoor = value; } }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload(ContentManager content)
        {
            if (_getMap != null) _getMap.Dispose();
            if (_getLayerCollide != null) _getLayerCollide.Dispose();
            if (_getLayerDoorCollide != null) _getLayerDoorCollide.Dispose();
            if (_firstLayer != null) _firstLayer.Dispose();
            if (_secondLayer != null) _secondLayer.Dispose();
            if (_RightDoor != null) _RightDoor.Dispose();
            if (_BottomDoor != null) _BottomDoor.Dispose();
            if (_LeftDoor != null) _LeftDoor.Dispose();
            if (_TopDoor != null) _TopDoor.Dispose();
        }


    }
}
