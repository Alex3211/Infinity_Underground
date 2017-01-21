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
            _position = new Vector2(300, 0);
            _lastTurn = int.MaxValue;
        }



        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Curiosity/black-hole");
            _whiteHole = content.Load<Texture2D>("Curiosity/white-hole");
            _wormHole = content.Load<Texture2D>("Curiosity/worm-hole");
        }

        public override void Unload(ContentManager content)
        {
            if (_wormHole != null) _wormHole.Dispose();
            if (_whiteHole != null) _wormHole.Dispose();
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
                        SpriteSheetColumns = 1;
                        SpriteSheetRows = 1;
                        break;

                    case 2:
                    case 0:
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
                    _wormHoleWidth = _wormHole.Width / SpriteSheetColumns;
                    _wormHoleHeight = _wormHole.Height / SpriteSheetRows;

                    sourceRectangle = new Rectangle(0, 0, _wormHoleWidth, _wormHoleHeight);

                    destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, _wormHoleWidth * 3, _wormHoleHeight * 3);


                    spriteBatch.Draw(_wormHole, destinationRectangle, sourceRectangle, Color.White);

                    break;

                case 0:
                    sourceRectangle = new Rectangle(Width * Column, Height * CurrentRow, Width, Height);

                    destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, Width * 4, Height * 4);

                    spriteBatch.Draw(_whiteHole, destinationRectangle, sourceRectangle, Color.White);
                    break;
            }


            _lastTurn = Turn;
        }


    }
}
