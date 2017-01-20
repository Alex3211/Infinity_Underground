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
    class Curiosity2 : SpriteSheet
    {
        SpriteSheet _monster;
        SPlayer _player;
        int _spellPositionX;
        SpriteSheet _explosion;


        public Curiosity2(SpriteSheet monster, SPlayer player)
        {
            SpriteSheetColumns = 3;
            SpriteSheetRows = 1;
            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            MillisecondsPerFrame = 20;
            IsSpell = true;
            _monster = monster;
            NameSpell = "Curiosity2";
            _player = player;
            _spellPositionX = _monster.Monster.PositionX;
            _explosion = new Explosion(_player);
            SpellReapeat = true;
        }

        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Curiosity/Curiosity2");
            _explosion.LoadContent(content);
        }

        public override void Unload(ContentManager content)
        {
            base.Unload(content);
        }

        public override void Update(GameTime gameTime)
        {
            if (_spellPositionX <= _player.PlayerAPI.PositionX)
            {
                _explosion.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (ResetPosition)
            {
                _spellPositionX = (int)_monster.FightsPosition.X;
            }

            Width = Spritesheet.Width / SpriteSheetColumns;
            Height = Spritesheet.Height / SpriteSheetRows;

            Column = CurrentFrame % SpriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);

            Rectangle destinationRectangle = new Rectangle(_spellPositionX, _player.PlayerAPI.PositionY + 65, Width*4, Height*4);

            if (_spellPositionX > _player.PlayerAPI.PositionX)
            {
                _spellPositionX = _spellPositionX - 6;
                spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);
                _explosion.ResetPosition = true;
            }
            else if (_spellPositionX <= _player.PlayerAPI.PositionX + 50)
            {
                _explosion.Draw(spriteBatch);
            }


            
        }
    }
}
