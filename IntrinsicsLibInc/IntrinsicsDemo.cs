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

        // Vector<T>.
        private static readonly Vector<float> srcT_float = CreateVectorUseRotate(float.MinValue, float.PositiveInfinity, float.NaN, -1.2f, 0f, 1f, 2f, 4f);
        private static readonly Vector<double> srcT_double = CreateVectorUseRotate(double.MinValue, double.PositiveInfinity, -1.2, 0);
        private static readonly Vector<sbyte> srcT_sbyte = CreateVectorUseRotate<sbyte>(sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64);
        private static readonly Vector<byte> srcT_byte = CreateVectorUseRotate<byte>(byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128);
        private static readonly Vector<short> srcT_short = CreateVectorUseRotate<short>(short.MinValue, short.MaxValue, -1, 0, 1, 2, 3, 16384);
        private static readonly Vector<ushort> srcT_ushort = CreateVectorUseRotate<ushort>(ushort.MinValue, ushort.MaxValue, 0, 1, 2, 3, 4, 32768);
        private static readonly Vector<int> srcT_int = CreateVectorUseRotate<int>(int.MinValue, int.MaxValue, -1, 0, 1, 2, 3, 32768);
        private static readonly Vector<uint> srcT_uint = CreateVectorUseRotate<uint>(uint.MinValue, uint.MaxValue, 0, 1, 2, 3, 4, 65536);
        private static readonly Vector<long> srcT_long = CreateVectorUseRotate<long>(long.MinValue, long.MaxValue, -1, 0, 1, 2, 3);
        private static readonly Vector<ulong> srcT_ulong = CreateVectorUseRotate<ulong>(ulong.MinValue, ulong.MaxValue, 0, 1, 2, 3);


        #endregion // #region Fields

        /// <summary>
        /// Create Vector&lt;T&gt; use rotate.
        /// </summary>
        /// <typeparam name="T">Vector type.</typeparam>
        /// <param name="list">Source value list.</param>
        /// <returns>Returns Vector&lt;T&gt;.</returns>
        static Vector<T> CreateVectorUseRotate<T>(params T[] list) where T : struct {
            if (null == list || list.Length <= 0) return Vector<T>.Zero;
            T[] arr = new T[Vector<T>.Count];
            int idx = 0;
            for (int i = 0; i < arr.Length; ++i) {
                arr[i] = list[idx];
                ++idx;
                if (idx >= list.Length) idx = 0;
            }
            Vector<T> rt = new Vector<T>(arr);
            return rt;
        }

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
                //RunX86(tw, indent);
                //RunArm(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine(ex);
            }
        }

        /// <summary>
        /// Run common.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunCommon(TextWriter tw, string indent) {
            RunBaseInfo(tw, indent);
            RunVector(tw, indent);
            RunVector64(tw, indent);
            RunVector128(tw, indent);
            RunVector256(tw, indent);
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
            // Test Vectors .
            double[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            byte[] arrByte = { byte.MinValue, byte.MaxValue, 0, 1 };
            //tw.WriteLine(Vectors.Create<Byte>(null)); // ArgumentNullException
            //tw.WriteLine(Vectors.Create(arrByte)); // IndexOutOfRangeException
            WriteLineFormat(tw, indent, "Create by T[]:\t{0}", Vectors.Create(arr));
            var parr = new ReadOnlySpan<double>(arr);
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

            // srcT
            tw.WriteLine(indent + "[Vector samples]");
            tw.WriteLine(indent + "-- Vector<T>");
            WriteLineFormat(tw, indent, "srcT_float:\t{0}", srcT_float);
            WriteLineFormat(tw, indent, "srcT_double:\t{0}", srcT_double);
            WriteLineFormat(tw, indent, "srcT_sbyte:\t{0}", srcT_sbyte);
            WriteLineFormat(tw, indent, "srcT_byte:\t{0}", srcT_byte);
            WriteLineFormat(tw, indent, "srcT_short:\t{0}", srcT_short);
            WriteLineFormat(tw, indent, "srcT_ushort:\t{0}", srcT_ushort);
            WriteLineFormat(tw, indent, "srcT_int:\t{0}", srcT_int);
            WriteLineFormat(tw, indent, "srcT_uint:\t{0}", srcT_uint);
            WriteLineFormat(tw, indent, "srcT_long:\t{0}", srcT_long);
            WriteLineFormat(tw, indent, "srcT_ulong:\t{0}", srcT_ulong);
            tw.WriteLine(indent + "-- Vector?<T>");
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

            // Vectors<T> .
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

            // Vector256s<T> .
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

            // done.
            tw.WriteLine();
        }

        /// <summary>
        /// Run base - <see cref="Vectors{T}"/>
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        public static void RunInfoVectors<T>(TextWriter tw, string indent) where T:struct {
            tw.WriteLine(indent + string.Format("-- Vectors<{0}>, Vector<{0}>.Count={1} --", typeof(T).Name, Vector<T>.Count));
            WriteLineFormat(tw, indent, "ElementSize:\t{0}", Vectors<T>.ElementSize);
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vectors<T>.SignBits, Vectors<T>.ExponentBits, Vectors<T>.MantissaBits));
            tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vectors<T>.SignShift, Vectors<T>.ExponentShift, Vectors<T>.MantissaShift));
            WriteLineFormat(tw, indent, "ElementZero:\t{0}", Vectors<T>.ElementZero);
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
            WriteLineFormat(tw, indent, "AllBitsSet:\t{0}", Vectors<T>.AllBitsSet);
            WriteLineFormat(tw, indent, "Serial:\t{0}", Vectors<T>.Serial);
            WriteLineFormat(tw, indent, "Demo:\t{0}", Vectors<T>.Demo);
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
            WriteLineFormat(tw, indent, "MaskBitPosSerial:\t{0}", Vectors<T>.MaskBitPosSerial);
            WriteLineFormat(tw, indent, "MaskBitsSerial:\t{0}", Vectors<T>.MaskBitsSerial);
            WriteLineFormat(tw, indent, "V0:\t{0}", Vectors<T>.V0);
            WriteLineFormat(tw, indent, "V1:\t{0}", Vectors<T>.V1);
            WriteLineFormat(tw, indent, "V_1:\t{0}", Vectors<T>.V_1);
        }

        /// <summary>
        /// Run base - <see cref="Vector256s{T}"/>
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        public static void RunInfoVector256s<T>(TextWriter tw, string indent) where T : struct {
            tw.WriteLine(indent + string.Format("-- Vector256s<{0}>, Vector256<{0}>.Count={1} --", typeof(T).Name, Vector256<T>.Count));
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vector256s<T>.SignBits, Vector256s<T>.ExponentBits, Vector256s<T>.MantissaBits));
            WriteLineFormat(tw, indent, "SignMask:\t{0}", Vector256s<T>.SignMask);
            WriteLineFormat(tw, indent, "ExponentMask:\t{0}", Vector256s<T>.ExponentMask);
            WriteLineFormat(tw, indent, "MantissaMask:\t{0}", Vector256s<T>.MantissaMask);
            WriteLineFormat(tw, indent, "MaxValue:\t{0}", Vector256s<T>.MaxValue);
            WriteLineFormat(tw, indent, "MinValue:\t{0}", Vector256s<T>.MinValue);
            WriteLineFormat(tw, indent, "E:\t{0}", Vector256s<T>.E);
            WriteLineFormat(tw, indent, "Pi:\t{0}", Vector256s<T>.Pi);
            WriteLineFormat(tw, indent, "Tau:\t{0}", Vector256s<T>.Tau);
            WriteLineFormat(tw, indent, "AllBitsSet:\t{0}", Vector256s<T>.AllBitsSet);
            WriteLineFormat(tw, indent, "Serial:\t{0}", Vector256s<T>.Serial);
            WriteLineFormat(tw, indent, "Demo:\t{0}", Vector256s<T>.Demo);
            WriteLineFormat(tw, indent, "V0:\t{0}", Vector256s<T>.V0);
            WriteLineFormat(tw, indent, "V1:\t{0}", Vector256s<T>.V1);
            WriteLineFormat(tw, indent, "V_1:\t{0}", Vector256s<T>.V_1);
        }

        /// <summary>
        /// Run Vector. https://learn.microsoft.com/zh-cn/dotnet/api/system.numerics.vector?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            //bool isAllow = Vector.IsHardwareAccelerated;
            bool isAllow = true;
            if (isAllow) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("-- Vector.IsSupported:\t{0}", Vector.IsHardwareAccelerated));
            if (!isAllow) {
                return;
            }

            // Count.
            tw.WriteLine(indent + string.Format("Vector<float>.Count:\t{0}", Vector<float>.Count));
            tw.WriteLine(indent + string.Format("Vector<double>.Count:\t{0}", Vector<double>.Count));
            tw.WriteLine(indent + string.Format("Vector<sbyte>.Count:\t{0}", Vector<sbyte>.Count));
            tw.WriteLine(indent + string.Format("Vector<byte>.Count:\t{0}", Vector<byte>.Count));
            tw.WriteLine(indent + string.Format("Vector<short>.Count:\t{0}", Vector<short>.Count));
            tw.WriteLine(indent + string.Format("Vector<ushort>.Count:\t{0}", Vector<ushort>.Count));
            tw.WriteLine(indent + string.Format("Vector<int>.Count:\t{0}", Vector<int>.Count));
            tw.WriteLine(indent + string.Format("Vector<uint>.Count:\t{0}", Vector<uint>.Count));
            tw.WriteLine(indent + string.Format("Vector<long>.Count:\t{0}", Vector<long>.Count));
            tw.WriteLine(indent + string.Format("Vector<ulong>.Count:\t{0}", Vector<ulong>.Count));
