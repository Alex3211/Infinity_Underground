using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using InfinityUnderground.API;
using InfinityUnderground.EntitiesUI;
using InfinityUnderground.Map;
using InfinityUnderground;
using System.Linq;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;

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

        Camera2D _camera;
        BoxingViewportAdapter _viewportAdapter;
        float _zoom;

        World _world;
        Player _player;
        MapLoader _mapLoad;
        List<IEntity> _entities;
        GameState _gameState;
        bool _loadGameState, _drawMiniMap;
        ManageUnderground _manageUnderground;
        WorldControlUI _worldControl;
        Dragon _dragon;
        CreateMonster _createMonster;


        /// <summary>
        /// Gets or sets the zoom.
        /// </summary>
        /// <value>
        /// The zoom.
        /// </value>
        internal float Zoom { get { return _zoom; } }

        /// <summary>
        /// Gets the get camera.
        /// </summary>
        /// <value>
        /// The get camera.
        /// </value>
        public Camera2D GetCamera { get { return _camera; } }

        /// <summary>
        /// Gets the get matrix.
        /// </summary>
        /// <value>
        /// The get matrix.
        /// </value>
        public Matrix GetMatrix { get { return _camera.GetViewMatrix(); } }


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
        /// Gets the map load.
        /// </summary>
        /// <value>
        /// The map load.
        /// </value>
        internal MapLoader MapLoad { get { return _mapLoad; } set { _mapLoad = value; } }

        /// <summary>
        /// Gets or sets the get dragon.
        /// </summary>
        /// <value>
        /// The get dragon.
        /// </value>
        internal Dragon GetDragon { get { return _dragon; } set { _dragon = value; } }

        /// <summary>
        /// Gets or sets the get create monster.
        /// </summary>
        /// <value>
        /// The get create monster.
        /// </value>
        internal CreateMonster GetCreateMonster { get { return _createMonster; } set { _createMonster = value; } }

        /// <summary>
        /// Gets or sets the world control.
        /// </summary>
        /// <value>
        /// The world control.
        /// </value>
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

            _world = new World();

            _entities = new List<IEntity>();
            _gameState = GameState.SURFACE;
            _loadGameState = true;

            _player = new Player(21, 13, this);
            _manageUnderground = new ManageUnderground(this);

            _zoom = 0.1f;
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
            _viewportAdapter = new BoxingViewportAdapter(Window, GraphicsDevice, WindowWidth, WindowHeight);
            _camera = new Camera2D(_viewportAdapter);
            _camera.LookAt(new Vector2(Player.CTPlayer.PositionX + 30, Player.CTPlayer.PositionY + 40));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {


            // Create a new spriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

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
            spriteBatch.Begin(transformMatrix: GetMatrix);

            foreach (var entity in _entities)
            {
                entity.Draw(spriteBatch);
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

                foreach (var entity in _entities)
                {
                    entity.Unload(Content);
                }

                Entities.Clear();
                MapLoad = null;

                switch (_gameState)
                {
                    case GameState.UNDERGROUND:
                        var rooms = from room in ManageUnderGroundGame.ListOfRoomLevelUnderground where room.Position == WorldAPI.Level.GetRooms.PosCurrentRoom select room;
                        if (rooms.Count() == 0)
                        {
                            Entities.Add(new LoadUnderground(this));
                            ManageUnderGroundGame.AddRoomToTheList();
                        }
                        else
                        {
                            foreach (SaveMap room in rooms)
                            {
                                Entities.Add(new LoadUnderground(this, room.TypeOfRoom, room.NumberOfRoom));
                                break;
                            }
                        }
                        Entities.Add(new MapLoader(this));
                        Entities.Add(new CreateMonster(this));
                        Entities.Add(new WorldControlUI(this));

                        _manageUnderground.MiniMap.ChangeRoom = true;

                        break;

                    case GameState.SURFACE:
                        Entities.Add(new LoadSurface(this));
                        Entities.Add(new WorldControlUI(this));
                        Entities.Add(new MapLoader(this));
                        break;
                }

                foreach (var entity in _entities)
                {
                    entity.LoadContent(Content);
                }

                GetCamera.LookAt(new Vector2(WorldAPI.Players[0].PositionX, WorldAPI.Players[0].PositionY));
                _loadGameState = false;
            }
        }

    }
}
