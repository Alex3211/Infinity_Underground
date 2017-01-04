using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CPlayer : CCharacter
    {

        public CPlayer()
            :base()
        {
            CharacterType.MoveSpeed = 2;
            CharacterType.LifePoint = 1000;
        }

    }
}
