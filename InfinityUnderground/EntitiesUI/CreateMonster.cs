﻿using InfinityUnderground.API.Characteres;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinityUnderground.EntitiesUI
{
    class CreateMonster : IEntity
    {

        List<Spritesheet> _listOfMob;
        Game1 _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateMonster"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public CreateMonster(Game1 context)
        {
            _listOfMob = new List<Spritesheet>();
            _context = context;
        }


        /// <summary>
        /// Gets or sets the list of mob.
        /// </summary>
        /// <value>
        /// The list of mob.
        /// </value>
        public List<Spritesheet> ListOfMob { get { return _listOfMob; } }


        /// <summary>
        /// Unloads this instance.
        /// </summary>
        /// <param name="content"></param>
        public void Unload(ContentManager content)
        {
            foreach(Spritesheet monster in _listOfMob)
            {
                monster.SpriteSheet.Dispose();
            }
        }

        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        public void LoadContent(ContentManager content)
        {
            _context.WorldAPI.Level.GetRooms.CreateMonster();
            foreach (CTNPC monster in _context.WorldAPI.Level.GetRooms.ListOfNPC)
            {
                switch(monster.IdMonster)
                {
                    case CTIDMonster.Bat:
                        _listOfMob.Add(new Bat(4, 4, _context, (CTBat)monster));
                        break;

                    case CTIDMonster.Foreman:
                        _listOfMob.Add(new Bat(4, 4, _context, (CTBat)monster));
                        break;

                    case CTIDMonster.Golem:
                        _listOfMob.Add(new Bat(4, 4, _context, (CTBat)monster));
                        break;

                    case CTIDMonster.Minor:
                        _listOfMob.Add(new Bat(4, 4, _context, (CTBat)monster));
                        break;

                    case CTIDMonster.QueenSpider:
                        _listOfMob.Add(new Bat(4, 4, _context, (CTBat)monster));
                        break;

                    case CTIDMonster.SpiderMutant:
                        _listOfMob.Add(new Bat(4, 4, _context, (CTBat)monster));
                        break;

                    case CTIDMonster.Worm:
                        _listOfMob.Add(new Bat(4, 4, _context, (CTBat)monster));
                        break;
                }
            }

            foreach(Bat monster in _listOfMob)
            {
                monster.LoadContent(content);
            }

        }

        /// <summary>
        /// Draws the specified spritebatch.
        /// </summary>
        /// <param name="spritebatch">The spritebatch.</param>
        public void Draw(SpriteBatch spritebatch)
        {
            foreach(Bat monster in _listOfMob)
            {
                monster.Draw(spritebatch);
            }
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        public void Update(GameTime gameTime)
        {
            foreach (Bat monster in _listOfMob)
            {
                monster.Update(gameTime);
            }
        }




    }
}
