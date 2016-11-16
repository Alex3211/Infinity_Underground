using Microsoft.Xna.Framework;
using System;

namespace Kepler_22_B.API.Entities
{
    public class ETPlayer : ETCharateristics
    {
        Vector2 _position;


        
        /// <summary>
        /// Initializes a new instance of the <see cref="ETPlayer"/> class.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        public ETPlayer(int x, int y)
        {
            _position = new Vector2(x, y);
        }

        public ETPlayer()
            :this(0, 0)
        {
        }



        public int PositionX { get { return (int)_position.X; } set { _position.X = value; } }
        public int PositionY { get { return (int)_position.Y; } set { _position.Y = value; } }


        public void Deplacement(int direction)
        {
            switch (direction)
            {
                case 0:
                    PositionX--;
                    break;

                case 1:
                    PositionY++;
                    break;

                case 2:
                    PositionX++;
                    break;

                case 3:
                    PositionY--;
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }





    }
}
