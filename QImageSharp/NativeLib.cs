using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace QImageSharp
{
    internal static class NativeLib
    {
        private static class Functions
        {
            #region Unix

            [DllImport("libdl")]
            private static extern IntPtr dlopen(string filename, int flags);

            [DllImport("libdl")]
            private static extern IntPtr dlsym(IntPtr handle, string name);

            #endregion Unix

            #region Windows

            [DllImport("kernel32")]
            private static extern IntPtr LoadLibrary(string filename);

            [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
            private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            #endregion Windows

            public static IntPtr LoadLib(string filename)
            {
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? LoadLibrary(filename)
                    : dlopen(filename, 0);
            }

            public static IntPtr LoadFuncPtr(IntPtr lib, string name)
            {
                IntPtr func;

                func = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                    ? GetProcAddress(lib, name)
                    : dlsym(lib, name);

                return func;
            }
        }

        private static readonly IntPtr Lib;

        public const string DllName = "QImageSharpNative-win-x64";

        static NativeLib()
        {
            var libname = "QImageSharpNative";

            var arch = Environment.Is64BitProcess ? "x64" : "x86";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                libname = $"{libname}-osx-{arch}.dylib";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                libname = $"lib{libname}-linux-{arch}.so";
            }
            else // Windows
            {
                libname = $"{libname}-win-{arch}.dll";
            }

            Lib = Functions.LoadLib(libname);
        }

        public static T LoadFunc<T>(string name)
        {
            return Marshal.GetDelegateForFunctionPointer<T>(Functions.LoadFuncPtr(Lib, name));
        }

        public static IntPtr LoadFuncPtr(string name)
        {
            return Functions.LoadFuncPtr(Lib, name);
        }
    }
}