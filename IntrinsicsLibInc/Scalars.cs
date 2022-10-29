using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace IntrinsicsLib {
    /// <summary>
    /// Methods of scalar(number type) 标量(数值类型)的方法.
    /// </summary>
    public static class Scalars {

        /// <summary>
        /// Converts a double to the target type value.
        /// </summary>
        /// <typeparam name="T">Target type (目标类型).</typeparam>
        /// <param name="src">Source value.</param>
        /// <returns>Returns target type value.</returns>
        public static T GetByDouble<T>(double src) {
            if (typeof(T) == typeof(Single)) {
                return (T)(object)(Single)src;
            } else if (typeof(T) == typeof(Double)) {
                return (T)(object)src;
            } else if (typeof(T) == typeof(SByte)) {
                return (T)(object)(SByte)src;
            } else if (typeof(T) == typeof(Int16)) {
                return (T)(object)(Int16)src;
            } else if (typeof(T) == typeof(Int32)) {
                return (T)(object)(Int32)src;
            } else if (typeof(T) == typeof(Int64)) {
                return (T)(object)(Int64)src;
            } else if (typeof(T) == typeof(Byte)) {
                return (T)(object)(Byte)src;
            } else if (typeof(T) == typeof(UInt16)) {
                return (T)(object)(UInt16)src;
            } else if (typeof(T) == typeof(UInt32)) {
                return (T)(object)(UInt32)src;
            } else if (typeof(T) == typeof(UInt64)) {
                return (T)(object)(UInt64)src;
            } else if (typeof(T) == typeof(IntPtr)) {
                return (T)(object)(IntPtr)(long)src;
            } else if (typeof(T) == typeof(UIntPtr)) {
                return (T)(object)(UIntPtr)(ulong)src;
#if NET5_0_OR_GREATER
            } else if (typeof(T) == typeof(Half)) {
                return (T)(object)(Half)src;
#endif // NET5_0_OR_GREATER
            } else {
                return (T)Convert.ChangeType(src, typeof(T));
            }
        }

        /// <summary>
        /// Converts a bits to the target type value.
        /// </summary>
        /// <typeparam name="T">Target type (目标类型).</typeparam>
        /// <param name="src">Source value.</param>
        /// <returns>Returns target type value.</returns>
        public static T GetByBits<T>(Int64 src) {
            if (typeof(T) == typeof(Single)) {
                return (T)(object)BitConverter.Int32BitsToSingle((Int32)src);
            } else if (typeof(T) == typeof(Double)) {
                return (T)(object)BitConverter.Int64BitsToDouble(src);
            } else if (typeof(T) == typeof(SByte)) {
                return (T)(object)(SByte)src;
            } else if (typeof(T) == typeof(Int16)) {
                return (T)(object)(Int16)src;
            } else if (typeof(T) == typeof(Int32)) {
                return (T)(object)(Int32)src;
            } else if (typeof(T) == typeof(Int64)) {
                return (T)(object)(Int64)src;
            } else if (typeof(T) == typeof(Byte)) {
                return (T)(object)(Byte)src;
            } else if (typeof(T) == typeof(UInt16)) {
                return (T)(object)(UInt16)src;
            } else if (typeof(T) == typeof(UInt32)) {
                return (T)(object)(UInt32)src;
            } else if (typeof(T) == typeof(UInt64)) {
                return (T)(object)(UInt64)src;
            } else if (typeof(T) == typeof(IntPtr)) {
                return (T)(object)(IntPtr)(long)src;
            } else if (typeof(T) == typeof(UIntPtr)) {
                return (T)(object)(UIntPtr)(ulong)src;
#if NET5_0_OR_GREATER
            } else if (typeof(T) == typeof(Half)) {
                return (T)(object)Int16BitsToHalf((Int16)src);
#endif // NET5_0_OR_GREATER
            } else {
                return (T)Convert.ChangeType(src, typeof(T));
            }
        }

        /// <summary>
        /// Get a <see cref="Int64"/> bits from target type value.
        /// </summary>
        /// <typeparam name="T">Target type (目标类型).</typeparam>
        /// <param name="src">Source value.</param>
        /// <returns>Returns a <see cref="Int64"/> bits.</returns>
        public static Int64 GetInt64BitsFrom<T>(T src) where T:struct {
            if (typeof(T) == typeof(Single)) {
                return (Int64)BitConverter.SingleToInt32Bits((Single)(object)src);
            } else if (typeof(T) == typeof(Double)) {
                return (Int64)BitConverter.DoubleToInt64Bits((Double)(object)src);
            } else if (typeof(T) == typeof(SByte)) {
                return (Int64)(SByte)(object)src;
            } else if (typeof(T) == typeof(Int16)) {
                return (Int64)(Int16)(object)src;
            } else if (typeof(T) == typeof(Int32)) {
                return (Int64)(Int32)(object)src;
            } else if (typeof(T) == typeof(Int64)) {
                return (Int64)(Int64)(object)src;
            } else if (typeof(T) == typeof(Byte)) {
                return (Int64)(Byte)(object)src;
            } else if (typeof(T) == typeof(UInt16)) {
                return (Int64)(UInt16)(object)src;
            } else if (typeof(T) == typeof(UInt32)) {
                return (Int64)(UInt32)(object)src;
            } else if (typeof(T) == typeof(UInt64)) {
                return (Int64)(UInt64)(object)src;
            } else if (typeof(T) == typeof(IntPtr)) {
                return (Int64)(IntPtr)(object)src;
            } else if (typeof(T) == typeof(UIntPtr)) {
                return (Int64)(UIntPtr)(object)src;
#if NET5_0_OR_GREATER
            } else if (typeof(T) == typeof(Half)) {
                return (Int64)HalfToInt16Bits((Half)(object)src);
#endif // NET5_0_OR_GREATER
            } else {
                return (Int64)Convert.ChangeType(src, typeof(Int64));
            }
        }

#if NET5_0_OR_GREATER
        /// <summary>
        /// Converts a half-precision floating-point value into a 16-bit integer.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A 16-bit integer whose bits are identical to value.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int16 HalfToInt16Bits(Half value) {
#if NET6_0_OR_GREATER
            return BitConverter.HalfToInt16Bits(value);
#else
            unsafe {
                return *(Int16*)&value;
            }
#endif // NET6_0_OR_GREATER
        }

        /// <summary>
        /// Converts a half-precision floating-point value into a 16-bit unsigned integer.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A 16-bit unsigned integer whose bits are identical to value.</returns>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt16 HalfToUInt16Bits(Half value) {
#if NET6_0_OR_GREATER
            return BitConverter.HalfToUInt16Bits(value);
#else
            unsafe {
                return *(UInt16*)&value;
            }
#endif // NET6_0_OR_GREATER
        }

        /// <summary>
        /// Reinterprets the specified 16-bit signed integer value as a half-precision floating-point value.
        /// </summary>
        /// <param name="value">The 16-bit signed integer value to convert.</param>
        /// <returns>A half-precision floating-point value that represents the converted integer.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Half Int16BitsToHalf(Int16 value) {
