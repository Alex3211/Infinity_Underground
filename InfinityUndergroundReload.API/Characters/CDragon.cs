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
            //Context = context;
            CharacterType.Armor = 1.0;
            CharacterType.CriticalChance = 1.0;
            CharacterType.CriticalDamage = 10;
            CharacterType.AttackSpeed = 3.0;
            CharacterType.LifePoint = 30;
            CharacterType.MoveSpeed = 1;
            CharacterType.Damage = 10;
            CharacterType.Range = 100;
            CharacterType.HitBox = 60;
            IsBoss = false;
            //IdMonster = CTIDMonster.Dragon;

            //ListOfAttack.Add(new CAttacks(CharacterType));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTDragon"/> class.
        /// </summary>
        public CDragon(World context)
            :this(50,50, context)
        {
        }

        /// <summary>
        /// Attack Player.
        /// </summary>
        /// <param name="direction">The direction.</param>
        //public bool DragonAttack(Direction direction, ref int timeSinceLastAttack)
        //{
        //    if ((timeSinceLastAttack <= CharacterType.GetSpeedAttack * 1000) && !(timeSinceLastAttack == 0))
        //    {
        //        return false;
        //    }

        //    if (timeSinceLastAttack >= CharacterType.GetSpeedAttack * 1000)
        //    {
        //        timeSinceLastAttack = 0;
        //    }
        //    timeSinceLastAttack++;


        //    foreach (CTPlayer player in Context.Players)
        //    {
        //        if (Attack(direction, player))
        //        {
        //            return true;
        //        }

        //    }

        //    return false;
        //}
    }
}
