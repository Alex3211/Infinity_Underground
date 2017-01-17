﻿using InfinityUndergroundReload.CharactersUI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.Spell
{
    class RedSlash : SpriteSheet
    {
        SPlayer _player;
        Vector2 _position;
        int _reload;
        int _time;

        public RedSlash(SPlayer player)
        {
            _player = player;
            NameSpell = "RedSlash";
            _reload = 250;
        }

        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Effect/RedSlash");
        }
        public override void Unload(ContentManager content)
        {
            base.Unload(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (_position == new Vector2(0, 0))
            {
                _position = _player.PlayerAPI.Position;
            }

            _time += _player.Context.GetGameTime.ElapsedGameTime.Milliseconds;


            Rectangle sourceRectangle = new Rectangle(0, 0, Spritesheet.Width, Spritesheet.Height);
            Rectangle destinationRectangle = new Rectangle((int)_position.X, (int)_position.Y, Spritesheet.Width, Spritesheet.Height);

            spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);

            _position.Y--;
            _position.X = _position.X + 50;

            if (_time >= _reload)
            {
                _position = _player.PlayerAPI.Position;
                _time = 0;
            }

        }
    }
}
