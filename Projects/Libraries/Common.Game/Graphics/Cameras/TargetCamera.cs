using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Cameras
{
    public class TargetCamera : Camera
    {
        public TargetCamera(GraphicsDevice graphicsDevice, Vector3 position, Vector3 target)
            : base(graphicsDevice)
        {
            Position = position;
            Target = target;
        }

        public TargetCamera(GraphicsDevice graphicsDevice, Vector3 target)
            : base(graphicsDevice)
        {
            Target = target;
        }

        protected TargetCamera(GraphicsDevice graphicsDevice)
            : base(graphicsDevice) {}

        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }

        public override void Update()
        {
            View = Matrix.CreateLookAt(Position, Target, FindUp());
        }

        private Vector3 FindUp()
        {
            var forward = Target - Position;
            var side = Vector3.Cross(forward, Vector3.Up);
            var up = Vector3.Cross(forward, side);

            return up;
        }
    }
}