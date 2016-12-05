using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Kepler_22_B.API.Characteres;
using Kepler_22_B.Characteres;
using System;
using MonoGame.Extended.Maps.Tiled;

namespace Kepler_22_B.EntitiesUI
{
    class Player
    {
        Texture2D _spriteSheet;
        KeyboardState _state;
        Game1 _context;
        CTPlayer _player;
        readonly int _spriteSheetRows, _spriteSheetColumns, _totalFrames;
        int _timeSinceLastFrame, _currentFrame, _width, _height, _playerDirection, _column, _millisecondsPerFrame;


        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// </summary>
        /// <param name="spriteSheetRows">The sprite sheet rows.</param>
        /// <param name="spriteSheetColumns">The sprite sheet columns.</param>
        /// <param name="spriteSheet">The sprite sheet.</param>
        public Player(int spriteSheetRows, int spriteSheetColumns, Game1 context)
        {
            _context = context;

            _spriteSheet = _context.Content.Load<Texture2D>("Player/Walking");
            _spriteSheetColumns = spriteSheetColumns;
            _spriteSheetRows = spriteSheetRows;
            _timeSinceLastFrame = 0;
            _millisecondsPerFrame = 80;
            _totalFrames = _spriteSheetRows * _spriteSheetColumns;
            _player = _context.WorldAPI.Players[0];
            _playerDirection = (int)Direction.Bottom;
        }

        /// <summary>
        /// Gets the get player.
        /// </summary>
        /// <value>
        /// The get player.
        /// </value>
        internal CTPlayer GCTPlayer { get { return _player; } }

         
        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            _state = Keyboard.GetState();
            
            _column = WalkAnimating(gameTime);

            _player.CanMove = BlockThePlayer(GetTheDirectionOfThePlayer());

            _playerDirection = UpdatePositionOfPlayerAndCamera(gameTime);

        }

        /// <summary>
        /// Draws this instance.
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            _width = _spriteSheet.Width / _spriteSheetColumns;
            _height = _spriteSheet.Height / _spriteSheetRows;

            Rectangle _sourceRectangle = new Rectangle(_width * _column, _height * _playerDirection, _width, _height);
            Rectangle _destinationRectangle = new Rectangle(_player.PositionX, _player.PositionY, _width, _height);

