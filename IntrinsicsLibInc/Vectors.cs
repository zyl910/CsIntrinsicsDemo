﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;

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
        /// <seealso cref="Vector{T}(ReadOnlySpan{byte})"/>
        public static Vector<T> Create<T>(ReadOnlySpan<byte> values) where T : struct {
#if NETCOREAPP3_0_OR_GREATER
            return new Vector<T>(values);
#else
            if (null== values) throw new ArgumentNullException(nameof(values));
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
        /// <seealso cref="Vector{T}(ReadOnlySpan{T})"/>
        public static Vector<T> Create<T>(ReadOnlySpan<T> values) where T : struct {
#if NETCOREAPP3_0_OR_GREATER
            return new Vector<T>(values);
#else
            if (null == values) throw new ArgumentNullException(nameof(values));
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
            return new Vector<T>(arr);
#endif // NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
#endif // NETCOREAPP3_0_OR_GREATER
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="Span{T}"/>.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as a span of objects of type <typeparamref name="T"/>.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <seealso cref="Vector{T}(Span{T})"/>
        public static Vector<T> Create<T>(Span<T> values) where T : struct {
#if NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            return new Vector<T>(values);
#else
            if (null == values) throw new ArgumentNullException(nameof(values));
            if (values.Length < Vector<T>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
            return Unsafe.ReadUnaligned<Vector<T>>(ref Unsafe.As<T, byte>(ref TraitsUtil.GetReference(values)));
#endif // NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> whose components are of a specified double type.
        /// </summary>
        /// <param name="src">Source value.</param>
        /// <returns>A new <see cref="Vector{T}"/> with all elements initialized to value.</returns>
        public static Vector<T> CreateByDouble<T>(double src) where T : struct {
            return new Vector<T>(TraitsUtil.GetByDouble<T>(src));
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector{T}"/> from a given array starting at a specified index position.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as an array of objects of type <typeparamref name="T"/>.</param>
        /// <param name="index">The starting index position from which to create the vector.</param>
        /// <param name="length">The rotation length of the element.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <seealso cref="Vector{T}(T[], int)"/>
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
            Vector<T> rt = new Vector<T>(arr);
            return rt;
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector{T}"/> from a given array.
        /// </summary>
        /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
        /// <param name="values">The values to add to the vector, as an array of objects of type <typeparamref name="T"/>.</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/>.</returns>
        /// <seealso cref="Vector{T}(T[], int)"/>
        public static Vector<T> CreateRotate<T>(params T[] values) where T : struct {
            return CreateRotate<T>(values, 0, values.Length);
        }

    }

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
                    Single full = BitConverter.Int32BitsToSingle(~0);
                    XyXMask = (Vector<T>)(object)Vectors<Single>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<Single>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<Single>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<Single>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<Single>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<Single>.CreateUseRotate(0, 0, 0, full);
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
                    Double full = BitConverter.Int64BitsToDouble(~0L);
                    XyXMask = (Vector<T>)(object)Vectors<Double>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<Double>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<Double>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<Double>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<Double>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<Double>.CreateUseRotate(0, 0, 0, full);
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
                    SByte full = ~0;
                    XyXMask = (Vector<T>)(object)Vectors<SByte>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<SByte>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<SByte>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<SByte>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<SByte>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<SByte>.CreateUseRotate(0, 0, 0, full);
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
                    Int16 full = ~0;
                    XyXMask = (Vector<T>)(object)Vectors<Int16>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<Int16>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<Int16>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<Int16>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<Int16>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<Int16>.CreateUseRotate(0, 0, 0, full);
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
                    Int32 full = ~0;
                    XyXMask = (Vector<T>)(object)Vectors<Int32>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<Int32>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<Int32>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<Int32>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<Int32>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<Int32>.CreateUseRotate(0, 0, 0, full);
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
                    Int64 full = ~0L;
                    XyXMask = (Vector<T>)(object)Vectors<Int64>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<Int64>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<Int64>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<Int64>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<Int64>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<Int64>.CreateUseRotate(0, 0, 0, full);
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
                    Byte full = (Byte)(~0);
                    XyXMask = (Vector<T>)(object)Vectors<Byte>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<Byte>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<Byte>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<Byte>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<Byte>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<Byte>.CreateUseRotate(0, 0, 0, full);
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
                    UInt16 full = (UInt16)(~0);
                    XyXMask = (Vector<T>)(object)Vectors<UInt16>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<UInt16>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<UInt16>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<UInt16>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<UInt16>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<UInt16>.CreateUseRotate(0, 0, 0, full);
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
                    UInt32 full = (UInt32)(~0);
                    XyXMask = (Vector<T>)(object)Vectors<UInt32>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<UInt32>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<UInt32>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<UInt32>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<UInt32>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<UInt32>.CreateUseRotate(0, 0, 0, full);
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
                    UInt64 full = (UInt64)(~0L);
                    XyXMask = (Vector<T>)(object)Vectors<UInt64>.CreateUseRotate(full, 0);
                    XyYMask = (Vector<T>)(object)Vectors<UInt64>.CreateUseRotate(0, full);
                    XyzwXMask = (Vector<T>)(object)Vectors<UInt64>.CreateUseRotate(full, 0, 0, 0);
                    XyzwYMask = (Vector<T>)(object)Vectors<UInt64>.CreateUseRotate(0, full, 0, 0);
                    XyzwZMask = (Vector<T>)(object)Vectors<UInt64>.CreateUseRotate(0, 0, full, 0);
                    XyzwWMask = (Vector<T>)(object)Vectors<UInt64>.CreateUseRotate(0, 0, 0, full);
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
            AllBitsSet = ~Vector<T>.Zero;
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
            return new Vector<T>(TraitsUtil.GetByDouble<T>(src));
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

        /// <summary>
        /// Get serial value.
        /// </summary>
        /// <returns>Return serial value.</returns>
        private static Vector<T> GetSerial() {
            T[] arr = new T[Vector<T>.Count];
            for (int i = 0; i < Vector<T>.Count; ++i) {
                arr[i] = ElementByDouble(i);
            }
            Vector<T> rt = new Vector<T>(arr);
            return rt;
        }

        /// <summary>
        /// Get demo value.
        /// </summary>
        /// <returns>Return demo value.</returns>
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

    }
}
