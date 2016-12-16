using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.Map
{
    public class ManageUnderground
    {
        Dictionary<Vector2, MapLoader> _undergroundMapLevel;
        Game1 _context;

        public ManageUnderground(Game1 context)
        {
            _context = context;
            _context.ManageUnderGroundGame = this;
            _undergroundMapLevel = new Dictionary<Vector2, MapLoader>();
        }

        /// <summary>
        /// Gets or sets the list of room level underground.
        /// </summary>
        /// <value>
        /// The list of room level underground.
        /// </value>
        public Dictionary<Vector2, MapLoader> ListOfRoomLevelUnderground { get { return _undergroundMapLevel; }  set { _undergroundMapLevel = value; } }

        /// <summary>
        /// Adds the room to the list.
        /// </summary>
        public void AddRoomToTheList(Vector2 position, MapLoader map)
        {
            if (!_undergroundMapLevel.ContainsKey(position))
            {
                _undergroundMapLevel.Add(position, map);
            }
        }







    }
}
