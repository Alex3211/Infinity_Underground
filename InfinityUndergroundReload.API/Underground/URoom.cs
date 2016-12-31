using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Underground
{
    enum ListOfTypeRoom
    {
        BossRoom,
        LabyrintheRoom,
        MonsterRoom,
        SecretRoom,
        TrapRoom,
    }

    public class URoom
    {
        readonly ULevel _context;
        readonly UTypeOfRoom _roomCharateristics;
        readonly Random _random;

        /// <summary>
        /// Initializes a new instance of the <see cref="URoom"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public URoom(ULevel context)
        {
            _random = new Random();

            _context = context;

            switch ((ListOfTypeRoom)_random.Next(0, 5))
            {
                case ListOfTypeRoom.BossRoom:
                    _roomCharateristics = new UBossRoom();
                    break;

                case ListOfTypeRoom.LabyrintheRoom:
                    _roomCharateristics = new ULabyrintheRoom();
                    break;

                case ListOfTypeRoom.MonsterRoom:
                    _roomCharateristics = new UMonsterRoom();
                    break;

                case ListOfTypeRoom.SecretRoom:
                    _roomCharateristics = new USecretRoom();
                    break;

                case ListOfTypeRoom.TrapRoom:
                    _roomCharateristics = new UTrapRoom();
                    break;
            }


        }

        /// <summary>
        /// Initializes a new instance of the <see cref="URoom"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="specificRoom">The specific room.</param>
        public URoom(ULevel context, string specificRoom)
        {
            _context = context;

            switch (specificRoom)
            {
                case "In":
                    _roomCharateristics = new URoomIn();
                    break;

                case "Out":
                    _roomCharateristics = new URoomOut();
                    break;

            }
        }



        /// <summary>
        /// Initializes a new instance of the <see cref="URoom"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="typeOfRoom">The type of room.</param>
        /// <param name="numberOfStyleRoom">The number of style room.</param>
        public URoom(ULevel context, string typeOfRoom, string numberOfStyleRoom)
        {
            _context = context;

            switch (typeOfRoom)
            {
                case "BossRoom":
                    _roomCharateristics = new UBossRoom();
                    break;

                case "LabyrintheRoom":
                    _roomCharateristics = new ULabyrintheRoom();
                    break;

                case "MonsterRoom":
                    _roomCharateristics = new UMonsterRoom();
                    break;

                case "SecretRoom":
                    _roomCharateristics = new USecretRoom();
                    break;

                case "TrapRoom":
                    _roomCharateristics = new UTrapRoom();
                    break;

                case "RoomIn":
                    _roomCharateristics = new URoomIn();
                    break;

                case "RoomOut":
                    _roomCharateristics = new URoomOut();
                    break;

                default:
                    throw new ArgumentNullException("The room does not exist");

            }

            _roomCharateristics.NumberOfStyleRoom = numberOfStyleRoom;



        }

        /// <summary>
        /// Gets the room charateristcs.
        /// </summary>
        /// <value>
        /// The room charateristcs.
        /// </value>
        public UTypeOfRoom RoomCharateristcs
        {
            get
            {
                return _roomCharateristics;
            }
        }

    }
}