            spriteBatch.Draw(_spriteSheet, _destinationRectangle, _sourceRectangle, Color.White);
        }


        /// <summary>
        /// Walk animating.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <returns>int of the column for SpriteSheet</returns>
        int WalkAnimating(GameTime gameTime)
        {
            if (_player.IsMoving)
            {
                ResetCurrentFrame(gameTime);
                return _currentFrame % _spriteSheetColumns;
            }
            else
            {
                return 0;
            }
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
                        if(_context.CameraLoader.GetCamera.Position.Y > 0 && _context.Player.GCTPlayer.PositionY < _context.MapLoad.GetMap.HeightInPixels- 350) _context.CameraLoader.GetCamera.Move(new Vector2(0, -_player.GetCharacterType.MoveSpeed));
                        return _player.Deplacement((int)Direction.Up);

                    case (int)Direction.Bottom:
                        if(_context.CameraLoader.GetCamera.Position.Y < _context.MapLoad.GetMap.HeightInPixels - 650 && _context.Player.GCTPlayer.PositionY > 250 ) _context.CameraLoader.GetCamera.Move(new Vector2(0, +_player.GetCharacterType.MoveSpeed));
                        return _player.Deplacement((int)Direction.Bottom);

                    case (int)Direction.Left:
                        if (_context.CameraLoader.GetCamera.Position.X > 0 && _context.Player.GCTPlayer.PositionY < _context.MapLoad.GetMap.WidthInPixels - 450) _context.CameraLoader.GetCamera.Move(new Vector2(-_player.GetCharacterType.MoveSpeed, 0));
                        return _player.Deplacement((int)Direction.Left);

                    case (int)Direction.Right:
                        if(_context.CameraLoader.GetCamera.Position.X < 0 || _context.Player.GCTPlayer.PositionX > 450) _context.CameraLoader.GetCamera.Move(new Vector2(+_player.GetCharacterType.MoveSpeed, 0));
                        return _player.Deplacement((int)Direction.Right);
                }
            }

            return GetTheDirectionOfThePlayer();

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
        /// For zoom on or out the player.
        /// </summary>
        /// <param name="gameTime"></param>
        void ZoomPlayer(GameTime gameTime)
        {
            if (_state.IsKeyDown(Keys.PageUp))
            {
                _context.CameraLoader.GetCamera.ZoomIn(_context.CameraLoader.Zoom);
            }
            if (_state.IsKeyDown(Keys.PageDown))
            {
                _context.CameraLoader.GetCamera.ZoomOut(_context.CameraLoader.Zoom);
            }
        }

        /// <summary>
        /// Resets the current frame.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        void ResetCurrentFrame(GameTime gameTime)
        {
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (!_player.CanMove || !_player.IsMoving)
            {
                _timeSinceLastFrame = 0;
            }

            if (_timeSinceLastFrame > _millisecondsPerFrame)
            {
                _timeSinceLastFrame -= _millisecondsPerFrame;

                _currentFrame++;

                _timeSinceLastFrame = 0;
                if (_currentFrame == _totalFrames)
                {
                    _currentFrame = 0;
                }
            }
        }


        /// <summary>
        /// Control for the player srpint.
        /// </summary>
        void PlayerSpeed()
        {
            if (_state.IsKeyDown(Keys.LeftShift))
            {
                _player.GetCharacterType.MoveSpeed = _player.Sprint;
                _millisecondsPerFrame = 40;
            }
            else if (_state.IsKeyUp(Keys.LeftShift))
            {
                _millisecondsPerFrame = 80;
                _player.GetCharacterType.MoveSpeed = 1;
            }
        }

        /// <summary>
        /// Blocks the player with GetLayerCollide and GetLayerDoorColide.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        bool BlockThePlayer(int direction)
        {
            if (_context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor") != null && _context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor").IsVisible == false) _context.MapLoad.GetLayerDoorCollide = _context.MapLoad.GetLayerCollide;
            else if (_context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretDoor") != null) _context.MapLoad.GetLayerDoorCollide = _context.MapLoad.GetMap.GetLayer<TiledTileLayer>("SecretCollide");
            else _context.MapLoad.GetLayerDoorCollide = _context.MapLoad.GetLayerCollide;
            int _tileWidth = _context.MapLoad.GetLayerCollide.TileWidth;

            switch (GetTheDirectionOfThePlayer())
            {
                case (int)Direction.Up:
                    return (_player.PositionY >= 0 && (_context.MapLoad.GetLayerCollide.GetTile((int)Math.Floor(_player.PositionX / (decimal)_tileWidth) + 1, (int)Math.Round((decimal)_player.PositionY / (decimal)_tileWidth)).Id != _context.MapLoad.IdTileCollide) && (_context.MapLoad.GetLayerDoorCollide.GetTile((int)Math.Floor(_player.PositionX / (decimal)_tileWidth) + 1, (int)Math.Round((decimal)_player.PositionY / (decimal)_tileWidth)).Id != _context.MapLoad.IdTileCollide));
                case (int)Direction.Left:
                    return (_player.PositionX >= 0 && (_context.MapLoad.GetLayerCollide.GetTile((int)Math.Round((decimal)_player.PositionX / _tileWidth), (int)Math.Round((decimal)_player.PositionY / _tileWidth) + 1).Id != _context.MapLoad.IdTileCollide) && (_context.MapLoad.GetLayerDoorCollide.GetTile((int)Math.Round((decimal)_player.PositionX / _tileWidth), (int)Math.Round((decimal)_player.PositionY / _tileWidth) + 1).Id != _context.MapLoad.IdTileCollide));

                case (int)Direction.Bottom:
                    return ((_player.PositionY <= (_context.MapLoad.GetMap.HeightInPixels - 50)) && (_context.MapLoad.GetLayerCollide.GetTile((int)Math.Floor(_player.PositionX / (decimal)_tileWidth) + 1, ((int)Math.Floor(_player.PositionY / (decimal)_tileWidth)) + 2).Id != _context.MapLoad.IdTileCollide) && (_context.MapLoad.GetLayerDoorCollide.GetTile((int)Math.Floor(_player.PositionX / (decimal)_tileWidth) + 1, ((int)Math.Floor(_player.PositionY / (decimal)_tileWidth)) + 2).Id != _context.MapLoad.IdTileCollide));

                case (int)Direction.Right:
                    return ((_player.PositionX <= (_context.MapLoad.GetMap.WidthInPixels)) && (_context.MapLoad.GetLayerCollide.GetTile(((int)Math.Round((decimal)_player.PositionX / _tileWidth)) + 1, ((int)Math.Round((decimal)_player.PositionY / _tileWidth)) + 1).Id != _context.MapLoad.IdTileCollide) && (_context.MapLoad.GetLayerDoorCollide.GetTile(((int)Math.Round((decimal)_player.PositionX / _tileWidth)) + 1, ((int)Math.Round((decimal)_player.PositionY / _tileWidth)) + 1).Id != _context.MapLoad.IdTileCollide));

            }
            return true;
        }

    }
}
