using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
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

        #region Fields
        // src0: Element value is 0.
        private static readonly Vector64<float> src0_64_float = Vector64.Create((float)0);
        private static readonly Vector128<float> src0_128_float = Vector128.Create((float)0);
        private static readonly Vector256<float> src0_256_float = Vector256.Create((float)0);
        private static readonly Vector64<double> src0_64_double = Vector64.Create((double)0);
        private static readonly Vector128<double> src0_128_double = Vector128.Create((double)0);
        private static readonly Vector256<double> src0_256_double = Vector256.Create((double)0);
        private static readonly Vector64<sbyte> src0_64_sbyte = Vector64.Create((sbyte)0);
        private static readonly Vector128<sbyte> src0_128_sbyte = Vector128.Create((sbyte)0);
        private static readonly Vector256<sbyte> src0_256_sbyte = Vector256.Create((sbyte)0);
        private static readonly Vector64<short> src0_64_short = Vector64.Create((short)0);
        private static readonly Vector128<short> src0_128_short = Vector128.Create((short)0);
        private static readonly Vector256<short> src0_256_short = Vector256.Create((short)0);
        private static readonly Vector64<int> src0_64_int = Vector64.Create((int)0);
        private static readonly Vector128<int> src0_128_int = Vector128.Create((int)0);
        private static readonly Vector256<int> src0_256_int = Vector256.Create((int)0);
        private static readonly Vector64<long> src0_64_long = Vector64.Create((long)0);
        private static readonly Vector128<long> src0_128_long = Vector128.Create((long)0);
        private static readonly Vector256<long> src0_256_long = Vector256.Create((long)0);
        private static readonly Vector64<byte> src0_64_byte = Vector64.Create((byte)0);
        private static readonly Vector128<byte> src0_128_byte = Vector128.Create((byte)0);
        private static readonly Vector256<byte> src0_256_byte = Vector256.Create((byte)0);
        private static readonly Vector64<ushort> src0_64_ushort = Vector64.Create((ushort)0);
        private static readonly Vector128<ushort> src0_128_ushort = Vector128.Create((ushort)0);
        private static readonly Vector256<ushort> src0_256_ushort = Vector256.Create((ushort)0);
        private static readonly Vector64<uint> src0_64_uint = Vector64.Create((uint)0);
        private static readonly Vector128<uint> src0_128_uint = Vector128.Create((uint)0);
        private static readonly Vector256<uint> src0_256_uint = Vector256.Create((uint)0);
        private static readonly Vector64<ulong> src0_64_ulong = Vector64.Create((ulong)0);
        private static readonly Vector128<ulong> src0_128_ulong = Vector128.Create((ulong)0);
        private static readonly Vector256<ulong> src0_256_ulong = Vector256.Create((ulong)0);

        // src1: Element value is 1.
        private static readonly Vector64<float> src1_64_float = Vector64.Create((float)1);
        private static readonly Vector128<float> src1_128_float = Vector128.Create((float)1);
        private static readonly Vector256<float> src1_256_float = Vector256.Create((float)1);
        private static readonly Vector64<double> src1_64_double = Vector64.Create((double)1);
        private static readonly Vector128<double> src1_128_double = Vector128.Create((double)1);
        private static readonly Vector256<double> src1_256_double = Vector256.Create((double)1);
        private static readonly Vector64<sbyte> src1_64_sbyte = Vector64.Create((sbyte)1);
        private static readonly Vector128<sbyte> src1_128_sbyte = Vector128.Create((sbyte)1);
        private static readonly Vector256<sbyte> src1_256_sbyte = Vector256.Create((sbyte)1);
        private static readonly Vector64<short> src1_64_short = Vector64.Create((short)1);
        private static readonly Vector128<short> src1_128_short = Vector128.Create((short)1);
        private static readonly Vector256<short> src1_256_short = Vector256.Create((short)1);
        private static readonly Vector64<int> src1_64_int = Vector64.Create((int)1);
        private static readonly Vector128<int> src1_128_int = Vector128.Create((int)1);
        private static readonly Vector256<int> src1_256_int = Vector256.Create((int)1);
        private static readonly Vector64<long> src1_64_long = Vector64.Create((long)1);
        private static readonly Vector128<long> src1_128_long = Vector128.Create((long)1);
        private static readonly Vector256<long> src1_256_long = Vector256.Create((long)1);
        private static readonly Vector64<byte> src1_64_byte = Vector64.Create((byte)1);
        private static readonly Vector128<byte> src1_128_byte = Vector128.Create((byte)1);
        private static readonly Vector256<byte> src1_256_byte = Vector256.Create((byte)1);
        private static readonly Vector64<ushort> src1_64_ushort = Vector64.Create((ushort)1);
        private static readonly Vector128<ushort> src1_128_ushort = Vector128.Create((ushort)1);
        private static readonly Vector256<ushort> src1_256_ushort = Vector256.Create((ushort)1);
        private static readonly Vector64<uint> src1_64_uint = Vector64.Create((uint)1);
        private static readonly Vector128<uint> src1_128_uint = Vector128.Create((uint)1);
        private static readonly Vector256<uint> src1_256_uint = Vector256.Create((uint)1);
        private static readonly Vector64<ulong> src1_64_ulong = Vector64.Create((ulong)1);
        private static readonly Vector128<ulong> src1_128_ulong = Vector128.Create((ulong)1);
        private static readonly Vector256<ulong> src1_256_ulong = Vector256.Create((ulong)1);

        // src2: Element value is 2.
        private static readonly Vector64<float> src2_64_float = Vector64.Create((float)2);
        private static readonly Vector128<float> src2_128_float = Vector128.Create((float)2);
        private static readonly Vector256<float> src2_256_float = Vector256.Create((float)2);
        private static readonly Vector64<double> src2_64_double = Vector64.Create((double)2);
        private static readonly Vector128<double> src2_128_double = Vector128.Create((double)2);
        private static readonly Vector256<double> src2_256_double = Vector256.Create((double)2);
        private static readonly Vector64<sbyte> src2_64_sbyte = Vector64.Create((sbyte)2);
        private static readonly Vector128<sbyte> src2_128_sbyte = Vector128.Create((sbyte)2);
        private static readonly Vector256<sbyte> src2_256_sbyte = Vector256.Create((sbyte)2);
        private static readonly Vector64<short> src2_64_short = Vector64.Create((short)2);
        private static readonly Vector128<short> src2_128_short = Vector128.Create((short)2);
        private static readonly Vector256<short> src2_256_short = Vector256.Create((short)2);
        private static readonly Vector64<int> src2_64_int = Vector64.Create((int)2);
        private static readonly Vector128<int> src2_128_int = Vector128.Create((int)2);
        private static readonly Vector256<int> src2_256_int = Vector256.Create((int)2);
        private static readonly Vector64<long> src2_64_long = Vector64.Create((long)2);
        private static readonly Vector128<long> src2_128_long = Vector128.Create((long)2);
        private static readonly Vector256<long> src2_256_long = Vector256.Create((long)2);
        private static readonly Vector64<byte> src2_64_byte = Vector64.Create((byte)2);
        private static readonly Vector128<byte> src2_128_byte = Vector128.Create((byte)2);
        private static readonly Vector256<byte> src2_256_byte = Vector256.Create((byte)2);
        private static readonly Vector64<ushort> src2_64_ushort = Vector64.Create((ushort)2);
        private static readonly Vector128<ushort> src2_128_ushort = Vector128.Create((ushort)2);
        private static readonly Vector256<ushort> src2_256_ushort = Vector256.Create((ushort)2);
        private static readonly Vector64<uint> src2_64_uint = Vector64.Create((uint)2);
        private static readonly Vector128<uint> src2_128_uint = Vector128.Create((uint)2);
        private static readonly Vector256<uint> src2_256_uint = Vector256.Create((uint)2);
        private static readonly Vector64<ulong> src2_64_ulong = Vector64.Create((ulong)2);
        private static readonly Vector128<ulong> src2_128_ulong = Vector128.Create((ulong)2);
        private static readonly Vector256<ulong> src2_256_ulong = Vector256.Create((ulong)2);

        // srcT: Element value is traits.
        private static readonly Vector64<float> srcT_64_float = Vector64.Create(-1.2f, 0f);
        private static readonly Vector128<float> srcT_128_float = Vector128.Create(float.MinValue, float.PositiveInfinity, -1.2f, 0f);
        private static readonly Vector256<float> srcT_256_float = Vector256.Create(float.MinValue, float.PositiveInfinity, float.NaN, -1.2f, 0f, 1f, 2f, 4f);
        private static readonly Vector64<double> srcT_64_double = Vector64.Create(-1.2);
        private static readonly Vector128<double> srcT_128_double = Vector128.Create(-1.2, 0);
        private static readonly Vector256<double> srcT_256_double = Vector256.Create(double.MinValue, double.PositiveInfinity, -1.2, 0);
        private static readonly Vector64<sbyte> srcT_64_sbyte = Vector64.Create(sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64);
        private static readonly Vector128<sbyte> srcT_128_sbyte = Vector128.Create(sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64, sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64);
        private static readonly Vector256<sbyte> srcT_256_sbyte = Vector256.Create(sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64, sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64, sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64, sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64);
        private static readonly Vector64<short> srcT_64_short = Vector64.Create(short.MinValue, short.MaxValue, -1, 0);
        private static readonly Vector128<short> srcT_128_short = Vector128.Create(short.MinValue, short.MaxValue, -1, 0, 1, 2, 3, 16384);
        private static readonly Vector256<short> srcT_256_short = Vector256.Create(short.MinValue, short.MaxValue, -1, 0, 1, 2, 3, 16384, short.MinValue, short.MaxValue, -1, 0, 1, 2, 3, 16384);
        private static readonly Vector64<int> srcT_64_int = Vector64.Create(int.MinValue, 0);
        private static readonly Vector128<int> srcT_128_int = Vector128.Create(int.MinValue, int.MaxValue, -1, 0);
        private static readonly Vector256<int> srcT_256_int = Vector256.Create(int.MinValue, int.MaxValue, -1, 0, 1, 2, 3, 32768);
        private static readonly Vector64<long> srcT_64_long = Vector64.Create(long.MinValue);
        private static readonly Vector128<long> srcT_128_long = Vector128.Create(long.MinValue, 0);
        private static readonly Vector256<long> srcT_256_long = Vector256.Create(long.MinValue, long.MaxValue, -1, 0);
        private static readonly Vector64<byte> srcT_64_byte = Vector64.Create(byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128);
        private static readonly Vector128<byte> srcT_128_byte = Vector128.Create(byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128, byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128);
        private static readonly Vector256<byte> srcT_256_byte = Vector256.Create(byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128, byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128, byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128, byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128);
        private static readonly Vector64<ushort> srcT_64_ushort = Vector64.Create(ushort.MinValue, ushort.MaxValue, 0, 1);
        private static readonly Vector128<ushort> srcT_128_ushort = Vector128.Create(ushort.MinValue, ushort.MaxValue, 0, 1, 2, 3, 4, 32768);
        private static readonly Vector256<ushort> srcT_256_ushort = Vector256.Create(ushort.MinValue, ushort.MaxValue, 0, 1, 2, 3, 4, 32768, ushort.MinValue, ushort.MaxValue, 0, 1, 2, 3, 4, 32768);
        private static readonly Vector64<uint> srcT_64_uint = Vector64.Create(uint.MaxValue, 0);
        private static readonly Vector128<uint> srcT_128_uint = Vector128.Create(uint.MinValue, uint.MaxValue, 0, 1);
        private static readonly Vector256<uint> srcT_256_uint = Vector256.Create(uint.MinValue, uint.MaxValue, 0, 1, 2, 3, 4, 65536);
        private static readonly Vector64<ulong> srcT_64_ulong = Vector64.Create(ulong.MaxValue);
        private static readonly Vector128<ulong> srcT_128_ulong = Vector128.Create(ulong.MaxValue, 0);
        private static readonly Vector256<ulong> srcT_256_ulong = Vector256.Create(ulong.MinValue, ulong.MaxValue, 0, 1);

        // srcQ: Element value is sequential.
        private static readonly Vector64<float> srcQ_64_float = Vector64.Create(0f, 1f);
        private static readonly Vector128<float> srcQ_128_float = Vector128.Create(0f, 1f, 2f, 3f);
        private static readonly Vector256<float> srcQ_256_float = Vector256.Create(0f, 1f, 2f, 3f, 4f, 5f, 6f, 7f);
        private static readonly Vector64<double> srcQ_64_double = Vector64.Create(0.0);
        private static readonly Vector128<double> srcQ_128_double = Vector128.Create(0.0, 1.0);
        private static readonly Vector256<double> srcQ_256_double = Vector256.Create(0.0, 1.0, 2.0, 3.0);
        private static readonly Vector64<sbyte> srcQ_64_sbyte = Vector64.Create((sbyte)0, 1, 2, 3, 4, 5, 6, 7);
        private static readonly Vector128<sbyte> srcQ_128_sbyte = Vector128.Create((sbyte)0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        private static readonly Vector256<sbyte> srcQ_256_sbyte = Vector256.Create((sbyte)0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31);
        private static readonly Vector64<short> srcQ_64_short = Vector64.Create((short)0, 1, 2, 3);
        private static readonly Vector128<short> srcQ_128_short = Vector128.Create((short)0, 1, 2, 3, 4, 5, 6, 7);
        private static readonly Vector256<short> srcQ_256_short = Vector256.Create((short)0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        private static readonly Vector64<int> srcQ_64_int = Vector64.Create((int)0, 1);
        private static readonly Vector128<int> srcQ_128_int = Vector128.Create((int)0, 1, 2, 3);
        private static readonly Vector256<int> srcQ_256_int = Vector256.Create((int)0, 1, 2, 3, 4, 5, 6, 7);
        private static readonly Vector64<long> srcQ_64_long = Vector64.Create((long)0);
        private static readonly Vector128<long> srcQ_128_long = Vector128.Create((long)0, 1);
        private static readonly Vector256<long> srcQ_256_long = Vector256.Create((long)0, 1, 2, 3);
        private static readonly Vector64<byte> srcQ_64_byte = Vector64.Create((byte)0, 1, 2, 3, 4, 5, 6, 7);
        private static readonly Vector128<byte> srcQ_128_byte = Vector128.Create((byte)0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        private static readonly Vector256<byte> srcQ_256_byte = Vector256.Create((byte)0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31);
        private static readonly Vector64<ushort> srcQ_64_ushort = Vector64.Create((ushort)0, 1, 2, 3);
        private static readonly Vector128<ushort> srcQ_128_ushort = Vector128.Create((ushort)0, 1, 2, 3, 4, 5, 6, 7);
        private static readonly Vector256<ushort> srcQ_256_ushort = Vector256.Create((ushort)0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15);
        private static readonly Vector64<uint> srcQ_64_uint = Vector64.Create((uint)0, 1);
        private static readonly Vector128<uint> srcQ_128_uint = Vector128.Create((uint)0, 1, 2, 3);
        private static readonly Vector256<uint> srcQ_256_uint = Vector256.Create((uint)0, 1, 2, 3, 4, 5, 6, 7);
        private static readonly Vector64<ulong> srcQ_64_ulong = Vector64.Create((ulong)0);
        private static readonly Vector128<ulong> srcQ_128_ulong = Vector128.Create((ulong)0, 1);
        private static readonly Vector256<ulong> srcQ_256_ulong = Vector256.Create((ulong)0, 1, 2, 3);

        // srcArray: array.
        private const int srcArraySize = 256;
        private static readonly float[] srcArray_float = Enumerable.Range(0, srcArraySize).Select(x => (float)x).ToArray();
        private static readonly double[] srcArray_double = Enumerable.Range(0, srcArraySize).Select(x => (double)x).ToArray();
        private static readonly byte[] srcArray_byte = Enumerable.Range(0, srcArraySize*4).Select(x => (byte)x).ToArray();
        private static readonly int[] srcArray_int = Enumerable.Range(0, srcArraySize).Select(x => (int)x).ToArray();
        private static readonly long[] srcArray_long = Enumerable.Range(0, srcArraySize).Select(x => (long)x).ToArray();
        #endregion // #region Fields

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
            //tw.WriteLine(string.Format("Vector4.Assembly.CodeBase:\t{0}", assembly.CodeBase));
            assembly = typeof(Vector<float>).GetTypeInfo().Assembly;
            tw.WriteLine(string.Format("Vector<T>.Assembly.CodeBase:\t{0}", assembly.CodeBase));
            assembly = typeof(Vector128<float>).GetTypeInfo().Assembly;
            tw.WriteLine(string.Format("Vector128<T>.Assembly.CodeBase:\t{0}", assembly.CodeBase));
        }

        /// <summary>
        /// Run.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void Run(TextWriter tw, string indent) {
            RunBaseInfo(tw, indent);
            RunX86(tw, indent);
            RunArm(tw, indent);
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

            // srcT
            tw.WriteLine(indent + "[Vector samples]");
            WriteLineFormat(tw, indent, "src1_64_float:\t{0}", src1_64_float);
            //WriteLineFormat(tw, indent, "src1_128_float:\t{0}", src1_128_float);
            //WriteLineFormat(tw, indent, "src1_256_float:\t{0}", src1_256_float);
            WriteLineFormat(tw, indent, "src1_64_double:\t{0}", src1_64_double);
            //WriteLineFormat(tw, indent, "src1_128_double:\t{0}", src1_128_double);
            //WriteLineFormat(tw, indent, "src1_256_double:\t{0}", src1_256_double);
            WriteLineFormat(tw, indent, "src2_64_float:\t{0}", src2_64_float);
            //WriteLineFormat(tw, indent, "src2_128_float:\t{0}", src2_128_float);
            //WriteLineFormat(tw, indent, "src2_256_float:\t{0}", src2_256_float);
            WriteLineFormat(tw, indent, "src2_64_double:\t{0}", src2_64_double);
            //WriteLineFormat(tw, indent, "src2_128_double:\t{0}", src2_128_double);
            //WriteLineFormat(tw, indent, "src2_256_double:\t{0}", src2_256_double);
            WriteLineFormat(tw, indent, "srcT_64_float:\t{0}", srcT_64_float);
            WriteLineFormat(tw, indent, "srcT_128_float:\t{0}", srcT_128_float);
            WriteLineFormat(tw, indent, "srcT_256_float:\t{0}", srcT_256_float);
            WriteLineFormat(tw, indent, "srcT_64_double:\t{0}", srcT_64_double);
            WriteLineFormat(tw, indent, "srcT_128_double:\t{0}", srcT_128_double);
            WriteLineFormat(tw, indent, "srcT_256_double:\t{0}", srcT_256_double);
            WriteLineFormat(tw, indent, "srcT_64_sbyte:\t{0}", srcT_64_sbyte);
            WriteLineFormat(tw, indent, "srcT_128_sbyte:\t{0}", srcT_128_sbyte);
            WriteLineFormat(tw, indent, "srcT_256_sbyte:\t{0}", srcT_256_sbyte);
            WriteLineFormat(tw, indent, "srcT_64_short:\t{0}", srcT_64_short);
            WriteLineFormat(tw, indent, "srcT_128_short:\t{0}", srcT_128_short);
            WriteLineFormat(tw, indent, "srcT_256_short:\t{0}", srcT_256_short);
            WriteLineFormat(tw, indent, "srcT_64_int:\t{0}", srcT_64_int);
            WriteLineFormat(tw, indent, "srcT_128_int:\t{0}", srcT_128_int);
            WriteLineFormat(tw, indent, "srcT_256_int:\t{0}", srcT_256_int);
            WriteLineFormat(tw, indent, "srcT_64_long:\t{0}", srcT_64_long);
            WriteLineFormat(tw, indent, "srcT_128_long:\t{0}", srcT_128_long);
            WriteLineFormat(tw, indent, "srcT_256_long:\t{0}", srcT_256_long);
            WriteLineFormat(tw, indent, "srcT_64_byte:\t{0}", srcT_64_byte);
            WriteLineFormat(tw, indent, "srcT_128_byte:\t{0}", srcT_128_byte);
            WriteLineFormat(tw, indent, "srcT_256_byte:\t{0}", srcT_256_byte);
            WriteLineFormat(tw, indent, "srcT_64_ushort:\t{0}", srcT_64_ushort);
            WriteLineFormat(tw, indent, "srcT_128_ushort:\t{0}", srcT_128_ushort);
            WriteLineFormat(tw, indent, "srcT_256_ushort:\t{0}", srcT_256_ushort);
            WriteLineFormat(tw, indent, "srcT_64_uint:\t{0}", srcT_64_uint);
            WriteLineFormat(tw, indent, "srcT_128_uint:\t{0}", srcT_128_uint);
            WriteLineFormat(tw, indent, "srcT_256_uint:\t{0}", srcT_256_uint);
            WriteLineFormat(tw, indent, "srcT_64_ulong:\t{0}", srcT_64_ulong);
            WriteLineFormat(tw, indent, "srcT_128_ulong:\t{0}", srcT_128_ulong);
            WriteLineFormat(tw, indent, "srcT_256_ulong:\t{0}", srcT_256_ulong);

            // done.
            tw.WriteLine();
        }
    }
}
