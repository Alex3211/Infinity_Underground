using Kepler_22_B.API.Characteres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Map
{
    class Room
    {
        List<CTNPC> _ctNpc;
        List<Door> _door;
        TypeRoom _typeOfRoom;
        Level _level;

        public Room(Level context)
        {
            _ctNpc = new List<CTNPC>();
            _door = new List<Door>();
            _level = context;

        }

    }
}
