using InfinityUnderground.API.Characteres;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using InfinityUnderground.UserInterface;
using Microsoft.Xna.Framework.Content;
using InfinityUnderground.Characteres;

namespace InfinityUnderground.EntitiesUI
{
    class Bat : Spritesheet, IEntity
    {
        CTBat _bat;
        List<Action> _action;
        int _direction, _widthBar;
        LifePointMonster _healthBar;

        public Bat(int spriteSheetRows, int spriteSheetColumns, Game1 context, CTBat bat)
        {
            Context = context;

            _widthBar = 100;

            _bat = bat;
            
            SpriteSheetColumns = spriteSheetColumns;
            SpriteSheetRows = spriteSheetRows;

            TotalFrames = SpriteSheetRows * SpriteSheetColumns;

            _action = new List<Action>();


            _action.Add(new Action((int)IDActionBat.WalkTop, 4));
            _action.Add(new Action((int)IDActionBat.WalkRight, 4));
            _action.Add(new Action((int)IDActionBat.WalkBottom, 4));
            _action.Add(new Action((int)IDActionBat.WalkLeft, 4));

            _healthBar = new LifePointMonster(_widthBar, 5);
        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        public void LoadContent(ContentManager content)
        {
            SpriteSheet = Context.Content.Load<Texture2D>("Monster/Dragon");
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            Column = BatAnimating(gameTime);
        }

        /// <summary>
        /// Bats the animating.
        /// </summary>
        /// <returns></returns>
        int BatAnimating(GameTime gameTime)
        {
            if (_bat.IsDead)
            {
                return 0;
            }
            else
            {
                ResetCurrentFrame(gameTime);
            }
            return CurrentFrame % SpriteSheetColumns;
        }

        /// <summary>
        /// Resets the current frame.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        void ResetCurrentFrame(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (_bat.IsDead)
            {
                TimeSinceLastFrame = 0;
            }

            if (TimeSinceLastFrame > MillisecondsPerFrame)
            {
                CurrentFrame++;

                TimeSinceLastFrame = 0;
                if (CurrentFrame == TotalFrames)
                {
                    CurrentFrame = 0;
                }
            }
        }




        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="SpriteBatch">The sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Width = SpriteSheet.Width / SpriteSheetColumns;
            Height = SpriteSheet.Height / SpriteSheetRows;

            if (!_bat.IsDead)
            {
                _direction = _bat.MoveDirectionToThePlayer();
                _direction = (int)ConvertDirection();
            }
            if (_bat.IsDead)
            {
                Column = 3;
            }

            
            _healthBar.Draw(spriteBatch, _bat.PositionX, _bat.PositionY-20, _bat.GetCharacterType.LifePoint, Context.GraphicsDevice, SetHealthBar());

            Rectangle _sourceRectangle = new Rectangle(Width * Column, Height * _direction, Width, Height);
            Rectangle _destinationRectangle = new Rectangle(_bat.PositionX, _bat.PositionY, Width, Height);

            if(_bat.IsDead)
            {
                spriteBatch.Draw(SpriteSheet, _destinationRectangle, _sourceRectangle, Color.Black);
            }
            else
            {
                spriteBatch.Draw(SpriteSheet, _destinationRectangle, _sourceRectangle, Color.White);
            }
        }

        /// <summary>
        /// Sets the health bar.
        /// </summary>
        public int SetHealthBar()
        {
            //////////////
            return (_widthBar * _bat.GetCharacterType.LifePoint / 20);
        }


        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload(ContentManager content)
        {
        }

        /// <summary>
        /// Converts the direction.
        /// </summary>
        IDActionBat ConvertDirection()
        {
            switch (_direction)
            {
                case (int)Direction.Up:
                    return IDActionBat.WalkTop;

                case (int)Direction.Left:
                    return IDActionBat.WalkLeft;

                case (int)Direction.Bottom:
                    return IDActionBat.WalkBottom;

                case (int)Direction.Right:
                    return IDActionBat.WalkRight;
            }
            return (IDActionBat)_direction;
        }

    }
}
