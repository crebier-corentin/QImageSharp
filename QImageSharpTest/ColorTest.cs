using NUnit.Framework;
using QImageSharp;

namespace QImageSharpTest
{
    [TestFixture]
    public class ColorTest
    {
        [TestCase(ColorSpec.Rgb, ExpectedResult = ColorSpec.Rgb)]
        [TestCase(ColorSpec.Cmyk, ExpectedResult = ColorSpec.Cmyk)]
        [TestCase(ColorSpec.Hsl, ExpectedResult = ColorSpec.Hsl)]
        public ColorSpec ConvertToTest(ColorSpec newSpec)
        {
            using (var color = Color.FromRgb(255, 40, 0))
            using (var newColor = color.ConvertTo(newSpec))
            {
                return newColor.Spec;
            }
        }

        [Test]
        public void SetRgbTest()
        {
            using (var color = new Color())
            {
                color.SetRgb(30, 50, 10);

                Assert.AreEqual(30, color.Red);
                Assert.AreEqual(50, color.Green);
                Assert.AreEqual(10, color.Blue);

                Assert.AreEqual(255, color.Alpha);
                color.Alpha = 32;
                Assert.AreEqual(32, color.Alpha);

                color.Red = 90;
                Assert.AreEqual(90, color.Red);

                color.Green = 70;
                Assert.AreEqual(70, color.Green);

                color.Blue = 30;
                Assert.AreEqual(30, color.Blue);
            }
        }

        [Test]
        public void SetHslTest()
        {
            using (var color = new Color())
            {
                color.SetHsl(30, 50, 10);

                Assert.AreEqual(30, color.HslHue);
                Assert.AreEqual(50, color.HslSaturation);
                Assert.AreEqual(10, color.Lightness);

                Assert.AreEqual(255, color.Alpha);
                color.Alpha = 32;
                Assert.AreEqual(32, color.Alpha);
            }
        }

        [Test]
        public void SetCmykTest()
        {
            using (var color = new Color())
            {
                color.SetCmyk(30, 50, 10, 20);

                Assert.AreEqual(30, color.Cyan);
                Assert.AreEqual(50, color.Magenta);
                Assert.AreEqual(10, color.Yellow);
                Assert.AreEqual(20, color.Black);

                Assert.AreEqual(255, color.Alpha);
                color.Alpha = 32;
                Assert.AreEqual(32, color.Alpha);
            }
        }

        [Test]
        public void ConstructorTest()
        {
            using (var rbgColor = Color.FromRgb(10, 20, 30))
            {
                Assert.AreEqual(10, rbgColor.Red);
                Assert.AreEqual(20, rbgColor.Green);
                Assert.AreEqual(30, rbgColor.Blue);
            }

            using (var hslColor = Color.FromHsl(10, 20, 30))
            {
                Assert.AreEqual(10, hslColor.HslHue);
                Assert.AreEqual(20, hslColor.HslSaturation);
                Assert.AreEqual(30, hslColor.Lightness);
            }

            using (var cymkColor = Color.FromCmyk(10, 20, 30, 40))
            {
                Assert.AreEqual(10, cymkColor.Cyan);
                Assert.AreEqual(20, cymkColor.Magenta);
                Assert.AreEqual(30, cymkColor.Yellow);
                Assert.AreEqual(40, cymkColor.Black);
            }
        }
    }
}