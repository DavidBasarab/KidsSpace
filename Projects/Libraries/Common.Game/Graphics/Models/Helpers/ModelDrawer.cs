using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Models.Helpers
{
    internal class ModelDrawer : BaseGraphic
    {
        public static void Draw(GenericModel model, Matrix view, Matrix projection)
        {
            new ModelDrawer(model, view, projection).Draw();
        }

        private Matrix _baseWorld;

        private ModelDrawer(GenericModel model, Matrix view, Matrix projection)
            : base(view, projection)
        {
            Model = model;
        }

        public GenericModel Model { get; set; }

        private void CalculateBaseTransformation()
        {
            _baseWorld = Matrix.CreateScale(Model.Scale) * Matrix.CreateFromYawPitchRoll(Model.Rotation.Y, Model.Rotation.X, Model.Rotation.Z) * Matrix.CreateTranslation(Model.Position);
        }

        private void Draw()
        {
            CalculateBaseTransformation();

            foreach(var mesh in Model.Meshes) DrawMesh(mesh);
        }

        private void DrawMesh(ModelMesh mesh)
        {
            var localWorld = Model.Transforms[mesh.ParentBone.Index] * _baseWorld;

            EnableMeshParts.Enable(View, Projection, localWorld, mesh.MeshParts);

            mesh.Draw();
        }
    }
}