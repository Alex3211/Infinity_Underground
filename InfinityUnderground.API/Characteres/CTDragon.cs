using InfinityUnderground.Characteres;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.API.Characteres
{
    public class CTDragon : CTNPC
    {

        GameTime gameTime;
        int _timeSinceLastAttack;

        public CTDragon(int x, int y, World context)
            :base(x, y)
        {
            Context = context;
            GetCharacterType.GetArmor = 1.0;
            GetCharacterType.GetCriticalChance = 1.0;
            GetCharacterType.GetCriticalDamage = 10;
            GetCharacterType.GetSpeedAttack = 3.0;
            GetCharacterType.LifePoint = 30;
            GetCharacterType.MoveSpeed = 1;
            GetCharacterType.GetDamage = 10;
            GetCharacterType.Range = 200;
            IsBoss = false;
            IdMonster = CTIDMonster.Dragon;

            ListOfAttack.Add(new CTAttack(GetCharacterType));
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTDragon"/> class.
        /// </summary>
        public CTDragon(World context)
            :this(50,50, context)
        {
        }

                /// <summary>
        /// Attack Player.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public bool DragonAttack(Direction direction, ref int timeSinceLastAttack)
        {
            if ((timeSinceLastAttack <= GetCharacterType.GetSpeedAttack * 1000) && !(timeSinceLastAttack == 0))
            {
                return false;
            }

            if (timeSinceLastAttack >= GetCharacterType.GetSpeedAttack * 1000)
            {
                timeSinceLastAttack = 0;
            }
            timeSinceLastAttack++;


            foreach (CTPlayer player in Context.Players)
            {
                if (Attack(direction, player))
                {
                    return true;
                }

            }
        
            return false;
        }


    }
}
