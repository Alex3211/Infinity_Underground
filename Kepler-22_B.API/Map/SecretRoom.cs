using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.API.Map
{
    public class SecretRoom : Room
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecretRoom"/> class.
        /// </summary>
        public SecretRoom()
        {
            NbOfNPC = 0;
            Path = 2;
            NameOfMap = "SecretRoom";
        }



    }
}
