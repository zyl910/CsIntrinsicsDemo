using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Zyl.VectorTraits;

namespace IntrinsicsLib {
    partial class IntrinsicsDemo {

        /// <summary>
        /// Run vector start.
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunVectorStart(TextWriter writer, string indent) {
            try {
                RunVector(writer, indent);
            } catch (Exception ex) {
                writer.WriteLine("RunVector fail! " + ex.ToString());
            }
            try {
                RunVector64(writer, indent);
            } catch (Exception ex) {
                writer.WriteLine("RunVector64 fail! " + ex.ToString());
            }
            try {
                RunVector128(writer, indent);
            } catch (Exception ex) {
                writer.WriteLine("RunVector128 fail! " + ex.ToString());
            }
            try {
                RunVector256(writer, indent);
            } catch (Exception ex) {
                writer.WriteLine("RunVector256 fail! " + ex.ToString());
            }
        }

        /// <summary>
        /// Run Vector. https://learn.microsoft.com/zh-cn/dotnet/api/system.numerics.vector?view=net-7.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            //bool isAllow = Vector.IsHardwareAccelerated;
            bool isAllow = true;
            if (isAllow) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Vector.IsSupported:\t{0}", Vector.IsHardwareAccelerated));
            if (!isAllow) {
                return;
            }

            // Count.
            writer.WriteLine(indent + string.Format("Vector<Single>.Count:\t{0}", Vector<Single>.Count));
            writer.WriteLine(indent + string.Format("Vector<Double>.Count:\t{0}", Vector<Double>.Count));
            writer.WriteLine(indent + string.Format("Vector<SByte>.Count:\t{0}", Vector<SByte>.Count));
            writer.WriteLine(indent + string.Format("Vector<Byte>.Count:\t{0}", Vector<Byte>.Count));
            writer.WriteLine(indent + string.Format("Vector<Int16>.Count:\t{0}", Vector<Int16>.Count));
            writer.WriteLine(indent + string.Format("Vector<UInt16>.Count:\t{0}", Vector<UInt16>.Count));
            writer.WriteLine(indent + string.Format("Vector<Int32>.Count:\t{0}", Vector<Int32>.Count));
            writer.WriteLine(indent + string.Format("Vector<UInt32>.Count:\t{0}", Vector<UInt32>.Count));
            writer.WriteLine(indent + string.Format("Vector<Int64>.Count:\t{0}", Vector<Int64>.Count));
            writer.WriteLine(indent + string.Format("Vector<UInt64>.Count:\t{0}", Vector<UInt64>.Count));
#if NET6_0_OR_GREATER
            writer.WriteLine(indent + string.Format("Vector<IntPtr>.Count:\t{0}", Vector<IntPtr>.Count));
            writer.WriteLine(indent + string.Format("Vector<UIntPtr>.Count:\t{0}", Vector<UIntPtr>.Count));
            // Unhandled exception. System.NotSupportedException: Specified type is not supported
            //writer.WriteLine(indent + string.Format("Vector<Half>.Count:\t{0}", Vector<Half>.Count));
#endif // NET6_0_OR_GREATER

