using Common.Game.Numbers;
using NUnit.Framework;

namespace Tests.Common.Game
{
    [TestFixture]
    [Category("Numbers")]
    public class ClampFloatTests
    {
        [Test]
        public void AClampFloatAndAFloatCanBeAdded()
        {
            ClampFloat numberOne = 1.0f;
            const float numberTwo = 0.75f;

            var total = numberOne + numberTwo;

            Assert.That((float)total, Is.EqualTo(1.75f));
        }

        [Test]
        public void AClampFloatAndFloatCanBeDevided()
        {
            ClampFloat numberOne = 10.0f;
            const float numberTwo = 0.5f;

            ClampFloat total = numberOne / numberTwo;

            Assert.That((float)total, Is.EqualTo(20.0f));
        }

        [Test]
        public void AClampFloatAndFloatCanBeMultiplied()
        {
            ClampFloat numberOne = 1.0f;
            const float numberTwo = 0.75f;

            ClampFloat total = numberOne * numberTwo;

            Assert.That((float)total, Is.EqualTo(0.75f));
        }

        [Test]
        public void AdditionOperationWillNotGoOverMaxValue()
        {
            ClampFloat number = 10.0f;

            number.Max = 12.0f;
            number.Min = float.MinValue;

            number += 10.10f;

            Assert.That((float)number, Is.EqualTo(12.0f));
        }

        [Test]
        public void AdditionOperationWillNotGoOverMinValue()
        {
            var number = new ClampFloat(10.0f, 5.0f, 12.0f);

            number += -10.10f;

            Assert.That((float)number, Is.EqualTo(5.0f));
        }

        [Test]
        public void CanAdd2ClampFloats()
        {
            ClampFloat numberOne = 1.0f;
            ClampFloat numberTwo = 0.75f;

            var total = numberOne + numberTwo;

            Assert.That((float)total, Is.EqualTo(1.75f));
        }

        [Test]
        public void CanConverClamtFloatImplicityToAFloat()
        {
            var clamp = new ClampFloat();

            float zero = clamp;

            Assert.That(zero, Is.EqualTo(0.0f));
        }

        [Test]
        public void CanCreateAClampFloatByNumber()
        {
            ClampFloat number = 1.8f;

            Assert.That((float)number, Is.EqualTo(1.8f));
        }

        [Test]
        public void CanIntializeWithJustAValue()
        {
            var clamp = new ClampFloat(1.0f);

            Assert.That((float)clamp, Is.EqualTo(1.0f));
        }

        [Test]
        public void ManyAddsKeepTheNumberAtMax()
        {
            var number = new ClampFloat(0.0f, 0.0f, 12.0f);

            for (var i = 0; i < 15; i++) number += 1.0f;

            Assert.That((float)number, Is.EqualTo(12.0f));
        }

        [Test]
        public void SubtractionOperationWillNotGoOverMinValue()
        {
            ClampFloat number = 10.0f;

            number.Max = float.MaxValue;
            number.Min = 5.0f;

            number -= 10.10f;

            Assert.That((float)number, Is.EqualTo(5.0f));
        }

        [Test]
        public void WhenTheNumberIsSetItIsClamped()
        {
            var number = new ClampFloat(17, 5, 25);

            number.Value = 32;

            Assert.That(number.Value, Is.EqualTo(25));
        }
    }
}