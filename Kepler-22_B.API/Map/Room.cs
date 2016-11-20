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
        List<string> _listOfTypeRoom;
        string _typeOfRoom;
        Level _level;

        public Room(Level context)
        {
            _ctNpc = new List<CTNPC>();
            _door = new List<Door>();
            _level = context;
            _listOfTypeRoom = new List<string>();
            _listOfTypeRoom.Add("Labyrinthe");
            _listOfTypeRoom.Add("BossRoom");
            _listOfTypeRoom.Add("TrapRoom");
        }

    }
}
