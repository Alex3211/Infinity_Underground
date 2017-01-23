using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CCharacterType
    {
        double _ratio;
        int _moveSpeed;
        int _lifepoint;
        int _maxLifePoint;
        int _damage;
        int _criticalDamage;
        int _range;
        int _hitbox;
        CCharacter _context;
        double _criticalChance;
        double _attackSpeed;
        double _armor;



        public CCharacterType(CCharacter context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets the maximum life point.
        /// </summary>
        /// <value>
        /// The maximum life point.
        /// </value>
        public int MaxLifePoint
        {
            get
            {
                if (!_context.IsPlayer && _context.Context.GetMaxLevel >= 10)
                {
                    _ratio = _context.Context.GetMaxLevel;
                }
                else
                {
                    _ratio = 10;
                }

                if (_lifepoint > _maxLifePoint)
                {
                    _maxLifePoint = _lifepoint;
                }

                return (int)(_maxLifePoint * (_ratio / 10));
            }

            set
            {
                _maxLifePoint = value;
            }
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
                if (!_context.IsPlayer && _context.Context.GetMaxLevel >= 10)
                {
                    _ratio = _context.Context.GetMaxLevel;
                }
                else
                {
                    _ratio = 10;
                }
                return (int)(_lifepoint * (_ratio / 10));
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
                if (!_context.IsPlayer && _context.Context.GetMaxLevel >= 10)
                    _ratio = _context.Context.GetMaxLevel;
                else
                {
                    _ratio = 10;
                }
                return (int)(_damage * (_ratio / 10));
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
                if (!_context.IsPlayer && _context.Context.GetMaxLevel >= 10)
                    _ratio = _context.Context.GetMaxLevel;
                else
                {
                    _ratio = 10;
                }
                return (int)(_criticalDamage * (_ratio / 10));
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
                if (!_context.IsPlayer && _context.Context.GetMaxLevel >= 10)
                    _ratio = _context.Context.GetMaxLevel;
                else
                {
                    _ratio = 10;
                }
                return (_criticalChance * (_ratio / 10));
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
                if (!_context.IsPlayer && _context.Context.GetMaxLevel >= 10)
                    _ratio = _context.Context.GetMaxLevel;
                else
                {
                    _ratio = 10;
                }
                return (_attackSpeed * (_ratio / 10));
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
                if (!_context.IsPlayer && _context.Context.GetMaxLevel >= 10)
                    _ratio = _context.Context.GetMaxLevel;
                else
                {
                    _ratio = 10;
                }
                return (_armor * (_ratio / 10));
            }

            set
            {
                _armor = value;
            }
        }

    }
}
