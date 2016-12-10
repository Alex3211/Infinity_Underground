using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.API.Map
{
    public class TrapRoom : Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrapRoom"/> class.
        /// </summary>
        public TrapRoom()
        {
            Path = 3;
            NameOfMap = "TrapRoom";
        }
    }
}
