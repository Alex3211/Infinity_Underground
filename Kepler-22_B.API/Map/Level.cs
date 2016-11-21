using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Map
{
    class Level
    {
        int _level;
        List<Room> _room;
        Vector2 _roomVector;
        Vector2 _roomOut;
        World _world;

        public Level(World context)
        {
            _room = new List<Room>();
            _world = context;
        }

        /// <summary>
        /// Gets the room vector.
        /// </summary>
        /// <value>
        /// The get room vector.
        /// </value>
        public Vector2 GetRoomVector { get { return _roomVector; } }

        /// <summary>
        /// Gets the room out vector.
        /// </summary>
        /// <value>
        /// The get room out.
        /// </value>
        public Vector2 GetRoomOut { get { return _roomOut; } }

        /// <summary>
        /// Gets the list of rooms.
        /// </summary>
        /// <value>
        /// The get list of rooms.
        /// </value>
        public List<Room> GetListOfRooms { get { return _room; } }

        /// <summary>
        /// Gets the currentlevel.
        /// </summary>
        /// <value>
        /// The get currentlevel.
        /// </value>
        public int GetCurrentlevel { get { return _level; } }

        /// <summary>
        /// Adds the room.
        /// </summary>
        /// <param name="room">The room.</param>
        public void AddRoom(Room room)
        {
            _room.Add(room);
        }
        /// <summary>
        /// Delete the room.
        /// </summary>
        /// <param name="room">The room.</param>
        public void DelRoom(Room room)
        {
            _room.Remove(room);
        }
        /// <summary>
        /// Gets the room.
        /// </summary>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Room GetCurrentRoom(Room room)
        {
            throw new NotImplementedException();
        }



    }
}
