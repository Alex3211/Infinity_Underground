using InfinityUndergroundReload.API.Underground;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityUndergroundReload.Map
{

    class MiniMap
    {
        int _widthRoom, _heightRoom;
        Texture2D _roomIn;
        Texture2D _roomOut;
        Texture2D _actualRoom;
        Texture2D _room;
        MapLoader _context;


        /// <summary>
        /// Initializes a new instance of the <see cref="MiniMap"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public MiniMap(MapLoader context)
        {
            _context = context;
        }

        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        /// <param name="widthRoom">The width room.</param>
        /// <param name="heightRoom">The height room.</param>
        public void Draw(SpriteBatch spriteBatch, int widthRoom, int heightRoom)
        {
            _heightRoom = heightRoom / 200;
            _widthRoom = widthRoom / 200;

            if (_room != null) _room.Dispose();
            if (_roomIn != null) _roomIn.Dispose();
            if (_roomOut != null) _roomOut.Dispose();
            if (_actualRoom != null) _actualRoom.Dispose();


            _roomIn = new Texture2D(_context.Context.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            _roomIn.SetData(new Color[] { Color.Green });

            _roomOut = new Texture2D(_context.Context.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            _roomOut.SetData(new Color[] { Color.PaleVioletRed });

            _actualRoom = new Texture2D(_context.Context.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            _actualRoom.SetData(new Color[] { Color.White });

            _room = new Texture2D(_context.Context.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            _room.SetData(new Color[] { Color.Gray });


            foreach (RoomInLevel room in _context.Context.WorldAPI.GetLevel.RoomsInLevel)
            {
                if (room.Position == new Vector2(0, 0))
                {
                    spriteBatch.Draw(_roomIn, new Rectangle((int)(_context.Context.Camera.Position.X + (room.Position.X * (_widthRoom + 10) + 800)), (int)(_context.Context.Camera.Position.Y + (room.Position.Y * (_heightRoom + 10)) + 5), _widthRoom, _heightRoom), Color.White);
                }
                else if (room.Position == _context.Context.WorldAPI.GetLevel.RoomOutPosition)
                {
                    spriteBatch.Draw(_roomOut, new Rectangle((int)(_context.Context.Camera.Position.X + (room.Position.X * (_widthRoom + 10) + 800)), (int)(_context.Context.Camera.Position.Y + (room.Position.Y * (_heightRoom + 10)) + 5), _widthRoom, _heightRoom), Color.White);
                }
                else if (room.Position == _context.Context.WorldAPI.GetLevel.PositionCurrentRoom)
                {
                    spriteBatch.Draw(_actualRoom, new Rectangle((int)(_context.Context.Camera.Position.X + (room.Position.X * (_widthRoom + 10) + 800)), (int)(_context.Context.Camera.Position.Y + (room.Position.Y * (_heightRoom + 10)) + 5), _widthRoom, _heightRoom), Color.White);
                }
                else
                {
                    spriteBatch.Draw(_room, new Rectangle((int)(_context.Context.Camera.Position.X + (room.Position.X * (_widthRoom + 10) + 800)), (int)(_context.Context.Camera.Position.Y + (room.Position.Y * (_heightRoom + 10)) + 5), _widthRoom, _heightRoom), Color.White);
                }
            }


         }
    }
}
