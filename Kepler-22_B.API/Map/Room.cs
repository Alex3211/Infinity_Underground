using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Map
{
    public abstract class Room
    {
        int _nbOfNPC;
        Random r;
        int _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        public Room()
        {
            r = new Random();
            _nbOfNPC = r.Next(2,10);
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public int Path { get { return _path; } set{ _path = value; } }

        /// <summary>
        /// Gets or sets the nb of NPC.
        /// </summary>
        /// <value>
        /// The nb of NPC.
        /// </value>
        public int NbOfNPC { get { return _nbOfNPC; } set { _nbOfNPC = value; } }

    }
}
