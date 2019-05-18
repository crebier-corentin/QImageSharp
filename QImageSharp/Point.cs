using System.Runtime.InteropServices;

namespace QImageSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        private static class Internal
        {
            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QPointManhattanLength(ref Point point);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QPointDotProduct(ref Point point1, ref Point point2);
        }

        #region Fields

        public int X;
        public int Y;

        #endregion

        #region Constructor

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Methods

        public int ManhattanLength()
        {
            return Internal.QPointManhattanLength(ref this);
        }

        public static int DotProduct(Point point1, Point point2)
        {
            return Internal.QPointDotProduct(ref point1, ref point2);
        }

        #endregion
    }
}