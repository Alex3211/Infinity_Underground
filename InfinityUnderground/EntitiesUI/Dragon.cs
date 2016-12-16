using InfinityUnderground.API.Characteres;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using InfinityUnderground.UserInterface;
using Microsoft.Xna.Framework.Content;
using InfinityUnderground.Characteres;

namespace InfinityUnderground.EntitiesUI
{
    class Dragon : Spritesheet, IEntity
    {
        CTDragon _dragon;
        List<Action> _action;
        int _direction, _widthBar;
        LifePointMonster _healthBar;

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
            if (_dragon.IsDead)
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

            if (_dragon.IsDead)
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

            if (!_dragon.IsDead)
            {
                _direction = _dragon.MoveDirectionToThePlayer();
                _direction = (int)ConvertDirection();
            }
            if (_dragon.IsDead)
            {
                Column = 3;
            }

            
            _healthBar.Draw(spriteBatch, _dragon.PositionX, _dragon.PositionY-20, _dragon.GetCharacterType.LifePoint, Context.GraphicsDevice, SetHealthBar());

            Rectangle _sourceRectangle = new Rectangle(Width * Column, Height * _direction, Width, Height);
            Rectangle _destinationRectangle = new Rectangle(_dragon.PositionX, _dragon.PositionY, Width, Height);

            if(_dragon.IsDead)
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
            return (_widthBar * _dragon.GetCharacterType.LifePoint / 20);
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

    }
}
