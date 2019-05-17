using NUnit.Framework;
using QImageSharp;

namespace QImageSharpTest
{
    [TestFixture]
    public class SizeTest
    {
        [Test]
        public void ConstructorTest()
        {
            var point1 = new Size();
            Assert.AreEqual(0, point1.Width);
            Assert.AreEqual(0, point1.Height);

            var point2 = new Size(5, 6);
            Assert.AreEqual(5, point2.Width);
            Assert.AreEqual(6, point2.Height);
        }

        [TestCase(1, 10, ExpectedResult = true)]
        [TestCase(0, 3, ExpectedResult = true)]
        [TestCase(-5, -9, ExpectedResult = false)]
        [TestCase(0, 0, ExpectedResult = true)]
        public bool IsValidTest(int width, int height)
        {
            return new Size(width, height).IsValid;
        }

        [TestCase(1, 10, ExpectedResult = false)]
        [TestCase(0, 3, ExpectedResult = true)]
        [TestCase(-5, -9, ExpectedResult = true)]
        [TestCase(0, 0, ExpectedResult = true)]
        public bool IsEmptyTest(int width, int height)
        {
            return new Size(width, height).IsEmpty;
        }

        [TestCase(1, 10, ExpectedResult = false)]
        [TestCase(0, 3, ExpectedResult = false)]
        [TestCase(-5, -9, ExpectedResult = false)]
        [TestCase(0, 0, ExpectedResult = true)]
        public bool IsNullTest(int width, int height)
        {
            return new Size(width, height).IsNull;
        }

        [Test]
        public void BoundedToTest()
        {
            var bSize1 = new Size(50, 80);
            var bSize2 = new Size(3, 120);

            Assert.AreEqual(new Size(3, 80), bSize1.BoundedTo(bSize2));
            Assert.AreEqual(new Size(3, 80), bSize2.BoundedTo(bSize1));
        }

        [Test]
        public void ExpandedToTest()
        {
            var bSize1 = new Size(50, 80);
            var bSize2 = new Size(3, 120);

            Assert.AreEqual(new Size(50, 120), bSize1.ExpandedTo(bSize2));
            Assert.AreEqual(new Size(50, 120), bSize2.ExpandedTo(bSize1));
        }

        [Test]
        public void ScaleTest()
        {
            var scaleSize = new Size(50, 100);

            var size = new Size(10, 200);

            Assert.AreEqual(new Size(50, 100), size.Scaled(scaleSize, AspectRatioMode.IgnoreAspectRatio));
            Assert.AreEqual(new Size(5, 100), size.Scaled(scaleSize, AspectRatioMode.KeepAspectRatio));
            Assert.AreEqual(new Size(50, 1000), size.Scaled(scaleSize, AspectRatioMode.KeepAspectRatioByExpanding));

            size.Scale(new Size(60, 3), AspectRatioMode.IgnoreAspectRatio);
            Assert.AreEqual(new Size(60, 3), size);
        }

        [Test]
        public void TransposeTest([Values(-5, 10, 50)] int w, [Values(-5, 10, 50)] int h)
        {
            var size = new Size(w, h);
            size.Transpose();

            Assert.AreEqual(w, size.Height);
            Assert.AreEqual(h, size.Width);

            var tSize = size.Transposed();

            Assert.AreEqual(w, tSize.Width);
            Assert.AreEqual(h, tSize.Height);
        }
    }
}