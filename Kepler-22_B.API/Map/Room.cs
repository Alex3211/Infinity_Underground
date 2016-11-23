using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Map
{
    abstract class RoomInLevel
    {
        int _nbOfNPC, _nbStyleRoom;
        Random r;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomInLevel"/> class.
        /// </summary>
        public RoomInLevel()
        {
            r = new Random();
            _nbStyleRoom = r.Next(2,10);
            _nbStyleRoom = r.Next(4);
        }

        /// <summary>
        /// Gets or sets the nb of NPC.
        /// </summary>
        /// <value>
        /// The nb of NPC.
        /// </value>
        public int NbOfNPC { get { return _nbOfNPC; } set { _nbOfNPC = value; } }

        /// <summary>
        /// Gets the nb style room.
        /// </summary>
        /// <value>
        /// The nb style room.
        /// </value>
        public int NbStyleRoom { get { return _nbStyleRoom; } }


    }
}
