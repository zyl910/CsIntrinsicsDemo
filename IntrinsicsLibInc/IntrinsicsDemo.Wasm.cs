using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics.Wasm;
#endif // NET8_0_OR_GREATER
using System.Text;
using Zyl.VectorTraits;

namespace IntrinsicsLib {
    partial class IntrinsicsDemo {
#if NET8_0_OR_GREATER

        /// <summary>
        /// Run Wasm. https://webassembly.github.io/spec/
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunWasm(TextWriter writer, string indent) {
#if NETX_0_OR_GREATER
            bool isSupported = WasmBase.IsSupported;
#else
            bool isSupported = PackedSimd.IsSupported;
#endif
            RunWasmSupported(writer, indent);
            if (!isSupported) return;
            Action<TextWriter, string>[] list = {
                RunWasmPackedSimd,
            };
            TraitsUtil.InvokeArray(writer, indent, list);
        }

        /// <summary>
        /// Run Wasm Supported. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.wasm?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunWasmSupported(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            writer.WriteLine();
            writer.WriteLine(indent + "[Intrinsics.Wasm]");
            WriteLine(writer, indent, "PackedSimd.IsSupported:\t{0}", PackedSimd.IsSupported);
        }

        /// <summary>
        /// Run Wasm PackedSimd. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.wasm.packedsimd?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunWasmPackedSimd(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = PackedSimd.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- PackedSimd.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

            //Abs(Vector128<Double>)
            //Abs(Vector128<Int16>)
            //Abs(Vector128<Int32>)
            //Abs(Vector128<Int64>)
            //Abs(Vector128<IntPtr>)
            //Abs(Vector128<SByte>)
            //Abs(Vector128<Single>)
            //Add(Vector128<Byte>, Vector128<Byte>)
            //Add(Vector128<Double>, Vector128<Double>)
            //Add(Vector128<Int16>, Vector128<Int16>)
            //Add(Vector128<Int32>, Vector128<Int32>)
            //Add(Vector128<Int64>, Vector128<Int64>)
            //Add(Vector128<IntPtr>, Vector128<IntPtr>)
            //Add(Vector128<SByte>, Vector128<SByte>)
            //Add(Vector128<Single>, Vector128<Single>)
            //Add(Vector128<UInt16>, Vector128<UInt16>)
            //Add(Vector128<UInt32>, Vector128<UInt32>)
            //Add(Vector128<UInt64>, Vector128<UInt64>)
            //Add(Vector128<UIntPtr>, Vector128<UIntPtr>)

            //AddPairwiseWidening(Vector128<Byte>)
            //AddPairwiseWidening(Vector128<Int16>)
            //AddPairwiseWidening(Vector128<SByte>)
            //AddPairwiseWidening(Vector128<UInt16>)
            // Adds lanes pairwise producing twice wider extended results.
            WriteLine(writer, indent, "AddPairwiseWidening(Vector128s<Byte>.Demo):\t{0}", PackedSimd.AddPairwiseWidening(Vector128s<Byte>.Demo));
            WriteLine(writer, indent, "AddPairwiseWidening(Vector128s<SByte>.Demo):\t{0}", PackedSimd.AddPairwiseWidening(Vector128s<SByte>.Demo));
            WriteLine(writer, indent, "AddPairwiseWidening(Vector128s<Int16>.Demo):\t{0}", PackedSimd.AddPairwiseWidening(Vector128s<Int16>.Demo));
            WriteLine(writer, indent, "AddPairwiseWidening(Vector128s<UInt16>.Demo):\t{0}", PackedSimd.AddPairwiseWidening(Vector128s<UInt16>.Demo));

            //AddSaturate(Vector128<Byte>, Vector128<Byte>)
            //AddSaturate(Vector128<Int16>, Vector128<Int16>)
            //AddSaturate(Vector128<SByte>, Vector128<SByte>)
            //AddSaturate(Vector128<UInt16>, Vector128<UInt16>)

            //AllTrue(Vector128<Byte>)
            //AllTrue(Vector128<Int16>)
            //AllTrue(Vector128<Int32>)
            //AllTrue(Vector128<Int64>)
            //AllTrue(Vector128<IntPtr>)
            //AllTrue(Vector128<SByte>)
            //AllTrue(Vector128<UInt16>)
            //AllTrue(Vector128<UInt32>)
            //AllTrue(Vector128<UInt64>)
            //AllTrue(Vector128<UIntPtr>)
            //And(Vector128<Byte>, Vector128<Byte>)
            //And(Vector128<Double>, Vector128<Double>)
            //And(Vector128<Int16>, Vector128<Int16>)
            //And(Vector128<Int32>, Vector128<Int32>)
            //And(Vector128<Int64>, Vector128<Int64>)
            //And(Vector128<IntPtr>, Vector128<IntPtr>)
            //And(Vector128<SByte>, Vector128<SByte>)
            //And(Vector128<Single>, Vector128<Single>)
            //And(Vector128<UInt16>, Vector128<UInt16>)
            //And(Vector128<UInt32>, Vector128<UInt32>)
            //And(Vector128<UInt64>, Vector128<UInt64>)
            //And(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //AndNot(Vector128<Byte>, Vector128<Byte>)
            //AndNot(Vector128<Double>, Vector128<Double>)
            //AndNot(Vector128<Int16>, Vector128<Int16>)
            //AndNot(Vector128<Int32>, Vector128<Int32>)
            //AndNot(Vector128<Int64>, Vector128<Int64>)
            //AndNot(Vector128<IntPtr>, Vector128<IntPtr>)
            //AndNot(Vector128<SByte>, Vector128<SByte>)
            //AndNot(Vector128<Single>, Vector128<Single>)
            //AndNot(Vector128<UInt16>, Vector128<UInt16>)
            //AndNot(Vector128<UInt32>, Vector128<UInt32>)
            //AndNot(Vector128<UInt64>, Vector128<UInt64>)
            //AndNot(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //AnyTrue(Vector128<Byte>)
            //AnyTrue(Vector128<Double>)
            //AnyTrue(Vector128<Int16>)
            //AnyTrue(Vector128<Int32>)
            //AnyTrue(Vector128<Int64>)
            //AnyTrue(Vector128<IntPtr>)
            //AnyTrue(Vector128<SByte>)
            //AnyTrue(Vector128<Single>)
            //AnyTrue(Vector128<UInt16>)
            //AnyTrue(Vector128<UInt32>)
            //AnyTrue(Vector128<UInt64>)
            //AnyTrue(Vector128<UIntPtr>)

