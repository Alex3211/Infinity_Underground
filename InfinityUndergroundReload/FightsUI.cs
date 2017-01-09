using InfinityUndergroundReload;
using InfinityUndergroundReload.API;
using InfinityUndergroundReload.API.Characters;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload
{
    public class FightsUI
    {
        InfinityUnderground _context;
        Fights _fight;

        public FightsUI(InfinityUnderground context, CNPC monster)
        {
            _context = context;

            _fight = context.WorldAPI.CreateFight(monster);

        }

        /// <summary>
        /// Gets the fights.
        /// </summary>
        /// <value>
        /// The fights.
        /// </value>
        public Fights TheFights
        {
            get
            {
                return _fight;
            }
        }





    }
}
