using Kepler_22_B.API.Characteres;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Map
{
    class RoomInLevel
    {
        List<CTNPC> _ctNpc;
        Door _firstDoor;
        List<object> _listOfTypeRoom;
        object _typeOfRoom;
        Level _context;
        Random r;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomInLevel"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RoomInLevel(Level context)
        {
            r = new Random();
            _ctNpc = new List<CTNPC>();
            _context = context;
            _firstDoor = null;

            _listOfTypeRoom = new List<object>();
            _listOfTypeRoom.Add(new LabyrintheRoom());
            _listOfTypeRoom.Add("BossRoom");
            _listOfTypeRoom.Add("TrapRoom");
            _listOfTypeRoom.Add("SecretRoom");
            _listOfTypeRoom.Add("MonsterRoom");

            _typeOfRoom = _listOfTypeRoom[r.Next(_listOfTypeRoom.Count)];
        }

        /// <summary>
        /// Adds the door.
        /// </summary>
        /// <param name="moreThan">The more than.</param>
        /// <param name="lowerThan">The lower than.</param>
        /// <param name="position">The position.</param>
        public void AddDoor(Vector2 moreThan, Vector2 lowerThan, string position)
        {
            Door _newDoor = new Door(moreThan, lowerThan, position);
            _newDoor.NextDoor = _firstDoor;    
            _firstDoor = _newDoor;
        }

        /// <summary>
        /// Players the in the door.
        /// </summary>
        /// <returns></returns>
        public bool PlayerInTheDoor()
        {
            while(_firstDoor.NextDoor != null)
            {
                
            }
            return false;
        }

    }
}
