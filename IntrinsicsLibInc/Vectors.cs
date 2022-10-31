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

        // == Vector as ==

#if NETCOREAPP3_0_OR_GREATER
        ///// <summary>
        ///// Reinterprets a <see cref="Vector64{T}"/> as a new <see cref="Vector{T}"/> (将 <see cref="Vector64{T}"/> 重新解释为新的 <see cref="Vector{T}"/>).
        ///// </summary>
        ///// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        ///// <param name="value">The vector to reinterpret (要重新解释的向量).</param>
        ///// <returns>value reinterpreted as a new <see cref="Vector{T}"/> (重新解释后新的 <see cref="Vector{T}"/>)值.</returns>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Vector<T> AsVector<T>(Vector64<T> value) where T : struct {
        //    //ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
        //    return Unsafe.As<Vector64<T>, Vector<T>>(ref value);
        //}

        /// <summary>
        /// Reinterprets a <see cref="Vector128{T}"/> as a new <see cref="Vector{T}"/> (将 <see cref="Vector128{T}"/> 重新解释为新的 <see cref="Vector{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="value">The vector to reinterpret (要重新解释的向量).</param>
        /// <returns>value reinterpreted as a new <see cref="Vector{T}"/> (重新解释后新的 <see cref="Vector{T}"/>)值.</returns>
        /// <seealso cref="Vector128.AsVector{T}(Vector128{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> AsVector<T>(Vector128<T> value) where T : struct {
            //ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
            return Unsafe.As<Vector128<T>, Vector<T>>(ref value);
        }

        /// <summary>
        /// Reinterprets a <see cref="Vector256{T}"/> as a new <see cref="Vector{T}"/> (将 <see cref="Vector256{T}"/> 重新解释为新的 <see cref="Vector{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="value">The vector to reinterpret (要重新解释的向量).</param>
        /// <returns>value reinterpreted as a new <see cref="Vector{T}"/> (重新解释后新的 <see cref="Vector{T}"/>)值.</returns>
        /// <seealso cref="Vector256.AsVector{T}(Vector256{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> AsVector<T>(Vector256<T> value) where T : struct {
            //ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
            return Unsafe.As<Vector256<T>, Vector<T>>(ref value);
        }

        ///// <summary>
        ///// Reinterprets a <see cref="Vector{T}"/> as a new <see cref="Vector64{T}"/> (将 <see cref="Vector{T}"/> 重新解释为新的 <see cref="Vector64{T}"/>).
        ///// </summary>
        ///// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        ///// <param name="value">The vector to reinterpret (要重新解释的向量).</param>
        ///// <returns>value reinterpreted as a new <see cref="Vector64{T}"/> (重新解释后新的 <see cref="Vector64{T}"/>)值.</returns>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Vector64<T> AsVector64<T>(Vector<T> value) where T : struct {
        //    //ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
        //    Vector64<T> source = default(Vector64<T>);
        //    Unsafe.WriteUnaligned(ref Unsafe.As<Vector64<T>, byte>(ref source), value);
        //    return source;
        //}

        /// <summary>
        /// Reinterprets a <see cref="Vector{T}"/> as a new <see cref="Vector128{T}"/> (将 <see cref="Vector{T}"/> 重新解释为新的 <see cref="Vector128{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="value">The vector to reinterpret (要重新解释的向量).</param>
        /// <returns>value reinterpreted as a new <see cref="Vector128{T}"/> (重新解释后新的 <see cref="Vector128{T}"/>)值.</returns>
        /// <seealso cref="Vector128.AsVector128{T}(Vector{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<T> AsVector128<T>(Vector<T> value) where T : struct {
            //ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
            Vector128<T> source = default(Vector128<T>);
            Unsafe.WriteUnaligned(ref Unsafe.As<Vector128<T>, byte>(ref source), value);
            return source;
        }

        /// <summary>
        /// Reinterprets a <see cref="Vector{T}"/> as a new <see cref="Vector256{T}"/> (将 <see cref="Vector{T}"/> 重新解释为新的 <see cref="Vector256{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="value">The vector to reinterpret (要重新解释的向量).</param>
        /// <returns>value reinterpreted as a new <see cref="Vector256{T}"/> (重新解释后新的 <see cref="Vector256{T}"/>)值.</returns>
        /// <seealso cref="Vector256.AsVector256{T}(Vector{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> AsVector256<T>(Vector<T> value) where T : struct {
            //ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
            Vector256<T> source = default(Vector256<T>);
            Unsafe.WriteUnaligned(ref Unsafe.As<Vector256<T>, byte>(ref source), value);
            return source;
        }