#if NET6_0_OR_GREATER
            return BitConverter.Int16BitsToHalf(value);
#else
            unsafe {
                return *(Half*)&value;
            }
#endif // NET6_0_OR_GREATER
        }

        /// <summary>
        /// Reinterprets the specified 16-bit unsigned integer value as a half-precision floating-point value.
        /// </summary>
        /// <param name="value">The 16-bit unsigned integer value to convert.</param>
        /// <returns>A half-precision floating-point value that represents the converted integer.</returns>
        [CLSCompliant(false)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Half UInt16BitsToHalf(UInt16 value) {
#if NET6_0_OR_GREATER
            return BitConverter.UInt16BitsToHalf(value);
#else
            unsafe {
                return *(Half*)&value;
            }
#endif // NET6_0_OR_GREATER
        }

#endif // NET5_0_OR_GREATER

        /// <summary>
        /// Get 64-bit's bits mask.
        /// </summary>
        /// <param name="start">Bits start.</param>
        /// <param name="len">Bits length.</param>
        /// <returns>Returns mask.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static long GetBitsMask64(int start, int len) {
            unchecked {
                if (len <= 0) return 0L;
                int n = sizeof(long) * 8 - len;
                if (n < 0) n = 0;
                ulong rt = (((ulong)~0L) >> n) << start;
                return (long)rt;
            }
        }

        /// <summary>
        /// Get bits mask (取得位掩码).
        /// </summary>
        /// <typeparam name="T">Target type (目标类型).</typeparam>
        /// <param name="start">Bits start.</param>
        /// <param name="len">Bits length.</param>
        /// <returns>Returns mask.</returns>
        public static T GetBitsMask<T>(int start, int len) {
            return GetByBits<T>(GetBitsMask64(start, len));
        }

        /// <summary>
        /// Computes the ones-complement(~) (按位取反运算).
        /// </summary>
        /// <typeparam name="T">Target type (目标类型).</typeparam>
        /// <param name="src">Source value (原值).</param>
        /// <returns>The ones-complement value (按位取反后的值).</returns>
        public static T OnesComplement<T>(T src) where T:struct {
            Int64 m = ~GetInt64BitsFrom(src);
            return GetByBits<T>(m);
        }
    }

    /// <summary>
    /// Constants of scalar(number type) 标量(数值类型)的常数.
    /// </summary>
    public static class Scalars<T> where T: struct {
        /// <summary>Value 0 (0的值).</summary>
        public static readonly T V0;
        /// <summary>All bit is 1 (所有位都是1的值).</summary>
        public static readonly T AllBitsSet;
        // -- Number struct --
        /// <summary>Byte size (字节大小).</summary>
        public static readonly int ByteSize;
        /// <summary>Sign bit size (符号位位数). When the type is an unsigned number, the value is 0.</summary>
        public static readonly int SignBits;
        /// <summary>Exponent bit size (指数位数). When the type is an integer, the value is 0.</summary>
        public static readonly int ExponentBits;
        /// <summary>Mantissa bit size (尾数位数).</summary>
        public static readonly int MantissaBits;
        /// <summary>Sign shift bit.</summary>
        public static readonly int SignShift;
        /// <summary>Exponent shift bit.</summary>
        public static readonly int ExponentShift;
        /// <summary>Mantissa shift bit.</summary>
        public static readonly int MantissaShift;
        /// <summary>Sign mask.</summary>
        public static readonly T SignMask;
        /// <summary>Exponent mask.</summary>
        public static readonly T ExponentMask;
        /// <summary>Mantissa mask.</summary>
        public static readonly T MantissaMask;
        /// <summary>Non-sign mask.</summary>
        public static readonly T NonSignMask;
        /// <summary>Non-exponent mask.</summary>
        public static readonly T NonExponentMask;
        /// <summary>Non-mantissa mask.</summary>
        public static readonly T NonMantissaMask;
        /// <summary>Represents the smallest positive value that is greater than zero. When the type is an integer, the value is 1.</summary>
        public static readonly T Epsilon;
        /// <summary>Represents the largest possible value.</summary>
        public static readonly T MaxValue;
        /// <summary>Represents the smallest possible value.</summary>
        public static readonly T MinValue;
        /// <summary>Represents not a number (NaN). When the type is an integer, the value is 0.</summary>
        public static readonly T NaN;
        /// <summary>Represents negative infinity. When the type is an integer, the value is 0.</summary>
        public static readonly T NegativeInfinity;
        /// <summary>Represents positive infinity. When the type is an integer, the value is 0.</summary>
        public static readonly T PositiveInfinity;
        // -- Math --
        /// <summary>Represents the natural logarithmic base, specified by the constant, e.</summary>
        public static readonly T E;
        /// <summary>Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.</summary>
        public static readonly T Pi;
        /// <summary>Represents the number of radians in one turn, specified by the constant, τ.</summary>
        public static readonly T Tau;
        // -- Mask --
        /// <summary>1 bits mask.</summary>
        public static readonly T MaskBits1;
        /// <summary>2 bits mask.</summary>
        public static readonly T MaskBits2;
        /// <summary>4 bits mask.</summary>
        public static readonly T MaskBits4;
        /// <summary>8 bits mask.</summary>
        public static readonly T MaskBits8;
        /// <summary>16 bits mask.</summary>
        public static readonly T MaskBits16;
        /// <summary>32 bits mask.</summary>
        public static readonly T MaskBits32;
        // -- Positive number --
        /// <summary>Value 1 .</summary>
        public static readonly T V1;
        /// <summary>Value 2 .</summary>
        public static readonly T V2;
        /// <summary>Value 3 .</summary>
        public static readonly T V3;
        /// <summary>Value 4 .</summary>
        public static readonly T V4;
        /// <summary>Value 5 .</summary>
        public static readonly T V5;
        /// <summary>Value 6 .</summary>
        public static readonly T V6;
        /// <summary>Value 7 .</summary>
        public static readonly T V7;
        /// <summary>Value 8 .</summary>
        public static readonly T V8;
        /// <summary>Value 127 (SByte.MaxValue).</summary>
        public static readonly T V127;
        /// <summary>Value 255 (Byte.MaxValue).</summary>
        public static readonly T V255;
        /// <summary>Value 32767 (Int16.MaxValue) .</summary>
        public static readonly T V32767;
        /// <summary>Value 65535 (UInt16.MaxValue) .</summary>
        public static readonly T V65535;
        /// <summary>Value 2147483647 (Int32.MaxValue) .</summary>
        public static readonly T V2147483647;
        /// <summary>Value 4294967295 (UInt32.MaxValue) .</summary>
        public static readonly T V4294967295;
        // -- Negative number  --
        /// <summary>Value -1 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly T V_1;
        /// <summary>Value -2 .</summary>
        public static readonly T V_2;
        /// <summary>Value -3 .</summary>
        public static readonly T V_3;
        /// <summary>Value -4 .</summary>
        public static readonly T V_4;
        /// <summary>Value -5 .</summary>
        public static readonly T V_5;
        /// <summary>Value -6 .</summary>
        public static readonly T V_6;
        /// <summary>Value -7 .</summary>
        public static readonly T V_7;
        /// <summary>Value -8 .</summary>
        public static readonly T V_8;
        /// <summary>Value -128 (SByte.MinValue).</summary>
        public static readonly T V_128;
        /// <summary>Value -32768 (Int16.MinValue) .</summary>
        public static readonly T V_32768;
        /// <summary>Value -2147483648 (Int32.MinValue) .</summary>
        public static readonly T V_2147483648;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Scalars() {
            V0 = default;
            AllBitsSet = Scalars.OnesComplement(V0);
            // -- Number struct --
            unchecked {
                if (typeof(T) == typeof(Single)) {
                    ByteSize = sizeof(Single);
                    SignBits = 1;
                    ExponentBits = 8;
                    MantissaBits = 23;
                    SignMask = (T)(object)BitConverter.Int32BitsToSingle((Int32)0x80000000);
                    ExponentMask = (T)(object)BitConverter.Int32BitsToSingle((Int32)0x7F800000);
                    MantissaMask = (T)(object)BitConverter.Int32BitsToSingle((Int32)0x007FFFFF);
                    NonSignMask = (T)(object)BitConverter.Int32BitsToSingle(~(Int32)0x80000000);
                    NonExponentMask = (T)(object)BitConverter.Int32BitsToSingle(~(Int32)0x7F800000);
                    NonMantissaMask = (T)(object)BitConverter.Int32BitsToSingle(~(Int32)0x007FFFFF);
                    Epsilon = (T)(object)Single.Epsilon;
                    MaxValue = (T)(object)Single.MaxValue;
                    MinValue = (T)(object)Single.MinValue;
                    NaN = (T)(object)Single.NaN;
                    NegativeInfinity = (T)(object)Single.NegativeInfinity;
                    PositiveInfinity = (T)(object)Single.PositiveInfinity;
                } else if (typeof(T) == typeof(Double)) {
                    ByteSize = sizeof(Double);
                    SignBits = 1;
                    ExponentBits = 11;
                    MantissaBits = 52;
                    SignMask = (T)(object)BitConverter.Int64BitsToDouble((Int64)0x8000000000000000L);
                    ExponentMask = (T)(object)BitConverter.Int64BitsToDouble((Int64)0x7FF0000000000000L);
                    MantissaMask = (T)(object)BitConverter.Int64BitsToDouble((Int64)0x000FFFFFFFFFFFFFL);
                    NonSignMask = (T)(object)BitConverter.Int64BitsToDouble(~(Int64)0x8000000000000000L);
                    NonExponentMask = (T)(object)BitConverter.Int64BitsToDouble(~(Int64)0x7FF0000000000000L);
                    NonMantissaMask = (T)(object)BitConverter.Int64BitsToDouble(~(Int64)0x000FFFFFFFFFFFFFL);
                    Epsilon = (T)(object)Double.Epsilon;
                    MaxValue = (T)(object)Double.MaxValue;
                    MinValue = (T)(object)Double.MinValue;
                    NaN = (T)(object)Double.NaN;
                    NegativeInfinity = (T)(object)Double.NegativeInfinity;
                    PositiveInfinity = (T)(object)Double.PositiveInfinity;
                } else if (typeof(T) == typeof(SByte)) {
                    ByteSize = sizeof(SByte);
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 7;
                    SignMask = (T)(object)(SByte)(0x80);
                    ExponentMask = (T)(object)(SByte)(0);
                    MantissaMask = (T)(object)(SByte)(0x7F);
                    NonSignMask = (T)(object)(SByte)(~0x80);
                    NonExponentMask = (T)(object)(SByte)(~0);
                    NonMantissaMask = (T)(object)(SByte)(~0x7F);
                    Epsilon = Scalars.GetByDouble<T>(1);
                    MaxValue = (T)(object)SByte.MaxValue;
                    MinValue = (T)(object)SByte.MinValue;
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int16)) {
                    ByteSize = sizeof(Int16);
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 15;
                    SignMask = (T)(object)(Int16)(0x8000);
                    ExponentMask = (T)(object)(Int16)(0);
                    MantissaMask = (T)(object)(Int16)(0x7FFF);
                    NonSignMask = (T)(object)(Int16)(~0x8000);
                    NonExponentMask = (T)(object)(Int16)(~0);
                    NonMantissaMask = (T)(object)(Int16)(~0x7FFF);
                    Epsilon = Scalars.GetByDouble<T>(1);
                    MaxValue = (T)(object)Int16.MaxValue;
                    MinValue = (T)(object)Int16.MinValue;
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int32)) {
                    ByteSize = sizeof(Int32);
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 31;
                    SignMask = (T)(object)(Int32)(0x80000000);
                    ExponentMask = (T)(object)(Int32)(0);
                    MantissaMask = (T)(object)(Int32)(0x7FFFFFFF);
                    NonSignMask = (T)(object)(Int32)(~0x80000000);
                    NonExponentMask = (T)(object)(Int32)(~0);
                    NonMantissaMask = (T)(object)(Int32)(~0x7FFFFFFF);
                    Epsilon = Scalars.GetByDouble<T>(1);
                    MaxValue = (T)(object)Int32.MaxValue;
                    MinValue = (T)(object)Int32.MinValue;
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int64)) {
                    ByteSize = sizeof(Int64);
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 63;
                    SignMask = (T)(object)(Int64)(0x8000000000000000L);
                    ExponentMask = (T)(object)(Int64)(0);
                    MantissaMask = (T)(object)(Int64)(0x7FFFFFFFFFFFFFFF);
                    NonSignMask = (T)(object)(Int64)(~0x8000000000000000L);
                    NonExponentMask = (T)(object)(Int64)(~0);
                    NonMantissaMask = (T)(object)(Int64)(~0x7FFFFFFFFFFFFFFF);
                    Epsilon = Scalars.GetByDouble<T>(1);
                    MaxValue = (T)(object)Int64.MaxValue;
                    MinValue = (T)(object)Int64.MinValue;
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Byte)) {
                    ByteSize = sizeof(Byte);
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 8;
                    SignMask = (T)(object)(Byte)(0);
                    ExponentMask = (T)(object)(Byte)(0);
                    MantissaMask = (T)(object)(Byte)(0xFF);
                    NonSignMask = (T)(object)(Byte)(~0);
                    NonExponentMask = (T)(object)(Byte)(~0);
                    NonMantissaMask = (T)(object)(Byte)(~0xFF);
                    Epsilon = Scalars.GetByDouble<T>(1);
                    MaxValue = (T)(object)Byte.MaxValue;
                    MinValue = (T)(object)Byte.MinValue;
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt16)) {
                    ByteSize = sizeof(UInt16);
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 16;
                    SignMask = (T)(object)(UInt16)(0);
                    ExponentMask = (T)(object)(UInt16)(0);
                    MantissaMask = (T)(object)(UInt16)(0xFFFF);
                    NonSignMask = (T)(object)(UInt16)(~0);
                    NonExponentMask = (T)(object)(UInt16)(~0);
                    NonMantissaMask = (T)(object)(UInt16)(~0xFFFF);
                    Epsilon = Scalars.GetByDouble<T>(1);
                    MaxValue = (T)(object)UInt16.MaxValue;
                    MinValue = (T)(object)UInt16.MinValue;
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt32)) {
                    ByteSize = sizeof(UInt32);
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 32;
                    SignMask = (T)(object)(UInt32)(0);
                    ExponentMask = (T)(object)(UInt32)(0);
                    MantissaMask = (T)(object)(UInt32)(0xFFFFFFFF);
                    NonSignMask = (T)(object)(UInt32)(~0);
                    NonExponentMask = (T)(object)(UInt32)(~0);
                    NonMantissaMask = (T)(object)(UInt32)(~0xFFFFFFFF);
                    Epsilon = Scalars.GetByDouble<T>(1);
                    MaxValue = (T)(object)UInt32.MaxValue;
                    MinValue = (T)(object)UInt32.MinValue;
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt64)) {
                    ByteSize = sizeof(UInt64);
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 64;
                    SignMask = (T)(object)(UInt64)(0);
                    ExponentMask = (T)(object)(UInt64)(0);
                    MantissaMask = (T)(object)(UInt64)(0xFFFFFFFFFFFFFFFFL);
                    NonSignMask = (T)(object)(UInt64)(~0L);
                    NonExponentMask = (T)(object)(UInt64)(~0L);
                    NonMantissaMask = (T)(object)(UInt64)(~0xFFFFFFFFFFFFFFFFL);
                    Epsilon = Scalars.GetByDouble<T>(1);
                    MaxValue = (T)(object)UInt64.MaxValue;
                    MinValue = (T)(object)UInt64.MinValue;
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                }
            }
            MantissaShift = 0;
            ExponentShift = MantissaShift + MantissaBits;
            SignShift = ExponentShift + ExponentBits;
            // -- Math --
            E = Scalars.GetByDouble<T>(Math.E);
            Pi = Scalars.GetByDouble<T>(Math.PI);
