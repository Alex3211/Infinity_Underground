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
        Texture2D _room;
        ManageUnderground _context;
        Color[] _data;
        List<RoomInMiniMap> _listOfRoom;
        Color _color;
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
        public void SetColor(RoomInMiniMap room, ref Texture2D roomRectangle)
        {
            _color = new Color(102, 102, 102);

            if (_context.Context.WorldAPI.Level.GetRooms.PosCurrentRoom == room.RoomPos)
            {
                _color = new Color(255, 255, 255);
            }

            for (int i = 0; i < _data.Length; i++)
            {
                _data[i] = _color;
            }

            roomRectangle.SetData(_data);
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

            if (_changeRoom)
            {

                _data = new Color[_widthRoom * _heightRoom];

                foreach (RoomInMiniMap room in _listOfRoom)
                {
                    _room = new Texture2D(_context.Context.GraphicsDevice, _widthRoom, _heightRoom);

                    SetColor(room, ref _room);
                    spriteBatch.Draw(_room, new Vector2(_context.Context.CameraLoader.GetCamera.Position.X + (room.PosInPixel.X) + 800, _context.Context.CameraLoader.GetCamera.Position.Y + (room.PosInPixel.Y) + 5), Color.White);
                }

            }
            else
            {
                foreach(RoomInMiniMap room in _listOfRoom)
                {
                    spriteBatch.Draw(_room, new Vector2(_context.Context.CameraLoader.GetCamera.Position.X + (room.PosInPixel.X) + 800, _context.Context.CameraLoader.GetCamera.Position.Y + (room.PosInPixel.Y) + 5), Color.White);
                }
            }


        }

        

    }
}
