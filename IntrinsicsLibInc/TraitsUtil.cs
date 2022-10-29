using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif
using System.Text;

[assembly: CLSCompliant(true)]

namespace IntrinsicsLib {
    /// <summary>
    /// Traits misc util.
    /// </summary>
    public static class TraitsUtil {

        // == Array ==
        /// <summary>
        /// Assigns the given value of type T to each element of the specified array.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to be filled.</param>
        /// <param name="value">The value to assign to each array element.</param>
        /// <see cref="Array.Fill{T}(T[], T)"/>
        public static void Fill<T>(T[] array, T value) {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            Array.Fill(array, value);
#else
            Fill(array, value, 0, array.Length);
#endif
        }

        /// <summary>
        /// Assigns the given value of type T to the elements of the specified array which are within the range of startIndex (inclusive) and the next count number of indices.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The System.Array to be filled.</param>
        /// <param name="value">The new value for the elements in the specified range.</param>
        /// <param name="startIndex">A 32-bit integer that represents the index in the System.Array at which filling begins.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <see cref="Array.Fill{T}(T[], T, int, int)"/>
        public static void Fill<T>(T[] array, T value, int startIndex, int count) {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            Array.Fill(array, value, startIndex, count);
#else
            for(int i=0, p=startIndex; i<count; ++i, ++p) {
                array[p] = value;
            }
#endif
        }

        // == Unsafe ==

        /// <summary>
        /// Reinterprets the given reference as a reference to a value of type <typeparamref name="TTo"/>.
        /// </summary>
        /// <typeparam name="TFrom">The type of reference to reinterpret.</typeparam>
        /// <typeparam name="TTo">The desired type of the reference.</typeparam>
        /// <param name="source">The reference to reinterpret.</param>
        /// <returns>A reference to a value of type <typeparamref name="TTo"/>.</returns>
        /// <seealso cref="Unsafe.As{TFrom, TTo}(ref TFrom)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref TTo As<TFrom, TTo>(ref TFrom source) {
            return ref Unsafe.As<TFrom, TTo>(ref source);
        }

        /// <summary>
        /// Writes a value of type <typeparamref name="T"/> to the given location without assuming architecture dependent alignment of the addresses.
        /// </summary>
        /// <typeparam name="T">The type of value to write.</typeparam>
        /// <param name="destination">The location to write to.</param>
        /// <param name="value">The value to write.</param>
        /// <seealso cref="Unsafe.WriteUnaligned{T}(ref byte, T)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteUnaligned<T>(ref byte destination, T value) {
            Unsafe.WriteUnaligned<T>(ref destination, value);
        }

        // == MemoryMarshal ==

        /// <summary>
        /// Returns a reference to the element of the read-only span at index 0.
        /// </summary>
        /// <typeparam name="T">The type of items in the span.</typeparam>
        /// <param name="span">The read-only span from which the reference is retrieved.</param>
        /// <returns>A reference to the element at index 0.</returns>
        public static ref readonly T GetReference<T>(ReadOnlySpan<T> span) {
            return ref span.GetPinnableReference();
        }

        /// <summary>
        /// Returns a reference to the element of the span at index 0.
        /// </summary>
        /// <typeparam name="T">The type of items in the span.</typeparam>
        /// <param name="span">The span from which the reference is retrieved.</param>
        /// <returns>A reference to the element at index 0.</returns>
        public static ref T GetReference<T>(Span<T> span) {
            return ref span.GetPinnableReference();
        }

        // == Vector as ==

