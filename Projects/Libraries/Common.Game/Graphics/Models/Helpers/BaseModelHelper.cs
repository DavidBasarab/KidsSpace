using Microsoft.Xna.Framework;

namespace Common.Game.Graphics.Models.Helpers
{
    internal abstract class BaseModelHelper
    {
        protected BaseModelHelper(Matrix view, Matrix projection)
        {
            View = view;
            Projection = projection;
        }

        public Matrix View { get; set; }
        public Matrix Projection { get; set; }
    }
}