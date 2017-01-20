using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Characters
{
    public class CAttacks
    {
        readonly string _name;
        int _damage;
        int _turnsLoading;
        readonly int _turnsDamage;
        int _turnsDuringDamage;
        int _spellReload;

        /// <summary>
        /// Initializes a new instance of the <see cref="CAttacks"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="turnsLoading">The turns loading.</param>
        /// <param name="turnsDamage">The turns damage.</param>
        /// <param name="turnsDuringDamage">The turns during damage.</param>
        /// <param name="spellReload">The spell reload.</param>
        public CAttacks(string name, int turnsLoading, int turnsDamage, int turnsDuringDamage, int spellReload, int damage)
        {
            _name = name;
            _turnsDamage = turnsDamage;
            _turnsDuringDamage = turnsDuringDamage;
            _turnsLoading = turnsLoading;
            _spellReload = spellReload;
            _damage = damage;
        }

        /// <summary>
        /// Turns need for use this spell again.
        /// </summary>
        public int SpellReload
        {
            get
            {
                return _spellReload;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return _name;
            }
        }

        /// <summary>
        /// Gets the damage.
        /// </summary>
        /// <value>
        /// The damage.
        /// </value>
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
        /// Gets the turns loading.
        /// </summary>
        /// <value>
        /// The turns loading.
        /// </value>
        public int TurnsLoading
        {
            get
            {
                return _turnsLoading;
            }

            set
            {
                _turnsLoading = value;
            }
        }

        /// <summary>
        /// Gets the turns during damage.
        /// </summary>
        /// <value>
        /// The turns during damage.
        /// </value>
        public int TurnsDuringDamage
        {
            get
            {
                return _turnsDuringDamage;
            }

            set
            {
                _turnsDuringDamage = value;
            }
        }

        public static CAttacks CreateBirthOfASun() => new CAttacks("BirthOfASun", 3, 4, 5, 5, 200);

        public static CAttacks ThrowDarkMatter() => new CAttacks("ThrowDarkMatter", 0, 1, 1, 0, 50);

        public static CAttacks DarkHole() => new CAttacks("DarkHole", 0, 0, 3, 5, 200);

        public static CAttacks RedSlash() => new CAttacks("RedSlash", 0, 1, 1, 0, 50);

        public static CAttacks Curiosity2() => new CAttacks("Curiosity2", 0, 1, 1, 0, 50);
    }


    //public class BirthOfASun : CAttacks
    //{
    //    CNPC _monster;

    //    public BirthOfASun(CNPC monster)
    //        : base("BirthOfASun", 3, 3, 5, 5)
    //    {
    //        _monster = monster;
    //        Damage = monster.CharacterType.Damage * 2;
    //    }
    //}

    //public class ThrowDarkMatter : CAttacks
    //{
    //    CNPC _monster;

    //    public ThrowDarkMatter(CNPC monster)
    //        : base("ThrowDarkMatter", 0, 1, 1, 0)
    //    {
    //        _monster = monster;
    //        Damage = monster.CharacterType.Damage;
    //    }
    //}

    //public class DarkHole : CAttacks
    //{
    //    CNPC _monster;

    //    public DarkHole(CNPC monster)
    //        : base("ThrowDarkMatter", 2, 2, 3, 5)
    //    {
    //        _monster = monster;
    //        Damage = monster.CharacterType.Damage;
    //    }
    //}

}