#if NETCOREAPP3_0_OR_GREATER
        ///// <summary>
        ///// Reinterprets a <see cref="Vector64{T}"/> as a new <see cref="Vector{T}"/>.
        ///// </summary>
        ///// <typeparam name="T">The type of the vectors.</typeparam>
        ///// <param name="value">The vector to reinterpret.</param>
        ///// <returns>value reinterpreted as a new <see cref="Vector{T}"/>.</returns>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Vector<T> AsVector<T>(Vector64<T> value) where T : struct {
        //    return As<Vector64<T>, Vector<T>>(ref value);
        //}

        /// <summary>
        /// Reinterprets a <see cref="Vector128{T}"/> as a new <see cref="Vector{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the vectors.</typeparam>
        /// <param name="value">The vector to reinterpret.</param>
        /// <returns>value reinterpreted as a new <see cref="Vector{T}"/>.</returns>
        /// <seealso cref="Vector128.AsVector{T}(Vector128{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> AsVector<T>(Vector128<T> value) where T : struct {
            return As<Vector128<T>, Vector<T>>(ref value);
        }

        /// <summary>
        /// Reinterprets a <see cref="Vector256{T}"/> as a new <see cref="Vector{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the vectors.</typeparam>
        /// <param name="value">The vector to reinterpret.</param>
        /// <returns>value reinterpreted as a new <see cref="Vector{T}"/>.</returns>
        /// <seealso cref="Vector256.AsVector{T}(Vector256{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> AsVector<T>(Vector256<T> value) where T : struct {
            //ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
            //return Unsafe.As<Vector256<T>, Vector<T>>(ref value);
            return As<Vector256<T>, Vector<T>>(ref value);
        }

        ///// <summary>
        ///// Reinterprets a <see cref="Vector{T}"/> as a new <see cref="Vector64{T}"/>.
        ///// </summary>
        ///// <typeparam name="T">The type of the vectors.</typeparam>
        ///// <param name="value">The vector to reinterpret.</param>
        ///// <returns>value reinterpreted as a new <see cref="Vector64{T}"/>.</returns>
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Vector64<T> AsVector64<T>(Vector<T> value) where T : struct {
        //    Vector64<T> source = default(Vector64<T>);
        //    WriteUnaligned(ref Unsafe.As<Vector64<T>, byte>(ref source), value);
        //    return source;
        //}

        /// <summary>
        /// Reinterprets a <see cref="Vector{T}"/> as a new <see cref="Vector128{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the vectors.</typeparam>
        /// <param name="value">The vector to reinterpret.</param>
        /// <returns>value reinterpreted as a new <see cref="Vector128{T}"/>.</returns>
        /// <seealso cref="Vector128.AsVector128{T}(Vector{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector128<T> AsVector128<T>(Vector<T> value) where T : struct {
            Vector128<T> source = default(Vector128<T>);
            WriteUnaligned(ref Unsafe.As<Vector128<T>, byte>(ref source), value);
            return source;
        }

        /// <summary>
        /// Reinterprets a <see cref="Vector{T}"/> as a new <see cref="Vector256{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the vectors.</typeparam>
        /// <param name="value">The vector to reinterpret.</param>
        /// <returns>value reinterpreted as a new <see cref="Vector256{T}"/>.</returns>
        /// <seealso cref="Vector256.AsVector256{T}(Vector{T})"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> AsVector256<T>(Vector<T> value) where T : struct {
            //ThrowHelper.ThrowForUnsupportedVectorBaseType<T>();
            Vector256<T> source = default(Vector256<T>);
            //Unsafe.WriteUnaligned(ref Unsafe.As<Vector256<T>, byte>(ref source), value);
            WriteUnaligned(ref Unsafe.As<Vector256<T>, byte>(ref source), value);
            return source;
        }

        /// <summary>
        /// Reinterprets a <see cref="Vector{T}"/> as a new <see cref="Vector256{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the vectors.</typeparam>
        /// <param name="value">The vector to reinterpret.</param>
        /// <returns>value reinterpreted as a new <see cref="Vector256{T}"/>.</returns>
        [Obsolete("Same AsVector256.")]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector256<T> AsVector256A<T>(Vector<T> value) where T : struct {
            return Unsafe.As<Vector<T>, Vector256<T>>(ref value);
        }
#endif

        // == MemoryMarshal ==
        // new Span: Error	CS1615	Argument 1 may not be passed with the 'ref' keyword
        //
        // /// <summary>
        // /// System.ThrowHelper.
        // /// </summary>
        // internal static class ThrowHelper {
        //     // ThrowHelper.ThrowInvalidTypeWithPointersNotSupported(typeof(TFrom));
        //     internal static void ThrowInvalidTypeWithPointersNotSupported(Type targetType) {
        //         //throw new ArgumentException(SR.Format(SR.Argument_InvalidTypeWithPointersNotSupported, targetType));
        //         string msg = string.Format("Invalid type({0}) with pointers not supported", targetType.FullName);
        //         throw new ArgumentException(msg);
        //     }
        // }
        // 
        // /// <summary>
        // /// Casts a span of one primitive type to a span of another primitive type.
        // /// </summary>
        // /// <typeparam name="TFrom">The type of the source span.</typeparam>
        // /// <typeparam name="TTo">The type of the target span.</typeparam>
        // /// <param name="span">The source slice to convert.</param>
        // /// <returns>The converted span.</returns>
        // /// <exception cref="ArgumentException">TFrom or TTo contains references or pointers.</exception>
        // /// <seealso cref="MemoryMarshal.Cast"/>
        // [MethodImpl(MethodImplOptions.AggressiveInlining)]
        // public static Span<TTo> Cast<TFrom, TTo>(Span<TFrom> span)
        //         where TFrom : struct
        //         where TTo : struct {
        //     if (RuntimeHelpers.IsReferenceOrContainsReferences<TFrom>()) {
        //         ThrowHelper.ThrowInvalidTypeWithPointersNotSupported(typeof(TFrom));
        //     }
        //     if (RuntimeHelpers.IsReferenceOrContainsReferences<TTo>()) {
        //         ThrowHelper.ThrowInvalidTypeWithPointersNotSupported(typeof(TTo));
        //     }
        //     uint num = (uint)Unsafe.SizeOf<TFrom>();
        //     uint num2 = (uint)Unsafe.SizeOf<TTo>();
        //     uint length = (uint)span.Length;
        //     int length2;
        //     if (num == num2) {
        //         length2 = (int)length;
        //     } else if (num == 1) {
        //         length2 = (int)(length / num2);
        //     } else {
        //         ulong num3 = (ulong)((long)length * (long)num) / (ulong)num2;
        //         length2 = checked((int)num3);
        //     }
        //     //return new Span<TTo>(ref Unsafe.As<TFrom, TTo>(ref span._pointer.Value), length2);
        //     ref TFrom refFrome = ref span.GetPinnableReference();
        //     return new Span<TTo>(ref Unsafe.As<TFrom, TTo>(ref refFrome), length2); // new Span: Error	CS1615	Argument 1 may not be passed with the 'ref' keyword
        //     // internal Span(ref T ptr, int length)
        // }


    }
}
