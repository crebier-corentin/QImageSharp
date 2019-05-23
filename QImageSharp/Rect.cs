using System;
using System.Runtime.InteropServices;

namespace QImageSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        #region Fields

        private int _x1;
        private int _y1;
        private int _x2;
        private int _y2;

        #endregion

        #region Constructor

        public static Rect Null => new Rect(0, 0, 0, 0);

        public Rect(int x, int y, int width, int height)
        {
            _x1 = x;
            _y1 = y;

            _x2 = x + width - 1;
            _y2 = y + height - 1;
        }

        public Rect(Point topLeft, Size size)
        {
            _x1 = topLeft.X;
            _y1 = topLeft.Y;

            _x2 = topLeft.X + size.Width - 1;
            _y2 = topLeft.Y + size.Height - 1;
        }

        #endregion

        #region Coords

        public int X
        {
            get => _x1;
            set => _x1 = value;
        }

        public int Y
        {
            get => _y1;
            set => _y1 = value;
        }

        #region Real Sides

        public int Left
        {
            get => _x1;
            set => _x1 = value;
        }

        public int Top
        {
            get => _y1;
            set => _y1 = value;
        }

        public int Right
        {
            get => _x2 + 1;
            set => _x2 = value - 1;
        }

        public int Bottom
        {
            get => _y2 + 1;
            set => _y2 = value - 1;
        }

        #endregion

        #region Real Corners

        public Point TopLeft
        {
            get => new Point(Left, Top);
            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }

        public Point TopRight
        {
            get => new Point(Right, Top);
            set
            {
                Right = value.X;
                Top = value.Y;
            }
        }

        public Point BottomLeft
        {
            get => new Point(Left, Bottom);
            set
            {
                Left = value.X;
                Bottom = value.Y;
            }
        }

        public Point BottomRight
        {
            get => new Point(Right, Bottom);
            set
            {
                Right = value.X;
                Bottom = value.Y;
            }
        }

        #endregion

        #region Qt Sides

        public int QtLeft
        {
            get => _x1;
            set => _x1 = value;
        }

        public int QtTop
        {
            get => _y1;
            set => _y1 = value;
        }

        public int QtRight
        {
            get => _x2;
            set => _x2 = value;
        }

        public int QtBottom
        {
            get => _y2;
            set => _y2 = value;
        }

        #endregion

        #region Qt Corners

        public Point QtTopLeft
        {
            get => new Point(QtLeft, QtTop);
            set
            {
                QtLeft = value.X;
                QtTop = value.Y;
            }
        }

        public Point QtTopRight
        {
            get => new Point(QtRight, QtTop);
            set
            {
                QtRight = value.X;
                QtTop = value.Y;
            }
        }

        public Point QtBottomLeft
        {
            get => new Point(QtLeft, QtBottom);
            set
            {
                QtLeft = value.X;
                QtBottom = value.Y;
            }
        }

        public Point QtBottomRight
        {
            get => new Point(QtRight, QtBottom);
            set
            {
                QtRight = value.X;
                QtBottom = value.Y;
            }
        }

        #endregion

        #endregion

        #region Size

        public int Width
        {
            get => _x2 - _x1 + 1;
            set => _x2 = value + _x1 - 1;
        }

        public int Height
        {
            get => _y2 - _y1 + 1;
            set => _y2 = value + _y1 - 1;
        }

        public Size Size
        {
            get => new Size(Width, Height);
            set
            {
                _x2 = value.Width + _x1 - 1;
                _y2 = value.Height + _y1 - 1;
            }
        }

        #endregion
    }
}