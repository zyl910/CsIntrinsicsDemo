﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
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
                WriteLineFormat(tw, indent, "Abs(Vectors<float>.Demo):\t{0}", Vector.Abs(Vectors<float>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<double>.Demo):\t{0}", Vector.Abs(Vectors<double>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<sbyte>.Demo):\t{0}", Vector.Abs(Vectors<sbyte>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<byte>.Demo):\t{0}", Vector.Abs(Vectors<byte>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<short>.Demo):\t{0}", Vector.Abs(Vectors<short>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<ushort>.Demo):\t{0}", Vector.Abs(Vectors<ushort>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<int>.Demo):\t{0}", Vector.Abs(Vectors<int>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<uint>.Demo):\t{0}", Vector.Abs(Vectors<uint>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<long>.Demo):\t{0}", Vector.Abs(Vectors<long>.Demo));
                WriteLineFormat(tw, indent, "Abs(Vectors<ulong>.Demo):\t{0}", Vector.Abs(Vectors<ulong>.Demo));

//            //Add<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the sum of each pair of elements from two given vectors.
//            WriteLineFormat(tw, indent, "Add(srcT, src1):\t{0}", Vector.Add(srcT, src1));
//            WriteLineFormat(tw, indent, "Add(srcT, src2):\t{0}", Vector.Add(srcT, src2));

//            //AndNot<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise And Not operation on each pair of corresponding elements in two vectors.
//            WriteLineFormat(tw, indent, "AndNot(srcT, src1):\t{0}", Vector.AndNot(srcT, src1));
//            WriteLineFormat(tw, indent, "AndNot(srcT, src2):\t{0}", Vector.AndNot(srcT, src2));

//            //As<TFrom, TTo>(Vector<TFrom>)    Reinterprets aVector64<T> as a new Vector64<T>.
//            //AsVectorByte<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of unsigned bytes.
//            //AsVectorDouble<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a double-precision floating-point vector.
//            //AsVectorInt16<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of 16-bit integers.
//            //AsVectorInt32<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of integers.
//            //AsVectorInt64<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of long integers.
//            //AsVectorNInt<T>(Vector<T>)  Reinterprets the bits of a specified vector into those of a vector of native-sized integers.
//            //AsVectorNUInt<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of native-sized, unsigned integers.
//            //AsVectorSByte<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of signed bytes.
//            //AsVectorSingle<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a single-precision floating-point vector.
//            //AsVectorUInt16<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a vector of unsigned 16-bit integers.
//            //AsVectorUInt32<T>(Vector<T>)    Reinterprets the bits of a specified vector into those of a vector of unsigned integers.
//            //AsVectorUInt64<T>(Vector<T>) Reinterprets the bits of a specified vector into those of a vector of unsigned long integers.
//            // `As***` see below.

//            //BitwiseAnd<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise Andoperation on each pair of elements in two vectors.
//            WriteLineFormat(tw, indent, "BitwiseAnd(srcT, src1):\t{0}", Vector.BitwiseAnd(srcT, src1));
//            WriteLineFormat(tw, indent, "BitwiseAnd(srcT, src2):\t{0}", Vector.BitwiseAnd(srcT, src2));
//            //BitwiseOr<T>(Vector<T>, Vector<T>)  Returns a new vector by performing a bitwise Oroperation on each pair of elements in two vectors.
//            WriteLineFormat(tw, indent, "BitwiseOr(srcT, src1):\t{0}", Vector.BitwiseOr(srcT, src1));
//            WriteLineFormat(tw, indent, "BitwiseOr(srcT, src2):\t{0}", Vector.BitwiseOr(srcT, src2));

//#if NET5_0_OR_GREATER
//            //Ceiling(Vector<Double>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
//            //Ceiling(Vector<Single>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
//            if (typeof(T) == typeof(Double)) {
//                WriteLineFormat(tw, indent, "Ceiling(srcT):\t{0}", Vector.Ceiling(Vector.AsVectorDouble(srcT)));
//            } else if (typeof(T) == typeof(Single)) {
//                WriteLineFormat(tw, indent, "Ceiling(srcT):\t{0}", Vector.Ceiling(Vector.AsVectorSingle(srcT)));
//            }
//#endif // NET5_0_OR_GREATER

