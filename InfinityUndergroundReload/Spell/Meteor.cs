using InfinityUndergroundReload.CharactersUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityUndergroundReload.Spell
{
    class Meteor : SpriteSheet
    {
        SpriteSheet _monster;
        SPlayer _player;
        int _spellPositionY;
        SpriteSheet _explosion;


        public Meteor(SpriteSheet monster, SPlayer player)
        {
            SpriteSheetColumns = 5;
            SpriteSheetRows = 3;
            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            MillisecondsPerFrame = 200;
            IsSpell = true;
            _monster = monster;
            NameSpell = "Meteor";
            _player = player;
            _spellPositionY = _player.PlayerAPI.PositionY - 600;
            _explosion = new NuclearExplosion(_player);
            SpellReapeat = true;
        }

        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Effect/meteor");
            _explosion.LoadContent(content);
        }

        public override void Unload(ContentManager content)
        {
            base.Unload(content);
        }

        public override void Update(GameTime gameTime)
        {
            if (_spellPositionY >= _player.PlayerAPI.PositionY)
            {
                _explosion.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            SpriteSheetColumns = 5;
            SpriteSheetRows = 3;

            if (ResetPosition)
            {
                CurrentRow = 0;
                CurrentFrame = 0;
                _spellPositionY = _player.PlayerAPI.PositionY - 600;
            }

            Width = Spritesheet.Width / SpriteSheetColumns;
            Height = Spritesheet.Height / SpriteSheetRows;

            Column = CurrentFrame % SpriteSheetColumns;

            Rectangle sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);

            Rectangle destinationRectangle = new Rectangle(_player.PlayerAPI.PositionX, _spellPositionY - 1000, Width, Height);

            if (_spellPositionY < _player.PlayerAPI.PositionY + 800)
            {
                _spellPositionY = _spellPositionY + 24;
                spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);
                _explosion.ResetPosition = true;
            }
            else if (_spellPositionY >= _player.PlayerAPI.PositionY)
            {
                _explosion.Draw(spriteBatch);
            }



        }

    }
}
