using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.SpriteSheet
{
    class ActionSpriteSheet
    {
        readonly int _column;
        readonly int _idOfActionSpriteSheet;


        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="name">the name of the ActionSpriteSheet</param>
        /// <param name="rows">the rows on sprite sheet</param>
        /// <param name="column">the column on sprite sheet</param>
        public ActionSpriteSheet(int id, int column)
        {
            _column = column;
            _idOfActionSpriteSheet = id;
        }


        /// <summary>
        /// Name of the ActionSpriteSheet.
        /// </summary>
        public int RowAction
        {
            get
            {
                return _idOfActionSpriteSheet;
            }
        }

        /// <summary>
        /// The column on sprite sheet.
        /// </summary>
        public int Column
        {
            get
            {
                return _column;
            }
        }

        /// <summary>
        /// return the direction of the player.
        /// </summary>
        public int Direction
        {
            get
            {
                return (int)_idOfActionSpriteSheet % 4;
            }
        }


    }
}
