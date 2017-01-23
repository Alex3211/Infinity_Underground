using InfinityUndergroundReload.API.Characters;
using InfinityUndergroundReload.Spell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.CharactersUI
{
    enum IDActionAngel
    {
        WalkBottom,
        WalkLeft,
        WalkRight,
        WalkTop
    }


    class SAngel : SpriteSheet
    {
        List<ActionSpriteSheet> _action;
        int _widthBar;
        LifePoint _healthBar;
        SpeedBarFights _speedBar;
        int _direction;
        Vector2 _lastPosition;
        List<SpriteSheet> _spells;
        int _lastLifePoint;
        CAttacks _lastAttack;
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
        public SAngel(int spriteSheetRows, int spriteSheetColumns, InfinityUnderground context, CAngel angel)
        {
            _redHit = 120;

            Context = context;

            _widthBar = 100;

            Monster = angel;

            SpriteSheetColumns = spriteSheetColumns;
            SpriteSheetRows = spriteSheetRows;

            TotalFrames = SpriteSheetRows * SpriteSheetColumns;

            _action = new List<ActionSpriteSheet>();


            _action.Add(new ActionSpriteSheet((int)IDActionCuriosity.WalkTop, 4));
            _action.Add(new ActionSpriteSheet((int)IDActionCuriosity.WalkRight, 4));
            _action.Add(new ActionSpriteSheet((int)IDActionCuriosity.WalkBottom, 4));
            _action.Add(new ActionSpriteSheet((int)IDActionCuriosity.WalkLeft, 4));

            _healthBar = new LifePoint(_widthBar, 5);
            _speedBar = new SpeedBarFights(_widthBar, 5);

            TypeOfMonster = Monster.TypeOfMonster;

            var _actionD = from action in _action where action.RowAction == (int)IDActionCuriosity.WalkBottom select action;
            foreach (ActionSpriteSheet action in _actionD)
            {
                _direction = action.RowAction;
            }

            FightsPosition = new Vector2(1000, 400);

            _spells = new List<SpriteSheet>();

            if (Context.LoadOrUnloadFights == FightsState.InFights)
            {
                foreach (string spell in Monster.ListOfAttack)
                {
                    switch (spell)
                    {
                        case "Meteor":
                            _spells.Add(new Meteor(this, Context.Player));
                            break;

                        case "BirthOfASun":
                            _spells.Add(new BirthOfASun(this, Context.Player));
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
            Spritesheet = content.Load<Texture2D>("Angel/Angel");

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
            if (Context.LoadOrUnloadFights == FightsState.InFights)
            {
                if (Context.Fights.Turn == API.CharacterTurn.Monster && Context.Fights.CurrentAttack != null)
                {
                    foreach (SpriteSheet s in _spells)
                    {
                        if (s.NameSpell == Context.Fights.CurrentAttack.Name)
                        {
                            s.Update(gameTime);
                        }
                    }
                }
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
                foreach (SpriteSheet s in _spells)
                {
                    if (_lastAttack != Context.Fights.CurrentAttack)
                    {
                        s.ResetPosition = true;
                    }

                }

                if (Context.Fights.Turn == API.CharacterTurn.Monster && Context.Fights.CurrentAttack != null)
                {

                    foreach (SpriteSheet s in _spells)
                    {

                        if (s.NameSpell == Context.Fights.CurrentAttack.Name)
                        {
                            s.Turn = Context.Fights.CurrentAttack.TurnsDuringDamage;
                            s.Draw(spriteBatch);
                        }

                        if (s.ResetPosition)
                        {
                            s.ResetPosition = false;
                        }
                    }
                }

                _lastAttack = Context.Fights.CurrentAttack;


                _speedBar.Draw(spriteBatch, (int)FightsPosition.X + 200, (int)FightsPosition.Y - 20, Monster.CharacterType.LifePoint, Context.GraphicsDevice, (int)Context.Fights.TheFights.MonsterTurnsLoading, 10, true);
                _healthBar.Draw(spriteBatch, (int)FightsPosition.X + 200, (int)FightsPosition.Y - 40, Monster.CharacterType.LifePoint, Context.GraphicsDevice, Monster.CharacterType.MaxLifePoint, 10, true);
                _destinationRectangle = new Rectangle((int)FightsPosition.X, (int)FightsPosition.Y, Width * 9, Height * 9);
            }
            else
            {
                _destinationRectangle = new Rectangle(Monster.PositionX, Monster.PositionY, Width * 4, Height * 4);
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