            //AverageRounded(Vector128<Byte>, Vector128<Byte>) i8x16.avgr.u
            //AverageRounded(Vector128<UInt16>, Vector128<UInt16>) i16x8.avgr.u
            // Computes the rounding average of each unsigned small integer lane.
            WriteLine(writer, indent, "AverageRounded(Vector128s<Byte>.Demo, Vector128s<Byte>.V2):\t{0}", PackedSimd.AverageRounded(Vector128s<Byte>.Demo, Vector128s<Byte>.V2));
            WriteLine(writer, indent, "AverageRounded(Vector128s<UInt16>.Demo, Vector128s<UInt16>.V2):\t{0}", PackedSimd.AverageRounded(Vector128s<UInt16>.Demo, Vector128s<UInt16>.V2));

            //Bitmask(Vector128<Byte>)
            //Bitmask(Vector128<Int16>)
            //Bitmask(Vector128<Int32>)
            //Bitmask(Vector128<Int64>)
            //Bitmask(Vector128<IntPtr>)
            //Bitmask(Vector128<SByte>)
            //Bitmask(Vector128<UInt16>)
            //Bitmask(Vector128<UInt32>)
            //Bitmask(Vector128<UInt64>)
            //Bitmask(Vector128<UIntPtr>)
            WriteLine(writer, indent, "Bitmask(Vector128s<Byte>.Demo):\t{0}", PackedSimd.Bitmask(Vector128s<Byte>.Demo));
            WriteLine(writer, indent, "Bitmask(Vector128s<SByte>.Demo):\t{0}", PackedSimd.Bitmask(Vector128s<SByte>.Demo));
            WriteLine(writer, indent, "Bitmask(Vector128s<Int16>.Demo):\t{0}", PackedSimd.Bitmask(Vector128s<Int16>.Demo));
            WriteLine(writer, indent, "Bitmask(Vector128s<UInt16>.Demo):\t{0}", PackedSimd.Bitmask(Vector128s<UInt16>.Demo));
            WriteLine(writer, indent, "Bitmask(Vector128s<Int32>.Demo):\t{0}", PackedSimd.Bitmask(Vector128s<Int32>.Demo));
            WriteLine(writer, indent, "Bitmask(Vector128s<UInt32>.Demo):\t{0}", PackedSimd.Bitmask(Vector128s<UInt32>.Demo));
            WriteLine(writer, indent, "Bitmask(Vector128s<Int64>.Demo):\t{0}", PackedSimd.Bitmask(Vector128s<Int64>.Demo));
            WriteLine(writer, indent, "Bitmask(Vector128s<UInt64>.Demo):\t{0}", PackedSimd.Bitmask(Vector128s<UInt64>.Demo));

            //BitwiseSelect(Vector128<Byte>, Vector128<Byte>, Vector128<Byte>)
            //BitwiseSelect(Vector128<Double>, Vector128<Double>, Vector128<Double>)
            //BitwiseSelect(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>)
            //BitwiseSelect(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>)
            //BitwiseSelect(Vector128<Int64>, Vector128<Int64>, Vector128<Int64>)
            //BitwiseSelect(Vector128<IntPtr>, Vector128<IntPtr>, Vector128<IntPtr>)
            //BitwiseSelect(Vector128<SByte>, Vector128<SByte>, Vector128<SByte>)
            //BitwiseSelect(Vector128<Single>, Vector128<Single>, Vector128<Single>)
            //BitwiseSelect(Vector128<UInt16>, Vector128<UInt16>, Vector128<UInt16>)
            //BitwiseSelect(Vector128<UInt32>, Vector128<UInt32>, Vector128<UInt32>)
            //BitwiseSelect(Vector128<UInt64>, Vector128<UInt64>, Vector128<UInt64>)
            //BitwiseSelect(Vector128<UIntPtr>, Vector128<UIntPtr>, Vector128<UIntPtr>)

            //Ceiling(Vector128<Double>)
            //Ceiling(Vector128<Single>)

