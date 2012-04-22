using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Cameras
{
    public class FreeCamera : Camera
    {
        private static Vector3 CalculateUpVector(Matrix rotation)
        {
            var up = Vector3.Transform(Vector3.Up, rotation);
            return up;
        }

        public FreeCamera(GraphicsDevice graphicsDevice, Vector3 position, float yaw, float pitch)
            : base(graphicsDevice)
        {
            Position = position;
            Yaw = yaw;
            Pitch = pitch;

            Translation = Vector3.Zero;
        }

        public float Yaw { get; set; }
        public float Pitch { get; set; }

        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }

        private Vector3 Translation { get; set; }

        public override void Update()
        {
            var rotation = CalculateRotationMatrix();

            OffsetPosition(rotation);

            CalculateNewTarget(rotation);

            var up = CalculateUpVector(rotation);

            CalculateViewMatrix(up);
        }

        public void Move(Vector3 translation)
        {
            Translation += translation;
        }

        public void Rotate(float yawChange, float pitchChange)
        {
            Yaw += yawChange;
            Pitch += pitchChange;
        }

        private void CalculateNewTarget(Matrix rotation)
        {
            var forward = Vector3.Transform(Vector3.Forward, rotation);
            Target = Position + forward;
        }

        private Matrix CalculateRotationMatrix()
        {
            var rotation = Matrix.CreateFromYawPitchRoll(Yaw, Pitch, 0);
            return rotation;
        }

        private void CalculateViewMatrix(Vector3 up)
        {
            View = Matrix.CreateLookAt(Position, Target, up);
        }

        private void OffsetPosition(Matrix rotation)
        {
            Translation = Vector3.Transform(Translation, rotation);
            Position += Translation;
            Translation = Vector3.Zero;
        }
    }
}