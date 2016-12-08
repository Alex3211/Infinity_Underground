using Kepler_22_B.Characteres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Characteres
{
    public class CTNPC : CTCharacter
    {
        bool _isBoss;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTNPC"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public CTNPC(int x, int y)
            :base(x, y)
        {
        }

        

        /// <summary>
        /// Gets or sets a value indicating whether this instance is boss.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is boss; otherwise, <c>false</c>.
        /// </value>
        public bool IsBoss { get { return _isBoss; } set { _isBoss = value; } } 


        public int MoveDirectionToThePlayer()
        {
            if (Context.Players[0].PositionY < PositionY - 30)
            {
                return Deplacement((int)Direction.Up);
            }

            if (Context.Players[0].PositionY > PositionY + 30)
            {
                return Deplacement((int)Direction.Bottom);
            }

            if (Context.Players[0].PositionX > PositionX + 30)
            {
                return Deplacement((int)Direction.Right);
            }

            if (Context.Players[0].PositionX < PositionX - 30)
            {
                return Deplacement((int)Direction.Left);
            }

            return 0;
        }
    }
}
