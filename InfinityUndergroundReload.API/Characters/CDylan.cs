using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CDylan : CCharacter
    {
        World _context;
        public CDylan(World context)
            : base(2770, 1250, context)
        {
            _context = context;
            CharacterType.HitBox = 50;
        }



    }
}
