using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kepler_22_B.API.Characteres;
using Kepler_22_B.API.Map;
using Microsoft.Xna.Framework;

namespace Kepler_22_B.API
{
    public class World
    {

        List<CTPlayer> _listOfPlayer;
        List<CTNPC> _listOfNPC;
        Level _level;
        int _tildeWidth;
        Door _enterUnderground;

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        public World()
        {
            _enterUnderground = new Door(new Vector2(10, 19), new Vector2(11,19), DoorDirection.Top );
            _tildeWidth = 32;
            _level = new Level(this);
            _listOfNPC = new List<CTNPC>();
            _listOfPlayer = new List<CTPlayer>();
            _listOfPlayer.Add(new CTPlayer());
        }

        /// <summary>
        /// Gets the players in a list.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public List<CTPlayer> Players { get { return _listOfPlayer; } }


        /// <summary>
        /// Gets the level.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public Level Level { get { return _level; } }

        /// <summary>
        /// Gets the width of the tilde.
        /// </summary>
        /// <value>
        /// The width of the tilde.
        /// </value>
        public int TildeWidth { get { return _tildeWidth; } }

        /// <summary>
        /// Gets the player1 position x in tile.
        /// </summary>
        /// <value>
        /// The player1 position x in tile.
        /// </value>
        public int Player1PositionXInTile { get { return _listOfPlayer[0].PositionX / _tildeWidth; } set { _listOfPlayer[0].PositionX = value * _tildeWidth; } }

        /// <summary>
        /// Gets the player1 position y in tile.
        /// </summary>
        /// <value>
        /// The player1 position y in tile.
        /// </value>
        public int Player1PositionYInTile { get { return _listOfPlayer[0].PositionY / _tildeWidth; } set { _listOfPlayer[0].PositionY = value * _tildeWidth; } }

        /// <summary>
        /// Accesses the underground.
        /// </summary>
        /// <returns>Bool condition</returns>
        public bool AccessUnderground()
        {
            foreach(CTPlayer player in _listOfPlayer)
            {
                if (((Player1PositionXInTile >= _enterUnderground.MoreThan.X) && (player.PositionX / _tildeWidth <= _enterUnderground.LowerThan.X)) && ((Player1PositionYInTile >= _enterUnderground.MoreThan.Y) && (player.PositionY / _tildeWidth <= _enterUnderground.LowerThan.Y)))
                {
                    _level.GetRooms.ChangePlayerPositionWithTheSwitchRoom(_enterUnderground.DoorDirection);
                    return true;
                }
           }
            return false;
        }
        
    }
}

