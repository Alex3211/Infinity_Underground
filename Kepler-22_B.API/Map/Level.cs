using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Map
{
    public class Level
    {
        int _level, _maxLevel;
        RoomInLevel _room;
        World _world;

        public Level(World context)
        {
            _room = new RoomInLevel(this);
            _world = context;
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
        public int GetCurrentlevel { get { return _level; } set { _level = value; } }


        /// <summary>
        /// Gets or sets the get maxlevel.
        /// </summary>
        /// <value>
        /// The get maxlevel.
        /// </value>
        public int GetMaxlevel { get { return _maxLevel; } set { _maxLevel = value; } }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The world.
        /// </value>
        public World World { get { return _world; } }


    }
}
