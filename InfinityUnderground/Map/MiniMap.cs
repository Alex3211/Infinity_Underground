using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.Map
{

    public class RoomInMiniMap
    {

        Vector2 _posRoom, _posInPixel;

        public RoomInMiniMap(Vector2 roomPos, int posInPixelX, int posInPixelY)
        {
            _posInPixel = new Vector2(posInPixelX, posInPixelY);
            _posRoom = roomPos;
        }

        /// <summary>
        /// Gets the room position.
        /// </summary>
        /// <value>
        /// The room position.
        /// </value>
        public Vector2 RoomPos { get { return _posRoom; } }

        /// <summary>
        /// Gets or sets the position in pixel.
        /// </summary>
        /// <value>
        /// The position in pixel.
        /// </value>
        public Vector2 PosInPixel { get { return _posInPixel; } }

    }

    public class MiniMap
    {
        int _widthRoom, _heightRoom;
        Texture2D _roomIn, _roomOut, _actualRoom, _room;
        ManageUnderground _context;
        List<RoomInMiniMap> _listOfRoom;
        bool _changeRoom;


        public MiniMap(ManageUnderground context)
        {
            _context = context;
            _listOfRoom = new List<RoomInMiniMap>();
        }

        /// <summary>
        /// Load the minimap when you changed room.
        /// </summary>
        public bool ChangeRoom { get{ return _changeRoom; }  set { _changeRoom = value; } }

        /// <summary>
        /// Gets the list of room.
        /// </summary>
        /// <value>
        /// The list of room.
        /// </value>
        public List<RoomInMiniMap> ListOfRoom { get { return _listOfRoom; } }

        /// <summary>
        /// Adds the room.
        /// </summary>
        /// <param name="pos">The position.</param>
        public void AddRoom(Vector2 pos)
        {
            _listOfRoom.Add(new RoomInMiniMap(pos, (int)(pos.X * (_widthRoom + 10)), (int)(pos.Y * (_heightRoom + 10))));
        }

        /// <summary>
        /// Sets the color.
        /// </summary>
        public void SetColor(RoomInMiniMap room)
        {

            if (_context.Context.WorldAPI.Level.GetRooms.PosCurrentRoom == room.RoomPos)
            {
                _room.SetData(new Color[] { Color.White });
            }
            else
            {
                _room.SetData(new Color[] { Color.Gray });
            }

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


            foreach (RoomInMiniMap room in _listOfRoom)
            {
                if (room.RoomPos == new Vector2(0,0))
                {
                    spriteBatch.Draw(_roomIn, new Rectangle((int)(_context.Context.GetCamera.Position.X + (room.PosInPixel.X) + 800), (int)(_context.Context.GetCamera.Position.Y + (room.PosInPixel.Y) + 5), _widthRoom, _heightRoom), Color.White);
                }
                else if(room.RoomPos == _context.Context.WorldAPI.Level.GetRooms.RoomOut)
                {
                    spriteBatch.Draw(_roomOut, new Rectangle((int)(_context.Context.GetCamera.Position.X + (room.PosInPixel.X) + 800), (int)(_context.Context.GetCamera.Position.Y + (room.PosInPixel.Y) + 5), _widthRoom, _heightRoom), Color.White);
                }
                else if (room.RoomPos == _context.Context.WorldAPI.Level.GetRooms.PosCurrentRoom)
                {
                    spriteBatch.Draw(_actualRoom, new Rectangle((int)(_context.Context.GetCamera.Position.X + (room.PosInPixel.X) + 800), (int)(_context.Context.GetCamera.Position.Y + (room.PosInPixel.Y) + 5), _widthRoom, _heightRoom), Color.White);
                }
                else
                {
                    spriteBatch.Draw(_room, new Rectangle((int)(_context.Context.GetCamera.Position.X + (room.PosInPixel.X) + 800), (int)(_context.Context.GetCamera.Position.Y + (room.PosInPixel.Y) + 5), _widthRoom, _heightRoom), Color.White);
                }
            }




            
        }    

    }
}
