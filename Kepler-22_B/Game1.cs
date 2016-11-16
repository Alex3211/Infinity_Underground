using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Kepler_22_B.Camera;
using MonoGame.Extended;
using Kepler_22_B.Map;
using MonoGame.Extended.Maps.Tiled;
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

        const int windowsWidth = 1280;
        const int windowsHeight = 800;

        Player _player;
        Texture2D _spriteSheetPlayer;

        CameraLoader _cameraLoader;
        Camera2D _camera;
        MapLoader _mapLoader;
        TiledMap _map;
        Debug _debug;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



            _spriteSheetPlayer = Content.Load<Texture2D>("Player/Walking");
            _player = new Player(4, 9, _spriteSheetPlayer);

            _mapLoader = new MapLoader(this, "map");
            _map = _mapLoader.GetMap;
            _cameraLoader = new CameraLoader(this, windowsWidth, windowsHeight);
            _camera = _cameraLoader.GetCamera;
            _debug = new Debug(this);
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
            spriteBatch.Begin();
            // TODO: Add your drawing code here


            _mapLoader.draw(spriteBatch);
            _debug.draw(spriteBatch);

            _player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
