using Kepler_22_B.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Kepler_22_B
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int _windowWidth = 1280;
        const int _windowHeight = 800;

        int speed = 5;

        ETPlayer _player;
        Texture2D _playerWalk;

        Vector2 _position = new Vector2(_windowWidth / 2, _windowHeight / 2);
        KeyboardState _state;

        int _direction = 2;


        internal int WindowWidth { get { return _windowWidth; } }
        internal int WindowHeight { get { return _windowHeight; } }
        /*internal int PlayerPositionX { get { return (int)_position.X; } set { _position.X = value; } }
        internal int PlayerPositionY { get { return (int)_position.Y; } set { _position.Y = value; } }
        */
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = _windowWidth;
            graphics.PreferredBackBufferHeight = _windowHeight;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            _playerWalk = Content.Load<Texture2D>("Entities/Player/Walking");
            _player = new ETPlayer(_playerWalk, 4, 9);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            bool _isMoving = true;
            GraphicsDevice.Clear(Color.Black);
          
            _state = Keyboard.GetState();
            _position = _player.MovingObject(ref _direction, ref _isMoving, _state, _position);
            _player.Draw(spriteBatch, new Vector2(_position.X, _position.Y), _direction, _isMoving);

            base.Draw(gameTime);
        }




    }
}
