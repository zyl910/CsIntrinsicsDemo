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
        /// Run Arm AdvSimd. https://learn.microsoft.com/en-us/dotnet/api/system.runtime.intrinsics.arm.advsimd?view=net-7.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunArm_AdvSimd(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = AdvSimd.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- AdvSimd.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

            //RunArm_AdvSimd_A(writer, indent);
            //RunArm_AdvSimd_B(writer, indent);
            //RunArm_AdvSimd_C(writer, indent);
            //RunArm_AdvSimd_D(writer, indent);
            //RunArm_AdvSimd_E(writer, indent);
            //RunArm_AdvSimd_F(writer, indent);
            //RunArm_AdvSimd_I(writer, indent);
            //RunArm_AdvSimd_L(writer, indent);
            //RunArm_AdvSimd_M(writer, indent);
            //RunArm_AdvSimd_N(writer, indent);
            //RunArm_AdvSimd_O(writer, indent);
            //RunArm_AdvSimd_P(writer, indent);
            //RunArm_AdvSimd_R(writer, indent);
            //RunArm_AdvSimd_S(writer, indent);
            //RunArm_AdvSimd_V(writer, indent);
            //RunArm_AdvSimd_X(writer, indent);
            //RunArm_AdvSimd_Z(writer, indent);
            Action<TextWriter, string>[] list = {
                RunArm_AdvSimd_A,
                RunArm_AdvSimd_B,
                RunArm_AdvSimd_C,
                RunArm_AdvSimd_D,
                RunArm_AdvSimd_E,
                RunArm_AdvSimd_F,
                RunArm_AdvSimd_I,
                RunArm_AdvSimd_L,
                RunArm_AdvSimd_M,
                RunArm_AdvSimd_N,
                RunArm_AdvSimd_O,
                RunArm_AdvSimd_P,
                RunArm_AdvSimd_R,
                RunArm_AdvSimd_S,
                RunArm_AdvSimd_V,
                RunArm_AdvSimd_X,
                RunArm_AdvSimd_Z,
            };
            TraitsUtil.InvokeArray(writer, indent, list);
        }
        public unsafe static void RunArm_AdvSimd_A(TextWriter writer, string indent) {
            // Abs(Vector128<Int16>)	int16x8_t vabsq_s16 (int16x8_t a); A32: VABS.S16 Qd, Qm; A64: ABS Vd.8H, Vn.8H
            // Abs(Vector128<Int32>)	int32x4_t vabsq_s32 (int32x4_t a); A32: VABS.S32 Qd, Qm; A64: ABS Vd.4S, Vn.4S
            // Abs(Vector128<SByte>)	int8x16_t vabsq_s8 (int8x16_t a); A32: VABS.S8 Qd, Qm; A64: ABS Vd.16B, Vn.16B
            // Abs(Vector128<Single>)	float32x4_t vabsq_f32 (float32x4_t a); A32: VABS.F32 Qd, Qm; A64: FABS Vd.4S, Vn.4S
            // Abs(Vector64<Int16>)	int16x4_t vabs_s16 (int16x4_t a); A32: VABS.S16 Dd, Dm; A64: ABS Vd.4H, Vn.4H
            // Abs(Vector64<Int32>)	int32x2_t vabs_s32 (int32x2_t a); A32: VABS.S32 Dd, Dm; A64: ABS Vd.2S, Vn.2S
            // Abs(Vector64<SByte>)	int8x8_t vabs_s8 (int8x8_t a); A32: VABS.S8 Dd, Dm; A64: ABS Vd.8B, Vn.8B
            // Abs(Vector64<Single>)	float32x2_t vabs_f32 (float32x2_t a); A32: VABS.F32 Dd, Dm; A64: FABS Vd.2S, Vn.2S
            // AbsoluteCompareGreaterThan(Vector128<Single>, Vector128<Single>)	uint32x4_t vcagtq_f32 (float32x4_t a, float32x4_t b); A32: VACGT.F32 Qd, Qn, Qm; A64: FACGT Vd.4S, Vn.4S, Vm.4S
            // AbsoluteCompareGreaterThan(Vector64<Single>, Vector64<Single>)	uint32x2_t vcagt_f32 (float32x2_t a, float32x2_t b); A32: VACGT.F32 Dd, Dn, Dm; A64: FACGT Vd.2S, Vn.2S, Vm.2S
            // AbsoluteCompareGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)	uint32x4_t vcageq_f32 (float32x4_t a, float32x4_t b); A32: VACGE.F32 Qd, Qn, Qm; A64: FACGE Vd.4S, Vn.4S, Vm.4S
            // AbsoluteCompareGreaterThanOrEqual(Vector64<Single>, Vector64<Single>)	uint32x2_t vcage_f32 (float32x2_t a, float32x2_t b); A32: VACGE.F32 Dd, Dn, Dm; A64: FACGE Vd.2S, Vn.2S, Vm.2S
            // AbsoluteCompareLessThan(Vector128<Single>, Vector128<Single>)	uint32x4_t vcaltq_f32 (float32x4_t a, float32x4_t b); A32: VACLT.F32 Qd, Qn, Qm; A64: FACGT Vd.4S, Vn.4S, Vm.4S
            // AbsoluteCompareLessThan(Vector64<Single>, Vector64<Single>)	uint32x2_t vcalt_f32 (float32x2_t a, float32x2_t b); A32: VACLT.F32 Dd, Dn, Dm; A64: FACGT Vd.2S, Vn.2S, Vm.2S
            // AbsoluteCompareLessThanOrEqual(Vector128<Single>, Vector128<Single>)	uint32x4_t vcaleq_f32 (float32x4_t a, float32x4_t b); A32: VACLE.F32 Qd, Qn, Qm; A64: FACGE Vd.4S, Vn.4S, Vm.4S
            // AbsoluteCompareLessThanOrEqual(Vector64<Single>, Vector64<Single>)	uint32x2_t vcale_f32 (float32x2_t a, float32x2_t b); A32: VACLE.F32 Dd, Dn, Dm; A64: FACGE Vd.2S, Vn.2S, Vm.2S
            // AbsoluteDifference(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vabdq_u8 (uint8x16_t a, uint8x16_t b); A32: VABD.U8 Qd, Qn, Qm; A64: UABD Vd.16B, Vn.16B, Vm.16B
            // AbsoluteDifference(Vector128<Int16>, Vector128<Int16>)	int16x8_t vabdq_s16 (int16x8_t a, int16x8_t b); A32: VABD.S16 Qd, Qn, Qm; A64: SABD Vd.8H, Vn.8H, Vm.8H
            // AbsoluteDifference(Vector128<Int32>, Vector128<Int32>)	int32x4_t vabdq_s32 (int32x4_t a, int32x4_t b); A32: VABD.S32 Qd, Qn, Qm; A64: SABD Vd.4S, Vn.4S, Vm.4S
            // AbsoluteDifference(Vector128<SByte>, Vector128<SByte>)	int8x16_t vabdq_s8 (int8x16_t a, int8x16_t b); A32: VABD.S8 Qd, Qn, Qm; A64: SABD Vd.16B, Vn.16B, Vm.16B
            // AbsoluteDifference(Vector128<Single>, Vector128<Single>)	float32x4_t vabdq_f32 (float32x4_t a, float32x4_t b); A32: VABD.F32 Qd, Qn, Qm; A64: FABD Vd.4S, Vn.4S, Vm.4S
            // AbsoluteDifference(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vabdq_u16 (uint16x8_t a, uint16x8_t b); A32: VABD.U16 Qd, Qn, Qm; A64: UABD Vd.8H, Vn.8H, Vm.8H
            // AbsoluteDifference(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vabdq_u32 (uint32x4_t a, uint32x4_t b); A32: VABD.U32 Qd, Qn, Qm; A64: UABD Vd.4S, Vn.4S, Vm.4S
            // AbsoluteDifference(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vabd_u8 (uint8x8_t a, uint8x8_t b); A32: VABD.U8 Dd, Dn, Dm; A64: UABD Vd.8B, Vn.8B, Vm.8B
            // AbsoluteDifference(Vector64<Int16>, Vector64<Int16>)	int16x4_t vabd_s16 (int16x4_t a, int16x4_t b); A32: VABD.S16 Dd, Dn, Dm; A64: SABD Vd.4H, Vn.4H, Vm.4H
            // AbsoluteDifference(Vector64<Int32>, Vector64<Int32>)	int32x2_t vabd_s32 (int32x2_t a, int32x2_t b); A32: VABD.S32 Dd, Dn, Dm; A64: SABD Vd.2S, Vn.2S, Vm.2S
            // AbsoluteDifference(Vector64<SByte>, Vector64<SByte>)	int8x8_t vabd_s8 (int8x8_t a, int8x8_t b); A32: VABD.S8 Dd, Dn, Dm; A64: SABD Vd.8B, Vn.8B, Vm.8B
            // AbsoluteDifference(Vector64<Single>, Vector64<Single>)	float32x2_t vabd_f32 (float32x2_t a, float32x2_t b); A32: VABD.F32 Dd, Dn, Dm; A64: FABD Vd.2S, Vn.2S, Vm.2S
            // AbsoluteDifference(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vabd_u16 (uint16x4_t a, uint16x4_t b); A32: VABD.U16 Dd, Dn, Dm; A64: UABD Vd.4H, Vn.4H, Vm.4H
            // AbsoluteDifference(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vabd_u32 (uint32x2_t a, uint32x2_t b); A32: VABD.U32 Dd, Dn, Dm; A64: UABD Vd.2S, Vn.2S, Vm.2S
            // AbsoluteDifferenceAdd(Vector128<Byte>, Vector128<Byte>, Vector128<Byte>)	uint8x16_t vabaq_u8 (uint8x16_t a, uint8x16_t b, uint8x16_t c); A32: VABA.U8 Qd, Qn, Qm; A64: UABA Vd.16B, Vn.16B, Vm.16B
            // AbsoluteDifferenceAdd(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>)	int16x8_t vabaq_s16 (int16x8_t a, int16x8_t b, int16x8_t c); A32: VABA.S16 Qd, Qn, Qm; A64: SABA Vd.8H, Vn.8H, Vm.8H
            // AbsoluteDifferenceAdd(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>)	int32x4_t vabaq_s32 (int32x4_t a, int32x4_t b, int32x4_t c); A32: VABA.S32 Qd, Qn, Qm; A64: SABA Vd.4S, Vn.4S, Vm.4S
            // AbsoluteDifferenceAdd(Vector128<SByte>, Vector128<SByte>, Vector128<SByte>)	int8x16_t vabaq_s8 (int8x16_t a, int8x16_t b, int8x16_t c); A32: VABA.S8 Qd, Qn, Qm; A64: SABA Vd.16B, Vn.16B, Vm.16B
            // AbsoluteDifferenceAdd(Vector128<UInt16>, Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vabaq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t c); A32: VABA.U16 Qd, Qn, Qm; A64: UABA Vd.8H, Vn.8H, Vm.8H
            // AbsoluteDifferenceAdd(Vector128<UInt32>, Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vabaq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t c); A32: VABA.U32 Qd, Qn, Qm; A64: UABA Vd.4S, Vn.4S, Vm.4S
            // AbsoluteDifferenceAdd(Vector64<Byte>, Vector64<Byte>, Vector64<Byte>)	uint8x8_t vaba_u8 (uint8x8_t a, uint8x8_t b, uint8x8_t c); A32: VABA.U8 Dd, Dn, Dm; A64: UABA Vd.8B, Vn.8B, Vm.8B
            // AbsoluteDifferenceAdd(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16x4_t vaba_s16 (int16x4_t a, int16x4_t b, int16x4_t c); A32: VABA.S16 Dd, Dn, Dm; A64: SABA Vd.4H, Vn.4H, Vm.4H
            // AbsoluteDifferenceAdd(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32x2_t vaba_s32 (int32x2_t a, int32x2_t b, int32x2_t c); A32: VABA.S32 Dd, Dn, Dm; A64: SABA Vd.2S, Vn.2S, Vm.2S
            // AbsoluteDifferenceAdd(Vector64<SByte>, Vector64<SByte>, Vector64<SByte>)	int8x8_t vaba_s8 (int8x8_t a, int8x8_t b, int8x8_t c); A32: VABA.S8 Dd, Dn, Dm; A64: SABA Vd.8B, Vn.8B, Vm.8B
            // AbsoluteDifferenceAdd(Vector64<UInt16>, Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vaba_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t c); A32: VABA.U16 Dd, Dn, Dm; A64: UABA Vd.4H, Vn.4H, Vm.4H
            // AbsoluteDifferenceAdd(Vector64<UInt32>, Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vaba_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t c); A32: VABA.U32 Dd, Dn, Dm; A64: UABA Vd.2S, Vn.2S, Vm.2S
            // AbsoluteDifferenceWideningLower(Vector64<Byte>, Vector64<Byte>)	uint16x8_t vabdl_u8 (uint8x8_t a, uint8x8_t b); A32: VABDL.U8 Qd, Dn, Dm; A64: UABDL Vd.8H, Vn.8B, Vm.8B
            // AbsoluteDifferenceWideningLower(Vector64<Int16>, Vector64<Int16>)	int32x4_t vabdl_s16 (int16x4_t a, int16x4_t b); A32: VABDL.S16 Qd, Dn, Dm; A64: SABDL Vd.4S, Vn.4H, Vm.4H
            // AbsoluteDifferenceWideningLower(Vector64<Int32>, Vector64<Int32>)	int64x2_t vabdl_s32 (int32x2_t a, int32x2_t b); A32: VABDL.S32 Qd, Dn, Dm; A64: SABDL Vd.2D, Vn.2S, Vm.2S
            // AbsoluteDifferenceWideningLower(Vector64<SByte>, Vector64<SByte>)	int16x8_t vabdl_s8 (int8x8_t a, int8x8_t b); A32: VABDL.S8 Qd, Dn, Dm; A64: SABDL Vd.8H, Vn.8B, Vm.8B
            // AbsoluteDifferenceWideningLower(Vector64<UInt16>, Vector64<UInt16>)	uint32x4_t vabdl_u16 (uint16x4_t a, uint16x4_t b); A32: VABDL.U16 Qd, Dn, Dm; A64: UABDL Vd.4S, Vn.4H, Vm.4H
            // AbsoluteDifferenceWideningLower(Vector64<UInt32>, Vector64<UInt32>)	uint64x2_t vabdl_u32 (uint32x2_t a, uint32x2_t b); A32: VABDL.U32 Qd, Dn, Dm; A64: UABDL Vd.2D, Vn.2S, Vm.2S
            // AbsoluteDifferenceWideningLowerAndAdd(Vector128<Int16>, Vector64<SByte>, Vector64<SByte>)	int16x8_t vabal_s8 (int16x8_t a, int8x8_t b, int8x8_t c); A32: VABAL.S8 Qd, Dn, Dm; A64: SABAL Vd.8H, Vn.8B, Vm.8B
            // AbsoluteDifferenceWideningLowerAndAdd(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>)	int32x4_t vabal_s16 (int32x4_t a, int16x4_t b, int16x4_t c); A32: VABAL.S16 Qd, Dn, Dm; A64: SABAL Vd.4S, Vn.4H, Vm.4H
            // AbsoluteDifferenceWideningLowerAndAdd(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>)	int64x2_t vabal_s32 (int64x2_t a, int32x2_t b, int32x2_t c); A32: VABAL.S32 Qd, Dn, Dm; A64: SABAL Vd.2D, Vn.2S, Vm.2S
            // AbsoluteDifferenceWideningLowerAndAdd(Vector128<UInt16>, Vector64<Byte>, Vector64<Byte>)	uint16x8_t vabal_u8 (uint16x8_t a, uint8x8_t b, uint8x8_t c); A32: VABAL.U8 Qd, Dn, Dm; A64: UABAL Vd.8H, Vn.8B, Vm.8B
            // AbsoluteDifferenceWideningLowerAndAdd(Vector128<UInt32>, Vector64<UInt16>, Vector64<UInt16>)	uint32x4_t vabal_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t c); A32: VABAL.U16 Qd, Dn, Dm; A64: UABAL Vd.4S, Vn.4H, Vm.4H
            // AbsoluteDifferenceWideningLowerAndAdd(Vector128<UInt64>, Vector64<UInt32>, Vector64<UInt32>)	uint64x2_t vabal_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t c); A32: VABAL.U32 Qd, Dn, Dm; A64: UABAL Vd.2D, Vn.2S, Vm.2S
            // AbsoluteDifferenceWideningUpper(Vector128<Byte>, Vector128<Byte>)	uint16x8_t vabdl_high_u8 (uint8x16_t a, uint8x16_t b); A32: VABDL.U8 Qd, Dn+1, Dm+1; A64: UABDL2 Vd.8H, Vn.16B, Vm.16B
            // AbsoluteDifferenceWideningUpper(Vector128<Int16>, Vector128<Int16>)	int32x4_t vabdl_high_s16 (int16x8_t a, int16x8_t b); A32: VABDL.S16 Qd, Dn+1, Dm+1; A64: SABDL2 Vd.4S, Vn.8H, Vm.8H
            // AbsoluteDifferenceWideningUpper(Vector128<Int32>, Vector128<Int32>)	int64x2_t vabdl_high_s32 (int32x4_t a, int32x4_t b); A32: VABDL.S32 Qd, Dn+1, Dm+1; A64: SABDL2 Vd.2D, Vn.4S, Vm.4S
            // AbsoluteDifferenceWideningUpper(Vector128<SByte>, Vector128<SByte>)	int16x8_t vabdl_high_s8 (int8x16_t a, int8x16_t b); A32: VABDL.S8 Qd, Dn+1, Dm+1; A64: SABDL2 Vd.8H, Vn.16B, Vm.16B
            // AbsoluteDifferenceWideningUpper(Vector128<UInt16>, Vector128<UInt16>)	uint32x4_t vabdl_high_u16 (uint16x8_t a, uint16x8_t b); A32: VABDL.U16 Qd, Dn+1, Dm+1; A64: UABDL2 Vd.4S, Vn.8H, Vm.8H
            // AbsoluteDifferenceWideningUpper(Vector128<UInt32>, Vector128<UInt32>)	uint64x2_t vabdl_high_u32 (uint32x4_t a, uint32x4_t b); A32: VABDL.U32 Qd, Dn+1, Dm+1; A64: UABDL2 Vd.2D, Vn.4S, Vm.4S
            // AbsoluteDifferenceWideningUpperAndAdd(Vector128<Int16>, Vector128<SByte>, Vector128<SByte>)	int16x8_t vabal_high_s8 (int16x8_t a, int8x16_t b, int8x16_t c); A32: VABAL.S8 Qd, Dn+1, Dm+1; A64: SABAL2 Vd.8H, Vn.16B, Vm.16B
            // AbsoluteDifferenceWideningUpperAndAdd(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>)	int32x4_t vabal_high_s16 (int32x4_t a, int16x8_t b, int16x8_t c); A32: VABAL.S16 Qd, Dn+1, Dm+1; A64: SABAL2 Vd.4S, Vn.8H, Vm.8H
            // AbsoluteDifferenceWideningUpperAndAdd(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>)	int64x2_t vabal_high_s32 (int64x2_t a, int32x4_t b, int32x4_t c); A32: VABAL.S32 Qd, Dn+1, Dm+1; A64: SABAL2 Vd.2D, Vn.4S, Vm.4S
            // AbsoluteDifferenceWideningUpperAndAdd(Vector128<UInt16>, Vector128<Byte>, Vector128<Byte>)	uint16x8_t vabal_high_u8 (uint16x8_t a, uint8x16_t b, uint8x16_t c); A32: VABAL.U8 Qd, Dn+1, Dm+1; A64: UABAL2 Vd.8H, Vn.16B, Vm.16B
            // AbsoluteDifferenceWideningUpperAndAdd(Vector128<UInt32>, Vector128<UInt16>, Vector128<UInt16>)	uint32x4_t vabal_high_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t c); A32: VABAL.U16 Qd, Dn+1, Dm+1; A64: UABAL2 Vd.4S, Vn.8H, Vm.8H
            // AbsoluteDifferenceWideningUpperAndAdd(Vector128<UInt64>, Vector128<UInt32>, Vector128<UInt32>)	uint64x2_t vabal_high_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t c); A32: VABAL.U32 Qd, Dn+1, Dm+1; A64: UABAL2 Vd.2D, Vn.4S, Vm.4S
            // AbsSaturate(Vector128<Int16>)	int16x8_t vqabsq_s16 (int16x8_t a); A32: VQABS.S16 Qd, Qm; A64: SQABS Vd.8H, Vn.8H
            // AbsSaturate(Vector128<Int32>)	int32x4_t vqabsq_s32 (int32x4_t a); A32: VQABS.S32 Qd, Qm; A64: SQABS Vd.4S, Vn.4S
            // AbsSaturate(Vector128<SByte>)	int8x16_t vqabsq_s8 (int8x16_t a); A32: VQABS.S8 Qd, Qm; A64: SQABS Vd.16B, Vn.16B
            // AbsSaturate(Vector64<Int16>)	int16x4_t vqabs_s16 (int16x4_t a); A32: VQABS.S16 Dd, Dm; A64: SQABS Vd.4H, Vn.4H
            // AbsSaturate(Vector64<Int32>)	int32x2_t vqabs_s32 (int32x2_t a); A32: VQABS.S32 Dd, Dm; A64: SQABS Vd.2S, Vn.2S
            // AbsSaturate(Vector64<SByte>)	int8x8_t vqabs_s8 (int8x8_t a); A32: VQABS.S8 Dd, Dm; A64: SQABS Vd.8B, Vn.8B
            // AbsScalar(Vector64<Double>)	float64x1_t vabs_f64 (float64x1_t a); A32: VABS.F64 Dd, Dm; A64: FABS Dd, Dn
            // AbsScalar(Vector64<Single>)	float32_t vabss_f32 (float32_t a); A32: VABS.F32 Sd, Sm; A64: FABS Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Add(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vaddq_u8 (uint8x16_t a, uint8x16_t b); A32: VADD.I8 Qd, Qn, Qm; A64: ADD Vd.16B, Vn.16B, Vm.16B
            // Add(Vector128<Int16>, Vector128<Int16>)	int16x8_t vaddq_s16 (int16x8_t a, int16x8_t b); A32: VADD.I16 Qd, Qn, Qm; A64: ADD Vd.8H, Vn.8H, Vm.8H
            // Add(Vector128<Int32>, Vector128<Int32>)	int32x4_t vaddq_s32 (int32x4_t a, int32x4_t b); A32: VADD.I32 Qd, Qn, Qm; A64: ADD Vd.4S, Vn.4S, Vm.4S
            // Add(Vector128<Int64>, Vector128<Int64>)	int64x2_t vaddq_s64 (int64x2_t a, int64x2_t b); A32: VADD.I64 Qd, Qn, Qm; A64: ADD Vd.2D, Vn.2D, Vm.2D
            // Add(Vector128<SByte>, Vector128<SByte>)	int8x16_t vaddq_s8 (int8x16_t a, int8x16_t b); A32: VADD.I8 Qd, Qn, Qm; A64: ADD Vd.16B, Vn.16B, Vm.16B
            // Add(Vector128<Single>, Vector128<Single>)	float32x4_t vaddq_f32 (float32x4_t a, float32x4_t b); A32: VADD.F32 Qd, Qn, Qm; A64: FADD Vd.4S, Vn.4S, Vm.4S
            // Add(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vaddq_u16 (uint16x8_t a, uint16x8_t b); A32: VADD.I16 Qd, Qn, Qm; A64: ADD Vd.8H, Vn.8H, Vm.8H
            // Add(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vaddq_u32 (uint32x4_t a, uint32x4_t b); A32: VADD.I32 Qd, Qn, Qm; A64: ADD Vd.4S, Vn.4S, Vm.4S
            // Add(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vaddq_u64 (uint64x2_t a, uint64x2_t b); A32: VADD.I64 Qd, Qn, Qm; A64: ADD Vd.2D, Vn.2D, Vm.2D
            // Add(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vadd_u8 (uint8x8_t a, uint8x8_t b); A32: VADD.I8 Dd, Dn, Dm; A64: ADD Vd.8B, Vn.8B, Vm.8B
            // Add(Vector64<Int16>, Vector64<Int16>)	int16x4_t vadd_s16 (int16x4_t a, int16x4_t b); A32: VADD.I16 Dd, Dn, Dm; A64: ADD Vd.4H, Vn.4H, Vm.4H
            // Add(Vector64<Int32>, Vector64<Int32>)	int32x2_t vadd_s32 (int32x2_t a, int32x2_t b); A32: VADD.I32 Dd, Dn, Dm; A64: ADD Vd.2S, Vn.2S, Vm.2S
            // Add(Vector64<SByte>, Vector64<SByte>)	int8x8_t vadd_s8 (int8x8_t a, int8x8_t b); A32: VADD.I8 Dd, Dn, Dm; A64: ADD Vd.8B, Vn.8B, Vm.8B
            // Add(Vector64<Single>, Vector64<Single>)	float32x2_t vadd_f32 (float32x2_t a, float32x2_t b); A32: VADD.F32 Dd, Dn, Dm; A64: FADD Vd.2S, Vn.2S, Vm.2S
            // Add(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vadd_u16 (uint16x4_t a, uint16x4_t b); A32: VADD.I16 Dd, Dn, Dm; A64: ADD Vd.4H, Vn.4H, Vm.4H
            // Add(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vadd_u32 (uint32x2_t a, uint32x2_t b); A32: VADD.I32 Dd, Dn, Dm; A64: ADD Vd.2S, Vn.2S, Vm.2S
            // AddHighNarrowingLower(Vector128<Int16>, Vector128<Int16>)	int8x8_t vaddhn_s16 (int16x8_t a, int16x8_t b); A32: VADDHN.I16 Dd, Qn, Qm; A64: ADDHN Vd.8B, Vn.8H, Vm.8H
            // AddHighNarrowingLower(Vector128<Int32>, Vector128<Int32>)	int16x4_t vaddhn_s32 (int32x4_t a, int32x4_t b); A32: VADDHN.I32 Dd, Qn, Qm; A64: ADDHN Vd.4H, Vn.4S, Vm.4S
            // AddHighNarrowingLower(Vector128<Int64>, Vector128<Int64>)	int32x2_t vaddhn_s64 (int64x2_t a, int64x2_t b); A32: VADDHN.I64 Dd, Qn, Qm; A64: ADDHN Vd.2S, Vn.2D, Vm.2D
            // AddHighNarrowingLower(Vector128<UInt16>, Vector128<UInt16>)	uint8x8_t vaddhn_u16 (uint16x8_t a, uint16x8_t b); A32: VADDHN.I16 Dd, Qn, Qm; A64: ADDHN Vd.8B, Vn.8H, Vm.8H
            // AddHighNarrowingLower(Vector128<UInt32>, Vector128<UInt32>)	uint16x4_t vaddhn_u32 (uint32x4_t a, uint32x4_t b); A32: VADDHN.I32 Dd, Qn, Qm; A64: ADDHN Vd.4H, Vn.4S, Vm.4S
            // AddHighNarrowingLower(Vector128<UInt64>, Vector128<UInt64>)	uint32x2_t vaddhn_u64 (uint64x2_t a, uint64x2_t b); A32: VADDHN.I64 Dd, Qn, Qm; A64: ADDHN Vd.2S, Vn.2D, Vm.2D
            // AddHighNarrowingUpper(Vector64<Byte>, Vector128<UInt16>, Vector128<UInt16>)	uint8x16_t vaddhn_high_u16 (uint8x8_t r, uint16x8_t a, uint16x8_t b); A32: VADDHN.I16 Dd+1, Qn, Qm; A64: ADDHN2 Vd.16B, Vn.8H, Vm.8H
            // AddHighNarrowingUpper(Vector64<Int16>, Vector128<Int32>, Vector128<Int32>)	int16x8_t vaddhn_high_s32 (int16x4_t r, int32x4_t a, int32x4_t b); A32: VADDHN.I32 Dd+1, Qn, Qm; A64: ADDHN2 Vd.8H, Vn.4S, Vm.4S
            // AddHighNarrowingUpper(Vector64<Int32>, Vector128<Int64>, Vector128<Int64>)	int32x4_t vaddhn_high_s64 (int32x2_t r, int64x2_t a, int64x2_t b); A32: VADDHN.I64 Dd+1, Qn, Qm; A64: ADDHN2 Vd.4S, Vn.2D, Vm.2D
            // AddHighNarrowingUpper(Vector64<SByte>, Vector128<Int16>, Vector128<Int16>)	int8x16_t vaddhn_high_s16 (int8x8_t r, int16x8_t a, int16x8_t b); A32: VADDHN.I16 Dd+1, Qn, Qm; A64: ADDHN2 Vd.16B, Vn.8H, Vm.8H
            // AddHighNarrowingUpper(Vector64<UInt16>, Vector128<UInt32>, Vector128<UInt32>)	uint16x8_t vaddhn_high_u32 (uint16x4_t r, uint32x4_t a, uint32x4_t b); A32: VADDHN.I32 Dd+1, Qn, Qm; A64: ADDHN2 Vd.8H, Vn.4S, Vm.4S
            // AddHighNarrowingUpper(Vector64<UInt32>, Vector128<UInt64>, Vector128<UInt64>)	uint32x4_t vaddhn_high_u64 (uint32x2_t r, uint64x2_t a, uint64x2_t b); A32: VADDHN.I64 Dd+1, Qn, Qm; A64: ADDHN2 Vd.4S, Vn.2D, Vm.2D
            // AddPairwise(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vpadd_u8 (uint8x8_t a, uint8x8_t b); A32: VPADD.I8 Dd, Dn, Dm; A64: ADDP Vd.8B, Vn.8B, Vm.8B
            // AddPairwise(Vector64<Int16>, Vector64<Int16>)	int16x4_t vpadd_s16 (int16x4_t a, int16x4_t b); A32: VPADD.I16 Dd, Dn, Dm; A64: ADDP Vd.4H, Vn.4H, Vm.4H
            // AddPairwise(Vector64<Int32>, Vector64<Int32>)	int32x2_t vpadd_s32 (int32x2_t a, int32x2_t b); A32: VPADD.I32 Dd, Dn, Dm; A64: ADDP Vd.2S, Vn.2S, Vm.2S
            // AddPairwise(Vector64<SByte>, Vector64<SByte>)	int8x8_t vpadd_s8 (int8x8_t a, int8x8_t b); A32: VPADD.I8 Dd, Dn, Dm; A64: ADDP Vd.8B, Vn.8B, Vm.8B
            // AddPairwise(Vector64<Single>, Vector64<Single>)	float32x2_t vpadd_f32 (float32x2_t a, float32x2_t b); A32: VPADD.F32 Dd, Dn, Dm; A64: FADDP Vd.2S, Vn.2S, Vm.2S
            // AddPairwise(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vpadd_u16 (uint16x4_t a, uint16x4_t b); A32: VPADD.I16 Dd, Dn, Dm; A64: ADDP Vd.4H, Vn.4H, Vm.4H
            // AddPairwise(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vpadd_u32 (uint32x2_t a, uint32x2_t b); A32: VPADD.I32 Dd, Dn, Dm; A64: ADDP Vd.2S, Vn.2S, Vm.2S
            // AddPairwiseWidening(Vector128<Byte>)	uint16x8_t vpaddlq_u8 (uint8x16_t a); A32: VPADDL.U8 Qd, Qm; A64: UADDLP Vd.8H, Vn.16B
            // AddPairwiseWidening(Vector128<Int16>)	int32x4_t vpaddlq_s16 (int16x8_t a); A32: VPADDL.S16 Qd, Qm; A64: SADDLP Vd.4S, Vn.8H
            // AddPairwiseWidening(Vector128<Int32>)	int64x2_t vpaddlq_s32 (int32x4_t a); A32: VPADDL.S32 Qd, Qm; A64: SADDLP Vd.2D, Vn.4S
            // AddPairwiseWidening(Vector128<SByte>)	int16x8_t vpaddlq_s8 (int8x16_t a); A32: VPADDL.S8 Qd, Qm; A64: SADDLP Vd.8H, Vn.16B
            // AddPairwiseWidening(Vector128<UInt16>)	uint32x4_t vpaddlq_u16 (uint16x8_t a); A32: VPADDL.U16 Qd, Qm; A64: UADDLP Vd.4S, Vn.8H
            // AddPairwiseWidening(Vector128<UInt32>)	uint64x2_t vpaddlq_u32 (uint32x4_t a); A32: VPADDL.U32 Qd, Qm; A64: UADDLP Vd.2D, Vn.4S
            // AddPairwiseWidening(Vector64<Byte>)	uint16x4_t vpaddl_u8 (uint8x8_t a); A32: VPADDL.U8 Dd, Dm; A64: UADDLP Vd.4H, Vn.8B
            // AddPairwiseWidening(Vector64<Int16>)	int32x2_t vpaddl_s16 (int16x4_t a); A32: VPADDL.S16 Dd, Dm; A64: SADDLP Vd.2S, Vn.4H
            // AddPairwiseWidening(Vector64<SByte>)	int16x4_t vpaddl_s8 (int8x8_t a); A32: VPADDL.S8 Dd, Dm; A64: SADDLP Vd.4H, Vn.8B
            // AddPairwiseWidening(Vector64<UInt16>)	uint32x2_t vpaddl_u16 (uint16x4_t a); A32: VPADDL.U16 Dd, Dm; A64: UADDLP Vd.2S, Vn.4H
            // AddPairwiseWideningAndAdd(Vector128<Int16>, Vector128<SByte>)	int16x8_t vpadalq_s8 (int16x8_t a, int8x16_t b); A32: VPADAL.S8 Qd, Qm; A64: SADALP Vd.8H, Vn.16B
            // AddPairwiseWideningAndAdd(Vector128<Int32>, Vector128<Int16>)	int32x4_t vpadalq_s16 (int32x4_t a, int16x8_t b); A32: VPADAL.S16 Qd, Qm; A64: SADALP Vd.4S, Vn.8H
            // AddPairwiseWideningAndAdd(Vector128<Int64>, Vector128<Int32>)	int64x2_t vpadalq_s32 (int64x2_t a, int32x4_t b); A32: VPADAL.S32 Qd, Qm; A64: SADALP Vd.2D, Vn.4S
            // AddPairwiseWideningAndAdd(Vector128<UInt16>, Vector128<Byte>)	uint16x8_t vpadalq_u8 (uint16x8_t a, uint8x16_t b); A32: VPADAL.U8 Qd, Qm; A64: UADALP Vd.8H, Vn.16B
            // AddPairwiseWideningAndAdd(Vector128<UInt32>, Vector128<UInt16>)	uint32x4_t vpadalq_u16 (uint32x4_t a, uint16x8_t b); A32: VPADAL.U16 Qd, Qm; A64: UADALP Vd.4S, Vn.8H
            // AddPairwiseWideningAndAdd(Vector128<UInt64>, Vector128<UInt32>)	uint64x2_t vpadalq_u32 (uint64x2_t a, uint32x4_t b); A32: VPADAL.U32 Qd, Qm; A64: UADALP Vd.2D, Vn.4S
            // AddPairwiseWideningAndAdd(Vector64<Int16>, Vector64<SByte>)	int16x4_t vpadal_s8 (int16x4_t a, int8x8_t b); A32: VPADAL.S8 Dd, Dm; A64: SADALP Vd.4H, Vn.8B
            // AddPairwiseWideningAndAdd(Vector64<Int32>, Vector64<Int16>)	int32x2_t vpadal_s16 (int32x2_t a, int16x4_t b); A32: VPADAL.S16 Dd, Dm; A64: SADALP Vd.2S, Vn.4H
            // AddPairwiseWideningAndAdd(Vector64<UInt16>, Vector64<Byte>)	uint16x4_t vpadal_u8 (uint16x4_t a, uint8x8_t b); A32: VPADAL.U8 Dd, Dm; A64: UADALP Vd.4H, Vn.8B
            // AddPairwiseWideningAndAdd(Vector64<UInt32>, Vector64<UInt16>)	uint32x2_t vpadal_u16 (uint32x2_t a, uint16x4_t b); A32: VPADAL.U16 Dd, Dm; A64: UADALP Vd.2S, Vn.4H
            // AddPairwiseWideningAndAddScalar(Vector64<Int64>, Vector64<Int32>)	int64x1_t vpadal_s32 (int64x1_t a, int32x2_t b); A32: VPADAL.S32 Dd, Dm; A64: SADALP Vd.1D, Vn.2S
            // AddPairwiseWideningAndAddScalar(Vector64<UInt64>, Vector64<UInt32>)	uint64x1_t vpadal_u32 (uint64x1_t a, uint32x2_t b); A32: VPADAL.U32 Dd, Dm; A64: UADALP Vd.1D, Vn.2S
            // AddPairwiseWideningScalar(Vector64<Int32>)	int64x1_t vpaddl_s32 (int32x2_t a); A32: VPADDL.S32 Dd, Dm; A64: SADDLP Dd, Vn.2S
            // AddPairwiseWideningScalar(Vector64<UInt32>)	uint64x1_t vpaddl_u32 (uint32x2_t a); A32: VPADDL.U32 Dd, Dm; A64: UADDLP Dd, Vn.2S
            // AddRoundedHighNarrowingLower(Vector128<Int16>, Vector128<Int16>)	int8x8_t vraddhn_s16 (int16x8_t a, int16x8_t b); A32: VRADDHN.I16 Dd, Qn, Qm; A64: RADDHN Vd.8B, Vn.8H, Vm.8H
            // AddRoundedHighNarrowingLower(Vector128<Int32>, Vector128<Int32>)	int16x4_t vraddhn_s32 (int32x4_t a, int32x4_t b); A32: VRADDHN.I32 Dd, Qn, Qm; A64: RADDHN Vd.4H, Vn.4S, Vm.4S
            // AddRoundedHighNarrowingLower(Vector128<Int64>, Vector128<Int64>)	int32x2_t vraddhn_s64 (int64x2_t a, int64x2_t b); A32: VRADDHN.I64 Dd, Qn, Qm; A64: RADDHN Vd.2S, Vn.2D, Vm.2D
            // AddRoundedHighNarrowingLower(Vector128<UInt16>, Vector128<UInt16>)	uint8x8_t vraddhn_u16 (uint16x8_t a, uint16x8_t b); A32: VRADDHN.I16 Dd, Qn, Qm; A64: RADDHN Vd.8B, Vn.8H, Vm.8H
            // AddRoundedHighNarrowingLower(Vector128<UInt32>, Vector128<UInt32>)	uint16x4_t vraddhn_u32 (uint32x4_t a, uint32x4_t b); A32: VRADDHN.I32 Dd, Qn, Qm; A64: RADDHN Vd.4H, Vn.4S, Vm.4S
            // AddRoundedHighNarrowingLower(Vector128<UInt64>, Vector128<UInt64>)	uint32x2_t vraddhn_u64 (uint64x2_t a, uint64x2_t b); A32: VRADDHN.I64 Dd, Qn, Qm; A64: RADDHN Vd.2S, Vn.2D, Vm.2D
            // AddRoundedHighNarrowingUpper(Vector64<Byte>, Vector128<UInt16>, Vector128<UInt16>)	uint8x16_t vraddhn_high_u16 (uint8x8_t r, uint16x8_t a, uint16x8_t b); A32: VRADDHN.I16 Dd+1, Qn, Qm; A64: RADDHN2 Vd.16B, Vn.8H, Vm.8H
            // AddRoundedHighNarrowingUpper(Vector64<Int16>, Vector128<Int32>, Vector128<Int32>)	int16x8_t vraddhn_high_s32 (int16x4_t r, int32x4_t a, int32x4_t b); A32: VRADDHN.I32 Dd+1, Qn, Qm; A64: RADDHN2 Vd.8H, Vn.4S, Vm.4S
            // AddRoundedHighNarrowingUpper(Vector64<Int32>, Vector128<Int64>, Vector128<Int64>)	int32x4_t vraddhn_high_s64 (int32x2_t r, int64x2_t a, int64x2_t b); A32: VRADDHN.I64 Dd+1, Qn, Qm; A64: RADDHN2 Vd.4S, Vn.2D, Vm.2D
            // AddRoundedHighNarrowingUpper(Vector64<SByte>, Vector128<Int16>, Vector128<Int16>)	int8x16_t vraddhn_high_s16 (int8x8_t r, int16x8_t a, int16x8_t b); A32: VRADDHN.I16 Dd+1, Qn, Qm; A64: RADDHN2 Vd.16B, Vn.8H, Vm.8H
            // AddRoundedHighNarrowingUpper(Vector64<UInt16>, Vector128<UInt32>, Vector128<UInt32>)	uint16x8_t vraddhn_high_u32 (uint16x4_t r, uint32x4_t a, uint32x4_t b); A32: VRADDHN.I32 Dd+1, Qn, Qm; A64: RADDHN2 Vd.8H, Vn.4S, Vm.4S
            // AddRoundedHighNarrowingUpper(Vector64<UInt32>, Vector128<UInt64>, Vector128<UInt64>)	uint32x4_t vraddhn_high_u64 (uint32x2_t r, uint64x2_t a, uint64x2_t b); A32: VRADDHN.I64 Dd+1, Qn, Qm; A64: RADDHN2 Vd.4S, Vn.2D, Vm.2D
            // AddSaturate(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vqaddq_u8 (uint8x16_t a, uint8x16_t b); A32: VQADD.U8 Qd, Qn, Qm; A64: UQADD Vd.16B, Vn.16B, Vm.16B
            // AddSaturate(Vector128<Int16>, Vector128<Int16>)	int16x8_t vqaddq_s16 (int16x8_t a, int16x8_t b); A32: VQADD.S16 Qd, Qn, Qm; A64: SQADD Vd.8H, Vn.8H, Vm.8H
            // AddSaturate(Vector128<Int32>, Vector128<Int32>)	int32x4_t vqaddq_s32 (int32x4_t a, int32x4_t b); A32: VQADD.S32 Qd, Qn, Qm; A64: SQADD Vd.4S, Vn.4S, Vm.4S
            // AddSaturate(Vector128<Int64>, Vector128<Int64>)	int64x2_t vqaddq_s64 (int64x2_t a, int64x2_t b); A32: VQADD.S64 Qd, Qn, Qm; A64: SQADD Vd.2D, Vn.2D, Vm.2D
            // AddSaturate(Vector128<SByte>, Vector128<SByte>)	int8x16_t vqaddq_s8 (int8x16_t a, int8x16_t b); A32: VQADD.S8 Qd, Qn, Qm; A64: SQADD Vd.16B, Vn.16B, Vm.16B
            // AddSaturate(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vqaddq_u16 (uint16x8_t a, uint16x8_t b); A32: VQADD.U16 Qd, Qn, Qm; A64: UQADD Vd.8H, Vn.8H, Vm.8H
            // AddSaturate(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vqaddq_u32 (uint32x4_t a, uint32x4_t b); A32: VQADD.U32 Qd, Qn, Qm; A64: UQADD Vd.4S, Vn.4S, Vm.4S
            // AddSaturate(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vqaddq_u64 (uint64x2_t a, uint64x2_t b); A32: VQADD.U64 Qd, Qn, Qm; A64: UQADD Vd.2D, Vn.2D, Vm.2D
            // AddSaturate(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vqadd_u8 (uint8x8_t a, uint8x8_t b); A32: VQADD.U8 Dd, Dn, Dm; A64: UQADD Vd.8B, Vn.8B, Vm.8B
            // AddSaturate(Vector64<Int16>, Vector64<Int16>)	int16x4_t vqadd_s16 (int16x4_t a, int16x4_t b); A32: VQADD.S16 Dd, Dn, Dm; A64: SQADD Vd.4H, Vn.4H, Vm.4H
            // AddSaturate(Vector64<Int32>, Vector64<Int32>)	int32x2_t vqadd_s32 (int32x2_t a, int32x2_t b); A32: VQADD.S32 Dd, Dn, Dm; A64: SQADD Vd.2S, Vn.2S, Vm.2S
            // AddSaturate(Vector64<SByte>, Vector64<SByte>)	int8x8_t vqadd_s8 (int8x8_t a, int8x8_t b); A32: VQADD.S8 Dd, Dn, Dm; A64: SQADD Vd.8B, Vn.8B, Vm.8B
            // AddSaturate(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vqadd_u16 (uint16x4_t a, uint16x4_t b); A32: VQADD.U16 Dd, Dn, Dm; A64: UQADD Vd.4H, Vn.4H, Vm.4H
            // AddSaturate(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vqadd_u32 (uint32x2_t a, uint32x2_t b); A32: VQADD.U32 Dd, Dn, Dm; A64: UQADD Vd.2S, Vn.2S, Vm.2S
            // AddSaturateScalar(Vector64<Int64>, Vector64<Int64>)	int64x1_t vqadd_s64 (int64x1_t a, int64x1_t b); A32: VQADD.S64 Dd, Dn, Dm; A64: SQADD Dd, Dn, Dm
            // AddSaturateScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vqadd_u64 (uint64x1_t a, uint64x1_t b); A32: VQADD.U64 Dd, Dn, Dm; A64: UQADD Dd, Dn, Dm
            // AddScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vadd_f64 (float64x1_t a, float64x1_t b); A32: VADD.F64 Dd, Dn, Dm; A64: FADD Dd, Dn, Dm
            // AddScalar(Vector64<Int64>, Vector64<Int64>)	int64x1_t vadd_s64 (int64x1_t a, int64x1_t b); A32: VADD.I64 Dd, Dn, Dm; A64: ADD Dd, Dn, Dm
            // AddScalar(Vector64<Single>, Vector64<Single>)	float32_t vadds_f32 (float32_t a, float32_t b); A32: VADD.F32 Sd, Sn, Sm; A64: FADD Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // AddScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vadd_u64 (uint64x1_t a, uint64x1_t b); A32: VADD.I64 Dd, Dn, Dm; A64: ADD Dd, Dn, Dm
            // AddWideningLower(Vector128<Int16>, Vector64<SByte>)	int16x8_t vaddw_s8 (int16x8_t a, int8x8_t b); A32: VADDW.S8 Qd, Qn, Dm; A64: SADDW Vd.8H, Vn.8H, Vm.8B
            // AddWideningLower(Vector128<Int32>, Vector64<Int16>)	int32x4_t vaddw_s16 (int32x4_t a, int16x4_t b); A32: VADDW.S16 Qd, Qn, Dm; A64: SADDW Vd.4S, Vn.4S, Vm.4H
            // AddWideningLower(Vector128<Int64>, Vector64<Int32>)	int64x2_t vaddw_s32 (int64x2_t a, int32x2_t b); A32: VADDW.S32 Qd, Qn, Dm; A64: SADDW Vd.2D, Vn.2D, Vm.2S
            // AddWideningLower(Vector128<UInt16>, Vector64<Byte>)	uint16x8_t vaddw_u8 (uint16x8_t a, uint8x8_t b); A32: VADDW.U8 Qd, Qn, Dm; A64: UADDW Vd.8H, Vn.8H, Vm.8B
            // AddWideningLower(Vector128<UInt32>, Vector64<UInt16>)	uint32x4_t vaddw_u16 (uint32x4_t a, uint16x4_t b); A32: VADDW.U16 Qd, Qn, Dm; A64: UADDW Vd.4S, Vn.4S, Vm.4H
            // AddWideningLower(Vector128<UInt64>, Vector64<UInt32>)	uint64x2_t vaddw_u32 (uint64x2_t a, uint32x2_t b); A32: VADDW.U32 Qd, Qn, Dm; A64: UADDW Vd.2D, Vn.2D, Vm.2S
            // AddWideningLower(Vector64<Byte>, Vector64<Byte>)	uint16x8_t vaddl_u8 (uint8x8_t a, uint8x8_t b); A32: VADDL.U8 Qd, Dn, Dm; A64: UADDL Vd.8H, Vn.8B, Vm.8B
            // AddWideningLower(Vector64<Int16>, Vector64<Int16>)	int32x4_t vaddl_s16 (int16x4_t a, int16x4_t b); A32: VADDL.S16 Qd, Dn, Dm; A64: SADDL Vd.4S, Vn.4H, Vm.4H
            // AddWideningLower(Vector64<Int32>, Vector64<Int32>)	int64x2_t vaddl_s32 (int32x2_t a, int32x2_t b); A32: VADDL.S32 Qd, Dn, Dm; A64: SADDL Vd.2D, Vn.2S, Vm.2S
            // AddWideningLower(Vector64<SByte>, Vector64<SByte>)	int16x8_t vaddl_s8 (int8x8_t a, int8x8_t b); A32: VADDL.S8 Qd, Dn, Dm; A64: SADDL Vd.8H, Vn.8B, Vm.8B
            // AddWideningLower(Vector64<UInt16>, Vector64<UInt16>)	uint32x4_t vaddl_u16 (uint16x4_t a, uint16x4_t b); A32: VADDL.U16 Qd, Dn, Dm; A64: UADDL Vd.4S, Vn.4H, Vm.4H
            // AddWideningLower(Vector64<UInt32>, Vector64<UInt32>)	uint64x2_t vaddl_u32 (uint32x2_t a, uint32x2_t b); A32: VADDL.U32 Qd, Dn, Dm; A64: UADDL Vd.2D, Vn.2S, Vm.2S
            // AddWideningUpper(Vector128<Byte>, Vector128<Byte>)	uint16x8_t vaddl_high_u8 (uint8x16_t a, uint8x16_t b); A32: VADDL.U8 Qd, Dn+1, Dm+1; A64: UADDL2 Vd.8H, Vn.16B, Vm.16B
            // AddWideningUpper(Vector128<Int16>, Vector128<Int16>)	int32x4_t vaddl_high_s16 (int16x8_t a, int16x8_t b); A32: VADDL.S16 Qd, Dn+1, Dm+1; A64: SADDL2 Vd.4S, Vn.8H, Vm.8H
            // AddWideningUpper(Vector128<Int16>, Vector128<SByte>)	int16x8_t vaddw_high_s8 (int16x8_t a, int8x16_t b); A32: VADDW.S8 Qd, Qn, Dm+1; A64: SADDW2 Vd.8H, Vn.8H, Vm.16B
            // AddWideningUpper(Vector128<Int32>, Vector128<Int16>)	int32x4_t vaddw_high_s16 (int32x4_t a, int16x8_t b); A32: VADDW.S16 Qd, Qn, Dm+1; A64: SADDW2 Vd.4S, Vn.4S, Vm.8H
            // AddWideningUpper(Vector128<Int32>, Vector128<Int32>)	int64x2_t vaddl_high_s32 (int32x4_t a, int32x4_t b); A32: VADDL.S32 Qd, Dn+1, Dm+1; A64: SADDL2 Vd.2D, Vn.4S, Vm.4S
            // AddWideningUpper(Vector128<Int64>, Vector128<Int32>)	int64x2_t vaddw_high_s32 (int64x2_t a, int32x4_t b); A32: VADDW.S32 Qd, Qn, Dm+1; A64: SADDW2 Vd.2D, Vn.2D, Vm.4S
            // AddWideningUpper(Vector128<SByte>, Vector128<SByte>)	int16x8_t vaddl_high_s8 (int8x16_t a, int8x16_t b); A32: VADDL.S8 Qd, Dn+1, Dm+1; A64: SADDL2 Vd.8H, Vn.16B, Vm.16B
            // AddWideningUpper(Vector128<UInt16>, Vector128<Byte>)	uint16x8_t vaddw_high_u8 (uint16x8_t a, uint8x16_t b); A32: VADDW.U8 Qd, Qn, Dm+1; A64: UADDW2 Vd.8H, Vn.8H, Vm.16B
            // AddWideningUpper(Vector128<UInt16>, Vector128<UInt16>)	uint32x4_t vaddl_high_u16 (uint16x8_t a, uint16x8_t b); A32: VADDL.U16 Qd, Dn+1, Dm+1; A64: UADDL2 Vd.4S, Vn.8H, Vm.8H
            // AddWideningUpper(Vector128<UInt32>, Vector128<UInt16>)	uint32x4_t vaddw_high_u16 (uint32x4_t a, uint16x8_t b); A32: VADDW.U16 Qd, Qn, Dm+1; A64: UADDW2 Vd.4S, Vn.4S, Vm.8H
            // AddWideningUpper(Vector128<UInt32>, Vector128<UInt32>)	uint64x2_t vaddl_high_u32 (uint32x4_t a, uint32x4_t b); A32: VADDL.U32 Qd, Dn+1, Dm+1; A64: UADDL2 Vd.2D, Vn.4S, Vm.4S
            // AddWideningUpper(Vector128<UInt64>, Vector128<UInt32>)	uint64x2_t vaddw_high_u32 (uint64x2_t a, uint32x4_t b); A32: VADDW.U32 Qd, Qn, Dm+1; A64: UADDW2 Vd.2D, Vn.2D, Vm.4S
            // And(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vandq_u8 (uint8x16_t a, uint8x16_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B
            // And(Vector128<Double>, Vector128<Double>)	float64x2_t vandq_f64 (float64x2_t a, float64x2_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // And(Vector128<Int16>, Vector128<Int16>)	int16x8_t vandq_s16 (int16x8_t a, int16x8_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B
            // And(Vector128<Int32>, Vector128<Int32>)	int32x4_t vandq_s32 (int32x4_t a, int32x4_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B
            // And(Vector128<Int64>, Vector128<Int64>)	int64x2_t vandq_s64 (int64x2_t a, int64x2_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B
            // And(Vector128<SByte>, Vector128<SByte>)	int8x16_t vandq_s8 (int8x16_t a, int8x16_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B
            // And(Vector128<Single>, Vector128<Single>)	float32x4_t vandq_f32 (float32x4_t a, float32x4_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // And(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vandq_u16 (uint16x8_t a, uint16x8_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B
            // And(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vandq_u32 (uint32x4_t a, uint32x4_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B
            // And(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vandq_u64 (uint64x2_t a, uint64x2_t b); A32: VAND Qd, Qn, Qm; A64: AND Vd.16B, Vn.16B, Vm.16B
            // And(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vand_u8 (uint8x8_t a, uint8x8_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B
            // And(Vector64<Double>, Vector64<Double>)	float64x1_t vand_f64 (float64x1_t a, float64x1_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // And(Vector64<Int16>, Vector64<Int16>)	int16x4_t vand_s16 (int16x4_t a, int16x4_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B
            // And(Vector64<Int32>, Vector64<Int32>)	int32x2_t vand_s32 (int32x2_t a, int32x2_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B
            // And(Vector64<Int64>, Vector64<Int64>)	int64x1_t vand_s64 (int64x1_t a, int64x1_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B
            // And(Vector64<SByte>, Vector64<SByte>)	int8x8_t vand_s8 (int8x8_t a, int8x8_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B
            // And(Vector64<Single>, Vector64<Single>)	float32x2_t vand_f32 (float32x2_t a, float32x2_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // And(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vand_u16 (uint16x4_t a, uint16x4_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B
            // And(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vand_u32 (uint32x2_t a, uint32x2_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B
            // And(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vand_u64 (uint64x1_t a, uint64x1_t b); A32: VAND Dd, Dn, Dm; A64: AND Vd.8B, Vn.8B, Vm.8B
        }
        public unsafe static void RunArm_AdvSimd_B(TextWriter writer, string indent) {
            // BitwiseClear(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vbicq_u8 (uint8x16_t a, uint8x16_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B
            // BitwiseClear(Vector128<Double>, Vector128<Double>)	float64x2_t vbicq_f64 (float64x2_t a, float64x2_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // BitwiseClear(Vector128<Int16>, Vector128<Int16>)	int16x8_t vbicq_s16 (int16x8_t a, int16x8_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B
            // BitwiseClear(Vector128<Int32>, Vector128<Int32>)	int32x4_t vbicq_s32 (int32x4_t a, int32x4_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B
            // BitwiseClear(Vector128<Int64>, Vector128<Int64>)	int64x2_t vbicq_s64 (int64x2_t a, int64x2_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B
            // BitwiseClear(Vector128<SByte>, Vector128<SByte>)	int8x16_t vbicq_s8 (int8x16_t a, int8x16_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B
            // BitwiseClear(Vector128<Single>, Vector128<Single>)	float32x4_t vbicq_f32 (float32x4_t a, float32x4_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // BitwiseClear(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vbicq_u16 (uint16x8_t a, uint16x8_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B
            // BitwiseClear(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vbicq_u32 (uint32x4_t a, uint32x4_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B
            // BitwiseClear(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vbicq_u64 (uint64x2_t a, uint64x2_t b); A32: VBIC Qd, Qn, Qm; A64: BIC Vd.16B, Vn.16B, Vm.16B
            // BitwiseClear(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vbic_u8 (uint8x8_t a, uint8x8_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B
            // BitwiseClear(Vector64<Double>, Vector64<Double>)	float64x1_t vbic_f64 (float64x1_t a, float64x1_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // BitwiseClear(Vector64<Int16>, Vector64<Int16>)	int16x4_t vbic_s16 (int16x4_t a, int16x4_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B
            // BitwiseClear(Vector64<Int32>, Vector64<Int32>)	int32x2_t vbic_s32 (int32x2_t a, int32x2_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B
            // BitwiseClear(Vector64<Int64>, Vector64<Int64>)	int64x1_t vbic_s64 (int64x1_t a, int64x1_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B
            // BitwiseClear(Vector64<SByte>, Vector64<SByte>)	int8x8_t vbic_s8 (int8x8_t a, int8x8_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B
            // BitwiseClear(Vector64<Single>, Vector64<Single>)	float32x2_t vbic_f32 (float32x2_t a, float32x2_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // BitwiseClear(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vbic_u16 (uint16x4_t a, uint16x4_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B
            // BitwiseClear(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vbic_u32 (uint32x2_t a, uint32x2_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B
            // BitwiseClear(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vbic_u64 (uint64x1_t a, uint64x1_t b); A32: VBIC Dd, Dn, Dm; A64: BIC Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector128<Byte>, Vector128<Byte>, Vector128<Byte>)	uint8x16_t vbslq_u8 (uint8x16_t a, uint8x16_t b, uint8x16_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<Double>, Vector128<Double>, Vector128<Double>)	float64x2_t vbslq_f64 (uint64x2_t a, float64x2_t b, float64x2_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>)	int16x8_t vbslq_s16 (uint16x8_t a, int16x8_t b, int16x8_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>)	int32x4_t vbslq_s32 (uint32x4_t a, int32x4_t b, int32x4_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<Int64>, Vector128<Int64>, Vector128<Int64>)	int64x2_t vbslq_s64 (uint64x2_t a, int64x2_t b, int64x2_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<SByte>, Vector128<SByte>, Vector128<SByte>)	int8x16_t vbslq_s8 (uint8x16_t a, int8x16_t b, int8x16_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<Single>, Vector128<Single>, Vector128<Single>)	float32x4_t vbslq_f32 (uint32x4_t a, float32x4_t b, float32x4_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<UInt16>, Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vbslq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<UInt32>, Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vbslq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector128<UInt64>, Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vbslq_u64 (uint64x2_t a, uint64x2_t b, uint64x2_t c); A32: VBSL Qd, Qn, Qm; A64: BSL Vd.16B, Vn.16B, Vm.16B
            // BitwiseSelect(Vector64<Byte>, Vector64<Byte>, Vector64<Byte>)	uint8x8_t vbsl_u8 (uint8x8_t a, uint8x8_t b, uint8x8_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<Double>, Vector64<Double>, Vector64<Double>)	float64x1_t vbsl_f64 (uint64x1_t a, float64x1_t b, float64x1_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16x4_t vbsl_s16 (uint16x4_t a, int16x4_t b, int16x4_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32x2_t vbsl_s32 (uint32x2_t a, int32x2_t b, int32x2_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<Int64>, Vector64<Int64>, Vector64<Int64>)	int64x1_t vbsl_s64 (uint64x1_t a, int64x1_t b, int64x1_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<SByte>, Vector64<SByte>, Vector64<SByte>)	int8x8_t vbsl_s8 (uint8x8_t a, int8x8_t b, int8x8_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32x2_t vbsl_f32 (uint32x2_t a, float32x2_t b, float32x2_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<UInt16>, Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vbsl_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<UInt32>, Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vbsl_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
            // BitwiseSelect(Vector64<UInt64>, Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vbsl_u64 (uint64x1_t a, uint64x1_t b, uint64x1_t c); A32: VBSL Dd, Dn, Dm; A64: BSL Vd.8B, Vn.8B, Vm.8B
        }
        public unsafe static void RunArm_AdvSimd_C(TextWriter writer, string indent) {
            // Ceiling(Vector128<Single>)	float32x4_t vrndpq_f32 (float32x4_t a); A32: VRINTP.F32 Qd, Qm; A64: FRINTP Vd.4S, Vn.4S
            // Ceiling(Vector64<Single>)	float32x2_t vrndp_f32 (float32x2_t a); A32: VRINTP.F32 Dd, Dm; A64: FRINTP Vd.2S, Vn.2S
            // CeilingScalar(Vector64<Double>)	float64x1_t vrndp_f64 (float64x1_t a); A32: VRINTP.F64 Dd, Dm; A64: FRINTP Dd, Dn
            // CeilingScalar(Vector64<Single>)	float32_t vrndps_f32 (float32_t a); A32: VRINTP.F32 Sd, Sm; A64: FRINTP Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // CompareEqual(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vceqq_u8 (uint8x16_t a, uint8x16_t b); A32: VCEQ.I8 Qd, Qn, Qm; A64: CMEQ Vd.16B, Vn.16B, Vm.16B
            // CompareEqual(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vceqq_s16 (int16x8_t a, int16x8_t b); A32: VCEQ.I16 Qd, Qn, Qm; A64: CMEQ Vd.8H, Vn.8H, Vm.8H
            // CompareEqual(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vceqq_s32 (int32x4_t a, int32x4_t b); A32: VCEQ.I32 Qd, Qn, Qm; A64: CMEQ Vd.4S, Vn.4S, Vm.4S
            // CompareEqual(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vceqq_s8 (int8x16_t a, int8x16_t b); A32: VCEQ.I8 Qd, Qn, Qm; A64: CMEQ Vd.16B, Vn.16B, Vm.16B
            // CompareEqual(Vector128<Single>, Vector128<Single>)	uint32x4_t vceqq_f32 (float32x4_t a, float32x4_t b); A32: VCEQ.F32 Qd, Qn, Qm; A64: FCMEQ Vd.4S, Vn.4S, Vm.4S
            // CompareEqual(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vceqq_u16 (uint16x8_t a, uint16x8_t b); A32: VCEQ.I16 Qd, Qn, Qm; A64: CMEQ Vd.8H, Vn.8H, Vm.8H
            // CompareEqual(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vceqq_u32 (uint32x4_t a, uint32x4_t b); A32: VCEQ.I32 Qd, Qn, Qm; A64: CMEQ Vd.4S, Vn.4S, Vm.4S
            // CompareEqual(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vceq_u8 (uint8x8_t a, uint8x8_t b); A32: VCEQ.I8 Dd, Dn, Dm; A64: CMEQ Vd.8B, Vn.8B, Vm.8B
            // CompareEqual(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vceq_s16 (int16x4_t a, int16x4_t b); A32: VCEQ.I16 Dd, Dn, Dm; A64: CMEQ Vd.4H, Vn.4H, Vm.4H
            // CompareEqual(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vceq_s32 (int32x2_t a, int32x2_t b); A32: VCEQ.I32 Dd, Dn, Dm; A64: CMEQ Vd.2S, Vn.2S, Vm.2S
            // CompareEqual(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vceq_s8 (int8x8_t a, int8x8_t b); A32: VCEQ.I8 Dd, Dn, Dm; A64: CMEQ Vd.8B, Vn.8B, Vm.8B
            // CompareEqual(Vector64<Single>, Vector64<Single>)	uint32x2_t vceq_f32 (float32x2_t a, float32x2_t b); A32: VCEQ.F32 Dd, Dn, Dm; A64: FCMEQ Vd.2S, Vn.2S, Vm.2S
            // CompareEqual(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vceq_u16 (uint16x4_t a, uint16x4_t b); A32: VCEQ.I16 Dd, Dn, Dm; A64: CMEQ Vd.4H, Vn.4H, Vm.4H
            // CompareEqual(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vceq_u32 (uint32x2_t a, uint32x2_t b); A32: VCEQ.I32 Dd, Dn, Dm; A64: CMEQ Vd.2S, Vn.2S, Vm.2S
            // CompareGreaterThan(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vcgtq_u8 (uint8x16_t a, uint8x16_t b); A32: VCGT.U8 Qd, Qn, Qm; A64: CMHI Vd.16B, Vn.16B, Vm.16B
            // CompareGreaterThan(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vcgtq_s16 (int16x8_t a, int16x8_t b); A32: VCGT.S16 Qd, Qn, Qm; A64: CMGT Vd.8H, Vn.8H, Vm.8H
            // CompareGreaterThan(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vcgtq_s32 (int32x4_t a, int32x4_t b); A32: VCGT.S32 Qd, Qn, Qm; A64: CMGT Vd.4S, Vn.4S, Vm.4S
            // CompareGreaterThan(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vcgtq_s8 (int8x16_t a, int8x16_t b); A32: VCGT.S8 Qd, Qn, Qm; A64: CMGT Vd.16B, Vn.16B, Vm.16B
            // CompareGreaterThan(Vector128<Single>, Vector128<Single>)	uint32x4_t vcgtq_f32 (float32x4_t a, float32x4_t b); A32: VCGT.F32 Qd, Qn, Qm; A64: FCMGT Vd.4S, Vn.4S, Vm.4S
            // CompareGreaterThan(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vcgtq_u16 (uint16x8_t a, uint16x8_t b); A32: VCGT.U16 Qd, Qn, Qm; A64: CMHI Vd.8H, Vn.8H, Vm.8H
            // CompareGreaterThan(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vcgtq_u32 (uint32x4_t a, uint32x4_t b); A32: VCGT.U32 Qd, Qn, Qm; A64: CMHI Vd.4S, Vn.4S, Vm.4S
            // CompareGreaterThan(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vcgt_u8 (uint8x8_t a, uint8x8_t b); A32: VCGT.U8 Dd, Dn, Dm; A64: CMHI Vd.8B, Vn.8B, Vm.8B
            // CompareGreaterThan(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vcgt_s16 (int16x4_t a, int16x4_t b); A32: VCGT.S16 Dd, Dn, Dm; A64: CMGT Vd.4H, Vn.4H, Vm.4H
            // CompareGreaterThan(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vcgt_s32 (int32x2_t a, int32x2_t b); A32: VCGT.S32 Dd, Dn, Dm; A64: CMGT Vd.2S, Vn.2S, Vm.2S
            // CompareGreaterThan(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vcgt_s8 (int8x8_t a, int8x8_t b); A32: VCGT.S8 Dd, Dn, Dm; A64: CMGT Vd.8B, Vn.8B, Vm.8B
            // CompareGreaterThan(Vector64<Single>, Vector64<Single>)	uint32x2_t vcgt_f32 (float32x2_t a, float32x2_t b); A32: VCGT.F32 Dd, Dn, Dm; A64: FCMGT Vd.2S, Vn.2S, Vm.2S
            // CompareGreaterThan(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vcgt_u16 (uint16x4_t a, uint16x4_t b); A32: VCGT.U16 Dd, Dn, Dm; A64: CMHI Vd.4H, Vn.4H, Vm.4H
            // CompareGreaterThan(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vcgt_u32 (uint32x2_t a, uint32x2_t b); A32: VCGT.U32 Dd, Dn, Dm; A64: CMHI Vd.2S, Vn.2S, Vm.2S
            // CompareGreaterThanOrEqual(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vcgeq_u8 (uint8x16_t a, uint8x16_t b); A32: VCGE.U8 Qd, Qn, Qm; A64: CMHS Vd.16B, Vn.16B, Vm.16B
            // CompareGreaterThanOrEqual(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vcgeq_s16 (int16x8_t a, int16x8_t b); A32: VCGE.S16 Qd, Qn, Qm; A64: CMGE Vd.8H, Vn.8H, Vm.8H
            // CompareGreaterThanOrEqual(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vcgeq_s32 (int32x4_t a, int32x4_t b); A32: VCGE.S32 Qd, Qn, Qm; A64: CMGE Vd.4S, Vn.4S, Vm.4S
            // CompareGreaterThanOrEqual(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vcgeq_s8 (int8x16_t a, int8x16_t b); A32: VCGE.S8 Qd, Qn, Qm; A64: CMGE Vd.16B, Vn.16B, Vm.16B
            // CompareGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)	uint32x4_t vcgeq_f32 (float32x4_t a, float32x4_t b); A32: VCGE.F32 Qd, Qn, Qm; A64: FCMGE Vd.4S, Vn.4S, Vm.4S
            // CompareGreaterThanOrEqual(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vcgeq_u16 (uint16x8_t a, uint16x8_t b); A32: VCGE.U16 Qd, Qn, Qm; A64: CMHS Vd.8H, Vn.8H, Vm.8H
            // CompareGreaterThanOrEqual(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vcgeq_u32 (uint32x4_t a, uint32x4_t b); A32: VCGE.U32 Qd, Qn, Qm; A64: CMHS Vd.4S, Vn.4S, Vm.4S
            // CompareGreaterThanOrEqual(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vcge_u8 (uint8x8_t a, uint8x8_t b); A32: VCGE.U8 Dd, Dn, Dm; A64: CMHS Vd.8B, Vn.8B, Vm.8B
            // CompareGreaterThanOrEqual(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vcge_s16 (int16x4_t a, int16x4_t b); A32: VCGE.S16 Dd, Dn, Dm; A64: CMGE Vd.4H, Vn.4H, Vm.4H
            // CompareGreaterThanOrEqual(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vcge_s32 (int32x2_t a, int32x2_t b); A32: VCGE.S32 Dd, Dn, Dm; A64: CMGE Vd.2S, Vn.2S, Vm.2S
            // CompareGreaterThanOrEqual(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vcge_s8 (int8x8_t a, int8x8_t b); A32: VCGE.S8 Dd, Dn, Dm; A64: CMGE Vd.8B, Vn.8B, Vm.8B
            // CompareGreaterThanOrEqual(Vector64<Single>, Vector64<Single>)	uint32x2_t vcge_f32 (float32x2_t a, float32x2_t b); A32: VCGE.F32 Dd, Dn, Dm; A64: FCMGE Vd.2S, Vn.2S, Vm.2S
            // CompareGreaterThanOrEqual(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vcge_u16 (uint16x4_t a, uint16x4_t b); A32: VCGE.U16 Dd, Dn, Dm; A64: CMHS Vd.4H, Vn.4H, Vm.4H
            // CompareGreaterThanOrEqual(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vcge_u32 (uint32x2_t a, uint32x2_t b); A32: VCGE.U32 Dd, Dn, Dm; A64: CMHS Vd.2S, Vn.2S, Vm.2S
            // CompareLessThan(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vcltq_u8 (uint8x16_t a, uint8x16_t b); A32: VCLT.U8 Qd, Qn, Qm; A64: CMHI Vd.16B, Vn.16B, Vm.16B
            // CompareLessThan(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vcltq_s16 (int16x8_t a, int16x8_t b); A32: VCLT.S16 Qd, Qn, Qm; A64: CMGT Vd.8H, Vn.8H, Vm.8H
            // CompareLessThan(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vcltq_s32 (int32x4_t a, int32x4_t b); A32: VCLT.S32 Qd, Qn, Qm; A64: CMGT Vd.4S, Vn.4S, Vm.4S
            // CompareLessThan(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vcltq_s8 (int8x16_t a, int8x16_t b); A32: VCLT.S8 Qd, Qn, Qm; A64: CMGT Vd.16B, Vn.16B, Vm.16B
            // CompareLessThan(Vector128<Single>, Vector128<Single>)	uint32x4_t vcltq_f32 (float32x4_t a, float32x4_t b); A32: VCLT.F32 Qd, Qn, Qm; A64: FCMGT Vd.4S, Vn.4S, Vm.4S
            // CompareLessThan(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vcltq_u16 (uint16x8_t a, uint16x8_t b); A32: VCLT.U16 Qd, Qn, Qm; A64: CMHI Vd.8H, Vn.8H, Vm.8H
            // CompareLessThan(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vcltq_u32 (uint32x4_t a, uint32x4_t b); A32: VCLT.U32 Qd, Qn, Qm; A64: CMHI Vd.4S, Vn.4S, Vm.4S
            // CompareLessThan(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vclt_u8 (uint8x8_t a, uint8x8_t b); A32: VCLT.U8 Dd, Dn, Dm; A64: CMHI Vd.8B, Vn.8B, Vm.8B
            // CompareLessThan(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vclt_s16 (int16x4_t a, int16x4_t b); A32: VCLT.S16 Dd, Dn, Dm; A64: CMGT Vd.4H, Vn.4H, Vm.4H
            // CompareLessThan(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vclt_s32 (int32x2_t a, int32x2_t b); A32: VCLT.S32 Dd, Dn, Dm; A64: CMGT Vd.2S, Vn.2S, Vm.2S
            // CompareLessThan(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vclt_s8 (int8x8_t a, int8x8_t b); A32: VCLT.S8 Dd, Dn, Dm; A64: CMGT Vd.8B, Vn.8B, Vm.8B
            // CompareLessThan(Vector64<Single>, Vector64<Single>)	uint32x2_t vclt_f32 (float32x2_t a, float32x2_t b); A32: VCLT.F32 Dd, Dn, Dm; A64: FCMGT Vd.2S, Vn.2S, Vm.2S
            // CompareLessThan(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vclt_u16 (uint16x4_t a, uint16x4_t b); A32: VCLT.U16 Dd, Dn, Dm; A64: CMHI Vd.4H, Vn.4H, Vm.4H
            // CompareLessThan(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vclt_u32 (uint32x2_t a, uint32x2_t b); A32: VCLT.U32 Dd, Dn, Dm; A64: CMHI Vd.2S, Vn.2S, Vm.2S
            // CompareLessThanOrEqual(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vcleq_u8 (uint8x16_t a, uint8x16_t b); A32: VCLE.U8 Qd, Qn, Qm; A64: CMHS Vd.16B, Vn.16B, Vm.16B
            // CompareLessThanOrEqual(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vcleq_s16 (int16x8_t a, int16x8_t b); A32: VCLE.S16 Qd, Qn, Qm; A64: CMGE Vd.8H, Vn.8H, Vm.8H
            // CompareLessThanOrEqual(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vcleq_s32 (int32x4_t a, int32x4_t b); A32: VCLE.S32 Qd, Qn, Qm; A64: CMGE Vd.4S, Vn.4S, Vm.4S
            // CompareLessThanOrEqual(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vcleq_s8 (int8x16_t a, int8x16_t b); A32: VCLE.S8 Qd, Qn, Qm; A64: CMGE Vd.16B, Vn.16B, Vm.16B
            // CompareLessThanOrEqual(Vector128<Single>, Vector128<Single>)	uint32x4_t vcleq_f32 (float32x4_t a, float32x4_t b); A32: VCLE.F32 Qd, Qn, Qm; A64: FCMGE Vd.4S, Vn.4S, Vm.4S
            // CompareLessThanOrEqual(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vcleq_u16 (uint16x8_t a, uint16x8_t b); A32: VCLE.U16 Qd, Qn, Qm; A64: CMHS Vd.8H, Vn.8H, Vm.8H
            // CompareLessThanOrEqual(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vcleq_u32 (uint32x4_t a, uint32x4_t b); A32: VCLE.U32 Qd, Qn, Qm; A64: CMHS Vd.4S, Vn.4S, Vm.4S
            // CompareLessThanOrEqual(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vcle_u8 (uint8x8_t a, uint8x8_t b); A32: VCLE.U8 Dd, Dn, Dm; A64: CMHS Vd.8B, Vn.8B, Vm.8B
            // CompareLessThanOrEqual(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vcle_s16 (int16x4_t a, int16x4_t b); A32: VCLE.S16 Dd, Dn, Dm; A64: CMGE Vd.4H, Vn.4H, Vm.4H
            // CompareLessThanOrEqual(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vcle_s32 (int32x2_t a, int32x2_t b); A32: VCLE.S32 Dd, Dn, Dm; A64: CMGE Vd.2S, Vn.2S, Vm.2S
            // CompareLessThanOrEqual(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vcle_s8 (int8x8_t a, int8x8_t b); A32: VCLE.S8 Dd, Dn, Dm; A64: CMGE Vd.8B, Vn.8B, Vm.8B
            // CompareLessThanOrEqual(Vector64<Single>, Vector64<Single>)	uint32x2_t vcle_f32 (float32x2_t a, float32x2_t b); A32: VCLE.F32 Dd, Dn, Dm; A64: FCMGE Vd.2S, Vn.2S, Vm.2S
            // CompareLessThanOrEqual(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vcle_u16 (uint16x4_t a, uint16x4_t b); A32: VCLE.U16 Dd, Dn, Dm; A64: CMHS Vd.4H, Vn.4H, Vm.4H
            // CompareLessThanOrEqual(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vcle_u32 (uint32x2_t a, uint32x2_t b); A32: VCLE.U32 Dd, Dn, Dm; A64: CMHS Vd.2S, Vn.2S, Vm.2S
            // CompareTest(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vtstq_u8 (uint8x16_t a, uint8x16_t b); A32: VTST.8 Qd, Qn, Qm; A64: CMTST Vd.16B, Vn.16B, Vm.16B
            // CompareTest(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vtstq_s16 (int16x8_t a, int16x8_t b); A32: VTST.16 Qd, Qn, Qm; A64: CMTST Vd.8H, Vn.8H, Vm.8H
            // CompareTest(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vtstq_s32 (int32x4_t a, int32x4_t b); A32: VTST.32 Qd, Qn, Qm; A64: CMTST Vd.4S, Vn.4S, Vm.4S
            // CompareTest(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vtstq_s8 (int8x16_t a, int8x16_t b); A32: VTST.8 Qd, Qn, Qm; A64: CMTST Vd.16B, Vn.16B, Vm.16B
            // CompareTest(Vector128<Single>, Vector128<Single>)	uint32x4_t vtstq_f32 (float32x4_t a, float32x4_t b); A32: VTST.32 Qd, Qn, Qm; A64: CMTST Vd.4S, Vn.4S, Vm.4S The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // CompareTest(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vtstq_u16 (uint16x8_t a, uint16x8_t b); A32: VTST.16 Qd, Qn, Qm; A64: CMTST Vd.8H, Vn.8H, Vm.8H
            // CompareTest(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vtstq_u32 (uint32x4_t a, uint32x4_t b); A32: VTST.32 Qd, Qn, Qm; A64: CMTST Vd.4S, Vn.4S, Vm.4S
            // CompareTest(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vtst_u8 (uint8x8_t a, uint8x8_t b); A32: VTST.8 Dd, Dn, Dm; A64: CMTST Vd.8B, Vn.8B, Vm.8B
            // CompareTest(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vtst_s16 (int16x4_t a, int16x4_t b); A32: VTST.16 Dd, Dn, Dm; A64: CMTST Vd.4H, Vn.4H, Vm.4H
            // CompareTest(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vtst_s32 (int32x2_t a, int32x2_t b); A32: VTST.32 Dd, Dn, Dm; A64: CMTST Vd.2S, Vn.2S, Vm.2S
            // CompareTest(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vtst_s8 (int8x8_t a, int8x8_t b); A32: VTST.8 Dd, Dn, Dm; A64: CMTST Vd.8B, Vn.8B, Vm.8B
            // CompareTest(Vector64<Single>, Vector64<Single>)	uint32x2_t vtst_f32 (float32x2_t a, float32x2_t b); A32: VTST.32 Dd, Dn, Dm; A64: CMTST Vd.2S, Vn.2S, Vm.2S The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // CompareTest(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vtst_u16 (uint16x4_t a, uint16x4_t b); A32: VTST.16 Dd, Dn, Dm; A64: CMTST Vd.4H, Vn.4H, Vm.4H
            // CompareTest(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vtst_u32 (uint32x2_t a, uint32x2_t b); A32: VTST.32 Dd, Dn, Dm; A64: CMTST Vd.2S, Vn.2S, Vm.2S
            // ConvertToInt32RoundAwayFromZero(Vector128<Single>)	int32x4_t vcvtaq_s32_f32 (float32x4_t a); A32: VCVTA.S32.F32 Qd, Qm; A64: FCVTAS Vd.4S, Vn.4S
            // ConvertToInt32RoundAwayFromZero(Vector64<Single>)	int32x2_t vcvta_s32_f32 (float32x2_t a); A32: VCVTA.S32.F32 Dd, Dm; A64: FCVTAS Vd.2S, Vn.2S
            // ConvertToInt32RoundAwayFromZeroScalar(Vector64<Single>)	int32_t vcvtas_s32_f32 (float32_t a); A32: VCVTA.S32.F32 Sd, Sm; A64: FCVTAS Sd, Sn
            // ConvertToInt32RoundToEven(Vector128<Single>)	int32x4_t vcvtnq_s32_f32 (float32x4_t a); A32: VCVTN.S32.F32 Qd, Qm; A64: FCVTNS Vd.4S, Vn.4S
            // ConvertToInt32RoundToEven(Vector64<Single>)	int32x2_t vcvtn_s32_f32 (float32x2_t a); A32: VCVTN.S32.F32 Dd, Dm; A64: FCVTNS Vd.2S, Vn.2S
            // ConvertToInt32RoundToEvenScalar(Vector64<Single>)	int32_t vcvtns_s32_f32 (float32_t a); A32: VCVTN.S32.F32 Sd, Sm; A64: FCVTNS Sd, Sn
            // ConvertToInt32RoundToNegativeInfinity(Vector128<Single>)	int32x4_t vcvtmq_s32_f32 (float32x4_t a); A32: VCVTM.S32.F32 Qd, Qm; A64: FCVTMS Vd.4S, Vn.4S
            // ConvertToInt32RoundToNegativeInfinity(Vector64<Single>)	int32x2_t vcvtm_s32_f32 (float32x2_t a); A32: VCVTM.S32.F32 Dd, Dm; A64: FCVTMS Vd.2S, Vn.2S
            // ConvertToInt32RoundToNegativeInfinityScalar(Vector64<Single>)	int32_t vcvtms_s32_f32 (float32_t a); A32: VCVTM.S32.F32 Sd, Sm; A64: FCVTMS Sd, Sn
            // ConvertToInt32RoundToPositiveInfinity(Vector128<Single>)	int32x4_t vcvtpq_s32_f32 (float32x4_t a); A32: VCVTP.S32.F32 Qd, Qm; A64: FCVTPS Vd.4S, Vn.4S
            // ConvertToInt32RoundToPositiveInfinity(Vector64<Single>)	int32x2_t vcvtp_s32_f32 (float32x2_t a); A32: VCVTP.S32.F32 Dd, Dm; A64: FCVTPS Vd.2S, Vn.2S
            // ConvertToInt32RoundToPositiveInfinityScalar(Vector64<Single>)	int32_t vcvtps_s32_f32 (float32_t a); A32: VCVTP.S32.F32 Sd, Sm; A64: FCVTPS Sd, Sn
            // ConvertToInt32RoundToZero(Vector128<Single>)	int32x4_t vcvtq_s32_f32 (float32x4_t a); A32: VCVT.S32.F32 Qd, Qm; A64: FCVTZS Vd.4S, Vn.4S
            // ConvertToInt32RoundToZero(Vector64<Single>)	int32x2_t vcvt_s32_f32 (float32x2_t a); A32: VCVT.S32.F32 Dd, Dm; A64: FCVTZS Vd.2S, Vn.2S
            // ConvertToInt32RoundToZeroScalar(Vector64<Single>)	int32_t vcvts_s32_f32 (float32_t a); A32: VCVT.S32.F32 Sd, Sm; A64: FCVTZS Sd, Sn
            // ConvertToSingle(Vector128<Int32>)	float32x4_t vcvtq_f32_s32 (int32x4_t a); A32: VCVT.F32.S32 Qd, Qm; A64: SCVTF Vd.4S, Vn.4S
            // ConvertToSingle(Vector128<UInt32>)	float32x4_t vcvtq_f32_u32 (uint32x4_t a); A32: VCVT.F32.U32 Qd, Qm; A64: UCVTF Vd.4S, Vn.4S
            // ConvertToSingle(Vector64<Int32>)	float32x2_t vcvt_f32_s32 (int32x2_t a); A32: VCVT.F32.S32 Dd, Dm; A64: SCVTF Vd.2S, Vn.2S
            // ConvertToSingle(Vector64<UInt32>)	float32x2_t vcvt_f32_u32 (uint32x2_t a); A32: VCVT.F32.U32 Dd, Dm; A64: UCVTF Vd.2S, Vn.2S
            // ConvertToSingleScalar(Vector64<Int32>)	float32_t vcvts_f32_s32 (int32_t a); A32: VCVT.F32.S32 Sd, Sm; A64: SCVTF Sd, Sn
            // ConvertToSingleScalar(Vector64<UInt32>)	float32_t vcvts_f32_u32 (uint32_t a); A32: VCVT.F32.U32 Sd, Sm; A64: UCVTF Sd, Sn
            // ConvertToUInt32RoundAwayFromZero(Vector128<Single>)	uint32x4_t vcvtaq_u32_f32 (float32x4_t a); A32: VCVTA.U32.F32 Qd, Qm; A64: FCVTAU Vd.4S, Vn.4S
            // ConvertToUInt32RoundAwayFromZero(Vector64<Single>)	uint32x2_t vcvta_u32_f32 (float32x2_t a); A32: VCVTA.U32.F32 Dd, Dm; A64: FCVTAU Vd.2S, Vn.2S
            // ConvertToUInt32RoundAwayFromZeroScalar(Vector64<Single>)	uint32_t vcvtas_u32_f32 (float32_t a); A32: VCVTA.U32.F32 Sd, Sm; A64: FCVTAU Sd, Sn
            // ConvertToUInt32RoundToEven(Vector128<Single>)	uint32x4_t vcvtnq_u32_f32 (float32x4_t a); A32: VCVTN.U32.F32 Qd, Qm; A64: FCVTNU Vd.4S, Vn.4S
            // ConvertToUInt32RoundToEven(Vector64<Single>)	uint32x2_t vcvtn_u32_f32 (float32x2_t a); A32: VCVTN.U32.F32 Dd, Dm; A64: FCVTNU Vd.2S, Vn.2S
            // ConvertToUInt32RoundToEvenScalar(Vector64<Single>)	uint32_t vcvtns_u32_f32 (float32_t a); A32: VCVTN.U32.F32 Sd, Sm; A64: FCVTNU Sd, Sn
            // ConvertToUInt32RoundToNegativeInfinity(Vector128<Single>)	uint32x4_t vcvtmq_u32_f32 (float32x4_t a); A32: VCVTM.U32.F32 Qd, Qm; A64: FCVTMU Vd.4S, Vn.4S
            // ConvertToUInt32RoundToNegativeInfinity(Vector64<Single>)	uint32x2_t vcvtm_u32_f32 (float32x2_t a); A32: VCVTM.U32.F32 Dd, Dm; A64: FCVTMU Vd.2S, Vn.2S
            // ConvertToUInt32RoundToNegativeInfinityScalar(Vector64<Single>)	uint32_t vcvtms_u32_f32 (float32_t a); A32: VCVTM.U32.F32 Sd, Sm; A64: FCVTMU Sd, Sn
            // ConvertToUInt32RoundToPositiveInfinity(Vector128<Single>)	uint32x4_t vcvtpq_u32_f32 (float32x4_t a); A32: VCVTP.U32.F32 Qd, Qm; A64: FCVTPU Vd.4S, Vn.4S
            // ConvertToUInt32RoundToPositiveInfinity(Vector64<Single>)	uint32x2_t vcvtp_u32_f32 (float32x2_t a); A32: VCVTP.U32.F32 Dd, Dm; A64: FCVTPU Vd.2S, Vn.2S
            // ConvertToUInt32RoundToPositiveInfinityScalar(Vector64<Single>)	uint32_t vcvtps_u32_f32 (float32_t a); A32: VCVTP.U32.F32 Sd, Sm; A64: FCVTPU Sd, Sn
            // ConvertToUInt32RoundToZero(Vector128<Single>)	uint32x4_t vcvtq_u32_f32 (float32x4_t a); A32: VCVT.U32.F32 Qd, Qm; A64: FCVTZU Vd.4S, Vn.4S
            // ConvertToUInt32RoundToZero(Vector64<Single>)	uint32x2_t vcvt_u32_f32 (float32x2_t a); A32: VCVT.U32.F32 Dd, Dm; A64: FCVTZU Vd.2S, Vn.2S
            // ConvertToUInt32RoundToZeroScalar(Vector64<Single>)	uint32_t vcvts_u32_f32 (float32_t a); A32: VCVT.U32.F32 Sd, Sm; A64: FCVTZU Sd, Sn
        }
        public unsafe static void RunArm_AdvSimd_D(TextWriter writer, string indent) {
            // DivideScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vdiv_f64 (float64x1_t a, float64x1_t b); A32: VDIV.F64 Dd, Dn, Dm; A64: FDIV Dd, Dn, Dm
            // DivideScalar(Vector64<Single>, Vector64<Single>)	float32_t vdivs_f32 (float32_t a, float32_t b); A32: VDIV.F32 Sd, Sn, Sm; A64: FDIV Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // DuplicateSelectedScalarToVector128(Vector128<Byte>, Byte)	uint8x16_t vdupq_lane_u8 (uint8x16_t vec, const int lane); A32: VDUP.8 Qd, Dm[index]; A64: DUP Vd.16B, Vn.B[index]
            // DuplicateSelectedScalarToVector128(Vector128<Int16>, Byte)	int16x8_t vdupq_lane_s16 (int16x8_t vec, const int lane); A32: VDUP.16 Qd, Dm[index]; A64: DUP Vd.8H, Vn.H[index]
            // DuplicateSelectedScalarToVector128(Vector128<Int32>, Byte)	int32x4_t vdupq_lane_s32 (int32x4_t vec, const int lane); A32: VDUP.32 Qd, Dm[index]; A64: DUP Vd.4S, Vn.S[index]
            // DuplicateSelectedScalarToVector128(Vector128<SByte>, Byte)	int8x16_t vdupq_lane_s8 (int8x16_t vec, const int lane); A32: VDUP.8 Qd, Dm[index]; A64: DUP Vd.16B, Vn.B[index]
            // DuplicateSelectedScalarToVector128(Vector128<Single>, Byte)	float32x4_t vdupq_lane_f32 (float32x4_t vec, const int lane); A32: VDUP.32 Qd, Dm[index]; A64: DUP Vd.4S, Vn.S[index]
            // DuplicateSelectedScalarToVector128(Vector128<UInt16>, Byte)	uint16x8_t vdupq_lane_u16 (uint16x8_t vec, const int lane); A32: VDUP.16 Qd, Dm[index]; A64: DUP Vd.8H, Vn.H[index]
            // DuplicateSelectedScalarToVector128(Vector128<UInt32>, Byte)	uint32x4_t vdupq_lane_u32 (uint32x4_t vec, const int lane); A32: VDUP.32 Qd, Dm[index]; A64: DUP Vd.4S, Vn.S[index]
            // DuplicateSelectedScalarToVector128(Vector64<Byte>, Byte)	uint8x16_t vdupq_lane_u8 (uint8x8_t vec, const int lane); A32: VDUP.8 Qd, Dm[index]; A64: DUP Vd.16B, Vn.B[index]
            // DuplicateSelectedScalarToVector128(Vector64<Int16>, Byte)	int16x8_t vdupq_lane_s16 (int16x4_t vec, const int lane); A32: VDUP.16 Qd, Dm[index]; A64: DUP Vd.8H, Vn.H[index]
            // DuplicateSelectedScalarToVector128(Vector64<Int32>, Byte)	int32x4_t vdupq_lane_s32 (int32x2_t vec, const int lane); A32: VDUP.32 Qd, Dm[index]; A64: DUP Vd.4S, Vn.S[index]
            // DuplicateSelectedScalarToVector128(Vector64<SByte>, Byte)	int8x16_t vdupq_lane_s8 (int8x8_t vec, const int lane); A32: VDUP.8 Qd, Dm[index]; A64: DUP Vd.16B, Vn.B[index]
            // DuplicateSelectedScalarToVector128(Vector64<Single>, Byte)	float32x4_t vdupq_lane_f32 (float32x2_t vec, const int lane); A32: VDUP.32 Qd, Dm[index]; A64: DUP Vd.4S, Vn.S[index]
            // DuplicateSelectedScalarToVector128(Vector64<UInt16>, Byte)	uint16x8_t vdupq_lane_u16 (uint16x4_t vec, const int lane); A32: VDUP.16 Qd, Dm[index]; A64: DUP Vd.8H, Vn.H[index]
            // DuplicateSelectedScalarToVector128(Vector64<UInt32>, Byte)	uint32x4_t vdupq_lane_u32 (uint32x2_t vec, const int lane); A32: VDUP.32 Qd, Dm[index]; A64: DUP Vd.4S, Vn.S[index]
            // DuplicateSelectedScalarToVector64(Vector128<Byte>, Byte)	uint8x8_t vdup_laneq_u8 (uint8x16_t vec, const int lane); A32: VDUP.8 Dd, Dm[index]; A64: DUP Vd.8B, Vn.B[index]
            // DuplicateSelectedScalarToVector64(Vector128<Int16>, Byte)	int16x4_t vdup_laneq_s16 (int16x8_t vec, const int lane); A32: VDUP.16 Dd, Dm[index]; A64: DUP Vd.4H, Vn.H[index]
            // DuplicateSelectedScalarToVector64(Vector128<Int32>, Byte)	int32x2_t vdup_laneq_s32 (int32x4_t vec, const int lane); A32: VDUP.32 Dd, Dm[index]; A64: DUP Vd.2S, Vn.S[index]
            // DuplicateSelectedScalarToVector64(Vector128<SByte>, Byte)	int8x8_t vdup_laneq_s8 (int8x16_t vec, const int lane); A32: VDUP.8 Dd, Dm[index]; A64: DUP Vd.8B, Vn.B[index]
            // DuplicateSelectedScalarToVector64(Vector128<Single>, Byte)	float32x2_t vdup_laneq_f32 (float32x4_t vec, const int lane); A32: VDUP.32 Dd, Dm[index]; A64: DUP Vd.2S, Vn.S[index]
            // DuplicateSelectedScalarToVector64(Vector128<UInt16>, Byte)	uint16x4_t vdup_laneq_u16 (uint16x8_t vec, const int lane); A32: VDUP.16 Dd, Dm[index]; A64: DUP Vd.4H, Vn.H[index]
            // DuplicateSelectedScalarToVector64(Vector128<UInt32>, Byte)	uint32x2_t vdup_laneq_u32 (uint32x4_t vec, const int lane); A32: VDUP.32 Dd, Dm[index]; A64: DUP Vd.2S, Vn.S[index]
            // DuplicateSelectedScalarToVector64(Vector64<Byte>, Byte)	uint8x8_t vdup_lane_u8 (uint8x8_t vec, const int lane); A32: VDUP.8 Dd, Dm[index]; A64: DUP Vd.8B, Vn.B[index]
            // DuplicateSelectedScalarToVector64(Vector64<Int16>, Byte)	int16x4_t vdup_lane_s16 (int16x4_t vec, const int lane); A32: VDUP.16 Dd, Dm[index]; A64: DUP Vd.4H, Vn.H[index]
            // DuplicateSelectedScalarToVector64(Vector64<Int32>, Byte)	int32x2_t vdup_lane_s32 (int32x2_t vec, const int lane); A32: VDUP.32 Dd, Dm[index]; A64: DUP Vd.2S, Vn.S[index]
            // DuplicateSelectedScalarToVector64(Vector64<SByte>, Byte)	int8x8_t vdup_lane_s8 (int8x8_t vec, const int lane); A32: VDUP.8 Dd, Dm[index]; A64: DUP Vd.8B, Vn.B[index]
            // DuplicateSelectedScalarToVector64(Vector64<Single>, Byte)	float32x2_t vdup_lane_f32 (float32x2_t vec, const int lane); A32: VDUP.32 Dd, Dm[index]; A64: DUP Vd.2S, Vn.S[index]
            // DuplicateSelectedScalarToVector64(Vector64<UInt16>, Byte)	uint16x4_t vdup_lane_u16 (uint16x4_t vec, const int lane); A32: VDUP.16 Dd, Dm[index]; A64: DUP Vd.4H, Vn.H[index]
            // DuplicateSelectedScalarToVector64(Vector64<UInt32>, Byte)	uint32x2_t vdup_lane_u32 (uint32x2_t vec, const int lane); A32: VDUP.32 Dd, Dm[index]; A64: DUP Vd.2S, Vn.S[index]
            // DuplicateToVector128(Byte)	uint8x16_t vdupq_n_u8 (uint8_t value); A32: VDUP.8 Qd, Rt; A64: DUP Vd.16B, Rn
            // DuplicateToVector128(Int16)	int16x8_t vdupq_n_s16 (int16_t value); A32: VDUP.16 Qd, Rt; A64: DUP Vd.8H, Rn
            // DuplicateToVector128(Int32)	int32x4_t vdupq_n_s32 (int32_t value); A32: VDUP.32 Qd, Rt; A64: DUP Vd.4S, Rn
            // DuplicateToVector128(SByte)	int8x16_t vdupq_n_s8 (int8_t value); A32: VDUP.8 Qd, Rt; A64: DUP Vd.16B, Rn
            // DuplicateToVector128(Single)	float32x4_t vdupq_n_f32 (float32_t value); A32: VDUP Qd, Dm[0]; A64: DUP Vd.4S, Vn.S[0]
            // DuplicateToVector128(UInt16)	uint16x8_t vdupq_n_u16 (uint16_t value); A32: VDUP.16 Qd, Rt; A64: DUP Vd.8H, Rn
            // DuplicateToVector128(UInt32)	uint32x4_t vdupq_n_u32 (uint32_t value); A32: VDUP.32 Qd, Rt; A64: DUP Vd.4S, Rn
            // DuplicateToVector64(Byte)	uint8x8_t vdup_n_u8 (uint8_t value); A32: VDUP.8 Dd, Rt; A64: DUP Vd.8B, Rn
            // DuplicateToVector64(Int16)	int16x4_t vdup_n_s16 (int16_t value); A32: VDUP.16 Dd, Rt; A64: DUP Vd.4H, Rn
            // DuplicateToVector64(Int32)	int32x2_t vdup_n_s32 (int32_t value); A32: VDUP.32 Dd, Rt; A64: DUP Vd.2S, Rn
            // DuplicateToVector64(SByte)	int8x8_t vdup_n_s8 (int8_t value); A32: VDUP.8 Dd, Rt; A64: DUP Vd.8B, Rn
            // DuplicateToVector64(Single)	float32x2_t vdup_n_f32 (float32_t value); A32: VDUP Dd, Dm[0]; A64: DUP Vd.2S, Vn.S[0]
            // DuplicateToVector64(UInt16)	uint16x4_t vdup_n_u16 (uint16_t value); A32: VDUP.16 Dd, Rt; A64: DUP Vd.4H, Rn
            // DuplicateToVector64(UInt32)	uint32x2_t vdup_n_u32 (uint32_t value); A32: VDUP.32 Dd, Rt; A64: DUP Vd.2S, Rn
        }
        public unsafe static void RunArm_AdvSimd_E(TextWriter writer, string indent) {
            // Extract(Vector128<Byte>, Byte)	uint8_t vgetq_lane_u8 (uint8x16_t v, const int lane); A32: VMOV.U8 Rt, Dn[lane]; A64: UMOV Wd, Vn.B[lane]
            // Extract(Vector128<Double>, Byte)	float64_t vgetq_lane_f64 (float64x2_t v, const int lane); A32: VMOV.F64 Dd, Dm; A64: DUP Dd, Vn.D[lane]
            // Extract(Vector128<Int16>, Byte)	int16_t vgetq_lane_s16 (int16x8_t v, const int lane); A32: VMOV.S16 Rt, Dn[lane]; A64: SMOV Wd, Vn.H[lane]
            // Extract(Vector128<Int32>, Byte)	int32_t vgetq_lane_s32 (int32x4_t v, const int lane); A32: VMOV.32 Rt, Dn[lane]; A64: SMOV Wd, Vn.S[lane]
            // Extract(Vector128<Int64>, Byte)	int64_t vgetq_lane_s64 (int64x2_t v, const int lane); A32: VMOV Rt, Rt2, Dm; A64: UMOV Xd, Vn.D[lane]
            // Extract(Vector128<SByte>, Byte)	int8_t vgetq_lane_s8 (int8x16_t v, const int lane); A32: VMOV.S8 Rt, Dn[lane]; A64: SMOV Wd, Vn.B[lane]
            // Extract(Vector128<Single>, Byte)	float32_t vgetq_lane_f32 (float32x4_t v, const int lane); A32: VMOV.F32 Sd, Sm; A64: DUP Sd, Vn.S[lane]
            // Extract(Vector128<UInt16>, Byte)	uint16_t vgetq_lane_u16 (uint16x8_t v, const int lane); A32: VMOV.U16 Rt, Dn[lane]; A64: UMOV Wd, Vn.H[lane]
            // Extract(Vector128<UInt32>, Byte)	uint32_t vgetq_lane_u32 (uint32x4_t v, const int lane); A32: VMOV.32 Rt, Dn[lane]; A64: UMOV Wd, Vn.S[lane]
            // Extract(Vector128<UInt64>, Byte)	uint64_t vgetq_lane_u64 (uint64x2_t v, const int lane); A32: VMOV Rt, Rt2, Dm; A64: UMOV Xd, Vn.D[lane]
            // Extract(Vector64<Byte>, Byte)	uint8_t vget_lane_u8 (uint8x8_t v, const int lane); A32: VMOV.U8 Rt, Dn[lane]; A64: UMOV Wd, Vn.B[lane]
            // Extract(Vector64<Int16>, Byte)	int16_t vget_lane_s16 (int16x4_t v, const int lane); A32: VMOV.S16 Rt, Dn[lane]; A64: SMOV Wd, Vn.H[lane]
            // Extract(Vector64<Int32>, Byte)	int32_t vget_lane_s32 (int32x2_t v, const int lane); A32: VMOV.32 Rt, Dn[lane]; A64: SMOV Wd, Vn.S[lane]
            // Extract(Vector64<SByte>, Byte)	int8_t vget_lane_s8 (int8x8_t v, const int lane); A32: VMOV.S8 Rt, Dn[lane]; A64: SMOV Wd, Vn.B[lane]
            // Extract(Vector64<Single>, Byte)	float32_t vget_lane_f32 (float32x2_t v, const int lane); A32: VMOV.F32 Sd, Sm; A64: DUP Sd, Vn.S[lane]
            // Extract(Vector64<UInt16>, Byte)	uint16_t vget_lane_u16 (uint16x4_t v, const int lane); A32: VMOV.U16 Rt, Dn[lane]; A64: UMOV Wd, Vn.H[lane]
            // Extract(Vector64<UInt32>, Byte)	uint32_t vget_lane_u32 (uint32x2_t v, const int lane); A32: VMOV.32 Rt, Dn[lane]; A64: UMOV Wd, Vn.S[lane]
            // ExtractNarrowingLower(Vector128<Int16>)	int8x8_t vmovn_s16 (int16x8_t a); A32: VMOVN.I16 Dd, Qm; A64: XTN Vd.8B, Vn.8H
            // ExtractNarrowingLower(Vector128<Int32>)	int16x4_t vmovn_s32 (int32x4_t a); A32: VMOVN.I32 Dd, Qm; A64: XTN Vd.4H, Vn.4S
            // ExtractNarrowingLower(Vector128<Int64>)	int32x2_t vmovn_s64 (int64x2_t a); A32: VMOVN.I64 Dd, Qm; A64: XTN Vd.2S, Vn.2D
            // ExtractNarrowingLower(Vector128<UInt16>)	uint8x8_t vmovn_u16 (uint16x8_t a); A32: VMOVN.I16 Dd, Qm; A64: XTN Vd.8B, Vn.8H
            // ExtractNarrowingLower(Vector128<UInt32>)	uint16x4_t vmovn_u32 (uint32x4_t a); A32: VMOVN.I32 Dd, Qm; A64: XTN Vd.4H, Vn.4S
            // ExtractNarrowingLower(Vector128<UInt64>)	uint32x2_t vmovn_u64 (uint64x2_t a); A32: VMOVN.I64 Dd, Qm; A64: XTN Vd.2S, Vn.2D
            // ExtractNarrowingSaturateLower(Vector128<Int16>)	int8x8_t vqmovn_s16 (int16x8_t a) A32: VQMOVN.S16 Dd, Qm A64: SQXTN Vd.8B, Vn.8H
            // ExtractNarrowingSaturateLower(Vector128<Int32>)	int16x4_t vqmovn_s32 (int32x4_t a) A32: VQMOVN.S32 Dd, Qm A64: SQXTN Vd.4H, Vn.4S
            // ExtractNarrowingSaturateLower(Vector128<Int64>)	int32x2_t vqmovn_s64 (int64x2_t a) A32: VQMOVN.S64 Dd, Qm A64: SQXTN Vd.2S, Vn.2D
            // ExtractNarrowingSaturateLower(Vector128<UInt16>)	uint8x8_t vqmovn_u16 (uint16x8_t a) A32: VQMOVN.U16 Dd, Qm A64: UQXTN Vd.8B, Vn.8H
            // ExtractNarrowingSaturateLower(Vector128<UInt32>)	uint16x4_t vqmovn_u32 (uint32x4_t a) A32: VQMOVN.U32 Dd, Qm A64: UQXTN Vd.4H, Vn.4S
            // ExtractNarrowingSaturateLower(Vector128<UInt64>)	uint32x2_t vqmovn_u64 (uint64x2_t a) A32: VQMOVN.U64 Dd, Qm A64: UQXTN Vd.2S, Vn.2D
            // ExtractNarrowingSaturateUnsignedLower(Vector128<Int16>)	uint8x8_t vqmovun_s16 (int16x8_t a) A32: VQMOVUN.S16 Dd, Qm A64: SQXTUN Vd.8B, Vn.8H
            // ExtractNarrowingSaturateUnsignedLower(Vector128<Int32>)	uint16x4_t vqmovun_s32 (int32x4_t a) A32: VQMOVUN.S32 Dd, Qm A64: SQXTUN Vd.4H, Vn.4S
            // ExtractNarrowingSaturateUnsignedLower(Vector128<Int64>)	uint32x2_t vqmovun_s64 (int64x2_t a) A32: VQMOVUN.S64 Dd, Qm A64: SQXTUN Vd.2S, Vn.2D
            // ExtractNarrowingSaturateUnsignedUpper(Vector64<Byte>, Vector128<Int16>)	uint8x16_t vqmovun_high_s16 (uint8x8_t r, int16x8_t a) A32: VQMOVUN.S16 Dd+1, Qm A64: SQXTUN2 Vd.16B, Vn.8H
            // ExtractNarrowingSaturateUnsignedUpper(Vector64<UInt16>, Vector128<Int32>)	uint16x8_t vqmovun_high_s32 (uint16x4_t r, int32x4_t a) A32: VQMOVUN.S32 Dd+1, Qm A64: SQXTUN2 Vd.8H, Vn.4S
            // ExtractNarrowingSaturateUnsignedUpper(Vector64<UInt32>, Vector128<Int64>)	uint32x4_t vqmovun_high_s64 (uint32x2_t r, int64x2_t a) A32: VQMOVUN.S64 Dd+1, Qm A64: SQXTUN2 Vd.4S, Vn.2D
            // ExtractNarrowingSaturateUpper(Vector64<Byte>, Vector128<UInt16>)	uint8x16_t vqmovn_high_u16 (uint8x8_t r, uint16x8_t a) A32: VQMOVN.U16 Dd+1, Qm A64: UQXTN2 Vd.16B, Vn.8H
            // ExtractNarrowingSaturateUpper(Vector64<Int16>, Vector128<Int32>)	int16x8_t vqmovn_high_s32 (int16x4_t r, int32x4_t a) A32: VQMOVN.S32 Dd+1, Qm A64: SQXTN2 Vd.8H, Vn.4S
            // ExtractNarrowingSaturateUpper(Vector64<Int32>, Vector128<Int64>)	int32x4_t vqmovn_high_s64 (int32x2_t r, int64x2_t a) A32: VQMOVN.S64 Dd+1, Qm A64: SQXTN2 Vd.4S, Vn.2D
            // ExtractNarrowingSaturateUpper(Vector64<SByte>, Vector128<Int16>)	int8x16_t vqmovn_high_s16 (int8x8_t r, int16x8_t a) A32: VQMOVN.S16 Dd+1, Qm A64: SQXTN2 Vd.16B, Vn.8H
            // ExtractNarrowingSaturateUpper(Vector64<UInt16>, Vector128<UInt32>)	uint16x8_t vqmovn_high_u32 (uint16x4_t r, uint32x4_t a) A32: VQMOVN.U32 Dd+1, Qm A64: UQXTN2 Vd.8H, Vn.4S
            // ExtractNarrowingSaturateUpper(Vector64<UInt32>, Vector128<UInt64>)	uint32x4_t vqmovn_high_u64 (uint32x2_t r, uint64x2_t a) A32: VQMOVN.U64 Dd+1, Qm A64: UQXTN2 Vd.4S, Vn.2D
            // ExtractNarrowingUpper(Vector64<Byte>, Vector128<UInt16>)	uint8x16_t vmovn_high_u16 (uint8x8_t r, uint16x8_t a); A32: VMOVN.I16 Dd+1, Qm; A64: XTN2 Vd.16B, Vn.8H
            // ExtractNarrowingUpper(Vector64<Int16>, Vector128<Int32>)	int16x8_t vmovn_high_s32 (int16x4_t r, int32x4_t a); A32: VMOVN.I32 Dd+1, Qm; A64: XTN2 Vd.8H, Vn.4S
            // ExtractNarrowingUpper(Vector64<Int32>, Vector128<Int64>)	int32x4_t vmovn_high_s64 (int32x2_t r, int64x2_t a); A32: VMOVN.I64 Dd+1, Qm; A64: XTN2 Vd.4S, Vn.2D
            // ExtractNarrowingUpper(Vector64<SByte>, Vector128<Int16>)	int8x16_t vmovn_high_s16 (int8x8_t r, int16x8_t a); A32: VMOVN.I16 Dd+1, Qm; A64: XTN2 Vd.16B, Vn.8H
            // ExtractNarrowingUpper(Vector64<UInt16>, Vector128<UInt32>)	uint16x8_t vmovn_high_u32 (uint16x4_t r, uint32x4_t a); A32: VMOVN.I32 Dd+1, Qm; A64: XTN2 Vd.8H, Vn.4S
            // ExtractNarrowingUpper(Vector64<UInt32>, Vector128<UInt64>)	uint32x4_t vmovn_high_u64 (uint32x2_t r, uint64x2_t a); A32: VMOVN.I64 Dd+1, Qm; A64: XTN2 Vd.4S, Vn.2D
            // ExtractVector128(Vector128<Byte>, Vector128<Byte>, Byte)	uint8x16_t vextq_s8 (uint8x16_t a, uint8x16_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #n; A64: EXT Vd.16B, Vn.16B, Vm.16B, #n
            // ExtractVector128(Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vextq_f64 (float64x2_t a, float64x2_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #(n*8); A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*8)
            // ExtractVector128(Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vextq_s16 (int16x8_t a, int16x8_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #(n*2); A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*2)
            // ExtractVector128(Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vextq_s32 (int32x4_t a, int32x4_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #(n*4); A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*4)
            // ExtractVector128(Vector128<Int64>, Vector128<Int64>, Byte)	int64x2_t vextq_s64 (int64x2_t a, int64x2_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #(n*8); A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*8)
            // ExtractVector128(Vector128<SByte>, Vector128<SByte>, Byte)	int8x16_t vextq_s8 (int8x16_t a, int8x16_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #n; A64: EXT Vd.16B, Vn.16B, Vm.16B, #n
            // ExtractVector128(Vector128<Single>, Vector128<Single>, Byte)	float32x4_t vextq_f32 (float32x4_t a, float32x4_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #(n*4); A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*4)
            // ExtractVector128(Vector128<UInt16>, Vector128<UInt16>, Byte)	uint16x8_t vextq_s16 (uint16x8_t a, uint16x8_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #(n*2); A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*2)
            // ExtractVector128(Vector128<UInt32>, Vector128<UInt32>, Byte)	uint32x4_t vextq_s32 (uint32x4_t a, uint32x4_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #(n*4); A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*4)
            // ExtractVector128(Vector128<UInt64>, Vector128<UInt64>, Byte)	uint64x2_t vextq_s64 (uint64x2_t a, uint64x2_t b, const int n); A32: VEXT.8 Qd, Qn, Qm, #(n*8); A64: EXT Vd.16B, Vn.16B, Vm.16B, #(n*8)
            // ExtractVector64(Vector64<Byte>, Vector64<Byte>, Byte)	uint8x8_t vext_s8 (uint8x8_t a, uint8x8_t b, const int n); A32: VEXT.8 Dd, Dn, Dm, #n; A64: EXT Vd.8B, Vn.8B, Vm.8B, #n
            // ExtractVector64(Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vext_s16 (int16x4_t a, int16x4_t b, const int n); A32: VEXT.8 Dd, Dn, Dm, #(n*2); A64: EXT Vd.8B, Vn.8B, Vm.8B, #(n*2)
            // ExtractVector64(Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vext_s32 (int32x2_t a, int32x2_t b, const int n); A32: VEXT.8 Dd, Dn, Dm, #(n*4); A64: EXT Vd.8B, Vn.8B, Vm.8B, #(n*4)
            // ExtractVector64(Vector64<SByte>, Vector64<SByte>, Byte)	int8x8_t vext_s8 (int8x8_t a, int8x8_t b, const int n); A32: VEXT.8 Dd, Dn, Dm, #n; A64: EXT Vd.8B, Vn.8B, Vm.8B, #n
            // ExtractVector64(Vector64<Single>, Vector64<Single>, Byte)	float32x2_t vext_f32 (float32x2_t a, float32x2_t b, const int n); A32: VEXT.8 Dd, Dn, Dm, #(n*4); A64: EXT Vd.8B, Vn.8B, Vm.8B, #(n*4)
            // ExtractVector64(Vector64<UInt16>, Vector64<UInt16>, Byte)	uint16x4_t vext_s16 (uint16x4_t a, uint16x4_t b, const int n); A32: VEXT.8 Dd, Dn, Dm, #(n*2); A64: EXT Vd.8B, Vn.8B, Vm.8B, #(n*2)
            // ExtractVector64(Vector64<UInt32>, Vector64<UInt32>, Byte)	uint32x2_t vext_s32 (uint32x2_t a, uint32x2_t b, const int n); A32: VEXT.8 Dd, Dn, Dm, #(n*4); A64: EXT Vd.8B, Vn.8B, Vm.8B, #(n*4)
        }
        public unsafe static void RunArm_AdvSimd_F(TextWriter writer, string indent) {
            // Floor(Vector128<Single>)	float32x4_t vrndmq_f32 (float32x4_t a); A32: VRINTM.F32 Qd, Qm; A64: FRINTM Vd.4S, Vn.4S
            // Floor(Vector64<Single>)	float32x2_t vrndm_f32 (float32x2_t a); A32: VRINTM.F32 Dd, Dm; A64: FRINTM Vd.2S, Vn.2S
            // FloorScalar(Vector64<Double>)	float64x1_t vrndm_f64 (float64x1_t a); A32: VRINTM.F64 Dd, Dm; A64: FRINTM Dd, Dn
            // FloorScalar(Vector64<Single>)	float32_t vrndms_f32 (float32_t a); A32: VRINTM.F32 Sd, Sm; A64: FRINTM Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // FusedAddHalving(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vhaddq_u8 (uint8x16_t a, uint8x16_t b); A32: VHADD.U8 Qd, Qn, Qm; A64: UHADD Vd.16B, Vn.16B, Vm.16B
            // FusedAddHalving(Vector128<Int16>, Vector128<Int16>)	int16x8_t vhaddq_s16 (int16x8_t a, int16x8_t b); A32: VHADD.S16 Qd, Qn, Qm; A64: SHADD Vd.8H, Vn.8H, Vm.8H
            // FusedAddHalving(Vector128<Int32>, Vector128<Int32>)	int32x4_t vhaddq_s32 (int32x4_t a, int32x4_t b); A32: VHADD.S32 Qd, Qn, Qm; A64: SHADD Vd.4S, Vn.4S, Vm.4S
            // FusedAddHalving(Vector128<SByte>, Vector128<SByte>)	int8x16_t vhaddq_s8 (int8x16_t a, int8x16_t b); A32: VHADD.S8 Qd, Qn, Qm; A64: SHADD Vd.16B, Vn.16B, Vm.16B
            // FusedAddHalving(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vhaddq_u16 (uint16x8_t a, uint16x8_t b); A32: VHADD.U16 Qd, Qn, Qm; A64: UHADD Vd.8H, Vn.8H, Vm.8H
            // FusedAddHalving(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vhaddq_u32 (uint32x4_t a, uint32x4_t b); A32: VHADD.U32 Qd, Qn, Qm; A64: UHADD Vd.4S, Vn.4S, Vm.4S
            // FusedAddHalving(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vhadd_u8 (uint8x8_t a, uint8x8_t b); A32: VHADD.U8 Dd, Dn, Dm; A64: UHADD Vd.8B, Vn.8B, Vm.8B
            // FusedAddHalving(Vector64<Int16>, Vector64<Int16>)	int16x4_t vhadd_s16 (int16x4_t a, int16x4_t b); A32: VHADD.S16 Dd, Dn, Dm; A64: SHADD Vd.4H, Vn.4H, Vm.4H
            // FusedAddHalving(Vector64<Int32>, Vector64<Int32>)	int32x2_t vhadd_s32 (int32x2_t a, int32x2_t b); A32: VHADD.S32 Dd, Dn, Dm; A64: SHADD Vd.2S, Vn.2S, Vm.2S
            // FusedAddHalving(Vector64<SByte>, Vector64<SByte>)	int8x8_t vhadd_s8 (int8x8_t a, int8x8_t b); A32: VHADD.S8 Dd, Dn, Dm; A64: SHADD Vd.8B, Vn.8B, Vm.8B
            // FusedAddHalving(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vhadd_u16 (uint16x4_t a, uint16x4_t b); A32: VHADD.U16 Dd, Dn, Dm; A64: UHADD Vd.4H, Vn.4H, Vm.4H
            // FusedAddHalving(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vhadd_u32 (uint32x2_t a, uint32x2_t b); A32: VHADD.U32 Dd, Dn, Dm; A64: UHADD Vd.2S, Vn.2S, Vm.2S
            // FusedAddRoundedHalving(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vrhaddq_u8 (uint8x16_t a, uint8x16_t b); A32: VRHADD.U8 Qd, Qn, Qm; A64: URHADD Vd.16B, Vn.16B, Vm.16B
            // FusedAddRoundedHalving(Vector128<Int16>, Vector128<Int16>)	int16x8_t vrhaddq_s16 (int16x8_t a, int16x8_t b); A32: VRHADD.S16 Qd, Qn, Qm; A64: SRHADD Vd.8H, Vn.8H, Vm.8H
            // FusedAddRoundedHalving(Vector128<Int32>, Vector128<Int32>)	int32x4_t vrhaddq_s32 (int32x4_t a, int32x4_t b); A32: VRHADD.S32 Qd, Qn, Qm; A64: SRHADD Vd.4S, Vn.4S, Vm.4S
            // FusedAddRoundedHalving(Vector128<SByte>, Vector128<SByte>)	int8x16_t vrhaddq_s8 (int8x16_t a, int8x16_t b); A32: VRHADD.S8 Qd, Qn, Qm; A64: SRHADD Vd.16B, Vn.16B, Vm.16B
            // FusedAddRoundedHalving(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vrhaddq_u16 (uint16x8_t a, uint16x8_t b); A32: VRHADD.U16 Qd, Qn, Qm; A64: URHADD Vd.8H, Vn.8H, Vm.8H
            // FusedAddRoundedHalving(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vrhaddq_u32 (uint32x4_t a, uint32x4_t b); A32: VRHADD.U32 Qd, Qn, Qm; A64: URHADD Vd.4S, Vn.4S, Vm.4S
            // FusedAddRoundedHalving(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vrhadd_u8 (uint8x8_t a, uint8x8_t b); A32: VRHADD.U8 Dd, Dn, Dm; A64: URHADD Vd.8B, Vn.8B, Vm.8B
            // FusedAddRoundedHalving(Vector64<Int16>, Vector64<Int16>)	int16x4_t vrhadd_s16 (int16x4_t a, int16x4_t b); A32: VRHADD.S16 Dd, Dn, Dm; A64: SRHADD Vd.4H, Vn.4H, Vm.4H
            // FusedAddRoundedHalving(Vector64<Int32>, Vector64<Int32>)	int32x2_t vrhadd_s32 (int32x2_t a, int32x2_t b); A32: VRHADD.S32 Dd, Dn, Dm; A64: SRHADD Vd.2S, Vn.2S, Vm.2S
            // FusedAddRoundedHalving(Vector64<SByte>, Vector64<SByte>)	int8x8_t vrhadd_s8 (int8x8_t a, int8x8_t b); A32: VRHADD.S8 Dd, Dn, Dm; A64: SRHADD Vd.8B, Vn.8B, Vm.8B
            // FusedAddRoundedHalving(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vrhadd_u16 (uint16x4_t a, uint16x4_t b); A32: VRHADD.U16 Dd, Dn, Dm; A64: URHADD Vd.4H, Vn.4H, Vm.4H
            // FusedAddRoundedHalving(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vrhadd_u32 (uint32x2_t a, uint32x2_t b); A32: VRHADD.U32 Dd, Dn, Dm; A64: URHADD Vd.2S, Vn.2S, Vm.2S
            // FusedMultiplyAdd(Vector128<Single>, Vector128<Single>, Vector128<Single>)	float32x4_t vfmaq_f32 (float32x4_t a, float32x4_t b, float32x4_t c); A32: VFMA.F32 Qd, Qn, Qm; A64: FMLA Vd.4S, Vn.4S, Vm.4S
            // FusedMultiplyAdd(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32x2_t vfma_f32 (float32x2_t a, float32x2_t b, float32x2_t c); A32: VFMA.F32 Dd, Dn, Dm; A64: FMLA Vd.2S, Vn.2S, Vm.2S
            // FusedMultiplyAddNegatedScalar(Vector64<Double>, Vector64<Double>, Vector64<Double>)	float64x1_t vfnma_f64 (float64x1_t a, float64x1_t b, float64x1_t c); A32: VFNMA.F64 Dd, Dn, Dm; A64: FNMADD Dd, Dn, Dm, Da The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // FusedMultiplyAddNegatedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32_t vfnmas_f32 (float32_t a, float32_t b, float32_t c); A32: VFNMA.F32 Sd, Sn, Sm; A64: FNMADD Sd, Sn, Sm, Sa The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // FusedMultiplyAddScalar(Vector64<Double>, Vector64<Double>, Vector64<Double>)	float64x1_t vfma_f64 (float64x1_t a, float64x1_t b, float64x1_t c); A32: VFMA.F64 Dd, Dn, Dm; A64: FMADD Dd, Dn, Dm, Da
            // FusedMultiplyAddScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32_t vfmas_f32 (float32_t a, float32_t b, float32_t c); A32: VFMA.F32 Sd, Sn, Sm; A64: FMADD Sd, Sn, Sm, Sa The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // FusedMultiplySubtract(Vector128<Single>, Vector128<Single>, Vector128<Single>)	float32x4_t vfmsq_f32 (float32x4_t a, float32x4_t b, float32x4_t c); A32: VFMS.F32 Qd, Qn, Qm; A64: FMLS Vd.4S, Vn.4S, Vm.4S
            // FusedMultiplySubtract(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32x2_t vfms_f32 (float32x2_t a, float32x2_t b, float32x2_t c); A32: VFMS.F32 Dd, Dn, Dm; A64: FMLS Vd.2S, Vn.2S, Vm.2S
            // FusedMultiplySubtractNegatedScalar(Vector64<Double>, Vector64<Double>, Vector64<Double>)	float64x1_t vfnms_f64 (float64x1_t a, float64x1_t b, float64x1_t c); A32: VFNMS.F64 Dd, Dn, Dm; A64: FNMSUB Dd, Dn, Dm, Da The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // FusedMultiplySubtractNegatedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32_t vfnmss_f32 (float32_t a, float32_t b, float32_t c); A32: VFNMS.F32 Sd, Sn, Sm; A64: FNMSUB Sd, Sn, Sm, Sa The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // FusedMultiplySubtractScalar(Vector64<Double>, Vector64<Double>, Vector64<Double>)	float64x1_t vfms_f64 (float64x1_t a, float64x1_t b, float64x1_t c); A32: VFMS.F64 Dd, Dn, Dm; A64: FMSUB Dd, Dn, Dm, Da
            // FusedMultiplySubtractScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32_t vfmss_f32 (float32_t a, float32_t b, float32_t c); A32: VFMS.F32 Sd, Sn, Sm; A64: FMSUB Sd, Sn, Sm, Sa The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // FusedSubtractHalving(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vhsubq_u8 (uint8x16_t a, uint8x16_t b); A32: VHSUB.U8 Qd, Qn, Qm; A64: UHSUB Vd.16B, Vn.16B, Vm.16B
            // FusedSubtractHalving(Vector128<Int16>, Vector128<Int16>)	int16x8_t vhsubq_s16 (int16x8_t a, int16x8_t b); A32: VHSUB.S16 Qd, Qn, Qm; A64: SHSUB Vd.8H, Vn.8H, Vm.8H
            // FusedSubtractHalving(Vector128<Int32>, Vector128<Int32>)	int32x4_t vhsubq_s32 (int32x4_t a, int32x4_t b); A32: VHSUB.S32 Qd, Qn, Qm; A64: SHSUB Vd.4S, Vn.4S, Vm.4S
            // FusedSubtractHalving(Vector128<SByte>, Vector128<SByte>)	int8x16_t vhsubq_s8 (int8x16_t a, int8x16_t b); A32: VHSUB.S8 Qd, Qn, Qm; A64: SHSUB Vd.16B, Vn.16B, Vm.16B
            // FusedSubtractHalving(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vhsubq_u16 (uint16x8_t a, uint16x8_t b); A32: VHSUB.U16 Qd, Qn, Qm; A64: UHSUB Vd.8H, Vn.8H, Vm.8H
            // FusedSubtractHalving(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vhsubq_u32 (uint32x4_t a, uint32x4_t b); A32: VHSUB.U32 Qd, Qn, Qm; A64: UHSUB Vd.4S, Vn.4S, Vm.4S
            // FusedSubtractHalving(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vhsub_u8 (uint8x8_t a, uint8x8_t b); A32: VHSUB.U8 Dd, Dn, Dm; A64: UHSUB Vd.8B, Vn.8B, Vm.8B
            // FusedSubtractHalving(Vector64<Int16>, Vector64<Int16>)	int16x4_t vhsub_s16 (int16x4_t a, int16x4_t b); A32: VHSUB.S16 Dd, Dn, Dm; A64: SHSUB Vd.4H, Vn.4H, Vm.4H
            // FusedSubtractHalving(Vector64<Int32>, Vector64<Int32>)	int32x2_t vhsub_s32 (int32x2_t a, int32x2_t b); A32: VHSUB.S32 Dd, Dn, Dm; A64: SHSUB Vd.2S, Vn.2S, Vm.2S
            // FusedSubtractHalving(Vector64<SByte>, Vector64<SByte>)	int8x8_t vhsub_s8 (int8x8_t a, int8x8_t b); A32: VHSUB.S8 Dd, Dn, Dm; A64: SHSUB Vd.8B, Vn.8B, Vm.8B
            // FusedSubtractHalving(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vhsub_u16 (uint16x4_t a, uint16x4_t b); A32: VHSUB.U16 Dd, Dn, Dm; A64: UHSUB Vd.4H, Vn.4H, Vm.4H
            // FusedSubtractHalving(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vhsub_u32 (uint32x2_t a, uint32x2_t b); A32: VHSUB.U32 Dd, Dn, Dm; A64: UHSUB Vd.2S, Vn.2S, Vm.2S
        }
        public unsafe static void RunArm_AdvSimd_I(TextWriter writer, string indent) {
            // Insert(Vector128<Byte>, Byte, Byte)	uint8x16_t vsetq_lane_u8 (uint8_t a, uint8x16_t v, const int lane); A32: VMOV.8 Dd[lane], Rt; A64: INS Vd.B[lane], Wn
            // Insert(Vector128<Double>, Byte, Double)	float64x2_t vsetq_lane_f64 (float64_t a, float64x2_t v, const int lane); A32: VMOV.F64 Dd, Dm; A64: INS Vd.D[lane], Vn.D[0]
            // Insert(Vector128<Int16>, Byte, Int16)	int16x8_t vsetq_lane_s16 (int16_t a, int16x8_t v, const int lane); A32: VMOV.16 Dd[lane], Rt; A64: INS Vd.H[lane], Wn
            // Insert(Vector128<Int32>, Byte, Int32)	int32x4_t vsetq_lane_s32 (int32_t a, int32x4_t v, const int lane); A32: VMOV.32 Dd[lane], Rt; A64: INS Vd.S[lane], Wn
            // Insert(Vector128<Int64>, Byte, Int64)	int64x2_t vsetq_lane_s64 (int64_t a, int64x2_t v, const int lane); A32: VMOV.64 Dd, Rt, Rt2; A64: INS Vd.D[lane], Xn
            // Insert(Vector128<SByte>, Byte, SByte)	int8x16_t vsetq_lane_s8 (int8_t a, int8x16_t v, const int lane); A32: VMOV.8 Dd[lane], Rt; A64: INS Vd.B[lane], Wn
            // Insert(Vector128<Single>, Byte, Single)	float32x4_t vsetq_lane_f32 (float32_t a, float32x4_t v, const int lane); A32: VMOV.F32 Sd, Sm; A64: INS Vd.S[lane], Vn.S[0]
            // Insert(Vector128<UInt16>, Byte, UInt16)	uint16x8_t vsetq_lane_u16 (uint16_t a, uint16x8_t v, const int lane); A32: VMOV.16 Dd[lane], Rt; A64: INS Vd.H[lane], Wn
            // Insert(Vector128<UInt32>, Byte, UInt32)	uint32x4_t vsetq_lane_u32 (uint32_t a, uint32x4_t v, const int lane); A32: VMOV.32 Dd[lane], Rt; A64: INS Vd.S[lane], Wn
            // Insert(Vector128<UInt64>, Byte, UInt64)	uint64x2_t vsetq_lane_u64 (uint64_t a, uint64x2_t v, const int lane); A32: VMOV.64 Dd, Rt, Rt2; A64: INS Vd.D[lane], Xn
            // Insert(Vector64<Byte>, Byte, Byte)	uint8x8_t vset_lane_u8 (uint8_t a, uint8x8_t v, const int lane); A32: VMOV.8 Dd[lane], Rt; A64: INS Vd.B[lane], Wn
            // Insert(Vector64<Int16>, Byte, Int16)	int16x4_t vset_lane_s16 (int16_t a, int16x4_t v, const int lane); A32: VMOV.16 Dd[lane], Rt; A64: INS Vd.H[lane], Wn
            // Insert(Vector64<Int32>, Byte, Int32)	int32x2_t vset_lane_s32 (int32_t a, int32x2_t v, const int lane); A32: VMOV.32 Dd[lane], Rt; A64: INS Vd.S[lane], Wn
            // Insert(Vector64<SByte>, Byte, SByte)	int8x8_t vset_lane_s8 (int8_t a, int8x8_t v, const int lane); A32: VMOV.8 Dd[lane], Rt; A64: INS Vd.B[lane], Wn
            // Insert(Vector64<Single>, Byte, Single)	float32x2_t vset_lane_f32 (float32_t a, float32x2_t v, const int lane); A32: VMOV.F32 Sd, Sm; A64: INS Vd.S[lane], Vn.S[0]
            // Insert(Vector64<UInt16>, Byte, UInt16)	uint16x4_t vset_lane_u16 (uint16_t a, uint16x4_t v, const int lane); A32: VMOV.16 Dd[lane], Rt; A64: INS Vd.H[lane], Wn
            // Insert(Vector64<UInt32>, Byte, UInt32)	uint32x2_t vset_lane_u32 (uint32_t a, uint32x2_t v, const int lane); A32: VMOV.32 Dd[lane], Rt; A64: INS Vd.S[lane], Wn
            // InsertScalar(Vector128<Double>, Byte, Vector64<Double>)	float64x2_t vcopyq_lane_f64 (float64x2_t a, const int lane1, float64x1_t b, const int lane2) A32: VMOV.F64 Dd, Dm A64: INS Vd.D[lane1], Vn.D[0]
            // InsertScalar(Vector128<Int64>, Byte, Vector64<Int64>)	int64x2_t vcopyq_lane_s64 (int64x2_t a, const int lane1, int64x1_t b, const int lane2) A32: VMOV Dd, Dm A64: INS Vd.D[lane1], Vn.D[0]
            // InsertScalar(Vector128<UInt64>, Byte, Vector64<UInt64>)	uint64x2_t vcopyq_lane_u64 (uint64x2_t a, const int lane1, uint64x1_t b, const int lane2) A32: VMOV Dd, Dm A64: INS Vd.D[lane1], Vn.D[0]
        }
        public unsafe static void RunArm_AdvSimd_L(TextWriter writer, string indent) {
            // LeadingSignCount(Vector128<Int16>)	int16x8_t vclsq_s16 (int16x8_t a); A32: VCLS.S16 Qd, Qm; A64: CLS Vd.8H, Vn.8H
            // LeadingSignCount(Vector128<Int32>)	int32x4_t vclsq_s32 (int32x4_t a); A32: VCLS.S32 Qd, Qm; A64: CLS Vd.4S, Vn.4S
            // LeadingSignCount(Vector128<SByte>)	int8x16_t vclsq_s8 (int8x16_t a); A32: VCLS.S8 Qd, Qm; A64: CLS Vd.16B, Vn.16B
            // LeadingSignCount(Vector64<Int16>)	int16x4_t vcls_s16 (int16x4_t a); A32: VCLS.S16 Dd, Dm; A64: CLS Vd.4H, Vn.4H
            // LeadingSignCount(Vector64<Int32>)	int32x2_t vcls_s32 (int32x2_t a); A32: VCLS.S32 Dd, Dm; A64: CLS Vd.2S, Vn.2S
            // LeadingSignCount(Vector64<SByte>)	int8x8_t vcls_s8 (int8x8_t a); A32: VCLS.S8 Dd, Dm; A64: CLS Vd.8B, Vn.8B
            // LeadingZeroCount(Vector128<Byte>)	uint8x16_t vclzq_u8 (uint8x16_t a); A32: VCLZ.I8 Qd, Qm; A64: CLZ Vd.16B, Vn.16B
            // LeadingZeroCount(Vector128<Int16>)	int16x8_t vclzq_s16 (int16x8_t a); A32: VCLZ.I16 Qd, Qm; A64: CLZ Vd.8H, Vn.8H
            // LeadingZeroCount(Vector128<Int32>)	int32x4_t vclzq_s32 (int32x4_t a); A32: VCLZ.I32 Qd, Qm; A64: CLZ Vd.4S, Vn.4S
            // LeadingZeroCount(Vector128<SByte>)	int8x16_t vclzq_s8 (int8x16_t a); A32: VCLZ.I8 Qd, Qm; A64: CLZ Vd.16B, Vn.16B
            // LeadingZeroCount(Vector128<UInt16>)	uint16x8_t vclzq_u16 (uint16x8_t a); A32: VCLZ.I16 Qd, Qm; A64: CLZ Vd.8H, Vn.8H
            // LeadingZeroCount(Vector128<UInt32>)	uint32x4_t vclzq_u32 (uint32x4_t a); A32: VCLZ.I32 Qd, Qm; A64: CLZ Vd.4S, Vn.4S
            // LeadingZeroCount(Vector64<Byte>)	uint8x8_t vclz_u8 (uint8x8_t a); A32: VCLZ.I8 Dd, Dm; A64: CLZ Vd.8B, Vn.8B
            // LeadingZeroCount(Vector64<Int16>)	int16x4_t vclz_s16 (int16x4_t a); A32: VCLZ.I16 Dd, Dm; A64: CLZ Vd.4H, Vn.4H
            // LeadingZeroCount(Vector64<Int32>)	int32x2_t vclz_s32 (int32x2_t a); A32: VCLZ.I32 Dd, Dm; A64: CLZ Vd.2S, Vn.2S
            // LeadingZeroCount(Vector64<SByte>)	int8x8_t vclz_s8 (int8x8_t a); A32: VCLZ.I8 Dd, Dm; A64: CLZ Vd.8B, Vn.8B
            // LeadingZeroCount(Vector64<UInt16>)	uint16x4_t vclz_u16 (uint16x4_t a); A32: VCLZ.I16 Dd, Dm; A64: CLZ Vd.4H, Vn.4H
            // LeadingZeroCount(Vector64<UInt32>)	uint32x2_t vclz_u32 (uint32x2_t a); A32: VCLZ.I32 Dd, Dm; A64: CLZ Vd.2S, Vn.2S
            // LoadAndInsertScalar(Vector128<Byte>, Byte, Byte*)	uint8x16_t vld1q_lane_u8 (uint8_t const * ptr, uint8x16_t src, const int lane); A32: VLD1.8 { Dd[index] }, [Rn]; A64: LD1 { Vt.B }[index], [Xn]
            // LoadAndInsertScalar(Vector128<Double>, Byte, Double*)	float64x2_t vld1q_lane_f64 (float64_t const * ptr, float64x2_t src, const int lane); A32: VLDR.64 Dd, [Rn]; A64: LD1 { Vt.D }[index], [Xn]
            // LoadAndInsertScalar(Vector128<Int16>, Byte, Int16*)	int16x8_t vld1q_lane_s16 (int16_t const * ptr, int16x8_t src, const int lane); A32: VLD1.16 { Dd[index] }, [Rn]; A64: LD1 { Vt.H }[index], [Xn]
            // LoadAndInsertScalar(Vector128<Int32>, Byte, Int32*)	int32x4_t vld1q_lane_s32 (int32_t const * ptr, int32x4_t src, const int lane); A32: VLD1.32 { Dd[index] }, [Rn]; A64: LD1 { Vt.S }[index], [Xn]
            // LoadAndInsertScalar(Vector128<Int64>, Byte, Int64*)	int64x2_t vld1q_lane_s64 (int64_t const * ptr, int64x2_t src, const int lane); A32: VLDR.64 Dd, [Rn]; A64: LD1 { Vt.D }[index], [Xn]
            // LoadAndInsertScalar(Vector128<SByte>, Byte, SByte*)	int8x16_t vld1q_lane_s8 (int8_t const * ptr, int8x16_t src, const int lane); A32: VLD1.8 { Dd[index] }, [Rn]; A64: LD1 { Vt.B }[index], [Xn]
            // LoadAndInsertScalar(Vector128<Single>, Byte, Single*)	float32x4_t vld1q_lane_f32 (float32_t const * ptr, float32x4_t src, const int lane); A32: VLD1.32 { Dd[index] }, [Rn]; A64: LD1 { Vt.S }[index], [Xn]
            // LoadAndInsertScalar(Vector128<UInt16>, Byte, UInt16*)	uint16x8_t vld1q_lane_u16 (uint16_t const * ptr, uint16x8_t src, const int lane); A32: VLD1.16 { Dd[index] }, [Rn]; A64: LD1 { Vt.H }[index], [Xn]
            // LoadAndInsertScalar(Vector128<UInt32>, Byte, UInt32*)	uint32x4_t vld1q_lane_u32 (uint32_t const * ptr, uint32x4_t src, const int lane); A32: VLD1.32 { Dd[index] }, [Rn]; A64: LD1 { Vt.S }[index], [Xn]
            // LoadAndInsertScalar(Vector128<UInt64>, Byte, UInt64*)	uint64x2_t vld1q_lane_u64 (uint64_t const * ptr, uint64x2_t src, const int lane); A32: VLDR.64 Dd, [Rn]; A64: LD1 { Vt.D }[index], [Xn]
            // LoadAndInsertScalar(Vector64<Byte>, Byte, Byte*)	uint8x8_t vld1_lane_u8 (uint8_t const * ptr, uint8x8_t src, const int lane); A32: VLD1.8 { Dd[index] }, [Rn]; A64: LD1 { Vt.B }[index], [Xn]
            // LoadAndInsertScalar(Vector64<Int16>, Byte, Int16*)	int16x4_t vld1_lane_s16 (int16_t const * ptr, int16x4_t src, const int lane); A32: VLD1.16 { Dd[index] }, [Rn]; A64: LD1 { Vt.H }[index], [Xn]
            // LoadAndInsertScalar(Vector64<Int32>, Byte, Int32*)	int32x2_t vld1_lane_s32 (int32_t const * ptr, int32x2_t src, const int lane); A32: VLD1.32 { Dd[index] }, [Rn]; A64: LD1 { Vt.S }[index], [Xn]
            // LoadAndInsertScalar(Vector64<SByte>, Byte, SByte*)	int8x8_t vld1_lane_s8 (int8_t const * ptr, int8x8_t src, const int lane); A32: VLD1.8 { Dd[index] }, [Rn]; A64: LD1 { Vt.B }[index], [Xn]
            // LoadAndInsertScalar(Vector64<Single>, Byte, Single*)	float32x2_t vld1_lane_f32 (float32_t const * ptr, float32x2_t src, const int lane); A32: VLD1.32 { Dd[index] }, [Rn]; A64: LD1 { Vt.S }[index], [Xn]
            // LoadAndInsertScalar(Vector64<UInt16>, Byte, UInt16*)	uint16x4_t vld1_lane_u16 (uint16_t const * ptr, uint16x4_t src, const int lane); A32: VLD1.16 { Dd[index] }, [Rn]; A64: LD1 { Vt.H }[index], [Xn]
            // LoadAndInsertScalar(Vector64<UInt32>, Byte, UInt32*)	uint32x2_t vld1_lane_u32 (uint32_t const * ptr, uint32x2_t src, const int lane); A32: VLD1.32 { Dd[index] }, [Rn]; A64: LD1 { Vt.S }[index], [Xn]
            // LoadAndReplicateToVector128(Byte*)	uint8x16_t vld1q_dup_u8 (uint8_t const * ptr); A32: VLD1.8 { Dd[], Dd+1[] }, [Rn]; A64: LD1R { Vt.16B }, [Xn]
            // LoadAndReplicateToVector128(Int16*)	int16x8_t vld1q_dup_s16 (int16_t const * ptr); A32: VLD1.16 { Dd[], Dd+1[] }, [Rn]; A64: LD1R { Vt.8H }, [Xn]
            // LoadAndReplicateToVector128(Int32*)	int32x4_t vld1q_dup_s32 (int32_t const * ptr); A32: VLD1.32 { Dd[], Dd+1[] }, [Rn]; A64: LD1R { Vt.4S }, [Xn]
            // LoadAndReplicateToVector128(SByte*)	int8x16_t vld1q_dup_s8 (int8_t const * ptr); A32: VLD1.8 { Dd[], Dd+1[] }, [Rn]; A64: LD1R { Vt.16B }, [Xn]
            // LoadAndReplicateToVector128(Single*)	float32x4_t vld1q_dup_f32 (float32_t const * ptr); A32: VLD1.32 { Dd[], Dd+1[] }, [Rn]; A64: LD1R { Vt.4S }, [Xn]
            // LoadAndReplicateToVector128(UInt16*)	uint16x8_t vld1q_dup_u16 (uint16_t const * ptr); A32: VLD1.16 { Dd[], Dd+1[] }, [Rn]; A64: LD1R { Vt.8H }, [Xn]
            // LoadAndReplicateToVector128(UInt32*)	uint32x4_t vld1q_dup_u32 (uint32_t const * ptr); A32: VLD1.32 { Dd[], Dd+1[] }, [Rn]; A64: LD1R { Vt.4S }, [Xn]
            // LoadAndReplicateToVector64(Byte*)	uint8x8_t vld1_dup_u8 (uint8_t const * ptr); A32: VLD1.8 { Dd[] }, [Rn]; A64: LD1R { Vt.8B }, [Xn]
            // LoadAndReplicateToVector64(Int16*)	int16x4_t vld1_dup_s16 (int16_t const * ptr); A32: VLD1.16 { Dd[] }, [Rn]; A64: LD1R { Vt.4H }, [Xn]
            // LoadAndReplicateToVector64(Int32*)	int32x2_t vld1_dup_s32 (int32_t const * ptr); A32: VLD1.32 { Dd[] }, [Rn]; A64: LD1R { Vt.2S }, [Xn]
            // LoadAndReplicateToVector64(SByte*)	int8x8_t vld1_dup_s8 (int8_t const * ptr); A32: VLD1.8 { Dd[] }, [Rn]; A64: LD1R { Vt.8B }, [Xn]
            // LoadAndReplicateToVector64(Single*)	float32x2_t vld1_dup_f32 (float32_t const * ptr); A32: VLD1.32 { Dd[] }, [Rn]; A64: LD1R { Vt.2S }, [Xn]
            // LoadAndReplicateToVector64(UInt16*)	uint16x4_t vld1_dup_u16 (uint16_t const * ptr); A32: VLD1.16 { Dd[] }, [Rn]; A64: LD1R { Vt.4H }, [Xn]
            // LoadAndReplicateToVector64(UInt32*)	uint32x2_t vld1_dup_u32 (uint32_t const * ptr); A32: VLD1.32 { Dd[] }, [Rn]; A64: LD1R { Vt.2S }, [Xn]
            // LoadVector128(Byte*)	uint8x16_t vld1q_u8 (uint8_t const * ptr); A32: VLD1.8 Dd, Dd+1, [Rn]; A64: LD1 Vt.16B, [Xn]
            // LoadVector128(Double*)	float64x2_t vld1q_f64 (float64_t const * ptr); A32: VLD1.64 Dd, Dd+1, [Rn]; A64: LD1 Vt.2D, [Xn]
            // LoadVector128(Int16*)	int16x8_t vld1q_s16 (int16_t const * ptr); A32: VLD1.16 Dd, Dd+1, [Rn]; A64: LD1 Vt.8H, [Xn]
            // LoadVector128(Int32*)	int32x4_t vld1q_s32 (int32_t const * ptr); A32: VLD1.32 Dd, Dd+1, [Rn]; A64: LD1 Vt.4S, [Xn]
            // LoadVector128(Int64*)	int64x2_t vld1q_s64 (int64_t const * ptr); A32: VLD1.64 Dd, Dd+1, [Rn]; A64: LD1 Vt.2D, [Xn]
            // LoadVector128(SByte*)	int8x16_t vld1q_s8 (int8_t const * ptr); A32: VLD1.8 Dd, Dd+1, [Rn]; A64: LD1 Vt.16B, [Xn]
            // LoadVector128(Single*)	float32x4_t vld1q_f32 (float32_t const * ptr); A32: VLD1.32 Dd, Dd+1, [Rn]; A64: LD1 Vt.4S, [Xn]
            // LoadVector128(UInt16*)	uint16x8_t vld1q_s16 (uint16_t const * ptr); A32: VLD1.16 Dd, Dd+1, [Rn]; A64: LD1 Vt.8H, [Xn]
            // LoadVector128(UInt32*)	uint32x4_t vld1q_s32 (uint32_t const * ptr); A32: VLD1.32 Dd, Dd+1, [Rn]; A64: LD1 Vt.4S, [Xn]
            // LoadVector128(UInt64*)	uint64x2_t vld1q_u64 (uint64_t const * ptr); A32: VLD1.64 Dd, Dd+1, [Rn]; A64: LD1 Vt.2D, [Xn]
            // LoadVector64(Byte*)	uint8x8_t vld1_u8 (uint8_t const * ptr); A32: VLD1.8 Dd, [Rn]; A64: LD1 Vt.8B, [Xn]
            // LoadVector64(Double*)	float64x1_t vld1_f64 (float64_t const * ptr); A32: VLD1.64 Dd, [Rn]; A64: LD1 Vt.1D, [Xn]
            // LoadVector64(Int16*)	int16x4_t vld1_s16 (int16_t const * ptr); A32: VLD1.16 Dd, [Rn]; A64: LD1 Vt.4H, [Xn]
            // LoadVector64(Int32*)	int32x2_t vld1_s32 (int32_t const * ptr); A32: VLD1.32 Dd, [Rn]; A64: LD1 Vt.2S, [Xn]
            // LoadVector64(Int64*)	int64x1_t vld1_s64 (int64_t const * ptr); A32: VLD1.64 Dd, [Rn]; A64: LD1 Vt.1D, [Xn]
            // LoadVector64(SByte*)	int8x8_t vld1_s8 (int8_t const * ptr); A32: VLD1.8 Dd, [Rn]; A64: LD1 Vt.8B, [Xn]
            // LoadVector64(Single*)	float32x2_t vld1_f32 (float32_t const * ptr); A32: VLD1.32 Dd, [Rn]; A64: LD1 Vt.2S, [Xn]
            // LoadVector64(UInt16*)	uint16x4_t vld1_u16 (uint16_t const * ptr); A32: VLD1.16 Dd, [Rn]; A64: LD1 Vt.4H, [Xn]
            // LoadVector64(UInt32*)	uint32x2_t vld1_u32 (uint32_t const * ptr); A32: VLD1.32 Dd, [Rn]; A64: LD1 Vt.2S, [Xn]
            // LoadVector64(UInt64*)	uint64x1_t vld1_u64 (uint64_t const * ptr); A32: VLD1.64 Dd, [Rn]; A64: LD1 Vt.1D, [Xn]
        }
        public unsafe static void RunArm_AdvSimd_M(TextWriter writer, string indent) {
            // Max(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vmaxq_u8 (uint8x16_t a, uint8x16_t b); A32: VMAX.U8 Qd, Qn, Qm; A64: UMAX Vd.16B, Vn.16B, Vm.16B
            // Max(Vector128<Int16>, Vector128<Int16>)	int16x8_t vmaxq_s16 (int16x8_t a, int16x8_t b); A32: VMAX.S16 Qd, Qn, Qm; A64: SMAX Vd.8H, Vn.8H, Vm.8H
            // Max(Vector128<Int32>, Vector128<Int32>)	int32x4_t vmaxq_s32 (int32x4_t a, int32x4_t b); A32: VMAX.S32 Qd, Qn, Qm; A64: SMAX Vd.4S, Vn.4S, Vm.4S
            // Max(Vector128<SByte>, Vector128<SByte>)	int8x16_t vmaxq_s8 (int8x16_t a, int8x16_t b); A32: VMAX.S8 Qd, Qn, Qm; A64: SMAX Vd.16B, Vn.16B, Vm.16B
            // Max(Vector128<Single>, Vector128<Single>)	float32x4_t vmaxq_f32 (float32x4_t a, float32x4_t b); A32: VMAX.F32 Qd, Qn, Qm; A64: FMAX Vd.4S, Vn.4S, Vm.4S
            // Max(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vmaxq_u16 (uint16x8_t a, uint16x8_t b); A32: VMAX.U16 Qd, Qn, Qm; A64: UMAX Vd.8H, Vn.8H, Vm.8H
            // Max(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vmaxq_u32 (uint32x4_t a, uint32x4_t b); A32: VMAX.U32 Qd, Qn, Qm; A64: UMAX Vd.4S, Vn.4S, Vm.4S
            // Max(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vmax_u8 (uint8x8_t a, uint8x8_t b); A32: VMAX.U8 Dd, Dn, Dm; A64: UMAX Vd.8B, Vn.8B, Vm.8B
            // Max(Vector64<Int16>, Vector64<Int16>)	int16x4_t vmax_s16 (int16x4_t a, int16x4_t b); A32: VMAX.S16 Dd, Dn, Dm; A64: SMAX Vd.4H, Vn.4H, Vm.4H
            // Max(Vector64<Int32>, Vector64<Int32>)	int32x2_t vmax_s32 (int32x2_t a, int32x2_t b); A32: VMAX.S32 Dd, Dn, Dm; A64: SMAX Vd.2S, Vn.2S, Vm.2S
            // Max(Vector64<SByte>, Vector64<SByte>)	int8x8_t vmax_s8 (int8x8_t a, int8x8_t b); A32: VMAX.S8 Dd, Dn, Dm; A64: SMAX Vd.8B, Vn.8B, Vm.8B
            // Max(Vector64<Single>, Vector64<Single>)	float32x2_t vmax_f32 (float32x2_t a, float32x2_t b); A32: VMAX.F32 Dd, Dn, Dm; A64: FMAX Vd.2S, Vn.2S, Vm.2S
            // Max(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vmax_u16 (uint16x4_t a, uint16x4_t b); A32: VMAX.U16 Dd, Dn, Dm; A64: UMAX Vd.4H, Vn.4H, Vm.4H
            // Max(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vmax_u32 (uint32x2_t a, uint32x2_t b); A32: VMAX.U32 Dd, Dn, Dm; A64: UMAX Vd.2S, Vn.2S, Vm.2S
            // MaxNumber(Vector128<Single>, Vector128<Single>)	float32x4_t vmaxnmq_f32 (float32x4_t a, float32x4_t b); A32: VMAXNM.F32 Qd, Qn, Qm; A64: FMAXNM Vd.4S, Vn.4S, Vm.4S
            // MaxNumber(Vector64<Single>, Vector64<Single>)	float32x2_t vmaxnm_f32 (float32x2_t a, float32x2_t b); A32: VMAXNM.F32 Dd, Dn, Dm; A64: FMAXNM Vd.2S, Vn.2S, Vm.2S
            // MaxNumberScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vmaxnm_f64 (float64x1_t a, float64x1_t b); A32: VMAXNM.F64 Dd, Dn, Dm; A64: FMAXNM Dd, Dn, Dm
            // MaxNumberScalar(Vector64<Single>, Vector64<Single>)	float32_t vmaxnms_f32 (float32_t a, float32_t b); A32: VMAXNM.F32 Sd, Sn, Sm; A64: FMAXNM Sd, Sn, Sm
            // MaxPairwise(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vpmax_u8 (uint8x8_t a, uint8x8_t b); A32: VPMAX.U8 Dd, Dn, Dm; A64: UMAXP Vd.8B, Vn.8B, Vm.8B
            // MaxPairwise(Vector64<Int16>, Vector64<Int16>)	int16x4_t vpmax_s16 (int16x4_t a, int16x4_t b); A32: VPMAX.S16 Dd, Dn, Dm; A64: SMAXP Vd.4H, Vn.4H, Vm.4H
            // MaxPairwise(Vector64<Int32>, Vector64<Int32>)	int32x2_t vpmax_s32 (int32x2_t a, int32x2_t b); A32: VPMAX.S32 Dd, Dn, Dm; A64: SMAXP Vd.2S, Vn.2S, Vm.2S
            // MaxPairwise(Vector64<SByte>, Vector64<SByte>)	int8x8_t vpmax_s8 (int8x8_t a, int8x8_t b); A32: VPMAX.S8 Dd, Dn, Dm; A64: SMAXP Vd.8B, Vn.8B, Vm.8B
            // MaxPairwise(Vector64<Single>, Vector64<Single>)	float32x2_t vpmax_f32 (float32x2_t a, float32x2_t b); A32: VPMAX.F32 Dd, Dn, Dm; A64: FMAXP Vd.2S, Vn.2S, Vm.2S
            // MaxPairwise(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vpmax_u16 (uint16x4_t a, uint16x4_t b); A32: VPMAX.U16 Dd, Dn, Dm; A64: UMAXP Vd.4H, Vn.4H, Vm.4H
            // MaxPairwise(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vpmax_u32 (uint32x2_t a, uint32x2_t b); A32: VPMAX.U32 Dd, Dn, Dm; A64: UMAXP Vd.2S, Vn.2S, Vm.2S
            // MemberwiseClone()	Creates a shallow copy of the current Object.; (Inherited from Object)
            // Min(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vminq_u8 (uint8x16_t a, uint8x16_t b); A32: VMIN.U8 Qd, Qn, Qm; A64: UMIN Vd.16B, Vn.16B, Vm.16B
            // Min(Vector128<Int16>, Vector128<Int16>)	int16x8_t vminq_s16 (int16x8_t a, int16x8_t b); A32: VMIN.S16 Qd, Qn, Qm; A64: SMIN Vd.8H, Vn.8H, Vm.8H
            // Min(Vector128<Int32>, Vector128<Int32>)	int32x4_t vminq_s32 (int32x4_t a, int32x4_t b); A32: VMIN.S32 Qd, Qn, Qm; A64: SMIN Vd.4S, Vn.4S, Vm.4S
            // Min(Vector128<SByte>, Vector128<SByte>)	int8x16_t vminq_s8 (int8x16_t a, int8x16_t b); A32: VMIN.S8 Qd, Qn, Qm; A64: SMIN Vd.16B, Vn.16B, Vm.16B
            // Min(Vector128<Single>, Vector128<Single>)	float32x4_t vminq_f32 (float32x4_t a, float32x4_t b); A32: VMIN.F32 Qd, Qn, Qm; A64: FMIN Vd.4S, Vn.4S, Vm.4S
            // Min(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vminq_u16 (uint16x8_t a, uint16x8_t b); A32: VMIN.U16 Qd, Qn, Qm; A64: UMIN Vd.8H, Vn.8H, Vm.8H
            // Min(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vminq_u32 (uint32x4_t a, uint32x4_t b); A32: VMIN.U32 Qd, Qn, Qm; A64: UMIN Vd.4S, Vn.4S, Vm.4S
            // Min(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vmin_u8 (uint8x8_t a, uint8x8_t b); A32: VMIN.U8 Dd, Dn, Dm; A64: UMIN Vd.8B, Vn.8B, Vm.8B
            // Min(Vector64<Int16>, Vector64<Int16>)	int16x4_t vmin_s16 (int16x4_t a, int16x4_t b); A32: VMIN.S16 Dd, Dn, Dm; A64: SMIN Vd.4H, Vn.4H, Vm.4H
            // Min(Vector64<Int32>, Vector64<Int32>)	int32x2_t vmin_s32 (int32x2_t a, int32x2_t b); A32: VMIN.S32 Dd, Dn, Dm; A64: SMIN Vd.2S, Vn.2S, Vm.2S
            // Min(Vector64<SByte>, Vector64<SByte>)	int8x8_t vmin_s8 (int8x8_t a, int8x8_t b); A32: VMIN.S8 Dd, Dn, Dm; A64: SMIN Vd.8B, Vn.8B, Vm.8B
            // Min(Vector64<Single>, Vector64<Single>)	float32x2_t vmin_f32 (float32x2_t a, float32x2_t b); A32: VMIN.F32 Dd, Dn, Dm; A64: FMIN Vd.2S, Vn.2S, Vm.2S
            // Min(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vmin_u16 (uint16x4_t a, uint16x4_t b); A32: VMIN.U16 Dd, Dn, Dm; A64: UMIN Vd.4H, Vn.4H, Vm.4H
            // Min(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vmin_u32 (uint32x2_t a, uint32x2_t b); A32: VMIN.U32 Dd, Dn, Dm; A64: UMIN Vd.2S, Vn.2S, Vm.2S
            // MinNumber(Vector128<Single>, Vector128<Single>)	float32x4_t vminnmq_f32 (float32x4_t a, float32x4_t b); A32: VMINNM.F32 Qd, Qn, Qm; A64: FMINNM Vd.4S, Vn.4S, Vm.4S
            // MinNumber(Vector64<Single>, Vector64<Single>)	float32x2_t vminnm_f32 (float32x2_t a, float32x2_t b); A32: VMINNM.F32 Dd, Dn, Dm; A64: FMINNM Vd.2S, Vn.2S, Vm.2S
            // MinNumberScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vminnm_f64 (float64x1_t a, float64x1_t b); A32: VMINNM.F64 Dd, Dn, Dm; A64: FMINNM Dd, Dn, Dm
            // MinNumberScalar(Vector64<Single>, Vector64<Single>)	float32_t vminnms_f32 (float32_t a, float32_t b); A32: VMINNM.F32 Sd, Sn, Sm; A64: FMINNM Sd, Sn, Sm
            // MinPairwise(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vpmin_u8 (uint8x8_t a, uint8x8_t b); A32: VPMIN.U8 Dd, Dn, Dm; A64: UMINP Vd.8B, Vn.8B, Vm.8B
            // MinPairwise(Vector64<Int16>, Vector64<Int16>)	int16x4_t vpmin_s16 (int16x4_t a, int16x4_t b); A32: VPMIN.S16 Dd, Dn, Dm; A64: SMINP Vd.4H, Vn.4H, Vm.4H
            // MinPairwise(Vector64<Int32>, Vector64<Int32>)	int32x2_t vpmin_s32 (int32x2_t a, int32x2_t b); A32: VPMIN.S32 Dd, Dn, Dm; A64: SMINP Vd.2S, Vn.2S, Vm.2S
            // MinPairwise(Vector64<SByte>, Vector64<SByte>)	int8x8_t vpmin_s8 (int8x8_t a, int8x8_t b); A32: VPMIN.S8 Dd, Dn, Dm; A64: SMINP Vd.8B, Vn.8B, Vm.8B
            // MinPairwise(Vector64<Single>, Vector64<Single>)	float32x2_t vpmin_f32 (float32x2_t a, float32x2_t b); A32: VPMIN.F32 Dd, Dn, Dm; A64: FMINP Vd.2S, Vn.2S, Vm.2S
            // MinPairwise(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vpmin_u16 (uint16x4_t a, uint16x4_t b); A32: VPMIN.U16 Dd, Dn, Dm; A64: UMINP Vd.4H, Vn.4H, Vm.4H
            // MinPairwise(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vpmin_u32 (uint32x2_t a, uint32x2_t b); A32: VPMIN.U32 Dd, Dn, Dm; A64: UMINP Vd.2S, Vn.2S, Vm.2S
            // Multiply(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vmulq_u8 (uint8x16_t a, uint8x16_t b); A32: VMUL.I8 Qd, Qn, Qm; A64: MUL Vd.16B, Vn.16B, Vm.16B
            // Multiply(Vector128<Int16>, Vector128<Int16>)	int16x8_t vmulq_s16 (int16x8_t a, int16x8_t b); A32: VMUL.I16 Qd, Qn, Qm; A64: MUL Vd.8H, Vn.8H, Vm.8H
            // Multiply(Vector128<Int32>, Vector128<Int32>)	int32x4_t vmulq_s32 (int32x4_t a, int32x4_t b); A32: VMUL.I32 Qd, Qn, Qm; A64: MUL Vd.4S, Vn.4S, Vm.4S
            // Multiply(Vector128<SByte>, Vector128<SByte>)	int8x16_t vmulq_s8 (int8x16_t a, int8x16_t b); A32: VMUL.I8 Qd, Qn, Qm; A64: MUL Vd.16B, Vn.16B, Vm.16B
            // Multiply(Vector128<Single>, Vector128<Single>)	float32x4_t vmulq_f32 (float32x4_t a, float32x4_t b); A32: VMUL.F32 Qd, Qn, Qm; A64: FMUL Vd.4S, Vn.4S, Vm.4S
            // Multiply(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vmulq_u16 (uint16x8_t a, uint16x8_t b); A32: VMUL.I16 Qd, Qn, Qm; A64: MUL Vd.8H, Vn.8H, Vm.8H
            // Multiply(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vmulq_u32 (uint32x4_t a, uint32x4_t b); A32: VMUL.I32 Qd, Qn, Qm; A64: MUL Vd.4S, Vn.4S, Vm.4S
            // Multiply(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vmul_u8 (uint8x8_t a, uint8x8_t b); A32: VMUL.I8 Dd, Dn, Dm; A64: MUL Vd.8B, Vn.8B, Vm.8B
            // Multiply(Vector64<Int16>, Vector64<Int16>)	int16x4_t vmul_s16 (int16x4_t a, int16x4_t b); A32: VMUL.I16 Dd, Dn, Dm; A64: MUL Vd.4H, Vn.4H, Vm.4H
            // Multiply(Vector64<Int32>, Vector64<Int32>)	int32x2_t vmul_s32 (int32x2_t a, int32x2_t b); A32: VMUL.I32 Dd, Dn, Dm; A64: MUL Vd.2S, Vn.2S, Vm.2S
            // Multiply(Vector64<SByte>, Vector64<SByte>)	int8x8_t vmul_s8 (int8x8_t a, int8x8_t b); A32: VMUL.I8 Dd, Dn, Dm; A64: MUL Vd.8B, Vn.8B, Vm.8B
            // Multiply(Vector64<Single>, Vector64<Single>)	float32x2_t vmul_f32 (float32x2_t a, float32x2_t b); A32: VMUL.F32 Dd, Dn, Dm; A64: FMUL Vd.2S, Vn.2S, Vm.2S
            // Multiply(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vmul_u16 (uint16x4_t a, uint16x4_t b); A32: VMUL.I16 Dd, Dn, Dm; A64: MUL Vd.4H, Vn.4H, Vm.4H
            // Multiply(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vmul_u32 (uint32x2_t a, uint32x2_t b); A32: VMUL.I32 Dd, Dn, Dm; A64: MUL Vd.2S, Vn.2S, Vm.2S
            // MultiplyAdd(Vector128<Byte>, Vector128<Byte>, Vector128<Byte>)	uint8x16_t vmlaq_u8 (uint8x16_t a, uint8x16_t b, uint8x16_t c); A32: VMLA.I8 Qd, Qn, Qm; A64: MLA Vd.16B, Vn.16B, Vm.16B
            // MultiplyAdd(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>)	int16x8_t vmlaq_s16 (int16x8_t a, int16x8_t b, int16x8_t c); A32: VMLA.I16 Qd, Qn, Qm; A64: MLA Vd.8H, Vn.8H, Vm.8H
            // MultiplyAdd(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>)	int32x4_t vmlaq_s32 (int32x4_t a, int32x4_t b, int32x4_t c); A32: VMLA.I32 Qd, Qn, Qm; A64: MLA Vd.4S, Vn.4S, Vm.4S
            // MultiplyAdd(Vector128<SByte>, Vector128<SByte>, Vector128<SByte>)	int8x16_t vmlaq_s8 (int8x16_t a, int8x16_t b, int8x16_t c); A32: VMLA.I8 Qd, Qn, Qm; A64: MLA Vd.16B, Vn.16B, Vm.16B
            // MultiplyAdd(Vector128<UInt16>, Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vmlaq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t c); A32: VMLA.I16 Qd, Qn, Qm; A64: MLA Vd.8H, Vn.8H, Vm.8H
            // MultiplyAdd(Vector128<UInt32>, Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vmlaq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t c); A32: VMLA.I32 Qd, Qn, Qm; A64: MLA Vd.4S, Vn.4S, Vm.4S
            // MultiplyAdd(Vector64<Byte>, Vector64<Byte>, Vector64<Byte>)	uint8x8_t vmla_u8 (uint8x8_t a, uint8x8_t b, uint8x8_t c); A32: VMLA.I8 Dd, Dn, Dm; A64: MLA Vd.8B, Vn.8B, Vm.8B
            // MultiplyAdd(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16x4_t vmla_s16 (int16x4_t a, int16x4_t b, int16x4_t c); A32: VMLA.I16 Dd, Dn, Dm; A64: MLA Vd.4H, Vn.4H, Vm.4H
            // MultiplyAdd(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32x2_t vmla_s32 (int32x2_t a, int32x2_t b, int32x2_t c); A32: VMLA.I32 Dd, Dn, Dm; A64: MLA Vd.2S, Vn.2S, Vm.2S
            // MultiplyAdd(Vector64<SByte>, Vector64<SByte>, Vector64<SByte>)	int8x8_t vmla_s8 (int8x8_t a, int8x8_t b, int8x8_t c); A32: VMLA.I8 Dd, Dn, Dm; A64: MLA Vd.8B, Vn.8B, Vm.8B
            // MultiplyAdd(Vector64<UInt16>, Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vmla_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t c); A32: VMLA.I16 Dd, Dn, Dm; A64: MLA Vd.4H, Vn.4H, Vm.4H
            // MultiplyAdd(Vector64<UInt32>, Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vmla_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t c); A32: VMLA.I32 Dd, Dn, Dm; A64: MLA Vd.2S, Vn.2S, Vm.2S
            // MultiplyAddByScalar(Vector128<Int16>, Vector128<Int16>, Vector64<Int16>)	int16x8_t vmlaq_n_s16 (int16x8_t a, int16x8_t b, int16_t c); A32: VMLA.I16 Qd, Qn, Dm[0]; A64: MLA Vd.8H, Vn.8H, Vm.H[0]
            // MultiplyAddByScalar(Vector128<Int32>, Vector128<Int32>, Vector64<Int32>)	int32x4_t vmlaq_n_s32 (int32x4_t a, int32x4_t b, int32_t c); A32: VMLA.I32 Qd, Qn, Dm[0]; A64: MLA Vd.4S, Vn.4S, Vm.S[0]
            // MultiplyAddByScalar(Vector128<UInt16>, Vector128<UInt16>, Vector64<UInt16>)	uint16x8_t vmlaq_n_u16 (uint16x8_t a, uint16x8_t b, uint16_t c); A32: VMLA.I16 Qd, Qn, Dm[0]; A64: MLA Vd.8H, Vn.8H, Vm.H[0]
            // MultiplyAddByScalar(Vector128<UInt32>, Vector128<UInt32>, Vector64<UInt32>)	uint32x4_t vmlaq_n_u32 (uint32x4_t a, uint32x4_t b, uint32_t c); A32: VMLA.I32 Qd, Qn, Dm[0]; A64: MLA Vd.4S, Vn.4S, Vm.S[0]
            // MultiplyAddByScalar(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16x4_t vmla_n_s16 (int16x4_t a, int16x4_t b, int16_t c); A32: VMLA.I16 Dd, Dn, Dm[0]; A64: MLA Vd.4H, Vn.4H, Vm.H[0]
            // MultiplyAddByScalar(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32x2_t vmla_n_s32 (int32x2_t a, int32x2_t b, int32_t c); A32: VMLA.I32 Dd, Dn, Dm[0]; A64: MLA Vd.2S, Vn.2S, Vm.S[0]
            // MultiplyAddByScalar(Vector64<UInt16>, Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vmla_n_u16 (uint16x4_t a, uint16x4_t b, uint16_t c); A32: VMLA.I16 Dd, Dn, Dm[0]; A64: MLA Vd.4H, Vn.4H, Vm.H[0]
            // MultiplyAddByScalar(Vector64<UInt32>, Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vmla_n_u32 (uint32x2_t a, uint32x2_t b, uint32_t c); A32: VMLA.I32 Dd, Dn, Dm[0]; A64: MLA Vd.2S, Vn.2S, Vm.S[0]
            // MultiplyAddBySelectedScalar(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vmlaq_laneq_s16 (int16x8_t a, int16x8_t b, int16x8_t v, const int lane); A32: VMLA.I16 Qd, Qn, Dm[lane]; A64: MLA Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyAddBySelectedScalar(Vector128<Int16>, Vector128<Int16>, Vector64<Int16>, Byte)	int16x8_t vmlaq_lane_s16 (int16x8_t a, int16x8_t b, int16x4_t v, const int lane); A32: VMLA.I16 Qd, Qn, Dm[lane]; A64: MLA Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyAddBySelectedScalar(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vmlaq_laneq_s32 (int32x4_t a, int32x4_t b, int32x4_t v, const int lane); A32: VMLA.I32 Qd, Qn, Dm[lane]; A64: MLA Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyAddBySelectedScalar(Vector128<Int32>, Vector128<Int32>, Vector64<Int32>, Byte)	int32x4_t vmlaq_lane_s32 (int32x4_t a, int32x4_t b, int32x2_t v, const int lane); A32: VMLA.I32 Qd, Qn, Dm[lane]; A64: MLA Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyAddBySelectedScalar(Vector128<UInt16>, Vector128<UInt16>, Vector128<UInt16>, Byte)	uint16x8_t vmlaq_laneq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t v, const int lane); A32: VMLA.I16 Qd, Qn, Dm[lane]; A64: MLA Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyAddBySelectedScalar(Vector128<UInt16>, Vector128<UInt16>, Vector64<UInt16>, Byte)	uint16x8_t vmlaq_lane_u16 (uint16x8_t a, uint16x8_t b, uint16x4_t v, const int lane); A32: VMLA.I16 Qd, Qn, Dm[lane]; A64: MLA Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyAddBySelectedScalar(Vector128<UInt32>, Vector128<UInt32>, Vector128<UInt32>, Byte)	uint32x4_t vmlaq_laneq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t v, const int lane); A32: VMLA.I32 Qd, Qn, Dm[lane]; A64: MLA Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyAddBySelectedScalar(Vector128<UInt32>, Vector128<UInt32>, Vector64<UInt32>, Byte)	uint32x4_t vmlaq_lane_u32 (uint32x4_t a, uint32x4_t b, uint32x2_t v, const int lane); A32: VMLA.I32 Qd, Qn, Dm[lane]; A64: MLA Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyAddBySelectedScalar(Vector64<Int16>, Vector64<Int16>, Vector128<Int16>, Byte)	int16x4_t vmla_laneq_s16 (int16x4_t a, int16x4_t b, int16x8_t v, const int lane); A32: VMLA.I16 Dd, Dn, Dm[lane]; A64: MLA Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyAddBySelectedScalar(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vmla_lane_s16 (int16x4_t a, int16x4_t b, int16x4_t v, const int lane); A32: VMLA.I16 Dd, Dn, Dm[lane]; A64: MLA Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyAddBySelectedScalar(Vector64<Int32>, Vector64<Int32>, Vector128<Int32>, Byte)	int32x2_t vmla_laneq_s32 (int32x2_t a, int32x2_t b, int32x4_t v, const int lane); A32: VMLA.I32 Dd, Dn, Dm[lane]; A64: MLA Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyAddBySelectedScalar(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vmla_lane_s32 (int32x2_t a, int32x2_t b, int32x2_t v, const int lane); A32: VMLA.I32 Dd, Dn, Dm[lane]; A64: MLA Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyAddBySelectedScalar(Vector64<UInt16>, Vector64<UInt16>, Vector128<UInt16>, Byte)	uint16x4_t vmla_laneq_u16 (uint16x4_t a, uint16x4_t b, uint16x8_t v, const int lane); A32: VMLA.I16 Dd, Dn, Dm[lane]; A64: MLA Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyAddBySelectedScalar(Vector64<UInt16>, Vector64<UInt16>, Vector64<UInt16>, Byte)	uint16x4_t vmla_lane_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t v, const int lane); A32: VMLA.I16 Dd, Dn, Dm[lane]; A64: MLA Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyAddBySelectedScalar(Vector64<UInt32>, Vector64<UInt32>, Vector128<UInt32>, Byte)	uint32x2_t vmla_laneq_u32 (uint32x2_t a, uint32x2_t b, uint32x4_t v, const int lane); A32: VMLA.I32 Dd, Dn, Dm[lane]; A64: MLA Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyAddBySelectedScalar(Vector64<UInt32>, Vector64<UInt32>, Vector64<UInt32>, Byte)	uint32x2_t vmla_lane_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t v, const int lane); A32: VMLA.I32 Dd, Dn, Dm[lane]; A64: MLA Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyByScalar(Vector128<Int16>, Vector64<Int16>)	int16x8_t vmulq_n_s16 (int16x8_t a, int16_t b); A32: VMUL.I16 Qd, Qn, Dm[0]; A64: MUL Vd.8H, Vn.8H, Vm.H[0]
            // MultiplyByScalar(Vector128<Int32>, Vector64<Int32>)	int32x4_t vmulq_n_s32 (int32x4_t a, int32_t b); A32: VMUL.I32 Qd, Qn, Dm[0]; A64: MUL Vd.4S, Vn.4S, Vm.S[0]
            // MultiplyByScalar(Vector128<Single>, Vector64<Single>)	float32x4_t vmulq_n_f32 (float32x4_t a, float32_t b); A32: VMUL.F32 Qd, Qn, Dm[0]; A64: FMUL Vd.4S, Vn.4S, Vm.S[0]
            // MultiplyByScalar(Vector128<UInt16>, Vector64<UInt16>)	uint16x8_t vmulq_n_u16 (uint16x8_t a, uint16_t b); A32: VMUL.I16 Qd, Qn, Dm[0]; A64: MUL Vd.8H, Vn.8H, Vm.H[0]
            // MultiplyByScalar(Vector128<UInt32>, Vector64<UInt32>)	uint32x4_t vmulq_n_u32 (uint32x4_t a, uint32_t b); A32: VMUL.I32 Qd, Qn, Dm[0]; A64: MUL Vd.4S, Vn.4S, Vm.S[0]
            // MultiplyByScalar(Vector64<Int16>, Vector64<Int16>)	int16x4_t vmul_n_s16 (int16x4_t a, int16_t b); A32: VMUL.I16 Dd, Dn, Dm[0]; A64: MUL Vd.4H, Vn.4H, Vm.H[0]
            // MultiplyByScalar(Vector64<Int32>, Vector64<Int32>)	int32x2_t vmul_n_s32 (int32x2_t a, int32_t b); A32: VMUL.I32 Dd, Dn, Dm[0]; A64: MUL Vd.2S, Vn.2S, Vm.S[0]
            // MultiplyByScalar(Vector64<Single>, Vector64<Single>)	float32x2_t vmul_n_f32 (float32x2_t a, float32_t b); A32: VMUL.F32 Dd, Dn, Dm[0]; A64: FMUL Vd.2S, Vn.2S, Vm.S[0]
            // MultiplyByScalar(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vmul_n_u16 (uint16x4_t a, uint16_t b); A32: VMUL.I16 Dd, Dn, Dm[0]; A64: MUL Vd.4H, Vn.4H, Vm.H[0]
            // MultiplyByScalar(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vmul_n_u32 (uint32x2_t a, uint32_t b); A32: VMUL.I32 Dd, Dn, Dm[0]; A64: MUL Vd.2S, Vn.2S, Vm.S[0]
            // MultiplyBySelectedScalar(Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vmulq_laneq_s16 (int16x8_t a, int16x8_t v, const int lane); A32: VMUL.I16 Qd, Qn, Dm[lane]; A64: MUL Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalar(Vector128<Int16>, Vector64<Int16>, Byte)	int16x8_t vmulq_lane_s16 (int16x8_t a, int16x4_t v, const int lane); A32: VMUL.I16 Qd, Qn, Dm[lane]; A64: MUL Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalar(Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vmulq_laneq_s32 (int32x4_t a, int32x4_t v, const int lane); A32: VMUL.I32 Qd, Qn, Dm[lane]; A64: MUL Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector128<Int32>, Vector64<Int32>, Byte)	int32x4_t vmulq_lane_s32 (int32x4_t a, int32x2_t v, const int lane); A32: VMUL.I32 Qd, Qn, Dm[lane]; A64: MUL Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector128<Single>, Vector128<Single>, Byte)	float32x4_t vmulq_laneq_f32 (float32x4_t a, float32x4_t v, const int lane); A32: VMUL.F32 Qd, Qn, Dm[lane]; A64: FMUL Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector128<Single>, Vector64<Single>, Byte)	float32x4_t vmulq_lane_f32 (float32x4_t a, float32x2_t v, const int lane); A32: VMUL.F32 Qd, Qn, Dm[lane]; A64: FMUL Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector128<UInt16>, Vector128<UInt16>, Byte)	uint16x8_t vmulq_laneq_u16 (uint16x8_t a, uint16x8_t v, const int lane); A32: VMUL.I16 Qd, Qn, Dm[lane]; A64: MUL Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalar(Vector128<UInt16>, Vector64<UInt16>, Byte)	uint16x8_t vmulq_lane_u16 (uint16x8_t a, uint16x4_t v, const int lane); A32: VMUL.I16 Qd, Qn, Dm[lane]; A64: MUL Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalar(Vector128<UInt32>, Vector128<UInt32>, Byte)	uint32x4_t vmulq_laneq_u32 (uint32x4_t a, uint32x4_t v, const int lane); A32: VMUL.I32 Qd, Qn, Dm[lane]; A64: MUL Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector128<UInt32>, Vector64<UInt32>, Byte)	uint32x4_t vmulq_lane_u32 (uint32x4_t a, uint32x2_t v, const int lane); A32: VMUL.I32 Qd, Qn, Dm[lane]; A64: MUL Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector64<Int16>, Vector128<Int16>, Byte)	int16x4_t vmul_laneq_s16 (int16x4_t a, int16x8_t v, const int lane); A32: VMUL.I16 Dd, Dn, Dm[lane]; A64: MUL Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalar(Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vmul_lane_s16 (int16x4_t a, int16x4_t v, const int lane); A32: VMUL.I16 Dd, Dn, Dm[lane]; A64: MUL Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalar(Vector64<Int32>, Vector128<Int32>, Byte)	int32x2_t vmul_laneq_s32 (int32x2_t a, int32x4_t v, const int lane); A32: VMUL.I32 Dd, Dn, Dm[lane]; A64: MUL Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vmul_lane_s32 (int32x2_t a, int32x2_t v, const int lane); A32: VMUL.I32 Dd, Dn, Dm[lane]; A64: MUL Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector64<Single>, Vector128<Single>, Byte)	float32x2_t vmul_laneq_f32 (float32x2_t a, float32x4_t v, const int lane); A32: VMUL.F32 Dd, Dn, Dm[lane]; A64: FMUL Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector64<Single>, Vector64<Single>, Byte)	float32x2_t vmul_lane_f32 (float32x2_t a, float32x2_t v, const int lane); A32: VMUL.F32 Dd, Dn, Dm[lane]; A64: FMUL Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector64<UInt16>, Vector128<UInt16>, Byte)	uint16x4_t vmul_laneq_u16 (uint16x4_t a, uint16x8_t v, const int lane); A32: VMUL.I16 Dd, Dn, Dm[lane]; A64: MUL Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalar(Vector64<UInt16>, Vector64<UInt16>, Byte)	uint16x4_t vmul_lane_u16 (uint16x4_t a, uint16x4_t v, const int lane); A32: VMUL.I16 Dd, Dn, Dm[lane]; A64: MUL Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalar(Vector64<UInt32>, Vector128<UInt32>, Byte)	uint32x2_t vmul_laneq_u32 (uint32x2_t a, uint32x4_t v, const int lane); A32: VMUL.I32 Dd, Dn, Dm[lane]; A64: MUL Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalar(Vector64<UInt32>, Vector64<UInt32>, Byte)	uint32x2_t vmul_lane_u32 (uint32x2_t a, uint32x2_t v, const int lane); A32: VMUL.I32 Dd, Dn, Dm[lane]; A64: MUL Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLower(Vector64<Int16>, Vector128<Int16>, Byte)	int32x4_t vmull_laneq_s16 (int16x4_t a, int16x8_t v, const int lane); A32: VMULL.S16 Qd, Dn, Dm[lane]; A64: SMULL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLower(Vector64<Int16>, Vector64<Int16>, Byte)	int32x4_t vmull_lane_s16 (int16x4_t a, int16x4_t v, const int lane); A32: VMULL.S16 Qd, Dn, Dm[lane]; A64: SMULL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLower(Vector64<Int32>, Vector128<Int32>, Byte)	int64x2_t vmull_laneq_s32 (int32x2_t a, int32x4_t v, const int lane); A32: VMULL.S32 Qd, Dn, Dm[lane]; A64: SMULL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLower(Vector64<Int32>, Vector64<Int32>, Byte)	int64x2_t vmull_lane_s32 (int32x2_t a, int32x2_t v, const int lane); A32: VMULL.S32 Qd, Dn, Dm[lane]; A64: SMULL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLower(Vector64<UInt16>, Vector128<UInt16>, Byte)	uint32x4_t vmull_laneq_u16 (uint16x4_t a, uint16x8_t v, const int lane); A32: VMULL.U16 Qd, Dn, Dm[lane]; A64: UMULL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLower(Vector64<UInt16>, Vector64<UInt16>, Byte)	uint32x4_t vmull_lane_u16 (uint16x4_t a, uint16x4_t v, const int lane); A32: VMULL.U16 Qd, Dn, Dm[lane]; A64: UMULL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLower(Vector64<UInt32>, Vector128<UInt32>, Byte)	uint64x2_t vmull_laneq_u32 (uint32x2_t a, uint32x4_t v, const int lane); A32: VMULL.U32 Qd, Dn, Dm[lane]; A64: UMULL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLower(Vector64<UInt32>, Vector64<UInt32>, Byte)	uint64x2_t vmull_lane_u32 (uint32x2_t a, uint32x2_t v, const int lane); A32: VMULL.U32 Qd, Dn, Dm[lane]; A64: UMULL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<Int32>, Vector64<Int16>, Vector128<Int16>, Byte)	int32x4_t vmlal_laneq_s16 (int32x4_t a, int16x4_t b, int16x8_t v, const int lane); A32: VMLAL.S16 Qd, Dn, Dm[lane]; A64: SMLAL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>, Byte)	int32x4_t vmlal_lane_s16 (int32x4_t a, int16x4_t b, int16x4_t v, const int lane); A32: VMLAL.S16 Qd, Dn, Dm[lane]; A64: SMLAL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<Int64>, Vector64<Int32>, Vector128<Int32>, Byte)	int64x2_t vmlal_laneq_s32 (int64x2_t a, int32x2_t b, int32x4_t v, const int lane); A32: VMLAL.S32 Qd, Dn, Dm[lane]; A64: SMLAL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>, Byte)	int64x2_t vmlal_lane_s32 (int64x2_t a, int32x2_t b, int32x2_t v, const int lane); A32: VMLAL.S32 Qd, Dn, Dm[lane]; A64: SMLAL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<UInt32>, Vector64<UInt16>, Vector128<UInt16>, Byte)	uint32x4_t vmlal_laneq_u16 (uint32x4_t a, uint16x4_t b, uint16x8_t v, const int lane); A32: VMLAL.U16 Qd, Dn, Dm[lane]; A64: UMLAL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<UInt32>, Vector64<UInt16>, Vector64<UInt16>, Byte)	uint32x4_t vmlal_lane_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t v, const int lane); A32: VMLAL.U16 Qd, Dn, Dm[lane]; A64: UMLAL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<UInt64>, Vector64<UInt32>, Vector128<UInt32>, Byte)	uint64x2_t vmlal_laneq_u32 (uint64x2_t a, uint32x2_t b, uint32x4_t v, const int lane); A32: VMLAL.U32 Qd, Dn, Dm[lane]; A64: UMLAL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLowerAndAdd(Vector128<UInt64>, Vector64<UInt32>, Vector64<UInt32>, Byte)	uint64x2_t vmlal_lane_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t v, const int lane); A32: VMLAL.U32 Qd, Dn, Dm[lane]; A64: UMLAL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<Int32>, Vector64<Int16>, Vector128<Int16>, Byte)	int32x4_t vmlsl_laneq_s16 (int32x4_t a, int16x4_t b, int16x8_t v, const int lane); A32: VMLSL.S16 Qd, Dn, Dm[lane]; A64: SMLSL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>, Byte)	int32x4_t vmlsl_lane_s16 (int32x4_t a, int16x4_t b, int16x4_t v, const int lane); A32: VMLSL.S16 Qd, Dn, Dm[lane]; A64: SMLSL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<Int64>, Vector64<Int32>, Vector128<Int32>, Byte)	int64x2_t vmlsl_laneq_s32 (int64x2_t a, int32x2_t b, int32x4_t v, const int lane); A32: VMLSL.S32 Qd, Dn, Dm[lane]; A64: SMLSL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>, Byte)	int64x2_t vmlsl_lane_s32 (int64x2_t a, int32x2_t b, int32x2_t v, const int lane); A32: VMLSL.S32 Qd, Dn, Dm[lane]; A64: SMLSL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<UInt32>, Vector64<UInt16>, Vector128<UInt16>, Byte)	uint32x4_t vmlsl_laneq_u16 (uint32x4_t a, uint16x4_t b, uint16x8_t v, const int lane); A32: VMLSL.U16 Qd, Dn, Dm[lane]; A64: UMLSL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<UInt32>, Vector64<UInt16>, Vector64<UInt16>, Byte)	uint32x4_t vmlsl_lane_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t v, const int lane); A32: VMLSL.U16 Qd, Dn, Dm[lane]; A64: UMLSL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<UInt64>, Vector64<UInt32>, Vector128<UInt32>, Byte)	uint64x2_t vmlsl_laneq_u32 (uint64x2_t a, uint32x2_t b, uint32x4_t v, const int lane); A32: VMLSL.U32 Qd, Dn, Dm[lane]; A64: UMLSL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningLowerAndSubtract(Vector128<UInt64>, Vector64<UInt32>, Vector64<UInt32>, Byte)	uint64x2_t vmlsl_lane_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t v, const int lane); A32: VMLSL.U32 Qd, Dn, Dm[lane]; A64: UMLSL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpper(Vector128<Int16>, Vector128<Int16>, Byte)	int32x4_t vmull_high_laneq_s16 (int16x8_t a, int16x8_t v, const int lane); A32: VMULL.S16 Qd, Dn+1, Dm[lane]; A64: SMULL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpper(Vector128<Int16>, Vector64<Int16>, Byte)	int32x4_t vmull_high_lane_s16 (int16x8_t a, int16x4_t v, const int lane); A32: VMULL.S16 Qd, Dn+1, Dm[lane]; A64: SMULL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpper(Vector128<Int32>, Vector128<Int32>, Byte)	int64x2_t vmull_high_laneq_s32 (int32x4_t a, int32x4_t v, const int lane); A32: VMULL.S32 Qd, Dn+1, Dm[lane]; A64: SMULL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpper(Vector128<Int32>, Vector64<Int32>, Byte)	int64x2_t vmull_high_lane_s32 (int32x4_t a, int32x2_t v, const int lane); A32: VMULL.S32 Qd, Dn+1, Dm[lane]; A64: SMULL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpper(Vector128<UInt16>, Vector128<UInt16>, Byte)	uint32x4_t vmull_high_laneq_u16 (uint16x8_t a, uint16x8_t v, const int lane); A32: VMULL.U16 Qd, Dn+1, Dm[lane]; A64: UMULL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpper(Vector128<UInt16>, Vector64<UInt16>, Byte)	uint32x4_t vmull_high_lane_u16 (uint16x8_t a, uint16x4_t v, const int lane); A32: VMULL.U16 Qd, Dn+1, Dm[lane]; A64: UMULL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpper(Vector128<UInt32>, Vector128<UInt32>, Byte)	uint64x2_t vmull_high_laneq_u32 (uint32x4_t a, uint32x4_t v, const int lane); A32: VMULL.U32 Qd, Dn+1, Dm[lane]; A64: UMULL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpper(Vector128<UInt32>, Vector64<UInt32>, Byte)	uint64x2_t vmull_high_lane_u32 (uint32x4_t a, uint32x2_t v, const int lane); A32: VMULL.U32 Qd, Dn+1, Dm[lane]; A64: UMULL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>, Byte)	int32x4_t vmlal_high_laneq_s16 (int32x4_t a, int16x8_t b, int16x8_t v, const int lane); A32: VMLAL.S16 Qd, Dn+1, Dm[lane]; A64: SMLAL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<Int32>, Vector128<Int16>, Vector64<Int16>, Byte)	int32x4_t vmlal_high_lane_s16 (int32x4_t a, int16x8_t b, int16x4_t v, const int lane); A32: VMLAL.S16 Qd, Dn+1, Dm[lane]; A64: SMLAL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>, Byte)	int64x2_t vmlal_high_laneq_s32 (int64x2_t a, int32x4_t b, int32x4_t v, const int lane); A32: VMLAL.S32 Qd, Dn+1, Dm[lane]; A64: SMLAL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<Int64>, Vector128<Int32>, Vector64<Int32>, Byte)	int64x2_t vmlal_high_lane_s32 (int64x2_t a, int32x4_t b, int32x2_t v, const int lane); A32: VMLAL.S32 Qd, Dn+1, Dm[lane]; A64: SMLAL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<UInt32>, Vector128<UInt16>, Vector128<UInt16>, Byte)	uint32x4_t vmlal_high_laneq_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t v, const int lane); A32: VMLAL.U16 Qd, Dn+1, Dm[lane]; A64: UMLAL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<UInt32>, Vector128<UInt16>, Vector64<UInt16>, Byte)	uint32x4_t vmlal_high_lane_u16 (uint32x4_t a, uint16x8_t b, uint16x4_t v, const int lane); A32: VMLAL.U16 Qd, Dn+1, Dm[lane]; A64: UMLAL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<UInt64>, Vector128<UInt32>, Vector128<UInt32>, Byte)	uint64x2_t vmlal_high_laneq_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t v, const int lane); A32: VMLAL.U32 Qd, Dn+1, Dm[lane]; A64: UMLAL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpperAndAdd(Vector128<UInt64>, Vector128<UInt32>, Vector64<UInt32>, Byte)	uint64x2_t vmlal_high_lane_u32 (uint64x2_t a, uint32x4_t b, uint32x2_t v, const int lane); A32: VMLAL.U32 Qd, Dn+1, Dm[lane]; A64: UMLAL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>, Byte)	int32x4_t vmlsl_high_laneq_s16 (int32x4_t a, int16x8_t b, int16x8_t v, const int lane); A32: VMLSL.S16 Qd, Dn+1, Dm[lane]; A64: SMLSL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<Int32>, Vector128<Int16>, Vector64<Int16>, Byte)	int32x4_t vmlsl_high_lane_s16 (int32x4_t a, int16x8_t b, int16x4_t v, const int lane); A32: VMLSL.S16 Qd, Dn+1, Dm[lane]; A64: SMLSL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>, Byte)	int64x2_t vmlsl_high_laneq_s32 (int64x2_t a, int32x4_t b, int32x4_t v, const int lane); A32: VMLSL.S32 Qd, Dn+1, Dm[lane]; A64: SMLSL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<Int64>, Vector128<Int32>, Vector64<Int32>, Byte)	int64x2_t vmlsl_high_lane_s32 (int64x2_t a, int32x4_t b, int32x2_t v, const int lane); A32: VMLSL.S32 Qd, Dn+1, Dm[lane]; A64: SMLSL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<UInt32>, Vector128<UInt16>, Vector128<UInt16>, Byte)	uint32x4_t vmlsl_high_laneq_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t v, const int lane); A32: VMLSL.U16 Qd, Dn+1, Dm[lane]; A64: UMLSL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<UInt32>, Vector128<UInt16>, Vector64<UInt16>, Byte)	uint32x4_t vmlsl_high_lane_u16 (uint32x4_t a, uint16x8_t b, uint16x4_t v, const int lane); A32: VMLSL.U16 Qd, Dn+1, Dm[lane]; A64: UMLSL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<UInt64>, Vector128<UInt32>, Vector128<UInt32>, Byte)	uint64x2_t vmlsl_high_laneq_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t v, const int lane); A32: VMLSL.U32 Qd, Dn+1, Dm[lane]; A64: UMLSL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyBySelectedScalarWideningUpperAndSubtract(Vector128<UInt64>, Vector128<UInt32>, Vector64<UInt32>, Byte)	uint64x2_t vmlsl_high_lane_u32 (uint64x2_t a, uint32x4_t b, uint32x2_t v, const int lane); A32: VMLSL.U32 Qd, Dn+1, Dm[lane]; A64: UMLSL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyDoublingByScalarSaturateHigh(Vector128<Int16>, Vector64<Int16>)	int16x8_t vqdmulhq_n_s16 (int16x8_t a, int16_t b) A32: VQDMULH.S16 Qd, Qn, Dm[0] A64: SQDMULH Vd.8H, Vn.8H, Vm.H[0]
            // MultiplyDoublingByScalarSaturateHigh(Vector128<Int32>, Vector64<Int32>)	int32x4_t vqdmulhq_n_s32 (int32x4_t a, int32_t b) A32: VQDMULH.S32 Qd, Qn, Dm[0] A64: SQDMULH Vd.4S, Vn.4S, Vm.S[0]
            // MultiplyDoublingByScalarSaturateHigh(Vector64<Int16>, Vector64<Int16>)	int16x4_t vqdmulh_n_s16 (int16x4_t a, int16_t b) A32: VQDMULH.S16 Dd, Dn, Dm[0] A64: SQDMULH Vd.4H, Vn.4H, Vm.H[0]
            // MultiplyDoublingByScalarSaturateHigh(Vector64<Int32>, Vector64<Int32>)	int32x2_t vqdmulh_n_s32 (int32x2_t a, int32_t b) A32: VQDMULH.S32 Dd, Dn, Dm[0] A64: SQDMULH Vd.2S, Vn.2S, Vm.S[0]
            // MultiplyDoublingBySelectedScalarSaturateHigh(Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vqdmulhq_laneq_s16 (int16x8_t a, int16x8_t v, const int lane) A32: VQDMULH.S16 Qd, Qn, Dm[lane] A64: SQDMULH Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyDoublingBySelectedScalarSaturateHigh(Vector128<Int16>, Vector64<Int16>, Byte)	int16x8_t vqdmulhq_lane_s16 (int16x8_t a, int16x4_t v, const int lane) A32: VQDMULH.S16 Qd, Qn, Dm[lane] A64: SQDMULH Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyDoublingBySelectedScalarSaturateHigh(Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vqdmulhq_laneq_s32 (int32x4_t a, int32x4_t v, const int lane) A32: VQDMULH.S32 Qd, Qn, Dm[lane] A64: SQDMULH Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyDoublingBySelectedScalarSaturateHigh(Vector128<Int32>, Vector64<Int32>, Byte)	int32x4_t vqdmulhq_lane_s32 (int32x4_t a, int32x2_t v, const int lane) A32: VQDMULH.S32 Qd, Qn, Dm[lane] A64: SQDMULH Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyDoublingBySelectedScalarSaturateHigh(Vector64<Int16>, Vector128<Int16>, Byte)	int16x4_t vqdmulh_laneq_s16 (int16x4_t a, int16x8_t v, const int lane) A32: VQDMULH.S16 Dd, Dn, Dm[lane] A64: SQDMULH Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyDoublingBySelectedScalarSaturateHigh(Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vqdmulh_lane_s16 (int16x4_t a, int16x4_t v, const int lane) A32: VQDMULH.S16 Dd, Dn, Dm[lane] A64: SQDMULH Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyDoublingBySelectedScalarSaturateHigh(Vector64<Int32>, Vector128<Int32>, Byte)	int32x2_t vqdmulh_laneq_s32 (int32x2_t a, int32x4_t v, const int lane) A32: VQDMULH.S32 Dd, Dn, Dm[lane] A64: SQDMULH Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyDoublingBySelectedScalarSaturateHigh(Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vqdmulh_lane_s32 (int32x2_t a, int32x2_t v, const int lane) A32: VQDMULH.S32 Dd, Dn, Dm[lane] A64: SQDMULH Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyDoublingSaturateHigh(Vector128<Int16>, Vector128<Int16>)	int16x8_t vqdmulhq_s16 (int16x8_t a, int16x8_t b) A32: VQDMULH.S16 Qd, Qn, Qm A64: SQDMULH Vd.8H, Vn.8H, Vm.8H
            // MultiplyDoublingSaturateHigh(Vector128<Int32>, Vector128<Int32>)	int32x4_t vqdmulhq_s32 (int32x4_t a, int32x4_t b) A32: VQDMULH.S32 Qd, Qn, Qm A64: SQDMULH Vd.4S, Vn.4S, Vm.4S
            // MultiplyDoublingSaturateHigh(Vector64<Int16>, Vector64<Int16>)	int16x4_t vqdmulh_s16 (int16x4_t a, int16x4_t b) A32: VQDMULH.S16 Dd, Dn, Dm A64: SQDMULH Vd.4H, Vn.4H, Vm.4H
            // MultiplyDoublingSaturateHigh(Vector64<Int32>, Vector64<Int32>)	int32x2_t vqdmulh_s32 (int32x2_t a, int32x2_t b) A32: VQDMULH.S32 Dd, Dn, Dm A64: SQDMULH Vd.2S, Vn.2S, Vm.2S
            // MultiplyDoublingWideningLowerAndAddSaturate(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>)	int32x4_t vqdmlal_s16 (int32x4_t a, int16x4_t b, int16x4_t c) A32: VQDMLAL.S16 Qd, Dn, Dm A64: SQDMLAL Vd.4S, Vn.4H, Vm.4H
            // MultiplyDoublingWideningLowerAndAddSaturate(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>)	int64x2_t vqdmlal_s32 (int64x2_t a, int32x2_t b, int32x2_t c) A32: VQDMLAL.S32 Qd, Dn, Dm A64: SQDMLAL Vd.2D, Vn.2S, Vm.2S
            // MultiplyDoublingWideningLowerAndSubtractSaturate(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>)	int32x4_t vqdmlsl_s16 (int32x4_t a, int16x4_t b, int16x4_t c) A32: VQDMLSL.S16 Qd, Dn, Dm A64: SQDMLSL Vd.4S, Vn.4H, Vm.4H
            // MultiplyDoublingWideningLowerAndSubtractSaturate(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>)	int64x2_t vqdmlsl_s32 (int64x2_t a, int32x2_t b, int32x2_t c) A32: VQDMLSL.S32 Qd, Dn, Dm A64: SQDMLSL Vd.2D, Vn.2S, Vm.2S
            // MultiplyDoublingWideningLowerByScalarAndAddSaturate(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>)	int32x4_t vqdmlal_n_s16 (int32x4_t a, int16x4_t b, int16_t c) A32: VQDMLAL.S16 Qd, Dn, Dm[0] A64: SQDMLAL Vd.4S, Vn.4H, Vm.H[0]
            // MultiplyDoublingWideningLowerByScalarAndAddSaturate(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>)	int64x2_t vqdmlal_n_s32 (int64x2_t a, int32x2_t b, int32_t c) A32: VQDMLAL.S32 Qd, Dn, Dm[0] A64: SQDMLAL Vd.2D, Vn.2S, Vm.S[0]
            // MultiplyDoublingWideningLowerByScalarAndSubtractSaturate(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>)	int32x4_t vqdmlsl_n_s16 (int32x4_t a, int16x4_t b, int16_t c) A32: VQDMLSL.S16 Qd, Dn, Dm[0] A64: SQDMLSL Vd.4S, Vn.4H, Vm.H[0]
            // MultiplyDoublingWideningLowerByScalarAndSubtractSaturate(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>)	int64x2_t vqdmlsl_n_s32 (int64x2_t a, int32x2_t b, int32_t c) A32: VQDMLSL.S32 Qd, Dn, Dm[0] A64: SQDMLSL Vd.2D, Vn.2S, Vm.S[0]
            // MultiplyDoublingWideningLowerBySelectedScalarAndAddSaturate(Vector128<Int32>, Vector64<Int16>, Vector128<Int16>, Byte)	int32x4_t vqdmlal_laneq_s16 (int32x4_t a, int16x4_t b, int16x8_t v, const int lane) A32: VQDMLAL.S16 Qd, Dn, Dm[lane] A64: SQDMLAL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyDoublingWideningLowerBySelectedScalarAndAddSaturate(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>, Byte)	int32x4_t vqdmlal_lane_s16 (int32x4_t a, int16x4_t b, int16x4_t v, const int lane) A32: VQDMLAL.S16 Qd, Dn, Dm[lane] A64: SQDMLAL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyDoublingWideningLowerBySelectedScalarAndAddSaturate(Vector128<Int64>, Vector64<Int32>, Vector128<Int32>, Byte)	int64x2_t vqdmlal_laneq_s32 (int64x2_t a, int32x2_t b, int32x4_t v, const int lane) A32: VQDMLAL.S32 Qd, Dn, Dm[lane] A64: SQDMLAL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyDoublingWideningLowerBySelectedScalarAndAddSaturate(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>, Byte)	int64x2_t vqdmlal_lane_s32 (int64x2_t a, int32x2_t b, int32x2_t v, const int lane) A32: VQDMLAL.S32 Qd, Dn, Dm[lane] A64: SQDMLAL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyDoublingWideningLowerBySelectedScalarAndSubtractSaturate(Vector128<Int32>, Vector64<Int16>, Vector128<Int16>, Byte)	int32x4_t vqdmlsl_laneq_s16 (int32x4_t a, int16x4_t b, int16x8_t v, const int lane) A32: VQDMLSL.S16 Qd, Dn, Dm[lane] A64: SQDMLSL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyDoublingWideningLowerBySelectedScalarAndSubtractSaturate(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>, Byte)	int32x4_t vqdmlsl_lane_s16 (int32x4_t a, int16x4_t b, int16x4_t v, const int lane) A32: VQDMLSL.S16 Qd, Dn, Dm[lane] A64: SQDMLSL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyDoublingWideningLowerBySelectedScalarAndSubtractSaturate(Vector128<Int64>, Vector64<Int32>, Vector128<Int32>, Byte)	int64x2_t vqdmlsl_laneq_s32 (int64x2_t a, int32x2_t b, int32x4_t v, const int lane) A32: VQDMLSL.S32 Qd, Dn, Dm[lane] A64: SQDMLSL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyDoublingWideningLowerBySelectedScalarAndSubtractSaturate(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>, Byte)	int64x2_t vqdmlsl_lane_s32 (int64x2_t a, int32x2_t b, int32x2_t v, const int lane) A32: VQDMLSL.S32 Qd, Dn, Dm[lane] A64: SQDMLSL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyDoublingWideningSaturateLower(Vector64<Int16>, Vector64<Int16>)	int32x4_t vqdmull_s16 (int16x4_t a, int16x4_t b) A32: VQDMULL.S16 Qd, Dn, Dm A64: SQDMULL Vd.4S, Vn.4H, Vm.4H
            // MultiplyDoublingWideningSaturateLower(Vector64<Int32>, Vector64<Int32>)	int64x2_t vqdmull_s32 (int32x2_t a, int32x2_t b) A32: VQDMULL.S32 Qd, Dn, Dm A64: SQDMULL Vd.2D, Vn.2S, Vm.2S
            // MultiplyDoublingWideningSaturateLowerByScalar(Vector64<Int16>, Vector64<Int16>)	int32x4_t vqdmull_n_s16 (int16x4_t a, int16_t b) A32: VQDMULL.S16 Qd, Dn, Dm[0] A64: SQDMULL Vd.4S, Vn.4H, Vm.H[0]
            // MultiplyDoublingWideningSaturateLowerByScalar(Vector64<Int32>, Vector64<Int32>)	int64x2_t vqdmull_n_s32 (int32x2_t a, int32_t b) A32: VQDMULL.S32 Qd, Dn, Dm[0] A64: SQDMULL Vd.2D, Vn.2S, Vm.S[0]
            // MultiplyDoublingWideningSaturateLowerBySelectedScalar(Vector64<Int16>, Vector128<Int16>, Byte)	int32x4_t vqdmull_laneq_s16 (int16x4_t a, int16x8_t v, const int lane) A32: VQDMULL.S16 Qd, Dn, Dm[lane] A64: SQDMULL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyDoublingWideningSaturateLowerBySelectedScalar(Vector64<Int16>, Vector64<Int16>, Byte)	int32x4_t vqdmull_lane_s16 (int16x4_t a, int16x4_t v, const int lane) A32: VQDMULL.S16 Qd, Dn, Dm[lane] A64: SQDMULL Vd.4S, Vn.4H, Vm.H[lane]
            // MultiplyDoublingWideningSaturateLowerBySelectedScalar(Vector64<Int32>, Vector128<Int32>, Byte)	int64x2_t vqdmull_laneq_s32 (int32x2_t a, int32x4_t v, const int lane) A32: VQDMULL.S32 Qd, Dn, Dm[lane] A64: SQDMULL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyDoublingWideningSaturateLowerBySelectedScalar(Vector64<Int32>, Vector64<Int32>, Byte)	int64x2_t vqdmull_lane_s32 (int32x2_t a, int32x2_t v, const int lane) A32: VQDMULL.S32 Qd, Dn, Dm[lane] A64: SQDMULL Vd.2D, Vn.2S, Vm.S[lane]
            // MultiplyDoublingWideningSaturateUpper(Vector128<Int16>, Vector128<Int16>)	int32x4_t vqdmull_high_s16 (int16x8_t a, int16x8_t b) A32: VQDMULL.S16 Qd, Dn+1, Dm+1 A64: SQDMULL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyDoublingWideningSaturateUpper(Vector128<Int32>, Vector128<Int32>)	int64x2_t vqdmull_high_s32 (int32x4_t a, int32x4_t b) A32: VQDMULL.S32 Qd, Dn+1, Dm+1 A64: SQDMULL2 Vd.2D, Vn.4S, Vm.4S
            // MultiplyDoublingWideningSaturateUpperByScalar(Vector128<Int16>, Vector64<Int16>)	int32x4_t vqdmull_high_n_s16 (int16x8_t a, int16_t b) A32: VQDMULL.S16 Qd, Dn+1, Dm[0] A64: SQDMULL2 Vd.4S, Vn.8H, Vm.H[0]
            // MultiplyDoublingWideningSaturateUpperByScalar(Vector128<Int32>, Vector64<Int32>)	int64x2_t vqdmull_high_n_s32 (int32x4_t a, int32_t b) A32: VQDMULL.S32 Qd, Dn+1, Dm[0] A64: SQDMULL2 Vd.2D, Vn.4S, Vm.S[0]
            // MultiplyDoublingWideningSaturateUpperBySelectedScalar(Vector128<Int16>, Vector128<Int16>, Byte)	int32x4_t vqdmull_high_laneq_s16 (int16x8_t a, int16x8_t v, const int lane) A32: VQDMULL.S16 Qd, Dn+1, Dm[lane] A64: SQDMULL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyDoublingWideningSaturateUpperBySelectedScalar(Vector128<Int16>, Vector64<Int16>, Byte)	int32x4_t vqdmull_high_lane_s16 (int16x8_t a, int16x4_t v, const int lane) A32: VQDMULL.S16 Qd, Dn+1, Dm[lane] A64: SQDMULL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyDoublingWideningSaturateUpperBySelectedScalar(Vector128<Int32>, Vector128<Int32>, Byte)	int64x2_t vqdmull_high_laneq_s32 (int32x4_t a, int32x4_t v, const int lane) A32: VQDMULL.S32 Qd, Dn+1, Dm[lane] A64: SQDMULL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyDoublingWideningSaturateUpperBySelectedScalar(Vector128<Int32>, Vector64<Int32>, Byte)	int64x2_t vqdmull_high_lane_s32 (int32x4_t a, int32x2_t v, const int lane) A32: VQDMULL.S32 Qd, Dn+1, Dm[lane] A64: SQDMULL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyDoublingWideningUpperAndAddSaturate(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>)	int32x4_t vqdmlal_high_s16 (int32x4_t a, int16x8_t b, int16x8_t c) A32: VQDMLAL.S16 Qd, Dn+1, Dm+1 A64: SQDMLAL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyDoublingWideningUpperAndAddSaturate(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>)	int64x2_t vqdmlal_high_s32 (int64x2_t a, int32x4_t b, int32x4_t c) A32: VQDMLAL.S32 Qd, Dn+1, Dm+1 A64: SQDMLAL2 Vd.2D, Vn.4S, Vm.4S
            // MultiplyDoublingWideningUpperAndSubtractSaturate(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>)	int32x4_t vqdmlsl_high_s16 (int32x4_t a, int16x8_t b, int16x8_t c) A32: VQDMLSL.S16 Qd, Dn+1, Dm+1 A64: SQDMLSL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyDoublingWideningUpperAndSubtractSaturate(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>)	int64x2_t vqdmlsl_high_s32 (int64x2_t a, int32x4_t b, int32x4_t c) A32: VQDMLSL.S32 Qd, Dn+1, Dm+1 A64: SQDMLSL2 Vd.2D, Vn.4S, Vm.4S
            // MultiplyDoublingWideningUpperByScalarAndAddSaturate(Vector128<Int32>, Vector128<Int16>, Vector64<Int16>)	int32x4_t vqdmlal_high_n_s16 (int32x4_t a, int16x8_t b, int16_t c) A32: VQDMLAL.S16 Qd, Dn+1, Dm[0] A64: SQDMLAL2 Vd.4S, Vn.8H, Vm.H[0]
            // MultiplyDoublingWideningUpperByScalarAndAddSaturate(Vector128<Int64>, Vector128<Int32>, Vector64<Int32>)	int64x2_t vqdmlal_high_n_s32 (int64x2_t a, int32x4_t b, int32_t c) A32: VQDMLAL.S32 Qd, Dn+1, Dm[0] A64: SQDMLAL2 Vd.2D, Vn.4S, Vm.S[0]
            // MultiplyDoublingWideningUpperByScalarAndSubtractSaturate(Vector128<Int32>, Vector128<Int16>, Vector64<Int16>)	int32x4_t vqdmlsl_high_n_s16 (int32x4_t a, int16x8_t b, int16_t c) A32: VQDMLSL.S16 Qd, Dn+1, Dm[0] A64: SQDMLSL2 Vd.4S, Vn.8H, Vm.H[0]
            // MultiplyDoublingWideningUpperByScalarAndSubtractSaturate(Vector128<Int64>, Vector128<Int32>, Vector64<Int32>)	int64x2_t vqdmlsl_high_n_s32 (int64x2_t a, int32x4_t b, int32_t c) A32: VQDMLSL.S32 Qd, Dn+1, Dm[0] A64: SQDMLSL2 Vd.2D, Vn.4S, Vm.S[0]
            // MultiplyDoublingWideningUpperBySelectedScalarAndAddSaturate(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>, Byte)	int32x4_t vqdmlal_high_laneq_s16 (int32x4_t a, int16x8_t b, int16x8_t v, const int lane) A32: VQDMLAL.S16 Qd, Dn+1, Dm[lane] A64: SQDMLAL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyDoublingWideningUpperBySelectedScalarAndAddSaturate(Vector128<Int32>, Vector128<Int16>, Vector64<Int16>, Byte)	int32x4_t vqdmlal_high_lane_s16 (int32x4_t a, int16x8_t b, int16x4_t v, const int lane) A32: VQDMLAL.S16 Qd, Dn+1, Dm[lane] A64: SQDMLAL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyDoublingWideningUpperBySelectedScalarAndAddSaturate(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>, Byte)	int64x2_t vqdmlal_high_laneq_s32 (int64x2_t a, int32x4_t b, int32x4_t v, const int lane) A32: VQDMLAL.S32 Qd, Dn+1, Dm[lane] A64: SQDMLAL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyDoublingWideningUpperBySelectedScalarAndAddSaturate(Vector128<Int64>, Vector128<Int32>, Vector64<Int32>, Byte)	int64x2_t vqdmlal_high_lane_s32 (int64x2_t a, int32x4_t b, int32x2_t v, const int lane) A32: VQDMLAL.S32 Qd, Dn+1, Dm[lane] A64: SQDMLAL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyDoublingWideningUpperBySelectedScalarAndSubtractSaturate(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>, Byte)	int32x4_t vqdmlsl_high_laneq_s16 (int32x4_t a, int16x8_t b, int16x8_t v, const int lane) A32: VQDMLSL.S16 Qd, Dn+1, Dm[lane] A64: SQDMLSL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyDoublingWideningUpperBySelectedScalarAndSubtractSaturate(Vector128<Int32>, Vector128<Int16>, Vector64<Int16>, Byte)	int32x4_t vqdmlsl_high_lane_s16 (int32x4_t a, int16x8_t b, int16x4_t v, const int lane) A32: VQDMLSL.S16 Qd, Dn+1, Dm[lane] A64: SQDMLSL2 Vd.4S, Vn.8H, Vm.H[lane]
            // MultiplyDoublingWideningUpperBySelectedScalarAndSubtractSaturate(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>, Byte)	int64x2_t vqdmlsl_high_laneq_s32 (int64x2_t a, int32x4_t b, int32x4_t v, const int lane) A32: VQDMLSL.S32 Qd, Dn+1, Dm[lane] A64: SQDMLSL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyDoublingWideningUpperBySelectedScalarAndSubtractSaturate(Vector128<Int64>, Vector128<Int32>, Vector64<Int32>, Byte)	int64x2_t vqdmlsl_high_lane_s32 (int64x2_t a, int32x4_t b, int32x2_t v, const int lane) A32: VQDMLSL.S32 Qd, Dn+1, Dm[lane] A64: SQDMLSL2 Vd.2D, Vn.4S, Vm.S[lane]
            // MultiplyRoundedDoublingByScalarSaturateHigh(Vector128<Int16>, Vector64<Int16>)	int16x8_t vqrdmulhq_n_s16 (int16x8_t a, int16_t b) A32: VQRDMULH.S16 Qd, Qn, Dm[0] A64: SQRDMULH Vd.8H, Vn.8H, Vm.H[0]
            // MultiplyRoundedDoublingByScalarSaturateHigh(Vector128<Int32>, Vector64<Int32>)	int32x4_t vqrdmulhq_n_s32 (int32x4_t a, int32_t b) A32: VQRDMULH.S32 Qd, Qn, Dm[0] A64: SQRDMULH Vd.4S, Vn.4S, Vm.S[0]
            // MultiplyRoundedDoublingByScalarSaturateHigh(Vector64<Int16>, Vector64<Int16>)	int16x4_t vqrdmulh_n_s16 (int16x4_t a, int16_t b) A32: VQRDMULH.S16 Dd, Dn, Dm[0] A64: SQRDMULH Vd.4H, Vn.4H, Vm.H[0]
            // MultiplyRoundedDoublingByScalarSaturateHigh(Vector64<Int32>, Vector64<Int32>)	int32x2_t vqrdmulh_n_s32 (int32x2_t a, int32_t b) A32: VQRDMULH.S32 Dd, Dn, Dm[0] A64: SQRDMULH Vd.2S, Vn.2S, Vm.S[0]
            // MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vqrdmulhq_laneq_s16 (int16x8_t a, int16x8_t v, const int lane) A32: VQRDMULH.S16 Qd, Qn, Dm[lane] A64: SQRDMULH Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector128<Int16>, Vector64<Int16>, Byte)	int16x8_t vqrdmulhq_lane_s16 (int16x8_t a, int16x4_t v, const int lane) A32: VQRDMULH.S16 Qd, Qn, Dm[lane] A64: SQRDMULH Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vqrdmulhq_laneq_s32 (int32x4_t a, int32x4_t v, const int lane) A32: VQRDMULH.S32 Qd, Qn, Dm[lane] A64: SQRDMULH Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector128<Int32>, Vector64<Int32>, Byte)	int32x4_t vqrdmulhq_lane_s32 (int32x4_t a, int32x2_t v, const int lane) A32: VQRDMULH.S32 Qd, Qn, Dm[lane] A64: SQRDMULH Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector64<Int16>, Vector128<Int16>, Byte)	int16x4_t vqrdmulh_laneq_s16 (int16x4_t a, int16x8_t v, const int lane) A32: VQRDMULH.S16 Dd, Dn, Dm[lane] A64: SQRDMULH Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vqrdmulh_lane_s16 (int16x4_t a, int16x4_t v, const int lane) A32: VQRDMULH.S16 Dd, Dn, Dm[lane] A64: SQRDMULH Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector64<Int32>, Vector128<Int32>, Byte)	int32x2_t vqrdmulh_laneq_s32 (int32x2_t a, int32x4_t v, const int lane) A32: VQRDMULH.S32 Dd, Dn, Dm[lane] A64: SQRDMULH Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyRoundedDoublingBySelectedScalarSaturateHigh(Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vqrdmulh_lane_s32 (int32x2_t a, int32x2_t v, const int lane) A32: VQRDMULH.S32 Dd, Dn, Dm[lane] A64: SQRDMULH Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyRoundedDoublingSaturateHigh(Vector128<Int16>, Vector128<Int16>)	int16x8_t vqrdmulhq_s16 (int16x8_t a, int16x8_t b) A32: VQRDMULH.S16 Qd, Qn, Qm A64: SQRDMULH Vd.8H, Vn.8H, Vm.8H
            // MultiplyRoundedDoublingSaturateHigh(Vector128<Int32>, Vector128<Int32>)	int32x4_t vqrdmulhq_s32 (int32x4_t a, int32x4_t b) A32: VQRDMULH.S32 Qd, Qn, Qm A64: SQRDMULH Vd.4S, Vn.4S, Vm.4S
            // MultiplyRoundedDoublingSaturateHigh(Vector64<Int16>, Vector64<Int16>)	int16x4_t vqrdmulh_s16 (int16x4_t a, int16x4_t b) A32: VQRDMULH.S16 Dd, Dn, Dm A64: SQRDMULH Vd.4H, Vn.4H, Vm.4H
            // MultiplyRoundedDoublingSaturateHigh(Vector64<Int32>, Vector64<Int32>)	int32x2_t vqrdmulh_s32 (int32x2_t a, int32x2_t b) A32: VQRDMULH.S32 Dd, Dn, Dm A64: SQRDMULH Vd.2S, Vn.2S, Vm.2S
            // MultiplyScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vmul_f64 (float64x1_t a, float64x1_t b); A32: VMUL.F64 Dd, Dn, Dm; A64: FMUL Dd, Dn, Dm
            // MultiplyScalar(Vector64<Single>, Vector64<Single>)	float32_t vmuls_f32 (float32_t a, float32_t b); A32: VMUL.F32 Sd, Sn, Sm; A64: FMUL Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // MultiplyScalarBySelectedScalar(Vector64<Single>, Vector128<Single>, Byte)	float32_t vmuls_laneq_f32 (float32_t a, float32x4_t v, const int lane); A32: VMUL.F32 Sd, Sn, Dm[lane]; A64: FMUL Sd, Sn, Vm.S[lane]
            // MultiplyScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Byte)	float32_t vmuls_lane_f32 (float32_t a, float32x2_t v, const int lane); A32: VMUL.F32 Sd, Sn, Dm[lane]; A64: FMUL Sd, Sn, Vm.S[lane]
            // MultiplySubtract(Vector128<Byte>, Vector128<Byte>, Vector128<Byte>)	uint8x16_t vmlsq_u8 (uint8x16_t a, uint8x16_t b, uint8x16_t c); A32: VMLS.I8 Qd, Qn, Qm; A64: MLS Vd.16B, Vn.16B, Vm.16B
            // MultiplySubtract(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>)	int16x8_t vmlsq_s16 (int16x8_t a, int16x8_t b, int16x8_t c); A32: VMLS.I16 Qd, Qn, Qm; A64: MLS Vd.8H, Vn.8H, Vm.8H
            // MultiplySubtract(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>)	int32x4_t vmlsq_s32 (int32x4_t a, int32x4_t b, int32x4_t c); A32: VMLS.I32 Qd, Qn, Qm; A64: MLS Vd.4S, Vn.4S, Vm.4S
            // MultiplySubtract(Vector128<SByte>, Vector128<SByte>, Vector128<SByte>)	int8x16_t vmlsq_s8 (int8x16_t a, int8x16_t b, int8x16_t c); A32: VMLS.I8 Qd, Qn, Qm; A64: MLS Vd.16B, Vn.16B, Vm.16B
            // MultiplySubtract(Vector128<UInt16>, Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vmlsq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t c); A32: VMLS.I16 Qd, Qn, Qm; A64: MLS Vd.8H, Vn.8H, Vm.8H
            // MultiplySubtract(Vector128<UInt32>, Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vmlsq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t c); A32: VMLS.I32 Qd, Qn, Qm; A64: MLS Vd.4S, Vn.4S, Vm.4S
            // MultiplySubtract(Vector64<Byte>, Vector64<Byte>, Vector64<Byte>)	uint8x8_t vmls_u8 (uint8x8_t a, uint8x8_t b, uint8x8_t c); A32: VMLS.I8 Dd, Dn, Dm; A64: MLS Vd.8B, Vn.8B, Vm.8B
            // MultiplySubtract(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16x4_t vmls_s16 (int16x4_t a, int16x4_t b, int16x4_t c); A32: VMLS.I16 Dd, Dn, Dm; A64: MLS Vd.4H, Vn.4H, Vm.4H
            // MultiplySubtract(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32x2_t vmls_s32 (int32x2_t a, int32x2_t b, int32x2_t c); A32: VMLS.I32 Dd, Dn, Dm; A64: MLS Vd.2S, Vn.2S, Vm.2S
            // MultiplySubtract(Vector64<SByte>, Vector64<SByte>, Vector64<SByte>)	int8x8_t vmls_s8 (int8x8_t a, int8x8_t b, int8x8_t c); A32: VMLS.I8 Dd, Dn, Dm; A64: MLS Vd.8B, Vn.8B, Vm.8B
            // MultiplySubtract(Vector64<UInt16>, Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vmls_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t c); A32: VMLS.I16 Dd, Dn, Dm; A64: MLS Vd.4H, Vn.4H, Vm.4H
            // MultiplySubtract(Vector64<UInt32>, Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vmls_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t c); A32: VMLS.I32 Dd, Dn, Dm; A64: MLS Vd.2S, Vn.2S, Vm.2S
            // MultiplySubtractByScalar(Vector128<Int16>, Vector128<Int16>, Vector64<Int16>)	int16x8_t vmlsq_n_s16 (int16x8_t a, int16x8_t b, int16_t c); A32: VMLS.I16 Qd, Qn, Dm[0]; A64: MLS Vd.8H, Vn.8H, Vm.H[0]
            // MultiplySubtractByScalar(Vector128<Int32>, Vector128<Int32>, Vector64<Int32>)	int32x4_t vmlsq_n_s32 (int32x4_t a, int32x4_t b, int32_t c); A32: VMLS.I32 Qd, Qn, Dm[0]; A64: MLS Vd.4S, Vn.4S, Vm.S[0]
            // MultiplySubtractByScalar(Vector128<UInt16>, Vector128<UInt16>, Vector64<UInt16>)	uint16x8_t vmlsq_n_u16 (uint16x8_t a, uint16x8_t b, uint16_t c); A32: VMLS.I16 Qd, Qn, Dm[0]; A64: MLS Vd.8H, Vn.8H, Vm.H[0]
            // MultiplySubtractByScalar(Vector128<UInt32>, Vector128<UInt32>, Vector64<UInt32>)	uint32x4_t vmlsq_n_u32 (uint32x4_t a, uint32x4_t b, uint32_t c); A32: VMLS.I32 Qd, Qn, Dm[0]; A64: MLS Vd.4S, Vn.4S, Vm.S[0]
            // MultiplySubtractByScalar(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>)	int16x4_t vmls_n_s16 (int16x4_t a, int16x4_t b, int16_t c); A32: VMLS.I16 Dd, Dn, Dm[0]; A64: MLS Vd.4H, Vn.4H, Vm.H[0]
            // MultiplySubtractByScalar(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>)	int32x2_t vmls_n_s32 (int32x2_t a, int32x2_t b, int32_t c); A32: VMLS.I32 Dd, Dn, Dm[0]; A64: MLS Vd.2S, Vn.2S, Vm.S[0]
            // MultiplySubtractByScalar(Vector64<UInt16>, Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vmls_n_u16 (uint16x4_t a, uint16x4_t b, uint16_t c); A32: VMLS.I16 Dd, Dn, Dm[0]; A64: MLS Vd.4H, Vn.4H, Vm.H[0]
            // MultiplySubtractByScalar(Vector64<UInt32>, Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vmls_n_u32 (uint32x2_t a, uint32x2_t b, uint32_t c); A32: VMLS.I32 Dd, Dn, Dm[0]; A64: MLS Vd.2S, Vn.2S, Vm.S[0]
            // MultiplySubtractBySelectedScalar(Vector128<Int16>, Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vmlsq_laneq_s16 (int16x8_t a, int16x8_t b, int16x8_t v, const int lane); A32: VMLS.I16 Qd, Qn, Dm[lane]; A64: MLS Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplySubtractBySelectedScalar(Vector128<Int16>, Vector128<Int16>, Vector64<Int16>, Byte)	int16x8_t vmlsq_lane_s16 (int16x8_t a, int16x8_t b, int16x4_t v, const int lane); A32: VMLS.I16 Qd, Qn, Dm[lane]; A64: MLS Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplySubtractBySelectedScalar(Vector128<Int32>, Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vmlsq_laneq_s32 (int32x4_t a, int32x4_t b, int32x4_t v, const int lane); A32: VMLS.I32 Qd, Qn, Dm[lane]; A64: MLS Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplySubtractBySelectedScalar(Vector128<Int32>, Vector128<Int32>, Vector64<Int32>, Byte)	int32x4_t vmlsq_lane_s32 (int32x4_t a, int32x4_t b, int32x2_t v, const int lane); A32: VMLS.I32 Qd, Qn, Dm[lane]; A64: MLS Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplySubtractBySelectedScalar(Vector128<UInt16>, Vector128<UInt16>, Vector128<UInt16>, Byte)	uint16x8_t vmlsq_laneq_u16 (uint16x8_t a, uint16x8_t b, uint16x8_t v, const int lane); A32: VMLS.I16 Qd, Qn, Dm[lane]; A64: MLS Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplySubtractBySelectedScalar(Vector128<UInt16>, Vector128<UInt16>, Vector64<UInt16>, Byte)	uint16x8_t vmlsq_lane_u16 (uint16x8_t a, uint16x8_t b, uint16x4_t v, const int lane); A32: VMLS.I16 Qd, Qn, Dm[lane]; A64: MLS Vd.8H, Vn.8H, Vm.H[lane]
            // MultiplySubtractBySelectedScalar(Vector128<UInt32>, Vector128<UInt32>, Vector128<UInt32>, Byte)	uint32x4_t vmlsq_laneq_u32 (uint32x4_t a, uint32x4_t b, uint32x4_t v, const int lane); A32: VMLS.I32 Qd, Qn, Dm[lane]; A64: MLS Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplySubtractBySelectedScalar(Vector128<UInt32>, Vector128<UInt32>, Vector64<UInt32>, Byte)	uint32x4_t vmlsq_lane_u32 (uint32x4_t a, uint32x4_t b, uint32x2_t v, const int lane); A32: VMLS.I32 Qd, Qn, Dm[lane]; A64: MLS Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplySubtractBySelectedScalar(Vector64<Int16>, Vector64<Int16>, Vector128<Int16>, Byte)	int16x4_t vmls_laneq_s16 (int16x4_t a, int16x4_t b, int16x8_t v, const int lane); A32: VMLS.I16 Dd, Dn, Dm[lane]; A64: MLS Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplySubtractBySelectedScalar(Vector64<Int16>, Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vmls_lane_s16 (int16x4_t a, int16x4_t b, int16x4_t v, const int lane); A32: VMLS.I16 Dd, Dn, Dm[lane]; A64: MLS Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplySubtractBySelectedScalar(Vector64<Int32>, Vector64<Int32>, Vector128<Int32>, Byte)	int32x2_t vmls_laneq_s32 (int32x2_t a, int32x2_t b, int32x4_t v, const int lane); A32: VMLS.I32 Dd, Dn, Dm[lane]; A64: MLS Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplySubtractBySelectedScalar(Vector64<Int32>, Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vmls_lane_s32 (int32x2_t a, int32x2_t b, int32x2_t v, const int lane); A32: VMLS.I32 Dd, Dn, Dm[lane]; A64: MLS Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplySubtractBySelectedScalar(Vector64<UInt16>, Vector64<UInt16>, Vector128<UInt16>, Byte)	uint16x4_t vmls_laneq_u16 (uint16x4_t a, uint16x4_t b, uint16x8_t v, const int lane); A32: VMLS.I16 Dd, Dn, Dm[lane]; A64: MLS Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplySubtractBySelectedScalar(Vector64<UInt16>, Vector64<UInt16>, Vector64<UInt16>, Byte)	uint16x4_t vmls_lane_u16 (uint16x4_t a, uint16x4_t b, uint16x4_t v, const int lane); A32: VMLS.I16 Dd, Dn, Dm[lane]; A64: MLS Vd.4H, Vn.4H, Vm.H[lane]
            // MultiplySubtractBySelectedScalar(Vector64<UInt32>, Vector64<UInt32>, Vector128<UInt32>, Byte)	uint32x2_t vmls_laneq_u32 (uint32x2_t a, uint32x2_t b, uint32x4_t v, const int lane); A32: VMLS.I32 Dd, Dn, Dm[lane]; A64: MLS Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplySubtractBySelectedScalar(Vector64<UInt32>, Vector64<UInt32>, Vector64<UInt32>, Byte)	uint32x2_t vmls_lane_u32 (uint32x2_t a, uint32x2_t b, uint32x2_t v, const int lane); A32: VMLS.I32 Dd, Dn, Dm[lane]; A64: MLS Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyWideningLower(Vector64<Byte>, Vector64<Byte>)	uint16x8_t vmull_u8 (uint8x8_t a, uint8x8_t b); A32: VMULL.U8 Qd, Dn, Dm; A64: UMULL Vd.8H, Vn.8B, Vm.8B
            // MultiplyWideningLower(Vector64<Int16>, Vector64<Int16>)	int32x4_t vmull_s16 (int16x4_t a, int16x4_t b); A32: VMULL.S16 Qd, Dn, Dm; A64: SMULL Vd.4S, Vn.4H, Vm.4H
            // MultiplyWideningLower(Vector64<Int32>, Vector64<Int32>)	int64x2_t vmull_s32 (int32x2_t a, int32x2_t b); A32: VMULL.S32 Qd, Dn, Dm; A64: SMULL Vd.2D, Vn.2S, Vm.2S
            // MultiplyWideningLower(Vector64<SByte>, Vector64<SByte>)	int16x8_t vmull_s8 (int8x8_t a, int8x8_t b); A32: VMULL.S8 Qd, Dn, Dm; A64: SMULL Vd.8H, Vn.8B, Vm.8B
            // MultiplyWideningLower(Vector64<UInt16>, Vector64<UInt16>)	uint32x4_t vmull_u16 (uint16x4_t a, uint16x4_t b); A32: VMULL.U16 Qd, Dn, Dm; A64: UMULL Vd.4S, Vn.4H, Vm.4H
            // MultiplyWideningLower(Vector64<UInt32>, Vector64<UInt32>)	uint64x2_t vmull_u32 (uint32x2_t a, uint32x2_t b); A32: VMULL.U32 Qd, Dn, Dm; A64: UMULL Vd.2D, Vn.2S, Vm.2S
            // MultiplyWideningLowerAndAdd(Vector128<Int16>, Vector64<SByte>, Vector64<SByte>)	int16x8_t vmlal_s8 (int16x8_t a, int8x8_t b, int8x8_t c); A32: VMLAL.S8 Qd, Dn, Dm; A64: SMLAL Vd.8H, Vn.8B, Vm.8B
            // MultiplyWideningLowerAndAdd(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>)	int32x4_t vmlal_s16 (int32x4_t a, int16x4_t b, int16x4_t c); A32: VMLAL.S16 Qd, Dn, Dm; A64: SMLAL Vd.4S, Vn.4H, Vm.4H
            // MultiplyWideningLowerAndAdd(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>)	int64x2_t vmlal_s32 (int64x2_t a, int32x2_t b, int32x2_t c); A32: VMLAL.S32 Qd, Dn, Dm; A64: SMLAL Vd.2D, Vn.2S, Vm.2S
            // MultiplyWideningLowerAndAdd(Vector128<UInt16>, Vector64<Byte>, Vector64<Byte>)	uint16x8_t vmlal_u8 (uint16x8_t a, uint8x8_t b, uint8x8_t c); A32: VMLAL.U8 Qd, Dn, Dm; A64: UMLAL Vd.8H, Vn.8B, Vm.8B
            // MultiplyWideningLowerAndAdd(Vector128<UInt32>, Vector64<UInt16>, Vector64<UInt16>)	uint32x4_t vmlal_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t c); A32: VMLAL.U16 Qd, Dn, Dm; A64: UMLAL Vd.4S, Vn.4H, Vm.4H
            // MultiplyWideningLowerAndAdd(Vector128<UInt64>, Vector64<UInt32>, Vector64<UInt32>)	uint64x2_t vmlal_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t c); A32: VMLAL.U32 Qd, Dn, Dm; A64: UMLAL Vd.2D, Vn.2S, Vm.2S
            // MultiplyWideningLowerAndSubtract(Vector128<Int16>, Vector64<SByte>, Vector64<SByte>)	int16x8_t vmlsl_s8 (int16x8_t a, int8x8_t b, int8x8_t c); A32: VMLSL.S8 Qd, Dn, Dm; A64: SMLSL Vd.8H, Vn.8B, Vm.8B
            // MultiplyWideningLowerAndSubtract(Vector128<Int32>, Vector64<Int16>, Vector64<Int16>)	int32x4_t vmlsl_s16 (int32x4_t a, int16x4_t b, int16x4_t c); A32: VMLSL.S16 Qd, Dn, Dm; A64: SMLSL Vd.4S, Vn.4H, Vm.4H
            // MultiplyWideningLowerAndSubtract(Vector128<Int64>, Vector64<Int32>, Vector64<Int32>)	int64x2_t vmlsl_s32 (int64x2_t a, int32x2_t b, int32x2_t c); A32: VMLSL.S32 Qd, Dn, Dm; A64: SMLSL Vd.2D, Vn.2S, Vm.2S
            // MultiplyWideningLowerAndSubtract(Vector128<UInt16>, Vector64<Byte>, Vector64<Byte>)	uint16x8_t vmlsl_u8 (uint16x8_t a, uint8x8_t b, uint8x8_t c); A32: VMLSL.U8 Qd, Dn, Dm; A64: UMLSL Vd.8H, Vn.8B, Vm.8B
            // MultiplyWideningLowerAndSubtract(Vector128<UInt32>, Vector64<UInt16>, Vector64<UInt16>)	uint32x4_t vmlsl_u16 (uint32x4_t a, uint16x4_t b, uint16x4_t c); A32: VMLSL.U16 Qd, Dn, Dm; A64: UMLSL Vd.4S, Vn.4H, Vm.4H
            // MultiplyWideningLowerAndSubtract(Vector128<UInt64>, Vector64<UInt32>, Vector64<UInt32>)	uint64x2_t vmlsl_u32 (uint64x2_t a, uint32x2_t b, uint32x2_t c); A32: VMLSL.U32 Qd, Dn, Dm; A64: UMLSL Vd.2D, Vn.2S, Vm.2S
            // MultiplyWideningUpper(Vector128<Byte>, Vector128<Byte>)	uint16x8_t vmull_high_u8 (uint8x16_t a, uint8x16_t b); A32: VMULL.U8 Qd, Dn+1, Dm+1; A64: UMULL2 Vd.8H, Vn.16B, Vm.16B
            // MultiplyWideningUpper(Vector128<Int16>, Vector128<Int16>)	int32x4_t vmull_high_s16 (int16x8_t a, int16x8_t b); A32: VMULL.S16 Qd, Dn+1, Dm+1; A64: SMULL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyWideningUpper(Vector128<Int32>, Vector128<Int32>)	int64x2_t vmull_high_s32 (int32x4_t a, int32x4_t b); A32: VMULL.S32 Qd, Dn+1, Dm+1; A64: SMULL2 Vd.2D, Vn.4S, Vm.4S
            // MultiplyWideningUpper(Vector128<SByte>, Vector128<SByte>)	int16x8_t vmull_high_s8 (int8x16_t a, int8x16_t b); A32: VMULL.S8 Qd, Dn+1, Dm+1; A64: SMULL2 Vd.8H, Vn.16B, Vm.16B
            // MultiplyWideningUpper(Vector128<UInt16>, Vector128<UInt16>)	uint32x4_t vmull_high_u16 (uint16x8_t a, uint16x8_t b); A32: VMULL.U16 Qd, Dn+1, Dm+1; A64: UMULL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyWideningUpper(Vector128<UInt32>, Vector128<UInt32>)	uint64x2_t vmull_high_u32 (uint32x4_t a, uint32x4_t b); A32: VMULL.U32 Qd, Dn+1, Dm+1; A64: UMULL2 Vd.2D, Vn.4S, Vm.4S
            // MultiplyWideningUpperAndAdd(Vector128<Int16>, Vector128<SByte>, Vector128<SByte>)	int16x8_t vmlal_high_s8 (int16x8_t a, int8x16_t b, int8x16_t c); A32: VMLAL.S8 Qd, Dn+1, Dm+1; A64: SMLAL2 Vd.8H, Vn.16B, Vm.16B
            // MultiplyWideningUpperAndAdd(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>)	int32x4_t vmlal_high_s16 (int32x4_t a, int16x8_t b, int16x8_t c); A32: VMLAL.S16 Qd, Dn+1, Dm+1; A64: SMLAL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyWideningUpperAndAdd(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>)	int64x2_t vmlal_high_s32 (int64x2_t a, int32x4_t b, int32x4_t c); A32: VMLAL.S32 Qd, Dn+1, Dm+1; A64: SMLAL2 Vd.2D, Vn.4S, Vm.4S
            // MultiplyWideningUpperAndAdd(Vector128<UInt16>, Vector128<Byte>, Vector128<Byte>)	uint16x8_t vmlal_high_u8 (uint16x8_t a, uint8x16_t b, uint8x16_t c); A32: VMLAL.U8 Qd, Dn+1, Dm+1; A64: UMLAL2 Vd.8H, Vn.16B, Vm.16B
            // MultiplyWideningUpperAndAdd(Vector128<UInt32>, Vector128<UInt16>, Vector128<UInt16>)	uint32x4_t vmlal_high_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t c); A32: VMLAL.U16 Qd, Dn+1, Dm+1; A64: UMLAL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyWideningUpperAndAdd(Vector128<UInt64>, Vector128<UInt32>, Vector128<UInt32>)	uint64x2_t vmlal_high_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t c); A32: VMLAL.U32 Qd, Dn+1, Dm+1; A64: UMLAL2 Vd.2D, Vn.4S, Vm.4S
            // MultiplyWideningUpperAndSubtract(Vector128<Int16>, Vector128<SByte>, Vector128<SByte>)	int16x8_t vmlsl_high_s8 (int16x8_t a, int8x16_t b, int8x16_t c); A32: VMLSL.S8 Qd, Dn+1, Dm+1; A64: SMLSL2 Vd.8H, Vn.16B, Vm.16B
            // MultiplyWideningUpperAndSubtract(Vector128<Int32>, Vector128<Int16>, Vector128<Int16>)	int32x4_t vmlsl_high_s16 (int32x4_t a, int16x8_t b, int16x8_t c); A32: VMLSL.S16 Qd, Dn+1, Dm+1; A64: SMLSL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyWideningUpperAndSubtract(Vector128<Int64>, Vector128<Int32>, Vector128<Int32>)	int64x2_t vmlsl_high_s32 (int64x2_t a, int32x4_t b, int32x4_t c); A32: VMLSL.S32 Qd, Dn+1, Dm+1; A64: SMLSL2 Vd.2D, Vn.4S, Vm.4S
            // MultiplyWideningUpperAndSubtract(Vector128<UInt16>, Vector128<Byte>, Vector128<Byte>)	uint16x8_t vmlsl_high_u8 (uint16x8_t a, uint8x16_t b, uint8x16_t c); A32: VMLSL.U8 Qd, Dn+1, Dm+1; A64: UMLSL2 Vd.8H, Vn.16B, Vm.16B
            // MultiplyWideningUpperAndSubtract(Vector128<UInt32>, Vector128<UInt16>, Vector128<UInt16>)	uint32x4_t vmlsl_high_u16 (uint32x4_t a, uint16x8_t b, uint16x8_t c); A32: VMLSL.U16 Qd, Dn+1, Dm+1; A64: UMLSL2 Vd.4S, Vn.8H, Vm.8H
            // MultiplyWideningUpperAndSubtract(Vector128<UInt64>, Vector128<UInt32>, Vector128<UInt32>)	uint64x2_t vmlsl_high_u32 (uint64x2_t a, uint32x4_t b, uint32x4_t c); A32: VMLSL.U32 Qd, Dn+1, Dm+1; A64: UMLSL2 Vd.2D, Vn.4S, Vm.4S
        }
        public unsafe static void RunArm_AdvSimd_N(TextWriter writer, string indent) {
            // Negate(Vector128<Int16>)	int16x8_t vnegq_s16 (int16x8_t a); A32: VNEG.S16 Qd, Qm; A64: NEG Vd.8H, Vn.8H
            // Negate(Vector128<Int32>)	int32x4_t vnegq_s32 (int32x4_t a); A32: VNEG.S32 Qd, Qm; A64: NEG Vd.4S, Vn.4S
            // Negate(Vector128<SByte>)	int8x16_t vnegq_s8 (int8x16_t a); A32: VNEG.S8 Qd, Qm; A64: NEG Vd.16B, Vn.16B
            // Negate(Vector128<Single>)	float32x4_t vnegq_f32 (float32x4_t a); A32: VNEG.F32 Qd, Qm; A64: FNEG Vd.4S, Vn.4S
            // Negate(Vector64<Int16>)	int16x4_t vneg_s16 (int16x4_t a); A32: VNEG.S16 Dd, Dm; A64: NEG Vd.4H, Vn.4H
            // Negate(Vector64<Int32>)	int32x2_t vneg_s32 (int32x2_t a); A32: VNEG.S32 Dd, Dm; A64: NEG Vd.2S, Vn.2S
            // Negate(Vector64<SByte>)	int8x8_t vneg_s8 (int8x8_t a); A32: VNEG.S8 Dd, Dm; A64: NEG Vd.8B, Vn.8B
            // Negate(Vector64<Single>)	float32x2_t vneg_f32 (float32x2_t a); A32: VNEG.F32 Dd, Dm; A64: FNEG Vd.2S, Vn.2S
            // NegateSaturate(Vector128<Int16>)	int16x8_t vqnegq_s16 (int16x8_t a); A32: VQNEG.S16 Qd, Qm; A64: SQNEG Vd.8H, Vn.8H
            // NegateSaturate(Vector128<Int32>)	int32x4_t vqnegq_s32 (int32x4_t a); A32: VQNEG.S32 Qd, Qm; A64: SQNEG Vd.4S, Vn.4S
            // NegateSaturate(Vector128<SByte>)	int8x16_t vqnegq_s8 (int8x16_t a); A32: VQNEG.S8 Qd, Qm; A64: SQNEG Vd.16B, Vn.16B
            // NegateSaturate(Vector64<Int16>)	int16x4_t vqneg_s16 (int16x4_t a); A32: VQNEG.S16 Dd, Dm; A64: SQNEG Vd.4H, Vn.4H
            // NegateSaturate(Vector64<Int32>)	int32x2_t vqneg_s32 (int32x2_t a); A32: VQNEG.S32 Dd, Dm; A64: SQNEG Vd.2S, Vn.2S
            // NegateSaturate(Vector64<SByte>)	int8x8_t vqneg_s8 (int8x8_t a); A32: VQNEG.S8 Dd, Dm; A64: SQNEG Vd.8B, Vn.8B
            // NegateScalar(Vector64<Double>)	float64x1_t vneg_f64 (float64x1_t a); A32: VNEG.F64 Dd, Dm; A64: FNEG Dd, Dn
            // NegateScalar(Vector64<Single>)	float32_t vnegs_f32 (float32_t a); A32: VNEG.F32 Sd, Sm; A64: FNEG Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Not(Vector128<Byte>)	uint8x16_t vmvnq_u8 (uint8x16_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B
            // Not(Vector128<Double>)	float64x2_t vmvnq_f64 (float64x2_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Not(Vector128<Int16>)	int16x8_t vmvnq_s16 (int16x8_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B
            // Not(Vector128<Int32>)	int32x4_t vmvnq_s32 (int32x4_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B
            // Not(Vector128<Int64>)	int64x2_t vmvnq_s64 (int64x2_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B
            // Not(Vector128<SByte>)	int8x16_t vmvnq_s8 (int8x16_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B
            // Not(Vector128<Single>)	float32x4_t vmvnq_f32 (float32x4_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Not(Vector128<UInt16>)	uint16x8_t vmvnq_u16 (uint16x8_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B
            // Not(Vector128<UInt32>)	uint32x4_t vmvnq_u32 (uint32x4_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B
            // Not(Vector128<UInt64>)	uint64x2_t vmvnq_u64 (uint64x2_t a); A32: VMVN Qd, Qm; A64: MVN Vd.16B, Vn.16B
            // Not(Vector64<Byte>)	uint8x8_t vmvn_u8 (uint8x8_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B
            // Not(Vector64<Double>)	float64x1_t vmvn_f64 (float64x1_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Not(Vector64<Int16>)	int16x4_t vmvn_s16 (int16x4_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B
            // Not(Vector64<Int32>)	int32x2_t vmvn_s32 (int32x2_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B
            // Not(Vector64<Int64>)	int64x1_t vmvn_s64 (int64x1_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B
            // Not(Vector64<SByte>)	int8x8_t vmvn_s8 (int8x8_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B
            // Not(Vector64<Single>)	float32x2_t vmvn_f32 (float32x2_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Not(Vector64<UInt16>)	uint16x4_t vmvn_u16 (uint16x4_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B
            // Not(Vector64<UInt32>)	uint32x2_t vmvn_u32 (uint32x2_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B
            // Not(Vector64<UInt64>)	uint64x1_t vmvn_u64 (uint64x1_t a); A32: VMVN Dd, Dm; A64: MVN Vd.8B, Vn.8B
        }
        public unsafe static void RunArm_AdvSimd_O(TextWriter writer, string indent) {
            // Or(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vorrq_u8 (uint8x16_t a, uint8x16_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B
            // Or(Vector128<Double>, Vector128<Double>)	float64x2_t vorrq_f64 (float64x2_t a, float64x2_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Or(Vector128<Int16>, Vector128<Int16>)	int16x8_t vorrq_s16 (int16x8_t a, int16x8_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B
            // Or(Vector128<Int32>, Vector128<Int32>)	int32x4_t vorrq_s32 (int32x4_t a, int32x4_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B
            // Or(Vector128<Int64>, Vector128<Int64>)	int64x2_t vorrq_s64 (int64x2_t a, int64x2_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B
            // Or(Vector128<SByte>, Vector128<SByte>)	int8x16_t vorrq_s8 (int8x16_t a, int8x16_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B
            // Or(Vector128<Single>, Vector128<Single>)	float32x4_t vorrq_f32 (float32x4_t a, float32x4_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Or(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vorrq_u16 (uint16x8_t a, uint16x8_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B
            // Or(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vorrq_u32 (uint32x4_t a, uint32x4_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B
            // Or(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vorrq_u64 (uint64x2_t a, uint64x2_t b); A32: VORR Qd, Qn, Qm; A64: ORR Vd.16B, Vn.16B, Vm.16B
            // Or(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vorr_u8 (uint8x8_t a, uint8x8_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B
            // Or(Vector64<Double>, Vector64<Double>)	float64x1_t vorr_f64 (float64x1_t a, float64x1_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Or(Vector64<Int16>, Vector64<Int16>)	int16x4_t vorr_s16 (int16x4_t a, int16x4_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B
            // Or(Vector64<Int32>, Vector64<Int32>)	int32x2_t vorr_s32 (int32x2_t a, int32x2_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B
            // Or(Vector64<Int64>, Vector64<Int64>)	int64x1_t vorr_s64 (int64x1_t a, int64x1_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B
            // Or(Vector64<SByte>, Vector64<SByte>)	int8x8_t vorr_s8 (int8x8_t a, int8x8_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B
            // Or(Vector64<Single>, Vector64<Single>)	float32x2_t vorr_f32 (float32x2_t a, float32x2_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Or(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vorr_u16 (uint16x4_t a, uint16x4_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B
            // Or(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vorr_u32 (uint32x2_t a, uint32x2_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B
            // Or(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vorr_u64 (uint64x1_t a, uint64x1_t b); A32: VORR Dd, Dn, Dm; A64: ORR Vd.8B, Vn.8B, Vm.8B
            // OrNot(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vornq_u8 (uint8x16_t a, uint8x16_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B
            // OrNot(Vector128<Double>, Vector128<Double>)	float64x2_t vornq_f64 (float64x2_t a, float64x2_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // OrNot(Vector128<Int16>, Vector128<Int16>)	int16x8_t vornq_s16 (int16x8_t a, int16x8_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B
            // OrNot(Vector128<Int32>, Vector128<Int32>)	int32x4_t vornq_s32 (int32x4_t a, int32x4_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B
            // OrNot(Vector128<Int64>, Vector128<Int64>)	int64x2_t vornq_s64 (int64x2_t a, int64x2_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B
            // OrNot(Vector128<SByte>, Vector128<SByte>)	int8x16_t vornq_s8 (int8x16_t a, int8x16_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B
            // OrNot(Vector128<Single>, Vector128<Single>)	float32x4_t vornq_f32 (float32x4_t a, float32x4_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // OrNot(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vornq_u16 (uint16x8_t a, uint16x8_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B
            // OrNot(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vornq_u32 (uint32x4_t a, uint32x4_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B
            // OrNot(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vornq_u64 (uint64x2_t a, uint64x2_t b); A32: VORN Qd, Qn, Qm; A64: ORN Vd.16B, Vn.16B, Vm.16B
            // OrNot(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vorn_u8 (uint8x8_t a, uint8x8_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B
            // OrNot(Vector64<Double>, Vector64<Double>)	float64x1_t vorn_f64 (float64x1_t a, float64x1_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // OrNot(Vector64<Int16>, Vector64<Int16>)	int16x4_t vorn_s16 (int16x4_t a, int16x4_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B
            // OrNot(Vector64<Int32>, Vector64<Int32>)	int32x2_t vorn_s32 (int32x2_t a, int32x2_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B
            // OrNot(Vector64<Int64>, Vector64<Int64>)	int64x1_t vorn_s64 (int64x1_t a, int64x1_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B
            // OrNot(Vector64<SByte>, Vector64<SByte>)	int8x8_t vorn_s8 (int8x8_t a, int8x8_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B
            // OrNot(Vector64<Single>, Vector64<Single>)	float32x2_t vorn_f32 (float32x2_t a, float32x2_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // OrNot(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vorn_u16 (uint16x4_t a, uint16x4_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B
            // OrNot(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vorn_u32 (uint32x2_t a, uint32x2_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B
            // OrNot(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vorn_u64 (uint64x1_t a, uint64x1_t b); A32: VORN Dd, Dn, Dm; A64: ORN Vd.8B, Vn.8B, Vm.8B
        }
        public unsafe static void RunArm_AdvSimd_P(TextWriter writer, string indent) {
            // PolynomialMultiply(Vector128<Byte>, Vector128<Byte>)	poly8x16_t vmulq_p8 (poly8x16_t a, poly8x16_t b); A32: VMUL.P8 Qd, Qn, Qm; A64: PMUL Vd.16B, Vn.16B, Vm.16B
            // PolynomialMultiply(Vector128<SByte>, Vector128<SByte>)	poly8x16_t vmulq_p8 (poly8x16_t a, poly8x16_t b); A32: VMUL.P8 Qd, Qn, Qm; A64: PMUL Vd.16B, Vn.16B, Vm.16B
            // PolynomialMultiply(Vector64<Byte>, Vector64<Byte>)	poly8x8_t vmul_p8 (poly8x8_t a, poly8x8_t b); A32: VMUL.P8 Dd, Dn, Dm; A64: PMUL Vd.8B, Vn.8B, Vm.8B
            // PolynomialMultiply(Vector64<SByte>, Vector64<SByte>)	poly8x8_t vmul_p8 (poly8x8_t a, poly8x8_t b); A32: VMUL.P8 Dd, Dn, Dm; A64: PMUL Vd.8B, Vn.8B, Vm.8B
            // PolynomialMultiplyWideningLower(Vector64<Byte>, Vector64<Byte>)	poly16x8_t vmull_p8 (poly8x8_t a, poly8x8_t b); A32: VMULL.P8 Qd, Dn, Dm; A64: PMULL Vd.16B, Vn.8B, Vm.8B
            // PolynomialMultiplyWideningLower(Vector64<SByte>, Vector64<SByte>)	poly16x8_t vmull_p8 (poly8x8_t a, poly8x8_t b); A32: VMULL.P8 Qd, Dn, Dm; A64: PMULL Vd.16B, Vn.8B, Vm.8B
            // PolynomialMultiplyWideningUpper(Vector128<Byte>, Vector128<Byte>)	poly16x8_t vmull_high_p8 (poly8x16_t a, poly8x16_t b); A32: VMULL.P8 Qd, Dn+1, Dm+1; A64: PMULL2 Vd.16B, Vn.16B, Vm.16B
            // PolynomialMultiplyWideningUpper(Vector128<SByte>, Vector128<SByte>)	poly16x8_t vmull_high_p8 (poly8x16_t a, poly8x16_t b); A32: VMULL.P8 Qd, Dn+1, Dm+1; A64: PMULL2 Vd.16B, Vn.16B, Vm.16B
            // PopCount(Vector128<Byte>)	uint8x16_t vcntq_u8 (uint8x16_t a); A32: VCNT.I8 Qd, Qm; A64: CNT Vd.16B, Vn.16B
            // PopCount(Vector128<SByte>)	int8x16_t vcntq_s8 (int8x16_t a); A32: VCNT.I8 Qd, Qm; A64: CNT Vd.16B, Vn.16B
            // PopCount(Vector64<Byte>)	uint8x8_t vcnt_u8 (uint8x8_t a); A32: VCNT.I8 Dd, Dm; A64: CNT Vd.8B, Vn.8B
            // PopCount(Vector64<SByte>)	int8x8_t vcnt_s8 (int8x8_t a); A32: VCNT.I8 Dd, Dm; A64: CNT Vd.8B, Vn.8B
        }
        public unsafe static void RunArm_AdvSimd_R(TextWriter writer, string indent) {
            // ReciprocalEstimate(Vector128<Single>)	float32x4_t vrecpeq_f32 (float32x4_t a); A32: VRECPE.F32 Qd, Qm; A64: FRECPE Vd.4S, Vn.4S
            // ReciprocalEstimate(Vector128<UInt32>)	uint32x4_t vrecpeq_u32 (uint32x4_t a); A32: VRECPE.U32 Qd, Qm; A64: URECPE Vd.4S, Vn.4S
            // ReciprocalEstimate(Vector64<Single>)	float32x2_t vrecpe_f32 (float32x2_t a); A32: VRECPE.F32 Dd, Dm; A64: FRECPE Vd.2S, Vn.2S
            // ReciprocalEstimate(Vector64<UInt32>)	uint32x2_t vrecpe_u32 (uint32x2_t a); A32: VRECPE.U32 Dd, Dm; A64: URECPE Vd.2S, Vn.2S
            // ReciprocalSquareRootEstimate(Vector128<Single>)	float32x4_t vrsqrteq_f32 (float32x4_t a); A32: VRSQRTE.F32 Qd, Qm; A64: FRSQRTE Vd.4S, Vn.4S
            // ReciprocalSquareRootEstimate(Vector128<UInt32>)	uint32x4_t vrsqrteq_u32 (uint32x4_t a); A32: VRSQRTE.U32 Qd, Qm; A64: URSQRTE Vd.4S, Vn.4S
            // ReciprocalSquareRootEstimate(Vector64<Single>)	float32x2_t vrsqrte_f32 (float32x2_t a); A32: VRSQRTE.F32 Dd, Dm; A64: FRSQRTE Vd.2S, Vn.2S
            // ReciprocalSquareRootEstimate(Vector64<UInt32>)	uint32x2_t vrsqrte_u32 (uint32x2_t a); A32: VRSQRTE.U32 Dd, Dm; A64: URSQRTE Vd.2S, Vn.2S
            // ReciprocalSquareRootStep(Vector128<Single>, Vector128<Single>)	float32x4_t vrsqrtsq_f32 (float32x4_t a, float32x4_t b); A32: VRSQRTS.F32 Qd, Qn, Qm; A64: FRSQRTS Vd.4S, Vn.4S, Vm.4S
            // ReciprocalSquareRootStep(Vector64<Single>, Vector64<Single>)	float32x2_t vrsqrts_f32 (float32x2_t a, float32x2_t b); A32: VRSQRTS.F32 Dd, Dn, Dm; A64: FRSQRTS Vd.2S, Vn.2S, Vm.2S
            // ReciprocalStep(Vector128<Single>, Vector128<Single>)	float32x4_t vrecpsq_f32 (float32x4_t a, float32x4_t b); A32: VRECPS.F32 Qd, Qn, Qm; A64: FRECPS Vd.4S, Vn.4S, Vm.4S
            // ReciprocalStep(Vector64<Single>, Vector64<Single>)	float32x2_t vrecps_f32 (float32x2_t a, float32x2_t b); A32: VRECPS.F32 Dd, Dn, Dm; A64: FRECPS Vd.2S, Vn.2S, Vm.2S
            // ReverseElement16(Vector128<Int32>)	int16x8_t vrev32q_s16 (int16x8_t vec) A32: VREV32.16 Qd, Qm A64: REV32 Vd.8H, Vn.8H
            // ReverseElement16(Vector128<Int64>)	int16x8_t vrev64q_s16 (int16x8_t vec) A32: VREV64.16 Qd, Qm A64: REV64 Vd.8H, Vn.8H
            // ReverseElement16(Vector128<UInt32>)	uint16x8_t vrev32q_u16 (uint16x8_t vec) A32: VREV32.16 Qd, Qm A64: REV32 Vd.8H, Vn.8H
            // ReverseElement16(Vector128<UInt64>)	uint16x8_t vrev64q_u16 (uint16x8_t vec) A32: VREV64.16 Qd, Qm A64: REV64 Vd.8H, Vn.8H
            // ReverseElement16(Vector64<Int32>)	int16x4_t vrev32_s16 (int16x4_t vec) A32: VREV32.16 Dd, Dm A64: REV32 Vd.4H, Vn.4H
            // ReverseElement16(Vector64<Int64>)	int16x4_t vrev64_s16 (int16x4_t vec) A32: VREV64.16 Dd, Dm A64: REV64 Vd.4H, Vn.4H
            // ReverseElement16(Vector64<UInt32>)	uint16x4_t vrev32_u16 (uint16x4_t vec) A32: VREV32.16 Dd, Dm A64: REV32 Vd.4H, Vn.4H
            // ReverseElement16(Vector64<UInt64>)	uint16x4_t vrev64_u16 (uint16x4_t vec) A32: VREV64.16 Dd, Dm A64: REV64 Vd.4H, Vn.4H
            // ReverseElement32(Vector128<Int64>)	int32x4_t vrev64q_s32 (int32x4_t vec) A32: VREV64.32 Qd, Qm A64: REV64 Vd.4S, Vn.4S
            // ReverseElement32(Vector128<UInt64>)	uint32x4_t vrev64q_u32 (uint32x4_t vec) A32: VREV64.32 Qd, Qm A64: REV64 Vd.4S, Vn.4S
            // ReverseElement32(Vector64<Int64>)	int32x2_t vrev64_s32 (int32x2_t vec) A32: VREV64.32 Dd, Dm A64: REV64 Vd.2S, Vn.2S
            // ReverseElement32(Vector64<UInt64>)	uint32x2_t vrev64_u32 (uint32x2_t vec) A32: VREV64.32 Dd, Dm A64: REV64 Vd.2S, Vn.2S
            // ReverseElement8(Vector128<Int16>)	int8x16_t vrev16q_s8 (int8x16_t vec) A32: VREV16.8 Qd, Qm A64: REV16 Vd.16B, Vn.16B
            // ReverseElement8(Vector128<Int32>)	int8x16_t vrev32q_s8 (int8x16_t vec) A32: VREV32.8 Qd, Qm A64: REV32 Vd.16B, Vn.16B
            // ReverseElement8(Vector128<Int64>)	int8x16_t vrev64q_s8 (int8x16_t vec) A32: VREV64.8 Qd, Qm A64: REV64 Vd.16B, Vn.16B
            // ReverseElement8(Vector128<UInt16>)	uint8x16_t vrev16q_u8 (uint8x16_t vec) A32: VREV16.8 Qd, Qm A64: REV16 Vd.16B, Vn.16B
            // ReverseElement8(Vector128<UInt32>)	uint8x16_t vrev32q_u8 (uint8x16_t vec) A32: VREV32.8 Qd, Qm A64: REV32 Vd.16B, Vn.16B
            // ReverseElement8(Vector128<UInt64>)	uint8x16_t vrev64q_u8 (uint8x16_t vec) A32: VREV64.8 Qd, Qm A64: REV64 Vd.16B, Vn.16B
            // ReverseElement8(Vector64<Int16>)	int8x8_t vrev16_s8 (int8x8_t vec) A32: VREV16.8 Dd, Dm A64: REV16 Vd.8B, Vn.8B
            // ReverseElement8(Vector64<Int32>)	int8x8_t vrev32_s8 (int8x8_t vec) A32: VREV32.8 Dd, Dm A64: REV32 Vd.8B, Vn.8B
            // ReverseElement8(Vector64<Int64>)	int8x8_t vrev64_s8 (int8x8_t vec) A32: VREV64.8 Dd, Dm A64: REV64 Vd.8B, Vn.8B
            // ReverseElement8(Vector64<UInt16>)	uint8x8_t vrev16_u8 (uint8x8_t vec) A32: VREV16.8 Dd, Dm A64: REV16 Vd.8B, Vn.8B
            // ReverseElement8(Vector64<UInt32>)	uint8x8_t vrev32_u8 (uint8x8_t vec) A32: VREV32.8 Dd, Dm A64: REV32 Vd.8B, Vn.8B
            // ReverseElement8(Vector64<UInt64>)	uint8x8_t vrev64_u8 (uint8x8_t vec) A32: VREV64.8 Dd, Dm A64: REV64 Vd.8B, Vn.8B
            // RoundAwayFromZero(Vector128<Single>)	float32x4_t vrndaq_f32 (float32x4_t a); A32: VRINTA.F32 Qd, Qm; A64: FRINTA Vd.4S, Vn.4S
            // RoundAwayFromZero(Vector64<Single>)	float32x2_t vrnda_f32 (float32x2_t a); A32: VRINTA.F32 Dd, Dm; A64: FRINTA Vd.2S, Vn.2S
            // RoundAwayFromZeroScalar(Vector64<Double>)	float64x1_t vrnda_f64 (float64x1_t a); A32: VRINTA.F64 Dd, Dm; A64: FRINTA Dd, Dn
            // RoundAwayFromZeroScalar(Vector64<Single>)	float32_t vrndas_f32 (float32_t a); A32: VRINTA.F32 Sd, Sm; A64: FRINTA Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // RoundToNearest(Vector128<Single>)	float32x4_t vrndnq_f32 (float32x4_t a); A32: VRINTN.F32 Qd, Qm; A64: FRINTN Vd.4S, Vn.4S
            // RoundToNearest(Vector64<Single>)	float32x2_t vrndn_f32 (float32x2_t a); A32: VRINTN.F32 Dd, Dm; A64: FRINTN Vd.2S, Vn.2S
            // RoundToNearestScalar(Vector64<Double>)	float64x1_t vrndn_f64 (float64x1_t a); A32: VRINTN.F64 Dd, Dm; A64: FRINTN Dd, Dn
            // RoundToNearestScalar(Vector64<Single>)	float32_t vrndns_f32 (float32_t a); A32: VRINTN.F32 Sd, Sm; A64: FRINTN Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // RoundToNegativeInfinity(Vector128<Single>)	float32x4_t vrndmq_f32 (float32x4_t a); A32: VRINTM.F32 Qd, Qm; A64: FRINTM Vd.4S, Vn.4S
            // RoundToNegativeInfinity(Vector64<Single>)	float32x2_t vrndm_f32 (float32x2_t a); A32: VRINTM.F32 Dd, Dm; A64: FRINTM Vd.2S, Vn.2S
            // RoundToNegativeInfinityScalar(Vector64<Double>)	float64x1_t vrndm_f64 (float64x1_t a); A32: VRINTM.F64 Dd, Dm; A64: FRINTM Dd, Dn
            // RoundToNegativeInfinityScalar(Vector64<Single>)	float32_t vrndms_f32 (float32_t a); A32: VRINTM.F32 Sd, Sm; A64: FRINTM Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // RoundToPositiveInfinity(Vector128<Single>)	float32x4_t vrndpq_f32 (float32x4_t a); A32: VRINTP.F32 Qd, Qm; A64: FRINTP Vd.4S, Vn.4S
            // RoundToPositiveInfinity(Vector64<Single>)	float32x2_t vrndp_f32 (float32x2_t a); A32: VRINTP.F32 Dd, Dm; A64: FRINTP Vd.2S, Vn.2S
            // RoundToPositiveInfinityScalar(Vector64<Double>)	float64x1_t vrndp_f64 (float64x1_t a); A32: VRINTP.F64 Dd, Dm; A64: FRINTP Dd, Dn
            // RoundToPositiveInfinityScalar(Vector64<Single>)	float32_t vrndps_f32 (float32_t a); A32: VRINTP.F32 Sd, Sm; A64: FRINTP Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // RoundToZero(Vector128<Single>)	float32x4_t vrndq_f32 (float32x4_t a); A32: VRINTZ.F32 Qd, Qm; A64: FRINTZ Vd.4S, Vn.4S
            // RoundToZero(Vector64<Single>)	float32x2_t vrnd_f32 (float32x2_t a); A32: VRINTZ.F32 Dd, Dm; A64: FRINTZ Vd.2S, Vn.2S
            // RoundToZeroScalar(Vector64<Double>)	float64x1_t vrnd_f64 (float64x1_t a); A32: VRINTZ.F64 Dd, Dm; A64: FRINTZ Dd, Dn
            // RoundToZeroScalar(Vector64<Single>)	float32_t vrnds_f32 (float32_t a); A32: VRINTZ.F32 Sd, Sm; A64: FRINTZ Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
        }
        public unsafe static void RunArm_AdvSimd_S(TextWriter writer, string indent) {
            string indentNext = indent + IndentNextSeparator;
            unchecked {
                // Mnemonic: `rt[i] := (count[i]>=0)?(value[i] << count[i]):(value[i] >> -count[i])`, `>>` is mean `floor(value[i] / pow(2,-count[i]))`. If the shift amount is out of range when shifting left, the result is 0. If the shift amount is out of range when shifting right, the result is 0/-1 .
                // 1、Vector shift left: vshl -> ri = ai << bi; (negative values shift right) 
                // left shifts each element in a vector by an amount specified in the corresponding element in the second input vector. The shift amount is the signed integer value of the least significant byte of the element in the second input vector. The bits shifted out of each element are lost.If the signed integer value is negative, it results in a right shift
                // 将一个向量中的每个元素左移一个在第二个输入向量中的相应元素中指定的量。移位量是第二个输入向量中元素的最低有效字节的有符号整数值。从每个元素移出的比特都丢失了。如果有符号整数值为负，则会导致右移
                // https://developer.arm.com/architectures/instruction-sets/intrinsics/vshl_s8
                // for e = 0 to elements-1
                //     shift = SInt(Elem[operand2, e, esize]<7:0>);
                //     if rounding then
                //         round_const = 1 << (-shift - 1); // 0 for left shift, 2^(n-1) for right shift 
                //     element = (Int(Elem[operand1, e, esize], unsigned) + round_const) << shift;
                //     if saturating then
                //         (Elem[result, e, esize], sat) = SatQ(element, esize, unsigned);
                //         if sat then FPSR.QC = '1';
                //     else
                //         Elem[result, e, esize] = element<esize-1:0>;
                // 
                // ShiftArithmetic(Vector128<Int16>, Vector128<Int16>)	int16x8_t vshlq_s16 (int16x8_t a, int16x8_t b); A32: VSHL.S16 Qd, Qn, Qm; A64: SSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftArithmetic(Vector128<Int32>, Vector128<Int32>)	int32x4_t vshlq_s32 (int32x4_t a, int32x4_t b); A32: VSHL.S32 Qd, Qn, Qm; A64: SSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftArithmetic(Vector128<Int64>, Vector128<Int64>)	int64x2_t vshlq_s64 (int64x2_t a, int64x2_t b); A32: VSHL.S64 Qd, Qn, Qm; A64: SSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftArithmetic(Vector128<SByte>, Vector128<SByte>)	int8x16_t vshlq_s8 (int8x16_t a, int8x16_t b); A32: VSHL.S8 Qd, Qn, Qm; A64: SSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftArithmetic(Vector64<Int16>, Vector64<Int16>)	int16x4_t vshl_s16 (int16x4_t a, int16x4_t b); A32: VSHL.S16 Dd, Dn, Dm; A64: SSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftArithmetic(Vector64<Int32>, Vector64<Int32>)	int32x2_t vshl_s32 (int32x2_t a, int32x2_t b); A32: VSHL.S32 Dd, Dn, Dm; A64: SSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftArithmetic(Vector64<SByte>, Vector64<SByte>)	int8x8_t vshl_s8 (int8x8_t a, int8x8_t b); A32: VSHL.S8 Dd, Dn, Dm; A64: SSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftArithmeticScalar(Vector64<Int64>, Vector64<Int64>)	int64x1_t vshl_s64 (int64x1_t a, int64x1_t b); A32: VSHL.S64 Dd, Dn, Dm; A64: SSHL Dd, Dn, Dm
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftArithmetic<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmetic(demo, serial):\t{0}", AdvSimd.ShiftArithmetic(demo, vcount));
                    }
                    if (true) {
                        Vector128<short> demo = Vector128.Create((short)elementNegative);
                        Vector128<short> vcount = Vector128.Create((short)15, 14, 1, 0, -1, -14, -15, -16);
                        WriteLine(writer, indent, "ShiftArithmetic<short>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmetic(demo, serial):\t{0}", AdvSimd.ShiftArithmetic(demo, vcount));
                    }
                    if (true) {
                        Vector128<int> demo = Vector128.Create((int)elementNegative);
                        Vector128<int> vcount = Vector128.Create((int)31, 30, -31, -32);
                        WriteLine(writer, indent, "ShiftArithmetic<int>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmetic(demo, serial):\t{0}", AdvSimd.ShiftArithmetic(demo, vcount));
                    }
                    if (true) {
                        Vector128<long> demo = Vector128.Create((long)elementNegative);
                        Vector128<long> vcount = Vector128.Create((long)63, -63);
                        WriteLine(writer, indent, "ShiftArithmetic<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmetic(demo, serial):\t{0}", AdvSimd.ShiftArithmetic(demo, vcount));
                        vcount = Vector128.Create((long)63, -64);
                        WriteLine(writer, indent, "ShiftArithmetic<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmetic(demo, serial):\t{0}", AdvSimd.ShiftArithmetic(demo, vcount));
                    }
                    if (true) {
                        // Try to go out of range.
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftArithmetic<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmetic(demo, serial):\t{0}", AdvSimd.ShiftArithmetic(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9);
                        WriteLine(writer, indent, "ShiftArithmetic<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmetic(demo, serial):\t{0}", AdvSimd.ShiftArithmetic(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9);
                        WriteLine(writer, indent, "ShiftArithmetic<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmetic(demo, serial):\t{0}", AdvSimd.ShiftArithmetic(demo, vcount));
                        // -- 发现 Arm支持变量值超出范围，且符合逻辑。左移超出范围时会变0，算术右移超出范围时会变“全符号位”（0或-1。因为“对负数做足够多次算术右移”时会变为-1）。
                        // ShiftArithmetic<sbyte>, demo=<-3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3>, vcount=<8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8>	# (FD FD FD FD FD FD FD FD FD FD FD FD FD FD FD FD), (08 07 06 05 03 02 01 00 FF FE FD FC FB FA F9 F8)
                        // 	ShiftArithmetic(demo, serial):	<0, -128, 64, -96, -24, -12, -6, -3, -2, -1, -1, -1, -1, -1, -1, -1>	# (00 80 40 A0 E8 F4 FA FD FE FF FF FF FF FF FF FF)
                        // ShiftArithmetic<sbyte>, demo=<-3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3>, vcount=<8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9>	# (FD FD FD FD FD FD FD FD FD FD FD FD FD FD FD FD), (08 07 06 05 03 02 01 00 FF FE FD FB FA F9 F8 F7)
                        // 	ShiftArithmetic(demo, serial):	<0, -128, 64, -96, -24, -12, -6, -3, -2, -1, -1, -1, -1, -1, -1, -1>	# (00 80 40 A0 E8 F4 FA FD FE FF FF FF FF FF FF FF)
                        // ShiftArithmetic<sbyte>, demo=<-3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3, -3>, vcount=<8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9>	# (FD FD FD FD FD FD FD FD FD FD FD FD FD FD FD FD), (08 07 10 0F 03 02 01 00 FF FE FD FB F0 EF F8 F7)
                        // 	ShiftArithmetic(demo, serial):	<0, -128, 0, 0, -24, -12, -6, -3, -2, -1, -1, -1, -1, -1, -1, -1>	# (00 80 00 00 E8 F4 FA FD FE FF FF FF FF FF FF FF)
                        // -- X86的变量算术右移也是支持超出范围的。但它的移位参数必须为无符号数，无法反向移位。且Avx2仅支持32位元素，Avx512才支持16、64位元素。
                        // ShiftRightArithmeticVariable(Vector128<Int32>, Vector128<UInt32>)	
                        // __m128i _mm_srav_epi32 (__m128i a, __m128i count)
                        // VPSRAVD xmm, xmm, xmm/m128
                        // https://www.intel.com/content/www/us/en/docs/intrinsics-guide/index.html
                        // IF count[i+31:i] < 32
                        // 	dst[i+31:i] := SignExtend32(a[i+31:i] >> count[i+31:i])
                        // ELSE
                        // 	dst[i+31:i] := (a[i+31] ? 0xFFFFFFFF : 0)
                        // FI
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // Mnemonic: `rt[i] := (count[i]>=0)?(value[i] << count[i]):(value[i] >> -count[i])`, `>>` is mean `round(value[i] / pow(2,-count[i])) = intDiv(value[i], pow(2,-count[i])) = (value[i] + (1 << (-count[i] - 1))) >> -count[i]`. If the shift amount is out of range when shifting left, the result is 0. If the shift amount is out of range when shifting right, the result is 0 .
                // 3、Vector rounding shift left(饱和指令):  
                // vrshl -> ri = ai << bi;(negative values shift right) 
                // If the shift value is positive, the operation is a left shift. Otherwise, it is a rounding right shift. left shifts each element in a vector of integers and places the results in the destination vector. It is similar to VSHL.  
                // The difference is that the shifted value is then rounded.
                // 如果shift值为正，则操作为左移。否则，它是一个舍入右移。左移整数向量中的每个元素，并将结果放在目标向量中。它类似于VSHL。
                // 不同之处在于移位后的值被四舍五入。
                // ShiftArithmeticRounded(Vector128<Int16>, Vector128<Int16>)	int16x8_t vrshlq_s16 (int16x8_t a, int16x8_t b); A32: VRSHL.S16 Qd, Qn, Qm; A64: SRSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftArithmeticRounded(Vector128<Int32>, Vector128<Int32>)	int32x4_t vrshlq_s32 (int32x4_t a, int32x4_t b); A32: VRSHL.S32 Qd, Qn, Qm; A64: SRSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftArithmeticRounded(Vector128<Int64>, Vector128<Int64>)	int64x2_t vrshlq_s64 (int64x2_t a, int64x2_t b); A32: VRSHL.S64 Qd, Qn, Qm; A64: SRSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftArithmeticRounded(Vector128<SByte>, Vector128<SByte>)	int8x16_t vrshlq_s8 (int8x16_t a, int8x16_t b); A32: VRSHL.S8 Qd, Qn, Qm; A64: SRSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftArithmeticRounded(Vector64<Int16>, Vector64<Int16>)	int16x4_t vrshl_s16 (int16x4_t a, int16x4_t b); A32: VRSHL.S16 Dd, Dn, Dm; A64: SRSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftArithmeticRounded(Vector64<Int32>, Vector64<Int32>)	int32x2_t vrshl_s32 (int32x2_t a, int32x2_t b); A32: VRSHL.S32 Dd, Dn, Dm; A64: SRSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftArithmeticRounded(Vector64<SByte>, Vector64<SByte>)	int8x8_t vrshl_s8 (int8x8_t a, int8x8_t b); A32: VRSHL.S8 Dd, Dn, Dm; A64: SRSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftArithmeticRoundedScalar(Vector64<Int64>, Vector64<Int64>)	int64x1_t vrshl_s64 (int64x1_t a, int64x1_t b); A32: VRSHL.S64 Dd, Dn, Dm; A64: SRSHL Dd, Dn, Dm
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftArithmeticRounded<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRounded(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRounded(demo, vcount));
                    }
                    if (true) {
                        Vector128<short> demo = Vector128.Create((short)elementNegative);
                        Vector128<short> vcount = Vector128.Create((short)15, 14, 1, 0, -1, -14, -15, -16);
                        WriteLine(writer, indent, "ShiftArithmeticRounded<short>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRounded(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRounded(demo, vcount));
                    }
                    if (true) {
                        Vector128<int> demo = Vector128.Create((int)elementNegative);
                        Vector128<int> vcount = Vector128.Create((int)31, 30, -31, -32);
                        WriteLine(writer, indent, "ShiftArithmeticRounded<int>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRounded(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRounded(demo, vcount));
                    }
                    if (true) {
                        Vector128<long> demo = Vector128.Create((long)elementNegative);
                        Vector128<long> vcount = Vector128.Create((long)63, -63);
                        WriteLine(writer, indent, "ShiftArithmeticRounded<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRounded(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRounded(demo, vcount));
                        vcount = Vector128.Create((long)63, -64);
                        WriteLine(writer, indent, "ShiftArithmeticRounded<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRounded(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRounded(demo, vcount));
                    }
                    if (true) {
                        // Try to go out of range.
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftArithmeticRounded<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRounded(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRounded(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9);
                        WriteLine(writer, indent, "ShiftArithmeticRounded<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRounded(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRounded(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9);
                        WriteLine(writer, indent, "ShiftArithmeticRounded<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRounded(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRounded(demo, vcount));
                        // ShiftArithmetic(demo, serial):	
                        // <-128, 64, -96, -48, 104, -76, -38, -19, -10, -5, -3, -2, -1, -1, -1, -1>	# (80 40 A0 D0 68 B4 DA ED F6 FB FD FE FF FF FF FF)
                        // ShiftArithmeticRounded(demo, serial):
                        // <-128, 64, -96, -48, 104, -76, -38, -19, -9, -5, -2, -1, -1, 0, 0, 0>	# (80 40 A0 D0 68 B4 DA ED F7 FB FE FF FF 00 00 00)
                        // f(e, shift)= (e + (1 << (-shift - 1))) << shift
                        // f(-19, -1) = (-19 + (1 << (-(-1) - 1))) << (-1) = (-19 + (1 << 0)) >> 1 = (-19 + 1) >> 1 = -18 >> 1 = -9
                        // f(-19, -2) = (-19 + (1 << (-(-2) - 1))) << (-2) = (-19 + (1 << 1)) >> 2 = (-19 + 2) >> 2 = -17 >> 2 = floor(-4.25) = -5
                        // f(-19, -3) = (-19 + (1 << (-(-3) - 1))) << (-3) = (-19 + (1 << 2)) >> 3 = (-19 + 4) >> 3 = -15 >> 3 = floor(-1.875) = -2
                        // f(-19, -4) = (-19 + (1 << (-(-4) - 1))) << (-4) = (-19 + (1 << 3)) >> 4 = (-19 + 8) >> 4 = -11 >> 4 = floor(-0.6875) = -1
                        // f(-19, -5) = (-19 + (1 << (-(-5) - 1))) << (-5) = (-19 + (1 << 4)) >> 5 = (-19 +16) >> 5 =  -3 >> 5 = floor(-0.09375) = -1
                        // f(-19, -6) = (-19 + (1 << (-(-6) - 1))) << (-6) = (-19 + (1 << 5)) >> 6 = (-19 +32) >> 6 =  13 >> 6 = floor(0.203125) = 0
                        // for e = 0 to elements-1
                        //     shift = SInt(Elem[operand2, e, esize]<7:0>);
                        //     if rounding then
                        //         round_const = 1 << (-shift - 1); // 0 for left shift, 2^(n-1) for right shift 
                        //     element = (Int(Elem[operand1, e, esize], unsigned) + round_const) << shift;
                        //     if saturating then
                        //         (Elem[result, e, esize], sat) = SatQ(element, esize, unsigned);
                        //         if sat then FPSR.QC = '1';
                        //     else
                        //         Elem[result, e, esize] = element<esize-1:0>;
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // Mnemonic: `rt[i] := (count[i]>=0)?(saturate(value[i] << count[i])):(value[i] >> -count[i])`, `>>` is mean `round(value[i] / pow(2,-count[i])) = intDiv(value[i], pow(2,-count[i])) = (value[i] + (1 << (-count[i] - 1))) >> -count[i]`. If the shift amount is out of range or the number overflows when shifting left, the result will saturate to the boundary. If the shift amount is out of range when shifting right, the result is 0 .
                // 4、Vector saturating rounding shift left(饱和指令): 
                // vqrshl -> ri = ai << bi;(negative values shift right) 
                // left shifts each element in a vector of integers and places the results in the destination vector.It is similar to VSHL. The difference is that the shifted value is rounded, and the sticky QC flag is set if saturation occurs.
                // 左移整数向量中的每个元素，并将结果放在目标向量中。它类似于VSHL。不同之处在于移位的值是四舍五入的，如果发生饱和，则设置粘滞QC标志。
                // ShiftArithmeticRoundedSaturate(Vector128<Int16>, Vector128<Int16>)	int16x8_t vqrshlq_s16 (int16x8_t a, int16x8_t b); A32: VQRSHL.S16 Qd, Qn, Qm; A64: SQRSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftArithmeticRoundedSaturate(Vector128<Int32>, Vector128<Int32>)	int32x4_t vqrshlq_s32 (int32x4_t a, int32x4_t b); A32: VQRSHL.S32 Qd, Qn, Qm; A64: SQRSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftArithmeticRoundedSaturate(Vector128<Int64>, Vector128<Int64>)	int64x2_t vqrshlq_s64 (int64x2_t a, int64x2_t b); A32: VQRSHL.S64 Qd, Qn, Qm; A64: SQRSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftArithmeticRoundedSaturate(Vector128<SByte>, Vector128<SByte>)	int8x16_t vqrshlq_s8 (int8x16_t a, int8x16_t b); A32: VQRSHL.S8 Qd, Qn, Qm; A64: SQRSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftArithmeticRoundedSaturate(Vector64<Int16>, Vector64<Int16>)	int16x4_t vqrshl_s16 (int16x4_t a, int16x4_t b); A32: VQRSHL.S16 Dd, Dn, Dm; A64: SQRSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftArithmeticRoundedSaturate(Vector64<Int32>, Vector64<Int32>)	int32x2_t vqrshl_s32 (int32x2_t a, int32x2_t b); A32: VQRSHL.S32 Dd, Dn, Dm; A64: SQRSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftArithmeticRoundedSaturate(Vector64<SByte>, Vector64<SByte>)	int8x8_t vqrshl_s8 (int8x8_t a, int8x8_t b); A32: VQRSHL.S8 Dd, Dn, Dm; A64: SQRSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftArithmeticRoundedSaturateScalar(Vector64<Int64>, Vector64<Int64>)	int64x1_t vqrshl_s64 (int64x1_t a, int64x1_t b); A32: VQRSHL.S64 Dd, Dn, Dm; A64: SQRSHL Dd, Dn, Dm
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<short> demo = Vector128.Create((short)elementNegative);
                        Vector128<short> vcount = Vector128.Create((short)15, 14, 1, 0, -1, -14, -15, -16);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<short>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<int> demo = Vector128.Create((int)elementNegative);
                        Vector128<int> vcount = Vector128.Create((int)31, 30, -31, -32);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<int>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<long> demo = Vector128.Create((long)elementNegative);
                        Vector128<long> vcount = Vector128.Create((long)63, -63);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                        vcount = Vector128.Create((long)63, -64);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                    }
                    if (true) {
                        // Try to go out of range.
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                        demo = Vector128.Create((sbyte)-elementNegative);
                        WriteLine(writer, indent, "ShiftArithmeticRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticRoundedSaturate(demo, vcount));
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // Mnemonic: `rt[i] := (count[i]>=0)?(saturate(value[i] << count[i])):(value[i] >> -count[i])`, `>>` is mean `floor(value[i] / pow(2,-count[i]))`. If the shift amount is out of range or the number overflows when shifting left, the result will saturate to the boundary. If the shift amount is out of range when shifting right, the result is 0/-1 .
                // 2、Vector saturating shift left(饱和指令):  
                // vqshl -> ri = ai << bi;(negative values shift right) 
                // If the shift value is positive, the operation is a left shift. Otherwise, it is a truncating right shift. left shifts each element in a vector of integers and places the results in the destination vector. It is similar to VSHL.  
                // The difference is that the sticky QC flag is set if saturation occurs
                // 如果shift值为正，则操作为左移。否则，它就是截断右移。左移整数向量中的每个元素，并将结果放在目标向量中。它类似于VSHL。
                // 区别在于，如果发生饱和，则设置粘性QC标志
                // ShiftArithmeticSaturate(Vector128<Int16>, Vector128<Int16>)	int16x8_t vqshlq_s16 (int16x8_t a, int16x8_t b); A32: VQSHL.S16 Qd, Qn, Qm; A64: SQSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftArithmeticSaturate(Vector128<Int32>, Vector128<Int32>)	int32x4_t vqshlq_s32 (int32x4_t a, int32x4_t b); A32: VQSHL.S32 Qd, Qn, Qm; A64: SQSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftArithmeticSaturate(Vector128<Int64>, Vector128<Int64>)	int64x2_t vqshlq_s64 (int64x2_t a, int64x2_t b); A32: VQSHL.S64 Qd, Qn, Qm; A64: SQSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftArithmeticSaturate(Vector128<SByte>, Vector128<SByte>)	int8x16_t vqshlq_s8 (int8x16_t a, int8x16_t b); A32: VQSHL.S8 Qd, Qn, Qm; A64: SQSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftArithmeticSaturate(Vector64<Int16>, Vector64<Int16>)	int16x4_t vqshl_s16 (int16x4_t a, int16x4_t b); A32: VQSHL.S16 Dd, Dn, Dm; A64: SQSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftArithmeticSaturate(Vector64<Int32>, Vector64<Int32>)	int32x2_t vqshl_s32 (int32x2_t a, int32x2_t b); A32: VQSHL.S32 Dd, Dn, Dm; A64: SQSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftArithmeticSaturate(Vector64<SByte>, Vector64<SByte>)	int8x8_t vqshl_s8 (int8x8_t a, int8x8_t b); A32: VQSHL.S8 Dd, Dn, Dm; A64: SQSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftArithmeticSaturateScalar(Vector64<Int64>, Vector64<Int64>)	int64x1_t vqshl_s64 (int64x1_t a, int64x1_t b); A32: VQSHL.S64 Dd, Dn, Dm; A64: SQSHL Dd, Dn, Dm
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftArithmeticSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<short> demo = Vector128.Create((short)elementNegative);
                        Vector128<short> vcount = Vector128.Create((short)15, 14, 1, 0, -1, -14, -15, -16);
                        WriteLine(writer, indent, "ShiftArithmeticSaturate<short>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<int> demo = Vector128.Create((int)elementNegative);
                        Vector128<int> vcount = Vector128.Create((int)31, 30, -31, -32);
                        WriteLine(writer, indent, "ShiftArithmeticSaturate<int>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<long> demo = Vector128.Create((long)elementNegative);
                        Vector128<long> vcount = Vector128.Create((long)63, -63);
                        WriteLine(writer, indent, "ShiftArithmeticSaturate<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticSaturate(demo, vcount));
                        vcount = Vector128.Create((long)63, -64);
                        WriteLine(writer, indent, "ShiftArithmeticSaturate<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticSaturate(demo, vcount));
                    }
                    if (true) {
                        // Try to go out of range.
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftArithmeticSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticSaturate(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9);
                        WriteLine(writer, indent, "ShiftArithmeticSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticSaturate(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9);
                        WriteLine(writer, indent, "ShiftArithmeticSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftArithmeticSaturate(demo, serial):\t{0}", AdvSimd.ShiftArithmeticSaturate(demo, vcount));
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // Mnemonic: `rt[i] := ConditionalSelect(GetBitsMask(shiftAmount), a[i], b[i] << shiftAmount)`. Tip: `GetBitsMask(shiftAmount) = (1 << shiftAmount) - 1`
                // 2、Vector shift left and insert: vsli ->; The least significant bit in each element 
                // in the destination vector is unchanged. left shifts each element in the second input vector by an immediate value, and inserts the results in the destination vector. 
                // It does not affect the lowest n significant bits of the elements in the destination register. Bits shifted out of the left of each element are lost. The first input vector holds the elements of the destination vector before the operation is performed.
                // 在目标向量中不变。左移第二个输入向量中的每个元素一个直接值，并将结果插入到目标向量中。
                // 它不影响目标寄存器中元素的最低n位有效位。从每个元素左侧移出的位将丢失。第一个输入向量保存执行操作之前目标向量的元素。
                // ShiftLeftAndInsert(Vector128<Byte>, Vector128<Byte>, Byte)	uint8x16_t vsliq_n_u8(uint8x16_t a, uint8x16_t b, __builtin_constant_p(n)) A32: VSLI.8 Qd, Qm, #n A64: SLI Vd.16B, Vn.16B, #n
                // ShiftLeftAndInsert(Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vsliq_n_s16(int16x8_t a, int16x8_t b, __builtin_constant_p(n)) A32: VSLI.16 Qd, Qm, #n A64: SLI Vd.8H, Vn.8H, #n
                // ShiftLeftAndInsert(Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vsliq_n_s32(int32x4_t a, int32x4_t b, __builtin_constant_p(n)) A32: VSLI.32 Qd, Qm, #n A64: SLI Vd.4S, Vn.4S, #n
                // ShiftLeftAndInsert(Vector128<Int64>, Vector128<Int64>, Byte)	int64x2_t vsliq_n_s64(int64x2_t a, int64x2_t b, __builtin_constant_p(n)) A32: VSLI.64 Qd, Qm, #n A64: SLI Vd.2D, Vn.2D, #n
                // ShiftLeftAndInsert(Vector128<SByte>, Vector128<SByte>, Byte)	int8x16_t vsliq_n_s8(int8x16_t a, int8x16_t b, __builtin_constant_p(n)) A32: VSLI.8 Qd, Qm, #n A64: SLI Vd.16B, Vn.16B, #n
                // ShiftLeftAndInsert(Vector128<UInt16>, Vector128<UInt16>, Byte)	uint16x8_t vsliq_n_u16(uint16x8_t a, uint16x8_t b, __builtin_constant_p(n)) A32: VSLI.16 Qd, Qm, #n A64: SLI Vd.8H, Vn.8H, #n
                // ShiftLeftAndInsert(Vector128<UInt32>, Vector128<UInt32>, Byte)	uint32x4_t vsliq_n_u32(uint32x4_t a, uint32x4_t b, __builtin_constant_p(n)) A32: VSLI.32 Qd, Qm, #n A64: SLI Vd.4S, Vn.4S, #n
                // ShiftLeftAndInsert(Vector128<UInt64>, Vector128<UInt64>, Byte)	uint64x2_t vsliq_n_u64(uint64x2_t a, uint64x2_t b, __builtin_constant_p(n)) A32: VSLI.64 Qd, Qm, #n A64: SLI Vd.2D, Vn.2D, #n
                // ShiftLeftAndInsert(Vector64<Byte>, Vector64<Byte>, Byte)	uint8x8_t vsli_n_u8(uint8x8_t a, uint8x8_t b, __builtin_constant_p(n)) A32: VSLI.8 Dd, Dm, #n A64: SLI Vd.8B, Vn.8B, #n
                // ShiftLeftAndInsert(Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vsli_n_s16(int16x4_t a, int16x4_t b, __builtin_constant_p(n)) A32: VSLI.16 Dd, Dm, #n A64: SLI Vd.4H, Vn.4H, #n
                // ShiftLeftAndInsert(Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vsli_n_s32(int32x2_t a, int32x2_t b, __builtin_constant_p(n)) A32: VSLI.32 Dd, Dm, #n A64: SLI Vd.2S, Vn.2S, #n
                // ShiftLeftAndInsert(Vector64<SByte>, Vector64<SByte>, Byte)	int8x8_t vsli_n_s8(int8x8_t a, int8x8_t b, __builtin_constant_p(n)) A32: VSLI.8 Dd, Dm, #n A64: SLI Vd.8B, Vn.8B, #n
                // ShiftLeftAndInsert(Vector64<UInt16>, Vector64<UInt16>, Byte)	uint16x4_t vsli_n_u16(uint16x4_t a, uint16x4_t b, __builtin_constant_p(n)) A32: VSLI.16 Dd, Dm, #n A64: SLI Vd.4H, Vn.4H, #n
                // ShiftLeftAndInsert(Vector64<UInt32>, Vector64<UInt32>, Byte)	uint32x2_t vsli_n_u32(uint32x2_t a, uint32x2_t b, __builtin_constant_p(n)) A32: VSLI.32 Dd, Dm, #n A64: SLI Vd.2S, Vn.2S, #n
                // ShiftLeftAndInsertScalar(Vector64<Int64>, Vector64<Int64>, Byte)	int64_t vslid_n_s64(int64_t a, int64_t b, __builtin_constant_p(n)) A32: VSLI.64 Dd, Dm, #n A64: SLI Dd, Dn, #n
                // ShiftLeftAndInsertScalar(Vector64<UInt64>, Vector64<UInt64>, Byte)	uint64_t vslid_n_u64(uint64_t a, uint64_t b, __builtin_constant_p(n)) A32: VSLI.64 Dd, Dm, #n A64: SLI Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    Vector128<sbyte> serial = Vector128s<sbyte>.Serial;
                    WriteLine(writer, indent, "ShiftLeftAndInsert<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 0; shiftAmount <= 7; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftAndInsert(demo, serial, {1}):\t{0}", AdvSimd.ShiftLeftAndInsert(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftLeftAndInsert<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 0; shiftAmount <= 15; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftAndInsert(demo, serial, {1}):\t{0}", AdvSimd.ShiftLeftAndInsert(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftLeftAndInsert<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 0; shiftAmount <= 31; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftAndInsert(demo, serial, {1}):\t{0}", AdvSimd.ShiftLeftAndInsert(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftLeftAndInsert<long>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 0; shiftAmount <= 63; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftAndInsert(demo, serial, {1}):\t{0}", AdvSimd.ShiftLeftAndInsert(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // Mnemonic: `rt[i] := value[i] << shiftAmount`
                // 2、Vector shift left by constant: vshl -> ri = ai << b; 
                // left shifts each element in a vector by an immediate value, and places the results in the destination vector. The bits shifted out of the left of each element are lost
                // 将向量中的每个元素左移一个直接值，并将结果放在目标向量中。移出每个元素左边的比特丢失
                // ShiftLeftLogical(Vector128<Byte>, Byte)	uint8x16_t vshlq_n_u8 (uint8x16_t a, const int n); A32: VSHL.I8 Qd, Qm, #n; A64: SHL Vd.16B, Vn.16B, #n
                // ShiftLeftLogical(Vector128<Int16>, Byte)	int16x8_t vshlq_n_s16 (int16x8_t a, const int n); A32: VSHL.I16 Qd, Qm, #n; A64: SHL Vd.8H, Vn.8H, #n
                // ShiftLeftLogical(Vector128<Int64>, Byte)	int64x2_t vshlq_n_s64 (int64x2_t a, const int n); A32: VSHL.I64 Qd, Qm, #n; A64: SHL Vd.2D, Vn.2D, #n
                // ShiftLeftLogical(Vector128<SByte>, Byte)	int8x16_t vshlq_n_s8 (int8x16_t a, const int n); A32: VSHL.I8 Qd, Qm, #n; A64: SHL Vd.16B, Vn.16B, #n
                // ShiftLeftLogical(Vector128<UInt16>, Byte)	uint16x8_t vshlq_n_u16 (uint16x8_t a, const int n); A32: VSHL.I16 Qd, Qm, #n; A64: SHL Vd.8H, Vn.8H, #n
                // ShiftLeftLogical(Vector128<UInt32>, Byte)	uint32x4_t vshlq_n_u32 (uint32x4_t a, const int n); A32: VSHL.I32 Qd, Qm, #n; A64: SHL Vd.4S, Vn.4S, #n
                // ShiftLeftLogical(Vector128<UInt64>, Byte)	uint64x2_t vshlq_n_u64 (uint64x2_t a, const int n); A32: VSHL.I64 Qd, Qm, #n; A64: SHL Vd.2D, Vn.2D, #n
                // ShiftLeftLogical(Vector64<Byte>, Byte)	uint8x8_t vshl_n_u8 (uint8x8_t a, const int n); A32: VSHL.I8 Dd, Dm, #n; A64: SHL Vd.8B, Vn.8B, #n
                // ShiftLeftLogical(Vector64<Int16>, Byte)	int16x4_t vshl_n_s16 (int16x4_t a, const int n); A32: VSHL.I16 Dd, Dm, #n; A64: SHL Vd.4H, Vn.4H, #n
                // ShiftLeftLogical(Vector64<Int32>, Byte)	int32x2_t vshl_n_s32 (int32x2_t a, const int n); A32: VSHL.I32 Dd, Dm, #n; A64: SHL Vd.2S, Vn.2S, #n
                // ShiftLeftLogical(Vector64<SByte>, Byte)	int8x8_t vshl_n_s8 (int8x8_t a, const int n); A32: VSHL.I8 Dd, Dm, #n; A64: SHL Vd.8B, Vn.8B, #n
                // ShiftLeftLogical(Vector64<UInt16>, Byte)	uint16x4_t vshl_n_u16 (uint16x4_t a, const int n); A32: VSHL.I16 Dd, Dm, #n; A64: SHL Vd.4H, Vn.4H, #n
                // ShiftLeftLogical(Vector64<UInt32>, Byte)	uint32x2_t vshl_n_u32 (uint32x2_t a, const int n); A32: VSHL.I32 Dd, Dm, #n; A64: SHL Vd.2S, Vn.2S, #n
                // ShiftLeftLogicalScalar(Vector64<Int64>, Byte)	int64x1_t vshl_n_s64 (int64x1_t a, const int n); A32: VSHL.I64 Dd, Dm, #n; A64: SHL Dd, Dn, #n
                // ShiftLeftLogicalScalar(Vector64<UInt64>, Byte)	uint64x1_t vshl_n_u64 (uint64x1_t a, const int n); A32: VSHL.I64 Dd, Dm, #n; A64: SHL Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogical<sbyte>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 7; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogical(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogical(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogical<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 15; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogical(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogical(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogical<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 31; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogical(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogical(demo.AsUInt32(), (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogical<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 63; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogical(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogical(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // Mnemonic: `rt[i] := saturate(value[i] << count[i]`. If the shift amount is out of range or the number overflows when shifting left, the result will saturate to the boundary.
                // 6、Vector saturating shift left by constant: vqshl -> ri = sat(ai << b);  
                // left shifts each element in a vector of integers by an immediate value, and places the results in the destination vector,and the sticky QC flag is set if saturation occurs.
                // 将整数向量中的每个元素左移一个即时值，并将结果放在目标向量中，如果发生饱和，则设置粘性QC标志。
                // ShiftLeftLogicalSaturate(Vector128<Byte>, Byte)	uint8x16_t vqshlq_n_u8 (uint8x16_t a, const int n); A32: VQSHL.U8 Qd, Qm, #n; A64: UQSHL Vd.16B, Vn.16B, #n
                // ShiftLeftLogicalSaturate(Vector128<Int16>, Byte)	int16x8_t vqshlq_n_s16 (int16x8_t a, const int n); A32: VQSHL.S16 Qd, Qm, #n; A64: SQSHL Vd.8H, Vn.8H, #n
                // ShiftLeftLogicalSaturate(Vector128<Int32>, Byte)	int32x4_t vqshlq_n_s32 (int32x4_t a, const int n); A32: VQSHL.S32 Qd, Qm, #n; A64: SQSHL Vd.4S, Vn.4S, #n
                // ShiftLeftLogicalSaturate(Vector128<Int64>, Byte)	int64x2_t vqshlq_n_s64 (int64x2_t a, const int n); A32: VQSHL.S64 Qd, Qm, #n; A64: SQSHL Vd.2D, Vn.2D, #n
                // ShiftLeftLogicalSaturate(Vector128<SByte>, Byte)	int8x16_t vqshlq_n_s8 (int8x16_t a, const int n); A32: VQSHL.S8 Qd, Qm, #n; A64: SQSHL Vd.16B, Vn.16B, #n
                // ShiftLeftLogicalSaturate(Vector128<UInt16>, Byte)	uint16x8_t vqshlq_n_u16 (uint16x8_t a, const int n); A32: VQSHL.U16 Qd, Qm, #n; A64: UQSHL Vd.8H, Vn.8H, #n
                // ShiftLeftLogicalSaturate(Vector128<UInt32>, Byte)	uint32x4_t vqshlq_n_u32 (uint32x4_t a, const int n); A32: VQSHL.U32 Qd, Qm, #n; A64: UQSHL Vd.4S, Vn.4S, #n
                // ShiftLeftLogicalSaturate(Vector128<UInt64>, Byte)	uint64x2_t vqshlq_n_u64 (uint64x2_t a, const int n); A32: VQSHL.U64 Qd, Qm, #n; A64: UQSHL Vd.2D, Vn.2D, #n
                // ShiftLeftLogicalSaturate(Vector64<Byte>, Byte)	uint8x8_t vqshl_n_u8 (uint8x8_t a, const int n); A32: VQSHL.U8 Dd, Dm, #n; A64: UQSHL Vd.8B, Vn.8B, #n
                // ShiftLeftLogicalSaturate(Vector64<Int16>, Byte)	int16x4_t vqshl_n_s16 (int16x4_t a, const int n); A32: VQSHL.S16 Dd, Dm, #n; A64: SQSHL Vd.4H, Vn.4H, #n
                // ShiftLeftLogicalSaturate(Vector64<Int32>, Byte)	int32x2_t vqshl_n_s32 (int32x2_t a, const int n); A32: VQSHL.S32 Dd, Dm, #n; A64: SQSHL Vd.2S, Vn.2S, #n
                // ShiftLeftLogicalSaturate(Vector64<SByte>, Byte)	int8x8_t vqshl_n_s8 (int8x8_t a, const int n); A32: VQSHL.S8 Dd, Dm, #n; A64: SQSHL Vd.8B, Vn.8B, #n
                // ShiftLeftLogicalSaturate(Vector64<UInt16>, Byte)	uint16x4_t vqshl_n_u16 (uint16x4_t a, const int n); A32: VQSHL.U16 Dd, Dm, #n; A64: UQSHL Vd.4H, Vn.4H, #n
                // ShiftLeftLogicalSaturate(Vector64<UInt32>, Byte)	uint32x2_t vqshl_n_u32 (uint32x2_t a, const int n); A32: VQSHL.U32 Dd, Dm, #n; A64: UQSHL Vd.2S, Vn.2S, #n
                // ShiftLeftLogicalSaturateScalar(Vector64<Int64>, Byte)	int64x1_t vqshl_n_s64 (int64x1_t a, const int n); A32: VQSHL.S64 Dd, Dm, #n; A64: SQSHL Dd, Dn, #n
                // ShiftLeftLogicalSaturateScalar(Vector64<UInt64>, Byte)	uint64x1_t vqshl_n_u64 (uint64x1_t a, const int n); A32: VQSHL.U64 Dd, Dm, #n; A64: UQSHL Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalSaturate<sbyte>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 7; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalSaturate(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalSaturate(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalSaturate<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 15; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalSaturate(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalSaturate(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalSaturate<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 31; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalSaturate(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalSaturate(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalSaturate<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 63; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalSaturate(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalSaturate(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // Mnemonic: `rt[i] := saturate(toUnsigned(max(0, value[i])) << count[i]`. If the shift amount is out of range or the number overflows when shifting left, the result will saturate to the boundary.
                // 7、Vector signed->unsigned saturating shift left by constant: vqshlu -> ri = ai << b;  
                // left shifts each element in a vector of integers by an immediate value, places the results in the destination vector, the sticky QC flag is set if saturation occurs, and indicates that the results are unsigned even though the operands are signed.
                // 将整数向量中的每个元素左移一个即时值，将结果放在目标向量中，如果发生饱和，则设置sticky QC标志，并指示即使操作数是有符号的，结果也是无符号的。
                // ShiftLeftLogicalSaturateUnsigned(Vector128<Int16>, Byte)	uint16x8_t vqshluq_n_s16 (int16x8_t a, const int n); A32: VQSHLU.S16 Qd, Qm, #n; A64: SQSHLU Vd.8H, Vn.8H, #n
                // ShiftLeftLogicalSaturateUnsigned(Vector128<Int32>, Byte)	uint32x4_t vqshluq_n_s32 (int32x4_t a, const int n); A32: VQSHLU.S32 Qd, Qm, #n; A64: SQSHLU Vd.4S, Vn.4S, #n
                // ShiftLeftLogicalSaturateUnsigned(Vector128<Int64>, Byte)	uint64x2_t vqshluq_n_s64 (int64x2_t a, const int n); A32: VQSHLU.S64 Qd, Qm, #n; A64: SQSHLU Vd.2D, Vn.2D, #n
                // ShiftLeftLogicalSaturateUnsigned(Vector128<SByte>, Byte)	uint8x16_t vqshluq_n_s8 (int8x16_t a, const int n); A32: VQSHLU.S8 Qd, Qm, #n; A64: SQSHLU Vd.16B, Vn.16B, #n
                // ShiftLeftLogicalSaturateUnsigned(Vector64<Int16>, Byte)	uint16x4_t vqshlu_n_s16 (int16x4_t a, const int n); A32: VQSHLU.S16 Dd, Dm, #n; A64: SQSHLU Vd.4H, Vn.4H, #n
                // ShiftLeftLogicalSaturateUnsigned(Vector64<Int32>, Byte)	uint32x2_t vqshlu_n_s32 (int32x2_t a, const int n); A32: VQSHLU.S32 Dd, Dm, #n; A64: SQSHLU Vd.2S, Vn.2S, #n
                // ShiftLeftLogicalSaturateUnsigned(Vector64<SByte>, Byte)	uint8x8_t vqshlu_n_s8 (int8x8_t a, const int n); A32: VQSHLU.S8 Dd, Dm, #n; A64: SQSHLU Vd.8B, Vn.8B, #n
                // ShiftLeftLogicalSaturateUnsignedScalar(Vector64<Int64>, Byte)	uint64x1_t vqshlu_n_s64 (int64x1_t a, const int n); A32: VQSHLU.S64 Dd, Dm, #n; A64: SQSHLU Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalSaturateUnsigned<sbyte>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 7; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalSaturateUnsigned(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalSaturateUnsigned(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalSaturateUnsigned<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 15; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalSaturateUnsigned(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalSaturateUnsigned(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalSaturateUnsigned<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 31; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalSaturateUnsigned(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalSaturateUnsigned(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalSaturateUnsigned<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 63; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalSaturateUnsigned(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalSaturateUnsigned(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // Mnemonic: `rt[i] := toWiden(value[i]) << shiftAmount`
                // 14、Vector widening shift left by constant: vshll -> ri = ai << b;  
                // left shifts each element in a vector of integers by an immediate value, and place the results in the destination vector. Bits shifted out of the left of each element are lost and values are sign extended or zero extended.
                // 将整数向量中的每个元素左移一个直接值，并将结果放在目标向量中。从每个元素左侧移出的位丢失，值扩展为符号扩展或0扩展。
                // ShiftLeftLogicalWideningLower(Vector64<Byte>, Byte)	uint16x8_t vshll_n_u8 (uint8x8_t a, const int n); A32: VSHLL.U8 Qd, Dm, #n; A64: USHLL Vd.8H, Vn.8B, #n
                // ShiftLeftLogicalWideningLower(Vector64<Int16>, Byte)	int32x4_t vshll_n_s16 (int16x4_t a, const int n); A32: VSHLL.S16 Qd, Dm, #n; A64: SSHLL Vd.4S, Vn.4H, #n
                // ShiftLeftLogicalWideningLower(Vector64<Int32>, Byte)	int64x2_t vshll_n_s32 (int32x2_t a, const int n); A32: VSHLL.S32 Qd, Dm, #n; A64: SSHLL Vd.2D, Vn.2S, #n
                // ShiftLeftLogicalWideningLower(Vector64<SByte>, Byte)	int16x8_t vshll_n_s8 (int8x8_t a, const int n); A32: VSHLL.S8 Qd, Dm, #n; A64: SSHLL Vd.8H, Vn.8B, #n
                // ShiftLeftLogicalWideningLower(Vector64<UInt16>, Byte)	uint32x4_t vshll_n_u16 (uint16x4_t a, const int n); A32: VSHLL.U16 Qd, Dm, #n; A64: USHLL Vd.4S, Vn.4H, #n
                // ShiftLeftLogicalWideningLower(Vector64<UInt32>, Byte)	uint64x2_t vshll_n_u32 (uint32x2_t a, const int n); A32: VSHLL.U32 Qd, Dm, #n; A64: USHLL Vd.2D, Vn.2S, #n
                if (true) {
                    Vector64<sbyte> demo = Vector64s<sbyte>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalWideningLower<sbyte>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 7; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalWideningLower(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalWideningLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                    // 8: System.ArgumentOutOfRangeException: Specified argument was out of the range of valid values.
                }
                if (true) {
                    Vector64<short> demo = Vector64s<short>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalWideningLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 15; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalWideningLower(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalWideningLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<int> demo = Vector64s<int>.Demo;
                    WriteLine(writer, indent, "ShiftLeftLogicalWideningLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 0; shiftAmount <= 31; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftLeftLogicalWideningLower(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalWideningLower(demo.AsUInt32(), (byte)shiftAmount), shiftAmount);
                    }
                }

                // Mnemonic: `rt[i] := toWiden(value[i+(vcount/2)]) << shiftAmount`
                // ShiftLeftLogicalWideningUpper(Vector128<Byte>, Byte)	uint16x8_t vshll_high_n_u8 (uint8x16_t a, const int n); A32: VSHLL.U8 Qd, Dm+1, #n; A64: USHLL2 Vd.8H, Vn.16B, #n
                // ShiftLeftLogicalWideningUpper(Vector128<Int16>, Byte)	int32x4_t vshll_high_n_s16 (int16x8_t a, const int n); A32: VSHLL.S16 Qd, Dm+1, #n; A64: SSHLL2 Vd.4S, Vn.8H, #n
                // ShiftLeftLogicalWideningUpper(Vector128<Int32>, Byte)	int64x2_t vshll_high_n_s32 (int32x4_t a, const int n); A32: VSHLL.S32 Qd, Dm+1, #n; A64: SSHLL2 Vd.2D, Vn.4S, #n
                // ShiftLeftLogicalWideningUpper(Vector128<SByte>, Byte)	int16x8_t vshll_high_n_s8 (int8x16_t a, const int n); A32: VSHLL.S8 Qd, Dm+1, #n; A64: SSHLL2 Vd.8H, Vn.16B, #n
                // ShiftLeftLogicalWideningUpper(Vector128<UInt16>, Byte)	uint32x4_t vshll_high_n_u16 (uint16x8_t a, const int n); A32: VSHLL.U16 Qd, Dm+1, #n; A64: USHLL2 Vd.4S, Vn.8H, #n
                // ShiftLeftLogicalWideningUpper(Vector128<UInt32>, Byte)	uint64x2_t vshll_high_n_u32 (uint32x4_t a, const int n); A32: VSHLL.U32 Qd, Dm+1, #n; A64: USHLL2 Vd.2D, Vn.4S, #n
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                        WriteLine(writer, indent, "ShiftLeftLogicalWideningUpper<sbyte>, demo:\t{0}", demo);
                        for (int shiftAmount = 0; shiftAmount <= 7; ++shiftAmount) {
                            WriteLine(writer, indentNext, "ShiftLeftLogicalWideningUpper(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalWideningUpper(demo, (byte)shiftAmount), shiftAmount);
                        }
                    }
                    if (true) {
                        Vector128<short> demo = Vector128s<short>.Demo;
                        WriteLine(writer, indent, "ShiftLeftLogicalWideningUpper<short>, demo:\t{0}", demo);
                        for (int shiftAmount = 0; shiftAmount <= 15; ++shiftAmount) {
                            WriteLine(writer, indentNext, "ShiftLeftLogicalWideningUpper(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalWideningUpper(demo, (byte)shiftAmount), shiftAmount);
                        }
                    }
                    if (true) {
                        Vector128<int> demo = Vector128s<int>.Demo;
                        WriteLine(writer, indent, "ShiftLeftLogicalWideningUpper<int>, demo:\t{0}", demo);
                        for (int shiftAmount = 0; shiftAmount <= 31; ++shiftAmount) {
                            WriteLine(writer, indentNext, "ShiftLeftLogicalWideningUpper(demo, {1}):\t{0}", AdvSimd.ShiftLeftLogicalWideningUpper(demo.AsUInt32(), (byte)shiftAmount), shiftAmount);
                        }
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // 1、Vector shift left: vshl -> ri = ai << bi; (negative values shift right) 
                // left shifts each element in a vector by an amount specified in the corresponding element in the second input vector. The shift amount is the signed integer value of the least significant byte of the element in the second input vector. The bits shifted out of each element are lost.If the signed integer value is negative, it results in a right shift
                // 将一个向量中的每个元素左移一个在第二个输入向量中的相应元素中指定的量。移位量是第二个输入向量中元素的最低有效字节的有符号整数值。从每个元素移出的比特都丢失了。如果有符号整数值为负，则会导致右移
                // ShiftLogical(Vector128<Byte>, Vector128<SByte>)	uint8x16_t vshlq_u8 (uint8x16_t a, int8x16_t b); A32: VSHL.U8 Qd, Qn, Qm; A64: USHL Vd.16B, Vn.16B, Vm.16B
                // ShiftLogical(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vshlq_u16 (uint16x8_t a, int16x8_t b); A32: VSHL.U16 Qd, Qn, Qm; A64: USHL Vd.8H, Vn.8H, Vm.8H
                // ShiftLogical(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vshlq_u32 (uint32x4_t a, int32x4_t b); A32: VSHL.U32 Qd, Qn, Qm; A64: USHL Vd.4S, Vn.4S, Vm.4S
                // ShiftLogical(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vshlq_u64 (uint64x2_t a, int64x2_t b); A32: VSHL.U64 Qd, Qn, Qm; A64: USHL Vd.2D, Vn.2D, Vm.2D
                // ShiftLogical(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vshlq_u8 (uint8x16_t a, int8x16_t b); A32: VSHL.U8 Qd, Qn, Qm; A64: USHL Vd.16B, Vn.16B, Vm.16B
                // ShiftLogical(Vector128<UInt16>, Vector128<Int16>)	uint16x8_t vshlq_u16 (uint16x8_t a, int16x8_t b); A32: VSHL.U16 Qd, Qn, Qm; A64: USHL Vd.8H, Vn.8H, Vm.8H
                // ShiftLogical(Vector128<UInt32>, Vector128<Int32>)	uint32x4_t vshlq_u32 (uint32x4_t a, int32x4_t b); A32: VSHL.U32 Qd, Qn, Qm; A64: USHL Vd.4S, Vn.4S, Vm.4S
                // ShiftLogical(Vector128<UInt64>, Vector128<Int64>)	uint64x2_t vshlq_u64 (uint64x2_t a, int64x2_t b); A32: VSHL.U64 Qd, Qn, Qm; A64: USHL Vd.2D, Vn.2D, Vm.2D
                // ShiftLogical(Vector64<Byte>, Vector64<SByte>)	uint8x8_t vshl_u8 (uint8x8_t a, int8x8_t b); A32: VSHL.U8 Dd, Dn, Dm; A64: USHL Vd.8B, Vn.8B, Vm.8B
                // ShiftLogical(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vshl_u16 (uint16x4_t a, int16x4_t b); A32: VSHL.U16 Dd, Dn, Dm; A64: USHL Vd.4H, Vn.4H, Vm.4H
                // ShiftLogical(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vshl_u32 (uint32x2_t a, int32x2_t b); A32: VSHL.U32 Dd, Dn, Dm; A64: USHL Vd.2S, Vn.2S, Vm.2S
                // ShiftLogical(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vshl_u8 (uint8x8_t a, int8x8_t b); A32: VSHL.U8 Dd, Dn, Dm; A64: USHL Vd.8B, Vn.8B, Vm.8B
                // ShiftLogical(Vector64<UInt16>, Vector64<Int16>)	uint16x4_t vshl_u16 (uint16x4_t a, int16x4_t b); A32: VSHL.U16 Dd, Dn, Dm; A64: USHL Vd.4H, Vn.4H, Vm.4H
                // ShiftLogical(Vector64<UInt32>, Vector64<Int32>)	uint32x2_t vshl_u32 (uint32x2_t a, int32x2_t b); A32: VSHL.U32 Dd, Dn, Dm; A64: USHL Vd.2S, Vn.2S, Vm.2S
                // ShiftLogicalScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vshl_u64 (uint64x1_t a, int64x1_t b); A32: VSHL.U64 Dd, Dn, Dm; A64: USHL Dd, Dn, Dm
                // ShiftLogicalScalar(Vector64<UInt64>, Vector64<Int64>)	uint64x1_t vshl_u64 (uint64x1_t a, int64x1_t b); A32: VSHL.U64 Dd, Dn, Dm; A64: USHL Dd, Dn, Dm
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftLogical<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogical(demo, serial):\t{0}", AdvSimd.ShiftLogical(demo, vcount));
                    }
                    if (true) {
                        Vector128<short> demo = Vector128.Create((short)elementNegative);
                        Vector128<short> vcount = Vector128.Create((short)15, 14, 1, 0, -1, -14, -15, -16);
                        WriteLine(writer, indent, "ShiftLogical<short>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogical(demo, serial):\t{0}", AdvSimd.ShiftLogical(demo, vcount));
                    }
                    if (true) {
                        Vector128<int> demo = Vector128.Create((int)elementNegative);
                        Vector128<int> vcount = Vector128.Create((int)31, 30, -31, -32);
                        WriteLine(writer, indent, "ShiftLogical<int>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogical(demo, serial):\t{0}", AdvSimd.ShiftLogical(demo, vcount));
                    }
                    if (true) {
                        Vector128<long> demo = Vector128.Create((long)elementNegative);
                        Vector128<long> vcount = Vector128.Create((long)63, -63);
                        WriteLine(writer, indent, "ShiftLogical<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogical(demo, serial):\t{0}", AdvSimd.ShiftLogical(demo, vcount));
                        vcount = Vector128.Create((long)63, -64);
                        WriteLine(writer, indent, "ShiftLogical<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogical(demo, serial):\t{0}", AdvSimd.ShiftLogical(demo, vcount));
                    }
                    if (true) {
                        // Try to go out of range.
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftLogical<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogical(demo, serial):\t{0}", AdvSimd.ShiftLogical(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9);
                        WriteLine(writer, indent, "ShiftLogical<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogical(demo, serial):\t{0}", AdvSimd.ShiftLogical(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9);
                        WriteLine(writer, indent, "ShiftLogical<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogical(demo, serial):\t{0}", AdvSimd.ShiftLogical(demo, vcount));
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // 3、Vector rounding shift left(舍入指令):  
                // vrshl -> ri = ai << bi;(negative values shift right) 
                // If the shift value is positive, the operation is a left shift. Otherwise, it is a rounding right shift. left shifts each element in a vector of integers and places the results in the destination vector. It is similar to VSHL.  
                // The difference is that the shifted value is then rounded.
                // 如果shift值为正，则操作为左移。否则，它是一个舍入右移。左移整数向量中的每个元素，并将结果放在目标向量中。它类似于VSHL。
                // 不同之处在于移位后的值被四舍五入。
                // ShiftLogicalRounded(Vector128<Byte>, Vector128<SByte>)	uint8x16_t vrshlq_u8 (uint8x16_t a, int8x16_t b); A32: VRSHL.U8 Qd, Qn, Qm; A64: URSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftLogicalRounded(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vrshlq_u16 (uint16x8_t a, int16x8_t b); A32: VRSHL.U16 Qd, Qn, Qm; A64: URSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftLogicalRounded(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vrshlq_u32 (uint32x4_t a, int32x4_t b); A32: VRSHL.U32 Qd, Qn, Qm; A64: URSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftLogicalRounded(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vrshlq_u64 (uint64x2_t a, int64x2_t b); A32: VRSHL.U64 Qd, Qn, Qm; A64: URSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftLogicalRounded(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vrshlq_u8 (uint8x16_t a, int8x16_t b); A32: VRSHL.U8 Qd, Qn, Qm; A64: URSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftLogicalRounded(Vector128<UInt16>, Vector128<Int16>)	uint16x8_t vrshlq_u16 (uint16x8_t a, int16x8_t b); A32: VRSHL.U16 Qd, Qn, Qm; A64: URSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftLogicalRounded(Vector128<UInt32>, Vector128<Int32>)	uint32x4_t vrshlq_u32 (uint32x4_t a, int32x4_t b); A32: VRSHL.U32 Qd, Qn, Qm; A64: URSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftLogicalRounded(Vector128<UInt64>, Vector128<Int64>)	uint64x2_t vrshlq_u64 (uint64x2_t a, int64x2_t b); A32: VRSHL.U64 Qd, Qn, Qm; A64: URSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftLogicalRounded(Vector64<Byte>, Vector64<SByte>)	uint8x8_t vrshl_u8 (uint8x8_t a, int8x8_t b); A32: VRSHL.U8 Dd, Dn, Dm; A64: URSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftLogicalRounded(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vrshl_u16 (uint16x4_t a, int16x4_t b); A32: VRSHL.U16 Dd, Dn, Dm; A64: URSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftLogicalRounded(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vrshl_u32 (uint32x2_t a, int32x2_t b); A32: VRSHL.U32 Dd, Dn, Dm; A64: URSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftLogicalRounded(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vrshl_u8 (uint8x8_t a, int8x8_t b); A32: VRSHL.U8 Dd, Dn, Dm; A64: URSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftLogicalRounded(Vector64<UInt16>, Vector64<Int16>)	uint16x4_t vrshl_u16 (uint16x4_t a, int16x4_t b); A32: VRSHL.U16 Dd, Dn, Dm; A64: URSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftLogicalRounded(Vector64<UInt32>, Vector64<Int32>)	uint32x2_t vrshl_u32 (uint32x2_t a, int32x2_t b); A32: VRSHL.U32 Dd, Dn, Dm; A64: URSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftLogicalRoundedScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vrshl_u64 (uint64x1_t a, int64x1_t b); A32: VRSHL.U64 Dd, Dn, Dm; A64: URSHL Dd, Dn, Dm
                // ShiftLogicalRoundedScalar(Vector64<UInt64>, Vector64<Int64>)	uint64x1_t vrshl_u64 (uint64x1_t a, int64x1_t b); A32: VRSHL.U64 Dd, Dn, Dm; A64: URSHL Dd, Dn, Dm
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftLogicalRounded<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRounded(demo, serial):\t{0}", AdvSimd.ShiftLogicalRounded(demo, vcount));
                    }
                    if (true) {
                        Vector128<short> demo = Vector128.Create((short)elementNegative);
                        Vector128<short> vcount = Vector128.Create((short)15, 14, 1, 0, -1, -14, -15, -16);
                        WriteLine(writer, indent, "ShiftLogicalRounded<short>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRounded(demo, serial):\t{0}", AdvSimd.ShiftLogicalRounded(demo, vcount));
                    }
                    if (true) {
                        Vector128<int> demo = Vector128.Create((int)elementNegative);
                        Vector128<int> vcount = Vector128.Create((int)31, 30, -31, -32);
                        WriteLine(writer, indent, "ShiftLogicalRounded<int>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRounded(demo, serial):\t{0}", AdvSimd.ShiftLogicalRounded(demo, vcount));
                    }
                    if (true) {
                        Vector128<long> demo = Vector128.Create((long)elementNegative);
                        Vector128<long> vcount = Vector128.Create((long)63, -63);
                        WriteLine(writer, indent, "ShiftLogicalRounded<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRounded(demo, serial):\t{0}", AdvSimd.ShiftLogicalRounded(demo, vcount));
                        vcount = Vector128.Create((long)63, -64);
                        WriteLine(writer, indent, "ShiftLogicalRounded<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRounded(demo, serial):\t{0}", AdvSimd.ShiftLogicalRounded(demo, vcount));
                    }
                    if (true) {
                        // Try to go out of range.
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftLogicalRounded<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRounded(demo, serial):\t{0}", AdvSimd.ShiftLogicalRounded(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9);
                        WriteLine(writer, indent, "ShiftLogicalRounded<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRounded(demo, serial):\t{0}", AdvSimd.ShiftLogicalRounded(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9);
                        WriteLine(writer, indent, "ShiftLogicalRounded<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRounded(demo, serial):\t{0}", AdvSimd.ShiftLogicalRounded(demo, vcount));
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // 4、Vector saturating rounding shift left(饱和舍入指令): 
                // vqrshl -> ri = ai << bi;(negative values shift right) 
                // left shifts each element in a vector of integers and places the results in the destination vector.It is similar to VSHL. The difference is that the shifted value is rounded, and the sticky QC flag is set if saturation occurs.
                // 左移整数向量中的每个元素，并将结果放在目标向量中。它类似于VSHL。不同之处在于移位的值是四舍五入的，如果发生饱和，则设置粘滞QC标志。
                // ShiftLogicalRoundedSaturate(Vector128<Byte>, Vector128<SByte>)	uint8x16_t vqrshlq_u8 (uint8x16_t a, int8x16_t b); A32: VQRSHL.U8 Qd, Qn, Qm; A64: UQRSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftLogicalRoundedSaturate(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vqrshlq_u16 (uint16x8_t a, int16x8_t b); A32: VQRSHL.U16 Qd, Qn, Qm; A64: UQRSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftLogicalRoundedSaturate(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vqrshlq_u32 (uint32x4_t a, int32x4_t b); A32: VQRSHL.U32 Qd, Qn, Qm; A64: UQRSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftLogicalRoundedSaturate(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vqrshlq_u64 (uint64x2_t a, int64x2_t b); A32: VQRSHL.U64 Qd, Qn, Qm; A64: UQRSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftLogicalRoundedSaturate(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vqrshlq_u8 (uint8x16_t a, int8x16_t b); A32: VQRSHL.U8 Qd, Qn, Qm; A64: UQRSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftLogicalRoundedSaturate(Vector128<UInt16>, Vector128<Int16>)	uint16x8_t vqrshlq_u16 (uint16x8_t a, int16x8_t b); A32: VQRSHL.U16 Qd, Qn, Qm; A64: UQRSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftLogicalRoundedSaturate(Vector128<UInt32>, Vector128<Int32>)	uint32x4_t vqrshlq_u32 (uint32x4_t a, int32x4_t b); A32: VQRSHL.U32 Qd, Qn, Qm; A64: UQRSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftLogicalRoundedSaturate(Vector128<UInt64>, Vector128<Int64>)	uint64x2_t vqrshlq_u64 (uint64x2_t a, int64x2_t b); A32: VQRSHL.U64 Qd, Qn, Qm; A64: UQRSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftLogicalRoundedSaturate(Vector64<Byte>, Vector64<SByte>)	uint8x8_t vqrshl_u8 (uint8x8_t a, int8x8_t b); A32: VQRSHL.U8 Dd, Dn, Dm; A64: UQRSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftLogicalRoundedSaturate(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vqrshl_u16 (uint16x4_t a, int16x4_t b); A32: VQRSHL.U16 Dd, Dn, Dm; A64: UQRSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftLogicalRoundedSaturate(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vqrshl_u32 (uint32x2_t a, int32x2_t b); A32: VQRSHL.U32 Dd, Dn, Dm; A64: UQRSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftLogicalRoundedSaturate(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vqrshl_u8 (uint8x8_t a, int8x8_t b); A32: VQRSHL.U8 Dd, Dn, Dm; A64: UQRSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftLogicalRoundedSaturate(Vector64<UInt16>, Vector64<Int16>)	uint16x4_t vqrshl_u16 (uint16x4_t a, int16x4_t b); A32: VQRSHL.U16 Dd, Dn, Dm; A64: UQRSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftLogicalRoundedSaturate(Vector64<UInt32>, Vector64<Int32>)	uint32x2_t vqrshl_u32 (uint32x2_t a, int32x2_t b); A32: VQRSHL.U32 Dd, Dn, Dm; A64: UQRSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftLogicalRoundedSaturateScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vqrshl_u64 (uint64x1_t a, int64x1_t b); A32: VQRSHL.U64 Dd, Dn, Dm; A64: UQRSHL Dd, Dn, Dm
                // ShiftLogicalRoundedSaturateScalar(Vector64<UInt64>, Vector64<Int64>)	uint64x1_t vqrshl_u64 (uint64x1_t a, int64x1_t b); A32: VQRSHL.U64 Dd, Dn, Dm; A64: UQRSHL Dd, Dn, Dm
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftLogicalRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalRoundedSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<short> demo = Vector128.Create((short)elementNegative);
                        Vector128<short> vcount = Vector128.Create((short)15, 14, 1, 0, -1, -14, -15, -16);
                        WriteLine(writer, indent, "ShiftLogicalRoundedSaturate<short>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalRoundedSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<int> demo = Vector128.Create((int)elementNegative);
                        Vector128<int> vcount = Vector128.Create((int)31, 30, -31, -32);
                        WriteLine(writer, indent, "ShiftLogicalRoundedSaturate<int>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalRoundedSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<long> demo = Vector128.Create((long)elementNegative);
                        Vector128<long> vcount = Vector128.Create((long)63, -63);
                        WriteLine(writer, indent, "ShiftLogicalRoundedSaturate<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalRoundedSaturate(demo, vcount));
                        vcount = Vector128.Create((long)63, -64);
                        WriteLine(writer, indent, "ShiftLogicalRoundedSaturate<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalRoundedSaturate(demo, vcount));
                    }
                    if (true) {
                        // Try to go out of range.
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftLogicalRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalRoundedSaturate(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9);
                        WriteLine(writer, indent, "ShiftLogicalRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalRoundedSaturate(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9);
                        WriteLine(writer, indent, "ShiftLogicalRoundedSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalRoundedSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalRoundedSaturate(demo, vcount));
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // 2、Vector saturating shift left(饱和指令):  
                // vqshl -> ri = ai << bi;(negative values shift right) 
                // If the shift value is positive, the operation is a left shift. Otherwise, it is a truncating right shift. left shifts each element in a vector of integers and places the results in the destination vector. It is similar to VSHL.  
                // The difference is that the sticky QC flag is set if saturation occurs
                // 如果shift值为正，则操作为左移。否则，它就是截断右移。左移整数向量中的每个元素，并将结果放在目标向量中。它类似于VSHL。
                // 区别在于，如果发生饱和，则设置粘性QC标志
                // ShiftLogicalSaturate(Vector128<Byte>, Vector128<SByte>)	uint8x16_t vqshlq_u8 (uint8x16_t a, int8x16_t b); A32: VQSHL.U8 Qd, Qn, Qm; A64: UQSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftLogicalSaturate(Vector128<Int16>, Vector128<Int16>)	uint16x8_t vqshlq_u16 (uint16x8_t a, int16x8_t b); A32: VQSHL.U16 Qd, Qn, Qm; A64: UQSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftLogicalSaturate(Vector128<Int32>, Vector128<Int32>)	uint32x4_t vqshlq_u32 (uint32x4_t a, int32x4_t b); A32: VQSHL.U32 Qd, Qn, Qm; A64: UQSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftLogicalSaturate(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vqshlq_u64 (uint64x2_t a, int64x2_t b); A32: VQSHL.U64 Qd, Qn, Qm; A64: UQSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftLogicalSaturate(Vector128<SByte>, Vector128<SByte>)	uint8x16_t vqshlq_u8 (uint8x16_t a, int8x16_t b); A32: VQSHL.U8 Qd, Qn, Qm; A64: UQSHL Vd.16B, Vn.16B, Vm.16B
                // ShiftLogicalSaturate(Vector128<UInt16>, Vector128<Int16>)	uint16x8_t vqshlq_u16 (uint16x8_t a, int16x8_t b); A32: VQSHL.U16 Qd, Qn, Qm; A64: UQSHL Vd.8H, Vn.8H, Vm.8H
                // ShiftLogicalSaturate(Vector128<UInt32>, Vector128<Int32>)	uint32x4_t vqshlq_u32 (uint32x4_t a, int32x4_t b); A32: VQSHL.U32 Qd, Qn, Qm; A64: UQSHL Vd.4S, Vn.4S, Vm.4S
                // ShiftLogicalSaturate(Vector128<UInt64>, Vector128<Int64>)	uint64x2_t vqshlq_u64 (uint64x2_t a, int64x2_t b); A32: VQSHL.U64 Qd, Qn, Qm; A64: UQSHL Vd.2D, Vn.2D, Vm.2D
                // ShiftLogicalSaturate(Vector64<Byte>, Vector64<SByte>)	uint8x8_t vqshl_u8 (uint8x8_t a, int8x8_t b); A32: VQSHL.U8 Dd, Dn, Dm; A64: UQSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftLogicalSaturate(Vector64<Int16>, Vector64<Int16>)	uint16x4_t vqshl_u16 (uint16x4_t a, int16x4_t b); A32: VQSHL.U16 Dd, Dn, Dm; A64: UQSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftLogicalSaturate(Vector64<Int32>, Vector64<Int32>)	uint32x2_t vqshl_u32 (uint32x2_t a, int32x2_t b); A32: VQSHL.U32 Dd, Dn, Dm; A64: UQSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftLogicalSaturate(Vector64<SByte>, Vector64<SByte>)	uint8x8_t vqshl_u8 (uint8x8_t a, int8x8_t b); A32: VQSHL.U8 Dd, Dn, Dm; A64: UQSHL Vd.8B, Vn.8B, Vm.8B
                // ShiftLogicalSaturate(Vector64<UInt16>, Vector64<Int16>)	uint16x4_t vqshl_u16 (uint16x4_t a, int16x4_t b); A32: VQSHL.U16 Dd, Dn, Dm; A64: UQSHL Vd.4H, Vn.4H, Vm.4H
                // ShiftLogicalSaturate(Vector64<UInt32>, Vector64<Int32>)	uint32x2_t vqshl_u32 (uint32x2_t a, int32x2_t b); A32: VQSHL.U32 Dd, Dn, Dm; A64: UQSHL Vd.2S, Vn.2S, Vm.2S
                // ShiftLogicalSaturateScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vqshl_u64 (uint64x1_t a, int64x1_t b); A32: VQSHL.U64 Dd, Dn, Dm; A64: UQSHL Dd, Dn, Dm
                // ShiftLogicalSaturateScalar(Vector64<UInt64>, Vector64<Int64>)	uint64x1_t vqshl_u64 (uint64x1_t a, int64x1_t b); A32: VQSHL.U64 Dd, Dn, Dm; A64: UQSHL Dd, Dn, Dm
                try {
                    if (true) {
                        Vector128<sbyte> demo = Vector128.Create((sbyte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)7, 6, 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftLogicalSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<short> demo = Vector128.Create((short)elementNegative);
                        Vector128<short> vcount = Vector128.Create((short)15, 14, 1, 0, -1, -14, -15, -16);
                        WriteLine(writer, indent, "ShiftLogicalSaturate<short>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<int> demo = Vector128.Create((int)elementNegative);
                        Vector128<int> vcount = Vector128.Create((int)31, 30, -31, -32);
                        WriteLine(writer, indent, "ShiftLogicalSaturate<int>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalSaturate(demo, vcount));
                    }
                    if (true) {
                        Vector128<long> demo = Vector128.Create((long)elementNegative);
                        Vector128<long> vcount = Vector128.Create((long)63, -63);
                        WriteLine(writer, indent, "ShiftLogicalSaturate<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalSaturate(demo, vcount));
                        vcount = Vector128.Create((long)63, -64);
                        WriteLine(writer, indent, "ShiftLogicalSaturate<long>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalSaturate(demo, vcount));
                    }
                    if (true) {
                        // Try to go out of range.
                        Vector128<byte> demo = Vector128.Create((byte)elementNegative);
                        Vector128<sbyte> vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -4, -5, -6, -7, -8);
                        WriteLine(writer, indent, "ShiftLogicalSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalSaturate(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 6, 5, 3, 2, 1, 0, -1, -2, -3, -5, -6, -7, -8, -9);
                        WriteLine(writer, indent, "ShiftLogicalSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalSaturate(demo, vcount));
                        vcount = Vector128.Create((sbyte)8, 7, 16, 15, 3, 2, 1, 0, -1, -2, -3, -5, -16, -17, -8, -9);
                        WriteLine(writer, indent, "ShiftLogicalSaturate<sbyte>, demo={0}, vcount={1}", demo, vcount);
                        WriteLine(writer, indentNext, "ShiftLogicalSaturate(demo, serial):\t{0}", AdvSimd.ShiftLogicalSaturate(demo, vcount));
                    }
                } catch (Exception ex) {
                    writer.WriteLine(indent + ex.ToString());
                }

                // 1、Vector shift right and insert: vsri -> ; The two most significant bits in the  
                // destination vector are unchanged. right shifts each element in the second input vector by an immediate value, and inserts the results in the destination vector. It does not affect the highest n significant bits of the elements in the destination register. 
                // Bits shifted out of the right of each element are lost.The first input vector holds the elements of the destination vector before the operation is performed.
                // 目标向量不变。第二个输入向量中的每个元素右移一个直接值，并将结果插入到目标向量中。它不影响目标寄存器中元素的最高n位有效位。
                // 移出每个元素右侧的位将丢失。第一个输入向量保存执行操作之前目标向量的元素。
                // ShiftRightAndInsert(Vector128<Byte>, Vector128<Byte>, Byte)	uint8x16_t vsriq_n_u8(uint8x16_t a, uint8x16_t b, __builtin_constant_p(n)); A32: VSRI.8 Qd, Qm, #n; A64: SRI Vd.16B, Vn.16B, #n
                // ShiftRightAndInsert(Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vsriq_n_s16(int16x8_t a, int16x8_t b, __builtin_constant_p(n)); A32: VSRI.16 Qd, Qm, #n; A64: SRI Vd.8H, Vn.8H, #n
                // ShiftRightAndInsert(Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vsriq_n_s32(int32x4_t a, int32x4_t b, __builtin_constant_p(n)); A32: VSRI.32 Qd, Qm, #n; A64: SRI Vd.4S, Vn.4S, #n
                // ShiftRightAndInsert(Vector128<Int64>, Vector128<Int64>, Byte)	int64x2_t vsriq_n_s64(int64x2_t a, int64x2_t b, __builtin_constant_p(n)); A32: VSRI.64 Qd, Qm, #n; A64: SRI Vd.2D, Vn.2D, #n
                // ShiftRightAndInsert(Vector128<SByte>, Vector128<SByte>, Byte)	int8x16_t vsriq_n_s8(int8x16_t a, int8x16_t b, __builtin_constant_p(n)); A32: VSRI.8 Qd, Qm, #n; A64: SRI Vd.16B, Vn.16B, #n
                // ShiftRightAndInsert(Vector128<UInt16>, Vector128<UInt16>, Byte)	uint16x8_t vsriq_n_u16(uint16x8_t a, uint16x8_t b, __builtin_constant_p(n)); A32: VSRI.16 Qd, Qm, #n; A64: SRI Vd.8H, Vn.8H, #n
                // ShiftRightAndInsert(Vector128<UInt32>, Vector128<UInt32>, Byte)	uint32x4_t vsriq_n_u32(uint32x4_t a, uint32x4_t b, __builtin_constant_p(n)); A32: VSRI.32 Qd, Qm, #n; A64: SRI Vd.4S, Vn.4S, #n
                // ShiftRightAndInsert(Vector128<UInt64>, Vector128<UInt64>, Byte)	uint64x2_t vsriq_n_u64(uint64x2_t a, uint64x2_t b, __builtin_constant_p(n)); A32: VSRI.64 Qd, Qm, #n; A64: SRI Vd.2D, Vn.2D, #n
                // ShiftRightAndInsert(Vector64<Byte>, Vector64<Byte>, Byte)	uint8x8_t vsri_n_u8(uint8x8_t a, uint8x8_t b, __builtin_constant_p(n)); A32: VSRI.8 Dd, Dm, #n; A64: SRI Vd.8B, Vn.8B, #n
                // ShiftRightAndInsert(Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vsri_n_s16(int16x4_t a, int16x4_t b, __builtin_constant_p(n)); A32: VSRI.16 Dd, Dm, #n; A64: SRI Vd.4H, Vn.4H, #n
                // ShiftRightAndInsert(Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vsri_n_s32(int32x2_t a, int32x2_t b, __builtin_constant_p(n)); A32: VSRI.32 Dd, Dm, #n; A64: SRI Vd.2S, Vn.2S, #n
                // ShiftRightAndInsert(Vector64<SByte>, Vector64<SByte>, Byte)	int8x8_t vsri_n_s8(int8x8_t a, int8x8_t b, __builtin_constant_p(n)); A32: VSRI.8 Dd, Dm, #n; A64: SRI Vd.8B, Vn.8B, #n
                // ShiftRightAndInsert(Vector64<UInt16>, Vector64<UInt16>, Byte)	uint16x4_t vsri_n_u16(uint16x4_t a, uint16x4_t b, __builtin_constant_p(n)); A32: VSRI.16 Dd, Dm, #n; A64: SRI Vd.4H, Vn.4H, #n
                // ShiftRightAndInsert(Vector64<UInt32>, Vector64<UInt32>, Byte)	uint32x2_t vsri_n_u32(uint32x2_t a, uint32x2_t b, __builtin_constant_p(n)); A32: VSRI.32 Dd, Dm, #n; A64: SRI Vd.2S, Vn.2S, #n
                // ShiftRightAndInsertScalar(Vector64<Int64>, Vector64<Int64>, Byte)	int64_t vsrid_n_s64(int64_t a, int64_t b, __builtin_constant_p(n)) A32: VSRI.64 Dd, Dm, #n A64: SRI Dd, Dn, #n
                // ShiftRightAndInsertScalar(Vector64<UInt64>, Vector64<UInt64>, Byte)	uint64_t vsrid_n_u64(uint64_t a, uint64_t b, __builtin_constant_p(n)) A32: VSRI.64 Dd, Dm, #n A64: SRI Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    Vector128<sbyte> serial = Vector128s<sbyte>.Serial;
                    WriteLine(writer, indent, "ShiftRightAndInsert<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightAndInsert(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightAndInsert(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightAndInsert<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightAndInsert(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightAndInsert(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightAndInsert<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightAndInsert(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightAndInsert(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightAndInsert<long>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightAndInsert(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightAndInsert(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 1、Vector shift right by constant: vshr -> ri = ai >> b;The results are truncated. 
                // right shifts each element in a vector by an immediate value, and places the results in the destination vector
                // 将向量中的每个元素右移一个直接值，并将结果放在目标向量中.
                // ShiftRightArithmetic(Vector128<Int16>, Byte)	int16x8_t vshrq_n_s16 (int16x8_t a, const int n); A32: VSHR.S16 Qd, Qm, #n; A64: SSHR Vd.8H, Vn.8H, #n
                // ShiftRightArithmetic(Vector128<Int32>, Byte)	int32x4_t vshrq_n_s32 (int32x4_t a, const int n); A32: VSHR.S32 Qd, Qm, #n; A64: SSHR Vd.4S, Vn.4S, #n
                // ShiftRightArithmetic(Vector128<Int64>, Byte)	int64x2_t vshrq_n_s64 (int64x2_t a, const int n); A32: VSHR.S64 Qd, Qm, #n; A64: SSHR Vd.2D, Vn.2D, #n
                // ShiftRightArithmetic(Vector128<SByte>, Byte)	int8x16_t vshrq_n_s8 (int8x16_t a, const int n); A32: VSHR.S8 Qd, Qm, #n; A64: SSHR Vd.16B, Vn.16B, #n
                // ShiftRightArithmetic(Vector64<Int16>, Byte)	int16x4_t vshr_n_s16 (int16x4_t a, const int n); A32: VSHR.S16 Dd, Dm, #n; A64: SSHR Vd.4H, Vn.4H, #n
                // ShiftRightArithmetic(Vector64<Int32>, Byte)	int32x2_t vshr_n_s32 (int32x2_t a, const int n); A32: VSHR.S32 Dd, Dm, #n; A64: SSHR Vd.2S, Vn.2S, #n
                // ShiftRightArithmetic(Vector64<SByte>, Byte)	int8x8_t vshr_n_s8 (int8x8_t a, const int n); A32: VSHR.S8 Dd, Dm, #n; A64: SSHR Vd.8B, Vn.8B, #n
                // ShiftRightArithmeticScalar(Vector64<Int64>, Byte)	int64x1_t vshr_n_s64 (int64x1_t a, const int n); A32: VSHR.S64 Dd, Dm, #n; A64: SSHR Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmetic<sbyte>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmetic(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmetic(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmetic<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmetic(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmetic(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmetic<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmetic(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmetic(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmetic<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmetic(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmetic(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 4、Vector shift right by constant and accumulate: vsra -> ri = (ai >> c) + (bi >> c);  
                // The results are truncated. right shifts each element in a vector by an immediate value, and accumulates the results into the destination vector.
                // 结果被截断。将向量中的每个元素右移一个直接值，并将结果累加到目标向量中。
                // ShiftRightArithmeticAdd(Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vsraq_n_s16 (int16x8_t a, int16x8_t b, const int n); A32: VSRA.S16 Qd, Qm, #n; A64: SSRA Vd.8H, Vn.8H, #n
                // ShiftRightArithmeticAdd(Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vsraq_n_s32 (int32x4_t a, int32x4_t b, const int n); A32: VSRA.S32 Qd, Qm, #n; A64: SSRA Vd.4S, Vn.4S, #n
                // ShiftRightArithmeticAdd(Vector128<Int64>, Vector128<Int64>, Byte)	int64x2_t vsraq_n_s64 (int64x2_t a, int64x2_t b, const int n); A32: VSRA.S64 Qd, Qm, #n; A64: SSRA Vd.2D, Vn.2D, #n
                // ShiftRightArithmeticAdd(Vector128<SByte>, Vector128<SByte>, Byte)	int8x16_t vsraq_n_s8 (int8x16_t a, int8x16_t b, const int n); A32: VSRA.S8 Qd, Qm, #n; A64: SSRA Vd.16B, Vn.16B, #n
                // ShiftRightArithmeticAdd(Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vsra_n_s16 (int16x4_t a, int16x4_t b, const int n); A32: VSRA.S16 Dd, Dm, #n; A64: SSRA Vd.4H, Vn.4H, #n
                // ShiftRightArithmeticAdd(Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vsra_n_s32 (int32x2_t a, int32x2_t b, const int n); A32: VSRA.S32 Dd, Dm, #n; A64: SSRA Vd.2S, Vn.2S, #n
                // ShiftRightArithmeticAdd(Vector64<SByte>, Vector64<SByte>, Byte)	int8x8_t vsra_n_s8 (int8x8_t a, int8x8_t b, const int n); A32: VSRA.S8 Dd, Dm, #n; A64: SSRA Vd.8B, Vn.8B, #n
                // ShiftRightArithmeticAddScalar(Vector64<Int64>, Vector64<Int64>, Byte)	int64x1_t vsra_n_s64 (int64x1_t a, int64x1_t b, const int n); A32: VSRA.S64 Dd, Dm, #n; A64: SSRA Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    Vector128<sbyte> serial = Vector128s<sbyte>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticAdd<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticAdd<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticAdd<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticAdd<long>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 11、Vector narrowing saturating shift right by constant: vqshrn -> ri = ai >> b;  
                // Results are truncated. right shifts each element in a quadword vector of integers by an immediate value, and places the results in a doubleword vector, and the sticky QC flag is set if saturation occurs.
                // 结果被截断。右移四字整数向量中的每个元素，并将结果放在双字向量中，如果发生饱和，则设置粘性QC标志。
                // ShiftRightArithmeticNarrowingSaturateLower(Vector128<Int16>, Byte)	int8x8_t vqshrn_n_s16 (int16x8_t a, const int n); A32: VQSHRN.S16 Dd, Qm, #n; A64: SQSHRN Vd.8B, Vn.8H, #n
                // ShiftRightArithmeticNarrowingSaturateLower(Vector128<Int32>, Byte)	int16x4_t vqshrn_n_s32 (int32x4_t a, const int n); A32: VQSHRN.S32 Dd, Qm, #n; A64: SQSHRN Vd.4H, Vn.4S, #n
                // ShiftRightArithmeticNarrowingSaturateLower(Vector128<Int64>, Byte)	int32x2_t vqshrn_n_s64 (int64x2_t a, const int n); A32: VQSHRN.S64 Dd, Qm, #n; A64: SQSHRN Vd.2S, Vn.2D, #n
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateLower<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 9、Vector signed->unsigned narrowing saturating shift right by constant: vqshrun -> ri = ai >> b;  
                // Results are truncated. right shifts each element in a quadword vector of integers by an immediate value, and places the results in a doubleword vector. The results are unsigned, although the operands are signed. The sticky QC flag is set if saturation occurs.
                // 结果被截断。将四字整数向量中的每个元素右移一个直接值，并将结果放入双字向量中。结果是无符号的，尽管操作数是有符号的。如果发生饱和，则设置粘滞QC标志。
                // ShiftRightArithmeticNarrowingSaturateUnsignedLower(Vector128<Int16>, Byte)	uint8x8_t vqshrun_n_s16 (int16x8_t a, const int n); A32: VQSHRUN.S16 Dd, Qm, #n; A64: SQSHRUN Vd.8B, Vn.8H, #n
                // ShiftRightArithmeticNarrowingSaturateUnsignedLower(Vector128<Int32>, Byte)	uint16x4_t vqshrun_n_s32 (int32x4_t a, const int n); A32: VQSHRUN.S32 Dd, Qm, #n; A64: SQSHRUN Vd.4H, Vn.4S, #n
                // ShiftRightArithmeticNarrowingSaturateUnsignedLower(Vector128<Int64>, Byte)	uint32x2_t vqshrun_n_s64 (int64x2_t a, const int n); A32: VQSHRUN.S64 Dd, Qm, #n; A64: SQSHRUN Vd.2S, Vn.2D, #n
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUnsignedLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUnsignedLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUnsignedLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUnsignedLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUnsignedLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUnsignedLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUnsignedLower<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUnsignedLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUnsignedLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // ShiftRightArithmeticNarrowingSaturateUnsignedUpper(Vector64<Byte>, Vector128<Int16>, Byte)	uint8x16_t vqshrun_high_n_s16 (uint8x8_t r, int16x8_t a, const int n); A32: VQSHRUN.S16 Dd+1, Dn, #n; A64: SQSHRUN2 Vd.16B, Vn.8H, #n
                // ShiftRightArithmeticNarrowingSaturateUnsignedUpper(Vector64<UInt16>, Vector128<Int32>, Byte)	uint16x8_t vqshrun_high_n_s32 (uint16x4_t r, int32x4_t a, const int n); A32: VQSHRUN.S32 Dd+1, Dn, #n; A64: SQSHRUN2 Vd.8H, Vn.4S, #n
                // ShiftRightArithmeticNarrowingSaturateUnsignedUpper(Vector64<UInt32>, Vector128<Int64>, Byte)	uint32x4_t vqshrun_high_n_s64 (uint32x2_t r, int64x2_t a, const int n); A32: VQSHRUN.S64 Dd+1, Dn, #n; A64: SQSHRUN2 Vd.4S, Vn.2D, #n
                if (true) {
                    Vector64<byte> demo = Vector64s<byte>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUnsignedUpper<byte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUnsignedUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUnsignedUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<ushort> demo = Vector64s<ushort>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUnsignedUpper<ushort>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUnsignedUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUnsignedUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<uint> demo = Vector64s<uint>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUnsignedUpper<uint>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUnsignedUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUnsignedUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // ShiftRightArithmeticNarrowingSaturateUpper(Vector64<Int16>, Vector128<Int32>, Byte)	int16x8_t vqshrn_high_n_s32 (int16x4_t r, int32x4_t a, const int n); A32: VQSHRN.S32 Dd+1, Qm, #n; A64: SQSHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightArithmeticNarrowingSaturateUpper(Vector64<Int32>, Vector128<Int64>, Byte)	int32x4_t vqshrn_high_n_s64 (int32x2_t r, int64x2_t a, const int n); A32: VQSHRN.S64 Dd+1, Qm, #n; A64: SQSHRN2 Vd.4S, Vn.2D, #n
                // ShiftRightArithmeticNarrowingSaturateUpper(Vector64<SByte>, Vector128<Int16>, Byte)	int8x16_t vqshrn_high_n_s16 (int8x8_t r, int16x8_t a, const int n); A32: VQSHRN.S16 Dd+1, Qm, #n; A64: SQSHRN2 Vd.16B, Vn.8H, #n
                if (true) {
                    Vector64<sbyte> demo = Vector64s<sbyte>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUpper<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<short> demo = Vector64s<short>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUpper<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<int> demo = Vector64s<int>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticNarrowingSaturateUpper<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 3、Vector rounding shift right by constant: vrshr -> ri = ai >> b; 
                // right shifts each element in a vector by an immediate value, and places the results in the destination vector. The shifted values are rounded.
                // 将向量中的每个元素右移一个直接值，并将结果放在目标向量中。移位后的值四舍五入。
                // ShiftRightArithmeticRounded(Vector128<Int16>, Byte)	int16x8_t vrshrq_n_s16 (int16x8_t a, const int n); A32: VRSHR.S16 Qd, Qm, #n; A64: SRSHR Vd.8H, Vn.8H, #n
                // ShiftRightArithmeticRounded(Vector128<Int32>, Byte)	int32x4_t vrshrq_n_s32 (int32x4_t a, const int n); A32: VRSHR.S32 Qd, Qm, #n; A64: SRSHR Vd.4S, Vn.4S, #n
                // ShiftRightArithmeticRounded(Vector128<Int64>, Byte)	int64x2_t vrshrq_n_s64 (int64x2_t a, const int n); A32: VRSHR.S64 Qd, Qm, #n; A64: SRSHR Vd.2D, Vn.2D, #n
                // ShiftRightArithmeticRounded(Vector128<SByte>, Byte)	int8x16_t vrshrq_n_s8 (int8x16_t a, const int n); A32: VRSHR.S8 Qd, Qm, #n; A64: SRSHR Vd.16B, Vn.16B, #n
                // ShiftRightArithmeticRounded(Vector64<Int16>, Byte)	int16x4_t vrshr_n_s16 (int16x4_t a, const int n); A32: VRSHR.S16 Dd, Dm, #n; A64: SRSHR Vd.4H, Vn.4H, #n
                // ShiftRightArithmeticRounded(Vector64<Int32>, Byte)	int32x2_t vrshr_n_s32 (int32x2_t a, const int n); A32: VRSHR.S32 Dd, Dm, #n; A64: SRSHR Vd.2S, Vn.2S, #n
                // ShiftRightArithmeticRounded(Vector64<SByte>, Byte)	int8x8_t vrshr_n_s8 (int8x8_t a, const int n); A32: VRSHR.S8 Dd, Dm, #n; A64: SRSHR Vd.8B, Vn.8B, #n
                // ShiftRightArithmeticRoundedScalar(Vector64<Int64>, Byte)	int64x1_t vrshr_n_s64 (int64x1_t a, const int n); A32: VRSHR.S64 Dd, Dm, #n; A64: SRSHR Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRounded<sbyte>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRounded(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRounded(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRounded<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRounded(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRounded(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRounded<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRounded(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRounded(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRounded<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRounded(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRounded(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 5、Vector rounding shift right by constant and accumulate:  vrsra -> ri = (ai >> c) + (bi >> c); 
                // The results are rounded.right shifts each element in a vector by an immediate value, and accumulates the rounded results into the destination vector.
                // 结果是四舍五入的。将向量中的每个元素右移一个直接值，并将四舍五入的结果累加到目标向量中。            // ShiftRightArithmeticRoundedAdd(Vector128<Int16>, Vector128<Int16>, Byte)	int16x8_t vrsraq_n_s16 (int16x8_t a, int16x8_t b, const int n); A32: VRSRA.S16 Qd, Qm, #n; A64: SRSRA Vd.8H, Vn.8H, #n
                // ShiftRightArithmeticRoundedAdd(Vector128<Int32>, Vector128<Int32>, Byte)	int32x4_t vrsraq_n_s32 (int32x4_t a, int32x4_t b, const int n); A32: VRSRA.S32 Qd, Qm, #n; A64: SRSRA Vd.4S, Vn.4S, #n
                // ShiftRightArithmeticRoundedAdd(Vector128<Int64>, Vector128<Int64>, Byte)	int64x2_t vrsraq_n_s64 (int64x2_t a, int64x2_t b, const int n); A32: VRSRA.S64 Qd, Qm, #n; A64: SRSRA Vd.2D, Vn.2D, #n
                // ShiftRightArithmeticRoundedAdd(Vector128<SByte>, Vector128<SByte>, Byte)	int8x16_t vrsraq_n_s8 (int8x16_t a, int8x16_t b, const int n); A32: VRSRA.S8 Qd, Qm, #n; A64: SRSRA Vd.16B, Vn.16B, #n
                // ShiftRightArithmeticRoundedAdd(Vector64<Int16>, Vector64<Int16>, Byte)	int16x4_t vrsra_n_s16 (int16x4_t a, int16x4_t b, const int n); A32: VRSRA.S16 Dd, Dm, #n; A64: SRSRA Vd.4H, Vn.4H, #n
                // ShiftRightArithmeticRoundedAdd(Vector64<Int32>, Vector64<Int32>, Byte)	int32x2_t vrsra_n_s32 (int32x2_t a, int32x2_t b, const int n); A32: VRSRA.S32 Dd, Dm, #n; A64: SRSRA Vd.2S, Vn.2S, #n
                // ShiftRightArithmeticRoundedAdd(Vector64<SByte>, Vector64<SByte>, Byte)	int8x8_t vrsra_n_s8 (int8x8_t a, int8x8_t b, const int n); A32: VRSRA.S8 Dd, Dm, #n; A64: SRSRA Vd.8B, Vn.8B, #n
                // ShiftRightArithmeticRoundedAddScalar(Vector64<Int64>, Vector64<Int64>, Byte)	int64x1_t vrsra_n_s64 (int64x1_t a, int64x1_t b, const int n); A32: VRSRA.S64 Dd, Dm, #n; A64: SRSRA Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    Vector128<sbyte> serial = Vector128s<sbyte>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedAdd<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedAdd<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedAdd<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedAdd<long>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 13、Vector rounding narrowing saturating shift right by constant: vqrshrn -> ri = ai >> b; 
                // Results are rounded. right shifts each element in a quadword vector of integers by an immediate value,and places the rounded,narrowed results in a doubleword vector.  
                // 结果四舍五入。将四字整数向量中的每个元素右移一个直接值，并将四舍五入、缩小的结果放在双字向量中。
                // ShiftRightArithmeticRoundedNarrowingSaturateLower(Vector128<Int16>, Byte)	int8x8_t vqrshrn_n_s16 (int16x8_t a, const int n); A32: VQRSHRN.S16 Dd, Qm, #n; A64: SQRSHRN Vd.8B, Vn.8H, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateLower(Vector128<Int32>, Byte)	int16x4_t vqrshrn_n_s32 (int32x4_t a, const int n); A32: VQRSHRN.S32 Dd, Qm, #n; A64: SQRSHRN Vd.4H, Vn.4S, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateLower(Vector128<Int64>, Byte)	int32x2_t vqrshrn_n_s64 (int64x2_t a, const int n); A32: VQRSHRN.S64 Dd, Qm, #n; A64: SQRSHRN Vd.2S, Vn.2D, #n
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateLower<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 10、Vector signed->unsigned rounding narrowing saturating shift right by constant:  vqrshrun -> ri = ai >> b;
                // Results are rounded. right shifts each element in a quadword vector of integers by an immediate value, and places the rounded results in a doubleword vector. The results are unsigned, although the operands are signed.
                // 结果四舍五入。将四字整数向量中的每个元素右移一个直接值，并将四舍五入的结果放在双字向量中。结果是无符号的，尽管操作数是有符号的。            // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(Vector128<Int16>, Byte)	uint8x8_t vqrshrun_n_s16 (int16x8_t a, const int n); A32: VQRSHRUN.S16 Dd, Qm, #n; A64: SQRSHRUN Vd.8B, Vn.8H, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(Vector128<Int32>, Byte)	uint16x4_t vqrshrun_n_s32 (int32x4_t a, const int n); A32: VQRSHRUN.S32 Dd, Qm, #n; A64: SQRSHRUN Vd.4H, Vn.4S, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(Vector128<Int64>, Byte)	uint32x2_t vqrshrun_n_s64 (int64x2_t a, const int n); A32: VQRSHRUN.S64 Dd, Qm, #n; A64: SQRSHRUN Vd.2S, Vn.2D, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper(Vector64<Byte>, Vector128<Int16>, Byte)	uint8x16_t vqrshrun_high_n_s16 (uint8x8_t r, int16x8_t a, const int n); A32: VQRSHRUN.S16 Dd+1, Dn, #n; A64: SQRSHRUN2 Vd.16B, Vn.8H, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper(Vector64<UInt16>, Vector128<Int32>, Byte)	uint16x8_t vqrshrun_high_n_s32 (uint16x4_t r, int32x4_t a, const int n); A32: VQRSHRUN.S32 Dd+1, Dn, #n; A64: SQRSHRUN2 Vd.8H, Vn.4S, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUnsignedUpper(Vector64<UInt32>, Vector128<Int64>, Byte)	uint32x4_t vqrshrun_high_n_s64 (uint32x2_t r, int64x2_t a, const int n); A32: VQRSHRUN.S64 Dd+1, Dn, #n; A64: SQRSHRUN2 Vd.4S, Vn.2D, #n
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(demo, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateUnsignedLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // ShiftRightArithmeticRoundedNarrowingSaturateUpper(Vector64<Int16>, Vector128<Int32>, Byte)	int16x8_t vqrshrn_high_n_s32 (int16x4_t r, int32x4_t a, const int n); A32: VQRSHRN.S32 Dd+1, Dn, #n; A64: SQRSHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUpper(Vector64<Int32>, Vector128<Int64>, Byte)	int32x4_t vqrshrn_high_n_s64 (int32x2_t r, int64x2_t a, const int n); A32: VQRSHRN.S64 Dd+1, Dn, #n; A64: SQRSHRN2 Vd.4S, Vn.2D, #n
                // ShiftRightArithmeticRoundedNarrowingSaturateUpper(Vector64<SByte>, Vector128<Int16>, Byte)	int8x16_t vqrshrn_high_n_s16 (int8x8_t r, int16x8_t a, const int n); A32: VQRSHRN.S16 Dd+1, Dn, #n; A64: SQRSHRN2 Vd.16B, Vn.8H, #n
                if (true) {
                    Vector64<sbyte> demo = Vector64s<sbyte>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateUpper<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<short> demo = Vector64s<short>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateUpper<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<int> demo = Vector64s<int>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightArithmeticRoundedNarrowingSaturateUpper<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightArithmeticRoundedNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightArithmeticRoundedNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 1、Vector shift right by constant: vshr -> ri = ai >> b;The results are truncated. 
                // right shifts each element in a vector by an immediate value, and places the results in the destination vector
                // 将向量中的每个元素右移一个直接值，并将结果放在目标向量中.
                // ShiftRightLogical(Vector128<Byte>, Byte)	uint8x16_t vshrq_n_u8 (uint8x16_t a, const int n); A32: VSHR.U8 Qd, Qm, #n; A64: USHR Vd.16B, Vn.16B, #n
                // ShiftRightLogical(Vector128<Int16>, Byte)	uint16x8_t vshrq_n_u16 (uint16x8_t a, const int n); A32: VSHR.U16 Qd, Qm, #n; A64: USHR Vd.8H, Vn.8H, #n
                // ShiftRightLogical(Vector128<Int32>, Byte)	uint32x4_t vshrq_n_u32 (uint32x4_t a, const int n); A32: VSHR.U32 Qd, Qm, #n; A64: USHR Vd.4S, Vn.4S, #n
                // ShiftRightLogical(Vector128<Int64>, Byte)	uint64x2_t vshrq_n_u64 (uint64x2_t a, const int n); A32: VSHR.U64 Qd, Qm, #n; A64: USHR Vd.2D, Vn.2D, #n
                // ShiftRightLogical(Vector128<SByte>, Byte)	uint8x16_t vshrq_n_u8 (uint8x16_t a, const int n); A32: VSHR.U8 Qd, Qm, #n; A64: USHR Vd.16B, Vn.16B, #n
                // ShiftRightLogical(Vector128<UInt16>, Byte)	uint16x8_t vshrq_n_u16 (uint16x8_t a, const int n); A32: VSHR.U16 Qd, Qm, #n; A64: USHR Vd.8H, Vn.8H, #n
                // ShiftRightLogical(Vector128<UInt32>, Byte)	uint32x4_t vshrq_n_u32 (uint32x4_t a, const int n); A32: VSHR.U32 Qd, Qm, #n; A64: USHR Vd.4S, Vn.4S, #n
                // ShiftRightLogical(Vector128<UInt64>, Byte)	uint64x2_t vshrq_n_u64 (uint64x2_t a, const int n); A32: VSHR.U64 Qd, Qm, #n; A64: USHR Vd.2D, Vn.2D, #n
                // ShiftRightLogical(Vector64<Byte>, Byte)	uint8x8_t vshr_n_u8 (uint8x8_t a, const int n); A32: VSHR.U8 Dd, Dm, #n; A64: USHR Vd.8B, Vn.8B, #n
                // ShiftRightLogical(Vector64<Int16>, Byte)	uint16x4_t vshr_n_u16 (uint16x4_t a, const int n); A32: VSHR.U16 Dd, Dm, #n; A64: USHR Vd.4H, Vn.4H, #n
                // ShiftRightLogical(Vector64<Int32>, Byte)	uint32x2_t vshr_n_u32 (uint32x2_t a, const int n); A32: VSHR.U32 Dd, Dm, #n; A64: USHR Vd.2S, Vn.2S, #n
                // ShiftRightLogical(Vector64<SByte>, Byte)	uint8x8_t vshr_n_u8 (uint8x8_t a, const int n); A32: VSHR.U8 Dd, Dm, #n; A64: USHR Vd.8B, Vn.8B, #n
                // ShiftRightLogical(Vector64<UInt16>, Byte)	uint16x4_t vshr_n_u16 (uint16x4_t a, const int n); A32: VSHR.U16 Dd, Dm, #n; A64: USHR Vd.4H, Vn.4H, #n
                // ShiftRightLogical(Vector64<UInt32>, Byte)	uint32x2_t vshr_n_u32 (uint32x2_t a, const int n); A32: VSHR.U32 Dd, Dm, #n; A64: USHR Vd.2S, Vn.2S, #n
                // ShiftRightLogicalScalar(Vector64<Int64>, Byte)	uint64x1_t vshr_n_u64 (uint64x1_t a, const int n); A32: VSHR.U64 Dd, Dm, #n; A64: USHR Dd, Dn, #n
                // ShiftRightLogicalScalar(Vector64<UInt64>, Byte)	uint64x1_t vshr_n_u64 (uint64x1_t a, const int n); A32: VSHR.U64 Dd, Dm, #n; A64: USHR Dd, Dn, #n
                if (true) {
                    Vector128<byte> demo = Vector128s<byte>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogical<byte>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogical(demo, {1}):\t{0}", AdvSimd.ShiftRightLogical(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<ushort> demo = Vector128s<ushort>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogical<ushort>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogical(demo, {1}):\t{0}", AdvSimd.ShiftRightLogical(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<uint> demo = Vector128s<uint>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogical<uint>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogical(demo, {1}):\t{0}", AdvSimd.ShiftRightLogical(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<ulong> demo = Vector128s<ulong>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogical<ulong>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogical(demo, {1}):\t{0}", AdvSimd.ShiftRightLogical(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 4、Vector shift right by constant and accumulate: vsra -> ri = (ai >> c) + (bi >> c);  
                // The results are truncated. right shifts each element in a vector by an immediate value, and accumulates the results into the destination vector.
                // 结果被截断。将向量中的每个元素右移一个直接值，并将结果累加到目标向量中。
                // ShiftRightLogicalAdd(Vector128<Byte>, Vector128<Byte>, Byte)	uint8x16_t vsraq_n_u8 (uint8x16_t a, uint8x16_t b, const int n); A32: VSRA.U8 Qd, Qm, #n; A64: USRA Vd.16B, Vn.16B, #n
                // ShiftRightLogicalAdd(Vector128<Int16>, Vector128<Int16>, Byte)	uint16x8_t vsraq_n_u16 (uint16x8_t a, uint16x8_t b, const int n); A32: VSRA.U16 Qd, Qm, #n; A64: USRA Vd.8H, Vn.8H, #n
                // ShiftRightLogicalAdd(Vector128<Int32>, Vector128<Int32>, Byte)	uint32x4_t vsraq_n_u32 (uint32x4_t a, uint32x4_t b, const int n); A32: VSRA.U32 Qd, Qm, #n; A64: USRA Vd.4S, Vn.4S, #n
                // ShiftRightLogicalAdd(Vector128<Int64>, Vector128<Int64>, Byte)	uint64x2_t vsraq_n_u64 (uint64x2_t a, uint64x2_t b, const int n); A32: VSRA.U64 Qd, Qm, #n; A64: USRA Vd.2D, Vn.2D, #n
                // ShiftRightLogicalAdd(Vector128<SByte>, Vector128<SByte>, Byte)	uint8x16_t vsraq_n_u8 (uint8x16_t a, uint8x16_t b, const int n); A32: VSRA.U8 Qd, Qm, #n; A64: USRA Vd.16B, Vn.16B, #n
                // ShiftRightLogicalAdd(Vector128<UInt16>, Vector128<UInt16>, Byte)	uint16x8_t vsraq_n_u16 (uint16x8_t a, uint16x8_t b, const int n); A32: VSRA.U16 Qd, Qm, #n; A64: USRA Vd.8H, Vn.8H, #n
                // ShiftRightLogicalAdd(Vector128<UInt32>, Vector128<UInt32>, Byte)	uint32x4_t vsraq_n_u32 (uint32x4_t a, uint32x4_t b, const int n); A32: VSRA.U32 Qd, Qm, #n; A64: USRA Vd.4S, Vn.4S, #n
                // ShiftRightLogicalAdd(Vector128<UInt64>, Vector128<UInt64>, Byte)	uint64x2_t vsraq_n_u64 (uint64x2_t a, uint64x2_t b, const int n); A32: VSRA.U64 Qd, Qm, #n; A64: USRA Vd.2D, Vn.2D, #n
                // ShiftRightLogicalAdd(Vector64<Byte>, Vector64<Byte>, Byte)	uint8x8_t vsra_n_u8 (uint8x8_t a, uint8x8_t b, const int n); A32: VSRA.U8 Dd, Dm, #n; A64: USRA Vd.8B, Vn.8B, #n
                // ShiftRightLogicalAdd(Vector64<Int16>, Vector64<Int16>, Byte)	uint16x4_t vsra_n_u16 (uint16x4_t a, uint16x4_t b, const int n); A32: VSRA.U16 Dd, Dm, #n; A64: USRA Vd.4H, Vn.4H, #n
                // ShiftRightLogicalAdd(Vector64<Int32>, Vector64<Int32>, Byte)	uint32x2_t vsra_n_u32 (uint32x2_t a, uint32x2_t b, const int n); A32: VSRA.U32 Dd, Dm, #n; A64: USRA Vd.2S, Vn.2S, #n
                // ShiftRightLogicalAdd(Vector64<SByte>, Vector64<SByte>, Byte)	uint8x8_t vsra_n_u8 (uint8x8_t a, uint8x8_t b, const int n); A32: VSRA.U8 Dd, Dm, #n; A64: USRA Vd.8B, Vn.8B, #n
                // ShiftRightLogicalAdd(Vector64<UInt16>, Vector64<UInt16>, Byte)	uint16x4_t vsra_n_u16 (uint16x4_t a, uint16x4_t b, const int n); A32: VSRA.U16 Dd, Dm, #n; A64: USRA Vd.4H, Vn.4H, #n
                // ShiftRightLogicalAdd(Vector64<UInt32>, Vector64<UInt32>, Byte)	uint32x2_t vsra_n_u32 (uint32x2_t a, uint32x2_t b, const int n); A32: VSRA.U32 Dd, Dm, #n; A64: USRA Vd.2S, Vn.2S, #n
                // ShiftRightLogicalAddScalar(Vector64<Int64>, Vector64<Int64>, Byte)	uint64x1_t vsra_n_u64 (uint64x1_t a, uint64x1_t b, const int n); A32: VSRA.U64 Dd, Dm, #n; A64: USRA Dd, Dn, #n
                // ShiftRightLogicalAddScalar(Vector64<UInt64>, Vector64<UInt64>, Byte)	uint64x1_t vsra_n_u64 (uint64x1_t a, uint64x1_t b, const int n); A32: VSRA.U64 Dd, Dm, #n; A64: USRA Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    Vector128<sbyte> serial = Vector128s<sbyte>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalAdd<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalAdd<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalAdd<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalAdd<long>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 8、Vector narrowing shift right by constant: vshrn -> ri = ai >> b; 
                // The results are truncated.right shifts each element in the input vector by an immediate value. It then narrows the result by storing only the least significant half of each element into the destination vector.
                // 结果被截断。将输入向量中的每个元素右移一个直接值。然后，它通过只将每个元素的最不重要的一半存储到目标向量中来缩小结果。
                // ShiftRightLogicalNarrowingLower(Vector128<Int16>, Byte)	int8x8_t vshrn_n_s16 (int16x8_t a, const int n); A32: VSHRN.I16 Dd, Qm, #n; A64: SHRN Vd.8B, Vn.8H, #n
                // ShiftRightLogicalNarrowingLower(Vector128<Int32>, Byte)	int16x4_t vshrn_n_s32 (int32x4_t a, const int n); A32: VSHRN.I32 Dd, Qm, #n; A64: SHRN Vd.4H, Vn.4S, #n
                // ShiftRightLogicalNarrowingLower(Vector128<Int64>, Byte)	int32x2_t vshrn_n_s64 (int64x2_t a, const int n); A32: VSHRN.I64 Dd, Qm, #n; A64: SHRN Vd.2S, Vn.2D, #n
                // ShiftRightLogicalNarrowingLower(Vector128<UInt16>, Byte)	uint8x8_t vshrn_n_u16 (uint16x8_t a, const int n); A32: VSHRN.I16 Dd, Qm, #n; A64: SHRN Vd.8B, Vn.8H, #n
                // ShiftRightLogicalNarrowingLower(Vector128<UInt32>, Byte)	uint16x4_t vshrn_n_u32 (uint32x4_t a, const int n); A32: VSHRN.I32 Dd, Qm, #n; A64: SHRN Vd.4H, Vn.4S, #n
                // ShiftRightLogicalNarrowingLower(Vector128<UInt64>, Byte)	uint32x2_t vshrn_n_u64 (uint64x2_t a, const int n); A32: VSHRN.I64 Dd, Qm, #n; A64: SHRN Vd.2S, Vn.2D, #n
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingLower<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 11、Vector narrowing saturating shift right by constant: vqshrn -> ri = ai >> b;  
                // Results are truncated. right shifts each element in a quadword vector of integers by an immediate value, and places the results in a doubleword vector, and the sticky QC flag is set if saturation occurs.
                // 结果被截断。右移四字整数向量中的每个元素，并将结果放在双字向量中，如果发生饱和，则设置粘性QC标志。
                // ShiftRightLogicalNarrowingSaturateLower(Vector128<Int16>, Byte)	uint8x8_t vqshrn_n_u16 (uint16x8_t a, const int n); A32: VQSHRN.U16 Dd, Qm, #n; A64: UQSHRN Vd.8B, Vn.8H, #n
                // ShiftRightLogicalNarrowingSaturateLower(Vector128<Int32>, Byte)	uint16x4_t vqshrn_n_u32 (uint32x4_t a, const int n); A32: VQSHRN.U32 Dd, Qm, #n; A64: UQSHRN Vd.4H, Vn.4S, #n
                // ShiftRightLogicalNarrowingSaturateLower(Vector128<Int64>, Byte)	uint32x2_t vqshrn_n_u64 (uint64x2_t a, const int n); A32: VQSHRN.U64 Dd, Qm, #n; A64: UQSHRN Vd.2S, Vn.2D, #n
                // ShiftRightLogicalNarrowingSaturateLower(Vector128<UInt16>, Byte)	uint8x8_t vqshrn_n_u16 (uint16x8_t a, const int n); A32: VQSHRN.U16 Dd, Qm, #n; A64: UQSHRN Vd.8B, Vn.8H, #n
                // ShiftRightLogicalNarrowingSaturateLower(Vector128<UInt32>, Byte)	uint16x4_t vqshrn_n_u32 (uint32x4_t a, const int n); A32: VQSHRN.U32 Dd, Qm, #n; A64: UQSHRN Vd.4H, Vn.4S, #n
                // ShiftRightLogicalNarrowingSaturateLower(Vector128<UInt64>, Byte)	uint32x2_t vqshrn_n_u64 (uint64x2_t a, const int n); A32: VQSHRN.U64 Dd, Qm, #n; A64: UQSHRN Vd.2S, Vn.2D, #n
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingSaturateLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingSaturateLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingSaturateLower<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // ShiftRightLogicalNarrowingSaturateUpper(Vector64<Byte>, Vector128<UInt16>, Byte)	uint8x16_t vqshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n); A32: VQSHRN.U16 Dd+1, Qm, #n; A64: UQSHRN2 Vd.16B, Vn.8H, #n
                // ShiftRightLogicalNarrowingSaturateUpper(Vector64<Int16>, Vector128<Int32>, Byte)	uint16x8_t vqshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n); A32: VQSHRN.U32 Dd+1, Qm, #n; A64: UQSHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightLogicalNarrowingSaturateUpper(Vector64<Int32>, Vector128<Int64>, Byte)	uint32x4_t vqshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n); A32: VQSHRN.U64 Dd+1, Qm, #n; A64: UQSHRN2 Vd.4S, Vn.2D, #n
                // ShiftRightLogicalNarrowingSaturateUpper(Vector64<SByte>, Vector128<Int16>, Byte)	uint8x16_t vqshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n); A32: VQSHRN.U16 Dd+1, Qm, #n; A64: UQSHRN2 Vd.16B, Vn.8H, #n
                // ShiftRightLogicalNarrowingSaturateUpper(Vector64<UInt16>, Vector128<UInt32>, Byte)	uint16x8_t vqshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n); A32: VQSHRN.U32 Dd+1, Qm, #n; A64: UQSHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightLogicalNarrowingSaturateUpper(Vector64<UInt32>, Vector128<UInt64>, Byte)	uint32x4_t vqshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n); A32: VQSHRN.U64 Dd+1, Qm, #n; A64: UQSHRN2 Vd.4S, Vn.2D, #n
                if (true) {
                    Vector64<sbyte> demo = Vector64s<sbyte>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingSaturateUpper<byte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<short> demo = Vector64s<short>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingSaturateUpper<ushort>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<int> demo = Vector64s<int>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingSaturateUpper<uint>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // ShiftRightLogicalNarrowingUpper(Vector64<Byte>, Vector128<UInt16>, Byte)	uint8x16_t vshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n); A32: VSHRN.I16 Dd+1, Qm, #n; A64: SHRN2 Vd.16B, Vn.8H, #n
                // ShiftRightLogicalNarrowingUpper(Vector64<Int16>, Vector128<Int32>, Byte)	int16x8_t vshrn_high_n_s32 (int16x4_t r, int32x4_t a, const int n); A32: VSHRN.I32 Dd+1, Qm, #n; A64: SHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightLogicalNarrowingUpper(Vector64<Int32>, Vector128<Int64>, Byte)	int32x4_t vshrn_high_n_s64 (int32x2_t r, int64x2_t a, const int n); A32: VSHRN.I64 Dd+1, Qm, #n; A64: SHRN2 Vd.4S, Vn.2D, #n
                // ShiftRightLogicalNarrowingUpper(Vector64<SByte>, Vector128<Int16>, Byte)	int8x16_t vshrn_high_n_s16 (int8x8_t r, int16x8_t a, const int n); A32: VSHRN.I16 Dd+1, Qm, #n; A64: SHRN2 Vd.16B, Vn.8H, #n
                // ShiftRightLogicalNarrowingUpper(Vector64<UInt16>, Vector128<UInt32>, Byte)	uint16x8_t vshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n); A32: VSHRN.I32 Dd+1, Qm, #n; A64: SHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightLogicalNarrowingUpper(Vector64<UInt32>, Vector128<UInt64>, Byte)	uint32x4_t vshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n); A32: VSHRN.I64 Dd+1, Qm, #n; A64: SHRN2 Vd.4S, Vn.2D, #n
                if (true) {
                    Vector64<sbyte> demo = Vector64s<sbyte>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingUpper<byte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<short> demo = Vector64s<short>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingUpper<ushort>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<int> demo = Vector64s<int>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalNarrowingUpper<uint>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalNarrowingUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalNarrowingUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 3、Vector rounding shift right by constant: vrshr -> ri = ai >> b; 
                // right shifts each element in a vector by an immediate value, and places the results in the destination vector. The shifted values are rounded.
                // 将向量中的每个元素右移一个直接值，并将结果放在目标向量中。移位后的值四舍五入。
                // ShiftRightLogicalRounded(Vector128<Byte>, Byte)	uint8x16_t vrshrq_n_u8 (uint8x16_t a, const int n); A32: VRSHR.U8 Qd, Qm, #n; A64: URSHR Vd.16B, Vn.16B, #n
                // ShiftRightLogicalRounded(Vector128<Int16>, Byte)	uint16x8_t vrshrq_n_u16 (uint16x8_t a, const int n); A32: VRSHR.U16 Qd, Qm, #n; A64: URSHR Vd.8H, Vn.8H, #n
                // ShiftRightLogicalRounded(Vector128<Int32>, Byte)	uint32x4_t vrshrq_n_u32 (uint32x4_t a, const int n); A32: VRSHR.U32 Qd, Qm, #n; A64: URSHR Vd.4S, Vn.4S, #n
                // ShiftRightLogicalRounded(Vector128<Int64>, Byte)	uint64x2_t vrshrq_n_u64 (uint64x2_t a, const int n); A32: VRSHR.U64 Qd, Qm, #n; A64: URSHR Vd.2D, Vn.2D, #n
                // ShiftRightLogicalRounded(Vector128<SByte>, Byte)	uint8x16_t vrshrq_n_u8 (uint8x16_t a, const int n); A32: VRSHR.U8 Qd, Qm, #n; A64: URSHR Vd.16B, Vn.16B, #n
                // ShiftRightLogicalRounded(Vector128<UInt16>, Byte)	uint16x8_t vrshrq_n_u16 (uint16x8_t a, const int n); A32: VRSHR.U16 Qd, Qm, #n; A64: URSHR Vd.8H, Vn.8H, #n
                // ShiftRightLogicalRounded(Vector128<UInt32>, Byte)	uint32x4_t vrshrq_n_u32 (uint32x4_t a, const int n); A32: VRSHR.U32 Qd, Qm, #n; A64: URSHR Vd.4S, Vn.4S, #n
                // ShiftRightLogicalRounded(Vector128<UInt64>, Byte)	uint64x2_t vrshrq_n_u64 (uint64x2_t a, const int n); A32: VRSHR.U64 Qd, Qm, #n; A64: URSHR Vd.2D, Vn.2D, #n
                // ShiftRightLogicalRounded(Vector64<Byte>, Byte)	uint8x8_t vrshr_n_u8 (uint8x8_t a, const int n); A32: VRSHR.U8 Dd, Dm, #n; A64: URSHR Vd.8B, Vn.8B, #n
                // ShiftRightLogicalRounded(Vector64<Int16>, Byte)	uint16x4_t vrshr_n_u16 (uint16x4_t a, const int n); A32: VRSHR.U16 Dd, Dm, #n; A64: URSHR Vd.4H, Vn.4H, #n
                // ShiftRightLogicalRounded(Vector64<Int32>, Byte)	uint32x2_t vrshr_n_u32 (uint32x2_t a, const int n); A32: VRSHR.U32 Dd, Dm, #n; A64: URSHR Vd.2S, Vn.2S, #n
                // ShiftRightLogicalRounded(Vector64<SByte>, Byte)	uint8x8_t vrshr_n_u8 (uint8x8_t a, const int n); A32: VRSHR.U8 Dd, Dm, #n; A64: URSHR Vd.8B, Vn.8B, #n
                // ShiftRightLogicalRounded(Vector64<UInt16>, Byte)	uint16x4_t vrshr_n_u16 (uint16x4_t a, const int n); A32: VRSHR.U16 Dd, Dm, #n; A64: URSHR Vd.4H, Vn.4H, #n
                // ShiftRightLogicalRounded(Vector64<UInt32>, Byte)	uint32x2_t vrshr_n_u32 (uint32x2_t a, const int n); A32: VRSHR.U32 Dd, Dm, #n; A64: URSHR Vd.2S, Vn.2S, #n
                // ShiftRightLogicalRoundedScalar(Vector64<Int64>, Byte)	uint64x1_t vrshr_n_u64 (uint64x1_t a, const int n); A32: VRSHR.U64 Dd, Dm, #n; A64: URSHR Dd, Dn, #n
                // ShiftRightLogicalRoundedScalar(Vector64<UInt64>, Byte)	uint64x1_t vrshr_n_u64 (uint64x1_t a, const int n); A32: VRSHR.U64 Dd, Dm, #n; A64: URSHR Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRounded<sbyte>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRounded(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRounded(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRounded<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRounded(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRounded(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRounded<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRounded(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRounded(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRounded<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRounded(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRounded(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 5、Vector rounding shift right by constant and accumulate:  
                // vrsra -> ri = (ai >> c) + (bi >> c); 
                // The results are rounded.right shifts each element in a vector by an immediate value, and accumulates the rounded results into the destination vector.
                // 结果是四舍五入的。将向量中的每个元素右移一个直接值，并将四舍五入的结果累加到目标向量中。
                // ShiftRightLogicalRoundedAdd(Vector128<Byte>, Vector128<Byte>, Byte)	uint8x16_t vrsraq_n_u8 (uint8x16_t a, uint8x16_t b, const int n); A32: VRSRA.U8 Qd, Qm, #n; A64: URSRA Vd.16B, Vn.16B, #n
                // ShiftRightLogicalRoundedAdd(Vector128<Int16>, Vector128<Int16>, Byte)	uint16x8_t vrsraq_n_u16 (uint16x8_t a, uint16x8_t b, const int n); A32: VRSRA.U16 Qd, Qm, #n; A64: URSRA Vd.8H, Vn.8H, #n
                // ShiftRightLogicalRoundedAdd(Vector128<Int32>, Vector128<Int32>, Byte)	uint32x4_t vrsraq_n_u32 (uint32x4_t a, uint32x4_t b, const int n); A32: VRSRA.U32 Qd, Qm, #n; A64: URSRA Vd.4S, Vn.4S, #n
                // ShiftRightLogicalRoundedAdd(Vector128<Int64>, Vector128<Int64>, Byte)	uint64x2_t vrsraq_n_u64 (uint64x2_t a, uint64x2_t b, const int n); A32: VRSRA.U64 Qd, Qm, #n; A64: URSRA Vd.2D, Vn.2D, #n
                // ShiftRightLogicalRoundedAdd(Vector128<SByte>, Vector128<SByte>, Byte)	uint8x16_t vrsraq_n_u8 (uint8x16_t a, uint8x16_t b, const int n); A32: VRSRA.U8 Qd, Qm, #n; A64: URSRA Vd.16B, Vn.16B, #n
                // ShiftRightLogicalRoundedAdd(Vector128<UInt16>, Vector128<UInt16>, Byte)	uint16x8_t vrsraq_n_u16 (uint16x8_t a, uint16x8_t b, const int n); A32: VRSRA.U16 Qd, Qm, #n; A64: URSRA Vd.8H, Vn.8H, #n
                // ShiftRightLogicalRoundedAdd(Vector128<UInt32>, Vector128<UInt32>, Byte)	uint32x4_t vrsraq_n_u32 (uint32x4_t a, uint32x4_t b, const int n); A32: VRSRA.U32 Qd, Qm, #n; A64: URSRA Vd.4S, Vn.4S, #n
                // ShiftRightLogicalRoundedAdd(Vector128<UInt64>, Vector128<UInt64>, Byte)	uint64x2_t vrsraq_n_u64 (uint64x2_t a, uint64x2_t b, const int n); A32: VRSRA.U64 Qd, Qm, #n; A64: URSRA Vd.2D, Vn.2D, #n
                // ShiftRightLogicalRoundedAdd(Vector64<Byte>, Vector64<Byte>, Byte)	uint8x8_t vrsra_n_u8 (uint8x8_t a, uint8x8_t b, const int n); A32: VRSRA.U8 Dd, Dm, #n; A64: URSRA Vd.8B, Vn.8B, #n
                // ShiftRightLogicalRoundedAdd(Vector64<Int16>, Vector64<Int16>, Byte)	uint16x4_t vrsra_n_u16 (uint16x4_t a, uint16x4_t b, const int n); A32: VRSRA.U16 Dd, Dm, #n; A64: URSRA Vd.4H, Vn.4H, #n
                // ShiftRightLogicalRoundedAdd(Vector64<Int32>, Vector64<Int32>, Byte)	uint32x2_t vrsra_n_u32 (uint32x2_t a, uint32x2_t b, const int n); A32: VRSRA.U32 Dd, Dm, #n; A64: URSRA Vd.2S, Vn.2S, #n
                // ShiftRightLogicalRoundedAdd(Vector64<SByte>, Vector64<SByte>, Byte)	uint8x8_t vrsra_n_u8 (uint8x8_t a, uint8x8_t b, const int n); A32: VRSRA.U8 Dd, Dm, #n; A64: URSRA Vd.8B, Vn.8B, #n
                // ShiftRightLogicalRoundedAdd(Vector64<UInt16>, Vector64<UInt16>, Byte)	uint16x4_t vrsra_n_u16 (uint16x4_t a, uint16x4_t b, const int n); A32: VRSRA.U16 Dd, Dm, #n; A64: URSRA Vd.4H, Vn.4H, #n
                // ShiftRightLogicalRoundedAdd(Vector64<UInt32>, Vector64<UInt32>, Byte)	uint32x2_t vrsra_n_u32 (uint32x2_t a, uint32x2_t b, const int n); A32: VRSRA.U32 Dd, Dm, #n; A64: URSRA Vd.2S, Vn.2S, #n
                // ShiftRightLogicalRoundedAddScalar(Vector64<Int64>, Vector64<Int64>, Byte)	uint64x1_t vrsra_n_u64 (uint64x1_t a, uint64x1_t b, const int n); A32: VRSRA.U64 Dd, Dm, #n; A64: URSRA Dd, Dn, #n
                // ShiftRightLogicalRoundedAddScalar(Vector64<UInt64>, Vector64<UInt64>, Byte)	uint64x1_t vrsra_n_u64 (uint64x1_t a, uint64x1_t b, const int n); A32: VRSRA.U64 Dd, Dm, #n; A64: URSRA Dd, Dn, #n
                if (true) {
                    Vector128<sbyte> demo = Vector128s<sbyte>.Demo;
                    Vector128<sbyte> serial = Vector128s<sbyte>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedAdd<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedAdd<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedAdd<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedAdd<long>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 64; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedAdd(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedAdd(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 12、Vector rounding narrowing shift right by constant: vrshrn -> ri = ai >> b;  
                // The results are rounded. right shifts each element in a vector by an immediate value, and places the rounded,narrowed results in the destination vector.
                // 结果是四舍五入的。将向量中的每个元素右移一个直接值，并将四舍五入、缩小的结果放在目标向量中。
                // ShiftRightLogicalRoundedNarrowingLower(Vector128<Int16>, Byte)	int8x8_t vrshrn_n_s16 (int16x8_t a, const int n); A32: VRSHRN.I16 Dd, Qm, #n; A64: RSHRN Vd.8B, Vn.8H, #n
                // ShiftRightLogicalRoundedNarrowingLower(Vector128<Int32>, Byte)	int16x4_t vrshrn_n_s32 (int32x4_t a, const int n); A32: VRSHRN.I32 Dd, Qm, #n; A64: RSHRN Vd.4H, Vn.4S, #n
                // ShiftRightLogicalRoundedNarrowingLower(Vector128<Int64>, Byte)	int32x2_t vrshrn_n_s64 (int64x2_t a, const int n); A32: VRSHRN.I64 Dd, Qm, #n; A64: RSHRN Vd.2S, Vn.2D, #n
                // ShiftRightLogicalRoundedNarrowingLower(Vector128<UInt16>, Byte)	uint8x8_t vrshrn_n_u16 (uint16x8_t a, const int n); A32: VRSHRN.I16 Dd, Qm, #n; A64: RSHRN Vd.8B, Vn.8H, #n
                // ShiftRightLogicalRoundedNarrowingLower(Vector128<UInt32>, Byte)	uint16x4_t vrshrn_n_u32 (uint32x4_t a, const int n); A32: VRSHRN.I32 Dd, Qm, #n; A64: RSHRN Vd.4H, Vn.4S, #n
                // ShiftRightLogicalRoundedNarrowingLower(Vector128<UInt64>, Byte)	uint32x2_t vrshrn_n_u64 (uint64x2_t a, const int n); A32: VRSHRN.I64 Dd, Qm, #n; A64: RSHRN Vd.2S, Vn.2D, #n
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingLower<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<Int16>, Byte)	uint8x8_t vqrshrn_n_u16 (uint16x8_t a, const int n); A32: VQRSHRN.U16 Dd, Qm, #n; A64: UQRSHRN Vd.8B, Vn.8H, #n
                // ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<Int32>, Byte)	uint16x4_t vqrshrn_n_u32 (uint32x4_t a, const int n); A32: VQRSHRN.U32 Dd, Qm, #n; A64: UQRSHRN Vd.4H, Vn.4S, #n
                // ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<Int64>, Byte)	uint32x2_t vqrshrn_n_u64 (uint64x2_t a, const int n); A32: VQRSHRN.U64 Dd, Qm, #n; A64: UQRSHRN Vd.2S, Vn.2D, #n
                // ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<UInt16>, Byte)	uint8x8_t vqrshrn_n_u16 (uint16x8_t a, const int n); A32: VQRSHRN.U16 Dd, Qm, #n; A64: UQRSHRN Vd.8B, Vn.8H, #n
                // ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<UInt32>, Byte)	uint16x4_t vqrshrn_n_u32 (uint32x4_t a, const int n); A32: VQRSHRN.U32 Dd, Qm, #n; A64: UQRSHRN Vd.4H, Vn.4S, #n
                // ShiftRightLogicalRoundedNarrowingSaturateLower(Vector128<UInt64>, Byte)	uint32x2_t vqrshrn_n_u64 (uint64x2_t a, const int n); A32: VQRSHRN.U64 Dd, Qm, #n; A64: UQRSHRN Vd.2S, Vn.2D, #n
                if (true) {
                    Vector128<short> demo = Vector128s<short>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingSaturateLower<short>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<int> demo = Vector128s<int>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingSaturateLower<int>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector128<long> demo = Vector128s<long>.Demo;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingSaturateLower<long>, demo:\t{0}", demo);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingSaturateLower(demo, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateLower(demo, (byte)shiftAmount), shiftAmount);
                    }
                }

                // ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<Byte>, Vector128<UInt16>, Byte)	uint8x16_t vqrshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n); A32: VQRSHRN.U16 Dd+1, Dn, #n; A64: UQRSHRN2 Vd.16B, Vn.8H, #n
                // ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<Int16>, Vector128<Int32>, Byte)	uint16x8_t vqrshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n); A32: VQRSHRN.U32 Dd+1, Dn, #n; A64: UQRSHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<Int32>, Vector128<Int64>, Byte)	uint32x4_t vqrshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n); A32: VQRSHRN.U64 Dd+1, Dn, #n; A64: UQRSHRN2 Vd.4S, Vn.2D, #n
                // ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<SByte>, Vector128<Int16>, Byte)	uint8x16_t vqrshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n); A32: VQRSHRN.U16 Dd+1, Dn, #n; A64: UQRSHRN2 Vd.16B, Vn.8H, #n
                // ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<UInt16>, Vector128<UInt32>, Byte)	uint16x8_t vqrshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n); A32: VQRSHRN.U32 Dd+1, Dn, #n; A64: UQRSHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightLogicalRoundedNarrowingSaturateUpper(Vector64<UInt32>, Vector128<UInt64>, Byte)	uint32x4_t vqrshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n); A32: VQRSHRN.U64 Dd+1, Dn, #n; A64: UQRSHRN2 Vd.4S, Vn.2D, #n
                if (true) {
                    Vector64<sbyte> demo = Vector64s<sbyte>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingSaturateUpper<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<short> demo = Vector64s<short>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingSaturateUpper<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<int> demo = Vector64s<int>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingSaturateUpper<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingSaturateUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingSaturateUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // ShiftRightLogicalRoundedNarrowingUpper(Vector64<Byte>, Vector128<UInt16>, Byte)	uint8x16_t vrshrn_high_n_u16 (uint8x8_t r, uint16x8_t a, const int n); A32: VRSHRN.I16 Dd+1, Qm, #n; A64: RSHRN2 Vd.16B, Vn.8H, #n
                // ShiftRightLogicalRoundedNarrowingUpper(Vector64<Int16>, Vector128<Int32>, Byte)	int16x8_t vrshrn_high_n_s32 (int16x4_t r, int32x4_t a, const int n); A32: VRSHRN.I32 Dd+1, Qm, #n; A64: RSHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightLogicalRoundedNarrowingUpper(Vector64<Int32>, Vector128<Int64>, Byte)	int32x4_t vrshrn_high_n_s64 (int32x2_t r, int64x2_t a, const int n); A32: VRSHRN.I64 Dd+1, Qm, #n; A64: RSHRN2 Vd.4S, Vn.2D, #n
                // ShiftRightLogicalRoundedNarrowingUpper(Vector64<SByte>, Vector128<Int16>, Byte)	int8x16_t vrshrn_high_n_s16 (int8x8_t r, int16x8_t a, const int n); A32: VRSHRN.I16 Dd+1, Qm, #n; A64: RSHRN2 Vd.16B, Vn.8H, #n
                // ShiftRightLogicalRoundedNarrowingUpper(Vector64<UInt16>, Vector128<UInt32>, Byte)	uint16x8_t vrshrn_high_n_u32 (uint16x4_t r, uint32x4_t a, const int n); A32: VRSHRN.I32 Dd+1, Qm, #n; A64: RSHRN2 Vd.8H, Vn.4S, #n
                // ShiftRightLogicalRoundedNarrowingUpper(Vector64<UInt32>, Vector128<UInt64>, Byte)	uint32x4_t vrshrn_high_n_u64 (uint32x2_t r, uint64x2_t a, const int n); A32: VRSHRN.I64 Dd+1, Qm, #n; A64: RSHRN2 Vd.4S, Vn.2D, #n
                if (true) {
                    Vector64<sbyte> demo = Vector64s<sbyte>.Demo;
                    Vector128<short> serial = Vector128s<short>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingUpper<sbyte>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 8; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<short> demo = Vector64s<short>.Demo;
                    Vector128<int> serial = Vector128s<int>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingUpper<short>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 16; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }
                if (true) {
                    Vector64<int> demo = Vector64s<int>.Demo;
                    Vector128<long> serial = Vector128s<long>.Serial;
                    WriteLine(writer, indent, "ShiftRightLogicalRoundedNarrowingUpper<int>, demo={0}, serial={1}", demo, serial);
                    for (int shiftAmount = 1; shiftAmount <= 32; ++shiftAmount) {
                        WriteLine(writer, indentNext, "ShiftRightLogicalRoundedNarrowingUpper(demo, serial, {1}):\t{0}", AdvSimd.ShiftRightLogicalRoundedNarrowingUpper(demo, serial, (byte)shiftAmount), shiftAmount);
                    }
                }

                // 2、Vector long move(长指令): vmovl -> sign extends or zero extends each element 
                // in a doubleword vector to twice its original length, and places the results in a quadword vector.
                // 在双字向量中转换为其原始长度的两倍，并将结果放入四字向量中。
                // SignExtendWideningLower(Vector64<Int16>)	int32x4_t vmovl_s16 (int16x4_t a); A32: VMOVL.S16 Qd, Dm; A64: SXTL Vd.4S, Vn.4H
                // SignExtendWideningLower(Vector64<Int32>)	int64x2_t vmovl_s32 (int32x2_t a); A32: VMOVL.S32 Qd, Dm; A64: SXTL Vd.2D, Vn.2S
                // SignExtendWideningLower(Vector64<SByte>)	int16x8_t vmovl_s8 (int8x8_t a); A32: VMOVL.S8 Qd, Dm; A64: SXTL Vd.8H, Vn.8B
                WriteLine(writer, indent, "SignExtendWideningLower(Vector64s<sbyte>.Demo):\t{0}", AdvSimd.SignExtendWideningLower(Vector64s<sbyte>.Demo));
                WriteLine(writer, indent, "SignExtendWideningLower(Vector64s<short>.Demo):\t{0}", AdvSimd.SignExtendWideningLower(Vector64s<short>.Demo));
                WriteLine(writer, indent, "SignExtendWideningLower(Vector64s<int>.Demo):\t{0}", AdvSimd.SignExtendWideningLower(Vector64s<int>.Demo));

                // SignExtendWideningUpper(Vector128<Int16>)	int32x4_t vmovl_high_s16 (int16x8_t a); A32: VMOVL.S16 Qd, Dm+1; A64: SXTL2 Vd.4S, Vn.8H
                // SignExtendWideningUpper(Vector128<Int32>)	int64x2_t vmovl_high_s32 (int32x4_t a); A32: VMOVL.S32 Qd, Dm+1; A64: SXTL2 Vd.2D, Vn.4S
                // SignExtendWideningUpper(Vector128<SByte>)	int16x8_t vmovl_high_s8 (int8x16_t a); A32: VMOVL.S8 Qd, Dm+1; A64: SXTL2 Vd.8H, Vn.16B
                WriteLine(writer, indent, "SignExtendWideningUpper(Vector128s<sbyte>.Demo):\t{0}", AdvSimd.SignExtendWideningUpper(Vector128s<sbyte>.Demo));
                WriteLine(writer, indent, "SignExtendWideningUpper(Vector128s<short>.Demo):\t{0}", AdvSimd.SignExtendWideningUpper(Vector128s<short>.Demo));
                WriteLine(writer, indent, "SignExtendWideningUpper(Vector128s<int>.Demo):\t{0}", AdvSimd.SignExtendWideningUpper(Vector128s<int>.Demo));

                // SqrtScalar(Vector64<Double>)	float64x1_t vsqrt_f64 (float64x1_t a); A32: VSQRT.F64 Dd, Dm; A64: FSQRT Dd, Dn
                // SqrtScalar(Vector64<Single>)	float32_t vsqrts_f32 (float32_t a); A32: VSQRT.F32 Sd, Sm; A64: FSQRT Sd, Sn The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
                WriteLine(writer, indent, "SqrtScalar(Vector64s<float>.V2):\t{0}", AdvSimd.SqrtScalar(Vector64s<float>.V2));
                WriteLine(writer, indent, "SqrtScalar(Vector64s<double>.V2):\t{0}", AdvSimd.SqrtScalar(Vector64s<double>.V2));

                // Store(Byte*, Vector128<Byte>)	void vst1q_u8 (uint8_t * ptr, uint8x16_t val); A32: VST1.8 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.16B }, [Xn]
                // Store(Byte*, Vector64<Byte>)	void vst1_u8 (uint8_t * ptr, uint8x8_t val); A32: VST1.8 { Dd }, [Rn]; A64: ST1 { Vt.8B }, [Xn]
                // Store(Double*, Vector128<Double>)	void vst1q_f64 (float64_t * ptr, float64x2_t val); A32: VST1.64 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.2D }, [Xn]
                // Store(Double*, Vector64<Double>)	void vst1_f64 (float64_t * ptr, float64x1_t val); A32: VST1.64 { Dd }, [Rn]; A64: ST1 { Vt.1D }, [Xn]
                // Store(Int16*, Vector128<Int16>)	void vst1q_s16 (int16_t * ptr, int16x8_t val); A32: VST1.16 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.8H }, [Xn]
                // Store(Int16*, Vector64<Int16>)	void vst1_s16 (int16_t * ptr, int16x4_t val); A32: VST1.16 { Dd }, [Rn]; A64: ST1 {Vt.4H }, [Xn]
                // Store(Int32*, Vector128<Int32>)	void vst1q_s32 (int32_t * ptr, int32x4_t val); A32: VST1.32 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.4S }, [Xn]
                // Store(Int32*, Vector64<Int32>)	void vst1_s32 (int32_t * ptr, int32x2_t val); A32: VST1.32 { Dd }, [Rn]; A64: ST1 { Vt.2S }, [Xn]
                // Store(Int64*, Vector128<Int64>)	void vst1q_s64 (int64_t * ptr, int64x2_t val); A32: VST1.64 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.2D }, [Xn]
                // Store(Int64*, Vector64<Int64>)	void vst1_s64 (int64_t * ptr, int64x1_t val); A32: VST1.64 { Dd }, [Rn]; A64: ST1 { Vt.1D }, [Xn]
                // Store(SByte*, Vector128<SByte>)	void vst1q_s8 (int8_t * ptr, int8x16_t val); A32: VST1.8 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.16B }, [Xn]
                // Store(SByte*, Vector64<SByte>)	void vst1_s8 (int8_t * ptr, int8x8_t val); A32: VST1.8 { Dd }, [Rn]; A64: ST1 { Vt.8B }, [Xn]
                // Store(Single*, Vector128<Single>)	void vst1q_f32 (float32_t * ptr, float32x4_t val); A32: VST1.32 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.4S }, [Xn]
                // Store(Single*, Vector64<Single>)	void vst1_f32 (float32_t * ptr, float32x2_t val); A32: VST1.32 { Dd }, [Rn]; A64: ST1 { Vt.2S }, [Xn]
                // Store(UInt16*, Vector128<UInt16>)	void vst1q_u16 (uint16_t * ptr, uint16x8_t val); A32: VST1.16 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.8H }, [Xn]
                // Store(UInt16*, Vector64<UInt16>)	void vst1_u16 (uint16_t * ptr, uint16x4_t val); A32: VST1.16 { Dd }, [Rn]; A64: ST1 { Vt.4H }, [Xn]
                // Store(UInt32*, Vector128<UInt32>)	void vst1q_u32 (uint32_t * ptr, uint32x4_t val); A32: VST1.32 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.4S }, [Xn]
                // Store(UInt32*, Vector64<UInt32>)	void vst1_u32 (uint32_t * ptr, uint32x2_t val); A32: VST1.32 { Dd }, [Rn]; A64: ST1 { Vt.2S }, [Xn]
                // Store(UInt64*, Vector128<UInt64>)	void vst1q_u64 (uint64_t * ptr, uint64x2_t val); A32: VST1.64 { Dd, Dd+1 }, [Rn]; A64: ST1 { Vt.2D }, [Xn]
                // Store(UInt64*, Vector64<UInt64>)	void vst1_u64 (uint64_t * ptr, uint64x1_t val); A32: VST1.64 { Dd }, [Rn]; A64: ST1 { Vt.1D }, [Xn]
                // StoreSelectedScalar(Byte*, Vector128<Byte>, Byte)	void vst1q_lane_u8 (uint8_t * ptr, uint8x16_t val, const int lane); A32: VST1.8 { Dd[index] }, [Rn]; A64: ST1 { Vt.B }[index], [Xn]
                // StoreSelectedScalar(Byte*, Vector64<Byte>, Byte)	void vst1_lane_u8 (uint8_t * ptr, uint8x8_t val, const int lane); A32: VST1.8 { Dd[index] }, [Rn]; A64: ST1 { Vt.B }[index], [Xn]
                // StoreSelectedScalar(Double*, Vector128<Double>, Byte)	void vst1q_lane_f64 (float64_t * ptr, float64x2_t val, const int lane); A32: VSTR.64 Dd, [Rn]; A64: ST1 { Vt.D }[index], [Xn]
                // StoreSelectedScalar(Int16*, Vector128<Int16>, Byte)	void vst1q_lane_s16 (int16_t * ptr, int16x8_t val, const int lane); A32: VST1.16 { Dd[index] }, [Rn]; A64: ST1 { Vt.H }[index], [Xn]
                // StoreSelectedScalar(Int16*, Vector64<Int16>, Byte)	void vst1_lane_s16 (int16_t * ptr, int16x4_t val, const int lane); A32: VST1.16 { Dd[index] }, [Rn]; A64: ST1 { Vt.H }[index], [Xn]
                // StoreSelectedScalar(Int32*, Vector128<Int32>, Byte)	void vst1q_lane_s32 (int32_t * ptr, int32x4_t val, const int lane); A32: VST1.32 { Dd[index] }, [Rn]; A64: ST1 { Vt.S }[index], [Xn]
                // StoreSelectedScalar(Int32*, Vector64<Int32>, Byte)	void vst1_lane_s32 (int32_t * ptr, int32x2_t val, const int lane); A32: VST1.32 { Dd[index] }, [Rn]; A64: ST1 { Vt.S }[index], [Xn]
                // StoreSelectedScalar(Int64*, Vector128<Int64>, Byte)	void vst1q_lane_s64 (int64_t * ptr, int64x2_t val, const int lane); A32: VSTR.64 Dd, [Rn]; A64: ST1 { Vt.D }[index], [Xn]
                // StoreSelectedScalar(SByte*, Vector128<SByte>, Byte)	void vst1q_lane_s8 (int8_t * ptr, int8x16_t val, const int lane); A32: VST1.8 { Dd[index] }, [Rn]; A64: ST1 { Vt.B }[index], [Xn]
                // StoreSelectedScalar(SByte*, Vector64<SByte>, Byte)	void vst1_lane_s8 (int8_t * ptr, int8x8_t val, const int lane); A32: VST1.8 { Dd[index] }, [Rn]; A64: ST1 { Vt.B }[index], [Xn]
                // StoreSelectedScalar(Single*, Vector128<Single>, Byte)	void vst1q_lane_f32 (float32_t * ptr, float32x4_t val, const int lane); A32: VST1.32 { Dd[index] }, [Rn]; A64: ST1 { Vt.S }[index], [Xn]
                // StoreSelectedScalar(Single*, Vector64<Single>, Byte)	void vst1_lane_f32 (float32_t * ptr, float32x2_t val, const int lane); A32: VST1.32 { Dd[index] }, [Rn]; A64: ST1 { Vt.S }[index], [Xn]
                // StoreSelectedScalar(UInt16*, Vector128<UInt16>, Byte)	void vst1q_lane_u16 (uint16_t * ptr, uint16x8_t val, const int lane); A32: VST1.16 { Dd[index] }, [Rn]; A64: ST1 { Vt.H }[index], [Xn]
                // StoreSelectedScalar(UInt16*, Vector64<UInt16>, Byte)	void vst1_lane_u16 (uint16_t * ptr, uint16x4_t val, const int lane); A32: VST1.16 { Dd[index] }, [Rn]; A64: ST1 { Vt.H }[index], [Xn]
                // StoreSelectedScalar(UInt32*, Vector128<UInt32>, Byte)	void vst1q_lane_u32 (uint32_t * ptr, uint32x4_t val, const int lane); A32: VST1.32 { Dd[index] }, [Rn]; A64: ST1 { Vt.S }[index], [Xn]
                // StoreSelectedScalar(UInt32*, Vector64<UInt32>, Byte)	void vst1_lane_u32 (uint32_t * ptr, uint32x2_t val, const int lane); A32: VST1.32 { Dd[index] }, [Rn]; A64: ST1 { Vt.S }[index], [Xn]
                // StoreSelectedScalar(UInt64*, Vector128<UInt64>, Byte)	void vst1q_lane_u64 (uint64_t * ptr, uint64x2_t val, const int lane); A32: VSTR.64 Dd, [Rn]; A64: ST1 { Vt.D }[index], [Xn]
                // Subtract(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vsubq_u8 (uint8x16_t a, uint8x16_t b); A32: VSUB.I8 Qd, Qn, Qm; A64: SUB Vd.16B, Vn.16B, Vm.16B
                // Subtract(Vector128<Int16>, Vector128<Int16>)	int16x8_t vsubq_s16 (int16x8_t a, int16x8_t b); A32: VSUB.I16 Qd, Qn, Qm; A64: SUB Vd.8H, Vn.8H, Vm.8H
                // Subtract(Vector128<Int32>, Vector128<Int32>)	int32x4_t vsubq_s32 (int32x4_t a, int32x4_t b); A32: VSUB.I32 Qd, Qn, Qm; A64: SUB Vd.4S, Vn.4S, Vm.4S
                // Subtract(Vector128<Int64>, Vector128<Int64>)	int64x2_t vsubq_s64 (int64x2_t a, int64x2_t b); A32: VSUB.I64 Qd, Qn, Qm; A64: SUB Vd.2D, Vn.2D, Vm.2D
                // Subtract(Vector128<SByte>, Vector128<SByte>)	int8x16_t vsubq_s8 (int8x16_t a, int8x16_t b); A32: VSUB.I8 Qd, Qn, Qm; A64: SUB Vd.16B, Vn.16B, Vm.16B
                // Subtract(Vector128<Single>, Vector128<Single>)	float32x4_t vsubq_f32 (float32x4_t a, float32x4_t b); A32: VSUB.F32 Qd, Qn, Qm; A64: FSUB Vd.4S, Vn.4S, Vm.4S
                // Subtract(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vsubq_u16 (uint16x8_t a, uint16x8_t b); A32: VSUB.I16 Qd, Qn, Qm; A64: SUB Vd.8H, Vn.8H, Vm.8H
                // Subtract(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vsubq_u32 (uint32x4_t a, uint32x4_t b); A32: VSUB.I32 Qd, Qn, Qm; A64: SUB Vd.4S, Vn.4S, Vm.4S
                // Subtract(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vsubq_u64 (uint64x2_t a, uint64x2_t b); A32: VSUB.I64 Qd, Qn, Qm; A64: SUB Vd.2D, Vn.2D, Vm.2D
                // Subtract(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vsub_u8 (uint8x8_t a, uint8x8_t b); A32: VSUB.I8 Dd, Dn, Dm; A64: SUB Vd.8B, Vn.8B, Vm.8B
                // Subtract(Vector64<Int16>, Vector64<Int16>)	int16x4_t vsub_s16 (int16x4_t a, int16x4_t b); A32: VSUB.I16 Dd, Dn, Dm; A64: SUB Vd.4H, Vn.4H, Vm.4H
                // Subtract(Vector64<Int32>, Vector64<Int32>)	int32x2_t vsub_s32 (int32x2_t a, int32x2_t b); A32: VSUB.I32 Dd, Dn, Dm; A64: SUB Vd.2S, Vn.2S, Vm.2S
                // Subtract(Vector64<SByte>, Vector64<SByte>)	int8x8_t vsub_s8 (int8x8_t a, int8x8_t b); A32: VSUB.I8 Dd, Dn, Dm; A64: SUB Vd.8B, Vn.8B, Vm.8B
                // Subtract(Vector64<Single>, Vector64<Single>)	float32x2_t vsub_f32 (float32x2_t a, float32x2_t b); A32: VSUB.F32 Dd, Dn, Dm; A64: FSUB Vd.2S, Vn.2S, Vm.2S
                // Subtract(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vsub_u16 (uint16x4_t a, uint16x4_t b); A32: VSUB.I16 Dd, Dn, Dm; A64: SUB Vd.4H, Vn.4H, Vm.4H
                // Subtract(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vsub_u32 (uint32x2_t a, uint32x2_t b); A32: VSUB.I32 Dd, Dn, Dm; A64: SUB Vd.2S, Vn.2S, Vm.2S
                // SubtractHighNarrowingLower(Vector128<Int16>, Vector128<Int16>)	int8x8_t vsubhn_s16 (int16x8_t a, int16x8_t b); A32: VSUBHN.I16 Dd, Qn, Qm; A64: SUBHN Vd.8B, Vn.8H, Vm.8H
                // SubtractHighNarrowingLower(Vector128<Int32>, Vector128<Int32>)	int16x4_t vsubhn_s32 (int32x4_t a, int32x4_t b); A32: VSUBHN.I32 Dd, Qn, Qm; A64: SUBHN Vd.4H, Vn.4S, Vm.4S
                // SubtractHighNarrowingLower(Vector128<Int64>, Vector128<Int64>)	int32x2_t vsubhn_s64 (int64x2_t a, int64x2_t b); A32: VSUBHN.I64 Dd, Qn, Qm; A64: SUBHN Vd.2S, Vn.2D, Vm.2D
                // SubtractHighNarrowingLower(Vector128<UInt16>, Vector128<UInt16>)	uint8x8_t vsubhn_u16 (uint16x8_t a, uint16x8_t b); A32: VSUBHN.I16 Dd, Qn, Qm; A64: SUBHN Vd.8B, Vn.8H, Vm.8H
                // SubtractHighNarrowingLower(Vector128<UInt32>, Vector128<UInt32>)	uint16x4_t vsubhn_u32 (uint32x4_t a, uint32x4_t b); A32: VSUBHN.I32 Dd, Qn, Qm; A64: SUBHN Vd.4H, Vn.4S, Vm.4S
                // SubtractHighNarrowingLower(Vector128<UInt64>, Vector128<UInt64>)	uint32x2_t vsubhn_u64 (uint64x2_t a, uint64x2_t b); A32: VSUBHN.I64 Dd, Qn, Qm; A64: SUBHN Vd.2S, Vn.2D, Vm.2D
                // SubtractHighNarrowingUpper(Vector64<Byte>, Vector128<UInt16>, Vector128<UInt16>)	uint8x16_t vsubhn_high_u16 (uint8x8_t r, uint16x8_t a, uint16x8_t b); A32: VSUBHN.I16 Dd+1, Qn, Qm; A64: SUBHN2 Vd.16B, Vn.8H, Vm.8H
                // SubtractHighNarrowingUpper(Vector64<Int16>, Vector128<Int32>, Vector128<Int32>)	int16x8_t vsubhn_high_s32 (int16x4_t r, int32x4_t a, int32x4_t b); A32: VSUBHN.I32 Dd+1, Qn, Qm; A64: SUBHN2 Vd.8H, Vn.4S, Vm.4S
                // SubtractHighNarrowingUpper(Vector64<Int32>, Vector128<Int64>, Vector128<Int64>)	int32x4_t vsubhn_high_s64 (int32x2_t r, int64x2_t a, int64x2_t b); A32: VSUBHN.I64 Dd+1, Qn, Qm; A64: SUBHN2 Vd.4S, Vn.2D, Vm.2D
                // SubtractHighNarrowingUpper(Vector64<SByte>, Vector128<Int16>, Vector128<Int16>)	int8x16_t vsubhn_high_s16 (int8x8_t r, int16x8_t a, int16x8_t b); A32: VSUBHN.I16 Dd+1, Qn, Qm; A64: SUBHN2 Vd.16B, Vn.8H, Vm.8H
                // SubtractHighNarrowingUpper(Vector64<UInt16>, Vector128<UInt32>, Vector128<UInt32>)	uint16x8_t vsubhn_high_u32 (uint16x4_t r, uint32x4_t a, uint32x4_t b); A32: VSUBHN.I32 Dd+1, Qn, Qm; A64: SUBHN2 Vd.8H, Vn.4S, Vm.4S
                // SubtractHighNarrowingUpper(Vector64<UInt32>, Vector128<UInt64>, Vector128<UInt64>)	uint32x4_t vsubhn_high_u64 (uint32x2_t r, uint64x2_t a, uint64x2_t b); A32: VSUBHN.I64 Dd+1, Qn, Qm; A64: SUBHN2 Vd.4S, Vn.2D, Vm.2D
                // SubtractRoundedHighNarrowingLower(Vector128<Int16>, Vector128<Int16>)	int8x8_t vrsubhn_s16 (int16x8_t a, int16x8_t b); A32: VRSUBHN.I16 Dd, Qn, Qm; A64: RSUBHN Vd.8B, Vn.8H, Vm.8H
                // SubtractRoundedHighNarrowingLower(Vector128<Int32>, Vector128<Int32>)	int16x4_t vrsubhn_s32 (int32x4_t a, int32x4_t b); A32: VRSUBHN.I32 Dd, Qn, Qm; A64: RSUBHN Vd.4H, Vn.4S, Vm.4S
                // SubtractRoundedHighNarrowingLower(Vector128<Int64>, Vector128<Int64>)	int32x2_t vrsubhn_s64 (int64x2_t a, int64x2_t b); A32: VRSUBHN.I64 Dd, Qn, Qm; A64: RSUBHN Vd.2S, Vn.2D, Vm.2D
                // SubtractRoundedHighNarrowingLower(Vector128<UInt16>, Vector128<UInt16>)	uint8x8_t vrsubhn_u16 (uint16x8_t a, uint16x8_t b); A32: VRSUBHN.I16 Dd, Qn, Qm; A64: RSUBHN Vd.8B, Vn.8H, Vm.8H
                // SubtractRoundedHighNarrowingLower(Vector128<UInt32>, Vector128<UInt32>)	uint16x4_t vrsubhn_u32 (uint32x4_t a, uint32x4_t b); A32: VRSUBHN.I32 Dd, Qn, Qm; A64: RSUBHN Vd.4H, Vn.4S, Vm.4S
                // SubtractRoundedHighNarrowingLower(Vector128<UInt64>, Vector128<UInt64>)	uint32x2_t vrsubhn_u64 (uint64x2_t a, uint64x2_t b); A32: VRSUBHN.I64 Dd, Qn, Qm; A64: RSUBHN Vd.2S, Vn.2D, Vm.2D
                // SubtractRoundedHighNarrowingUpper(Vector64<Byte>, Vector128<UInt16>, Vector128<UInt16>)	uint8x16_t vrsubhn_high_u16 (uint8x8_t r, uint16x8_t a, uint16x8_t b); A32: VRSUBHN.I16 Dd+1, Qn, Qm; A64: RSUBHN2 Vd.16B, Vn.8H, Vm.8H
                // SubtractRoundedHighNarrowingUpper(Vector64<Int16>, Vector128<Int32>, Vector128<Int32>)	int16x8_t vrsubhn_high_s32 (int16x4_t r, int32x4_t a, int32x4_t b); A32: VRSUBHN.I32 Dd+1, Qn, Qm; A64: RSUBHN2 Vd.8H, Vn.4S, Vm.4S
                // SubtractRoundedHighNarrowingUpper(Vector64<Int32>, Vector128<Int64>, Vector128<Int64>)	int32x4_t vrsubhn_high_s64 (int32x2_t r, int64x2_t a, int64x2_t b); A32: VRSUBHN.I64 Dd+1, Qn, Qm; A64: RSUBHN2 Vd.4S, Vn.2D, Vm.2D
                // SubtractRoundedHighNarrowingUpper(Vector64<SByte>, Vector128<Int16>, Vector128<Int16>)	int8x16_t vrsubhn_high_s16 (int8x8_t r, int16x8_t a, int16x8_t b); A32: VRSUBHN.I16 Dd+1, Qn, Qm; A64: RSUBHN2 Vd.16B, Vn.8H, Vm.8H
                // SubtractRoundedHighNarrowingUpper(Vector64<UInt16>, Vector128<UInt32>, Vector128<UInt32>)	uint16x8_t vrsubhn_high_u32 (uint16x4_t r, uint32x4_t a, uint32x4_t b); A32: VRSUBHN.I32 Dd+1, Qn, Qm; A64: RSUBHN2 Vd.8H, Vn.4S, Vm.4S
                // SubtractRoundedHighNarrowingUpper(Vector64<UInt32>, Vector128<UInt64>, Vector128<UInt64>)	uint32x4_t vrsubhn_high_u64 (uint32x2_t r, uint64x2_t a, uint64x2_t b); A32: VRSUBHN.I64 Dd+1, Qn, Qm; A64: RSUBHN2 Vd.4S, Vn.2D, Vm.2D
                // SubtractSaturate(Vector128<Byte>, Vector128<Byte>)	uint8x16_t vqsubq_u8 (uint8x16_t a, uint8x16_t b); A32: VQSUB.U8 Qd, Qn, Qm; A64: UQSUB Vd.16B, Vn.16B, Vm.16B
                // SubtractSaturate(Vector128<Int16>, Vector128<Int16>)	int16x8_t vqsubq_s16 (int16x8_t a, int16x8_t b); A32: VQSUB.S16 Qd, Qn, Qm; A64: SQSUB Vd.8H, Vn.8H, Vm.8H
                // SubtractSaturate(Vector128<Int32>, Vector128<Int32>)	int32x4_t vqsubq_s32 (int32x4_t a, int32x4_t b); A32: VQSUB.S32 Qd, Qn, Qm; A64: SQSUB Vd.4S, Vn.4S, Vm.4S
                // SubtractSaturate(Vector128<Int64>, Vector128<Int64>)	int64x2_t vqsubq_s64 (int64x2_t a, int64x2_t b); A32: VQSUB.S64 Qd, Qn, Qm; A64: SQSUB Vd.2D, Vn.2D, Vm.2D
                // SubtractSaturate(Vector128<SByte>, Vector128<SByte>)	int8x16_t vqsubq_s8 (int8x16_t a, int8x16_t b); A32: VQSUB.S8 Qd, Qn, Qm; A64: SQSUB Vd.16B, Vn.16B, Vm.16B
                // SubtractSaturate(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t vqsubq_u16 (uint16x8_t a, uint16x8_t b); A32: VQSUB.U16 Qd, Qn, Qm; A64: UQSUB Vd.8H, Vn.8H, Vm.8H
                // SubtractSaturate(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t vqsubq_u32 (uint32x4_t a, uint32x4_t b); A32: VQSUB.U32 Qd, Qn, Qm; A64: UQSUB Vd.4S, Vn.4S, Vm.4S
                // SubtractSaturate(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vqsubq_u64 (uint64x2_t a, uint64x2_t b); A32: VQSUB.U64 Qd, Qn, Qm; A64: UQSUB Vd.2D, Vn.2D, Vm.2D
                // SubtractSaturate(Vector64<Byte>, Vector64<Byte>)	uint8x8_t vqsub_u8 (uint8x8_t a, uint8x8_t b); A32: VQSUB.U8 Dd, Dn, Dm; A64: UQSUB Vd.8B, Vn.8B, Vm.8B
                // SubtractSaturate(Vector64<Int16>, Vector64<Int16>)	int16x4_t vqsub_s16 (int16x4_t a, int16x4_t b); A32: VQSUB.S16 Dd, Dn, Dm; A64: SQSUB Vd.4H, Vn.4H, Vm.4H
                // SubtractSaturate(Vector64<Int32>, Vector64<Int32>)	int32x2_t vqsub_s32 (int32x2_t a, int32x2_t b); A32: VQSUB.S32 Dd, Dn, Dm; A64: SQSUB Vd.2S, Vn.2S, Vm.2S
                // SubtractSaturate(Vector64<SByte>, Vector64<SByte>)	int8x8_t vqsub_s8 (int8x8_t a, int8x8_t b); A32: VQSUB.S8 Dd, Dn, Dm; A64: SQSUB Vd.8B, Vn.8B, Vm.8B
                // SubtractSaturate(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t vqsub_u16 (uint16x4_t a, uint16x4_t b); A32: VQSUB.U16 Dd, Dn, Dm; A64: UQSUB Vd.4H, Vn.4H, Vm.4H
                // SubtractSaturate(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t vqsub_u32 (uint32x2_t a, uint32x2_t b); A32: VQSUB.U32 Dd, Dn, Dm; A64: UQSUB Vd.2S, Vn.2S, Vm.2S
                // SubtractSaturateScalar(Vector64<Int64>, Vector64<Int64>)	int64x1_t vqsub_s64 (int64x1_t a, int64x1_t b); A32: VQSUB.S64 Dd, Dn, Dm; A64: SQSUB Dd, Dn, Dm
                // SubtractSaturateScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vqsub_u64 (uint64x1_t a, uint64x1_t b); A32: VQSUB.U64 Dd, Dn, Dm; A64: UQSUB Dd, Dn, Dm
                // SubtractScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vsub_f64 (float64x1_t a, float64x1_t b); A32: VSUB.F64 Dd, Dn, Dm; A64: FSUB Dd, Dn, Dm
                // SubtractScalar(Vector64<Int64>, Vector64<Int64>)	int64x1_t vsub_s64 (int64x1_t a, int64x1_t b); A32: VSUB.I64 Dd, Dn, Dm; A64: SUB Dd, Dn, Dm
                // SubtractScalar(Vector64<Single>, Vector64<Single>)	float32_t vsubs_f32 (float32_t a, float32_t b); A32: VSUB.F32 Sd, Sn, Sm; A64: FSUB Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
                // SubtractScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vsub_u64 (uint64x1_t a, uint64x1_t b); A32: VSUB.I64 Dd, Dn, Dm; A64: SUB Dd, Dn, Dm
                // SubtractWideningLower(Vector128<Int16>, Vector64<SByte>)	int16x8_t vsubw_s8 (int16x8_t a, int8x8_t b); A32: VSUBW.S8 Qd, Qn, Dm; A64: SSUBW Vd.8H, Vn.8H, Vm.8B
                // SubtractWideningLower(Vector128<Int32>, Vector64<Int16>)	int32x4_t vsubw_s16 (int32x4_t a, int16x4_t b); A32: VSUBW.S16 Qd, Qn, Dm; A64: SSUBW Vd.4S, Vn.4S, Vm.4H
                // SubtractWideningLower(Vector128<Int64>, Vector64<Int32>)	int64x2_t vsubw_s32 (int64x2_t a, int32x2_t b); A32: VSUBW.S32 Qd, Qn, Dm; A64: SSUBW Vd.2D, Vn.2D, Vm.2S
                // SubtractWideningLower(Vector128<UInt16>, Vector64<Byte>)	uint16x8_t vsubw_u8 (uint16x8_t a, uint8x8_t b); A32: VSUBW.U8 Qd, Qn, Dm; A64: USUBW Vd.8H, Vn.8H, Vm.8B
                // SubtractWideningLower(Vector128<UInt32>, Vector64<UInt16>)	uint32x4_t vsubw_u16 (uint32x4_t a, uint16x4_t b); A32: VSUBW.U16 Qd, Qn, Dm; A64: USUBW Vd.4S, Vn.4S, Vm.4H
                // SubtractWideningLower(Vector128<UInt64>, Vector64<UInt32>)	uint64x2_t vsubw_u32 (uint64x2_t a, uint32x2_t b); A32: VSUBW.U32 Qd, Qn, Dm; A64: USUBW Vd.2D, Vn.2D, Vm.2S
                // SubtractWideningLower(Vector64<Byte>, Vector64<Byte>)	uint16x8_t vsubl_u8 (uint8x8_t a, uint8x8_t b); A32: VSUBL.U8 Qd, Dn, Dm; A64: USUBL Vd.8H, Vn.8B, Vm.8B
                // SubtractWideningLower(Vector64<Int16>, Vector64<Int16>)	int32x4_t vsubl_s16 (int16x4_t a, int16x4_t b); A32: VSUBL.S16 Qd, Dn, Dm; A64: SSUBL Vd.4S, Vn.4H, Vm.4H
                // SubtractWideningLower(Vector64<Int32>, Vector64<Int32>)	int64x2_t vsubl_s32 (int32x2_t a, int32x2_t b); A32: VSUBL.S32 Qd, Dn, Dm; A64: SSUBL Vd.2D, Vn.2S, Vm.2S
                // SubtractWideningLower(Vector64<SByte>, Vector64<SByte>)	int16x8_t vsubl_s8 (int8x8_t a, int8x8_t b); A32: VSUBL.S8 Qd, Dn, Dm; A64: SSUBL Vd.8H, Vn.8B, Vm.8B
                // SubtractWideningLower(Vector64<UInt16>, Vector64<UInt16>)	uint32x4_t vsubl_u16 (uint16x4_t a, uint16x4_t b); A32: VSUBL.U16 Qd, Dn, Dm; A64: USUBL Vd.4S, Vn.4H, Vm.4H
                // SubtractWideningLower(Vector64<UInt32>, Vector64<UInt32>)	uint64x2_t vsubl_u32 (uint32x2_t a, uint32x2_t b); A32: VSUBL.U32 Qd, Dn, Dm; A64: USUBL Vd.2D, Vn.2S, Vm.2S
                // SubtractWideningUpper(Vector128<Byte>, Vector128<Byte>)	uint16x8_t vsubl_high_u8 (uint8x16_t a, uint8x16_t b); A32: VSUBL.U8 Qd, Dn+1, Dm+1; A64: USUBL2 Vd.8H, Vn.16B, Vm.16B
                // SubtractWideningUpper(Vector128<Int16>, Vector128<Int16>)	int32x4_t vsubl_high_s16 (int16x8_t a, int16x8_t b); A32: VSUBL.S16 Qd, Dn+1, Dm+1; A64: SSUBL2 Vd.4S, Vn.8H, Vm.8H
                // SubtractWideningUpper(Vector128<Int16>, Vector128<SByte>)	int16x8_t vsubw_high_s8 (int16x8_t a, int8x16_t b); A32: VSUBW.S8 Qd, Qn, Dm+1; A64: SSUBW2 Vd.8H, Vn.8H, Vm.16B
                // SubtractWideningUpper(Vector128<Int32>, Vector128<Int16>)	int32x4_t vsubw_high_s16 (int32x4_t a, int16x8_t b); A32: VSUBW.S16 Qd, Qn, Dm+1; A64: SSUBW2 Vd.4S, Vn.4S, Vm.8H
                // SubtractWideningUpper(Vector128<Int32>, Vector128<Int32>)	int64x2_t vsubl_high_s32 (int32x4_t a, int32x4_t b); A32: VSUBL.S32 Qd, Dn+1, Dm+1; A64: SSUBL2 Vd.2D, Vn.4S, Vm.4S
                // SubtractWideningUpper(Vector128<Int64>, Vector128<Int32>)	int64x2_t vsubw_high_s32 (int64x2_t a, int32x4_t b); A32: VSUBW.S32 Qd, Qn, Dm+1; A64: SSUBW2 Vd.2D, Vn.2D, Vm.4S
                // SubtractWideningUpper(Vector128<SByte>, Vector128<SByte>)	int16x8_t vsubl_high_s8 (int8x16_t a, int8x16_t b); A32: VSUBL.S8 Qd, Dn+1, Dm+1; A64: SSUBL2 Vd.8H, Vn.16B, Vm.16B
                // SubtractWideningUpper(Vector128<UInt16>, Vector128<Byte>)	uint16x8_t vsubw_high_u8 (uint16x8_t a, uint8x16_t b); A32: VSUBW.U8 Qd, Qn, Dm+1; A64: USUBW2 Vd.8H, Vn.8H, Vm.16B
                // SubtractWideningUpper(Vector128<UInt16>, Vector128<UInt16>)	uint32x4_t vsubl_high_u16 (uint16x8_t a, uint16x8_t b); A32: VSUBL.U16 Qd, Dn+1, Dm+1; A64: USUBL2 Vd.4S, Vn.8H, Vm.8H
                // SubtractWideningUpper(Vector128<UInt32>, Vector128<UInt16>)	uint32x4_t vsubw_high_u16 (uint32x4_t a, uint16x8_t b); A32: VSUBW.U16 Qd, Qn, Dm+1; A64: USUBW2 Vd.4S, Vn.4S, Vm.8H
                // SubtractWideningUpper(Vector128<UInt32>, Vector128<UInt32>)	uint64x2_t vsubl_high_u32 (uint32x4_t a, uint32x4_t b); A32: VSUBL.U32 Qd, Dn+1, Dm+1; A64: USUBL2 Vd.2D, Vn.4S, Vm.4S
                // SubtractWideningUpper(Vector128<UInt64>, Vector128<UInt32>)	uint64x2_t vsubw_high_u32 (uint64x2_t a, uint32x4_t b); A32: VSUBW.U32 Qd, Qn, Dm+1; A64: USUBW2 Vd.2D, Vn.2D, Vm.4S
            }
        }
        public unsafe static void RunArm_AdvSimd_V(TextWriter writer, string indent) {
            string indentNext = indent + IndentNextSeparator;
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
            // VectorTableLookup(Vector128<Byte>, Vector64<Byte>)	uint8x8_t vqvtbl1_u8(uint8x16_t t, uint8x8_t idx); A32: VTBL Dd, {Dn, Dn+1}, Dm; A64: TBL Vd.8B, {Vn.16B}, Vm.8B
            // VectorTableLookup(Vector128<SByte>, Vector64<SByte>)	int8x8_t vqvtbl1_s8(int8x16_t t, uint8x8_t idx); A32: VTBL Dd, {Dn, Dn+1}, Dm; A64: TBL Vd.8B, {Vn.16B}, Vm.8B
            if (true) {
                Vector128<byte> t = Vector128s<byte>.SerialNegative;
                Vector64<byte> idx = Vector64s<byte>.Serial;
                WriteLine(writer, indent, "VectorTableLookup<byte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.VectorTableLookup(t, idx));
                idx = Vector64s<byte>.SerialDesc;
                WriteLine(writer, indent, "VectorTableLookup<byte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.VectorTableLookup(t, idx));
                idx = Vector64s<byte>.Demo;
                WriteLine(writer, indent, "VectorTableLookup<byte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.VectorTableLookup(t, idx));
            }
            if (true) {
                Vector128<sbyte> t = Vector128s<sbyte>.SerialNegative;
                Vector64<sbyte> idx = Vector64s<sbyte>.Serial;
                WriteLine(writer, indent, "VectorTableLookup<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.VectorTableLookup(t, idx));
                idx = Vector64s<sbyte>.SerialDesc;
                WriteLine(writer, indent, "VectorTableLookup<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.VectorTableLookup(t, idx));
                idx = Vector64s<sbyte>.Demo;
                WriteLine(writer, indent, "VectorTableLookup<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.VectorTableLookup(t, idx));
                idx = Vector64.Create(-128, -2, 127, -1, 4, 16, 8, 7);
                WriteLine(writer, indent, "VectorTableLookup<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.VectorTableLookup(t, idx));
                idx = Vector64.Create(8, 9, 10, 11, 14, 15, 16, 17);
                WriteLine(writer, indent, "VectorTableLookup<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookup(t, idx):\t{0}", AdvSimd.VectorTableLookup(t, idx));
            }

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
            // VectorTableLookupExtension(Vector64<Byte>, Vector128<Byte>, Vector64<Byte>)	uint8x8_t vqvtbx1_u8(uint8x8_t r, uint8x16_t t, uint8x8_t idx); A32: VTBX Dd, {Dn, Dn+1}, Dm; A64: TBX Vd.8B, {Vn.16B}, Vm.8B
            // VectorTableLookupExtension(Vector64<SByte>, Vector128<SByte>, Vector64<SByte>)	int8x8_t vqvtbx1_s8(int8x8_t r, int8x16_t t, uint8x8_t idx); A32: VTBX Dd, {Dn, Dn+1}, Dm; A64: TBX Vd.8B, {Vn.16B}, Vm.8B
            if (true) {
                Vector64<sbyte> r = Vector64s<sbyte>.Serial;
                Vector128<sbyte> t = Vector128s<sbyte>.SerialNegative;
                Vector64<sbyte> idx = Vector64s<sbyte>.Serial;
                WriteLine(writer, indent, "VectorTableLookupExtension<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookupExtension(r, t, idx):\t{0}", AdvSimd.VectorTableLookupExtension(r, t, idx));
                idx = Vector64s<sbyte>.SerialDesc;
                WriteLine(writer, indent, "VectorTableLookupExtension<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookupExtension(r, t, idx):\t{0}", AdvSimd.VectorTableLookupExtension(r, t, idx));
                idx = Vector64s<sbyte>.Demo;
                WriteLine(writer, indent, "VectorTableLookupExtension<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookupExtension(r, t, idx):\t{0}", AdvSimd.VectorTableLookupExtension(r, t, idx));
                idx = Vector64.Create(-128, -2, 127, -1, 4, 16, 8, 7);
                WriteLine(writer, indent, "VectorTableLookupExtension<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookupExtension(t, idx):\t{0}", AdvSimd.VectorTableLookupExtension(r, t, idx));
                idx = Vector64.Create(8, 9, 10, 11, 14, 15, 16, 17);
                WriteLine(writer, indent, "VectorTableLookupExtension<sbyte>, idx={0}", idx);
                WriteLine(writer, indentNext, "VectorTableLookupExtension(t, idx):\t{0}", AdvSimd.VectorTableLookupExtension(r, t, idx));
            }
        }
        public unsafe static void RunArm_AdvSimd_X(TextWriter writer, string indent) {
            // Xor(Vector128<Byte>, Vector128<Byte>)	uint8x16_t veorq_u8 (uint8x16_t a, uint8x16_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B
            // Xor(Vector128<Double>, Vector128<Double>)	float64x2_t veorq_f64 (float64x2_t a, float64x2_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Xor(Vector128<Int16>, Vector128<Int16>)	int16x8_t veorq_s16 (int16x8_t a, int16x8_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B
            // Xor(Vector128<Int32>, Vector128<Int32>)	int32x4_t veorq_s32 (int32x4_t a, int32x4_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B
            // Xor(Vector128<Int64>, Vector128<Int64>)	int64x2_t veorq_s64 (int64x2_t a, int64x2_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B
            // Xor(Vector128<SByte>, Vector128<SByte>)	int8x16_t veorq_s8 (int8x16_t a, int8x16_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B
            // Xor(Vector128<Single>, Vector128<Single>)	float32x4_t veorq_f32 (float32x4_t a, float32x4_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Xor(Vector128<UInt16>, Vector128<UInt16>)	uint16x8_t veorq_u16 (uint16x8_t a, uint16x8_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B
            // Xor(Vector128<UInt32>, Vector128<UInt32>)	uint32x4_t veorq_u32 (uint32x4_t a, uint32x4_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B
            // Xor(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t veorq_u64 (uint64x2_t a, uint64x2_t b); A32: VEOR Qd, Qn, Qm; A64: EOR Vd.16B, Vn.16B, Vm.16B
            // Xor(Vector64<Byte>, Vector64<Byte>)	uint8x8_t veor_u8 (uint8x8_t a, uint8x8_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B
            // Xor(Vector64<Double>, Vector64<Double>)	float64x1_t veor_f64 (float64x1_t a, float64x1_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Xor(Vector64<Int16>, Vector64<Int16>)	int16x4_t veor_s16 (int16x4_t a, int16x4_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B
            // Xor(Vector64<Int32>, Vector64<Int32>)	int32x2_t veor_s32 (int32x2_t a, int32x2_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B
            // Xor(Vector64<Int64>, Vector64<Int64>)	int64x1_t veor_s64 (int64x1_t a, int64x1_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B
            // Xor(Vector64<SByte>, Vector64<SByte>)	int8x8_t veor_s8 (int8x8_t a, int8x8_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B
            // Xor(Vector64<Single>, Vector64<Single>)	float32x2_t veor_f32 (float32x2_t a, float32x2_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Xor(Vector64<UInt16>, Vector64<UInt16>)	uint16x4_t veor_u16 (uint16x4_t a, uint16x4_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B
            // Xor(Vector64<UInt32>, Vector64<UInt32>)	uint32x2_t veor_u32 (uint32x2_t a, uint32x2_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B
            // Xor(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t veor_u64 (uint64x1_t a, uint64x1_t b); A32: VEOR Dd, Dn, Dm; A64: EOR Vd.8B, Vn.8B, Vm.8B
        }
        public unsafe static void RunArm_AdvSimd_Z(TextWriter writer, string indent) {
            // ZeroExtendWideningLower(Vector64<Byte>)	uint16x8_t vmovl_u8 (uint8x8_t a); A32: VMOVL.U8 Qd, Dm; A64: UXTL Vd.8H, Vn.8B
            // ZeroExtendWideningLower(Vector64<Int16>)	uint32x4_t vmovl_u16 (uint16x4_t a); A32: VMOVL.U16 Qd, Dm; A64: UXTL Vd.4S, Vn.4H
            // ZeroExtendWideningLower(Vector64<Int32>)	uint64x2_t vmovl_u32 (uint32x2_t a); A32: VMOVL.U32 Qd, Dm; A64: UXTL Vd.2D, Vn.2S
            // ZeroExtendWideningLower(Vector64<SByte>)	uint16x8_t vmovl_u8 (uint8x8_t a); A32: VMOVL.U8 Qd, Dm; A64: UXTL Vd.8H, Vn.8B
            // ZeroExtendWideningLower(Vector64<UInt16>)	uint32x4_t vmovl_u16 (uint16x4_t a); A32: VMOVL.U16 Qd, Dm; A64: UXTL Vd.4S, Vn.4H
            // ZeroExtendWideningLower(Vector64<UInt32>)	uint64x2_t vmovl_u32 (uint32x2_t a); A32: VMOVL.U32 Qd, Dm; A64: UXTL Vd.2D, Vn.2S
            // ZeroExtendWideningUpper(Vector128<Byte>)	uint16x8_t vmovl_high_u8 (uint8x16_t a); A32: VMOVL.U8 Qd, Dm+1; A64: UXTL2 Vd.8H, Vn.16B
            // ZeroExtendWideningUpper(Vector128<Int16>)	uint32x4_t vmovl_high_u16 (uint16x8_t a); A32: VMOVL.U16 Qd, Dm+1; A64: UXTL2 Vd.4S, Vn.8H
            // ZeroExtendWideningUpper(Vector128<Int32>)	uint64x2_t vmovl_high_u32 (uint32x4_t a); A32: VMOVL.U32 Qd, Dm+1; A64: UXTL2 Vd.2D, Vn.4S
            // ZeroExtendWideningUpper(Vector128<SByte>)	uint16x8_t vmovl_high_u8 (uint8x16_t a); A32: VMOVL.U8 Qd, Dm+1; A64: UXTL2 Vd.8H, Vn.16B
            // ZeroExtendWideningUpper(Vector128<UInt16>)	uint32x4_t vmovl_high_u16 (uint16x8_t a); A32: VMOVL.U16 Qd, Dm+1; A64: UXTL2 Vd.4S, Vn.8H
            // ZeroExtendWideningUpper(Vector128<UInt32>)	uint64x2_t vmovl_high_u32 (uint32x4_t a); A32: VMOVL.U32 Qd, Dm+1; A64: UXTL2 Vd.2D, Vn.4S

        }

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
            // Abs(Vector128<Double>)	float64x2_t vabsq_f64 (float64x2_t a); A64: FABS Vd.2D, Vn.2D
            // Abs(Vector128<Int64>)	int64x2_t vabsq_s64 (int64x2_t a); A64: ABS Vd.2D, Vn.2D
            // AbsoluteCompareGreaterThan(Vector128<Double>, Vector128<Double>)	uint64x2_t vcagtq_f64 (float64x2_t a, float64x2_t b); A64: FACGT Vd.2D, Vn.2D, Vm.2D
            // AbsoluteCompareGreaterThanOrEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vcageq_f64 (float64x2_t a, float64x2_t b); A64: FACGE Vd.2D, Vn.2D, Vm.2D
            // AbsoluteCompareGreaterThanOrEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcage_f64 (float64x1_t a, float64x1_t b); A64: FACGE Dd, Dn, Dm
            // AbsoluteCompareGreaterThanOrEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcages_f32 (float32_t a, float32_t b); A64: FACGE Sd, Sn, Sm
            // AbsoluteCompareGreaterThanScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcagt_f64 (float64x1_t a, float64x1_t b); A64: FACGT Dd, Dn, Dm
            // AbsoluteCompareGreaterThanScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcagts_f32 (float32_t a, float32_t b); A64: FACGT Sd, Sn, Sm
            // AbsoluteCompareLessThan(Vector128<Double>, Vector128<Double>)	uint64x2_t vcaltq_f64 (float64x2_t a, float64x2_t b); A64: FACGT Vd.2D, Vn.2D, Vm.2D
            // AbsoluteCompareLessThanOrEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vcaleq_f64 (float64x2_t a, float64x2_t b); A64: FACGE Vd.2D, Vn.2D, Vm.2D
            // AbsoluteCompareLessThanOrEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcale_f64 (float64x1_t a, float64x1_t b); A64: FACGE Dd, Dn, Dm
            // AbsoluteCompareLessThanOrEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcales_f32 (float32_t a, float32_t b); A64: FACGE Sd, Sn, Sm
            // AbsoluteCompareLessThanScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcalt_f64 (float64x1_t a, float64x1_t b); A64: FACGT Dd, Dn, Dm
            // AbsoluteCompareLessThanScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcalts_f32 (float32_t a, float32_t b); A64: FACGT Sd, Sn, Sm
            // AbsoluteDifference(Vector128<Double>, Vector128<Double>)	float64x2_t vabdq_f64 (float64x2_t a, float64x2_t b); A64: FABD Vd.2D, Vn.2D, Vm.2D
            // AbsoluteDifferenceScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vabd_f64 (float64x1_t a, float64x1_t b); A64: FABD Dd, Dn, Dm
            // AbsoluteDifferenceScalar(Vector64<Single>, Vector64<Single>)	float32_t vabds_f32 (float32_t a, float32_t b); A64: FABD Sd, Sn, Sm
            // AbsSaturate(Vector128<Int64>)	int64x2_t vqabsq_s64 (int64x2_t a); A64: SQABS Vd.2D, Vn.2D
            // AbsSaturateScalar(Vector64<Int16>)	int16_t vqabsh_s16 (int16_t a); A64: SQABS Hd, Hn
            // AbsSaturateScalar(Vector64<Int32>)	int32_t vqabss_s32 (int32_t a); A64: SQABS Sd, Sn
            // AbsSaturateScalar(Vector64<Int64>)	int64_t vqabsd_s64 (int64_t a); A64: SQABS Dd, Dn
            // AbsSaturateScalar(Vector64<SByte>)	int8_t vqabsb_s8 (int8_t a); A64: SQABS Bd, Bn
            // AbsScalar(Vector64<Int64>)	int64x1_t vabs_s64 (int64x1_t a); A64: ABS Dd, Dn
            // Add(Vector128<Double>, Vector128<Double>)	float64x2_t vaddq_f64 (float64x2_t a, float64x2_t b); A64: FADD Vd.2D, Vn.2D, Vm.2D
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
        }
        public unsafe static void RunArm_AdvSimd_64_C(TextWriter writer, string indent) {
            // Ceiling(Vector128<Double>)	float64x2_t vrndpq_f64 (float64x2_t a); A64: FRINTP Vd.2D, Vn.2D
            // CompareEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vceqq_f64 (float64x2_t a, float64x2_t b); A64: FCMEQ Vd.2D, Vn.2D, Vm.2D
            // CompareEqual(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vceqq_s64 (int64x2_t a, int64x2_t b); A64: CMEQ Vd.2D, Vn.2D, Vm.2D
            // CompareEqual(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vceqq_u64 (uint64x2_t a, uint64x2_t b); A64: CMEQ Vd.2D, Vn.2D, Vm.2D
            // CompareEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vceq_f64 (float64x1_t a, float64x1_t b); A64: FCMEQ Dd, Dn, Dm
            // CompareEqualScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vceq_s64 (int64x1_t a, int64x1_t b); A64: CMEQ Dd, Dn, Dm
            // CompareEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vceqs_f32 (float32_t a, float32_t b); A64: FCMEQ Sd, Sn, Sm
            // CompareEqualScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vceq_u64 (uint64x1_t a, uint64x1_t b); A64: CMEQ Dd, Dn, Dm
            // CompareGreaterThan(Vector128<Double>, Vector128<Double>)	uint64x2_t vcgtq_f64 (float64x2_t a, float64x2_t b); A64: FCMGT Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThan(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vcgtq_s64 (int64x2_t a, int64x2_t b); A64: CMGT Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThan(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vcgtq_u64 (uint64x2_t a, uint64x2_t b); A64: CMHI Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThanOrEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vcgeq_f64 (float64x2_t a, float64x2_t b); A64: FCMGE Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThanOrEqual(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vcgeq_s64 (int64x2_t a, int64x2_t b); A64: CMGE Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThanOrEqual(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vcgeq_u64 (uint64x2_t a, uint64x2_t b); A64: CMHS Vd.2D, Vn.2D, Vm.2D
            // CompareGreaterThanOrEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcge_f64 (float64x1_t a, float64x1_t b); A64: FCMGE Dd, Dn, Dm
            // CompareGreaterThanOrEqualScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vcge_s64 (int64x1_t a, int64x1_t b); A64: CMGE Dd, Dn, Dm
            // CompareGreaterThanOrEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcges_f32 (float32_t a, float32_t b); A64: FCMGE Sd, Sn, Sm
            // CompareGreaterThanOrEqualScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vcge_u64 (uint64x1_t a, uint64x1_t b); A64: CMHS Dd, Dn, Dm
            // CompareGreaterThanScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcgt_f64 (float64x1_t a, float64x1_t b); A64: FCMGT Dd, Dn, Dm
            // CompareGreaterThanScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vcgt_s64 (int64x1_t a, int64x1_t b); A64: CMGT Dd, Dn, Dm
            // CompareGreaterThanScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcgts_f32 (float32_t a, float32_t b); A64: FCMGT Sd, Sn, Sm
            // CompareGreaterThanScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vcgt_u64 (uint64x1_t a, uint64x1_t b); A64: CMHI Dd, Dn, Dm
            // CompareLessThan(Vector128<Double>, Vector128<Double>)	uint64x2_t vcltq_f64 (float64x2_t a, float64x2_t b); A64: FCMGT Vd.2D, Vn.2D, Vm.2D
            // CompareLessThan(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vcltq_s64 (int64x2_t a, int64x2_t b); A64: CMGT Vd.2D, Vn.2D, Vm.2D
            // CompareLessThan(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vcltq_u64 (uint64x2_t a, uint64x2_t b); A64: CMHI Vd.2D, Vn.2D, Vm.2D
            // CompareLessThanOrEqual(Vector128<Double>, Vector128<Double>)	uint64x2_t vcleq_f64 (float64x2_t a, float64x2_t b); A64: FCMGE Vd.2D, Vn.2D, Vm.2D
            // CompareLessThanOrEqual(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vcleq_s64 (int64x2_t a, int64x2_t b); A64: CMGE Vd.2D, Vn.2D, Vm.2D
            // CompareLessThanOrEqual(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vcleq_u64 (uint64x2_t a, uint64x2_t b); A64: CMHS Vd.2D, Vn.2D, Vm.2D
            // CompareLessThanOrEqualScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vcle_f64 (float64x1_t a, float64x1_t b); A64: FCMGE Dd, Dn, Dm
            // CompareLessThanOrEqualScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vcle_s64 (int64x1_t a, int64x1_t b); A64: CMGE Dd, Dn, Dm
            // CompareLessThanOrEqualScalar(Vector64<Single>, Vector64<Single>)	uint32_t vcles_f32 (float32_t a, float32_t b); A64: FCMGE Sd, Sn, Sm
            // CompareLessThanOrEqualScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vcle_u64 (uint64x1_t a, uint64x1_t b); A64: CMHS Dd, Dn, Dm
            // CompareLessThanScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vclt_f64 (float64x1_t a, float64x1_t b); A64: FCMGT Dd, Dn, Dm
            // CompareLessThanScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vclt_s64 (int64x1_t a, int64x1_t b); A64: CMGT Dd, Dn, Dm
            // CompareLessThanScalar(Vector64<Single>, Vector64<Single>)	uint32_t vclts_f32 (float32_t a, float32_t b); A64: FCMGT Sd, Sn, Sm
            // CompareLessThanScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vclt_u64 (uint64x1_t a, uint64x1_t b); A64: CMHI Dd, Dn, Dm
            // CompareTest(Vector128<Double>, Vector128<Double>)	uint64x2_t vtstq_f64 (float64x2_t a, float64x2_t b); A64: CMTST Vd.2D, Vn.2D, Vm.2D The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // CompareTest(Vector128<Int64>, Vector128<Int64>)	uint64x2_t vtstq_s64 (int64x2_t a, int64x2_t b); A64: CMTST Vd.2D, Vn.2D, Vm.2D
            // CompareTest(Vector128<UInt64>, Vector128<UInt64>)	uint64x2_t vtstq_u64 (uint64x2_t a, uint64x2_t b); A64: CMTST Vd.2D, Vn.2D, Vm.2D
            // CompareTestScalar(Vector64<Double>, Vector64<Double>)	uint64x1_t vtst_f64 (float64x1_t a, float64x1_t b); A64: CMTST Dd, Dn, Dm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // CompareTestScalar(Vector64<Int64>, Vector64<Int64>)	uint64x1_t vtst_s64 (int64x1_t a, int64x1_t b); A64: CMTST Dd, Dn, Dm
            // CompareTestScalar(Vector64<UInt64>, Vector64<UInt64>)	uint64x1_t vtst_u64 (uint64x1_t a, uint64x1_t b); A64: CMTST Dd, Dn, Dm
            // ConvertToDouble(Vector128<Int64>)	float64x2_t vcvtq_f64_s64 (int64x2_t a); A64: SCVTF Vd.2D, Vn.2D
            // ConvertToDouble(Vector128<UInt64>)	float64x2_t vcvtq_f64_u64 (uint64x2_t a); A64: UCVTF Vd.2D, Vn.2D
            // ConvertToDouble(Vector64<Single>)	float64x2_t vcvt_f64_f32 (float32x2_t a); A64: FCVTL Vd.2D, Vn.2S
            // ConvertToDoubleScalar(Vector64<Int64>)	float64x1_t vcvt_f64_s64 (int64x1_t a); A64: SCVTF Dd, Dn
            // ConvertToDoubleScalar(Vector64<UInt64>)	float64x1_t vcvt_f64_u64 (uint64x1_t a); A64: UCVTF Dd, Dn
            // ConvertToDoubleUpper(Vector128<Single>)	float64x2_t vcvt_high_f64_f32 (float32x4_t a); A64: FCVTL2 Vd.2D, Vn.4S
            // ConvertToInt64RoundAwayFromZero(Vector128<Double>)	int64x2_t vcvtaq_s64_f64 (float64x2_t a); A64: FCVTAS Vd.2D, Vn.2D
            // ConvertToInt64RoundAwayFromZeroScalar(Vector64<Double>)	int64x1_t vcvta_s64_f64 (float64x1_t a); A64: FCVTAS Dd, Dn
            // ConvertToInt64RoundToEven(Vector128<Double>)	int64x2_t vcvtnq_s64_f64 (float64x2_t a); A64: FCVTNS Vd.2D, Vn.2D
            // ConvertToInt64RoundToEvenScalar(Vector64<Double>)	int64x1_t vcvtn_s64_f64 (float64x1_t a); A64: FCVTNS Dd, Dn
            // ConvertToInt64RoundToNegativeInfinity(Vector128<Double>)	int64x2_t vcvtmq_s64_f64 (float64x2_t a); A64: FCVTMS Vd.2D, Vn.2D
            // ConvertToInt64RoundToNegativeInfinityScalar(Vector64<Double>)	int64x1_t vcvtm_s64_f64 (float64x1_t a); A64: FCVTMS Dd, Dn
            // ConvertToInt64RoundToPositiveInfinity(Vector128<Double>)	int64x2_t vcvtpq_s64_f64 (float64x2_t a); A64: FCVTPS Vd.2D, Vn.2D
            // ConvertToInt64RoundToPositiveInfinityScalar(Vector64<Double>)	int64x1_t vcvtp_s64_f64 (float64x1_t a); A64: FCVTPS Dd, Dn
            // ConvertToInt64RoundToZero(Vector128<Double>)	int64x2_t vcvtq_s64_f64 (float64x2_t a); A64: FCVTZS Vd.2D, Vn.2D
            // ConvertToInt64RoundToZeroScalar(Vector64<Double>)	int64x1_t vcvt_s64_f64 (float64x1_t a); A64: FCVTZS Dd, Dn
            // ConvertToSingleLower(Vector128<Double>)	float32x2_t vcvt_f32_f64 (float64x2_t a); A64: FCVTN Vd.2S, Vn.2D
            // ConvertToSingleRoundToOddLower(Vector128<Double>)	float32x2_t vcvtx_f32_f64 (float64x2_t a); A64: FCVTXN Vd.2S, Vn.2D
            // ConvertToSingleRoundToOddUpper(Vector64<Single>, Vector128<Double>)	float32x4_t vcvtx_high_f32_f64 (float32x2_t r, float64x2_t a); A64: FCVTXN2 Vd.4S, Vn.2D
            // ConvertToSingleUpper(Vector64<Single>, Vector128<Double>)	float32x4_t vcvt_high_f32_f64 (float32x2_t r, float64x2_t a); A64: FCVTN2 Vd.4S, Vn.2D
            // ConvertToUInt64RoundAwayFromZero(Vector128<Double>)	uint64x2_t vcvtaq_u64_f64 (float64x2_t a); A64: FCVTAU Vd.2D, Vn.2D
            // ConvertToUInt64RoundAwayFromZeroScalar(Vector64<Double>)	uint64x1_t vcvta_u64_f64 (float64x1_t a); A64: FCVTAU Dd, Dn
            // ConvertToUInt64RoundToEven(Vector128<Double>)	uint64x2_t vcvtnq_u64_f64 (float64x2_t a); A64: FCVTNU Vd.2D, Vn.2D
            // ConvertToUInt64RoundToEvenScalar(Vector64<Double>)	uint64x1_t vcvtn_u64_f64 (float64x1_t a); A64: FCVTNU Dd, Dn
            // ConvertToUInt64RoundToNegativeInfinity(Vector128<Double>)	uint64x2_t vcvtmq_u64_f64 (float64x2_t a); A64: FCVTMU Vd.2D, Vn.2D
            // ConvertToUInt64RoundToNegativeInfinityScalar(Vector64<Double>)	uint64x1_t vcvtm_u64_f64 (float64x1_t a); A64: FCVTMU Dd, Dn
            // ConvertToUInt64RoundToPositiveInfinity(Vector128<Double>)	uint64x2_t vcvtpq_u64_f64 (float64x2_t a); A64: FCVTPU Vd.2D, Vn.2D
            // ConvertToUInt64RoundToPositiveInfinityScalar(Vector64<Double>)	uint64x1_t vcvtp_u64_f64 (float64x1_t a); A64: FCVTPU Dd, Dn
            // ConvertToUInt64RoundToZero(Vector128<Double>)	uint64x2_t vcvtq_u64_f64 (float64x2_t a); A64: FCVTZU Vd.2D, Vn.2D
            // ConvertToUInt64RoundToZeroScalar(Vector64<Double>)	uint64x1_t vcvt_u64_f64 (float64x1_t a); A64: FCVTZU Dd, Dn
        }
        public unsafe static void RunArm_AdvSimd_64_D(TextWriter writer, string indent) {
            // Divide(Vector128<Double>, Vector128<Double>)	float64x2_t vdivq_f64 (float64x2_t a, float64x2_t b); A64: FDIV Vd.2D, Vn.2D, Vm.2D
            // Divide(Vector128<Single>, Vector128<Single>)	float32x4_t vdivq_f32 (float32x4_t a, float32x4_t b); A64: FDIV Vd.4S, Vn.4S, Vm.4S
            // Divide(Vector64<Single>, Vector64<Single>)	float32x2_t vdiv_f32 (float32x2_t a, float32x2_t b); A64: FDIV Vd.2S, Vn.2S, Vm.2S
            // DuplicateSelectedScalarToVector128(Vector128<Double>, Byte)	float64x2_t vdupq_laneq_f64 (float64x2_t vec, const int lane); A64: DUP Vd.2D, Vn.D[index]
            // DuplicateSelectedScalarToVector128(Vector128<Int64>, Byte)	int64x2_t vdupq_laneq_s64 (int64x2_t vec, const int lane); A64: DUP Vd.2D, Vn.D[index]
            // DuplicateSelectedScalarToVector128(Vector128<UInt64>, Byte)	uint64x2_t vdupq_laneq_u64 (uint64x2_t vec, const int lane); A64: DUP Vd.2D, Vn.D[index]
            // DuplicateToVector128(Double)	float64x2_t vdupq_n_f64 (float64_t value); A64: DUP Vd.2D, Vn.D[0]
            // DuplicateToVector128(Int64)	int64x2_t vdupq_n_s64 (int64_t value); A64: DUP Vd.2D, Rn
            // DuplicateToVector128(UInt64)	uint64x2_t vdupq_n_s64 (uint64_t value); A64: DUP Vd.2D, Rn
            // ExtractNarrowingSaturateScalar(Vector64<Int16>)	int8_t vqmovnh_s16 (int16_t a) A64: SQXTN Bd, Hn
            // ExtractNarrowingSaturateScalar(Vector64<Int32>)	int16_t vqmovns_s32 (int32_t a) A64: SQXTN Hd, Sn
            // ExtractNarrowingSaturateScalar(Vector64<Int64>)	int32_t vqmovnd_s64 (int64_t a) A64: SQXTN Sd, Dn
            // ExtractNarrowingSaturateScalar(Vector64<UInt16>)	uint8_t vqmovnh_u16 (uint16_t a) A64: UQXTN Bd, Hn
            // ExtractNarrowingSaturateScalar(Vector64<UInt32>)	uint16_t vqmovns_u32 (uint32_t a) A64: UQXTN Hd, Sn
            // ExtractNarrowingSaturateScalar(Vector64<UInt64>)	uint32_t vqmovnd_u64 (uint64_t a) A64: UQXTN Sd, Dn
            // ExtractNarrowingSaturateUnsignedScalar(Vector64<Int16>)	uint8_t vqmovunh_s16 (int16_t a) A64: SQXTUN Bd, Hn
            // ExtractNarrowingSaturateUnsignedScalar(Vector64<Int32>)	uint16_t vqmovuns_s32 (int32_t a) A64: SQXTUN Hd, Sn
            // ExtractNarrowingSaturateUnsignedScalar(Vector64<Int64>)	uint32_t vqmovund_s64 (int64_t a) A64: SQXTUN Sd, Dn
        }
        public unsafe static void RunArm_AdvSimd_64_F(TextWriter writer, string indent) {
            // Floor(Vector128<Double>)	float64x2_t vrndmq_f64 (float64x2_t a); A64: FRINTM Vd.2D, Vn.2D
            // FusedMultiplyAdd(Vector128<Double>, Vector128<Double>, Vector128<Double>)	float64x2_t vfmaq_f64 (float64x2_t a, float64x2_t b, float64x2_t c); A64: FMLA Vd.2D, Vn.2D, Vm.2D
            // FusedMultiplyAddByScalar(Vector128<Double>, Vector128<Double>, Vector64<Double>)	float64x2_t vfmaq_n_f64 (float64x2_t a, float64x2_t b, float64_t n); A64: FMLA Vd.2D, Vn.2D, Vm.D[0]
            // FusedMultiplyAddByScalar(Vector128<Single>, Vector128<Single>, Vector64<Single>)	float32x4_t vfmaq_n_f32 (float32x4_t a, float32x4_t b, float32_t n); A64: FMLA Vd.4S, Vn.4S, Vm.S[0]
            // FusedMultiplyAddByScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32x2_t vfma_n_f32 (float32x2_t a, float32x2_t b, float32_t n); A64: FMLA Vd.2S, Vn.2S, Vm.S[0]
            // FusedMultiplyAddBySelectedScalar(Vector128<Double>, Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vfmaq_laneq_f64 (float64x2_t a, float64x2_t b, float64x2_t v, const int lane); A64: FMLA Vd.2D, Vn.2D, Vm.D[lane]
            // FusedMultiplyAddBySelectedScalar(Vector128<Single>, Vector128<Single>, Vector128<Single>, Byte)	float32x4_t vfmaq_laneq_f32 (float32x4_t a, float32x4_t b, float32x4_t v, const int lane); A64: FMLA Vd.4S, Vn.4S, Vm.S[lane]
            // FusedMultiplyAddBySelectedScalar(Vector128<Single>, Vector128<Single>, Vector64<Single>, Byte)	float32x4_t vfmaq_lane_f32 (float32x4_t a, float32x4_t b, float32x2_t v, const int lane); A64: FMLA Vd.4S, Vn.4S, Vm.S[lane]
            // FusedMultiplyAddBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector128<Single>, Byte)	float32x2_t vfma_laneq_f32 (float32x2_t a, float32x2_t b, float32x4_t v, const int lane); A64: FMLA Vd.2S, Vn.2S, Vm.S[lane]
            // FusedMultiplyAddBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>, Byte)	float32x2_t vfma_lane_f32 (float32x2_t a, float32x2_t b, float32x2_t v, const int lane); A64: FMLA Vd.2S, Vn.2S, Vm.S[lane]
            // FusedMultiplyAddScalarBySelectedScalar(Vector64<Double>, Vector64<Double>, Vector128<Double>, Byte)	float64_t vfmad_laneq_f64 (float64_t a, float64_t b, float64x2_t v, const int lane); A64: FMLA Dd, Dn, Vm.D[lane]
            // FusedMultiplyAddScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector128<Single>, Byte)	float32_t vfmas_laneq_f32 (float32_t a, float32_t b, float32x4_t v, const int lane); A64: FMLA Sd, Sn, Vm.S[lane]
            // FusedMultiplyAddScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>, Byte)	float32_t vfmas_lane_f32 (float32_t a, float32_t b, float32x2_t v, const int lane); A64: FMLA Sd, Sn, Vm.S[lane]
            // FusedMultiplySubtract(Vector128<Double>, Vector128<Double>, Vector128<Double>)	float64x2_t vfmsq_f64 (float64x2_t a, float64x2_t b, float64x2_t c); A64: FMLS Vd.2D, Vn.2D, Vm.2D
            // FusedMultiplySubtractByScalar(Vector128<Double>, Vector128<Double>, Vector64<Double>)	float64x2_t vfmsq_n_f64 (float64x2_t a, float64x2_t b, float64_t n); A64: FMLS Vd.2D, Vn.2D, Vm.D[0]
            // FusedMultiplySubtractByScalar(Vector128<Single>, Vector128<Single>, Vector64<Single>)	float32x4_t vfmsq_n_f32 (float32x4_t a, float32x4_t b, float32_t n); A64: FMLS Vd.4S, Vn.4S, Vm.S[0]
            // FusedMultiplySubtractByScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>)	float32x2_t vfms_n_f32 (float32x2_t a, float32x2_t b, float32_t n); A64: FMLS Vd.2S, Vn.2S, Vm.S[0]
            // FusedMultiplySubtractBySelectedScalar(Vector128<Double>, Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vfmsq_laneq_f64 (float64x2_t a, float64x2_t b, float64x2_t v, const int lane); A64: FMLS Vd.2D, Vn.2D, Vm.D[lane]
            // FusedMultiplySubtractBySelectedScalar(Vector128<Single>, Vector128<Single>, Vector128<Single>, Byte)	float32x4_t vfmsq_laneq_f32 (float32x4_t a, float32x4_t b, float32x4_t v, const int lane); A64: FMLS Vd.4S, Vn.4S, Vm.S[lane]
            // FusedMultiplySubtractBySelectedScalar(Vector128<Single>, Vector128<Single>, Vector64<Single>, Byte)	float32x4_t vfmsq_lane_f32 (float32x4_t a, float32x4_t b, float32x2_t v, const int lane); A64: FMLS Vd.4S, Vn.4S, Vm.S[lane]
            // FusedMultiplySubtractBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector128<Single>, Byte)	float32x2_t vfms_laneq_f32 (float32x2_t a, float32x2_t b, float32x4_t v, const int lane); A64: FMLS Vd.2S, Vn.2S, Vm.S[lane]
            // FusedMultiplySubtractBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>, Byte)	float32x2_t vfms_lane_f32 (float32x2_t a, float32x2_t b, float32x2_t v, const int lane); A64: FMLS Vd.2S, Vn.2S, Vm.S[lane]
            // FusedMultiplySubtractScalarBySelectedScalar(Vector64<Double>, Vector64<Double>, Vector128<Double>, Byte)	float64_t vfmsd_laneq_f64 (float64_t a, float64_t b, float64x2_t v, const int lane); A64: FMLS Dd, Dn, Vm.D[lane]
            // FusedMultiplySubtractScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector128<Single>, Byte)	float32_t vfmss_laneq_f32 (float32_t a, float32_t b, float32x4_t v, const int lane); A64: FMLS Sd, Sn, Vm.S[lane]
            // FusedMultiplySubtractScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Vector64<Single>, Byte)	float32_t vfmss_lane_f32 (float32_t a, float32_t b, float32x2_t v, const int lane); A64: FMLS Sd, Sn, Vm.S[lane]
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
        }
        public unsafe static void RunArm_AdvSimd_64_L(TextWriter writer, string indent) {
            // LoadAndReplicateToVector128(Double*)	float64x2_t vld1q_dup_f64 (float64_t const * ptr); A64: LD1R { Vt.2D }, [Xn]
            // LoadAndReplicateToVector128(Int64*)	int64x2_t vld1q_dup_s64 (int64_t const * ptr); A64: LD1R { Vt.2D }, [Xn]
            // LoadAndReplicateToVector128(UInt64*)	uint64x2_t vld1q_dup_u64 (uint64_t const * ptr); A64: LD1R { Vt.2D }, [Xn]
            // LoadPairScalarVector64(Int32*)	A64: LDP St1, St2, [Xn]
            // LoadPairScalarVector64(Single*)	A64: LDP St1, St2, [Xn]
            // LoadPairScalarVector64(UInt32*)	A64: LDP St1, St2, [Xn]
            // LoadPairScalarVector64NonTemporal(Int32*)	A64: LDNP St1, St2, [Xn]
            // LoadPairScalarVector64NonTemporal(Single*)	A64: LDNP St1, St2, [Xn]
            // LoadPairScalarVector64NonTemporal(UInt32*)	A64: LDNP St1, St2, [Xn]
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
        }
        public unsafe static void RunArm_AdvSimd_64_M(TextWriter writer, string indent) {
            // Max(Vector128<Double>, Vector128<Double>)	float64x2_t vmaxq_f64 (float64x2_t a, float64x2_t b); A64: FMAX Vd.2D, Vn.2D, Vm.2D
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
            // MaxNumber(Vector128<Double>, Vector128<Double>)	float64x2_t vmaxnmq_f64 (float64x2_t a, float64x2_t b); A64: FMAXNM Vd.2D, Vn.2D, Vm.2D
            // MaxNumberAcross(Vector128<Single>)	float32_t vmaxnmvq_f32 (float32x4_t a); A64: FMAXNMV Sd, Vn.4S
            // MaxNumberPairwise(Vector128<Double>, Vector128<Double>)	float64x2_t vpmaxnmq_f64 (float64x2_t a, float64x2_t b); A64: FMAXNMP Vd.2D, Vn.2D, Vm.2D
            // MaxNumberPairwise(Vector128<Single>, Vector128<Single>)	float32x4_t vpmaxnmq_f32 (float32x4_t a, float32x4_t b); A64: FMAXNMP Vd.4S, Vn.4S, Vm.4S
            // MaxNumberPairwise(Vector64<Single>, Vector64<Single>)	float32x2_t vpmaxnm_f32 (float32x2_t a, float32x2_t b); A64: FMAXNMP Vd.2S, Vn.2S, Vm.2S
            // MaxNumberPairwiseScalar(Vector128<Double>)	float64_t vpmaxnmqd_f64 (float64x2_t a); A64: FMAXNMP Dd, Vn.2D
            // MaxNumberPairwiseScalar(Vector64<Single>)	float32_t vpmaxnms_f32 (float32x2_t a); A64: FMAXNMP Sd, Vn.2S
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
            // MaxScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vmax_f64 (float64x1_t a, float64x1_t b); A64: FMAX Dd, Dn, Dm
            // MaxScalar(Vector64<Single>, Vector64<Single>)	float32_t vmaxs_f32 (float32_t a, float32_t b); A64: FMAX Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Min(Vector128<Double>, Vector128<Double>)	float64x2_t vminq_f64 (float64x2_t a, float64x2_t b); A64: FMIN Vd.2D, Vn.2D, Vm.2D
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
            // MinNumber(Vector128<Double>, Vector128<Double>)	float64x2_t vminnmq_f64 (float64x2_t a, float64x2_t b); A64: FMINNM Vd.2D, Vn.2D, Vm.2D
            // MinNumberAcross(Vector128<Single>)	float32_t vminnmvq_f32 (float32x4_t a); A64: FMINNMV Sd, Vn.4S
            // MinNumberPairwise(Vector128<Double>, Vector128<Double>)	float64x2_t vpminnmq_f64 (float64x2_t a, float64x2_t b); A64: FMINNMP Vd.2D, Vn.2D, Vm.2D
            // MinNumberPairwise(Vector128<Single>, Vector128<Single>)	float32x4_t vpminnmq_f32 (float32x4_t a, float32x4_t b); A64: FMINNMP Vd.4S, Vn.4S, Vm.4S
            // MinNumberPairwise(Vector64<Single>, Vector64<Single>)	float32x2_t vpminnm_f32 (float32x2_t a, float32x2_t b); A64: FMINNMP Vd.2S, Vn.2S, Vm.2S
            // MinNumberPairwiseScalar(Vector128<Double>)	float64_t vpminnmqd_f64 (float64x2_t a); A64: FMINNMP Dd, Vn.2D
            // MinNumberPairwiseScalar(Vector64<Single>)	float32_t vpminnms_f32 (float32x2_t a); A64: FMINNMP Sd, Vn.2S
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
            // MinScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vmin_f64 (float64x1_t a, float64x1_t b); A64: FMIN Dd, Dn, Dm
            // MinScalar(Vector64<Single>, Vector64<Single>)	float32_t vmins_f32 (float32_t a, float32_t b); A64: FMIN Sd, Sn, Sm The above native signature does not exist. We provide this additional overload for consistency with the other scalar APIs.
            // Multiply(Vector128<Double>, Vector128<Double>)	float64x2_t vmulq_f64 (float64x2_t a, float64x2_t b); A64: FMUL Vd.2D, Vn.2D, Vm.2D
            // MultiplyByScalar(Vector128<Double>, Vector64<Double>)	float64x2_t vmulq_n_f64 (float64x2_t a, float64_t b); A64: FMUL Vd.2D, Vn.2D, Vm.D[0]
            // MultiplyBySelectedScalar(Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vmulq_laneq_f64 (float64x2_t a, float64x2_t v, const int lane); A64: FMUL Vd.2D, Vn.2D, Vm.D[lane]
            // MultiplyDoublingSaturateHighScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqdmulhh_s16 (int16_t a, int16_t b) A64: SQDMULH Hd, Hn, Hm
            // MultiplyDoublingSaturateHighScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqdmulhs_s32 (int32_t a, int32_t b) A64: SQDMULH Sd, Sn, Sm
            // MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int16>, Vector128<Int16>, Byte)	int16_t vqdmulhh_laneq_s16 (int16_t a, int16x8_t v, const int lane) A64: SQDMULH Hd, Hn, Vm.H[lane]
            // MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int16>, Vector64<Int16>, Byte)	int16_t vqdmulhh_lane_s16 (int16_t a, int16x4_t v, const int lane) A64: SQDMULH Hd, Hn, Vm.H[lane]
            // MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int32>, Vector128<Int32>, Byte)	int32_t vqdmulhs_laneq_s32 (int32_t a, int32x4_t v, const int lane) A64: SQDMULH Sd, Sn, Vm.S[lane]
            // MultiplyDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int32>, Vector64<Int32>, Byte)	int32_t vqdmulhs_lane_s32 (int32_t a, int32x2_t v, const int lane) A64: SQDMULH Sd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningAndAddSaturateScalar(Vector64<Int32>, Vector64<Int16>, Vector64<Int16>)	int32_t vqdmlalh_s16 (int32_t a, int16_t b, int16_t c) A64: SQDMLAL Sd, Hn, Hm
            // MultiplyDoublingWideningAndAddSaturateScalar(Vector64<Int64>, Vector64<Int32>, Vector64<Int32>)	int64_t vqdmlals_s32 (int64_t a, int32_t b, int32_t c) A64: SQDMLAL Dd, Sn, Sm
            // MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64<Int32>, Vector64<Int16>, Vector64<Int16>)	int32_t vqdmlslh_s16 (int32_t a, int16_t b, int16_t c) A64: SQDMLSL Sd, Hn, Hm
            // MultiplyDoublingWideningAndSubtractSaturateScalar(Vector64<Int64>, Vector64<Int32>, Vector64<Int32>)	int64_t vqdmlsls_s32 (int64_t a, int32_t b, int32_t c) A64: SQDMLSL Dd, Sn, Sm
            // MultiplyDoublingWideningSaturateScalar(Vector64<Int16>, Vector64<Int16>)	int32_t vqdmullh_s16 (int16_t a, int16_t b) A64: SQDMULL Sd, Hn, Hm
            // MultiplyDoublingWideningSaturateScalar(Vector64<Int32>, Vector64<Int32>)	int64_t vqdmulls_s32 (int32_t a, int32_t b) A64: SQDMULL Dd, Sn, Sm
            // MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<Int16>, Vector128<Int16>, Byte)	int32_t vqdmullh_laneq_s16 (int16_t a, int16x8_t v, const int lane) A64: SQDMULL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<Int16>, Vector64<Int16>, Byte)	int32_t vqdmullh_lane_s16 (int16_t a, int16x4_t v, const int lane) A64: SQDMULL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<Int32>, Vector128<Int32>, Byte)	int64_t vqdmulls_laneq_s32 (int32_t a, int32x4_t v, const int lane) A64: SQDMULL Dd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningSaturateScalarBySelectedScalar(Vector64<Int32>, Vector64<Int32>, Byte)	int64_t vqdmulls_lane_s32 (int32_t a, int32x2_t v, const int lane) A64: SQDMULL Dd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<Int32>, Vector64<Int16>, Vector128<Int16>, Byte)	int32_t vqdmlalh_laneq_s16 (int32_t a, int16_t b, int16x8_t v, const int lane) A64: SQDMLAL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<Int32>, Vector64<Int16>, Vector64<Int16>, Byte)	int32_t vqdmlalh_lane_s16 (int32_t a, int16_t b, int16x4_t v, const int lane) A64: SQDMLAL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<Int64>, Vector64<Int32>, Vector128<Int32>, Byte)	int64_t vqdmlals_laneq_s32 (int64_t a, int32_t b, int32x4_t v, const int lane) A64: SQDMLAL Dd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndAddSaturate(Vector64<Int64>, Vector64<Int32>, Vector64<Int32>, Byte)	int64_t vqdmlals_lane_s32 (int64_t a, int32_t b, int32x2_t v, const int lane) A64: SQDMLAL Dd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<Int32>, Vector64<Int16>, Vector128<Int16>, Byte)	int32_t vqdmlslh_laneq_s16 (int32_t a, int16_t b, int16x8_t v, const int lane) A64: SQDMLSL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<Int32>, Vector64<Int16>, Vector64<Int16>, Byte)	int32_t vqdmlslh_lane_s16 (int32_t a, int16_t b, int16x4_t v, const int lane) A64: SQDMLSL Sd, Hn, Vm.H[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<Int64>, Vector64<Int32>, Vector128<Int32>, Byte)	int64_t vqdmlsls_laneq_s32 (int64_t a, int32_t b, int32x4_t v, const int lane) A64: SQDMLSL Dd, Sn, Vm.S[lane]
            // MultiplyDoublingWideningScalarBySelectedScalarAndSubtractSaturate(Vector64<Int64>, Vector64<Int32>, Vector64<Int32>, Byte)	int64_t vqdmlsls_lane_s32 (int64_t a, int32_t b, int32x2_t v, const int lane) A64: SQDMLSL Dd, Sn, Vm.S[lane]
            // MultiplyExtended(Vector128<Double>, Vector128<Double>)	float64x2_t vmulxq_f64 (float64x2_t a, float64x2_t b); A64: FMULX Vd.2D, Vn.2D, Vm.2D
            // MultiplyExtended(Vector128<Single>, Vector128<Single>)	float32x4_t vmulxq_f32 (float32x4_t a, float32x4_t b); A64: FMULX Vd.4S, Vn.4S, Vm.4S
            // MultiplyExtended(Vector64<Single>, Vector64<Single>)	float32x2_t vmulx_f32 (float32x2_t a, float32x2_t b); A64: FMULX Vd.2S, Vn.2S, Vm.2S
            // MultiplyExtendedByScalar(Vector128<Double>, Vector64<Double>)	float64x2_t vmulxq_lane_f64 (float64x2_t a, float64x1_t v, const int lane); A64: FMULX Vd.2D, Vn.2D, Vm.D[0]
            // MultiplyExtendedBySelectedScalar(Vector128<Double>, Vector128<Double>, Byte)	float64x2_t vmulxq_laneq_f64 (float64x2_t a, float64x2_t v, const int lane); A64: FMULX Vd.2D, Vn.2D, Vm.D[lane]
            // MultiplyExtendedBySelectedScalar(Vector128<Single>, Vector128<Single>, Byte)	float32x4_t vmulxq_laneq_f32 (float32x4_t a, float32x4_t v, const int lane); A64: FMULX Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyExtendedBySelectedScalar(Vector128<Single>, Vector64<Single>, Byte)	float32x4_t vmulxq_lane_f32 (float32x4_t a, float32x2_t v, const int lane); A64: FMULX Vd.4S, Vn.4S, Vm.S[lane]
            // MultiplyExtendedBySelectedScalar(Vector64<Single>, Vector128<Single>, Byte)	float32x2_t vmulx_laneq_f32 (float32x2_t a, float32x4_t v, const int lane); A64: FMULX Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyExtendedBySelectedScalar(Vector64<Single>, Vector64<Single>, Byte)	float32x2_t vmulx_lane_f32 (float32x2_t a, float32x2_t v, const int lane); A64: FMULX Vd.2S, Vn.2S, Vm.S[lane]
            // MultiplyExtendedScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vmulx_f64 (float64x1_t a, float64x1_t b); A64: FMULX Dd, Dn, Dm
            // MultiplyExtendedScalar(Vector64<Single>, Vector64<Single>)	float32_t vmulxs_f32 (float32_t a, float32_t b); A64: FMULX Sd, Sn, Sm
            // MultiplyExtendedScalarBySelectedScalar(Vector64<Double>, Vector128<Double>, Byte)	float64_t vmulxd_laneq_f64 (float64_t a, float64x2_t v, const int lane); A64: FMULX Dd, Dn, Vm.D[lane]
            // MultiplyExtendedScalarBySelectedScalar(Vector64<Single>, Vector128<Single>, Byte)	float32_t vmulxs_laneq_f32 (float32_t a, float32x4_t v, const int lane); A64: FMULX Sd, Sn, Vm.S[lane]
            // MultiplyExtendedScalarBySelectedScalar(Vector64<Single>, Vector64<Single>, Byte)	float32_t vmulxs_lane_f32 (float32_t a, float32x2_t v, const int lane); A64: FMULX Sd, Sn, Vm.S[lane]
            // MultiplyRoundedDoublingSaturateHighScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqrdmulhh_s16 (int16_t a, int16_t b) A64: SQRDMULH Hd, Hn, Hm
            // MultiplyRoundedDoublingSaturateHighScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqrdmulhs_s32 (int32_t a, int32_t b) A64: SQRDMULH Sd, Sn, Sm
            // MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int16>, Vector128<Int16>, Byte)	int16_t vqrdmulhh_laneq_s16 (int16_t a, int16x8_t v, const int lane) A64: SQRDMULH Hd, Hn, Vm.H[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int16>, Vector64<Int16>, Byte)	int16_t vqrdmulhh_lane_s16 (int16_t a, int16x4_t v, const int lane) A64: SQRDMULH Hd, Hn, Vm.H[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int32>, Vector128<Int32>, Byte)	int32_t vqrdmulhs_laneq_s32 (int32_t a, int32x4_t v, const int lane) A64: SQRDMULH Sd, Sn, Vm.S[lane]
            // MultiplyRoundedDoublingScalarBySelectedScalarSaturateHigh(Vector64<Int32>, Vector64<Int32>, Byte)	int32_t vqrdmulhs_lane_s32 (int32_t a, int32x2_t v, const int lane) A64: SQRDMULH Sd, Sn, Vm.S[lane]
            // MultiplyScalarBySelectedScalar(Vector64<Double>, Vector128<Double>, Byte)	float64_t vmuld_laneq_f64 (float64_t a, float64x2_t v, const int lane); A64: FMUL Dd, Dn, Vm.D[lane]
        }
        public unsafe static void RunArm_AdvSimd_64_N(TextWriter writer, string indent) {
            // Negate(Vector128<Double>)	float64x2_t vnegq_f64 (float64x2_t a); A64: FNEG Vd.2D, Vn.2D
            // Negate(Vector128<Int64>)	int64x2_t vnegq_s64 (int64x2_t a); A64: NEG Vd.2D, Vn.2D
            // NegateSaturate(Vector128<Int64>)	int64x2_t vqnegq_s64 (int64x2_t a); A64: SQNEG Vd.2D, Vn.2D
            // NegateSaturateScalar(Vector64<Int16>)	int16_t vqnegh_s16 (int16_t a); A64: SQNEG Hd, Hn
            // NegateSaturateScalar(Vector64<Int32>)	int32_t vqnegs_s32 (int32_t a); A64: SQNEG Sd, Sn
            // NegateSaturateScalar(Vector64<Int64>)	int64_t vqnegd_s64 (int64_t a); A64: SQNEG Dd, Dn
            // NegateSaturateScalar(Vector64<SByte>)	int8_t vqnegb_s8 (int8_t a); A64: SQNEG Bd, Bn
            // NegateScalar(Vector64<Int64>)	int64x1_t vneg_s64 (int64x1_t a); A64: NEG Dd, Dn
        }
        public unsafe static void RunArm_AdvSimd_64_R(TextWriter writer, string indent) {
            // ReciprocalEstimate(Vector128<Double>)	float64x2_t vrecpeq_f64 (float64x2_t a); A64: FRECPE Vd.2D, Vn.2D
            // ReciprocalEstimateScalar(Vector64<Double>)	float64x1_t vrecpe_f64 (float64x1_t a); A64: FRECPE Dd, Dn
            // ReciprocalEstimateScalar(Vector64<Single>)	float32_t vrecpes_f32 (float32_t a); A64: FRECPE Sd, Sn
            // ReciprocalExponentScalar(Vector64<Double>)	float64_t vrecpxd_f64 (float64_t a); A64: FRECPX Dd, Dn
            // ReciprocalExponentScalar(Vector64<Single>)	float32_t vrecpxs_f32 (float32_t a); A64: FRECPX Sd, Sn
            // ReciprocalSquareRootEstimate(Vector128<Double>)	float64x2_t vrsqrteq_f64 (float64x2_t a); A64: FRSQRTE Vd.2D, Vn.2D
            // ReciprocalSquareRootEstimateScalar(Vector64<Double>)	float64x1_t vrsqrte_f64 (float64x1_t a); A64: FRSQRTE Dd, Dn
            // ReciprocalSquareRootEstimateScalar(Vector64<Single>)	float32_t vrsqrtes_f32 (float32_t a); A64: FRSQRTE Sd, Sn
            // ReciprocalSquareRootStep(Vector128<Double>, Vector128<Double>)	float64x2_t vrsqrtsq_f64 (float64x2_t a, float64x2_t b); A64: FRSQRTS Vd.2D, Vn.2D, Vm.2D
            // ReciprocalSquareRootStepScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vrsqrts_f64 (float64x1_t a, float64x1_t b); A64: FRSQRTS Dd, Dn, Dm
            // ReciprocalSquareRootStepScalar(Vector64<Single>, Vector64<Single>)	float32_t vrsqrtss_f32 (float32_t a, float32_t b); A64: FRSQRTS Sd, Sn, Sm
            // ReciprocalStep(Vector128<Double>, Vector128<Double>)	float64x2_t vrecpsq_f64 (float64x2_t a, float64x2_t b); A64: FRECPS Vd.2D, Vn.2D, Vm.2D
            // ReciprocalStepScalar(Vector64<Double>, Vector64<Double>)	float64x1_t vrecps_f64 (float64x1_t a, float64x1_t b); A64: FRECPS Dd, Dn, Dm
            // ReciprocalStepScalar(Vector64<Single>, Vector64<Single>)	float32_t vrecpss_f32 (float32_t a, float32_t b); A64: FRECPS Sd, Sn, Sm
            // ReverseElementBits(Vector128<Byte>)	uint8x16_t vrbitq_u8 (uint8x16_t a); A64: RBIT Vd.16B, Vn.16B
            // ReverseElementBits(Vector128<SByte>)	int8x16_t vrbitq_s8 (int8x16_t a); A64: RBIT Vd.16B, Vn.16B
            // ReverseElementBits(Vector64<Byte>)	uint8x8_t vrbit_u8 (uint8x8_t a); A64: RBIT Vd.8B, Vn.8B
            // ReverseElementBits(Vector64<SByte>)	int8x8_t vrbit_s8 (int8x8_t a); A64: RBIT Vd.8B, Vn.8B
            // RoundAwayFromZero(Vector128<Double>)	float64x2_t vrndaq_f64 (float64x2_t a); A64: FRINTA Vd.2D, Vn.2D
            // RoundToNearest(Vector128<Double>)	float64x2_t vrndnq_f64 (float64x2_t a); A64: FRINTN Vd.2D, Vn.2D
            // RoundToNegativeInfinity(Vector128<Double>)	float64x2_t vrndmq_f64 (float64x2_t a); A64: FRINTM Vd.2D, Vn.2D
            // RoundToPositiveInfinity(Vector128<Double>)	float64x2_t vrndpq_f64 (float64x2_t a); A64: FRINTP Vd.2D, Vn.2D
            // RoundToZero(Vector128<Double>)	float64x2_t vrndq_f64 (float64x2_t a); A64: FRINTZ Vd.2D, Vn.2D
        }
        public unsafe static void RunArm_AdvSimd_64_S(TextWriter writer, string indent) {
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
            // Sqrt(Vector128<Double>)	float64x2_t vsqrtq_f64 (float64x2_t a); A64: FSQRT Vd.2D, Vn.2D
            // Sqrt(Vector128<Single>)	float32x4_t vsqrtq_f32 (float32x4_t a); A64: FSQRT Vd.4S, Vn.4S
            // Sqrt(Vector64<Single>)	float32x2_t vsqrt_f32 (float32x2_t a); A64: FSQRT Vd.2S, Vn.2S
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
            // Subtract(Vector128<Double>, Vector128<Double>)	float64x2_t vsubq_f64 (float64x2_t a, float64x2_t b); A64: FSUB Vd.2D, Vn.2D, Vm.2D
            // SubtractSaturateScalar(Vector64<Byte>, Vector64<Byte>)	uint8_t vqsubb_u8 (uint8_t a, uint8_t b); A64: UQSUB Bd, Bn, Bm
            // SubtractSaturateScalar(Vector64<Int16>, Vector64<Int16>)	int16_t vqsubh_s16 (int16_t a, int16_t b); A64: SQSUB Hd, Hn, Hm
            // SubtractSaturateScalar(Vector64<Int32>, Vector64<Int32>)	int32_t vqsubs_s32 (int32_t a, int32_t b); A64: SQSUB Sd, Sn, Sm
            // SubtractSaturateScalar(Vector64<SByte>, Vector64<SByte>)	int8_t vqsubb_s8 (int8_t a, int8_t b); A64: SQSUB Bd, Bn, Bm
            // SubtractSaturateScalar(Vector64<UInt16>, Vector64<UInt16>)	uint16_t vqsubh_u16 (uint16_t a, uint16_t b); A64: UQSUB Hd, Hn, Hm
            // SubtractSaturateScalar(Vector64<UInt32>, Vector64<UInt32>)	uint32_t vqsubs_u32 (uint32_t a, uint32_t b); A64: UQSUB Sd, Sn, Sm
        }
        public unsafe static void RunArm_AdvSimd_64_T(TextWriter writer, string indent) {
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
        }
        public unsafe static void RunArm_AdvSimd_64_U(TextWriter writer, string indent) {
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
        }
        public unsafe static void RunArm_AdvSimd_64_V(TextWriter writer, string indent) {
            string indentNext = indent + IndentNextSeparator;
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

        }

    }
}
