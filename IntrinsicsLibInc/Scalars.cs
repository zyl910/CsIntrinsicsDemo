using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace IntrinsicsLib {
    /// <summary>
    /// Methods of scalar - number type.
    /// </summary>
    public static class Scalars {

        /// <summary>
        /// Converts a double to the target type value.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
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
        /// <typeparam name="T">Target type.</typeparam>
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
        /// Get bits mask.
        /// </summary>
        /// <typeparam name="T">Target type.</typeparam>
        /// <param name="start">Bits start.</param>
        /// <param name="len">Bits length.</param>
        /// <returns>Returns mask.</returns>
        public static T GetBitsMask<T>(int start, int len) {
            return GetByBits<T>(GetBitsMask64(start, len));
        }

    }

    /// <summary>
    /// Constants of scalar - number type.
    /// </summary>
    public static class Scalars<T> {
    }

}
