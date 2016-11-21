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
        List<RoomInLevel> _room;
        Vector2 _roomVector;
        Vector2 _roomOut;
        World _world;

        public Level(World context)
        {
            _room = new List<RoomInLevel>();
            _world = context;
        }

    }
}
