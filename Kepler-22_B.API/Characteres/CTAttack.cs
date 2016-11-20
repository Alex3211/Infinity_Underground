using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Characteres
{
    public class CTAttack
    {
        CTCharacterType _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CTAttack"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CTAttack(CTCharacterType context)
        {
            _context = context;
        }
    }
}
