using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InfinityUnderground.UserInterface
{
    public class KeyboardHandler
    {
        Game1 _context;
        KeyboardState _keyboardState;
        string _myStringBuilder;
        bool _caps;
        Keys[] _pressedKeys;
        private Keys[] _lastPressedKeys = new Keys[1];

        public string GetString { get { return _myStringBuilder; } set { _myStringBuilder = value; } }


        public KeyboardHandler(Game1 Context)
        {
            _context = Context;
            _myStringBuilder = string.Empty;
        }

        public void GetKeys()
        {
            _keyboardState = Keyboard.GetState();
            _pressedKeys = _keyboardState.GetPressedKeys();
            foreach (Keys key in _lastPressedKeys)
            {
                if (!_pressedKeys.Contains(key))
                    OnKeyUp(key);
            }
            foreach (Keys key in _pressedKeys)
            {
                if (!_lastPressedKeys.Contains(key))
                    OnKeyDown(key);
            }
            _lastPressedKeys = _pressedKeys;
        }

        private void OnKeyDown(Keys key)
        {
            if (key == Keys.A || key == Keys.Z || key == Keys.E || key == Keys.R || key == Keys.T || key == Keys.Y || key == Keys.U || key == Keys.I || key == Keys.O || key == Keys.P || key == Keys.M || key == Keys.L || key == Keys.K || key == Keys.J || key == Keys.H || key == Keys.G || key == Keys.F || key == Keys.D || key == Keys.S || key == Keys.Q || key == Keys.W || key == Keys.X || key == Keys.C || key == Keys.V || key == Keys.B || key == Keys.N || key == Keys.A || key == Keys.Space || key == Keys.Back || key == Keys.LeftShift || key == Keys.RightShift || key == Keys.NumPad0 || key == Keys.NumPad1 || key == Keys.NumPad2 || key == Keys.NumPad3 || key == Keys.NumPad4 || key == Keys.NumPad5 || key == Keys.NumPad6 || key == Keys.NumPad7 || key == Keys.NumPad8 || key == Keys.NumPad9)
            {
                if(key == Keys.NumPad0 || key == Keys.NumPad1 || key == Keys.NumPad2 || key == Keys.NumPad3 || key == Keys.NumPad4 || key == Keys.NumPad5 || key == Keys.NumPad6 || key == Keys.NumPad7 || key == Keys.NumPad8 || key == Keys.NumPad9)
                {
                    if (key == Keys.NumPad0) _myStringBuilder += "0";
                    else if (key == Keys.NumPad1) _myStringBuilder += "1";
                    else if (key == Keys.NumPad2) _myStringBuilder += "2";
                    else if (key == Keys.NumPad3) _myStringBuilder += "3";
                    else if (key == Keys.NumPad4) _myStringBuilder += "4";
                    else if (key == Keys.NumPad5) _myStringBuilder += "5";
                    else if (key == Keys.NumPad6) _myStringBuilder += "6";
                    else if (key == Keys.NumPad7) _myStringBuilder += "7";
                    else if (key == Keys.NumPad8) _myStringBuilder += "8";
                    else if (key == Keys.NumPad9) _myStringBuilder += "9";
                }
                else if (key == Keys.Back)
                {
                    if(_myStringBuilder.Length > 0) _myStringBuilder = _myStringBuilder.Remove(_myStringBuilder.Length - 1);
                }
                else if (key == Keys.LeftShift || key == Keys.RightShift)
                {
                    _caps = true;
                }
                else if (!_caps && _myStringBuilder.Length < 16)
                {
                    if (key == Keys.Space) _myStringBuilder += " ";
                    else _myStringBuilder += key.ToString().ToLower();
                }
                else if (_myStringBuilder.Length < 50)
                {
                    _myStringBuilder += key.ToString();
                }
            }
        }

        private void OnKeyUp(Keys key)
        {
            if (key == Keys.LeftShift || key == Keys.RightShift)
                _caps = false;
        }
    }
}
