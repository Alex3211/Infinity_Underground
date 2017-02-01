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
    public class SAlex : SpriteSheet
    {
        Texture2D _alex;
        CAlex _alexAPI;

        public SAlex(InfinityUnderground context, CAlex dylan)
        {
            _alexAPI = dylan;

            Context = context;

            SpriteSheetRows = 21;
            SpriteSheetColumns = 13;

            TotalFrames = SpriteSheetColumns * SpriteSheetRows;
        }


        public void LoadContent(ContentManager content)
        {
            _alex = content.Load<Texture2D>(@"Player\Alex");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Width = _alex.Width / SpriteSheetColumns;
            Height = _alex.Height / SpriteSheetRows;

            Rectangle sourceRectangle = new Rectangle(Width * 0, Height * 2, Width, Height);
            Rectangle destinationRectangle = new Rectangle(_alexAPI.PositionX, _alexAPI.PositionY, Width, Height);

            spriteBatch.Draw(_alex, destinationRectangle, sourceRectangle, Color.White);

        }
    }
}
