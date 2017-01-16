using InfinityUndergroundReload.API;
using InfinityUndergroundReload.Interface;
using InfinityUndergroundReload.Map;
using InfinityUndergroundReload.SpriteSheet;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System.Collections.Generic;
using System.Threading;

namespace InfinityUndergroundReload
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class InfinityUnderground : Game
    {
        const int WindowWidth = 960;
        const int WindowHeight = 540;
        float _zoom;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera2D _camera;
        BoxingViewportAdapter _viewportAdapter;

        World _worldAPI;
        SPlayer _player;
        MapLoader _map;
        Door _door;
        DataSave _dataSave;
        //List<IEntity> _entities;



        public int GetWindowsHeight { get { return WindowHeight; } }
        public int GetWindowWidth { get { return WindowWidth; } }



        /// <summary>
        /// Gets the zoom.
        /// </summary>
        /// <value>
        /// The zoom.
        /// </value>
        public float Zoom
        {
            get
            {
                return _zoom;
            }
        }


        /// <summary>
        /// Gets the world API.
        /// </summary>
        /// <value>
        /// The world API.
        /// </value>
        public World WorldAPI
        {
            get
            {
                return _worldAPI;
            }
        }

        /// <summary>
        /// Gets the camera.
        /// </summary>
        /// <value>
        /// The camera.
        /// </value>
        public Camera2D Camera
        {
            get
            {
                return _camera;
            }
        }

        /// <summary>
        /// Gets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public MapLoader Map
        {
            get
            {
                return _map;
            }
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        public SPlayer Player
        {
            get
            {
                return _player;
            }
        }


        public InfinityUnderground()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            _zoom = 0.1f;

            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.PreferredBackBufferWidth = WindowWidth;

            _worldAPI = new World();
            _map = new MapLoader(this);
            _player = new SPlayer(this, 21, 13);
            
            _worldAPI.CreateDoor();
            _dataSave = new DataSave(this);
            if (_dataSave.IsExistSave)
            {
                _dataSave.LoadValuesFromTheFile();
                _dataSave.SetValuesInThePlayer();
            }
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
            _viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, WindowWidth, WindowHeight);
            _camera = new Camera2D(_viewportAdapter);
            _camera.LookAt(new Vector2(_player.PlayerAPI.PositionX + 30, _player.PlayerAPI.PositionY + 40));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            _map.LoadContent(Content);

            base.LoadContent();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            _map.Unload(Content);
            spriteBatch.Dispose();
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                _dataSave.LoadValuesOfThePlayerInTheClass();
                _dataSave.WriteValuesInTheFile();
                Exit();
            }
            // TODO: Add your update logic here

            _map.Update(gameTime);
            if (!Map.GetStateOfEnigm)
            {
                _player.Update(gameTime);
                _door = _worldAPI.PlayerTakeDoor();
                if (_door != null)
                {
                    _worldAPI.ActionWithDoor(_door);
                    UnloadContent();
                    Map.GetStateTransition = true;
                    LoadContent();
                    if (WorldAPI.GetLevel.GetRoom.RoomCharateristcs.NameOfMap == "SecretRoom") Map.GetStateSecretDoor = false;
                    _camera.LookAt(_player.PlayerAPI.Position);
                }
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(39, 33, 41));

            // TODO: Add your drawing code here

            spriteBatch.Begin(transformMatrix: _camera.GetViewMatrix());

            _map.Draw(spriteBatch);
            if (Map.GetStateTransition)
            {
                Map.MonitorTransitionOn(spriteBatch);
                Map.MonitorTransitionOff(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
