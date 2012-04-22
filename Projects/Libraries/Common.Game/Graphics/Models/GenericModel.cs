using Common.Game.Graphics.Models.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Models
{
    public class GenericModel
    {
        private Model _model;

        public GenericModel(Model model, Vector3 position, Vector3 rotation, Vector3 scale, GraphicsDevice graphicsDevice)
        {
            SetModel(model);

            Position = position;
            Rotation = rotation;
            Scale = scale;

            GraphicsDevice = graphicsDevice;
        }

        public ModelMeshCollection Meshes
        {
            get { return Model.Meshes; }
        }

        public Vector3 Position { get; set; }
        public Vector3 Rotation { get; set; }
        public Vector3 Scale { get; set; }

        public Model Model
        {
            get { return _model; }
        }

        public Matrix[] Transforms { get; set; }

        private GraphicsDevice GraphicsDevice { get; set; }

        public void Draw(Matrix view, Matrix projection)
        {
            ModelDrawer.Draw(this, view, projection);
        }

        private void SetModel(Model value)
        {
            _model = value;

            Transforms = new Matrix[_model.GetBoneCount()];

            _model.CopyAbsoluteBoneTransformsTo(Transforms);
        }
    }
}