using Kepler_22_B.API.Characteres;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace Kepler_22_B.API.Map
{
    public class RoomInLevel
    {
        List<CTNPC> _ctNpc;
        Door _firstDoor;
        List<Room> _listOfTypeRoom;
        Room _typeOfRoom;
        Level _context;
        Random rand;
        Vector2 _roomOut, _posCurrentRoom;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomInLevel"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public RoomInLevel(Level context)
        {
            rand = new Random();
            _ctNpc = new List<CTNPC>();
            _context = context;
            _firstDoor = null;
            _posCurrentRoom = new Vector2(0, 0);
            _roomOut = new Vector2(0, 0);


            _listOfTypeRoom = new List<Room>();
        }

        /// <summary>
        /// Gets or sets the position current room.
        /// </summary>
        /// <value>
        /// The position current room.
        /// </value>
        public Vector2 PosCurrentRoom { get { return _posCurrentRoom; } }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public Level Context { get{ return _context; } }

        /// <summary>
        /// Gets the first door.
        /// </summary>
        /// <value>
        /// The first door.
        /// </value>
        public Door FirstDoor { get { return _firstDoor; } }

        /// <summary>
        /// Return the type of room.
        /// </summary>
        public Room TypeOfRoom { get { return _typeOfRoom; } }

        /// <summary>
        /// Switches the room.
        /// </summary>
        public bool SwitchRoom()
        {
            Door _playerDoor = PlayerInTheDoor();
            if (_playerDoor != null)
            {
                changeVectorCurrentRoom(_playerDoor);
                ClearDoor();
                ChangeRoom();
                ChangePositionWithTheSwitchRoom(_playerDoor.DoorDirection);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Create new Room
        /// </summary>
        public void CreateRoom()
        {
            _listOfTypeRoom.Add(new LabyrintheRoom());
            _listOfTypeRoom.Add(new TrapRoom());
            _listOfTypeRoom.Add(new BossRoom());
            _listOfTypeRoom.Add(new SecretRoom());
            _listOfTypeRoom.Add(new MonsterRoom());

            _typeOfRoom = _listOfTypeRoom[rand.Next(_listOfTypeRoom.Count)];

        }

        /// <summary>
        /// Creates the room out.
        /// </summary>
        public void CreateRoomOut()
        {
            _roomOut.X = rand.Next(0, (2 * _context.GetCurrentlevel));
            _roomOut.Y = rand.Next(0, (2 * _context.GetCurrentlevel));
        }


        /// <summary>
        /// Adds the door.
        /// </summary>
        /// <param name="moreThan">The more than.</param>
        /// <param name="lowerThan">The lower than.</param>
        /// <param name="position">The position.</param>
        public void AddDoor(Vector2 moreThan, Vector2 lowerThan, DoorDirection direction)
        {
            Door _newDoor = new Door(moreThan, lowerThan, direction);
            _newDoor.NextDoor = _firstDoor;    
            _firstDoor = _newDoor;
        }

        /// <summary>
        /// Players the in the door.
        /// </summary>
        /// <returns></returns>
        public Door PlayerInTheDoor()
        {
            Door _currentDoor = null;
            if (!(_firstDoor == null))
            {
                _currentDoor = _firstDoor;
            }

            while (_currentDoor != null)
            {
                foreach(CTPlayer player in _context.World.Players)
                {
                    if (((player.PositionX / _context.World.TildeWidth >= _currentDoor.MoreThan.X) && (player.PositionX / _context.World.TildeWidth <= _currentDoor.LowerThan.X)) && ((player.PositionY / _context.World.TildeWidth >= _currentDoor.MoreThan.Y) && (player.PositionY / _context.World.TildeWidth <= _currentDoor.LowerThan.Y))) return _currentDoor;
                }
                _currentDoor = _currentDoor.NextDoor;
            }
            return null;
        }

        /// <summary>
        /// Change the Vector of the current Room
        /// </summary>
        /// <param name="doorWhoTakeThePlayer">The door who take the player</param>
        public void changeVectorCurrentRoom(Door doorWhoTakeThePlayer)
        {
            switch(doorWhoTakeThePlayer.DoorDirection)
            {
                case DoorDirection.Top:
                    _posCurrentRoom.Y--;
                    break;


                case DoorDirection.Left:
                    _posCurrentRoom.X--;
                    break;


                case DoorDirection.Bottom:
                    _posCurrentRoom.Y++;
                    break;


                case DoorDirection.Right:
                    _posCurrentRoom.X++;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }


        /// <summary>
        /// Clears the door.
        /// </summary>
        public void ClearDoor()
        {
            _firstDoor = null;
        }

        /// <summary>
        /// Change the room.
        /// </summary>
        public void ChangeRoom()
        {
            CreateRoom();
            if (_posCurrentRoom.Y > 0)
                AddDoor(new Vector2(26,0), new Vector2(27, 2), DoorDirection.Top);

            if (_posCurrentRoom.X > 0)
                AddDoor(new Vector2(0, 14), new Vector2(0, 16), DoorDirection.Left);

            if (_posCurrentRoom.X <= _roomOut.X)
                AddDoor(new Vector2(46, 31), new Vector2(47, 31), DoorDirection.Bottom);

            if (_posCurrentRoom.Y <= _roomOut.Y)
                AddDoor(new Vector2(63, 14), new Vector2(63, 16), DoorDirection.Right);

        }

        void ChangePositionWithTheSwitchRoom(DoorDirection doorDirection)
        {
            foreach (CTPlayer player in _context.World.Players)
            {
                switch (doorDirection)
                {
                    case DoorDirection.Top:
                        player.PositionX = 0;
                        player.PositionY = 0;
                        break;

                    case DoorDirection.Left:
                        player.PositionX = 0;
                        player.PositionY = 0;
                        break;

                    case DoorDirection.Bottom:
                        player.PositionX = 0;
                        player.PositionY = 0;
                        break;

                    case DoorDirection.Right:
                        player.PositionX = 0;
                        player.PositionY = 0;
                        break;

                }
            }
            
        }
        
        /// <summary>
        /// Go to the next level.
        /// </summary>
        public void RoomForNextLevel()
        {
            _context.GetCurrentlevel++;
        }




    }
}
