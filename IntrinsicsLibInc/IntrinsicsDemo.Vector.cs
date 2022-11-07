using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace IntrinsicsLib {
    partial class IntrinsicsDemo {

        /// <summary>
        /// Run vector start.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunVectorStart(TextWriter tw, string indent) {
            try {
                RunVector(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunVector fail! " + ex.ToString());
            }
            try {
                RunVector64(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunVector64 fail! " + ex.ToString());
            }
            try {
                RunVector128(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunVector128 fail! " + ex.ToString());
            }
            try {
                RunVector256(tw, indent);
            } catch (Exception ex) {
                tw.WriteLine("RunVector256 fail! " + ex.ToString());
            }
        }

        /// <summary>
        /// Run Vector. https://learn.microsoft.com/zh-cn/dotnet/api/system.numerics.vector?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            //bool isAllow = Vector.IsHardwareAccelerated;
            bool isAllow = true;
            if (isAllow) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("-- Vector.IsSupported:\t{0}", Vector.IsHardwareAccelerated));
            if (!isAllow) {
                return;
            }

            // Count.
            tw.WriteLine(indent + string.Format("Vector<float>.Count:\t{0}", Vector<float>.Count));
            tw.WriteLine(indent + string.Format("Vector<double>.Count:\t{0}", Vector<double>.Count));
            tw.WriteLine(indent + string.Format("Vector<sbyte>.Count:\t{0}", Vector<sbyte>.Count));
            tw.WriteLine(indent + string.Format("Vector<byte>.Count:\t{0}", Vector<byte>.Count));
            tw.WriteLine(indent + string.Format("Vector<short>.Count:\t{0}", Vector<short>.Count));
            tw.WriteLine(indent + string.Format("Vector<ushort>.Count:\t{0}", Vector<ushort>.Count));
            tw.WriteLine(indent + string.Format("Vector<int>.Count:\t{0}", Vector<int>.Count));
            tw.WriteLine(indent + string.Format("Vector<uint>.Count:\t{0}", Vector<uint>.Count));
            tw.WriteLine(indent + string.Format("Vector<long>.Count:\t{0}", Vector<long>.Count));
            tw.WriteLine(indent + string.Format("Vector<ulong>.Count:\t{0}", Vector<ulong>.Count));
#if NET6_0_OR_GREATER
            tw.WriteLine(indent + string.Format("Vector<nint>.Count:\t{0}", Vector<nint>.Count));
            tw.WriteLine(indent + string.Format("Vector<nuint>.Count:\t{0}", Vector<nuint>.Count));
            // Unhandled exception. System.NotSupportedException: Specified type is not supported
            //tw.WriteLine(indent + string.Format("Vector<Half>.Count:\t{0}", Vector<Half>.Count));
#endif // NET6_0_OR_GREATER

            // -- Methods --
            #region Methods
            unchecked {
                //Debugger.Break();
                //Abs<T>(Vector<T>) Returns a new vector whose elements are the absolute values of the given vector's elements.
                WriteLine(tw, indent, "Abs(Vectors<float>.Demo):\t{0}", Vector.Abs(Vectors<float>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<double>.Demo):\t{0}", Vector.Abs(Vectors<double>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<sbyte>.Demo):\t{0}", Vector.Abs(Vectors<sbyte>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<byte>.Demo):\t{0}", Vector.Abs(Vectors<byte>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<short>.Demo):\t{0}", Vector.Abs(Vectors<short>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<ushort>.Demo):\t{0}", Vector.Abs(Vectors<ushort>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<int>.Demo):\t{0}", Vector.Abs(Vectors<int>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<uint>.Demo):\t{0}", Vector.Abs(Vectors<uint>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<long>.Demo):\t{0}", Vector.Abs(Vectors<long>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<ulong>.Demo):\t{0}", Vector.Abs(Vectors<ulong>.Demo));

                //Add<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the sum of each pair of elements from two given vectors.
                WriteLine(tw, indent, "Add(Vectors<float>.Demo, Vectors<float>.V1):\t{0}", Vector.Add(Vectors<float>.Demo, Vectors<float>.V1));
                WriteLine(tw, indent, "Add(Vectors<double>.Demo, Vectors<double>.V1):\t{0}", Vector.Add(Vectors<double>.Demo, Vectors<double>.V1));
                WriteLine(tw, indent, "Add(Vectors<sbyte>.Demo, Vectors<sbyte>.V1):\t{0}", Vector.Add(Vectors<sbyte>.Demo, Vectors<sbyte>.V1));
                WriteLine(tw, indent, "Add(Vectors<byte>.Demo, Vectors<byte>.V1):\t{0}", Vector.Add(Vectors<byte>.Demo, Vectors<byte>.V1));
                WriteLine(tw, indent, "Add(Vectors<short>.Demo, Vectors<short>.V1):\t{0}", Vector.Add(Vectors<short>.Demo, Vectors<short>.V1));
                WriteLine(tw, indent, "Add(Vectors<ushort>.Demo, Vectors<ushort>.V1):\t{0}", Vector.Add(Vectors<ushort>.Demo, Vectors<ushort>.V1));
                WriteLine(tw, indent, "Add(Vectors<int>.Demo, Vectors<int>.V1):\t{0}", Vector.Add(Vectors<int>.Demo, Vectors<int>.V1));
                WriteLine(tw, indent, "Add(Vectors<uint>.Demo, Vectors<uint>.V1):\t{0}", Vector.Add(Vectors<uint>.Demo, Vectors<uint>.V1));
                WriteLine(tw, indent, "Add(Vectors<long>.Demo, Vectors<long>.V1):\t{0}", Vector.Add(Vectors<long>.Demo, Vectors<long>.V1));
                WriteLine(tw, indent, "Add(Vectors<ulong>.Demo, Vectors<ulong>.V1):\t{0}", Vector.Add(Vectors<ulong>.Demo, Vectors<ulong>.V1));

                //AndNot<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise And Not operation on each pair of corresponding elements in two vectors.
                WriteLine(tw, indent, "AndNot(Vectors<float>.Demo, Vectors<float>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<float>.Demo, Vectors<float>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<double>.Demo, Vectors<double>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<double>.Demo, Vectors<double>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<sbyte>.Demo, Vectors<sbyte>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<sbyte>.Demo, Vectors<sbyte>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<byte>.Demo, Vectors<byte>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<byte>.Demo, Vectors<byte>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<short>.Demo, Vectors<short>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<short>.Demo, Vectors<short>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<ushort>.Demo, Vectors<ushort>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<ushort>.Demo, Vectors<ushort>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<int>.Demo, Vectors<int>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<int>.Demo, Vectors<int>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<uint>.Demo, Vectors<uint>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<uint>.Demo, Vectors<uint>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<long>.Demo, Vectors<long>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<long>.Demo, Vectors<long>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<ulong>.Demo, Vectors<ulong>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<ulong>.Demo, Vectors<ulong>.XyzwWMask));

                //As<TFrom, TTo>(Vector<TFrom>)    Reinterprets aVector64<T> as a new Vector64<T>.
                //AsVectorByte<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of unsigned bytes.
                //AsVectorDouble<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a double-precision floating-point vector.
                //AsVectorInt16<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of 16-bit integers.
                //AsVectorInt32<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of integers.
                //AsVectorInt64<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of long integers.
                //AsVectorNInt<T>(Vector<T>)  Reinterprets the bits of a specified vector into those of a vector of native-sized integers.
                //AsVectorNUInt<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of native-sized, unsigned integers.
                //AsVectorSByte<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of signed bytes.
                //AsVectorSingle<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a single-precision floating-point vector.
                //AsVectorUInt16<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a vector of unsigned 16-bit integers.
                //AsVectorUInt32<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a vector of unsigned integers.
                //AsVectorUInt64<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of unsigned long integers.
                // `As***` see below.

                //BitwiseAnd<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise Andoperation on each pair of elements in two vectors.
                WriteLine(tw, indent, "BitwiseAnd(Vectors<float>.Demo, Vectors<float>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<float>.Demo, Vectors<float>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<double>.Demo, Vectors<double>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<double>.Demo, Vectors<double>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<sbyte>.Demo, Vectors<sbyte>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<sbyte>.Demo, Vectors<sbyte>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<byte>.Demo, Vectors<byte>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<byte>.Demo, Vectors<byte>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<short>.Demo, Vectors<short>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<short>.Demo, Vectors<short>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<ushort>.Demo, Vectors<ushort>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<ushort>.Demo, Vectors<ushort>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<int>.Demo, Vectors<int>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<int>.Demo, Vectors<int>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<uint>.Demo, Vectors<uint>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<uint>.Demo, Vectors<uint>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<long>.Demo, Vectors<long>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<long>.Demo, Vectors<long>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<ulong>.Demo, Vectors<ulong>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<ulong>.Demo, Vectors<ulong>.XyzwWMask));

                //BitwiseOr<T>(Vector<T>, Vector<T>)  Returns a new vector by performing a bitwise Oroperation on each pair of elements in two vectors.
                WriteLine(tw, indent, "BitwiseOr(Vectors<float>.Demo, Vectors<float>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<float>.Demo, Vectors<float>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<double>.Demo, Vectors<double>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<double>.Demo, Vectors<double>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<sbyte>.Demo, Vectors<sbyte>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<sbyte>.Demo, Vectors<sbyte>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<byte>.Demo, Vectors<byte>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<byte>.Demo, Vectors<byte>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<short>.Demo, Vectors<short>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<short>.Demo, Vectors<short>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<ushort>.Demo, Vectors<ushort>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<ushort>.Demo, Vectors<ushort>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<int>.Demo, Vectors<int>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<int>.Demo, Vectors<int>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<uint>.Demo, Vectors<uint>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<uint>.Demo, Vectors<uint>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<long>.Demo, Vectors<long>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<long>.Demo, Vectors<long>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<ulong>.Demo, Vectors<ulong>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<ulong>.Demo, Vectors<ulong>.XyzwWMask));

#if NET5_0_OR_GREATER
                //Ceiling(Vector<Double>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
                //Ceiling(Vector<Single>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
                WriteLine(tw, indent, "Ceiling(Vectors<float>.Demo):\t{0}", Vector.Ceiling(Vectors<float>.Demo));
                WriteLine(tw, indent, "Ceiling(Vectors<double>.Demo):\t{0}", Vector.Ceiling(Vectors<double>.Demo));
#endif // NET5_0_OR_GREATER

                //ConditionalSelect(Vector<Int32>, Vector<Single>, Vector<Single>)    Creates a new single-precision vector with elements selected between two specified single-precision source vectors based on an integral mask vector.
                //ConditionalSelect(Vector<Int64>, Vector<Double>, Vector<Double>) Creates a new double-precision vector with elements selected between two specified double-precision source vectors based on an integral mask vector.
                //ConditionalSelect<T>(Vector<T>, Vector<T>, Vector<T>) Creates a new vector of a specified type with elements selected between two specified source vectors of the same type based on an integral mask vector.
                // ConditionalSelect = left&mask | right&~mask;
                //
                // Sample UInt32:
                //# srcT:   <0, 4294967295, 0, 1, 2, 3, 4, 0>       # (00000000 FFFFFFFF 00000000 00000001 00000002 00000003 00000004 00000000)
                //# ConditionalSelect(srcT, src0, src1):    <1, 0, 1, 0, 1, 0, 1, 1>        # (00000001 00000000 00000001 00000000 00000001 00000000 00000001 00000001)
                // Mean:
                //[0] = src0[0]&srcT[0] | src0[1]&~srcT[0] = 0&0 | 1&~0 = 0 | 1&0xFFFFFFFF = 1
                //[1] = src0[1]&srcT[1] | src0[1]&~srcT[1] = 0&4294967295 | 1&~4294967295 = 0 | 1&0 = 0
                //[2] = src0[2]&srcT[2] | src0[2]&~srcT[2] = 0&0 | 1&~0 = 0 | 1&0xFFFFFFFF = 1
                //[3] = src0[3]&srcT[3] | src0[3]&~srcT[3] = 0&1 | 1&~1 = 0 | 1&0xFFFFFFFE = 0
                //[4] = src0[4]&srcT[4] | src0[4]&~srcT[4] = 0&2 | 1&~2 = 0 | 1&0xFFFFFFFD = 1
                //[5] = src0[5]&srcT[5] | src0[5]&~srcT[5] = 0&3 | 1&~3 = 0 | 1&0xFFFFFFFC = 0
                //[6] = src0[6]&srcT[6] | src0[6]&~srcT[6] = 0&4 | 1&~4 = 0 | 1&0xFFFFFFFB = 1
                //[7] = src0[7]&srcT[7] | src0[7]&~srcT[7] = 0&0 | 1&~0 = 0 | 1 = 1
                WriteLine(tw, indent, "ConditionalSelect(Vectors<float>.XyzwWMask, Vectors<float>.Demo, Vectors<float>.V7):\t{0}", Vector.ConditionalSelect(Vectors<float>.XyzwWMask, Vectors<float>.Demo, Vectors<float>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<double>.XyzwWMask, Vectors<double>.Demo, Vectors<double>.V7):\t{0}", Vector.ConditionalSelect(Vectors<double>.XyzwWMask, Vectors<double>.Demo, Vectors<double>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<sbyte>.XyzwWMask, Vectors<sbyte>.Demo, Vectors<sbyte>.V7):\t{0}", Vector.ConditionalSelect(Vectors<sbyte>.XyzwWMask, Vectors<sbyte>.Demo, Vectors<sbyte>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<byte>.XyzwWMask, Vectors<byte>.Demo, Vectors<byte>.V7):\t{0}", Vector.ConditionalSelect(Vectors<byte>.XyzwWMask, Vectors<byte>.Demo, Vectors<byte>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<short>.XyzwWMask, Vectors<short>.Demo, Vectors<short>.V7):\t{0}", Vector.ConditionalSelect(Vectors<short>.XyzwWMask, Vectors<short>.Demo, Vectors<short>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<ushort>.XyzwWMask, Vectors<ushort>.Demo, Vectors<ushort>.V7):\t{0}", Vector.ConditionalSelect(Vectors<ushort>.XyzwWMask, Vectors<ushort>.Demo, Vectors<ushort>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<int>.XyzwWMask, Vectors<int>.Demo, Vectors<int>.V7):\t{0}", Vector.ConditionalSelect(Vectors<int>.XyzwWMask, Vectors<int>.Demo, Vectors<int>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<uint>.XyzwWMask, Vectors<uint>.Demo, Vectors<uint>.V7):\t{0}", Vector.ConditionalSelect(Vectors<uint>.XyzwWMask, Vectors<uint>.Demo, Vectors<uint>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<long>.XyzwWMask, Vectors<long>.Demo, Vectors<long>.V7):\t{0}", Vector.ConditionalSelect(Vectors<long>.XyzwWMask, Vectors<long>.Demo, Vectors<long>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<ulong>.XyzwWMask, Vectors<ulong>.Demo, Vectors<ulong>.V7):\t{0}", Vector.ConditionalSelect(Vectors<ulong>.XyzwWMask, Vectors<ulong>.Demo, Vectors<ulong>.V7));

                //            //ConvertToDouble(Vector<Int64>) Converts a Vector<Int64>to aVector<Double>.
                //            //ConvertToDouble(Vector<UInt64>) Converts a Vector<UInt64> to aVector<Double>.
                //            //ConvertToInt32(Vector<Single>) Converts a Vector<Single> to aVector<Int32>.
                //            //ConvertToInt64(Vector<Double>) Converts a Vector<Double> to aVector<Int64>.
                //            //ConvertToSingle(Vector<Int32>) Converts a Vector<Int32> to aVector<Single>.
                //            //ConvertToSingle(Vector<UInt32>) Converts a Vector<UInt32> to aVector<Single>.
                //            //ConvertToUInt32(Vector<Single>) Converts a Vector<Single> to aVector<UInt32>.
                //            //ConvertToUInt64(Vector<Double>) Converts a Vector<Double> to aVector<UInt64>.
                //            // Infinity or NaN -> IntTypes.MinValue .
                //            if (typeof(T) == typeof(Double)) {
                //                WriteLine(tw, indent, "ConvertToInt64(srcT):\t{0}", Vector.ConvertToInt64(Vector.AsVectorDouble(srcT)));
                //                WriteLine(tw, indent, "ConvertToUInt64(srcT):\t{0}", Vector.ConvertToUInt64(Vector.AsVectorDouble(srcT)));
                //            } else if (typeof(T) == typeof(Single)) {
                //                WriteLine(tw, indent, "ConvertToInt32(srcT):\t{0}", Vector.ConvertToInt32(Vector.AsVectorSingle(srcT)));
                //                WriteLine(tw, indent, "ConvertToUInt32(srcT):\t{0}", Vector.ConvertToUInt32(Vector.AsVectorSingle(srcT)));
                //            } else if (typeof(T) == typeof(Int32)) {
                //                WriteLine(tw, indent, "ConvertToSingle(srcT):\t{0}", Vector.ConvertToSingle(Vector.AsVectorInt32(srcT)));
                //            } else if (typeof(T) == typeof(UInt32)) {
                //                WriteLine(tw, indent, "ConvertToSingle(srcT):\t{0}", Vector.ConvertToSingle(Vector.AsVectorUInt32(srcT)));
                //            } else if (typeof(T) == typeof(Int64)) {
                //                WriteLine(tw, indent, "ConvertToDouble(srcT):\t{0}", Vector.ConvertToDouble(Vector.AsVectorInt64(srcT)));
                //            } else if (typeof(T) == typeof(UInt64)) {
                //                WriteLine(tw, indent, "ConvertToDouble(srcT):\t{0}", Vector.ConvertToDouble(Vector.AsVectorUInt64(srcT)));
                //            }

                //            //Divide<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the result of dividing the first vector's elements by the corresponding elements in the second vector.
                //            WriteLine(tw, indent, "Divide(srcT, src2):\t{0}", Vector.Divide(srcT, src2));

                //            //Dot<T>(Vector<T>, Vector<T>) Returns the dot product of two vectors.
                //            WriteLine(tw, indent, "Dot(srcT, src1):\t{0}", Vector.Dot(srcT, src1));
                //            WriteLine(tw, indent, "Dot(srcT, src2):\t{0}", Vector.Dot(srcT, src2));
                //            WriteLine(tw, indent, "Dot(src1, src2):\t{0}", Vector.Dot(src1, src2));

                //            //Equals(Vector<Double>, Vector<Double>)  Returns a new integral vector whose elements signal whether the elements in two specified double-precision vectors are equal.
                //            //Equals(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in two specified integral vectors are equal.
                //            //Equals(Vector<Int64>, Vector<Int64>)    Returns a new vector whose elements signal whether the elements in two specified long integer vectors are equal.
                //            //Equals(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in two specified single-precision vectors are equal.
                //            //Equals<T>(Vector<T>, Vector<T>) Returns a new vector of a specified type whose elements signal whether the elements in two specified vectors of the same type are equal.
                //            WriteLine(tw, indent, "Equals(srcT, src0):\t{0}", Vector.Equals(srcT, src0));
                //            WriteLine(tw, indent, "Equals(srcT, src1):\t{0}", Vector.Equals(srcT, src1));

                //            //EqualsAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether each pair of elements in the given vectors is equal.
                //            WriteLine(tw, indent, "EqualsAll(srcT, src0):\t{0}", Vector.EqualsAll(srcT, src0));
                //            //EqualsAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any single pair of elements in the given vectors is equal.
                //            WriteLine(tw, indent, "EqualsAny(srcT, src0):\t{0}", Vector.EqualsAny(srcT, src0));

#if NET5_0_OR_GREATER
                //Floor(Vector<Double>) Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
                //Floor(Vector<Single>)   Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
                WriteLine(tw, indent, "Floor(Vectors<float>.Demo):\t{0}", Vector.Floor(Vectors<float>.Demo));
                WriteLine(tw, indent, "Floor(Vectors<double>.Demo):\t{0}", Vector.Floor(Vectors<double>.Demo));
#endif // NET5_0_OR_GREATER

                //            //GreaterThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are greater than their corresponding elements in a second double-precision floating-point vector.
                //            //GreaterThan(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than their corresponding elements in a second integral vector.
                //            //GreaterThan(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than their corresponding elements in a second long integer vector.
                //            //GreaterThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are greater than their corresponding elements in a second single-precision floating-point vector.
                //            //GreaterThan<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than their corresponding elements in the second vector of the same time.
                //            WriteLine(tw, indent, "GreaterThan(srcT, src0):\t{0}", Vector.GreaterThan(srcT, src0));
                //            WriteLine(tw, indent, "GreaterThan(srcT, src1):\t{0}", Vector.GreaterThan(srcT, src1));

                //            //GreaterThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than the corresponding elements in the second vector.
                //            //GreaterThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than the corresponding element in the second vector.

                //            //GreaterThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the second double-precision floating-point vector.
                //            //GreaterThanOrEqual(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than or equal to their corresponding elements in the second integral vector.
                //            //GreaterThanOrEqual(Vector<Int64>, Vector<Int64>)    Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than or equal to their corresponding elements in the second long integer vector.
                //            //GreaterThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the single-precision floating-point second vector.
                //            //GreaterThanOrEqual<T>(Vector<T>, Vector<T>) Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than or equal to their corresponding elements in the second vector of the same type.
                //            WriteLine(tw, indent, "GreaterThanOrEqual(srcT, src0):\t{0}", Vector.GreaterThanOrEqual(srcT, src0));
                //            WriteLine(tw, indent, "GreaterThanOrEqual(srcT, src1):\t{0}", Vector.GreaterThanOrEqual(srcT, src1));

                //            //GreaterThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than or equal to all the corresponding elements in the second vector.
                //            //GreaterThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than or equal to the corresponding element in the second vector.

                //            //LessThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than their corresponding elements in a second double-precision floating-point vector.
                //            //LessThan(Vector<Int32>, Vector<Int32>)  Returns a new integral vector whose elements signal whether the elements in one integral vector are less than their corresponding elements in a second integral vector.
                //            //LessThan(Vector<Int64>, Vector<Int64>)  Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less than their corresponding elements in a second long integer vector.
                //            //LessThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision vector are less than their corresponding elements in a second single-precision vector.
                //            //LessThan<T>(Vector<T>, Vector<T>)   Returns a new vector of a specified type whose elements signal whether the elements in one vector are less than their corresponding elements in the second vector.
                //            WriteLine(tw, indent, "LessThan(srcT, src0):\t{0}", Vector.LessThan(srcT, src0));
                //            WriteLine(tw, indent, "LessThan(srcT, src1):\t{0}", Vector.LessThan(srcT, src1));

                //            //LessThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all of the elements in the first vector are less than their corresponding elements in the second vector.
                //            //LessThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than the corresponding element in the second vector.

                //            //LessThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than or equal to their corresponding elements in a second double-precision floating-point vector.
                //            //LessThanOrEqual(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are less than or equal to their corresponding elements in a second integral vector.
                //            //LessThanOrEqual(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less or equal to their corresponding elements in a second long integer vector.
                //            //LessThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are less than or equal to their corresponding elements in a second single-precision floating-point vector.
                //            //LessThanOrEqual<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector are less than or equal to their corresponding elements in the second vector.
                //            WriteLine(tw, indent, "LessThanOrEqual(srcT, src0):\t{0}", Vector.LessThanOrEqual(srcT, src0));
                //            WriteLine(tw, indent, "LessThanOrEqual(srcT, src1):\t{0}", Vector.LessThanOrEqual(srcT, src1));

                //            //LessThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are less than or equal to their corresponding elements in the second vector.
                //            //LessThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than or equal to the corresponding element in the second vector.

                //            //Max<T>(Vector<T>, Vector<T>) Returns a new vector whose elements are the maximum of each pair of elements in the two given vectors.
                //            WriteLine(tw, indent, "Max(srcT, src0):\t{0}", Vector.Max(srcT, src0));
                //            WriteLine(tw, indent, "Max(srcT, src2):\t{0}", Vector.Max(srcT, src2));
                //            //Min<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements are the minimum of each pair of elements in the two given vectors.
                //            WriteLine(tw, indent, "Min(srcT, src0):\t{0}", Vector.Min(srcT, src0));
                //            WriteLine(tw, indent, "Min(srcT, src2):\t{0}", Vector.Min(srcT, src2));
                //            WriteLine(tw, indent, "Min(Max(srcT, src0), src2):\t{0}", Vector.Min(Vector.Max(srcT, src0), src2));

                //            //Multiply<T>(T, Vector<T>)   Returns a new vector whose values are a scalar value multiplied by each of the values of a specified vector.
                //            //Multiply<T>(Vector<T>, T) Returns a new vector whose values are the values of a specified vector each multiplied by a scalar value.
                //            //Multiply<T>(Vector<T>, Vector<T>)   Returns a new vector whose values are the product of each pair of elements in two specified vectors.
                //            WriteLine(tw, indent, "Multiply(srcT, src2):\t{0}", Vector.Multiply(srcT, src2));

                //Narrow(Vector<Double>, Vector<Double>) Narrows two Vector<Double>instances into one Vector<Single>.
                //Narrow(Vector<Int16>, Vector<Int16>) Narrows two Vector<Int16> instances into one Vector<SByte>.
                //Narrow(Vector<Int32>, Vector<Int32>) Narrows two Vector<Int32> instances into one Vector<Int16>.
                //Narrow(Vector<Int64>, Vector<Int64>) Narrows two Vector<Int64> instances into one Vector<Int32>.
                //Narrow(Vector<UInt16>, Vector<UInt16>) Narrows two Vector<UInt16> instances into one Vector<Byte>.
                //Narrow(Vector<UInt32>, Vector<UInt32>) Narrows two Vector<UInt32> instances into one Vector<UInt16>.
                //Narrow(Vector<UInt64>, Vector<UInt64>) Narrows two Vector<UInt64> instances into one Vector<UInt32>.
                WriteLine(tw, indent, "Narrow(Vectors<Double>.Demo, Vectors<Double>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Double>.Demo, Vectors<Double>.SerialNegative));
                WriteLine(tw, indent, "Narrow(Vectors<Int16>.Demo, Vectors<Int16>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Int16>.Demo, Vectors<Int16>.SerialNegative));
                WriteLine(tw, indent, "Narrow(Vectors<Int32>.Demo, Vectors<Int32>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Int32>.Demo, Vectors<Int32>.SerialNegative));
                WriteLine(tw, indent, "Narrow(Vectors<Int64>.Demo, Vectors<Int64>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Int64>.Demo, Vectors<Int64>.SerialNegative));
                WriteLine(tw, indent, "Narrow(Vectors<UInt16>.Demo, Vectors<UInt16>.SerialNegative):\t{0}", Vector.Narrow(Vectors<UInt16>.Demo, Vectors<UInt16>.SerialNegative));
                WriteLine(tw, indent, "Narrow(Vectors<UInt32>.Demo, Vectors<UInt32>.SerialNegative):\t{0}", Vector.Narrow(Vectors<UInt32>.Demo, Vectors<UInt32>.SerialNegative));
                WriteLine(tw, indent, "Narrow(Vectors<UInt64>.Demo, Vectors<UInt64>.SerialNegative):\t{0}", Vector.Narrow(Vectors<UInt64>.Demo, Vectors<UInt64>.SerialNegative));

                ////Negate<T>(Vector<T>) Returns a new vector whose elements are the negation of the corresponding element in the specified vector.
                //WriteLine(tw, indent, "Negate(srcT):\t{0}", Vector.Negate(srcT));
                //WriteLine(tw, indent, "Negate(srcAllOnes):\t{0}", Vector.Negate(srcAllOnes));
                ////OnesComplement<T>(Vector<T>) Returns a new vector whose elements are obtained by taking the one's complement of a specified vector's elements.
                //WriteLine(tw, indent, "OnesComplement(srcT):\t{0}", Vector.OnesComplement(srcT));
                //WriteLine(tw, indent, "OnesComplement(srcAllOnes):\t{0}", Vector.OnesComplement(srcAllOnes));

#if NET7_0_OR_GREATER
                            //ShiftLeft(Vector<Byte>, Int32)  Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<Int16>, Int32) Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<Int32>, Int32) Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<Int64>, Int32) Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<IntPtr>, Int32)    Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<SByte>, Int32) Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<UInt16>, Int32)    Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<UInt32>, Int32) Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<UInt64>, Int32)    Shifts each element of a vector left by the specified amount.
                            //ShiftLeft(Vector<UIntPtr>, Int32) Shifts each element of a vector left by the specified amount.
                            //ShiftRightArithmetic(Vector<Int16>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                            //ShiftRightArithmetic(Vector<Int32>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                            //ShiftRightArithmetic(Vector<Int64>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                            //ShiftRightArithmetic(Vector<IntPtr>, Int32) Shifts(signed) each element of a vector right by the specified amount.
                            //ShiftRightArithmetic(Vector<SByte>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<Byte>, Int32)  Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<Int16>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<Int32>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<Int64>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<IntPtr>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<SByte>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<UInt16>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<UInt32>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<UInt64>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
                            //ShiftRightLogical(Vector<UIntPtr>, Int32)   Shifts(unsigned) each element of a vector right by the specified amount.
#endif // NET7_0_OR_GREATER

                //            //SquareRoot<T>(Vector<T>)    Returns a new vector whose elements are the square roots of a specified vector's elements.
                //            WriteLine(tw, indent, "SquareRoot(srcT):\t{0}", Vector.SquareRoot(srcT));

                //            //Subtract<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the difference between the elements in the second vector and their corresponding elements in the first vector.
                //            WriteLine(tw, indent, "Subtract(srcT, src1):\t{0}", Vector.Subtract(srcT, src1));
                //            WriteLine(tw, indent, "Subtract(srcT, src2):\t{0}", Vector.Subtract(srcT, src2));

#if NET6_0_OR_GREATER
                //Sum<T>(Vector<T>) Returns the sum of all the elements inside the specified vector.
                WriteLine(tw, indent, "Sum(Vectors<float>.Demo):\t{0}", Vector.Sum(Vectors<float>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<double>.Demo):\t{0}", Vector.Sum(Vectors<double>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<sbyte>.Demo):\t{0}", Vector.Sum(Vectors<sbyte>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<byte>.Demo):\t{0}", Vector.Sum(Vectors<byte>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<short>.Demo):\t{0}", Vector.Sum(Vectors<short>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<ushort>.Demo):\t{0}", Vector.Sum(Vectors<ushort>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<int>.Demo):\t{0}", Vector.Sum(Vectors<int>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<uint>.Demo):\t{0}", Vector.Sum(Vectors<uint>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<long>.Demo):\t{0}", Vector.Sum(Vectors<long>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<ulong>.Demo):\t{0}", Vector.Sum(Vectors<ulong>.Demo));
#endif // NET6_0_OR_GREATER

                //Widen(Vector<Byte>, Vector<UInt16>, Vector<UInt16>) Widens aVector<Byte> into two Vector<UInt16>instances.
                //Widen(Vector<Int16>, Vector<Int32>, Vector<Int32>) Widens a Vector<Int16> into twoVector<Int32> instances.
                //Widen(Vector<Int32>, Vector<Int64>, Vector<Int64>) Widens a Vector<Int32> into twoVector<Int64> instances.
                //Widen(Vector<SByte>, Vector<Int16>, Vector<Int16>) Widens a Vector<SByte> into twoVector<Int16> instances.
                //Widen(Vector<Single>, Vector<Double>, Vector<Double>) Widens a Vector<Single> into twoVector<Double> instances.
                //Widen(Vector<UInt16>, Vector<UInt32>, Vector<UInt32>) Widens a Vector<UInt16> into twoVector<UInt32> instances.
                //Widen(Vector<UInt32>, Vector<UInt64>, Vector<UInt64>) Widens a Vector<UInt32> into twoVector<UInt64> instances.
                // Debugger.Break();
                // WriteLine(tw, indent, "Avx2.Abs:\t{0}", Avx2.Abs(Vector256s<short>.AllBitsSet)); // Visual Studio 2019 YMM registers not displaying in Managed Debugger
                if (true) {
                    Vector.Widen(Vectors<float>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<float>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<sbyte>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<sbyte>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<byte>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<byte>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<short>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<short>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<ushort>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<ushort>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<int>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<int>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<uint>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<uint>.Demo):\t{0}, {1}", low, high);
                }

                //Xor<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise exclusive Or(XOr) operation on each pair of elements in two vectors.
                WriteLine(tw, indent, "Xor(Vectors<float>.Demo, Vectors<float>.XyzwWMask):\t{0}", Vector.Xor(Vectors<float>.Demo, Vectors<float>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<double>.Demo, Vectors<double>.XyzwWMask):\t{0}", Vector.Xor(Vectors<double>.Demo, Vectors<double>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<sbyte>.Demo, Vectors<sbyte>.XyzwWMask):\t{0}", Vector.Xor(Vectors<sbyte>.Demo, Vectors<sbyte>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<byte>.Demo, Vectors<byte>.XyzwWMask):\t{0}", Vector.Xor(Vectors<byte>.Demo, Vectors<byte>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<short>.Demo, Vectors<short>.XyzwWMask):\t{0}", Vector.Xor(Vectors<short>.Demo, Vectors<short>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<ushort>.Demo, Vectors<ushort>.XyzwWMask):\t{0}", Vector.Xor(Vectors<ushort>.Demo, Vectors<ushort>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<int>.Demo, Vectors<int>.XyzwWMask):\t{0}", Vector.Xor(Vectors<int>.Demo, Vectors<int>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<uint>.Demo, Vectors<uint>.XyzwWMask):\t{0}", Vector.Xor(Vectors<uint>.Demo, Vectors<uint>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<long>.Demo, Vectors<long>.XyzwWMask):\t{0}", Vector.Xor(Vectors<long>.Demo, Vectors<long>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<ulong>.Demo, Vectors<ulong>.XyzwWMask):\t{0}", Vector.Xor(Vectors<ulong>.Demo, Vectors<ulong>.XyzwWMask));

            }

            #endregion // Methods

        }

        /// <summary>
        /// Run Vector64. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.vector64?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector64(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector64.IsHardwareAccelerated) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("-- Vector64.IsSupported:\t{0}", Vector64.IsHardwareAccelerated));
            if (!Vector64.IsHardwareAccelerated) {
                return;
            }

#else
            // none.
#endif
        }

        /// <summary>
        /// Run Vector128. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.vector128?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector128(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector128.IsHardwareAccelerated) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("-- Vector128.IsSupported:\t{0}", Vector128.IsHardwareAccelerated));
            if (!Vector128.IsHardwareAccelerated) {
                return;
            }

#else
            // none.
#endif
        }

        /// <summary>
        /// Run Vector256. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.vector256?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector256(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector256.IsHardwareAccelerated) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("-- Vector256.IsSupported:\t{0}", Vector256.IsHardwareAccelerated));
            if (!Vector256.IsHardwareAccelerated) {
                return;
            }

#else
            // none.
#endif
        }
    }

}
