using InfinityUndergroundReload.CharactersUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.Spell
{
    class Explosion : SpriteSheet
    {
        SPlayer _player;
        SoundEffect _sound;

        public Explosion(SPlayer player)
        {
            SpriteSheetColumns = 5;
            SpriteSheetRows = 4;
            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            MillisecondsPerFrame = 20;
            IsSpell = true;
            NameSpell = "explosion";
            _player = player;
            CurrentRow = 0;
        }

        public override void LoadContent(ContentManager content)
        {
            _sound = content.Load<SoundEffect>(@"Song\Explosion");
            Spritesheet = content.Load<Texture2D>("Effect/explosion");
        }

        public override void Unload(ContentManager content)
        {
            base.Unload(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (ResetPosition)
            {
                CurrentRow = 0;
                ResetPosition = false;
                _sound.Play();
            }

            SpriteSheetColumns = 5;
            SpriteSheetRows = 4;

            Width = Spritesheet.Width / SpriteSheetColumns;
            Height = Spritesheet.Height / SpriteSheetRows;

            Column = CurrentFrame % SpriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);

            Rectangle destinationRectangle = new Rectangle(_player.PlayerAPI.PositionX, _player.PlayerAPI.PositionY - 100, Width * 4, Height * 4);

            spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }


    class NuclearExplosion : SpriteSheet
    {
        SPlayer _player;


        public NuclearExplosion(SPlayer player)
        {
            SpriteSheetColumns = 5;
            SpriteSheetRows = 3;
            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            MillisecondsPerFrame = 70;
            IsSpell = true;
            NameSpell = "nuclear-explosion";
            _player = player;
            CurrentRow = 0;
            SpellReapeat = false;
        }

        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Effect/nuclear-explosion");
        }

        public override void Unload(ContentManager content)
        {
            base.Unload(content);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            MillisecondsPerFrame = 80;

            if (ResetPosition)
            {
                CurrentRow = 0;
                ResetPosition = false;
            }

            SpriteSheetColumns = 5;
            SpriteSheetRows = 3;

            Width = Spritesheet.Width / SpriteSheetColumns;
            Height = Spritesheet.Height / SpriteSheetRows;

            Column = CurrentFrame % SpriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);

            Rectangle destinationRectangle = new Rectangle(_player.PlayerAPI.PositionX, _player.PlayerAPI.PositionY - 150, Width * 4, Height * 4);

            spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);
        }
    }
}
