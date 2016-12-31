using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Underground
{

    class RoomInLevel
    {
        readonly Vector2 _position;
        readonly string _typeOfRoom;
        readonly string _numberOfRoom;

        public RoomInLevel(Vector2 pos, string typeOfRoom, string numberOfRoom)
        {
            _position = pos;
            _typeOfRoom = typeOfRoom;
            _numberOfRoom = numberOfRoom;
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        internal Vector2 Position
        {
            get
            {
                return _position;
            }
        }

        /// <summary>
        /// Gets the type of room.
        /// </summary>
        /// <value>
        /// The type of room.
        /// </value>
        internal string TypeOfRoom
        {
            get
            {
                return _typeOfRoom;
            }
        }

        /// <summary>
        /// Gets the number of room.
        /// </summary>
        /// <value>
        /// The number of room.
        /// </value>
        internal string NumberOfRoom
        {
            get
            {
                return _numberOfRoom;
            }
        }

    }


    public class ULevel
    {
        World _context;
        Vector2 _posCurrentRoom;
        Vector2 _roomOut;
        Random _random;

        URoom _room;
        List<RoomInLevel> _saveRoom;

        /// <summary>
        /// Initializes a new instance of the <see cref="ULevel"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ULevel(World context, int currentLevel)
        {
            _random = new Random();
            _context = context;
            _posCurrentRoom = new Vector2();
            _saveRoom = new List<RoomInLevel>();


            while (_roomOut == new Vector2(0, 0))
            {
                _roomOut = new Vector2(_random.Next(1, 2 * currentLevel), _random.Next(1, 2 * currentLevel));
            } 

        }

        public URoom GetRoom
        {
            get
            {
                return _room;
            }
        }

        /// <summary>
        /// Gets the room out position.
        /// </summary>
        /// <value>
        /// The room out position.
        /// </value>
        public Vector2 RoomOutPosition
        {
            get
            {
                return _roomOut;
            }
        }

        /// <summary>
        /// Gets the position current room.
        /// </summary>
        /// <value>
        /// The position current room.
        /// </value>
        public Vector2 PositionCurrentRoom
        {
            get
            {
                return _posCurrentRoom;
            }
        }

        /// <summary>
        /// Gets or sets the position current room x.
        /// </summary>
        /// <value>
        /// The position current room x.
        /// </value>
        public int PositionCurrentRoomX
        {
            get
            {
                return (int)_posCurrentRoom.X;
            }

            set
            {
                _posCurrentRoom.X = value;
            }
        }

        /// <summary>
        /// Gets or sets the position current room y.
        /// </summary>
        /// <value>
        /// The position current room y.
        /// </value>
        public int PositionCurrentRoomY
        {
            get
            {
                return (int)_posCurrentRoom.Y;
            }

            set
            {
                _posCurrentRoom.Y = value;
            }
        }


        /// <summary>
        /// Creates the room.
        /// </summary>
        public void CreateRoom()
        {
            var rooms = from room in _saveRoom where room.Position == _posCurrentRoom select room;

            if (rooms.Count() != 0)
            {
                foreach(RoomInLevel room in rooms)
                {
                    _room = new URoom(this, room.TypeOfRoom, room.NumberOfRoom);
                }
            }
            else
            {
                if (_posCurrentRoom == new Vector2(0, 0))
                {
                    _room = new URoom(this, "In");
                }
                else if (_posCurrentRoom == _roomOut)
                {
                    _room = new URoom(this, "Out");
                }
                else
                {
                    _room = new URoom(this);
                }

                _saveRoom.Add(new RoomInLevel(_posCurrentRoom, _room.RoomCharateristcs.NameOfMap, _room.RoomCharateristcs.NumberOfStyleRoom.ToString()));
            }
        }


    }
}
