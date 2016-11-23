using Kepler_22_B.API.Characteres;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace Kepler_22_B.API.Map
{
    class RoomInTheLevel
    {
        List<CTNPC> _ctNpc;
        Door _firstDoor;
        List<object> _listOfTypeRoom;
        object _typeOfRoom;
        Level _context;
        Random rand;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomInLevel"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RoomInTheLevel(Level context)
        {
            rand = new Random();
            _ctNpc = new List<CTNPC>();
            _context = context;
            _firstDoor = null;

            _listOfTypeRoom = new List<object>();
            _listOfTypeRoom.Add(new LabyrintheRoom());
            _listOfTypeRoom.Add(new TrapRoom());
            _listOfTypeRoom.Add(new BossRoom());
            _listOfTypeRoom.Add(new SecretRoom());
            _listOfTypeRoom.Add(new MonsterRoom());

            _typeOfRoom = _listOfTypeRoom[rand.Next(_listOfTypeRoom.Count)];
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
            Door _currentDoor = null;
            if (!(_firstDoor == null))
            {
                _currentDoor = _firstDoor;
            }

            while (_currentDoor.NextDoor != null)
            {
                foreach(CTPlayer player in _context.World.Players)
                {
                    if (((player.PositionX >= _currentDoor.MoreThan.X) && (player.PositionX <= _currentDoor.LowerThan.X)) && ((player.PositionY >= _currentDoor.MoreThan.Y) && (player.PositionY <= _currentDoor.LowerThan.Y))) return true;
                }
            }
            return false;
        }


    }
}