#if NET6_0_OR_GREATER
            tw.WriteLine(indent + string.Format("Vector<nint>.Count:\t{0}", Vector<nint>.Count));
            tw.WriteLine(indent + string.Format("Vector<nuint>.Count:\t{0}", Vector<nuint>.Count));
            // Unhandled exception. System.NotSupportedException: Specified type is not supported
            //tw.WriteLine(indent + string.Format("Vector<Half>.Count:\t{0}", Vector<Half>.Count));
#endif // NET6_0_OR_GREATER

            // -- Methods --
            #region Methods
            //Debugger.Break();
            //Abs<T>(Vector<T>) Returns a new vector whose elements are the absolute values of the given vector's elements.
            WriteLineFormat(tw, indent, "Abs(Vectors<float>.Demo):\t{0}", Vector.Abs(Vectors<float>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<double>.Demo):\t{0}", Vector.Abs(Vectors<double>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<sbyte>.Demo):\t{0}", Vector.Abs(Vectors<sbyte>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<byte>.Demo):\t{0}", Vector.Abs(Vectors<byte>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<short>.Demo):\t{0}", Vector.Abs(Vectors<short>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<ushort>.Demo):\t{0}", Vector.Abs(Vectors<ushort>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<int>.Demo):\t{0}", Vector.Abs(Vectors<int>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<uint>.Demo):\t{0}", Vector.Abs(Vectors<uint>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<long>.Demo):\t{0}", Vector.Abs(Vectors<long>.Demo));
            WriteLineFormat(tw, indent, "Abs(Vectors<ulong>.Demo):\t{0}", Vector.Abs(Vectors<ulong>.Demo));

