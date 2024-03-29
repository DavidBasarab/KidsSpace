﻿using Common.Game.Numbers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Cameras
{
    public class ArcBallCamera : TargetCamera
    {
        public ArcBallCamera(Vector3 target, ClampFloat rotationX, ClampFloat rotationY, ClampFloat distance, GraphicsDevice graphicsDevice)
            : base(graphicsDevice, target)
        {
            Target = target;
            
            RotationY = rotationY;
            RotationX = rotationX;

            Distance = distance;
        }

        public ClampFloat RotationX { get; set; }
        public ClampFloat RotationY { get; set; }
        
        public ClampFloat Distance { get; set; }
        
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
        }

        public void Rotate(float rotationXChange, float rotationYChange)
        {
            RotationX += rotationXChange;
            RotationY += -rotationYChange;
        }

        public void Translate(Vector3 positionChange)
        {
            Position += positionChange;
        }
    }
}