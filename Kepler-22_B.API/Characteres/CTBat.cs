using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Characteres
{
    public class CTBat : CTNPC
    {

        public CTBat(int x, int y, World context)
            :base(x, y)
        {
            Context = context;
            GetCharacterType.GetArmor = 1.0;
            GetCharacterType.GetCriticalChance = 1.0;
            GetCharacterType.GetCriticalDamage = 10;
            GetCharacterType.GetSpeedAttack = 1.0;
            GetCharacterType.LifePoint = 50;
            GetCharacterType.MoveSpeed = 5;
            IsBoss = false;

            //GetCharacterType.GetAttacks;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTBat"/> class.
        /// </summary>
        public CTBat(World context)
            :this(50,50, context)
        {
        }







    }
}
