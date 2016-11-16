using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
namespace Kepler_22_B.Camera
{
    internal class CameraLoader
    {
        private Game1 _context;

        public Camera2D GetCamera { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraLoader"/> class.
        /// This class is used to create Camera.
        /// The move of the camera is ont the move of the character.
        /// </summary>
        /// <param name="_context">The context.</param>
        /// <param name="windowsWidth">Width of the windows.</param>
        /// <param name="windowsHeight">Height of the windows.</param>
        public CameraLoader(Game1 context, int windowsWidth, int windowsHeight)
        {
            _context = context;
            var viewportAdapter = new BoxingViewportAdapter(_context.Window, _context.GraphicsDevice, windowsWidth, windowsHeight);
            GetCamera = new Camera2D(viewportAdapter);
        }
    }
}
