using InfinityUndergroundReload.CharactersUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityUndergroundReload.Spell
{
    class DarkHole : SpriteSheet
    {
        SpriteSheet _monster;
        SPlayer _player;
        Texture2D _wormHole;
        Texture2D _whiteHole;

        int _wormHoleWidth;
        int _wormHoleHeight;

        int _lastTurn;

        float rotation;

        Vector2 _position;

        float _angle;


        SoundEffect _blackSong;
        SoundEffect _whiteSong;
        SoundEffect _wormSong;


        public DarkHole(SpriteSheet monster, SPlayer player)
        {
            SpriteSheetColumns = 6;
            SpriteSheetRows = 6;
            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            MillisecondsPerFrame = 60;
            IsSpell = true;
            SpellReapeat = false;
            _monster = monster;
            NameSpell = "DarkHole";
            _player = player;
            _position = new Vector2(400, 0);
            _lastTurn = int.MaxValue;
        }



        public override void LoadContent(ContentManager content)
        {
            try
            {
                _blackSong = content.Load<SoundEffect>(@"Song\Vortex");
                _wormSong = content.Load<SoundEffect>(@"Song\WormHole");
                _whiteSong = content.Load<SoundEffect>("Song/WhiteHole");
            }
            catch
            { }

            Spritesheet = content.Load<Texture2D>(@"Curiosity\black-hole");
            _whiteHole = content.Load<Texture2D>(@"Curiosity\white-hole");
            _wormHole = content.Load<Texture2D>(@"Curiosity\worm-hole");
        }
        public override void Unload(ContentManager content)
        {
            if (_blackSong != null) _blackSong.Dispose();
            if (_wormSong != null) _wormSong.Dispose();
            if (_whiteHole != null) _whiteHole.Dispose();

            if (_wormHole != null) _wormHole.Dispose();
            if (_whiteHole != null) _whiteHole.Dispose();
            base.Unload(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle();

            Rectangle destinationRectangle = new Rectangle();
        
            if (_lastTurn != Turn)
            {
                switch(Turn)
                {

                    case 1:
                        _wormSong.Play();
                        SpriteSheetColumns = 1;
                        SpriteSheetRows = 1;
                        break;

                    case 2:
                        _blackSong.Play();
                        SpriteSheetColumns = 6;
                        SpriteSheetRows = 6;
                        break;

                    case 0:
                        _whiteSong.Play();
                        SpriteSheetColumns = 6;
                        SpriteSheetRows = 6;
                        break;

                }

                CurrentRow = 0;
                CurrentFrame = 0;
                TotalFrames = SpriteSheetRows * SpriteSheetColumns;

            }



            Column = CurrentFrame % SpriteSheetColumns;

            switch (Turn)
            {
                case 2:
                    Width = Spritesheet.Width / SpriteSheetColumns;
                    Height = Spritesheet.Height / SpriteSheetRows;

                    sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);

                    destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, Width * 4, Height * 4);

                    spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);
                    break;
                
                case 1:
                    _angle += 55.55f;
                    Vector2 _origin = new Vector2(_wormHole.Width / 2, _wormHole.Height / 2);
                    _wormHoleWidth = _wormHole.Width / SpriteSheetColumns;
                    _wormHoleHeight = _wormHole.Height / SpriteSheetRows;

                    sourceRectangle = new Rectangle(0, 0, _wormHoleWidth, _wormHoleHeight);

                    destinationRectangle = new Rectangle((int)_position.X + 400, (int)_position.Y + 500, _wormHoleWidth * 2, _wormHoleHeight * 2);


                    spriteBatch.Draw(_wormHole, destinationRectangle, sourceRectangle, Color.White, _angle, _origin, SpriteEffects.None, 1);
                    break;

                case 0:
                    sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);

                    destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, Width * 4, Height * 4);

                    spriteBatch.Draw(_whiteHole, destinationRectangle, sourceRectangle, Color.White);
                    break;
            }


            _lastTurn = Turn;


            if (_monster.Context.Fights.StopSong)
            {
                _monster.Context.Fights.StopSong = false;
            }

        }


    }
}
