using System;
using System.Runtime.InteropServices;

namespace QImageSharp
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Line
    {
        #region Fields

        public Point Pt1;
        public Point Pt2;

        #endregion

        #region Properties

        //X Y
        public int X1
        {
            get => Pt1.X;
            set => Pt1.X = value;
        }

        public int Y1
        {
            get => Pt1.Y;
            set => Pt1.Y = value;
        }

        public int X2
        {
            get => Pt2.X;
            set => Pt2.X = value;
        }

        public int Y2
        {
            get => Pt2.Y;
            set => Pt2.Y = value;
        }

        //DX DY
        // ReSharper disable once InconsistentNaming
        public int DX => Pt2.X - Pt1.X;

        // ReSharper disable once InconsistentNaming
        public int DY => Pt2.Y - Pt1.Y;

        //Center
        public Point Center => new Point((Pt1.X + Pt2.X) / 2, (Pt1.Y + Pt2.Y) / 2);

        //Null
        public bool IsNull => Pt1 == Pt2;

        #endregion

        #region Constructor

        public Line(Point pt1, Point pt2)
        {
            Pt1 = pt1;
            Pt2 = pt2;
        }

        public Line(int x1, int y1, int x2, int y2)
        {
            Pt1 = new Point(x1, y1);
            Pt2 = new Point(x2, y2);
        }

        #endregion

        #region Methods

        public void SetPoints(Point p1, Point p2)
        {
            Pt1 = p1;
            Pt2 = p2;
        }

        public void SetLine(int x1, int y1, int x2, int y2)
        {
            Pt1 = new Point(x1, y1);
            Pt2 = new Point(x2, y2);
        }

        public void Translate(Point point)
        {
            Pt1 += point;
            Pt2 += point;
        }

        public void Translate(int dx, int dy)
        {
            Translate(new Point(dx, dy));
        }

        public Line Translated(Point point)
        {
            return new Line(Pt1 + point, Pt2 + point);
        }

        public Line Translated(int dx, int dy)
        {
            return Translated(new Point(dx, dy));
        }

        #endregion
        
     
    }
}