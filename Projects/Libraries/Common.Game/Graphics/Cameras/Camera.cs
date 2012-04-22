using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Cameras
{
    public abstract class Camera : BaseGraphic
    {
        protected Camera(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            GeneratePerspectiveProjectionMatrix(MathHelper.PiOver4);
        }

        protected GraphicsDevice GraphicsDevice { get; set; }

        public abstract void Update();

        private void GeneratePerspectiveProjectionMatrix(float fieldOfView)
        {
            var presentationParameters = GraphicsDevice.PresentationParameters;

            var aspectRatio = presentationParameters.BackBufferWidth / (float)presentationParameters.BackBufferHeight;

            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), aspectRatio, 0.1f, 1000000.0f);
        }
    }
}