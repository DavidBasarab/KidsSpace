using Microsoft.Xna.Framework;

namespace Common.Game.Vectors
{
    public class PositionOffset : Offset
    {
        public PositionOffset(Vector3 vector)
            : base(vector) {}

        public PositionOffset(float x, float y, float z)
            : base(x, y, z) {}

        public PositionOffset(float value)
            : base(value) {}
    }
}