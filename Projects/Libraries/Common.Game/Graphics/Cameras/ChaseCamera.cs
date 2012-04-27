using Common.Game.Numbers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Cameras
{
    public class ChaseCamera : TargetCamera
    {
        private ClampFloat _springiness = new ClampFloat(.15f, 0, 1);

        public ChaseCamera(Vector3 positionOffset, Vector3 targetOffset, Vector3 relativeCameraRotation, GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        {
            PositionOffset = positionOffset;
            TargetOffset = targetOffset;
            RelativeCameraRotation = relativeCameraRotation;
        }

        public Vector3 FollowTargetPosition { get; set; }
        public Vector3 FollowTargetRotation { get; set; }

        public Vector3 PositionOffset { get; set; }
        public Vector3 TargetOffset { get; set; }

        public Vector3 RelativeCameraRotation { get; set; }

        public ClampFloat Springiness
        {
            get { return _springiness; }
            set { _springiness = value; }
        }

        public override void Update()
        {
            // Summ the rotations of the model and the camera to ensure it is rotated to the correct position relative to the model's rotation
            Vector3 combinedRotation = FollowTargetRotation + RelativeCameraRotation;

            // Calculate the rotation matrix for the camera
            Matrix rotation = Matrix.CreateFromYawPitchRoll(combinedRotation.Y, combinedRotation.X, combinedRotation.Z);

            // Calculate the position the camera would be without the spring value, using the rotation matrix and target position
            Vector3 desiredPosition = FollowTargetPosition + Vector3.Transform(PositionOffset, rotation);

            // Interpolate between the current position and desired position
            Position = Vector3.Lerp(Position, desiredPosition, Springiness);

            // Calculate the new target using rotation matrix
            Target = FollowTargetPosition + Vector3.Transform(TargetOffset, rotation);

            // Obtain the up vector from the matrix
            Vector3 up = Vector3.Transform(Vector3.Up, rotation);

            // Recalculate the view matrix
            View = Matrix.CreateLookAt(Position, Target, up);
        }

        public void Move(Vector3 followTargetPosition, Vector3 followTargetRotation)
        {
            FollowTargetPosition = followTargetPosition;
            FollowTargetRotation = followTargetRotation;
        }

        public void Rotate(Vector3 rotationChange)
        {
            RelativeCameraRotation = rotationChange;
        }
    }
}