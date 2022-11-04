using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Text;

namespace IntrinsicsLib {
    /// <summary>
    /// Demo for Intrinsics function and Vector types (内在函数及向量类型的Demo).
    /// </summary>
    public partial class IntrinsicsDemo {
        /// <summary>Indent next separator.</summary>
        public static readonly string IndentNextSeparator = "\t";

        /// <summary>
        /// Is release make.
        /// </summary>
        public static readonly bool IsRelease =
#if DEBUG
            false
#else
            true
#endif
        ;

        public static bool ShowFull = false;

        // srcArray: array.
        private const int srcArraySize = 256;
        private static readonly float[] srcArray_float = Enumerable.Range(0, srcArraySize).Select(x => (float)x).ToArray();
        private static readonly double[] srcArray_double = Enumerable.Range(0, srcArraySize).Select(x => (double)x).ToArray();
        private static readonly byte[] srcArray_byte = Enumerable.Range(0, srcArraySize * 4).Select(x => (byte)x).ToArray();
        private static readonly int[] srcArray_int = Enumerable.Range(0, srcArraySize).Select(x => (int)x).ToArray();
        private static readonly long[] srcArray_long = Enumerable.Range(0, srcArraySize).Select(x => (long)x).ToArray();

        /// <summary>
        /// Output Environment.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void OutputEnvironment(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            //string indentNext = indent + "\t";
            tw.WriteLine(indent + string.Format("IsRelease:\t{0}", IsRelease));
            tw.WriteLine(indent + string.Format("EnvironmentVariable(PROCESSOR_IDENTIFIER):\t{0}", Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER")));
            tw.WriteLine(indent + string.Format("Environment.ProcessorCount:\t{0}", Environment.ProcessorCount));
            tw.WriteLine(indent + string.Format("Environment.Is64BitOperatingSystem:\t{0}", Environment.Is64BitOperatingSystem));
            tw.WriteLine(indent + string.Format("Environment.Is64BitProcess:\t{0}", Environment.Is64BitProcess));
            tw.WriteLine(indent + string.Format("Environment.OSVersion:\t{0}", Environment.OSVersion));
            tw.WriteLine(indent + string.Format("Environment.Version:\t{0}", Environment.Version));
            //tw.WriteLine(indent + string.Format("RuntimeEnvironment.GetSystemVersion:\t{0}", System.Runtime.InteropServices.RuntimeEnvironment.GetSystemVersion())); // Same Environment.Version
            tw.WriteLine(indent + string.Format("RuntimeEnvironment.GetRuntimeDirectory:\t{0}", System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeDirectory()));
#if (NET47 || NET462 || NET461 || NET46 || NET452 || NET451 || NET45 || NET40 || NET35 || NET20) || (NETSTANDARD1_0)
#else
            tw.WriteLine(indent + string.Format("RuntimeInformation.FrameworkDescription:\t{0}", System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription));
            tw.WriteLine(indent + string.Format("RuntimeInformation.OSArchitecture:\t{0}", System.Runtime.InteropServices.RuntimeInformation.OSArchitecture));
#endif
            tw.WriteLine(indent + string.Format("BitConverter.IsLittleEndian:\t{0}", BitConverter.IsLittleEndian));
            tw.WriteLine(indent + string.Format("IntPtr.Size:\t{0}", IntPtr.Size));
            tw.WriteLine(indent + string.Format("Vector.IsHardwareAccelerated:\t{0}", Vector.IsHardwareAccelerated));
            tw.WriteLine(indent + string.Format("Vector<byte>.Count:\t{0}\t# {1}bit", Vector<byte>.Count, Vector<byte>.Count * sizeof(byte) * 8));
            tw.WriteLine(indent + string.Format("Vector<float>.Count:\t{0}\t# {1}bit", Vector<float>.Count, Vector<float>.Count * sizeof(float) * 8));
            //tw.WriteLine(indent + string.Format("Vector<double>.Count:\t{0}\t# {1}bit", Vector<double>.Count, Vector<double>.Count * sizeof(double) * 8));
            Assembly assembly;
            //assembly = typeof(Vector4).GetTypeInfo().Assembly;
            //tw.WriteLine(string.Format("Vector4.Assembly:\t{0}", assembly));
#pragma warning disable SYSLIB0012 // Type or member is obsolete
            //tw.WriteLine(string.Format("Vector4.Assembly.CodeBase:\t{0}", assembly.CodeBase));
            assembly = typeof(Vector<float>).GetTypeInfo().Assembly;
            tw.WriteLine(string.Format("Vector<T>.Assembly.CodeBase:\t{0}", assembly.CodeBase));
            assembly = typeof(Vector128<float>).GetTypeInfo().Assembly;
            tw.WriteLine(string.Format("Vector128<T>.Assembly.CodeBase:\t{0}", assembly.CodeBase));
#pragma warning restore SYSLIB0012 // Type or member is obsolete
        }

        /// <summary>
        /// Run.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void Run(TextWriter tw, string indent) {
            try {
                RunCommon(tw, indent);
                RunX86(tw, indent);
                RunArm(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine(ex);
            }
            if (null!= tw) {
                // [Debug]
            }
        }

        /// <summary>
        /// Run common.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunCommon(TextWriter tw, string indent) {
            try {
                RunBaseInfo(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunBaseInfo fail! " + ex.ToString());
            }
            try {
                RunVectorStart(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunVectorStart fail! " + ex.ToString());
            }
        }

        /// <summary>
        /// Get hex string.
        /// </summary>
        /// <typeparam name="T">Vector value type.</typeparam>
        /// <param name="src">Source value.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="noFixEndian">No fix endian.</param>
        /// <returns>Returns hex string.</returns>
        private static string GetHex<T>(Vector<T> src, string separator, bool noFixEndian) where T : struct {
            Vector<byte> list = Vector.AsVectorByte(src);
            int unitCount = Vector<T>.Count;
            int unitSize = Vector<byte>.Count / unitCount;
            bool fixEndian = false;
            if (!noFixEndian && BitConverter.IsLittleEndian) fixEndian = true;
            StringBuilder sb = new StringBuilder();
            if (fixEndian) {
                // IsLittleEndian.
                for (int i = 0; i < unitCount; ++i) {
                    if ((i > 0)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            sb.Append(separator);
                        }
                    }
                    int idx = unitSize * (i + 1) - 1;
                    for (int j = 0; j < unitSize; ++j) {
                        byte by = list[idx];
                        --idx;
                        sb.Append(by.ToString("X2"));
                    }
                }
            } else {
                for (int i = 0; i < Vector<byte>.Count; ++i) {
                    byte by = list[i];
                    if ((i > 0) && (0 == i % unitSize)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            sb.Append(separator);
                        }
                    }
                    sb.Append(by.ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Get hex string by Vector64.
        /// </summary>
        /// <typeparam name="T">Vector value type.</typeparam>
        /// <param name="src">Source value.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="noFixEndian">No fix endian.</param>
        /// <returns>Returns hex string.</returns>
        private static string GetHex<T>(Vector64<T> src, string separator, bool noFixEndian) where T : struct {
            Vector64<byte> list = Vector64.AsByte(src);
            int byteCount = Vector64<byte>.Count;
            int unitCount = Vector64<T>.Count;
            int unitSize = byteCount / unitCount;
            bool fixEndian = false;
            if (!noFixEndian && BitConverter.IsLittleEndian) fixEndian = true;
            StringBuilder sb = new StringBuilder();
            if (fixEndian) {
                // IsLittleEndian.
                for (int i = 0; i < unitCount; ++i) {
                    if ((i > 0)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            sb.Append(separator);
                        }
                    }
                    int idx = unitSize * (i + 1) - 1;
                    for (int j = 0; j < unitSize; ++j) {
                        byte by = list.GetElement(idx);
                        --idx;
                        sb.Append(by.ToString("X2"));
                    }
                }
            } else {
                for (int i = 0; i < byteCount; ++i) {
                    byte by = list.GetElement(i);
                    if ((i > 0) && (0 == i % unitSize)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            sb.Append(separator);
                        }
                    }
                    sb.Append(by.ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Get hex string by Vector128.
        /// </summary>
        /// <typeparam name="T">Vector value type.</typeparam>
        /// <param name="src">Source value.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="noFixEndian">No fix endian.</param>
        /// <returns>Returns hex string.</returns>
        private static string GetHex<T>(Vector128<T> src, string separator, bool noFixEndian) where T : struct {
            Vector128<byte> list = Vector128.AsByte(src);
            int byteCount = Vector128<byte>.Count;
            int unitCount = Vector128<T>.Count;
            int unitSize = byteCount / unitCount;
            bool fixEndian = false;
            if (!noFixEndian && BitConverter.IsLittleEndian) fixEndian = true;
            StringBuilder sb = new StringBuilder();
            if (fixEndian) {
                // IsLittleEndian.
                for (int i = 0; i < unitCount; ++i) {
                    if ((i > 0)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            sb.Append(separator);
                        }
                    }
                    int idx = unitSize * (i + 1) - 1;
                    for (int j = 0; j < unitSize; ++j) {
                        byte by = list.GetElement(idx);
                        --idx;
                        sb.Append(by.ToString("X2"));
                    }
                }
            } else {
                for (int i = 0; i < byteCount; ++i) {
                    byte by = list.GetElement(i);
                    if ((i > 0) && (0 == i % unitSize)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            sb.Append(separator);
                        }
                    }
                    sb.Append(by.ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Get hex string by Vector256.
        /// </summary>
        /// <typeparam name="T">Vector value type.</typeparam>
        /// <param name="src">Source value.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="noFixEndian">No fix endian.</param>
        /// <returns>Returns hex string.</returns>
        private static string GetHex<T>(Vector256<T> src, string separator, bool noFixEndian) where T : struct {
            Vector256<byte> list = Vector256.AsByte(src);
            int byteCount = Vector256<byte>.Count;
            int unitCount = Vector256<T>.Count;
            int unitSize = byteCount / unitCount;
            bool fixEndian = false;
            if (!noFixEndian && BitConverter.IsLittleEndian) fixEndian = true;
            StringBuilder sb = new StringBuilder();
            if (fixEndian) {
                // IsLittleEndian.
                for (int i = 0; i < unitCount; ++i) {
                    if ((i > 0)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            sb.Append(separator);
                        }
                    }
                    int idx = unitSize * (i + 1) - 1;
                    for (int j = 0; j < unitSize; ++j) {
                        byte by = list.GetElement(idx);
                        --idx;
                        sb.Append(by.ToString("X2"));
                    }
                }
            } else {
                for (int i = 0; i < byteCount; ++i) {
                    byte by = list.GetElement(i);
                    if ((i > 0) && (0 == i % unitSize)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            sb.Append(separator);
                        }
                    }
                    sb.Append(by.ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// WriteLine with format by Vector.
        /// </summary>
        /// <typeparam name="T">Vector value type.</typeparam>
        /// <param name="tw">The TextWriter.</param>
        /// <param name="indent">The indent.</param>
        /// <param name="format">The format.</param>
        /// <param name="src">Source value</param>
        private static void WriteLineFormat<T>(TextWriter tw, string indent, string format, Vector<T> src) where T : struct {
            if (null == tw) return;
            string line = indent + string.Format(format, src);
            string hex = GetHex(src, " ", false);
            line += "\t# (" + hex + ")";
            tw.WriteLine(line);
        }

        /// <summary>
        /// WriteLine with format by Vector64.
        /// </summary>
        /// <typeparam name="T">Vector value type.</typeparam>
        /// <param name="tw">The TextWriter.</param>
        /// <param name="indent">The indent.</param>
        /// <param name="format">The format.</param>
        /// <param name="src">Source value</param>
        private static void WriteLineFormat<T>(TextWriter tw, string indent, string format, Vector64<T> src) where T : struct {
            if (null == tw) return;
            string line = indent + string.Format(format, src);
            string hex = GetHex(src, " ", false);
            line += "\t# (" + hex + ")";
            tw.WriteLine(line);
        }

        /// <summary>
        /// WriteLine with format by Vector128.
        /// </summary>
        /// <typeparam name="T">Vector value type.</typeparam>
        /// <param name="tw">The TextWriter.</param>
        /// <param name="indent">The indent.</param>
        /// <param name="format">The format.</param>
        /// <param name="src">Source value</param>
        private static void WriteLineFormat<T>(TextWriter tw, string indent, string format, Vector128<T> src) where T : struct {
            if (null == tw) return;
            string line = indent + string.Format(format, src);
            string hex = GetHex(src, " ", false);
            line += "\t# (" + hex + ")";
            tw.WriteLine(line);
        }

        /// <summary>
        /// WriteLine with format by Vector256.
        /// </summary>
        /// <typeparam name="T">Vector value type.</typeparam>
        /// <param name="tw">The TextWriter.</param>
        /// <param name="indent">The indent.</param>
        /// <param name="format">The format.</param>
        /// <param name="src">Source value</param>
        private static void WriteLineFormat<T>(TextWriter tw, string indent, string format, Vector256<T> src) where T : struct {
            if (null == tw) return;
            string line = indent + string.Format(format, src);
            string hex = GetHex(src, " ", false);
            line += "\t# (" + hex + ")";
            tw.WriteLine(line);
        }

        /// <summary>
        /// WriteLine with format.
        /// </summary>
        /// <param name="tw">The TextWriter.</param>
        /// <param name="indent">The indent.</param>
        /// <param name="format">The format.</param>
        /// <param name="src">Source value</param>
        private static void WriteLineFormat(TextWriter tw, string indent, string format, object src) {
            if (null == tw) return;
            tw.WriteLine(indent + string.Format(format, src));
        }

        /// <summary>
        /// Run base info.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunBaseInfo(TextWriter tw, string indent) {
            // Vector create .
            tw.WriteLine(indent + "[Vector create]");
            double[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] arrByte = { byte.MinValue, byte.MaxValue, 0, 1 };
            //tw.WriteLine(Vectors.Create<Byte>(null)); // ArgumentNullException
            //tw.WriteLine(Vectors.Create(arrByte)); // IndexOutOfRangeException
            WriteLineFormat(tw, indent, "Create by T[]:\t{0}", Vectors.Create(arr));
            var parr = new ReadOnlySpan<double>(arr);
            WriteLineFormat(tw, indent, "Create by Span<T>:\t{0}", Vectors.Create(new Span<double>(arr)));
            WriteLineFormat(tw, indent, "Create by ReadOnlySpan<T>:\t{0}", Vectors.Create(parr));
            if (true) {
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                var parr2 = MemoryMarshal.AsBytes(parr);
                WriteLineFormat(tw, indent, "Create by ReadOnlySpan<byte>:\t{0}", Vectors.Create<double>(parr2));
#else
#endif // NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            }
            WriteLineFormat(tw, indent, "Vectors.CreateRotate(arrByte):\t{0}", Vectors.CreateRotate(arrByte));
            tw.WriteLine();

            // Scalars<T> .
            tw.WriteLine(indent + "[Scalar samples]");
            RunInfoScalars<float>(tw, indent);
            RunInfoScalars<double>(tw, indent);
            RunInfoScalars<sbyte>(tw, indent);
            RunInfoScalars<byte>(tw, indent);
            RunInfoScalars<short>(tw, indent);
            RunInfoScalars<ushort>(tw, indent);
            RunInfoScalars<int>(tw, indent);
            RunInfoScalars<uint>(tw, indent);
            RunInfoScalars<long>(tw, indent);
            RunInfoScalars<ulong>(tw, indent);
            RunInfoScalars<IntPtr>(tw, indent);
            RunInfoScalars<UIntPtr>(tw, indent);
#if NET5_0_OR_GREATER
            RunInfoScalars<Half>(tw, indent);
#endif // NET5_0_OR_GREATER
            tw.WriteLine();

            // Vectors<T> .
            tw.WriteLine(indent + "[Vector samples]");
            RunInfoVectors<float>(tw, indent);
            RunInfoVectors<double>(tw, indent);
            RunInfoVectors<sbyte>(tw, indent);
            RunInfoVectors<byte>(tw, indent);
            RunInfoVectors<short>(tw, indent);
            RunInfoVectors<ushort>(tw, indent);
            RunInfoVectors<int>(tw, indent);
            RunInfoVectors<uint>(tw, indent);
            RunInfoVectors<long>(tw, indent);
            RunInfoVectors<ulong>(tw, indent);
            unsafe {
                // When the return type is `T`, you cannot get a pointer. // CS0211	Cannot take the address of the given expression
                //fixed (void* p = &Vectors<ulong>.Zero) {
                //    WriteLineFormat(tw, indent, "&Vectors<ulong>.Zero:\t0x{0:X}", (IntPtr)p);
                //}
                // When the return type is `ref readonly T`, you cannot get a pointer.
                fixed (void* p = &Vectors<ulong>.V0) {
                    WriteLineFormat(tw, indent, "&Vectors<ulong>.V0:\t0x{0:X}", (IntPtr)p);
                }
            }
            tw.WriteLine();

            // Vector64s<T> .
            try {
                RunInfoVector64s<float>(tw, indent);
                RunInfoVector64s<double>(tw, indent);
                RunInfoVector64s<sbyte>(tw, indent);
                RunInfoVector64s<byte>(tw, indent);
                RunInfoVector64s<short>(tw, indent);
                RunInfoVector64s<ushort>(tw, indent);
                RunInfoVector64s<int>(tw, indent);
                RunInfoVector64s<uint>(tw, indent);
                RunInfoVector64s<long>(tw, indent);
                RunInfoVector64s<ulong>(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunInfoVector64s fail! " + ex.ToString());
            }
            tw.WriteLine();

            // Vector128s<T> .
            try {
                RunInfoVector128s<float>(tw, indent);
                RunInfoVector128s<double>(tw, indent);
                RunInfoVector128s<sbyte>(tw, indent);
                RunInfoVector128s<byte>(tw, indent);
                RunInfoVector128s<short>(tw, indent);
                RunInfoVector128s<ushort>(tw, indent);
                RunInfoVector128s<int>(tw, indent);
                RunInfoVector128s<uint>(tw, indent);
                RunInfoVector128s<long>(tw, indent);
                RunInfoVector128s<ulong>(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunInfoVector128s fail! " + ex.ToString());
            }
            tw.WriteLine();

            // Vector256s<T> .
            try {
                RunInfoVector256s<float>(tw, indent);
                RunInfoVector256s<double>(tw, indent);
                RunInfoVector256s<sbyte>(tw, indent);
                RunInfoVector256s<byte>(tw, indent);
                RunInfoVector256s<short>(tw, indent);
                RunInfoVector256s<ushort>(tw, indent);
                RunInfoVector256s<int>(tw, indent);
                RunInfoVector256s<uint>(tw, indent);
                RunInfoVector256s<long>(tw, indent);
                RunInfoVector256s<ulong>(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunInfoVector256s fail! " + ex.ToString());
            }
            tw.WriteLine();
        }

        /// <summary>
        /// Run base - <see cref="Scalars{T}"/>
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        public static void RunInfoScalars<T>(TextWriter tw, string indent) where T : struct {
            tw.WriteLine(indent + string.Format("-- Scalars<{0}> --", typeof(T).Name));
            if (ShowFull) {
                WriteLineFormat(tw, indent, "V0:\t{0}", Scalars<T>.V0);
                WriteLineFormat(tw, indent, "AllBitsSet:\t{0}", Scalars<T>.AllBitsSet);
            }
            WriteLineFormat(tw, indent, "ByteSize:\t{0}", Scalars<T>.ByteSize);
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Scalars<T>.SignBits, Scalars<T>.ExponentBits, Scalars<T>.MantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Scalars<T>.SignShift, Scalars<T>.ExponentShift, Scalars<T>.MantissaShift));
                WriteLineFormat(tw, indent, "ExponentBias:\t{0}", Scalars<T>.ExponentBias);
                WriteLineFormat(tw, indent, "SignMask:\t{0}", Scalars<T>.SignMask);
                WriteLineFormat(tw, indent, "ExponentMask:\t{0}", Scalars<T>.ExponentMask);
                WriteLineFormat(tw, indent, "MantissaMask:\t{0}", Scalars<T>.MantissaMask);
                WriteLineFormat(tw, indent, "NonSignMask:\t{0}", Scalars<T>.NonSignMask);
                WriteLineFormat(tw, indent, "NonExponentMask:\t{0}", Scalars<T>.NonExponentMask);
                WriteLineFormat(tw, indent, "NonMantissaMask:\t{0}", Scalars<T>.NonMantissaMask);
                WriteLineFormat(tw, indent, "SignMask:\t{0}", Scalars<T>.SignMask);
                WriteLineFormat(tw, indent, "ExponentMask:\t{0}", Scalars<T>.ExponentMask);
                WriteLineFormat(tw, indent, "MantissaMask:\t{0}", Scalars<T>.MantissaMask);
                WriteLineFormat(tw, indent, "NonSignMask:\t{0}", Scalars<T>.NonSignMask);
                WriteLineFormat(tw, indent, "NonExponentMask:\t{0}", Scalars<T>.NonExponentMask);
                WriteLineFormat(tw, indent, "NonMantissaMask:\t{0}", Scalars<T>.NonMantissaMask);
                WriteLineFormat(tw, indent, "Epsilon:\t{0}", Scalars<T>.Epsilon);
                WriteLineFormat(tw, indent, "MaxValue:\t{0}", Scalars<T>.MaxValue);
                WriteLineFormat(tw, indent, "MinValue:\t{0}", Scalars<T>.MinValue);
                WriteLineFormat(tw, indent, "NaN:\t{0}", Scalars<T>.NaN);
                WriteLineFormat(tw, indent, "NegativeInfinity:\t{0}", Scalars<T>.NegativeInfinity);
                WriteLineFormat(tw, indent, "PositiveInfinity:\t{0}", Scalars<T>.PositiveInfinity);
                WriteLineFormat(tw, indent, "E:\t{0}", Scalars<T>.E);
                WriteLineFormat(tw, indent, "Pi:\t{0}", Scalars<T>.Pi);
                WriteLineFormat(tw, indent, "Tau:\t{0}", Scalars<T>.Tau);
                WriteLineFormat(tw, indent, "V0:\t{0}", Scalars<T>.V0);
                WriteLineFormat(tw, indent, "V1:\t{0}", Scalars<T>.V1);
                WriteLineFormat(tw, indent, "V127:\t{0}", Scalars<T>.V127);
                WriteLineFormat(tw, indent, "V255:\t{0}", Scalars<T>.V255);
                WriteLineFormat(tw, indent, "V32767:\t{0}", Scalars<T>.V32767);
                WriteLineFormat(tw, indent, "V65535:\t{0}", Scalars<T>.V65535);
                WriteLineFormat(tw, indent, "V2147483647:\t{0}", Scalars<T>.V2147483647);
                WriteLineFormat(tw, indent, "V4294967295:\t{0}", Scalars<T>.V4294967295);
                WriteLineFormat(tw, indent, "V_1:\t{0}", Scalars<T>.V_1);
                WriteLineFormat(tw, indent, "V_128:\t{0}", Scalars<T>.V_128);
                WriteLineFormat(tw, indent, "V_32768:\t{0}", Scalars<T>.V_32768);
                WriteLineFormat(tw, indent, "V_2147483648:\t{0}", Scalars<T>.V_2147483648);
            }
        }

        /// <summary>
        /// Run base - <see cref="Vectors{T}"/>
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        public static void RunInfoVectors<T>(TextWriter tw, string indent) where T:struct {
            tw.WriteLine(indent + string.Format("-- Vectors<{0}> (Count={1}) --", typeof(T).Name, Vector<T>.Count));
            if (ShowFull) {
                WriteLineFormat(tw, indent, "ElementByteSize:\t{0}", Vectors<T>.ElementByteSize);
            }
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vectors<T>.ElementSignBits, Vectors<T>.ElementExponentBits, Vectors<T>.ElementMantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vectors<T>.ElementSignShift, Vectors<T>.ElementExponentShift, Vectors<T>.ElementMantissaShift));
                WriteLineFormat(tw, indent, "ElementV0:\t{0}", Vectors<T>.ElementV0);
                WriteLineFormat(tw, indent, "ElementAllBitsSet:\t{0}", Vectors<T>.ElementAllBitsSet);
                WriteLineFormat(tw, indent, "ElementSignMask:\t{0}", Vectors<T>.ElementSignMask);
                WriteLineFormat(tw, indent, "ElementExponentMask:\t{0}", Vectors<T>.ElementExponentMask);
                WriteLineFormat(tw, indent, "ElementMantissaMask:\t{0}", Vectors<T>.ElementMantissaMask);
                WriteLineFormat(tw, indent, "ElementNonSignMask:\t{0}", Vectors<T>.ElementNonSignMask);
                WriteLineFormat(tw, indent, "ElementNonExponentMask:\t{0}", Vectors<T>.ElementNonExponentMask);
                WriteLineFormat(tw, indent, "ElementNonMantissaMask:\t{0}", Vectors<T>.ElementNonMantissaMask);
                WriteLineFormat(tw, indent, "ElementEpsilon:\t{0}", Vectors<T>.ElementEpsilon);
                WriteLineFormat(tw, indent, "ElementMaxValue:\t{0}", Vectors<T>.ElementMaxValue);
                WriteLineFormat(tw, indent, "ElementMinValue:\t{0}", Vectors<T>.ElementMinValue);
                WriteLineFormat(tw, indent, "ElementNaN:\t{0}", Vectors<T>.ElementNaN);
                WriteLineFormat(tw, indent, "ElementNegativeInfinity:\t{0}", Vectors<T>.ElementNegativeInfinity);
                WriteLineFormat(tw, indent, "ElementPositiveInfinity:\t{0}", Vectors<T>.ElementPositiveInfinity);
                WriteLineFormat(tw, indent, "AllBitsSet:\t{0}", Vectors<T>.AllBitsSet);
                WriteLineFormat(tw, indent, "SignMask:\t{0}", Vectors<T>.SignMask);
                WriteLineFormat(tw, indent, "ExponentMask:\t{0}", Vectors<T>.ExponentMask);
                WriteLineFormat(tw, indent, "MantissaMask:\t{0}", Vectors<T>.MantissaMask);
                WriteLineFormat(tw, indent, "NonSignMask:\t{0}", Vectors<T>.NonSignMask);
                WriteLineFormat(tw, indent, "NonExponentMask:\t{0}", Vectors<T>.NonExponentMask);
                WriteLineFormat(tw, indent, "NonMantissaMask:\t{0}", Vectors<T>.NonMantissaMask);
                WriteLineFormat(tw, indent, "Epsilon:\t{0}", Vectors<T>.Epsilon);
                WriteLineFormat(tw, indent, "MaxValue:\t{0}", Vectors<T>.MaxValue);
                WriteLineFormat(tw, indent, "MinValue:\t{0}", Vectors<T>.MinValue);
                WriteLineFormat(tw, indent, "NaN:\t{0}", Vectors<T>.NaN);
                WriteLineFormat(tw, indent, "NegativeInfinity:\t{0}", Vectors<T>.NegativeInfinity);
                WriteLineFormat(tw, indent, "PositiveInfinity:\t{0}", Vectors<T>.PositiveInfinity);
                WriteLineFormat(tw, indent, "E:\t{0}", Vectors<T>.E);
                WriteLineFormat(tw, indent, "Pi:\t{0}", Vectors<T>.Pi);
                WriteLineFormat(tw, indent, "Tau:\t{0}", Vectors<T>.Tau);
                WriteLineFormat(tw, indent, "V0:\t{0}", Vectors<T>.V0);
                WriteLineFormat(tw, indent, "V1:\t{0}", Vectors<T>.V1);
                WriteLineFormat(tw, indent, "V127:\t{0}", Vectors<T>.V127);
                WriteLineFormat(tw, indent, "V255:\t{0}", Vectors<T>.V255);
                WriteLineFormat(tw, indent, "V32767:\t{0}", Vectors<T>.V32767);
                WriteLineFormat(tw, indent, "V65535:\t{0}", Vectors<T>.V65535);
                WriteLineFormat(tw, indent, "V2147483647:\t{0}", Vectors<T>.V2147483647);
                WriteLineFormat(tw, indent, "V4294967295:\t{0}", Vectors<T>.V4294967295);
                WriteLineFormat(tw, indent, "V_1:\t{0}", Vectors<T>.V_1);
                WriteLineFormat(tw, indent, "V_128:\t{0}", Vectors<T>.V_128);
                WriteLineFormat(tw, indent, "V_32768:\t{0}", Vectors<T>.V_32768);
                WriteLineFormat(tw, indent, "V_2147483648:\t{0}", Vectors<T>.V_2147483648);
            }
            WriteLineFormat(tw, indent, "Serial:\t{0}", Vectors<T>.Serial);
            WriteLineFormat(tw, indent, "Demo:\t{0}", Vectors<T>.Demo);
            WriteLineFormat(tw, indent, "MaskBitPosSerial:\t{0}", Vectors<T>.MaskBitPosSerial);
            WriteLineFormat(tw, indent, "MaskBitsSerial:\t{0}", Vectors<T>.MaskBitsSerial);
            if (ShowFull) {
                WriteLineFormat(tw, indent, "InterlacedSign:\t{0}", Vectors<T>.InterlacedSign);
                WriteLineFormat(tw, indent, "InterlacedSignNegative:\t{0}", Vectors<T>.InterlacedSignNegative);
                WriteLineFormat(tw, indent, "MaskBits8:\t{0}", Vectors<T>.MaskBits8);
                WriteLineFormat(tw, indent, "MaskBits16:\t{0}", Vectors<T>.MaskBits16);
                WriteLineFormat(tw, indent, "MaskBits32:\t{0}", Vectors<T>.MaskBits32);
                WriteLineFormat(tw, indent, "XyXMask:\t{0}", Vectors<T>.XyXMask);
                WriteLineFormat(tw, indent, "XyYMask:\t{0}", Vectors<T>.XyYMask);
                WriteLineFormat(tw, indent, "XyzwXMask:\t{0}", Vectors<T>.XyzwXMask);
                WriteLineFormat(tw, indent, "XyzwYMask:\t{0}", Vectors<T>.XyzwYMask);
                WriteLineFormat(tw, indent, "XyzwZMask:\t{0}", Vectors<T>.XyzwZMask);
                WriteLineFormat(tw, indent, "XyzwWMask:\t{0}", Vectors<T>.XyzwWMask);
                WriteLineFormat(tw, indent, "XyzwNotXMask:\t{0}", Vectors<T>.XyzwNotXMask);
                WriteLineFormat(tw, indent, "XyzwNotYMask:\t{0}", Vectors<T>.XyzwNotYMask);
                WriteLineFormat(tw, indent, "XyzwNotZMask:\t{0}", Vectors<T>.XyzwNotZMask);
                WriteLineFormat(tw, indent, "XyzwNotWMask:\t{0}", Vectors<T>.XyzwNotWMask);
            }
        }

        /// <summary>
        /// Run base - <see cref="Vector64s{T}"/>
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        public static void RunInfoVector64s<T>(TextWriter tw, string indent) where T : struct {
            tw.WriteLine(indent + string.Format("-- Vector64s<{0}> (Count={1}) --", typeof(T).Name, Vector64<T>.Count));
            if (ShowFull) {
                WriteLineFormat(tw, indent, "ElementByteSize:\t{0}", Vector64s<T>.ElementByteSize);
            }
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vector64s<T>.ElementSignBits, Vector64s<T>.ElementExponentBits, Vector64s<T>.ElementMantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vector64s<T>.ElementSignShift, Vector64s<T>.ElementExponentShift, Vector64s<T>.ElementMantissaShift));
                WriteLineFormat(tw, indent, "ElementV0:\t{0}", Vector64s<T>.ElementV0);
                WriteLineFormat(tw, indent, "ElementAllBitsSet:\t{0}", Vector64s<T>.ElementAllBitsSet);
                WriteLineFormat(tw, indent, "ElementSignMask:\t{0}", Vector64s<T>.ElementSignMask);
                WriteLineFormat(tw, indent, "ElementExponentMask:\t{0}", Vector64s<T>.ElementExponentMask);
                WriteLineFormat(tw, indent, "ElementMantissaMask:\t{0}", Vector64s<T>.ElementMantissaMask);
                WriteLineFormat(tw, indent, "ElementNonSignMask:\t{0}", Vector64s<T>.ElementNonSignMask);
                WriteLineFormat(tw, indent, "ElementNonExponentMask:\t{0}", Vector64s<T>.ElementNonExponentMask);
                WriteLineFormat(tw, indent, "ElementNonMantissaMask:\t{0}", Vector64s<T>.ElementNonMantissaMask);
                WriteLineFormat(tw, indent, "ElementEpsilon:\t{0}", Vector64s<T>.ElementEpsilon);
                WriteLineFormat(tw, indent, "ElementMaxValue:\t{0}", Vector64s<T>.ElementMaxValue);
                WriteLineFormat(tw, indent, "ElementMinValue:\t{0}", Vector64s<T>.ElementMinValue);
                WriteLineFormat(tw, indent, "ElementNaN:\t{0}", Vector64s<T>.ElementNaN);
                WriteLineFormat(tw, indent, "ElementNegativeInfinity:\t{0}", Vector64s<T>.ElementNegativeInfinity);
                WriteLineFormat(tw, indent, "ElementPositiveInfinity:\t{0}", Vector64s<T>.ElementPositiveInfinity);
                WriteLineFormat(tw, indent, "AllBitsSet:\t{0}", Vector64s<T>.AllBitsSet);
                WriteLineFormat(tw, indent, "SignMask:\t{0}", Vector64s<T>.SignMask);
                WriteLineFormat(tw, indent, "ExponentMask:\t{0}", Vector64s<T>.ExponentMask);
                WriteLineFormat(tw, indent, "MantissaMask:\t{0}", Vector64s<T>.MantissaMask);
                WriteLineFormat(tw, indent, "NonSignMask:\t{0}", Vector64s<T>.NonSignMask);
                WriteLineFormat(tw, indent, "NonExponentMask:\t{0}", Vector64s<T>.NonExponentMask);
                WriteLineFormat(tw, indent, "NonMantissaMask:\t{0}", Vector64s<T>.NonMantissaMask);
                WriteLineFormat(tw, indent, "Epsilon:\t{0}", Vector64s<T>.Epsilon);
                WriteLineFormat(tw, indent, "MaxValue:\t{0}", Vector64s<T>.MaxValue);
                WriteLineFormat(tw, indent, "MinValue:\t{0}", Vector64s<T>.MinValue);
                WriteLineFormat(tw, indent, "NaN:\t{0}", Vector64s<T>.NaN);
                WriteLineFormat(tw, indent, "NegativeInfinity:\t{0}", Vector64s<T>.NegativeInfinity);
                WriteLineFormat(tw, indent, "PositiveInfinity:\t{0}", Vector64s<T>.PositiveInfinity);
                WriteLineFormat(tw, indent, "E:\t{0}", Vector64s<T>.E);
                WriteLineFormat(tw, indent, "Pi:\t{0}", Vector64s<T>.Pi);
                WriteLineFormat(tw, indent, "Tau:\t{0}", Vector64s<T>.Tau);
                WriteLineFormat(tw, indent, "V0:\t{0}", Vector64s<T>.V0);
                WriteLineFormat(tw, indent, "V1:\t{0}", Vector64s<T>.V1);
                WriteLineFormat(tw, indent, "V127:\t{0}", Vector64s<T>.V127);
                WriteLineFormat(tw, indent, "V255:\t{0}", Vector64s<T>.V255);
                WriteLineFormat(tw, indent, "V32767:\t{0}", Vector64s<T>.V32767);
                WriteLineFormat(tw, indent, "V65535:\t{0}", Vector64s<T>.V65535);
                WriteLineFormat(tw, indent, "V2147483647:\t{0}", Vector64s<T>.V2147483647);
                WriteLineFormat(tw, indent, "V4294967295:\t{0}", Vector64s<T>.V4294967295);
                WriteLineFormat(tw, indent, "V_1:\t{0}", Vector64s<T>.V_1);
                WriteLineFormat(tw, indent, "V_128:\t{0}", Vector64s<T>.V_128);
                WriteLineFormat(tw, indent, "V_32768:\t{0}", Vector64s<T>.V_32768);
                WriteLineFormat(tw, indent, "V_2147483648:\t{0}", Vector64s<T>.V_2147483648);
            }
            WriteLineFormat(tw, indent, "Serial:\t{0}", Vector64s<T>.Serial);
            WriteLineFormat(tw, indent, "Demo:\t{0}", Vector64s<T>.Demo);
            WriteLineFormat(tw, indent, "MaskBitPosSerial:\t{0}", Vector64s<T>.MaskBitPosSerial);
            WriteLineFormat(tw, indent, "MaskBitsSerial:\t{0}", Vector64s<T>.MaskBitsSerial);
            if (ShowFull) {
                WriteLineFormat(tw, indent, "InterlacedSign:\t{0}", Vector64s<T>.InterlacedSign);
                WriteLineFormat(tw, indent, "InterlacedSignNegative:\t{0}", Vector64s<T>.InterlacedSignNegative);
                WriteLineFormat(tw, indent, "MaskBits8:\t{0}", Vectors<T>.MaskBits8);
                WriteLineFormat(tw, indent, "MaskBits16:\t{0}", Vectors<T>.MaskBits16);
                WriteLineFormat(tw, indent, "MaskBits32:\t{0}", Vectors<T>.MaskBits32);
                WriteLineFormat(tw, indent, "XyXMask:\t{0}", Vector64s<T>.XyXMask);
                WriteLineFormat(tw, indent, "XyYMask:\t{0}", Vector64s<T>.XyYMask);
                WriteLineFormat(tw, indent, "XyzwXMask:\t{0}", Vector64s<T>.XyzwXMask);
                WriteLineFormat(tw, indent, "XyzwYMask:\t{0}", Vector64s<T>.XyzwYMask);
                WriteLineFormat(tw, indent, "XyzwZMask:\t{0}", Vector64s<T>.XyzwZMask);
                WriteLineFormat(tw, indent, "XyzwWMask:\t{0}", Vector64s<T>.XyzwWMask);
                WriteLineFormat(tw, indent, "XyzwNotXMask:\t{0}", Vector64s<T>.XyzwNotXMask);
                WriteLineFormat(tw, indent, "XyzwNotYMask:\t{0}", Vector64s<T>.XyzwNotYMask);
                WriteLineFormat(tw, indent, "XyzwNotZMask:\t{0}", Vector64s<T>.XyzwNotZMask);
                WriteLineFormat(tw, indent, "XyzwNotWMask:\t{0}", Vector64s<T>.XyzwNotWMask);
            }
        }

        /// <summary>
        /// Run base - <see cref="Vector128s{T}"/>
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        public static void RunInfoVector128s<T>(TextWriter tw, string indent) where T : struct {
            tw.WriteLine(indent + string.Format("-- Vector128s<{0}> (Count={1}) --", typeof(T).Name, Vector128<T>.Count));
            if (ShowFull) {
                WriteLineFormat(tw, indent, "ElementByteSize:\t{0}", Vector128s<T>.ElementByteSize);
            }
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vector128s<T>.ElementSignBits, Vector128s<T>.ElementExponentBits, Vector128s<T>.ElementMantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vector128s<T>.ElementSignShift, Vector128s<T>.ElementExponentShift, Vector128s<T>.ElementMantissaShift));
                WriteLineFormat(tw, indent, "ElementV0:\t{0}", Vector128s<T>.ElementV0);
                WriteLineFormat(tw, indent, "ElementAllBitsSet:\t{0}", Vector128s<T>.ElementAllBitsSet);
                WriteLineFormat(tw, indent, "ElementSignMask:\t{0}", Vector128s<T>.ElementSignMask);
                WriteLineFormat(tw, indent, "ElementExponentMask:\t{0}", Vector128s<T>.ElementExponentMask);
                WriteLineFormat(tw, indent, "ElementMantissaMask:\t{0}", Vector128s<T>.ElementMantissaMask);
                WriteLineFormat(tw, indent, "ElementNonSignMask:\t{0}", Vector128s<T>.ElementNonSignMask);
                WriteLineFormat(tw, indent, "ElementNonExponentMask:\t{0}", Vector128s<T>.ElementNonExponentMask);
                WriteLineFormat(tw, indent, "ElementNonMantissaMask:\t{0}", Vector128s<T>.ElementNonMantissaMask);
                WriteLineFormat(tw, indent, "ElementEpsilon:\t{0}", Vector128s<T>.ElementEpsilon);
                WriteLineFormat(tw, indent, "ElementMaxValue:\t{0}", Vector128s<T>.ElementMaxValue);
                WriteLineFormat(tw, indent, "ElementMinValue:\t{0}", Vector128s<T>.ElementMinValue);
                WriteLineFormat(tw, indent, "ElementNaN:\t{0}", Vector128s<T>.ElementNaN);
                WriteLineFormat(tw, indent, "ElementNegativeInfinity:\t{0}", Vector128s<T>.ElementNegativeInfinity);
                WriteLineFormat(tw, indent, "ElementPositiveInfinity:\t{0}", Vector128s<T>.ElementPositiveInfinity);
                WriteLineFormat(tw, indent, "AllBitsSet:\t{0}", Vector128s<T>.AllBitsSet);
                WriteLineFormat(tw, indent, "SignMask:\t{0}", Vector128s<T>.SignMask);
                WriteLineFormat(tw, indent, "ExponentMask:\t{0}", Vector128s<T>.ExponentMask);
                WriteLineFormat(tw, indent, "MantissaMask:\t{0}", Vector128s<T>.MantissaMask);
                WriteLineFormat(tw, indent, "NonSignMask:\t{0}", Vector128s<T>.NonSignMask);
                WriteLineFormat(tw, indent, "NonExponentMask:\t{0}", Vector128s<T>.NonExponentMask);
                WriteLineFormat(tw, indent, "NonMantissaMask:\t{0}", Vector128s<T>.NonMantissaMask);
                WriteLineFormat(tw, indent, "Epsilon:\t{0}", Vector128s<T>.Epsilon);
                WriteLineFormat(tw, indent, "MaxValue:\t{0}", Vector128s<T>.MaxValue);
                WriteLineFormat(tw, indent, "MinValue:\t{0}", Vector128s<T>.MinValue);
                WriteLineFormat(tw, indent, "NaN:\t{0}", Vector128s<T>.NaN);
                WriteLineFormat(tw, indent, "NegativeInfinity:\t{0}", Vector128s<T>.NegativeInfinity);
                WriteLineFormat(tw, indent, "PositiveInfinity:\t{0}", Vector128s<T>.PositiveInfinity);
                WriteLineFormat(tw, indent, "E:\t{0}", Vector128s<T>.E);
                WriteLineFormat(tw, indent, "Pi:\t{0}", Vector128s<T>.Pi);
                WriteLineFormat(tw, indent, "Tau:\t{0}", Vector128s<T>.Tau);
                WriteLineFormat(tw, indent, "V0:\t{0}", Vector128s<T>.V0);
                WriteLineFormat(tw, indent, "V1:\t{0}", Vector128s<T>.V1);
                WriteLineFormat(tw, indent, "V127:\t{0}", Vector128s<T>.V127);
                WriteLineFormat(tw, indent, "V255:\t{0}", Vector128s<T>.V255);
                WriteLineFormat(tw, indent, "V32767:\t{0}", Vector128s<T>.V32767);
                WriteLineFormat(tw, indent, "V65535:\t{0}", Vector128s<T>.V65535);
                WriteLineFormat(tw, indent, "V2147483647:\t{0}", Vector128s<T>.V2147483647);
                WriteLineFormat(tw, indent, "V4294967295:\t{0}", Vector128s<T>.V4294967295);
                WriteLineFormat(tw, indent, "V_1:\t{0}", Vector128s<T>.V_1);
                WriteLineFormat(tw, indent, "V_128:\t{0}", Vector128s<T>.V_128);
                WriteLineFormat(tw, indent, "V_32768:\t{0}", Vector128s<T>.V_32768);
                WriteLineFormat(tw, indent, "V_2147483648:\t{0}", Vector128s<T>.V_2147483648);
            }
            WriteLineFormat(tw, indent, "Serial:\t{0}", Vector128s<T>.Serial);
            WriteLineFormat(tw, indent, "Demo:\t{0}", Vector128s<T>.Demo);
            WriteLineFormat(tw, indent, "MaskBitPosSerial:\t{0}", Vector128s<T>.MaskBitPosSerial);
            WriteLineFormat(tw, indent, "MaskBitsSerial:\t{0}", Vector128s<T>.MaskBitsSerial);
            if (ShowFull) {
                WriteLineFormat(tw, indent, "InterlacedSign:\t{0}", Vector128s<T>.InterlacedSign);
                WriteLineFormat(tw, indent, "InterlacedSignNegative:\t{0}", Vector128s<T>.InterlacedSignNegative);
                WriteLineFormat(tw, indent, "MaskBits8:\t{0}", Vectors<T>.MaskBits8);
                WriteLineFormat(tw, indent, "MaskBits16:\t{0}", Vectors<T>.MaskBits16);
                WriteLineFormat(tw, indent, "MaskBits32:\t{0}", Vectors<T>.MaskBits32);
                WriteLineFormat(tw, indent, "XyXMask:\t{0}", Vector128s<T>.XyXMask);
                WriteLineFormat(tw, indent, "XyYMask:\t{0}", Vector128s<T>.XyYMask);
                WriteLineFormat(tw, indent, "XyzwXMask:\t{0}", Vector128s<T>.XyzwXMask);
                WriteLineFormat(tw, indent, "XyzwYMask:\t{0}", Vector128s<T>.XyzwYMask);
                WriteLineFormat(tw, indent, "XyzwZMask:\t{0}", Vector128s<T>.XyzwZMask);
                WriteLineFormat(tw, indent, "XyzwWMask:\t{0}", Vector128s<T>.XyzwWMask);
                WriteLineFormat(tw, indent, "XyzwNotXMask:\t{0}", Vector128s<T>.XyzwNotXMask);
                WriteLineFormat(tw, indent, "XyzwNotYMask:\t{0}", Vector128s<T>.XyzwNotYMask);
                WriteLineFormat(tw, indent, "XyzwNotZMask:\t{0}", Vector128s<T>.XyzwNotZMask);
                WriteLineFormat(tw, indent, "XyzwNotWMask:\t{0}", Vector128s<T>.XyzwNotWMask);
            }
        }

        /// <summary>
        /// Run base - <see cref="Vector256s{T}"/>
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        public static void RunInfoVector256s<T>(TextWriter tw, string indent) where T : struct {
            tw.WriteLine(indent + string.Format("-- Vector256s<{0}> (Count={1}) --", typeof(T).Name, Vector256<T>.Count));
            if (ShowFull) {
                WriteLineFormat(tw, indent, "ElementByteSize:\t{0}", Vector256s<T>.ElementByteSize);
            }
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vector256s<T>.ElementSignBits, Vector256s<T>.ElementExponentBits, Vector256s<T>.ElementMantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vector256s<T>.ElementSignShift, Vector256s<T>.ElementExponentShift, Vector256s<T>.ElementMantissaShift));
                WriteLineFormat(tw, indent, "ElementV0:\t{0}", Vector256s<T>.ElementV0);
                WriteLineFormat(tw, indent, "ElementAllBitsSet:\t{0}", Vector256s<T>.ElementAllBitsSet);
                WriteLineFormat(tw, indent, "ElementSignMask:\t{0}", Vector256s<T>.ElementSignMask);
                WriteLineFormat(tw, indent, "ElementExponentMask:\t{0}", Vector256s<T>.ElementExponentMask);
                WriteLineFormat(tw, indent, "ElementMantissaMask:\t{0}", Vector256s<T>.ElementMantissaMask);
                WriteLineFormat(tw, indent, "ElementNonSignMask:\t{0}", Vector256s<T>.ElementNonSignMask);
                WriteLineFormat(tw, indent, "ElementNonExponentMask:\t{0}", Vector256s<T>.ElementNonExponentMask);
                WriteLineFormat(tw, indent, "ElementNonMantissaMask:\t{0}", Vector256s<T>.ElementNonMantissaMask);
                WriteLineFormat(tw, indent, "ElementEpsilon:\t{0}", Vector256s<T>.ElementEpsilon);
                WriteLineFormat(tw, indent, "ElementMaxValue:\t{0}", Vector256s<T>.ElementMaxValue);
                WriteLineFormat(tw, indent, "ElementMinValue:\t{0}", Vector256s<T>.ElementMinValue);
                WriteLineFormat(tw, indent, "ElementNaN:\t{0}", Vector256s<T>.ElementNaN);
                WriteLineFormat(tw, indent, "ElementNegativeInfinity:\t{0}", Vector256s<T>.ElementNegativeInfinity);
                WriteLineFormat(tw, indent, "ElementPositiveInfinity:\t{0}", Vector256s<T>.ElementPositiveInfinity);
                WriteLineFormat(tw, indent, "AllBitsSet:\t{0}", Vector256s<T>.AllBitsSet);
                WriteLineFormat(tw, indent, "SignMask:\t{0}", Vector256s<T>.SignMask);
                WriteLineFormat(tw, indent, "ExponentMask:\t{0}", Vector256s<T>.ExponentMask);
                WriteLineFormat(tw, indent, "MantissaMask:\t{0}", Vector256s<T>.MantissaMask);
                WriteLineFormat(tw, indent, "NonSignMask:\t{0}", Vector256s<T>.NonSignMask);
                WriteLineFormat(tw, indent, "NonExponentMask:\t{0}", Vector256s<T>.NonExponentMask);
                WriteLineFormat(tw, indent, "NonMantissaMask:\t{0}", Vector256s<T>.NonMantissaMask);
                WriteLineFormat(tw, indent, "Epsilon:\t{0}", Vector256s<T>.Epsilon);
                WriteLineFormat(tw, indent, "MaxValue:\t{0}", Vector256s<T>.MaxValue);
                WriteLineFormat(tw, indent, "MinValue:\t{0}", Vector256s<T>.MinValue);
                WriteLineFormat(tw, indent, "NaN:\t{0}", Vector256s<T>.NaN);
                WriteLineFormat(tw, indent, "NegativeInfinity:\t{0}", Vector256s<T>.NegativeInfinity);
                WriteLineFormat(tw, indent, "PositiveInfinity:\t{0}", Vector256s<T>.PositiveInfinity);
                WriteLineFormat(tw, indent, "E:\t{0}", Vector256s<T>.E);
                WriteLineFormat(tw, indent, "Pi:\t{0}", Vector256s<T>.Pi);
                WriteLineFormat(tw, indent, "Tau:\t{0}", Vector256s<T>.Tau);
                WriteLineFormat(tw, indent, "V0:\t{0}", Vector256s<T>.V0);
                WriteLineFormat(tw, indent, "V1:\t{0}", Vector256s<T>.V1);
                WriteLineFormat(tw, indent, "V127:\t{0}", Vector256s<T>.V127);
                WriteLineFormat(tw, indent, "V255:\t{0}", Vector256s<T>.V255);
                WriteLineFormat(tw, indent, "V32767:\t{0}", Vector256s<T>.V32767);
                WriteLineFormat(tw, indent, "V65535:\t{0}", Vector256s<T>.V65535);
                WriteLineFormat(tw, indent, "V2147483647:\t{0}", Vector256s<T>.V2147483647);
                WriteLineFormat(tw, indent, "V4294967295:\t{0}", Vector256s<T>.V4294967295);
                WriteLineFormat(tw, indent, "V_1:\t{0}", Vector256s<T>.V_1);
                WriteLineFormat(tw, indent, "V_128:\t{0}", Vector256s<T>.V_128);
                WriteLineFormat(tw, indent, "V_32768:\t{0}", Vector256s<T>.V_32768);
                WriteLineFormat(tw, indent, "V_2147483648:\t{0}", Vector256s<T>.V_2147483648);
            }
            WriteLineFormat(tw, indent, "Serial:\t{0}", Vector256s<T>.Serial);
            WriteLineFormat(tw, indent, "Demo:\t{0}", Vector256s<T>.Demo);
            WriteLineFormat(tw, indent, "MaskBitPosSerial:\t{0}", Vector256s<T>.MaskBitPosSerial);
            WriteLineFormat(tw, indent, "MaskBitsSerial:\t{0}", Vector256s<T>.MaskBitsSerial);
            if (ShowFull) {
                WriteLineFormat(tw, indent, "InterlacedSign:\t{0}", Vector256s<T>.InterlacedSign);
                WriteLineFormat(tw, indent, "InterlacedSignNegative:\t{0}", Vector256s<T>.InterlacedSignNegative);
                WriteLineFormat(tw, indent, "MaskBits8:\t{0}", Vectors<T>.MaskBits8);
                WriteLineFormat(tw, indent, "MaskBits16:\t{0}", Vectors<T>.MaskBits16);
                WriteLineFormat(tw, indent, "MaskBits32:\t{0}", Vectors<T>.MaskBits32);
                WriteLineFormat(tw, indent, "XyXMask:\t{0}", Vector256s<T>.XyXMask);
                WriteLineFormat(tw, indent, "XyYMask:\t{0}", Vector256s<T>.XyYMask);
                WriteLineFormat(tw, indent, "XyzwXMask:\t{0}", Vector256s<T>.XyzwXMask);
                WriteLineFormat(tw, indent, "XyzwYMask:\t{0}", Vector256s<T>.XyzwYMask);
                WriteLineFormat(tw, indent, "XyzwZMask:\t{0}", Vector256s<T>.XyzwZMask);
                WriteLineFormat(tw, indent, "XyzwWMask:\t{0}", Vector256s<T>.XyzwWMask);
                WriteLineFormat(tw, indent, "XyzwNotXMask:\t{0}", Vector256s<T>.XyzwNotXMask);
                WriteLineFormat(tw, indent, "XyzwNotYMask:\t{0}", Vector256s<T>.XyzwNotYMask);
                WriteLineFormat(tw, indent, "XyzwNotZMask:\t{0}", Vector256s<T>.XyzwNotZMask);
                WriteLineFormat(tw, indent, "XyzwNotWMask:\t{0}", Vector256s<T>.XyzwNotWMask);
            }
        }

    }
}
