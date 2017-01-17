using InfinityUndergroundReload.CharactersUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.Spell
{
    public class BirthOfASun : SpriteSheet
    {
        public BirthOfASun()
        {
            SpriteSheetColumns = 3;
            SpriteSheetRows = 4;
            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            MillisecondsPerFrame = 100;
            IsSpell = true;
        }

        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("SunTest");
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Width = Spritesheet.Width / SpriteSheetColumns;
            Height = Spritesheet.Height / SpriteSheetRows;

            Column = CurrentFrame % SpriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);
            Rectangle destinationRectangle = new Rectangle(500, 100, Width, Height);

            spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
