using NUnit.Framework;
using QImageSharp;

namespace QImageSharpTest
{
    [TestFixture]
    public class RectTest
    {
        [Test]
        public void ConstructorTest()
        {
            var nullRect = Rect.Null;

            Assert.AreEqual(0, nullRect.X);
            Assert.AreEqual(0, nullRect.Y);
            Assert.AreEqual(0, nullRect.Width);
            Assert.AreEqual(0, nullRect.Height);

            var structRect = new Rect(new Point(1, 2), new Size(10, 20));

            Assert.AreEqual(1, structRect.X);
            Assert.AreEqual(2, structRect.Y);
            Assert.AreEqual(10, structRect.Width);
            Assert.AreEqual(20, structRect.Height);

            var intRect = new Rect(1, 2, 10, 20);

            Assert.AreEqual(1, intRect.X);
            Assert.AreEqual(2, intRect.Y);
            Assert.AreEqual(10, intRect.Width);
            Assert.AreEqual(20, intRect.Height);
        }

        [Test]
        public void CoordsTest()
        {
            var rect = new Rect(1, 2, 10, 20);

            //Real Sides
            Assert.AreEqual(1, rect.Left);
            Assert.AreEqual(2, rect.Top);
            Assert.AreEqual(11, rect.Right);
            Assert.AreEqual(22, rect.Bottom);

            //Modify individually
            rect.Left = 50;
            rect.Top = 5;
            rect.Right = 54;
            rect.Bottom = 80;

            Assert.AreEqual(50, rect.Left);
            Assert.AreEqual(5, rect.Top);
            Assert.AreEqual(54, rect.Right);
            Assert.AreEqual(80, rect.Bottom);

            //Qt Sides
            Assert.AreEqual(50, rect.QtLeft);
            Assert.AreEqual(5, rect.QtTop);
            Assert.AreEqual(53, rect.QtRight);
            Assert.AreEqual(79, rect.QtBottom);


            //Real Corners
            Assert.AreEqual(new Point(50, 5), rect.TopLeft);
            Assert.AreEqual(new Point(54, 5), rect.TopRight);
            Assert.AreEqual(new Point(50, 80), rect.BottomLeft);
            Assert.AreEqual(new Point(54, 80), rect.BottomRight);

            //Modify individually
            rect.TopLeft = new Point(10, 20);
            Assert.AreEqual(new Point(10, 20), rect.TopLeft);
            Assert.AreEqual(new Point(10, 20), rect.QtTopLeft);

            rect.TopRight = new Point(20, 15);
            Assert.AreEqual(new Point(20, 15), rect.TopRight);
            Assert.AreEqual(new Point(19, 15), rect.QtTopRight);

            rect.BottomLeft = new Point(11, 7);
            Assert.AreEqual(new Point(11, 7), rect.BottomLeft);
            Assert.AreEqual(new Point(11, 6), rect.QtBottomLeft);

            rect.BottomRight = new Point(9, 6);
            Assert.AreEqual(new Point(9, 6), rect.BottomRight);
            Assert.AreEqual(new Point(8, 5), rect.QtBottomRight);
        }

        [Test]
        public void SizeTest()
        {
            var rect = new Rect(0, 0, 10, 20);
            
            Assert.AreEqual(10, rect.Width);
            Assert.AreEqual(20, rect.Height);
            Assert.AreEqual(new Size(10, 20), rect.Size);

            rect.Width = 14;
            rect.Height = 85;

            Assert.AreEqual(new Size(14, 85), rect.Size);
            
            rect.Size = new Size(7, 3);
            Assert.AreEqual(7, rect.Width);
            Assert.AreEqual(3, rect.Height);
        }
    }
}