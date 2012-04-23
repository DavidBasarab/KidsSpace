using Microsoft.Xna.Framework;

namespace Common.Game.Graphics.Models.Helpers
{
    internal class BoundingSphereTransformer
    {
        public static BoundingSphere TransformToLocaitonAndScale(BoundingSphere boundingSphere, Vector3 scale, Vector3 position)
        {
            return new BoundingSphereTransformer(boundingSphere, scale, position).Transform();
        }

        private BoundingSphere _transformed;
        private Matrix _worldTransform;

        public BoundingSphereTransformer(BoundingSphere boundingSphere, Vector3 scale, Vector3 position)
        {
            BoundingSphere = boundingSphere;
            Scale = scale;
            Position = position;
        }

        private Vector3 Position { get; set; }
        private Vector3 Scale { get; set; }
        private BoundingSphere BoundingSphere { get; set; }

        private void CreateWorldTransform()
        {
            _worldTransform = Matrix.CreateScale(Scale) * Matrix.CreateTranslation(Position);
        }

        private BoundingSphere Transform()
        {
            CreateWorldTransform();

            TransformSphere();

            return _transformed;
        }

        private void TransformSphere()
        {
            _transformed = BoundingSphere;
            _transformed = _transformed.Transform(_worldTransform);
        }
    }
}