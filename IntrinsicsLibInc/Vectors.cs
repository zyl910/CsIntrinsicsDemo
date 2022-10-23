using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace IntrinsicsLib {
    /// <summary>
    /// Constants of <see cref="Vector{T}"/> .
    /// </summary>
    /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
    public static class Vectors<T> where T:struct {
        // -- Number struct --
        /// <summary>Sign bit size. When the type is an unsigned number, the value is 0.</summary>
        public static readonly int SignBits;
        /// <summary>Exponent bit size. When the type is an integer, the value is 0.</summary>
        public static readonly int ExponentBits;
        /// <summary>Mantissa bit size.</summary>
        public static readonly int MantissaBits;
        /// <summary>Sign shift bit.</summary>
        public static readonly int SignShift;
        /// <summary>Exponent shift bit.</summary>
        public static readonly int ExponentShift;
        /// <summary>Mantissa shift bit.</summary>
        public static readonly int MantissaShift;
        /// <summary>Sign mask.</summary>
        public static readonly Vector<T> SignMask;
        /// <summary>Exponent mask.</summary>
        public static readonly Vector<T> ExponentMask;
        /// <summary>Mantissa mask.</summary>
        public static readonly Vector<T> MantissaMask;
        /// <summary>Non-sign mask.</summary>
        public static readonly Vector<T> NonSignMask;
        /// <summary>Non-exponent mask.</summary>
        public static readonly Vector<T> NonExponentMask;
        /// <summary>Non-mantissa mask.</summary>
        public static readonly Vector<T> NonMantissaMask;
        /// <summary>Represents the smallest positive value that is greater than zero. When the type is an integer, the value is 0.</summary>
        public static readonly Vector<T> Epsilon;
        /// <summary>Represents the largest possible value.</summary>
        public static readonly Vector<T> MaxValue;
        /// <summary>Represents the smallest possible value.</summary>
        public static readonly Vector<T> MinValue;
        /// <summary>Represents not a number (NaN). When the type is an integer, the value is 0.</summary>
        public static readonly Vector<T> NaN;
        /// <summary>Represents negative infinity. When the type is an integer, the value is 0.</summary>
        public static readonly Vector<T> NegativeInfinity;
        /// <summary>Represents positive infinity. When the type is an integer, the value is 0.</summary>
        public static readonly Vector<T> PositiveInfinity;
        // -- Math --
        /// <summary>Represents the natural logarithmic base, specified by the constant, e.</summary>
        public static readonly Vector<T> E;
        /// <summary>Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.</summary>
        public static readonly Vector<T> Pi;
        /// <summary>Represents the number of radians in one turn, specified by the constant, τ.</summary>
        public static readonly Vector<T> Tau;
        // -- Specified value --
        /// <summary>All bit is 1.</summary>
        public static readonly Vector<T> AllOnes;
        /// <summary>Serial Value. e.g. 0,1,2,3...</summary>
        public static readonly Vector<T> Serial;
        /// <summary>Demo Value. It is a value constructed for testing purposes. It is characterized by different element values, and contains a minimum value, a maximum value.</summary>
        public static readonly Vector<T> Demo;
        // -- Zero or positive number --
        /// <summary>Value 0 .</summary>
        public static readonly Vector<T> V0;
        /// <summary>Value 1 .</summary>
        public static readonly Vector<T> V1;
        /// <summary>Value 2 .</summary>
        public static readonly Vector<T> V2;
        /// <summary>Value 3 .</summary>
        public static readonly Vector<T> V3;
        /// <summary>Value 4 .</summary>
        public static readonly Vector<T> V4;
        // -- Negative number  --
        /// <summary>Value -1 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector<T> V_1;
        /// <summary>Value -2 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector<T> V_2;
        /// <summary>Value -3 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector<T> V_3;
        /// <summary>Value -4 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector<T> V_4;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Vectors() {
            V0 = Vector<T>.Zero;
            // -- Number struct --
            unchecked {
                if (typeof(T) == typeof(Single)) {
                    SignBits = 1;
                    ExponentBits = 8;
                    MantissaBits = 23;
                    SignMask = (Vector<T>)(object)(new Vector<Single>(BitConverter.Int32BitsToSingle((Int32)0x80000000)));
                    ExponentMask = (Vector<T>)(object)(new Vector<Single>(BitConverter.Int32BitsToSingle((Int32)0x7F800000)));
                    MantissaMask = (Vector<T>)(object)(new Vector<Single>(BitConverter.Int32BitsToSingle((Int32)0x007FFFFF)));
                    Epsilon = (Vector<T>)(object)(new Vector<Single>(Single.Epsilon));
                    MaxValue = (Vector<T>)(object)(new Vector<Single>(Single.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<Single>(Single.MinValue));
                    NaN = (Vector<T>)(object)(new Vector<Single>(Single.NaN));
                    NegativeInfinity = (Vector<T>)(object)(new Vector<Single>(Single.NegativeInfinity));
                    PositiveInfinity = (Vector<T>)(object)(new Vector<Single>(Single.PositiveInfinity));
                } else if (typeof(T) == typeof(Double)) {
                    SignBits = 1;
                    ExponentBits = 11;
                    MantissaBits = 52;
                    SignMask = (Vector<T>)(object)(new Vector<Double>(BitConverter.Int64BitsToDouble((Int64)0x8000000000000000L)));
                    ExponentMask = (Vector<T>)(object)(new Vector<Double>(BitConverter.Int64BitsToDouble((Int64)0x7FF0000000000000L)));
                    MantissaMask = (Vector<T>)(object)(new Vector<Double>(BitConverter.Int64BitsToDouble((Int64)0x000FFFFFFFFFFFFFL)));
                    Epsilon = (Vector<T>)(object)(new Vector<Double>(Double.Epsilon));
                    MaxValue = (Vector<T>)(object)(new Vector<Double>(Double.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<Double>(Double.MinValue));
                    NaN = (Vector<T>)(object)(new Vector<Double>(Double.NaN));
                    NegativeInfinity = (Vector<T>)(object)(new Vector<Double>(Double.NegativeInfinity));
                    PositiveInfinity = (Vector<T>)(object)(new Vector<Double>(Double.PositiveInfinity));
                } else if (typeof(T) == typeof(SByte)) {
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 7;
                    SignMask = (Vector<T>)(object)(new Vector<SByte>((SByte)0x80));
                    ExponentMask = (Vector<T>)(object)(new Vector<SByte>(0));
                    MantissaMask = (Vector<T>)(object)(new Vector<SByte>((SByte)0x7F));
                    Epsilon = V0;
                    MaxValue = (Vector<T>)(object)(new Vector<SByte>(SByte.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<SByte>(SByte.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int16)) {
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 15;
                    SignMask = (Vector<T>)(object)(new Vector<Int16>((Int16)0x8000));
                    ExponentMask = (Vector<T>)(object)(new Vector<Int16>(0));
                    MantissaMask = (Vector<T>)(object)(new Vector<Int16>((Int16)0x7FFF));
                    Epsilon = V0;
                    MaxValue = (Vector<T>)(object)(new Vector<Int16>(Int16.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<Int16>(Int16.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int32)) {
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 31;
                    SignMask = (Vector<T>)(object)(new Vector<Int32>((Int32)0x80000000));
                    ExponentMask = (Vector<T>)(object)(new Vector<Int32>(0));
                    MantissaMask = (Vector<T>)(object)(new Vector<Int32>((Int32)0x7FFFFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector<T>)(object)(new Vector<Int32>(Int32.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<Int32>(Int32.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int64)) {
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 63;
                    SignMask = (Vector<T>)(object)(new Vector<Int64>((Int64)0x8000000000000000L));
                    ExponentMask = (Vector<T>)(object)(new Vector<Int64>(0));
                    MantissaMask = (Vector<T>)(object)(new Vector<Int64>((Int64)0x7FFFFFFFFFFFFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector<T>)(object)(new Vector<Int64>(Int64.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<Int64>(Int64.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Byte)) {
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 8;
                    SignMask = (Vector<T>)(object)(new Vector<Byte>(0));
                    ExponentMask = (Vector<T>)(object)(new Vector<Byte>(0));
                    MantissaMask = (Vector<T>)(object)(new Vector<Byte>((Byte)0xFF));
                    Epsilon = V0;
                    MaxValue = (Vector<T>)(object)(new Vector<Byte>(Byte.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<Byte>(Byte.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt16)) {
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 16;
                    SignMask = (Vector<T>)(object)(new Vector<UInt16>(0));
                    ExponentMask = (Vector<T>)(object)(new Vector<UInt16>(0));
                    MantissaMask = (Vector<T>)(object)(new Vector<UInt16>((UInt16)0xFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector<T>)(object)(new Vector<UInt16>(UInt16.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<UInt16>(UInt16.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt32)) {
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 32;
                    SignMask = (Vector<T>)(object)(new Vector<UInt32>(0));
                    ExponentMask = (Vector<T>)(object)(new Vector<UInt32>(0));
                    MantissaMask = (Vector<T>)(object)(new Vector<UInt32>((UInt32)0xFFFFFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector<T>)(object)(new Vector<UInt32>(UInt32.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<UInt32>(UInt32.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt64)) {
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 64;
                    SignMask = (Vector<T>)(object)(new Vector<UInt64>(0));
                    ExponentMask = (Vector<T>)(object)(new Vector<UInt64>(0));
                    MantissaMask = (Vector<T>)(object)(new Vector<UInt64>((UInt64)0xFFFFFFFFFFFFFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector<T>)(object)(new Vector<UInt64>(UInt64.MaxValue));
                    MinValue = (Vector<T>)(object)(new Vector<UInt64>(UInt64.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                }
                MantissaShift = 0;
                ExponentShift = MantissaShift + MantissaBits;
                SignShift = ExponentShift + ExponentBits;
                NonSignMask = ~SignMask;
                NonExponentMask = ~ExponentMask;
                NonMantissaMask = ~MantissaMask;
            }
            // -- Math --
            E = CreateByDouble(Math.E);
            Pi = CreateByDouble(Math.PI);
#if NET5_0_OR_GREATER
            Tau = CreateByDouble(Math.Tau);
#else
            Tau = CreateByDouble(Math.PI * 2);
#endif // NET5_0_OR_GREATER
            // -- Math shift --
            // -- Specified value --
            AllOnes = ~Vector<T>.Zero;
            Serial = GetSerial();
            Demo = GetDemo();
            // -- Positive number --
            V1 = CreateByDouble(1);
            V2 = CreateByDouble(2);
            V3 = CreateByDouble(3);
            V4 = CreateByDouble(4);
            // -- Negative number  --
            V_1 = CreateByDouble(-1);
            V_2 = CreateByDouble(-2);
            V_3 = CreateByDouble(-3);
            V_4 = CreateByDouble(-4);
        }

        private static Vector<T> GetSerial() {
            T[] arr = new T[Vector<T>.Count];
            for (int i = 0; i < Vector<T>.Count; ++i) {
                arr[i] = ElementByDouble(i);
            }
            Vector<T> rt = new Vector<T>(arr);
            return rt;
        }

        private static Vector<T> GetDemo() {
            if (typeof(T) == typeof(Single)) {
                return (Vector<T>)(object)Vectors<Single>.CreateUseRotate(float.MinValue, float.PositiveInfinity, float.NaN, -1.2f, 0f, 1f, 2f, 4f);
            } else if (typeof(T) == typeof(Double)) {
                return (Vector<T>)(object)Vectors<Double>.CreateUseRotate(double.MinValue, double.PositiveInfinity, -1.2, 0);
            } else if (typeof(T) == typeof(SByte)) {
                return (Vector<T>)(object)Vectors<SByte>.CreateUseRotate(sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64);
            } else if (typeof(T) == typeof(Int16)) {
                return (Vector<T>)(object)Vectors<Int16>.CreateUseRotate(short.MinValue, short.MaxValue, -1, 0, 1, 2, 3, 16384);
            } else if (typeof(T) == typeof(Int32)) {
                return (Vector<T>)(object)Vectors<Int32>.CreateUseRotate(int.MinValue, int.MaxValue, -1, 0, 1, 2, 3, 32768);
            } else if (typeof(T) == typeof(Int64)) {
                return (Vector<T>)(object)Vectors<Int64>.CreateUseRotate(long.MinValue, long.MaxValue, -1, 0, 1, 2, 3);
            } else if (typeof(T) == typeof(Byte)) {
                return (Vector<T>)(object)Vectors<Byte>.CreateUseRotate(byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128);
            } else if (typeof(T) == typeof(UInt16)) {
                return (Vector<T>)(object)Vectors<UInt16>.CreateUseRotate(ushort.MinValue, ushort.MaxValue, 0, 1, 2, 3, 4, 32768);
            } else if (typeof(T) == typeof(UInt32)) {
                return (Vector<T>)(object)Vectors<UInt32>.CreateUseRotate(uint.MinValue, uint.MaxValue, 0, 1, 2, 3, 4, 65536);
            } else if (typeof(T) == typeof(UInt64)) {
                return (Vector<T>)(object)Vectors<UInt64>.CreateUseRotate(ulong.MinValue, ulong.MaxValue, 0, 1, 2, 3);
            } else {
                return GetSerial();
            }
        }

        /// <summary>
        /// Convert double to element type value.
        /// </summary>
        /// <param name="src">Source value.</param>
        /// <returns>Return value.</returns>
        public static T ElementByDouble(double src) {
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
            } else {
                return (T)Convert.ChangeType(src, typeof(T));
            }
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> whose components are of a specified double type.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Vector<T> CreateByDouble(double src) {
            return new Vector<T>(ElementByDouble(src));
        }

        /// <summary>
        /// Create <see cref="Vector{T}"/> use rotate.
        /// </summary>
        /// <param name="list">Source value list.</param>
        /// <returns>Returns <see cref="Vector{T}"/>.</returns>
        public static Vector<T> CreateUseRotate(params T[] list) {
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

    }
}