//            //ConditionalSelect(Vector<Int32>, Vector<Single>, Vector<Single>)    Creates a new single-precision vector with elements selected between two specified single-precision source vectors based on an integral mask vector.
//            //ConditionalSelect(Vector<Int64>, Vector<Double>, Vector<Double>) Creates a new double-precision vector with elements selected between two specified double-precision source vectors based on an integral mask vector.
//            //ConditionalSelect<T>(Vector<T>, Vector<T>, Vector<T>) Creates a new vector of a specified type with elements selected between two specified source vectors of the same type based on an integral mask vector.
//            Vector<T> mask = Vector.GreaterThan(srcT, src0);
//            WriteLineFormat(tw, indent, "# Max mask=GreaterThan(srcT, src0):\t{0}", mask);
//            WriteLineFormat(tw, indent, "ConditionalSelect(mask, srcT, src0):\t{0}", Vector.ConditionalSelect(mask, srcT, src0));
//            WriteLineFormat(tw, indent, "ConditionalSelect(srcT, src0, src1):\t{0}", Vector.ConditionalSelect(srcT, src0, src1));
//            // ConditionalSelect = left&mask | right&~mask;
//            //
//            // Sample UInt32:
//            //# srcT:   <0, 4294967295, 0, 1, 2, 3, 4, 0>       # (00000000 FFFFFFFF 00000000 00000001 00000002 00000003 00000004 00000000)
//            //# ConditionalSelect(srcT, src0, src1):    <1, 0, 1, 0, 1, 0, 1, 1>        # (00000001 00000000 00000001 00000000 00000001 00000000 00000001 00000001)
//            // Mean:
//            //[0] = src0[0]&srcT[0] | src0[1]&~srcT[0] = 0&0 | 1&~0 = 0 | 1&0xFFFFFFFF = 1
//            //[1] = src0[1]&srcT[1] | src0[1]&~srcT[1] = 0&4294967295 | 1&~4294967295 = 0 | 1&0 = 0
//            //[2] = src0[2]&srcT[2] | src0[2]&~srcT[2] = 0&0 | 1&~0 = 0 | 1&0xFFFFFFFF = 1
//            //[3] = src0[3]&srcT[3] | src0[3]&~srcT[3] = 0&1 | 1&~1 = 0 | 1&0xFFFFFFFE = 0
//            //[4] = src0[4]&srcT[4] | src0[4]&~srcT[4] = 0&2 | 1&~2 = 0 | 1&0xFFFFFFFD = 1
//            //[5] = src0[5]&srcT[5] | src0[5]&~srcT[5] = 0&3 | 1&~3 = 0 | 1&0xFFFFFFFC = 0
//            //[6] = src0[6]&srcT[6] | src0[6]&~srcT[6] = 0&4 | 1&~4 = 0 | 1&0xFFFFFFFB = 1
//            //[7] = src0[7]&srcT[7] | src0[7]&~srcT[7] = 0&0 | 1&~0 = 0 | 1 = 1

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
//                WriteLineFormat(tw, indent, "ConvertToInt64(srcT):\t{0}", Vector.ConvertToInt64(Vector.AsVectorDouble(srcT)));
//                WriteLineFormat(tw, indent, "ConvertToUInt64(srcT):\t{0}", Vector.ConvertToUInt64(Vector.AsVectorDouble(srcT)));
//            } else if (typeof(T) == typeof(Single)) {
//                WriteLineFormat(tw, indent, "ConvertToInt32(srcT):\t{0}", Vector.ConvertToInt32(Vector.AsVectorSingle(srcT)));
//                WriteLineFormat(tw, indent, "ConvertToUInt32(srcT):\t{0}", Vector.ConvertToUInt32(Vector.AsVectorSingle(srcT)));
//            } else if (typeof(T) == typeof(Int32)) {
//                WriteLineFormat(tw, indent, "ConvertToSingle(srcT):\t{0}", Vector.ConvertToSingle(Vector.AsVectorInt32(srcT)));
//            } else if (typeof(T) == typeof(UInt32)) {
//                WriteLineFormat(tw, indent, "ConvertToSingle(srcT):\t{0}", Vector.ConvertToSingle(Vector.AsVectorUInt32(srcT)));
//            } else if (typeof(T) == typeof(Int64)) {
//                WriteLineFormat(tw, indent, "ConvertToDouble(srcT):\t{0}", Vector.ConvertToDouble(Vector.AsVectorInt64(srcT)));
//            } else if (typeof(T) == typeof(UInt64)) {
//                WriteLineFormat(tw, indent, "ConvertToDouble(srcT):\t{0}", Vector.ConvertToDouble(Vector.AsVectorUInt64(srcT)));
//            }

