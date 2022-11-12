using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.Intrinsics;
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
            tw.WriteLine(indent + string.Format("Vector<Single>.Count:\t{0}", Vector<Single>.Count));
            tw.WriteLine(indent + string.Format("Vector<Double>.Count:\t{0}", Vector<Double>.Count));
            tw.WriteLine(indent + string.Format("Vector<SByte>.Count:\t{0}", Vector<SByte>.Count));
            tw.WriteLine(indent + string.Format("Vector<Byte>.Count:\t{0}", Vector<Byte>.Count));
            tw.WriteLine(indent + string.Format("Vector<Int16>.Count:\t{0}", Vector<Int16>.Count));
            tw.WriteLine(indent + string.Format("Vector<UInt16>.Count:\t{0}", Vector<UInt16>.Count));
            tw.WriteLine(indent + string.Format("Vector<Int32>.Count:\t{0}", Vector<Int32>.Count));
            tw.WriteLine(indent + string.Format("Vector<UInt32>.Count:\t{0}", Vector<UInt32>.Count));
            tw.WriteLine(indent + string.Format("Vector<Int64>.Count:\t{0}", Vector<Int64>.Count));
            tw.WriteLine(indent + string.Format("Vector<UInt64>.Count:\t{0}", Vector<UInt64>.Count));
#if NET6_0_OR_GREATER
            tw.WriteLine(indent + string.Format("Vector<IntPtr>.Count:\t{0}", Vector<IntPtr>.Count));
            tw.WriteLine(indent + string.Format("Vector<UIntPtr>.Count:\t{0}", Vector<UIntPtr>.Count));
            // Unhandled exception. System.NotSupportedException: Specified type is not supported
            //tw.WriteLine(indent + string.Format("Vector<Half>.Count:\t{0}", Vector<Half>.Count));
