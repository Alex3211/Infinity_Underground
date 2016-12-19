using InfinityUnderground.API.Characteres;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using InfinityUnderground.UserInterface;
using Microsoft.Xna.Framework.Content;
using InfinityUnderground.Characteres;
using Microsoft.Xna.Framework.Audio;

namespace InfinityUnderground.EntitiesUI
{
    class Dragon : Spritesheet, IEntity
    {
        CTDragon _dragon;
        List<Action> _action;
        int _direction, _widthBar, _timeSinceLastAttack, _millisecondPerFrameFlame, _currentFlame, _columnFlame, _totalFramesFlame, _timeSindceLastFrameFlame, _heightFlame, _spriteSheetFlameColumns, _spriteSheetFlameRows;
        LifePointMonster _healthBar;
        bool _isMoving, _animateFlame, _dragonAttack;
        Texture2D _flame;
        Vector2 spriteOrigin;
        SoundEffect _songAttack;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dragon"/> class.
        /// </summary>
        /// <param name="spriteSheetRows">The sprite sheet rows.</param>
        /// <param name="spriteSheetColumns">The sprite sheet columns.</param>
        /// <param name="context">The context.</param>
        /// <param name="bat">The bat.</param>
        public Dragon(int spriteSheetRows, int spriteSheetColumns, Game1 context, CTDragon bat)
        {
            Context = context;

            _widthBar = 100;

            _dragon = bat;
            
            SpriteSheetColumns = spriteSheetColumns;
            SpriteSheetRows = spriteSheetRows;

            TotalFrames = SpriteSheetRows * SpriteSheetColumns;

            _action = new List<Action>();


            _action.Add(new Action((int)IDActionDragon.WalkTop, 4));
            _action.Add(new Action((int)IDActionDragon.WalkRight, 4));
            _action.Add(new Action((int)IDActionDragon.WalkBottom, 4));
            _action.Add(new Action((int)IDActionDragon.WalkLeft, 4));

            _healthBar = new LifePointMonster(_widthBar, 5);

            _millisecondPerFrameFlame = 20;
            _spriteSheetFlameColumns = 8;
            _spriteSheetFlameRows = 7;
            _totalFramesFlame = _spriteSheetFlameColumns/2;
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            SpriteSheet = Context.Content.Load<Texture2D>("Monster/Dragon");
            _flame = Context.Content.Load<Texture2D>("Effect/Flame");
            _songAttack = Context.Content.Load<SoundEffect>("Song/Dragon/DreathIce");
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            _timeSinceLastAttack += gameTime.ElapsedGameTime.Milliseconds;

            if (!_isMoving)
            {
                _dragonAttack = _dragon.DragonAttack((Direction)_direction, ref _timeSinceLastAttack);
                if (_dragonAttack) _animateFlame = true;
            }

            if (!_dragon.IsDead)
            {
                _direction = _dragon.MoveDirectionToThePlayer(ref _direction, ref _isMoving);

                if (_isMoving)
                {
                    _direction = (int)ConvertDirection();
                }
            }



            int currentFrame = CurrentFrame;
            int totalFrame = TotalFrames;
            int timeSinceLastFrame = TimeSinceLastFrame;
            int spriteSheetColumns = SpriteSheetColumns;
            int column = Column;
            AnimatingObject(gameTime, ref currentFrame, ref timeSinceLastFrame, TotalFrames, spriteSheetColumns, ref column, MillisecondsPerFrame);
            CurrentFrame = currentFrame;
            TotalFrames = totalFrame;
            TimeSinceLastFrame = timeSinceLastFrame;
            SpriteSheetColumns = spriteSheetColumns;
            Column = column;




            if (AnimatingObject(gameTime, ref _currentFlame, ref _timeSindceLastFrameFlame, _totalFramesFlame, 6, ref _columnFlame, _millisecondPerFrameFlame))
            {
                _heightFlame++;
                if (_heightFlame == _spriteSheetFlameRows)
                {
                    _heightFlame = 0;
                    _animateFlame = false;
                    
                }
            }



            if (_dragon.IsDead)
            {
                Column = 3;
            }
        }

        /// <summary>
        /// Bats the animating.
        /// </summary>
        /// <returns></returns>
        bool AnimatingObject(GameTime gameTime, ref int currentFrame, ref int timeSinceLastFrame, int totalFrames, int spriteSheetColumns, ref int column, int millisecondsPerFrame)
        {
            bool forAttack = false;

            if (_dragon.IsDead)
            {
                column = 0;
            }
            else
            {
                forAttack = ResetcurrentFrame(gameTime, millisecondsPerFrame, totalFrames, ref currentFrame, ref timeSinceLastFrame);
            }

            column = currentFrame % spriteSheetColumns;
            return forAttack;
        }

        /// <summary>
        /// Resets the current frame.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        bool ResetcurrentFrame(GameTime gameTime, int millisecondsPerFrame, int totalFrames, ref int currentFrame, ref int timeSinceLastFrame)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (_dragon.IsDead)
            {
                timeSinceLastFrame = 0;
            }

            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                currentFrame++;

