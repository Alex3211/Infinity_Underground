using InfinityUndergroundReload;
using InfinityUndergroundReload.API;
using InfinityUndergroundReload.API.Characters;
using InfinityUndergroundReload.CharactersUI;
using InfinityUndergroundReload.Spell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload
{
    public enum FightsState
    {
        Enter,
        InFights,
        Exit,
        Close
    }

    public class FightsUI
    {
        InfinityUnderground _context;
        Fights _fights;
        SpriteSheet _monster;
        int _timeMaxForAnimation;
        int _timeForAnimation;
        CharacterTurn _turn;
        CharacterTurn _lastTurn;
        KeyboardState _keyboard;
        List<CAttacks> _attacks;
        CAttacks _currentAttack;
        SpriteFont _police;
        RectangleSelectAttack _playerAttack;
        SelectedAttack _selectedAttack;
        int _timeBeforeLeave;
        int _timeLeave;

        public FightsUI(InfinityUnderground context)
        {
            _context = context;
            _timeMaxForAnimation = 5000;
            _turn = CharacterTurn.NoOne;
            _lastTurn = CharacterTurn.NoOne;
            _playerAttack = new RectangleSelectAttack();
            _timeBeforeLeave = 3000;
        }

        public SpriteSheet MonsterFights
        {
            get
            {
                return _monster;
            }
        }

        /// <summary>
        /// Gets the fights.
        /// </summary>
        /// <value>
        /// The fights.
        /// </value>
        public Fights TheFights
        {
            get
            {
                return _fights;
            }
        }


        public CharacterTurn Turn
        {
            get
            {
                return _turn;
            }
        }

        public CAttacks CurrentAttack
        {
            get
            {
                return _currentAttack;
            }
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            _playerAttack.LoadContent(content);
        }


        /// <summary>
        /// Updates this instance.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            _keyboard = Keyboard.GetState();


            if (_context.LoadOrUnloadFights == FightsState.InFights)
            {

                _timeForAnimation += gameTime.ElapsedGameTime.Milliseconds;


                if (_timeForAnimation >= _timeMaxForAnimation)
                {

                    if (_turn != CharacterTurn.Player)
                    {
                        _turn = _fights.ChoiceTurn();
                        if (_turn != _lastTurn)
                        {
                            _currentAttack = null;
                        }
                        _lastTurn = _turn;
                    }
                    if (_turn != CharacterTurn.NoOne)
                    {
                        if (_turn == CharacterTurn.Monster)
                        {

                            _currentAttack = _fights.GetAttack(_turn);



                            _fights.GiveDamageWithAttack(_currentAttack, _turn);

                            _timeForAnimation = 0;
                        }
                        else if (_turn == CharacterTurn.Player)
                        {
                            _turn = CharacterTurn.Player;

                            if (_keyboard.IsKeyDown(Keys.Left))
                            {
                                _selectedAttack = SelectedAttack.First;

                            }
                            else if (_keyboard.IsKeyDown(Keys.Right))
                            {
                                _selectedAttack = SelectedAttack.Second;
                            }


                            if (_keyboard.IsKeyDown(Keys.I))
                            {
                                _timeForAnimation = 0;
                                _turn = CharacterTurn.NoOne;

                                switch(_selectedAttack)
                                {
                                    case SelectedAttack.First:
                                        _currentAttack = _fights.GetAttack(_turn, 0);


                                        _fights.GiveDamageWithAttack(_currentAttack, _turn);
                                        break;

                                    case SelectedAttack.Second:
                                        _context.Player.PlayerAPI.Shield = true;
                                        break;


                                }

                                

                            }
                        }
                    }  
                }

            }




            foreach (SpriteSheet monster in _context.ListOfMonsterUI)
            {
                if (_keyboard.IsKeyDown(Keys.E) 
                    &&
                    _context.Player.PlayerAPI.Position.X >= ((int)monster.Monster.Position.X - monster.Monster.CharacterType.HitBox) 
                    &&
                    _context.Player.PlayerAPI.Position.Y >= ((int)monster.Monster.Position.Y - monster.Monster.CharacterType.HitBox) 
                    && 
                    _context.Player.PlayerAPI.Position.X <= ((int)monster.Monster.Position.X + monster.Monster.CharacterType.HitBox) 
                    && 
                    _context.Player.PlayerAPI.Position.Y <= ((int)monster.Monster.Position.Y + monster.Monster.CharacterType.HitBox) 
                    && 
                    _context.LoadOrUnloadFights == FightsState.Close && !monster.Monster.IsDead)
                {
                    _context.LoadOrUnloadFights = FightsState.Enter;
                    _monster = monster;
                    _fights = _context.WorldAPI.CreateFight(_monster.Monster);
                    _currentAttack = null;
                    break;
                }
            }

            if (_context.LoadOrUnloadFights != FightsState.Close && (_keyboard.IsKeyDown(Keys.Enter) || _context.Player.PlayerAPI.CharacterType.LifePoint <= 0 || _monster.Monster.CharacterType.LifePoint <= 0))
            {
                _timeLeave += _context.GetGameTime.ElapsedGameTime.Milliseconds;
                if (_timeLeave >= _timeBeforeLeave)
                {
                    _context.LoadOrUnloadFights = FightsState.Exit;
                    _timeLeave = 0;
                }
            }

        }
        

        /// <summary>
        /// Unloads the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void Unload(ContentManager content)
        {
            _playerAttack.Unload(content);
            _selectedAttack = SelectedAttack.None;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (_turn == CharacterTurn.Player)
            {

                _playerAttack.Draw(spriteBatch, _context.GraphicsDevice, _selectedAttack);
            }
        }


    }
}