            //CompareEqual(Vector128<Byte>, Vector128<Byte>)
            //CompareEqual(Vector128<Double>, Vector128<Double>)
            //CompareEqual(Vector128<Int16>, Vector128<Int16>)
            //CompareEqual(Vector128<Int32>, Vector128<Int32>)
            //CompareEqual(Vector128<Int64>, Vector128<Int64>)
            //CompareEqual(Vector128<IntPtr>, Vector128<IntPtr>)
            //CompareEqual(Vector128<SByte>, Vector128<SByte>)
            //CompareEqual(Vector128<Single>, Vector128<Single>)
            //CompareEqual(Vector128<UInt16>, Vector128<UInt16>)
            //CompareEqual(Vector128<UInt32>, Vector128<UInt32>)
            //CompareEqual(Vector128<UInt64>, Vector128<UInt64>)
            //CompareEqual(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //CompareGreaterThan(Vector128<Byte>, Vector128<Byte>)
            //CompareGreaterThan(Vector128<Double>, Vector128<Double>)
            //CompareGreaterThan(Vector128<Int16>, Vector128<Int16>)
            //CompareGreaterThan(Vector128<Int32>, Vector128<Int32>)
            //CompareGreaterThan(Vector128<Int64>, Vector128<Int64>)
            //CompareGreaterThan(Vector128<IntPtr>, Vector128<IntPtr>)
            //CompareGreaterThan(Vector128<SByte>, Vector128<SByte>)
            //CompareGreaterThan(Vector128<Single>, Vector128<Single>)
            //CompareGreaterThan(Vector128<UInt16>, Vector128<UInt16>)
            //CompareGreaterThan(Vector128<UInt32>, Vector128<UInt32>)
            //CompareGreaterThan(Vector128<UInt64>, Vector128<UInt64>)
            //CompareGreaterThan(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //CompareGreaterThanOrEqual(Vector128<Byte>, Vector128<Byte>)
            //CompareGreaterThanOrEqual(Vector128<Double>, Vector128<Double>)
            //CompareGreaterThanOrEqual(Vector128<Int16>, Vector128<Int16>)
            //CompareGreaterThanOrEqual(Vector128<Int32>, Vector128<Int32>)
            //CompareGreaterThanOrEqual(Vector128<Int64>, Vector128<Int64>)
            //CompareGreaterThanOrEqual(Vector128<IntPtr>, Vector128<IntPtr>)
            //CompareGreaterThanOrEqual(Vector128<SByte>, Vector128<SByte>)
            //CompareGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)
            //CompareGreaterThanOrEqual(Vector128<UInt16>, Vector128<UInt16>)
            //CompareGreaterThanOrEqual(Vector128<UInt32>, Vector128<UInt32>)
            //CompareGreaterThanOrEqual(Vector128<UInt64>, Vector128<UInt64>)
            //CompareGreaterThanOrEqual(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //CompareLessThan(Vector128<Byte>, Vector128<Byte>)
            //CompareLessThan(Vector128<Double>, Vector128<Double>)
            //CompareLessThan(Vector128<Int16>, Vector128<Int16>)
            //CompareLessThan(Vector128<Int32>, Vector128<Int32>)
            //CompareLessThan(Vector128<Int64>, Vector128<Int64>)
            //CompareLessThan(Vector128<IntPtr>, Vector128<IntPtr>)
            //CompareLessThan(Vector128<SByte>, Vector128<SByte>)
            //CompareLessThan(Vector128<Single>, Vector128<Single>)
            //CompareLessThan(Vector128<UInt16>, Vector128<UInt16>)
            //CompareLessThan(Vector128<UInt32>, Vector128<UInt32>)
            //CompareLessThan(Vector128<UInt64>, Vector128<UInt64>)
            //CompareLessThan(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //CompareLessThanOrEqual(Vector128<Byte>, Vector128<Byte>)
            //CompareLessThanOrEqual(Vector128<Double>, Vector128<Double>)
            //CompareLessThanOrEqual(Vector128<Int16>, Vector128<Int16>)
            //CompareLessThanOrEqual(Vector128<Int32>, Vector128<Int32>)
            //CompareLessThanOrEqual(Vector128<Int64>, Vector128<Int64>)
            //CompareLessThanOrEqual(Vector128<IntPtr>, Vector128<IntPtr>)
            //CompareLessThanOrEqual(Vector128<SByte>, Vector128<SByte>)
            //CompareLessThanOrEqual(Vector128<Single>, Vector128<Single>)
            //CompareLessThanOrEqual(Vector128<UInt16>, Vector128<UInt16>)
            //CompareLessThanOrEqual(Vector128<UInt32>, Vector128<UInt32>)
            //CompareLessThanOrEqual(Vector128<UInt64>, Vector128<UInt64>)
            //CompareLessThanOrEqual(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //CompareNotEqual(Vector128<Byte>, Vector128<Byte>)
            //CompareNotEqual(Vector128<Double>, Vector128<Double>)
            //CompareNotEqual(Vector128<Int16>, Vector128<Int16>)
            //CompareNotEqual(Vector128<Int32>, Vector128<Int32>)
            //CompareNotEqual(Vector128<Int64>, Vector128<Int64>)
            //CompareNotEqual(Vector128<IntPtr>, Vector128<IntPtr>)
            //CompareNotEqual(Vector128<SByte>, Vector128<SByte>)
            //CompareNotEqual(Vector128<Single>, Vector128<Single>)
            //CompareNotEqual(Vector128<UInt16>, Vector128<UInt16>)
            //CompareNotEqual(Vector128<UInt32>, Vector128<UInt32>)
            //CompareNotEqual(Vector128<UInt64>, Vector128<UInt64>)
            //CompareNotEqual(Vector128<UIntPtr>, Vector128<UIntPtr>)

            //ConvertNarrowingSaturateSigned(Vector128<Int16>, Vector128<Int16>)
            //ConvertNarrowingSaturateSigned(Vector128<Int32>, Vector128<Int32>)
            WriteLine(writer, indent, "ConvertNarrowingSaturateSigned(Vector128s<Int16>.Demo, Vector128s<Int16>.V2):\t{0}", PackedSimd.ConvertNarrowingSaturateSigned(Vector128s<Int16>.Demo, Vector128s<Int16>.V2));
            WriteLine(writer, indent, "ConvertNarrowingSaturateSigned(Vector128s<Int32>.Demo, Vector128s<Int32>.V2):\t{0}", PackedSimd.ConvertNarrowingSaturateSigned(Vector128s<Int32>.Demo, Vector128s<Int32>.V2));

