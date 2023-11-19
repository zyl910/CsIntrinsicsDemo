using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

namespace Zyl.VectorTraits {

    /// <summary>
    /// Methods of <see cref="Vector512{T}"/> .
    /// </summary>
    public static class Vector512s {
#if NET8_0_OR_GREATER

        // == Mask array ==
        // It takes up too much space to construct a batch of mask arrays for each element type. Int32/UInt32/Single can share a 4-byte mask, and the total bit length of vector types is fixed. Therefore, arrays such as MaskBitPosArray1B can be shared by multiple element types. (��Ϊÿһ��Ԫ�����Ͷ�����һ����������Ļ�, ̫ռ�ռ���. ���ǵ� Int32/UInt32/Single �ɹ���4�ֽڵ�����, ���������͵���λ���ǹ̶���, ���� MaskBitPosArray1B ��������Ը�����Ԫ������������.)

        /// <summary>Bit pos mask array - 1Byte (λƫ����������� - 1�ֽ�). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        private static readonly Vector512<Byte>[] MaskBitPosArray1B;
        /// <summary>Bit pos mask array - 2Byte (λƫ����������� - 2�ֽ�). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        private static readonly Vector512<Byte>[] MaskBitPosArray2B;
        /// <summary>Bit pos mask array - 4Byte (λƫ����������� - 4�ֽ�). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        private static readonly Vector512<Byte>[] MaskBitPosArray4B;
        /// <summary>Bit pos mask array - 8Byte (λƫ����������� - 8�ֽ�). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        private static readonly Vector512<Byte>[] MaskBitPosArray8B;
        /// <summary>Bits mask array - 1Byte (λ����������� - 1�ֽ�). e.g. 0, 1, 3, 7, 0xF, 0x1F ...</summary>
        private static readonly Vector512<Byte>[] MaskBitsArray1B;
        /// <summary>Bits mask array - 2Byte (λ����������� - 2�ֽ�). e.g. 0, 1, 3, 7, 0xF, 0x1F ...</summary>
        private static readonly Vector512<Byte>[] MaskBitsArray2B;
        /// <summary>Bits mask array - 4Byte (λ����������� - 4�ֽ�). e.g. 0, 1, 3, 7, 0xF, 0x1F ...</summary>
        private static readonly Vector512<Byte>[] MaskBitsArray4B;
        /// <summary>Bits mask array - 8Byte (λ����������� - 8�ֽ�). e.g. 0, 1, 3, 7, 0xF, 0x1F ...</summary>
        private static readonly Vector512<Byte>[] MaskBitsArray8B;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Vector512s() {
            unchecked {
                Int64 bitpos;
                Int64 bits;
                int i;
                MaskBitPosArray1B = new Vector512<Byte>[1 * 8];
                MaskBitPosArray2B = new Vector512<Byte>[2 * 8];
                MaskBitPosArray4B = new Vector512<Byte>[4 * 8];
                MaskBitPosArray8B = new Vector512<Byte>[8 * 8];
                MaskBitsArray1B = new Vector512<Byte>[1 * 8 + 1];
                MaskBitsArray2B = new Vector512<Byte>[2 * 8 + 1];
                MaskBitsArray4B = new Vector512<Byte>[4 * 8 + 1];
                MaskBitsArray8B = new Vector512<Byte>[8 * 8 + 1];
                MaskBitsArray1B[0] = Vector512<Byte>.Zero;
                MaskBitsArray2B[0] = Vector512<Byte>.Zero;
                MaskBitsArray4B[0] = Vector512<Byte>.Zero;
                MaskBitsArray8B[0] = Vector512<Byte>.Zero;
                bitpos = 1;
                bits = 1;
                for (i = 0; i < MaskBitPosArray8B.Length; ++i) {
                    if (i < MaskBitPosArray1B.Length) {
                        MaskBitPosArray1B[i] = Vector512.Create(Scalars.GetByBits<Byte>(bitpos));
                        MaskBitsArray1B[1 + i] = Vector512.Create(Scalars.GetByBits<Byte>(bits));
                    }
                    if (i < MaskBitPosArray2B.Length) {
                        MaskBitPosArray2B[i] = Vector512.AsByte(Vector512.Create(Scalars.GetByBits<UInt16>(bitpos)));
                        MaskBitsArray2B[1 + i] = Vector512.AsByte(Vector512.Create(Scalars.GetByBits<UInt16>(bits)));
                    }
                    if (i < MaskBitPosArray4B.Length) {
                        MaskBitPosArray4B[i] = Vector512.AsByte(Vector512.Create(Scalars.GetByBits<UInt32>(bitpos)));
                        MaskBitsArray4B[1 + i] = Vector512.AsByte(Vector512.Create(Scalars.GetByBits<UInt32>(bits)));
                    }
                    if (i < MaskBitPosArray8B.Length) {
                        MaskBitPosArray8B[i] = Vector512.AsByte(Vector512.Create(Scalars.GetByBits<UInt64>(bitpos)));
                        MaskBitsArray8B[1 + i] = Vector512.AsByte(Vector512.Create(Scalars.GetByBits<UInt64>(bits)));
                    }
                    // next.
                    bitpos <<= 1;
                    bits = bits << 1 | 1;
                }
                if (0 != bits) {
                    // [Debug]
                }
            }
        }

        /// <summary>
        /// Get bit pos mask array (ȡ��λƫ�����������).
        /// </summary>
        /// <param name="byteSize">Ԫ�ص��ֽڴ�С (Ԫ�ص��ֽڴ�С).</param>
        /// <returns>Returns bit pos mask array (����λƫ�����������). An 8-byte array is returned if not found, to avoid returning null (�Ҳ���ʱ����8�ֽڵ�����, ����Ϊ�˱��ⷵ��null).</returns>
        internal static Vector512<Byte>[] GetMaskBitPosArray(int byteSize) {
            if (1 == byteSize) {
                return MaskBitPosArray1B;
            } else if (2 == byteSize) {
                return MaskBitPosArray2B;
            } else if (4 == byteSize) {
                return MaskBitPosArray4B;
            } else {
                return MaskBitPosArray8B;
            }
        }

        /// <summary>
        /// Get bits mask array (ȡ��λ�����������).
        /// </summary>
        /// <param name="byteSize">Ԫ�ص��ֽڴ�С (Ԫ�ص��ֽڴ�С).</param>
        /// <returns>Returns bits mask array (����λ�����������). An 8-byte array is returned if not found, to avoid returning null (�Ҳ���ʱ����8�ֽڵ�����, ����Ϊ�˱��ⷵ��null).</returns>
        internal static Vector512<Byte>[] GetMaskBitsArray(int byteSize) {
            if (1 == byteSize) {
                return MaskBitsArray1B;
            } else if (2 == byteSize) {
                return MaskBitsArray2B;
            } else if (4 == byteSize) {
                return MaskBitsArray4B;
            } else {
                return MaskBitsArray8B;
            }
        }

