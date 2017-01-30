using InfinityUndergroundReload.API.Characters;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API
{
    public enum CharacterTurn
    {
        Player,
        Monster,
        NoOne
    }

    public class Fights
    {
        World _context;
        CPlayer _player;
        CNPC _monster;
        int _playerTurn;
        int _monsterTurn;
        double _playerTurnLoading;
        double _monsterTurnLoading;
        List<CAttacks> _monsterAttacks;
        List<CAttacks> _playerAttacks;
        bool _createAttack;
        string _nameAttack;
        CAttacks _tempAttack;




        public Fights(World context, Vector2 positionPlayer, CNPC monster)
        {
            _context = context;
            _monster = monster;
            _player = _context.Player;

            _monsterAttacks = new List<CAttacks>();
            _playerAttacks = new List<CAttacks>();
        }

        public double PlayerTurnsLoading
        {
            get
            {
                return _playerTurnLoading;
            }
        }


        public double MonsterTurnsLoading
        {
            get
            {
                return _monsterTurnLoading;
            }
        }


        /// <summary>
        /// Gets the name attack.
        /// </summary>
        /// <value>
        /// The name attack.
        /// </value>
        public string NameAttack
        {
            get
            {
                return _nameAttack;
            }
        }

        public void GiveDamageWithAttack(CAttacks attack, CharacterTurn turn)
        {
            
            if (attack.TurnsLoading == 0)
            {
                switch (attack.Name)
                {
                    default:
                        if (attack.TurnsDuringDamage != 0)
                        {
                            if (turn == CharacterTurn.Monster)
                            {
                                //if (!_context.Player.Shield)
                                //{
                                    GiveDamage(_monster, _context.Player, attack);
                                //}
                                //else
                                //{
                                //    _context.Player.Shield = false;
                                //}
                            }
                            else
                            {
                                GiveDamage(_context.Player, _monster, attack);
                            }
                            
                            attack.TurnsDuringDamage--;
                        }
                        break;
                }
                if (attack.TurnsDuringDamage == 0)
                {
                    _monsterAttacks.Remove(attack);
                    _playerAttacks.Remove(attack);
                }
                

            }
        }


        public CAttacks GetAttack(CharacterTurn turn)
        {

            if (turn == CharacterTurn.Monster)
            {
                _monsterTurnLoading = 0;

                foreach (CAttacks attack in _monsterAttacks)
                {
                    if (attack.TurnsLoading != 0)
                    {
                        attack.TurnsLoading--;
                    }


                    if (attack.TurnsLoading != 0 || attack.TurnsDuringDamage != 0)
                    {
                        return attack;
                    }

                }


                return CreateAttack(turn);


            }

            return null;

        }

        /// <summary>
        /// Gets the attack.
        /// </summary>
        /// <param name="turn">The turn.</param>
        /// <returns></returns>
        public CAttacks GetAttack(CharacterTurn turn, int attackPlayer)
        {

            foreach (CAttacks attack in _playerAttacks)
            {
                if (attack.TurnsLoading != 0)
                {
                    attack.TurnsLoading--;
                }


                if (attack.TurnsLoading != 0 || attack.TurnsDuringDamage != 0)
                {
                    return attack;
                }

            }

            switch (attackPlayer)
            {
                case 0:
                    _tempAttack = CAttacks.RedSlash();
                    _playerAttacks.Add(_tempAttack);
                    return _tempAttack;

                case 1:
                    return null;

            }
            return null;

        }

        public CAttacks CreateAttack(CharacterTurn turn)
        {
            if (turn == CharacterTurn.Monster)
            {
                
                switch(_context.Random.Next(0, _monster.ListOfAttack.Count()))
                {
                    case 0:
                        switch(_monster.TypeOfMonster)
                        {
                            case "Dragon":
                                _tempAttack = CAttacks.ThrowDarkMatter();
                                _monsterAttacks.Add(_tempAttack);
                                return _tempAttack;

                            case "Curiosity4":
                                _tempAttack = CAttacks.Curiosity2();
                                _monsterAttacks.Add(_tempAttack);
                                return _tempAttack;

                            case "Angel":
                                _tempAttack = CAttacks.Meteor();
                                _playerAttacks.Add(_tempAttack);
                                return _tempAttack;
                        }
                        break;

                    case 1:
                        switch (_monster.TypeOfMonster)
                        {
                            case "Dragon":
                                _tempAttack = CAttacks.ThrowDarkMatter();
                                _monsterAttacks.Add(_tempAttack);
                                return _tempAttack;

                            case "Curiosity4":
                                _tempAttack = CAttacks.DarkHole();
                                _monsterAttacks.Add(_tempAttack);
                                return _tempAttack;

                            case "Angel":
                                _tempAttack = CAttacks.CreateBirthOfASun();
                                _monsterAttacks.Add(_tempAttack);
                                return _tempAttack;
                        }
                        break;
                        
                }
            }
            else if (turn == CharacterTurn.Player)
            {

            }

            return null;
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
        public void GiveDamage(CCharacter sender, CCharacter receiver, CAttacks attack)
        {
            int damage = 0;
            if (IsCritical(sender.CharacterType.CriticalChance))
            {
                damage = CriticalDamage(sender.CharacterType.Damage, sender.CharacterType.CriticalDamage) + attack.Damage;
            }
            else
            {
                damage = sender.CharacterType.Damage + attack.Damage;
            }

            if (_context.Player.Shield && receiver.IsPlayer)
            {
                damage = Math.Abs(((damage * 80) / 100) - damage);
                _context.Player.Shield = false;
            }

            receiver.CharacterType.LifePoint -= damage;
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
            double _criticalChance = (int)(criticalChance * 100);
            int _numberChance = _context.Random.Next(10000);

            if (_numberChance <= _criticalChance)
            {
                return true;
            }

            return false;
        }

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


        /// <summary>
        /// Choose the turn character.
        /// </summary>
        /// <returns></returns>
        public CharacterTurn ChoiceTurn()
        {
            _monsterTurnLoading += _monster.CharacterType.AttackSpeed;
            _playerTurnLoading += _player.CharacterType.AttackSpeed;

            if (_monsterTurnLoading >= 100)
            {
                _monsterTurnLoading = 0;
                return CharacterTurn.Monster;
            }
            else if (_playerTurnLoading >= 100)
            {
                _playerTurnLoading = 0;
                return CharacterTurn.Player;
            }
            return CharacterTurn.NoOne;
        }


    }
}
