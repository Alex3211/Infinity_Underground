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
        int _criticalChance, _numberChance;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTAttack"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CTAttack(CTCharacterType context)
        {
            r = new Random();
            _context = context;
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
        public void NormalAttack(CTCharacter sender, CTCharacter receiver)
        {
            if (IsCritical(sender.GetCharacterType.GetCriticalChance))
            {
                receiver.GetCharacterType.LifePoint -= CriticalDamage(sender.GetCharacterType.GetDamage, sender.GetCharacterType.GetCriticalDamage);
            }
            else
            {
                receiver.GetCharacterType.LifePoint -= sender.GetCharacterType.GetDamage;
            }
        }



        /// <summary>
        /// Determines if is a critical damage.
        /// </summary>
        /// <param name="criticalChance">The critical chance.</param>
        /// <returns>
        ///   <c>true</c> if the specified critical chance is critical; otherwise, <c>false</c>.
        /// </returns>
        public bool IsCritical(double criticalChance)
        {
            _criticalChance = (int)(criticalChance * 100);
            _numberChance = r.Next(10000);

            if (_numberChance <= _criticalChance)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Return the damage in critical strike.
        /// </summary>
        /// <param name="damage">The damage.</param>
        /// <param name="criticalDamage">The critical damage.</param>
        /// <returns></returns>
        public int CriticalDamage(int damage, int criticalDamage)
        {
            return (damage + ((damage * criticalDamage) / 100));
        }

        /// <summary>
        /// Reduces the damage with armor stat.
        /// </summary>
        /// <param name="armor">The armor.</param>
        /// <param name="damage">The damage.</param>
        /// <returns></returns>
        public int ReduceDamageWithArmor(int damage, double armor)
        {
            double _damage = Convert.ToDouble(damage);
            return (int)(_damage - (_damage * armor / 100));
        } 



    }
}
