using System;
using System.Runtime.InteropServices;

namespace QImageSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point : IEquatable<Point>
    {
        private static class Internal
        {
            [DllImport(NativeLib.Name, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QPointManhattanLength(ref Point point);

            [DllImport(NativeLib.Name, CallingConvention = CallingConvention.Cdecl)]
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

        #region Operators

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        #endregion

        #region Equals

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is Point other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        #endregion

        public override string ToString()
        {
            return $"Size X={X} Y={Y}";
        }
    }
}