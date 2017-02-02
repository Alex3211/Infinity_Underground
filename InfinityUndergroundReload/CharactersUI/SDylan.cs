using InfinityUndergroundReload.API.Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUndergroundReload.CharactersUI
{
    public class SDylan : SpriteSheet
    {
        Texture2D _dylan;
        CDylan _dylanAPI;

        public SDylan(InfinityUnderground context, CDylan dylan)
        {
            _dylanAPI = dylan;

            Context = context;

            SpriteSheetRows = 21;
            SpriteSheetColumns = 13;

            TotalFrames = SpriteSheetColumns * SpriteSheetRows;
        }


        public void LoadContent(ContentManager content)
        {
            _dylan = content.Load<Texture2D>(@"Player\Dylan");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Width = _dylan.Width / SpriteSheetColumns;
            Height = _dylan.Height / SpriteSheetRows;

            Rectangle sourceRectangle = new Rectangle(Width * 0, Height * 2, Width, Height);
            Rectangle destinationRectangle = new Rectangle(_dylanAPI.PositionX, _dylanAPI.PositionY, Width, Height);

            spriteBatch.Draw(_dylan, destinationRectangle, sourceRectangle, Color.White);

        }

    }
}
