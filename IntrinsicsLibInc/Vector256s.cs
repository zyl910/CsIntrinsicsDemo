using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Intrinsics;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace IntrinsicsLib {
    /// <summary>
    /// Constants of <see cref="Vector256{T}"/> .
    /// </summary>
    /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
    public static class Vector256s<T> where T : struct {
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
        public static readonly Vector256<T> SignMask;
        /// <summary>Exponent mask.</summary>
        public static readonly Vector256<T> ExponentMask;
        /// <summary>Mantissa mask.</summary>
        public static readonly Vector256<T> MantissaMask;
        /// <summary>Non-sign mask.</summary>
        public static readonly Vector256<T> NonSignMask;
        /// <summary>Non-exponent mask.</summary>
        public static readonly Vector256<T> NonExponentMask;
        /// <summary>Non-mantissa mask.</summary>
        public static readonly Vector256<T> NonMantissaMask;
        /// <summary>Represents the smallest positive value that is greater than zero. When the type is an integer, the value is 0.</summary>
        public static readonly Vector256<T> Epsilon;
        /// <summary>Represents the largest possible value.</summary>
        public static readonly Vector256<T> MaxValue;
        /// <summary>Represents the smallest possible value.</summary>
        public static readonly Vector256<T> MinValue;
        /// <summary>Represents not a number (NaN). When the type is an integer, the value is 0.</summary>
        public static readonly Vector256<T> NaN;
        /// <summary>Represents negative infinity. When the type is an integer, the value is 0.</summary>
        public static readonly Vector256<T> NegativeInfinity;
        /// <summary>Represents positive infinity. When the type is an integer, the value is 0.</summary>
        public static readonly Vector256<T> PositiveInfinity;
        // -- Math --
        /// <summary>Represents the natural logarithmic base, specified by the constant, e.</summary>
        public static readonly Vector256<T> E;
        /// <summary>Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π.</summary>
        public static readonly Vector256<T> Pi;
        /// <summary>Represents the number of radians in one turn, specified by the constant, τ.</summary>
        public static readonly Vector256<T> Tau;
        // -- Specified value --
        /// <summary>All bit is 1.</summary>
        public static readonly Vector256<T> AllOnes;
        /// <summary>Serial Value. e.g. 0,1,2,3...</summary>
        public static readonly Vector256<T> Serial;
        /// <summary>Demo Value. It is a value constructed for testing purposes. It is characterized by different element values, and contains a minimum value, a maximum value.</summary>
        public static readonly Vector256<T> Demo;
        // -- Zero or positive number --
        /// <summary>Value 0 .</summary>
        public static readonly Vector256<T> V0;
        /// <summary>Value 1 .</summary>
        public static readonly Vector256<T> V1;
        /// <summary>Value 2 .</summary>
        public static readonly Vector256<T> V2;
        /// <summary>Value 3 .</summary>
        public static readonly Vector256<T> V3;
        /// <summary>Value 4 .</summary>
        public static readonly Vector256<T> V4;
        // -- Negative number  --
        /// <summary>Value -1 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector256<T> V_1;
        /// <summary>Value -2 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector256<T> V_2;
        /// <summary>Value -3 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector256<T> V_3;
        /// <summary>Value -4 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector256<T> V_4;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Vector256s() {
            V0 = Vector256<T>.Zero;
            // -- Number struct --
            unchecked {
                if (typeof(T) == typeof(Single)) {
                    SignBits = 1;
                    ExponentBits = 8;
                    MantissaBits = 23;
                    SignMask = (Vector256<T>)(object)(Vector256.Create(BitConverter.Int32BitsToSingle((Int32)0x80000000)));
                    ExponentMask = (Vector256<T>)(object)(Vector256.Create(BitConverter.Int32BitsToSingle((Int32)0x7F800000)));
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create(BitConverter.Int32BitsToSingle((Int32)0x007FFFFF)));
                    Epsilon = (Vector256<T>)(object)(Vector256.Create(Single.Epsilon));
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(Single.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(Single.MinValue));
                    NaN = (Vector256<T>)(object)(Vector256.Create(Single.NaN));
                    NegativeInfinity = (Vector256<T>)(object)(Vector256.Create(Single.NegativeInfinity));
                    PositiveInfinity = (Vector256<T>)(object)(Vector256.Create(Single.PositiveInfinity));
                } else if (typeof(T) == typeof(Double)) {
                    SignBits = 1;
                    ExponentBits = 11;
                    MantissaBits = 52;
                    SignMask = (Vector256<T>)(object)(Vector256.Create(BitConverter.Int64BitsToDouble((Int64)0x8000000000000000L)));
                    ExponentMask = (Vector256<T>)(object)(Vector256.Create(BitConverter.Int64BitsToDouble((Int64)0x7FF0000000000000L)));
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create(BitConverter.Int64BitsToDouble((Int64)0x000FFFFFFFFFFFFFL)));
                    Epsilon = (Vector256<T>)(object)(Vector256.Create(Double.Epsilon));
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(Double.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(Double.MinValue));
                    NaN = (Vector256<T>)(object)(Vector256.Create(Double.NaN));
                    NegativeInfinity = (Vector256<T>)(object)(Vector256.Create(Double.NegativeInfinity));
                    PositiveInfinity = (Vector256<T>)(object)(Vector256.Create(Double.PositiveInfinity));
                } else if (typeof(T) == typeof(SByte)) {
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 7;
                    SignMask = (Vector256<T>)(object)(Vector256.Create((SByte)0x80));
                    ExponentMask = V0;
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create((SByte)0x7F));
                    Epsilon = V0;
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(SByte.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(SByte.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int16)) {
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 15;
                    SignMask = (Vector256<T>)(object)(Vector256.Create((Int16)0x8000));
                    ExponentMask = V0;
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create((Int16)0x7FFF));
                    Epsilon = V0;
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(Int16.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(Int16.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int32)) {
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 31;
                    SignMask = (Vector256<T>)(object)(Vector256.Create((Int32)0x80000000));
                    ExponentMask = V0;
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create((Int32)0x7FFFFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(Int32.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(Int32.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Int64)) {
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 63;
                    SignMask = (Vector256<T>)(object)(Vector256.Create((Int64)0x8000000000000000L));
                    ExponentMask = V0;
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create((Int64)0x7FFFFFFFFFFFFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(Int64.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(Int64.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(Byte)) {
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 8;
                    SignMask = V0;
                    ExponentMask = V0;
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create((Byte)0xFF));
                    Epsilon = V0;
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(Byte.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(Byte.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt16)) {
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 16;
                    SignMask = V0;
                    ExponentMask = V0;
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create((UInt16)0xFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(UInt16.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(UInt16.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt32)) {
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 32;
                    SignMask = V0;
                    ExponentMask = V0;
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create((UInt32)0xFFFFFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(UInt32.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(UInt32.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                } else if (typeof(T) == typeof(UInt64)) {
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 64;
                    SignMask = V0;
                    ExponentMask = V0;
                    MantissaMask = (Vector256<T>)(object)(Vector256.Create((UInt64)0xFFFFFFFFFFFFFFFF));
                    Epsilon = V0;
                    MaxValue = (Vector256<T>)(object)(Vector256.Create(UInt64.MaxValue));
                    MinValue = (Vector256<T>)(object)(Vector256.Create(UInt64.MinValue));
                    NaN = V0;
                    NegativeInfinity = V0;
                    PositiveInfinity = V0;
                }
                MantissaShift = 0;
                ExponentShift = MantissaShift + MantissaBits;
                SignShift = ExponentShift + ExponentBits;
                NonSignMask = OnesComplement(SignMask);
                NonExponentMask = OnesComplement(ExponentMask);
                NonMantissaMask = OnesComplement(MantissaMask);
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
            AllOnes = OnesComplement(Vector256<T>.Zero);
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

        /// <summary>
        /// Computes the ones-complement (~) of a vector.
        /// </summary>
        /// <param name="src">The vector whose ones-complement is to be computed.</param>
        /// <returns>A vector whose elements are the ones-complement of the corresponding elements in <paramref name="src"/>.</returns>
        public static unsafe Vector256<T> OnesComplement(Vector256<T> src) {
#if NET7_0_OR_GREATER
            return ~src;
#else
            int cnt = Vector256<ulong>.Count;
            ulong* p = (ulong*)&src;
            for (int i = 0; i < cnt; ++i) {
                p[i] = ~p[i];
            }
            return src;
#endif // NET7_0_OR_GREATER
        }

        /// <summary>
        /// Creates a new <see cref="Vector256{T}"/> from a given array.
        /// </summary>
        /// <param name="arr">Source values.</param>
        /// <returns>A new <see cref="Vector256{T}"/> with its elements set to the first Count elements from <paramref name="arr"/>.</returns>
        public static Vector256<T> Create(T[] arr) {
            //fixed(T* p= &arr[0]) { // CS0208	Cannot take the address of, get the size of, or declare a pointer to a managed type ('T')
            //}
            //Vector256<T>[] varr = new Vector256<T>[1];
            //Buffer.BlockCopy(arr, 0, varr, 0, Vector256<byte>.Count);
            //Vector256<T> rt = varr[0];
            Vector256<T> rt = Unsafe.ReadUnaligned<Vector256<T>>(ref Unsafe.As<T, byte>(ref arr[0]));
            return rt;
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
        /// Creates a <see cref="Vector256{T}"/> whose components are of a specified double type.
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Vector256<T> CreateByDouble(double src) {
#if NET7_0_OR_GREATER
            return Vector256.Create(ElementByDouble(src));
#else
            return CreateUseRotate(ElementByDouble(src));
#endif // NET7_0_OR_GREATER
        }

        /// <summary>
        /// Create <see cref="Vector256{T}"/> use rotate.
        /// </summary>
        /// <param name="list">Source value list.</param>
        /// <returns>Returns <see cref="Vector256{T}"/>.</returns>
        public static Vector256<T> CreateUseRotate(params T[] list) {
            if (null == list || list.Length <= 0) return Vector256<T>.Zero;
            T[] arr = new T[Vector256<T>.Count];
            int idx = 0;
            for (int i = 0; i < arr.Length; ++i) {
                arr[i] = list[idx];
                ++idx;
                if (idx >= list.Length) idx = 0;
            }
            Vector256<T> rt = Create(arr);
            return rt;
        }

        /// <summary>
        /// Get serial value.
        /// </summary>
        /// <returns>Return serial value.</returns>
        private static Vector256<T> GetSerial() {
            T[] arr = new T[Vector256<T>.Count];
            for (int i = 0; i < Vector256<T>.Count; ++i) {
                arr[i] = ElementByDouble(i);
            }
            Vector256<T> rt = Create(arr);
            return rt;
        }

        /// <summary>
        /// Get demo value.
        /// </summary>
        /// <returns>Return demo value.</returns>
        private static Vector256<T> GetDemo() {
            if (typeof(T) == typeof(Single)) {
                return (Vector256<T>)(object)Vector256s<Single>.CreateUseRotate(float.MinValue, float.PositiveInfinity, float.NaN, -1.2f, 0f, 1f, 2f, 4f);
            } else if (typeof(T) == typeof(Double)) {
                return (Vector256<T>)(object)Vector256s<Double>.CreateUseRotate(double.MinValue, double.PositiveInfinity, -1.2, 0);
            } else if (typeof(T) == typeof(SByte)) {
                return (Vector256<T>)(object)Vector256s<SByte>.CreateUseRotate(sbyte.MinValue, sbyte.MaxValue, -1, 0, 1, 2, 3, 64);
            } else if (typeof(T) == typeof(Int16)) {
                return (Vector256<T>)(object)Vector256s<Int16>.CreateUseRotate(short.MinValue, short.MaxValue, -1, 0, 1, 2, 3, 16384);
            } else if (typeof(T) == typeof(Int32)) {
                return (Vector256<T>)(object)Vector256s<Int32>.CreateUseRotate(int.MinValue, int.MaxValue, -1, 0, 1, 2, 3, 32768);
            } else if (typeof(T) == typeof(Int64)) {
                return (Vector256<T>)(object)Vector256s<Int64>.CreateUseRotate(long.MinValue, long.MaxValue, -1, 0, 1, 2, 3);
            } else if (typeof(T) == typeof(Byte)) {
                return (Vector256<T>)(object)Vector256s<Byte>.CreateUseRotate(byte.MinValue, byte.MaxValue, 0, 1, 2, 3, 4, 128);
            } else if (typeof(T) == typeof(UInt16)) {
                return (Vector256<T>)(object)Vector256s<UInt16>.CreateUseRotate(ushort.MinValue, ushort.MaxValue, 0, 1, 2, 3, 4, 32768);
            } else if (typeof(T) == typeof(UInt32)) {
                return (Vector256<T>)(object)Vector256s<UInt32>.CreateUseRotate(uint.MinValue, uint.MaxValue, 0, 1, 2, 3, 4, 65536);
            } else if (typeof(T) == typeof(UInt64)) {
                return (Vector256<T>)(object)Vector256s<UInt64>.CreateUseRotate(ulong.MinValue, ulong.MaxValue, 0, 1, 2, 3);
            } else {
                return GetSerial();
            }
        }

    }
}
