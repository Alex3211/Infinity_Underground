using Kepler_22_B.API.Data;
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
        MiniMap _miniMap;
        Data _saveMap;
        string _guid;

        public ManageUnderground(Game1 context)
        {
            _context = context;
            _context.ManageUnderGroundGame = this;
            _undergroundMapLevel = new Dictionary<Vector2, MapLoader>();

            _guid = Guid.NewGuid().ToString();

            //_saveMap = new Data(_guid, "Underground");
            //_saveMap = new Data(_guid);

            _miniMap = new MiniMap(this);
        }

        /// <summary>
        /// Gets the mini map.
        /// </summary>
        /// <value>
        /// The mini map.
        /// </value>
        public MiniMap MiniMap { get { return _miniMap; } }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public Game1 Context { get { return _context; } }

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

                //_saveMap.GetContentElementName = "room";
                //_saveMap.CreateDataDocument(_guid);


                    



                _undergroundMapLevel.Add(position, map);
                _miniMap.AddRoom(position);
                _context.DrawMiniMap = true;
            }
        }

        





    }
}
