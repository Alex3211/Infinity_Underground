using System;
using System.Collections.Generic;
using InfinityUndergroundReload.API.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using MonoGame.Extended.Maps.Tiled;
using Microsoft.Xna.Framework.Audio;

namespace InfinityUndergroundReload.CharactersUI
{

    enum IDActionDragon
    {
        WalkBottom,
        WalkLeft,
        WalkRight,
        WalkTop
    }

    class SDragon : SpriteSheet
    {
        List<ActionSpriteSheet> _action;
        int _widthBar;
        LifePoint _healthBar;
        int _direction;
        Random _random;
        Vector2 _lastPosition;
        SoundEffect _dragonRoar;
        //SoundEffect _songAttack;


        /// <summary>
        /// Initializes a new instance of the <see cref="Dragon"/> class.
        /// </summary>
        /// <param name="spriteSheetRows">The sprite sheet rows.</param>
        /// <param name="spriteSheetColumns">The sprite sheet columns.</param>
        /// <param name="context">The context.</param>
        /// <param name="bat">The bat.</param>
        public SDragon(int spriteSheetRows, int spriteSheetColumns, InfinityUnderground context, CDragon dragon)
        {
            _random = new Random();
            Context = context;

            _widthBar = 100;

            Monster = dragon;

            SpriteSheetColumns = spriteSheetColumns;
            SpriteSheetRows = spriteSheetRows;

            TotalFrames = SpriteSheetRows * SpriteSheetColumns;

            _action = new List<ActionSpriteSheet>();


            _action.Add(new ActionSpriteSheet((int)IDActionDragon.WalkTop, 4));
            _action.Add(new ActionSpriteSheet((int)IDActionDragon.WalkRight, 4));
            _action.Add(new ActionSpriteSheet((int)IDActionDragon.WalkBottom, 4));
            _action.Add(new ActionSpriteSheet((int)IDActionDragon.WalkLeft, 4));

            _healthBar = new LifePoint(_widthBar, 5);

            TypeOfMonster = Monster.TypeOfMonster;

            var _actionD = from action in _action where action.RowAction == (int)IDActionDragon.WalkBottom select action;
            foreach (ActionSpriteSheet action in _actionD)
            {
                _direction = action.RowAction;
            }

            FightsPosition = new Vector2(1300, 250);
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Dragon/Dragon");
            if (Context.Fight != null)
            {
                _dragonRoar = content.Load<SoundEffect>(@"Song\DragonRoar");
                _dragonRoar.Play();
            }
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }


        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="SpriteBatch">The sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle _destinationRectangle;
            Width = Spritesheet.Width / SpriteSheetColumns;
            Height = Spritesheet.Height / SpriteSheetRows;

            Column = CurrentFrame % SpriteSheetColumns;
            

            if (Context.Fight != null)
            {
                if (_lastPosition == new Vector2(0,0)) _lastPosition = Monster.Position;
                _direction = (int)IDActionDragon.WalkLeft;  
            }
            //else if (_lastPosition != new Vector2(0,0))
            //{
            //    Monster.Position = _lastPosition;
            //}

            _healthBar.Draw(spriteBatch, Monster.PositionX, Monster.PositionY - 20, Monster.CharacterType.LifePoint, Context.GraphicsDevice, (_widthBar * Monster.CharacterType.LifePoint / 20), 2);

            Rectangle _sourceRectangle = new Rectangle(Width * Column, Height * _direction, Width, Height);

            if (Context.Fight != null)
            {
                _destinationRectangle = new Rectangle((int)FightsPosition.X, (int)FightsPosition.Y, Width * 6, Height * 6);
            }
            else
            {
                _destinationRectangle = new Rectangle(Monster.PositionX, Monster.PositionY, Width, Height);
            }

            spriteBatch.Draw(Spritesheet, _destinationRectangle, _sourceRectangle, Color.White);

        }

    }
}
