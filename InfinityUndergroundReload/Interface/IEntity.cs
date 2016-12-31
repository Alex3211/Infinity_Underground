using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace InfinityUndergroundReload.Interface
{
    public interface IEntity
    {
        /// <summary>
        /// Loads the content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="graphicsDevice">The graphics device.</param>
        void LoadContent(ContentManager content);


        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="keyboardState">State of the keyboard.</param>
        /// <param name="camera">The camera.</param>
        void Update(GameTime gameTime);


        /// <summary>
        /// Draws the specified sprite dragonch.
        /// </summary>
        /// <param name="spriteBatch">The sprite dragonch.</param>
        /// <param name="frozenMatrix">The frozen matrix.</param>
        /// <param name="cameraMatrix">The camera matrix.</param>
        void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Unloads this instance.
        /// </summary>
        void Unload(ContentManager content);
    }
}
