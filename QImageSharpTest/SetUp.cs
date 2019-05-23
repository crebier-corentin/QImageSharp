using NUnit.Framework;
using QImageSharp;

namespace QImageSharpTest
{
    [SetUpFixture]
    public class SetUp
    {
        private static string PointToString(Point point)
        {
            return $"Size X={point.X} Y={point.Y}";
        }

        private static string SizeToString(Size size)
        {
            return $"Size Width={size.Width} Height={size.Height}";
        }

        private static string LineToString(Line line)
        {
            return $"Line X1={line.X1} Y1={line.Y1} X2={line.X2} Y2={line.Y2}";
        }

        private static string RectToString(Rect rect)
        {
            return $"Rect X={rect.X} Y={rect.Y} Width={rect.Width} Height={rect.Height}";
        }

        [OneTimeSetUp]
        public void SetUpTests()
        {
            TestContext.AddFormatter<Point>(val => PointToString((Point) val));
            TestContext.AddFormatter<Size>(val => SizeToString((Size) val));
            TestContext.AddFormatter<Line>(val => LineToString((Line) val));
            TestContext.AddFormatter<Rect>(val => RectToString((Rect) val));
        }
    }
}