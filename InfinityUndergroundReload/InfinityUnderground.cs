using InfinityUndergroundReload.API;
using InfinityUndergroundReload.Map;
using InfinityUndergroundReload.CharactersUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using System;
using System.Collections.Generic;
using System.Threading;
using InfinityUndergroundReload.API.Characters;
using Microsoft.Xna.Framework.Content;
using MonoGame.Extended.Maps.Tiled;
using InfinityUndergroundReload.Interface;

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
        List<SpriteSheet> _listOfMonster;
        FightsUI _fights;
        int _timeForTakeNextDoor;
        int _timeMaxForTakeNextDoor;

        FightsState _fightState;

        /// <summary>
        /// Gets the game time.
        /// </summary>
        /// <value>
        /// The game time.
        /// </value>
        public GameTime GetGameTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the height of the get windows.
        /// </summary>
        /// <value>
        /// The height of the get windows.
        /// </value>
        public int GetWindowsHeight
        {
            get
            {
                return WindowHeight;
            }
        }

        /// <summary>
        /// Gets the width of the get window.
        /// </summary>
        /// <value>
        /// The width of the get window.
        /// </value>
        public int GetWindowWidth
        {
            get
            {
                return WindowWidth;
            }
        }

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
        /// Get the list of Monster.
        /// </summary>
        public List<SpriteSheet> ListOfMonsterUI
        {
            get
            {
                return _listOfMonster;
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

        public FightsUI Fights
        {
            get
            {
                return _fights;
            }
        }

        public FightsState LoadOrUnloadFights
        {
            get
            {
                return _fightState;
            }

            set
            {
                _fightState = value;
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
            _listOfMonster = new List<SpriteSheet>();
            _fights = new FightsUI(this);
            
            _worldAPI.CreateDoor();
            _dataSave = new DataSave(this);
            if (_dataSave.IsExistSave)
            {
                _dataSave.LoadValuesFromTheFile();
                _dataSave.SetValuesInThePlayer();
            }
            _fightState = FightsState.Close;
            _timeMaxForTakeNextDoor = 1000;
            _timeForTakeNextDoor = 0;
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
            //Content = new ContentManager(Content.ServiceProvider, "Content");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);

            _map.LoadContent(Content);


            if (ListOfMonsterUI.Count != 0)
            {
                foreach (SpriteSheet monster in ListOfMonsterUI)
                {
                    monster.LoadContent(Content);
                }
            }

            if (LoadOrUnloadFights == FightsState.Enter || LoadOrUnloadFights == FightsState.InFights) _fights.LoadContent(Content);


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

            foreach (SpriteSheet monster in _listOfMonster)
            {
                monster.Unload(Content);
            }

            _fights.Unload(Content);

            _listOfMonster.Clear();
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
            GetGameTime = gameTime;

            _player.Update(gameTime);
            _map.Update(gameTime);

            ActionChangeEnvironment(gameTime);
            _fights.Update(gameTime);

            foreach (SpriteSheet monster in ListOfMonsterUI)
            {
                monster.Update(gameTime);
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

            _fights.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }



        /// <summary>
        /// Actions the with door UI.
        /// </summary>
        public void ActionChangeEnvironment(GameTime gameTime)
        {
            _timeForTakeNextDoor += gameTime.ElapsedGameTime.Milliseconds;


            _door = _worldAPI.PlayerTakeDoor();

            if ((_door != null || LoadOrUnloadFights != FightsState.Close) && LoadOrUnloadFights != FightsState.InFights && _timeForTakeNextDoor >= _timeMaxForTakeNextDoor)
            {
                _timeForTakeNextDoor = 0;
                switch(LoadOrUnloadFights)
                {
                    case FightsState.Close:
                        _worldAPI.ActionWithDoor(_door);
                        _camera.LookAt(_player.PlayerAPI.Position);
                        break;

                    case FightsState.Enter:
                        _camera.LookAt(new Vector2(960, 500));
                        _camera.ZoomOut(0.5f);
                        LoadOrUnloadFights = FightsState.InFights;
                        break;

                    case FightsState.Exit:
                        WorldAPI.ExitFights();
                        _camera.LookAt(_player.PlayerAPI.Position);
                        _camera.ZoomIn(0.5f);
                        break;
                }



                UnloadContent();
                Thread.Sleep(500);
                _listOfMonster.Clear();


                switch(LoadOrUnloadFights)
                {
                    case FightsState.InFights:
                        switch (_fights.MonsterFights.Monster.TypeOfMonster)
                        {
                            case "Dragon":
                                _listOfMonster.Add(new SDragon(4, 4, this, (CDragon)_fights.MonsterFights.Monster));
                                break;

                            case "Curiosity4":
                                _listOfMonster.Add(new SCuriosity4(4, 3, this, (CCuriosity4)_fights.MonsterFights.Monster));
                                break;
                        }
                        break;

                    default:
                        if (WorldAPI.CurrentLevel != 0 && (WorldAPI.GetLevel.GetRoom.RoomCharateristcs.NameOfMap != "RoomIn" && WorldAPI.GetLevel.GetRoom.RoomCharateristcs.NameOfMap != "RoomOut"))
                        {
                            CreateMonster();
                        }
                        break;
                }

                LoadContent();
                Thread.Sleep(500);



                if (LoadOrUnloadFights == FightsState.Close)
                {
                    
                    foreach (SpriteSheet monster in ListOfMonsterUI)
                    {
                        monster.SetPosition();
                    }

                    if (WorldAPI.GetLevel.GetRoom.RoomCharateristcs.NameOfMap == "SecretRoom")
                    {
                        Map.GetStateSecretDoor = false;
                    }
                }
                else if (LoadOrUnloadFights == FightsState.Exit)
                {
                    LoadOrUnloadFights = FightsState.Close;
                }



            }

        }

        /// <summary>
        /// Creates the monster.
        /// </summary>
        void CreateMonster()
        {

            foreach (CNPC monster in WorldAPI.ListOfMonster)
            {

                switch (monster.TypeOfMonster)
                {
                    case "Dragon":
                        _listOfMonster.Add(new SDragon(4, 4, this, (CDragon)monster));
                        break;

                    case "Curiosity4":
                        _listOfMonster.Add(new SCuriosity4(4, 3, this, (CCuriosity4)monster));
                        break;
                }
            }
        }

    }

}