//            //Add<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the sum of each pair of elements from two given vectors.
//            WriteLineFormat(tw, indent, "Add(srcT, src1):\t{0}", Vector.Add(srcT, src1));
//            WriteLineFormat(tw, indent, "Add(srcT, src2):\t{0}", Vector.Add(srcT, src2));

//            //AndNot<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise And Not operation on each pair of corresponding elements in two vectors.
//            WriteLineFormat(tw, indent, "AndNot(srcT, src1):\t{0}", Vector.AndNot(srcT, src1));
//            WriteLineFormat(tw, indent, "AndNot(srcT, src2):\t{0}", Vector.AndNot(srcT, src2));

//            //As<TFrom, TTo>(Vector<TFrom>)    Reinterprets aVector64<T> as a new Vector64<T>.
//            //AsVectorByte<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of unsigned bytes.
//            //AsVectorDouble<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a double-precision floating-point vector.
//            //AsVectorInt16<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of 16-bit integers.
//            //AsVectorInt32<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of integers.
//            //AsVectorInt64<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of long integers.
//            //AsVectorNInt<T>(Vector<T>)  Reinterprets the bits of a specified vector into those of a vector of native-sized integers.
//            //AsVectorNUInt<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of native-sized, unsigned integers.
//            //AsVectorSByte<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of signed bytes.
//            //AsVectorSingle<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a single-precision floating-point vector.
//            //AsVectorUInt16<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a vector of unsigned 16-bit integers.
//            //AsVectorUInt32<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a vector of unsigned integers.
//            //AsVectorUInt64<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of unsigned long integers.
//            // `As***` see below.

