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
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr createQColorDelegate();

            public static createQColorDelegate createQColor;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr createQColorRgbDelegate(int r, int g, int b, int a = 255);

            public static createQColorRgbDelegate createQColorRgb;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr createQColorCmykDelegate(int c, int m, int y, int k, int a = 255);

            public static createQColorCmykDelegate createQColorCmyk;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr createQColorHslDelegate(int h, int s, int l, int a = 255);

            public static createQColorHslDelegate createQColorHsl;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void freeQColorDelegate(IntPtr qColor);

            public static freeQColorDelegate freeQColor;

            //Spec
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate ColorSpec QColorSpecDelegate(IntPtr qColor);

            public static QColorSpecDelegate QColorSpec;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr QColorConvertToDelegate(IntPtr qColor, ColorSpec colorSpec);

            public static QColorConvertToDelegate QColorConvertTo;

            //Alpha
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorAlphaDelegate(IntPtr qColor);

            public static QColorAlphaDelegate QColorAlpha;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr QColorSetAlphaDelegate(IntPtr qColor, int value);

            public static QColorSetAlphaDelegate QColorSetAlpha;

            //Get RGB
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorRedDelegate(IntPtr qColor);

            public static QColorRedDelegate QColorRed;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorGreenDelegate(IntPtr qColor);

            public static QColorGreenDelegate QColorGreen;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorBlueDelegate(IntPtr qColor);

            public static QColorBlueDelegate QColorBlue;

            //Set RGB
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetRedDelegate(IntPtr qColor, int value);

            public static QColorSetRedDelegate QColorSetRed;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetGreenDelegate(IntPtr qColor, int value);

            public static QColorSetGreenDelegate QColorSetGreen;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetBlueDelegate(IntPtr qColor, int value);

            public static QColorSetBlueDelegate QColorSetBlue;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetRgbDelegate(IntPtr qColor, int r, int g, int b, int a = 255);

            public static QColorSetRgbDelegate QColorSetRgb;

            //HSL
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorHslHueDelegate(IntPtr qColor);

            public static QColorHslHueDelegate QColorHslHue;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorHslSaturationDelegate(IntPtr qColor);

            public static QColorHslSaturationDelegate QColorHslSaturation;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorLightnessDelegate(IntPtr qColor);

            public static QColorLightnessDelegate QColorLightness;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetHslDelegate(IntPtr qColor, int h, int s, int l, int a = 255);

            public static QColorSetHslDelegate QColorSetHsl;

            //CMYK
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorCyanDelegate(IntPtr qColor);

            public static QColorCyanDelegate QColorCyan;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorMagentaDelegate(IntPtr qColor);

            public static QColorMagentaDelegate QColorMagenta;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorYellowDelegate(IntPtr qColor);

            public static QColorYellowDelegate QColorYellow;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorBlackDelegate(IntPtr qColor);

            public static QColorBlackDelegate QColorBlack;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetCymkDelegate(IntPtr qColor, int c, int m, int y, int k, int a = 255);

            public static QColorSetCymkDelegate QColorSetCymk;

            static Internal()
            {
                createQColor = NativeLib.LoadFunc<createQColorDelegate>("createQColor");
                createQColorRgb = NativeLib.LoadFunc<createQColorRgbDelegate>("createQColorRgb");
                createQColorCmyk = NativeLib.LoadFunc<createQColorCmykDelegate>("createQColorCmyk");
                createQColorHsl = NativeLib.LoadFunc<createQColorHslDelegate>("createQColorHsl");
                freeQColor = NativeLib.LoadFunc<freeQColorDelegate>("freeQColor");
                QColorSpec = NativeLib.LoadFunc<QColorSpecDelegate>("QColorSpec");
                QColorConvertTo = NativeLib.LoadFunc<QColorConvertToDelegate>("QColorConvertTo");
                QColorAlpha = NativeLib.LoadFunc<QColorAlphaDelegate>("QColorAlpha");
                QColorSetAlpha = NativeLib.LoadFunc<QColorSetAlphaDelegate>("QColorSetAlpha");
                QColorRed = NativeLib.LoadFunc<QColorRedDelegate>("QColorRed");
                QColorGreen = NativeLib.LoadFunc<QColorGreenDelegate>("QColorGreen");
                QColorBlue = NativeLib.LoadFunc<QColorBlueDelegate>("QColorBlue");
                QColorSetRed = NativeLib.LoadFunc<QColorSetRedDelegate>("QColorSetRed");
                QColorSetGreen = NativeLib.LoadFunc<QColorSetGreenDelegate>("QColorSetGreen");
                QColorSetBlue = NativeLib.LoadFunc<QColorSetBlueDelegate>("QColorSetBlue");
                QColorSetRgb = NativeLib.LoadFunc<QColorSetRgbDelegate>("QColorSetRgb");
                QColorHslHue = NativeLib.LoadFunc<QColorHslHueDelegate>("QColorHslHue");
                QColorHslSaturation = NativeLib.LoadFunc<QColorHslSaturationDelegate>("QColorHslSaturation");
                QColorLightness = NativeLib.LoadFunc<QColorLightnessDelegate>("QColorLightness");
                QColorSetHsl = NativeLib.LoadFunc<QColorSetHslDelegate>("QColorSetHsl");
                QColorCyan = NativeLib.LoadFunc<QColorCyanDelegate>("QColorCyan");
                QColorMagenta = NativeLib.LoadFunc<QColorMagentaDelegate>("QColorMagenta");
                QColorYellow = NativeLib.LoadFunc<QColorYellowDelegate>("QColorYellow");
                QColorBlack = NativeLib.LoadFunc<QColorBlackDelegate>("QColorBlack");
                QColorSetCymk = NativeLib.LoadFunc<QColorSetCymkDelegate>("QColorSetCymk");
            }
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
                _instance = Internal.createQColor();
            }
        }

        public static Color FromRgb(int r, int g, int b, int a = 255)
        {
            return new Color(false) {_instance = Internal.createQColorRgb(r, g, b, a)};
        }

        public static Color FromCmyk(int c, int m, int y, int k, int a = 255)
        {
            return new Color(false) {_instance = Internal.createQColorCmyk(c, m, y, k, a)};
        }

        public static Color FromHsl(int h, int s, int l, int a = 255)
        {
            return new Color(false) {_instance = Internal.createQColorHsl(h, s, l, a)};
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
                Internal.freeQColor(_instance);
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