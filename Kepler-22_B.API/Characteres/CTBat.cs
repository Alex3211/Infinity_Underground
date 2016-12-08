using Kepler_22_B.Characteres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Characteres
{
    public class CTBat : CTNPC
    {

        public CTBat(int x, int y, World context)
            :base(x, y)
        {
            Context = context;
            GetCharacterType.GetArmor = 1.0;
            GetCharacterType.GetCriticalChance = 1.0;
            GetCharacterType.GetCriticalDamage = 10;
            GetCharacterType.GetSpeedAttack = 3.0;
            GetCharacterType.LifePoint = 50;
            GetCharacterType.MoveSpeed = 5;
            GetCharacterType.GetDamage = 10;
            IsBoss = false;

            //GetCharacterType.GetAttacks;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CTBat"/> class.
        /// </summary>
        public CTBat(World context)
            :this(50,50, context)
        {
        }

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

            foreach (CTCharacter player in Context.ListOfPlayer)
            {
                switch (direction)
                {
                    case Direction.Up:
                        if ((player.PositionY < PositionY) && (player.PositionY > PositionY - GetCharacterType.Range))
                        {
                            GetCharacterType.GetAttacks.NormalAttack(this, player);
                        }
                        break;

                    case Direction.Left:
                        if ((player.PositionX < PositionX) && (player.PositionX > PositionX - GetCharacterType.Range))
                        {
                            GetCharacterType.GetAttacks.NormalAttack(this, player);
                        }
                        break;

                    case Direction.Bottom:
                        if ((player.PositionY > PositionY) && (player.PositionY < PositionY + GetCharacterType.Range))
                        {
                            GetCharacterType.GetAttacks.NormalAttack(this, player);
                        }
                        break;

                    case Direction.Right:
                        if ((player.PositionX > PositionX) && (player.PositionX < PositionX + GetCharacterType.Range))
                        {
                            GetCharacterType.GetAttacks.NormalAttack(this, player);
                        }
                        break;

                }

                if (player.GetCharacterType.LifePoint <= 0)
                {
                    player.IsDead = true;
                }
            }
            return true;       
        }





    }
}
