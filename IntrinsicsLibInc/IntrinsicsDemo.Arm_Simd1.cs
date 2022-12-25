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
        /// Run Arm Dp . https://learn.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.arm.dp?view=net-7.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunArm_Dp(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Dp.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Dp.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

            // Dot Product signed arithmetic (vector). This instruction performs the dot product of the four signed 8-bit elements in each 32-bit element of the first source register with the four signed 8-bit elements of the corresponding 32-bit element in the second source register, accumulating the result into the corresponding 32-bit element of the destination register.
            // 点积符号算术(向量)。这条指令执行第一个源寄存器中每个32位元素中的4个带符号的8位元素与第二个源寄存器中相应32位元素的4个带符号的8位元素的点积，将结果累加到目标寄存器中相应的32位元素中。
            // for e = 0 to elements-1 
            //     integer res = 0;
            //     integer element1, element2;
            //     for i = 0 to 3 
            //         if signed then
            //             element1 = SInt(Elem[operand1, 4 * e + i, esize DIV 4]); 
            //             element2 = SInt(Elem[operand2, 4 * e + i, esize DIV 4]);
            //         else 
            //             element1 = UInt(Elem[operand1, 4 * e + i, esize DIV 4]); 
            //             element2 = UInt(Elem[operand2, 4 * e + i, esize DIV 4]);
            //         res = res + element1 * element2; 
            //     Elem[result, e, esize] = Elem[result, e, esize] + res;
            // DotProduct(Vector128<Int32>, Vector128<SByte>, Vector128<SByte>)	int32x4_t vdotq_s32 (int32x4_t r, int8x16_t a, int8x16_t b) A32: VSDOT.S8 Qd, Qn, Qm A64: SDOT Vd.4S, Vn.16B, Vm.16B
            // DotProduct(Vector128<UInt32>, Vector128<Byte>, Vector128<Byte>)	uint32x4_t vdotq_u32 (uint32x4_t r, uint8x16_t a, uint8x16_t b) A32: VUDOT.U8 Qd, Qn, Qm A64: UDOT Vd.4S, Vn.16B, Vm.16B
            // DotProduct(Vector64<Int32>, Vector64<SByte>, Vector64<SByte>)	int32x2_t vdot_s32 (int32x2_t r, int8x8_t a, int8x8_t b) A32: VSDOT.S8 Dd, Dn, Dm A64: SDOT Vd.2S, Vn.8B, Vm.8B
            // DotProduct(Vector64<UInt32>, Vector64<Byte>, Vector64<Byte>)	uint32x2_t vdot_u32 (uint32x2_t r, uint8x8_t a, uint8x8_t b) A32: VUDOT.U8 Dd, Dn, Dm A64: UDOT Vd.2S, Vn.8B, Vm.8B
            WriteLine(writer, indent, "DotProduct(Vector128s<int>.V1, Vector128s<sbyte>.Serial, Vector128s<sbyte>.V2):\t{0}", Dp.DotProduct(Vector128s<int>.V1, Vector128s<sbyte>.Serial, Vector128s<sbyte>.V2));
            WriteLine(writer, indent, "DotProduct(Vector128s<uint>.V1, Vector128s<byte>.Serial, Vector128s<byte>.V2):\t{0}", Dp.DotProduct(Vector128s<uint>.V1, Vector128s<byte>.Serial, Vector128s<byte>.V2));

            // Dot Product signed arithmetic (vector). This instruction performs the dot product of the four signed 8-bit elements in each 32-bit element of the first source register with the four signed 8-bit elements of the corresponding 32-bit element in the second source register, accumulating the result into the corresponding 32-bit element of the destination register.
            // 点积符号算术(向量)。这条指令执行第一个源寄存器中每个32位元素中的4个带符号的8位元素与第二个源寄存器中相应32位元素的4个带符号的8位元素的点积，将结果累加到目标寄存器中相应的32位元素中。
            // lane  minimum: 0; maximum: 3
            // for e = 0 to elements-1 
            //     integer res = 0;
            //     integer element1, element2;
            //     for i = 0 to 3 
            //         if signed then
            //             element1 = SInt(Elem[operand1, 4 * e + i, esize DIV 4]); 
            //             element2 = SInt(Elem[operand2, 4 * e + i, esize DIV 4]);
            //         else 
            //             element1 = UInt(Elem[operand1, 4 * e + i, esize DIV 4]); 
            //             element2 = UInt(Elem[operand2, 4 * e + i, esize DIV 4]);
            //         res = res + element1 * element2; 
            //     Elem[result, e, esize] = Elem[result, e, esize] + res;
            // DotProductBySelectedQuadruplet(Vector128<Int32>, Vector128<SByte>, Vector128<SByte>, Byte)	int32x4_t vdotq_laneq_s32 (int32x4_t r, int8x16_t a, int8x16_t b, const int lane) A32: VSDOT.S8 Qd, Qn, Dm[lane] A64: SDOT Vd.4S, Vn.16B, Vm.4B[lane]
            // DotProductBySelectedQuadruplet(Vector128<Int32>, Vector128<SByte>, Vector64<SByte>, Byte)	int32x4_t vdotq_lane_s32 (int32x4_t r, int8x16_t a, int8x8_t b, const int lane) A32: VSDOT.S8 Qd, Qn, Dm[lane] A64: SDOT Vd.4S, Vn.16B, Vm.4B[lane]
            // DotProductBySelectedQuadruplet(Vector128<UInt32>, Vector128<Byte>, Vector128<Byte>, Byte)	uint32x4_t vdotq_laneq_u32 (uint32x4_t r, uint8x16_t a, uint8x16_t b, const int lane) A32: VUDOT.U8 Qd, Qn, Dm[lane] A64: UDOT Vd.4S, Vn.16B, Vm.4B[lane]
            // DotProductBySelectedQuadruplet(Vector128<UInt32>, Vector128<Byte>, Vector64<Byte>, Byte)	uint32x4_t vdotq_lane_u32 (uint32x4_t r, uint8x16_t a, uint8x8_t b, const int lane) A32: VUDOT.U8 Qd, Qn, Dm[lane] A64: UDOT Vd.4S, Vn.16B, Vm.4B[lane]
            // DotProductBySelectedQuadruplet(Vector64<Int32>, Vector64<SByte>, Vector128<SByte>, Byte)	int32x2_t vdot_laneq_s32 (int32x2_t r, int8x8_t a, int8x16_t b, const int lane) A32: VSDOT.S8 Dd, Dn, Dm[lane] A64: SDOT Vd.2S, Vn.8B, Vm.4B[lane]
            // DotProductBySelectedQuadruplet(Vector64<Int32>, Vector64<SByte>, Vector64<SByte>, Byte)	int32x2_t vdot_lane_s32 (int32x2_t r, int8x8_t a, int8x8_t b, const int lane) A32: VSDOT.S8 Dd, Dn, Dm[lane] A64: SDOT Vd.2S, Vn.8B, Vm.4B[lane]
            // DotProductBySelectedQuadruplet(Vector64<UInt32>, Vector64<Byte>, Vector128<Byte>, Byte)	uint32x2_t vdot_laneq_u32 (uint32x2_t r, uint8x8_t a, uint8x16_t b, const int lane) A32: VUDOT.U8 Dd, Dn, Dm[lane] A64: UDOT Vd.2S, Vn.8B, Vm.4B[lane]
            // DotProductBySelectedQuadruplet(Vector64<UInt32>, Vector64<Byte>, Vector64<Byte>, Byte)	uint32x2_t vdot_lane_u32 (uint32x2_t r, uint8x8_t a, uint8x8_t b, const int lane) A32: VUDOT.U8 Dd, Dn, Dm[lane] A64: UDOT Vd.2S, Vn.8B, Vm.4B[lane]
            if (true) {
                Vector128<int> r = Vector128s<int>.V1;
                Vector128<sbyte> a = Vector128s<sbyte>.Serial;
                Vector128<sbyte> b = Vector128s<sbyte>.V2;
                WriteLine(writer, indent, "DotProductBySelectedQuadruplet<sbyte>, r={0}, a={1}, b={2}", r, a, b);
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indentNext, "DotProductBySelectedQuadruplet(r, a, b, {1}):\t{0}", Dp.DotProductBySelectedQuadruplet(r, a, b, i), i);
                }
            }
            if (true) {
                Vector128<uint> r = Vector128s<uint>.V1;
                Vector128<byte> a = Vector128s<byte>.Serial;
                Vector128<byte> b = Vector128s<byte>.V2;
                WriteLine(writer, indent, "DotProductBySelectedQuadruplet<byte>, r={0}, a={1}, b={2}", r, a, b);
                for (byte i = 0; i <= 3; ++i) {
                    WriteLine(writer, indentNext, "DotProductBySelectedQuadruplet(r, a, b, {1}):\t{0}", Dp.DotProductBySelectedQuadruplet(r, a, b, i), i);
                }
            }
        }

        /// <summary>
        /// Run Arm Dp.Arm64 .
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunArm_Dp_64(TextWriter writer, string indent) {
            //if (null == writer) return;
            //if (null == indent) indent = "";
            //string indentNext = indent + IndentNextSeparator;
            //bool isSupported = Dp.Arm64.IsSupported;
            //if (isSupported) {
            //    writer.WriteLine();
            //}
            //writer.WriteLine(indent + string.Format("-- Dp.Arm64.IsSupported:\t{0}", isSupported));
            //if (!isSupported) {
            //    return;
            //}
            //// Nothing
        }

        /// <summary>
        /// Run Arm Rdm .
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunArm_Rdm(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Rdm.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Rdm.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

            // MultiplyRoundedDoublingAndAddSaturateHigh(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>)	int16x8_t vqrdmlahq_s16 (int16x8_t a, int16x8_t b, int16x8_t c) A32: VQRDMLAH.S16 Qd, Qn, Qm A64: SQRDMLAH Vd.8H, Vn.8H, Vm.8H
            // MultiplyRoundedDoublingAndAddSaturateHigh(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>)	int32x4_t vqrdmlahq_s32 (int32x4_t a, int32x4_t b, int32x4_t c) A32: VQRDMLAH.S32 Qd, Qn, Qm A64: SQRDMLAH Vd.4S, Vn.4S, Vm.4S
            // MultiplyRoundedDoublingAndAddSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16x4_t vqrdmlah_s16 (int16x4_t a, int16x4_t b, int16x4_t c) A32: VQRDMLAH.S16 Dd, Dn, Dm A64: SQRDMLAH Vd.4H, Vn.4H, Vm.4H
            // MultiplyRoundedDoublingAndAddSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32x2_t vqrdmlah_s32 (int32x2_t a, int32x2_t b, int32x2_t c) A32: VQRDMLAH.S32 Dd, Dn, Dm A64: SQRDMLAH Vd.2S, Vn.2S, Vm.2S
            // MultiplyRoundedDoublingAndSubtractSaturateHigh(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>)	int16x8_t vqrdmlshq_s16 (int16x8_t a, int16x8_t b, int16x8_t c) A32: VQRDMLSH.S16 Qd, Qn, Qm A64: SQRDMLSH Vd.8H, Vn.8H, Vm.8H
            // MultiplyRoundedDoublingAndSubtractSaturateHigh(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>)	int32x4_t vqrdmlshq_s32 (int32x4_t a, int32x4_t b, int32x4_t c) A32: VQRDMLSH.S32 Qd, Qn, Qm A64: SQRDMLSH Vd.4S, Vn.4S, Vm.4S
            // MultiplyRoundedDoublingAndSubtractSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16x4_t vqrdmlsh_s16 (int16x4_t a, int16x4_t b, int16x4_t c) A32: VQRDMLSH.S16 Dd, Dn, Dm A64: SQRDMLSH Vd.4H, Vn.4H, Vm.4H
            // MultiplyRoundedDoublingAndSubtractSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32x2_t vqrdmlsh_s32 (int32x2_t a, int32x2_t b, int32x2_t c) A32: VQRDMLSH.S32 Dd, Dn, Dm A64: SQRDMLSH Vd.2S, Vn.2S, Vm.2S
            // MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vqrdmlahq_laneq_s16 (int16x8_t a, int16x8_t b, int16x8_t v, const int lane) A32: VQRDMLAH.S16 Qd, Qn, Dm[lane] A64: SQRDMLAH Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector128<Int16>, Vector128<Int16>, Vector64<Int16>, Byte)	int16x8_t vqrdmlahq_lane_s16 (int16x8_t a, int16x8_t b, int16x4_t v, const int lane) A32: VQRDMLAH.S16 Qd, Qn, Dm[lane] A64: SQRDMLAH Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vqrdmlahq_laneq_s32 (int32x4_t a, int32x4_t b, int32x4_t v, const int lane) A32: VQRDMLAH.S32 Qd, Qn, Dm[lane] A64: SQRDMLAH Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector128<Int32>, Vector128<Int32>, Vector64<Int32>, Byte)	int32x4_t vqrdmlahq_lane_s32 (int32x4_t a, int32x4_t b, int32x2_t v, const int lane) A32: VQRDMLAH.S32 Qd, Qn, Dm[lane] A64: SQRDMLAH Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector128<Int16>, Byte)	int16x4_t vqrdmlah_laneq_s16 (int16x4_t a, int16x4_t b, int16x8_t v, const int lane) A32: VQRDMLAH.S16 Dd, Dn, Dm[lane] A64: SQRDMLAH Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vqrdmlah_lane_s16 (int16x4_t a, int16x4_t b, int16x4_t v, const int lane) A32: VQRDMLAH.S16 Dd, Dn, Dm[lane] A64: SQRDMLAH Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector128<Int32>, Byte)	int32x2_t vqrdmlah_laneq_s32 (int32x2_t a, int32x2_t b, int32x4_t v, const int lane) A32: VQRDMLAH.S32 Dd, Dn, Dm[lane] A64: SQRDMLAH Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndAddSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vqrdmlah_lane_s32 (int32x2_t a, int32x2_t b, int32x2_t v, const int lane) A32: VQRDMLAH.S32 Dd, Dn, Dm[lane] A64: SQRDMLAH Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vqrdmlshq_laneq_s16 (int16x8_t a, int16x8_t b, int16x8_t v, const int lane) A32: VQRDMLSH.S16 Qd, Qn, Dm[lane] A64: SQRDMLSH Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector128<Int16>, Vector128<Int16>, Vector64<Int16>, Byte)	int16x8_t vqrdmlshq_lane_s16 (int16x8_t a, int16x8_t b, int16x4_t v, const int lane) A32: VQRDMLSH.S16 Qd, Qn, Dm[lane] A64: SQRDMLSH Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vqrdmlshq_laneq_s32 (int32x4_t a, int32x4_t b, int32x4_t v, const int lane) A32: VQRDMLSH.S32 Qd, Qn, Dm[lane] A64: SQRDMLSH Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector128<Int32>, Vector128<Int32>, Vector64<Int32>, Byte)	int32x4_t vqrdmlshq_lane_s32 (int32x4_t a, int32x4_t b, int32x2_t v, const int lane) A32: VQRDMLSH.S32 Qd, Qn, Dm[lane] A64: SQRDMLSH Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector128<Int16>, Byte)	int16x4_t vqrdmlsh_laneq_s16 (int16x4_t a, int16x4_t b, int16x8_t v, const int lane) A32: VQRDMLSH.S16 Dd, Dn, Dm[lane] A64: SQRDMLSH Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vqrdmlsh_lane_s16 (int16x4_t a, int16x4_t b, int16x4_t v, const int lane) A32: VQRDMLSH.S16 Dd, Dn, Dm[lane] A64: SQRDMLSH Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector128<Int32>, Byte)	int32x2_t vqrdmlsh_laneq_s32 (int32x2_t a, int32x2_t b, int32x4_t v, const int lane) A32: VQRDMLSH.S32 Dd, Dn, Dm[lane] A64: SQRDMLSH Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarAndSubtractSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vqrdmlsh_lane_s32 (int32x2_t a, int32x2_t b, int32x2_t v, const int lane) A32: VQRDMLSH.S32 Dd, Dn, Dm[lane] A64: SQRDMLSH Vd.2S, Vn.2S, Vm.S[lane]

        }

        /// <summary>
        /// Run Arm Rdm.Arm64 .
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunArm_Rdm_64(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Rdm.Arm64.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Rdm.Arm64.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

            // MultiplyRoundedDoublingAndAddSaturateHighScalar(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16_t vqrdmlahh_s16 (int16_t a, int16_t b, int16_t c) A64: SQRDMLAH Hd, Hn, Hm
            // MultiplyRoundedDoublingAndAddSaturateHighScalar(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32_t vqrdmlahs_s32 (int32_t a, int32_t b, int32_t c) A64: SQRDMLAH Sd, Sn, Sm
            // MultiplyRoundedDoublingAndSubtractSaturateHighScalar(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16_t vqrdmlshh_s16 (int16_t a, int16_t b, int16_t c) A64: SQRDMLSH Hd, Hn, Hm
            // MultiplyRoundedDoublingAndSubtractSaturateHighScalar(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32_t vqrdmlshs_s32 (int32_t a, int32_t b, int32_t c) A64: SQRDMLSH Sd, Sn, Sm
            // MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector128<Int16>, Byte)	int16_t vqrdmlahh_laneq_s16 (int16_t a, int16_t b, int16x8_t v, const int lane) A64: SQRDMLAH Hd, Hn, Vm.H[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>, Byte)	int16_t vqrdmlahh_lane_s16 (int16_t a, int16_t b, int16x4_t v, const int lane) A64: SQRDMLAH Hd, Hn, Vm.H[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector128<Int32>, Byte)	int32_t vqrdmlahs_laneq_s32 (int32_t a, int32_t b, int32x4_t v, const int lane) A64: SQRDMLAH Sd, Sn, Vm.S[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarAndAddSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>, Byte)	int32_t vqrdmlahs_lane_s32 (int32_t a, int32_t b, int32x2_t v, const int lane) A64: SQRDMLAH Sd, Sn, Vm.S[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector128<Int16>, Byte)	int16_t vqrdmlshh_laneq_s16 (int16_t a, int16_t b, int16x8_t v, const int lane) A64: SQRDMLSH Hd, Hn, Vm.H[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>, Byte)	int16_t vqrdmlshh_lane_s16 (int16_t a, int16_t b, int16x4_t v, const int lane) A64: SQRDMLSH Hd, Hn, Vm.H[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector128<Int32>, Byte)	int32_t vqrdmlshs_laneq_s32 (int32_t a, int32_t b, int32x4_t v, const int lane) A64: SQRDMLSH Sd, Sn, Vm.S[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarAndSubtractSaturateHigh(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>, Byte)	int32_t vqrdmlshs_lane_s32 (int32_t a, int32_t b, int32x2_t v, const int lane) A64: SQRDMLSH Sd, Sn, Vm.S[lane]

        }
    }

}