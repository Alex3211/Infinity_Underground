using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using InfinityUnderground.API.Characteres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.EntitiesUI
{
    class Spider : Spritesheet, IEntity
    {

        List<Action> _listOfAction;

        public Spider(int spriteSheetRows, int spriteSheetColumns, Game1 context, CTSpiderMutant spider)
        {
            Context = context;

            SpriteSheetColumns = spriteSheetColumns;
            SpriteSheetRows = spriteSheetRows;

            _listOfAction = new List<Action>();

            _listOfAction.Add(new Action((int)IDActionSpider.WalkBottom, 6));
            _listOfAction.Add(new Action((int)IDActionSpider.WalkLeft, 6));
            _listOfAction.Add(new Action((int)IDActionSpider.WalkTop, 6));
            _listOfAction.Add(new Action((int)IDActionSpider.WalkRight, 6));

        }


        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {

        }


        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {

        }


        /// <summary>
        /// Draws the specified sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch.</param>
        public void Draw(SpriteBatch spriteBatch)
        {

        }

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        /// <param name="content"></param>
        public void Unload(ContentManager content)
        {

        }

    }
}
