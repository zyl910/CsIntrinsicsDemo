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
using Zyl.VectorTraits;

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

        public static bool ShowFull = true;

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
                //RunX86(tw, indent);
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
        /// WriteLine with format.
        /// </summary>
        /// <param name="tw">The TextWriter.</param>
        /// <param name="indent">The indent.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The args</param>
        private static void WriteLine(TextWriter tw, string indent, string format, params object?[] args) {
            if (null == tw) return;
            TraitsUtil.WriteLine(indent, tw, format, args);
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
            WriteLine(tw, indent, "Create by T[]:\t{0}", Vectors.Create(arr));
            var parr = new ReadOnlySpan<double>(arr);
            WriteLine(tw, indent, "Create by Span<T>:\t{0}", Vectors.Create(new Span<double>(arr)));
            WriteLine(tw, indent, "Create by ReadOnlySpan<T>:\t{0}", Vectors.Create(parr));
            if (true) {
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
                var parr2 = MemoryMarshal.AsBytes(parr);
                WriteLine(tw, indent, "Create by ReadOnlySpan<byte>:\t{0}", Vectors.Create<double>(parr2));
#else
#endif // NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            }
            WriteLine(tw, indent, "Vectors.CreatePadding(arrByte):\t{0}", Vectors.CreatePadding(arrByte));
            WriteLine(tw, indent, "Vectors.CreateRotate(arrByte):\t{0}", Vectors.CreateRotate(arrByte));
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
#if NET6_0_OR_GREATER
            RunInfoVectors<nint>(tw, indent);
            RunInfoVectors<nuint>(tw, indent);
#endif // NET6_0_OR_GREATER
            unsafe {
                // When the return type is `T`, you cannot get a pointer. // CS0211	Cannot take the address of the given expression
                //fixed (void* p = &Vectors<ulong>.Zero) {
                //    WriteLine(tw, indent, "&Vectors<ulong>.Zero:\t0x{0:X}", (IntPtr)p);
                //}
                // When the return type is `ref readonly T`, you cannot get a pointer.
                fixed (void* p = &Vectors<ulong>.V0) {
                    WriteLine(tw, indent, "&Vectors<ulong>.V0:\t0x{0:X}", (IntPtr)p);
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
                WriteLine(tw, indent, "V0:\t{0}", Scalars<T>.V0);
                WriteLine(tw, indent, "AllBitsSet:\t{0}", Scalars<T>.AllBitsSet);
            }
            WriteLine(tw, indent, "ByteSize:\t{0}", Scalars<T>.ByteSize);
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Scalars<T>.SignBits, Scalars<T>.ExponentBits, Scalars<T>.MantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Scalars<T>.SignShift, Scalars<T>.ExponentShift, Scalars<T>.MantissaShift));
                WriteLine(tw, indent, "BitSizeMask:\t{0}", Scalars<T>.BitSizeMask);
                WriteLine(tw, indent, "ExponentBias:\t{0}", Scalars<T>.ExponentBias);
                WriteLine(tw, indent, "SignMask:\t{0}", Scalars<T>.SignMask);
                WriteLine(tw, indent, "ExponentMask:\t{0}", Scalars<T>.ExponentMask);
                WriteLine(tw, indent, "MantissaMask:\t{0}", Scalars<T>.MantissaMask);
                WriteLine(tw, indent, "NonSignMask:\t{0}", Scalars<T>.NonSignMask);
                WriteLine(tw, indent, "NonExponentMask:\t{0}", Scalars<T>.NonExponentMask);
                WriteLine(tw, indent, "NonMantissaMask:\t{0}", Scalars<T>.NonMantissaMask);
                WriteLine(tw, indent, "SignMask:\t{0}", Scalars<T>.SignMask);
                WriteLine(tw, indent, "ExponentMask:\t{0}", Scalars<T>.ExponentMask);
                WriteLine(tw, indent, "MantissaMask:\t{0}", Scalars<T>.MantissaMask);
                WriteLine(tw, indent, "NonSignMask:\t{0}", Scalars<T>.NonSignMask);
                WriteLine(tw, indent, "NonExponentMask:\t{0}", Scalars<T>.NonExponentMask);
                WriteLine(tw, indent, "NonMantissaMask:\t{0}", Scalars<T>.NonMantissaMask);
                WriteLine(tw, indent, "Epsilon:\t{0}", Scalars<T>.Epsilon);
                WriteLine(tw, indent, "MaxValue:\t{0}", Scalars<T>.MaxValue);
                WriteLine(tw, indent, "MinValue:\t{0}", Scalars<T>.MinValue);
                WriteLine(tw, indent, "NaN:\t{0}", Scalars<T>.NaN);
                WriteLine(tw, indent, "NegativeInfinity:\t{0}", Scalars<T>.NegativeInfinity);
                WriteLine(tw, indent, "PositiveInfinity:\t{0}", Scalars<T>.PositiveInfinity);
                WriteLine(tw, indent, "NormOne:\t{0}", Scalars<T>.NormOne);
                WriteLine(tw, indent, "FixedShift:\t{0}", Scalars<T>.FixedShift);
                WriteLine(tw, indent, "FixedOne:\t{0}", Scalars<T>.FixedOne);
                WriteLine(tw, indent, "FixedOneDouble:\t{0}", Scalars<T>.FixedOneDouble);
                WriteLine(tw, indent, "E:\t{0}", Scalars<T>.E);
                WriteLine(tw, indent, "Pi:\t{0}", Scalars<T>.Pi);
                WriteLine(tw, indent, "Tau:\t{0}", Scalars<T>.Tau);
                WriteLine(tw, indent, "V0:\t{0}", Scalars<T>.V0);
                WriteLine(tw, indent, "V1:\t{0}", Scalars<T>.V1);
                WriteLine(tw, indent, "V127:\t{0}", Scalars<T>.V127);
                WriteLine(tw, indent, "V255:\t{0}", Scalars<T>.V255);
                WriteLine(tw, indent, "V32767:\t{0}", Scalars<T>.V32767);
                WriteLine(tw, indent, "V65535:\t{0}", Scalars<T>.V65535);
                WriteLine(tw, indent, "V2147483647:\t{0}", Scalars<T>.V2147483647);
                WriteLine(tw, indent, "V4294967295:\t{0}", Scalars<T>.V4294967295);
                WriteLine(tw, indent, "V_1:\t{0}", Scalars<T>.V_1);
                WriteLine(tw, indent, "V_128:\t{0}", Scalars<T>.V_128);
                WriteLine(tw, indent, "V_32768:\t{0}", Scalars<T>.V_32768);
                WriteLine(tw, indent, "V_2147483648:\t{0}", Scalars<T>.V_2147483648);
                WriteLine(tw, indent, "VReciprocal127:\t{0}", Scalars<T>.VReciprocal127);
                WriteLine(tw, indent, "VReciprocal255:\t{0}", Scalars<T>.VReciprocal255);
                WriteLine(tw, indent, "VReciprocal32767:\t{0}", Scalars<T>.VReciprocal32767);
                WriteLine(tw, indent, "VReciprocal65535:\t{0}", Scalars<T>.VReciprocal65535);
                WriteLine(tw, indent, "VReciprocal2147483647:\t{0}", Scalars<T>.VReciprocal2147483647);
                WriteLine(tw, indent, "VReciprocal4294967295:\t{0}", Scalars<T>.VReciprocal4294967295);
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
                WriteLine(tw, indent, "ElementByteSize:\t{0}", Vectors<T>.ElementByteSize);
            }
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vectors<T>.ElementSignBits, Vectors<T>.ElementExponentBits, Vectors<T>.ElementMantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vectors<T>.ElementSignShift, Vectors<T>.ElementExponentShift, Vectors<T>.ElementMantissaShift));
                WriteLine(tw, indent, "ElementV0:\t{0}", Vectors<T>.ElementV0);
                WriteLine(tw, indent, "ElementAllBitsSet:\t{0}", Vectors<T>.ElementAllBitsSet);
                WriteLine(tw, indent, "ElementSignMask:\t{0}", Vectors<T>.ElementSignMask);
                WriteLine(tw, indent, "ElementExponentMask:\t{0}", Vectors<T>.ElementExponentMask);
                WriteLine(tw, indent, "ElementMantissaMask:\t{0}", Vectors<T>.ElementMantissaMask);
                WriteLine(tw, indent, "ElementNonSignMask:\t{0}", Vectors<T>.ElementNonSignMask);
                WriteLine(tw, indent, "ElementNonExponentMask:\t{0}", Vectors<T>.ElementNonExponentMask);
                WriteLine(tw, indent, "ElementNonMantissaMask:\t{0}", Vectors<T>.ElementNonMantissaMask);
                WriteLine(tw, indent, "ElementEpsilon:\t{0}", Vectors<T>.ElementEpsilon);
                WriteLine(tw, indent, "ElementMaxValue:\t{0}", Vectors<T>.ElementMaxValue);
                WriteLine(tw, indent, "ElementMinValue:\t{0}", Vectors<T>.ElementMinValue);
                WriteLine(tw, indent, "ElementNaN:\t{0}", Vectors<T>.ElementNaN);
                WriteLine(tw, indent, "ElementNegativeInfinity:\t{0}", Vectors<T>.ElementNegativeInfinity);
                WriteLine(tw, indent, "ElementPositiveInfinity:\t{0}", Vectors<T>.ElementPositiveInfinity);
                WriteLine(tw, indent, "AllBitsSet:\t{0}", Vectors<T>.AllBitsSet);
                WriteLine(tw, indent, "SignMask:\t{0}", Vectors<T>.SignMask);
                WriteLine(tw, indent, "ExponentMask:\t{0}", Vectors<T>.ExponentMask);
                WriteLine(tw, indent, "MantissaMask:\t{0}", Vectors<T>.MantissaMask);
                WriteLine(tw, indent, "NonSignMask:\t{0}", Vectors<T>.NonSignMask);
                WriteLine(tw, indent, "NonExponentMask:\t{0}", Vectors<T>.NonExponentMask);
                WriteLine(tw, indent, "NonMantissaMask:\t{0}", Vectors<T>.NonMantissaMask);
                WriteLine(tw, indent, "Epsilon:\t{0}", Vectors<T>.Epsilon);
                WriteLine(tw, indent, "MaxValue:\t{0}", Vectors<T>.MaxValue);
                WriteLine(tw, indent, "MinValue:\t{0}", Vectors<T>.MinValue);
                WriteLine(tw, indent, "NaN:\t{0}", Vectors<T>.NaN);
                WriteLine(tw, indent, "NegativeInfinity:\t{0}", Vectors<T>.NegativeInfinity);
                WriteLine(tw, indent, "PositiveInfinity:\t{0}", Vectors<T>.PositiveInfinity);
                WriteLine(tw, indent, "FixedOne:\t{0}", Vectors<T>.FixedOne);
                WriteLine(tw, indent, "E:\t{0}", Vectors<T>.E);
                WriteLine(tw, indent, "Pi:\t{0}", Vectors<T>.Pi);
                WriteLine(tw, indent, "Tau:\t{0}", Vectors<T>.Tau);
                WriteLine(tw, indent, "V0:\t{0}", Vectors<T>.V0);
                WriteLine(tw, indent, "V1:\t{0}", Vectors<T>.V1);
                WriteLine(tw, indent, "V127:\t{0}", Vectors<T>.V127);
                WriteLine(tw, indent, "V255:\t{0}", Vectors<T>.V255);
                WriteLine(tw, indent, "V32767:\t{0}", Vectors<T>.V32767);
                WriteLine(tw, indent, "V65535:\t{0}", Vectors<T>.V65535);
                WriteLine(tw, indent, "V2147483647:\t{0}", Vectors<T>.V2147483647);
                WriteLine(tw, indent, "V4294967295:\t{0}", Vectors<T>.V4294967295);
                WriteLine(tw, indent, "V_1:\t{0}", Vectors<T>.V_1);
                WriteLine(tw, indent, "V_128:\t{0}", Vectors<T>.V_128);
                WriteLine(tw, indent, "V_32768:\t{0}", Vectors<T>.V_32768);
                WriteLine(tw, indent, "V_2147483648:\t{0}", Vectors<T>.V_2147483648);
                WriteLine(tw, indent, "VReciprocal127:\t{0}", Vectors<T>.VReciprocal127);
                WriteLine(tw, indent, "VReciprocal255:\t{0}", Vectors<T>.VReciprocal255);
                WriteLine(tw, indent, "VReciprocal32767:\t{0}", Vectors<T>.VReciprocal32767);
                WriteLine(tw, indent, "VReciprocal65535:\t{0}", Vectors<T>.VReciprocal65535);
                WriteLine(tw, indent, "VReciprocal2147483647:\t{0}", Vectors<T>.VReciprocal2147483647);
                WriteLine(tw, indent, "VReciprocal4294967295:\t{0}", Vectors<T>.VReciprocal4294967295);
            }
            WriteLine(tw, indent, "Serial:\t{0}", Vectors<T>.Serial);
            WriteLine(tw, indent, "SerialNegative:\t{0}", Vectors<T>.SerialNegative);
            WriteLine(tw, indent, "Demo:\t{0}", Vectors<T>.Demo);
            WriteLine(tw, indent, "MaskBitPosSerial:\t{0}", Vectors<T>.MaskBitPosSerial);
            WriteLine(tw, indent, "MaskBitPosSerialRotate:\t{0}", Vectors<T>.MaskBitPosSerialRotate);
            WriteLine(tw, indent, "MaskBitsSerial:\t{0}", Vectors<T>.MaskBitsSerial);
            WriteLine(tw, indent, "MaskBitsSerialRotate:\t{0}", Vectors<T>.MaskBitsSerialRotate);
            if (ShowFull) {
                WriteLine(tw, indent, "InterlacedSign:\t{0}", Vectors<T>.InterlacedSign);
                WriteLine(tw, indent, "InterlacedSignNegative:\t{0}", Vectors<T>.InterlacedSignNegative);
                WriteLine(tw, indent, "MaskBits8:\t{0}", Vectors<T>.MaskBits8);
                WriteLine(tw, indent, "MaskBits16:\t{0}", Vectors<T>.MaskBits16);
                WriteLine(tw, indent, "MaskBits32:\t{0}", Vectors<T>.MaskBits32);
                WriteLine(tw, indent, "XyXMask:\t{0}", Vectors<T>.XyXMask);
                WriteLine(tw, indent, "XyYMask:\t{0}", Vectors<T>.XyYMask);
                WriteLine(tw, indent, "XyzwXMask:\t{0}", Vectors<T>.XyzwXMask);
                WriteLine(tw, indent, "XyzwYMask:\t{0}", Vectors<T>.XyzwYMask);
                WriteLine(tw, indent, "XyzwZMask:\t{0}", Vectors<T>.XyzwZMask);
                WriteLine(tw, indent, "XyzwWMask:\t{0}", Vectors<T>.XyzwWMask);
                WriteLine(tw, indent, "XyzwNotXMask:\t{0}", Vectors<T>.XyzwNotXMask);
                WriteLine(tw, indent, "XyzwNotYMask:\t{0}", Vectors<T>.XyzwNotYMask);
                WriteLine(tw, indent, "XyzwNotZMask:\t{0}", Vectors<T>.XyzwNotZMask);
                WriteLine(tw, indent, "XyzwNotWMask:\t{0}", Vectors<T>.XyzwNotWMask);
                WriteLine(tw, indent, "XyzwXNormOne:\t{0}", Vectors<T>.XyzwXNormOne);
                WriteLine(tw, indent, "XyzwYNormOne:\t{0}", Vectors<T>.XyzwYNormOne);
                WriteLine(tw, indent, "XyzwZNormOne:\t{0}", Vectors<T>.XyzwZNormOne);
                WriteLine(tw, indent, "XyzwWNormOne:\t{0}", Vectors<T>.XyzwWNormOne);
                WriteLine(tw, indent, "RgbaANormOne:\t{0}", Vectors<T>.RgbaANormOne);
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
                WriteLine(tw, indent, "ElementByteSize:\t{0}", Vector64s<T>.ElementByteSize);
            }
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vector64s<T>.ElementSignBits, Vector64s<T>.ElementExponentBits, Vector64s<T>.ElementMantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vector64s<T>.ElementSignShift, Vector64s<T>.ElementExponentShift, Vector64s<T>.ElementMantissaShift));
                WriteLine(tw, indent, "ElementV0:\t{0}", Vector64s<T>.ElementV0);
                WriteLine(tw, indent, "ElementAllBitsSet:\t{0}", Vector64s<T>.ElementAllBitsSet);
                WriteLine(tw, indent, "ElementSignMask:\t{0}", Vector64s<T>.ElementSignMask);
                WriteLine(tw, indent, "ElementExponentMask:\t{0}", Vector64s<T>.ElementExponentMask);
                WriteLine(tw, indent, "ElementMantissaMask:\t{0}", Vector64s<T>.ElementMantissaMask);
                WriteLine(tw, indent, "ElementNonSignMask:\t{0}", Vector64s<T>.ElementNonSignMask);
                WriteLine(tw, indent, "ElementNonExponentMask:\t{0}", Vector64s<T>.ElementNonExponentMask);
                WriteLine(tw, indent, "ElementNonMantissaMask:\t{0}", Vector64s<T>.ElementNonMantissaMask);
                WriteLine(tw, indent, "ElementEpsilon:\t{0}", Vector64s<T>.ElementEpsilon);
                WriteLine(tw, indent, "ElementMaxValue:\t{0}", Vector64s<T>.ElementMaxValue);
                WriteLine(tw, indent, "ElementMinValue:\t{0}", Vector64s<T>.ElementMinValue);
                WriteLine(tw, indent, "ElementNaN:\t{0}", Vector64s<T>.ElementNaN);
                WriteLine(tw, indent, "ElementNegativeInfinity:\t{0}", Vector64s<T>.ElementNegativeInfinity);
                WriteLine(tw, indent, "ElementPositiveInfinity:\t{0}", Vector64s<T>.ElementPositiveInfinity);
                WriteLine(tw, indent, "AllBitsSet:\t{0}", Vector64s<T>.AllBitsSet);
                WriteLine(tw, indent, "SignMask:\t{0}", Vector64s<T>.SignMask);
                WriteLine(tw, indent, "ExponentMask:\t{0}", Vector64s<T>.ExponentMask);
                WriteLine(tw, indent, "MantissaMask:\t{0}", Vector64s<T>.MantissaMask);
                WriteLine(tw, indent, "NonSignMask:\t{0}", Vector64s<T>.NonSignMask);
                WriteLine(tw, indent, "NonExponentMask:\t{0}", Vector64s<T>.NonExponentMask);
                WriteLine(tw, indent, "NonMantissaMask:\t{0}", Vector64s<T>.NonMantissaMask);
                WriteLine(tw, indent, "Epsilon:\t{0}", Vector64s<T>.Epsilon);
                WriteLine(tw, indent, "MaxValue:\t{0}", Vector64s<T>.MaxValue);
                WriteLine(tw, indent, "MinValue:\t{0}", Vector64s<T>.MinValue);
                WriteLine(tw, indent, "NaN:\t{0}", Vector64s<T>.NaN);
                WriteLine(tw, indent, "NegativeInfinity:\t{0}", Vector64s<T>.NegativeInfinity);
                WriteLine(tw, indent, "PositiveInfinity:\t{0}", Vector64s<T>.PositiveInfinity);
                WriteLine(tw, indent, "FixedOne:\t{0}", Vector64s<T>.FixedOne);
                WriteLine(tw, indent, "E:\t{0}", Vector64s<T>.E);
                WriteLine(tw, indent, "Pi:\t{0}", Vector64s<T>.Pi);
                WriteLine(tw, indent, "Tau:\t{0}", Vector64s<T>.Tau);
                WriteLine(tw, indent, "V0:\t{0}", Vector64s<T>.V0);
                WriteLine(tw, indent, "V1:\t{0}", Vector64s<T>.V1);
                WriteLine(tw, indent, "V127:\t{0}", Vector64s<T>.V127);
                WriteLine(tw, indent, "V255:\t{0}", Vector64s<T>.V255);
                WriteLine(tw, indent, "V32767:\t{0}", Vector64s<T>.V32767);
                WriteLine(tw, indent, "V65535:\t{0}", Vector64s<T>.V65535);
                WriteLine(tw, indent, "V2147483647:\t{0}", Vector64s<T>.V2147483647);
                WriteLine(tw, indent, "V4294967295:\t{0}", Vector64s<T>.V4294967295);
                WriteLine(tw, indent, "V_1:\t{0}", Vector64s<T>.V_1);
                WriteLine(tw, indent, "V_128:\t{0}", Vector64s<T>.V_128);
                WriteLine(tw, indent, "V_32768:\t{0}", Vector64s<T>.V_32768);
                WriteLine(tw, indent, "V_2147483648:\t{0}", Vector64s<T>.V_2147483648);
                WriteLine(tw, indent, "VReciprocal127:\t{0}", Vector64s<T>.VReciprocal127);
                WriteLine(tw, indent, "VReciprocal255:\t{0}", Vector64s<T>.VReciprocal255);
                WriteLine(tw, indent, "VReciprocal32767:\t{0}", Vector64s<T>.VReciprocal32767);
                WriteLine(tw, indent, "VReciprocal65535:\t{0}", Vector64s<T>.VReciprocal65535);
                WriteLine(tw, indent, "VReciprocal2147483647:\t{0}", Vector64s<T>.VReciprocal2147483647);
                WriteLine(tw, indent, "VReciprocal4294967295:\t{0}", Vector64s<T>.VReciprocal4294967295);
            }
            WriteLine(tw, indent, "Serial:\t{0}", Vector64s<T>.Serial);
            WriteLine(tw, indent, "SerialNegative:\t{0}", Vector64s<T>.SerialNegative);
            WriteLine(tw, indent, "Demo:\t{0}", Vector64s<T>.Demo);
            WriteLine(tw, indent, "MaskBitPosSerial:\t{0}", Vector64s<T>.MaskBitPosSerial);
            WriteLine(tw, indent, "MaskBitPosSerialRotate:\t{0}", Vector64s<T>.MaskBitPosSerialRotate);
            WriteLine(tw, indent, "MaskBitsSerial:\t{0}", Vector64s<T>.MaskBitsSerial);
            WriteLine(tw, indent, "MaskBitsSerialRotate:\t{0}", Vector64s<T>.MaskBitsSerialRotate);
            if (ShowFull) {
                WriteLine(tw, indent, "InterlacedSign:\t{0}", Vector64s<T>.InterlacedSign);
                WriteLine(tw, indent, "InterlacedSignNegative:\t{0}", Vector64s<T>.InterlacedSignNegative);
                WriteLine(tw, indent, "MaskBits8:\t{0}", Vector64s<T>.MaskBits8);
                WriteLine(tw, indent, "MaskBits16:\t{0}", Vector64s<T>.MaskBits16);
                WriteLine(tw, indent, "MaskBits32:\t{0}", Vector64s<T>.MaskBits32);
                WriteLine(tw, indent, "XyXMask:\t{0}", Vector64s<T>.XyXMask);
                WriteLine(tw, indent, "XyYMask:\t{0}", Vector64s<T>.XyYMask);
                WriteLine(tw, indent, "XyzwXMask:\t{0}", Vector64s<T>.XyzwXMask);
                WriteLine(tw, indent, "XyzwYMask:\t{0}", Vector64s<T>.XyzwYMask);
                WriteLine(tw, indent, "XyzwZMask:\t{0}", Vector64s<T>.XyzwZMask);
                WriteLine(tw, indent, "XyzwWMask:\t{0}", Vector64s<T>.XyzwWMask);
                WriteLine(tw, indent, "XyzwNotXMask:\t{0}", Vector64s<T>.XyzwNotXMask);
                WriteLine(tw, indent, "XyzwNotYMask:\t{0}", Vector64s<T>.XyzwNotYMask);
                WriteLine(tw, indent, "XyzwNotZMask:\t{0}", Vector64s<T>.XyzwNotZMask);
                WriteLine(tw, indent, "XyzwNotWMask:\t{0}", Vector64s<T>.XyzwNotWMask);
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
                WriteLine(tw, indent, "ElementByteSize:\t{0}", Vector128s<T>.ElementByteSize);
            }
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vector128s<T>.ElementSignBits, Vector128s<T>.ElementExponentBits, Vector128s<T>.ElementMantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vector128s<T>.ElementSignShift, Vector128s<T>.ElementExponentShift, Vector128s<T>.ElementMantissaShift));
                WriteLine(tw, indent, "ElementV0:\t{0}", Vector128s<T>.ElementV0);
                WriteLine(tw, indent, "ElementAllBitsSet:\t{0}", Vector128s<T>.ElementAllBitsSet);
                WriteLine(tw, indent, "ElementSignMask:\t{0}", Vector128s<T>.ElementSignMask);
                WriteLine(tw, indent, "ElementExponentMask:\t{0}", Vector128s<T>.ElementExponentMask);
                WriteLine(tw, indent, "ElementMantissaMask:\t{0}", Vector128s<T>.ElementMantissaMask);
                WriteLine(tw, indent, "ElementNonSignMask:\t{0}", Vector128s<T>.ElementNonSignMask);
                WriteLine(tw, indent, "ElementNonExponentMask:\t{0}", Vector128s<T>.ElementNonExponentMask);
                WriteLine(tw, indent, "ElementNonMantissaMask:\t{0}", Vector128s<T>.ElementNonMantissaMask);
                WriteLine(tw, indent, "ElementEpsilon:\t{0}", Vector128s<T>.ElementEpsilon);
                WriteLine(tw, indent, "ElementMaxValue:\t{0}", Vector128s<T>.ElementMaxValue);
                WriteLine(tw, indent, "ElementMinValue:\t{0}", Vector128s<T>.ElementMinValue);
                WriteLine(tw, indent, "ElementNaN:\t{0}", Vector128s<T>.ElementNaN);
                WriteLine(tw, indent, "ElementNegativeInfinity:\t{0}", Vector128s<T>.ElementNegativeInfinity);
                WriteLine(tw, indent, "ElementPositiveInfinity:\t{0}", Vector128s<T>.ElementPositiveInfinity);
                WriteLine(tw, indent, "AllBitsSet:\t{0}", Vector128s<T>.AllBitsSet);
                WriteLine(tw, indent, "SignMask:\t{0}", Vector128s<T>.SignMask);
                WriteLine(tw, indent, "ExponentMask:\t{0}", Vector128s<T>.ExponentMask);
                WriteLine(tw, indent, "MantissaMask:\t{0}", Vector128s<T>.MantissaMask);
                WriteLine(tw, indent, "NonSignMask:\t{0}", Vector128s<T>.NonSignMask);
                WriteLine(tw, indent, "NonExponentMask:\t{0}", Vector128s<T>.NonExponentMask);
                WriteLine(tw, indent, "NonMantissaMask:\t{0}", Vector128s<T>.NonMantissaMask);
                WriteLine(tw, indent, "Epsilon:\t{0}", Vector128s<T>.Epsilon);
                WriteLine(tw, indent, "MaxValue:\t{0}", Vector128s<T>.MaxValue);
                WriteLine(tw, indent, "MinValue:\t{0}", Vector128s<T>.MinValue);
                WriteLine(tw, indent, "NaN:\t{0}", Vector128s<T>.NaN);
                WriteLine(tw, indent, "NegativeInfinity:\t{0}", Vector128s<T>.NegativeInfinity);
                WriteLine(tw, indent, "PositiveInfinity:\t{0}", Vector128s<T>.PositiveInfinity);
                WriteLine(tw, indent, "FixedOne:\t{0}", Vector128s<T>.FixedOne);
                WriteLine(tw, indent, "E:\t{0}", Vector128s<T>.E);
                WriteLine(tw, indent, "Pi:\t{0}", Vector128s<T>.Pi);
                WriteLine(tw, indent, "Tau:\t{0}", Vector128s<T>.Tau);
                WriteLine(tw, indent, "V0:\t{0}", Vector128s<T>.V0);
                WriteLine(tw, indent, "V1:\t{0}", Vector128s<T>.V1);
                WriteLine(tw, indent, "V127:\t{0}", Vector128s<T>.V127);
                WriteLine(tw, indent, "V255:\t{0}", Vector128s<T>.V255);
                WriteLine(tw, indent, "V32767:\t{0}", Vector128s<T>.V32767);
                WriteLine(tw, indent, "V65535:\t{0}", Vector128s<T>.V65535);
                WriteLine(tw, indent, "V2147483647:\t{0}", Vector128s<T>.V2147483647);
                WriteLine(tw, indent, "V4294967295:\t{0}", Vector128s<T>.V4294967295);
                WriteLine(tw, indent, "V_1:\t{0}", Vector128s<T>.V_1);
                WriteLine(tw, indent, "V_128:\t{0}", Vector128s<T>.V_128);
                WriteLine(tw, indent, "V_32768:\t{0}", Vector128s<T>.V_32768);
                WriteLine(tw, indent, "V_2147483648:\t{0}", Vector128s<T>.V_2147483648);
                WriteLine(tw, indent, "VReciprocal127:\t{0}", Vector128s<T>.VReciprocal127);
                WriteLine(tw, indent, "VReciprocal255:\t{0}", Vector128s<T>.VReciprocal255);
                WriteLine(tw, indent, "VReciprocal32767:\t{0}", Vector128s<T>.VReciprocal32767);
                WriteLine(tw, indent, "VReciprocal65535:\t{0}", Vector128s<T>.VReciprocal65535);
                WriteLine(tw, indent, "VReciprocal2147483647:\t{0}", Vector128s<T>.VReciprocal2147483647);
                WriteLine(tw, indent, "VReciprocal4294967295:\t{0}", Vector128s<T>.VReciprocal4294967295);
            }
            WriteLine(tw, indent, "Serial:\t{0}", Vector128s<T>.Serial);
            WriteLine(tw, indent, "SerialNegative:\t{0}", Vector128s<T>.SerialNegative);
            WriteLine(tw, indent, "Demo:\t{0}", Vector128s<T>.Demo);
            WriteLine(tw, indent, "MaskBitPosSerial:\t{0}", Vector128s<T>.MaskBitPosSerial);
            WriteLine(tw, indent, "MaskBitPosSerialRotate:\t{0}", Vector128s<T>.MaskBitPosSerialRotate);
            WriteLine(tw, indent, "MaskBitsSerial:\t{0}", Vector128s<T>.MaskBitsSerial);
            WriteLine(tw, indent, "MaskBitsSerialRotate:\t{0}", Vector128s<T>.MaskBitsSerialRotate);
            if (ShowFull) {
                WriteLine(tw, indent, "InterlacedSign:\t{0}", Vector128s<T>.InterlacedSign);
                WriteLine(tw, indent, "InterlacedSignNegative:\t{0}", Vector128s<T>.InterlacedSignNegative);
                WriteLine(tw, indent, "MaskBits8:\t{0}", Vector128s<T>.MaskBits8);
                WriteLine(tw, indent, "MaskBits16:\t{0}", Vector128s<T>.MaskBits16);
                WriteLine(tw, indent, "MaskBits32:\t{0}", Vector128s<T>.MaskBits32);
                WriteLine(tw, indent, "XyXMask:\t{0}", Vector128s<T>.XyXMask);
                WriteLine(tw, indent, "XyYMask:\t{0}", Vector128s<T>.XyYMask);
                WriteLine(tw, indent, "XyzwXMask:\t{0}", Vector128s<T>.XyzwXMask);
                WriteLine(tw, indent, "XyzwYMask:\t{0}", Vector128s<T>.XyzwYMask);
                WriteLine(tw, indent, "XyzwZMask:\t{0}", Vector128s<T>.XyzwZMask);
                WriteLine(tw, indent, "XyzwWMask:\t{0}", Vector128s<T>.XyzwWMask);
                WriteLine(tw, indent, "XyzwNotXMask:\t{0}", Vector128s<T>.XyzwNotXMask);
                WriteLine(tw, indent, "XyzwNotYMask:\t{0}", Vector128s<T>.XyzwNotYMask);
                WriteLine(tw, indent, "XyzwNotZMask:\t{0}", Vector128s<T>.XyzwNotZMask);
                WriteLine(tw, indent, "XyzwNotWMask:\t{0}", Vector128s<T>.XyzwNotWMask);
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
                WriteLine(tw, indent, "ElementByteSize:\t{0}", Vector256s<T>.ElementByteSize);
            }
            tw.WriteLine(indent + string.Format("SignBits-ExponentBits-MantissaBits:\t{0}-{1}-{2}", Vector256s<T>.ElementSignBits, Vector256s<T>.ElementExponentBits, Vector256s<T>.ElementMantissaBits));
            if (ShowFull) {
                tw.WriteLine(indent + string.Format("SignShift-ExponentShift-MantissaShift:\t{0}-{1}-{2}", Vector256s<T>.ElementSignShift, Vector256s<T>.ElementExponentShift, Vector256s<T>.ElementMantissaShift));
                WriteLine(tw, indent, "ElementV0:\t{0}", Vector256s<T>.ElementV0);
                WriteLine(tw, indent, "ElementAllBitsSet:\t{0}", Vector256s<T>.ElementAllBitsSet);
                WriteLine(tw, indent, "ElementSignMask:\t{0}", Vector256s<T>.ElementSignMask);
                WriteLine(tw, indent, "ElementExponentMask:\t{0}", Vector256s<T>.ElementExponentMask);
                WriteLine(tw, indent, "ElementMantissaMask:\t{0}", Vector256s<T>.ElementMantissaMask);
                WriteLine(tw, indent, "ElementNonSignMask:\t{0}", Vector256s<T>.ElementNonSignMask);
                WriteLine(tw, indent, "ElementNonExponentMask:\t{0}", Vector256s<T>.ElementNonExponentMask);
                WriteLine(tw, indent, "ElementNonMantissaMask:\t{0}", Vector256s<T>.ElementNonMantissaMask);
                WriteLine(tw, indent, "ElementEpsilon:\t{0}", Vector256s<T>.ElementEpsilon);
                WriteLine(tw, indent, "ElementMaxValue:\t{0}", Vector256s<T>.ElementMaxValue);
                WriteLine(tw, indent, "ElementMinValue:\t{0}", Vector256s<T>.ElementMinValue);
                WriteLine(tw, indent, "ElementNaN:\t{0}", Vector256s<T>.ElementNaN);
                WriteLine(tw, indent, "ElementNegativeInfinity:\t{0}", Vector256s<T>.ElementNegativeInfinity);
                WriteLine(tw, indent, "ElementPositiveInfinity:\t{0}", Vector256s<T>.ElementPositiveInfinity);
                WriteLine(tw, indent, "AllBitsSet:\t{0}", Vector256s<T>.AllBitsSet);
                WriteLine(tw, indent, "SignMask:\t{0}", Vector256s<T>.SignMask);
                WriteLine(tw, indent, "ExponentMask:\t{0}", Vector256s<T>.ExponentMask);
                WriteLine(tw, indent, "MantissaMask:\t{0}", Vector256s<T>.MantissaMask);
                WriteLine(tw, indent, "NonSignMask:\t{0}", Vector256s<T>.NonSignMask);
                WriteLine(tw, indent, "NonExponentMask:\t{0}", Vector256s<T>.NonExponentMask);
                WriteLine(tw, indent, "NonMantissaMask:\t{0}", Vector256s<T>.NonMantissaMask);
                WriteLine(tw, indent, "Epsilon:\t{0}", Vector256s<T>.Epsilon);
                WriteLine(tw, indent, "MaxValue:\t{0}", Vector256s<T>.MaxValue);
                WriteLine(tw, indent, "MinValue:\t{0}", Vector256s<T>.MinValue);
                WriteLine(tw, indent, "NaN:\t{0}", Vector256s<T>.NaN);
                WriteLine(tw, indent, "NegativeInfinity:\t{0}", Vector256s<T>.NegativeInfinity);
                WriteLine(tw, indent, "PositiveInfinity:\t{0}", Vector256s<T>.PositiveInfinity);
                WriteLine(tw, indent, "FixedOne:\t{0}", Vector256s<T>.FixedOne);
                WriteLine(tw, indent, "E:\t{0}", Vector256s<T>.E);
                WriteLine(tw, indent, "Pi:\t{0}", Vector256s<T>.Pi);
                WriteLine(tw, indent, "Tau:\t{0}", Vector256s<T>.Tau);
                WriteLine(tw, indent, "V0:\t{0}", Vector256s<T>.V0);
                WriteLine(tw, indent, "V1:\t{0}", Vector256s<T>.V1);
                WriteLine(tw, indent, "V127:\t{0}", Vector256s<T>.V127);
                WriteLine(tw, indent, "V255:\t{0}", Vector256s<T>.V255);
                WriteLine(tw, indent, "V32767:\t{0}", Vector256s<T>.V32767);
                WriteLine(tw, indent, "V65535:\t{0}", Vector256s<T>.V65535);
                WriteLine(tw, indent, "V2147483647:\t{0}", Vector256s<T>.V2147483647);
                WriteLine(tw, indent, "V4294967295:\t{0}", Vector256s<T>.V4294967295);
                WriteLine(tw, indent, "V_1:\t{0}", Vector256s<T>.V_1);
                WriteLine(tw, indent, "V_128:\t{0}", Vector256s<T>.V_128);
                WriteLine(tw, indent, "V_32768:\t{0}", Vector256s<T>.V_32768);
                WriteLine(tw, indent, "V_2147483648:\t{0}", Vector256s<T>.V_2147483648);
                WriteLine(tw, indent, "VReciprocal127:\t{0}", Vector256s<T>.VReciprocal127);
                WriteLine(tw, indent, "VReciprocal255:\t{0}", Vector256s<T>.VReciprocal255);
                WriteLine(tw, indent, "VReciprocal32767:\t{0}", Vector256s<T>.VReciprocal32767);
                WriteLine(tw, indent, "VReciprocal65535:\t{0}", Vector256s<T>.VReciprocal65535);
                WriteLine(tw, indent, "VReciprocal2147483647:\t{0}", Vector256s<T>.VReciprocal2147483647);
                WriteLine(tw, indent, "VReciprocal4294967295:\t{0}", Vector256s<T>.VReciprocal4294967295);
            }
            WriteLine(tw, indent, "Serial:\t{0}", Vector256s<T>.Serial);
            WriteLine(tw, indent, "SerialNegative:\t{0}", Vector256s<T>.SerialNegative);
            WriteLine(tw, indent, "Demo:\t{0}", Vector256s<T>.Demo);
            WriteLine(tw, indent, "MaskBitPosSerial:\t{0}", Vector256s<T>.MaskBitPosSerial);
            WriteLine(tw, indent, "MaskBitPosSerialRotate:\t{0}", Vector256s<T>.MaskBitPosSerialRotate);
            WriteLine(tw, indent, "MaskBitsSerial:\t{0}", Vector256s<T>.MaskBitsSerial);
            WriteLine(tw, indent, "MaskBitsSerialRotate:\t{0}", Vector256s<T>.MaskBitsSerialRotate);
            if (ShowFull) {
                WriteLine(tw, indent, "InterlacedSign:\t{0}", Vector256s<T>.InterlacedSign);
                WriteLine(tw, indent, "InterlacedSignNegative:\t{0}", Vector256s<T>.InterlacedSignNegative);
                WriteLine(tw, indent, "MaskBits8:\t{0}", Vector256s<T>.MaskBits8);
                WriteLine(tw, indent, "MaskBits16:\t{0}", Vector256s<T>.MaskBits16);
                WriteLine(tw, indent, "MaskBits32:\t{0}", Vector256s<T>.MaskBits32);
                WriteLine(tw, indent, "XyXMask:\t{0}", Vector256s<T>.XyXMask);
                WriteLine(tw, indent, "XyYMask:\t{0}", Vector256s<T>.XyYMask);
                WriteLine(tw, indent, "XyzwXMask:\t{0}", Vector256s<T>.XyzwXMask);
                WriteLine(tw, indent, "XyzwYMask:\t{0}", Vector256s<T>.XyzwYMask);
                WriteLine(tw, indent, "XyzwZMask:\t{0}", Vector256s<T>.XyzwZMask);
                WriteLine(tw, indent, "XyzwWMask:\t{0}", Vector256s<T>.XyzwWMask);
                WriteLine(tw, indent, "XyzwNotXMask:\t{0}", Vector256s<T>.XyzwNotXMask);
                WriteLine(tw, indent, "XyzwNotYMask:\t{0}", Vector256s<T>.XyzwNotYMask);
                WriteLine(tw, indent, "XyzwNotZMask:\t{0}", Vector256s<T>.XyzwNotZMask);
                WriteLine(tw, indent, "XyzwNotWMask:\t{0}", Vector256s<T>.XyzwNotWMask);
            }
        }

    }
}
