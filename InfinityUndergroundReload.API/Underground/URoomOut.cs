using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.API.Underground
{
    class URoomOut : UTypeOfRoom
    {

        int _styleRoom = 1;

        public URoomOut()
            :base()
        {
            NameOfMap = "RoomOut";
            NumberOfStyleRoom = _styleRoom.ToString();
        }
    }
}
