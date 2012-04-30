using Microsoft.Xna.Framework;

namespace Common.Game.Vectors
{
    public class Rotation : BaseVector3
    {
        public Rotation(Vector3 vector)
            : base(vector) {}

        public Rotation(float x, float y, float z)
            : base(x, y, z) {}

        public Rotation(float value)
            : base(value) {}
    }
}