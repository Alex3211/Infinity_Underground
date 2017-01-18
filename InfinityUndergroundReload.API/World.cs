using InfinityUndergroundReload.API.Characters;
using InfinityUndergroundReload.API.Underground;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace InfinityUndergroundReload.API
{
    public class World
    {
        ULevel _level;
        CPlayer _player;
        int _currentLevel;
        int _maxLevel;
        int _tileSize;
        Door _firstDoor;
        Random _random;
        List<CNPC> _listOfMonster;
        //Fights _fights;
        Vector2 _lastPositionOfThePlayer;
        Vector2 _newPositionOfThePlayer;

        public World()
        {
            _random = new Random();
            _player = new CPlayer();
            _listOfMonster = new List<CNPC>();
            _maxLevel = 1;
            _tileSize = 32;
        }

        /// <summary>
        /// Gets the list of monster.
        /// </summary>
        /// <value>
        /// The list of monster.
        /// </value>
        public List<CNPC> ListOfMonster
        {
            get
            {
                return _listOfMonster;
            }

            set
            {
                _listOfMonster = value;
            }
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        public CPlayer Player
        {
            get
            {
                return _player;
            }
        }

        /// <summary>
        /// Gets the current level.
        /// </summary>
        /// <value>
        /// The current level.
        /// </value>
        public int CurrentLevel
        {
            get
            {
                return _currentLevel;
            }
        }

        /// <summary>
        /// Gets the current level.
        /// </summary>
        /// <value>
        /// The current level.
        /// </value>
        public int GetMaxLevel
        {
            get
            {
                return _maxLevel;
            }
            set
            {
                _maxLevel = value;
            }
        }

        /// <summary>
        /// Gets the get level.
        /// </summary>
        /// <value>
        /// The get level.
        /// </value>
        public ULevel GetLevel
        {
            get
            {
                return _level;
            }
        }

        /// <summary>
        /// Creates the level.
        /// </summary>
        public void CreateLevel()
        {
            _level = new ULevel(this, _maxLevel);
        }

        /// <summary>
        /// Gets the random.
        /// </summary>
        /// <value>
        /// The random.
        /// </value>
        public Random Random
        {
            get
            {
                return _random;
            }
        }
        /// <summary>
        /// Creates the door.
        /// </summary>
        public void CreateDoor()
        {
            ClearDoor();

            if (_currentLevel == 0)
            {
                AddDoor(new Vector2(9, 19), new Vector2(11, 19), DoorDirection.Center);
            }
            else
            {
                if (_level.PositionCurrentRoom == new Vector2(0,0))
                    AddDoor(new Vector2(29, 8), new Vector2(31, 9), DoorDirection.Up);
                if (_level.PositionCurrentRoom == _level.RoomOutPosition)
                    AddDoor(new Vector2(29, 11), new Vector2(32, 13), DoorDirection.Center);
                if (_level.PositionCurrentRoom.Y > 0)
                    AddDoor(new Vector2(29, 2), new Vector2(32, 3), DoorDirection.Top);
                if (_level.PositionCurrentRoom.X > 0)
                    AddDoor(new Vector2(0, 11), new Vector2(1, 13), DoorDirection.Left);
                if (_level.PositionCurrentRoom.Y <= (_level.RoomOutPosition.Y * 2))
                    AddDoor(new Vector2(30, 28), new Vector2(32, 28), DoorDirection.Bottom);
                if (_level.PositionCurrentRoom.X <= (_level.RoomOutPosition.X * 2))
                    AddDoor(new Vector2(61, 11), new Vector2(61, 13), DoorDirection.Right);
            }
        }

        /// <summary>
        /// Adds doors.
        /// </summary>
        public void AddDoor(Vector2 moreThan, Vector2 lowerThan, DoorDirection direction)
        {
            Door _newDoor = new Door(moreThan, lowerThan, direction);
            _newDoor.NextDoor = _firstDoor;
            _firstDoor = _newDoor;
        }

        /// <summary>
        /// Clears the door.
        /// </summary>
        public void ClearDoor()
        {
            _firstDoor = null;
        }

        /// <summary>
        /// Players the take door.
        /// </summary>
        /// <returns></returns>
        public Door PlayerTakeDoor()
        {
            Door _currentDoor = null;
            if (!(_firstDoor == null))
            {
                _currentDoor = _firstDoor;
            }

            while (_currentDoor != null)
            {
                if ((((_player.Position.X / _tileSize) >= _currentDoor.MoreThan.X) && ((_player.Position.X / _tileSize) <= _currentDoor.LowerThan.X)) && (((_player.Position.Y / _tileSize) >= _currentDoor.MoreThan.Y) && ((int)(_player.Position.Y / _tileSize) <= _currentDoor.LowerThan.Y)))
                {
                    return _currentDoor;
                }

                _currentDoor = _currentDoor.NextDoor;
            }

            if (_player.IsDead)
            {
                _currentDoor = new Door(new Vector2(0,0), new Vector2(0, 0), DoorDirection.Center);
                return _currentDoor;
            }

            return null;
        }

        public List<DoorDirection> DoorIsDrawable()
        {
            List<DoorDirection> _doorsDirection = new List<DoorDirection>();
            Door _currentDoor = null;
            if (!(_firstDoor == null))
            {
                _currentDoor = _firstDoor;
            }
            while (_currentDoor != null)
            {
                if (_currentDoor.DoorDirection == DoorDirection.Top || _currentDoor.DoorDirection == DoorDirection.Left || _currentDoor.DoorDirection == DoorDirection.Bottom || _currentDoor.DoorDirection == DoorDirection.Right)
                    _doorsDirection.Add(_currentDoor.DoorDirection);
                _currentDoor = _currentDoor.NextDoor;
            }
            return _doorsDirection;
        }

        /// <summary>
        /// Actions the with door.
        /// </summary>
        /// <param name="doorSelected">The door selected.</param>
        public void ActionWithDoor(Door doorSelected)
        {

            switch(doorSelected.DoorDirection)
            {
                case DoorDirection.Up:
                    if (_maxLevel < _currentLevel) _maxLevel = _currentLevel;
                    _currentLevel = 0;
                    _player.Position = new Vector2(10 * _tileSize, 22 * _tileSize);
                    break;

                case DoorDirection.Center:
                    _player.Position = new Vector2(31 * _tileSize, 18 * _tileSize);
                    if (!_player.IsDead)
                    {
                        if (_currentLevel == 0)
                        {
                            _currentLevel = _maxLevel;
                        }
                        else
                        {
                            _currentLevel++;
                        }
                    }
                    else
                    {
                        _player.IsDead = false;
                    }
                    _player.CharacterType.LifePoint = _player.CharacterType.MaxLifePoint;
                    _level = new ULevel(this, _currentLevel);
                    _level.CreateRoom();
                    
                    break;

                case DoorDirection.Left:
                    _player.PositionX = 60 * _tileSize;
                    _level.PositionCurrentRoomX--;
                    _level.CreateRoom();
                    break;

                case DoorDirection.Right:
                    _player.PositionX = 3 * _tileSize;
                    _level.PositionCurrentRoomX++;
                    _level.CreateRoom();
                    break;

                case DoorDirection.Top:
                    _player.PositionY = 28 * _tileSize;
                    _level.PositionCurrentRoomY--;
                    _level.CreateRoom();
                    break;

                case DoorDirection.Bottom:
                    _player.PositionY = 2 * _tileSize;
                    _level.PositionCurrentRoomY++;
                    _level.CreateRoom();
                    break;

            }

            CreateDoor();
            if (CurrentLevel != 0) CreateMonster();
        }

        /// <summary>
        /// Creates the monster.
        /// </summary>
        void CreateMonster()
        {
            _listOfMonster.Clear();
            for (int i = 0; i < GetLevel.GetRoom.RoomCharateristcs.NbOfNPC; i++)
            {
                switch(_random.Next(0,2))
                {
                    case 0:
                        _listOfMonster.Add(new CDragon(this));
                        break;

                    case 1:
                        _listOfMonster.Add(new CCuriosity4(this));
                        break;
                }
            }
        }

        /// <summary>
        /// Creates the fight.
        /// </summary>
        public Fights CreateFight(CNPC monster)
        {
            _lastPositionOfThePlayer = Player.Position;
            _newPositionOfThePlayer = new Vector2(70, 720);
            Player.Position = _newPositionOfThePlayer;
            return new Fights(this, Player.Position, monster);
        }

        public void ExitFights()
        {
            Player.Position = _lastPositionOfThePlayer;
        }
    }
}
