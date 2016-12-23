using Kepler_22_B.API.Data;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.Map
{

    public class SaveMap
    {
        readonly Vector2 _position;
        readonly string _typeOfRoom;
        readonly string _numberOfRoom;

        public SaveMap(Vector2 pos, string typeOfRoom, string numberOfRoom)
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
        internal Vector2 Position { get{ return _position; } }

        /// <summary>
        /// Gets the type of room.
        /// </summary>
        /// <value>
        /// The type of room.
        /// </value>
        internal string TypeOfRoom { get{ return _typeOfRoom; } }

        /// <summary>
        /// Gets the number of room.
        /// </summary>
        /// <value>
        /// The number of room.
        /// </value>
        internal string NumberOfRoom { get{ return _numberOfRoom; } }

    }


    public class ManageUnderground
    {
        Dictionary<Vector2, MapLoader> _undergroundMapLevel;

        List<SaveMap> _mapOfUnderground;

        Game1 _context;
        MiniMap _miniMap;
        Data _saveMap;
        string _guid;

        public ManageUnderground(Game1 context)
        {
            _context = context;
            _context.ManageUnderGroundGame = this;

            _mapOfUnderground = new List<SaveMap>();
            
            _miniMap = new MiniMap(this);
        }

        /// <summary>
        /// Gets the mini map.
        /// </summary>
        /// <value>
        /// The mini map.
        /// </value>
        public MiniMap MiniMap { get { return _miniMap; } }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public Game1 Context { get { return _context; } }

        /// <summary>
        /// Gets or sets the list of room level underground.
        /// </summary>
        /// <value>
        /// The list of room level underground.
        /// </value>
        public List<SaveMap> ListOfRoomLevelUnderground { get { return _mapOfUnderground; } set { _mapOfUnderground = value; } }

        /// <summary>
        /// Adds the room to the list.
        /// </summary>
        public void AddRoomToTheList()
        {
            _mapOfUnderground.Add(new SaveMap(_context.WorldAPI.Level.GetRooms.PosCurrentRoom, _context.WorldAPI.Level.GetRooms.TypeOfRoom.NameOfMap, _context.WorldAPI.Level.GetRooms.NBRandom.ToString()));

            _miniMap.AddRoom(_context.WorldAPI.Level.GetRooms.PosCurrentRoom);
            _context.DrawMiniMap = true;
        }

        





    }
}
