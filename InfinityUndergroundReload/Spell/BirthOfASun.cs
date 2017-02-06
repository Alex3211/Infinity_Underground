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
    public class BirthOfASun : SpriteSheet
    {
        Texture2D _smoke;
        Texture2D _fusion;
        int _lastTurn;
        SpriteSheet _monster;
        SpriteSheet _player;
        Vector2 _position;
        int _smokeWidth;
        int _smokeHeight;
        int _fusionWidth;
        int _fusionHeight;

        SoundEffect _dustSong;
        SoundEffect _fusionSong;
        SoundEffect _sunSong;

        public BirthOfASun(SpriteSheet monster, SPlayer player)
        {
            SpriteSheetColumns = 6;
            SpriteSheetRows = 6;
            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            MillisecondsPerFrame = 60;
            IsSpell = true;
            SpellReapeat = true;
            _monster = monster;
            NameSpell = "BirthOfASun";
            _player = player;
            _position = new Vector2(200, -125);
            _lastTurn = int.MaxValue;
        }



        public override void LoadContent(ContentManager content)
        {
            _dustSong = content.Load<SoundEffect>(@"Song\Sand");
            _fusionSong = content.Load<SoundEffect>(@"Song\Fusion");
            _sunSong = content.Load<SoundEffect>(@"Song\Sun");


            Spritesheet = content.Load<Texture2D>("SunTest");
            _smoke = content.Load<Texture2D>("Effect/Smoke");
            _fusion = content.Load<Texture2D>("Effect/fusion");
        }

        public override void Unload(ContentManager content)
        {
            if (_dustSong != null) _dustSong.Dispose();
            if (_fusionSong != null) _fusionSong.Dispose();
            if (_sunSong != null) _sunSong.Dispose();
            if (_smoke != null) _smoke.Dispose();
            if (_fusion != null) _fusion.Dispose();
            base.Unload(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle();

            Rectangle destinationRectangle = new Rectangle();

            
            if (_lastTurn != Turn)
            {
                switch (Turn)
                {

                    case 2:
                        _dustSong.Play();
                        SpriteSheetColumns = 7;
                        SpriteSheetRows = 7;
                        break;

                    case 0:
                        _sunSong.Play();
                        SpriteSheetColumns = 3;
                        SpriteSheetRows = 4;
                        break;

                    case 1:
                        _fusionSong.Play();
                        SpriteSheetColumns = 3;
                        SpriteSheetRows = 4;
                        break;

                }

                CurrentRow = 0;
                CurrentFrame = 0;
                TotalFrames = SpriteSheetRows * SpriteSheetColumns;

            }


            Column = CurrentFrame % SpriteSheetColumns;

            switch (Turn)
            {
                case 0:
                    Width = Spritesheet.Width / SpriteSheetColumns;
                    Height = Spritesheet.Height / SpriteSheetRows;

                    sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);

                    destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, Width * 2, Height * 2);

                    spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);
                    break;

                case 1:
                    _fusionWidth = _fusion.Width / SpriteSheetColumns;
                    _fusionHeight = _fusion.Height / SpriteSheetRows;

                    sourceRectangle = new Rectangle(_fusionWidth * Column, _fusionHeight * CurrentRow, _fusionWidth, _fusionHeight);

                    destinationRectangle = new Rectangle((int)_position.X + 25, (int)_position.Y + 150, _fusionWidth * 2, _fusionHeight * 2);


                    spriteBatch.Draw(_fusion, destinationRectangle, sourceRectangle, Color.White);

                    break;

                case 2:
                    _smokeWidth = _smoke.Width / SpriteSheetColumns;
                    _smokeHeight = _smoke.Height / SpriteSheetRows;

                    sourceRectangle = new Rectangle(_smokeWidth * Column, _smokeHeight * CurrentRow, _smokeWidth, _smokeHeight);

                    destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, _smokeWidth * 4, _smokeHeight * 4);

                    spriteBatch.Draw(_smoke, destinationRectangle, sourceRectangle, Color.White);
                    break;
            }


            _lastTurn = Turn;
        }

    }
}
