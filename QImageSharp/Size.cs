using System;
using System.Runtime.InteropServices;

namespace QImageSharp
{
    public enum AspectRatioMode
    {
        IgnoreAspectRatio,
        KeepAspectRatio,
        KeepAspectRatioByExpanding
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Size
    {
        private static class Internal
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QSizeScaleDelegate(ref Size size, int width, int height, AspectRatioMode mode);

            public static QSizeScaleDelegate QSizeScale;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr QSizeScaledDelegate(Size size, int width, int height, AspectRatioMode mode);

            public static QSizeScaledDelegate QSizeScaled;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr QSizeBoundedToDelegate(ref Size size, Size otherSize);

            public static QSizeBoundedToDelegate QSizeBoundedTo;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr QSizeExpandedToDelegate(ref Size size, Size otherSize);

            public static QSizeExpandedToDelegate QSizeExpandedTo;

            static Internal()
            {
                QSizeScale = NativeLib.LoadFunc<QSizeScaleDelegate>("QSizeScale");
                QSizeScaled = NativeLib.LoadFunc<QSizeScaledDelegate>("QSizeScaled");
                QSizeBoundedTo = NativeLib.LoadFunc<QSizeBoundedToDelegate>("QSizeBoundedTo");
                QSizeExpandedTo = NativeLib.LoadFunc<QSizeExpandedToDelegate>("QSizeExpandedTo");
            }
        }

        #region Fields

        public int Width;
        public int Height;

        #endregion

        #region Constructor

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        #endregion

        #region Properties

        public bool IsValid => Width >= 0 && Height >= 0;
        public bool IsEmpty => Width <= 0 || Height <= 0;
        public bool IsNull => Width == 0 && Height == 0;

        #endregion

        #region Methods

        public Size BoundedTo(Size otherSize)
        {
            return Marshal.PtrToStructure<Size>(Internal.QSizeBoundedTo(ref this, otherSize));
        }

        public Size ExpandedTo(Size otherSize)
        {
            return Marshal.PtrToStructure<Size>(Internal.QSizeExpandedTo(ref this, otherSize));
        }

        public void Scale(int width, int height, AspectRatioMode mode)
        {
            Internal.QSizeScale(ref this, width, height, mode);
        }

        public void Scale(Size size, AspectRatioMode mode)
        {
            Scale(size.Width, size.Height, mode);
        }

        public Size Scaled(int width, int height, AspectRatioMode mode)
        {
            return Marshal.PtrToStructure<Size>(Internal.QSizeScaled(this, width, height, mode));
        }

        public Size Scaled(Size size, AspectRatioMode mode)
        {
            return Scaled(size.Width, size.Height, mode);
        }

        public void Transpose()
        {
            var tmp = Width;
            Width = Height;
            Height = tmp;
        }

        public Size Transposed()
        {
            return new Size(Height, Width);
        }

        #endregion

        public override string ToString()
        {
            return $"Size Width={Width} Height={Height}";
        }
    }
}