//            //BitwiseAnd<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise Andoperation on each pair of elements in two vectors.
//            WriteLineFormat(tw, indent, "BitwiseAnd(srcT, src1):\t{0}", Vector.BitwiseAnd(srcT, src1));
//            WriteLineFormat(tw, indent, "BitwiseAnd(srcT, src2):\t{0}", Vector.BitwiseAnd(srcT, src2));
//            //BitwiseOr<T>(Vector<T>, Vector<T>)  Returns a new vector by performing a bitwise Oroperation on each pair of elements in two vectors.
//            WriteLineFormat(tw, indent, "BitwiseOr(srcT, src1):\t{0}", Vector.BitwiseOr(srcT, src1));
//            WriteLineFormat(tw, indent, "BitwiseOr(srcT, src2):\t{0}", Vector.BitwiseOr(srcT, src2));

//#if NET5_0_OR_GREATER
//            //Ceiling(Vector<Double>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
//            //Ceiling(Vector<Single>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
//            if (typeof(T) == typeof(Double)) {
//                WriteLineFormat(tw, indent, "Ceiling(srcT):\t{0}", Vector.Ceiling(Vector.AsVectorDouble(srcT)));
//            } else if (typeof(T) == typeof(Single)) {
//                WriteLineFormat(tw, indent, "Ceiling(srcT):\t{0}", Vector.Ceiling(Vector.AsVectorSingle(srcT)));
//            }
//#endif // NET5_0_OR_GREATER

//            //ConditionalSelect(Vector<Int32>, Vector<Single>, Vector<Single>)    Creates a new single-precision vector with elements selected between two specified single-precision source vectors based on an integral mask vector.
//            //ConditionalSelect(Vector<Int64>, Vector<Double>, Vector<Double>) Creates a new double-precision vector with elements selected between two specified double-precision source vectors based on an integral mask vector.
//            //ConditionalSelect<T>(Vector<T>, Vector<T>, Vector<T>) Creates a new vector of a specified type with elements selected between two specified source vectors of the same type based on an integral mask vector.
//            Vector<T> mask = Vector.GreaterThan(srcT, src0);
//            WriteLineFormat(tw, indent, "# Max mask=GreaterThan(srcT, src0):\t{0}", mask);
//            WriteLineFormat(tw, indent, "ConditionalSelect(mask, srcT, src0):\t{0}", Vector.ConditionalSelect(mask, srcT, src0));
//            WriteLineFormat(tw, indent, "ConditionalSelect(srcT, src0, src1):\t{0}", Vector.ConditionalSelect(srcT, src0, src1));
//            // ConditionalSelect = left&mask | right&~mask;
//            //
//            // Sample UInt32:
//            //# srcT:   <0, 4294967295, 0, 1, 2, 3, 4, 0>       # (00000000 FFFFFFFF 00000000 00000001 00000002 00000003 00000004 00000000)
//            //# ConditionalSelect(srcT, src0, src1):    <1, 0, 1, 0, 1, 0, 1, 1>        # (00000001 00000000 00000001 00000000 00000001 00000000 00000001 00000001)
//            // Mean:
//            //[0] = src0[0]&srcT[0] | src0[1]&~srcT[0] = 0&0 | 1&~0 = 0 | 1&0xFFFFFFFF = 1
//            //[1] = src0[1]&srcT[1] | src0[1]&~srcT[1] = 0&4294967295 | 1&~4294967295 = 0 | 1&0 = 0
//            //[2] = src0[2]&srcT[2] | src0[2]&~srcT[2] = 0&0 | 1&~0 = 0 | 1&0xFFFFFFFF = 1
//            //[3] = src0[3]&srcT[3] | src0[3]&~srcT[3] = 0&1 | 1&~1 = 0 | 1&0xFFFFFFFE = 0
//            //[4] = src0[4]&srcT[4] | src0[4]&~srcT[4] = 0&2 | 1&~2 = 0 | 1&0xFFFFFFFD = 1
//            //[5] = src0[5]&srcT[5] | src0[5]&~srcT[5] = 0&3 | 1&~3 = 0 | 1&0xFFFFFFFC = 0
//            //[6] = src0[6]&srcT[6] | src0[6]&~srcT[6] = 0&4 | 1&~4 = 0 | 1&0xFFFFFFFB = 1
//            //[7] = src0[7]&srcT[7] | src0[7]&~srcT[7] = 0&0 | 1&~0 = 0 | 1 = 1

