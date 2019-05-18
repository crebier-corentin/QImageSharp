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
            public delegate IntPtr CreateQColorDelegate();

            public static readonly CreateQColorDelegate CreateQColor;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr CreateQColorRgbDelegate(int r, int g, int b, int a = 255);

            public static readonly CreateQColorRgbDelegate CreateQColorRgb;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr CreateQColorCmykDelegate(int c, int m, int y, int k, int a = 255);

            public static readonly CreateQColorCmykDelegate CreateQColorCmyk;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr CreateQColorHslDelegate(int h, int s, int l, int a = 255);

            public static readonly CreateQColorHslDelegate CreateQColorHsl;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void FreeQColorDelegate(IntPtr qColor);

            public static readonly FreeQColorDelegate FreeQColor;

            //Spec
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate ColorSpec QColorSpecDelegate(IntPtr qColor);

            public static readonly QColorSpecDelegate QColorSpec;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr QColorConvertToDelegate(IntPtr qColor, ColorSpec colorSpec);

            public static readonly QColorConvertToDelegate QColorConvertTo;

            //Alpha
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorAlphaDelegate(IntPtr qColor);

            public static readonly QColorAlphaDelegate QColorAlpha;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate IntPtr QColorSetAlphaDelegate(IntPtr qColor, int value);

            public static readonly QColorSetAlphaDelegate QColorSetAlpha;

            //Get RGB
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorRedDelegate(IntPtr qColor);

            public static readonly QColorRedDelegate QColorRed;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorGreenDelegate(IntPtr qColor);

            public static readonly QColorGreenDelegate QColorGreen;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorBlueDelegate(IntPtr qColor);

            public static readonly QColorBlueDelegate QColorBlue;

            //Set RGB
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetRedDelegate(IntPtr qColor, int value);

            public static readonly QColorSetRedDelegate QColorSetRed;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetGreenDelegate(IntPtr qColor, int value);

            public static readonly QColorSetGreenDelegate QColorSetGreen;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetBlueDelegate(IntPtr qColor, int value);

            public static readonly QColorSetBlueDelegate QColorSetBlue;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetRgbDelegate(IntPtr qColor, int r, int g, int b, int a = 255);

            public static readonly QColorSetRgbDelegate QColorSetRgb;

            //HSL
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorHslHueDelegate(IntPtr qColor);

            public static readonly QColorHslHueDelegate QColorHslHue;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorHslSaturationDelegate(IntPtr qColor);

            public static readonly QColorHslSaturationDelegate QColorHslSaturation;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorLightnessDelegate(IntPtr qColor);

            public static readonly QColorLightnessDelegate QColorLightness;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetHslDelegate(IntPtr qColor, int h, int s, int l, int a = 255);

            public static readonly QColorSetHslDelegate QColorSetHsl;

            //CMYK
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorCyanDelegate(IntPtr qColor);

            public static readonly QColorCyanDelegate QColorCyan;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorMagentaDelegate(IntPtr qColor);

            public static readonly QColorMagentaDelegate QColorMagenta;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorYellowDelegate(IntPtr qColor);

            public static readonly QColorYellowDelegate QColorYellow;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate int QColorBlackDelegate(IntPtr qColor);

            public static readonly QColorBlackDelegate QColorBlack;

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void QColorSetCymkDelegate(IntPtr qColor, int c, int m, int y, int k, int a = 255);

            public static readonly QColorSetCymkDelegate QColorSetCymk;

            static Internal()
            {
                CreateQColor = NativeLib.LoadFunc<CreateQColorDelegate>("CreateQColor");
                CreateQColorRgb = NativeLib.LoadFunc<CreateQColorRgbDelegate>("CreateQColorRgb");
                CreateQColorCmyk = NativeLib.LoadFunc<CreateQColorCmykDelegate>("CreateQColorCmyk");
                CreateQColorHsl = NativeLib.LoadFunc<CreateQColorHslDelegate>("CreateQColorHsl");
                FreeQColor = NativeLib.LoadFunc<FreeQColorDelegate>("FreeQColor");
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