using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CAlex : CCharacter
    {
        World _context;

        public CAlex(World context)
            :base(2870, 1250, context)
        {
            _context = context;
            CharacterType.HitBox = 50;
        }


    }
}