//            //ConvertToDouble(Vector<Int64>) Converts a Vector<Int64>to aVector<Double>.
//            //ConvertToDouble(Vector<UInt64>) Converts a Vector<UInt64> to aVector<Double>.
//            //ConvertToInt32(Vector<Single>) Converts a Vector<Single> to aVector<Int32>.
//            //ConvertToInt64(Vector<Double>) Converts a Vector<Double> to aVector<Int64>.
//            //ConvertToSingle(Vector<Int32>) Converts a Vector<Int32> to aVector<Single>.
//            //ConvertToSingle(Vector<UInt32>) Converts a Vector<UInt32> to aVector<Single>.
//            //ConvertToUInt32(Vector<Single>) Converts a Vector<Single> to aVector<UInt32>.
//            //ConvertToUInt64(Vector<Double>) Converts a Vector<Double> to aVector<UInt64>.
//            // Infinity or NaN -> IntTypes.MinValue .
//            if (typeof(T) == typeof(Double)) {
//                WriteLineFormat(tw, indent, "ConvertToInt64(srcT):\t{0}", Vector.ConvertToInt64(Vector.AsVectorDouble(srcT)));
//                WriteLineFormat(tw, indent, "ConvertToUInt64(srcT):\t{0}", Vector.ConvertToUInt64(Vector.AsVectorDouble(srcT)));
//            } else if (typeof(T) == typeof(Single)) {
//                WriteLineFormat(tw, indent, "ConvertToInt32(srcT):\t{0}", Vector.ConvertToInt32(Vector.AsVectorSingle(srcT)));
//                WriteLineFormat(tw, indent, "ConvertToUInt32(srcT):\t{0}", Vector.ConvertToUInt32(Vector.AsVectorSingle(srcT)));
//            } else if (typeof(T) == typeof(Int32)) {
//                WriteLineFormat(tw, indent, "ConvertToSingle(srcT):\t{0}", Vector.ConvertToSingle(Vector.AsVectorInt32(srcT)));
//            } else if (typeof(T) == typeof(UInt32)) {
//                WriteLineFormat(tw, indent, "ConvertToSingle(srcT):\t{0}", Vector.ConvertToSingle(Vector.AsVectorUInt32(srcT)));
//            } else if (typeof(T) == typeof(Int64)) {
//                WriteLineFormat(tw, indent, "ConvertToDouble(srcT):\t{0}", Vector.ConvertToDouble(Vector.AsVectorInt64(srcT)));
//            } else if (typeof(T) == typeof(UInt64)) {
//                WriteLineFormat(tw, indent, "ConvertToDouble(srcT):\t{0}", Vector.ConvertToDouble(Vector.AsVectorUInt64(srcT)));
//            }

//            //Divide<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the result of dividing the first vector's elements by the corresponding elements in the second vector.
//            WriteLineFormat(tw, indent, "Divide(srcT, src2):\t{0}", Vector.Divide(srcT, src2));

//            //Dot<T>(Vector<T>, Vector<T>) Returns the dot product of two vectors.
//            WriteLineFormat(tw, indent, "Dot(srcT, src1):\t{0}", Vector.Dot(srcT, src1));
//            WriteLineFormat(tw, indent, "Dot(srcT, src2):\t{0}", Vector.Dot(srcT, src2));
//            WriteLineFormat(tw, indent, "Dot(src1, src2):\t{0}", Vector.Dot(src1, src2));

//            //Equals(Vector<Double>, Vector<Double>)  Returns a new integral vector whose elements signal whether the elements in two specified double-precision vectors are equal.
//            //Equals(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in two specified integral vectors are equal.
//            //Equals(Vector<Int64>, Vector<Int64>)    Returns a new vector whose elements signal whether the elements in two specified long integer vectors are equal.
//            //Equals(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in two specified single-precision vectors are equal.
//            //Equals<T>(Vector<T>, Vector<T>) Returns a new vector of a specified type whose elements signal whether the elements in two specified vectors of the same type are equal.
//            WriteLineFormat(tw, indent, "Equals(srcT, src0):\t{0}", Vector.Equals(srcT, src0));
//            WriteLineFormat(tw, indent, "Equals(srcT, src1):\t{0}", Vector.Equals(srcT, src1));

//            //EqualsAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether each pair of elements in the given vectors is equal.
//            WriteLineFormat(tw, indent, "EqualsAll(srcT, src0):\t{0}", Vector.EqualsAll(srcT, src0));
//            //EqualsAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any single pair of elements in the given vectors is equal.
//            WriteLineFormat(tw, indent, "EqualsAny(srcT, src0):\t{0}", Vector.EqualsAny(srcT, src0));