//            //Divide<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the result of dividing the first vector's elements by the corresponding elements in the second vector.
//            WriteLineFormat(tw, indent, "Divide(srcT, src2):\t{0}", Vector.Divide(srcT, src2));

//            //Dot<T>(Vector<T>, Vector<T>) Returns the dot product of two vectors.
//            WriteLineFormat(tw, indent, "Dot(srcT, src1):\t{0}", Vector.Dot(srcT, src1));
//            WriteLineFormat(tw, indent, "Dot(srcT, src2):\t{0}", Vector.Dot(srcT, src2));
//            WriteLineFormat(tw, indent, "Dot(src1, src2):\t{0}", Vector.Dot(src1, src2));

//            //Equals(Vector<Double>, Vector<Double>)  Returns a new integral vector whose elements signal whether the elements in two specified double-precision vectors are equal.
//            //Equals(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in two specified integral vectors are equal.
//            //Equals(Vector<Int64>, Vector<Int64>)    Returns a new vector whose elements signal whether the elements in two specified long integer vectors are equal.
//            //Equals(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in two specified single-precision vectors are equal.
//            //Equals<T>(Vector<T>, Vector<T>) Returns a new vector of a specified type whose elements signal whether the elements in two specified vectors of the same type are equal.
//            WriteLineFormat(tw, indent, "Equals(srcT, src0):\t{0}", Vector.Equals(srcT, src0));
//            WriteLineFormat(tw, indent, "Equals(srcT, src1):\t{0}", Vector.Equals(srcT, src1));

//            //EqualsAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether each pair of elements in the given vectors is equal.
//            WriteLineFormat(tw, indent, "EqualsAll(srcT, src0):\t{0}", Vector.EqualsAll(srcT, src0));
//            //EqualsAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any single pair of elements in the given vectors is equal.
//            WriteLineFormat(tw, indent, "EqualsAny(srcT, src0):\t{0}", Vector.EqualsAny(srcT, src0));

//#if NET5_0_OR_GREATER
//            //Floor(Vector<Double>) Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
//            //Floor(Vector<Single>)   Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
//            if (typeof(T) == typeof(Double)) {
//                WriteLineFormat(tw, indent, "Floor(srcT):\t{0}", Vector.Floor(Vector.AsVectorDouble(srcT)));
//            } else if (typeof(T) == typeof(Single)) {
//                WriteLineFormat(tw, indent, "Floor(srcT):\t{0}", Vector.Floor(Vector.AsVectorSingle(srcT)));
//            }
//#endif // NET5_0_OR_GREATER

//            //GreaterThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are greater than their corresponding elements in a second double-precision floating-point vector.
//            //GreaterThan(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than their corresponding elements in a second integral vector.
//            //GreaterThan(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than their corresponding elements in a second long integer vector.
//            //GreaterThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are greater than their corresponding elements in a second single-precision floating-point vector.
//            //GreaterThan<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than their corresponding elements in the second vector of the same time.
//            WriteLineFormat(tw, indent, "GreaterThan(srcT, src0):\t{0}", Vector.GreaterThan(srcT, src0));
//            WriteLineFormat(tw, indent, "GreaterThan(srcT, src1):\t{0}", Vector.GreaterThan(srcT, src1));

