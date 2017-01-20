using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CPlayer : CCharacter
    {
        List<string> _listOfAttacks;
        bool _shield;

        public CPlayer()
            :base()
        {
            CharacterType.MoveSpeed = 2;
            CharacterType.LifePoint = 2000;
            CharacterType.MaxLifePoint = 2000;
            CharacterType.CriticalChance = 30;
            CharacterType.CriticalDamage = 20;
            CharacterType.AttackSpeed = 2;
            CharacterType.Damage = 50;
            _listOfAttacks = new List<string>();
            _listOfAttacks.Add(CAttacks.RedSlash().Name);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CPlayer"/> is shield.
        /// </summary>
        /// <value>
        ///   <c>true</c> if shield; otherwise, <c>false</c>.
        /// </value>
        public bool Shield
        {
            get
            {
                return _shield;
            }

            set
            {
                _shield = value;
            }
        }

        /// <summary>
        /// Gets the list of attack.
        /// </summary>
        /// <value>
        /// The list of attack.
        /// </value>
        public List<string> ListOfAttack
        {
            get
            {
                return _listOfAttacks;
            }
        }

    }
}