//#if NET5_0_OR_GREATER
//            //Floor(Vector<Double>) Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
//            //Floor(Vector<Single>)   Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
//            if (typeof(T) == typeof(Double)) {
//                WriteLineFormat(tw, indent, "Floor(srcT):\t{0}", Vector.Floor(Vector.AsVectorDouble(srcT)));
//            } else if (typeof(T) == typeof(Single)) {
//                WriteLineFormat(tw, indent, "Floor(srcT):\t{0}", Vector.Floor(Vector.AsVectorSingle(srcT)));
//            }
//#endif // NET5_0_OR_GREATER

//            //GreaterThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are greater than their corresponding elements in a second double-precision floating-point vector.
//            //GreaterThan(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than their corresponding elements in a second integral vector.
//            //GreaterThan(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than their corresponding elements in a second long integer vector.
//            //GreaterThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are greater than their corresponding elements in a second single-precision floating-point vector.
//            //GreaterThan<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than their corresponding elements in the second vector of the same time.
//            WriteLineFormat(tw, indent, "GreaterThan(srcT, src0):\t{0}", Vector.GreaterThan(srcT, src0));
//            WriteLineFormat(tw, indent, "GreaterThan(srcT, src1):\t{0}", Vector.GreaterThan(srcT, src1));

//            //GreaterThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than the corresponding elements in the second vector.
//            //GreaterThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than the corresponding element in the second vector.

//            //GreaterThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the second double-precision floating-point vector.
//            //GreaterThanOrEqual(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than or equal to their corresponding elements in the second integral vector.
//            //GreaterThanOrEqual(Vector<Int64>, Vector<Int64>)    Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than or equal to their corresponding elements in the second long integer vector.
//            //GreaterThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the single-precision floating-point second vector.
//            //GreaterThanOrEqual<T>(Vector<T>, Vector<T>) Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than or equal to their corresponding elements in the second vector of the same type.
//            WriteLineFormat(tw, indent, "GreaterThanOrEqual(srcT, src0):\t{0}", Vector.GreaterThanOrEqual(srcT, src0));
//            WriteLineFormat(tw, indent, "GreaterThanOrEqual(srcT, src1):\t{0}", Vector.GreaterThanOrEqual(srcT, src1));

//            //GreaterThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than or equal to all the corresponding elements in the second vector.
//            //GreaterThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than or equal to the corresponding element in the second vector.

//            //LessThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than their corresponding elements in a second double-precision floating-point vector.
//            //LessThan(Vector<Int32>, Vector<Int32>)  Returns a new integral vector whose elements signal whether the elements in one integral vector are less than their corresponding elements in a second integral vector.
//            //LessThan(Vector<Int64>, Vector<Int64>)  Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less than their corresponding elements in a second long integer vector.
//            //LessThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision vector are less than their corresponding elements in a second single-precision vector.
//            //LessThan<T>(Vector<T>, Vector<T>)   Returns a new vector of a specified type whose elements signal whether the elements in one vector are less than their corresponding elements in the second vector.
//            WriteLineFormat(tw, indent, "LessThan(srcT, src0):\t{0}", Vector.LessThan(srcT, src0));
//            WriteLineFormat(tw, indent, "LessThan(srcT, src1):\t{0}", Vector.LessThan(srcT, src1));

//            //LessThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all of the elements in the first vector are less than their corresponding elements in the second vector.
//            //LessThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than the corresponding element in the second vector.

//            //LessThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than or equal to their corresponding elements in a second double-precision floating-point vector.
//            //LessThanOrEqual(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are less than or equal to their corresponding elements in a second integral vector.
//            //LessThanOrEqual(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less or equal to their corresponding elements in a second long integer vector.
//            //LessThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are less than or equal to their corresponding elements in a second single-precision floating-point vector.
//            //LessThanOrEqual<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector are less than or equal to their corresponding elements in the second vector.
//            WriteLineFormat(tw, indent, "LessThanOrEqual(srcT, src0):\t{0}", Vector.LessThanOrEqual(srcT, src0));
//            WriteLineFormat(tw, indent, "LessThanOrEqual(srcT, src1):\t{0}", Vector.LessThanOrEqual(srcT, src1));

//            //LessThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are less than or equal to their corresponding elements in the second vector.
//            //LessThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than or equal to the corresponding element in the second vector.