#endif // NET6_0_OR_GREATER

            // -- Methods --
            unchecked {
                //Debugger.Break();
                //Abs<T>(Vector<T>) Returns a new vector whose elements are the absolute values of the given vector's elements.
                WriteLine(tw, indent, "Abs(Vectors<Single>.Demo):\t{0}", Vector.Abs(Vectors<Single>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<Double>.Demo):\t{0}", Vector.Abs(Vectors<Double>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<SByte>.Demo):\t{0}", Vector.Abs(Vectors<SByte>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<Byte>.Demo):\t{0}", Vector.Abs(Vectors<Byte>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<Int16>.Demo):\t{0}", Vector.Abs(Vectors<Int16>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<UInt16>.Demo):\t{0}", Vector.Abs(Vectors<UInt16>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<Int32>.Demo):\t{0}", Vector.Abs(Vectors<Int32>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<UInt32>.Demo):\t{0}", Vector.Abs(Vectors<UInt32>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<Int64>.Demo):\t{0}", Vector.Abs(Vectors<Int64>.Demo));
                WriteLine(tw, indent, "Abs(Vectors<UInt64>.Demo):\t{0}", Vector.Abs(Vectors<UInt64>.Demo));

                //Add<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the sum of each pair of elements from two given vectors.
                WriteLine(tw, indent, "Add(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Add(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(tw, indent, "Add(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Add(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(tw, indent, "Add(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Add(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(tw, indent, "Add(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Add(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(tw, indent, "Add(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Add(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(tw, indent, "Add(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Add(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(tw, indent, "Add(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Add(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(tw, indent, "Add(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Add(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(tw, indent, "Add(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Add(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(tw, indent, "Add(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Add(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

                //AndNot<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise And Not operation on each pair of corresponding elements in two vectors.
                WriteLine(tw, indent, "AndNot(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask));
                WriteLine(tw, indent, "AndNot(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask));

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
                WriteLine(tw, indent, "BitwiseAnd(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseAnd(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask));

                //BitwiseOr<T>(Vector<T>, Vector<T>)  Returns a new vector by performing a bitwise Oroperation on each pair of elements in two vectors.
                WriteLine(tw, indent, "BitwiseOr(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask));
                WriteLine(tw, indent, "BitwiseOr(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask));

#if NET5_0_OR_GREATER
                //Ceiling(Vector<Double>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
                //Ceiling(Vector<Single>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
                WriteLine(tw, indent, "Ceiling(Vectors<Single>.Demo):\t{0}", Vector.Ceiling(Vectors<Single>.Demo));
                WriteLine(tw, indent, "Ceiling(Vectors<Double>.Demo):\t{0}", Vector.Ceiling(Vectors<Double>.Demo));
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
                WriteLine(tw, indent, "ConditionalSelect(Vectors<Single>.XyzwWMask, Vectors<Single>.Demo, Vectors<Single>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Single>.XyzwWMask, Vectors<Single>.Demo, Vectors<Single>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<Double>.XyzwWMask, Vectors<Double>.Demo, Vectors<Double>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Double>.XyzwWMask, Vectors<Double>.Demo, Vectors<Double>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<SByte>.XyzwWMask, Vectors<SByte>.Demo, Vectors<SByte>.V7):\t{0}", Vector.ConditionalSelect(Vectors<SByte>.XyzwWMask, Vectors<SByte>.Demo, Vectors<SByte>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<Byte>.XyzwWMask, Vectors<Byte>.Demo, Vectors<Byte>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Byte>.XyzwWMask, Vectors<Byte>.Demo, Vectors<Byte>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<Int16>.XyzwWMask, Vectors<Int16>.Demo, Vectors<Int16>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Int16>.XyzwWMask, Vectors<Int16>.Demo, Vectors<Int16>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<UInt16>.XyzwWMask, Vectors<UInt16>.Demo, Vectors<UInt16>.V7):\t{0}", Vector.ConditionalSelect(Vectors<UInt16>.XyzwWMask, Vectors<UInt16>.Demo, Vectors<UInt16>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<Int32>.XyzwWMask, Vectors<Int32>.Demo, Vectors<Int32>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Int32>.XyzwWMask, Vectors<Int32>.Demo, Vectors<Int32>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<UInt32>.XyzwWMask, Vectors<UInt32>.Demo, Vectors<UInt32>.V7):\t{0}", Vector.ConditionalSelect(Vectors<UInt32>.XyzwWMask, Vectors<UInt32>.Demo, Vectors<UInt32>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<Int64>.XyzwWMask, Vectors<Int64>.Demo, Vectors<Int64>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Int64>.XyzwWMask, Vectors<Int64>.Demo, Vectors<Int64>.V7));
                WriteLine(tw, indent, "ConditionalSelect(Vectors<UInt64>.XyzwWMask, Vectors<UInt64>.Demo, Vectors<UInt64>.V7):\t{0}", Vector.ConditionalSelect(Vectors<UInt64>.XyzwWMask, Vectors<UInt64>.Demo, Vectors<UInt64>.V7));

                //ConvertToDouble(Vector<Int64>) Converts a Vector<Int64>to aVector<Double>.
                //ConvertToDouble(Vector<UInt64>) Converts a Vector<UInt64> to aVector<Double>.
                //ConvertToInt32(Vector<Single>) Converts a Vector<Single> to aVector<Int32>.
                //ConvertToInt64(Vector<Double>) Converts a Vector<Double> to aVector<Int64>.
                //ConvertToSingle(Vector<Int32>) Converts a Vector<Int32> to aVector<Single>.
                //ConvertToSingle(Vector<UInt32>) Converts a Vector<UInt32> to aVector<Single>.
                //ConvertToUInt32(Vector<Single>) Converts a Vector<Single> to aVector<UInt32>.
                //ConvertToUInt64(Vector<Double>) Converts a Vector<Double> to aVector<UInt64>.
                // Infinity or NaN -> IntTypes.MinValue .
                WriteLine(tw, indent, "ConvertToDouble(Vectors<Int64>.Demo):\t{0}", Vector.ConvertToDouble(Vectors<Int64>.Demo));
                WriteLine(tw, indent, "ConvertToDouble(Vectors<UInt64>.Demo):\t{0}", Vector.ConvertToDouble(Vectors<UInt64>.Demo));
                WriteLine(tw, indent, "ConvertToInt32(Vectors<Single>.Demo):\t{0}", Vector.ConvertToInt32(Vectors<Single>.Demo));
                WriteLine(tw, indent, "ConvertToInt64(Vectors<Double>.Demo):\t{0}", Vector.ConvertToInt64(Vectors<Double>.Demo));
                WriteLine(tw, indent, "ConvertToSingle(Vectors<Int32>.Demo):\t{0}", Vector.ConvertToSingle(Vectors<Int32>.Demo));
                WriteLine(tw, indent, "ConvertToSingle(Vectors<UInt32>.Demo):\t{0}", Vector.ConvertToSingle(Vectors<UInt32>.Demo));
                WriteLine(tw, indent, "ConvertToUInt32(Vectors<Single>.Demo):\t{0}", Vector.ConvertToUInt32(Vectors<Single>.Demo));
                WriteLine(tw, indent, "ConvertToUInt64(Vectors<Double>.Demo):\t{0}", Vector.ConvertToUInt64(Vectors<Double>.Demo));

                //Divide<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the result of dividing the first vector's elements by the corresponding elements in the second vector.
                WriteLine(tw, indent, "Divide(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Divide(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(tw, indent, "Divide(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Divide(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(tw, indent, "Divide(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Divide(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(tw, indent, "Divide(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Divide(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(tw, indent, "Divide(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Divide(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(tw, indent, "Divide(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Divide(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(tw, indent, "Divide(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Divide(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(tw, indent, "Divide(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Divide(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(tw, indent, "Divide(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Divide(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(tw, indent, "Divide(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Divide(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

                //Dot<T>(Vector<T>, Vector<T>) Returns the dot product of two vectors.
                WriteLine(tw, indent, "Dot(Vectors<Int32>.V1, Vectors<Int32>.V2):\t{0}", Vector.Dot(Vectors<Int32>.V1, Vectors<Int32>.V2)); // 1*2*Vector<T>.Count
                WriteLine(tw, indent, "Dot(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Dot(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(tw, indent, "Dot(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Dot(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(tw, indent, "Dot(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Dot(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(tw, indent, "Dot(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Dot(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(tw, indent, "Dot(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Dot(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(tw, indent, "Dot(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Dot(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(tw, indent, "Dot(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Dot(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(tw, indent, "Dot(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Dot(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(tw, indent, "Dot(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Dot(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(tw, indent, "Dot(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Dot(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

                //Equals(Vector<Double>, Vector<Double>)  Returns a new integral vector whose elements signal whether the elements in two specified double-precision vectors are equal.
                //Equals(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in two specified integral vectors are equal.
                //Equals(Vector<Int64>, Vector<Int64>)    Returns a new vector whose elements signal whether the elements in two specified long integer vectors are equal.
                //Equals(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in two specified single-precision vectors are equal.
                //Equals<T>(Vector<T>, Vector<T>) Returns a new vector of a specified type whose elements signal whether the elements in two specified vectors of the same type are equal.
                WriteLine(tw, indent, "Equals(Vectors<Single>.Demo, Vectors<Single>.MinValue):\t{0}", Vector.Equals(Vectors<Single>.Demo, Vectors<Single>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<Double>.Demo, Vectors<Double>.MinValue):\t{0}", Vector.Equals(Vectors<Double>.Demo, Vectors<Double>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<SByte>.Demo, Vectors<SByte>.MinValue):\t{0}", Vector.Equals(Vectors<SByte>.Demo, Vectors<SByte>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<Byte>.Demo, Vectors<Byte>.MinValue):\t{0}", Vector.Equals(Vectors<Byte>.Demo, Vectors<Byte>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<Int16>.Demo, Vectors<Int16>.MinValue):\t{0}", Vector.Equals(Vectors<Int16>.Demo, Vectors<Int16>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<UInt16>.Demo, Vectors<UInt16>.MinValue):\t{0}", Vector.Equals(Vectors<UInt16>.Demo, Vectors<UInt16>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<Int32>.Demo, Vectors<Int32>.MinValue):\t{0}", Vector.Equals(Vectors<Int32>.Demo, Vectors<Int32>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<UInt32>.Demo, Vectors<UInt32>.MinValue):\t{0}", Vector.Equals(Vectors<UInt32>.Demo, Vectors<UInt32>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<Int64>.Demo, Vectors<Int64>.MinValue):\t{0}", Vector.Equals(Vectors<Int64>.Demo, Vectors<Int64>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<UInt64>.Demo, Vectors<UInt64>.MinValue):\t{0}", Vector.Equals(Vectors<UInt64>.Demo, Vectors<UInt64>.MinValue));
                WriteLine(tw, indent, "Equals(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.Equals(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(tw, indent, "Equals(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.Equals(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(tw, indent, "Equals(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.Equals(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(tw, indent, "Equals(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.Equals(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(tw, indent, "Equals(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.Equals(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(tw, indent, "Equals(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.Equals(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(tw, indent, "Equals(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.Equals(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(tw, indent, "Equals(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.Equals(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(tw, indent, "Equals(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.Equals(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(tw, indent, "Equals(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.Equals(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //EqualsAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether each pair of elements in the given vectors is equal.
                WriteLine(tw, indent, "EqualsAll(Vectors<Single>.Demo, Vectors<Single>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Single>.Demo, Vectors<Single>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<Double>.Demo, Vectors<Double>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Double>.Demo, Vectors<Double>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<SByte>.Demo, Vectors<SByte>.MinValue):\t{0}", Vector.EqualsAll(Vectors<SByte>.Demo, Vectors<SByte>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<Byte>.Demo, Vectors<Byte>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Byte>.Demo, Vectors<Byte>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<Int16>.Demo, Vectors<Int16>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Int16>.Demo, Vectors<Int16>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<UInt16>.Demo, Vectors<UInt16>.MinValue):\t{0}", Vector.EqualsAll(Vectors<UInt16>.Demo, Vectors<UInt16>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<Int32>.Demo, Vectors<Int32>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Int32>.Demo, Vectors<Int32>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<UInt32>.Demo, Vectors<UInt32>.MinValue):\t{0}", Vector.EqualsAll(Vectors<UInt32>.Demo, Vectors<UInt32>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<Int64>.Demo, Vectors<Int64>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Int64>.Demo, Vectors<Int64>.MinValue));
                WriteLine(tw, indent, "EqualsAll(Vectors<UInt64>.Demo, Vectors<UInt64>.MinValue):\t{0}", Vector.EqualsAll(Vectors<UInt64>.Demo, Vectors<UInt64>.MinValue));

                //EqualsAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any single pair of elements in the given vectors is equal.
                WriteLine(tw, indent, "EqualsAny(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.EqualsAny(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.EqualsAny(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.EqualsAny(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.EqualsAny(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.EqualsAny(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.EqualsAny(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.EqualsAny(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.EqualsAny(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.EqualsAny(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(tw, indent, "EqualsAny(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.EqualsAny(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

#if NET5_0_OR_GREATER
                //Floor(Vector<Double>) Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
                //Floor(Vector<Single>)   Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
                WriteLine(tw, indent, "Floor(Vectors<Single>.Demo):\t{0}", Vector.Floor(Vectors<Single>.Demo));
                WriteLine(tw, indent, "Floor(Vectors<Double>.Demo):\t{0}", Vector.Floor(Vectors<Double>.Demo));
#endif // NET5_0_OR_GREATER

                //GreaterThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are greater than their corresponding elements in a second double-precision floating-point vector.
                //GreaterThan(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than their corresponding elements in a second integral vector.
                //GreaterThan(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than their corresponding elements in a second long integer vector.
                //GreaterThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are greater than their corresponding elements in a second single-precision floating-point vector.
                //GreaterThan<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than their corresponding elements in the second vector of the same time.
                WriteLine(tw, indent, "GreaterThan(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.GreaterThan(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.GreaterThan(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.GreaterThan(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.GreaterThan(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.GreaterThan(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.GreaterThan(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.GreaterThan(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.GreaterThan(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.GreaterThan(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(tw, indent, "GreaterThan(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.GreaterThan(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //GreaterThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than the corresponding elements in the second vector.
                //GreaterThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than the corresponding element in the second vector.

                //GreaterThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the second double-precision floating-point vector.
                //GreaterThanOrEqual(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than or equal to their corresponding elements in the second integral vector.
                //GreaterThanOrEqual(Vector<Int64>, Vector<Int64>)    Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than or equal to their corresponding elements in the second long integer vector.
                //GreaterThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the single-precision floating-point second vector.
                //GreaterThanOrEqual<T>(Vector<T>, Vector<T>) Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than or equal to their corresponding elements in the second vector of the same type.
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(tw, indent, "GreaterThanOrEqual(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //GreaterThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than or equal to all the corresponding elements in the second vector.
                //GreaterThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than or equal to the corresponding element in the second vector.

                //LessThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than their corresponding elements in a second double-precision floating-point vector.
                //LessThan(Vector<Int32>, Vector<Int32>)  Returns a new integral vector whose elements signal whether the elements in one integral vector are less than their corresponding elements in a second integral vector.
                //LessThan(Vector<Int64>, Vector<Int64>)  Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less than their corresponding elements in a second long integer vector.
                //LessThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision vector are less than their corresponding elements in a second single-precision vector.
                //LessThan<T>(Vector<T>, Vector<T>)   Returns a new vector of a specified type whose elements signal whether the elements in one vector are less than their corresponding elements in the second vector.
                WriteLine(tw, indent, "LessThan(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.LessThan(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.LessThan(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.LessThan(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.LessThan(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.LessThan(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.LessThan(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.LessThan(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.LessThan(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.LessThan(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(tw, indent, "LessThan(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.LessThan(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //LessThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all of the elements in the first vector are less than their corresponding elements in the second vector.
                //LessThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than the corresponding element in the second vector.

                //LessThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than or equal to their corresponding elements in a second double-precision floating-point vector.
                //LessThanOrEqual(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are less than or equal to their corresponding elements in a second integral vector.
                //LessThanOrEqual(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less or equal to their corresponding elements in a second long integer vector.
                //LessThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are less than or equal to their corresponding elements in a second single-precision floating-point vector.
                //LessThanOrEqual<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector are less than or equal to their corresponding elements in the second vector.
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(tw, indent, "LessThanOrEqual(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //LessThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are less than or equal to their corresponding elements in the second vector.
                //LessThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than or equal to the corresponding element in the second vector.

                //Max<T>(Vector<T>, Vector<T>) Returns a new vector whose elements are the maximum of each pair of elements in the two given vectors.
                WriteLine(tw, indent, "Max(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.Max(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(tw, indent, "Max(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.Max(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(tw, indent, "Max(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.Max(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(tw, indent, "Max(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.Max(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(tw, indent, "Max(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.Max(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(tw, indent, "Max(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.Max(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(tw, indent, "Max(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.Max(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(tw, indent, "Max(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.Max(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(tw, indent, "Max(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.Max(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(tw, indent, "Max(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.Max(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //Min<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements are the minimum of each pair of elements in the two given vectors.
                WriteLine(tw, indent, "Min(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.Min(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(tw, indent, "Min(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.Min(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(tw, indent, "Min(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.Min(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(tw, indent, "Min(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.Min(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(tw, indent, "Min(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.Min(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(tw, indent, "Min(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.Min(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(tw, indent, "Min(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.Min(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(tw, indent, "Min(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.Min(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(tw, indent, "Min(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.Min(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(tw, indent, "Min(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.Min(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));
                // limit to [0, 255].
                WriteLine(tw, indent, "Vector.Min(Vector.Max(Vectors<Single>.Demo, Vectors<Single>.V0), Vectors<Single>.V255)):\t{0}", Vector.Min(Vector.Max(Vectors<Single>.Demo, Vectors<Single>.V0), Vectors<Single>.V255));

                //Multiply<T>(T, Vector<T>)   Returns a new vector whose values are a scalar value multiplied by each of the values of a specified vector.
                //Multiply<T>(Vector<T>, T) Returns a new vector whose values are the values of a specified vector each multiplied by a scalar value.
                //Multiply<T>(Vector<T>, Vector<T>)   Returns a new vector whose values are the product of each pair of elements in two specified vectors.
                WriteLine(tw, indent, "Multiply(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Multiply(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Multiply(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Multiply(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Multiply(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Multiply(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Multiply(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Multiply(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Multiply(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Multiply(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(tw, indent, "Multiply(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Multiply(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

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

                //Negate<T>(Vector<T>) Returns a new vector whose elements are the negation of the corresponding element in the specified vector.
                WriteLine(tw, indent, "Negate(Vectors<Single>.Demo):\t{0}", Vector.Negate(Vectors<Single>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<Double>.Demo):\t{0}", Vector.Negate(Vectors<Double>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<SByte>.Demo):\t{0}", Vector.Negate(Vectors<SByte>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<Byte>.Demo):\t{0}", Vector.Negate(Vectors<Byte>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<Int16>.Demo):\t{0}", Vector.Negate(Vectors<Int16>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<UInt16>.Demo):\t{0}", Vector.Negate(Vectors<UInt16>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<Int32>.Demo):\t{0}", Vector.Negate(Vectors<Int32>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<UInt32>.Demo):\t{0}", Vector.Negate(Vectors<UInt32>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<Int64>.Demo):\t{0}", Vector.Negate(Vectors<Int64>.Demo));
                WriteLine(tw, indent, "Negate(Vectors<UInt64>.Demo):\t{0}", Vector.Negate(Vectors<UInt64>.Demo));

                //OnesComplement<T>(Vector<T>) Returns a new vector whose elements are obtained by taking the one's complement of a specified vector's elements.
                WriteLine(tw, indent, "OnesComplement(Vectors<Single>.Demo):\t{0}", Vector.OnesComplement(Vectors<Single>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<Double>.Demo):\t{0}", Vector.OnesComplement(Vectors<Double>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<SByte>.Demo):\t{0}", Vector.OnesComplement(Vectors<SByte>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<Byte>.Demo):\t{0}", Vector.OnesComplement(Vectors<Byte>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<Int16>.Demo):\t{0}", Vector.OnesComplement(Vectors<Int16>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<UInt16>.Demo):\t{0}", Vector.OnesComplement(Vectors<UInt16>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<Int32>.Demo):\t{0}", Vector.OnesComplement(Vectors<Int32>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<UInt32>.Demo):\t{0}", Vector.OnesComplement(Vectors<UInt32>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<Int64>.Demo):\t{0}", Vector.OnesComplement(Vectors<Int64>.Demo));
                WriteLine(tw, indent, "OnesComplement(Vectors<UInt64>.Demo):\t{0}", Vector.OnesComplement(Vectors<UInt64>.Demo));

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
                int shift = 4;
                WriteLine(tw, indent, "ShiftLeft(Vectors<SByte>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<SByte>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<Byte>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<Byte>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<Int16>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<Int16>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<UInt16>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<UInt16>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<Int32>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<Int32>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<UInt32>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<UInt32>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<Int64>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<Int64>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<UInt64>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<UInt64>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<IntPtr>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<IntPtr>.Demo, shift));
                WriteLine(tw, indent, "ShiftLeft(Vectors<UIntPtr>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<UIntPtr>.Demo, shift));

                //ShiftRightArithmetic(Vector<Int16>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                //ShiftRightArithmetic(Vector<Int32>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                //ShiftRightArithmetic(Vector<Int64>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                //ShiftRightArithmetic(Vector<IntPtr>, Int32) Shifts(signed) each element of a vector right by the specified amount.
                //ShiftRightArithmetic(Vector<SByte>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                WriteLine(tw, indent, "ShiftRightArithmetic(Vectors<SByte>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<SByte>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightArithmetic(Vectors<Int16>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<Int16>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightArithmetic(Vectors<Int32>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<Int32>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightArithmetic(Vectors<Int64>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<Int64>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightArithmetic(Vectors<IntPtr>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<IntPtr>.Demo, shift));

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
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<SByte>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<SByte>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<Byte>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<Byte>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<Int16>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<Int16>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<UInt16>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<UInt16>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<Int32>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<Int32>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<UInt32>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<UInt32>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<Int64>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<Int64>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<UInt64>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<UInt64>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<IntPtr>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<IntPtr>.Demo, shift));
                WriteLine(tw, indent, "ShiftRightLogical(Vectors<UIntPtr>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<UIntPtr>.Demo, shift));
#endif // NET7_0_OR_GREATER

                //SquareRoot<T>(Vector<T>)    Returns a new vector whose elements are the square roots of a specified vector's elements.
                WriteLine(tw, indent, "SquareRoot(Vectors<Single>.Demo):\t{0}", Vector.SquareRoot(Vectors<Single>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<Double>.Demo):\t{0}", Vector.SquareRoot(Vectors<Double>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<SByte>.Demo):\t{0}", Vector.SquareRoot(Vectors<SByte>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<Byte>.Demo):\t{0}", Vector.SquareRoot(Vectors<Byte>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<Int16>.Demo):\t{0}", Vector.SquareRoot(Vectors<Int16>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<UInt16>.Demo):\t{0}", Vector.SquareRoot(Vectors<UInt16>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<Int32>.Demo):\t{0}", Vector.SquareRoot(Vectors<Int32>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<UInt32>.Demo):\t{0}", Vector.SquareRoot(Vectors<UInt32>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<Int64>.Demo):\t{0}", Vector.SquareRoot(Vectors<Int64>.Demo));
                WriteLine(tw, indent, "SquareRoot(Vectors<UInt64>.Demo):\t{0}", Vector.SquareRoot(Vectors<UInt64>.Demo));

                //Subtract<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the difference between the elements in the second vector and their corresponding elements in the first vector.
                WriteLine(tw, indent, "Subtract(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Subtract(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Subtract(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Subtract(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Subtract(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Subtract(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Subtract(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Subtract(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Subtract(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Subtract(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(tw, indent, "Subtract(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Subtract(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

#if NET6_0_OR_GREATER
                //Sum<T>(Vector<T>) Returns the sum of all the elements inside the specified vector.
                WriteLine(tw, indent, "Sum(Vectors<Single>.Demo):\t{0}", Vector.Sum(Vectors<Single>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<Double>.Demo):\t{0}", Vector.Sum(Vectors<Double>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<SByte>.Demo):\t{0}", Vector.Sum(Vectors<SByte>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<Byte>.Demo):\t{0}", Vector.Sum(Vectors<Byte>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<Int16>.Demo):\t{0}", Vector.Sum(Vectors<Int16>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<UInt16>.Demo):\t{0}", Vector.Sum(Vectors<UInt16>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<Int32>.Demo):\t{0}", Vector.Sum(Vectors<Int32>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<UInt32>.Demo):\t{0}", Vector.Sum(Vectors<UInt32>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<Int64>.Demo):\t{0}", Vector.Sum(Vectors<Int64>.Demo));
                WriteLine(tw, indent, "Sum(Vectors<UInt64>.Demo):\t{0}", Vector.Sum(Vectors<UInt64>.Demo));
#endif // NET6_0_OR_GREATER

                //Widen(Vector<Byte>, Vector<UInt16>, Vector<UInt16>) Widens aVector<Byte> into two Vector<UInt16>instances.
                //Widen(Vector<Int16>, Vector<Int32>, Vector<Int32>) Widens a Vector<Int16> into twoVector<Int32> instances.
                //Widen(Vector<Int32>, Vector<Int64>, Vector<Int64>) Widens a Vector<Int32> into twoVector<Int64> instances.
                //Widen(Vector<SByte>, Vector<Int16>, Vector<Int16>) Widens a Vector<SByte> into twoVector<Int16> instances.
                //Widen(Vector<Single>, Vector<Double>, Vector<Double>) Widens a Vector<Single> into twoVector<Double> instances.
                //Widen(Vector<UInt16>, Vector<UInt32>, Vector<UInt32>) Widens a Vector<UInt16> into twoVector<UInt32> instances.
                //Widen(Vector<UInt32>, Vector<UInt64>, Vector<UInt64>) Widens a Vector<UInt32> into twoVector<UInt64> instances.
                // Debugger.Break();
                if (true) {
                    Vector.Widen(Vectors<Single>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<Single>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<SByte>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<SByte>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<Byte>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<Byte>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<Int16>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<Int16>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<UInt16>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<UInt16>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<Int32>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<Int32>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<UInt32>.Demo, out var low, out var high);
                    WriteLine(tw, indent, "Widen(Vectors<UInt32>.Demo):\t{0}, {1}", low, high);
                }

                //Xor<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise exclusive Or(XOr) operation on each pair of elements in two vectors.
                WriteLine(tw, indent, "Xor(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask):\t{0}", Vector.Xor(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask):\t{0}", Vector.Xor(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask):\t{0}", Vector.Xor(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask));
                WriteLine(tw, indent, "Xor(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask):\t{0}", Vector.Xor(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask));

            } // unchecked

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