        // == Vector512 methods ==

        /// <summary>
        /// Creates a new <see cref="Vector512{T}"/> instance with all elements initialized to the specified value (�����µ� <see cref="Vector512{T}"/> ʵ������������Ԫ���ѳ�ʼ��Ϊָ��ֵ).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="value">The value that all elements will be initialized to (����Ԫ�صĳ�ʼ��Ŀ��ֵ).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with all elements initialized to value (һ���µ� <see cref="Vector512{T}"/>����������Ԫ���ѳ�ʼ��Ϊ <paramref name="value"/> ).</returns>
        /// <seealso cref="Vector512{T}(T)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector512<T> Create<T>(T value) where T : struct {
#if NET7_0_OR_GREATER
            return Vector512.Create(value);
#else
            if (typeof(T) == typeof(Single)) {
                return (Vector512<T>)(object)Vector512.Create((Single)(object)value);
            } else if (typeof(T) == typeof(Double)) {
                return (Vector512<T>)(object)Vector512.Create((Double)(object)value);
            } else if (typeof(T) == typeof(SByte)) {
                return (Vector512<T>)(object)Vector512.Create((SByte)(object)value);
            } else if (typeof(T) == typeof(Int16)) {
                return (Vector512<T>)(object)Vector512.Create((Int16)(object)value);
            } else if (typeof(T) == typeof(Int32)) {
                return (Vector512<T>)(object)Vector512.Create((Int32)(object)value);
            } else if (typeof(T) == typeof(Int64)) {
                return (Vector512<T>)(object)Vector512.Create((Int64)(object)value);
            } else if (typeof(T) == typeof(Byte)) {
                return (Vector512<T>)(object)Vector512.Create((Byte)(object)value);
            } else if (typeof(T) == typeof(UInt16)) {
                return (Vector512<T>)(object)Vector512.Create((UInt16)(object)value);
            } else if (typeof(T) == typeof(UInt32)) {
                return (Vector512<T>)(object)Vector512.Create((UInt32)(object)value);
            } else if (typeof(T) == typeof(UInt64)) {
                return (Vector512<T>)(object)Vector512.Create((UInt64)(object)value);
            } else {
                return (Vector512<T>)(object)Vector512.Create((dynamic)value);
            }
#endif
        }

        /// <summary>
        /// Creates a new <see cref="Vector512{T}"/> from a given array (�Ӹ������鴴��һ���µ� <see cref="Vector512{T}"/> ).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The array from which the vector is created (���ڴ�������������).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        /// <seealso cref="Vector512{T}(T[])"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector512<T> Create<T>(T[] values) where T : struct {
#if NET7_0_OR_GREATER
            return Vector512.Create(values);
#else
            return Create(values, 0);
#endif
        }

        /// <summary>
        /// Creates a new <see cref="Vector512{T}"/> from a given array starting at a specified index position (��ָ������λ�ÿ�ʼ����ָ�����鴴��һ�� <see cref="Vector512{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The array from which the vector is created (���ڴ�������������).</param>
        /// <param name="index">The starting index position from which to create the vector (��������������ʼ����λ��).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        /// <exception cref="IndexOutOfRangeException">The <paramref name="index"/> is less than zero (<paramref name="index"/> С����). The length of <paramref name="values"/>, starting from <paramref name="index"/>, is less than <see cref="Vector512{T}.Count"/> (�� <paramref name="index"/> ��ʼ�� <paramref name="values"/> �ĳ���С�� <see cref="Vector512{T}.Count"/>).</exception>
        /// <seealso cref="Vector512{T}(T[], int)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector512<T> Create<T>(T[] values, int index) where T : struct {
#if NET7_0_OR_GREATER
            return Vector512.Create(values, index);
#else
            if (null == values) throw new ArgumentNullException(nameof(values));
            int idxEnd = index + Vector512<T>.Count;
            if (index < 0 || idxEnd > values.Length) {
                throw new IndexOutOfRangeException(string.Format("Index({0}) was outside the bounds{1} of the array!", index, values.Length));
            }
            return Unsafe.ReadUnaligned<Vector512<T>>(ref Unsafe.As<T, byte>(ref values[index]));
#endif
        }

        /// <summary>
        /// Creates a new <see cref="Vector512{T}"/> from a given read-only span of bytes (���ݸ�����ֻ���ֽڿ�ȹ���һ�� <see cref="Vector512{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">A read-only span of bytes that contains the values to add to the vector (���д���������ֻ���ֽڿ��).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least <see cref="Vector512{T}.Count"/> elements (<paramref name="values"/> �ĳ���С�� <see cref="Vector512{T}.Count"/>).</exception>
        /// <seealso cref="Vector512{T}(ReadOnlySpan{byte})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector512<T> Create<T>(ReadOnlySpan<byte> values) where T : struct {
            if (values.Length < Vector512<byte>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
            return Unsafe.ReadUnaligned<Vector512<T>>(ref MemoryMarshal.GetReference(values));
        }

        /// <summary>
        /// Creates a new <see cref="Vector512{T}"/> from a from the given <see cref="ReadOnlySpan{T}"/> (���ݸ����� <see cref="ReadOnlySpan{T}"/> ����һ�� <see cref="Vector512{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The readonly span from which the vector is created (���д���������ֻ�����).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least <see cref="Vector512{T}.Count"/> elements (<paramref name="values"/> �ĳ���С�� <see cref="Vector512{T}.Count"/>).</exception>
        /// <seealso cref="Vector512{T}(ReadOnlySpan{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector512<T> Create<T>(ReadOnlySpan<T> values) where T : struct {
#if NET7_0_OR_GREATER
            return Vector512.Create(values);