#endif

        // == Vector methods ==

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> instance with all elements initialized to the specified value (创建新的 <see cref="Vector{T}"/> 实例，其中所有元素已初始化为指定值).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="value">The value that all elements will be initialized to (所有元素的初始化目标值).</param>
        /// <returns>A new <see cref="Vector{T}"/> with all elements initialized to value (一个新的 <see cref="Vector{T}"/>，其中所有元素已初始化为 <paramref name="value"/> ).</returns>
        /// <seealso cref="Vector{T}(T)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> Create<T>(T value) where T : struct {
            return new Vector<T>(value);
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a given array (从给定数组创建一个新的 <see cref="Vector{T}"/> ).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="values">The array from which the vector is created (用于创建向量的数组).</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (一个新<see cref="Vector{T}"/>，其元素设置为来自<paramref name="values"/>首批满足长度的元素).</returns>
        /// <seealso cref="Vector{T}(T[])"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> Create<T>(T[] values) where T:struct {
            return new Vector<T>(values);
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a given array starting at a specified index position (于指定索引位置开始，从指定数组创建一个 <see cref="Vector{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="values">The array from which the vector is created (用于创建向量的数组).</param>
        /// <param name="index">The starting index position from which to create the vector (欲创建向量的起始索引位置).</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (一个新<see cref="Vector{T}"/>，其元素设置为来自<paramref name="values"/>首批满足长度的元素).</returns>
        /// <exception cref="IndexOutOfRangeException">The <paramref name="index"/> is less than zero (<paramref name="index"/> 小于零). The length of <paramref name="values"/>, starting from <paramref name="index"/>, is less than <see cref="Vector{T}.Count"/> (从 <paramref name="index"/> 开始的 <paramref name="values"/> 的长度小于 <see cref="Vector{T}.Count"/>).</exception>
        /// <seealso cref="Vector{T}(T[], int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> Create<T>(T[] values, int index) where T : struct {
            return new Vector<T>(values, index);
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a given read-only span of bytes (根据给定的只读字节跨度构造一个 <see cref="Vector{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="values">A read-only span of bytes that contains the values to add to the vector (从中创建向量的只读字节跨度).</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (一个新<see cref="Vector{T}"/>，其元素设置为来自<paramref name="values"/>首批满足长度的元素).</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least <see cref="Vector{T}.Count"/> elements (<paramref name="values"/> 的长度小于 <see cref="Vector{T}.Count"/>).</exception>
        /// <seealso cref="Vector{T}(ReadOnlySpan{byte})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> Create<T>(ReadOnlySpan<byte> values) where T : struct {
#if NETCOREAPP3_0_OR_GREATER
            return new Vector<T>(values);
#else
            if (values.Length < Vector<byte>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
            return Unsafe.ReadUnaligned<Vector<T>>(ref Scalars.GetReference(values));
#endif // NETCOREAPP3_0_OR_GREATER
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="ReadOnlySpan{T}"/> (根据给定的 <see cref="ReadOnlySpan{T}"/> 构造一个 <see cref="Vector{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="values">The readonly span from which the vector is created (从中创建向量的只读跨度).</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (一个新<see cref="Vector{T}"/>，其元素设置为来自<paramref name="values"/>首批满足长度的元素).</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least <see cref="Vector{T}.Count"/> elements (<paramref name="values"/> 的长度小于 <see cref="Vector{T}.Count"/>).</exception>
        /// <seealso cref="Vector{T}(ReadOnlySpan{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> Create<T>(ReadOnlySpan<T> values) where T : struct {
#if NETCOREAPP3_0_OR_GREATER
            return new Vector<T>(values);
#else
            if (values.Length < Vector<T>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
            return Unsafe.ReadUnaligned<Vector<T>>(ref Unsafe.As<T, byte>(ref Scalars.GetReference(values)));
#endif // NETCOREAPP3_0_OR_GREATER
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="Span{T}"/> (根据给定的 <see cref="Span{T}"/> 构造一个 <see cref="Vector{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="values">The span from which the vector is created (从中创建向量的跨度).</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (一个新<see cref="Vector{T}"/>，其元素设置为来自<paramref name="values"/>首批满足长度的元素).</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least <see cref="Vector{T}.Count"/> elements (<paramref name="values"/> 的长度小于 <see cref="Vector{T}.Count"/>).</exception>
        /// <seealso cref="Vector{T}(Span{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> Create<T>(Span<T> values) where T : struct {
#if (NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER)
            return new Vector<T>(values);
#else
            if (values.Length < Vector<T>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
            return Unsafe.ReadUnaligned<Vector<T>>(ref Unsafe.As<T, byte>(ref Scalars.GetReference(values)));
#endif // NETCOREAPP2_1_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector{T}"/> from a given array starting at a specified index position (于指定索引位置开始，从指定数组旋转创建一个 <see cref="Vector{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="values">The array from which the vector is created (用于创建向量的数组).</param>
        /// <param name="index">The starting index position from which to create the vector (欲创建向量的起始索引位置).</param>
        /// <param name="length">The rotation length of the element (The rotation length of the element).</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (一个新<see cref="Vector{T}"/>，其元素设置为来自<paramref name="values"/>首批满足长度的元素).</returns>
        /// <exception cref="IndexOutOfRangeException">The <paramref name="index"/> is less than zero (<paramref name="index"/> 小于零). The length of <paramref name="values"/>, starting from <paramref name="index"/>, is less than <see cref="Vector{T}.Count"/> (从 <paramref name="index"/> 开始的 <paramref name="values"/> 的长度小于 <see cref="Vector{T}.Count"/>).</exception>
        public static Vector<T> CreateRotate<T>(T[] values, int index, int length) where T : struct {
            int idxEnd = index + length;
            int idx = index;
            if (null == values || values.Length <= 0) return Vector<T>.Zero;
            if (index < 0 || idxEnd > values.Length) {
                throw new IndexOutOfRangeException(string.Format("Index({0}) was outside the bounds{1} of the array!", index, values.Length));
            }
            Vector<T> temp = default;
            unsafe {
                // T* arr = (T*)&temp; // CS0208	Cannot take the address of, get the size of, or declare a pointer to a managed type ('T')
                Span<T> arr = new Span<T>(&temp, Vector<T>.Count);
                for (int i = 0; i < arr.Length; ++i) {
                    arr[i] = values[idx];
                    ++idx;
                    if (idx >= idxEnd) idx = index;
                }
                return Create(arr);
            }
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector{T}"/> from a given array (从给定数组旋转创建一个新的 <see cref="Vector{T}"/> ).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="values">The array from which the vector is created (用于创建向量的数组).</param>
        /// <returns>A new <see cref="Vector{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (一个新<see cref="Vector{T}"/>，其元素设置为来自<paramref name="values"/>首批满足长度的元素).</returns>
        public static Vector<T> CreateRotate<T>(params T[] values) where T : struct {
            return CreateRotate<T>(values, 0, values.Length);
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="Func{T, TResult}"/> (从给定 <see cref="Func{T, TResult}"/> 创建一个新的 <see cref="Vector{T}"/> ) .
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="func">A function that gets the value of each element (获取每个元素值的函数). Prototype: `T func(int index)`, `index` is element index.</param>
        /// <returns>A new <see cref="Vector{T}"/> from a from the given <see cref="Func{T, TResult}"/> (一个新<see cref="Vector{T}"/>，其元素来 <see cref="Func{T, TResult}"/>).</returns>
        public static Vector<T> CreateByFunc<T>(Func<int, T> func) where T : struct {
            if (null == func) throw new ArgumentNullException(nameof(func));
            Vector<T> temp = default;
            unsafe {
                Span<T> arr = new Span<T>(&temp, Vector<T>.Count);
                for (int i = 0; i < Vector<T>.Count; ++i) {
                    arr[i] = func(i);
                }
                return Create(arr);
            }
        }

        /// <summary>
        /// Creates a new <see cref="Vector{T}"/> from a from the given <see cref="Func{T1, T2, TResult}"/> (从给定 <see cref="Func{T1, T2, TResult}"/> 创建一个新的 <see cref="Vector{T}"/> ) .
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <typeparam name="TUserdata">Type of <paramref name="userdata"/> (<paramref name="userdata"/>的类型).</typeparam>
        /// <param name="func">A function that gets the value of each element (获取每个元素值的函数). Prototype: `T func(int index, TUserdata userdata)`, `index` is element index.</param>
        /// <param name="userdata">The userdata (用户自定义数据).</param>
        /// <returns>A new <see cref="Vector{T}"/> from a from the given <see cref="Func{T1, T2, TResult}"/> (一个新<see cref="Vector{T}"/>，其元素来 <see cref="Func{T1, T2, TResult}"/>).</returns>
        public static Vector<T> CreateByFunc<T, TUserdata>(Func<int, TUserdata, T> func, TUserdata userdata) where T : struct {
            if (null == func) throw new ArgumentNullException(nameof(func));
            Vector<T> temp = default;
            unsafe {
                Span<T> arr = new Span<T>(&temp, Vector<T>.Count);
                for (int i = 0; i < Vector<T>.Count; ++i) {
                    arr[i] = func(i, userdata);
                }
                return Create(arr);
            }
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> whose components are of a specified double value (创建一个 <see cref="Vector{T}"/>，其元素为指定的双精度浮点值).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="src">Source value (源值).</param>
        /// <returns>A new <see cref="Vector{T}"/> with all elements initialized to value (一个新的 <see cref="Vector{T}"/>，其中所有元素已初始化为 <paramref name="value"/> ).</returns>
        public static Vector<T> CreateByDouble<T>(double src) where T : struct {
            return Create(Scalars.GetByDouble<T>(src));
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> from double value `for` loop (创建一个 <see cref="Vector{T}"/>，其元素来自双精度浮点值的`for`循环).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="start">Start value (起始值).</param>
        /// <param name="step">Increments at each step (每一步的增量).</param>
        /// <returns>A new <see cref="Vector{T}"/> from a from double value `for` loop (一个新<see cref="Vector{T}"/>，其元素来自双精度浮点值的`for`循环.</returns>
        public static Vector<T> CreateByDoubleLoop<T>(double start, double step) where T : struct {
            return CreateByFunc(delegate (int index) {
                double src = start + step * index;
                return Scalars.GetByDouble<T>(src);
            });
        }

        /// <summary>
        /// Creates a <see cref="Vector{T}"/> whose components are of a specified integer bits (创建一个 <see cref="Vector{T}"/>，其元素为指定的整数位).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="src">Source value (源值).</param>
        /// <returns>A new <see cref="Vector{T}"/> with all elements initialized to value (一个新的 <see cref="Vector{T}"/>，其中所有元素已初始化为 <paramref name="value"/> ).</returns>
        public static Vector<T> CreateByBits<T>(Int64 src) where T : struct {
            return Create(Scalars.GetByBits<T>(src));
        }

        /// <summary>
        /// Computes the ones-complement (~) of a vector (计算向量的补数).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="src">The vector whose ones-complement is to be computed (要计算其补数的向量).</param>
        /// <returns>A vector whose elements are the ones-complement of the corresponding elements in <paramref name="src"/> (一个向量，其各元素是 <paramref name="src"/> 相应元素的补数).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> OnesComplement<T>(Vector<T> src) where T : struct {
            return ~src;
        }

    }

    /// <summary>
    /// Constants of <see cref="Vector{T}"/> .
    /// </summary>
    /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
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
        /// <summary>Serial Value (顺序值). e.g. 0, 1, 2, 3 ...</summary>
        public static readonly Vector<T> Serial;
        /// <summary>Demo Value (演示值). It is a value constructed for testing purposes (它是为测试目的而构造的值).</summary>
        public static readonly Vector<T> Demo;
        /// <summary>Serial bit pos mask (顺序位偏移的掩码). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        public static readonly Vector<T> MaskBitPosSerial;
        /// <summary>Serial bits mask (顺序位集的掩码). e.g. 1, 3, 7, 0xF, 0x1F ...</summary>
        public static readonly Vector<T> MaskBitsSerial;
        /// <summary>Interlaced sign number (交错的符号数值). e.g. 1, -1, 1, -1, 1, -1 ...</summary>
        public static readonly Vector<T> InterlacedSign;
        /// <summary>Interlaced sign number starting with a negative number (负数开头的交错的符号数值). e.g. -1, 1, -1, 1, -1, 1 ...</summary>
        public static readonly Vector<T> InterlacedSignNegative;
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
            InterlacedSign = Vectors.CreateRotate<T>(ElementV1, ElementV_1);
            InterlacedSignNegative = Vectors.CreateRotate<T>(ElementV_1, ElementV1);
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

        /// <summary>Zero (0).</summary>
        public static Vector<T> Zero { get { return V0; } }
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
