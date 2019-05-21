using NUnit.Framework;
using QImageSharp;

namespace QImageSharpTest
{
    [TestFixture]
    public class LineTest
    {
        [Test]
        public void ConstructorTest()
        {
            //Default
            var line1 = new Line();
            Assert.AreEqual(0, line1.X1);
            Assert.AreEqual(0, line1.Y1);

            Assert.AreEqual(0, line1.X2);
            Assert.AreEqual(0, line1.Y2);

            //Point
            var p1 = new Point(1, 2);
            var p2 = new Point(10, 20);

            var line2 = new Line(p1, p2);
            Assert.AreEqual(1, line2.X1);
            Assert.AreEqual(2, line2.Y1);

            Assert.AreEqual(10, line2.X2);
            Assert.AreEqual(20, line2.Y2);

            //Int
            var line3 = new Line(-5, 6, 80, 100);
            Assert.AreEqual(-5, line3.X1);
            Assert.AreEqual(6, line3.Y1);

            Assert.AreEqual(80, line3.X2);
            Assert.AreEqual(100, line3.Y2);
        }

        [Test]
        public void SetterTest()
        {
            var line = new Line();
            Assert.AreEqual(new Line(0, 0, 0, 0), line);

            line.X1 = 1;
            line.Y1 = 2;
            line.X2 = 3;
            line.Y2 = 4;
            Assert.AreEqual(new Line(1, 2, 3, 4), line);

            line.SetLine(10, 20, 30, 40);
            Assert.AreEqual(new Line(10, 20, 30, 40), line);

            line.SetPoints(new Point(100, 200), new Point(300, 400));
            Assert.AreEqual(new Line(100, 200, 300, 400), line);
        }

        [TestCase(0, 20, 50, 10, ExpectedResult = 50)]
        [TestCase(-5, 47, 80, 0, ExpectedResult = 85)]
        [TestCase(254, 84, -3, 23, ExpectedResult = -257)]
        // ReSharper disable once InconsistentNaming
        public int DXTest(int x1, int y1, int x2, int y2)
        {
            return new Line(x1, y1, x2, y2).DX;
        }

        [TestCase(0, 20, 50, 10, ExpectedResult = -10)]
        [TestCase(-5, 47, 80, 0, ExpectedResult = -47)]
        [TestCase(254, 84, -3, 23, ExpectedResult = -61)]
        // ReSharper disable once InconsistentNaming
        public int DYTest(int x1, int y1, int x2, int y2)
        {
            return new Line(x1, y1, x2, y2).DY;
        }

        //TestCaseSource doesn't work on rider for some reason
        public static (Line line, Point result)[] CenterTestSource =
        {
            (new Line(0, 0, 10, 10), new Point(5, 5)),
            (new Line(-5, 75, 30, 24), new Point(12, 49)),
            (new Line(60, 4, 12, 83), new Point(36, 43))
        };

        [Test]
        public void CenterTest()
        {
            foreach (var (line, result) in CenterTestSource)
            {
                Assert.AreEqual(result, line.Center);
            }
        }

        [Test]
        public void IsNullTest([Values(1, -5)] int x1, [Values(1, -5)] int y1, [Values(1, -5)] int x2,
            [Values(1, -5)] int y2)
        {
            var p1 = new Point(x1, y1);
            var p2 = new Point(x2, y2);

            Assert.AreEqual(p1 == p2, new Line(p1, p2).IsNull);
        }

        [Test]
        public void TranslateTest()
        {
            var offsetPoint = new Point(5, 10);

            var line1 = new Line(20, 50, 43, -2);
            Assert.AreEqual(new Line(25, 60, 48, 8), line1.Translated(offsetPoint));
            Assert.AreEqual(line1.Translated(offsetPoint), line1.Translated(5, 10));

            line1.Translate(offsetPoint);
            Assert.AreEqual(new Line(25, 60, 48, 8), line1);

            line1.Translate(-10, 15);
            Assert.AreEqual(new Line(15, 75, 38, 23), line1);
        }
    }
}