//            //Max<T>(Vector<T>, Vector<T>) Returns a new vector whose elements are the maximum of each pair of elements in the two given vectors.
//            WriteLineFormat(tw, indent, "Max(srcT, src0):\t{0}", Vector.Max(srcT, src0));
//            WriteLineFormat(tw, indent, "Max(srcT, src2):\t{0}", Vector.Max(srcT, src2));
//            //Min<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements are the minimum of each pair of elements in the two given vectors.
//            WriteLineFormat(tw, indent, "Min(srcT, src0):\t{0}", Vector.Min(srcT, src0));
//            WriteLineFormat(tw, indent, "Min(srcT, src2):\t{0}", Vector.Min(srcT, src2));
//            WriteLineFormat(tw, indent, "Min(Max(srcT, src0), src2):\t{0}", Vector.Min(Vector.Max(srcT, src0), src2));

//            //Multiply<T>(T, Vector<T>)   Returns a new vector whose values are a scalar value multiplied by each of the values of a specified vector.
//            //Multiply<T>(Vector<T>, T) Returns a new vector whose values are the values of a specified vector each multiplied by a scalar value.
//            //Multiply<T>(Vector<T>, Vector<T>)   Returns a new vector whose values are the product of each pair of elements in two specified vectors.
//            WriteLineFormat(tw, indent, "Multiply(srcT, src2):\t{0}", Vector.Multiply(srcT, src2));

//            //Narrow(Vector<Double>, Vector<Double>) Narrows two Vector<Double>instances into one Vector<Single>.
//            //Narrow(Vector<Int16>, Vector<Int16>) Narrows two Vector<Int16> instances into one Vector<SByte>.
//            //Narrow(Vector<Int32>, Vector<Int32>) Narrows two Vector<Int32> instances into one Vector<Int16>.
//            //Narrow(Vector<Int64>, Vector<Int64>) Narrows two Vector<Int64> instances into one Vector<Int32>.
//            //Narrow(Vector<UInt16>, Vector<UInt16>) Narrows two Vector<UInt16> instances into one Vector<Byte>.
//            //Narrow(Vector<UInt32>, Vector<UInt32>) Narrows two Vector<UInt32> instances into one Vector<UInt16>.
//            //Narrow(Vector<UInt64>, Vector<UInt64>) Narrows two Vector<UInt64> instances into one Vector<UInt32>.
//            if (typeof(T) == typeof(Double)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorDouble(srcT), Vector.AsVectorDouble(src1)));
//            } else if (typeof(T) == typeof(Int16)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorInt16(srcT), Vector.AsVectorInt16(src1)));
//            } else if (typeof(T) == typeof(Int32)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorInt32(srcT), Vector.AsVectorInt32(src1)));
//            } else if (typeof(T) == typeof(Int64)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorInt64(srcT), Vector.AsVectorInt64(src1)));
//            } else if (typeof(T) == typeof(UInt16)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorUInt16(srcT), Vector.AsVectorUInt16(src1)));
//            } else if (typeof(T) == typeof(UInt32)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorUInt32(srcT), Vector.AsVectorUInt32(src1)));
//            } else if (typeof(T) == typeof(UInt64)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorUInt64(srcT), Vector.AsVectorUInt64(src1)));
//            }

//            //Negate<T>(Vector<T>) Returns a new vector whose elements are the negation of the corresponding element in the specified vector.
//            WriteLineFormat(tw, indent, "Negate(srcT):\t{0}", Vector.Negate(srcT));
//            WriteLineFormat(tw, indent, "Negate(srcAllOnes):\t{0}", Vector.Negate(srcAllOnes));
//            //OnesComplement<T>(Vector<T>) Returns a new vector whose elements are obtained by taking the one's complement of a specified vector's elements.
//            WriteLineFormat(tw, indent, "OnesComplement(srcT):\t{0}", Vector.OnesComplement(srcT));
//            WriteLineFormat(tw, indent, "OnesComplement(srcAllOnes):\t{0}", Vector.OnesComplement(srcAllOnes));

//#if NET7_0_OR_GREATER
//            //ShiftLeft(Vector<Byte>, Int32)  Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<Int16>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<Int32>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<Int64>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<IntPtr>, Int32)    Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<SByte>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<UInt16>, Int32)    Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<UInt32>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<UInt64>, Int32)    Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<UIntPtr>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftRightArithmetic(Vector<Int16>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightArithmetic(Vector<Int32>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightArithmetic(Vector<Int64>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightArithmetic(Vector<IntPtr>, Int32) Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightArithmetic(Vector<SByte>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<Byte>, Int32)  Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<Int16>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<Int32>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<Int64>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<IntPtr>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<SByte>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<UInt16>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<UInt32>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<UInt64>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<UIntPtr>, Int32)   Shifts(unsigned) each element of a vector right by the specified amount.
//#endif // NET7_0_OR_GREATER

