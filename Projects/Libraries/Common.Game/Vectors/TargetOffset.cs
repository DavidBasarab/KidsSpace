using Microsoft.Xna.Framework;

namespace Common.Game.Vectors
{
    public class TargetOffset : Offset
    {
        public TargetOffset(Vector3 vector)
            : base(vector) {}

        public TargetOffset(float x, float y, float z)
            : base(x, y, z) {}

        public TargetOffset(float value)
            : base(value) {}
    }
}