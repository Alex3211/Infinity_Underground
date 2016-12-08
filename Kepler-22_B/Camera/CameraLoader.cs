using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
namespace Kepler_22_B.Camera
{
    public class CameraLoader
    {



        Game1 _context;
        Camera2D _getCamera;
        BoxingViewportAdapter _viewportAdapter;
        float _zoom;


        /// <summary>
        /// Gets or sets the zoom.
        /// </summary>
        /// <value>
        /// The zoom.
        /// </value>
        internal float Zoom { get { return _zoom; } }


        /// <summary>
        /// Gets the get camera.
        /// </summary>
        /// <value>
        /// The get camera.
        /// </value>
        public Camera2D GetCamera { get { return _getCamera; } }

        /// <summary>
        /// Gets the get matrix.
        /// </summary>
        /// <value>
        /// The get matrix.
        /// </value>
        public Matrix GetMatrix { get { return _getCamera.GetViewMatrix(); } }


        /// <summary>
        /// Initializes a new instance of the <see cref="CameraLoader"/> class.
        /// This class is used to create Camera.
        /// The move of the camera is ont the move of the character.
        /// </summary>
        /// <param name="_context">The context.</param>
        /// <param name="windowsWidth">Width of the windows.</param>
        /// <param name="windowsHeight">Height of the windows.</param>
        public CameraLoader(Game1 context)
        {
            _context = context;
            _context.CameraLoader = this;
            _zoom = (float)0.1;
        }

        /// <summary>
        /// Viewports the adapter camera.
        /// </summary>
        /// <param name="windowWidth">Width of the window.</param>
        /// <param name="windowHeight">Height of the window.</param>
        public void ViewportAdapterCamera(int windowWidth, int windowHeight)
        {
            _viewportAdapter = new BoxingViewportAdapter(_context.Window, _context.GraphicsDevice, windowWidth, windowHeight);
            _getCamera = new Camera2D(_viewportAdapter);
            _getCamera.LookAt(new Vector2(80, 90));
        }
        


        
    }
}