            // -- Methods --
            unchecked {
                //Debugger.Break();
                //Abs<T>(Vector<T>) Returns a new vector whose elements are the absolute values of the given vector's elements.
                WriteLine(writer, indent, "Abs(Vectors<Single>.Demo):\t{0}", Vector.Abs(Vectors<Single>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<Double>.Demo):\t{0}", Vector.Abs(Vectors<Double>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<SByte>.Demo):\t{0}", Vector.Abs(Vectors<SByte>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<Byte>.Demo):\t{0}", Vector.Abs(Vectors<Byte>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<Int16>.Demo):\t{0}", Vector.Abs(Vectors<Int16>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<UInt16>.Demo):\t{0}", Vector.Abs(Vectors<UInt16>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<Int32>.Demo):\t{0}", Vector.Abs(Vectors<Int32>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<UInt32>.Demo):\t{0}", Vector.Abs(Vectors<UInt32>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<Int64>.Demo):\t{0}", Vector.Abs(Vectors<Int64>.Demo));
                WriteLine(writer, indent, "Abs(Vectors<UInt64>.Demo):\t{0}", Vector.Abs(Vectors<UInt64>.Demo));

                //Add<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the sum of each pair of elements from writero given vectors.
                WriteLine(writer, indent, "Add(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Add(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(writer, indent, "Add(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Add(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(writer, indent, "Add(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Add(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(writer, indent, "Add(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Add(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(writer, indent, "Add(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Add(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(writer, indent, "Add(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Add(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(writer, indent, "Add(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Add(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(writer, indent, "Add(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Add(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(writer, indent, "Add(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Add(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(writer, indent, "Add(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Add(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

                //AndNot<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise And Not operation on each pair of corresponding elements in writero vectors.
                WriteLine(writer, indent, "AndNot(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask):\t{0}", Vector.AndNot(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask));

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

                //BitwiseAnd<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise Andoperation on each pair of elements in writero vectors.
                WriteLine(writer, indent, "BitwiseAnd(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask):\t{0}", Vector.BitwiseAnd(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask));

                //BitwiseOr<T>(Vector<T>, Vector<T>)  Returns a new vector by performing a bitwise Oroperation on each pair of elements in writero vectors.
                WriteLine(writer, indent, "BitwiseOr(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask):\t{0}", Vector.BitwiseOr(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask));

#if NET5_0_OR_GREATER
                //Ceiling(Vector<Double>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
                //Ceiling(Vector<Single>) Returns a new vector whose elements are the smallest integral values that are greater than or equal to the given vector's elements.
                WriteLine(writer, indent, "Ceiling(Vectors<Single>.Demo):\t{0}", Vector.Ceiling(Vectors<Single>.Demo));
                WriteLine(writer, indent, "Ceiling(Vectors<Double>.Demo):\t{0}", Vector.Ceiling(Vectors<Double>.Demo));
#endif // NET5_0_OR_GREATER

                //ConditionalSelect(Vector<Int32>, Vector<Single>, Vector<Single>)    Creates a new single-precision vector with elements selected between writero specified single-precision source vectors based on an integral mask vector.
                //ConditionalSelect(Vector<Int64>, Vector<Double>, Vector<Double>) Creates a new double-precision vector with elements selected between writero specified double-precision source vectors based on an integral mask vector.
                //ConditionalSelect<T>(Vector<T>, Vector<T>, Vector<T>) Creates a new vector of a specified type with elements selected between writero specified source vectors of the same type based on an integral mask vector.
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
                WriteLine(writer, indent, "ConditionalSelect(Vectors<Single>.XyzwWMask, Vectors<Single>.Demo, Vectors<Single>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Single>.XyzwWMask, Vectors<Single>.Demo, Vectors<Single>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<Double>.XyzwWMask, Vectors<Double>.Demo, Vectors<Double>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Double>.XyzwWMask, Vectors<Double>.Demo, Vectors<Double>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<SByte>.XyzwWMask, Vectors<SByte>.Demo, Vectors<SByte>.V7):\t{0}", Vector.ConditionalSelect(Vectors<SByte>.XyzwWMask, Vectors<SByte>.Demo, Vectors<SByte>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<Byte>.XyzwWMask, Vectors<Byte>.Demo, Vectors<Byte>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Byte>.XyzwWMask, Vectors<Byte>.Demo, Vectors<Byte>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<Int16>.XyzwWMask, Vectors<Int16>.Demo, Vectors<Int16>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Int16>.XyzwWMask, Vectors<Int16>.Demo, Vectors<Int16>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<UInt16>.XyzwWMask, Vectors<UInt16>.Demo, Vectors<UInt16>.V7):\t{0}", Vector.ConditionalSelect(Vectors<UInt16>.XyzwWMask, Vectors<UInt16>.Demo, Vectors<UInt16>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<Int32>.XyzwWMask, Vectors<Int32>.Demo, Vectors<Int32>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Int32>.XyzwWMask, Vectors<Int32>.Demo, Vectors<Int32>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<UInt32>.XyzwWMask, Vectors<UInt32>.Demo, Vectors<UInt32>.V7):\t{0}", Vector.ConditionalSelect(Vectors<UInt32>.XyzwWMask, Vectors<UInt32>.Demo, Vectors<UInt32>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<Int64>.XyzwWMask, Vectors<Int64>.Demo, Vectors<Int64>.V7):\t{0}", Vector.ConditionalSelect(Vectors<Int64>.XyzwWMask, Vectors<Int64>.Demo, Vectors<Int64>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vectors<UInt64>.XyzwWMask, Vectors<UInt64>.Demo, Vectors<UInt64>.V7):\t{0}", Vector.ConditionalSelect(Vectors<UInt64>.XyzwWMask, Vectors<UInt64>.Demo, Vectors<UInt64>.V7));

                //ConvertToDouble(Vector<Int64>) Converts a Vector<Int64>to aVector<Double>.
                //ConvertToDouble(Vector<UInt64>) Converts a Vector<UInt64> to aVector<Double>.
                //ConvertToInt32(Vector<Single>) Converts a Vector<Single> to aVector<Int32>.
                //ConvertToInt64(Vector<Double>) Converts a Vector<Double> to aVector<Int64>.
                //ConvertToSingle(Vector<Int32>) Converts a Vector<Int32> to aVector<Single>.
                //ConvertToSingle(Vector<UInt32>) Converts a Vector<UInt32> to aVector<Single>.
                //ConvertToUInt32(Vector<Single>) Converts a Vector<Single> to aVector<UInt32>.
                //ConvertToUInt64(Vector<Double>) Converts a Vector<Double> to aVector<UInt64>.
                // Infinity or NaN -> IntTypes.MinValue .
                WriteLine(writer, indent, "ConvertToDouble(Vectors<Int64>.Demo):\t{0}", Vector.ConvertToDouble(Vectors<Int64>.Demo));
                WriteLine(writer, indent, "ConvertToDouble(Vectors<UInt64>.Demo):\t{0}", Vector.ConvertToDouble(Vectors<UInt64>.Demo));
                WriteLine(writer, indent, "ConvertToInt32(Vectors<Single>.Demo):\t{0}", Vector.ConvertToInt32(Vectors<Single>.Demo));
                WriteLine(writer, indent, "ConvertToInt64(Vectors<Double>.Demo):\t{0}", Vector.ConvertToInt64(Vectors<Double>.Demo));
                WriteLine(writer, indent, "ConvertToSingle(Vectors<Int32>.Demo):\t{0}", Vector.ConvertToSingle(Vectors<Int32>.Demo));
                WriteLine(writer, indent, "ConvertToSingle(Vectors<UInt32>.Demo):\t{0}", Vector.ConvertToSingle(Vectors<UInt32>.Demo));
                WriteLine(writer, indent, "ConvertToUInt32(Vectors<Single>.Demo):\t{0}", Vector.ConvertToUInt32(Vectors<Single>.Demo));
                WriteLine(writer, indent, "ConvertToUInt64(Vectors<Double>.Demo):\t{0}", Vector.ConvertToUInt64(Vectors<Double>.Demo));

                //Divide<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the result of dividing the first vector's elements by the corresponding elements in the second vector.
                WriteLine(writer, indent, "Divide(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Divide(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(writer, indent, "Divide(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Divide(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(writer, indent, "Divide(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Divide(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(writer, indent, "Divide(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Divide(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(writer, indent, "Divide(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Divide(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(writer, indent, "Divide(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Divide(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(writer, indent, "Divide(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Divide(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(writer, indent, "Divide(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Divide(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(writer, indent, "Divide(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Divide(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(writer, indent, "Divide(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Divide(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

                //Dot<T>(Vector<T>, Vector<T>) Returns the dot product of writero vectors.
                WriteLine(writer, indent, "Dot(Vectors<Int32>.V1, Vectors<Int32>.V2):\t{0}", Vector.Dot(Vectors<Int32>.V1, Vectors<Int32>.V2)); // 1*2*Vector<T>.Count
                WriteLine(writer, indent, "Dot(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Dot(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(writer, indent, "Dot(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Dot(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(writer, indent, "Dot(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Dot(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(writer, indent, "Dot(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Dot(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(writer, indent, "Dot(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Dot(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(writer, indent, "Dot(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Dot(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(writer, indent, "Dot(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Dot(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(writer, indent, "Dot(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Dot(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(writer, indent, "Dot(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Dot(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(writer, indent, "Dot(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Dot(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

                //Equals(Vector<Double>, Vector<Double>)  Returns a new integral vector whose elements signal whether the elements in writero specified double-precision vectors are equal.
                //Equals(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in writero specified integral vectors are equal.
                //Equals(Vector<Int64>, Vector<Int64>)    Returns a new vector whose elements signal whether the elements in writero specified long integer vectors are equal.
                //Equals(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in writero specified single-precision vectors are equal.
                //Equals<T>(Vector<T>, Vector<T>) Returns a new vector of a specified type whose elements signal whether the elements in writero specified vectors of the same type are equal.
                WriteLine(writer, indent, "Equals(Vectors<Single>.Demo, Vectors<Single>.MinValue):\t{0}", Vector.Equals(Vectors<Single>.Demo, Vectors<Single>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<Double>.Demo, Vectors<Double>.MinValue):\t{0}", Vector.Equals(Vectors<Double>.Demo, Vectors<Double>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<SByte>.Demo, Vectors<SByte>.MinValue):\t{0}", Vector.Equals(Vectors<SByte>.Demo, Vectors<SByte>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<Byte>.Demo, Vectors<Byte>.MinValue):\t{0}", Vector.Equals(Vectors<Byte>.Demo, Vectors<Byte>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<Int16>.Demo, Vectors<Int16>.MinValue):\t{0}", Vector.Equals(Vectors<Int16>.Demo, Vectors<Int16>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<UInt16>.Demo, Vectors<UInt16>.MinValue):\t{0}", Vector.Equals(Vectors<UInt16>.Demo, Vectors<UInt16>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<Int32>.Demo, Vectors<Int32>.MinValue):\t{0}", Vector.Equals(Vectors<Int32>.Demo, Vectors<Int32>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<UInt32>.Demo, Vectors<UInt32>.MinValue):\t{0}", Vector.Equals(Vectors<UInt32>.Demo, Vectors<UInt32>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<Int64>.Demo, Vectors<Int64>.MinValue):\t{0}", Vector.Equals(Vectors<Int64>.Demo, Vectors<Int64>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<UInt64>.Demo, Vectors<UInt64>.MinValue):\t{0}", Vector.Equals(Vectors<UInt64>.Demo, Vectors<UInt64>.MinValue));
                WriteLine(writer, indent, "Equals(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.Equals(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(writer, indent, "Equals(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.Equals(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(writer, indent, "Equals(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.Equals(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(writer, indent, "Equals(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.Equals(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(writer, indent, "Equals(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.Equals(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(writer, indent, "Equals(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.Equals(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(writer, indent, "Equals(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.Equals(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(writer, indent, "Equals(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.Equals(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(writer, indent, "Equals(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.Equals(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(writer, indent, "Equals(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.Equals(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //EqualsAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether each pair of elements in the given vectors is equal.
                WriteLine(writer, indent, "EqualsAll(Vectors<Single>.Demo, Vectors<Single>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Single>.Demo, Vectors<Single>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<Double>.Demo, Vectors<Double>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Double>.Demo, Vectors<Double>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<SByte>.Demo, Vectors<SByte>.MinValue):\t{0}", Vector.EqualsAll(Vectors<SByte>.Demo, Vectors<SByte>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<Byte>.Demo, Vectors<Byte>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Byte>.Demo, Vectors<Byte>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<Int16>.Demo, Vectors<Int16>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Int16>.Demo, Vectors<Int16>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<UInt16>.Demo, Vectors<UInt16>.MinValue):\t{0}", Vector.EqualsAll(Vectors<UInt16>.Demo, Vectors<UInt16>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<Int32>.Demo, Vectors<Int32>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Int32>.Demo, Vectors<Int32>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<UInt32>.Demo, Vectors<UInt32>.MinValue):\t{0}", Vector.EqualsAll(Vectors<UInt32>.Demo, Vectors<UInt32>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<Int64>.Demo, Vectors<Int64>.MinValue):\t{0}", Vector.EqualsAll(Vectors<Int64>.Demo, Vectors<Int64>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vectors<UInt64>.Demo, Vectors<UInt64>.MinValue):\t{0}", Vector.EqualsAll(Vectors<UInt64>.Demo, Vectors<UInt64>.MinValue));

                //EqualsAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any single pair of elements in the given vectors is equal.
                WriteLine(writer, indent, "EqualsAny(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.EqualsAny(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.EqualsAny(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.EqualsAny(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.EqualsAny(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.EqualsAny(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.EqualsAny(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.EqualsAny(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.EqualsAny(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.EqualsAny(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(writer, indent, "EqualsAny(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.EqualsAny(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

#if NET5_0_OR_GREATER
                //Floor(Vector<Double>) Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
                //Floor(Vector<Single>)   Returns a new vector whose elements are the largest integral values that are less than or equal to the given vector's elements.
                WriteLine(writer, indent, "Floor(Vectors<Single>.Demo):\t{0}", Vector.Floor(Vectors<Single>.Demo));
                WriteLine(writer, indent, "Floor(Vectors<Double>.Demo):\t{0}", Vector.Floor(Vectors<Double>.Demo));
#endif // NET5_0_OR_GREATER

                //GreaterThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are greater than their corresponding elements in a second double-precision floating-point vector.
                //GreaterThan(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than their corresponding elements in a second integral vector.
                //GreaterThan(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than their corresponding elements in a second long integer vector.
                //GreaterThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are greater than their corresponding elements in a second single-precision floating-point vector.
                //GreaterThan<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than their corresponding elements in the second vector of the same time.
                WriteLine(writer, indent, "GreaterThan(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.GreaterThan(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.GreaterThan(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.GreaterThan(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.GreaterThan(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.GreaterThan(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.GreaterThan(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.GreaterThan(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.GreaterThan(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.GreaterThan(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(writer, indent, "GreaterThan(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.GreaterThan(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //GreaterThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than the corresponding elements in the second vector.
                //GreaterThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than the corresponding element in the second vector.

                //GreaterThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the second double-precision floating-point vector.
                //GreaterThanOrEqual(Vector<Int32>, Vector<Int32>)    Returns a new integral vector whose elements signal whether the elements in one integral vector are greater than or equal to their corresponding elements in the second integral vector.
                //GreaterThanOrEqual(Vector<Int64>, Vector<Int64>)    Returns a new long integer vector whose elements signal whether the elements in one long integer vector are greater than or equal to their corresponding elements in the second long integer vector.
                //GreaterThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one vector are greater than or equal to their corresponding elements in the single-precision floating-point second vector.
                //GreaterThanOrEqual<T>(Vector<T>, Vector<T>) Returns a new vector whose elements signal whether the elements in one vector of a specified type are greater than or equal to their corresponding elements in the second vector of the same type.
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.GreaterThanOrEqual(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //GreaterThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are greater than or equal to all the corresponding elements in the second vector.
                //GreaterThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is greater than or equal to the corresponding element in the second vector.

                //LessThan(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than their corresponding elements in a second double-precision floating-point vector.
                //LessThan(Vector<Int32>, Vector<Int32>)  Returns a new integral vector whose elements signal whether the elements in one integral vector are less than their corresponding elements in a second integral vector.
                //LessThan(Vector<Int64>, Vector<Int64>)  Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less than their corresponding elements in a second long integer vector.
                //LessThan(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision vector are less than their corresponding elements in a second single-precision vector.
                //LessThan<T>(Vector<T>, Vector<T>)   Returns a new vector of a specified type whose elements signal whether the elements in one vector are less than their corresponding elements in the second vector.
                WriteLine(writer, indent, "LessThan(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.LessThan(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.LessThan(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.LessThan(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.LessThan(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.LessThan(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.LessThan(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.LessThan(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.LessThan(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.LessThan(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(writer, indent, "LessThan(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.LessThan(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //LessThanAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all of the elements in the first vector are less than their corresponding elements in the second vector.
                //LessThanAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than the corresponding element in the second vector.

                //LessThanOrEqual(Vector<Double>, Vector<Double>) Returns a new integral vector whose elements signal whether the elements in one double-precision floating-point vector are less than or equal to their corresponding elements in a second double-precision floating-point vector.
                //LessThanOrEqual(Vector<Int32>, Vector<Int32>)   Returns a new integral vector whose elements signal whether the elements in one integral vector are less than or equal to their corresponding elements in a second integral vector.
                //LessThanOrEqual(Vector<Int64>, Vector<Int64>)   Returns a new long integer vector whose elements signal whether the elements in one long integer vector are less or equal to their corresponding elements in a second long integer vector.
                //LessThanOrEqual(Vector<Single>, Vector<Single>) Returns a new integral vector whose elements signal whether the elements in one single-precision floating-point vector are less than or equal to their corresponding elements in a second single-precision floating-point vector.
                //LessThanOrEqual<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements signal whether the elements in one vector are less than or equal to their corresponding elements in the second vector.
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.LessThanOrEqual(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //LessThanOrEqualAll<T>(Vector<T>, Vector<T>) Returns a value that indicates whether all elements in the first vector are less than or equal to their corresponding elements in the second vector.
                //LessThanOrEqualAny<T>(Vector<T>, Vector<T>) Returns a value that indicates whether any element in the first vector is less than or equal to the corresponding element in the second vector.

                //Max<T>(Vector<T>, Vector<T>) Returns a new vector whose elements are the maximum of each pair of elements in the writero given vectors.
                WriteLine(writer, indent, "Max(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.Max(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(writer, indent, "Max(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.Max(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(writer, indent, "Max(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.Max(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(writer, indent, "Max(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.Max(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(writer, indent, "Max(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.Max(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(writer, indent, "Max(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.Max(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(writer, indent, "Max(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.Max(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(writer, indent, "Max(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.Max(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(writer, indent, "Max(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.Max(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(writer, indent, "Max(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.Max(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));

                //Min<T>(Vector<T>, Vector<T>)    Returns a new vector whose elements are the minimum of each pair of elements in the writero given vectors.
                WriteLine(writer, indent, "Min(Vectors<Single>.Demo, Vectors<Single>.V0):\t{0}", Vector.Min(Vectors<Single>.Demo, Vectors<Single>.V0));
                WriteLine(writer, indent, "Min(Vectors<Double>.Demo, Vectors<Double>.V0):\t{0}", Vector.Min(Vectors<Double>.Demo, Vectors<Double>.V0));
                WriteLine(writer, indent, "Min(Vectors<SByte>.Demo, Vectors<SByte>.V0):\t{0}", Vector.Min(Vectors<SByte>.Demo, Vectors<SByte>.V0));
                WriteLine(writer, indent, "Min(Vectors<Byte>.Demo, Vectors<Byte>.V0):\t{0}", Vector.Min(Vectors<Byte>.Demo, Vectors<Byte>.V0));
                WriteLine(writer, indent, "Min(Vectors<Int16>.Demo, Vectors<Int16>.V0):\t{0}", Vector.Min(Vectors<Int16>.Demo, Vectors<Int16>.V0));
                WriteLine(writer, indent, "Min(Vectors<UInt16>.Demo, Vectors<UInt16>.V0):\t{0}", Vector.Min(Vectors<UInt16>.Demo, Vectors<UInt16>.V0));
                WriteLine(writer, indent, "Min(Vectors<Int32>.Demo, Vectors<Int32>.V0):\t{0}", Vector.Min(Vectors<Int32>.Demo, Vectors<Int32>.V0));
                WriteLine(writer, indent, "Min(Vectors<UInt32>.Demo, Vectors<UInt32>.V0):\t{0}", Vector.Min(Vectors<UInt32>.Demo, Vectors<UInt32>.V0));
                WriteLine(writer, indent, "Min(Vectors<Int64>.Demo, Vectors<Int64>.V0):\t{0}", Vector.Min(Vectors<Int64>.Demo, Vectors<Int64>.V0));
                WriteLine(writer, indent, "Min(Vectors<UInt64>.Demo, Vectors<UInt64>.V0):\t{0}", Vector.Min(Vectors<UInt64>.Demo, Vectors<UInt64>.V0));
                // limit to [0, 255].
                WriteLine(writer, indent, "Vector.Min(Vector.Max(Vectors<Single>.Demo, Vectors<Single>.V0), Vectors<Single>.VMaxByte)):\t{0}", Vector.Min(Vector.Max(Vectors<Single>.Demo, Vectors<Single>.V0), Vectors<Single>.VMaxByte));

                //Multiply<T>(T, Vector<T>)   Returns a new vector whose values are a scalar value multiplied by each of the values of a specified vector.
                //Multiply<T>(Vector<T>, T) Returns a new vector whose values are the values of a specified vector each multiplied by a scalar value.
                //Multiply<T>(Vector<T>, Vector<T>)   Returns a new vector whose values are the product of each pair of elements in writero specified vectors.
                WriteLine(writer, indent, "Multiply(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Multiply(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Multiply(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Multiply(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Multiply(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Multiply(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Multiply(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Multiply(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Multiply(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Multiply(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(writer, indent, "Multiply(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Multiply(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

                //Narrow(Vector<Double>, Vector<Double>) Narrows writero Vector<Double>instances into one Vector<Single>.
                //Narrow(Vector<Int16>, Vector<Int16>) Narrows writero Vector<Int16> instances into one Vector<SByte>.
                //Narrow(Vector<Int32>, Vector<Int32>) Narrows writero Vector<Int32> instances into one Vector<Int16>.
                //Narrow(Vector<Int64>, Vector<Int64>) Narrows writero Vector<Int64> instances into one Vector<Int32>.
                //Narrow(Vector<UInt16>, Vector<UInt16>) Narrows writero Vector<UInt16> instances into one Vector<Byte>.
                //Narrow(Vector<UInt32>, Vector<UInt32>) Narrows writero Vector<UInt32> instances into one Vector<UInt16>.
                //Narrow(Vector<UInt64>, Vector<UInt64>) Narrows writero Vector<UInt64> instances into one Vector<UInt32>.
                WriteLine(writer, indent, "Narrow(Vectors<Double>.Demo, Vectors<Double>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Double>.Demo, Vectors<Double>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vectors<Int16>.Demo, Vectors<Int16>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Int16>.Demo, Vectors<Int16>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vectors<Int32>.Demo, Vectors<Int32>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Int32>.Demo, Vectors<Int32>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vectors<Int64>.Demo, Vectors<Int64>.SerialNegative):\t{0}", Vector.Narrow(Vectors<Int64>.Demo, Vectors<Int64>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vectors<UInt16>.Demo, Vectors<UInt16>.SerialNegative):\t{0}", Vector.Narrow(Vectors<UInt16>.Demo, Vectors<UInt16>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vectors<UInt32>.Demo, Vectors<UInt32>.SerialNegative):\t{0}", Vector.Narrow(Vectors<UInt32>.Demo, Vectors<UInt32>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vectors<UInt64>.Demo, Vectors<UInt64>.SerialNegative):\t{0}", Vector.Narrow(Vectors<UInt64>.Demo, Vectors<UInt64>.SerialNegative));

                //Negate<T>(Vector<T>) Returns a new vector whose elements are the negation of the corresponding element in the specified vector.
                WriteLine(writer, indent, "Negate(Vectors<Single>.Demo):\t{0}", Vector.Negate(Vectors<Single>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<Double>.Demo):\t{0}", Vector.Negate(Vectors<Double>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<SByte>.Demo):\t{0}", Vector.Negate(Vectors<SByte>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<Byte>.Demo):\t{0}", Vector.Negate(Vectors<Byte>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<Int16>.Demo):\t{0}", Vector.Negate(Vectors<Int16>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<UInt16>.Demo):\t{0}", Vector.Negate(Vectors<UInt16>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<Int32>.Demo):\t{0}", Vector.Negate(Vectors<Int32>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<UInt32>.Demo):\t{0}", Vector.Negate(Vectors<UInt32>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<Int64>.Demo):\t{0}", Vector.Negate(Vectors<Int64>.Demo));
                WriteLine(writer, indent, "Negate(Vectors<UInt64>.Demo):\t{0}", Vector.Negate(Vectors<UInt64>.Demo));

                //OnesComplement<T>(Vector<T>) Returns a new vector whose elements are obtained by taking the one's complement of a specified vector's elements.
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<Single>.Demo):\t{0}", Vector.OnesComplement(Vectors<Single>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<Double>.Demo):\t{0}", Vector.OnesComplement(Vectors<Double>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<SByte>.Demo):\t{0}", Vector.OnesComplement(Vectors<SByte>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<Byte>.Demo):\t{0}", Vector.OnesComplement(Vectors<Byte>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<Int16>.Demo):\t{0}", Vector.OnesComplement(Vectors<Int16>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<UInt16>.Demo):\t{0}", Vector.OnesComplement(Vectors<UInt16>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<Int32>.Demo):\t{0}", Vector.OnesComplement(Vectors<Int32>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<UInt32>.Demo):\t{0}", Vector.OnesComplement(Vectors<UInt32>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<Int64>.Demo):\t{0}", Vector.OnesComplement(Vectors<Int64>.Demo));
                WriteLine(writer, indent, "BaseOnesComplement(Vectors<UInt64>.Demo):\t{0}", Vector.OnesComplement(Vectors<UInt64>.Demo));

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
                WriteLine(writer, indent, "ShiftLeft(Vectors<SByte>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<SByte>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<Byte>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<Byte>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<Int16>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<Int16>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<UInt16>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<UInt16>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<Int32>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<Int32>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<UInt32>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<UInt32>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<Int64>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<Int64>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<UInt64>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<UInt64>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<IntPtr>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<IntPtr>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vectors<UIntPtr>.Demo, shift):\t{0}", Vector.ShiftLeft(Vectors<UIntPtr>.Demo, shift));

                //ShiftRightArithmetic(Vector<Int16>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                //ShiftRightArithmetic(Vector<Int32>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                //ShiftRightArithmetic(Vector<Int64>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                //ShiftRightArithmetic(Vector<IntPtr>, Int32) Shifts(signed) each element of a vector right by the specified amount.
                //ShiftRightArithmetic(Vector<SByte>, Int32)  Shifts(signed) each element of a vector right by the specified amount.
                WriteLine(writer, indent, "ShiftRightArithmetic(Vectors<SByte>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<SByte>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightArithmetic(Vectors<Int16>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<Int16>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightArithmetic(Vectors<Int32>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<Int32>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightArithmetic(Vectors<Int64>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<Int64>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightArithmetic(Vectors<IntPtr>.Demo, shift):\t{0}", Vector.ShiftRightArithmetic(Vectors<IntPtr>.Demo, shift));

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
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<SByte>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<SByte>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<Byte>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<Byte>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<Int16>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<Int16>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<UInt16>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<UInt16>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<Int32>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<Int32>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<UInt32>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<UInt32>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<Int64>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<Int64>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<UInt64>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<UInt64>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<IntPtr>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<IntPtr>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vectors<UIntPtr>.Demo, shift):\t{0}", Vector.ShiftRightLogical(Vectors<UIntPtr>.Demo, shift));
#endif // NET7_0_OR_GREATER

                //SquareRoot<T>(Vector<T>)    Returns a new vector whose elements are the square roots of a specified vector's elements.
                WriteLine(writer, indent, "SquareRoot(Vectors<Single>.Demo):\t{0}", Vector.SquareRoot(Vectors<Single>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<Double>.Demo):\t{0}", Vector.SquareRoot(Vectors<Double>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<SByte>.Demo):\t{0}", Vector.SquareRoot(Vectors<SByte>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<Byte>.Demo):\t{0}", Vector.SquareRoot(Vectors<Byte>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<Int16>.Demo):\t{0}", Vector.SquareRoot(Vectors<Int16>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<UInt16>.Demo):\t{0}", Vector.SquareRoot(Vectors<UInt16>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<Int32>.Demo):\t{0}", Vector.SquareRoot(Vectors<Int32>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<UInt32>.Demo):\t{0}", Vector.SquareRoot(Vectors<UInt32>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<Int64>.Demo):\t{0}", Vector.SquareRoot(Vectors<Int64>.Demo));
                WriteLine(writer, indent, "SquareRoot(Vectors<UInt64>.Demo):\t{0}", Vector.SquareRoot(Vectors<UInt64>.Demo));

                //Subtract<T>(Vector<T>, Vector<T>) Returns a new vector whose values are the difference between the elements in the second vector and their corresponding elements in the first vector.
                WriteLine(writer, indent, "Subtract(Vectors<Single>.Demo, Vectors<Single>.V2):\t{0}", Vector.Subtract(Vectors<Single>.Demo, Vectors<Single>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<Double>.Demo, Vectors<Double>.V2):\t{0}", Vector.Subtract(Vectors<Double>.Demo, Vectors<Double>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<SByte>.Demo, Vectors<SByte>.V2):\t{0}", Vector.Subtract(Vectors<SByte>.Demo, Vectors<SByte>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<Byte>.Demo, Vectors<Byte>.V2):\t{0}", Vector.Subtract(Vectors<Byte>.Demo, Vectors<Byte>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<Int16>.Demo, Vectors<Int16>.V2):\t{0}", Vector.Subtract(Vectors<Int16>.Demo, Vectors<Int16>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<UInt16>.Demo, Vectors<UInt16>.V2):\t{0}", Vector.Subtract(Vectors<UInt16>.Demo, Vectors<UInt16>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<Int32>.Demo, Vectors<Int32>.V2):\t{0}", Vector.Subtract(Vectors<Int32>.Demo, Vectors<Int32>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<UInt32>.Demo, Vectors<UInt32>.V2):\t{0}", Vector.Subtract(Vectors<UInt32>.Demo, Vectors<UInt32>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<Int64>.Demo, Vectors<Int64>.V2):\t{0}", Vector.Subtract(Vectors<Int64>.Demo, Vectors<Int64>.V2));
                WriteLine(writer, indent, "Subtract(Vectors<UInt64>.Demo, Vectors<UInt64>.V2):\t{0}", Vector.Subtract(Vectors<UInt64>.Demo, Vectors<UInt64>.V2));

#if NET6_0_OR_GREATER
                //Sum<T>(Vector<T>) Returns the sum of all the elements inside the specified vector.
                WriteLine(writer, indent, "Sum(Vectors<Single>.Demo):\t{0}", Vector.Sum(Vectors<Single>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<Double>.Demo):\t{0}", Vector.Sum(Vectors<Double>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<SByte>.Demo):\t{0}", Vector.Sum(Vectors<SByte>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<Byte>.Demo):\t{0}", Vector.Sum(Vectors<Byte>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<Int16>.Demo):\t{0}", Vector.Sum(Vectors<Int16>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<UInt16>.Demo):\t{0}", Vector.Sum(Vectors<UInt16>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<Int32>.Demo):\t{0}", Vector.Sum(Vectors<Int32>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<UInt32>.Demo):\t{0}", Vector.Sum(Vectors<UInt32>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<Int64>.Demo):\t{0}", Vector.Sum(Vectors<Int64>.Demo));
                WriteLine(writer, indent, "Sum(Vectors<UInt64>.Demo):\t{0}", Vector.Sum(Vectors<UInt64>.Demo));
#endif // NET6_0_OR_GREATER

                //Widen(Vector<Byte>, Vector<UInt16>, Vector<UInt16>) Widens aVector<Byte> into writero Vector<UInt16>instances.
                //Widen(Vector<Int16>, Vector<Int32>, Vector<Int32>) Widens a Vector<Int16> into writeroVector<Int32> instances.
                //Widen(Vector<Int32>, Vector<Int64>, Vector<Int64>) Widens a Vector<Int32> into writeroVector<Int64> instances.
                //Widen(Vector<SByte>, Vector<Int16>, Vector<Int16>) Widens a Vector<SByte> into writeroVector<Int16> instances.
                //Widen(Vector<Single>, Vector<Double>, Vector<Double>) Widens a Vector<Single> into writeroVector<Double> instances.
                //Widen(Vector<UInt16>, Vector<UInt32>, Vector<UInt32>) Widens a Vector<UInt16> into writeroVector<UInt32> instances.
                //Widen(Vector<UInt32>, Vector<UInt64>, Vector<UInt64>) Widens a Vector<UInt32> into writeroVector<UInt64> instances.
                // Debugger.Break();
                if (true) {
                    Vector.Widen(Vectors<Single>.Demo, out var low, out var high);
                    WriteLine(writer, indent, "Widen(Vectors<Single>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<SByte>.Demo, out var low, out var high);
                    WriteLine(writer, indent, "Widen(Vectors<SByte>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<Byte>.Demo, out var low, out var high);
                    WriteLine(writer, indent, "Widen(Vectors<Byte>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<Int16>.Demo, out var low, out var high);
                    WriteLine(writer, indent, "Widen(Vectors<Int16>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<UInt16>.Demo, out var low, out var high);
                    WriteLine(writer, indent, "Widen(Vectors<UInt16>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<Int32>.Demo, out var low, out var high);
                    WriteLine(writer, indent, "Widen(Vectors<Int32>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    Vector.Widen(Vectors<UInt32>.Demo, out var low, out var high);
                    WriteLine(writer, indent, "Widen(Vectors<UInt32>.Demo):\t{0}, {1}", low, high);
                }

                //Xor<T>(Vector<T>, Vector<T>) Returns a new vector by performing a bitwise exclusive Or(XOr) operation on each pair of elements in writero vectors.
                WriteLine(writer, indent, "Xor(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Single>.Demo, Vectors<Single>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Double>.Demo, Vectors<Double>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask):\t{0}", Vector.Xor(Vectors<SByte>.Demo, Vectors<SByte>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Byte>.Demo, Vectors<Byte>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Int16>.Demo, Vectors<Int16>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask):\t{0}", Vector.Xor(Vectors<UInt16>.Demo, Vectors<UInt16>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Int32>.Demo, Vectors<Int32>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask):\t{0}", Vector.Xor(Vectors<UInt32>.Demo, Vectors<UInt32>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask):\t{0}", Vector.Xor(Vectors<Int64>.Demo, Vectors<Int64>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask):\t{0}", Vector.Xor(Vectors<UInt64>.Demo, Vectors<UInt64>.XyzwWMask));

            } // unchecked

        }

        /// <summary>
        /// Run Vector64. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.vector64?view=net-7.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector64(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector64.IsHardwareAccelerated) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Vector64.IsSupported:\t{0}", Vector64.IsHardwareAccelerated));
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
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector128(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector128.IsHardwareAccelerated) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Vector128.IsSupported:\t{0}", Vector128.IsHardwareAccelerated));
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
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunVector256(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
#if NET7_0_OR_GREATER
            if (Vector256.IsHardwareAccelerated) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Vector256.IsSupported:\t{0}", Vector256.IsHardwareAccelerated));
            if (!Vector256.IsHardwareAccelerated) {
                return;
            }

            // Count.
            writer.WriteLine(indent + string.Format("Vector256<Single>.Count:\t{0}", Vector256<Single>.Count));
            writer.WriteLine(indent + string.Format("Vector256<Double>.Count:\t{0}", Vector256<Double>.Count));
            writer.WriteLine(indent + string.Format("Vector256<SByte>.Count:\t{0}", Vector256<SByte>.Count));
            writer.WriteLine(indent + string.Format("Vector256<Byte>.Count:\t{0}", Vector256<Byte>.Count));
            writer.WriteLine(indent + string.Format("Vector256<Int16>.Count:\t{0}", Vector256<Int16>.Count));
            writer.WriteLine(indent + string.Format("Vector256<UInt16>.Count:\t{0}", Vector256<UInt16>.Count));
            writer.WriteLine(indent + string.Format("Vector256<Int32>.Count:\t{0}", Vector256<Int32>.Count));
            writer.WriteLine(indent + string.Format("Vector256<UInt32>.Count:\t{0}", Vector256<UInt32>.Count));
            writer.WriteLine(indent + string.Format("Vector256<Int64>.Count:\t{0}", Vector256<Int64>.Count));
            writer.WriteLine(indent + string.Format("Vector256<UInt64>.Count:\t{0}", Vector256<UInt64>.Count));
            writer.WriteLine(indent + string.Format("Vector256<IntPtr>.Count:\t{0}", Vector256<IntPtr>.Count));
            writer.WriteLine(indent + string.Format("Vector256<UIntPtr>.Count:\t{0}", Vector256<UIntPtr>.Count));
            // Unhandled exception. System.NotSupportedException: Specified type is not supported
            //writer.WriteLine(indent + string.Format("Vector256<Half>.Count:\t{0}", Vector256<Half>.Count));

            // -- Methods --
            int shift;
            unchecked {
                //Debugger.Break();
                // Abs<T>(Vector256<T>)	
                // Computes the absolute value of each element in a vector.
                WriteLine(writer, indent, "Abs(Vector256s<Single>.Demo):\t{0}", Vector256.Abs(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<Double>.Demo):\t{0}", Vector256.Abs(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<SByte>.Demo):\t{0}", Vector256.Abs(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<Byte>.Demo):\t{0}", Vector256.Abs(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<Int16>.Demo):\t{0}", Vector256.Abs(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<UInt16>.Demo):\t{0}", Vector256.Abs(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<Int32>.Demo):\t{0}", Vector256.Abs(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<UInt32>.Demo):\t{0}", Vector256.Abs(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<Int64>.Demo):\t{0}", Vector256.Abs(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "Abs(Vector256s<UInt64>.Demo):\t{0}", Vector256.Abs(Vector256s<UInt64>.Demo));

                // Add<T>(Vector256<T>, Vector256<T>)	
                // Adds writero vectors to compute their sum.
                WriteLine(writer, indent, "Add(Vector256s<Single>.Demo, Vector256s<Single>.V2):\t{0}", Vector256.Add(Vector256s<Single>.Demo, Vector256s<Single>.V2));
                WriteLine(writer, indent, "Add(Vector256s<Double>.Demo, Vector256s<Double>.V2):\t{0}", Vector256.Add(Vector256s<Double>.Demo, Vector256s<Double>.V2));
                WriteLine(writer, indent, "Add(Vector256s<SByte>.Demo, Vector256s<SByte>.V2):\t{0}", Vector256.Add(Vector256s<SByte>.Demo, Vector256s<SByte>.V2));
                WriteLine(writer, indent, "Add(Vector256s<Byte>.Demo, Vector256s<Byte>.V2):\t{0}", Vector256.Add(Vector256s<Byte>.Demo, Vector256s<Byte>.V2));
                WriteLine(writer, indent, "Add(Vector256s<Int16>.Demo, Vector256s<Int16>.V2):\t{0}", Vector256.Add(Vector256s<Int16>.Demo, Vector256s<Int16>.V2));
                WriteLine(writer, indent, "Add(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2):\t{0}", Vector256.Add(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2));
                WriteLine(writer, indent, "Add(Vector256s<Int32>.Demo, Vector256s<Int32>.V2):\t{0}", Vector256.Add(Vector256s<Int32>.Demo, Vector256s<Int32>.V2));
                WriteLine(writer, indent, "Add(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2):\t{0}", Vector256.Add(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2));
                WriteLine(writer, indent, "Add(Vector256s<Int64>.Demo, Vector256s<Int64>.V2):\t{0}", Vector256.Add(Vector256s<Int64>.Demo, Vector256s<Int64>.V2));
                WriteLine(writer, indent, "Add(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2):\t{0}", Vector256.Add(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2));

                // AndNot<T>(Vector256<T>, Vector256<T>)	
                // Computes the bitwise-and of a given vector and the ones complement of another vector.
                WriteLine(writer, indent, "AndNot(Vector256s<Single>.Demo, Vector256s<Single>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<Single>.Demo, Vector256s<Single>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<Double>.Demo, Vector256s<Double>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<Double>.Demo, Vector256s<Double>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<SByte>.Demo, Vector256s<SByte>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<SByte>.Demo, Vector256s<SByte>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<Byte>.Demo, Vector256s<Byte>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<Byte>.Demo, Vector256s<Byte>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<Int16>.Demo, Vector256s<Int16>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<Int16>.Demo, Vector256s<Int16>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<UInt16>.Demo, Vector256s<UInt16>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<UInt16>.Demo, Vector256s<UInt16>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<Int32>.Demo, Vector256s<Int32>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<Int32>.Demo, Vector256s<Int32>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<UInt32>.Demo, Vector256s<UInt32>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<UInt32>.Demo, Vector256s<UInt32>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<Int64>.Demo, Vector256s<Int64>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<Int64>.Demo, Vector256s<Int64>.XyzwWMask));
                WriteLine(writer, indent, "AndNot(Vector256s<UInt64>.Demo, Vector256s<UInt64>.XyzwWMask):\t{0}", Vector256.AndNot(Vector256s<UInt64>.Demo, Vector256s<UInt64>.XyzwWMask));

                // As<TFrom,TTo>(Vector256<TFrom>)	
                // Reinterprets a Vector256<T> of type TFrom as a new Vector256<T> of type TTo.
                // AsByte<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type Byte.
                // AsDouble<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type Double.
                // AsInt16<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type Int16.
                // AsInt32<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type Int32.
                // AsInt64<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type Int64.
                // AsNInt<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256<T>.
                // AsNUInt<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256<T>.
                // AsSByte<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type SByte.
                // AsSingle<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type Single.
                // AsUInt16<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type UInt16.
                // AsUInt32<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type UInt32.
                // AsUInt64<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector256 of type UInt64.
                // AsVector<T>(Vector256<T>)	
                // Reinterprets a Vector256<T> as a new Vector<T>.
                // AsVector256<T>(Vector<T>)	
                // Reinterprets a Vector<T> as a new Vector256<T>.
                // `As***` see below.

                // BitwiseAnd<T>(Vector256<T>, Vector256<T>)	
                // Computes the bitwise-and of writero vectors.
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<Single>.Demo, Vector256s<Single>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<Single>.Demo, Vector256s<Single>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<Double>.Demo, Vector256s<Double>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<Double>.Demo, Vector256s<Double>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<SByte>.Demo, Vector256s<SByte>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<SByte>.Demo, Vector256s<SByte>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<Byte>.Demo, Vector256s<Byte>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<Byte>.Demo, Vector256s<Byte>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<Int16>.Demo, Vector256s<Int16>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<Int16>.Demo, Vector256s<Int16>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<UInt16>.Demo, Vector256s<UInt16>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<UInt16>.Demo, Vector256s<UInt16>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<Int32>.Demo, Vector256s<Int32>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<Int32>.Demo, Vector256s<Int32>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<UInt32>.Demo, Vector256s<UInt32>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<UInt32>.Demo, Vector256s<UInt32>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<Int64>.Demo, Vector256s<Int64>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<Int64>.Demo, Vector256s<Int64>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseAnd(Vector256s<UInt64>.Demo, Vector256s<UInt64>.XyzwWMask):\t{0}", Vector256.BitwiseAnd(Vector256s<UInt64>.Demo, Vector256s<UInt64>.XyzwWMask));

                // BitwiseOr<T>(Vector256<T>, Vector256<T>)	
                // Computes the bitwise-or of writero vectors.
                WriteLine(writer, indent, "BitwiseOr(Vector256s<Single>.Demo, Vector256s<Single>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<Single>.Demo, Vector256s<Single>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<Double>.Demo, Vector256s<Double>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<Double>.Demo, Vector256s<Double>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<SByte>.Demo, Vector256s<SByte>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<SByte>.Demo, Vector256s<SByte>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<Byte>.Demo, Vector256s<Byte>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<Byte>.Demo, Vector256s<Byte>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<Int16>.Demo, Vector256s<Int16>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<Int16>.Demo, Vector256s<Int16>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<UInt16>.Demo, Vector256s<UInt16>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<UInt16>.Demo, Vector256s<UInt16>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<Int32>.Demo, Vector256s<Int32>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<Int32>.Demo, Vector256s<Int32>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<UInt32>.Demo, Vector256s<UInt32>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<UInt32>.Demo, Vector256s<UInt32>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<Int64>.Demo, Vector256s<Int64>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<Int64>.Demo, Vector256s<Int64>.XyzwWMask));
                WriteLine(writer, indent, "BitwiseOr(Vector256s<UInt64>.Demo, Vector256s<UInt64>.XyzwWMask):\t{0}", Vector256.BitwiseOr(Vector256s<UInt64>.Demo, Vector256s<UInt64>.XyzwWMask));

                // Ceiling(Vector256<Double>)	
                // Computes the ceiling of each element in a vector.
                // Ceiling(Vector256<Single>)	
                // Computes the ceiling of each element in a vector.
                WriteLine(writer, indent, "Ceiling(Vector256s<Single>.Demo):\t{0}", Vector256.Ceiling(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "Ceiling(Vector256s<Double>.Demo):\t{0}", Vector256.Ceiling(Vector256s<Double>.Demo));

                // ConditionalSelect<T>(Vector256<T>, Vector256<T>, Vector256<T>)	
                // Conditionally selects a value from writero vectors on a bitwise basis.
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<Single>.XyzwWMask, Vector256s<Single>.Demo, Vector256s<Single>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<Single>.XyzwWMask, Vector256s<Single>.Demo, Vector256s<Single>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<Double>.XyzwWMask, Vector256s<Double>.Demo, Vector256s<Double>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<Double>.XyzwWMask, Vector256s<Double>.Demo, Vector256s<Double>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<SByte>.XyzwWMask, Vector256s<SByte>.Demo, Vector256s<SByte>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<SByte>.XyzwWMask, Vector256s<SByte>.Demo, Vector256s<SByte>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<Byte>.XyzwWMask, Vector256s<Byte>.Demo, Vector256s<Byte>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<Byte>.XyzwWMask, Vector256s<Byte>.Demo, Vector256s<Byte>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<Int16>.XyzwWMask, Vector256s<Int16>.Demo, Vector256s<Int16>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<Int16>.XyzwWMask, Vector256s<Int16>.Demo, Vector256s<Int16>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<UInt16>.XyzwWMask, Vector256s<UInt16>.Demo, Vector256s<UInt16>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<UInt16>.XyzwWMask, Vector256s<UInt16>.Demo, Vector256s<UInt16>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<Int32>.XyzwWMask, Vector256s<Int32>.Demo, Vector256s<Int32>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<Int32>.XyzwWMask, Vector256s<Int32>.Demo, Vector256s<Int32>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<UInt32>.XyzwWMask, Vector256s<UInt32>.Demo, Vector256s<UInt32>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<UInt32>.XyzwWMask, Vector256s<UInt32>.Demo, Vector256s<UInt32>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<Int64>.XyzwWMask, Vector256s<Int64>.Demo, Vector256s<Int64>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<Int64>.XyzwWMask, Vector256s<Int64>.Demo, Vector256s<Int64>.V7));
                WriteLine(writer, indent, "ConditionalSelect(Vector256s<UInt64>.XyzwWMask, Vector256s<UInt64>.Demo, Vector256s<UInt64>.V7):\t{0}", Vector256.ConditionalSelect(Vector256s<UInt64>.XyzwWMask, Vector256s<UInt64>.Demo, Vector256s<UInt64>.V7));

                // ConvertToDouble(Vector256<Int64>)	
                // Converts a Vector256<T> to a Vector256<T>.
                // ConvertToDouble(Vector256<UInt64>)	
                // Converts a Vector256<T> to a Vector256<T>.
                // ConvertToInt32(Vector256<Single>)	
                // Converts a Vector256<T> to a Vector256<T>.
                // ConvertToInt64(Vector256<Double>)	
                // Converts a Vector256<T> to a Vector256<T>.
                // ConvertToSingle(Vector256<Int32>)	
                // Converts a Vector256<T> to a Vector256<T>.
                // ConvertToSingle(Vector256<UInt32>)	
                // Converts a Vector256<T> to a Vector256<T>.
                // ConvertToUInt32(Vector256<Single>)	
                // Converts a Vector256<T> to a Vector256<T>.
                // ConvertToUInt64(Vector256<Double>)	
                // Converts a Vector256<T> to a Vector256<T>.
                WriteLine(writer, indent, "ConvertToDouble(Vector256s<Int64>.Demo):\t{0}", Vector256.ConvertToDouble(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "ConvertToDouble(Vector256s<UInt64>.Demo):\t{0}", Vector256.ConvertToDouble(Vector256s<UInt64>.Demo));
                WriteLine(writer, indent, "ConvertToInt32(Vector256s<Single>.Demo):\t{0}", Vector256.ConvertToInt32(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "ConvertToInt64(Vector256s<Double>.Demo):\t{0}", Vector256.ConvertToInt64(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "ConvertToSingle(Vector256s<Int32>.Demo):\t{0}", Vector256.ConvertToSingle(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "ConvertToSingle(Vector256s<UInt32>.Demo):\t{0}", Vector256.ConvertToSingle(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "ConvertToUInt32(Vector256s<Single>.Demo):\t{0}", Vector256.ConvertToUInt32(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "ConvertToUInt64(Vector256s<Double>.Demo):\t{0}", Vector256.ConvertToUInt64(Vector256s<Double>.Demo));

                // CopyTo<T>(Vector256<T>, Span<T>)	
                // Copies a Vector256<T> to a given span.
                // CopyTo<T>(Vector256<T>, T[])	
                // Copies a Vector256<T> to a given array.
                // CopyTo<T>(Vector256<T>, T[], Int32)	
                // Copies a Vector256<T> to a given array starting at the specified index.

                // Create(Byte)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte, Byte)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(Double)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(Double, Double, Double, Double)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(Int16)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16, Int16)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(Int32)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(Int32, Int32, Int32, Int32, Int32, Int32, Int32, Int32)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(Int64)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(Int64, Int64, Int64, Int64)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(IntPtr)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(SByte)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte, SByte)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(Single)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(Single, Single, Single, Single, Single, Single, Single, Single)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(UInt16)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16, UInt16)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(UInt32)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32, UInt32)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(UInt64)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create(UInt64, UInt64, UInt64, UInt64)	
                // Creates a new Vector256<T> instance with each element initialized to the corresponding specified value.
                // Create(UIntPtr)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // `Create` see below.

                // Create(Vector128<Byte>, Vector128<Byte>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<Double>, Vector128<Double>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<Int16>, Vector128<Int16>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<Int32>, Vector128<Int32>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<Int64>, Vector128<Int64>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<SByte>, Vector128<SByte>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<Single>, Vector128<Single>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<UInt16>, Vector128<UInt16>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<UInt32>, Vector128<UInt32>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                // Create(Vector128<UInt64>, Vector128<UInt64>)	
                // Creates a new Vector256<T> instance from writero Vector128<T> instances.
                WriteLine(writer, indent, "Create(Vector128s<Single>.Demo, Vector128s<Single>.SerialNegative):\t{0}", Vector256.Create(Vector128s<Single>.Demo, Vector128s<Single>.SerialNegative));

                // Create<T>(ReadOnlySpan<T>)	
                // Creates a new Vector256<T> from a given readonly span.
                // Create<T>(T)	
                // Creates a new Vector256<T> instance with all elements initialized to the specified value.
                // Create<T>(T[])	
                // Creates a new Vector256<T> from a given array.
                // Create<T>(T[], Int32)	
                // Creates a new Vector256<T> from a given array.
                // `Create` see below.

                // CreateScalar(Byte)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(Double)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(Int16)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(Int32)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(Int64)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(IntPtr)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(SByte)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(Single)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(UInt16)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(UInt32)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(UInt64)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                // CreateScalar(UIntPtr)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements initialized to zero.
                WriteLine(writer, indent, "CreateScalar(9):\t{0}", Vector256.CreateScalar(9));

                // CreateScalarUnsafe(Byte)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(Double)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(Int16)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(Int32)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(Int64)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(IntPtr)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(SByte)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(Single)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(UInt16)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(UInt32)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(UInt64)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                // CreateScalarUnsafe(UIntPtr)	
                // Creates a new Vector256<T> instance with the first element initialized to the specified value and the remaining elements left uninitialized.
                WriteLine(writer, indent, "CreateScalarUnsafe(9):\t{0}", Vector256.CreateScalarUnsafe(9));

                // Divide<T>(Vector256<T>, Vector256<T>)	
                // Divides writero vectors to compute their quotient.
                WriteLine(writer, indent, "Divide(Vector256s<Single>.Demo, Vector256s<Single>.V2):\t{0}", Vector256.Divide(Vector256s<Single>.Demo, Vector256s<Single>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<Double>.Demo, Vector256s<Double>.V2):\t{0}", Vector256.Divide(Vector256s<Double>.Demo, Vector256s<Double>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<SByte>.Demo, Vector256s<SByte>.V2):\t{0}", Vector256.Divide(Vector256s<SByte>.Demo, Vector256s<SByte>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<Byte>.Demo, Vector256s<Byte>.V2):\t{0}", Vector256.Divide(Vector256s<Byte>.Demo, Vector256s<Byte>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<Int16>.Demo, Vector256s<Int16>.V2):\t{0}", Vector256.Divide(Vector256s<Int16>.Demo, Vector256s<Int16>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2):\t{0}", Vector256.Divide(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<Int32>.Demo, Vector256s<Int32>.V2):\t{0}", Vector256.Divide(Vector256s<Int32>.Demo, Vector256s<Int32>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2):\t{0}", Vector256.Divide(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<Int64>.Demo, Vector256s<Int64>.V2):\t{0}", Vector256.Divide(Vector256s<Int64>.Demo, Vector256s<Int64>.V2));
                WriteLine(writer, indent, "Divide(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2):\t{0}", Vector256.Divide(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2));

                // Dot<T>(Vector256<T>, Vector256<T>)	
                // Computes the dot product of writero vectors.
                WriteLine(writer, indent, "Dot(Vector256s<Int32>.V1, Vector256s<Int32>.V2):\t{0}", Vector256.Dot(Vector256s<Int32>.V1, Vector256s<Int32>.V2)); // 1*2*Vector256<T>.Count
                WriteLine(writer, indent, "Dot(Vector256s<Single>.Demo, Vector256s<Single>.V2):\t{0}", Vector256.Dot(Vector256s<Single>.Demo, Vector256s<Single>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<Double>.Demo, Vector256s<Double>.V2):\t{0}", Vector256.Dot(Vector256s<Double>.Demo, Vector256s<Double>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<SByte>.Demo, Vector256s<SByte>.V2):\t{0}", Vector256.Dot(Vector256s<SByte>.Demo, Vector256s<SByte>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<Byte>.Demo, Vector256s<Byte>.V2):\t{0}", Vector256.Dot(Vector256s<Byte>.Demo, Vector256s<Byte>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<Int16>.Demo, Vector256s<Int16>.V2):\t{0}", Vector256.Dot(Vector256s<Int16>.Demo, Vector256s<Int16>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2):\t{0}", Vector256.Dot(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<Int32>.Demo, Vector256s<Int32>.V2):\t{0}", Vector256.Dot(Vector256s<Int32>.Demo, Vector256s<Int32>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2):\t{0}", Vector256.Dot(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<Int64>.Demo, Vector256s<Int64>.V2):\t{0}", Vector256.Dot(Vector256s<Int64>.Demo, Vector256s<Int64>.V2));
                WriteLine(writer, indent, "Dot(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2):\t{0}", Vector256.Dot(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2));

                // Equals<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if they are equal on a per-element basis.
                WriteLine(writer, indent, "Equals(Vector256s<Single>.Demo, Vector256s<Single>.MinValue):\t{0}", Vector256.Equals(Vector256s<Single>.Demo, Vector256s<Single>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<Double>.Demo, Vector256s<Double>.MinValue):\t{0}", Vector256.Equals(Vector256s<Double>.Demo, Vector256s<Double>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<SByte>.Demo, Vector256s<SByte>.MinValue):\t{0}", Vector256.Equals(Vector256s<SByte>.Demo, Vector256s<SByte>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<Byte>.Demo, Vector256s<Byte>.MinValue):\t{0}", Vector256.Equals(Vector256s<Byte>.Demo, Vector256s<Byte>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<Int16>.Demo, Vector256s<Int16>.MinValue):\t{0}", Vector256.Equals(Vector256s<Int16>.Demo, Vector256s<Int16>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<UInt16>.Demo, Vector256s<UInt16>.MinValue):\t{0}", Vector256.Equals(Vector256s<UInt16>.Demo, Vector256s<UInt16>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<Int32>.Demo, Vector256s<Int32>.MinValue):\t{0}", Vector256.Equals(Vector256s<Int32>.Demo, Vector256s<Int32>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<UInt32>.Demo, Vector256s<UInt32>.MinValue):\t{0}", Vector256.Equals(Vector256s<UInt32>.Demo, Vector256s<UInt32>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<Int64>.Demo, Vector256s<Int64>.MinValue):\t{0}", Vector256.Equals(Vector256s<Int64>.Demo, Vector256s<Int64>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<UInt64>.Demo, Vector256s<UInt64>.MinValue):\t{0}", Vector256.Equals(Vector256s<UInt64>.Demo, Vector256s<UInt64>.MinValue));
                WriteLine(writer, indent, "Equals(Vector256s<Single>.Demo, Vector256s<Single>.V0):\t{0}", Vector256.Equals(Vector256s<Single>.Demo, Vector256s<Single>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<Double>.Demo, Vector256s<Double>.V0):\t{0}", Vector256.Equals(Vector256s<Double>.Demo, Vector256s<Double>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<SByte>.Demo, Vector256s<SByte>.V0):\t{0}", Vector256.Equals(Vector256s<SByte>.Demo, Vector256s<SByte>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<Byte>.Demo, Vector256s<Byte>.V0):\t{0}", Vector256.Equals(Vector256s<Byte>.Demo, Vector256s<Byte>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<Int16>.Demo, Vector256s<Int16>.V0):\t{0}", Vector256.Equals(Vector256s<Int16>.Demo, Vector256s<Int16>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0):\t{0}", Vector256.Equals(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<Int32>.Demo, Vector256s<Int32>.V0):\t{0}", Vector256.Equals(Vector256s<Int32>.Demo, Vector256s<Int32>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0):\t{0}", Vector256.Equals(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<Int64>.Demo, Vector256s<Int64>.V0):\t{0}", Vector256.Equals(Vector256s<Int64>.Demo, Vector256s<Int64>.V0));
                WriteLine(writer, indent, "Equals(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0):\t{0}", Vector256.Equals(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0));

                // EqualsAll<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if all elements are equal.
                WriteLine(writer, indent, "EqualsAll(Vector256s<Single>.Demo, Vector256s<Single>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<Single>.Demo, Vector256s<Single>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<Double>.Demo, Vector256s<Double>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<Double>.Demo, Vector256s<Double>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<SByte>.Demo, Vector256s<SByte>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<SByte>.Demo, Vector256s<SByte>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<Byte>.Demo, Vector256s<Byte>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<Byte>.Demo, Vector256s<Byte>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<Int16>.Demo, Vector256s<Int16>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<Int16>.Demo, Vector256s<Int16>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<UInt16>.Demo, Vector256s<UInt16>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<UInt16>.Demo, Vector256s<UInt16>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<Int32>.Demo, Vector256s<Int32>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<Int32>.Demo, Vector256s<Int32>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<UInt32>.Demo, Vector256s<UInt32>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<UInt32>.Demo, Vector256s<UInt32>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<Int64>.Demo, Vector256s<Int64>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<Int64>.Demo, Vector256s<Int64>.MinValue));
                WriteLine(writer, indent, "EqualsAll(Vector256s<UInt64>.Demo, Vector256s<UInt64>.MinValue):\t{0}", Vector256.EqualsAll(Vector256s<UInt64>.Demo, Vector256s<UInt64>.MinValue));

                // EqualsAny<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if any elements are equal.
                WriteLine(writer, indent, "EqualsAny(Vector256s<Single>.Demo, Vector256s<Single>.V0):\t{0}", Vector256.EqualsAny(Vector256s<Single>.Demo, Vector256s<Single>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<Double>.Demo, Vector256s<Double>.V0):\t{0}", Vector256.EqualsAny(Vector256s<Double>.Demo, Vector256s<Double>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<SByte>.Demo, Vector256s<SByte>.V0):\t{0}", Vector256.EqualsAny(Vector256s<SByte>.Demo, Vector256s<SByte>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<Byte>.Demo, Vector256s<Byte>.V0):\t{0}", Vector256.EqualsAny(Vector256s<Byte>.Demo, Vector256s<Byte>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<Int16>.Demo, Vector256s<Int16>.V0):\t{0}", Vector256.EqualsAny(Vector256s<Int16>.Demo, Vector256s<Int16>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0):\t{0}", Vector256.EqualsAny(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<Int32>.Demo, Vector256s<Int32>.V0):\t{0}", Vector256.EqualsAny(Vector256s<Int32>.Demo, Vector256s<Int32>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0):\t{0}", Vector256.EqualsAny(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<Int64>.Demo, Vector256s<Int64>.V0):\t{0}", Vector256.EqualsAny(Vector256s<Int64>.Demo, Vector256s<Int64>.V0));
                WriteLine(writer, indent, "EqualsAny(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0):\t{0}", Vector256.EqualsAny(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0));

                // ExtractMostSignificantBits<T>(Vector256<T>)	
                // Extracts the most significant bit from each element in a vector.
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<Single>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<Double>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<SByte>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<Byte>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<Int16>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<UInt16>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<Int32>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<UInt32>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<Int64>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "ExtractMostSignificantBits(Vector256s<UInt64>.Demo):\t{0}", Vector256.ExtractMostSignificantBits(Vector256s<UInt64>.Demo));

                // Floor(Vector256<Double>)	
                // Computes the floor of each element in a vector.
                // Floor(Vector256<Single>)	
                // Computes the floor of each element in a vector.
                WriteLine(writer, indent, "Floor(Vector256s<Single>.Demo):\t{0}", Vector256.Floor(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "Floor(Vector256s<Double>.Demo):\t{0}", Vector256.Floor(Vector256s<Double>.Demo));

                // GetElement<T>(Vector256<T>, Int32)	
                // Gets the element at the specified index.
                // Ignore.
                if (true) {
                    shift = 1;
                    WriteLine(writer, indent, "shift:\t{0}", shift);
                    WriteLine(writer, indent, "GetElement(Vector256s<Single>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<Single>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<Double>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<Double>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<SByte>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<SByte>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<Byte>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<Byte>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<Int16>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<Int16>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<UInt16>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<UInt16>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<Int32>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<Int32>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<UInt32>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<UInt32>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<Int64>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<Int64>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<UInt64>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<UInt64>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<IntPtr>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<IntPtr>.Demo, shift));
                    WriteLine(writer, indent, "GetElement(Vector256s<UIntPtr>.Demo, shift):\t{0}", Vector256.GetElement(Vector256s<UIntPtr>.Demo, shift));
                }

                // GetLower<T>(Vector256<T>)	
                // Gets the value of the lower 128 bits as a new Vector128<T>.
                WriteLine(writer, indent, "GetLower(Vector256s<Single>.Demo):\t{0}", Vector256.GetLower(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<Double>.Demo):\t{0}", Vector256.GetLower(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<SByte>.Demo):\t{0}", Vector256.GetLower(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<Byte>.Demo):\t{0}", Vector256.GetLower(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<Int16>.Demo):\t{0}", Vector256.GetLower(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<UInt16>.Demo):\t{0}", Vector256.GetLower(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<Int32>.Demo):\t{0}", Vector256.GetLower(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<UInt32>.Demo):\t{0}", Vector256.GetLower(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<Int64>.Demo):\t{0}", Vector256.GetLower(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "GetLower(Vector256s<UInt64>.Demo):\t{0}", Vector256.GetLower(Vector256s<UInt64>.Demo));

                // GetUpper<T>(Vector256<T>)	
                // Gets the value of the upper 128 bits as a new Vector128<T>.
                WriteLine(writer, indent, "GetUpper(Vector256s<Single>.Demo):\t{0}", Vector256.GetUpper(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<Double>.Demo):\t{0}", Vector256.GetUpper(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<SByte>.Demo):\t{0}", Vector256.GetUpper(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<Byte>.Demo):\t{0}", Vector256.GetUpper(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<Int16>.Demo):\t{0}", Vector256.GetUpper(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<UInt16>.Demo):\t{0}", Vector256.GetUpper(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<Int32>.Demo):\t{0}", Vector256.GetUpper(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<UInt32>.Demo):\t{0}", Vector256.GetUpper(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<Int64>.Demo):\t{0}", Vector256.GetUpper(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "GetUpper(Vector256s<UInt64>.Demo):\t{0}", Vector256.GetUpper(Vector256s<UInt64>.Demo));

                // GreaterThan<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine which is greater on a per-element basis.
                WriteLine(writer, indent, "GreaterThan(Vector256s<Single>.Demo, Vector256s<Single>.V0):\t{0}", Vector256.GreaterThan(Vector256s<Single>.Demo, Vector256s<Single>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<Double>.Demo, Vector256s<Double>.V0):\t{0}", Vector256.GreaterThan(Vector256s<Double>.Demo, Vector256s<Double>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<SByte>.Demo, Vector256s<SByte>.V0):\t{0}", Vector256.GreaterThan(Vector256s<SByte>.Demo, Vector256s<SByte>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<Byte>.Demo, Vector256s<Byte>.V0):\t{0}", Vector256.GreaterThan(Vector256s<Byte>.Demo, Vector256s<Byte>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<Int16>.Demo, Vector256s<Int16>.V0):\t{0}", Vector256.GreaterThan(Vector256s<Int16>.Demo, Vector256s<Int16>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0):\t{0}", Vector256.GreaterThan(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<Int32>.Demo, Vector256s<Int32>.V0):\t{0}", Vector256.GreaterThan(Vector256s<Int32>.Demo, Vector256s<Int32>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0):\t{0}", Vector256.GreaterThan(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<Int64>.Demo, Vector256s<Int64>.V0):\t{0}", Vector256.GreaterThan(Vector256s<Int64>.Demo, Vector256s<Int64>.V0));
                WriteLine(writer, indent, "GreaterThan(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0):\t{0}", Vector256.GreaterThan(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0));

                // GreaterThanAll<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if all elements are greater.
                // GreaterThanAny<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if any elements are greater.

                // GreaterThanOrEqual<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine which is greater or equal on a per-element basis.
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<Single>.Demo, Vector256s<Single>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<Single>.Demo, Vector256s<Single>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<Double>.Demo, Vector256s<Double>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<Double>.Demo, Vector256s<Double>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<SByte>.Demo, Vector256s<SByte>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<SByte>.Demo, Vector256s<SByte>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<Byte>.Demo, Vector256s<Byte>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<Byte>.Demo, Vector256s<Byte>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<Int16>.Demo, Vector256s<Int16>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<Int16>.Demo, Vector256s<Int16>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<Int32>.Demo, Vector256s<Int32>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<Int32>.Demo, Vector256s<Int32>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<Int64>.Demo, Vector256s<Int64>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<Int64>.Demo, Vector256s<Int64>.V0));
                WriteLine(writer, indent, "GreaterThanOrEqual(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0):\t{0}", Vector256.GreaterThanOrEqual(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0));

                // GreaterThanOrEqualAll<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if all elements are greater or equal.
                // GreaterThanOrEqualAny<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if any elements are greater or equal.

                // LessThan<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine which is less on a per-element basis.
                WriteLine(writer, indent, "LessThan(Vector256s<Single>.Demo, Vector256s<Single>.V0):\t{0}", Vector256.LessThan(Vector256s<Single>.Demo, Vector256s<Single>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<Double>.Demo, Vector256s<Double>.V0):\t{0}", Vector256.LessThan(Vector256s<Double>.Demo, Vector256s<Double>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<SByte>.Demo, Vector256s<SByte>.V0):\t{0}", Vector256.LessThan(Vector256s<SByte>.Demo, Vector256s<SByte>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<Byte>.Demo, Vector256s<Byte>.V0):\t{0}", Vector256.LessThan(Vector256s<Byte>.Demo, Vector256s<Byte>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<Int16>.Demo, Vector256s<Int16>.V0):\t{0}", Vector256.LessThan(Vector256s<Int16>.Demo, Vector256s<Int16>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0):\t{0}", Vector256.LessThan(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<Int32>.Demo, Vector256s<Int32>.V0):\t{0}", Vector256.LessThan(Vector256s<Int32>.Demo, Vector256s<Int32>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0):\t{0}", Vector256.LessThan(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<Int64>.Demo, Vector256s<Int64>.V0):\t{0}", Vector256.LessThan(Vector256s<Int64>.Demo, Vector256s<Int64>.V0));
                WriteLine(writer, indent, "LessThan(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0):\t{0}", Vector256.LessThan(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0));

                // LessThanAll<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if all elements are less.
                // LessThanAny<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if any elements are less.

                // LessThanOrEqual<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine which is less or equal on a per-element basis.
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<Single>.Demo, Vector256s<Single>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<Single>.Demo, Vector256s<Single>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<Double>.Demo, Vector256s<Double>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<Double>.Demo, Vector256s<Double>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<SByte>.Demo, Vector256s<SByte>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<SByte>.Demo, Vector256s<SByte>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<Byte>.Demo, Vector256s<Byte>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<Byte>.Demo, Vector256s<Byte>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<Int16>.Demo, Vector256s<Int16>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<Int16>.Demo, Vector256s<Int16>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<Int32>.Demo, Vector256s<Int32>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<Int32>.Demo, Vector256s<Int32>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<Int64>.Demo, Vector256s<Int64>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<Int64>.Demo, Vector256s<Int64>.V0));
                WriteLine(writer, indent, "LessThanOrEqual(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0):\t{0}", Vector256.LessThanOrEqual(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0));

                // LessThanOrEqualAll<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if all elements are less or equal.
                // LessThanOrEqualAny<T>(Vector256<T>, Vector256<T>)	
                // Compares writero vectors to determine if any elements are less or equal.

                // Load<T>(T*)	
                // Loads a vector from the given source.
                // LoadAligned<T>(T*)	
                // Loads a vector from the given aligned source.
                // LoadAlignedNonTemporal<T>(T*)	
                // Loads a vector from the given aligned source.
                // LoadUnsafe<T>(T)	
                // Loads a vector from the given source.
                // LoadUnsafe<T>(T, UIntPtr)	
                // Loads a vector from the given source and element offset.
                // Ignore.

                // Max<T>(Vector256<T>, Vector256<T>)	
                // Computes the maximum of writero vectors on a per-element basis.
                WriteLine(writer, indent, "Max(Vector256s<Single>.Demo, Vector256s<Single>.V0):\t{0}", Vector256.Max(Vector256s<Single>.Demo, Vector256s<Single>.V0));
                WriteLine(writer, indent, "Max(Vector256s<Double>.Demo, Vector256s<Double>.V0):\t{0}", Vector256.Max(Vector256s<Double>.Demo, Vector256s<Double>.V0));
                WriteLine(writer, indent, "Max(Vector256s<SByte>.Demo, Vector256s<SByte>.V0):\t{0}", Vector256.Max(Vector256s<SByte>.Demo, Vector256s<SByte>.V0));
                WriteLine(writer, indent, "Max(Vector256s<Byte>.Demo, Vector256s<Byte>.V0):\t{0}", Vector256.Max(Vector256s<Byte>.Demo, Vector256s<Byte>.V0));
                WriteLine(writer, indent, "Max(Vector256s<Int16>.Demo, Vector256s<Int16>.V0):\t{0}", Vector256.Max(Vector256s<Int16>.Demo, Vector256s<Int16>.V0));
                WriteLine(writer, indent, "Max(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0):\t{0}", Vector256.Max(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0));
                WriteLine(writer, indent, "Max(Vector256s<Int32>.Demo, Vector256s<Int32>.V0):\t{0}", Vector256.Max(Vector256s<Int32>.Demo, Vector256s<Int32>.V0));
                WriteLine(writer, indent, "Max(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0):\t{0}", Vector256.Max(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0));
                WriteLine(writer, indent, "Max(Vector256s<Int64>.Demo, Vector256s<Int64>.V0):\t{0}", Vector256.Max(Vector256s<Int64>.Demo, Vector256s<Int64>.V0));
                WriteLine(writer, indent, "Max(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0):\t{0}", Vector256.Max(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0));

                // Min<T>(Vector256<T>, Vector256<T>)	
                // Computes the minimum of writero vectors on a per-element basis.
                WriteLine(writer, indent, "Min(Vector256s<Single>.Demo, Vector256s<Single>.V0):\t{0}", Vector256.Min(Vector256s<Single>.Demo, Vector256s<Single>.V0));
                WriteLine(writer, indent, "Min(Vector256s<Double>.Demo, Vector256s<Double>.V0):\t{0}", Vector256.Min(Vector256s<Double>.Demo, Vector256s<Double>.V0));
                WriteLine(writer, indent, "Min(Vector256s<SByte>.Demo, Vector256s<SByte>.V0):\t{0}", Vector256.Min(Vector256s<SByte>.Demo, Vector256s<SByte>.V0));
                WriteLine(writer, indent, "Min(Vector256s<Byte>.Demo, Vector256s<Byte>.V0):\t{0}", Vector256.Min(Vector256s<Byte>.Demo, Vector256s<Byte>.V0));
                WriteLine(writer, indent, "Min(Vector256s<Int16>.Demo, Vector256s<Int16>.V0):\t{0}", Vector256.Min(Vector256s<Int16>.Demo, Vector256s<Int16>.V0));
                WriteLine(writer, indent, "Min(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0):\t{0}", Vector256.Min(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V0));
                WriteLine(writer, indent, "Min(Vector256s<Int32>.Demo, Vector256s<Int32>.V0):\t{0}", Vector256.Min(Vector256s<Int32>.Demo, Vector256s<Int32>.V0));
                WriteLine(writer, indent, "Min(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0):\t{0}", Vector256.Min(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V0));
                WriteLine(writer, indent, "Min(Vector256s<Int64>.Demo, Vector256s<Int64>.V0):\t{0}", Vector256.Min(Vector256s<Int64>.Demo, Vector256s<Int64>.V0));
                WriteLine(writer, indent, "Min(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0):\t{0}", Vector256.Min(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V0));
                // limit to [0, 255].
                WriteLine(writer, indent, "Vector256.Min(Vector256.Max(Vector256s<Single>.Demo, Vector256s<Single>.V0), Vector256s<Single>.VMaxByte)):\t{0}", Vector256.Min(Vector256.Max(Vector256s<Single>.Demo, Vector256s<Single>.V0), Vector256s<Single>.VMaxByte));

                // Multiply<T>(T, Vector256<T>)	
                // Multiplies a vector by a scalar to compute their product.
                // Multiply<T>(Vector256<T>, T)	
                // Multiplies a vector by a scalar to compute their product.
                // Multiply<T>(Vector256<T>, Vector256<T>)	
                // Multiplies writero vectors to compute their element-wise product.
                WriteLine(writer, indent, "Multiply(Vector256s<Single>.Demo, Vector256s<Single>.V2):\t{0}", Vector256.Multiply(Vector256s<Single>.Demo, Vector256s<Single>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<Double>.Demo, Vector256s<Double>.V2):\t{0}", Vector256.Multiply(Vector256s<Double>.Demo, Vector256s<Double>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<SByte>.Demo, Vector256s<SByte>.V2):\t{0}", Vector256.Multiply(Vector256s<SByte>.Demo, Vector256s<SByte>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<Byte>.Demo, Vector256s<Byte>.V2):\t{0}", Vector256.Multiply(Vector256s<Byte>.Demo, Vector256s<Byte>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<Int16>.Demo, Vector256s<Int16>.V2):\t{0}", Vector256.Multiply(Vector256s<Int16>.Demo, Vector256s<Int16>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2):\t{0}", Vector256.Multiply(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<Int32>.Demo, Vector256s<Int32>.V2):\t{0}", Vector256.Multiply(Vector256s<Int32>.Demo, Vector256s<Int32>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2):\t{0}", Vector256.Multiply(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<Int64>.Demo, Vector256s<Int64>.V2):\t{0}", Vector256.Multiply(Vector256s<Int64>.Demo, Vector256s<Int64>.V2));
                WriteLine(writer, indent, "Multiply(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2):\t{0}", Vector256.Multiply(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2));

                // Narrow(Vector256<Double>, Vector256<Double>)	
                // Narrows writero Vector256<T> instances into one Vector256<T>.
                // Narrow(Vector256<Int16>, Vector256<Int16>)	
                // Narrows writero Vector256<T> instances into one Vector256<T>.
                // Narrow(Vector256<Int32>, Vector256<Int32>)	
                // Narrows writero Vector256<T> instances into one Vector256<T>.
                // Narrow(Vector256<Int64>, Vector256<Int64>)	
                // Narrows writero Vector256<T> instances into one Vector256<T>.
                // Narrow(Vector256<UInt16>, Vector256<UInt16>)	
                // Narrows writero Vector256<T> instances into one Vector256<T>.
                // Narrow(Vector256<UInt32>, Vector256<UInt32>)	
                // Narrows writero Vector256<T> instances into one Vector256<T>.
                // Narrow(Vector256<UInt64>, Vector256<UInt64>)	
                // Narrows writero Vector256<T> instances into one Vector256<T>.
                WriteLine(writer, indent, "Narrow(Vector256s<Double>.Demo, Vector256s<Double>.SerialNegative):\t{0}", Vector256.Narrow(Vector256s<Double>.Demo, Vector256s<Double>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vector256s<Int16>.Demo, Vector256s<Int16>.SerialNegative):\t{0}", Vector256.Narrow(Vector256s<Int16>.Demo, Vector256s<Int16>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vector256s<Int32>.Demo, Vector256s<Int32>.SerialNegative):\t{0}", Vector256.Narrow(Vector256s<Int32>.Demo, Vector256s<Int32>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vector256s<Int64>.Demo, Vector256s<Int64>.SerialNegative):\t{0}", Vector256.Narrow(Vector256s<Int64>.Demo, Vector256s<Int64>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vector256s<UInt16>.Demo, Vector256s<UInt16>.SerialNegative):\t{0}", Vector256.Narrow(Vector256s<UInt16>.Demo, Vector256s<UInt16>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vector256s<UInt32>.Demo, Vector256s<UInt32>.SerialNegative):\t{0}", Vector256.Narrow(Vector256s<UInt32>.Demo, Vector256s<UInt32>.SerialNegative));
                WriteLine(writer, indent, "Narrow(Vector256s<UInt64>.Demo, Vector256s<UInt64>.SerialNegative):\t{0}", Vector256.Narrow(Vector256s<UInt64>.Demo, Vector256s<UInt64>.SerialNegative));

                // Negate<T>(Vector256<T>)	
                // Negates a vector.
                WriteLine(writer, indent, "Negate(Vector256s<Single>.Demo):\t{0}", Vector256.Negate(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<Double>.Demo):\t{0}", Vector256.Negate(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<SByte>.Demo):\t{0}", Vector256.Negate(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<Byte>.Demo):\t{0}", Vector256.Negate(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<Int16>.Demo):\t{0}", Vector256.Negate(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<UInt16>.Demo):\t{0}", Vector256.Negate(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<Int32>.Demo):\t{0}", Vector256.Negate(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<UInt32>.Demo):\t{0}", Vector256.Negate(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<Int64>.Demo):\t{0}", Vector256.Negate(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "Negate(Vector256s<UInt64>.Demo):\t{0}", Vector256.Negate(Vector256s<UInt64>.Demo));

                // OnesComplement<T>(Vector256<T>)	
                // Computes the ones-complement of a vector.
                WriteLine(writer, indent, "OnesComplement(Vector256s<Single>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<Double>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<SByte>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<Byte>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<Int16>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<UInt16>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<Int32>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<UInt32>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<Int64>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "OnesComplement(Vector256s<UInt64>.Demo):\t{0}", Vector256.OnesComplement(Vector256s<UInt64>.Demo));

                // ShiftLeft(Vector256<Byte>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<Int16>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<Int32>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<Int64>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<IntPtr>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<SByte>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<UInt16>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<UInt32>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<UInt64>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                // ShiftLeft(Vector256<UIntPtr>, Int32)	
                // Shifts each element of a vector left by the specified amount.
                shift = 4;
                WriteLine(writer, indent, "shift:\t{0}", shift);
                WriteLine(writer, indent, "ShiftLeft(Vector256s<SByte>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<SByte>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<Byte>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<Byte>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<Int16>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<Int16>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<UInt16>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<UInt16>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<Int32>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<Int32>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<UInt32>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<UInt32>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<Int64>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<Int64>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<UInt64>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<UInt64>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<IntPtr>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<IntPtr>.Demo, shift));
                WriteLine(writer, indent, "ShiftLeft(Vector256s<UIntPtr>.Demo, shift):\t{0}", Vector256.ShiftLeft(Vector256s<UIntPtr>.Demo, shift));

                // ShiftRightArithmetic(Vector256<Int16>, Int32)	
                // Shifts (signed) each element of a vector right by the specified amount.
                // ShiftRightArithmetic(Vector256<Int32>, Int32)	
                // Shifts (signed) each element of a vector right by the specified amount.
                // ShiftRightArithmetic(Vector256<Int64>, Int32)	
                // Shifts (signed) each element of a vector right by the specified amount.
                // ShiftRightArithmetic(Vector256<IntPtr>, Int32)	
                // Shifts (signed) each element of a vector right by the specified amount.
                // ShiftRightArithmetic(Vector256<SByte>, Int32)	
                // Shifts (signed) each element of a vector right by the specified amount.
                WriteLine(writer, indent, "ShiftRightArithmetic(Vector256s<SByte>.Demo, shift):\t{0}", Vector256.ShiftRightArithmetic(Vector256s<SByte>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightArithmetic(Vector256s<Int16>.Demo, shift):\t{0}", Vector256.ShiftRightArithmetic(Vector256s<Int16>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightArithmetic(Vector256s<Int32>.Demo, shift):\t{0}", Vector256.ShiftRightArithmetic(Vector256s<Int32>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightArithmetic(Vector256s<Int64>.Demo, shift):\t{0}", Vector256.ShiftRightArithmetic(Vector256s<Int64>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightArithmetic(Vector256s<IntPtr>.Demo, shift):\t{0}", Vector256.ShiftRightArithmetic(Vector256s<IntPtr>.Demo, shift));

                // ShiftRightLogical(Vector256<Byte>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<Int16>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<Int32>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<Int64>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<IntPtr>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<SByte>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<UInt16>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<UInt32>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<UInt64>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                // ShiftRightLogical(Vector256<UIntPtr>, Int32)	
                // Shifts (unsigned) each element of a vector right by the specified amount.
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<SByte>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<SByte>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<Byte>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<Byte>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<Int16>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<Int16>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<UInt16>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<UInt16>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<Int32>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<Int32>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<UInt32>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<UInt32>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<Int64>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<Int64>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<UInt64>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<UInt64>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<IntPtr>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<IntPtr>.Demo, shift));
                WriteLine(writer, indent, "ShiftRightLogical(Vector256s<UIntPtr>.Demo, shift):\t{0}", Vector256.ShiftRightLogical(Vector256s<UIntPtr>.Demo, shift));

                // Shuffle(Vector256<Byte>, Vector256<Byte>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<Double>, Vector256<Int64>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<Int16>, Vector256<Int16>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<Int32>, Vector256<Int32>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<Int64>, Vector256<Int64>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<SByte>, Vector256<SByte>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<Single>, Vector256<Int32>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<UInt16>, Vector256<UInt16>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<UInt32>, Vector256<UInt32>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                // Shuffle(Vector256<UInt64>, Vector256<UInt64>)	
                // Creates a new vector by selecting values from an input vector using a set of indices.
                WriteLine(writer, indent, "Shuffle(Vector256s<Single>.Demo, Vector256s<Int32>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<Single>.Demo, Vector256s<Int32>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<Double>.Demo, Vector256s<Int64>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<Double>.Demo, Vector256s<Int64>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<SByte>.Demo, Vector256s<SByte>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<SByte>.Demo, Vector256s<SByte>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<Byte>.Demo, Vector256s<Byte>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<Byte>.Demo, Vector256s<Byte>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<Int16>.Demo, Vector256s<Int16>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<Int16>.Demo, Vector256s<Int16>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<UInt16>.Demo, Vector256s<UInt16>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<UInt16>.Demo, Vector256s<UInt16>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<Int32>.Demo, Vector256s<Int32>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<Int32>.Demo, Vector256s<Int32>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<UInt32>.Demo, Vector256s<UInt32>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<UInt32>.Demo, Vector256s<UInt32>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<Int64>.Demo, Vector256s<Int64>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<Int64>.Demo, Vector256s<Int64>.SerialDesc));
                WriteLine(writer, indent, "Shuffle(Vector256s<UInt64>.Demo, Vector256s<UInt64>.SerialDesc):\t{0}", Vector256.Shuffle(Vector256s<UInt64>.Demo, Vector256s<UInt64>.SerialDesc));

                // Sqrt<T>(Vector256<T>)	
                // Computes the square root of a vector on a per-element basis.
                WriteLine(writer, indent, "Sqrt(Vector256s<Single>.Demo):\t{0}", Vector256.Sqrt(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<Double>.Demo):\t{0}", Vector256.Sqrt(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<SByte>.Demo):\t{0}", Vector256.Sqrt(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<Byte>.Demo):\t{0}", Vector256.Sqrt(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<Int16>.Demo):\t{0}", Vector256.Sqrt(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<UInt16>.Demo):\t{0}", Vector256.Sqrt(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<Int32>.Demo):\t{0}", Vector256.Sqrt(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<UInt32>.Demo):\t{0}", Vector256.Sqrt(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<Int64>.Demo):\t{0}", Vector256.Sqrt(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "Sqrt(Vector256s<UInt64>.Demo):\t{0}", Vector256.Sqrt(Vector256s<UInt64>.Demo));

                // Store<T>(Vector256<T>, T*)	
                // Stores a vector at the given destination.
                // StoreAligned<T>(Vector256<T>, T*)	
                // Stores a vector at the given aligned destination.
                // StoreAlignedNonTemporal<T>(Vector256<T>, T*)	
                // Stores a vector at the given aligned destination.
                // StoreUnsafe<T>(Vector256<T>, T)	
                // Stores a vector at the given destination.
                // StoreUnsafe<T>(Vector256<T>, T, UIntPtr)	
                // Stores a vector at the given destination.
                // Ignore.

                // Subtract<T>(Vector256<T>, Vector256<T>)	
                // Subtracts writero vectors to compute their difference.
                WriteLine(writer, indent, "Subtract(Vector256s<Single>.Demo, Vector256s<Single>.V2):\t{0}", Vector256.Subtract(Vector256s<Single>.Demo, Vector256s<Single>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<Double>.Demo, Vector256s<Double>.V2):\t{0}", Vector256.Subtract(Vector256s<Double>.Demo, Vector256s<Double>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<SByte>.Demo, Vector256s<SByte>.V2):\t{0}", Vector256.Subtract(Vector256s<SByte>.Demo, Vector256s<SByte>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<Byte>.Demo, Vector256s<Byte>.V2):\t{0}", Vector256.Subtract(Vector256s<Byte>.Demo, Vector256s<Byte>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<Int16>.Demo, Vector256s<Int16>.V2):\t{0}", Vector256.Subtract(Vector256s<Int16>.Demo, Vector256s<Int16>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2):\t{0}", Vector256.Subtract(Vector256s<UInt16>.Demo, Vector256s<UInt16>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<Int32>.Demo, Vector256s<Int32>.V2):\t{0}", Vector256.Subtract(Vector256s<Int32>.Demo, Vector256s<Int32>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2):\t{0}", Vector256.Subtract(Vector256s<UInt32>.Demo, Vector256s<UInt32>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<Int64>.Demo, Vector256s<Int64>.V2):\t{0}", Vector256.Subtract(Vector256s<Int64>.Demo, Vector256s<Int64>.V2));
                WriteLine(writer, indent, "Subtract(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2):\t{0}", Vector256.Subtract(Vector256s<UInt64>.Demo, Vector256s<UInt64>.V2));

                // Sum<T>(Vector256<T>)	
                // Computes the sum of all elements in a vector.
                WriteLine(writer, indent, "Sum(Vector256s<Single>.Demo):\t{0}", Vector256.Sum(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<Double>.Demo):\t{0}", Vector256.Sum(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<SByte>.Demo):\t{0}", Vector256.Sum(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<Byte>.Demo):\t{0}", Vector256.Sum(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<Int16>.Demo):\t{0}", Vector256.Sum(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<UInt16>.Demo):\t{0}", Vector256.Sum(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<Int32>.Demo):\t{0}", Vector256.Sum(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<UInt32>.Demo):\t{0}", Vector256.Sum(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<Int64>.Demo):\t{0}", Vector256.Sum(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "Sum(Vector256s<UInt64>.Demo):\t{0}", Vector256.Sum(Vector256s<UInt64>.Demo));

                // ToScalar<T>(Vector256<T>)	
                // Converts the given vector to a scalar containing the value of the first element.
                WriteLine(writer, indent, "ToScalar(Vector256s<Single>.Demo):\t{0}", Vector256.ToScalar(Vector256s<Single>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<Double>.Demo):\t{0}", Vector256.ToScalar(Vector256s<Double>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<SByte>.Demo):\t{0}", Vector256.ToScalar(Vector256s<SByte>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<Byte>.Demo):\t{0}", Vector256.ToScalar(Vector256s<Byte>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<Int16>.Demo):\t{0}", Vector256.ToScalar(Vector256s<Int16>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<UInt16>.Demo):\t{0}", Vector256.ToScalar(Vector256s<UInt16>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<Int32>.Demo):\t{0}", Vector256.ToScalar(Vector256s<Int32>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<UInt32>.Demo):\t{0}", Vector256.ToScalar(Vector256s<UInt32>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<Int64>.Demo):\t{0}", Vector256.ToScalar(Vector256s<Int64>.Demo));
                WriteLine(writer, indent, "ToScalar(Vector256s<UInt64>.Demo):\t{0}", Vector256.ToScalar(Vector256s<UInt64>.Demo));

                // TryCopyTo<T>(Vector256<T>, Span<T>)	
                // Tries to copy a Vector<T> to a given span.
                // Ignore.

                // Widen(Vector256<Byte>)	
                // Widens a Vector256<T> into writero Vector256<T>.
                // Widen(Vector256<Int16>)	
                // Widens a Vector256<T> into writero Vector256<T>.
                // Widen(Vector256<Int32>)	
                // Widens a Vector256<T> into writero Vector256<T>.
                // Widen(Vector256<SByte>)	
                // Widens a Vector256<T> into writero Vector256<T>.
                // Widen(Vector256<Single>)	
                // Widens a Vector256<T> into writero Vector256<T>.
                // Widen(Vector256<UInt16>)	
                // Widens a Vector256<T> into writero Vector256<T>.
                // Widen(Vector256<UInt32>)	
                // Widens a Vector256<T> into writero Vector256<T>.
                if (true) {
                    (var low, var high) = Vector256.Widen(Vector256s<Single>.Demo);
                    WriteLine(writer, indent, "Widen(Vector256s<Single>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    (var low, var high) = Vector256.Widen(Vector256s<SByte>.Demo);
                    WriteLine(writer, indent, "Widen(Vector256s<SByte>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    (var low, var high) = Vector256.Widen(Vector256s<Byte>.Demo);
                    WriteLine(writer, indent, "Widen(Vector256s<Byte>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    (var low, var high) = Vector256.Widen(Vector256s<Int16>.Demo);
                    WriteLine(writer, indent, "Widen(Vector256s<Int16>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    (var low, var high) = Vector256.Widen(Vector256s<UInt16>.Demo);
                    WriteLine(writer, indent, "Widen(Vector256s<UInt16>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    (var low, var high) = Vector256.Widen(Vector256s<Int32>.Demo);
                    WriteLine(writer, indent, "Widen(Vector256s<Int32>.Demo):\t{0}, {1}", low, high);
                }
                if (true) {
                    (var low, var high) = Vector256.Widen(Vector256s<UInt32>.Demo);
                    WriteLine(writer, indent, "Widen(Vector256s<UInt32>.Demo):\t{0}, {1}", low, high);
                }

                // WithElement<T>(Vector256<T>, Int32, T)	
                // Creates a new Vector256<T> with the element at the specified index set to the specified value and the remaining elements set to the same value as that in the given vector.
                if (true) {
                    shift = 1;
                    WriteLine(writer, indent, "shift:\t{0}", shift);
                    WriteLine(writer, indent, "WithElement(Vector256s<Single>.Demo, shift):\t{0}", Vector256.WithElement(Vector256s<Single>.Demo, shift, Scalars<Single>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<Double>.Demo, shift, Scalars<Single>.V1):\t{0}", Vector256.WithElement(Vector256s<Double>.Demo, shift, Scalars<Single>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<SByte>.Demo, shift, Scalars<SByte>.V1):\t{0}", Vector256.WithElement(Vector256s<SByte>.Demo, shift, Scalars<SByte>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<Byte>.Demo, shift, Scalars<Byte>.V1):\t{0}", Vector256.WithElement(Vector256s<Byte>.Demo, shift, Scalars<Byte>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<Int16>.Demo, shift, Scalars<Int16>.V1):\t{0}", Vector256.WithElement(Vector256s<Int16>.Demo, shift, Scalars<Int16>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<UInt16>.Demo, shift, Scalars<UInt16>.V1):\t{0}", Vector256.WithElement(Vector256s<UInt16>.Demo, shift, Scalars<UInt16>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<Int32>.Demo, shift, Scalars<Int32>.V1):\t{0}", Vector256.WithElement(Vector256s<Int32>.Demo, shift, Scalars<Int32>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<UInt32>.Demo, shift, Scalars<UInt32>.V1):\t{0}", Vector256.WithElement(Vector256s<UInt32>.Demo, shift, Scalars<UInt32>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<Int64>.Demo, shift, Scalars<Int64>.V1):\t{0}", Vector256.WithElement(Vector256s<Int64>.Demo, shift, Scalars<Int64>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<UInt64>.Demo, shift, Scalars<UInt64>.V1):\t{0}", Vector256.WithElement(Vector256s<UInt64>.Demo, shift, Scalars<UInt64>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<IntPtr>.Demo, shift, Scalars<IntPtr>.V1):\t{0}", Vector256.WithElement(Vector256s<IntPtr>.Demo, shift, Scalars<IntPtr>.V1));
                    WriteLine(writer, indent, "WithElement(Vector256s<UIntPtr>.Demo, shift, Scalars<UIntPtr>.V1):\t{0}", Vector256.WithElement(Vector256s<UIntPtr>.Demo, shift, Scalars<UIntPtr>.V1));
                }

                // WithLower<T>(Vector256<T>, Vector128<T>)	
                // Creates a new Vector256<T> with the lower 128 bits set to the specified value and the upper 128 bits set to the same value as that in the given vector.
                WriteLine(writer, indent, "WithLower(Vector256s<Single>.Demo, Vector128s<Single>.V2):\t{0}", Vector256.WithLower(Vector256s<Single>.Demo, Vector128s<Single>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<Double>.Demo, Vector128s<Double>.V2):\t{0}", Vector256.WithLower(Vector256s<Double>.Demo, Vector128s<Double>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<SByte>.Demo, Vector128s<SByte>.V2):\t{0}", Vector256.WithLower(Vector256s<SByte>.Demo, Vector128s<SByte>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<Byte>.Demo, Vector128s<Byte>.V2):\t{0}", Vector256.WithLower(Vector256s<Byte>.Demo, Vector128s<Byte>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<Int16>.Demo, Vector128s<Int16>.V2):\t{0}", Vector256.WithLower(Vector256s<Int16>.Demo, Vector128s<Int16>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<UInt16>.Demo, Vector128s<UInt16>.V2):\t{0}", Vector256.WithLower(Vector256s<UInt16>.Demo, Vector128s<UInt16>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<Int32>.Demo, Vector128s<Int32>.V2):\t{0}", Vector256.WithLower(Vector256s<Int32>.Demo, Vector128s<Int32>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<UInt32>.Demo, Vector128s<UInt32>.V2):\t{0}", Vector256.WithLower(Vector256s<UInt32>.Demo, Vector128s<UInt32>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<Int64>.Demo, Vector128s<Int64>.V2):\t{0}", Vector256.WithLower(Vector256s<Int64>.Demo, Vector128s<Int64>.V2));
                WriteLine(writer, indent, "WithLower(Vector256s<UInt64>.Demo, Vector128s<UInt64>.V2):\t{0}", Vector256.WithLower(Vector256s<UInt64>.Demo, Vector128s<UInt64>.V2));

                // WithUpper<T>(Vector256<T>, Vector128<T>)	
                // Creates a new Vector256<T> with the upper 128 bits set to the specified value and the lower 128 bits set to the same value as that in the given vector.
                WriteLine(writer, indent, "WithUpper(Vector256s<Single>.Demo, Vector128s<Single>.V2):\t{0}", Vector256.WithUpper(Vector256s<Single>.Demo, Vector128s<Single>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<Double>.Demo, Vector128s<Double>.V2):\t{0}", Vector256.WithUpper(Vector256s<Double>.Demo, Vector128s<Double>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<SByte>.Demo, Vector128s<SByte>.V2):\t{0}", Vector256.WithUpper(Vector256s<SByte>.Demo, Vector128s<SByte>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<Byte>.Demo, Vector128s<Byte>.V2):\t{0}", Vector256.WithUpper(Vector256s<Byte>.Demo, Vector128s<Byte>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<Int16>.Demo, Vector128s<Int16>.V2):\t{0}", Vector256.WithUpper(Vector256s<Int16>.Demo, Vector128s<Int16>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<UInt16>.Demo, Vector128s<UInt16>.V2):\t{0}", Vector256.WithUpper(Vector256s<UInt16>.Demo, Vector128s<UInt16>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<Int32>.Demo, Vector128s<Int32>.V2):\t{0}", Vector256.WithUpper(Vector256s<Int32>.Demo, Vector128s<Int32>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<UInt32>.Demo, Vector128s<UInt32>.V2):\t{0}", Vector256.WithUpper(Vector256s<UInt32>.Demo, Vector128s<UInt32>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<Int64>.Demo, Vector128s<Int64>.V2):\t{0}", Vector256.WithUpper(Vector256s<Int64>.Demo, Vector128s<Int64>.V2));
                WriteLine(writer, indent, "WithUpper(Vector256s<UInt64>.Demo, Vector128s<UInt64>.V2):\t{0}", Vector256.WithUpper(Vector256s<UInt64>.Demo, Vector128s<UInt64>.V2));

                // Xor<T>(Vector256<T>, Vector256<T>)	
                // Computes the exclusive-or of writero vectors.
                WriteLine(writer, indent, "Xor(Vector256s<Single>.Demo, Vector256s<Single>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<Single>.Demo, Vector256s<Single>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<Double>.Demo, Vector256s<Double>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<Double>.Demo, Vector256s<Double>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<SByte>.Demo, Vector256s<SByte>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<SByte>.Demo, Vector256s<SByte>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<Byte>.Demo, Vector256s<Byte>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<Byte>.Demo, Vector256s<Byte>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<Int16>.Demo, Vector256s<Int16>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<Int16>.Demo, Vector256s<Int16>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<UInt16>.Demo, Vector256s<UInt16>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<UInt16>.Demo, Vector256s<UInt16>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<Int32>.Demo, Vector256s<Int32>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<Int32>.Demo, Vector256s<Int32>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<UInt32>.Demo, Vector256s<UInt32>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<UInt32>.Demo, Vector256s<UInt32>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<Int64>.Demo, Vector256s<Int64>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<Int64>.Demo, Vector256s<Int64>.XyzwWMask));
                WriteLine(writer, indent, "Xor(Vector256s<UInt64>.Demo, Vector256s<UInt64>.XyzwWMask):\t{0}", Vector256.Xor(Vector256s<UInt64>.Demo, Vector256s<UInt64>.XyzwWMask));
            }

#else
            // none.
#endif // NET7_0_OR_GREATER
        }
    }

}
