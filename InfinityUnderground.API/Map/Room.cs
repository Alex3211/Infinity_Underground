using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.API.Map
{
    public abstract class Room
    {
        int _nbOfNPC, _path;
        Random r;
        string _nameOfMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="Room"/> class.
        /// </summary>
        public Room()
        {
            r = new Random();
            _nbOfNPC = r.Next(2,10);
        }

        /// <summary>
        /// Gets or sets the name of map.
        /// </summary>
        /// <value>
        /// The name of map.
        /// </value>
        public string NameOfMap { get { return _nameOfMap; } set { _nameOfMap = value; } }

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
