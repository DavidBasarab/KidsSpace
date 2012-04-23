using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Cameras
{
    public class ArcBallCamera : Camera
    {
        public ArcBallCamera(Vector3 target, float rotationX, float rotationY, float minRotationY, float maxRotationY, float distance, float minDistance, float maxDistance,
                             GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        {
            Target = target;

            MinRotationY = minRotationY;
            MaxRotationY = maxRotationY;

            // Locak the y axis rotation between the min and max values
            RotationY = MathHelper.Clamp(rotationY, MinRotationY, MaxRotationY);

            RotationX = rotationX;

            MinDistance = minDistance;
            MaxDistance = maxDistance;

            // Locak the distance between the min and max values
            Distance = MathHelper.Clamp(distance, MinDistance, MaxDistance);
        }

        // Rotation around the two axes
        public float RotationX { get; set; }
        public float RotationY { get; set; }

        // Y axis rotation limits (radians)
        public float MinRotationY { get; set; }
        public float MaxRotationY { get; set; }

        // Distance between the target and camera
        public float Distance { get; set; }

        // Distance limits
        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }

        // Calculated postion and specified target
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }

        public override void Update()
        {
            // Calculate rotation matrix from rotation values
            var rotation = Matrix.CreateFromYawPitchRoll(RotationX, -RotationY, 0);

            // Translate down the Z axis by the desired distance between the camera and object 
            // then rotate that vector to find the camera offset from the target
            var translation = new Vector3(0, 0, Distance);
            translation = Vector3.Transform(translation, rotation);

            Position = Target + translation;

            // Calculate the up vector from the rotation matrix
            var up = Vector3.Transform(Vector3.Up, rotation);

            View = Matrix.CreateLookAt(Position, Target, up);
        }

        public void Move(float distanceChange)
        {
            Distance += distanceChange;

            Distance = MathHelper.Clamp(Distance, MinDistance, MaxDistance);
        }

        public void Rotate(float rotationXChange, float rotationYChange)
        {
            RotationX += rotationXChange;
            RotationY += -rotationYChange;

            RotationY = MathHelper.Clamp(RotationY, MinRotationY, MaxRotationY);
        }

        public void Translate(Vector3 positionChange)
        {
            Position += positionChange;
        }
    }
}