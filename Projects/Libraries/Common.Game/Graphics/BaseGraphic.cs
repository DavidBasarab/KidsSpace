using Microsoft.Xna.Framework;

namespace Common.Game.Graphics
{
    public abstract class BaseGraphic
    {
        protected BaseGraphic(Matrix view, Matrix projection)
        {
            View = view;
            Projection = projection;
        }

        protected BaseGraphic() {}

        public Matrix View { get; set; }
        public Matrix Projection { get; set; }
    }
}