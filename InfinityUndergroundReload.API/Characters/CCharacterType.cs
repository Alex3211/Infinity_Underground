using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CCharacterType
    {
        int _moveSpeed;
        int _lifepoint;
        int _damage;
        int _criticalDamage;
        int _range;
        int _hitbox;
        CCharacter _context;
        CAttacks _attacks;
        double _criticalChance;
        double _attackSpeed;
        double _armor;

        public CCharacterType(CCharacter context)
        {
            _attacks = new CAttacks();
            _context = context;
        }

        /// <summary>
        /// Character MoveSpeed.
        /// </summary>
        public int MoveSpeed
        {
            get
            {
                return _moveSpeed;
            }

            set
            {
                _moveSpeed = value;
            }
        }

        /// <summary>
        /// Character Lifepoint.
        /// </summary>
        public int LifePoint
        { 
            get
            {
                return _lifepoint;
            }

            set
            {
                _lifepoint = value;
            }
        }

        /// <summary>
        /// Character Damage.
        /// </summary>
        public int Damage
        { 
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        /// <summary>
        /// Character Critical Damage.
        /// </summary>
        public int CriticalDamage
        {
            get
            {
                return _criticalDamage;
            }

            set
            {
                _criticalDamage = value;
            }
        }

        /// <summary>
        /// Character Range.
        /// </summary>
        public int Range
        {
            get
            {
                return _range;
            }

            set
            {
                _range = value;
            }

        }

        /// <summary>
        /// Character HitBox.
        /// </summary>
        public int HitBox
        {
            get
            {
                return _hitbox;
            }

            set
            {
                _hitbox = value;
            }

        }

        /// <summary>
        /// Character critical chance.
        /// </summary>
        public double CriticalChance
        {
            get
            {
                return _criticalChance;
            }

            set
            {
                _criticalChance = value;
            }
        }

        /// <summary>
        /// Character attack speed.
        /// </summary>
        public double AttackSpeed
        {
            get
            {
                return _attackSpeed;
            }

            set
            {
                _attackSpeed = value;
            }
        }

        /// <summary>
        /// Character armor.
        /// </summary>
        public double Armor
        {
            get
            {
                return _armor;
            }

            set
            {
                _armor = value;
            }
        }

    }
}
