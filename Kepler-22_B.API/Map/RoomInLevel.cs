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
        bool _isFinalRoom;

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
        /// Gets a value indicating whether this instance is final room.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is final room; otherwise, <c>false</c>.
        /// </value>
        public bool IsFinalRoom { get { return _isFinalRoom; } }

        /// <summary>
        /// Gets the room out.
        /// </summary>
        /// <value>
        /// The room out.
        /// </value>
        public Vector2 RoomOut { get{ return _roomOut; } }

        /// <summary>
        /// Gets or sets the position current room.
        /// </summary>
        /// <value>
        /// The position current room.
        /// </value>
        public Vector2 PosCurrentRoom { get { return _posCurrentRoom; } set { _posCurrentRoom = value; } }

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

                if (((_context.World.Player1PositionXInTile >= _currentDoor.MoreThan.X) && (_context.World.Player1PositionXInTile <= _currentDoor.LowerThan.X)) && ((_context.World.Player1PositionYInTile >= _currentDoor.MoreThan.Y) && (_context.World.Player1PositionYInTile <= _currentDoor.LowerThan.Y)))
                {
                    return _currentDoor;
                }

                _currentDoor = _currentDoor.NextDoor;
            }
            return null;
        }


        /// <summary>
        /// Change the Vector of the current Room
        /// </summary>
        /// <param name="doorWhoTakeThePlayer">The door who take the player</param>
        public DoorDirection ChangeVectorCurrentRoom(Door doorWhoTakeThePlayer)
        {
            switch (doorWhoTakeThePlayer.DoorDirection)
            {
                case DoorDirection.Top:
                    _posCurrentRoom.Y--;
                    return DoorDirection.Top;


                case DoorDirection.Left:
                    _posCurrentRoom.X--;
                    return DoorDirection.Left;


                case DoorDirection.Bottom:
                    _posCurrentRoom.Y++;
                    return DoorDirection.Bottom;


                case DoorDirection.Right:
                    _posCurrentRoom.X++;
                    return DoorDirection.Right;

                case DoorDirection.Center:
                    _context.GetCurrentlevel++;
                    return DoorDirection.Center;

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
        /// Change the room.
        /// </summary>
        public void AddDoorInRoom()
        {
            
            if (_context.World.IsSurface)
            {
                AddDoor(new Vector2(9, 19), new Vector2(10, 19), DoorDirection.Center);
            }
            else
            {

                if (_isFinalRoom)
                {
                    AddDoor(new Vector2(30, 11), new Vector2(30, 11), DoorDirection.Center);
                }

                if (_posCurrentRoom.Y > 0)
                    AddDoor(new Vector2(29, 2), new Vector2(32, 3), DoorDirection.Top);

                if (_posCurrentRoom.X > 0)
                    AddDoor(new Vector2(0, 11), new Vector2(0, 13), DoorDirection.Left);

                if (_posCurrentRoom.X <= (_roomOut.X * 2))
                    AddDoor(new Vector2(30, 28), new Vector2(31, 28), DoorDirection.Bottom);

                if (_posCurrentRoom.Y <= (_roomOut.Y * 2))
                    AddDoor(new Vector2(61, 11), new Vector2(61, 13), DoorDirection.Right);
            }

        }




        /// <summary>
        /// Switches the room.
        /// </summary>
        public bool SwitchRoom()
        {
            Door _doorPlayer = PlayerInTheDoor();
            if (_doorPlayer != null && !_isFinalRoom && !_context.World.IsSurface)
            {
                ManageUnderground(_doorPlayer);
                return true;
            }
            return false;
        }






        /// <summary>
        /// Creates the room out.
        /// </summary>
        public bool SwitchLevel()
        {
            Door _doorPlayer = PlayerInTheDoor();
            if (_doorPlayer != null && _doorPlayer.DoorDirection == DoorDirection.Center)
            {
                _posCurrentRoom = new Vector2(0, 0);

                _context.World.Player1PositionXInTile = 0;
                _context.World.Player1PositionYInTile = 0;

                _isFinalRoom = false;
                do
                {
                    if (_context.GetCurrentlevel != 0)
                    {
                        _roomOut.X = rand.Next(0, (2 * _context.GetCurrentlevel));
                        _roomOut.Y = rand.Next(0, (2 * _context.GetCurrentlevel));
                    }
                    else
                    {
                        _roomOut.X = rand.Next(0, 2);
                        _roomOut.Y = rand.Next(0, 2);
                    }
                } while (_roomOut == new Vector2(0,0));

                ManageUnderground(_doorPlayer);

                return true;
            }
            return false;
        }


        /// <summary>
        /// Manage the underground
        /// </summary>
        /// <param name="doorPlayer"></param>
        public void ManageUnderground(Door doorPlayer)
        {
            ChangePlayerPositionWithTheSwitchRoom(ChangeVectorCurrentRoom(doorPlayer));
            IfThePlayerAreInFinalRoom();
            ClearDoor();
            CreateRoom();
            _context.World.PlayerIsSurfaceOrNot();
            AddDoorInRoom();
        }









        /// <summary>
        /// Changes the player position with the switch room.
        /// </summary>
        /// <param name="doorDirection">The door direction.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The player did'nt take door</exception>
        public DoorDirection ChangePlayerPositionWithTheSwitchRoom(DoorDirection doorDirection)
        {
            foreach (CTPlayer player in _context.World.Players)
            {
                switch (doorDirection)
                {
                    case DoorDirection.Top:
                        player.PositionY = 28 * _context.World.TildeWidth;
                        return DoorDirection.Top;

                    case DoorDirection.Left:
                        player.PositionX = 60 * _context.World.TildeWidth;
                        return DoorDirection.Left;

                    case DoorDirection.Bottom:
                        player.PositionY = 5 * _context.World.TildeWidth;
                        return DoorDirection.Bottom;

                    case DoorDirection.Right:
                        player.PositionX = 3 * _context.World.TildeWidth;
                        return DoorDirection.Right;

                    case DoorDirection.Center:
                        player.PositionX = 31 * _context.World.TildeWidth;
                        player.PositionY = 11 * _context.World.TildeWidth;
                        return DoorDirection.Center;

                    default:
                        throw new ArgumentOutOfRangeException("The player did'nt take door");

                }

            }
            return DoorDirection.Center;

        }
        


        /// <summary>
        /// Ifs the player are final room.
        /// </summary>
        public void IfThePlayerAreInFinalRoom()
        {
            if (_posCurrentRoom == _roomOut) _isFinalRoom = true;
        }

    }
}
