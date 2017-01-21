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
    public class ThrowDarkMatter : SpriteSheet
    {
        SpriteSheet _monster;
        SPlayer _player;

        public ThrowDarkMatter(SpriteSheet monster, SPlayer player)
        {
            SpriteSheetColumns = 5;
            SpriteSheetRows = 2;
            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            MillisecondsPerFrame = 60;
            IsSpell = true;
            SpellReapeat = true;
            _monster = monster;
            NameSpell = "ThrowDarkMatter";
            _player = player;
        }

        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Effect/DarkMatter");
        }

        public override void Unload(ContentManager content)
        {
            base.Unload(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Width = Spritesheet.Width / SpriteSheetColumns;
            Height = Spritesheet.Height / SpriteSheetRows;

            Column = CurrentFrame % SpriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);
            
            Rectangle destinationRectangle = new Rectangle(_player.PlayerAPI.PositionX, _player.PlayerAPI.PositionY, Width, Height);

            spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
