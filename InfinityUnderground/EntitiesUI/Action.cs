using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.EntitiesUI
{
    class Action
    {
        readonly int _column, _idOfAction;


        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="name">the name of the action</param>
        /// <param name="rows">the rows on sprite sheet</param>
        /// <param name="column">the column on sprite sheet</param>
        public Action( int id, int column)
        {
            _column = column;
            _idOfAction = id;
        }


		/// <summary>
        /// Name of the action.
        /// </summary>
		public int IDActionPlayer { get { return _idOfAction; } }

        /// <summary>
        /// The column on sprite sheet.
        /// </summary>
        public int Column { get { return _column; } }

		/// <summary>
        /// return the direction of the player.
        /// </summary>
		public int Direction { get { return (int)_idOfAction % 4; } }




    }
}