//            //GreaterThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than the corresponding elements in the second vector.
//            //GreaterThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than the corresponding element in the second vector.

//            //GreaterThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the second double-precision floating-point vector.
//            //GreaterThanOrEqual(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than or equal to their corresponding elements in the second integral vector.
//            //GreaterThanOrEqual(Vector<Int64>, Vector<Int64>)    Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than or equal to their corresponding elements in the second long integer vector.
//            //GreaterThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the single-precision floating-point second vector.
//            //GreaterThanOrEqual<T>(Vector<T>, Vector<T>) Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than or equal to their corresponding elements in the second vector of the same type.
//            WriteLineFormat(tw, indent, "GreaterThanOrEqual(srcT, src0):\t{0}", Vector.GreaterThanOrEqual(srcT, src0));
//            WriteLineFormat(tw, indent, "GreaterThanOrEqual(srcT, src1):\t{0}", Vector.GreaterThanOrEqual(srcT, src1));

//            //GreaterThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than or equal to all the corresponding elements in the second vector.
//            //GreaterThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than or equal to the corresponding element in the second vector.

//            //LessThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than their corresponding elements in a second double-precision floating-point vector.
//            //LessThan(Vector<Int32>, Vector<Int32>)  Returns a new integral vector whose elements signal whether the elements in one integral vector are less than their corresponding elements in a second integral vector.
//            //LessThan(Vector<Int64>, Vector<Int64>)  Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less than their corresponding elements in a second long integer vector.
//            //LessThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision vector are less than their corresponding elements in a second single-precision vector.
//            //LessThan<T>(Vector<T>, Vector<T>)   Returns a new vector of a specified type whose elements signal whether the elements in one vector are less than their corresponding elements in the second vector.
//            WriteLineFormat(tw, indent, "LessThan(srcT, src0):\t{0}", Vector.LessThan(srcT, src0));
//            WriteLineFormat(tw, indent, "LessThan(srcT, src1):\t{0}", Vector.LessThan(srcT, src1));

//            //LessThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all of the elements in the first vector are less than their corresponding elements in the second vector.
//            //LessThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than the corresponding element in the second vector.

//            //LessThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than or equal to their corresponding elements in a second double-precision floating-point vector.
//            //LessThanOrEqual(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are less than or equal to their corresponding elements in a second integral vector.
//            //LessThanOrEqual(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less or equal to their corresponding elements in a second long integer vector.
//            //LessThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are less than or equal to their corresponding elements in a second single-precision floating-point vector.
//            //LessThanOrEqual<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector are less than or equal to their corresponding elements in the second vector.
//            WriteLineFormat(tw, indent, "LessThanOrEqual(srcT, src0):\t{0}", Vector.LessThanOrEqual(srcT, src0));
//            WriteLineFormat(tw, indent, "LessThanOrEqual(srcT, src1):\t{0}", Vector.LessThanOrEqual(srcT, src1));

//            //LessThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are less than or equal to their corresponding elements in the second vector.
//            //LessThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than or equal to the corresponding element in the second vector.

//            //Max<T>(Vector<T>, Vector<T>) Returns a new vector whose elements are the maximum of each pair of elements in the two given vectors.
//            WriteLineFormat(tw, indent, "Max(srcT, src0):\t{0}", Vector.Max(srcT, src0));
//            WriteLineFormat(tw, indent, "Max(srcT, src2):\t{0}", Vector.Max(srcT, src2));
//            //Min<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements are the minimum of each pair of elements in the two given vectors.
//            WriteLineFormat(tw, indent, "Min(srcT, src0):\t{0}", Vector.Min(srcT, src0));
//            WriteLineFormat(tw, indent, "Min(srcT, src2):\t{0}", Vector.Min(srcT, src2));
//            WriteLineFormat(tw, indent, "Min(Max(srcT, src0), src2):\t{0}", Vector.Min(Vector.Max(srcT, src0), src2));

