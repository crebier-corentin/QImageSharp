using NUnit.Framework;
using QImageSharp;

namespace QImageSharpTest
{
    [TestFixture]
    public class PointTest
    {
        [Test]
        public void ConstructorTest()
        {
            var point1 = new Point();
            Assert.AreEqual(0, point1.X);
            Assert.AreEqual(0, point1.Y);

            var point2 = new Point(5, 6);
            Assert.AreEqual(5, point2.X);
            Assert.AreEqual(6, point2.Y);
        }

        [TestCase(5, 10, ExpectedResult = 15)]
        [TestCase(74, 132, ExpectedResult = 206)]
        [TestCase(1, 3, ExpectedResult = 4)]
        public int ManhattanLengthTest(int x, int y)
        {
            return new Point(x, y).ManhattanLength();
        }


        [TestCase(1, 8, 8, 90, ExpectedResult = 728)]
        [TestCase(3, 7, -1, 4, ExpectedResult = 25)]
        [TestCase(73, 84, 40, 90, ExpectedResult = 10480)]
        public int DotProductTest(int x1, int y1, int x2, int y2)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);

            return Point.DotProduct(p1, p2);
        }
    }
}