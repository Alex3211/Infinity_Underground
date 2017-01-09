using InfinityUndergroundReload.API;
using InfinityUndergroundReload.Interface;
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
        Random _random;
        List<SpriteSheet> _listOfMonster;
        KeyboardState _keyboard;
        FightsUI _fights;

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

        /// <summary>
        /// Gets the random.
        /// </summary>
        /// <value>
        /// The random.
        /// </value>
        public Random Random
        {
            get
            {
                return _random;
            }
        }

        public FightsUI Fight
        {
            get
            {
                return _fights;
            }
        }

        public InfinityUnderground()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _zoom = 0.1f;

            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.PreferredBackBufferWidth = WindowWidth;

            _random = new Random();
            _worldAPI = new World();
            _map = new MapLoader(this);
            _player = new SPlayer(this, 21, 13);
            _listOfMonster = new List<SpriteSheet>();
            
            _worldAPI.CreateDoor();
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
                foreach (SDragon monster in ListOfMonsterUI)
                {
                    monster.LoadContent(Content);
                }
            }


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

            //if (Dragon != null) Dragon.Dispose();
            //if (Flame != null) Flame.Dispose();

            foreach (SpriteSheet monster in _listOfMonster)
            {
                monster.Unload(Content);
            }

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
                Exit();
            _keyboard = Keyboard.GetState();
            // TODO: Add your update logic here
            

            _map.Update(gameTime);
            _player.Update(gameTime);

            ActionWithDoorUI();
            //CreateFights();

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

            spriteBatch.End();

            base.Draw(gameTime);
        }



        /// <summary>
        /// Actions the with door UI.
        /// </summary>
        public void ActionWithDoorUI()
        {
            bool _fightsOn = false;
            bool _fightsOff = false;
            SpriteSheet _monsterFight = null;

            if (_keyboard.IsKeyDown(Keys.Enter) && _fights != null)
            {
                _fightsOff = true;
            }

            foreach (SpriteSheet monster in ListOfMonsterUI)
            {
                if (_keyboard.IsKeyDown(Keys.E) && Player.PlayerAPI.Position.X >= ((int)monster.Monster.Position.X - monster.Monster.CharacterType.HitBox) && Player.PlayerAPI.Position.Y <= ((int)monster.Monster.Position.Y + monster.Monster.CharacterType.HitBox) && Player.PlayerAPI.Position.X <= ((int)monster.Monster.Position.X + monster.Monster.CharacterType.HitBox) && Player.PlayerAPI.Position.Y <= ((int)monster.Monster.Position.Y + monster.Monster.CharacterType.HitBox) && _fights == null)
                {
                    _fightsOn = true;
                    _monsterFight = monster;
                }
            }

            _door = _worldAPI.PlayerTakeDoor();
            if (_door != null || _fightsOn || _fightsOff)
            {
                _listOfMonster.Clear();

                if (_fightsOff)
                {
                    WorldAPI.ExitFights();
                    _fights = null;
                    _camera.LookAt(_player.PlayerAPI.Position);
                    _camera.ZoomIn(0.5f);
                }
                if (!_fightsOn && _door != null)
                {
                    _worldAPI.ActionWithDoor(_door);
                    _camera.LookAt(_player.PlayerAPI.Position);
                }
                else if (_fightsOn)
                {
                    _fights = new FightsUI(this, _monsterFight.Monster);
                    _camera.LookAt(new Vector2(960, 540));
                    _camera.ZoomOut(0.5f);
                }

                

                UnloadContent();
                Thread.Sleep(500);
                if (!_fightsOn && WorldAPI.CurrentLevel != 0 && (WorldAPI.GetLevel.GetRoom.RoomCharateristcs.NameOfMap != "RoomIn" && WorldAPI.GetLevel.GetRoom.RoomCharateristcs.NameOfMap != "RoomOut")) CreateMonster();
                else if (_fightsOn)
                {
                    switch (_monsterFight.Monster.TypeOfMonster)
                    {
                        case "Dragon":
                            _listOfMonster.Add(new SDragon(4, 4, this, (CDragon)_monsterFight.Monster));
                            break;
                    }
                }

                LoadContent();
                Thread.Sleep(500);
                if (!_fightsOn && !_fightsOff)
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
                _fightsOn = false;
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
                }
            }
        }

    }

}