#if NET5_0_OR_GREATER
            Tau = Scalars.GetByDouble<T>(Math.Tau);
#else
            Tau = CreateByDouble(Math.PI * 2);
#endif // NET5_0_OR_GREATER
            // -- Math shift --
            // -- Mask --
            MaskBits1 = Scalars.GetByBits<T>(0x1);
            MaskBits2 = Scalars.GetByBits<T>(0x3);
            MaskBits4 = Scalars.GetByBits<T>(0xF);
            MaskBits8 = Scalars.GetByBits<T>(0xFF);
            MaskBits16 = Scalars.GetByBits<T>(0xFFFF);
            MaskBits32 = Scalars.GetByBits<T>(0xFFFFFFFF);
            // -- Positive number --
            V1 = Scalars.GetByDouble<T>(1);
            V2 = Scalars.GetByDouble<T>(2);
            V3 = Scalars.GetByDouble<T>(3);
            V4 = Scalars.GetByDouble<T>(4);
            V5 = Scalars.GetByDouble<T>(5);
            V6 = Scalars.GetByDouble<T>(6);
            V7 = Scalars.GetByDouble<T>(7);
            V8 = Scalars.GetByDouble<T>(8);
            V127 = Scalars.GetByDouble<T>(127);
            V255 = Scalars.GetByDouble<T>(255);
            V32767 = Scalars.GetByDouble<T>(32767);
            V65535 = Scalars.GetByDouble<T>(65535);
            V2147483647 = Scalars.GetByDouble<T>(2147483647);
            V4294967295 = Scalars.GetByDouble<T>(4294967295);
            // -- Negative number  --
            V_1 = Scalars.GetByDouble<T>(-1);
            V_2 = Scalars.GetByDouble<T>(-2);
            V_3 = Scalars.GetByDouble<T>(-3);
            V_4 = Scalars.GetByDouble<T>(-4);
            V_5 = Scalars.GetByDouble<T>(-5);
            V_6 = Scalars.GetByDouble<T>(-6);
            V_7 = Scalars.GetByDouble<T>(-7);
            V_8 = Scalars.GetByDouble<T>(-8);
            V_128 = Scalars.GetByDouble<T>(-128);
            V_32768 = Scalars.GetByDouble<T>(-32768);
            V_2147483648 = Scalars.GetByDouble<T>(-2147483648);
        }

    }

}