            //ConvertNarrowingSaturateUnsigned(Vector128<Int16>, Vector128<Int16>)
            //ConvertNarrowingSaturateUnsigned(Vector128<Int32>, Vector128<Int32>)
            WriteLine(writer, indent, "ConvertNarrowingSaturateUnsigned(Vector128s<Int16>.Demo, Vector128s<Int16>.V2):\t{0}", PackedSimd.ConvertNarrowingSaturateUnsigned(Vector128s<Int16>.Demo, Vector128s<Int16>.V2));
            WriteLine(writer, indent, "ConvertNarrowingSaturateUnsigned(Vector128s<Int32>.Demo, Vector128s<Int32>.V2):\t{0}", PackedSimd.ConvertNarrowingSaturateUnsigned(Vector128s<Int32>.Demo, Vector128s<Int32>.V2));

            //ConvertToDoubleLower(Vector128<Int32>)
            //ConvertToDoubleLower(Vector128<Single>)
            //ConvertToDoubleLower(Vector128<UInt32>)

            //ConvertToInt32Saturate(Vector128<Double>) // i32x4.trunc_sat_f64x2_s_zero
            //ConvertToInt32Saturate(Vector128<Single>) // i32x4.trunc_sat_f32x4_s
            WriteLine(writer, indent, "ConvertToInt32Saturate(Vector128s<Double>.Demo):\t{0}", PackedSimd.ConvertToInt32Saturate(Vector128s<Double>.Demo));
            WriteLine(writer, indent, "ConvertToInt32Saturate(Vector128s<Single>.Demo):\t{0}", PackedSimd.ConvertToInt32Saturate(Vector128s<Single>.Demo));

            //ConvertToSingle(Vector128<Double>)
            //ConvertToSingle(Vector128<Int32>)
            //ConvertToSingle(Vector128<UInt32>)

            //ConvertToUInt32Saturate(Vector128<Double>) // i32x4.trunc_sat_f64x2_u_zero
            //ConvertToUInt32Saturate(Vector128<Single>) // i32x4.trunc_sat_f32x4_u
            WriteLine(writer, indent, "ConvertToUInt32Saturate(Vector128s<Double>.Demo):\t{0}", PackedSimd.ConvertToUInt32Saturate(Vector128s<Double>.Demo));
            WriteLine(writer, indent, "ConvertToUInt32Saturate(Vector128s<Single>.Demo):\t{0}", PackedSimd.ConvertToUInt32Saturate(Vector128s<Single>.Demo));

            //Divide(Vector128<Double>, Vector128<Double>)
            //Divide(Vector128<Single>, Vector128<Single>)

            //Dot(Vector128<Int16>, Vector128<Int16>)
            WriteLine(writer, indent, "Dot(Vector128s<Int16>.Demo, Vector128s<Int16>.V2):\t{0}", PackedSimd.Dot(Vector128s<Int16>.Demo, Vector128s<Int16>.V2));

            //ExtractScalar(Vector128<Byte>, Byte)
            //ExtractScalar(Vector128<Double>, Byte)
            //ExtractScalar(Vector128<Int16>, Byte)
            //ExtractScalar(Vector128<Int32>, Byte)
            //ExtractScalar(Vector128<Int64>, Byte)
            //ExtractScalar(Vector128<IntPtr>, Byte)
            //ExtractScalar(Vector128<SByte>, Byte)
            //ExtractScalar(Vector128<Single>, Byte)
            //ExtractScalar(Vector128<UInt16>, Byte)
            //ExtractScalar(Vector128<UInt32>, Byte)
            //ExtractScalar(Vector128<UInt64>, Byte)
            //ExtractScalar(Vector128<UIntPtr>, Byte)
            //Floor(Vector128<Double>)
            //Floor(Vector128<Single>)
            //LoadScalarAndInsert(Byte*, Vector128<Byte>, Byte)
            //LoadScalarAndInsert(Double*, Vector128<Double>, Byte)
            //LoadScalarAndInsert(Int16*, Vector128<Int16>, Byte)
            //LoadScalarAndInsert(Int32*, Vector128<Int32>, Byte)
            //LoadScalarAndInsert(Int64*, Vector128<Int64>, Byte)
            //LoadScalarAndInsert(IntPtr*, Vector128<IntPtr>, Byte)
            //LoadScalarAndInsert(SByte*, Vector128<SByte>, Byte)
            //LoadScalarAndInsert(Single*, Vector128<Single>, Byte)
            //LoadScalarAndInsert(UInt16*, Vector128<UInt16>, Byte)
            //LoadScalarAndInsert(UInt32*, Vector128<UInt32>, Byte)
            //LoadScalarAndInsert(UInt64*, Vector128<UInt64>, Byte)
            //LoadScalarAndInsert(UIntPtr*, Vector128<UIntPtr>, Byte)
            //LoadScalarAndSplatVector128(Byte*)
            //LoadScalarAndSplatVector128(Double*)
            //LoadScalarAndSplatVector128(Int16*)
            //LoadScalarAndSplatVector128(Int32*)
            //LoadScalarAndSplatVector128(Int64*)
            //LoadScalarAndSplatVector128(IntPtr*)
            //LoadScalarAndSplatVector128(SByte*)
            //LoadScalarAndSplatVector128(Single*)
            //LoadScalarAndSplatVector128(UInt16*)
            //LoadScalarAndSplatVector128(UInt32*)
            //LoadScalarAndSplatVector128(UInt64*)
            //LoadScalarAndSplatVector128(UIntPtr*)
            //LoadScalarVector128(Double*)
            //LoadScalarVector128(Int32*)
            //LoadScalarVector128(Int64*)
            //LoadScalarVector128(IntPtr*)
            //LoadScalarVector128(Single*)
            //LoadScalarVector128(UInt32*)
            //LoadScalarVector128(UInt64*)
            //LoadScalarVector128(UIntPtr*)
            //LoadVector128(Byte*)
            //LoadVector128(Double*)
            //LoadVector128(Int16*)
            //LoadVector128(Int32*)
            //LoadVector128(Int64*)
            //LoadVector128(IntPtr*)
            //LoadVector128(SByte*)
            //LoadVector128(Single*)
            //LoadVector128(UInt16*)
            //LoadVector128(UInt32*)
            //LoadVector128(UInt64*)
            //LoadVector128(UIntPtr*)

