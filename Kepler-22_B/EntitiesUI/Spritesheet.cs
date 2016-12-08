using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kepler_22_B.EntitiesUI
{
    class Spritesheet
    {
        Texture2D _spriteSheet;

        Game1 _context;
        int _timeSinceLastFrame, _currentFrame, _width, _height, _column, _millisecondsPerFrame, _spriteSheetRows, _spriteSheetColumns, _totalFrames;



        public Spritesheet()
        {
            _timeSinceLastFrame = 0;
            _millisecondsPerFrame = 80;

        }

        /// <summary>
        /// Gets or sets the sprite sheet.
        /// </summary>
        /// <value>
        /// The sprite sheet.
        /// </value>
        internal Texture2D SpriteSheet { get { return _spriteSheet; } set { _spriteSheet = value; } }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        internal Game1 Context { get { return _context; } set { _context = value; } }

        /// <summary>
        /// Gets or sets the sprite sheet rows.
        /// </summary>
        /// <value>
        /// The sprite sheet rows.
        /// </value>
        internal int SpriteSheetRows { get { return _spriteSheetRows; } set { _spriteSheetRows = value; } }

        /// <summary>
        /// Gets or sets the sprite sheet column.
        /// </summary>
        /// <value>
        /// The sprite sheet column.
        /// </value>
        internal int SpriteSheetColumns { get { return _spriteSheetColumns; } set { _spriteSheetColumns = value; } }

        /// <summary>
        /// Gets or sets the total frame.
        /// </summary>
        /// <value>
        /// The total frame.
        /// </value>
        internal int TotalFrames { get { return _totalFrames; } set { _totalFrames = value; } }

        /// <summary>
        /// Gets or sets the time since last frame.
        /// </summary>
        /// <value>
        /// The time since last frame.
        /// </value>
        internal int TimeSinceLastFrame { get { return _timeSinceLastFrame; } set { _timeSinceLastFrame = value; } }

        /// <summary>
        /// Gets or sets the current frame.
        /// </summary>
        /// <value>
        /// The current frame.
        /// </value>
        internal int CurrentFrame { get { return _currentFrame; } set { _currentFrame = value; } }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        internal int Width { get { return _width; } set { _width = value; } }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        internal int Height { get { return _height; } set { _height = value; } }

        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        internal int Column { get { return _column; } set { _column = value; } }

        /// <summary>
        /// Gets or sets the milliseconds per frame.
        /// </summary>
        /// <value>
        /// The milliseconds per frame.
        /// </value>
        internal int MillisecondsPerFrame { get { return _millisecondsPerFrame; } set { _millisecondsPerFrame = value; } }





    }
}
