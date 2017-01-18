using System;
using System.Collections.Generic;
using InfinityUndergroundReload.API.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Linq;
using MonoGame.Extended.Maps.Tiled;
using Microsoft.Xna.Framework.Audio;
using InfinityUndergroundReload.Spell;

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
        SpeedBarFights _speedBar;
        int _direction;
        Vector2 _lastPosition;
        List<SpriteSheet> _spells;
        int _lastLifePoint;
        bool _takeHit;
        int i;
        int _redHit;
        //SoundEffect _dragonRoar;


        /// <summary>
        /// Initializes a new instance of the <see cref="Dragon"/> class.
        /// </summary>
        /// <param name="spriteSheetRows">The sprite sheet rows.</param>
        /// <param name="spriteSheetColumns">The sprite sheet columns.</param>
        /// <param name="context">The context.</param>
        /// <param name="bat">The bat.</param>
        public SDragon(int spriteSheetRows, int spriteSheetColumns, InfinityUnderground context, CDragon dragon)
        {
            _redHit = 300;

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
            _speedBar = new SpeedBarFights(_widthBar, 5);

            TypeOfMonster = Monster.TypeOfMonster;

            var _actionD = from action in _action where action.RowAction == (int)IDActionDragon.WalkBottom select action;
            foreach (ActionSpriteSheet action in _actionD)
            {
                _direction = action.RowAction;
            }

            FightsPosition = new Vector2(1300, 250);

            _spells = new List<SpriteSheet>();

            if (Context.LoadOrUnloadFights == FightsState.InFights)
            {
                foreach (string spell in Monster.ListOfAttack)
                {
                    switch (spell)
                    {
                        case "ThrowDarkMatter":
                            _spells.Add(new ThrowDarkMatter(this, Context.Player));
                            break;
                    }
                }
            }

            _lastLifePoint = Monster.CharacterType.LifePoint;

        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Dragon/Dragon");

            if (Context.LoadOrUnloadFights == FightsState.InFights)
            {
                foreach (SpriteSheet s in _spells)
                {
                    s.LoadContent(content);
                }
            }

            if (Context.Fights != null)
            {
                //_dragonRoar = content.Load<SoundEffect>(@"Song\DragonRoar");
                //_dragonRoar.Play();
            }
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public override void Update(GameTime gameTime)
        {
            foreach (SpriteSheet s in _spells)
            {
                s.Update(gameTime);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Unloads the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        public override void Unload(ContentManager content)
        {
            base.Unload(content);
            foreach (SpriteSheet s in _spells)
            {
                s.Unload(content);
            }
        }

        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="SpriteBatch">The sprite batch.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle _sourceRectangle;
            Rectangle _destinationRectangle;
            Width = Spritesheet.Width / SpriteSheetColumns;
            Height = Spritesheet.Height / SpriteSheetRows;

            Column = CurrentFrame % SpriteSheetColumns;


            if (Context.LoadOrUnloadFights == FightsState.InFights)
            {
                if (_lastPosition == new Vector2(0, 0)) _lastPosition = Monster.Position;
                _direction = (int)IDActionDragon.WalkLeft;
            }


            if (Monster.IsDead)
            {
                _sourceRectangle = new Rectangle(0, Height * _direction, Width, Height);
            }
            else
            {
                _sourceRectangle = new Rectangle(Width * Column, Height * _direction, Width, Height);
            }

            if (Context.LoadOrUnloadFights == FightsState.InFights)
            {

                if (Context.Fights.Turn == API.CharacterTurn.Monster && Context.Fights.CurrentAttack != null)
                {
                    foreach(SpriteSheet s in _spells)
                    {
                        if (s.NameSpell == Context.Fights.CurrentAttack.Name)
                        {
                            s.Draw(spriteBatch);
                        }
                    }
                }



                _speedBar.Draw(spriteBatch, (int)FightsPosition.X, (int)FightsPosition.Y - 20, Monster.CharacterType.LifePoint, Context.GraphicsDevice, (_widthBar * (int)Context.Fights.TheFights.MonsterTurnsLoading / 20), 10);
                _healthBar.Draw(spriteBatch, (int)FightsPosition.X, (int)FightsPosition.Y - 40, Monster.CharacterType.LifePoint, Context.GraphicsDevice, (_widthBar * Monster.CharacterType.LifePoint / 20), 20);
                _destinationRectangle = new Rectangle((int)FightsPosition.X, (int)FightsPosition.Y, Width * 6, Height * 6);
            }
            else
            {
                _destinationRectangle = new Rectangle(Monster.PositionX, Monster.PositionY, Width, Height);
            }

            if (_lastLifePoint != Monster.CharacterType.LifePoint || _takeHit)
            {

                _takeHit = true;

                i++;
                if (i > _redHit)
                {
                    _takeHit = false;
                    i = 0;
                }

                spriteBatch.Draw(Spritesheet, _destinationRectangle, _sourceRectangle, Color.Red);
            }
            else if (Monster.IsDead)
            {
                spriteBatch.Draw(Spritesheet, _destinationRectangle, _sourceRectangle, Color.Black);
            }
            else
            {
                spriteBatch.Draw(Spritesheet, _destinationRectangle, _sourceRectangle, Color.White);
            }
            _lastLifePoint = Monster.CharacterType.LifePoint;

        }

    }
}
