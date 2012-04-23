using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Cameras
{
    public abstract class Camera : BaseGraphic
    {
        protected Camera(GraphicsDevice graphicsDevice)
        {
            GraphicsDevice = graphicsDevice;
            GeneratePerspectiveProjectionMatrix();
        }

        protected GraphicsDevice GraphicsDevice { get; set; }

        public BoundingFrustum Frustum { get; private set; }

        public abstract void Update();

        public bool IsInView(BoundingSphere sphere)
        {
            return Frustum.Contains(sphere) != ContainmentType.Disjoint;
        }

        public bool IsInView(BoundingBox box)
        {
            return Frustum.Contains(box) != ContainmentType.Disjoint;
        }

        protected override void OnProjectionChange()
        {
            GenerateFrustum();
        }

        protected override void OnViewChange()
        {
            GenerateFrustum();
        }

        private void GenerateFrustum()
        {
            var viewProjection = View * Projection;
            Frustum = new BoundingFrustum(viewProjection);
        }

        private void GeneratePerspectiveProjectionMatrix()
        {
            var presentationParameters = GraphicsDevice.PresentationParameters;

            var aspectRatio = presentationParameters.BackBufferWidth / (float)presentationParameters.BackBufferHeight;

            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), aspectRatio, 0.1f, 1000000.0f);
        }
    }
}