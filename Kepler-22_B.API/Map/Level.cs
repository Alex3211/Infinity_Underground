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
        RoomInLevel _room;
        Door _roomInLevel;
        World _world;
        Random r;

        public Level(World context)
        {
            _room = new RoomInLevel(this);
            _world = context;

        }

        public void ChangeLevel()
        {
            if(_room.PlayerInTheDoor() != null)
            {
                _roomInLevel = _room.PlayerInTheDoor();
                _level++;
            }
        }

        /// <summary>
        /// Gets the list of rooms.
        /// </summary>
        /// <value>
        /// The get list of rooms.
        /// </value>
        public RoomInLevel GetRooms { get { return _room; } }

        /// <summary>
        /// Gets the currentlevel.
        /// </summary>
        /// <value>
        /// The get currentlevel.
        /// </value>
        public int GetCurrentlevel { get { return _level; } }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The world.
        /// </value>
        public World World { get { return _world; } }


    }
}
