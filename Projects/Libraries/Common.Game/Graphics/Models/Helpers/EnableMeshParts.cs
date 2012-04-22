using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Models.Helpers
{
    internal class EnableMeshParts : BaseModelHelper
    {
        public static void Enable(Matrix view, Matrix projection, Matrix localWorld, ModelMeshPartCollection meshes)
        {
            new EnableMeshParts(view, projection, localWorld, meshes).Enable();
        }

        private EnableMeshParts(Matrix view, Matrix projection, Matrix localWorld, ModelMeshPartCollection meshes)
            : base(view, projection)
        {
            LocalWorld = localWorld;
            Meshes = meshes;
        }

        private Matrix LocalWorld { get; set; }
        private ModelMeshPartCollection Meshes { get; set; }

        private void Enable()
        {
            foreach(var meshPart in Meshes) EnableEffect(meshPart);
        }

        private void EnableEffect(ModelMeshPart meshPart)
        {
            var effect = (BasicEffect)meshPart.Effect;

            effect.World = LocalWorld;
            effect.View = View;
            effect.Projection = Projection;

            effect.EnableDefaultLighting();
        }
    }
}