#else
            if (values.Length < Vector512<T>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
            return Unsafe.ReadUnaligned<Vector512<T>>(ref Unsafe.As<T, byte>(ref MemoryMarshal.GetReference(values)));
#endif // NET7_0_OR_GREATER
        }

        /// <summary>
        /// Creates a new <see cref="Vector512{T}"/> from a from the given <see cref="Span{T}"/> (���ݸ����� <see cref="Span{T}"/> ����һ�� <see cref="Vector512{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The span from which the vector is created (���д��������Ŀ��).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        /// <exception cref="IndexOutOfRangeException"><paramref name="values"/> did not contain at least <see cref="Vector512{T}.Count"/> elements (<paramref name="values"/> �ĳ���С�� <see cref="Vector512{T}.Count"/>).</exception>
        /// <seealso cref="Vector512{T}(Span{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector512<T> Create<T>(Span<T> values) where T : struct {
            if (values.Length < Vector512<T>.Count) {
                throw new IndexOutOfRangeException(string.Format("Index was outside the bounds({0}) of the array!", values.Length));
            }
            return Unsafe.ReadUnaligned<Vector512<T>>(ref Unsafe.As<T, byte>(ref MemoryMarshal.GetReference(values)));
        }

        /// <summary>
        /// Padding creates a new <see cref="Vector512{T}"/> from a given span starting at a specified index position (��ָ������λ�ÿ�ʼ����ָ����Ȳ��봴��һ�� <see cref="Vector512{T}"/>). The element after values is initialized to 0(values ֮���Ԫ�ػ��ʼ��Ϊ0).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The span from which the vector is created (���ڴ��������Ŀ��).</param>
        /// <param name="index">Starting index position of valid data in <paramref name="values"/> (<paramref name="values"/> ����Ч���ݵ���ʼ����λ��).</param>
        /// <param name="length">Length of valid data in <paramref name="values"/> (<paramref name="values"/> ����Ч���ݵĳ���).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        /// <exception cref="IndexOutOfRangeException">The <paramref name="index"/> is less than zero (<paramref name="index"/> С����). The length of <paramref name="values"/>, starting from <paramref name="index"/>, is less than <see cref="Vector512{T}.Count"/> (�� <paramref name="index"/> ��ʼ�� <paramref name="values"/> �ĳ���С�� <see cref="Vector512{T}.Count"/>).</exception>
        public static Vector512<T> CreatePadding<T>(ReadOnlySpan<T> values, int index, int length) where T : struct {
            int idxEnd = index + length;
            int idx = index;
            if (null == values || values.Length <= 0) return Vector512<T>.Zero;
            if (index < 0 || idxEnd > values.Length) {
                throw new IndexOutOfRangeException(string.Format("Index({0}) was outside the bounds{1} of the array!", index, values.Length));
            }
            Vector512<T> temp = default;
            unsafe {
                // T* arr = (T*)&temp; // CS0208	Cannot take the address of, get the size of, or declare a pointer to a managed type ('T')
                Span<T> arr = new Span<T>(&temp, Vector512<T>.Count);
                int m = Math.Min(arr.Length, length);
                for (int i = 0; i < m; ++i) {
                    arr[i] = values[idx];
                    ++idx;
                    if (idx >= idxEnd) break;
                }
                return Create(arr);
            }
        }

        /// <summary>
        /// Padding creates a new <see cref="Vector512{T}"/> from a given span (��ָ����Ȳ��봴��һ�� <see cref="Vector512{T}"/>). The element after values is initialized to 0(values ֮���Ԫ�ػ��ʼ��Ϊ0).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The span from which the vector is created (���ڴ��������Ŀ��).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        public static Vector512<T> CreatePadding<T>(ReadOnlySpan<T> values) where T : struct {
            return CreatePadding<T>(values, 0, values.Length);
        }

        /// <summary>
        /// Padding creates a new <see cref="Vector512{T}"/> from a given array (�Ӹ������鲹�봴��һ���µ� <see cref="Vector512{T}"/> ). The element after values is initialized to 0(values ֮���Ԫ�ػ��ʼ��Ϊ0).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The array from which the vector is created (���ڴ�������������).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        public static Vector512<T> CreatePadding<T>(params T[] values) where T : struct {
            return CreatePadding<T>(values, 0, values.Length);
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector512{T}"/> from a given span starting at a specified index position (��ָ������λ�ÿ�ʼ����ָ�������ת����һ�� <see cref="Vector512{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The span from which the vector is created (���ڴ��������Ŀ��).</param>
        /// <param name="index">Starting index position of valid data in <paramref name="values"/> (<paramref name="values"/> ����Ч���ݵ���ʼ����λ��).</param>
        /// <param name="length">Length of valid data in <paramref name="values"/> (<paramref name="values"/> ����Ч���ݵĳ���).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        /// <exception cref="IndexOutOfRangeException">The <paramref name="index"/> is less than zero (<paramref name="index"/> С����). The length of <paramref name="values"/>, starting from <paramref name="index"/>, is less than <see cref="Vector512{T}.Count"/> (�� <paramref name="index"/> ��ʼ�� <paramref name="values"/> �ĳ���С�� <see cref="Vector512{T}.Count"/>).</exception>
        public static Vector512<T> CreateRotate<T>(ReadOnlySpan<T> values, int index, int length) where T : struct {
            int idxEnd = index + length;
            int idx = index;
            if (null == values || values.Length <= 0) return Vector512<T>.Zero;
            if (index < 0 || idxEnd > values.Length) {
                throw new IndexOutOfRangeException(string.Format("Index({0}) was outside the bounds{1} of the array!", index, values.Length));
            }
            Vector512<T> temp = default;
            unsafe {
                // T* arr = (T*)&temp; // CS0208	Cannot take the address of, get the size of, or declare a pointer to a managed type ('T')
                Span<T> arr = new Span<T>(&temp, Vector512<T>.Count);
                for (int i = 0; i < arr.Length; ++i) {
                    arr[i] = values[idx];
                    ++idx;
                    if (idx >= idxEnd) idx = index;
                }
                return Create(arr);
            }
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector512{T}"/> from a given span starting at a specified index position (��ָ������λ�ÿ�ʼ����ָ�������ת����һ�� <see cref="Vector512{T}"/>).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The span from which the vector is created (���ڴ��������Ŀ��).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        public static Vector512<T> CreateRotate<T>(ReadOnlySpan<T> values) where T : struct {
            return CreateRotate<T>(values, 0, values.Length);
        }

        /// <summary>
        /// Rotate creates a new <see cref="Vector512{T}"/> from a given array (�Ӹ���������ת����һ���µ� <see cref="Vector512{T}"/> ).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="values">The array from which the vector is created (���ڴ�������������).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with its elements set to the first Count elements from <paramref name="values"/> (һ����<see cref="Vector512{T}"/>����Ԫ������Ϊ����<paramref name="values"/>�������㳤�ȵ�Ԫ��).</returns>
        public static Vector512<T> CreateRotate<T>(params T[] values) where T : struct {
            return CreateRotate<T>(values, 0, values.Length);
        }

        /// <summary>
        /// Creates a new <see cref="Vector512{T}"/> from a from the given <see cref="Func{T, TResult}"/> (�Ӹ��� <see cref="Func{T, TResult}"/> ����һ���µ� <see cref="Vector512{T}"/> ) .
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="func">A function that gets the value of each element (��ȡÿ��Ԫ��ֵ�ĺ���). Prototype: `T func(int index)`, `index` is element index.</param>
        /// <returns>A new <see cref="Vector512{T}"/> from a from the given <see cref="Func{T, TResult}"/> (һ����<see cref="Vector512{T}"/>����Ԫ���� <see cref="Func{T, TResult}"/>).</returns>
        public static Vector512<T> CreateByFunc<T>(Func<int, T> func) where T : struct {
            if (null == func) throw new ArgumentNullException(nameof(func));
            Vector512<T> temp = default;
            unsafe {
                Span<T> arr = new Span<T>(&temp, Vector512<T>.Count);
                for (int i = 0; i < Vector512<T>.Count; ++i) {
                    arr[i] = func(i);
                }
                return Create(arr);
            }
        }

        /// <summary>
        /// Creates a new <see cref="Vector512{T}"/> from a from the given <see cref="Func{T1, T2, TResult}"/> (�Ӹ��� <see cref="Func{T1, T2, TResult}"/> ����һ���µ� <see cref="Vector512{T}"/> ) .
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <typeparam name="TUserdata">Type of <paramref name="userdata"/> (<paramref name="userdata"/>������).</typeparam>
        /// <param name="func">A function that gets the value of each element (��ȡÿ��Ԫ��ֵ�ĺ���). Prototype: `T func(int index, TUserdata userdata)`, `index` is element index.</param>
        /// <param name="userdata">The userdata (�û��Զ�������).</param>
        /// <returns>A new <see cref="Vector512{T}"/> from a from the given <see cref="Func{T1, T2, TResult}"/> (һ����<see cref="Vector512{T}"/>����Ԫ���� <see cref="Func{T1, T2, TResult}"/>).</returns>
        public static Vector512<T> CreateByFunc<T, TUserdata>(Func<int, TUserdata, T> func, TUserdata userdata) where T : struct {
            if (null == func) throw new ArgumentNullException(nameof(func));
            Vector512<T> temp = default;
            unsafe {
                Span<T> arr = new Span<T>(&temp, Vector512<T>.Count);
                for (int i = 0; i < Vector512<T>.Count; ++i) {
                    arr[i] = func(i, userdata);
                }
                return Create(arr);
            }
        }

        /// <summary>
        /// Creates a <see cref="Vector512{T}"/> whose components are of a specified double value (����һ�� <see cref="Vector512{T}"/>����Ԫ��Ϊָ����˫���ȸ���ֵ).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="src">Source value (Դֵ).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with all elements initialized to value (һ���µ� <see cref="Vector512{T}"/>����������Ԫ���ѳ�ʼ��Ϊ <paramref name="value"/> ).</returns>
        public static Vector512<T> CreateByDouble<T>(double src) where T : struct {
            return Create(Scalars.GetByDouble<T>(src));
        }

        /// <summary>
        /// Creates a <see cref="Vector512{T}"/> from double value `for` loop (����һ�� <see cref="Vector512{T}"/>����Ԫ������˫���ȸ���ֵ��`for`ѭ��).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="start">Start value (��ʼֵ).</param>
        /// <param name="step">Increments at each step (ÿһ��������).</param>
        /// <returns>A new <see cref="Vector512{T}"/> from a from double value `for` loop (һ����<see cref="Vector512{T}"/>����Ԫ������˫���ȸ���ֵ��`for`ѭ��.</returns>
        public static Vector512<T> CreateByDoubleLoop<T>(double start, double step) where T : struct {
            return CreateByFunc(delegate (int index) {
                double src = start + step * index;
                return Scalars.GetByDouble<T>(src);
            });
        }

        /// <summary>
        /// Creates a <see cref="Vector512{T}"/> whose components are of a specified integer bits (����һ�� <see cref="Vector512{T}"/>����Ԫ��Ϊָ��������λ).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="src">Source value (Դֵ).</param>
        /// <returns>A new <see cref="Vector512{T}"/> with all elements initialized to value (һ���µ� <see cref="Vector512{T}"/>����������Ԫ���ѳ�ʼ��Ϊ <paramref name="value"/> ).</returns>
        public static Vector512<T> CreateByBits<T>(Int64 src) where T : struct {
            return Create(Scalars.GetByBits<T>(src));
        }

        /// <summary>
        /// [Base] Computes the ones-complement (~) of a vector (���������Ĳ���).
        /// </summary>
        /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
        /// <param name="src">The vector whose ones-complement is to be computed (Ҫ�����䲹��������).</param>
        /// <returns>A vector whose elements are the ones-complement of the corresponding elements in <paramref name="src"/> (һ�����������Ԫ���� <paramref name="src"/> ��ӦԪ�صĲ���).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector512<T> BaseOnesComplement<T>(Vector512<T> src) where T : struct {
#if NET7_0_OR_GREATER
            return ~src;
#else
            unsafe {
                UInt64* p = (UInt64*)&src;
                p[0] = ~p[0];
                p[1] = ~p[1];
                p[2] = ~p[2];
                p[3] = ~p[3];
                return src;
            }
#endif // NET7_0_OR_GREATER
        }

