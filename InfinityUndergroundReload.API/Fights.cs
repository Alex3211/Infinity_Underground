using InfinityUndergroundReload.API.Characters;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API
{
    public class Fights
    {
        World _context;
        CPlayer _player;
        CNPC _monster;

        public Fights(World context, Vector2 positionPlayer, CNPC monster)
        {
            _context = context;

            _monster = monster; 
        }

    }
}
