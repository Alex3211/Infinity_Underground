using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Underground
{
    class UTrapRoom : UTypeOfRoom
    {
        public UTrapRoom()
            :base()
        {
            NameOfMap = "TrapRoom";
            if (NumberOfStyleRoom == "1")
            {
                NbOfNPC *= 2;
            }
        }

    }
}