            //LoadWideningVector128(Byte*)
            //LoadWideningVector128(Int16*)
            //LoadWideningVector128(Int32*)
            //LoadWideningVector128(SByte*)
            //LoadWideningVector128(UInt16*)
            //LoadWideningVector128(UInt32*)

            //Max(Vector128<Byte>, Vector128<Byte>)
            //Max(Vector128<Double>, Vector128<Double>) // f64x2.max
            //Max(Vector128<Int16>, Vector128<Int16>)
            //Max(Vector128<Int32>, Vector128<Int32>)
            //Max(Vector128<SByte>, Vector128<SByte>)
            //Max(Vector128<Single>, Vector128<Single>) // f32x4.max
            //Max(Vector128<UInt16>, Vector128<UInt16>)
            //Max(Vector128<UInt32>, Vector128<UInt32>)
            // Computes the maximum of each lane.
            WriteLine(writer, indent, "Max(Vector128s<Double>.Demo, Vector128s<Double>.V2):\t{0}", PackedSimd.Max(Vector128s<Double>.Demo, Vector128s<Double>.V2));
            WriteLine(writer, indent, "Max(Vector128s<Single>.Demo, Vector128s<Single>.V2):\t{0}", PackedSimd.Max(Vector128s<Single>.Demo, Vector128s<Single>.V2));

            //Min(Vector128<Byte>, Vector128<Byte>)
            //Min(Vector128<Double>, Vector128<Double>)
            //Min(Vector128<Int16>, Vector128<Int16>)
            //Min(Vector128<Int32>, Vector128<Int32>)
            //Min(Vector128<SByte>, Vector128<SByte>)
            //Min(Vector128<Single>, Vector128<Single>)
            //Min(Vector128<UInt16>, Vector128<UInt16>)
            //Min(Vector128<UInt32>, Vector128<UInt32>)
            WriteLine(writer, indent, "Min(Vector128s<Double>.Demo, Vector128s<Double>.V2):\t{0}", PackedSimd.Min(Vector128s<Double>.Demo, Vector128s<Double>.V2));
            WriteLine(writer, indent, "Min(Vector128s<Single>.Demo, Vector128s<Single>.V2):\t{0}", PackedSimd.Min(Vector128s<Single>.Demo, Vector128s<Single>.V2));

            //Multiply(Vector128<Double>, Vector128<Double>)
            //Multiply(Vector128<Int16>, Vector128<Int16>)
            //Multiply(Vector128<Int32>, Vector128<Int32>)
            //Multiply(Vector128<Int64>, Vector128<Int64>)
            //Multiply(Vector128<IntPtr>, Vector128<IntPtr>)
            //Multiply(Vector128<Single>, Vector128<Single>)
            //Multiply(Vector128<UInt16>, Vector128<UInt16>)
            //Multiply(Vector128<UInt32>, Vector128<UInt32>)
            //Multiply(Vector128<UInt64>, Vector128<UInt64>)
            //Multiply(Vector128<UIntPtr>, Vector128<UIntPtr>)

            //MultiplyRoundedSaturateQ15(Vector128<Int16>, Vector128<Int16>) i16x8.q15mulr.sat.s
            // Performs the line-wise saturating rounding multiplication in Q15 format ((a[i] * b[i] + (1 << (Q - 1))) >> Q where Q=15).
            WriteLine(writer, indent, "MultiplyRoundedSaturateQ15(Vector128s<Int16>.Demo, Vector128s<Int16>.V2):\t{0}", PackedSimd.MultiplyRoundedSaturateQ15(Vector128s<Int16>.Demo, Vector128s<Int16>.V2));

            //MultiplyWideningLower(Vector128<Byte>, Vector128<Byte>)
            //MultiplyWideningLower(Vector128<Int16>, Vector128<Int16>)
            //MultiplyWideningLower(Vector128<Int32>, Vector128<Int32>)
            //MultiplyWideningLower(Vector128<SByte>, Vector128<SByte>)
            //MultiplyWideningLower(Vector128<UInt16>, Vector128<UInt16>)
            //MultiplyWideningLower(Vector128<UInt32>, Vector128<UInt32>)
            WriteLine(writer, indent, "MultiplyWideningLower(Vector128s<SByte>.Demo, Vector128s<SByte>.V2):\t{0}", PackedSimd.MultiplyWideningLower(Vector128s<SByte>.Demo, Vector128s<SByte>.V2));
            WriteLine(writer, indent, "MultiplyWideningLower(Vector128s<Byte>.Demo, Vector128s<Byte>.V2):\t{0}", PackedSimd.MultiplyWideningLower(Vector128s<Byte>.Demo, Vector128s<Byte>.V2));
            WriteLine(writer, indent, "MultiplyWideningLower(Vector128s<Int16>.Demo, Vector128s<Int16>.V2):\t{0}", PackedSimd.MultiplyWideningLower(Vector128s<Int16>.Demo, Vector128s<Int16>.V2));
            WriteLine(writer, indent, "MultiplyWideningLower(Vector128s<UInt16>.Demo, Vector128s<UInt16>.V2):\t{0}", PackedSimd.MultiplyWideningLower(Vector128s<UInt16>.Demo, Vector128s<UInt16>.V2));
            WriteLine(writer, indent, "MultiplyWideningLower(Vector128s<Int32>.Demo, Vector128s<Int32>.V2):\t{0}", PackedSimd.MultiplyWideningLower(Vector128s<Int32>.Demo, Vector128s<Int32>.V2));
            WriteLine(writer, indent, "MultiplyWideningLower(Vector128s<UInt32>.Demo, Vector128s<UInt32>.V2):\t{0}", PackedSimd.MultiplyWideningLower(Vector128s<UInt32>.Demo, Vector128s<UInt32>.V2));

