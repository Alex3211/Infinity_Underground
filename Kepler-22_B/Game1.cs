using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Kepler_22_B.Camera;
using Kepler_22_B.Map;
using Kepler_22_B.DebugGame;
using Kepler_22_B.EntitiesUI;

namespace Kepler_22_B
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WindowWidth = 1920;
        const int WindowHeight = 1080;

        Player _player;
        CameraLoader _cameraLoader;
        MapLoader _mapLoad;
        Debug _debug;

        /// <summary>
        /// Gets the camera loader.
        /// </summary>
        /// <value>
        /// The camera loader.
        /// </value>
        internal CameraLoader CameraLoader { get { return _cameraLoader; } }

        /// <summary>
        /// Gets the map load.
        /// </summary>
        /// <value>
        /// The map load.
        /// </value>
        internal MapLoader MapLoad { get { return _mapLoad; } }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        internal Player Player { get { return _player; } }


        /// <summary>
        /// Initializes a new instance of the <see cref="Game1"/> class.
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.PreferredBackBufferWidth = WindowWidth;
            _cameraLoader = new CameraLoader(this);
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
            _cameraLoader.ViewportAdapterCamera(WindowWidth, WindowHeight);

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            _mapLoad = new MapLoader(this, "map");

            
            _debug = new Debug(this, _cameraLoader);


            _player = new Player(4, 9, this);


            // TODO: use this.Content to load your game content here
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
            
            // TODO: Add your update logic here
            _debug.Update(gameTime);



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(transformMatrix: _cameraLoader.GetMatrix);

            _mapLoad.draw(spriteBatch);

            _debug.draw(spriteBatch);

            _player.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
