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
        }

        public int MinimalAttack(CTCharacter sender, CTCharacter receiver, int damageSender, double armorReceiver)
        {
            return receiver.LifePoint = sender.GetCharacterType.GetDamage * receiver.GetCharacterType.GetArmor;
        }

        public int NormalAttack(CTCharacter sender, CTCharacter receiver, int damageSender, double armorReceiver)
        {
            return receiver.LifePoint = (sender.GetCharacterType.GetDamage*receiver.GetCharacterType.GetArmor)*r.Next(1, 3);
        }

        public int CriticalAttack(CTCharacter sender, CTCharacter receiver, int damageSender, double armorReceiver)
        {
            return receiver.LifePoint = (sender.GetCharacterType.GetDamage * receiver.GetCharacterType.GetArmor)*r.Next(1, 5);
        }

        
    }
}