            //MultiplyWideningUpper(Vector128<Byte>, Vector128<Byte>)
            //MultiplyWideningUpper(Vector128<Int16>, Vector128<Int16>)
            //MultiplyWideningUpper(Vector128<Int32>, Vector128<Int32>)
            //MultiplyWideningUpper(Vector128<SByte>, Vector128<SByte>)
            //MultiplyWideningUpper(Vector128<UInt16>, Vector128<UInt16>)
            //MultiplyWideningUpper(Vector128<UInt32>, Vector128<UInt32>)
            WriteLine(writer, indent, "MultiplyWideningUpper(Vector128s<SByte>.Demo, Vector128s<SByte>.V2):\t{0}", PackedSimd.MultiplyWideningUpper(Vector128s<SByte>.Demo, Vector128s<SByte>.V2));
            WriteLine(writer, indent, "MultiplyWideningUpper(Vector128s<Byte>.Demo, Vector128s<Byte>.V2):\t{0}", PackedSimd.MultiplyWideningUpper(Vector128s<Byte>.Demo, Vector128s<Byte>.V2));
            WriteLine(writer, indent, "MultiplyWideningUpper(Vector128s<Int16>.Demo, Vector128s<Int16>.V2):\t{0}", PackedSimd.MultiplyWideningUpper(Vector128s<Int16>.Demo, Vector128s<Int16>.V2));
            WriteLine(writer, indent, "MultiplyWideningUpper(Vector128s<UInt16>.Demo, Vector128s<UInt16>.V2):\t{0}", PackedSimd.MultiplyWideningUpper(Vector128s<UInt16>.Demo, Vector128s<UInt16>.V2));
            WriteLine(writer, indent, "MultiplyWideningUpper(Vector128s<Int32>.Demo, Vector128s<Int32>.V2):\t{0}", PackedSimd.MultiplyWideningUpper(Vector128s<Int32>.Demo, Vector128s<Int32>.V2));
            WriteLine(writer, indent, "MultiplyWideningUpper(Vector128s<UInt32>.Demo, Vector128s<UInt32>.V2):\t{0}", PackedSimd.MultiplyWideningUpper(Vector128s<UInt32>.Demo, Vector128s<UInt32>.V2));

            //Negate(Vector128<Byte>)
            //Negate(Vector128<Double>)
            //Negate(Vector128<Int16>)
            //Negate(Vector128<Int32>)
            //Negate(Vector128<Int64>)
            //Negate(Vector128<IntPtr>)
            //Negate(Vector128<SByte>)
            //Negate(Vector128<Single>)
            //Negate(Vector128<UInt16>)
            //Negate(Vector128<UInt32>)
            //Negate(Vector128<UInt64>)
            //Negate(Vector128<UIntPtr>)
            //Not(Vector128<Byte>)
            //Not(Vector128<Double>)
            //Not(Vector128<Int16>)
            //Not(Vector128<Int32>)
            //Not(Vector128<Int64>)
            //Not(Vector128<IntPtr>)
            //Not(Vector128<SByte>)
            //Not(Vector128<Single>)
            //Not(Vector128<UInt16>)
            //Not(Vector128<UInt32>)
            //Not(Vector128<UInt64>)
            //Not(Vector128<UIntPtr>)
            //Or(Vector128<Byte>, Vector128<Byte>)
            //Or(Vector128<Double>, Vector128<Double>)
            //Or(Vector128<Int16>, Vector128<Int16>)
            //Or(Vector128<Int32>, Vector128<Int32>)
            //Or(Vector128<Int64>, Vector128<Int64>)
            //Or(Vector128<IntPtr>, Vector128<IntPtr>)
            //Or(Vector128<SByte>, Vector128<SByte>)
            //Or(Vector128<Single>, Vector128<Single>)
            //Or(Vector128<UInt16>, Vector128<UInt16>)
            //Or(Vector128<UInt32>, Vector128<UInt32>)
            //Or(Vector128<UInt64>, Vector128<UInt64>)
            //Or(Vector128<UIntPtr>, Vector128<UIntPtr>)

            //PopCount(Vector128<Byte>)
            WriteLine(writer, indent, "PopCount(Vector128s<Byte>.Demo):\t{0}", PackedSimd.PopCount(Vector128s<Byte>.Demo));