#endif
    }

    /// <summary>
    /// Constants of <see cref="Vector512{T}"/> .
    /// </summary>
    /// <typeparam name="T">The vector element type (�����е�Ԫ�ص�����).</typeparam>
    public abstract class Vector512s<T> : AbstractVectors<T> where T : struct {
#if NETCOREAPP3_0_OR_GREATER
        /// <summary>Value 0 (0��ֵ).</summary>
        public static readonly Vector512<T> V0;
        /// <summary>All bit is 1 (����λ����1��ֵ).</summary>
        public static readonly Vector512<T> AllBitsSet;
        // -- Number struct --
        /// <summary>Sign mask (��������).</summary>
        public static readonly Vector512<T> SignMask;
        /// <summary>Exponent mask (ָ������).</summary>
        public static readonly Vector512<T> ExponentMask;
        /// <summary>Mantissa mask (β������).</summary>
        public static readonly Vector512<T> MantissaMask;
        /// <summary>Non-sign mask (�Ƿ�������).</summary>
        public static readonly Vector512<T> NonSignMask;
        /// <summary>Non-exponent mask (��ָ������).</summary>
        public static readonly Vector512<T> NonExponentMask;
        /// <summary>Non-mantissa mask (��β������).</summary>
        public static readonly Vector512<T> NonMantissaMask;
        /// <summary>Represents the smallest positive value that is greater than zero (��ʾ���������С��ֵ). When the type is an integer, the value is 1 (������Ϊ����ʱ����ֵΪ1).</summary>
        public static readonly Vector512<T> Epsilon;
        /// <summary>Represents the largest possible value (��ʾ������ֵ).</summary>
        public static readonly Vector512<T> MaxValue;
        /// <summary>Represents the smallest possible value (��ʾ������ֵ).</summary>
        public static readonly Vector512<T> MinValue;
        /// <summary>Represents not a number (NaN) (��ʾ������(NaN)����ֵ). When the type is an integer, the value is 0 (������Ϊ����ʱ����ֵΪ0).</summary>
        public static readonly Vector512<T> NaN;
        /// <summary>Represents negative infinity (��ʾ������). When the type is an integer, the value is 0 (������Ϊ����ʱ����ֵΪ0).</summary>
        public static readonly Vector512<T> NegativeInfinity;
        /// <summary>Represents positive infinity (��ʾ������). When the type is an integer, the value is 0 (������Ϊ����ʱ����ֵΪ0).</summary>
        public static readonly Vector512<T> PositiveInfinity;
        // -- Math --
        /// <summary>Normalized number of value 1 (ֵ1�Ĺ�һ����). When the type is an integer, the value is'<see cref="ElementMaxValue"/>'; Otherwise it's 1 (������Ϊ����ʱ������ֵΪ `<see cref="ElementMaxValue"/>`; ���������Ϊ 1).</summary>
        public static readonly Vector512<T> NormOne;
        /// <summary>The fixed point number of the value 1 (ֵ1�Ķ�����). When the type is an integer, the value is'Pow(2, <see cref="ElementFixedShift"/>)'; Otherwise it's 1 (������Ϊ����ʱ������ֵΪ `Pow(2, <see cref="ElementFixedShift"/>)`; ���������Ϊ 1).</summary>
        public static readonly Vector512<T> FixedOne;
        /// <summary>Represents the natural logarithmic base, specified by the constant, e (��ʾ��Ȼ�����ĵף����ɳ��� e ָ��).</summary>
        public static readonly Vector512<T> E;
        /// <summary>Represents the ratio of the circumference of a circle to its diameter, specified by the constant, �� (��ʾԲ���ܳ�����ֱ���ı�ֵ���ɳ��� �� ָ��).</summary>
        public static readonly Vector512<T> Pi;
        /// <summary>Represents the number of radians in one turn, specified by the constant, �� (��ʾתһȦ�Ļ��������ɳ��� �� ָ��).</summary>
        public static readonly Vector512<T> Tau;
        // -- Positive number --
        /// <summary>Value 1 .</summary>
        public static readonly Vector512<T> V1;
        /// <summary>Value 2 .</summary>
        public static readonly Vector512<T> V2;
        /// <summary>Value 3 .</summary>
        public static readonly Vector512<T> V3;
        /// <summary>Value 4 .</summary>
        public static readonly Vector512<T> V4;
        /// <summary>Value 5 .</summary>
        public static readonly Vector512<T> V5;
        /// <summary>Value 6 .</summary>
        public static readonly Vector512<T> V6;
        /// <summary>Value 7 .</summary>
        public static readonly Vector512<T> V7;
        /// <summary>Value 8 .</summary>
        public static readonly Vector512<T> V8;
        /// <summary>Value 127 (SByte.MaxValue).</summary>
        public static readonly Vector512<T> VMaxSByte;
        /// <summary>Value 255 (Byte.MaxValue).</summary>
        public static readonly Vector512<T> VMaxByte;
        /// <summary>Value 32767 (Int16.MaxValue) .</summary>
        public static readonly Vector512<T> VMaxInt16;
        /// <summary>Value 65535 (UInt16.MaxValue) .</summary>
        public static readonly Vector512<T> VMaxUInt16;
        /// <summary>Value 2147483647 (Int32.MaxValue) .</summary>
        public static readonly Vector512<T> VMaxInt32;
        /// <summary>Value 4294967295 (UInt32.MaxValue) .</summary>
        public static readonly Vector512<T> VMaxUInt32;
        // -- Negative number --
        /// <summary>Value -1 . When the type is unsigned integer, the value is a signed cast value (������Ϊ�޷�������ʱ��ֵΪ������ǿ��ת��ֵ). Example: '(Byte)(-1)=255' .</summary>
        public static readonly Vector512<T> V_1;
        /// <summary>Value -2 .</summary>
        public static readonly Vector512<T> V_2;
        /// <summary>Value -3 .</summary>
        public static readonly Vector512<T> V_3;
        /// <summary>Value -4 .</summary>
        public static readonly Vector512<T> V_4;
        /// <summary>Value -5 .</summary>
        public static readonly Vector512<T> V_5;
        /// <summary>Value -6 .</summary>
        public static readonly Vector512<T> V_6;
        /// <summary>Value -7 .</summary>
        public static readonly Vector512<T> V_7;
        /// <summary>Value -8 .</summary>
        public static readonly Vector512<T> V_8;
        /// <summary>Value -128 (SByte.MinValue).</summary>
        public static readonly Vector512<T> VMinSByte;
        /// <summary>Value -32768 (Int16.MinValue) .</summary>
        public static readonly Vector512<T> VMinInt16;
        /// <summary>Value -2147483648 (Int32.MinValue) .</summary>
        public static readonly Vector512<T> VMinInt32;
        // -- Reciprocal number --
        /// <summary>Reciprocal value: 1/127 (SByte.MaxValue). When the type is an integer, it is a fixed point number using the <see cref="ElementFixedShift"/> convention (������Ϊ����ʱ, ��ʹ�� <see cref="ElementFixedShift"/> Լ���Ķ�����).</summary>
        public static readonly Vector512<T> VReciprocalMaxSByte;
        /// <summary>Reciprocal value: 1/255 (Byte.MaxValue). When the type is an integer, it is a fixed point number using the <see cref="ElementFixedShift"/> convention (������Ϊ����ʱ, ��ʹ�� <see cref="ElementFixedShift"/> Լ���Ķ�����).</summary>
        public static readonly Vector512<T> VReciprocalMaxByte;
        /// <summary>Reciprocal value: 1/32767 (Int16.MaxValue). When the type is an integer, it is a fixed point number using the <see cref="ElementFixedShift"/> convention (������Ϊ����ʱ, ��ʹ�� <see cref="ElementFixedShift"/> Լ���Ķ�����).</summary>
        public static readonly Vector512<T> VReciprocalMaxInt16;
        /// <summary>Reciprocal value: 1/65535 (UInt16.MaxValue). When the type is an integer, it is a fixed point number using the <see cref="ElementFixedShift"/> convention (������Ϊ����ʱ, ��ʹ�� <see cref="ElementFixedShift"/> Լ���Ķ�����).</summary>
        public static readonly Vector512<T> VReciprocalMaxUInt16;
        /// <summary>Reciprocal value: 1/2147483647 (Int32.MaxValue). When the type is an integer, it is a fixed point number using the <see cref="ElementFixedShift"/> convention (������Ϊ����ʱ, ��ʹ�� <see cref="ElementFixedShift"/> Լ���Ķ�����).</summary>
        public static readonly Vector512<T> VReciprocalMaxInt32;
        /// <summary>Reciprocal value: 1/4294967295 (UInt32.MaxValue). When the type is an integer, it is a fixed point number using the <see cref="ElementFixedShift"/> convention (������Ϊ����ʱ, ��ʹ�� <see cref="ElementFixedShift"/> Լ���Ķ�����).</summary>
        public static readonly Vector512<T> VReciprocalMaxUInt32;
        // -- Specified value --
        /// <summary>Serial Value (˳��ֵ). e.g. 0, 1, 2, 3 ...</summary>
        public static readonly Vector512<T> Serial;
        /// <summary>Serial Value descend (˳��ֵ����). e.g. (Count-1), (Count-2), ... 2, 1, 0</summary>
        public static readonly Vector512<T> SerialDesc;
        /// <summary>Negative serial Value (����˳��ֵ). e.g. 0, -1, -2, -3 ...</summary>
        public static readonly Vector512<T> SerialNegative;
        /// <summary>Demo Value (��ʾֵ). It is a value constructed for testing purposes (����Ϊ����Ŀ�Ķ������ֵ).</summary>
        public static readonly Vector512<T> Demo;
        /// <summary>Serial bit pos mask (˳��λƫ�Ƶ�����). The element whose index exceeds the number of bits has a value of 0(��������λ����Ԫ��ֵΪ0). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        public static readonly Vector512<T> MaskBitPosSerial;
        /// <summary>Serial bit pos rotate mask (˳��λƫ�Ƶ���ת����). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        public static readonly Vector512<T> MaskBitPosSerialRotate;
        /// <summary>Serial bits mask (˳��λ��������). The element whose index exceeds the number of bits has a value of all bit set 1(��������λ����Ԫ��ֵΪ����λ����1��ֵ). e.g. 1, 3, 7, 0xF, 0x1F ...</summary>
        public static readonly Vector512<T> MaskBitsSerial;
        /// <summary>Serial bits rotate mask (˳��λ������ת����). e.g. 1, 3, 7, 0xF, 0x1F ...</summary>
        public static readonly Vector512<T> MaskBitsSerialRotate;
        /// <summary>Interlaced sign number (����ķ�����ֵ). e.g. 1, -1, 1, -1, 1, -1 ...</summary>
        public static readonly Vector512<T> InterlacedSign;
        /// <summary>Interlaced sign number starting with a negative number (������ͷ�Ľ���ķ�����ֵ). e.g. -1, 1, -1, 1, -1, 1 ...</summary>
        public static readonly Vector512<T> InterlacedSignNegative;
        // -- Xyzw --
        /// <summary>Xy - X mask. For a 2-element group, select the mask of the 0th element (����2��Ԫ�ص��飬ѡ���0��Ԫ�ص�����).</summary>
        public static readonly Vector512<T> XyXMask;
        /// <summary>Xy - Y mask. For a 2-element group, select the mask of the 1st element (����2��Ԫ�ص��飬ѡ���1��Ԫ�ص�����).</summary>
        public static readonly Vector512<T> XyYMask;
        /// <summary>Xyzw - X mask. For a 4-element group, select the mask of the 0th element (����4��Ԫ�ص��飬ѡ���0��Ԫ�ص�����). Alias has <see cref="RgbaRMask"/>.</summary>
        public static readonly Vector512<T> XyzwXMask;
        /// <summary>Xyzw - Y mask. For a 4-element group, select the mask of the 1th element (����4��Ԫ�ص��飬ѡ���1��Ԫ�ص�����). Alias has <see cref="RgbaGMask"/>.</summary>
        public static readonly Vector512<T> XyzwYMask;
        /// <summary>Xyzw - Z mask. For a 4-element group, select the mask of the 2th element (����4��Ԫ�ص��飬ѡ���2��Ԫ�ص�����). Alias has <see cref="RgbaBMask"/>.</summary>
        public static readonly Vector512<T> XyzwZMask;
        /// <summary>Xyzw - W mask. For a 4-element group, select the mask of the 3th element (����4��Ԫ�ص��飬ѡ���3��Ԫ�ص�����). Alias has <see cref="RgbaAMask"/>.</summary>
        public static readonly Vector512<T> XyzwWMask;
        /// <summary>Xyzw - Not X mask. For a 4-element group, not select the mask of the 0th element (����4��Ԫ�ص��飬��ѡ���0��Ԫ�ص�����). Alias has <see cref="RgbaNotRMask"/>.</summary>
        public static readonly Vector512<T> XyzwNotXMask;
        /// <summary>Xyzw - Not Y mask. For a 4-element group, not select the mask of the 1th element (����4��Ԫ�ص��飬��ѡ���1��Ԫ�ص�����). Alias has <see cref="RgbaNotGMask"/>.</summary>
        public static readonly Vector512<T> XyzwNotYMask;
        /// <summary>Xyzw - Not Z mask. For a 4-element group, not select the mask of the 2th element (����4��Ԫ�ص��飬��ѡ���2��Ԫ�ص�����). Alias has <see cref="RgbaNotBMask"/>.</summary>
        public static readonly Vector512<T> XyzwNotZMask;
        /// <summary>Xyzw - Not W mask. For a 4-element group, not select the mask of the 3th element (����4��Ԫ�ص��飬��ѡ���3��Ԫ�ص�����). Alias has <see cref="RgbaNotAMask"/>.</summary>
        public static readonly Vector512<T> XyzwNotWMask;
        /// <summary>Xyzw - X is normalized number of value 1 (X Ϊֵ1�Ĺ�һ����).</summary>
        public static readonly Vector512<T> XyzwXNormOne;
        /// <summary>Xyzw - Y is normalized number of value 1 (Y Ϊֵ1�Ĺ�һ����).</summary>
        public static readonly Vector512<T> XyzwYNormOne;
        /// <summary>Xyzw - Z is normalized number of value 1 (Z Ϊֵ1�Ĺ�һ����).</summary>
        public static readonly Vector512<T> XyzwZNormOne;
        /// <summary>Xyzw - W is normalized number of value 1 (W Ϊֵ1�Ĺ�һ����).</summary>
        public static readonly Vector512<T> XyzwWNormOne;
        // == Mask array ==
        /// <summary>Bit pos mask array (λƫ�����������). e.g. 1, 2, 4, 8, 0x10 ...</summary>
        private static readonly Vector512<Byte>[] MaskBitPosArray;
        /// <summary>Bits mask array (λ�����������). e.g. 0, 1, 3, 7, 0xF, 0x1F ...</summary>
        private static readonly Vector512<Byte>[] MaskBitsArray;

        /// <summary>
        /// Static constructor.
        /// </summary>
        static Vector512s() {
            V0 = Vector512s.Create<T>(ElementV0);
            AllBitsSet = Vector512s.Create<T>(ElementAllBitsSet);
            // -- Number struct --
            SignMask = Vector512s.Create<T>(ElementSignMask);
            ExponentMask = Vector512s.Create<T>(ElementExponentMask);
            MantissaMask = Vector512s.Create<T>(ElementMantissaMask);
            NonSignMask = Vector512s.Create<T>(ElementNonSignMask);
            NonExponentMask = Vector512s.Create<T>(ElementNonExponentMask);
            NonMantissaMask = Vector512s.Create<T>(ElementNonMantissaMask);
            Epsilon = Vector512s.Create<T>(ElementEpsilon);
            MaxValue = Vector512s.Create<T>(ElementMaxValue);
            MinValue = Vector512s.Create<T>(ElementMinValue);
            NaN = Vector512s.Create<T>(ElementNaN);
            NegativeInfinity = Vector512s.Create<T>(ElementNegativeInfinity);
            PositiveInfinity = Vector512s.Create<T>(ElementPositiveInfinity);
            // -- Math --
            NormOne = Vector512s.Create<T>(ElementNormOne);
            FixedOne = Vector512s.Create<T>(ElementFixedOne);
            E = Vector512s.Create<T>(ElementE);
            Pi = Vector512s.Create<T>(ElementPi);
            Tau = Vector512s.Create<T>(ElementTau);
            // -- Positive number --
            V1 = Vector512s.Create<T>(ElementV1);
            V2 = Vector512s.Create<T>(ElementV2);
            V3 = Vector512s.Create<T>(ElementV3);
            V4 = Vector512s.Create<T>(ElementV4);
            V5 = Vector512s.Create<T>(ElementV5);
            V6 = Vector512s.Create<T>(ElementV6);
            V7 = Vector512s.Create<T>(ElementV7);
            V8 = Vector512s.Create<T>(ElementV8);
            VMaxSByte = Vector512s.Create<T>(ElementVMaxSByte);
            VMaxByte = Vector512s.Create<T>(ElementVMaxByte);
            VMaxInt16 = Vector512s.Create<T>(ElementVMaxInt16);
            VMaxUInt16 = Vector512s.Create<T>(ElementVMaxUInt16);
            VMaxInt32 = Vector512s.Create<T>(ElementVMaxInt32);
            VMaxUInt32 = Vector512s.Create<T>(ElementVMaxUInt32);
            // -- Negative number  --
            V_1 = Vector512s.Create<T>(ElementV_1);
            V_2 = Vector512s.Create<T>(ElementV_2);
            V_3 = Vector512s.Create<T>(ElementV_3);
            V_4 = Vector512s.Create<T>(ElementV_4);
            V_5 = Vector512s.Create<T>(ElementV_5);
            V_6 = Vector512s.Create<T>(ElementV_6);
            V_7 = Vector512s.Create<T>(ElementV_7);
            V_8 = Vector512s.Create<T>(ElementV_8);
            VMinSByte = Vector512s.Create<T>(ElementVMinSByte);
            VMinInt16 = Vector512s.Create<T>(ElementVMinInt16);
            VMinInt32 = Vector512s.Create<T>(ElementVMinInt32);
            // -- Reciprocal number  --
            VReciprocalMaxSByte = Vector512s.Create<T>(ElementVReciprocalMaxSByte);
            VReciprocalMaxByte = Vector512s.Create<T>(ElementVReciprocalMaxByte);
            VReciprocalMaxInt16 = Vector512s.Create<T>(ElementVReciprocalMaxInt16);
            VReciprocalMaxUInt16 = Vector512s.Create<T>(ElementVReciprocalMaxUInt16);
            VReciprocalMaxInt32 = Vector512s.Create<T>(ElementVReciprocalMaxInt32);
            VReciprocalMaxUInt32 = Vector512s.Create<T>(ElementVReciprocalMaxUInt32);
            // -- Specified value --
            Serial = Vector512s.CreateByDoubleLoop<T>(0, 1);
            SerialDesc = Vector512s.CreateByDoubleLoop<T>(Vector512<T>.Count - 1, -1);
            SerialNegative = Vector512s.CreateByDoubleLoop<T>(0, -1);
            Demo = Vector512s.CreateByFunc<T>(Vectors.GenerateDemoElement<T>);
            int bitLen = ElementByteSize * 8;
            MaskBitPosSerial = Vector512s.CreateByFunc<T>(delegate (int index) {
                long n = 0;
                if (index < bitLen) {
                    n = 1L << index;
                }
                return Scalars.GetByBits<T>(n);
            });
            MaskBitPosSerialRotate = Vector512s.CreateByFunc<T>(delegate (int index) {
                int m = index % bitLen;
                long n = 1L << m;
                return Scalars.GetByBits<T>(n);
            });
            MaskBitsSerial = Vector512s.CreateByFunc<T>(delegate (int index) {
                int m = Math.Min(index + 1, bitLen);
                return Scalars.GetBitsMask<T>(0, m);
            });
            MaskBitsSerialRotate = Vector512s.CreateByFunc<T>(delegate (int index) {
                int m = index % bitLen + 1;
                return Scalars.GetBitsMask<T>(0, m);
            });
            InterlacedSign = Vector512s.CreateRotate<T>(ElementV1, ElementV_1);
            InterlacedSignNegative = Vector512s.CreateRotate<T>(ElementV_1, ElementV1);
            // -- Xyzw --
            if (true) {
                T o = ElementZero;
                T f = ElementAllBitsSet;
                T n = ElementNormOne;
                XyXMask = Vector512s.CreateRotate<T>(f, o);
                XyYMask = Vector512s.CreateRotate<T>(o, f);
                XyzwXMask = Vector512s.CreateRotate<T>(f, o, o, o);
                XyzwYMask = Vector512s.CreateRotate<T>(o, f, o, o);
                XyzwZMask = Vector512s.CreateRotate<T>(o, o, f, o);
                XyzwWMask = Vector512s.CreateRotate<T>(o, o, o, f);
                XyzwNotXMask = Vector512s.BaseOnesComplement(XyzwXMask);
                XyzwNotYMask = Vector512s.BaseOnesComplement(XyzwYMask);
                XyzwNotZMask = Vector512s.BaseOnesComplement(XyzwZMask);
                XyzwNotWMask = Vector512s.BaseOnesComplement(XyzwWMask);
                XyzwXNormOne = Vector512s.CreateRotate<T>(n, o, o, o);
                XyzwYNormOne = Vector512s.CreateRotate<T>(o, n, o, o);
                XyzwZNormOne = Vector512s.CreateRotate<T>(o, o, n, o);
                XyzwWNormOne = Vector512s.CreateRotate<T>(o, o, o, n);
            }
            // == Mask array ==
            MaskBitPosArray = Vector512s.GetMaskBitPosArray(ElementByteSize);
            MaskBitsArray = Vector512s.GetMaskBitsArray(ElementByteSize);
        }

        /// <summary>
        /// Get bit pos mask by index (����������ȡλƫ������). The equivalent of <c>Vector512s.Create(Scalars.GetByBits&lt;T&gt;(1L &lt;&lt; index))</c>.
        /// </summary>
        /// <param name="index">The index (����). The value ranges from 0 to <c>ElementBitSize-1</c> (ֵ�ķ�Χ�� 0 ~ <c>ElementBitSize-1</c>). Ϊ������, ������������Χ���, ��������ȷ������ֵ�ڷ�Χ�� (For performance purposes, this function does not do range checking; the caller should ensure that its value is within the range).</param>
        /// <returns>Returns bit pos mask (����λƫ������).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly Vector512<T> GetMaskBitPos(int index) {
            return ref Unsafe.As<Vector512<Byte>, Vector512<T>>(ref MaskBitPosArray[index]);
        }

        /// <summary>
        /// Get bit pos mask span (��ȡλƫ������Ŀ��). Tip: You can use <see cref="Unsafe.As"/> convert its item to <see cref="Vector512{T}"/> type (��ʾ: ������ <see cref="Unsafe.As"/> ��������ĿתΪ <see cref="Vector512{T}"/> ����).
        /// </summary>
        /// <returns>Returns bit pos mask span (����λƫ������Ŀ��).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<Vector512<Byte>> GetMaskBitPosSpan() {
            return new ReadOnlySpan<Vector512<Byte>>(MaskBitPosArray);
        }

        /// <summary>
        /// Get bits mask by index (����������ȡλ������). The equivalent of <c>Vector512s.Create(Scalars.GetBitsMask&lt;T&gt;(0, index))</c>.
        /// </summary>
        /// <param name="index">The index (����). The value ranges from 0 to <c>ElementBitSize</c> (ֵ�ķ�Χ�� 0 ~ <c>ElementBitSize</c>). Ϊ������, ������������Χ���, ��������ȷ������ֵ�ڷ�Χ�� (For performance purposes, this function does not do range checking; the caller should ensure that its value is within the range).</param>
        /// <returns>Returns bits mask mask (����λ������).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly Vector512<T> GetMaskBits(int index) {
            return ref Unsafe.As<Vector512<Byte>, Vector512<T>>(ref MaskBitsArray[index]);
        }

        /// <summary>
        /// Get bits mask span (��ȡλ������Ŀ��). Tip: You can use <see cref="Unsafe.As"/> convert its item to <see cref="Vector512{T}"/> type (��ʾ: ������ <see cref="Unsafe.As"/> ��������ĿתΪ <see cref="Vector512{T}"/> ����).
        /// </summary>
        /// <returns>Returns bits mask span (����λ������Ŀ��).</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<Vector512<Byte>> GetMaskBitsSpan() {
            return new ReadOnlySpan<Vector512<Byte>>(MaskBitsArray);
        }


        /// <summary>Zero (0).</summary>
        public static Vector512<T> Zero { get { return V0; } }

        /// <summary>1 bits mask (1λ����).</summary>
        public static ref readonly Vector512<T> MaskBits1 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref GetMaskBits(1); } }
        /// <summary>2 bits mask (2λ����).</summary>
        public static ref readonly Vector512<T> MaskBits2 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref GetMaskBits(2); } }
        /// <summary>4 bits mask (4λ����).</summary>
        public static ref readonly Vector512<T> MaskBits4 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref GetMaskBits(4); } }
        /// <summary>8 bits mask (8λ����).</summary>
        public static ref readonly Vector512<T> MaskBits8 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref GetMaskBits(8); } }
        /// <summary>16 bits mask (16λ����).</summary>
        public static ref readonly Vector512<T> MaskBits16 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref GetMaskBits(Math.Min(ElementBitSize, 16)); } }
        /// <summary>32 bits mask (32λ����).</summary>
        public static ref readonly Vector512<T> MaskBits32 { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref GetMaskBits(Math.Min(ElementBitSize, 32)); } }

        /// <summary>Xy - Not X mask. For a 2-element group, not select the mask of the 0th element (����2��Ԫ�ص��飬��ѡ���0��Ԫ�ص�����).</summary>
        public static ref readonly Vector512<T> XyNotXMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyYMask; } }
        /// <summary>Xy - Not Y mask. For a 2-element group, not select the mask of the 1st element (����2��Ԫ�ص��飬��ѡ���1��Ԫ�ص�����).</summary>
        public static ref readonly Vector512<T> XyNotYMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyXMask; } }
        /// <summary>Rgba - R mask. For a 4-element group, select the mask of the 0th element (����4��Ԫ�ص��飬ѡ���0��Ԫ�ص�����). Alias has <see cref="XyzwXMask"/>.</summary>
        public static ref readonly Vector512<T> RgbaRMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwXMask; } }
        /// <summary>Rgba - G mask. For a 4-element group, select the mask of the 1th element (����4��Ԫ�ص��飬ѡ���1��Ԫ�ص�����). Alias has <see cref="XyzwYMask"/>.</summary>
        public static ref readonly Vector512<T> RgbaGMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwYMask; } }
        /// <summary>Rgba - B mask. For a 4-element group, select the mask of the 2th element (����4��Ԫ�ص��飬ѡ���2��Ԫ�ص�����). Alias has <see cref="XyzwZMask"/>.</summary>
        public static ref readonly Vector512<T> RgbaBMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwZMask; } }
        /// <summary>Rgba - A mask. For a 4-element group, select the mask of the 3th element (����4��Ԫ�ص��飬ѡ���3��Ԫ�ص�����). Alias has <see cref="XyzwWMask"/>.</summary>
        public static ref readonly Vector512<T> RgbaAMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwWMask; } }
        /// <summary>Rgba - Not R mask. For a 4-element group, not select the mask of the 0th element (����4��Ԫ�ص��飬��ѡ���0��Ԫ�ص�����). Alias has <see cref="XyzwNotXMask"/>.</summary>
        public static ref readonly Vector512<T> RgbaNotRMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwNotXMask; } }
        /// <summary>Rgba - Not G mask. For a 4-element group, not select the mask of the 1th element (����4��Ԫ�ص��飬��ѡ���1��Ԫ�ص�����). Alias has <see cref="XyzwNotYMask"/>.</summary>
        public static ref readonly Vector512<T> RgbaNotGMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwNotYMask; } }
        /// <summary>Rgba - Not B mask. For a 4-element group, not select the mask of the 2th element (����4��Ԫ�ص��飬��ѡ���2��Ԫ�ص�����). Alias has <see cref="XyzwNotZMask"/>.</summary>
        public static ref readonly Vector512<T> RgbaNotBMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwNotZMask; } }
        /// <summary>Rgba - Not A mask. For a 4-element group, not select the mask of the 3th element (����4��Ԫ�ص��飬��ѡ���3��Ԫ�ص�����). Alias has <see cref="XyzwNotWMask"/>.</summary>
        public static ref readonly Vector512<T> RgbaNotAMask { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwNotWMask; } }
        /// <summary>Rgba - R is normalized number of value 1 (R Ϊֵ1�Ĺ�һ����).</summary>
        public static ref readonly Vector512<T> RgbaRNormOne { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwXNormOne; } }
        /// <summary>Rgba - G is normalized number of value 1 (G Ϊֵ1�Ĺ�һ����).</summary>
        public static ref readonly Vector512<T> RgbaGNormOne { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwYNormOne; } }
        /// <summary>Rgba - B is normalized number of value 1 (B Ϊֵ1�Ĺ�һ����).</summary>
        public static ref readonly Vector512<T> RgbaBNormOne { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwZNormOne; } }
        /// <summary>Rgba - A is normalized number of value 1 (A Ϊֵ1�Ĺ�һ����).</summary>
        public static ref readonly Vector512<T> RgbaANormOne { [MethodImpl(MethodImplOptions.AggressiveInlining)] get { return ref XyzwWNormOne; } }

#endif
    }
}