//            //Multiply<T>(T, Vector<T>)   Returns a new vector whose values are a scalar value multiplied by each of the values of a specified vector.
//            //Multiply<T>(Vector<T>, T) Returns a new vector whose values are the values of a specified vector each multiplied by a scalar value.
//            //Multiply<T>(Vector<T>, Vector<T>)   Returns a new vector whose values are the product of each pair of elements in two specified vectors.
//            WriteLineFormat(tw, indent, "Multiply(srcT, src2):\t{0}", Vector.Multiply(srcT, src2));

//            //Narrow(Vector<Double>, Vector<Double>) Narrows two Vector<Double>instances into one Vector<Single>.
//            //Narrow(Vector<Int16>, Vector<Int16>) Narrows two Vector<Int16> instances into one Vector<SByte>.
//            //Narrow(Vector<Int32>, Vector<Int32>) Narrows two Vector<Int32> instances into one Vector<Int16>.
//            //Narrow(Vector<Int64>, Vector<Int64>) Narrows two Vector<Int64> instances into one Vector<Int32>.
//            //Narrow(Vector<UInt16>, Vector<UInt16>) Narrows two Vector<UInt16> instances into one Vector<Byte>.
//            //Narrow(Vector<UInt32>, Vector<UInt32>) Narrows two Vector<UInt32> instances into one Vector<UInt16>.
//            //Narrow(Vector<UInt64>, Vector<UInt64>) Narrows two Vector<UInt64> instances into one Vector<UInt32>.
//            if (typeof(T) == typeof(Double)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorDouble(srcT), Vector.AsVectorDouble(src1)));
//            } else if (typeof(T) == typeof(Int16)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorInt16(srcT), Vector.AsVectorInt16(src1)));
//            } else if (typeof(T) == typeof(Int32)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorInt32(srcT), Vector.AsVectorInt32(src1)));
//            } else if (typeof(T) == typeof(Int64)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorInt64(srcT), Vector.AsVectorInt64(src1)));
//            } else if (typeof(T) == typeof(UInt16)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorUInt16(srcT), Vector.AsVectorUInt16(src1)));
//            } else if (typeof(T) == typeof(UInt32)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorUInt32(srcT), Vector.AsVectorUInt32(src1)));
//            } else if (typeof(T) == typeof(UInt64)) {
//                WriteLineFormat(tw, indent, "Narrow(srcT):\t{0}", Vector.Narrow(Vector.AsVectorUInt64(srcT), Vector.AsVectorUInt64(src1)));
//            }

//            //Negate<T>(Vector<T>) Returns a new vector whose elements are the negation of the corresponding element in the specified vector.
//            WriteLineFormat(tw, indent, "Negate(srcT):\t{0}", Vector.Negate(srcT));
//            WriteLineFormat(tw, indent, "Negate(srcAllOnes):\t{0}", Vector.Negate(srcAllOnes));
//            //OnesComplement<T>(Vector<T>) Returns a new vector whose elements are obtained by taking the one's complement of a specified vector's elements.
//            WriteLineFormat(tw, indent, "OnesComplement(srcT):\t{0}", Vector.OnesComplement(srcT));
//            WriteLineFormat(tw, indent, "OnesComplement(srcAllOnes):\t{0}", Vector.OnesComplement(srcAllOnes));

//#if NET7_0_OR_GREATER
//            //ShiftLeft(Vector<Byte>, Int32)  Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<Int16>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<Int32>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<Int64>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<IntPtr>, Int32)    Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<SByte>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<UInt16>, Int32)    Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<UInt32>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<UInt64>, Int32)    Shifts each element of a vector left by the specified amount.
//            //ShiftLeft(Vector<UIntPtr>, Int32) Shifts each element of a vector left by the specified amount.
//            //ShiftRightArithmetic(Vector<Int16>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightArithmetic(Vector<Int32>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightArithmetic(Vector<Int64>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightArithmetic(Vector<IntPtr>, Int32) Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightArithmetic(Vector<SByte>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<Byte>, Int32)  Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<Int16>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<Int32>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<Int64>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<IntPtr>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<SByte>, Int32) Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<UInt16>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<UInt32>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<UInt64>, Int32)    Shifts(unsigned) each element of a vector right by the specified amount.
//            //ShiftRightLogical(Vector<UIntPtr>, Int32)   Shifts(unsigned) each element of a vector right by the specified amount.
//#endif // NET7_0_OR_GREATER