            //PseudoMax(Vector128<Double>, Vector128<Double>) // f64x2.pmax
            //PseudoMax(Vector128<Single>, Vector128<Single>) // f32x4.pmax
            // Computes the pseudo-maximum of each lane.
            WriteLine(writer, indent, "PseudoMax(Vector128s<Double>.Demo, Vector128s<Double>.V2):\t{0}", PackedSimd.PseudoMax(Vector128s<Double>.Demo, Vector128s<Double>.V2));
            WriteLine(writer, indent, "PseudoMax(Vector128s<Single>.Demo, Vector128s<Single>.V2):\t{0}", PackedSimd.PseudoMax(Vector128s<Single>.Demo, Vector128s<Single>.V2));

            //PseudoMin(Vector128<Double>, Vector128<Double>)
            //PseudoMin(Vector128<Single>, Vector128<Single>)
            WriteLine(writer, indent, "PseudoMin(Vector128s<Double>.Demo, Vector128s<Double>.V2):\t{0}", PackedSimd.PseudoMin(Vector128s<Double>.Demo, Vector128s<Double>.V2));
            WriteLine(writer, indent, "PseudoMin(Vector128s<Single>.Demo, Vector128s<Single>.V2):\t{0}", PackedSimd.PseudoMin(Vector128s<Single>.Demo, Vector128s<Single>.V2));

            //ReplaceScalar(Vector128<Byte>, Byte, UInt32)
            //ReplaceScalar(Vector128<Double>, Byte, Double)
            //ReplaceScalar(Vector128<Int16>, Byte, Int32)
            //ReplaceScalar(Vector128<Int32>, Byte, Int32)
            //ReplaceScalar(Vector128<Int64>, Byte, Int64)
            //ReplaceScalar(Vector128<IntPtr>, Byte, IntPtr)
            //ReplaceScalar(Vector128<SByte>, Byte, Int32)
            //ReplaceScalar(Vector128<Single>, Byte, Single)
            //ReplaceScalar(Vector128<UInt16>, Byte, UInt32)
            //ReplaceScalar(Vector128<UInt32>, Byte, UInt32)
            //ReplaceScalar(Vector128<UInt64>, Byte, UInt64)
            //ReplaceScalar(Vector128<UIntPtr>, Byte, UIntPtr)
            //RoundToNearest(Vector128<Double>)
            //RoundToNearest(Vector128<Single>)
            //ShiftLeft(Vector128<Byte>, Int32)
            //ShiftLeft(Vector128<Int16>, Int32)
            //ShiftLeft(Vector128<Int32>, Int32)
            //ShiftLeft(Vector128<Int64>, Int32)
            //ShiftLeft(Vector128<IntPtr>, Int32)
            //ShiftLeft(Vector128<SByte>, Int32)
            //ShiftLeft(Vector128<UInt16>, Int32)
            //ShiftLeft(Vector128<UInt32>, Int32)
            //ShiftLeft(Vector128<UInt64>, Int32)
            //ShiftLeft(Vector128<UIntPtr>, Int32)
            //ShiftRightArithmetic(Vector128<Byte>, Int32)
            //ShiftRightArithmetic(Vector128<Int16>, Int32)
            //ShiftRightArithmetic(Vector128<Int32>, Int32)
            //ShiftRightArithmetic(Vector128<Int64>, Int32)
            //ShiftRightArithmetic(Vector128<IntPtr>, Int32)
            //ShiftRightArithmetic(Vector128<SByte>, Int32)
            //ShiftRightArithmetic(Vector128<UInt16>, Int32)
            //ShiftRightArithmetic(Vector128<UInt32>, Int32)
            //ShiftRightArithmetic(Vector128<UInt64>, Int32)
            //ShiftRightArithmetic(Vector128<UIntPtr>, Int32)
            //ShiftRightLogical(Vector128<Byte>, Int32)
            //ShiftRightLogical(Vector128<Int16>, Int32)
            //ShiftRightLogical(Vector128<Int32>, Int32)
            //ShiftRightLogical(Vector128<Int64>, Int32)
            //ShiftRightLogical(Vector128<IntPtr>, Int32)
            //ShiftRightLogical(Vector128<SByte>, Int32)
            //ShiftRightLogical(Vector128<UInt16>, Int32)
            //ShiftRightLogical(Vector128<UInt32>, Int32)
            //ShiftRightLogical(Vector128<UInt64>, Int32)
            //ShiftRightLogical(Vector128<UIntPtr>, Int32)
            //SignExtendWideningLower(Vector128<Byte>)
            //SignExtendWideningLower(Vector128<Int16>)
            //SignExtendWideningLower(Vector128<Int32>)
            //SignExtendWideningLower(Vector128<SByte>)
            //SignExtendWideningLower(Vector128<UInt16>)
            //SignExtendWideningLower(Vector128<UInt32>)
            //SignExtendWideningUpper(Vector128<Byte>)
            //SignExtendWideningUpper(Vector128<Int16>)
            //SignExtendWideningUpper(Vector128<Int32>)
            //SignExtendWideningUpper(Vector128<SByte>)
            //SignExtendWideningUpper(Vector128<UInt16>)
            //SignExtendWideningUpper(Vector128<UInt32>)
            //Splat(Byte)
            //Splat(Double)
            //Splat(Int16)
            //Splat(Int32)
            //Splat(Int64)
            //Splat(IntPtr)
            //Splat(SByte)
            //Splat(Single)
            //Splat(UInt16)
            //Splat(UInt32)
            //Splat(UInt64)
            //Splat(UIntPtr)
            //Sqrt(Vector128<Double>)
            //Sqrt(Vector128<Single>)
            //Store(Byte*, Vector128<Byte>)
            //Store(Double*, Vector128<Double>)
            //Store(Int16*, Vector128<Int16>)
            //Store(Int32*, Vector128<Int32>)
            //Store(Int64*, Vector128<Int64>)
            //Store(IntPtr*, Vector128<IntPtr>)
            //Store(SByte*, Vector128<SByte>)
            //Store(Single*, Vector128<Single>)
            //Store(UInt16*, Vector128<UInt16>)
            //Store(UInt32*, Vector128<UInt32>)
            //Store(UInt64*, Vector128<UInt64>)
            //Store(UIntPtr*, Vector128<UIntPtr>)
            //StoreSelectedScalar(Byte*, Vector128<Byte>, Byte)
            //StoreSelectedScalar(Double*, Vector128<Double>, Byte)
            //StoreSelectedScalar(Int16*, Vector128<Int16>, Byte)
            //StoreSelectedScalar(Int32*, Vector128<Int32>, Byte)
            //StoreSelectedScalar(Int64*, Vector128<Int64>, Byte)
            //StoreSelectedScalar(IntPtr*, Vector128<IntPtr>, Byte)
            //StoreSelectedScalar(SByte*, Vector128<SByte>, Byte)
            //StoreSelectedScalar(Single*, Vector128<Single>, Byte)
            //StoreSelectedScalar(UInt16*, Vector128<UInt16>, Byte)
            //StoreSelectedScalar(UInt32*, Vector128<UInt32>, Byte)
            //StoreSelectedScalar(UInt64*, Vector128<UInt64>, Byte)
            //StoreSelectedScalar(UIntPtr*, Vector128<UIntPtr>, Byte)
            //Subtract(Vector128<Byte>, Vector128<Byte>)
            //Subtract(Vector128<Double>, Vector128<Double>)
            //Subtract(Vector128<Int16>, Vector128<Int16>)
            //Subtract(Vector128<Int32>, Vector128<Int32>)
            //Subtract(Vector128<Int64>, Vector128<Int64>)
            //Subtract(Vector128<IntPtr>, Vector128<IntPtr>)
            //Subtract(Vector128<SByte>, Vector128<SByte>)
            //Subtract(Vector128<Single>, Vector128<Single>)
            //Subtract(Vector128<UInt16>, Vector128<UInt16>)
            //Subtract(Vector128<UInt32>, Vector128<UInt32>)
            //Subtract(Vector128<UInt64>, Vector128<UInt64>)
            //Subtract(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //SubtractSaturate(Vector128<Byte>, Vector128<Byte>)
            //SubtractSaturate(Vector128<Int16>, Vector128<Int16>)
            //SubtractSaturate(Vector128<SByte>, Vector128<SByte>)
            //SubtractSaturate(Vector128<UInt16>, Vector128<UInt16>)

