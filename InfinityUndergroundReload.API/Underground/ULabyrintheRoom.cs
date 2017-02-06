using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Underground
{
    class ULabyrintheRoom : UTypeOfRoom
    {
        public ULabyrintheRoom()
            :base()
        {
            NbOfNPC = 0;
            NameOfMap = "LabyrintheRoom";
        }
    }
}
