using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Kepler_22_B.API.Characteres;
using Kepler_22_B.Characteres;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Maps.Tiled;

namespace Kepler_22_B.EntitiesUI
{
    class Player : Spritesheet , IEntity 
    {
        KeyboardState _state;
        CTPlayer _player;
        int _playerDirection, _lastMoveSpeed, _timeSinceLastAttack;
        List<Action> _playerAction;
        Action _actualAction, _lastAction;
        bool _playerAttack, _isAttacking;
 

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="spriteSheetRows">The sprite sheet rows.</param>
        /// <param name="spriteSheetColumns">The sprite sheet columns.</param>
        /// <param name="spriteSheet">The sprite sheet.</param>
        public Player(int spriteSheetRows, int spriteSheetColumns, Game1 context)
        {
            Context = context;
            Context.Player = this;
            
            SpriteSheetColumns = spriteSheetColumns;
            SpriteSheetRows = spriteSheetRows;

            TotalFrames = SpriteSheetRows * SpriteSheetColumns;
            _player = Context.WorldAPI.Players[0];
            _playerDirection = (int)Direction.Bottom;

            _lastMoveSpeed = _player.GetCharacterType.MoveSpeed;

            _playerAction = new List<Action>();


            _playerAction.Add(new Action((int)IDActionPlayer.WalkTop, 9));
            _playerAction.Add(new Action((int)IDActionPlayer.WalkLeft, 9));
            _playerAction.Add(new Action((int)IDActionPlayer.WalkBottom, 9));
            _playerAction.Add(new Action((int)IDActionPlayer.WalkRight, 9));
            _playerAction.Add(new Action((int)IDActionPlayer.AttackTop, 6));
            _playerAction.Add(new Action((int)IDActionPlayer.AttackLeft, 6));
            _playerAction.Add(new Action((int)IDActionPlayer.AttackBottom, 6));
            _playerAction.Add(new Action((int)IDActionPlayer.AttackRight, 6));
            _playerAction.Add(new Action((int)IDActionPlayer.TakeDamageTop, 7));
            _playerAction.Add(new Action((int)IDActionPlayer.TakeDamageLeft, 7));
            _playerAction.Add(new Action((int)IDActionPlayer.TakeDamageBottom, 7));
            _playerAction.Add(new Action((int)IDActionPlayer.TakeDamageRight, 7));

            var _action = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.WalkBottom select action;
            foreach (Action action in _action)
            {
                _actualAction = action;
            }
            
        }

        /// <summary>
        /// Gets the get player.
        /// </summary>
        /// <value>
        /// The get player.
        /// </value>
        internal CTPlayer CTPlayer { get { return _player; } }


        public void LoadContent(ContentManager content)
        {
            SpriteSheet = Context.Content.Load<Texture2D>("Player/Player");
        }

        /// <summary>
        /// For zoom on or out the player.
        /// </summary>
        /// <param name="gameTime"></param>
        void ZoomPlayer(GameTime gameTime)
        {
            if (_state.IsKeyDown(Keys.PageUp))
            {
                Context.CameraLoader.GetCamera.ZoomIn(Context.CameraLoader.Zoom);
            }
            if (_state.IsKeyDown(Keys.PageDown))
            {
                Context.CameraLoader.GetCamera.ZoomOut(Context.CameraLoader.Zoom);
            }
        }



        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            if (_playerAttack && (Column + 1) == _actualAction.Column)
            {
                _playerAttack = false;
                MillisecondsPerFrame = 80;
            }
            else
            {
                _state = Keyboard.GetState();
            }

            _timeSinceLastAttack += gameTime.ElapsedGameTime.Milliseconds;

            if (_playerAttack)
            {
                _isAttacking = _player.PlayerAttack((Direction)_playerDirection, ref _timeSinceLastAttack);
            }

            Column = WalkAnimating(gameTime);

            _player.CanMove = BlockThePlayer(GetTheDirectionOfThePlayer());

