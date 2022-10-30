using System;
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
            return Create(Scalars.GetByDouble<T>(src));
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
                return Scalars.GetByDouble<T>(src);
            });
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> whose components are of a specified bits.
        /// </summary>
        /// <param name="src">Source value.</param>
        /// <returns>A new <see cref="Vector{T}"/> with all elements initialized to value.</returns>
        public static Vector<T> CreateByBits<T>(Int64 src) where T : struct {
            return Create(Scalars.GetByBits<T>(src));
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
    public abstract class Vectors<T>: AbstractVectors<T> where T:struct {
        /// <summary>Value 0 (0的值).</summary>
        public static readonly Vector<T> V0;
        /// <summary>All bit is 1 (所有位都是1的值).</summary>
        public static readonly Vector<T> AllBitsSet;
        // -- Number struct --
        /// <summary>Sign mask (符号掩码).</summary>
        public static readonly Vector<T> SignMask;
        /// <summary>Exponent mask (指数掩码).</summary>
        public static readonly Vector<T> ExponentMask;
        /// <summary>Mantissa mask (尾数掩码).</summary>
        public static readonly Vector<T> MantissaMask;
        /// <summary>Non-sign mask (非符号掩码).</summary>
        public static readonly Vector<T> NonSignMask;
        /// <summary>Non-exponent mask (非指数掩码).</summary>
        public static readonly Vector<T> NonExponentMask;
        /// <summary>Non-mantissa mask (非尾数掩码).</summary>
        public static readonly Vector<T> NonMantissaMask;
        /// <summary>Represents the smallest positive value that is greater than zero (表示大于零的最小正值). When the type is an integer, the value is 1 (当类型为整数时，该值为1).</summary>
        public static readonly Vector<T> Epsilon;
        /// <summary>Represents the largest possible value (表示最大可能值).</summary>
        public static readonly Vector<T> MaxValue;
        /// <summary>Represents the smallest possible value (表示最大可能值).</summary>
        public static readonly Vector<T> MinValue;
        /// <summary>Represents not a number (NaN) (表示“非数(NaN)”的值). When the type is an integer, the value is 0 (当类型为整数时，该值为0).</summary>
        public static readonly Vector<T> NaN;
        /// <summary>Represents negative infinity (表示负无穷). When the type is an integer, the value is 0 (当类型为整数时，该值为0).</summary>
        public static readonly Vector<T> NegativeInfinity;
        /// <summary>Represents positive infinity (表示正无穷). When the type is an integer, the value is 0 (当类型为整数时，该值为0).</summary>
        public static readonly Vector<T> PositiveInfinity;
        // -- Math --
        /// <summary>Represents the natural logarithmic base, specified by the constant, e (表示自然对数的底，它由常数 e 指定).</summary>
        public static readonly Vector<T> E;
        /// <summary>Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π (表示圆的周长与其直径的比值，由常数 π 指定).</summary>
        public static readonly Vector<T> Pi;
        /// <summary>Represents the number of radians in one turn, specified by the constant, τ (表示转一圈的弧度数，由常量 τ 指定).</summary>
        public static readonly Vector<T> Tau;
        // -- Mask --
        /// <summary>1 bits mask (1位掩码).</summary>
        public static readonly Vector<T> MaskBits1;
        /// <summary>2 bits mask (2位掩码).</summary>
        public static readonly Vector<T> MaskBits2;
        /// <summary>4 bits mask (4位掩码).</summary>
        public static readonly Vector<T> MaskBits4;
        /// <summary>8 bits mask (8位掩码).</summary>
        public static readonly Vector<T> MaskBits8;
        /// <summary>16 bits mask (16位掩码).</summary>
        public static readonly Vector<T> MaskBits16;
        /// <summary>32 bits mask (32位掩码).</summary>
        public static readonly Vector<T> MaskBits32;
        // -- Positive number --
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
        /// <summary>Value -1 . When the type is unsigned integer, the value is a signed cast value (当类型为无符号整型时，值为带符号强制转换值). Example: '(Byte)(-1)=255' .</summary>
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
        // -- Specified value --
        /// <summary>Serial Value (顺序值). e.g. 0,1,2,3...</summary>
        public static readonly Vector<T> Serial;
        /// <summary>Demo Value (演示值). It is a value constructed for testing purposes (它是为测试目的而构造的值).</summary>
        public static readonly Vector<T> Demo;
        /// <summary>Serial bit pos mask (顺序位偏移的掩码). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        public static readonly Vector<T> MaskBitPosSerial;
        /// <summary>Serial bits mask (顺序位集的掩码). e.g. 1, 3, 7, 0xF, 0x1F ...</summary>
        public static readonly Vector<T> MaskBitsSerial;
        // -- Xyzw --
        /// <summary>Xy - X mask. For a 2-element group, select the mask of the 0th element (对于2个元素的组，选择第0个元素的掩码).</summary>
        public static readonly Vector<T> XyXMask;
        /// <summary>Xy - Y mask. For a 2-element group, select the mask of the 1st element (对于2个元素的组，选择第1个元素的掩码).</summary>
        public static readonly Vector<T> XyYMask;
        /// <summary>Xyzw - X mask. For a 4-element group, select the mask of the 0th element (对于4个元素的组，选择第0个元素的掩码). Alias has <see cref="RgbaRMask"/>.</summary>
        public static readonly Vector<T> XyzwXMask;
        /// <summary>Xyzw - Y mask. For a 4-element group, select the mask of the 1th element (对于4个元素的组，选择第1个元素的掩码). Alias has <see cref="RgbaGMask"/>.</summary>
        public static readonly Vector<T> XyzwYMask;
        /// <summary>Xyzw - Z mask. For a 4-element group, select the mask of the 2th element (对于4个元素的组，选择第2个元素的掩码). Alias has <see cref="RgbaBMask"/>.</summary>
        public static readonly Vector<T> XyzwZMask;
        /// <summary>Xyzw - W mask. For a 4-element group, select the mask of the 3th element (对于4个元素的组，选择第3个元素的掩码). Alias has <see cref="RgbaAMask"/>.</summary>
        public static readonly Vector<T> XyzwWMask;
        /// <summary>Xyzw - Not X mask. For a 4-element group, not select the mask of the 0th element (对于4个元素的组，不选择第0个元素的掩码). Alias has <see cref="RgbaNotRMask"/>.</summary>
        public static readonly Vector<T> XyzwNotXMask;
        /// <summary>Xyzw - Not Y mask. For a 4-element group, not select the mask of the 1th element (对于4个元素的组，不选择第1个元素的掩码). Alias has <see cref="RgbaNotGMask"/>.</summary>
        public static readonly Vector<T> XyzwNotYMask;
        /// <summary>Xyzw - Not Z mask. For a 4-element group, not select the mask of the 2th element (对于4个元素的组，不选择第2个元素的掩码). Alias has <see cref="RgbaNotBMask"/>.</summary>
        public static readonly Vector<T> XyzwNotZMask;
        /// <summary>Xyzw - Not W mask. For a 4-element group, not select the mask of the 3th element (对于4个元素的组，不选择第3个元素的掩码). Alias has <see cref="RgbaNotAMask"/>.</summary>
        public static readonly Vector<T> XyzwNotWMask;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Vectors() {
            V0 = Vectors.Create<T>(ElementV0);
            AllBitsSet = Vectors.Create<T>(ElementAllBitsSet);
            // -- Number struct --
            SignMask = Vectors.Create<T>(ElementSignMask);
            ExponentMask = Vectors.Create<T>(ElementExponentMask);
            MantissaMask = Vectors.Create<T>(ElementMantissaMask);
            NonSignMask = Vectors.Create<T>(ElementNonSignMask);
            NonExponentMask = Vectors.Create<T>(ElementNonExponentMask);
            NonMantissaMask = Vectors.Create<T>(ElementNonMantissaMask);
            Epsilon = Vectors.Create<T>(ElementEpsilon);
            MaxValue = Vectors.Create<T>(ElementMaxValue);
            MinValue = Vectors.Create<T>(ElementMinValue);
            NaN = Vectors.Create<T>(ElementNaN);
            NegativeInfinity = Vectors.Create<T>(ElementNegativeInfinity);
            PositiveInfinity = Vectors.Create<T>(ElementPositiveInfinity);
            // -- Math --
            E = Vectors.Create<T>(ElementE);
            Pi = Vectors.Create<T>(ElementPi);
            Tau = Vectors.Create<T>(ElementTau);
            // -- Mask --
            MaskBits1 = Vectors.Create<T>(ElementMaskBits1);
            MaskBits2 = Vectors.Create<T>(ElementMaskBits2);
            MaskBits4 = Vectors.Create<T>(ElementMaskBits4);
            MaskBits8 = Vectors.Create<T>(ElementMaskBits8);
            MaskBits16 = Vectors.Create<T>(ElementMaskBits16);
            MaskBits32 = Vectors.Create<T>(ElementMaskBits32);
            // -- Positive number --
            V1 = Vectors.Create<T>(ElementV1);
            V2 = Vectors.Create<T>(ElementV2);
            V3 = Vectors.Create<T>(ElementV3);
            V4 = Vectors.Create<T>(ElementV4);
            V5 = Vectors.Create<T>(ElementV5);
            V6 = Vectors.Create<T>(ElementV6);
            V7 = Vectors.Create<T>(ElementV7);
            V8 = Vectors.Create<T>(ElementV8);
            V127 = Vectors.Create<T>(ElementV127);
            V255 = Vectors.Create<T>(ElementV255);
            V32767 = Vectors.Create<T>(ElementV32767);
            V65535 = Vectors.Create<T>(ElementV65535);
            V2147483647 = Vectors.Create<T>(ElementV2147483647);
            V4294967295 = Vectors.Create<T>(ElementV4294967295);
            // -- Negative number  --
            V_1 = Vectors.Create<T>(ElementV_1);
            V_2 = Vectors.Create<T>(ElementV_2);
            V_3 = Vectors.Create<T>(ElementV_3);
            V_4 = Vectors.Create<T>(ElementV_4);
            V_5 = Vectors.Create<T>(ElementV_5);
            V_6 = Vectors.Create<T>(ElementV_6);
            V_7 = Vectors.Create<T>(ElementV_7);
            V_8 = Vectors.Create<T>(ElementV_8);
            V_128 = Vectors.Create<T>(ElementV_128);
            V_32768 = Vectors.Create<T>(ElementV_32768);
            V_2147483648 = Vectors.Create<T>(ElementV_2147483648);
            // -- Specified value --
            Serial = Vectors.CreateByDoubleLoop<T>(0, 1);
            Demo = GetDemo();
            int bitLen = ElementByteSize * 8;
            MaskBitPosSerial = Vectors.CreateByFunc<T>(delegate (int index) {
                int m = index % bitLen;
                long n = 1L << m;
                return Scalars.GetByBits<T>(n);
            });
            MaskBitsSerial = Vectors.CreateByFunc<T>(delegate (int index) {
                int m = index % bitLen + 1;
                return Scalars.GetBitsMask<T>(0, m);
            });
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

        /// <summary>Xy - Not X mask. For a 2-element group, not select the mask of the 0th element (对于2个元素的组，不选择第0个元素的掩码).</summary>
        public static ref readonly Vector<T> XyNotXMask { get { return ref XyYMask; } }
        /// <summary>Xy - Not Y mask. For a 2-element group, not select the mask of the 1st element (对于2个元素的组，不选择第1个元素的掩码).</summary>
        public static ref readonly Vector<T> XyNotYMask { get { return ref XyXMask; } }
        /// <summary>Rgba - R mask. For a 4-element group, select the mask of the 0th element (对于4个元素的组，选择第0个元素的掩码). Alias has <see cref="XyzwXMask"/>.</summary>
        public static ref readonly Vector<T> RgbaRMask { get { return ref XyzwXMask; } }
        /// <summary>Rgba - G mask. For a 4-element group, select the mask of the 1th element (对于4个元素的组，选择第1个元素的掩码). Alias has <see cref="XyzwYMask"/>.</summary>
        public static ref readonly Vector<T> RgbaGMask { get { return ref XyzwYMask; } }
        /// <summary>Rgba - B mask. For a 4-element group, select the mask of the 2th element (对于4个元素的组，选择第2个元素的掩码). Alias has <see cref="XyzwZMask"/>.</summary>
        public static ref readonly Vector<T> RgbaBMask { get { return ref XyzwZMask; } }
        /// <summary>Rgba - A mask. For a 4-element group, select the mask of the 3th element (对于4个元素的组，选择第3个元素的掩码). Alias has <see cref="XyzwWMask"/>.</summary>
        public static ref readonly Vector<T> RgbaAMask { get { return ref XyzwWMask; } }
        /// <summary>Rgba - Not R mask. For a 4-element group, not select the mask of the 0th element (对于4个元素的组，不选择第0个元素的掩码). Alias has <see cref="XyzwNotXMask"/>.</summary>
        public static ref readonly Vector<T> RgbaNotRMask { get { return ref XyzwNotXMask; } }
        /// <summary>Rgba - Not G mask. For a 4-element group, not select the mask of the 1th element (对于4个元素的组，不选择第1个元素的掩码). Alias has <see cref="XyzwNotYMask"/>.</summary>
        public static ref readonly Vector<T> RgbaNotGMask { get { return ref XyzwNotYMask; } }
        /// <summary>Rgba - Not B mask. For a 4-element group, not select the mask of the 2th element (对于4个元素的组，不选择第2个元素的掩码). Alias has <see cref="XyzwNotZMask"/>.</summary>
        public static ref readonly Vector<T> RgbaNotBMask { get { return ref XyzwNotZMask; } }
        /// <summary>Rgba - Not A mask. For a 4-element group, not select the mask of the 3th element (对于4个元素的组，不选择第3个元素的掩码). Alias has <see cref="XyzwNotWMask"/>.</summary>
        public static ref readonly Vector<T> RgbaNotAMask { get { return ref XyzwNotWMask; } }


    }
}
