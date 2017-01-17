using InfinityUndergroundReload.CharactersUI;
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
    class Shield : SpriteSheet
    {
        SPlayer _player;

        public Shield(SPlayer player)
        {
            _player = player;
            NameSpell = "Shield";
        }

        public override void LoadContent(ContentManager content)
        {
            Spritesheet = content.Load<Texture2D>("Effect/Shield");
        }
        public override void Unload(ContentManager content)
        {
            base.Unload(content);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle = new Rectangle(0, 0, Spritesheet.Width, Spritesheet.Height);
            Rectangle destinationRectangle = new Rectangle((int)_player.PlayerAPI.Position.X - 30, (int)_player.PlayerAPI.Position.Y - 10, Spritesheet.Width/2, Spritesheet.Height/2);

            spriteBatch.Draw(Spritesheet, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
