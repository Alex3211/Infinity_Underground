using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Characteres
{
    public class CTAttack
    {
        CTCharacterType _context;
        Random r;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTAttack"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CTAttack(CTCharacterType context)
        {
            _context = context;
            r = new Random();
        }

        /// <summary>
        /// Attack function
        /// First if: Critical attack
        /// Second if : Normal attack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="receiver"></param>
        /// <param name="damageSender"></param>
        /// <param name="armorReceiver"></param>
        /// <returns></returns>
        public int Attack(CTCharacter sender, CTCharacter receiver, int damageSender, double armorReceiver)
        {
            int random = r.Next(1, 8);
            if (random > 5) return receiver.LifePoint = (sender.GetCharacterType.GetContext.GetDamage * receiver.GetCharacterType.GetContext.GetArmor) * random;
            else if (random < 5 && random > 2) return receiver.LifePoint = (sender.GetCharacterType.GetContext.GetDamage * receiver.GetCharacterType.GetContext.GetArmor) * random;
            else return 0;
        }

        
    }
}
