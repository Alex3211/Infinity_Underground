using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CDragon : CNPC
    {
        public CDragon(int x, int y, World context)
            :base(x, y, "Dragon")
        {
            CharacterType.Armor = 1.0;
            CharacterType.CriticalChance = 1.0;
            CharacterType.CriticalDamage = 10;
            CharacterType.AttackSpeed = 6.0;
            CharacterType.LifePoint = 100;
            CharacterType.MoveSpeed = 1;
            CharacterType.Damage = 500;
            CharacterType.Range = 100;
            CharacterType.HitBox = 60;
            IsBoss = false;
            ListOfAttack.Add(CAttacks.ThrowDarkMatter().Name);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTDragon"/> class.
        /// </summary>
        public CDragon(World context)
            :this(50,50, context)
        {
        }

    }
}
