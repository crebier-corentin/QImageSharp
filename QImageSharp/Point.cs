using System.Runtime.InteropServices;

namespace QImageSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        private static class Internal
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QPointManhattanLengthDelegate(ref Point point);

            public static readonly QPointManhattanLengthDelegate QPointManhattanLength;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QPointDotProductDelegate(ref Point point1, ref Point point2);

            public static readonly QPointDotProductDelegate QPointDotProduct;

            static Internal()
            {
                QPointManhattanLength = NativeLib.LoadFunc<QPointManhattanLengthDelegate>("QPointManhattanLength");
                QPointDotProduct = NativeLib.LoadFunc<QPointDotProductDelegate>("QPointDotProduct");
            }
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