//            //SquareRoot<T>(Vector<T>)    Returns a new vector whose elements are the square roots of a specified vector's elements.
//            WriteLineFormat(tw, indent, "SquareRoot(srcT):\t{0}", Vector.SquareRoot(srcT));

//            //Subtract<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the difference between the elements in the second vector and their corresponding elements in the first vector.
//            WriteLineFormat(tw, indent, "Subtract(srcT, src1):\t{0}", Vector.Subtract(srcT, src1));
//            WriteLineFormat(tw, indent, "Subtract(srcT, src2):\t{0}", Vector.Subtract(srcT, src2));

//#if NET6_0_OR_GREATER
//            //Sum<T>(Vector<T>) Returns the sum of all the elements inside the specified vector.
//            WriteLineFormat(tw, indent, "Sum(srcT):\t{0}", Vector.Sum(srcT));
//            WriteLineFormat(tw, indent, "Sum(src1):\t{0}", Vector.Sum(src1));
//#endif // NET6_0_OR_GREATER

//            //Widen(Vector<Byte>, Vector<UInt16>, Vector<UInt16>) Widens aVector<Byte> into two Vector<UInt16>instances.
//            //Widen(Vector<Int16>, Vector<Int32>, Vector<Int32>) Widens a Vector<Int16> into twoVector<Int32> instances.
//            //Widen(Vector<Int32>, Vector<Int64>, Vector<Int64>) Widens a Vector<Int32> into twoVector<Int64> instances.
//            //Widen(Vector<SByte>, Vector<Int16>, Vector<Int16>) Widens a Vector<SByte> into twoVector<Int16> instances.
//            //Widen(Vector<Single>, Vector<Double>, Vector<Double>) Widens a Vector<Single> into twoVector<Double> instances.
//            //Widen(Vector<UInt16>, Vector<UInt32>, Vector<UInt32>) Widens a Vector<UInt16> into twoVector<UInt32> instances.
//            //Widen(Vector<UInt32>, Vector<UInt64>, Vector<UInt64>) Widens a Vector<UInt32> into twoVector<UInt64> instances.
//            if (typeof(T) == typeof(Single)) {
//                Vector<Double> low, high;
//                Vector.Widen(Vector.AsVectorSingle(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(SByte)) {
//                Vector<Int16> low, high;
//                Vector.Widen(Vector.AsVectorSByte(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(Int16)) {
//                Vector<Int32> low, high;
//                Vector.Widen(Vector.AsVectorInt16(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(Int32)) {
//                Vector<Int64> low, high;
//                Vector.Widen(Vector.AsVectorInt32(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(Byte)) {
//                Vector<UInt16> low, high;
//                Vector.Widen(Vector.AsVectorByte(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(UInt16)) {
//                Vector<UInt32> low, high;
//                Vector.Widen(Vector.AsVectorUInt16(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(UInt32)) {
//                Vector<UInt64> low, high;
//                Vector.Widen(Vector.AsVectorUInt32(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            }

//            //Xor<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise exclusive Or(XOr) operation on each pair of elements in two vectors.
//            WriteLineFormat(tw, indent, "Xor(srcT, src1):\t{0}", Vector.Xor(srcT, src1));
//            WriteLineFormat(tw, indent, "Xor(srcT, src2):\t{0}", Vector.Xor(srcT, src2));

#endregion // Methods

        }

        /// <summary>
        /// Run Vector64. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.vector64?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector64(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector64.IsHardwareAccelerated) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("-- Vector64.IsSupported:\t{0}", Vector64.IsHardwareAccelerated));
            if (!Vector64.IsHardwareAccelerated) {
                return;
            }

#else
            // none.
#endif
        }

        /// <summary>
        /// Run Vector128. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.vector128?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector128(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector128.IsHardwareAccelerated) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("-- Vector128.IsSupported:\t{0}", Vector128.IsHardwareAccelerated));
            if (!Vector128.IsHardwareAccelerated) {
                return;
            }

#else
            // none.
#endif
        }

        /// <summary>
        /// Run Vector256. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.vector256?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector256(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector256.IsHardwareAccelerated) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("-- Vector256.IsSupported:\t{0}", Vector256.IsHardwareAccelerated));
            if (!Vector256.IsHardwareAccelerated) {
                return;
            }

#else
            // none.
#endif
        }

    }
}