            //Swizzle(Vector128<Byte>, Vector128<Byte>) // i8x16.swizzle
            //Swizzle(Vector128<SByte>, Vector128<SByte>)
            // 根据第二个向量的 8 位通道指定的索引 [0-15] 从第一个向量中选择 8 位通道。
            WriteLine(writer, indent, "Swizzle(Vector128s<Byte>.Demo, Vector128s<Byte>.V2):\t{0}", PackedSimd.Swizzle(Vector128s<Byte>.Demo, Vector128s<Byte>.V2));
            WriteLine(writer, indent, "Swizzle(Vector128s<Byte>.Demo, Vector128s<Byte>.SerialDesc):\t{0}", PackedSimd.Swizzle(Vector128s<Byte>.Demo, Vector128s<Byte>.SerialDesc));
            WriteLine(writer, indent, "Swizzle(Vector128s<SByte>.Demo, Vector128s<SByte>.V2):\t{0}", PackedSimd.Swizzle(Vector128s<SByte>.Demo, Vector128s<SByte>.V2));
            WriteLine(writer, indent, "Swizzle(Vector128s<SByte>.Demo, Vector128s<SByte>.SerialNegative):\t{0}", PackedSimd.Swizzle(Vector128s<SByte>.Demo, Vector128s<SByte>.SerialNegative));

            //Truncate(Vector128<Double>)
            //Truncate(Vector128<Single>)
            //Xor(Vector128<Byte>, Vector128<Byte>)
            //Xor(Vector128<Double>, Vector128<Double>)
            //Xor(Vector128<Int16>, Vector128<Int16>)
            //Xor(Vector128<Int32>, Vector128<Int32>)
            //Xor(Vector128<Int64>, Vector128<Int64>)
            //Xor(Vector128<IntPtr>, Vector128<IntPtr>)
            //Xor(Vector128<SByte>, Vector128<SByte>)
            //Xor(Vector128<Single>, Vector128<Single>)
            //Xor(Vector128<UInt16>, Vector128<UInt16>)
            //Xor(Vector128<UInt32>, Vector128<UInt32>)
            //Xor(Vector128<UInt64>, Vector128<UInt64>)
            //Xor(Vector128<UIntPtr>, Vector128<UIntPtr>)
            //ZeroExtendWideningLower(Vector128<Byte>)
            //ZeroExtendWideningLower(Vector128<Int16>)
            //ZeroExtendWideningLower(Vector128<Int32>)
            //ZeroExtendWideningLower(Vector128<SByte>)
            //ZeroExtendWideningLower(Vector128<UInt16>)
            //ZeroExtendWideningLower(Vector128<UInt32>)
            //ZeroExtendWideningUpper(Vector128<Byte>)
            //ZeroExtendWideningUpper(Vector128<Int16>)
            //ZeroExtendWideningUpper(Vector128<Int32>)
            //ZeroExtendWideningUpper(Vector128<SByte>)
            //ZeroExtendWideningUpper(Vector128<UInt16>)
            //ZeroExtendWideningUpper(Vector128<UInt32>)
        }

#endif // NET8_0_OR_GREATER
    }
}