                timeSinceLastFrame = 0;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                    return true;
                }
            }
            return false;
        }



        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="SpriteBatch">The sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Width = SpriteSheet.Width / SpriteSheetColumns;
            Height = SpriteSheet.Height / SpriteSheetRows;

            int widthFlame = _flame.Width / _spriteSheetFlameColumns;
            int heightFlame = _flame.Height / _spriteSheetFlameRows;

            
            _healthBar.Draw(spriteBatch, _dragon.PositionX, _dragon.PositionY-20, _dragon.GetCharacterType.LifePoint, Context.GraphicsDevice, SetHealthBar());

            Rectangle _sourceRectangle = new Rectangle(Width * Column, Height * _direction, Width, Height);
            Rectangle _destinationRectangle = new Rectangle(_dragon.PositionX, _dragon.PositionY, Width, Height);
           

            Rectangle _sourceRectangleFlame = new Rectangle(widthFlame * _columnFlame, heightFlame * _heightFlame, widthFlame, heightFlame);
            spriteOrigin = new Vector2(_sourceRectangleFlame.Width / 2, _sourceRectangleFlame.Height / 2);

            Rectangle _destinationRectangleFlame = SetPositionFlame( widthFlame, heightFlame);

            if (_dragon.IsDead)
            {
                spriteBatch.Draw(SpriteSheet, _destinationRectangle, _sourceRectangle, Color.Black);
            }
            else
            {
                if (_animateFlame)
                {
                    FlipSpriteSheet(_destinationRectangleFlame, _sourceRectangleFlame, spriteBatch);
                    _songAttack.Play();
                }

                spriteBatch.Draw(SpriteSheet, _destinationRectangle, _sourceRectangle, Color.White);
            }
        }

        /// <summary>
        /// Sets the health bar.
        /// </summary>
        public int SetHealthBar()
        {
            return (_widthBar * _dragon.GetCharacterType.LifePoint / 20);
        }


        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload(ContentManager content)
        {
            if (SpriteSheet != null) SpriteSheet.Dispose();
            if (_flame != null)  _flame.Dispose();
            if (_songAttack != null)  _songAttack.Dispose();
            content.Unload();
        }

        /// <summary>
        /// Converts the direction.
        /// </summary>
        IDActionDragon ConvertDirection()
        {
            switch (_direction)
            {
                case (int)Direction.Up:
                    return IDActionDragon.WalkTop;

                case (int)Direction.Left:
                    return IDActionDragon.WalkLeft;

                case (int)Direction.Bottom:
                    return IDActionDragon.WalkBottom;

                case (int)Direction.Right:
                    return IDActionDragon.WalkRight;
            }
            return (IDActionDragon)_direction;
        }

        /// <summary>
        /// Flips the sprite sheet flame.
        /// </summary>
        Rectangle SetPositionFlame(int widthFlame, int heightFlame)
        {
            switch((IDActionDragon)_direction)
            {

                case IDActionDragon.WalkTop:
                    return new Rectangle(_dragon.PositionX + (int)(_dragon.GetCharacterType.Range*0.2), _dragon.PositionY - (int)(_dragon.GetCharacterType.Range*0.6), widthFlame, heightFlame);


                case IDActionDragon.WalkLeft:
                    return new Rectangle(_dragon.PositionX - (int)(_dragon.GetCharacterType.Range * 0.7), _dragon.PositionY + (int)(_dragon.GetCharacterType.Range * 0.4), widthFlame, heightFlame);


                case IDActionDragon.WalkBottom:
                    return new Rectangle(_dragon.PositionX + (int)(_dragon.GetCharacterType.Range*0.25), _dragon.PositionY + (int)(_dragon.GetCharacterType.Range * 1.2), widthFlame, heightFlame);
                    

                case IDActionDragon.WalkRight:
                    return new Rectangle(_dragon.PositionX + (int)(_dragon.GetCharacterType.Range * 1.2), _dragon.PositionY + (int)(_dragon.GetCharacterType.Range * 0.3), widthFlame, heightFlame);
                    

            }
            return new Rectangle(_dragon.PositionX, _dragon.PositionY, widthFlame, heightFlame);

        }

        void FlipSpriteSheet(Rectangle _destinationRectangleFlame, Rectangle _sourceRectangleFlame, SpriteBatch spriteBatch)
        {
            switch((IDActionDragon)_direction)
            {

                case IDActionDragon.WalkTop:
                    spriteBatch.Draw(_flame, _destinationRectangleFlame, _sourceRectangleFlame, Color.White, 0.0f, spriteOrigin, SpriteEffects.None, 0);
                    break;


                case IDActionDragon.WalkLeft:
                    spriteBatch.Draw(_flame, _destinationRectangleFlame, _sourceRectangleFlame, Color.White, 4.7f, spriteOrigin, SpriteEffects.None, 0);
                    break;


                case IDActionDragon.WalkBottom:
                    spriteBatch.Draw(_flame, _destinationRectangleFlame, _sourceRectangleFlame, Color.White, 3.1f, spriteOrigin, SpriteEffects.FlipHorizontally, 0);
                    break;


                case IDActionDragon.WalkRight:
                    spriteBatch.Draw(_flame, _destinationRectangleFlame, _sourceRectangleFlame, Color.White, 1.6f, spriteOrigin, SpriteEffects.None, 0);
                    break;


            }
        }



    }
}
