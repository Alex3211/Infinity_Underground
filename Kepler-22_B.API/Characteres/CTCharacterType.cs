using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Characteres
{

    public class CTCharacterType
    {
        int _moveSpeed;
        CTCharacter _context;
        CTAttack _attacks;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTCharacterType"/> class.
        /// </summary>
        public CTCharacterType(CTCharacter context)
        {
            _attacks = new CTAttack(this);
            _context = context;
            _moveSpeed = 2;
        }


        /// <summary>
        /// Gets the attacks.
        /// </summary>
        /// <value>
        /// The get attacks.
        /// </value>
        public CTAttack GetAttacks { get { return _attacks; } }

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




    }
}
