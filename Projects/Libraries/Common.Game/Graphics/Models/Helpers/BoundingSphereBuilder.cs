using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Common.Game.Graphics.Models.Helpers
{
    public class BoundingSphereBuilder
    {
        public static BoundingSphere Build(ModelMeshCollection meshes, Matrix[] transforms)
        {
            return new BoundingSphereBuilder(meshes, transforms).Build();
        }

        private BoundingSphereBuilder(ModelMeshCollection meshes, Matrix[] transforms)
        {
            Meshes = meshes;
            Transforms = transforms;
            Sphere = new BoundingSphere(Vector3.Zero, 0);
        }

        private BoundingSphere Sphere { get; set; }
        private ModelMeshCollection Meshes { get; set; }
        private Matrix[] Transforms { get; set; }

        private BoundingSphere Build()
        {
            foreach(var mesh in Meshes) BuildMeshSphere(mesh);

            return Sphere;
        }

        private void BuildMeshSphere(ModelMesh mesh)
        {
            var transformed = mesh.BoundingSphere.Transform(Transforms[mesh.ParentBone.Index]);

            Sphere = BoundingSphere.CreateMerged(Sphere, transformed);
        }
    }
}