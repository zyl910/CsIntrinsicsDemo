﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using System.Collections;

namespace IntrinsicsLib {

    /// <summary>
    /// Methods of <see cref="Vector{T}"/> .
    /// </summary>
    public static class Vectors {

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> instance with all elements initialized to the specified value.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="value">The value that all elements will be initialized to.</param>
        /// <returns>A new <see cref="Vector{T}"/> with all elements initialized to value.</returns>
        /// <seealso cref="Vector{T}(T)"/>
        public static Vector<T> Create<T>(T value) where T : struct {
            return new Vector<T>(value);
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a given array.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as an array of objects of type <typeparamref name="T"/>.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <seealso cref="Vector{T}(T[])"/>
        public static Vector<T> Create<T>(T[] values) where T:struct {
            return new Vector<T>(values);
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a given array starting at a specified index position.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as an array of objects of type <typeparamref name="T"/>.</param>
        /// <param name="index">The starting index position from which to create the vector.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">The <paramref name="index"/> is less than zero. The <paramref name="length"/> of values minus index is less than Length.</exception>
        /// <seealso cref="Vector{T}(T[], int)"/>
        public static Vector<T> Create<T>(T[] values, int index) where T : struct {
            return new Vector<T>(values, index);
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a given read-only span of bytes.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">A read-only span of bytes that contains the values to add to the vector.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least Count elements.</exception>
        /// <seealso cref="Vector{T}(ReadOnlySpan{byte})"/>
        public static Vector<T> Create<T>(ReadOnlySpan<byte> values) where T : struct {
#if NETCOREAPP3_0_OR_GREATER
            return new Vector<T>(values);
#else
            if (values.Length < Vector<byte>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            return Unsafe.ReadUnaligned<Vector<T>>(ref MemoryMarshal.GetReference(values)); // Only .NET Core 2.1+, .NET Standard 2.1+ .
#else
            unsafe {
                fixed (byte* p = values) {
                    return *(Vector<T>*)(void*)p;
                }
            }
#endif // NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
#endif // NETCOREAPP3_0_OR_GREATER
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="ReadOnlySpan{T}"/>.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as a read-only span of objects of type <typeparamref name="T"/>.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least Count elements.</exception>
        /// <seealso cref="Vector{T}(ReadOnlySpan{T})"/>
        public static Vector<T> Create<T>(ReadOnlySpan<T> values) where T : struct {
#if NETCOREAPP3_0_OR_GREATER
            return new Vector<T>(values);
#else
            if (values.Length < Vector<T>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            return Unsafe.ReadUnaligned<Vector<T>>(ref Unsafe.As<T, byte>(ref MemoryMarshal.GetReference(values)));
#else
            //return Unsafe.ReadUnaligned<Vector<T>>(ref Unsafe.As<T, byte>(ref TraitsUtil.GetReference(values))); // CS8329	Cannot use method 'TraitsUtil.GetReference<T>(ReadOnlySpan<T>)' as a ref or out value because it is a readonly variable.
            int cnt = Vector<T>.Count;
            T[] arr = new T[cnt];
            for(int i=0; i<cnt; ++i) {
                arr[i] = values[i];
            }
            return Vectors.Create<T>(arr);
#endif // NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
#endif // NETCOREAPP3_0_OR_GREATER
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="Span{T}"/>.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as a span of objects of type <typeparamref name="T"/>.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least Count elements.</exception>
        /// <seealso cref="Vector{T}(Span{T})"/>
        public static Vector<T> Create<T>(Span<T> values) where T : struct {
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            return new Vector<T>(values);
#else
            if (values.Length < Vector<T>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
            return Unsafe.ReadUnaligned<Vector<T>>(ref Unsafe.As<T, byte>(ref TraitsUtil.GetReference(values)));
#endif // NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector{T}"/> from a given array starting at a specified index position.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as an array of objects of type <typeparamref name="T"/>.</param>
        /// <param name="index">The starting index position from which to create the vector.</param>
        /// <param name="length">The rotation length of the element.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <exception cref="IndexOutOfRangeException">The <paramref name="index"/> is less than zero. The <paramref name="length"/> of values minus index is less than Length.</exception>
        public static Vector<T> CreateRotate<T>(T[] values, int index, int length) where T : struct {
            T[] arr = new T[Vector<T>.Count];
            int idxEnd = index + length;
            int idx = index;
            if (null == values || values.Length <= 0) return Vector<T>.Zero;
            if (index < 0 || idxEnd > values.Length) {
                throw new IndexOutOfRangeException(string.Format("Index({0}) was outside the bounds{1} of the array!", index, values.Length));
            }
            for (int i = 0; i < arr.Length; ++i) {
                arr[i] = values[idx];
                ++idx;
                if (idx >= idxEnd) idx = index;
            }
            Vector<T> rt = Create(arr);
            return rt;
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector{T}"/> from a given array.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as an array of objects of type <typeparamref name="T"/>.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        public static Vector<T> CreateRotate<T>(params T[] values) where T : struct {
            return CreateRotate<T>(values, 0, values.Length);
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="Func{T, TResult}"/>.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="func">A function that gets the value of each element. Prototype: `T func(int index)`, `index` is element index.</param>
        /// <returns>A new <see cref="Vector{T}"/> from a from the given <see cref="Func{T, TResult}"/>.</returns>
        public static Vector<T> CreateByFunc<T>(Func<int, T> func) where T : struct {
            if (null == func) throw new ArgumentNullException(nameof(func));
            T[] arr = new T[Vector<T>.Count];
            for(int i=0; i < Vector<T>.Count; ++i) {
                arr[i] = func(i);
            }
            Vector<T> rt = Create(arr);
            return rt;
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="Func{T1, T2, TResult}"/>.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <typeparam name="TUserdata">Type of <paramref name="userdata"/>.</typeparam>
        /// <param name="func">A function that gets the value of each element. Prototype: `T func(int index, TUserdata userdata)`, `index` is element index.</param>
        /// <param name="userdata">The userdata.</param>
        /// <returns>A new <see cref="Vector{T}"/> from a from the given <see cref="Func{T1, T2, TResult}"/>.</returns>
        public static Vector<T> CreateByFunc<T, TUserdata>(Func<int, TUserdata, T> func, TUserdata userdata) where T : struct {
            if (null == func) throw new ArgumentNullException(nameof(func));
            T[] arr = new T[Vector<T>.Count];
            for (int i = 0; i < Vector<T>.Count; ++i) {
                arr[i] = func(i, userdata);
            }
            Vector<T> rt = Create(arr);
            return rt;
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> whose components are of a specified double type.
        /// </summary>
        /// <param name="src">Source value.</param>
        /// <returns>A new <see cref="Vector{T}"/> with all elements initialized to value.</returns>
        public static Vector<T> CreateByDouble<T>(double src) where T : struct {
            return Create(TraitsUtil.GetByDouble<T>(src));
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> from double value `for` loop.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="start">Start value.</param>
        /// <param name="step">Step value.</param>
        /// <returns>A new <see cref="Vector{T}"/> from double value `for` loop.</returns>
        public static Vector<T> CreateByDoubleLoop<T>(double start, double step) where T : struct {
            return CreateByFunc(delegate (int index) {
                double src = start + step * index;
                return TraitsUtil.GetByDouble<T>(src);
            });
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> whose components are of a specified bits.
        /// </summary>
        /// <param name="src">Source value.</param>
        /// <returns>A new <see cref="Vector{T}"/> with all elements initialized to value.</returns>
        public static Vector<T> CreateByBits<T>(Int64 src) where T : struct {
            return Create(TraitsUtil.GetByBits<T>(src));
        }

        /// <summary>
        /// Computes the ones-complement (~) of a vector.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="src">The vector whose ones-complement is to be computed.</param>
        /// <returns>A vector whose elements are the ones-complement of the corresponding elements in <paramref name="src"/>.</returns>
        public static Vector<T> OnesComplement<T>(Vector<T> src) where T : struct {
            return ~src;
        }

    }

    /// <summary>
    /// Constants of <see cref="Vector{T}"/> .
    /// </summary>
    /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
    public static class Vectors<T> where T:struct {
        // -- Number struct --
        /// <summary>Element byte size.</summary>
        public static readonly int ElementSize;
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
        /// <summary>(Element) Zero.</summary>
        public static readonly T ElementZero;
        /// <summary>(Element) All bit is 1.</summary>
        public static readonly T ElementAllBitsSet;
        /// <summary>(Element) Sign mask.</summary>
        public static readonly T ElementSignMask;
        /// <summary>(Element) Exponent mask.</summary>
        public static readonly T ElementExponentMask;
        /// <summary>(Element) Mantissa mask.</summary>
        public static readonly T ElementMantissaMask;
        /// <summary>(Element) Non-sign mask.</summary>
        public static readonly T ElementNonSignMask;
        /// <summary>(Element) Non-exponent mask.</summary>
        public static readonly T ElementNonExponentMask;
        /// <summary>(Element) Non-mantissa mask.</summary>
        public static readonly T ElementNonMantissaMask;
        /// <summary>(Element) Represents the smallest positive value that is greater than zero. When the type is an integer, the value is 1.</summary>
        public static readonly T ElementEpsilon;
        /// <summary>(Element) Represents the largest possible value.</summary>
        public static readonly T ElementMaxValue;
        /// <summary>(Element) Represents the smallest possible value.</summary>
        public static readonly T ElementMinValue;
        /// <summary>(Element) Represents not a number (NaN). When the type is an integer, the value is 0.</summary>
        public static readonly T ElementNaN;
        /// <summary>(Element) Represents negative infinity. When the type is an integer, the value is 0.</summary>
        public static readonly T ElementNegativeInfinity;
        /// <summary>(Element) Represents positive infinity. When the type is an integer, the value is 0.</summary>
        public static readonly T ElementPositiveInfinity;
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
        /// <summary>Represents the smallest positive value that is greater than zero. When the type is an integer, the value is 1.</summary>
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
        public static readonly Vector<T> AllBitsSet;
        /// <summary>Serial Value. e.g. 0,1,2,3...</summary>
        public static readonly Vector<T> Serial;
        /// <summary>Demo Value. It is a value constructed for testing purposes. It is characterized by different element values, and contains a minimum value, a maximum value.</summary>
        public static readonly Vector<T> Demo;
        // -- Xyzw --
        /// <summary>Xy - X mask. For a 2-element group, select the mask of the 0th element.</summary>
        public static readonly Vector<T> XyXMask;
        /// <summary>Xy - Y mask. For a 2-element group, select the mask of the 1st element.</summary>
        public static readonly Vector<T> XyYMask;
        /// <summary>Xyzw - X mask. For a 4-element group, select the mask of the 0th element. Alias has `RgbaRMask`.</summary>
        public static readonly Vector<T> XyzwXMask;
        /// <summary>Xyzw - Y mask. For a 4-element group, select the mask of the 1th element. Alias has `RgbaGMask`.</summary>
        public static readonly Vector<T> XyzwYMask;
        /// <summary>Xyzw - Z mask. For a 4-element group, select the mask of the 2th element. Alias has `RgbaBMask`.</summary>
        public static readonly Vector<T> XyzwZMask;
        /// <summary>Xyzw - W mask. For a 4-element group, select the mask of the 3th element. Alias has `RgbaAMask`.</summary>
        public static readonly Vector<T> XyzwWMask;
        /// <summary>Xyzw - Not X mask. For a 4-element group, not select the mask of the 0th element. Alias has `RgbaNotRMask`.</summary>
        public static readonly Vector<T> XyzwNotXMask;
        /// <summary>Xyzw - Not Y mask. For a 4-element group, not select the mask of the 1th element. Alias has `RgbaNotGMask`.</summary>
        public static readonly Vector<T> XyzwNotYMask;
        /// <summary>Xyzw - Not Z mask. For a 4-element group, not select the mask of the 2th element. Alias has `RgbaNotBMask`.</summary>
        public static readonly Vector<T> XyzwNotZMask;
        /// <summary>Xyzw - Not W mask. For a 4-element group, not select the mask of the 3th element. Alias has `RgbaNotAMask`.</summary>
        public static readonly Vector<T> XyzwNotWMask;
        // -- Mask --
        /// <summary>Serial bit pos mask. e.g. 1, 2, 4, 8, 0x10 ...</summary>
        public static readonly Vector<T> MaskBitPosSerial;
        /// <summary>Serial bits mask. e.g. 1, 3, 7, 0xF, 0x1F ...</summary>
        public static readonly Vector<T> MaskBitsSerial;
        /// <summary>1 bits mask.</summary>
        public static readonly Vector<T> MaskBits1;
        /// <summary>2 bits mask.</summary>
        public static readonly Vector<T> MaskBits2;
        /// <summary>4 bits mask.</summary>
        public static readonly Vector<T> MaskBits4;
        /// <summary>8 bits mask.</summary>
        public static readonly Vector<T> MaskBits8;
        /// <summary>16 bits mask.</summary>
        public static readonly Vector<T> MaskBits16;
        /// <summary>32 bits mask.</summary>
        public static readonly Vector<T> MaskBits32;
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
        /// <summary>Value 5 .</summary>
        public static readonly Vector<T> V5;
        /// <summary>Value 6 .</summary>
        public static readonly Vector<T> V6;
        /// <summary>Value 7 .</summary>
        public static readonly Vector<T> V7;
        /// <summary>Value 8 .</summary>
        public static readonly Vector<T> V8;
        /// <summary>Value 127 (SByte.MaxValue).</summary>
        public static readonly Vector<T> V127;
        /// <summary>Value 255 (Byte.MaxValue).</summary>
        public static readonly Vector<T> V255;
        /// <summary>Value 32767 (Int16.MaxValue) .</summary>
        public static readonly Vector<T> V32767;
        /// <summary>Value 65535 (UInt16.MaxValue) .</summary>
        public static readonly Vector<T> V65535;
        /// <summary>Value 2147483647 (Int32.MaxValue) .</summary>
        public static readonly Vector<T> V2147483647;
        /// <summary>Value 4294967295 (UInt32.MaxValue) .</summary>
        public static readonly Vector<T> V4294967295;
        // -- Negative number  --
        /// <summary>Value -1 . When the type is unsigned, the value is a signed cast value (Example: '(Byte)(-1)=255').</summary>
        public static readonly Vector<T> V_1;
        /// <summary>Value -2 .</summary>
        public static readonly Vector<T> V_2;
        /// <summary>Value -3 .</summary>
        public static readonly Vector<T> V_3;
        /// <summary>Value -4 .</summary>
        public static readonly Vector<T> V_4;
        /// <summary>Value -5 .</summary>
        public static readonly Vector<T> V_5;
        /// <summary>Value -6 .</summary>
        public static readonly Vector<T> V_6;
        /// <summary>Value -7 .</summary>
        public static readonly Vector<T> V_7;
        /// <summary>Value -8 .</summary>
        public static readonly Vector<T> V_8;
        /// <summary>Value -128 (SByte.MinValue).</summary>
        public static readonly Vector<T> V_128;
        /// <summary>Value -32768 (Int16.MinValue) .</summary>
        public static readonly Vector<T> V_32768;
        /// <summary>Value -2147483648 (Int32.MinValue) .</summary>
        public static readonly Vector<T> V_2147483648;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Vectors() {
            V0 = Vector<T>.Zero;
            ElementZero = default;
            // -- Number struct --
            unchecked {
                if (typeof(T) == typeof(Single)) {
                    ElementSize = sizeof(Single);
                    SignBits = 1;
                    ExponentBits = 8;
                    MantissaBits = 23;
                    ElementAllBitsSet = (T)(object)BitConverter.Int32BitsToSingle(~0);
                    ElementSignMask = (T)(object)BitConverter.Int32BitsToSingle((Int32)0x80000000);
                    ElementExponentMask = (T)(object)BitConverter.Int32BitsToSingle((Int32)0x7F800000);
                    ElementMantissaMask = (T)(object)BitConverter.Int32BitsToSingle((Int32)0x007FFFFF);
                    ElementNonSignMask = (T)(object)BitConverter.Int32BitsToSingle(~(Int32)0x80000000);
                    ElementNonExponentMask = (T)(object)BitConverter.Int32BitsToSingle(~(Int32)0x7F800000);
                    ElementNonMantissaMask = (T)(object)BitConverter.Int32BitsToSingle(~(Int32)0x007FFFFF);
                    ElementEpsilon = (T)(object)Single.Epsilon;
                    ElementMaxValue = (T)(object)Single.MaxValue;
                    ElementMinValue = (T)(object)Single.MinValue;
                    ElementNaN = (T)(object)Single.NaN;
                    ElementNegativeInfinity = (T)(object)Single.NegativeInfinity;
                    ElementPositiveInfinity = (T)(object)Single.PositiveInfinity;
                } else if (typeof(T) == typeof(Double)) {
                    ElementSize = sizeof(Double);
                    SignBits = 1;
                    ExponentBits = 11;
                    MantissaBits = 52;
                    ElementAllBitsSet = (T)(object)BitConverter.Int64BitsToDouble(~0L);
                    ElementSignMask = (T)(object)BitConverter.Int64BitsToDouble((Int64)0x8000000000000000L);
                    ElementExponentMask = (T)(object)BitConverter.Int64BitsToDouble((Int64)0x7FF0000000000000L);
                    ElementMantissaMask = (T)(object)BitConverter.Int64BitsToDouble((Int64)0x000FFFFFFFFFFFFFL);
                    ElementNonSignMask = (T)(object)BitConverter.Int64BitsToDouble(~(Int64)0x8000000000000000L);
                    ElementNonExponentMask = (T)(object)BitConverter.Int64BitsToDouble(~(Int64)0x7FF0000000000000L);
                    ElementNonMantissaMask = (T)(object)BitConverter.Int64BitsToDouble(~(Int64)0x000FFFFFFFFFFFFFL);
                    ElementEpsilon = (T)(object)Double.Epsilon;
                    ElementMaxValue = (T)(object)Double.MaxValue;
                    ElementMinValue = (T)(object)Double.MinValue;
                    ElementNaN = (T)(object)Double.NaN;
                    ElementNegativeInfinity = (T)(object)Double.NegativeInfinity;
                    ElementPositiveInfinity = (T)(object)Double.PositiveInfinity;
                } else if (typeof(T) == typeof(SByte)) {
                    ElementSize = sizeof(SByte);
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 7;
                    ElementAllBitsSet = (T)(object)(SByte)(~0);
                    ElementSignMask = (T)(object)(SByte)(0x80);
                    ElementExponentMask = (T)(object)(SByte)(0);
                    ElementMantissaMask = (T)(object)(SByte)(0x7F);
                    ElementNonSignMask = (T)(object)(SByte)(~0x80);
                    ElementNonExponentMask = (T)(object)(SByte)(~0);
                    ElementNonMantissaMask = (T)(object)(SByte)(~0x7F);
                    ElementEpsilon = TraitsUtil.GetByDouble<T>(1);
                    ElementMaxValue = (T)(object)SByte.MaxValue;
                    ElementMinValue = (T)(object)SByte.MinValue;
                    ElementNaN = ElementZero;
                    ElementNegativeInfinity = ElementZero;
                    ElementPositiveInfinity = ElementZero;
                } else if (typeof(T) == typeof(Int16)) {
                    ElementSize = sizeof(Int16);
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 15;
                    ElementAllBitsSet = (T)(object)(Int16)(~0);
                    ElementSignMask = (T)(object)(Int16)(0x8000);
                    ElementExponentMask = (T)(object)(Int16)(0);
                    ElementMantissaMask = (T)(object)(Int16)(0x7FFF);
                    ElementNonSignMask = (T)(object)(Int16)(~0x8000);
                    ElementNonExponentMask = (T)(object)(Int16)(~0);
                    ElementNonMantissaMask = (T)(object)(Int16)(~0x7FFF);
                    ElementEpsilon = TraitsUtil.GetByDouble<T>(1);
                    ElementMaxValue = (T)(object)Int16.MaxValue;
                    ElementMinValue = (T)(object)Int16.MinValue;
                    ElementNaN = ElementZero;
                    ElementNegativeInfinity = ElementZero;
                    ElementPositiveInfinity = ElementZero;
                } else if (typeof(T) == typeof(Int32)) {
                    ElementSize = sizeof(Int32);
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 31;
                    ElementAllBitsSet = (T)(object)(Int32)(~0);
                    ElementSignMask = (T)(object)(Int32)(0x80000000);
                    ElementExponentMask = (T)(object)(Int32)(0);
                    ElementMantissaMask = (T)(object)(Int32)(0x7FFFFFFF);
                    ElementNonSignMask = (T)(object)(Int32)(~0x80000000);
                    ElementNonExponentMask = (T)(object)(Int32)(~0);
                    ElementNonMantissaMask = (T)(object)(Int32)(~0x7FFFFFFF);
                    ElementEpsilon = TraitsUtil.GetByDouble<T>(1);
                    ElementMaxValue = (T)(object)Int32.MaxValue;
                    ElementMinValue = (T)(object)Int32.MinValue;
                    ElementNaN = ElementZero;
                    ElementNegativeInfinity = ElementZero;
                    ElementPositiveInfinity = ElementZero;
                } else if (typeof(T) == typeof(Int64)) {
                    ElementSize = sizeof(Int64);
                    SignBits = 1;
                    ExponentBits = 0;
                    MantissaBits = 63;
                    ElementAllBitsSet = (T)(object)(Int64)(~0);
                    ElementSignMask = (T)(object)(Int64)(0x8000000000000000L);
                    ElementExponentMask = (T)(object)(Int64)(0);
                    ElementMantissaMask = (T)(object)(Int64)(0x7FFFFFFFFFFFFFFF);
                    ElementNonSignMask = (T)(object)(Int64)(~0x8000000000000000L);
                    ElementNonExponentMask = (T)(object)(Int64)(~0);
                    ElementNonMantissaMask = (T)(object)(Int64)(~0x7FFFFFFFFFFFFFFF);
                    ElementEpsilon = TraitsUtil.GetByDouble<T>(1);
                    ElementMaxValue = (T)(object)Int64.MaxValue;
                    ElementMinValue = (T)(object)Int64.MinValue;
                    ElementNaN = ElementZero;
                    ElementNegativeInfinity = ElementZero;
                    ElementPositiveInfinity = ElementZero;
                } else if (typeof(T) == typeof(Byte)) {
                    ElementSize = sizeof(Byte);
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 8;
                    ElementAllBitsSet = (T)(object)(Byte)(~0);
                    ElementSignMask = (T)(object)(Byte)(0);
                    ElementExponentMask = (T)(object)(Byte)(0);
                    ElementMantissaMask = (T)(object)(Byte)(0xFF);
                    ElementNonSignMask = (T)(object)(Byte)(~0);
                    ElementNonExponentMask = (T)(object)(Byte)(~0);
                    ElementNonMantissaMask = (T)(object)(Byte)(~0xFF);
                    ElementEpsilon = TraitsUtil.GetByDouble<T>(1);
                    ElementMaxValue = (T)(object)Byte.MaxValue;
                    ElementMinValue = (T)(object)Byte.MinValue;
                    ElementNaN = ElementZero;
                    ElementNegativeInfinity = ElementZero;
                    ElementPositiveInfinity = ElementZero;
                } else if (typeof(T) == typeof(UInt16)) {
                    ElementSize = sizeof(UInt16);
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 16;
                    ElementAllBitsSet = (T)(object)(UInt16)(~0);
                    ElementSignMask = (T)(object)(UInt16)(0);
                    ElementExponentMask = (T)(object)(UInt16)(0);
                    ElementMantissaMask = (T)(object)(UInt16)(0xFFFF);
                    ElementNonSignMask = (T)(object)(UInt16)(~0);
                    ElementNonExponentMask = (T)(object)(UInt16)(~0);
                    ElementNonMantissaMask = (T)(object)(UInt16)(~0xFFFF);
                    ElementEpsilon = TraitsUtil.GetByDouble<T>(1);
                    ElementMaxValue = (T)(object)UInt16.MaxValue;
                    ElementMinValue = (T)(object)UInt16.MinValue;
                    ElementNaN = ElementZero;
                    ElementNegativeInfinity = ElementZero;
                    ElementPositiveInfinity = ElementZero;
                } else if (typeof(T) == typeof(UInt32)) {
                    ElementSize = sizeof(UInt32);
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 32;
                    ElementAllBitsSet = (T)(object)(UInt32)(~0);
                    ElementSignMask = (T)(object)(UInt32)(0);
                    ElementExponentMask = (T)(object)(UInt32)(0);
                    ElementMantissaMask = (T)(object)(UInt32)(0xFFFFFFFF);
                    ElementNonSignMask = (T)(object)(UInt32)(~0);
                    ElementNonExponentMask = (T)(object)(UInt32)(~0);
                    ElementNonMantissaMask = (T)(object)(UInt32)(~0xFFFFFFFF);
                    ElementEpsilon = TraitsUtil.GetByDouble<T>(1);
                    ElementMaxValue = (T)(object)UInt32.MaxValue;
                    ElementMinValue = (T)(object)UInt32.MinValue;
                    ElementNaN = ElementZero;
                    ElementNegativeInfinity = ElementZero;
                    ElementPositiveInfinity = ElementZero;
                } else if (typeof(T) == typeof(UInt64)) {
                    ElementSize = sizeof(UInt64);
                    SignBits = 0;
                    ExponentBits = 0;
                    MantissaBits = 64;
                    ElementAllBitsSet = (T)(object)(UInt64)(~0);
                    ElementSignMask = (T)(object)(UInt64)(0);
                    ElementExponentMask = (T)(object)(UInt64)(0);
                    ElementMantissaMask = (T)(object)(UInt64)(0xFFFFFFFFFFFFFFFFL);
                    ElementNonSignMask = (T)(object)(UInt64)(~0L);
                    ElementNonExponentMask = (T)(object)(UInt64)(~0L);
                    ElementNonMantissaMask = (T)(object)(UInt64)(~0xFFFFFFFFFFFFFFFFL);
                    ElementEpsilon = TraitsUtil.GetByDouble<T>(1);
                    ElementMaxValue = (T)(object)UInt64.MaxValue;
                    ElementMinValue = (T)(object)UInt64.MinValue;
                    ElementNaN = ElementZero;
                    ElementNegativeInfinity = ElementZero;
                    ElementPositiveInfinity = ElementZero;
                }
            }
            MantissaShift = 0;
            ExponentShift = MantissaShift + MantissaBits;
            SignShift = ExponentShift + ExponentBits;
            SignMask = Vectors.Create(ElementSignMask);
            ExponentMask = Vectors.Create(ElementExponentMask);
            MantissaMask = Vectors.Create(ElementMantissaMask);
            Epsilon = Vectors.Create(ElementEpsilon);
            MaxValue = Vectors.Create(ElementMaxValue);
            MinValue = Vectors.Create(ElementMinValue);
            NaN = Vectors.Create(ElementNaN);
            NegativeInfinity = Vectors.Create(ElementNegativeInfinity);
            PositiveInfinity = Vectors.Create(ElementPositiveInfinity);
            NonSignMask = Vectors.OnesComplement(SignMask);
            NonExponentMask = Vectors.OnesComplement(ExponentMask);
            NonMantissaMask = Vectors.OnesComplement(MantissaMask);
            // -- Math --
            E = Vectors.CreateByDouble<T>(Math.E);
            Pi = Vectors.CreateByDouble<T>(Math.PI);
#if NET5_0_OR_GREATER
            Tau = Vectors.CreateByDouble<T>(Math.Tau);
#else
            Tau = CreateByDouble(Math.PI * 2);
#endif // NET5_0_OR_GREATER
            // -- Math shift --
            // -- Specified value --
            AllBitsSet = Vectors.OnesComplement(Vector<T>.Zero);
            Serial = GetSerial();
            Demo = GetDemo();
            // -- Xyzw --
            if (true) {
                T o = ElementZero;
                T f = ElementAllBitsSet;
                XyXMask = Vectors.CreateRotate<T>(f, o);
                XyYMask = Vectors.CreateRotate<T>(o, f);
                XyzwXMask = Vectors.CreateRotate<T>(f, o, o, o);
                XyzwYMask = Vectors.CreateRotate<T>(o, f, o, o);
                XyzwZMask = Vectors.CreateRotate<T>(o, o, f, o);
                XyzwWMask = Vectors.CreateRotate<T>(o, o, o, f);
                XyzwNotXMask = Vectors.OnesComplement(XyzwXMask);
                XyzwNotYMask = Vectors.OnesComplement(XyzwYMask);
                XyzwNotZMask = Vectors.OnesComplement(XyzwZMask);
                XyzwNotWMask = Vectors.OnesComplement(XyzwWMask);
            }
            // -- Mask --
            int bitLen = ElementSize * 8;
            MaskBitPosSerial = Vectors.CreateByFunc<T>(delegate (int index) {
                int m = index % bitLen;
                long n = 1L << m;
                return TraitsUtil.GetByBits<T>(n);
            });
            MaskBitsSerial = Vectors.CreateByFunc<T>(delegate (int index) {
                int m = index % bitLen + 1;
                return TraitsUtil.GetBitsMask<T>(0, m);
            });
            MaskBits1 = Vectors.CreateByBits<T>(0x1);
            MaskBits2 = Vectors.CreateByBits<T>(0x3);
            MaskBits4 = Vectors.CreateByBits<T>(0xF);
            MaskBits8 = Vectors.CreateByBits<T>(0xFF);
            MaskBits16 = Vectors.CreateByBits<T>(0xFFFF);
            MaskBits32 = Vectors.CreateByBits<T>(0xFFFFFFFF);
            // -- Positive number --
            V1 = Vectors.CreateByDouble<T>(1);
            V2 = Vectors.CreateByDouble<T>(2);
            V3 = Vectors.CreateByDouble<T>(3);
            V4 = Vectors.CreateByDouble<T>(4);
            V5 = Vectors.CreateByDouble<T>(5);
            V6 = Vectors.CreateByDouble<T>(6);
            V7 = Vectors.CreateByDouble<T>(7);
            V8 = Vectors.CreateByDouble<T>(8);
            V127 = Vectors.CreateByDouble<T>(127);
            V255 = Vectors.CreateByDouble<T>(255);
            V32767 = Vectors.CreateByDouble<T>(32767);
            V65535 = Vectors.CreateByDouble<T>(65535);
            V2147483647 = Vectors.CreateByDouble<T>(2147483647);
            V4294967295 = Vectors.CreateByDouble<T>(4294967295);
            // -- Negative number  --
            V_1 = Vectors.CreateByDouble<T>(-1);
            V_2 = Vectors.CreateByDouble<T>(-2);
            V_3 = Vectors.CreateByDouble<T>(-3);
            V_4 = Vectors.CreateByDouble<T>(-4);
            V_5 = Vectors.CreateByDouble<T>(-5);
            V_6 = Vectors.CreateByDouble<T>(-6);
            V_7 = Vectors.CreateByDouble<T>(-7);
            V_8 = Vectors.CreateByDouble<T>(-8);
            V_128 = Vectors.CreateByDouble<T>(-128);
            V_32768 = Vectors.CreateByDouble<T>(-32768);
            V_2147483648 = Vectors.CreateByDouble<T>(-2147483648);
        }

        /// <summary>
        /// Get serial value.
        /// </summary>
        /// <returns>Return serial value.</returns>
        private static Vector<T> GetSerial() {
            return Vectors.CreateByDoubleLoop<T>(0, 1);
        }

        /// <summary>
        /// Get demo value.
        /// </summary>
        /// <returns>Return demo value.</returns>
        private static Vector<T> GetDemo() {
            if (typeof(T) == typeof(Single)) {
                return (Vector<T>)(object)Vectors.CreateRotate<Single>(Single.MinValue, Single.PositiveInfinity, Single.NaN, -1.2f, 0f, 1f, 2f, 4f);
            } else if (typeof(T) == typeof(Double)) {
                return (Vector<T>)(object)Vectors.CreateRotate<double>(Double.MinValue, Double.PositiveInfinity, -1.2, 0);
            } else if (typeof(T) == typeof(SByte)) {
                return (Vector<T>)(object)Vectors.CreateRotate<SByte>(SByte.MinValue, SByte.MaxValue, -1, 0, 1, 2, 3, 64);
            } else if (typeof(T) == typeof(Int16)) {
                return (Vector<T>)(object)Vectors.CreateRotate<Int16>(Int16.MinValue, Int16.MaxValue, -1, 0, 1, 2, 3, 16384);
            } else if (typeof(T) == typeof(Int32)) {
                return (Vector<T>)(object)Vectors.CreateRotate<Int32>(Int32.MinValue, Int32.MaxValue, -1, 0, 1, 2, 3, 32768);
            } else if (typeof(T) == typeof(Int64)) {
                return (Vector<T>)(object)Vectors.CreateRotate<Int64>(Int64.MinValue, Int64.MaxValue, -1, 0, 1, 2, 3);
            } else if (typeof(T) == typeof(Byte)) {
                return (Vector<T>)(object)Vectors.CreateRotate<Byte>(Byte.MinValue, Byte.MaxValue, 0, 1, 2, 3, 4, 128);
            } else if (typeof(T) == typeof(UInt16)) {
                return (Vector<T>)(object)Vectors.CreateRotate<UInt16>(UInt16.MinValue, UInt16.MaxValue, 0, 1, 2, 3, 4, 32768);
            } else if (typeof(T) == typeof(UInt32)) {
                return (Vector<T>)(object)Vectors.CreateRotate<UInt32>(UInt32.MinValue, UInt32.MaxValue, 0, 1, 2, 3, 4, 65536);
            } else if (typeof(T) == typeof(UInt64)) {
                return (Vector<T>)(object)Vectors.CreateRotate<UInt64>(UInt64.MinValue, UInt64.MaxValue, 0, 1, 2, 3);
            } else {
                return Serial; // GetSerial();
            }
        }

    }
}
