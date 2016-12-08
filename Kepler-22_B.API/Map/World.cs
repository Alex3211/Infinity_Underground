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
        bool _isSurface;

        /// <summary>
        /// Initializes a new instance of the <see cref="World"/> class.
        /// </summary>
        public World()
        {
            _isSurface = true;
            _tildeWidth = 32;
            _level = new Level(this);
            _listOfNPC = new List<CTNPC>();
            _listOfPlayer = new List<CTPlayer>();
            _listOfPlayer.Add(new CTPlayer(this));
            _listOfNPC.Add(new CTBat(200, 200, this));
            _level.GetRooms.AddDoorInRoom();
        }


        /// <summary>
        /// Gets the list of pc.
        /// </summary>
        /// <value>
        /// The list of pc.
        /// </value>
        public List<CTNPC> ListOfPlayer { get { return _listOfNPC; } }


        /// <summary>
        /// Gets or sets a value indicating whether this instance is surface.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is surface; otherwise, <c>false</c>.
        /// </value>
        public bool IsSurface { get { return _isSurface; } set { _isSurface = value; } }

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
        /// Players the is surface or not.
        /// </summary>
        public void PlayerIsSurfaceOrNot()
        {
            if (_level.GetCurrentlevel == 0)
            {
                _isSurface = true;
            }
            else
            {
                _isSurface = false;
            }

        }
    }
}