            _playerDirection = UpdatePositionOfPlayerAndCamera(gameTime);

        }

        /// <summary>
        /// Walk animating.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <returns>int of the column for SpriteSheet</returns>
        int WalkAnimating(GameTime gameTime)
        {
            if (_player.IsMoving || _playerAttack)
            {
                ResetCurrentFrame(gameTime);
                return CurrentFrame % SpriteSheetColumns;
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// Resets the current frame.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        void ResetCurrentFrame(GameTime gameTime)
        {
            TimeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if ((!_player.CanMove || !_player.IsMoving) && !_playerAttack)
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
        /// Blocks the player.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        bool BlockThePlayer(int direction)
        {

            int _tileWidth = Context.MapLoad.GetLayerCollide.TileWidth;

            switch (GetTheDirectionOfThePlayer())
            {
                case (int)Direction.Up:
                    return (_player.PositionY >= 0 && (Context.MapLoad.GetLayerCollide.GetTile((int)Math.Floor((decimal)_player.PositionX / (decimal)_tileWidth) + 1, (int)Math.Round((decimal)_player.PositionY / (decimal)_tileWidth)).Id != Context.MapLoad.IdTileCollide));

                case (int)Direction.Left:
                    return (_player.PositionX >= 0 && (Context.MapLoad.GetLayerCollide.GetTile((int)Math.Round((decimal)_player.PositionX / (decimal)_tileWidth), (int)Math.Round((decimal)_player.PositionY / (decimal)_tileWidth) + 1).Id != Context.MapLoad.IdTileCollide));

                case (int)Direction.Bottom:
                    return ((_player.PositionY <= (Context.MapLoad.GetMap.HeightInPixels - 50)) && (Context.MapLoad.GetLayerCollide.GetTile((int)Math.Floor((decimal)(_player.PositionX / (decimal)_tileWidth)) + 1, ((int)Math.Floor((decimal)_player.PositionY / (decimal)_tileWidth)) + 2).Id != Context.MapLoad.IdTileCollide));

                case (int)Direction.Right:
                    return ((_player.PositionX <= (Context.MapLoad.GetMap.WidthInPixels)) && (Context.MapLoad.GetLayerCollide.GetTile(((int)Math.Round((decimal)_player.PositionX / (decimal)_tileWidth)) + 1, ((int)Math.Round((decimal)_player.PositionY / (decimal)_tileWidth)) + 1).Id != Context.MapLoad.IdTileCollide));

            }
            return true;
        }


        /// <summary>
        /// Gets the direction of the player.
        /// </summary>
        /// <returns></returns>
        int GetTheDirectionOfThePlayer()
        {

            _player.IsMoving = true;

            if (_state.IsKeyDown(Keys.Z) || _state.IsKeyDown(Keys.Up))
            {
                return (int)Direction.Up;
            }
            if (_state.IsKeyDown(Keys.S) || _state.IsKeyDown(Keys.Down))
            {
                return (int)Direction.Bottom;
            }
            if (_state.IsKeyDown(Keys.Q) || _state.IsKeyDown(Keys.Left))
            {
                return (int)Direction.Left;
            }
            if (_state.IsKeyDown(Keys.D) || _state.IsKeyDown(Keys.Right))
            {
                return (int)Direction.Right;
            }

            _player.IsMoving = false;
            return _playerDirection;
        }


        /// <summary>
        /// Updates the position of player and camera.
        /// </summary>
        /// <returns>the int of the direction</returns>
        int UpdatePositionOfPlayerAndCamera(GameTime gameTime)
        {

            ZoomPlayer(gameTime);
            PlayerSpeed();

            if (_player.CanMove && _player.IsMoving)
            {
                switch (GetTheDirectionOfThePlayer())
                {
                    case (int)Direction.Up:
                        Context.CameraLoader.GetCamera.Move(new Vector2(0, -_player.GetCharacterType.MoveSpeed));
                        return _player.Deplacement((int)Direction.Up);

                    case (int)Direction.Bottom:
                        Context.CameraLoader.GetCamera.Move(new Vector2(0, +_player.GetCharacterType.MoveSpeed));
                        return _player.Deplacement((int)Direction.Bottom);

                    case (int)Direction.Left:
                        Context.CameraLoader.GetCamera.Move(new Vector2(-_player.GetCharacterType.MoveSpeed, 0));
                        return _player.Deplacement((int)Direction.Left);

                    case (int)Direction.Right:
                        Context.CameraLoader.GetCamera.Move(new Vector2(+_player.GetCharacterType.MoveSpeed, 0));
                        return _player.Deplacement((int)Direction.Right);
                }
            }

            return GetTheDirectionOfThePlayer();

        }


        /// <summary>
        /// Control for the player srpint.
        /// </summary>
        void PlayerSpeed()
        {
            if (_state.IsKeyDown(Keys.LeftShift))
            {
                _player.GetCharacterType.MoveSpeed = _player.Sprint;
                MillisecondsPerFrame = 40;
            }
            else if (_state.IsKeyUp(Keys.LeftShift))
            {
                MillisecondsPerFrame = 80;
                _player.GetCharacterType.MoveSpeed = _lastMoveSpeed;
            }
        }




        /// <summary>
        /// Draws this instance.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            Width = SpriteSheet.Width / SpriteSheetColumns;
            Height = SpriteSheet.Height / SpriteSheetRows;

            _lastAction = _actualAction;
            _actualAction = SelectAction();
            

            if (_actualAction.Column == (Column+1))
            {
                CurrentFrame = TotalFrames;
            }

            if (_lastAction != _actualAction)
            {
                CurrentFrame = 0;
            }
            

            Rectangle _sourceRectangle = new Rectangle(Width * Column, Height * (int)_actualAction.IDActionPlayer, Width, Height);
            Rectangle _destinationRectangle = new Rectangle(_player.PositionX, _player.PositionY, Width, Height);

            spriteBatch.Draw(SpriteSheet, _destinationRectangle, _sourceRectangle, Color.White);
        }


        Action SelectAction()
        {
            if (_state.IsKeyDown(Keys.Z) || _state.IsKeyDown(Keys.Up))
            {
                var _action = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.WalkTop select action;
                foreach (Action action in _action)
                {
                    return action;
                }
            }
            if (_state.IsKeyDown(Keys.S) || _state.IsKeyDown(Keys.Down))
            {
                var _action = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.WalkBottom select action;
                foreach (Action action in _action)
                {
                    return action;
                }
            }
            if (_state.IsKeyDown(Keys.Q) || _state.IsKeyDown(Keys.Left))
            {
                var _action = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.WalkLeft select action;
                foreach (Action action in _action)
                {
                    return action;
                }
            }
            if (_state.IsKeyDown(Keys.D) || _state.IsKeyDown(Keys.Right))
            {
                var _action = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.WalkRight select action;
                foreach (Action action in _action)
                {
                    return action;
                }
            }
            if (_state.IsKeyDown(Keys.Space))
            {


                _playerAttack = true;
                MillisecondsPerFrame = 20;
                switch ((int)_actualAction.IDActionPlayer % 4)
                {
                    case 0:
                        var _actionTop = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.AttackTop select action;
                        foreach (Action action in _actionTop)
                        {
                            return action;
                        }
                        break;

                    case 1:
                        var _actionLeft = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.AttackLeft select action;
                        foreach (Action action in _actionLeft)
                        {
                            return action;
                        }
                        break;

                    case 2:
                        var _actionBottom = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.AttackBottom select action;
                        foreach (Action action in _actionBottom)
                        {
                            return action;
                        }
                        break;

                    case 3:
                        var _actionRight = from action in _playerAction where action.IDActionPlayer == (int)IDActionPlayer.AttackRight select action;
                        foreach (Action action in _actionRight)
                        {
                            return action;
                        }
                        break;
                }
            }
            return _actualAction;
        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        public void Unload()
        {
        }
    }
}
