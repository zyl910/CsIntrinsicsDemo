using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics;
#if NET5_0_OR_GREATER
using System.Runtime.Intrinsics.Arm;
#endif // #if NET5_0_OR_GREATER
using System.Text;
using Zyl.VectorTraits;

namespace IntrinsicsLib {
    partial class IntrinsicsDemo {

        /// <summary>
        /// Run Arm AdvSimd.Arm64.
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunArm_AdvSimd_64(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = AdvSimd.Arm64.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- AdvSimd.Arm64.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

            //RunArm_AdvSimd_64_A(writer, indent);
            //RunArm_AdvSimd_64_C(writer, indent);
            //RunArm_AdvSimd_64_D(writer, indent);
            //RunArm_AdvSimd_64_F(writer, indent);
            //RunArm_AdvSimd_64_I(writer, indent);
            //RunArm_AdvSimd_64_L(writer, indent);
            //RunArm_AdvSimd_64_M(writer, indent);
            //RunArm_AdvSimd_64_N(writer, indent);
            //RunArm_AdvSimd_64_R(writer, indent);
            //RunArm_AdvSimd_64_S(writer, indent);
            //RunArm_AdvSimd_64_T(writer, indent);
            //RunArm_AdvSimd_64_U(writer, indent);
            //RunArm_AdvSimd_64_V(writer, indent);
            //RunArm_AdvSimd_64_Z(writer, indent);
            Action<TextWriter, string>[] list = {
                RunArm_AdvSimd_64_A,
                RunArm_AdvSimd_64_C,
                RunArm_AdvSimd_64_D,
                RunArm_AdvSimd_64_E,
                RunArm_AdvSimd_64_F,
                RunArm_AdvSimd_64_I,
                RunArm_AdvSimd_64_L,
                RunArm_AdvSimd_64_M,
                RunArm_AdvSimd_64_N,
                RunArm_AdvSimd_64_R,
                RunArm_AdvSimd_64_S,
                RunArm_AdvSimd_64_T,
                RunArm_AdvSimd_64_U,
                RunArm_AdvSimd_64_V,
                RunArm_AdvSimd_64_Z,
            };
            TraitsUtil.InvokeArray(writer, indent, list);

        }
        public unsafe static void RunArm_AdvSimd_64_A(TextWriter writer, string indent) {
            // 1、Absolute(正常指令): vabs -> ri = |ai|; 
            // returns the absolute value of each element in a vector.
            // Abs(Vector128<Double>)	float64x2_t vabsq_f64 (float64x2_t a); A64: FABS Vd.2D, Vn.2D
            // Abs(Vector128<Int64>)	int64x2_t vabsq_s64 (int64x2_t a); A64: ABS Vd.2D, Vn.2D
            // AbsScalar(Vector64<Int64>)	int64x1_t vabs_s64 (int64x1_t a); A64: ABS Dd, Dn
            WriteLine(writer, indent, "Abs(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.Abs(Vector128s<double>.Demo));
            WriteLine(writer, indent, "Abs(Vector128s<long>.Demo):\t{0}", AdvSimd.Arm64.Abs(Vector128s<long>.Demo));

            // 8、Vector compare absolute greater-than(正常指令): 
            // vcage -> ri = |ai| > |bi| ? 1...1:0...0; 
            // compares the absolute value of each element in a vector with the absolute value of the corresponding element of a second vector. If it is greater than it,  
            // the corresponding element in the destination vector is set to all ones.  
            // Otherwise, it is set to all zeros.
            // 将一个向量中每个元素的绝对值与第二个向量中相应元素的绝对值进行比较。如果它大于它，
            // 目标向量中的相应元素被设置为全部为1。
            // 否则，它被设置为全零。
            // AbsoluteCompareGreaterThan(Vector128<Double>, Vector128<Double>)	uint64x2_t vcagtq_f64 (float64x2_t a, float64x2_t b); A64: FACGT Vd.2D, Vn.2D, Vm.2D
            // AbsoluteCompareGreaterThanOrEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vcageq_f64 (float64x2_t a, float64x2_t b); A64: FACGE Vd.2D, Vn.2D, Vm.2D
            // AbsoluteCompareGreaterThanOrEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcage_f64 (float64x1_t a, float64x1_t b); A64: FACGE Dd, Dn, Dm
            // AbsoluteCompareGreaterThanOrEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcages_f32 (float32_t a, float32_t b); A64: FACGE Sd, Sn, Sm
            // AbsoluteCompareGreaterThanScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcagt_f64 (float64x1_t a, float64x1_t b); A64: FACGT Dd, Dn, Dm
            // AbsoluteCompareGreaterThanScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcagts_f32 (float32_t a, float32_t b); A64: FACGT Sd, Sn, Sm
            WriteLine(writer, indent, "AbsoluteCompareGreaterThan(Vector128s<double>.Demo, Vector128s<double>.V6):\t{0}", AdvSimd.Arm64.AbsoluteCompareGreaterThan(Vector128s<double>.Demo, Vector128s<double>.V6));
            WriteLine(writer, indent, "AbsoluteCompareGreaterThanOrEqual(Vector128s<double>.Demo, Vector128s<double>.V6):\t{0}", AdvSimd.Arm64.AbsoluteCompareGreaterThanOrEqual(Vector128s<double>.Demo, Vector128s<double>.V6));

            // 9、Vector compare absolute less-than(正常指令): 
            // vcalt -> ri = |ai| < |bi| ? 1...1:0...0; 
            // compares the absolute value of each element in a vector with the absolute value of the corresponding element of a second vector.
            // If it is less than it, the corresponding element in the destination vector is set to all ones. Otherwise,it is set to all zeros
            // 将一个向量中每个元素的绝对值与第二个向量中相应元素的绝对值进行比较。
            // 如果它小于它，则目标向量中的相应元素被设置为全部为1。否则，它被设置为全零
            // AbsoluteCompareLessThan(Vector128<Double>, Vector128<Double>)	uint64x2_t vcaltq_f64 (float64x2_t a, float64x2_t b); A64: FACGT Vd.2D, Vn.2D, Vm.2D
            // AbsoluteCompareLessThanScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcalt_f64 (float64x1_t a, float64x1_t b); A64: FACGT Dd, Dn, Dm
            // AbsoluteCompareLessThanScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcalts_f32 (float32_t a, float32_t b); A64: FACGT Sd, Sn, Sm
            // AbsoluteCompareLessThanOrEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vcaleq_f64 (float64x2_t a, float64x2_t b); A64: FACGE Vd.2D, Vn.2D, Vm.2D
            // AbsoluteCompareLessThanOrEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcale_f64 (float64x1_t a, float64x1_t b); A64: FACGE Dd, Dn, Dm
            // AbsoluteCompareLessThanOrEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcales_f32 (float32_t a, float32_t b); A64: FACGE Sd, Sn, Sm
            WriteLine(writer, indent, "AbsoluteCompareLessThan(Vector128s<double>.Demo, Vector128s<double>.V6):\t{0}", AdvSimd.Arm64.AbsoluteCompareLessThan(Vector128s<double>.Demo, Vector128s<double>.V6));
            WriteLine(writer, indent, "AbsoluteCompareLessThanOrEqual(Vector128s<double>.Demo, Vector128s<double>.V6):\t{0}", AdvSimd.Arm64.AbsoluteCompareLessThanOrEqual(Vector128s<double>.Demo, Vector128s<double>.V6));

            // 1、Absolute difference between the arguments(正常指令): vabd -> ri = |ai - bi|; 
            // returns the absolute values of the results
            // 返回结果的绝对值
            // AbsoluteDifference(Vector128<Double>, Vector128<Double>)	float64x2_t vabdq_f64 (float64x2_t a, float64x2_t b); A64: FABD Vd.2D, Vn.2D, Vm.2D
            // AbsoluteDifferenceScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vabd_f64 (float64x1_t a, float64x1_t b); A64: FABD Dd, Dn, Dm
            // AbsoluteDifferenceScalar(Vector64<Single>, Vector64<Single>)	float32_t vabds_f32 (float32_t a, float32_t b); A64: FABD Sd, Sn, Sm
            WriteLine(writer, indent, "AbsoluteDifference(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.AbsoluteDifference(Vector128s<double>.Demo, Vector128s<double>.V2));

            // 2、Saturating absolute(饱和指令): vqabs -> ri = sat(|ai|); 
            // returns the absolute value of each element in a vector. If any of the results overflow, they are saturated and the sticky QC flag is set.
            // 返回向量中每个元素的绝对值。如果任何结果溢出，它们将被饱和，并设置粘性QC标志。
            // AbsSaturate(Vector128<Int64>)	int64x2_t vqabsq_s64 (int64x2_t a); A64: SQABS Vd.2D, Vn.2D
            // AbsSaturateScalar(Vector64<Int16>)	int16_t vqabsh_s16 (int16_t a); A64: SQABS Hd, Hn
            // AbsSaturateScalar(Vector64<Int32>)	int32_t vqabss_s32 (int32_t a); A64: SQABS Sd, Sn
            // AbsSaturateScalar(Vector64<Int64>)	int64_t vqabsd_s64 (int64_t a); A64: SQABS Dd, Dn
            // AbsSaturateScalar(Vector64<SByte>)	int8_t vqabsb_s8 (int8_t a); A64: SQABS Bd, Bn
            WriteLine(writer, indent, "AbsSaturate(Vector128s<long>.Demo):\t{0}", AdvSimd.Arm64.AbsSaturate(Vector128s<long>.Demo));

            // Add(Vector128<Double>, Vector128<Double>)	float64x2_t vaddq_f64 (float64x2_t a, float64x2_t b); A64: FADD Vd.2D, Vn.2D, Vm.2D
            WriteLine(writer, indent, "Add(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Add(Vector128s<double>.Demo, Vector128s<double>.V2));

            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vaddvq_u8
            // Add across Vector. This instruction adds every vector element in the source SIMD&FP register together, and writes the scalar result to the destination SIMD&FP register.
            // 在向量上相加。这条指令将源SIMD&FP寄存器中的每个向量元素加在一起，并将标量结果写入目标SIMD&FP寄存器。
            // bits(datasize) operand = V[n];
            // V[d] = Reduce(op, operand, esize);
            // AddAcross(Vector128<Byte>)	uint8_t vaddvq_u8 (uint8x16_t a); A64: ADDV Bd, Vn.16B
            // AddAcross(Vector128<Int16>)	int16_t vaddvq_s16 (int16x8_t a); A64: ADDV Hd, Vn.8H
            // AddAcross(Vector128<Int32>)	int32_t vaddvq_s32 (int32x4_t a); A64: ADDV Sd, Vn.4S
            // AddAcross(Vector128<SByte>)	int8_t vaddvq_s8 (int8x16_t a); A64: ADDV Bd, Vn.16B
            // AddAcross(Vector128<UInt16>)	uint16_t vaddvq_u16 (uint16x8_t a); A64: ADDV Hd, Vn.8H
            // AddAcross(Vector128<UInt32>)	uint32_t vaddvq_u32 (uint32x4_t a); A64: ADDV Sd, Vn.4S
            // AddAcross(Vector64<Byte>)	uint8_t vaddv_u8 (uint8x8_t a); A64: ADDV Bd, Vn.8B
            // AddAcross(Vector64<Int16>)	int16_t vaddv_s16 (int16x4_t a); A64: ADDV Hd, Vn.4H
            // AddAcross(Vector64<SByte>)	int8_t vaddv_s8 (int8x8_t a); A64: ADDV Bd, Vn.8B
            // AddAcross(Vector64<UInt16>)	uint16_t vaddv_u16 (uint16x4_t a); A64: ADDV Hd, Vn.4H
            WriteLine(writer, indent, "AddAcross(Vector128s<byte>.Demo):\t{0}", AdvSimd.Arm64.AddAcross(Vector128s<byte>.Demo));
            WriteLine(writer, indent, "AddAcross(Vector128s<sbyte>.Demo):\t{0}", AdvSimd.Arm64.AddAcross(Vector128s<sbyte>.Demo));
            WriteLine(writer, indent, "AddAcross(Vector128s<short>.Demo):\t{0}", AdvSimd.Arm64.AddAcross(Vector128s<short>.Demo));
            WriteLine(writer, indent, "AddAcross(Vector128s<ushort>.Demo):\t{0}", AdvSimd.Arm64.AddAcross(Vector128s<ushort>.Demo));
            WriteLine(writer, indent, "AddAcross(Vector128s<int>.Demo):\t{0}", AdvSimd.Arm64.AddAcross(Vector128s<int>.Demo));
            WriteLine(writer, indent, "AddAcross(Vector128s<uint>.Demo):\t{0}", AdvSimd.Arm64.AddAcross(Vector128s<uint>.Demo));

            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vaddlvq_u8
            // Unsigned sum Long across Vector. This instruction adds every vector element in the source SIMD&FP register together, and writes the scalar result to the destination SIMD&FP register. The destination scalar is twice as long as the source vector elements. All the values in this instruction are unsigned integer values.
            // 向量上的无符号和。这条指令将源SIMD&FP寄存器中的每个向量元素加在一起，并将标量结果写入目标SIMD&FP寄存器。目标标量的长度是源向量元素的两倍。此指令中的所有值都是无符号整数值。
            // sum = Int(Elem[operand, 0, esize], unsigned);
            // for e = 1 to elements-1
            //     sum = sum + Int(Elem[operand, e, esize], unsigned);
            // AddAcrossWidening(Vector128<Byte>)	uint16_t vaddlvq_u8 (uint8x16_t a); A64: UADDLV Hd, Vn.16B
            // AddAcrossWidening(Vector128<Int16>)	int32_t vaddlvq_s16 (int16x8_t a); A64: SADDLV Sd, Vn.8H
            // AddAcrossWidening(Vector128<Int32>)	int64_t vaddlvq_s32 (int32x4_t a); A64: SADDLV Dd, Vn.4S
            // AddAcrossWidening(Vector128<SByte>)	int16_t vaddlvq_s8 (int8x16_t a); A64: SADDLV Hd, Vn.16B
            // AddAcrossWidening(Vector128<UInt16>)	uint32_t vaddlvq_u16 (uint16x8_t a); A64: UADDLV Sd, Vn.8H
            // AddAcrossWidening(Vector128<UInt32>)	uint64_t vaddlvq_u32 (uint32x4_t a); A64: UADDLV Dd, Vn.4S
            // AddAcrossWidening(Vector64<Byte>)	uint16_t vaddlv_u8 (uint8x8_t a); A64: UADDLV Hd, Vn.8B
            // AddAcrossWidening(Vector64<Int16>)	int32_t vaddlv_s16 (int16x4_t a); A64: SADDLV Sd, Vn.4H
            // AddAcrossWidening(Vector64<SByte>)	int16_t vaddlv_s8 (int8x8_t a); A64: SADDLV Hd, Vn.8B
            // AddAcrossWidening(Vector64<UInt16>)	uint32_t vaddlv_u16 (uint16x4_t a); A64: UADDLV Sd, Vn.4H
            WriteLine(writer, indent, "AddAcrossWidening(Vector128s<byte>.Demo):\t{0}", AdvSimd.Arm64.AddAcrossWidening(Vector128s<byte>.Demo));
            WriteLine(writer, indent, "AddAcrossWidening(Vector128s<sbyte>.Demo):\t{0}", AdvSimd.Arm64.AddAcrossWidening(Vector128s<sbyte>.Demo));
            WriteLine(writer, indent, "AddAcrossWidening(Vector128s<short>.Demo):\t{0}", AdvSimd.Arm64.AddAcrossWidening(Vector128s<short>.Demo));
            WriteLine(writer, indent, "AddAcrossWidening(Vector128s<ushort>.Demo):\t{0}", AdvSimd.Arm64.AddAcrossWidening(Vector128s<ushort>.Demo));
            WriteLine(writer, indent, "AddAcrossWidening(Vector128s<int>.Demo):\t{0}", AdvSimd.Arm64.AddAcrossWidening(Vector128s<int>.Demo));
            WriteLine(writer, indent, "AddAcrossWidening(Vector128s<uint>.Demo):\t{0}", AdvSimd.Arm64.AddAcrossWidening(Vector128s<uint>.Demo));

            // Mnemonic: `rt[i] := (i<center)?( a[i2]+a[i2+1] ):( b[i2]+b[i2+1] )`, `i2 := (i*2)%T.Count`, `center := T.Count/2`.
            // Example of element-2: `f({a[0], a[1]}, {b[0], b[1]}) = {a[0]+a[1], b[0]+b[1]}` .
            // Example of element-4: `f({a[0], a[1], a[2], a[3]}, {b[0], b[1], b[2], b[3]}) = {a[0]+a[1], a[2]+a[3], b[0]+b[1], b[2]+b[3]}` .
            // 1、Pairwise add(正常指令):  
            // vpadd -> r0 = a0 + a1, ..., r3 = a6 + a7, r4 = b0 + b1, ..., r7 = b6 + b7 
            // adds adjacent pairs of elements of two vectors,  and places the results in the destination vector.
            // 将两个向量的相邻元素对相加，并将结果放在目标向量中。
            // AddPairwise(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vpaddq_u8 (uint8x16_t a, uint8x16_t b); A64: ADDP Vd.16B, Vn.16B, Vm.16B
            // AddPairwise(Vector128<Double>, Vector128<Double>)	float64x2_t vpaddq_f64 (float64x2_t a, float64x2_t b); A64: FADDP Vd.2D, Vn.2D, Vm.2D
            // AddPairwise(Vector128<Int16>, Vector128<Int16>)	int16x8_t vpaddq_s16 (int16x8_t a, int16x8_t b); A64: ADDP Vd.8H, Vn.8H, Vm.8H
            // AddPairwise(Vector128<Int32>, Vector128<Int32>)	int32x4_t vpaddq_s32 (int32x4_t a, int32x4_t b); A64: ADDP Vd.4S, Vn.4S, Vm.4S
            // AddPairwise(Vector128<Int64>, Vector128<Int64>)	int64x2_t vpaddq_s64 (int64x2_t a, int64x2_t b); A64: ADDP Vd.2D, Vn.2D, Vm.2D
            // AddPairwise(Vector128<SByte>, Vector128<SByte>)	int8x16_t vpaddq_s8 (int8x16_t a, int8x16_t b); A64: ADDP Vd.16B, Vn.16B, Vm.16B
            // AddPairwise(Vector128<Single>, Vector128<Single>)	float32x4_t vpaddq_f32 (float32x4_t a, float32x4_t b); A64: FADDP Vd.4S, Vn.4S, Vm.4S
            // AddPairwise(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vpaddq_u16 (uint16x8_t a, uint16x8_t b); A64: ADDP Vd.8H, Vn.8H, Vm.8H
            // AddPairwise(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vpaddq_u32 (uint32x4_t a, uint32x4_t b); A64: ADDP Vd.4S, Vn.4S, Vm.4S
            // AddPairwise(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vpaddq_u64 (uint64x2_t a, uint64x2_t b); A64: ADDP Vd.2D, Vn.2D, Vm.2D
            // AddPairwiseScalar(Vector128<Double>)	float64_t vpaddd_f64 (float64x2_t a); A64: FADDP Dd, Vn.2D
            // AddPairwiseScalar(Vector128<Int64>)	int64_t vpaddd_s64 (int64x2_t a); A64: ADDP Dd, Vn.2D
            // AddPairwiseScalar(Vector128<UInt64>)	uint64_t vpaddd_u64 (uint64x2_t a); A64: ADDP Dd, Vn.2D
            // AddPairwiseScalar(Vector64<Single>)	float32_t vpadds_f32 (float32x2_t a); A64: FADDP Sd, Vn.2S
            WriteLine(writer, indent, "AddPairwise(Vector128s<sbyte>.Demo, Vector128s<sbyte>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<sbyte>.Demo, Vector128s<sbyte>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<byte>.Demo, Vector128s<byte>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<byte>.Demo, Vector128s<byte>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<short>.Demo, Vector128s<short>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<short>.Demo, Vector128s<short>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<ushort>.Demo, Vector128s<ushort>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<ushort>.Demo, Vector128s<ushort>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<int>.Demo, Vector128s<int>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<int>.Demo, Vector128s<int>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<uint>.Demo, Vector128s<uint>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<uint>.Demo, Vector128s<uint>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<long>.Demo, Vector128s<long>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<long>.Demo, Vector128s<long>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<ulong>.Demo, Vector128s<ulong>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<ulong>.Demo, Vector128s<ulong>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<float>.Demo, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<float>.Demo, Vector128s<float>.V2));
            WriteLine(writer, indent, "AddPairwise(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.AddPairwise(Vector128s<double>.Demo, Vector128s<double>.V2));

            // Mnemonic: `rt[i] := saturate( a[i] + b[i] )`.
            // AddSaturate(Vector128<Byte>, Vector128<SByte>)	uint8x16_t vsqaddq_u8 (uint8x16_t a, int8x16_t b); A64: USQADD Vd.16B, Vn.16B
            // AddSaturate(Vector128<Int16>, Vector128<UInt16>)	int16x8_t vuqaddq_s16 (int16x8_t a, uint16x8_t b); A64: SUQADD Vd.8H, Vn.8H
            // AddSaturate(Vector128<Int32>, Vector128<UInt32>)	int32x4_t vuqaddq_s32 (int32x4_t a, uint32x4_t b); A64: SUQADD Vd.4S, Vn.4S
            // AddSaturate(Vector128<Int64>, Vector128<UInt64>)	int64x2_t vuqaddq_s64 (int64x2_t a, uint64x2_t b); A64: SUQADD Vd.2D, Vn.2D
            // AddSaturate(Vector128<SByte>, Vector128<Byte>)	int8x16_t vuqaddq_s8 (int8x16_t a, uint8x16_t b); A64: SUQADD Vd.16B, Vn.16B
            // AddSaturate(Vector128<UInt16>, Vector128<Int16>)	uint16x8_t vsqaddq_u16 (uint16x8_t a, int16x8_t b); A64: USQADD Vd.8H, Vn.8H
            // AddSaturate(Vector128<UInt32>, Vector128<Int32>)	uint32x4_t vsqaddq_u32 (uint32x4_t a, int32x4_t b); A64: USQADD Vd.4S, Vn.4S
            // AddSaturate(Vector128<UInt64>, Vector128<Int64>)	uint64x2_t vsqaddq_u64 (uint64x2_t a, int64x2_t b); A64: USQADD Vd.2D, Vn.2D
            // AddSaturate(Vector64<Byte>, Vector64<SByte>)	uint8x8_t vsqadd_u8 (uint8x8_t a, int8x8_t b); A64: USQADD Vd.8B, Vn.8B
            // AddSaturate(Vector64<Int16>, Vector64<UInt16>)	int16x4_t vuqadd_s16 (int16x4_t a, uint16x4_t b); A64: SUQADD Vd.4H, Vn.4H
            // AddSaturate(Vector64<Int32>, Vector64<UInt32>)	int32x2_t vuqadd_s32 (int32x2_t a, uint32x2_t b); A64: SUQADD Vd.2S, Vn.2S
            // AddSaturate(Vector64<SByte>, Vector64<Byte>)	int8x8_t vuqadd_s8 (int8x8_t a, uint8x8_t b); A64: SUQADD Vd.8B, Vn.8B
            // AddSaturate(Vector64<UInt16>, Vector64<Int16>)	uint16x4_t vsqadd_u16 (uint16x4_t a, int16x4_t b); A64: USQADD Vd.4H, Vn.4H
            // AddSaturate(Vector64<UInt32>, Vector64<Int32>)	uint32x2_t vsqadd_u32 (uint32x2_t a, int32x2_t b); A64: USQADD Vd.2S, Vn.2S
            WriteLine(writer, indent, "AddSaturate(Vector128s<byte>.Demo, Vector128s<sbyte>.V2):\t{0}", AdvSimd.Arm64.AddSaturate(Vector128s<byte>.Demo, Vector128s<sbyte>.V2));
            WriteLine(writer, indent, "AddSaturate(Vector128s<sbyte>.Demo, Vector128s<byte>.V2):\t{0}", AdvSimd.Arm64.AddSaturate(Vector128s<sbyte>.Demo, Vector128s<byte>.V2));
            WriteLine(writer, indent, "AddSaturate(Vector128s<ushort>.Demo, Vector128s<short>.V2):\t{0}", AdvSimd.Arm64.AddSaturate(Vector128s<ushort>.Demo, Vector128s<short>.V2));
            WriteLine(writer, indent, "AddSaturate(Vector128s<short>.Demo, Vector128s<ushort>.V2):\t{0}", AdvSimd.Arm64.AddSaturate(Vector128s<short>.Demo, Vector128s<ushort>.V2));
            WriteLine(writer, indent, "AddSaturate(Vector128s<uint>.Demo, Vector128s<int>.V2):\t{0}", AdvSimd.Arm64.AddSaturate(Vector128s<uint>.Demo, Vector128s<int>.V2));
            WriteLine(writer, indent, "AddSaturate(Vector128s<int>.Demo, Vector128s<uint>.V2):\t{0}", AdvSimd.Arm64.AddSaturate(Vector128s<int>.Demo, Vector128s<uint>.V2));
            WriteLine(writer, indent, "AddSaturate(Vector128s<ulong>.Demo, Vector128s<long>.V2):\t{0}", AdvSimd.Arm64.AddSaturate(Vector128s<ulong>.Demo, Vector128s<long>.V2));
            WriteLine(writer, indent, "AddSaturate(Vector128s<long>.Demo, Vector128s<ulong>.V2):\t{0}", AdvSimd.Arm64.AddSaturate(Vector128s<long>.Demo, Vector128s<ulong>.V2));

            // AddSaturateScalar(Vector64<Byte>, Vector64<Byte>)	uint8_t vqaddb_u8 (uint8_t a, uint8_t b); A64: UQADD Bd, Bn, Bm
            // AddSaturateScalar(Vector64<Byte>, Vector64<SByte>)	uint8_t vsqaddb_u8 (uint8_t a, int8_t b); A64: USQADD Bd, Bn
            // AddSaturateScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqaddh_s16 (int16_t a, int16_t b); A64: SQADD Hd, Hn, Hm
            // AddSaturateScalar(Vector64<Int16>, Vector64<UInt16>)	int16_t vuqaddh_s16 (int16_t a, uint16_t b); A64: SUQADD Hd, Hn
            // AddSaturateScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqadds_s32 (int32_t a, int32_t b); A64: SQADD Sd, Sn, Sm
            // AddSaturateScalar(Vector64<Int32>, Vector64<UInt32>)	int32_t vuqadds_s32 (int32_t a, uint32_t b); A64: SUQADD Sd, Sn
            // AddSaturateScalar(Vector64<Int64>, Vector64<UInt64>)	int64x1_t vuqadd_s64 (int64x1_t a, uint64x1_t b); A64: SUQADD Dd, Dn
            // AddSaturateScalar(Vector64<SByte>, Vector64<Byte>)	int8_t vuqaddb_s8 (int8_t a, uint8_t b); A64: SUQADD Bd, Bn
            // AddSaturateScalar(Vector64<SByte>, Vector64<SByte>)	int8_t vqaddb_s8 (int8_t a, int8_t b); A64: SQADD Bd, Bn, Bm
            // AddSaturateScalar(Vector64<UInt16>, Vector64<Int16>)	uint16_t vsqaddh_u16 (uint16_t a, int16_t b); A64: USQADD Hd, Hn
            // AddSaturateScalar(Vector64<UInt16>, Vector64<UInt16>)	uint16_t vqaddh_u16 (uint16_t a, uint16_t b); A64: UQADD Hd, Hn, Hm
            // AddSaturateScalar(Vector64<UInt32>, Vector64<Int32>)	uint32_t vsqadds_u32 (uint32_t a, int32_t b); A64: USQADD Sd, Sn
            // AddSaturateScalar(Vector64<UInt32>, Vector64<UInt32>)	uint32_t vqadds_u32 (uint32_t a, uint32_t b); A64: UQADD Sd, Sn, Sm
            // AddSaturateScalar(Vector64<UInt64>, Vector64<Int64>)	uint64x1_t vsqadd_u64 (uint64x1_t a, int64x1_t b); A64: USQADD Dd, Dn
            WriteLine(writer, indent, "AddSaturateScalar(Vector64s<sbyte>.Demo, Vector64s<sbyte>.V2):\t{0}", AdvSimd.Arm64.AddSaturateScalar(Vector64s<sbyte>.Demo, Vector64s<sbyte>.V2));
            WriteLine(writer, indent, "AddSaturateScalar(Vector64s<byte>.Demo, Vector64s<byte>.V2):\t{0}", AdvSimd.Arm64.AddSaturateScalar(Vector64s<byte>.Demo, Vector64s<byte>.V2));
            WriteLine(writer, indent, "AddSaturateScalar(Vector64s<short>.Demo, Vector64s<short>.V2):\t{0}", AdvSimd.Arm64.AddSaturateScalar(Vector64s<short>.Demo, Vector64s<short>.V2));
            WriteLine(writer, indent, "AddSaturateScalar(Vector64s<ushort>.Demo, Vector64s<ushort>.V2):\t{0}", AdvSimd.Arm64.AddSaturateScalar(Vector64s<ushort>.Demo, Vector64s<ushort>.V2));
            WriteLine(writer, indent, "AddSaturateScalar(Vector64s<int>.Demo, Vector64s<int>.V2):\t{0}", AdvSimd.Arm64.AddSaturateScalar(Vector64s<int>.Demo, Vector64s<int>.V2));
            WriteLine(writer, indent, "AddSaturateScalar(Vector64s<uint>.Demo, Vector64s<uint>.V2):\t{0}", AdvSimd.Arm64.AddSaturateScalar(Vector64s<uint>.Demo, Vector64s<uint>.V2));
            WriteLine(writer, indent, "AddSaturateScalar(Vector64s<long>.Demo, Vector64s<ulong>.V2):\t{0}", AdvSimd.Arm64.AddSaturateScalar(Vector64s<long>.Demo, Vector64s<ulong>.V2));
            WriteLine(writer, indent, "AddSaturateScalar(Vector64s<ulong>.Demo, Vector64s<long>.V2):\t{0}", AdvSimd.Arm64.AddSaturateScalar(Vector64s<ulong>.Demo, Vector64s<long>.V2));
        }
        public unsafe static void RunArm_AdvSimd_64_C(TextWriter writer, string indent) {
            // 3、towards +Inf
            // Ceiling(Vector128<Double>)	float64x2_t vrndpq_f64 (float64x2_t a); A64: FRINTP Vd.2D, Vn.2D
            WriteLine(writer, indent, "Ceiling(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.Ceiling(Vector128s<double>.Demo));

            // 1、Vector compare equal(正常指令): vceq -> ri = ai == bi ? 1...1 : 0...0;  
            // If they are equal, the corresponding element in the destination vector is set to all ones. 
            // Otherwise, it is set to all zeros
            // CompareEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vceqq_f64 (float64x2_t a, float64x2_t b); A64: FCMEQ Vd.2D, Vn.2D, Vm.2D
            // CompareEqual(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vceqq_s64 (int64x2_t a, int64x2_t b); A64: CMEQ Vd.2D, Vn.2D, Vm.2D
            // CompareEqual(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vceqq_u64 (uint64x2_t a, uint64x2_t b); A64: CMEQ Vd.2D, Vn.2D, Vm.2D
            // CompareEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vceq_f64 (float64x1_t a, float64x1_t b); A64: FCMEQ Dd, Dn, Dm
            // CompareEqualScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vceq_s64 (int64x1_t a, int64x1_t b); A64: CMEQ Dd, Dn, Dm
            // CompareEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vceqs_f32 (float32_t a, float32_t b); A64: FCMEQ Sd, Sn, Sm
            // CompareEqualScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vceq_u64 (uint64x1_t a, uint64x1_t b); A64: CMEQ Dd, Dn, Dm
            WriteLine(writer, indent, "CompareEqual(Vector128s<long>.Demo, Vector128s<long>.V0):\t{0}", AdvSimd.Arm64.CompareEqual(Vector128s<long>.Demo, Vector128s<long>.V0));
            WriteLine(writer, indent, "CompareEqual(Vector128s<ulong>.Demo, Vector128s<ulong>.V0):\t{0}", AdvSimd.Arm64.CompareEqual(Vector128s<ulong>.Demo, Vector128s<ulong>.V0));
            WriteLine(writer, indent, "CompareEqual(Vector128s<double>.Demo, Vector128s<double>.V0):\t{0}", AdvSimd.Arm64.CompareEqual(Vector128s<double>.Demo, Vector128s<double>.V0));

            // 4、Vector compare greater-than(正常指令): vcgt -> ri = ai > bi ? 1...1:0...0; 
            // If it is greater than it, the corresponding element in the destination vector is set to all ones. Otherwise, it is set to all zeros
            // CompareGreaterThan(Vector128<Double>, Vector128<Double>)	uint64x2_t vcgtq_f64 (float64x2_t a, float64x2_t b); A64: FCMGT Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThan(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vcgtq_s64 (int64x2_t a, int64x2_t b); A64: CMGT Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThan(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vcgtq_u64 (uint64x2_t a, uint64x2_t b); A64: CMHI Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThanScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcgt_f64 (float64x1_t a, float64x1_t b); A64: FCMGT Dd, Dn, Dm
            // CompareGreaterThanScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vcgt_s64 (int64x1_t a, int64x1_t b); A64: CMGT Dd, Dn, Dm
            // CompareGreaterThanScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcgts_f32 (float32_t a, float32_t b); A64: FCMGT Sd, Sn, Sm
            // CompareGreaterThanScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vcgt_u64 (uint64x1_t a, uint64x1_t b); A64: CMHI Dd, Dn, Dm
            WriteLine(writer, indent, "CompareGreaterThan(Vector128s<long>.Demo, Vector128s<long>.V0):\t{0}", AdvSimd.Arm64.CompareGreaterThan(Vector128s<long>.Demo, Vector128s<long>.V0));
            WriteLine(writer, indent, "CompareGreaterThan(Vector128s<ulong>.Demo, Vector128s<ulong>.V0):\t{0}", AdvSimd.Arm64.CompareGreaterThan(Vector128s<ulong>.Demo, Vector128s<ulong>.V0));
            WriteLine(writer, indent, "CompareGreaterThan(Vector128s<double>.Demo, Vector128s<double>.V0):\t{0}", AdvSimd.Arm64.CompareGreaterThan(Vector128s<double>.Demo, Vector128s<double>.V0));

            // 2、Vector compare greater-than or equal(正常指令): vcge-> ri = ai >= bi ? 1...1:0...0; 
            // If it is greater than or equal to it, the corresponding element in the destination vector is set to all ones. Otherwise, it is set to all zeros.
            // CompareGreaterThanOrEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vcgeq_f64 (float64x2_t a, float64x2_t b); A64: FCMGE Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThanOrEqual(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vcgeq_s64 (int64x2_t a, int64x2_t b); A64: CMGE Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThanOrEqual(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vcgeq_u64 (uint64x2_t a, uint64x2_t b); A64: CMHS Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThanOrEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcge_f64 (float64x1_t a, float64x1_t b); A64: FCMGE Dd, Dn, Dm
            // CompareGreaterThanOrEqualScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vcge_s64 (int64x1_t a, int64x1_t b); A64: CMGE Dd, Dn, Dm
            // CompareGreaterThanOrEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcges_f32 (float32_t a, float32_t b); A64: FCMGE Sd, Sn, Sm
            // CompareGreaterThanOrEqualScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vcge_u64 (uint64x1_t a, uint64x1_t b); A64: CMHS Dd, Dn, Dm
            WriteLine(writer, indent, "CompareGreaterThanOrEqual(Vector128s<long>.Demo, Vector128s<long>.V0):\t{0}", AdvSimd.Arm64.CompareGreaterThanOrEqual(Vector128s<long>.Demo, Vector128s<long>.V0));
            WriteLine(writer, indent, "CompareGreaterThanOrEqual(Vector128s<ulong>.Demo, Vector128s<ulong>.V0):\t{0}", AdvSimd.Arm64.CompareGreaterThanOrEqual(Vector128s<ulong>.Demo, Vector128s<ulong>.V0));
            WriteLine(writer, indent, "CompareGreaterThanOrEqual(Vector128s<double>.Demo, Vector128s<double>.V0):\t{0}", AdvSimd.Arm64.CompareGreaterThanOrEqual(Vector128s<double>.Demo, Vector128s<double>.V0));

            // 5、Vector compare less-than(正常指令): vclt -> ri = ai < bi ? 1...1:0...0; 
            // If it is less than it, the corresponding element in the destination vector is set to all ones.Otherwise, it is set to all zeros
            // CompareLessThan(Vector128<Double>, Vector128<Double>)	uint64x2_t vcltq_f64 (float64x2_t a, float64x2_t b); A64: FCMGT Vd.2D, Vn.2D, Vm.2D
            // CompareLessThan(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vcltq_s64 (int64x2_t a, int64x2_t b); A64: CMGT Vd.2D, Vn.2D, Vm.2D
            // CompareLessThan(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vcltq_u64 (uint64x2_t a, uint64x2_t b); A64: CMHI Vd.2D, Vn.2D, Vm.2D
            // CompareLessThanScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vclt_f64 (float64x1_t a, float64x1_t b); A64: FCMGT Dd, Dn, Dm
            // CompareLessThanScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vclt_s64 (int64x1_t a, int64x1_t b); A64: CMGT Dd, Dn, Dm
            // CompareLessThanScalar(Vector64<Single>, Vector64<Single>)	uint32_t vclts_f32 (float32_t a, float32_t b); A64: FCMGT Sd, Sn, Sm
            // CompareLessThanScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vclt_u64 (uint64x1_t a, uint64x1_t b); A64: CMHI Dd, Dn, Dm
            // 3、Vector compare less-than or equal(正常指令): vcle -> ri = ai <= bi ? 1...1:0...0; 
            // If it is less than or equal to it, the corresponding element in the destination vector is set to all ones. Otherwise, it is set to all zeros.
            // CompareLessThanOrEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vcleq_f64 (float64x2_t a, float64x2_t b); A64: FCMGE Vd.2D, Vn.2D, Vm.2D
            // CompareLessThanOrEqual(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vcleq_s64 (int64x2_t a, int64x2_t b); A64: CMGE Vd.2D, Vn.2D, Vm.2D
            // CompareLessThanOrEqual(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vcleq_u64 (uint64x2_t a, uint64x2_t b); A64: CMHS Vd.2D, Vn.2D, Vm.2D
            // CompareLessThanOrEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcle_f64 (float64x1_t a, float64x1_t b); A64: FCMGE Dd, Dn, Dm
            // CompareLessThanOrEqualScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vcle_s64 (int64x1_t a, int64x1_t b); A64: CMGE Dd, Dn, Dm
            // CompareLessThanOrEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcles_f32 (float32_t a, float32_t b); A64: FCMGE Sd, Sn, Sm
            // CompareLessThanOrEqualScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vcle_u64 (uint64x1_t a, uint64x1_t b); A64: CMHS Dd, Dn, Dm
            // CompareTest(Vector128<Double>, Vector128<Double>)	uint64x2_t vtstq_f64 (float64x2_t a, float64x2_t b); A64: CMTST Vd.2D, Vn.2D, Vm.2D The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // CompareTest(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vtstq_s64 (int64x2_t a, int64x2_t b); A64: CMTST Vd.2D, Vn.2D, Vm.2D
            // CompareTest(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vtstq_u64 (uint64x2_t a, uint64x2_t b); A64: CMTST Vd.2D, Vn.2D, Vm.2D
            // 10、正常指令，vtst -> ri = (ai & bi != 0) ? 1...1:0...0; 
            // bitwise logical ANDs each element in a vector with the corresponding element of a second vector.If the result is not zero, the corresponding element in the destination vector is set to all ones. Otherwise, it is set to all zeros
            // CompareTestScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vtst_f64 (float64x1_t a, float64x1_t b); A64: CMTST Dd, Dn, Dm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // CompareTestScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vtst_s64 (int64x1_t a, int64x1_t b); A64: CMTST Dd, Dn, Dm
            // CompareTestScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vtst_u64 (uint64x1_t a, uint64x1_t b); A64: CMTST Dd, Dn, Dm
            // Ignore

            // ConvertToDouble(Vector128<Int64>)	float64x2_t vcvtq_f64_s64 (int64x2_t a); A64: SCVTF Vd.2D, Vn.2D
            // ConvertToDouble(Vector128<UInt64>)	float64x2_t vcvtq_f64_u64 (uint64x2_t a); A64: UCVTF Vd.2D, Vn.2D
            // ConvertToDouble(Vector64<Single>)	float64x2_t vcvt_f64_f32 (float32x2_t a); A64: FCVTL Vd.2D, Vn.2S
            // ConvertToDoubleScalar(Vector64<Int64>)	float64x1_t vcvt_f64_s64 (int64x1_t a); A64: SCVTF Dd, Dn
            // ConvertToDoubleScalar(Vector64<UInt64>)	float64x1_t vcvt_f64_u64 (uint64x1_t a); A64: UCVTF Dd, Dn
            WriteLine(writer, indent, "ConvertToDouble(Vector128s<long>.Demo):\t{0}", AdvSimd.Arm64.ConvertToDouble(Vector128s<long>.Demo));
            WriteLine(writer, indent, "ConvertToDouble(Vector128s<ulong>.Demo):\t{0}", AdvSimd.Arm64.ConvertToDouble(Vector128s<ulong>.Demo));

            // ConvertToDoubleUpper(Vector128<Single>)	float64x2_t vcvt_high_f64_f32 (float32x4_t a); A64: FCVTL2 Vd.2D, Vn.4S
            WriteLine(writer, indent, "ConvertToDoubleUpper(Vector128s<float>.Demo):\t{0}", AdvSimd.Arm64.ConvertToDoubleUpper(Vector128s<float>.Demo));

            // ConvertToInt64RoundAwayFromZero(Vector128<Double>)	int64x2_t vcvtaq_s64_f64 (float64x2_t a); A64: FCVTAS Vd.2D, Vn.2D
            // ConvertToInt64RoundAwayFromZeroScalar(Vector64<Double>)	int64x1_t vcvta_s64_f64 (float64x1_t a); A64: FCVTAS Dd, Dn
            WriteLine(writer, indent, "ConvertToInt64RoundAwayFromZero(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToInt64RoundAwayFromZero(Vector128s<double>.Demo));

            // ConvertToInt64RoundToEven(Vector128<Double>)	int64x2_t vcvtnq_s64_f64 (float64x2_t a); A64: FCVTNS Vd.2D, Vn.2D
            // ConvertToInt64RoundToEvenScalar(Vector64<Double>)	int64x1_t vcvtn_s64_f64 (float64x1_t a); A64: FCVTNS Dd, Dn
            WriteLine(writer, indent, "ConvertToInt64RoundToEven(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToInt64RoundToEven(Vector128s<double>.Demo));

            // ConvertToInt64RoundToNegativeInfinity(Vector128<Double>)	int64x2_t vcvtmq_s64_f64 (float64x2_t a); A64: FCVTMS Vd.2D, Vn.2D
            // ConvertToInt64RoundToNegativeInfinityScalar(Vector64<Double>)	int64x1_t vcvtm_s64_f64 (float64x1_t a); A64: FCVTMS Dd, Dn
            WriteLine(writer, indent, "ConvertToInt64RoundToNegativeInfinity(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToInt64RoundToNegativeInfinity(Vector128s<double>.Demo));

            // ConvertToInt64RoundToPositiveInfinity(Vector128<Double>)	int64x2_t vcvtpq_s64_f64 (float64x2_t a); A64: FCVTPS Vd.2D, Vn.2D
            // ConvertToInt64RoundToPositiveInfinityScalar(Vector64<Double>)	int64x1_t vcvtp_s64_f64 (float64x1_t a); A64: FCVTPS Dd, Dn
            WriteLine(writer, indent, "ConvertToInt64RoundToPositiveInfinity(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToInt64RoundToPositiveInfinity(Vector128s<double>.Demo));

            // ConvertToInt64RoundToZero(Vector128<Double>)	int64x2_t vcvtq_s64_f64 (float64x2_t a); A64: FCVTZS Vd.2D, Vn.2D
            // ConvertToInt64RoundToZeroScalar(Vector64<Double>)	int64x1_t vcvt_s64_f64 (float64x1_t a); A64: FCVTZS Dd, Dn
            WriteLine(writer, indent, "ConvertToInt64RoundToZero(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToInt64RoundToZero(Vector128s<double>.Demo));

            // ConvertToSingleLower(Vector128<Double>)	float32x2_t vcvt_f32_f64 (float64x2_t a); A64: FCVTN Vd.2S, Vn.2D
            WriteLine(writer, indent, "ConvertToSingleLower(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToSingleLower(Vector128s<double>.Demo));

            // ConvertToSingleRoundToOddLower(Vector128<Double>)	float32x2_t vcvtx_f32_f64 (float64x2_t a); A64: FCVTXN Vd.2S, Vn.2D
            WriteLine(writer, indent, "ConvertToSingleRoundToOddLower(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToSingleRoundToOddLower(Vector128s<double>.Demo));

            // ConvertToSingleRoundToOddUpper(Vector64<Single>, Vector128<Double>)	float32x4_t vcvtx_high_f32_f64 (float32x2_t r, float64x2_t a); A64: FCVTXN2 Vd.4S, Vn.2D
            WriteLine(writer, indent, "ConvertToSingleRoundToOddUpper(Vector64s<float>.SerialNegative, Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToSingleRoundToOddUpper(Vector64s<float>.SerialNegative, Vector128s<double>.Demo));

            // ConvertToSingleUpper(Vector64<Single>, Vector128<Double>)	float32x4_t vcvt_high_f32_f64 (float32x2_t r, float64x2_t a); A64: FCVTN2 Vd.4S, Vn.2D
            WriteLine(writer, indent, "ConvertToSingleUpper(Vector64s<float>.SerialNegative, Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToSingleUpper(Vector64s<float>.SerialNegative, Vector128s<double>.Demo));

            // ConvertToUInt64RoundAwayFromZero(Vector128<Double>)	uint64x2_t vcvtaq_u64_f64 (float64x2_t a); A64: FCVTAU Vd.2D, Vn.2D
            // ConvertToUInt64RoundAwayFromZeroScalar(Vector64<Double>)	uint64x1_t vcvta_u64_f64 (float64x1_t a); A64: FCVTAU Dd, Dn
            WriteLine(writer, indent, "ConvertToUInt64RoundAwayFromZero(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToUInt64RoundAwayFromZero(Vector128s<double>.Demo));

            // ConvertToUInt64RoundToEven(Vector128<Double>)	uint64x2_t vcvtnq_u64_f64 (float64x2_t a); A64: FCVTNU Vd.2D, Vn.2D
            // ConvertToUInt64RoundToEvenScalar(Vector64<Double>)	uint64x1_t vcvtn_u64_f64 (float64x1_t a); A64: FCVTNU Dd, Dn
            WriteLine(writer, indent, "ConvertToUInt64RoundToEven(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToUInt64RoundToEven(Vector128s<double>.Demo));

            // ConvertToUInt64RoundToNegativeInfinity(Vector128<Double>)	uint64x2_t vcvtmq_u64_f64 (float64x2_t a); A64: FCVTMU Vd.2D, Vn.2D
            // ConvertToUInt64RoundToNegativeInfinityScalar(Vector64<Double>)	uint64x1_t vcvtm_u64_f64 (float64x1_t a); A64: FCVTMU Dd, Dn
            WriteLine(writer, indent, "ConvertToUInt64RoundToNegativeInfinity(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToUInt64RoundToNegativeInfinity(Vector128s<double>.Demo));

            // ConvertToUInt64RoundToPositiveInfinity(Vector128<Double>)	uint64x2_t vcvtpq_u64_f64 (float64x2_t a); A64: FCVTPU Vd.2D, Vn.2D
            // ConvertToUInt64RoundToPositiveInfinityScalar(Vector64<Double>)	uint64x1_t vcvtp_u64_f64 (float64x1_t a); A64: FCVTPU Dd, Dn
            WriteLine(writer, indent, "ConvertToUInt64RoundToPositiveInfinity(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToUInt64RoundToPositiveInfinity(Vector128s<double>.Demo));

            // ConvertToUInt64RoundToZero(Vector128<Double>)	uint64x2_t vcvtq_u64_f64 (float64x2_t a); A64: FCVTZU Vd.2D, Vn.2D
            // ConvertToUInt64RoundToZeroScalar(Vector64<Double>)	uint64x1_t vcvt_u64_f64 (float64x1_t a); A64: FCVTZU Dd, Dn
            WriteLine(writer, indent, "ConvertToUInt64RoundToZero(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ConvertToUInt64RoundToZero(Vector128s<double>.Demo));
        }
        public unsafe static void RunArm_AdvSimd_64_D(TextWriter writer, string indent) {
            // X86 SSE2+: _mm_div_ps, _mm_div_pd
            // Mnemonic: `rt[0] := a[i] / b[i]`.
            // Divide(Vector128<Double>, Vector128<Double>)	float64x2_t vdivq_f64 (float64x2_t a, float64x2_t b); A64: FDIV Vd.2D, Vn.2D, Vm.2D
            // Divide(Vector128<Single>, Vector128<Single>)	float32x4_t vdivq_f32 (float32x4_t a, float32x4_t b); A64: FDIV Vd.4S, Vn.4S, Vm.4S
            // Divide(Vector64<Single>, Vector64<Single>)	float32x2_t vdiv_f32 (float32x2_t a, float32x2_t b); A64: FDIV Vd.2S, Vn.2S, Vm.2S
            try {
                //WriteLine(writer, indent, "Divide(Vector64s<float>.Serial, Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector64s<float>.Serial, Vector64s<float>.V2));
                //WriteLine(writer, indent, "Divide(Vector128s<float>.Serial, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector128s<float>.Serial, Vector128s<float>.V2));
                //WriteLine(writer, indent, "Divide(Vector128s<double>.Serial, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector128s<double>.Serial, Vector128s<double>.V2));
                WriteLine(writer, indent, "Divide(Vector64s<float>.Demo, Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector64s<float>.Demo, Vector64s<float>.V2));
                WriteLine(writer, indent, "Divide(Vector128s<float>.Demo, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector128s<float>.Demo, Vector128s<float>.V2));
                WriteLine(writer, indent, "Divide(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector128s<double>.Demo, Vector128s<double>.V2));
                WriteLine(writer, indent, "Divide(Vector64s<float>.InterlacedSign, Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector64s<float>.InterlacedSign, Vector64s<float>.V2));
                WriteLine(writer, indent, "Divide(Vector128s<float>.InterlacedSign, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector128s<float>.InterlacedSign, Vector128s<float>.V2));
                WriteLine(writer, indent, "Divide(Vector128s<double>.InterlacedSign, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Divide(Vector128s<double>.InterlacedSign, Vector128s<double>.V2));
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // Mnemonic: `rt[i] := vec[lane]`.
            // DuplicateSelectedScalarToVector128(Vector128<Double>, Byte)	float64x2_t vdupq_laneq_f64 (float64x2_t vec, const int lane); A64: DUP Vd.2D, Vn.D[index]
            // DuplicateSelectedScalarToVector128(Vector128<Int64>, Byte)	int64x2_t vdupq_laneq_s64 (int64x2_t vec, const int lane); A64: DUP Vd.2D, Vn.D[index]
            // DuplicateSelectedScalarToVector128(Vector128<UInt64>, Byte)	uint64x2_t vdupq_laneq_u64 (uint64x2_t vec, const int lane); A64: DUP Vd.2D, Vn.D[index]
            for (byte i = 0; i <= 1; ++i) {
                WriteLine(writer, indent, "DuplicateSelectedScalarToVector128(Vector128s<ulong>.Serial, {1}):\t{0}", AdvSimd.Arm64.DuplicateSelectedScalarToVector128(Vector128s<ulong>.Serial, i), i);
                WriteLine(writer, indent, "DuplicateSelectedScalarToVector128(Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.DuplicateSelectedScalarToVector128(Vector128s<double>.Serial, i), i);
            }

            // Mnemonic: `rt[i] := vec[lane]`.
            // DuplicateToVector128(Double)	float64x2_t vdupq_n_f64 (float64_t value); A64: DUP Vd.2D, Vn.D[0]
            // DuplicateToVector128(Int64)	int64x2_t vdupq_n_s64 (int64_t value); A64: DUP Vd.2D, Rn
            // DuplicateToVector128(UInt64)	uint64x2_t vdupq_n_s64 (uint64_t value); A64: DUP Vd.2D, Rn
            WriteLine(writer, indent, "DuplicateToVector128((long)-64):\t{0}", AdvSimd.Arm64.DuplicateToVector128((long)-64));
            WriteLine(writer, indent, "DuplicateToVector128((double)-64.5):\t{0}", AdvSimd.Arm64.DuplicateToVector128((double)-64.5));
        }
        public unsafe static void RunArm_AdvSimd_64_E(TextWriter writer, string indent) {
            // ExtractNarrowingSaturateScalar(Vector64<Int16>)	int8_t vqmovnh_s16 (int16_t a) A64: SQXTN Bd, Hn
            // ExtractNarrowingSaturateScalar(Vector64<Int32>)	int16_t vqmovns_s32 (int32_t a) A64: SQXTN Hd, Sn
            // ExtractNarrowingSaturateScalar(Vector64<Int64>)	int32_t vqmovnd_s64 (int64_t a) A64: SQXTN Sd, Dn
            // ExtractNarrowingSaturateScalar(Vector64<UInt16>)	uint8_t vqmovnh_u16 (uint16_t a) A64: UQXTN Bd, Hn
            // ExtractNarrowingSaturateScalar(Vector64<UInt32>)	uint16_t vqmovns_u32 (uint32_t a) A64: UQXTN Hd, Sn
            // ExtractNarrowingSaturateScalar(Vector64<UInt64>)	uint32_t vqmovnd_u64 (uint64_t a) A64: UQXTN Sd, Dn
            WriteLine(writer, indent, "ExtractNarrowingSaturateScalar(Vector64s<short>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateScalar(Vector64s<short>.Demo));
            WriteLine(writer, indent, "ExtractNarrowingSaturateScalar(Vector64s<ushort>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateScalar(Vector64s<ushort>.Demo));
            WriteLine(writer, indent, "ExtractNarrowingSaturateScalar(Vector64s<int>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateScalar(Vector64s<int>.Demo));
            WriteLine(writer, indent, "ExtractNarrowingSaturateScalar(Vector64s<uint>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateScalar(Vector64s<uint>.Demo));
            WriteLine(writer, indent, "ExtractNarrowingSaturateScalar(Vector64s<long>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateScalar(Vector64s<long>.Demo));
            WriteLine(writer, indent, "ExtractNarrowingSaturateScalar(Vector64s<ulong>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateScalar(Vector64s<ulong>.Demo));

            // ExtractNarrowingSaturateUnsignedScalar(Vector64<Int16>)	uint8_t vqmovunh_s16 (int16_t a) A64: SQXTUN Bd, Hn
            // ExtractNarrowingSaturateUnsignedScalar(Vector64<Int32>)	uint16_t vqmovuns_s32 (int32_t a) A64: SQXTUN Hd, Sn
            // ExtractNarrowingSaturateUnsignedScalar(Vector64<Int64>)	uint32_t vqmovund_s64 (int64_t a) A64: SQXTUN Sd, Dn
            WriteLine(writer, indent, "ExtractNarrowingSaturateUnsignedScalar(Vector64s<short>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateUnsignedScalar(Vector64s<short>.Demo));
            WriteLine(writer, indent, "ExtractNarrowingSaturateUnsignedScalar(Vector64s<int>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateUnsignedScalar(Vector64s<int>.Demo));
            WriteLine(writer, indent, "ExtractNarrowingSaturateUnsignedScalar(Vector64s<long>.Demo):\t{0}", AdvSimd.Arm64.ExtractNarrowingSaturateUnsignedScalar(Vector64s<long>.Demo));
        }
        public unsafe static void RunArm_AdvSimd_64_F(TextWriter writer, string indent) {
            // 4、towards -Inf
            // Floor(Vector128<Double>)	float64x2_t vrndmq_f64 (float64x2_t a); A64: FRINTM Vd.2D, Vn.2D
            WriteLine(writer, indent, "Floor(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.Floor(Vector128s<double>.Demo));

            // 12、Fused multiply accumulate: vfma -> ri = ai + bi * ci;  
            // The result of the multiply is not rounded before the accumulation
            // 乘法的结果在累加之前没有被四舍五入.
            // FusedMultiplyAdd(Vector128<Double>, Vector128<Double>, Vector128<Double>)	float64x2_t vfmaq_f64 (float64x2_t a, float64x2_t b, float64x2_t c); A64: FMLA Vd.2D, Vn.2D, Vm.2D
            WriteLine(writer, indent, "FusedMultiplyAdd(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.V3):\t{0}", AdvSimd.Arm64.FusedMultiplyAdd(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.V3));

            // FusedMultiplyAddByScalar(Vector128<Double>, Vector128<Double>, Vector64<Double>)	float64x2_t vfmaq_n_f64 (float64x2_t a, float64x2_t b, float64_t n); A64: FMLA Vd.2D, Vn.2D, Vm.D[0]
            // FusedMultiplyAddByScalar(Vector128<Single>, Vector128<Single>, Vector64<Single>)	float32x4_t vfmaq_n_f32 (float32x4_t a, float32x4_t b, float32_t n); A64: FMLA Vd.4S, Vn.4S, Vm.S[0]
            // FusedMultiplyAddByScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32x2_t vfma_n_f32 (float32x2_t a, float32x2_t b, float32_t n); A64: FMLA Vd.2S, Vn.2S, Vm.S[0]
            WriteLine(writer, indent, "FusedMultiplyAddByScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.V3):\t{0}", AdvSimd.Arm64.FusedMultiplyAddByScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector64s<double>.V3));

            // FusedMultiplyAddBySelectedScalar(Vector128<Double>, Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vfmaq_laneq_f64 (float64x2_t a, float64x2_t b, float64x2_t v, const int lane); A64: FMLA Vd.2D, Vn.2D, Vm.D[lane]
            // FusedMultiplyAddBySelectedScalar(Vector128<Single>, Vector128<Single>, Vector128<Single>, Byte)	float32x4_t vfmaq_laneq_f32 (float32x4_t a, float32x4_t b, float32x4_t v, const int lane); A64: FMLA Vd.4S, Vn.4S, Vm.S[lane]
            // FusedMultiplyAddBySelectedScalar(Vector128<Single>, Vector128<Single>, Vector64<Single>, Byte)	float32x4_t vfmaq_lane_f32 (float32x4_t a, float32x4_t b, float32x2_t v, const int lane); A64: FMLA Vd.4S, Vn.4S, Vm.S[lane]
            // FusedMultiplyAddBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector128<Single>, Byte)	float32x2_t vfma_laneq_f32 (float32x2_t a, float32x2_t b, float32x4_t v, const int lane); A64: FMLA Vd.2S, Vn.2S, Vm.S[lane]
            // FusedMultiplyAddBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>, Byte)	float32x2_t vfma_lane_f32 (float32x2_t a, float32x2_t b, float32x2_t v, const int lane); A64: FMLA Vd.2S, Vn.2S, Vm.S[lane]
            try {
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "FusedMultiplyAddBySelectedScalar(Vector128s<float>.Demo, Vector128s<float>.V2, Vector128s<float>.Serial, {1}):\t{0}", AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(Vector128s<float>.Demo, Vector128s<float>.V2, Vector128s<float>.Serial, i), i);
                }
                for (byte i = 0; i <= 1; ++i) {
                    WriteLine(writer, indent, "FusedMultiplyAddBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.FusedMultiplyAddBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // FusedMultiplyAddScalarBySelectedScalar(Vector64<Double>, Vector64<Double>, Vector128<Double>, Byte)	float64_t vfmad_laneq_f64 (float64_t a, float64_t b, float64x2_t v, const int lane); A64: FMLA Dd, Dn, Vm.D[lane]
            // FusedMultiplyAddScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector128<Single>, Byte)	float32_t vfmas_laneq_f32 (float32_t a, float32_t b, float32x4_t v, const int lane); A64: FMLA Sd, Sn, Vm.S[lane]
            // FusedMultiplyAddScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>, Byte)	float32_t vfmas_lane_f32 (float32_t a, float32_t b, float32x2_t v, const int lane); A64: FMLA Sd, Sn, Vm.S[lane]
            try {
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "FusedMultiplyAddScalarBySelectedScalar(Vector128s<float>.Demo, Vector128s<float>.V2, Vector128s<float>.Serial, {1}):\t{0}", AdvSimd.Arm64.FusedMultiplyAddScalarBySelectedScalar(Vector64s<float>.Demo, Vector64s<float>.V2, Vector128s<float>.Serial, i), i);
                }
                for (byte i = 0; i <= 1; ++i) {
                    WriteLine(writer, indent, "FusedMultiplyAddScalarBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.FusedMultiplyAddScalarBySelectedScalar(Vector64s<double>.Demo, Vector64s<double>.V2, Vector128s<double>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // 13、Fused multiply subtract: vfms -> ri = ai - bi * ci;  
            // The result of the multiply is not rounded before the subtraction
            // 乘的结果在减法之前没有四舍五入
            // FusedMultiplySubtract(Vector128<Double>, Vector128<Double>, Vector128<Double>)	float64x2_t vfmsq_f64 (float64x2_t a, float64x2_t b, float64x2_t c); A64: FMLS Vd.2D, Vn.2D, Vm.2D
            WriteLine(writer, indent, "FusedMultiplySubtract(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.V3):\t{0}", AdvSimd.Arm64.FusedMultiplySubtract(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.V3));

            // FusedMultiplySubtractByScalar(Vector128<Double>, Vector128<Double>, Vector64<Double>)	float64x2_t vfmsq_n_f64 (float64x2_t a, float64x2_t b, float64_t n); A64: FMLS Vd.2D, Vn.2D, Vm.D[0]
            // FusedMultiplySubtractByScalar(Vector128<Single>, Vector128<Single>, Vector64<Single>)	float32x4_t vfmsq_n_f32 (float32x4_t a, float32x4_t b, float32_t n); A64: FMLS Vd.4S, Vn.4S, Vm.S[0]
            // FusedMultiplySubtractByScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32x2_t vfms_n_f32 (float32x2_t a, float32x2_t b, float32_t n); A64: FMLS Vd.2S, Vn.2S, Vm.S[0]
            WriteLine(writer, indent, "FusedMultiplySubtractByScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.V3):\t{0}", AdvSimd.Arm64.FusedMultiplySubtractByScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector64s<double>.V3));

            // FusedMultiplySubtractBySelectedScalar(Vector128<Double>, Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vfmsq_laneq_f64 (float64x2_t a, float64x2_t b, float64x2_t v, const int lane); A64: FMLS Vd.2D, Vn.2D, Vm.D[lane]
            // FusedMultiplySubtractBySelectedScalar(Vector128<Single>, Vector128<Single>, Vector128<Single>, Byte)	float32x4_t vfmsq_laneq_f32 (float32x4_t a, float32x4_t b, float32x4_t v, const int lane); A64: FMLS Vd.4S, Vn.4S, Vm.S[lane]
            // FusedMultiplySubtractBySelectedScalar(Vector128<Single>, Vector128<Single>, Vector64<Single>, Byte)	float32x4_t vfmsq_lane_f32 (float32x4_t a, float32x4_t b, float32x2_t v, const int lane); A64: FMLS Vd.4S, Vn.4S, Vm.S[lane]
            // FusedMultiplySubtractBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector128<Single>, Byte)	float32x2_t vfms_laneq_f32 (float32x2_t a, float32x2_t b, float32x4_t v, const int lane); A64: FMLS Vd.2S, Vn.2S, Vm.S[lane]
            // FusedMultiplySubtractBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>, Byte)	float32x2_t vfms_lane_f32 (float32x2_t a, float32x2_t b, float32x2_t v, const int lane); A64: FMLS Vd.2S, Vn.2S, Vm.S[lane]
            try {
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "FusedMultiplySubtractBySelectedScalar(Vector128s<float>.Demo, Vector128s<float>.V2, Vector128s<float>.Serial, {1}):\t{0}", AdvSimd.Arm64.FusedMultiplySubtractBySelectedScalar(Vector128s<float>.Demo, Vector128s<float>.V2, Vector128s<float>.Serial, i), i);
                }
                for (byte i = 0; i <= 1; ++i) {
                    WriteLine(writer, indent, "FusedMultiplySubtractBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.FusedMultiplySubtractBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // FusedMultiplySubtractScalarBySelectedScalar(Vector64<Double>, Vector64<Double>, Vector128<Double>, Byte)	float64_t vfmsd_laneq_f64 (float64_t a, float64_t b, float64x2_t v, const int lane); A64: FMLS Dd, Dn, Vm.D[lane]
            // FusedMultiplySubtractScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector128<Single>, Byte)	float32_t vfmss_laneq_f32 (float32_t a, float32_t b, float32x4_t v, const int lane); A64: FMLS Sd, Sn, Vm.S[lane]
            // FusedMultiplySubtractScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>, Byte)	float32_t vfmss_lane_f32 (float32_t a, float32_t b, float32x2_t v, const int lane); A64: FMLS Sd, Sn, Vm.S[lane]
            try {
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "FusedMultiplySubtractScalarBySelectedScalar(Vector128s<float>.Demo, Vector128s<float>.V2, Vector128s<float>.Serial, {1}):\t{0}", AdvSimd.Arm64.FusedMultiplySubtractScalarBySelectedScalar(Vector64s<float>.Demo, Vector64s<float>.V2, Vector128s<float>.Serial, i), i);
                }
                for (byte i = 0; i <= 1; ++i) {
                    WriteLine(writer, indent, "FusedMultiplySubtractScalarBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.V2, Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.FusedMultiplySubtractScalarBySelectedScalar(Vector64s<double>.Demo, Vector64s<double>.V2, Vector128s<double>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }
        }
        public unsafe static void RunArm_AdvSimd_64_I(TextWriter writer, string indent) {
            // InsertSelectedScalar(Vector128<Byte>, Byte, Vector128<Byte>, Byte)	uint8x16_t vcopyq_laneq_u8 (uint8x16_t a, const int lane1, uint8x16_t b, const int lane2); A64: INS Vd.B[lane1], Vn.B[lane2]
            // InsertSelectedScalar(Vector128<Byte>, Byte, Vector64<Byte>, Byte)	uint8x16_t vcopyq_lane_u8 (uint8x16_t a, const int lane1, uint8x8_t b, const int lane2); A64: INS Vd.B[lane1], Vn.B[lane2]
            // InsertSelectedScalar(Vector128<Double>, Byte, Vector128<Double>, Byte)	float64x2_t vcopyq_laneq_f64 (float64x2_t a, const int lane1, float64x2_t b, const int lane2); A64: INS Vd.D[lane1], Vn.D[lane2]
            // InsertSelectedScalar(Vector128<Int16>, Byte, Vector128<Int16>, Byte)	int16x8_t vcopyq_laneq_s16 (int16x8_t a, const int lane1, int16x8_t b, const int lane2); A64: INS Vd.H[lane1], Vn.H[lane2]
            // InsertSelectedScalar(Vector128<Int16>, Byte, Vector64<Int16>, Byte)	int16x8_t vcopyq_lane_s16 (int16x8_t a, const int lane1, int16x4_t b, const int lane2); A64: INS Vd.H[lane1], Vn.H[lane2]
            // InsertSelectedScalar(Vector128<Int32>, Byte, Vector128<Int32>, Byte)	int32x4_t vcopyq_laneq_s32 (int32x4_t a, const int lane1, int32x4_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector128<Int32>, Byte, Vector64<Int32>, Byte)	int32x4_t vcopyq_lane_s32 (int32x4_t a, const int lane1, int32x2_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector128<Int64>, Byte, Vector128<Int64>, Byte)	int64x2_t vcopyq_laneq_s64 (int64x2_t a, const int lane1, int64x2_t b, const int lane2); A64: INS Vd.D[lane1], Vn.D[lane2]
            // InsertSelectedScalar(Vector128<SByte>, Byte, Vector128<SByte>, Byte)	int8x16_t vcopyq_laneq_s8 (int8x16_t a, const int lane1, int8x16_t b, const int lane2); A64: INS Vd.B[lane1], Vn.B[lane2]
            // InsertSelectedScalar(Vector128<SByte>, Byte, Vector64<SByte>, Byte)	int8x16_t vcopyq_lane_s8 (int8x16_t a, const int lane1, int8x8_t b, const int lane2); A64: INS Vd.B[lane1], Vn.B[lane2]
            // InsertSelectedScalar(Vector128<Single>, Byte, Vector128<Single>, Byte)	float32x4_t vcopyq_laneq_f32 (float32x4_t a, const int lane1, float32x4_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector128<Single>, Byte, Vector64<Single>, Byte)	float32x4_t vcopyq_lane_f32 (float32x4_t a, const int lane1, float32x2_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector128<UInt16>, Byte, Vector128<UInt16>, Byte)	uint16x8_t vcopyq_laneq_u16 (uint16x8_t a, const int lane1, uint16x8_t b, const int lane2); A64: INS Vd.H[lane1], Vn.H[lane2]
            // InsertSelectedScalar(Vector128<UInt16>, Byte, Vector64<UInt16>, Byte)	uint16x8_t vcopyq_lane_u16 (uint16x8_t a, const int lane1, uint16x4_t b, const int lane2); A64: INS Vd.H[lane1], Vn.H[lane2]
            // InsertSelectedScalar(Vector128<UInt32>, Byte, Vector128<UInt32>, Byte)	uint32x4_t vcopyq_laneq_u32 (uint32x4_t a, const int lane1, uint32x4_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector128<UInt32>, Byte, Vector64<UInt32>, Byte)	uint32x4_t vcopyq_lane_u32 (uint32x4_t a, const int lane1, uint32x2_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector128<UInt64>, Byte, Vector128<UInt64>, Byte)	uint64x2_t vcopyq_laneq_u64 (uint64x2_t a, const int lane1, uint64x2_t b, const int lane2); A64: INS Vd.D[lane1], Vn.D[lane2]
            // InsertSelectedScalar(Vector64<Byte>, Byte, Vector128<Byte>, Byte)	uint8x8_t vcopy_laneq_u8 (uint8x8_t a, const int lane1, uint8x16_t b, const int lane2); A64: INS Vd.B[lane1], Vn.B[lane2]
            // InsertSelectedScalar(Vector64<Byte>, Byte, Vector64<Byte>, Byte)	uint8x8_t vcopy_lane_u8 (uint8x8_t a, const int lane1, uint8x8_t b, const int lane2); A64: INS Vd.B[lane1], Vn.B[lane2]
            // InsertSelectedScalar(Vector64<Int16>, Byte, Vector128<Int16>, Byte)	int16x4_t vcopy_laneq_s16 (int16x4_t a, const int lane1, int16x8_t b, const int lane2); A64: INS Vd.H[lane1], Vn.H[lane2]
            // InsertSelectedScalar(Vector64<Int16>, Byte, Vector64<Int16>, Byte)	int16x4_t vcopy_lane_s16 (int16x4_t a, const int lane1, int16x4_t b, const int lane2); A64: INS Vd.H[lane1], Vn.H[lane2]
            // InsertSelectedScalar(Vector64<Int32>, Byte, Vector128<Int32>, Byte)	int32x2_t vcopy_laneq_s32 (int32x2_t a, const int lane1, int32x4_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector64<Int32>, Byte, Vector64<Int32>, Byte)	int32x2_t vcopy_lane_s32 (int32x2_t a, const int lane1, int32x2_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector64<SByte>, Byte, Vector128<SByte>, Byte)	int8x8_t vcopy_laneq_s8 (int8x8_t a, const int lane1, int8x16_t b, const int lane2); A64: INS Vd.B[lane1], Vn.B[lane2]
            // InsertSelectedScalar(Vector64<SByte>, Byte, Vector64<SByte>, Byte)	int8x8_t vcopy_lane_s8 (int8x8_t a, const int lane1, int8x8_t b, const int lane2); A64: INS Vd.B[lane1], Vn.B[lane2]
            // InsertSelectedScalar(Vector64<Single>, Byte, Vector128<Single>, Byte)	float32x2_t vcopy_laneq_f32 (float32x2_t a, const int lane1, float32x4_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector64<Single>, Byte, Vector64<Single>, Byte)	float32x2_t vcopy_lane_f32 (float32x2_t a, const int lane1, float32x2_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector64<UInt16>, Byte, Vector128<UInt16>, Byte)	uint16x4_t vcopy_laneq_u16 (uint16x4_t a, const int lane1, uint16x8_t b, const int lane2); A64: INS Vd.H[lane1], Vn.H[lane2]
            // InsertSelectedScalar(Vector64<UInt16>, Byte, Vector64<UInt16>, Byte)	uint16x4_t vcopy_lane_u16 (uint16x4_t a, const int lane1, uint16x4_t b, const int lane2); A64: INS Vd.H[lane1], Vn.H[lane2]
            // InsertSelectedScalar(Vector64<UInt32>, Byte, Vector128<UInt32>, Byte)	uint32x2_t vcopy_laneq_u32 (uint32x2_t a, const int lane1, uint32x4_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            // InsertSelectedScalar(Vector64<UInt32>, Byte, Vector64<UInt32>, Byte)	uint32x2_t vcopy_lane_u32 (uint32x2_t a, const int lane1, uint32x2_t b, const int lane2); A64: INS Vd.S[lane1], Vn.S[lane2]
            try {
                for (byte i = 0; i <= 1; ++i) {
                    for (byte j = 0; j <= 1; ++j) {
                        WriteLine(writer, indent, "InsertSelectedScalar(Vector128s<byte>.Demo, {1}, Vector128s<byte>.SerialNegative, {2}):\t{0}", AdvSimd.Arm64.InsertSelectedScalar(Vector128s<byte>.Demo, i, Vector128s<byte>.SerialNegative, j), i, j);
                    }
                }
                for (byte i = 0; i <= 1; ++i) {
                    for (byte j = 0; j <= 1; ++j) {
                        WriteLine(writer, indent, "InsertSelectedScalar(Vector128s<short>.Demo, {1}, Vector128s<short>.SerialNegative, {2}):\t{0}", AdvSimd.Arm64.InsertSelectedScalar(Vector128s<short>.Demo, i, Vector128s<short>.SerialNegative, j), i, j);
                    }
                }
                for (byte i = 0; i <= 1; ++i) {
                    for (byte j = 0; j <= 1; ++j) {
                        WriteLine(writer, indent, "InsertSelectedScalar(Vector128s<int>.Demo, {1}, Vector128s<int>.SerialNegative, {2}):\t{0}", AdvSimd.Arm64.InsertSelectedScalar(Vector128s<int>.Demo, i, Vector128s<int>.SerialNegative, j), i, j);
                    }
                }
                for (byte i = 0; i <= 1; ++i) {
                    for (byte j = 0; j <= 1; ++j) {
                        WriteLine(writer, indent, "InsertSelectedScalar(Vector128s<long>.Demo, {1}, Vector128s<long>.SerialNegative, {2}):\t{0}", AdvSimd.Arm64.InsertSelectedScalar(Vector128s<long>.Demo, i, Vector128s<long>.SerialNegative, j), i, j);
                    }
                }
                for (byte i = 0; i <= 1; ++i) {
                    for (byte j = 0; j <= 1; ++j) {
                        WriteLine(writer, indent, "InsertSelectedScalar(Vector128s<float>.Demo, {1}, Vector128s<float>.SerialNegative, {2}):\t{0}", AdvSimd.Arm64.InsertSelectedScalar(Vector128s<float>.Demo, i, Vector128s<float>.SerialNegative, j), i, j);
                    }
                }
                for (byte i = 0; i <= 1; ++i) {
                    for (byte j = 0; j <= 1; ++j) {
                        WriteLine(writer, indent, "InsertSelectedScalar(Vector128s<double>.Demo, {1}, Vector128s<double>.SerialNegative, {2}):\t{0}", AdvSimd.Arm64.InsertSelectedScalar(Vector128s<double>.Demo, i, Vector128s<double>.SerialNegative, j), i, j);
                    }
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }
        }
        public unsafe static void RunArm_AdvSimd_64_L(TextWriter writer, string indent) {
            // 3、Load all lanes of vector with same value from memory: vld1 ->  
            // loads one element in a vector from memory.  
            // The loaded element is copied to all other lanes of the vector.
            // 从内存中加载向量中的一个元素。
            // 加载的元素被复制到向量的所有其他车道上。
            // LoadAndReplicateToVector128(Double*)	float64x2_t vld1q_dup_f64 (float64_t const * ptr); A64: LD1R { Vt.2D }, [Xn]
            // LoadAndReplicateToVector128(Int64*)	int64x2_t vld1q_dup_s64 (int64_t const * ptr); A64: LD1R { Vt.2D }, [Xn]
            // LoadAndReplicateToVector128(UInt64*)	uint64x2_t vld1q_dup_u64 (uint64_t const * ptr); A64: LD1R { Vt.2D }, [Xn]
            // Ignore

            // LoadPairScalarVector64(Int32*)	A64: LDP St1, St2, [Xn]
            // LoadPairScalarVector64(Single*)	A64: LDP St1, St2, [Xn]
            // LoadPairScalarVector64(UInt32*)	A64: LDP St1, St2, [Xn]
            // LoadPairScalarVector64NonTemporal(Int32*)	A64: LDNP St1, St2, [Xn]
            // LoadPairScalarVector64NonTemporal(Single*)	A64: LDNP St1, St2, [Xn]
            // LoadPairScalarVector64NonTemporal(UInt32*)	A64: LDNP St1, St2, [Xn]
            fixed (void* p0 = &Vector64s<int>.SerialNegative) {
                int* p = (int*)p0;
                WriteLine(writer, indent, "LoadPairScalarVector64(p):\t{0}", AdvSimd.Arm64.LoadPairScalarVector64(p));
            }

            // LoadPairVector128(Byte*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(Double*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(Int16*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(Int32*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(Int64*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(SByte*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(Single*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(UInt16*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(UInt32*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128(UInt64*)	A64: LDP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(Byte*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(Double*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(Int16*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(Int32*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(Int64*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(SByte*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(Single*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(UInt16*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(UInt32*)	A64: LDNP Qt1, Qt2, [Xn]
            // LoadPairVector128NonTemporal(UInt64*)	A64: LDNP Qt1, Qt2, [Xn]
            fixed (void* p0 = &Vector128s<byte>.SerialNegative) {
                byte* p = (byte*)p0;
                WriteLine(writer, indent, "LoadPairVector128(p):\t{0}", AdvSimd.Arm64.LoadPairVector128(p));
            }
            fixed (void* p0 = &Vector128s<short>.SerialNegative) {
                short* p = (short*)p0;
                WriteLine(writer, indent, "LoadPairVector128(p):\t{0}", AdvSimd.Arm64.LoadPairVector128(p));
            }
            fixed (void* p0 = &Vector128s<int>.SerialNegative) {
                int* p = (int*)p0;
                WriteLine(writer, indent, "LoadPairVector128(p):\t{0}", AdvSimd.Arm64.LoadPairVector128(p));
            }

            // LoadPairVector64(Byte*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(Double*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(Int16*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(Int32*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(Int64*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(SByte*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(Single*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(UInt16*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(UInt32*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64(UInt64*)	A64: LDP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(Byte*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(Double*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(Int16*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(Int32*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(Int64*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(SByte*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(Single*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(UInt16*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(UInt32*)	A64: LDNP Dt1, Dt2, [Xn]
            // LoadPairVector64NonTemporal(UInt64*)	A64: LDNP Dt1, Dt2, [Xn]
            // Ignore
        }
        public unsafe static void RunArm_AdvSimd_64_M(TextWriter writer, string indent) {
            // 正常指令, vmax -> ri = ai >= bi ? ai : bi; returns the larger of each pair
            // Max(Vector128<Double>, Vector128<Double>)	float64x2_t vmaxq_f64 (float64x2_t a, float64x2_t b); A64: FMAX Vd.2D, Vn.2D, Vm.2D
            WriteLine(writer, indent, "Max(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Max(Vector128s<double>.Demo, Vector128s<double>.V2));

            // Unsigned Maximum across Vector. This instruction compares all the vector elements in the source SIMD&FP register, and writes the largest of the values as a scalar to the destination SIMD&FP register. All the values in this instruction are unsigned integer values.
            // 跨向量的无符号最大值。这条指令比较源SIMD&FP寄存器中的所有向量元素，并将其中最大的值作为标量写入目标SIMD&FP寄存器。此指令中的所有值都是无符号整数值。
            // maxmin = Int(Elem[operand, 0, esize], unsigned);
            // for e = 1 to elements-1
            //     element = Int(Elem[operand, e, esize], unsigned);
            //     maxmin = if min then Min(maxmin, element) else Max(maxmin, element);
            // MaxAcross(Vector128<Byte>)	uint8_t vmaxvq_u8 (uint8x16_t a); A64: UMAXV Bd, Vn.16B
            // MaxAcross(Vector128<Int16>)	int16_t vmaxvq_s16 (int16x8_t a); A64: SMAXV Hd, Vn.8H
            // MaxAcross(Vector128<Int32>)	int32_t vmaxvq_s32 (int32x4_t a); A64: SMAXV Sd, Vn.4S
            // MaxAcross(Vector128<SByte>)	int8_t vmaxvq_s8 (int8x16_t a); A64: SMAXV Bd, Vn.16B
            // MaxAcross(Vector128<Single>)	float32_t vmaxvq_f32 (float32x4_t a); A64: FMAXV Sd, Vn.4S
            // MaxAcross(Vector128<UInt16>)	uint16_t vmaxvq_u16 (uint16x8_t a); A64: UMAXV Hd, Vn.8H
            // MaxAcross(Vector128<UInt32>)	uint32_t vmaxvq_u32 (uint32x4_t a); A64: UMAXV Sd, Vn.4S
            // MaxAcross(Vector64<Byte>)	uint8_t vmaxv_u8 (uint8x8_t a); A64: UMAXV Bd, Vn.8B
            // MaxAcross(Vector64<Int16>)	int16_t vmaxv_s16 (int16x4_t a); A64: SMAXV Hd, Vn.4H
            // MaxAcross(Vector64<SByte>)	int8_t vmaxv_s8 (int8x8_t a); A64: SMAXV Bd, Vn.8B
            // MaxAcross(Vector64<UInt16>)	uint16_t vmaxv_u16 (uint16x4_t a); A64: UMAXV Hd, Vn.4H
            WriteLine(writer, indent, "MaxAcross(Vector128s<sbyte>.Serial):\t{0}", AdvSimd.Arm64.MaxAcross(Vector128s<sbyte>.Serial));
            WriteLine(writer, indent, "MaxAcross(Vector128s<byte>.Serial):\t{0}", AdvSimd.Arm64.MaxAcross(Vector128s<byte>.Serial));
            WriteLine(writer, indent, "MaxAcross(Vector128s<short>.Serial):\t{0}", AdvSimd.Arm64.MaxAcross(Vector128s<short>.Serial));
            WriteLine(writer, indent, "MaxAcross(Vector128s<ushort>.Serial):\t{0}", AdvSimd.Arm64.MaxAcross(Vector128s<ushort>.Serial));
            WriteLine(writer, indent, "MaxAcross(Vector128s<int>.Serial):\t{0}", AdvSimd.Arm64.MaxAcross(Vector128s<int>.Serial));
            WriteLine(writer, indent, "MaxAcross(Vector128s<uint>.Serial):\t{0}", AdvSimd.Arm64.MaxAcross(Vector128s<uint>.Serial));
            WriteLine(writer, indent, "MaxAcross(Vector128s<float>.Serial):\t{0}", AdvSimd.Arm64.MaxAcross(Vector128s<float>.Serial));

            // MaxNumber(Vector128<Double>, Vector128<Double>)	float64x2_t vmaxnmq_f64 (float64x2_t a, float64x2_t b); A64: FMAXNM Vd.2D, Vn.2D, Vm.2D
            WriteLine(writer, indent, "MaxNumber(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.MaxNumber(Vector128s<double>.Demo, Vector128s<double>.V2));

            // MaxNumberAcross(Vector128<Single>)	float32_t vmaxnmvq_f32 (float32x4_t a); A64: FMAXNMV Sd, Vn.4S
            WriteLine(writer, indent, "MaxAcross(Vector128s<float>.Serial):\t{0}", AdvSimd.Arm64.MaxAcross(Vector128s<float>.Serial));

            // MaxNumberPairwise(Vector128<Double>, Vector128<Double>)	float64x2_t vpmaxnmq_f64 (float64x2_t a, float64x2_t b); A64: FMAXNMP Vd.2D, Vn.2D, Vm.2D
            // MaxNumberPairwise(Vector128<Single>, Vector128<Single>)	float32x4_t vpmaxnmq_f32 (float32x4_t a, float32x4_t b); A64: FMAXNMP Vd.4S, Vn.4S, Vm.4S
            // MaxNumberPairwise(Vector64<Single>, Vector64<Single>)	float32x2_t vpmaxnm_f32 (float32x2_t a, float32x2_t b); A64: FMAXNMP Vd.2S, Vn.2S, Vm.2S
            WriteLine(writer, indent, "MaxNumberPairwise(Vector128s<float>.Serial, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.MaxNumberPairwise(Vector128s<float>.Serial, Vector128s<float>.V2));
            WriteLine(writer, indent, "MaxNumberPairwise(Vector128s<double>.Serial, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.MaxNumberPairwise(Vector128s<double>.Serial, Vector128s<double>.V2));

            // MaxNumberPairwiseScalar(Vector128<Double>)	float64_t vpmaxnmqd_f64 (float64x2_t a); A64: FMAXNMP Dd, Vn.2D
            // MaxNumberPairwiseScalar(Vector64<Single>)	float32_t vpmaxnms_f32 (float32x2_t a); A64: FMAXNMP Sd, Vn.2S
            WriteLine(writer, indent, "MaxNumberPairwiseScalar(Vector64s<float>.Serial):\t{0}", AdvSimd.Arm64.MaxNumberPairwiseScalar(Vector64s<float>.Serial));
            WriteLine(writer, indent, "MaxNumberPairwiseScalar(Vector128s<double>.Serial):\t{0}", AdvSimd.Arm64.MaxNumberPairwiseScalar(Vector128s<double>.Serial));

            // 饱和指令, vpmax -> vpmax r0 = a0 >= a1 ? a0 : a1, ..., r4 = b0 >= b1 ? b0 : b1, ...; 
            // compares adjacent pairs of elements, and copies the larger of each pair into the destination vector.
            // The maximums from each pair of the first input vector are stored in the lower half of the destination vector.
            // The maximums from each pair of the second input vector are stored in the higher half of the destination vector
            // 比较相邻的元素对，并将每对中较大的元素复制到目标向量中。
            // 第一个输入向量的每对最大值存储在目标向量的下半部分。
            // 来自第二个输入向量的每对的最大值存储在目标向量的上半部分
            // MaxPairwise(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vpmaxq_u8 (uint8x16_t a, uint8x16_t b); A64: UMAXP Vd.16B, Vn.16B, Vm.16B
            // MaxPairwise(Vector128<Double>, Vector128<Double>)	float64x2_t vpmaxq_f64 (float64x2_t a, float64x2_t b); A64: FMAXP Vd.2D, Vn.2D, Vm.2D
            // MaxPairwise(Vector128<Int16>, Vector128<Int16>)	int16x8_t vpmaxq_s16 (int16x8_t a, int16x8_t b); A64: SMAXP Vd.8H, Vn.8H, Vm.8H
            // MaxPairwise(Vector128<Int32>, Vector128<Int32>)	int32x4_t vpmaxq_s32 (int32x4_t a, int32x4_t b); A64: SMAXP Vd.4S, Vn.4S, Vm.4S
            // MaxPairwise(Vector128<SByte>, Vector128<SByte>)	int8x16_t vpmaxq_s8 (int8x16_t a, int8x16_t b); A64: SMAXP Vd.16B, Vn.16B, Vm.16B
            // MaxPairwise(Vector128<Single>, Vector128<Single>)	float32x4_t vpmaxq_f32 (float32x4_t a, float32x4_t b); A64: FMAXP Vd.4S, Vn.4S, Vm.4S
            // MaxPairwise(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vpmaxq_u16 (uint16x8_t a, uint16x8_t b); A64: UMAXP Vd.8H, Vn.8H, Vm.8H
            // MaxPairwise(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vpmaxq_u32 (uint32x4_t a, uint32x4_t b); A64: UMAXP Vd.4S, Vn.4S, Vm.4S
            // MaxPairwiseScalar(Vector128<Double>)	float64_t vpmaxqd_f64 (float64x2_t a); A64: FMAXP Dd, Vn.2D
            // MaxPairwiseScalar(Vector64<Single>)	float32_t vpmaxs_f32 (float32x2_t a); A64: FMAXP Sd, Vn.2S
            WriteLine(writer, indent, "MaxPairwise(Vector128s<sbyte>.Serial, Vector128s<sbyte>.V2):\t{0}", AdvSimd.Arm64.MaxPairwise(Vector128s<sbyte>.Serial, Vector128s<sbyte>.V2));
            WriteLine(writer, indent, "MaxPairwise(Vector128s<byte>.Serial, Vector128s<byte>.V2):\t{0}", AdvSimd.Arm64.MaxPairwise(Vector128s<byte>.Serial, Vector128s<byte>.V2));
            WriteLine(writer, indent, "MaxPairwise(Vector128s<short>.Serial, Vector128s<short>.V2):\t{0}", AdvSimd.Arm64.MaxPairwise(Vector128s<short>.Serial, Vector128s<short>.V2));
            WriteLine(writer, indent, "MaxPairwise(Vector128s<ushort>.Serial, Vector128s<ushort>.V2):\t{0}", AdvSimd.Arm64.MaxPairwise(Vector128s<ushort>.Serial, Vector128s<ushort>.V2));
            WriteLine(writer, indent, "MaxPairwise(Vector128s<int>.Serial, Vector128s<int>.V2):\t{0}", AdvSimd.Arm64.MaxPairwise(Vector128s<int>.Serial, Vector128s<int>.V2));
            WriteLine(writer, indent, "MaxPairwise(Vector128s<uint>.Serial, Vector128s<uint>.V2):\t{0}", AdvSimd.Arm64.MaxPairwise(Vector128s<uint>.Serial, Vector128s<uint>.V2));
            WriteLine(writer, indent, "MaxPairwise(Vector128s<float>.Serial, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.MaxPairwise(Vector128s<float>.Serial, Vector128s<float>.V2));
            WriteLine(writer, indent, "MaxPairwiseScalar(Vector128s<double>.Serial):\t{0}", AdvSimd.Arm64.MaxPairwiseScalar(Vector128s<double>.Serial));

            // MaxScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vmax_f64 (float64x1_t a, float64x1_t b); A64: FMAX Dd, Dn, Dm
            // MaxScalar(Vector64<Single>, Vector64<Single>)	float32_t vmaxs_f32 (float32_t a, float32_t b); A64: FMAX Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            WriteLine(writer, indent, "MaxScalar(Vector64s<float>.Serial, Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.MaxScalar(Vector64s<float>.Serial, Vector64s<float>.V2));
            WriteLine(writer, indent, "MaxScalar(Vector64s<double>.Serial, Vector64s<double>.V2):\t{0}", AdvSimd.Arm64.MaxScalar(Vector64s<double>.Serial, Vector64s<double>.V2));

            // 正常指令, vmin -> ri = ai >= bi ? bi : ai; returns the smaller of each pair
            // Min(Vector128<Double>, Vector128<Double>)	float64x2_t vminq_f64 (float64x2_t a, float64x2_t b); A64: FMIN Vd.2D, Vn.2D, Vm.2D
            WriteLine(writer, indent, "Min(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Min(Vector128s<double>.Demo, Vector128s<double>.V2));

            // MinAcross(Vector128<Byte>)	uint8_t vminvq_u8 (uint8x16_t a); A64: UMINV Bd, Vn.16B
            // MinAcross(Vector128<Int16>)	int16_t vminvq_s16 (int16x8_t a); A64: SMINV Hd, Vn.8H
            // MinAcross(Vector128<Int32>)	int32_t vaddvq_s32 (int32x4_t a); A64: SMINV Sd, Vn.4S
            // MinAcross(Vector128<SByte>)	int8_t vminvq_s8 (int8x16_t a); A64: SMINV Bd, Vn.16B
            // MinAcross(Vector128<Single>)	float32_t vminvq_f32 (float32x4_t a); A64: FMINV Sd, Vn.4S
            // MinAcross(Vector128<UInt16>)	uint16_t vminvq_u16 (uint16x8_t a); A64: UMINV Hd, Vn.8H
            // MinAcross(Vector128<UInt32>)	uint32_t vminvq_u32 (uint32x4_t a); A64: UMINV Sd, Vn.4S
            // MinAcross(Vector64<Byte>)	uint8_t vminv_u8 (uint8x8_t a); A64: UMINV Bd, Vn.8B
            // MinAcross(Vector64<Int16>)	int16_t vminv_s16 (int16x4_t a); A64: SMINV Hd, Vn.4H
            // MinAcross(Vector64<SByte>)	int8_t vminv_s8 (int8x8_t a); A64: SMINV Bd, Vn.8B
            // MinAcross(Vector64<UInt16>)	uint16_t vminv_u16 (uint16x4_t a); A64: UMINV Hd, Vn.4H
            WriteLine(writer, indent, "MinAcross(Vector128s<sbyte>.Serial):\t{0}", AdvSimd.Arm64.MinAcross(Vector128s<sbyte>.Serial));
            WriteLine(writer, indent, "MinAcross(Vector128s<byte>.Serial):\t{0}", AdvSimd.Arm64.MinAcross(Vector128s<byte>.Serial));
            WriteLine(writer, indent, "MinAcross(Vector128s<short>.Serial):\t{0}", AdvSimd.Arm64.MinAcross(Vector128s<short>.Serial));
            WriteLine(writer, indent, "MinAcross(Vector128s<ushort>.Serial):\t{0}", AdvSimd.Arm64.MinAcross(Vector128s<ushort>.Serial));
            WriteLine(writer, indent, "MinAcross(Vector128s<int>.Serial):\t{0}", AdvSimd.Arm64.MinAcross(Vector128s<int>.Serial));
            WriteLine(writer, indent, "MinAcross(Vector128s<uint>.Serial):\t{0}", AdvSimd.Arm64.MinAcross(Vector128s<uint>.Serial));
            WriteLine(writer, indent, "MinAcross(Vector128s<float>.Serial):\t{0}", AdvSimd.Arm64.MinAcross(Vector128s<float>.Serial));

            // MinNumber(Vector128<Double>, Vector128<Double>)	float64x2_t vminnmq_f64 (float64x2_t a, float64x2_t b); A64: FMINNM Vd.2D, Vn.2D, Vm.2D
            WriteLine(writer, indent, "MinNumber(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.MinNumber(Vector128s<double>.Demo, Vector128s<double>.V2));

            // MinNumberAcross(Vector128<Single>)	float32_t vminnmvq_f32 (float32x4_t a); A64: FMINNMV Sd, Vn.4S
            WriteLine(writer, indent, "MinAcross(Vector128s<float>.Serial):\t{0}", AdvSimd.Arm64.MinAcross(Vector128s<float>.Serial));

            // MinNumberPairwise(Vector128<Double>, Vector128<Double>)	float64x2_t vpminnmq_f64 (float64x2_t a, float64x2_t b); A64: FMINNMP Vd.2D, Vn.2D, Vm.2D
            // MinNumberPairwise(Vector128<Single>, Vector128<Single>)	float32x4_t vpminnmq_f32 (float32x4_t a, float32x4_t b); A64: FMINNMP Vd.4S, Vn.4S, Vm.4S
            // MinNumberPairwise(Vector64<Single>, Vector64<Single>)	float32x2_t vpminnm_f32 (float32x2_t a, float32x2_t b); A64: FMINNMP Vd.2S, Vn.2S, Vm.2S
            WriteLine(writer, indent, "MinNumberPairwise(Vector128s<float>.Serial, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.MinNumberPairwise(Vector128s<float>.Serial, Vector128s<float>.V2));
            WriteLine(writer, indent, "MinNumberPairwise(Vector128s<double>.Serial, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.MinNumberPairwise(Vector128s<double>.Serial, Vector128s<double>.V2));

            // MinNumberPairwiseScalar(Vector128<Double>)	float64_t vpminnmqd_f64 (float64x2_t a); A64: FMINNMP Dd, Vn.2D
            // MinNumberPairwiseScalar(Vector64<Single>)	float32_t vpminnms_f32 (float32x2_t a); A64: FMINNMP Sd, Vn.2S
            WriteLine(writer, indent, "MinNumberPairwiseScalar(Vector64s<float>.Serial):\t{0}", AdvSimd.Arm64.MinNumberPairwiseScalar(Vector64s<float>.Serial));
            WriteLine(writer, indent, "MinNumberPairwiseScalar(Vector128s<double>.Serial):\t{0}", AdvSimd.Arm64.MinNumberPairwiseScalar(Vector128s<double>.Serial));

            // 饱和指令, vpmin -> r0 = a0 >= a1 ? a1 : a0, ..., r4 = b0 >= b1 ? b1 : b0, ...; 
            // compares adjacent pairs of elements, and copies the smaller of each pair into the destination vector.
            // The minimums from each pair of the first input vector are stored in the lower half of the destination vector.
            // The minimums from each pair of the second input vector are stored in the higher half of the destination vector.
            // 比较相邻的元素对，并将每对中较小的元素复制到目标向量中。
            // 第一个输入向量的每对的最小值存储在目标向量的下半部分。
            // 来自第二个输入向量的每对的最小值存储在目标向量的上半部分。
            // MinPairwise(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vpminq_u8 (uint8x16_t a, uint8x16_t b); A64: UMINP Vd.16B, Vn.16B, Vm.16B
            // MinPairwise(Vector128<Double>, Vector128<Double>)	float64x2_t vpminq_f64 (float64x2_t a, float64x2_t b); A64: FMINP Vd.2D, Vn.2D, Vm.2D
            // MinPairwise(Vector128<Int16>, Vector128<Int16>)	int16x8_t vpminq_s16 (int16x8_t a, int16x8_t b); A64: SMINP Vd.8H, Vn.8H, Vm.8H
            // MinPairwise(Vector128<Int32>, Vector128<Int32>)	int32x4_t vpminq_s32 (int32x4_t a, int32x4_t b); A64: SMINP Vd.4S, Vn.4S, Vm.4S
            // MinPairwise(Vector128<SByte>, Vector128<SByte>)	int8x16_t vpminq_s8 (int8x16_t a, int8x16_t b); A64: SMINP Vd.16B, Vn.16B, Vm.16B
            // MinPairwise(Vector128<Single>, Vector128<Single>)	float32x4_t vpminq_f32 (float32x4_t a, float32x4_t b); A64: FMINP Vd.4S, Vn.4S, Vm.4S
            // MinPairwise(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vpminq_u16 (uint16x8_t a, uint16x8_t b); A64: UMINP Vd.8H, Vn.8H, Vm.8H
            // MinPairwise(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vpminq_u32 (uint32x4_t a, uint32x4_t b); A64: UMINP Vd.4S, Vn.4S, Vm.4S
            // MinPairwiseScalar(Vector128<Double>)	float64_t vpminqd_f64 (float64x2_t a); A64: FMINP Dd, Vn.2D
            // MinPairwiseScalar(Vector64<Single>)	float32_t vpmins_f32 (float32x2_t a); A64: FMINP Sd, Vn.2S
            WriteLine(writer, indent, "MinPairwise(Vector128s<sbyte>.Serial, Vector128s<sbyte>.V2):\t{0}", AdvSimd.Arm64.MinPairwise(Vector128s<sbyte>.Serial, Vector128s<sbyte>.V2));
            WriteLine(writer, indent, "MinPairwise(Vector128s<byte>.Serial, Vector128s<byte>.V2):\t{0}", AdvSimd.Arm64.MinPairwise(Vector128s<byte>.Serial, Vector128s<byte>.V2));
            WriteLine(writer, indent, "MinPairwise(Vector128s<short>.Serial, Vector128s<short>.V2):\t{0}", AdvSimd.Arm64.MinPairwise(Vector128s<short>.Serial, Vector128s<short>.V2));
            WriteLine(writer, indent, "MinPairwise(Vector128s<ushort>.Serial, Vector128s<ushort>.V2):\t{0}", AdvSimd.Arm64.MinPairwise(Vector128s<ushort>.Serial, Vector128s<ushort>.V2));
            WriteLine(writer, indent, "MinPairwise(Vector128s<int>.Serial, Vector128s<int>.V2):\t{0}", AdvSimd.Arm64.MinPairwise(Vector128s<int>.Serial, Vector128s<int>.V2));
            WriteLine(writer, indent, "MinPairwise(Vector128s<uint>.Serial, Vector128s<uint>.V2):\t{0}", AdvSimd.Arm64.MinPairwise(Vector128s<uint>.Serial, Vector128s<uint>.V2));
            WriteLine(writer, indent, "MinPairwise(Vector128s<float>.Serial, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.MinPairwise(Vector128s<float>.Serial, Vector128s<float>.V2));
            WriteLine(writer, indent, "MinPairwiseScalar(Vector128s<double>.Serial):\t{0}", AdvSimd.Arm64.MinPairwiseScalar(Vector128s<double>.Serial));

            // MinScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vmin_f64 (float64x1_t a, float64x1_t b); A64: FMIN Dd, Dn, Dm
            // MinScalar(Vector64<Single>, Vector64<Single>)	float32_t vmins_f32 (float32_t a, float32_t b); A64: FMIN Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            WriteLine(writer, indent, "MinScalar(Vector64s<float>.Serial, Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.MinScalar(Vector64s<float>.Serial, Vector64s<float>.V2));
            WriteLine(writer, indent, "MinScalar(Vector64s<double>.Serial, Vector64s<double>.V2):\t{0}", AdvSimd.Arm64.MinScalar(Vector64s<double>.Serial, Vector64s<double>.V2));

            // 1、Vector multiply(正常指令): vmul -> ri = ai * bi;
            // Multiply(Vector128<Double>, Vector128<Double>)	float64x2_t vmulq_f64 (float64x2_t a, float64x2_t b); A64: FMUL Vd.2D, Vn.2D, Vm.2D
            WriteLine(writer, indent, "Multiply(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Multiply(Vector128s<double>.Demo, Vector128s<double>.V2));

            // 1、Vector multiply by scalar: vmul -> ri = ai * b;  
            // multiplies each element in a vector by a scalar, and places the results in the destination vector.
            // 将向量中的每个元素乘以一个标量，并将结果放在目标向量中。
            // MultiplyByScalar(Vector128<Double>, Vector64<Double>)	float64x2_t vmulq_n_f64 (float64x2_t a, float64_t b); A64: FMUL Vd.2D, Vn.2D, Vm.D[0]
            WriteLine(writer, indent, "MultiplyByScalar(Vector128s<double>.Demo, Vector64s<double>.V2):\t{0}", AdvSimd.Arm64.MultiplyByScalar(Vector128s<double>.Demo, Vector64s<double>.V2));

            // 2、Vector multiply by scalar: -> ri = ai * b[c];  
            // multiplies the first vector by a scalar.  
            // The scalar is the element in the second vector with index c.
            // 将第一个向量乘以一个标量。
            // 标量是第二个向量中下标为c的元素。
            // MultiplyBySelectedScalar(Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vmulq_laneq_f64 (float64x2_t a, float64x2_t v, const int lane); A64: FMUL Vd.2D, Vn.2D, Vm.D[lane]
            try {
                for (byte i = 0; i <= 1; ++i) {
                    WriteLine(writer, indent, "MultiplyBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // MultiplyDoublingSaturateHighScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqdmulhh_s16 (int16_t a, int16_t b) A64: SQDMULH Hd, Hn, Hm
            // MultiplyDoublingSaturateHighScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqdmulhs_s32 (int32_t a, int32_t b) A64: SQDMULH Sd, Sn, Sm
            WriteLine(writer, indent, "MultiplyDoublingSaturateHighScalar(Vector64s<short>.Demo, Vector64s<short>.V2):\t{0}", AdvSimd.Arm64.MultiplyDoublingSaturateHighScalar(Vector64s<short>.Demo, Vector64s<short>.V2));
            WriteLine(writer, indent, "MultiplyDoublingSaturateHighScalar(Vector64s<int>.Demo, Vector64s<int>.V2):\t{0}", AdvSimd.Arm64.MultiplyDoublingSaturateHighScalar(Vector64s<int>.Demo, Vector64s<int>.V2));

            // MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int16>, Vector128<Int16>, Byte)	int16_t vqdmulhh_laneq_s16 (int16_t a, int16x8_t v, const int lane) A64: SQDMULH Hd, Hn, Vm.H[lane]
            // MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int16>, Vector64<Int16>, Byte)	int16_t vqdmulhh_lane_s16 (int16_t a, int16x4_t v, const int lane) A64: SQDMULH Hd, Hn, Vm.H[lane]
            // MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int32>, Vector128<Int32>, Byte)	int32_t vqdmulhs_laneq_s32 (int32_t a, int32x4_t v, const int lane) A64: SQDMULH Sd, Sn, Vm.S[lane]
            // MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int32>, Vector64<Int32>, Byte)	int32_t vqdmulhs_lane_s32 (int32_t a, int32x2_t v, const int lane) A64: SQDMULH Sd, Sn, Vm.S[lane]
            try {
                for (byte i = 0; i <= 7; ++i) {
                    WriteLine(writer, indent, "MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64s<short>.Demo, Vector128s<short>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64s<short>.Demo, Vector128s<short>.Serial, i), i);
                }
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64s<int>.Demo, Vector128s<int>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64s<int>.Demo, Vector128s<int>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // MultiplyDoublingWideningAndAddSaturateScalar(Vector64<Int32>, Vector64<Int16>, Vector64<Int16>)	int32_t vqdmlalh_s16 (int32_t a, int16_t b, int16_t c) A64: SQDMLAL Sd, Hn, Hm
            // MultiplyDoublingWideningAndAddSaturateScalar(Vector64<Int64>, Vector64<Int32>, Vector64<Int32>)	int64_t vqdmlals_s32 (int64_t a, int32_t b, int32_t c) A64: SQDMLAL Dd, Sn, Sm
            WriteLine(writer, indent, "MultiplyDoublingWideningAndAddSaturateScalar(Vector64s<int>.V4, Vector64s<short>.Demo, Vector64s<short>.V2):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningAndAddSaturateScalar(Vector64s<int>.V4, Vector64s<short>.Demo, Vector64s<short>.V2));
            WriteLine(writer, indent, "MultiplyDoublingWideningAndAddSaturateScalar(Vector64s<long>.V4, Vector64s<int>.Demo, Vector64s<int>.V2):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningAndAddSaturateScalar(Vector64s<long>.V4, Vector64s<int>.Demo, Vector64s<int>.V2));

            // MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64<Int32>, Vector64<Int16>, Vector64<Int16>)	int32_t vqdmlslh_s16 (int32_t a, int16_t b, int16_t c) A64: SQDMLSL Sd, Hn, Hm
            // MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64<Int64>, Vector64<Int32>, Vector64<Int32>)	int64_t vqdmlsls_s32 (int64_t a, int32_t b, int32_t c) A64: SQDMLSL Dd, Sn, Sm
            WriteLine(writer, indent, "MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64s<int>.V4, Vector64s<short>.Demo, Vector64s<short>.V2):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64s<int>.V4, Vector64s<short>.Demo, Vector64s<short>.V2));
            WriteLine(writer, indent, "MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64s<long>.V4, Vector64s<int>.Demo, Vector64s<int>.V2):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64s<long>.V4, Vector64s<int>.Demo, Vector64s<int>.V2));

            // MultiplyDoublingWideningSaturateScalar(Vector64<Int16>, Vector64<Int16>)	int32_t vqdmullh_s16 (int16_t a, int16_t b) A64: SQDMULL Sd, Hn, Hm
            // MultiplyDoublingWideningSaturateScalar(Vector64<Int32>, Vector64<Int32>)	int64_t vqdmulls_s32 (int32_t a, int32_t b) A64: SQDMULL Dd, Sn, Sm
            WriteLine(writer, indent, "MultiplyDoublingWideningSaturateScalar(Vector64s<short>.Demo, Vector64s<short>.V2):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningSaturateScalar(Vector64s<short>.Demo, Vector64s<short>.V2));
            WriteLine(writer, indent, "MultiplyDoublingWideningSaturateScalar(Vector64s<int>.Demo, Vector64s<int>.V2):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningSaturateScalar(Vector64s<int>.Demo, Vector64s<int>.V2));

            // MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<Int16>, Vector128<Int16>, Byte)	int32_t vqdmullh_laneq_s16 (int16_t a, int16x8_t v, const int lane) A64: SQDMULL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<Int16>, Vector64<Int16>, Byte)	int32_t vqdmullh_lane_s16 (int16_t a, int16x4_t v, const int lane) A64: SQDMULL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<Int32>, Vector128<Int32>, Byte)	int64_t vqdmulls_laneq_s32 (int32_t a, int32x4_t v, const int lane) A64: SQDMULL Dd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<Int32>, Vector64<Int32>, Byte)	int64_t vqdmulls_lane_s32 (int32_t a, int32x2_t v, const int lane) A64: SQDMULL Dd, Sn, Vm.S[lane]
            try {
                for (byte i = 0; i <= 7; ++i) {
                    WriteLine(writer, indent, "MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64s<short>.Demo, Vector128s<short>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64s<short>.Demo, Vector128s<short>.Serial, i), i);
                }
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64s<int>.Demo, Vector128s<int>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64s<int>.Demo, Vector128s<int>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<Int32>, Vector64<Int16>, Vector128<Int16>, Byte)	int32_t vqdmlalh_laneq_s16 (int32_t a, int16_t b, int16x8_t v, const int lane) A64: SQDMLAL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<Int32>, Vector64<Int16>, Vector64<Int16>, Byte)	int32_t vqdmlalh_lane_s16 (int32_t a, int16_t b, int16x4_t v, const int lane) A64: SQDMLAL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<Int64>, Vector64<Int32>, Vector128<Int32>, Byte)	int64_t vqdmlals_laneq_s32 (int64_t a, int32_t b, int32x4_t v, const int lane) A64: SQDMLAL Dd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<Int64>, Vector64<Int32>, Vector64<Int32>, Byte)	int64_t vqdmlals_lane_s32 (int64_t a, int32_t b, int32x2_t v, const int lane) A64: SQDMLAL Dd, Sn, Vm.S[lane]
            try {
                for (byte i = 0; i <= 7; ++i) {
                    WriteLine(writer, indent, "MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64s<int>.V4, Vector64s<short>.Demo, Vector128s<short>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64s<int>.V4, Vector64s<short>.Demo, Vector128s<short>.Serial, i), i);
                }
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64s<long>.V4, Vector64s<int>.Demo, Vector128s<int>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64s<long>.V4, Vector64s<int>.Demo, Vector128s<int>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<Int32>, Vector64<Int16>, Vector128<Int16>, Byte)	int32_t vqdmlslh_laneq_s16 (int32_t a, int16_t b, int16x8_t v, const int lane) A64: SQDMLSL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<Int32>, Vector64<Int16>, Vector64<Int16>, Byte)	int32_t vqdmlslh_lane_s16 (int32_t a, int16_t b, int16x4_t v, const int lane) A64: SQDMLSL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<Int64>, Vector64<Int32>, Vector128<Int32>, Byte)	int64_t vqdmlsls_laneq_s32 (int64_t a, int32_t b, int32x4_t v, const int lane) A64: SQDMLSL Dd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<Int64>, Vector64<Int32>, Vector64<Int32>, Byte)	int64_t vqdmlsls_lane_s32 (int64_t a, int32_t b, int32x2_t v, const int lane) A64: SQDMLSL Dd, Sn, Vm.S[lane]
            try {
                for (byte i = 0; i <= 7; ++i) {
                    WriteLine(writer, indent, "MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64s<int>.V4, Vector64s<short>.Demo, Vector128s<short>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64s<int>.V4, Vector64s<short>.Demo, Vector128s<short>.Serial, i), i);
                }
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64s<long>.V4, Vector64s<int>.Demo, Vector128s<int>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64s<long>.V4, Vector64s<int>.Demo, Vector128s<int>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // Floating-point Multiply extended. This instruction multiplies corresponding floating-point values in the vectors of the two source SIMD&FP registers, places the resulting floating-point values in a vector, and writes the vector to the destination SIMD&FP register.
            // 浮点乘法扩展。这条指令将两个源SIMD&FP寄存器的向量中对应的浮点值相乘，将结果浮点值放入一个向量中，并将该向量写入目标SIMD&FP寄存器。
            // for e = 0 to elements-1
            //     element1 = Elem[operand1, e, esize];
            //     element2 = Elem[operand2, e, esize];
            //     Elem[result, e, esize] = FPMulX(element1, element2, fpcr);
            // MultiplyExtended(Vector128<Double>, Vector128<Double>)	float64x2_t vmulxq_f64 (float64x2_t a, float64x2_t b); A64: FMULX Vd.2D, Vn.2D, Vm.2D
            // MultiplyExtended(Vector128<Single>, Vector128<Single>)	float32x4_t vmulxq_f32 (float32x4_t a, float32x4_t b); A64: FMULX Vd.4S, Vn.4S, Vm.4S
            // MultiplyExtended(Vector64<Single>, Vector64<Single>)	float32x2_t vmulx_f32 (float32x2_t a, float32x2_t b); A64: FMULX Vd.2S, Vn.2S, Vm.2S
            // MultiplyExtendedByScalar(Vector128<Double>, Vector64<Double>)	float64x2_t vmulxq_lane_f64 (float64x2_t a, float64x1_t v, const int lane); A64: FMULX Vd.2D, Vn.2D, Vm.D[0]
            WriteLine(writer, indent, "MultiplyExtended(Vector128s<float>.Demo, Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.MultiplyExtended(Vector128s<float>.Demo, Vector128s<float>.V2));
            WriteLine(writer, indent, "MultiplyExtended(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.MultiplyExtended(Vector128s<double>.Demo, Vector128s<double>.V2));

            // MultiplyExtendedBySelectedScalar(Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vmulxq_laneq_f64 (float64x2_t a, float64x2_t v, const int lane); A64: FMULX Vd.2D, Vn.2D, Vm.D[lane]
            // MultiplyExtendedBySelectedScalar(Vector128<Single>, Vector128<Single>, Byte)	float32x4_t vmulxq_laneq_f32 (float32x4_t a, float32x4_t v, const int lane); A64: FMULX Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyExtendedBySelectedScalar(Vector128<Single>, Vector64<Single>, Byte)	float32x4_t vmulxq_lane_f32 (float32x4_t a, float32x2_t v, const int lane); A64: FMULX Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyExtendedBySelectedScalar(Vector64<Single>, Vector128<Single>, Byte)	float32x2_t vmulx_laneq_f32 (float32x2_t a, float32x4_t v, const int lane); A64: FMULX Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyExtendedBySelectedScalar(Vector64<Single>, Vector64<Single>, Byte)	float32x2_t vmulx_lane_f32 (float32x2_t a, float32x2_t v, const int lane); A64: FMULX Vd.2S, Vn.2S, Vm.S[lane]
            try {
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "MultiplyExtendedBySelectedScalar(Vector128s<float>.Demo, Vector128s<float>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyExtendedBySelectedScalar(Vector128s<float>.Demo, Vector128s<float>.Serial, i), i);
                }
                for (byte i = 0; i <= 1; ++i) {
                    WriteLine(writer, indent, "MultiplyExtendedBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyExtendedBySelectedScalar(Vector128s<double>.Demo, Vector128s<double>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // MultiplyExtendedScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vmulx_f64 (float64x1_t a, float64x1_t b); A64: FMULX Dd, Dn, Dm
            // MultiplyExtendedScalar(Vector64<Single>, Vector64<Single>)	float32_t vmulxs_f32 (float32_t a, float32_t b); A64: FMULX Sd, Sn, Sm
            WriteLine(writer, indent, "MultiplyExtendedScalar(Vector64s<float>.Demo, Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.MultiplyExtendedScalar(Vector64s<float>.Demo, Vector64s<float>.V2));
            WriteLine(writer, indent, "MultiplyExtendedScalar(Vector64s<double>.Demo, Vector64s<double>.V2):\t{0}", AdvSimd.Arm64.MultiplyExtendedScalar(Vector64s<double>.Demo, Vector64s<double>.V2));

            // MultiplyExtendedScalarBySelectedScalar(Vector64<Double>, Vector128<Double>, Byte)	float64_t vmulxd_laneq_f64 (float64_t a, float64x2_t v, const int lane); A64: FMULX Dd, Dn, Vm.D[lane]
            // MultiplyExtendedScalarBySelectedScalar(Vector64<Single>, Vector128<Single>, Byte)	float32_t vmulxs_laneq_f32 (float32_t a, float32x4_t v, const int lane); A64: FMULX Sd, Sn, Vm.S[lane]
            // MultiplyExtendedScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Byte)	float32_t vmulxs_lane_f32 (float32_t a, float32x2_t v, const int lane); A64: FMULX Sd, Sn, Vm.S[lane]
            try {
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "MultiplyExtendedScalarBySelectedScalar(Vector64s<float>.Demo, Vector128s<float>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyExtendedScalarBySelectedScalar(Vector64s<float>.Demo, Vector128s<float>.Serial, i), i);
                }
                for (byte i = 0; i <= 1; ++i) {
                    WriteLine(writer, indent, "MultiplyExtendedScalarBySelectedScalar(Vector64s<double>.Demo, Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyExtendedScalarBySelectedScalar(Vector64s<double>.Demo, Vector128s<double>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // MultiplyRoundedDoublingSaturateHighScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqrdmulhh_s16 (int16_t a, int16_t b) A64: SQRDMULH Hd, Hn, Hm
            // MultiplyRoundedDoublingSaturateHighScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqrdmulhs_s32 (int32_t a, int32_t b) A64: SQRDMULH Sd, Sn, Sm
            WriteLine(writer, indent, "MultiplyRoundedDoublingSaturateHighScalar(Vector64s<short>.Demo, Vector64s<short>.V2):\t{0}", AdvSimd.Arm64.MultiplyRoundedDoublingSaturateHighScalar(Vector64s<short>.Demo, Vector64s<short>.V2));
            WriteLine(writer, indent, "MultiplyRoundedDoublingSaturateHighScalar(Vector64s<int>.Demo, Vector64s<int>.V2):\t{0}", AdvSimd.Arm64.MultiplyRoundedDoublingSaturateHighScalar(Vector64s<int>.Demo, Vector64s<int>.V2));

            // MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int16>, Vector128<Int16>, Byte)	int16_t vqrdmulhh_laneq_s16 (int16_t a, int16x8_t v, const int lane) A64: SQRDMULH Hd, Hn, Vm.H[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int16>, Vector64<Int16>, Byte)	int16_t vqrdmulhh_lane_s16 (int16_t a, int16x4_t v, const int lane) A64: SQRDMULH Hd, Hn, Vm.H[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int32>, Vector128<Int32>, Byte)	int32_t vqrdmulhs_laneq_s32 (int32_t a, int32x4_t v, const int lane) A64: SQRDMULH Sd, Sn, Vm.S[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int32>, Vector64<Int32>, Byte)	int32_t vqrdmulhs_lane_s32 (int32_t a, int32x2_t v, const int lane) A64: SQRDMULH Sd, Sn, Vm.S[lane]
            try {
                for (byte i = 0; i <= 7; ++i) {
                    WriteLine(writer, indent, "MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64s<short>.Demo, Vector128s<short>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64s<short>.Demo, Vector128s<short>.Serial, i), i);
                }
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indent, "MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64s<int>.Demo, Vector128s<int>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64s<int>.Demo, Vector128s<int>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // MultiplyScalarBySelectedScalar(Vector64<Double>, Vector128<Double>, Byte)	float64_t vmuld_laneq_f64 (float64_t a, float64x2_t v, const int lane); A64: FMUL Dd, Dn, Vm.D[lane]
            try {
                for (byte i = 0; i <= 1; ++i) {
                    WriteLine(writer, indent, "MultiplyScalarBySelectedScalar(Vector64s<double>.Demo, Vector128s<double>.Serial, {1}):\t{0}", AdvSimd.Arm64.MultiplyScalarBySelectedScalar(Vector64s<double>.Demo, Vector128s<double>.Serial, i), i);
                }
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }
        }
        public unsafe static void RunArm_AdvSimd_64_N(TextWriter writer, string indent) {
            // 1、Negate(正常指令): vneg -> ri = -ai; negates each element in a vector.
            // Negate(Vector128<Double>)	float64x2_t vnegq_f64 (float64x2_t a); A64: FNEG Vd.2D, Vn.2D
            // Negate(Vector128<Int64>)	int64x2_t vnegq_s64 (int64x2_t a); A64: NEG Vd.2D, Vn.2D
            WriteLine(writer, indent, "Negate(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.Negate(Vector128s<double>.Demo));
            WriteLine(writer, indent, "Negate(Vector128s<long>.Demo):\t{0}", AdvSimd.Arm64.Negate(Vector128s<long>.Demo));

            // 2、Saturating Negate: vqneg -> ri = sat(-ai); 
            // negates each element in a vector. If any of the results overflow, they are saturated and the sticky QC flag is set.
            // 对向量中的每个元素求反。如果任何结果溢出，它们将被饱和，并设置粘性QC标志。
            // NegateSaturate(Vector128<Int64>)	int64x2_t vqnegq_s64 (int64x2_t a); A64: SQNEG Vd.2D, Vn.2D
            WriteLine(writer, indent, "NegateSaturate(Vector128s<long>.Demo):\t{0}", AdvSimd.Arm64.NegateSaturate(Vector128s<long>.Demo));

            // NegateSaturateScalar(Vector64<Int16>)	int16_t vqnegh_s16 (int16_t a); A64: SQNEG Hd, Hn
            // NegateSaturateScalar(Vector64<Int32>)	int32_t vqnegs_s32 (int32_t a); A64: SQNEG Sd, Sn
            // NegateSaturateScalar(Vector64<Int64>)	int64_t vqnegd_s64 (int64_t a); A64: SQNEG Dd, Dn
            // NegateSaturateScalar(Vector64<SByte>)	int8_t vqnegb_s8 (int8_t a); A64: SQNEG Bd, Bn
            WriteLine(writer, indent, "NegateSaturateScalar(Vector64s<sbyte>.Demo):\t{0}", AdvSimd.Arm64.NegateSaturateScalar(Vector64s<sbyte>.Demo));
            WriteLine(writer, indent, "NegateSaturateScalar(Vector64s<short>.Demo):\t{0}", AdvSimd.Arm64.NegateSaturateScalar(Vector64s<short>.Demo));
            WriteLine(writer, indent, "NegateSaturateScalar(Vector64s<int>.Demo):\t{0}", AdvSimd.Arm64.NegateSaturateScalar(Vector64s<int>.Demo));
            WriteLine(writer, indent, "NegateSaturateScalar(Vector64s<long>.Demo):\t{0}", AdvSimd.Arm64.NegateSaturateScalar(Vector64s<long>.Demo));

            // NegateScalar(Vector64<Int64>)	int64x1_t vneg_s64 (int64x1_t a); A64: NEG Dd, Dn
            WriteLine(writer, indent, "NegateScalar(Vector64s<long>.Demo):\t{0}", AdvSimd.Arm64.NegateScalar(Vector64s<long>.Demo));
        }
        public unsafe static void RunArm_AdvSimd_64_R(TextWriter writer, string indent) {
            // 正常指令, vrecpe -> ; 
            // finds an approximate reciprocal of each element in a vector, and places it in the result vector.
            // 查找向量中每个元素的近似倒数，并将其放入结果向量中。
            // ReciprocalEstimate(Vector128<Double>)	float64x2_t vrecpeq_f64 (float64x2_t a); A64: FRECPE Vd.2D, Vn.2D
            // ReciprocalEstimateScalar(Vector64<Double>)	float64x1_t vrecpe_f64 (float64x1_t a); A64: FRECPE Dd, Dn
            // ReciprocalEstimateScalar(Vector64<Single>)	float32_t vrecpes_f32 (float32_t a); A64: FRECPE Sd, Sn
            WriteLine(writer, indent, "ReciprocalEstimate(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ReciprocalEstimate(Vector128s<double>.Demo));
            WriteLine(writer, indent, "ReciprocalEstimateScalar(Vector64s<float>.Demo):\t{0}", AdvSimd.Arm64.ReciprocalEstimateScalar(Vector64s<float>.Demo));

            // Floating-point Reciprocal exponent (scalar). This instruction finds an approximate reciprocal exponent for each vector element in the source SIMD&FP register, places the result in a vector, and writes the vector to the destination SIMD&FP register.
            // 浮点倒数指数(标量)。这条指令为源SIMD&FP寄存器中的每个向量元素找到一个近似的倒数指数，将结果放入一个向量中，并将该向量写入目标SIMD&FP寄存器。
            // for e = 0 to elements-1
            //     element = Elem[operand, e, esize];
            //     Elem[result, e, esize] = FPRecpX(element, fpcr);
            // ReciprocalExponentScalar(Vector64<Double>)	float64_t vrecpxd_f64 (float64_t a); A64: FRECPX Dd, Dn
            // ReciprocalExponentScalar(Vector64<Single>)	float32_t vrecpxs_f32 (float32_t a); A64: FRECPX Sd, Sn
            WriteLine(writer, indent, "ReciprocalExponentScalar(Vector64s<float>.Demo):\t{0}", AdvSimd.Arm64.ReciprocalExponentScalar(Vector64s<float>.Demo));
            WriteLine(writer, indent, "ReciprocalExponentScalar(Vector64s<float>.Demo):\t{0}", AdvSimd.Arm64.ReciprocalExponentScalar(Vector64s<float>.Demo));

            // 正常指令, vrsqrte -> ; 
            // finds an approximate reciprocal square root of each element in a vector, and places it in the return vector.
            // 找出向量中每个元素的近似倒数平方根，并将其放入返回向量中。
            // ReciprocalSquareRootEstimate(Vector128<Double>)	float64x2_t vrsqrteq_f64 (float64x2_t a); A64: FRSQRTE Vd.2D, Vn.2D
            // ReciprocalSquareRootEstimateScalar(Vector64<Double>)	float64x1_t vrsqrte_f64 (float64x1_t a); A64: FRSQRTE Dd, Dn
            // ReciprocalSquareRootEstimateScalar(Vector64<Single>)	float32_t vrsqrtes_f32 (float32_t a); A64: FRSQRTE Sd, Sn
            WriteLine(writer, indent, "ReciprocalSquareRootEstimate(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.ReciprocalSquareRootEstimate(Vector128s<double>.Demo));
            WriteLine(writer, indent, "ReciprocalSquareRootEstimateScalar(Vector64s<float>.Demo):\t{0}", AdvSimd.Arm64.ReciprocalSquareRootEstimateScalar(Vector64s<float>.Demo));

            // 2、饱和指令,
            // performs a Newton-Raphson step for finding the reciprocal square root.  
            // It multiplies the elements of one vector by the corresponding elements of another vector, subtracts each of the results from 3, divides these results by two, and places the final results into the elements of the destination vector
            // 执行牛顿-拉弗森步骤来寻找平方根的倒数。
            // 它将一个向量的元素与另一个向量的相应元素相乘，将每个结果从3中减去，将这些结果除以2，并将最终结果放入目标向量的元素中
            // ReciprocalSquareRootStep(Vector128<Double>, Vector128<Double>)	float64x2_t vrsqrtsq_f64 (float64x2_t a, float64x2_t b); A64: FRSQRTS Vd.2D, Vn.2D, Vm.2D
            // ReciprocalSquareRootStepScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vrsqrts_f64 (float64x1_t a, float64x1_t b); A64: FRSQRTS Dd, Dn, Dm
            // ReciprocalSquareRootStepScalar(Vector64<Single>, Vector64<Single>)	float32_t vrsqrtss_f32 (float32_t a, float32_t b); A64: FRSQRTS Sd, Sn, Sm
            WriteLine(writer, indent, "ReciprocalSquareRootStep(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.ReciprocalSquareRootStep(Vector128s<double>.Demo, Vector128s<double>.V2));
            WriteLine(writer, indent, "ReciprocalSquareRootStepScalar(Vector64s<double>.Demo, Vector64s<double>.V2):\t{0}", AdvSimd.Arm64.ReciprocalSquareRootStepScalar(Vector64s<double>.Demo, Vector64s<double>.V2));
            WriteLine(writer, indent, "ReciprocalSquareRootStepScalar(Vector64s<float>.Demo, Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.ReciprocalSquareRootStepScalar(Vector64s<float>.Demo, Vector64s<float>.V2));

            // 1、饱和指令, Newton-Raphson iteration(牛顿 - 拉夫逊迭代) 
            // performs a Newton-Raphson step for finding the reciprocal. It multiplies the elements of one vector by the corresponding elements of another vector, subtracts each of the results from 2, and places the final results into the elements of the destination vector
            // 执行牛顿-拉弗森步骤求倒数。它将一个向量的元素与另一个向量的相应元素相乘，每个结果从2中减去，并将最终结果放入目标向量的元素中
            // ReciprocalStep(Vector128<Double>, Vector128<Double>)	float64x2_t vrecpsq_f64 (float64x2_t a, float64x2_t b); A64: FRECPS Vd.2D, Vn.2D, Vm.2D
            // ReciprocalStepScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vrecps_f64 (float64x1_t a, float64x1_t b); A64: FRECPS Dd, Dn, Dm
            // ReciprocalStepScalar(Vector64<Single>, Vector64<Single>)	float32_t vrecpss_f32 (float32_t a, float32_t b); A64: FRECPS Sd, Sn, Sm
            WriteLine(writer, indent, "ReciprocalStep(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.ReciprocalStep(Vector128s<double>.Demo, Vector128s<double>.V2));
            WriteLine(writer, indent, "ReciprocalStepScalar(Vector64s<double>.Demo, Vector64s<double>.V2):\t{0}", AdvSimd.Arm64.ReciprocalStepScalar(Vector64s<double>.Demo, Vector64s<double>.V2));
            WriteLine(writer, indent, "ReciprocalStepScalar(Vector64s<float>.Demo, Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.ReciprocalStepScalar(Vector64s<float>.Demo, Vector64s<float>.V2));

            // Reverse Bit order (vector). This instruction reads each vector element from the source SIMD&FP register, reverses the bits of the element, places the results into a vector, and writes the vector to the destination SIMD&FP register.
            // 反向位序(向量)。这条指令从源SIMD&FP寄存器读取每个vector元素，反转元素的位，将结果放入一个向量，并将该向量写入目标SIMD&FP寄存器。
            // ReverseElementBits(Vector128<Byte>)	uint8x16_t vrbitq_u8 (uint8x16_t a); A64: RBIT Vd.16B, Vn.16B
            // ReverseElementBits(Vector128<SByte>)	int8x16_t vrbitq_s8 (int8x16_t a); A64: RBIT Vd.16B, Vn.16B
            // ReverseElementBits(Vector64<Byte>)	uint8x8_t vrbit_u8 (uint8x8_t a); A64: RBIT Vd.8B, Vn.8B
            // ReverseElementBits(Vector64<SByte>)	int8x8_t vrbit_s8 (int8x8_t a); A64: RBIT Vd.8B, Vn.8B
            WriteLine(writer, indent, "ReverseElementBits(Vector128s<sbyte>.Demo):\t{0}", AdvSimd.Arm64.ReverseElementBits(Vector128s<sbyte>.Demo));
            WriteLine(writer, indent, "ReverseElementBits(Vector128s<byte>.Demo):\t{0}", AdvSimd.Arm64.ReverseElementBits(Vector128s<byte>.Demo));

            // 2、to nearest, ties away from zero
            // RoundAwayFromZero(Vector128<Double>)	float64x2_t vrndaq_f64 (float64x2_t a); A64: FRINTA Vd.2D, Vn.2D
            WriteLine(writer, indent, "RoundAwayFromZero(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.RoundAwayFromZero(Vector128s<double>.Demo));

            // 1、to nearest, ties to even
            // RoundToNearest(Vector128<Double>)	float64x2_t vrndnq_f64 (float64x2_t a); A64: FRINTN Vd.2D, Vn.2D
            WriteLine(writer, indent, "RoundToNearest(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.RoundToNearest(Vector128s<double>.Demo));

            // 4、towards -Inf
            // RoundToNegativeInfinity(Vector128<Double>)	float64x2_t vrndmq_f64 (float64x2_t a); A64: FRINTM Vd.2D, Vn.2D
            WriteLine(writer, indent, "RoundToNegativeInfinity(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.RoundToNegativeInfinity(Vector128s<double>.Demo));

            // 3、towards +Inf
            // RoundToPositiveInfinity(Vector128<Double>)	float64x2_t vrndpq_f64 (float64x2_t a); A64: FRINTP Vd.2D, Vn.2D
            WriteLine(writer, indent, "RoundToPositiveInfinity(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.RoundToPositiveInfinity(Vector128s<double>.Demo));

            // 5、towards 0
            // RoundToZero(Vector128<Double>)	float64x2_t vrndq_f64 (float64x2_t a); A64: FRINTZ Vd.2D, Vn.2D
            WriteLine(writer, indent, "RoundToZero(Vector128s<double>.Demo):\t{0}", AdvSimd.Arm64.RoundToZero(Vector128s<double>.Demo));

        }
        public unsafe static void RunArm_AdvSimd_64_S(TextWriter writer, string indent) {
            string indentNext = indent + IndentNextSeparator;
            unchecked {
                // ShiftArithmeticRoundedSaturateScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqrshlh_s16 (int16_t a, int16_t b); A64: SQRSHL Hd, Hn, Hm
                // ShiftArithmeticRoundedSaturateScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqrshls_s32 (int32_t a, int32_t b); A64: SQRSHL Sd, Sn, Sm
                // ShiftArithmeticRoundedSaturateScalar(Vector64<SByte>, Vector64<SByte>)	int8_t vqrshlb_s8 (int8_t a, int8_t b); A64: SQRSHL Bd, Bn, Bm
                // ShiftArithmeticSaturateScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqshlh_s16 (int16_t a, int16_t b); A64: SQSHL Hd, Hn, Hm
                // ShiftArithmeticSaturateScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqshls_s32 (int32_t a, int32_t b); A64: SQSHL Sd, Sn, Sm
                // ShiftArithmeticSaturateScalar(Vector64<SByte>, Vector64<SByte>)	int8_t vqshlb_s8 (int8_t a, int8_t b); A64: SQSHL Bd, Bn, Bm
                // ShiftLeftLogicalSaturateScalar(Vector64<Byte>, Byte)	uint8_t vqshlb_n_u8 (uint8_t a, const int n); A64: UQSHL Bd, Bn, #n
                // ShiftLeftLogicalSaturateScalar(Vector64<Int16>, Byte)	int16_t vqshlh_n_s16 (int16_t a, const int n); A64: SQSHL Hd, Hn, #n
                // ShiftLeftLogicalSaturateScalar(Vector64<Int32>, Byte)	int32_t vqshls_n_s32 (int32_t a, const int n); A64: SQSHL Sd, Sn, #n
                // ShiftLeftLogicalSaturateScalar(Vector64<SByte>, Byte)	int8_t vqshlb_n_s8 (int8_t a, const int n); A64: SQSHL Bd, Bn, #n
                // ShiftLeftLogicalSaturateScalar(Vector64<UInt16>, Byte)	uint16_t vqshlh_n_u16 (uint16_t a, const int n); A64: UQSHL Hd, Hn, #n
                // ShiftLeftLogicalSaturateScalar(Vector64<UInt32>, Byte)	uint32_t vqshls_n_u32 (uint32_t a, const int n); A64: UQSHL Sd, Sn, #n
                // ShiftLeftLogicalSaturateUnsignedScalar(Vector64<Int16>, Byte)	uint16_t vqshluh_n_s16 (int16_t a, const int n); A64: SQSHLU Hd, Hn, #n
                // ShiftLeftLogicalSaturateUnsignedScalar(Vector64<Int32>, Byte)	uint32_t vqshlus_n_s32 (int32_t a, const int n); A64: SQSHLU Sd, Sn, #n
                // ShiftLeftLogicalSaturateUnsignedScalar(Vector64<SByte>, Byte)	uint8_t vqshlub_n_s8 (int8_t a, const int n); A64: SQSHLU Bd, Bn, #n
                // ShiftLogicalRoundedSaturateScalar(Vector64<Byte>, Vector64<SByte>)	uint8_t vqrshlb_u8 (uint8_t a, int8_t b); A64: UQRSHL Bd, Bn, Bm
                // ShiftLogicalRoundedSaturateScalar(Vector64<Int16>, Vector64<Int16>)	uint16_t vqrshlh_u16 (uint16_t a, int16_t b); A64: UQRSHL Hd, Hn, Hm
                // ShiftLogicalRoundedSaturateScalar(Vector64<Int32>, Vector64<Int32>)	uint32_t vqrshls_u32 (uint32_t a, int32_t b); A64: UQRSHL Sd, Sn, Sm
                // ShiftLogicalRoundedSaturateScalar(Vector64<SByte>, Vector64<SByte>)	uint8_t vqrshlb_u8 (uint8_t a, int8_t b); A64: UQRSHL Bd, Bn, Bm
                // ShiftLogicalRoundedSaturateScalar(Vector64<UInt16>, Vector64<Int16>)	uint16_t vqrshlh_u16 (uint16_t a, int16_t b); A64: UQRSHL Hd, Hn, Hm
                // ShiftLogicalRoundedSaturateScalar(Vector64<UInt32>, Vector64<Int32>)	uint32_t vqrshls_u32 (uint32_t a, int32_t b); A64: UQRSHL Sd, Sn, Sm
                // ShiftLogicalSaturateScalar(Vector64<Byte>, Vector64<SByte>)	uint8_t vqshlb_u8 (uint8_t a, int8_t b); A64: UQSHL Bd, Bn, Bm
                // ShiftLogicalSaturateScalar(Vector64<Int16>, Vector64<Int16>)	uint16_t vqshlh_u16 (uint16_t a, int16_t b); A64: UQSHL Hd, Hn, Hm
                // ShiftLogicalSaturateScalar(Vector64<Int32>, Vector64<Int32>)	uint32_t vqshls_u32 (uint32_t a, int32_t b); A64: UQSHL Sd, Sn, Sm
                // ShiftLogicalSaturateScalar(Vector64<SByte>, Vector64<SByte>)	uint8_t vqshlb_u8 (uint8_t a, int8_t b); A64: UQSHL Bd, Bn, Bm
                // ShiftLogicalSaturateScalar(Vector64<UInt16>, Vector64<Int16>)	uint16_t vqshlh_u16 (uint16_t a, int16_t b); A64: UQSHL Hd, Hn, Hm
                // ShiftLogicalSaturateScalar(Vector64<UInt32>, Vector64<Int32>)	uint32_t vqshls_u32 (uint32_t a, int32_t b); A64: UQSHL Sd, Sn, Sm
                // ShiftRightArithmeticNarrowingSaturateScalar(Vector64<Int16>, Byte)	int8_t vqshrnh_n_s16 (int16_t a, const int n); A64: SQSHRN Bd, Hn, #n
                // ShiftRightArithmeticNarrowingSaturateScalar(Vector64<Int32>, Byte)	int16_t vqshrns_n_s32 (int32_t a, const int n); A64: SQSHRN Hd, Sn, #n
                // ShiftRightArithmeticNarrowingSaturateScalar(Vector64<Int64>, Byte)	int32_t vqshrnd_n_s64 (int64_t a, const int n); A64: SQSHRN Sd, Dn, #n
                // ShiftRightArithmeticNarrowingSaturateUnsignedScalar(Vector64<Int16>, Byte)	uint8_t vqshrunh_n_s16 (int16_t a, const int n); A64: SQSHRUN Bd, Hn, #n
                // ShiftRightArithmeticNarrowingSaturateUnsignedScalar(Vector64<Int32>, Byte)	uint16_t vqshruns_n_s32 (int32_t a, const int n); A64: SQSHRUN Hd, Sn, #n
                // ShiftRightArithmeticNarrowingSaturateUnsignedScalar(Vector64<Int64>, Byte)	uint32_t vqshrund_n_s64 (int64_t a, const int n); A64: SQSHRUN Sd, Dn, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateScalar(Vector64<Int16>, Byte)	int8_t vqrshrnh_n_s16 (int16_t a, const int n); A64: SQRSHRN Bd, Hn, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateScalar(Vector64<Int32>, Byte)	int16_t vqrshrns_n_s32 (int32_t a, const int n); A64: SQRSHRN Hd, Sn, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateScalar(Vector64<Int64>, Byte)	int32_t vqrshrnd_n_s64 (int64_t a, const int n); A64: SQRSHRN Sd, Dn, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedScalar(Vector64<Int16>, Byte)	uint8_t vqrshrunh_n_s16 (int16_t a, const int n); A64: SQRSHRUN Bd, Hn, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedScalar(Vector64<Int32>, Byte)	uint16_t vqrshruns_n_s32 (int32_t a, const int n); A64: SQRSHRUN Hd, Sn, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedScalar(Vector64<Int64>, Byte)	uint32_t vqrshrund_n_s64 (int64_t a, const int n); A64: SQRSHRUN Sd, Dn, #n
                // ShiftRightLogicalNarrowingSaturateScalar(Vector64<Int16>, Byte)	uint8_t vqshrnh_n_u16 (uint16_t a, const int n); A64: UQSHRN Bd, Hn, #n
                // ShiftRightLogicalNarrowingSaturateScalar(Vector64<Int32>, Byte)	uint16_t vqshrns_n_u32 (uint32_t a, const int n); A64: UQSHRN Hd, Sn, #n
                // ShiftRightLogicalNarrowingSaturateScalar(Vector64<Int64>, Byte)	uint32_t vqshrnd_n_u64 (uint64_t a, const int n); A64: UQSHRN Sd, Dn, #n
                // ShiftRightLogicalNarrowingSaturateScalar(Vector64<UInt16>, Byte)	uint8_t vqshrnh_n_u16 (uint16_t a, const int n); A64: UQSHRN Bd, Hn, #n
                // ShiftRightLogicalNarrowingSaturateScalar(Vector64<UInt32>, Byte)	uint16_t vqshrns_n_u32 (uint32_t a, const int n); A64: UQSHRN Hd, Sn, #n
                // ShiftRightLogicalNarrowingSaturateScalar(Vector64<UInt64>, Byte)	uint32_t vqshrnd_n_u64 (uint64_t a, const int n); A64: UQSHRN Sd, Dn, #n
                // ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<Int16>, Byte)	uint8_t vqrshrnh_n_u16 (uint16_t a, const int n); A64: UQRSHRN Bd, Hn, #n
                // ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<Int32>, Byte)	uint16_t vqrshrns_n_u32 (uint32_t a, const int n); A64: UQRSHRN Hd, Sn, #n
                // ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<Int64>, Byte)	uint32_t vqrshrnd_n_u64 (uint64_t a, const int n); A64: UQRSHRN Sd, Dn, #n
                // ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<UInt16>, Byte)	uint8_t vqrshrnh_n_u16 (uint16_t a, const int n); A64: UQRSHRN Bd, Hn, #n
                // ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<UInt32>, Byte)	uint16_t vqrshrns_n_u32 (uint32_t a, const int n); A64: UQRSHRN Hd, Sn, #n
                // ShiftRightLogicalRoundedNarrowingSaturateScalar(Vector64<UInt64>, Byte)	uint32_t vqrshrnd_n_u64 (uint64_t a, const int n); A64: UQRSHRN Sd, Dn, #n
                // Ignore

                // Sqrt(Vector128<Double>)	float64x2_t vsqrtq_f64 (float64x2_t a); A64: FSQRT Vd.2D, Vn.2D
                // Sqrt(Vector128<Single>)	float32x4_t vsqrtq_f32 (float32x4_t a); A64: FSQRT Vd.4S, Vn.4S
                // Sqrt(Vector64<Single>)	float32x2_t vsqrt_f32 (float32x2_t a); A64: FSQRT Vd.2S, Vn.2S
                WriteLine(writer, indent, "Sqrt(Vector64s<float>.V2):\t{0}", AdvSimd.Arm64.Sqrt(Vector64s<float>.V2));
                WriteLine(writer, indent, "Sqrt(Vector128s<float>.V2):\t{0}", AdvSimd.Arm64.Sqrt(Vector128s<float>.V2));
                WriteLine(writer, indent, "Sqrt(Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Sqrt(Vector128s<double>.V2));

                // 3、Store 2 vectors into memory: vst2 ->  
                // stores 2 vectors into memory. It interleaves the 2 vectors into memory.
                // void vst2_s8 (int8_t * __a, int8x8x2_t __b);
                // StorePair(Byte*, Vector128<Byte>, Vector128<Byte>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(Byte*, Vector64<Byte>, Vector64<Byte>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(Double*, Vector128<Double>, Vector128<Double>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(Double*, Vector64<Double>, Vector64<Double>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(Int16*, Vector128<Int16>, Vector128<Int16>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(Int16*, Vector64<Int16>, Vector64<Int16>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(Int32*, Vector128<Int32>, Vector128<Int32>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(Int32*, Vector64<Int32>, Vector64<Int32>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(Int64*, Vector128<Int64>, Vector128<Int64>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(Int64*, Vector64<Int64>, Vector64<Int64>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(SByte*, Vector128<SByte>, Vector128<SByte>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(SByte*, Vector64<SByte>, Vector64<SByte>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(Single*, Vector128<Single>, Vector128<Single>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(Single*, Vector64<Single>, Vector64<Single>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(UInt16*, Vector128<UInt16>, Vector128<UInt16>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(UInt16*, Vector64<UInt16>, Vector64<UInt16>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(UInt32*, Vector128<UInt32>, Vector128<UInt32>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(UInt32*, Vector64<UInt32>, Vector64<UInt32>)	A64: STP Dt1, Dt2, [Xn]
                // StorePair(UInt64*, Vector128<UInt64>, Vector128<UInt64>)	A64: STP Qt1, Qt2, [Xn]
                // StorePair(UInt64*, Vector64<UInt64>, Vector64<UInt64>)	A64: STP Dt1, Dt2, [Xn]
                if (true) {
                    Vector64<sbyte> a = Vector64s<sbyte>.Demo;
                    Vector64<sbyte> b = Vector64s<sbyte>.SerialNegative;
                    Vector128<sbyte> dst = default;
                    AdvSimd.Arm64.StorePair((sbyte*)&dst, a, b);
                    WriteLine(writer, indent, "StorePair<sbyte>(&dst, a, b), a={0}, b={1}", a, b);
                    WriteLine(writer, indentNext, "dst:\t{0}", dst);
                }

                // StorePairNonTemporal(Byte*, Vector128<Byte>, Vector128<Byte>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(Byte*, Vector64<Byte>, Vector64<Byte>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(Double*, Vector128<Double>, Vector128<Double>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(Double*, Vector64<Double>, Vector64<Double>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(Int16*, Vector128<Int16>, Vector128<Int16>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(Int16*, Vector64<Int16>, Vector64<Int16>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(Int32*, Vector128<Int32>, Vector128<Int32>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(Int32*, Vector64<Int32>, Vector64<Int32>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(Int64*, Vector128<Int64>, Vector128<Int64>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(Int64*, Vector64<Int64>, Vector64<Int64>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(SByte*, Vector128<SByte>, Vector128<SByte>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(SByte*, Vector64<SByte>, Vector64<SByte>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(Single*, Vector128<Single>, Vector128<Single>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(Single*, Vector64<Single>, Vector64<Single>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(UInt16*, Vector128<UInt16>, Vector128<UInt16>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(UInt16*, Vector64<UInt16>, Vector64<UInt16>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(UInt32*, Vector128<UInt32>, Vector128<UInt32>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(UInt32*, Vector64<UInt32>, Vector64<UInt32>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairNonTemporal(UInt64*, Vector128<UInt64>, Vector128<UInt64>)	A64: STNP Qt1, Qt2, [Xn]
                // StorePairNonTemporal(UInt64*, Vector64<UInt64>, Vector64<UInt64>)	A64: STNP Dt1, Dt2, [Xn]
                // StorePairScalar(Int32*, Vector64<Int32>, Vector64<Int32>)	A64: STP St1, St2, [Xn]
                // StorePairScalar(Single*, Vector64<Single>, Vector64<Single>)	A64: STP St1, St2, [Xn]
                // StorePairScalar(UInt32*, Vector64<UInt32>, Vector64<UInt32>)	A64: STP St1, St2, [Xn]
                // StorePairScalarNonTemporal(Int32*, Vector64<Int32>, Vector64<Int32>)	A64: STNP St1, St2, [Xn]
                // StorePairScalarNonTemporal(Single*, Vector64<Single>, Vector64<Single>)	A64: STNP St1, St2, [Xn]
                // StorePairScalarNonTemporal(UInt32*, Vector64<UInt32>, Vector64<UInt32>)	A64: STNP St1, St2, [Xn]
                // Ignore

                // 1、Vector subtract(正常指令):vsub -> ri = ai - bi;
                // Subtract(Vector128<Double>, Vector128<Double>)	float64x2_t vsubq_f64 (float64x2_t a, float64x2_t b); A64: FSUB Vd.2D, Vn.2D, Vm.2D
                WriteLine(writer, indent, "Subtract(Vector128s<double>.Demo, Vector128s<double>.V2):\t{0}", AdvSimd.Arm64.Subtract(Vector128s<double>.Demo, Vector128s<double>.V2));

                // 4、Vector saturating subtract(饱和指令): vqsub -> ri = sat(ai - bi); 
                // If any of the results overflow, they are saturated
                // 如果有任何结果溢出，则它们是饱和的
                // SubtractSaturateScalar(Vector64<Byte>, Vector64<Byte>)	uint8_t vqsubb_u8 (uint8_t a, uint8_t b); A64: UQSUB Bd, Bn, Bm
                // SubtractSaturateScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqsubh_s16 (int16_t a, int16_t b); A64: SQSUB Hd, Hn, Hm
                // SubtractSaturateScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqsubs_s32 (int32_t a, int32_t b); A64: SQSUB Sd, Sn, Sm
                // SubtractSaturateScalar(Vector64<SByte>, Vector64<SByte>)	int8_t vqsubb_s8 (int8_t a, int8_t b); A64: SQSUB Bd, Bn, Bm
                // SubtractSaturateScalar(Vector64<UInt16>, Vector64<UInt16>)	uint16_t vqsubh_u16 (uint16_t a, uint16_t b); A64: UQSUB Hd, Hn, Hm
                // SubtractSaturateScalar(Vector64<UInt32>, Vector64<UInt32>)	uint32_t vqsubs_u32 (uint32_t a, uint32_t b); A64: UQSUB Sd, Sn, Sm
                WriteLine(writer, indent, "SubtractSaturateScalar(Vector64s<sbyte>.Demo, Vector64s<sbyte>.V2):\t{0}", AdvSimd.Arm64.SubtractSaturateScalar(Vector64s<sbyte>.Demo, Vector64s<sbyte>.V2));
                WriteLine(writer, indent, "SubtractSaturateScalar(Vector64s<byte>.Demo, Vector64s<byte>.V2):\t{0}", AdvSimd.Arm64.SubtractSaturateScalar(Vector64s<byte>.Demo, Vector64s<byte>.V2));
                WriteLine(writer, indent, "SubtractSaturateScalar(Vector64s<short>.Demo, Vector64s<short>.V2):\t{0}", AdvSimd.Arm64.SubtractSaturateScalar(Vector64s<short>.Demo, Vector64s<short>.V2));
                WriteLine(writer, indent, "SubtractSaturateScalar(Vector64s<ushort>.Demo, Vector64s<ushort>.V2):\t{0}", AdvSimd.Arm64.SubtractSaturateScalar(Vector64s<ushort>.Demo, Vector64s<ushort>.V2));
                WriteLine(writer, indent, "SubtractSaturateScalar(Vector64s<int>.Demo, Vector64s<int>.V2):\t{0}", AdvSimd.Arm64.SubtractSaturateScalar(Vector64s<int>.Demo, Vector64s<int>.V2));
                WriteLine(writer, indent, "SubtractSaturateScalar(Vector64s<uint>.Demo, Vector64s<uint>.V2):\t{0}", AdvSimd.Arm64.SubtractSaturateScalar(Vector64s<uint>.Demo, Vector64s<uint>.V2));
            }
        }
        public unsafe static void RunArm_AdvSimd_64_T(TextWriter writer, string indent) {
            // https://developer.arm.com/documentation/dui0472/k/Using-NEON-Support/NEON-intrinsics-for-transposition-operations
            // int8x8x2_t vtrn_s8 (int8x8_t __a, int8x8_t __b);  
            // 1、Transpose elements: vtrn -> 
            // treats the elements of its input vectors as elements of 2 x 2 matrices, and transposes the matrices.
            // Essentially, it exchanges the elements with odd indices from Vector1 with the elements with even indices from Vector2.
            // 将输入向量的元素视为2 × 2矩阵的元素，并对矩阵进行转置。
            // 本质上，它将来自Vector1的奇数下标的元素与来自Vector2的偶数下标的元素交换。

            // Mnemonic: `rt[i] := (0==(i&1))?( a[i&~1] ):( b[i&~1] )`.
            // Example of element-2: `f({a[0], a[1]}, {b[0], b[1]}) = {a[0], b[0]}` .
            // Example of element-4: `f({a[0], a[1], a[2], a[3]}, {b[0], b[1], b[2], b[3]}) = {a[0], b[0], a[2], b[2]}` .
            // Example of element-8: `f({a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7]}, {b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7]}) = {a[0], b[0], a[2], b[2], a[4], b[4], a[6], b[6]}` .
            // Example of element-16: `f({a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15]}, {b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7], b[8], b[9], b[10], b[11], b[12], b[13], b[14], b[15]}) = {a[0], b[0], a[2], b[2], a[4], b[4], a[6], b[6], a[8], b[8], a[10], b[10], a[12], b[12], a[14], b[14]}` .
            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vtrn1q_u8
            // Transpose vectors (primary). This instruction reads corresponding even-numbered vector elements from the two source SIMD&FP registers, starting at zero, places each result into consecutive elements of a vector, and writes the vector to the destination SIMD&FP register. Vector elements from the first source register are placed into even-numbered elements of the destination vector, starting at zero, while vector elements from the second source register are placed into odd-numbered elements of the destination vector.
            // 转置向量(主)。这条指令从两个源SIMD&FP寄存器读取相应的偶数向量元素，从0开始，将每个结果放入一个向量的连续元素中，并将该向量写入目标SIMD&FP寄存器。来自第一个源寄存器的向量元素被放入目标向量的偶数元素中，从0开始，而来自第二个源寄存器的向量元素被放入目标向量的奇数元素中。
            // for p = 0 to pairs-1
            //     Elem[result, 2*p+0, esize] = Elem[operand1, 2*p+part, esize];
            //     Elem[result, 2*p+1, esize] = Elem[operand2, 2*p+part, esize];
            // TransposeEven(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vtrn1q_u8(uint8x16_t a, uint8x16_t b); A64: TRN1 Vd.16B, Vn.16B, Vm.16B
            // TransposeEven(Vector128<Double>, Vector128<Double>)	float64x2_t vtrn1q_f64(float64x2_t a, float64x2_t b); A64: TRN1 Vd.2D, Vn.2D, Vm.2D
            // TransposeEven(Vector128<Int16>, Vector128<Int16>)	int16x8_t vtrn1q_s16(int16x8_t a, int16x8_t b); A64: TRN1 Vd.8H, Vn.8H, Vm.8H
            // TransposeEven(Vector128<Int32>, Vector128<Int32>)	int32x4_t vtrn1q_s32(int32x4_t a, int32x4_t b); A64: TRN1 Vd.4S, Vn.4S, Vm.4S
            // TransposeEven(Vector128<Int64>, Vector128<Int64>)	int64x2_t vtrn1q_s64(int64x2_t a, int64x2_t b); A64: TRN1 Vd.2D, Vn.2D, Vm.2D
            // TransposeEven(Vector128<SByte>, Vector128<SByte>)	int8x16_t vtrn1q_u8(int8x16_t a, int8x16_t b); A64: TRN1 Vd.16B, Vn.16B, Vm.16B
            // TransposeEven(Vector128<Single>, Vector128<Single>)	float32x4_t vtrn1q_f32(float32x4_t a, float32x4_t b); A64: TRN1 Vd.4S, Vn.4S, Vm.4S
            // TransposeEven(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vtrn1q_u16(uint16x8_t a, uint16x8_t b); A64: TRN1 Vd.8H, Vn.8H, Vm.8H
            // TransposeEven(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vtrn1q_u32(uint32x4_t a, uint32x4_t b); A64: TRN1 Vd.4S, Vn.4S, Vm.4S
            // TransposeEven(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vtrn1q_u64(uint64x2_t a, uint64x2_t b); A64: TRN1 Vd.2D, Vn.2D, Vm.2D
            // TransposeEven(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vtrn1_u8(uint8x8_t a, uint8x8_t b); A64: TRN1 Vd.8B, Vn.8B, Vm.8B
            // TransposeEven(Vector64<Int16>, Vector64<Int16>)	int16x4_t vtrn1_s16(int16x4_t a, int16x4_t b); A64: TRN1 Vd.4H, Vn.4H, Vm.4H
            // TransposeEven(Vector64<Int32>, Vector64<Int32>)	int32x2_t vtrn1_s32(int32x2_t a, int32x2_t b); A64: TRN1 Vd.2S, Vn.2S, Vm.2S
            // TransposeEven(Vector64<SByte>, Vector64<SByte>)	int8x8_t vtrn1_s8(int8x8_t a, int8x8_t b); A64: TRN1 Vd.8B, Vn.8B, Vm.8B
            // TransposeEven(Vector64<Single>, Vector64<Single>)	float32x2_t vtrn1_f32(float32x2_t a, float32x2_t b); A64: TRN1 Vd.2S, Vn.2S, Vm.2S
            // TransposeEven(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vtrn1_u16(uint16x4_t a, uint16x4_t b); A64: TRN1 Vd.4H, Vn.4H, Vm.4H
            // TransposeEven(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vtrn1_u32(uint32x2_t a, uint32x2_t b); A64: TRN1 Vd.2S, Vn.2S, Vm.2S
            try {
                WriteLine(writer, indent, "TransposeEven(Vector128s<float>.Demo, Vector128s<float>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<float>.Demo, Vector128s<float>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<double>.Demo, Vector128s<double>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<double>.Demo, Vector128s<double>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<short>.Demo, Vector128s<short>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<short>.Demo, Vector128s<short>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<int>.Demo, Vector128s<int>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<int>.Demo, Vector128s<int>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<long>.Demo, Vector128s<long>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<long>.Demo, Vector128s<long>.SerialNegative));
                WriteLine(writer, indent, "TransposeEven(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeEven(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative));
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // Mnemonic: `rt[i] := (0==(i&1))?( a[i&~1 + 1] ):( b[i&~1 + 1] )`.
            // Example of element-2: `f({a[0], a[1]}, {b[0], b[1]}) = {a[1], b[1]}` .
            // Example of element-4: `f({a[0], a[1], a[2], a[3]}, {b[0], b[1], b[2], b[3]}) = {a[1], b[1], a[3], b[3]}` .
            // Example of element-8: `f({a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7]}, {b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7]}) = {a[1], b[1], a[3], b[3], a[5], b[5], a[7], b[7]}` .
            // Example of element-16: `f({a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15]}, {b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7], b[8], b[9], b[10], b[11], b[12], b[13], b[14], b[15]}) = {a[1], b[1], a[3], b[3], a[5], b[5], a[7], b[7], a[9], b[9], a[11], b[11], a[13], b[13], a[15], b[15]}` .
            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vtrn2q_u8
            // Transpose vectors (secondary). This instruction reads corresponding odd-numbered vector elements from the two source SIMD&FP registers, places each result into consecutive elements of a vector, and writes the vector to the destination SIMD&FP register. Vector elements from the first source register are placed into even-numbered elements of the destination vector, starting at zero, while vector elements from the second source register are placed into odd-numbered elements of the destination vector.
            // 转置向量(次要的)。这条指令从两个源SIMD&FP寄存器读取相应的奇数向量元素，将每个结果放入一个向量的连续元素中，并将该向量写入目标SIMD&FP寄存器。来自第一个源寄存器的向量元素被放入目标向量的偶数元素中，从0开始，而来自第二个源寄存器的向量元素被放入目标向量的奇数元素中。
            // for p = 0 to pairs-1
            //     Elem[result, 2*p+0, esize] = Elem[operand1, 2*p+part, esize];
            //     Elem[result, 2*p+1, esize] = Elem[operand2, 2*p+part, esize];
            // TransposeOdd(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vtrn2q_u8(uint8x16_t a, uint8x16_t b); A64: TRN2 Vd.16B, Vn.16B, Vm.16B
            // TransposeOdd(Vector128<Double>, Vector128<Double>)	float64x2_t vtrn2q_f64(float64x2_t a, float64x2_t b); A64: TRN2 Vd.2D, Vn.2D, Vm.2D
            // TransposeOdd(Vector128<Int16>, Vector128<Int16>)	int16x8_t vtrn2q_s16(int16x8_t a, int16x8_t b); A64: TRN2 Vd.8H, Vn.8H, Vm.8H
            // TransposeOdd(Vector128<Int32>, Vector128<Int32>)	int32x4_t vtrn2q_s32(int32x4_t a, int32x4_t b); A64: TRN2 Vd.4S, Vn.4S, Vm.4S
            // TransposeOdd(Vector128<Int64>, Vector128<Int64>)	int64x2_t vtrn2q_s64(int64x2_t a, int64x2_t b); A64: TRN2 Vd.2D, Vn.2D, Vm.2D
            // TransposeOdd(Vector128<SByte>, Vector128<SByte>)	int8x16_t vtrn2q_u8(int8x16_t a, int8x16_t b); A64: TRN2 Vd.16B, Vn.16B, Vm.16B
            // TransposeOdd(Vector128<Single>, Vector128<Single>)	float32x4_t vtrn2q_f32(float32x4_t a, float32x4_t b); A64: TRN2 Vd.4S, Vn.4S, Vm.4S
            // TransposeOdd(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vtrn2q_u16(uint16x8_t a, uint16x8_t b); A64: TRN2 Vd.8H, Vn.8H, Vm.8H
            // TransposeOdd(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vtrn2q_u32(uint32x4_t a, uint32x4_t b); A64: TRN2 Vd.4S, Vn.4S, Vm.4S
            // TransposeOdd(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vtrn2q_u64(uint64x2_t a, uint64x2_t b); A64: TRN2 Vd.2D, Vn.2D, Vm.2D
            // TransposeOdd(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vtrn2_u8(uint8x8_t a, uint8x8_t b); A64: TRN2 Vd.8B, Vn.8B, Vm.8B
            // TransposeOdd(Vector64<Int16>, Vector64<Int16>)	int16x4_t vtrn2_s16(int16x4_t a, int16x4_t b); A64: TRN2 Vd.4H, Vn.4H, Vm.4H
            // TransposeOdd(Vector64<Int32>, Vector64<Int32>)	int32x2_t vtrn2_s32(int32x2_t a, int32x2_t b); A64: TRN2 Vd.2S, Vn.2S, Vm.2S
            // TransposeOdd(Vector64<SByte>, Vector64<SByte>)	int8x8_t vtrn2_s8(int8x8_t a, int8x8_t b); A64: TRN2 Vd.8B, Vn.8B, Vm.8B
            // TransposeOdd(Vector64<Single>, Vector64<Single>)	float32x2_t vtrn2_f32(float32x2_t a, float32x2_t b); A64: TRN2 Vd.2S, Vn.2S, Vm.2S
            // TransposeOdd(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vtrn2_u16(uint16x4_t a, uint16x4_t b); A64: TRN2 Vd.4H, Vn.4H, Vm.4H
            // TransposeOdd(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vtrn2_u32(uint32x2_t a, uint32x2_t b); A64: TRN2 Vd.2S, Vn.2S, Vm.2S
            try {
                WriteLine(writer, indent, "TransposeOdd(Vector128s<float>.Demo, Vector128s<float>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<float>.Demo, Vector128s<float>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<double>.Demo, Vector128s<double>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<double>.Demo, Vector128s<double>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<short>.Demo, Vector128s<short>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<short>.Demo, Vector128s<short>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<int>.Demo, Vector128s<int>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<int>.Demo, Vector128s<int>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<long>.Demo, Vector128s<long>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<long>.Demo, Vector128s<long>.SerialNegative));
                WriteLine(writer, indent, "TransposeOdd(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative):\t{0}", AdvSimd.Arm64.TransposeOdd(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative));
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }
        }
        public unsafe static void RunArm_AdvSimd_64_U(TextWriter writer, string indent) {
            // https://developer.arm.com/documentation/dui0472/k/Using-NEON-Support/NEON-intrinsics-for-transposition-operations
            // De-Interleave elements
            // int8x8x2_t    vuzp_s8(int8x8_t a, int8x8_t b);         // VUZP.8 d0,d0 
            // 3、De-Interleave elements(Unzip elements):  
            // vuzp -> (Vector Unzip) de-interleaves the elements of two vectors. 
            // De-interleaving is the inverse process of interleaving.
            // 解交错两个向量的元素。
            // 解交织是交织的逆过程。

            // Mnemonic: `rt[i] := (i<center)?( a[i2] ):( b[i2] )`, `i2 := (i*2)%T.Count`, `center := T.Count/2`.
            // Example of element-2: `f({a[0], a[1]}, {b[0], b[1]}) = {a[0], b[0]}` .
            // Example of element-4: `f({a[0], a[1], a[2], a[3]}, {b[0], b[1], b[2], b[3]}) = {a[0], a[2], b[0], b[2]}` .
            // Example of element-8: `f({a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7]}, {b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7]}) = {a[0], a[2], a[4], a[6], b[0], b[2], b[4], b[6]}` .
            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vuzp1q_u8
            // Unzip vectors (primary). This instruction reads corresponding even-numbered vector elements from the two source SIMD&FP registers, starting at zero, places the result from the first source register into consecutive elements in the lower half of a vector, and the result from the second source register into consecutive elements in the upper half of a vector, and writes the vector to the destination SIMD&FP register.
            // bits(datasize*2) zipped = operandh:operandl;
            // for e = 0 to elements-1
            //     Elem[result, e, esize] = Elem[zipped, 2*e+part, esize];
            // UnzipEven(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vuzp1q_u8(uint8x16_t a, uint8x16_t b); A64: UZP1 Vd.16B, Vn.16B, Vm.16B
            // UnzipEven(Vector128<Double>, Vector128<Double>)	float64x2_t vuzp1q_f64(float64x2_t a, float64x2_t b); A64: UZP1 Vd.2D, Vn.2D, Vm.2D
            // UnzipEven(Vector128<Int16>, Vector128<Int16>)	int16x8_t vuzp1q_s16(int16x8_t a, int16x8_t b); A64: UZP1 Vd.8H, Vn.8H, Vm.8H
            // UnzipEven(Vector128<Int32>, Vector128<Int32>)	int32x4_t vuzp1q_s32(int32x4_t a, int32x4_t b); A64: UZP1 Vd.4S, Vn.4S, Vm.4S
            // UnzipEven(Vector128<Int64>, Vector128<Int64>)	int64x2_t vuzp1q_s64(int64x2_t a, int64x2_t b); A64: UZP1 Vd.2D, Vn.2D, Vm.2D
            // UnzipEven(Vector128<SByte>, Vector128<SByte>)	int8x16_t vuzp1q_u8(int8x16_t a, int8x16_t b); A64: UZP1 Vd.16B, Vn.16B, Vm.16B
            // UnzipEven(Vector128<Single>, Vector128<Single>)	float32x4_t vuzp1q_f32(float32x4_t a, float32x4_t b); A64: UZP1 Vd.4S, Vn.4S, Vm.4S
            // UnzipEven(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vuzp1q_u16(uint16x8_t a, uint16x8_t b); A64: UZP1 Vd.8H, Vn.8H, Vm.8H
            // UnzipEven(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vuzp1q_u32(uint32x4_t a, uint32x4_t b); A64: UZP1 Vd.4S, Vn.4S, Vm.4S
            // UnzipEven(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vuzp1q_u64(uint64x2_t a, uint64x2_t b); A64: UZP1 Vd.2D, Vn.2D, Vm.2D
            // UnzipEven(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vuzp1_u8(uint8x8_t a, uint8x8_t b); A64: UZP1 Vd.8B, Vn.8B, Vm.8B
            // UnzipEven(Vector64<Int16>, Vector64<Int16>)	int16x4_t vuzp1_s16(int16x4_t a, int16x4_t b); A64: UZP1 Vd.4H, Vn.4H, Vm.4H
            // UnzipEven(Vector64<Int32>, Vector64<Int32>)	int32x2_t vuzp1_s32(int32x2_t a, int32x2_t b); A64: UZP1 Vd.2S, Vn.2S, Vm.2S
            // UnzipEven(Vector64<SByte>, Vector64<SByte>)	int8x8_t vuzp1_s8(int8x8_t a, int8x8_t b); A64: UZP1 Vd.8B, Vn.8B, Vm.8B
            // UnzipEven(Vector64<Single>, Vector64<Single>)	float32x2_t vuzp1_f32(float32x2_t a, float32x2_t b); A64: UZP1 Vd.2S, Vn.2S, Vm.2S
            // UnzipEven(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vuzp1_u16(uint16x4_t a, uint16x4_t b); A64: UZP1 Vd.4H, Vn.4H, Vm.4H
            // UnzipEven(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vuzp1_u32(uint32x2_t a, uint32x2_t b); A64: UZP1 Vd.2S, Vn.2S, Vm.2S
            try {
                WriteLine(writer, indent, "UnzipEven(Vector128s<float>.Demo, Vector128s<float>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<float>.Demo, Vector128s<float>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<double>.Demo, Vector128s<double>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<double>.Demo, Vector128s<double>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<short>.Demo, Vector128s<short>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<short>.Demo, Vector128s<short>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<int>.Demo, Vector128s<int>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<int>.Demo, Vector128s<int>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<long>.Demo, Vector128s<long>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<long>.Demo, Vector128s<long>.SerialNegative));
                WriteLine(writer, indent, "UnzipEven(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipEven(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative));
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // Mnemonic: `rt[i] := (i<center)?( a[i2] ):( b[i2] )`, `i2 := (i*2)%T.Count + 1`, `center := T.Count/2`.
            // Example of element-2: `f({a[0], a[1]}, {b[0], b[1]}) = {a[1], b[1]}` .
            // Example of element-4: `f({a[0], a[1], a[2], a[3]}, {b[0], b[1], b[2], b[3]}) = {a[1], a[3], b[1], b[3]}` .
            // Example of element-8: `f({a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7]}, {b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7]}) = {a[1], a[3], a[5], a[7], b[1], b[3], b[5], b[7]}` .
            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vuzp2q_u8
            // Unzip vectors (secondary). This instruction reads corresponding odd-numbered vector elements from the two source SIMD&FP registers, places the result from the first source register into consecutive elements in the lower half of a vector, and the result from the second source register into consecutive elements in the upper half of a vector, and writes the vector to the destination SIMD&FP register.
            // 解压缩向量(次要)。该指令从两个源SIMD&FP寄存器读取相应的奇数向量元素，将第一个源寄存器的结果放入向量下半部分的连续元素中，将第二个源寄存器的结果放入向量上半部分的连续元素中，并将该向量写入目标SIMD&FP寄存器。
            // bits(datasize*2) zipped = operandh:operandl;
            // for e = 0 to elements-1
            //     Elem[result, e, esize] = Elem[zipped, 2*e+part, esize];
            // UnzipOdd(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vuzp2q_u8(uint8x16_t a, uint8x16_t b); A64: UZP2 Vd.16B, Vn.16B, Vm.16B
            // UnzipOdd(Vector128<Double>, Vector128<Double>)	float64x2_t vuzp2q_f64(float64x2_t a, float64x2_t b); A64: UZP2 Vd.2D, Vn.2D, Vm.2D
            // UnzipOdd(Vector128<Int16>, Vector128<Int16>)	int16x8_t vuzp2q_s16(int16x8_t a, int16x8_t b); A64: UZP2 Vd.8H, Vn.8H, Vm.8H
            // UnzipOdd(Vector128<Int32>, Vector128<Int32>)	int32x4_t vuzp2q_s32(int32x4_t a, int32x4_t b); A64: UZP2 Vd.4S, Vn.4S, Vm.4S
            // UnzipOdd(Vector128<Int64>, Vector128<Int64>)	int64x2_t vuzp2q_s64(int64x2_t a, int64x2_t b); A64: UZP2 Vd.2D, Vn.2D, Vm.2D
            // UnzipOdd(Vector128<SByte>, Vector128<SByte>)	int8x16_t vuzp2q_u8(int8x16_t a, int8x16_t b); A64: UZP2 Vd.16B, Vn.16B, Vm.16B
            // UnzipOdd(Vector128<Single>, Vector128<Single>)	float32x4_t vuzp2_f32(float32x4_t a, float32x4_t b); A64: UZP2 Vd.4S, Vn.4S, Vm.4S
            // UnzipOdd(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vuzp2q_u16(uint16x8_t a, uint16x8_t b); A64: UZP2 Vd.8H, Vn.8H, Vm.8H
            // UnzipOdd(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vuzp2q_u32(uint32x4_t a, uint32x4_t b); A64: UZP2 Vd.4S, Vn.4S, Vm.4S
            // UnzipOdd(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vuzp2q_u64(uint64x2_t a, uint64x2_t b); A64: UZP2 Vd.2D, Vn.2D, Vm.2D
            // UnzipOdd(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vuzp2_u8(uint8x8_t a, uint8x8_t b); A64: UZP2 Vd.8B, Vn.8B, Vm.8B
            // UnzipOdd(Vector64<Int16>, Vector64<Int16>)	int16x4_t vuzp2_s16(int16x4_t a, int16x4_t b); A64: UZP2 Vd.4H, Vn.4H, Vm.4H
            // UnzipOdd(Vector64<Int32>, Vector64<Int32>)	int32x2_t vuzp2_s32(int32x2_t a, int32x2_t b); A64: UZP2 Vd.2S, Vn.2S, Vm.2S
            // UnzipOdd(Vector64<SByte>, Vector64<SByte>)	int8x8_t vuzp2_s8(int8x8_t a, int8x8_t b); A64: UZP2 Vd.8B, Vn.8B, Vm.8B
            // UnzipOdd(Vector64<Single>, Vector64<Single>)	float32x2_t vuzp2_f32(float32x2_t a, float32x2_t b); A64: UZP2 Vd.2S, Vn.2S, Vm.2S
            // UnzipOdd(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vuzp2_u16(uint16x4_t a, uint16x4_t b); A64: UZP2 Vd.4H, Vn.4H, Vm.4H
            // UnzipOdd(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vuzp2_u32(uint32x2_t a, uint32x2_t b); A64: UZP2 Vd.2S, Vn.2S, Vm.2S
            try {
                WriteLine(writer, indent, "UnzipOdd(Vector128s<float>.Demo, Vector128s<float>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<float>.Demo, Vector128s<float>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<double>.Demo, Vector128s<double>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<double>.Demo, Vector128s<double>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<short>.Demo, Vector128s<short>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<short>.Demo, Vector128s<short>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<int>.Demo, Vector128s<int>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<int>.Demo, Vector128s<int>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<long>.Demo, Vector128s<long>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<long>.Demo, Vector128s<long>.SerialNegative));
                WriteLine(writer, indent, "UnzipOdd(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative):\t{0}", AdvSimd.Arm64.UnzipOdd(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative));
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }
        }
        public unsafe static void RunArm_AdvSimd_64_V(TextWriter writer, string indent) {
            string indentNext = indent + IndentNextSeparator;
            // X86 SSSE3+: _mm_shuffle_epi8
            // Mnemonic: `rt[i] := (checkRange(idx[i])) ? t[idx[i]] : 0`, `checkRange(idx[i]) := 0<=idx[i] && idx[i]<t.Count` .
            // 1、Table lookup: vtbl -> 
            // uses byte indexes in a control vector to look up byte values in a table and generate a new vector. Indexes out of range return 0.  
            // The table is in Vector1 and uses one(or two or three or four)D registers.
            // 使用控制向量中的字节索引在表中查找字节值并生成新向量。超出范围的索引返回0。
            // 该表位于Vector1中，并使用一个(或两个、三个或四个)D寄存器。
            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vtbl1_u8
            // result = if is_tbl then Zeros() else V[d];
            // for i = 0 to elements - 1
            //     index = UInt(Elem[indices, i, 8]);
            //     if index < 16 * regs then
            //         Elem[result, i, 8] = Elem[table, index, 8];
            // VectorTableLookup(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vqvtbl1q_u8(uint8x16_t t, uint8x16_t idx); A64: TBL Vd.16B, {Vn.16B}, Vm.16B
            // VectorTableLookup(Vector128<SByte>, Vector128<SByte>)	int8x16_t vqvtbl1q_s8(int8x16_t t, uint8x16_t idx); A64: TBL Vd.16B, {Vn.16B}, Vm.16B
            if (true) {
                Vector128<byte> t = Vector128s<byte>.SerialNegative;
                Vector128<byte> idx = Vector128s<byte>.Serial;
                WriteLine(writer, indent, "VectorTableLookup<byte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookup(t, idx));
                idx = Vector128s<byte>.SerialDesc;
                WriteLine(writer, indent, "VectorTableLookup<byte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookup(t, idx));
                idx = Vector128s<byte>.Demo;
                WriteLine(writer, indent, "VectorTableLookup<byte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookup(t, idx));
            }
            if (true) {
                Vector128<sbyte> t = Vector128s<sbyte>.SerialNegative;
                Vector128<sbyte> idx = Vector128s<sbyte>.Serial;
                WriteLine(writer, indent, "VectorTableLookup<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookup(t, idx));
                idx = Vector128s<sbyte>.SerialDesc;
                WriteLine(writer, indent, "VectorTableLookup<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookup(t, idx));
                idx = Vector128s<sbyte>.Demo;
                WriteLine(writer, indent, "VectorTableLookup<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookup(t, idx));
            }

            // Mnemonic: `rt[i] := (checkRange(idx[i])) ? t[idx[i]] : r[i]`, `checkRange(idx[i]) := 0<=idx[i] && idx[i]<t.Count` .
            // 2、Extended table lookup: vtbx -> 
            // uses byte indexes in a control vector to look up byte values in a table and generate a new vector. Indexes out of range leave the destination element unchanged.
            // The table is in Vector2 and uses one(or two or three or four) D register. Vector1 contains the elements of the destination vector.
            // 使用控制向量中的字节索引在表中查找字节值并生成新向量。超出范围的索引保持目标元素不变。
            // 该表位于Vector2中，并使用一个(或两个、三个或四个)D寄存器。Vector1包含目标向量的元素。
            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vtbx1
            // This intrinsic compiles to the following instructions:
            // MOVI Vtmp.8B,#8
            // CMHS Vtmp.8B,Vm.8B,Vtmp.8B
            // TBL Vtmp1.8B,{Vn.16B},Vm.8B
            // BIF Vd.8B,Vtmp1.8B,Vtmp.8B
            // VectorTableLookupExtension(Vector128<Byte>, Vector128<Byte>, Vector128<Byte>)	uint8x16_t vqvtbx1q_u8(uint8x16_t r, int8x16_t t, uint8x16_t idx); A64: TBX Vd.16B, {Vn.16B}, Vm.16B
            // VectorTableLookupExtension(Vector128<SByte>, Vector128<SByte>, Vector128<SByte>)	int8x16_t vqvtbx1q_s8(int8x16_t r, int8x16_t t, uint8x16_t idx); A64: TBX Vd.16B, {Vn.16B}, Vm.16B
            if (true) {
                Vector128<sbyte> r = Vector128s<sbyte>.Serial;
                Vector128<sbyte> t = Vector128s<sbyte>.SerialNegative;
                Vector128<sbyte> idx = Vector128s<sbyte>.Serial;
                WriteLine(writer, indent, "VectorTableLookupExtension<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookupExtension(r, t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookupExtension(r, t, idx));
                idx = Vector128s<sbyte>.SerialDesc;
                WriteLine(writer, indent, "VectorTableLookupExtension<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookupExtension(r, t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookupExtension(r, t, idx));
                idx = Vector128s<sbyte>.Demo;
                WriteLine(writer, indent, "VectorTableLookupExtension<byte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookupExtension(r, t, idx):\t{0}", AdvSimd.Arm64.VectorTableLookupExtension(r, t, idx));
            }
        }
        public unsafe static void RunArm_AdvSimd_64_Z(TextWriter writer, string indent) {
            // https://developer.arm.com/documentation/dui0472/k/Using-NEON-Support/NEON-intrinsics-for-transposition-operations
            // Interleave elements
            // int8x8x2_t    vzip_s8(int8x8_t a, int8x8_t b);         // VZIP.8 d0,d0 
            // 2、Interleave elements(Zip elements):  
            // vzip ->  (Vector Zip) interleaves the elements of two vectors.

            // My guess:
            // ZipLow(ZipLow(a,b), ZipLow(a,b)) = TransposeEven(a,b)
            // ZipHigh(ZipHigh(a,b), ZipHigh(a,b)) = TransposeOdd(a,b)
            // Mnemonic: `rt[i] := (0==(i&1))?( a[i2] ):( b[i2] )`, `i2 := (i+T.Count)/2`.
            // Example of element-2: `f({a[0], a[1]}, {b[0], b[1]}) = {a[1], b[1]}` .
            // Example of element-4: `f({a[0], a[1], a[2], a[3]}, {b[0], b[1], b[2], b[3]}) = {a[2], b[2], a[3], b[3]}` .
            // Example of element-8: `f({a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7]}, {b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7]}) = {a[4], b[4], a[5], b[5], a[6], b[6], a[7], b[7]}` .
            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vzip2q_u8
            // Zip vectors (secondary). This instruction reads adjacent vector elements from the upper half of two source SIMD&FP registers as pairs, interleaves the pairs and places them into a vector, and writes the vector to the destination SIMD&FP register. The first pair from the first source register is placed into the two lowest vector elements, with subsequent pairs taken alternately from each source register.
            // 压缩向量(次要)。这条指令从两个源SIMD&FP寄存器的上半部分读取相邻的向量元素作为对，将这些对交叉并将它们放入一个向量中，并将该向量写入目标SIMD&FP寄存器。来自第一个源寄存器的第一对被放入两个最低的向量元素中，随后的对交替从每个源寄存器中取出。
            // integer base = part * pairs;
            // for p = 0 to pairs-1
            //     Elem[result, 2*p+0, esize] = Elem[operand1, base+p, esize];
            //     Elem[result, 2*p+1, esize] = Elem[operand2, base+p, esize];
            // ZipHigh(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vzip2q_u8(uint8x16_t a, uint8x16_t b); A64: ZIP2 Vd.16B, Vn.16B, Vm.16B
            // ZipHigh(Vector128<Double>, Vector128<Double>)	float64x2_t vzip2q_f64(float64x2_t a, float64x2_t b); A64: ZIP2 Vd.2D, Vn.2D, Vm.2D
            // ZipHigh(Vector128<Int16>, Vector128<Int16>)	int16x8_t vzip2q_s16(int16x8_t a, int16x8_t b); A64: ZIP2 Vd.8H, Vn.8H, Vm.8H
            // ZipHigh(Vector128<Int32>, Vector128<Int32>)	int32x4_t vzip2q_s32(int32x4_t a, int32x4_t b); A64: ZIP2 Vd.4S, Vn.4S, Vm.4S
            // ZipHigh(Vector128<Int64>, Vector128<Int64>)	int64x2_t vzip2q_s64(int64x2_t a, int64x2_t b); A64: ZIP2 Vd.2D, Vn.2D, Vm.2D
            // ZipHigh(Vector128<SByte>, Vector128<SByte>)	int8x16_t vzip2q_u8(int8x16_t a, int8x16_t b); A64: ZIP2 Vd.16B, Vn.16B, Vm.16B
            // ZipHigh(Vector128<Single>, Vector128<Single>)	float32x4_t vzip2q_f32(float32x4_t a, float32x4_t b); A64: ZIP2 Vd.4S, Vn.4S, Vm.4S
            // ZipHigh(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vzip2q_u16(uint16x8_t a, uint16x8_t b); A64: ZIP2 Vd.8H, Vn.8H, Vm.8H
            // ZipHigh(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vzip2q_u32(uint32x4_t a, uint32x4_t b); A64: ZIP2 Vd.4S, Vn.4S, Vm.4S
            // ZipHigh(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vzip2q_u64(uint64x2_t a, uint64x2_t b); A64: ZIP2 Vd.2D, Vn.2D, Vm.2D
            // ZipHigh(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vzip2_u8(uint8x8_t a, uint8x8_t b); A64: ZIP2 Vd.8B, Vn.8B, Vm.8B
            // ZipHigh(Vector64<Int16>, Vector64<Int16>)	int16x4_t vzip2_s16(int16x4_t a, int16x4_t b); A64: ZIP2 Vd.4H, Vn.4H, Vm.4H
            // ZipHigh(Vector64<Int32>, Vector64<Int32>)	int32x2_t vzip2_s32(int32x2_t a, int32x2_t b); A64: ZIP2 Vd.2S, Vn.2S, Vm.2S
            // ZipHigh(Vector64<SByte>, Vector64<SByte>)	int8x8_t vzip2_s8(int8x8_t a, int8x8_t b); A64: ZIP2 Vd.8B, Vn.8B, Vm.8B
            // ZipHigh(Vector64<Single>, Vector64<Single>)	float32x2_t vzip2_f32(float32x2_t a, float32x2_t b); A64: ZIP2 Vd.2S, Vn.2S, Vm.2S
            // ZipHigh(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vzip2_u16(uint16x4_t a, uint16x4_t b); A64: ZIP2 Vd.4H, Vn.4H, Vm.4H
            // ZipHigh(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vzip2_u32(uint32x2_t a, uint32x2_t b); A64: ZIP2 Vd.2S, Vn.2S, Vm.2S
            try {
                WriteLine(writer, indent, "ZipHigh(Vector128s<float>.Demo, Vector128s<float>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<float>.Demo, Vector128s<float>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<double>.Demo, Vector128s<double>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<double>.Demo, Vector128s<double>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<short>.Demo, Vector128s<short>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<short>.Demo, Vector128s<short>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<int>.Demo, Vector128s<int>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<int>.Demo, Vector128s<int>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<long>.Demo, Vector128s<long>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<long>.Demo, Vector128s<long>.SerialNegative));
                WriteLine(writer, indent, "ZipHigh(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipHigh(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative));
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

            // Mnemonic: `rt[i] := (0==(i&1))?( a[i2] ):( b[i2] )`, `i2 := i/2`.
            // Example of element-2: `f({a[0], a[1]}, {b[0], b[1]}) = {a[0], b[0]}` .
            // Example of element-4: `f({a[0], a[1], a[2], a[3]}, {b[0], b[1], b[2], b[3]}) = {a[0], b[0], a[1], b[1]}` .
            // Example of element-8: `f({a[0], a[1], a[2], a[3], a[4], a[5], a[6], a[7]}, {b[0], b[1], b[2], b[3], b[4], b[5], b[6], b[7]}) = {a[0], b[0], a[1], b[1], a[2], b[2], a[3], b[3]}` .
            // https://developer.arm.com/architectures/instruction-sets/intrinsics/#q=vzip1q_u8
            // Zip vectors (primary). This instruction reads adjacent vector elements from the lower half of two source SIMD&FP registers as pairs, interleaves the pairs and places them into a vector, and writes the vector to the destination SIMD&FP register. The first pair from the first source register is placed into the two lowest vector elements, with subsequent pairs taken alternately from each source register.
            // 压缩向量(主要)。这条指令从两个源SIMD&FP寄存器的下半部分读取相邻的向量元素作为对，将这些对交叉并将它们放入一个向量中，并将该向量写入目标SIMD&FP寄存器。来自第一个源寄存器的第一对被放入两个最低的向量元素中，随后的对交替从每个源寄存器中取出。
            // integer base = part * pairs;
            // for p = 0 to pairs-1
            //     Elem[result, 2*p+0, esize] = Elem[operand1, base+p, esize];
            //     Elem[result, 2*p+1, esize] = Elem[operand2, base+p, esize];
            // ZipLow(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vzip1q_u8(uint8x16_t a, uint8x16_t b); A64: ZIP1 Vd.16B, Vn.16B, Vm.16B
            // ZipLow(Vector128<Double>, Vector128<Double>)	float64x2_t vzip1q_f64(float64x2_t a, float64x2_t b); A64: ZIP1 Vd.2D, Vn.2D, Vm.2D
            // ZipLow(Vector128<Int16>, Vector128<Int16>)	int16x8_t vzip1q_s16(int16x8_t a, int16x8_t b); A64: ZIP1 Vd.8H, Vn.8H, Vm.8H
            // ZipLow(Vector128<Int32>, Vector128<Int32>)	int32x4_t vzip1q_s32(int32x4_t a, int32x4_t b); A64: ZIP1 Vd.4S, Vn.4S, Vm.4S
            // ZipLow(Vector128<Int64>, Vector128<Int64>)	int64x2_t vzip1q_s64(int64x2_t a, int64x2_t b); A64: ZIP1 Vd.2D, Vn.2D, Vm.2D
            // ZipLow(Vector128<SByte>, Vector128<SByte>)	int8x16_t vzip1q_u8(int8x16_t a, int8x16_t b); A64: ZIP1 Vd.16B, Vn.16B, Vm.16B
            // ZipLow(Vector128<Single>, Vector128<Single>)	float32x4_t vzip1q_f32(float32x4_t a, float32x4_t b); A64: ZIP1 Vd.4S, Vn.4S, Vm.4S
            // ZipLow(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vzip1q_u16(uint16x8_t a, uint16x8_t b); A64: ZIP1 Vd.8H, Vn.8H, Vm.8H
            // ZipLow(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vzip1q_u32(uint32x4_t a, uint32x4_t b); A64: ZIP1 Vd.4S, Vn.4S, Vm.4S
            // ZipLow(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vzip1q_u64(uint64x2_t a, uint64x2_t b); A64: ZIP1 Vd.2D, Vn.2D, Vm.2D
            // ZipLow(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vzip1_u8(uint8x8_t a, uint8x8_t b); A64: ZIP1 Vd.8B, Vn.8B, Vm.8B
            // ZipLow(Vector64<Int16>, Vector64<Int16>)	int16x4_t vzip1_s16(int16x4_t a, int16x4_t b); A64: ZIP1 Vd.4H, Vn.4H, Vm.4H
            // ZipLow(Vector64<Int32>, Vector64<Int32>)	int32x2_t vzip1_s32(int32x2_t a, int32x2_t b); A64: ZIP1 Vd.2S, Vn.2S, Vm.2S
            // ZipLow(Vector64<SByte>, Vector64<SByte>)	int8x8_t vzip1_s8(int8x8_t a, int8x8_t b); A64: ZIP1 Vd.8B, Vn.8B, Vm.8B
            // ZipLow(Vector64<Single>, Vector64<Single>)	float32x2_t vzip1_f32(float32x2_t a, float32x2_t b); A64: ZIP1 Vd.2S, Vn.2S, Vm.2S
            // ZipLow(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vzip1_u16(uint16x4_t a, uint16x4_t b); A64: ZIP1 Vd.4H, Vn.4H, Vm.4H
            // ZipLow(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vzip1_u32(uint32x2_t a, uint32x2_t b); A64: ZIP1 Vd.2S, Vn.2S, Vm.2S
            try {
                WriteLine(writer, indent, "ZipLow(Vector128s<float>.Demo, Vector128s<float>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<float>.Demo, Vector128s<float>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<double>.Demo, Vector128s<double>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<double>.Demo, Vector128s<double>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<sbyte>.Demo, Vector128s<sbyte>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<byte>.Demo, Vector128s<byte>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<short>.Demo, Vector128s<short>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<short>.Demo, Vector128s<short>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<ushort>.Demo, Vector128s<ushort>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<int>.Demo, Vector128s<int>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<int>.Demo, Vector128s<int>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<uint>.Demo, Vector128s<uint>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<long>.Demo, Vector128s<long>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<long>.Demo, Vector128s<long>.SerialNegative));
                WriteLine(writer, indent, "ZipLow(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative):\t{0}", AdvSimd.Arm64.ZipLow(Vector128s<ulong>.Demo, Vector128s<ulong>.SerialNegative));
            } catch (Exception ex) {
                writer.WriteLine(indent + ex.ToString());
            }

        }

    }
}
