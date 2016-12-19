using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using InfinityUnderground.API;
using InfinityUnderground.EntitiesUI;
using InfinityUnderground.Camera;
using InfinityUnderground.Map;
using InfinityUnderground;

namespace InfinityUnderground
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public enum GameState
        {
            SURFACE,
            UNDERGROUND
        }

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WindowWidth = 960;
        const int WindowHeight = 540;

        //CreateMonster _monster;
        World _world;
        Player _player;
        CameraLoader _cameraLoader;
        MapLoader _mapLoad;
        List<IEntity> _entities;
        GameState _gameState;
        bool _loadGameState, _drawMiniMap;
        ManageUnderground _manageUnderground;
        WorldControlUI _worldControl;


        /// <summary>
        /// Gets or sets a value indicating whether [draw mini map].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [draw mini map]; otherwise, <c>false</c>.
        /// </value>
        public bool DrawMiniMap { get { return _drawMiniMap;} set { _drawMiniMap = value; } }

        /// <summary>
        /// Gets or sets the manage under ground game.
        /// </summary>
        /// <value>
        /// The manage under ground game.
        /// </value>
        public ManageUnderground ManageUnderGroundGame { get { return _manageUnderground; } set { _manageUnderground = value; } }

        /// <summary>
        /// Load the GameState.
        /// </summary>
        public bool LoadGameState { get { return _loadGameState; } set { _loadGameState = value; } }

        /// <summary>
        /// Get or Set the State of the game.
        /// </summary>
        public GameState GetGameState { get { return _gameState; } set { _gameState = value; } }

        /// <summary>
        /// Gets or sets the entities.
        /// </summary>
        /// <value>
        /// The entities.
        /// </value>
        public List<IEntity> Entities { get { return _entities; } }

        /// <summary>
        /// Gets the camera loader.
        /// </summary>
        /// <value>
        /// The camera loader.
        /// </value>
        public CameraLoader CameraLoader { get { return _cameraLoader; } set { _cameraLoader = value; } }

        /// <summary>
        /// Gets the map load.
        /// </summary>
        /// <value>
        /// The map load.
        /// </value>
        internal MapLoader MapLoad { get { return _mapLoad; } set { _mapLoad = value; } }



        internal WorldControlUI WorldControl { get { return _worldControl; } set { _worldControl = value; } }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        internal Player Player { get { return _player; } set { _player = value; } }

        /// <summary>
        /// Gets the world API.
        /// </summary>
        /// <value>
        /// The world API.
        /// </value>
        internal World WorldAPI { get { return _world; } }

        /// <summary>
        /// Gets the list of map.
        /// </summary>
        /// <value>
        /// The list of map.
        /// </value>
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
            _world = new World();

            _entities = new List<IEntity>();
            _gameState = GameState.SURFACE;
            _loadGameState = true;

            _player = new Player(21, 13, this);
            _manageUnderground = new ManageUnderground(this);
        }

        /// <summary>
        /// Gets or sets the graphics.
        /// </summary>
        /// <value>
        /// The graphics.
        /// </value>
        public GraphicsDeviceManager Graphics { get { return graphics; } }

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


            // Create a new spriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            foreach (var entity in _entities)
            {
                entity.LoadContent(Content);
            }

            if (MapLoad != null && GetGameState == GameState.UNDERGROUND && !_manageUnderground.ListOfRoomLevelUnderground.ContainsKey(WorldAPI.Level.GetRooms.PosCurrentRoom)) ManageUnderGroundGame.AddRoomToTheList(WorldAPI.Level.GetRooms.PosCurrentRoom, MapLoad);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            foreach (var entity in _entities)
            {
                entity.Unload(Content);
            }
            // TODO: Unload any non ContentManager content here
            //Dispose();
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




            SwitchGameState();



            foreach (var entity in _entities)
            {
                entity.Update(gameTime);
            }


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(39, 33, 41));
            spriteBatch.Begin(transformMatrix: _cameraLoader.GetMatrix);


            foreach (var entity in _entities)
            {
                entity.Draw(spriteBatch);
            }

            if (_gameState == GameState.UNDERGROUND)
            {
                _manageUnderground.MiniMap.Draw(spriteBatch, MapLoad.GetMap.WidthInPixels, MapLoad.GetMap.HeightInPixels);
                _drawMiniMap = false;
            }

            spriteBatch.End();
        }



        /// <summary>
        /// Switches the state of the game.
        /// </summary>
        void SwitchGameState()
        {
            if (_loadGameState)
            {
                UnloadContent();
                Entities.Clear();
                MapLoad = null;

                switch (_gameState)
                {
                    case GameState.UNDERGROUND:
                        if (!ManageUnderGroundGame.ListOfRoomLevelUnderground.ContainsKey(WorldAPI.Level.GetRooms.PosCurrentRoom))
                        {
                            Entities.Add(new LoadUnderground(this));
                            Entities.Add(new MapLoader(this));
                            Entities.Add(new CreateMonster(this));
                            Entities.Add(new WorldControlUI(this));
                        }
                        else
                        {
                            Entities.Add(ManageUnderGroundGame.ListOfRoomLevelUnderground[WorldAPI.Level.GetRooms.PosCurrentRoom]);
                            MapLoad = ManageUnderGroundGame.ListOfRoomLevelUnderground[WorldAPI.Level.GetRooms.PosCurrentRoom];
                        }
                        _manageUnderground.MiniMap.ChangeRoom = true;
                        break;

                    case GameState.SURFACE:
                        Entities.Add(new LoadSurface(this));
                        Entities.Add(new MapLoader(this));
                        Entities.Add(new WorldControlUI(this));
                        break;
                }
                
                LoadContent();
                CameraLoader.GetCamera.LookAt(new Vector2(WorldAPI.Players[0].PositionX, WorldAPI.Players[0].PositionY));
                _loadGameState = false;
            }
        }

    }
}
