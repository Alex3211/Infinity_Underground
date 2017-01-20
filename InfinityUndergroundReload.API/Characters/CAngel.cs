using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CAngel : CNPC
    {

        public CAngel(int x, int y, World context)
            :base(x, y, "Angel")
        {
            CharacterType.Armor = 10.0;
            CharacterType.CriticalChance = 20.0;
            CharacterType.CriticalDamage = 70;
            CharacterType.AttackSpeed = 1.0;
            CharacterType.LifePoint = 10000;
            CharacterType.MoveSpeed = 1;
            CharacterType.Damage = 100;
            CharacterType.Range = 100;
            CharacterType.HitBox = 60;
            IsBoss = false;
            ListOfAttack.Add(CAttacks.Curiosity2().Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTDragon"/> class.
        /// </summary>
        public CAngel(World context)
            :this(50,50, context)
        {
        }



    }
}
