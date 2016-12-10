using InfinityUnderground.Characteres;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace InfinityUnderground.API.Characteres
{
    public class CTPlayer : CTCharacter
    {
        bool _isMoving, _canMove;
        int _sprint;
        List<CTAttack> _listOfAttack;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CTPlayer"/> class.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public CTPlayer(World context)
        {
            GetCharacterType.GetArmor = 1.0;
            GetCharacterType.GetCriticalChance = 2.0;
            GetCharacterType.GetCriticalDamage = 10;
            GetCharacterType.GetSpeedAttack = 2.0;
            GetCharacterType.LifePoint = 1000;
            GetCharacterType.MoveSpeed = 2;
            GetCharacterType.GetDamage = 10;
            _isMoving = true;
            _canMove = true;
            _sprint = 10;
            Context = context;


            _listOfAttack = new List<CTAttack>();
            _listOfAttack.Add(new CTAttack(GetCharacterType));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTPlayer"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public CTPlayer(int x, int y)
            : base(x, y)
        {
        }

        
        /// <summary>
        /// Gets or sets the sprint.
        /// </summary>
        /// <value>
        /// The sprint.
        /// </value>
        public int Sprint { get { return _sprint; } set { _sprint = value; } }

        
        /// <summary>
        /// Gets or sets a value indicating whether this instance can move.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the player can move; otherwise, <c>false</c>.
        /// </value>
        public bool CanMove { get { return _canMove; } set { _canMove = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is moving.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the player is moving; otherwise, <c>false</c>.
        /// </value>
        public bool IsMoving { get { return _isMoving; } set { _isMoving = value; } }

        /// <summary>
        /// Attack Player.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public bool PlayerAttack(Direction direction, ref int timeSinceLastAttack)
        {


            if ((timeSinceLastAttack <= GetCharacterType.GetSpeedAttack * 1000) && !(timeSinceLastAttack == 0))
            {
                return false;
            }

            if (timeSinceLastAttack >= GetCharacterType.GetSpeedAttack * 1000)
            {
                timeSinceLastAttack = 0;
            }
            timeSinceLastAttack++;

            foreach (CTCharacter NPC in Context.ListOfPlayer)
            {
                switch (direction)
                {
                    case Direction.Up:
                        if ((NPC.PositionY < PositionY) && (NPC.PositionY > PositionY - GetCharacterType.Range))
                        {
                            GetCharacterType.GetAttacks.NormalAttack(this, NPC);
                        }
                        break;

                    case Direction.Left:
                        if ((NPC.PositionX < PositionX) && (NPC.PositionX > PositionX - GetCharacterType.Range))
                        {
                            GetCharacterType.GetAttacks.NormalAttack(this, NPC);
                        }
                        break;

                    case Direction.Bottom:
                        if ((NPC.PositionY > PositionY) && (NPC.PositionY < PositionY + GetCharacterType.Range))
                        {
                            GetCharacterType.GetAttacks.NormalAttack(this, NPC);
                        }
                        break;

                    case Direction.Right:
                        if ((NPC.PositionX > PositionX) && (NPC.PositionX < PositionX + GetCharacterType.Range))
                        {
                            GetCharacterType.GetAttacks.NormalAttack(this, NPC);
                        }
                        break;

                }

                if (NPC.GetCharacterType.LifePoint <= 0)
                {
                    NPC.IsDead = true;
                }
            }
            return true;       
        }
    }
}
