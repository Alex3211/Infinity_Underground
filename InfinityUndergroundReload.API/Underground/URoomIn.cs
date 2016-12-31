using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Underground
{
    class URoomIn : UTypeOfRoom
    {

        int _styleRoom = 1;

        public URoomIn()
            :base()
        {
            NameOfMap = "RoomIn";
            NumberOfStyleRoom = _styleRoom.ToString();
        }
    }
}