//            //SquareRoot<T>(Vector<T>)    Returns a new vector whose elements are the square roots of a specified vector's elements.
//            WriteLineFormat(tw, indent, "SquareRoot(srcT):\t{0}", Vector.SquareRoot(srcT));

//            //Subtract<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the difference between the elements in the second vector and their corresponding elements in the first vector.
//            WriteLineFormat(tw, indent, "Subtract(srcT, src1):\t{0}", Vector.Subtract(srcT, src1));
//            WriteLineFormat(tw, indent, "Subtract(srcT, src2):\t{0}", Vector.Subtract(srcT, src2));

//#if NET6_0_OR_GREATER
//            //Sum<T>(Vector<T>) Returns the sum of all the elements inside the specified vector.
//            WriteLineFormat(tw, indent, "Sum(srcT):\t{0}", Vector.Sum(srcT));
//            WriteLineFormat(tw, indent, "Sum(src1):\t{0}", Vector.Sum(src1));
//#endif // NET6_0_OR_GREATER

//            //Widen(Vector<Byte>, Vector<UInt16>, Vector<UInt16>) Widens aVector<Byte> into two Vector<UInt16>instances.
//            //Widen(Vector<Int16>, Vector<Int32>, Vector<Int32>) Widens a Vector<Int16> into twoVector<Int32> instances.
//            //Widen(Vector<Int32>, Vector<Int64>, Vector<Int64>) Widens a Vector<Int32> into twoVector<Int64> instances.
//            //Widen(Vector<SByte>, Vector<Int16>, Vector<Int16>) Widens a Vector<SByte> into twoVector<Int16> instances.
//            //Widen(Vector<Single>, Vector<Double>, Vector<Double>) Widens a Vector<Single> into twoVector<Double> instances.
//            //Widen(Vector<UInt16>, Vector<UInt32>, Vector<UInt32>) Widens a Vector<UInt16> into twoVector<UInt32> instances.
//            //Widen(Vector<UInt32>, Vector<UInt64>, Vector<UInt64>) Widens a Vector<UInt32> into twoVector<UInt64> instances.
//            if (typeof(T) == typeof(Single)) {
//                Vector<Double> low, high;
//                Vector.Widen(Vector.AsVectorSingle(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(SByte)) {
//                Vector<Int16> low, high;
//                Vector.Widen(Vector.AsVectorSByte(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(Int16)) {
//                Vector<Int32> low, high;
//                Vector.Widen(Vector.AsVectorInt16(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(Int32)) {
//                Vector<Int64> low, high;
//                Vector.Widen(Vector.AsVectorInt32(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(Byte)) {
//                Vector<UInt16> low, high;
//                Vector.Widen(Vector.AsVectorByte(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(UInt16)) {
//                Vector<UInt32> low, high;
//                Vector.Widen(Vector.AsVectorUInt16(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            } else if (typeof(T) == typeof(UInt32)) {
//                Vector<UInt64> low, high;
//                Vector.Widen(Vector.AsVectorUInt32(srcT), out low, out high);
//                WriteLineFormat(tw, indent, "Widen(srcT).low:\t{0}", low);
//                WriteLineFormat(tw, indent, "Widen(srcT).high:\t{0}", high);
//            }

//            //Xor<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise exclusive Or(XOr) operation on each pair of elements in two vectors.
//            WriteLineFormat(tw, indent, "Xor(srcT, src1):\t{0}", Vector.Xor(srcT, src1));
//            WriteLineFormat(tw, indent, "Xor(srcT, src2):\t{0}", Vector.Xor(srcT, src2));

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
