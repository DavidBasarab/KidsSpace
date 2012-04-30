using Microsoft.Xna.Framework;

namespace Common.Game.Vectors
{
    public abstract class Offset : BaseVector3
    {
        protected Offset(Vector3 vector)
            : base(vector) {}

        protected Offset(float x, float y, float z)
            : base(x, y, z) {}

        protected Offset(float value)
            : base(value) {}
    }
}