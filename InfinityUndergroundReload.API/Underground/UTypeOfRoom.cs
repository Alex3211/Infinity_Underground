using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Underground
{
    public abstract class UTypeOfRoom
    {
        int _nbOfNPC;
        string _numberOfStyleRoom;
        Random r;
        string _nameOfMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        public UTypeOfRoom()
        {
            r = new Random();
            _nbOfNPC = r.Next(2, 10);
            _numberOfStyleRoom = r.Next(1, 5).ToString();
        }



        /// <summary>
        /// Gets or sets the name of map.
        /// </summary>
        /// <value>
        /// The name of map.
        /// </value>
        public string NameOfMap { get { return _nameOfMap; } set { _nameOfMap = value; } }

        /// <summary>
        /// Gets the NumberOfStyleRoom.
        /// </summary>
        /// <value>
        /// The NumberOfStyleRoom.
        /// </value>
        public string NumberOfStyleRoom { get { return _numberOfStyleRoom; } set { _numberOfStyleRoom = value; } }

        /// <summary>
        /// Gets or sets the nb of NPC.
        /// </summary>
        /// <value>
        /// The nb of NPC.
        /// </value>
        public int NbOfNPC { get { return _nbOfNPC; } set { _nbOfNPC = value; } }



    }
}
