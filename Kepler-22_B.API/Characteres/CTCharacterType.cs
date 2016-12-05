using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Characteres
{

    public class CTCharacterType
    {
        int _moveSpeed, _lifePoint, _damage, _criticalDamage, _range;
        CTCharacter _context;
        CTAttack _attacks;
        double _criticalChance, _attackSpeed, _armor;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTCharacterType"/> class.
        /// </summary>
        public CTCharacterType(CTCharacter context)
        {
            _attacks = new CTAttack(this);
            _context = context;
            _range = 40;
        }

        /// <summary>
        /// Gets or sets the range.
        /// </summary>
        /// <value>
        /// The range.
        /// </value>
        public int Range { get { return _range; } set { _range = value; } }

        /// <summary>
        /// Gets the attacks.
        /// </summary>
        /// <value>
        /// The get attacks.
        /// </value>
        public CTAttack GetAttacks { get { return _attacks; } set { _attacks = value; } }

        /// <summary>
        /// Gets or sets the move speed.
        /// </summary>
        /// <value>
        /// The move speed.
        /// </value>
        public int MoveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }


        /// <summary>
        /// Gets the get context.
        /// </summary>
        /// <value>
        /// The get context.
        /// </value>
        public CTCharacter GetContext { get { return _context; } }

        /// <summary>
        /// Gets the get damage.
        /// </summary>
        /// <value>
        /// The get damage.
        /// </value>
        public int GetDamage { get { return _damage; } set { _damage = value; } }

        /// <summary>
        /// Gets the critical damage.
        /// </summary>
        /// <value>
        /// The get critical damage.
        /// </value>
        public int GetCriticalDamage { get { return _criticalDamage; } set { _criticalDamage = value; } }


        /// <summary>
        /// Gets the speed attack.
        /// </summary>
        /// <value>
        /// The get speed attack.
        /// </value>
        public double GetSpeedAttack { get { return _attackSpeed; } set { _attackSpeed = value; } }

        /// <summary>
        /// Gets the get armor.
        /// </summary>
        /// <value>
        /// The get armor.
        /// </value>
        public double GetArmor { get { return _armor; } set { _armor = value; } }

        /// <summary>
        /// Gets the get critical punch.
        /// </summary>
        /// <value>
        /// The get critical punch.
        /// </value>
        public double GetCriticalChance { get { return _criticalChance; }  set { _criticalChance = value; } }

        /// <summary>
        /// Gets the life point.
        /// </summary>
        /// <value>
        /// The life point.
        /// </value>
        public int LifePoint { get { return _lifePoint; } set { _lifePoint = value; } }





    }
}
