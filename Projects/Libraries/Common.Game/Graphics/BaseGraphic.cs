using Microsoft.Xna.Framework;

namespace Common.Game.Graphics
{
    public abstract class BaseGraphic
    {
        private Matrix _projection;
        private Matrix _view;

        protected BaseGraphic(Matrix view, Matrix projection)
        {
            View = view;
            Projection = projection;
        }

        protected BaseGraphic() {}

        public Matrix View
        {
            get { return _view; }
            set
            {
                _view = value;

                OnViewChange();
            }
        }

        public Matrix Projection
        {
            get { return _projection; }
            set
            {
                _projection = value;

                OnProjectionChange();
            }
        }

        protected virtual void OnProjectionChange() {}

        protected virtual void OnViewChange() {}
    }
}