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


    }
}
