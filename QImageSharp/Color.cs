using System;
using System.Runtime.InteropServices;

namespace QImageSharp
{
    public enum ColorSpec
    {
        Invalid,
        Rgb,
        Hsv,
        Cmyk,
        Hsl
    }

    public class Color : IDisposable
    {
        private static class Internal
        {
            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateQColor();

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateQColorRgb(int r, int g, int b, int a = 255);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateQColorCmyk(int c, int m, int y, int k, int a = 255);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr CreateQColorHsl(int h, int s, int l, int a = 255);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void FreeQColor(IntPtr qColor);

            //Spec
            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern ColorSpec QColorSpec(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr QColorConvertTo(IntPtr qColor, ColorSpec colorSpec);

            //Alpha
            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorAlpha(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern IntPtr QColorSetAlpha(IntPtr qColor, int value);

            //Get RGB
            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorRed(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorGreen(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorBlue(IntPtr qColor);

            //Set RGB
            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void QColorSetRed(IntPtr qColor, int value);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void QColorSetGreen(IntPtr qColor, int value);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void QColorSetBlue(IntPtr qColor, int value);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void QColorSetRgb(IntPtr qColor, int r, int g, int b, int a = 255);

            //HSL
            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorHslHue(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorHslSaturation(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorLightness(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void QColorSetHsl(IntPtr qColor, int h, int s, int l, int a = 255);

            //CMYK
            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorCyan(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorMagenta(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorYellow(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern int QColorBlack(IntPtr qColor);

            [DllImport(NativeLib.DllName, CallingConvention = CallingConvention.Cdecl)]
            public static extern void QColorSetCymk(IntPtr qColor, int c, int m, int y, int k, int a = 255);
        }

        private IntPtr _instance;

        #region Constructor

        public Color() : this(true)
        {
        }

        private Color(bool defaultInstance)
        {
            if (defaultInstance)
            {
                _instance = Internal.CreateQColor();
            }
        }

        public static Color FromRgb(int r, int g, int b, int a = 255)
        {
            return new Color(false) {_instance = Internal.CreateQColorRgb(r, g, b, a)};
        }

        public static Color FromCmyk(int c, int m, int y, int k, int a = 255)
        {
            return new Color(false) {_instance = Internal.CreateQColorCmyk(c, m, y, k, a)};
        }

        public static Color FromHsl(int h, int s, int l, int a = 255)
        {
            return new Color(false) {_instance = Internal.CreateQColorHsl(h, s, l, a)};
        }

        #endregion

        #region Spec

        public ColorSpec Spec => Internal.QColorSpec(_instance);

        public Color ConvertTo(ColorSpec spec)
        {
            return new Color(false) {_instance = Internal.QColorConvertTo(_instance, spec)};
        }

        #endregion

        #region RGB

        public int Alpha
        {
            get => Internal.QColorAlpha(_instance);
            set => Internal.QColorSetAlpha(_instance, value);
        }

        public int Red
        {
            get => Internal.QColorRed(_instance);
            set => Internal.QColorSetRed(_instance, value);
        }

        public int Green
        {
            get => Internal.QColorGreen(_instance);
            set => Internal.QColorSetGreen(_instance, value);
        }

        public int Blue
        {
            get => Internal.QColorBlue(_instance);
            set => Internal.QColorSetBlue(_instance, value);
        }

        public void SetRgb(int r, int g, int b, int a = 255)
        {
            Internal.QColorSetRgb(_instance, r, g, b, a);
        }

        #endregion

        #region HSL

        public int HslHue => Internal.QColorHslHue(_instance);

        public int HslSaturation => Internal.QColorHslSaturation(_instance);

        public int Lightness => Internal.QColorLightness(_instance);

        public void SetHsl(int h, int s, int l, int a = 255)
        {
            Internal.QColorSetHsl(_instance, h, s, l, a);
        }

        #endregion

        #region CMYK

        public int Cyan => Internal.QColorCyan(_instance);

        public int Magenta => Internal.QColorMagenta(_instance);

        public int Yellow => Internal.QColorYellow(_instance);

        public int Black => Internal.QColorBlack(_instance);

        public void SetCmyk(int c, int m, int y, int k, int a = 255)
        {
            Internal.QColorSetCymk(_instance, c, m, y, k, a);
        }

        #endregion

        #region Dispose

        private void ReleaseUnmanagedResources()
        {
            if (_instance != IntPtr.Zero)
            {
                Internal.FreeQColor(_instance);
            }
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~Color()
        {
            ReleaseUnmanagedResources();
        }

        #endregion
    }
}