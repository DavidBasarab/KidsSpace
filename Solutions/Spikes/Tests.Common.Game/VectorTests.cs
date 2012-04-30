using Common.Game.Vectors;
using NUnit.Framework;

namespace Tests.Common.Game
{
    [TestFixture]
    [Category("Vectors")]
    public class VectorTests
    {
        [Test]
        public void VectorsWillAddProperly()
        {
            var offset1 = new PositionOffset(1, 0, 0);
            var offset2 = new PositionOffset(1, 0, 0);

            var result = offset1 + offset2;

            Assert.That(result.X, Is.EqualTo(2));
        }
    }
}