using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace IntrinsicsLib {
    partial class IntrinsicsDemo {

        /// <summary>
        /// Run x86.
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunX86(TextWriter tw, string indent) {
            RunX86Avx(tw, indent);
            RunX86Avx2(tw, indent);
        }

        /// <summary>
        /// Run x86 Avx. https://docs.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + "\t";
            if (Avx.IsSupported) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("Avx.IsSupported:\t{0}", Avx.IsSupported));
            if (!Avx.IsSupported) {
                return;
            }

            float f3 = 3.0f;
            double d3 = 3.0;

            // Add(Vector256<Double>, Vector256<Double>)	__m256d _mm256_add_pd (__m256d a, __m256d b)
            // VADDPD ymm, ymm, ymm/m256
            // Add(Vector256<Single>, Vector256<Single>)	__m256 _mm256_add_ps (__m256 a, __m256 b)
            // VADDPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Add(srcT_256_double, src1_256_double):\t{0}", Avx.Add(srcT_256_double, src1_256_double));
            WriteLineFormat(tw, indent, "Add(srcT_256_double, src2_256_double):\t{0}", Avx.Add(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "Add(srcT_256_float, src1_256_float):\t{0}", Avx.Add(srcT_256_float, src1_256_float));
            WriteLineFormat(tw, indent, "Add(srcT_256_float, src2_256_float):\t{0}", Avx.Add(srcT_256_float, src2_256_float));

            // AddSubtract(Vector256<Double>, Vector256<Double>)	__m256d _mm256_addsub_pd (__m256d a, __m256d b)
            // VADDSUBPD ymm, ymm, ymm/m256
            // AddSubtract(Vector256<Single>, Vector256<Single>)	__m256 _mm256_addsub_ps (__m256 a, __m256 b)
            // VADDSUBPS ymm, ymm, ymm/m256
            // FOR j := 0 to 7
            // 	i := j*32
            // 	IF ((j & 1) == 0)
            // 		dst[i+31:i] := a[i+31:i] - b[i+31:i]
            // 	ELSE
            // 		dst[i+31:i] := a[i+31:i] + b[i+31:i]
            // 	FI
            // ENDFOR
            WriteLineFormat(tw, indent, "AddSubtract(srcT_256_double, src1_256_double):\t{0}", Avx.AddSubtract(srcT_256_double, src1_256_double));
            WriteLineFormat(tw, indent, "AddSubtract(srcT_256_double, src2_256_double):\t{0}", Avx.AddSubtract(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "AddSubtract(srcT_256_float, src1_256_float):\t{0}", Avx.AddSubtract(srcT_256_float, src1_256_float));
            WriteLineFormat(tw, indent, "AddSubtract(srcT_256_float, src2_256_float):\t{0}", Avx.AddSubtract(srcT_256_float, src2_256_float));

            // And(Vector256<Double>, Vector256<Double>)	__m256d _mm256_and_pd (__m256d a, __m256d b)
            // VANDPD ymm, ymm, ymm/m256
            // And(Vector256<Single>, Vector256<Single>)	__m256 _mm256_and_ps (__m256 a, __m256 b)
            // VANDPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "And(srcT_256_double, src1_256_double):\t{0}", Avx.And(srcT_256_double, src1_256_double));
            WriteLineFormat(tw, indent, "And(srcT_256_double, src2_256_double):\t{0}", Avx.And(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "And(srcT_256_float, src1_256_float):\t{0}", Avx.And(srcT_256_float, src1_256_float));
            WriteLineFormat(tw, indent, "And(srcT_256_float, src2_256_float):\t{0}", Avx.And(srcT_256_float, src2_256_float));

            // AndNot(Vector256<Double>, Vector256<Double>)	__m256d _mm256_andnot_pd (__m256d a, __m256d b)
            // VANDNPD ymm, ymm, ymm/m256
            // AndNot(Vector256<Single>, Vector256<Single>)	__m256 _mm256_andnot_ps (__m256 a, __m256 b)
            // VANDNPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "AndNot(srcT_256_double, src1_256_double):\t{0}", Avx.AndNot(srcT_256_double, src1_256_double));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_double, src2_256_double):\t{0}", Avx.AndNot(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_float, src1_256_float):\t{0}", Avx.AndNot(srcT_256_float, src1_256_float));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_float, src2_256_float):\t{0}", Avx.AndNot(srcT_256_float, src2_256_float));

            // Blend(Vector256<Double>, Vector256<Double>, Byte)	__m256d _mm256_blend_pd (__m256d a, __m256d b, const int imm8)
            // VBLENDPD ymm, ymm, ymm/m256, imm8
            // FOR j := 0 to 3
            // 	i := j*64
            // 	IF imm8[j]
            // 		dst[i+63:i] := b[i+63:i]
            // 	ELSE
            // 		dst[i+63:i] := a[i+63:i]
            // 	FI
            // ENDFOR
            // dst[MAX:256] := 0
            // Blend(Vector256<Single>, Vector256<Single>, Byte)	__m256 _mm256_blend_ps (__m256 a, __m256 b, const int imm8)
            // VBLENDPS ymm, ymm, ymm/m256, imm8
            // Blend packed single-precision (32-bit) floating-point elements from a and b using control mask imm8, and store the results in dst. (使用控制掩码imm8混合来自a和b的打包单精度(32位)浮点元素，并将结果存储在dst中。)
            // FOR j := 0 to 7
            // 	i := j*32
            // 	IF imm8[j]
            // 		dst[i+31:i] := b[i+31:i]
            // 	ELSE
            // 		dst[i+31:i] := a[i+31:i]
            // 	FI
            // ENDFOR
            foreach(byte control in new byte[] { 1, 3, 0xCB }) {
                WriteLineFormat(tw, indent, "Blend - control={0} (0x{0:X}):", control);
                WriteLineFormat(tw, indentNext, "Blend(srcT_256_double, src1_256_double, control):\t{0}", Avx.Blend(srcT_256_double, src1_256_double, control));
                WriteLineFormat(tw, indentNext, "Blend(srcT_256_double, src2_256_double, control):\t{0}", Avx.Blend(srcT_256_double, src2_256_double, control));
                WriteLineFormat(tw, indentNext, "Blend(srcT_256_float, src1_256_float, control):\t{0}", Avx.Blend(srcT_256_float, src1_256_float, control));
                WriteLineFormat(tw, indentNext, "Blend(srcT_256_float, src2_256_float, control):\t{0}", Avx.Blend(srcT_256_float, src2_256_float, control));
            }

            // BlendVariable(Vector256<Double>, Vector256<Double>, Vector256<Double>)	__m256d _mm256_blendv_pd (__m256d a, __m256d b, __m256d mask)
            // VBLENDVPD ymm, ymm, ymm/m256, ymm
            // FOR j := 0 to 3
            // 	i := j*64
            // 	IF mask[i+63]
            // 		dst[i+63:i] := b[i+63:i]
            // 	ELSE
            // 		dst[i+63:i] := a[i+63:i]
            // 	FI
            // ENDFOR
            // BlendVariable(Vector256<Single>, Vector256<Single>, Vector256<Single>)	__m256 _mm256_blendv_ps (__m256 a, __m256 b, __m256 mask)
            // VBLENDVPS ymm, ymm, ymm/m256, ymm
            // FOR j := 0 to 7
            // 	i := j*32
            // 	IF mask[i+31]
            // 		dst[i+31:i] := b[i+31:i]
            // 	ELSE
            // 		dst[i+31:i] := a[i+31:i]
            // 	FI
            // ENDFOR
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_double, src1_256_double, srcT_256_double):\t{0}", Avx.BlendVariable(srcT_256_double, src1_256_double, srcT_256_double));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_double, src2_256_double, srcT_256_double):\t{0}", Avx.BlendVariable(srcT_256_double, src2_256_double, srcT_256_double));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_float, src1_256_float, srcT_256_float):\t{0}", Avx.BlendVariable(srcT_256_float, src1_256_float, srcT_256_float));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_float, src2_256_float, srcT_256_float):\t{0}", Avx.BlendVariable(srcT_256_float, src2_256_float, srcT_256_float));

            // BroadcastScalarToVector128(Single*)	__m128 _mm_broadcast_ss (float const * mem_addr)
            // VBROADCASTSS xmm, m32
            // Broadcast a single-precision (32-bit) floating-point element from memory to all elements of dst.
            // tmp[31:0] := MEM[mem_addr+31:mem_addr]
            // FOR j := 0 to 3
            // 	i := j*32
            // 	dst[i+31:i] := tmp[31:0]
            // ENDFOR
            // BroadcastScalarToVector256(Double*)	__m256d _mm256_broadcast_sd (double const * mem_addr)
            // VBROADCASTSD ymm, m64
            // Broadcast a double-precision (64-bit) floating-point element from memory to all elements of dst.
            // tmp[63:0] := MEM[mem_addr+63:mem_addr]
            // FOR j := 0 to 3
            // 	i := j*64
            // 	dst[i+63:i] := tmp[63:0]
            // ENDFOR
            // BroadcastScalarToVector256(Single*)	__m256 _mm256_broadcast_ss (float const * mem_addr)
            // VBROADCASTSS ymm, m32
            // Broadcast a single-precision (32-bit) floating-point element from memory to all elements of dst.
            // tmp[31:0] := MEM[mem_addr+31:mem_addr]
            // FOR j := 0 to 7
            // 	i := j*32
            // 	dst[i+31:i] := tmp[31:0]
            // ENDFOR
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(&f3):\t{0}", Avx.BroadcastScalarToVector128(&f3));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(&f3):\t{0}", Avx.BroadcastScalarToVector256(&d3));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(&f3):\t{0}", Avx.BroadcastScalarToVector256(&f3));

            // BroadcastVector128ToVector256(Double*)	__m256d _mm256_broadcast_pd (__m128d const * mem_addr)
            // VBROADCASTF128, ymm, m128
            // tmp[127:0] := MEM[mem_addr+127:mem_addr]
            // dst[127:0] := tmp[127:0]
            // dst[255:128] := tmp[127:0]
            // dst[MAX:256] := 0
            // BroadcastVector128ToVector256(Single*)	__m256 _mm256_broadcast_ps (__m128 const * mem_addr)
            // VBROADCASTF128, ymm, m128
            // tmp[127:0] := MEM[mem_addr+127:mem_addr]
            // dst[127:0] := tmp[127:0]
            // dst[255:128] := tmp[127:0]
            // dst[MAX:256] := 0
            fixed (void* p = &srcT_128_double) {
                WriteLineFormat(tw, indent, "BroadcastVector128ToVector256(&srcT_128_double):\t{0}", Avx.BroadcastVector128ToVector256((double*)p));
            }
            fixed (void* p = &srcT_128_float) {
                WriteLineFormat(tw, indent, "BroadcastVector128ToVector256(&srcT_128_float):\t{0}", Avx.BroadcastVector128ToVector256((float*)p));
            }

            // Ceiling(Vector256<Double>)	__m256d _mm256_ceil_pd (__m256d a)
            // VROUNDPD ymm, ymm/m256, imm8(10)
            // Ceiling(Vector256<Single>)	__m256 _mm256_ceil_ps (__m256 a)
            // VROUNDPS ymm, ymm/m256, imm8(10)
            WriteLineFormat(tw, indent, "Ceiling(srcT_256_double):\t{0}", Avx.Ceiling(srcT_256_double));
            WriteLineFormat(tw, indent, "Ceiling(srcT_256_float):\t{0}", Avx.Ceiling(srcT_256_float));

            // Compare(Vector128<Double>, Vector128<Double>, FloatComparisonMode)	__m128d _mm_cmp_pd (__m128d a, __m128d b, const int imm8)
            // VCMPPD xmm, xmm, xmm/m128, imm8
            // Compare(Vector128<Single>, Vector128<Single>, FloatComparisonMode)	__m128 _mm_cmp_ps (__m128 a, __m128 b, const int imm8)
            // VCMPPS xmm, xmm, xmm/m128, imm8
            // Compare(Vector256<Double>, Vector256<Double>, FloatComparisonMode)	__m256d _mm256_cmp_pd (__m256d a, __m256d b, const int imm8)
            // VCMPPD ymm, ymm, ymm/m256, imm8
            // Compare(Vector256<Single>, Vector256<Single>, FloatComparisonMode)	__m256 _mm256_cmp_ps (__m256 a, __m256 b, const int imm8)
            // VCMPPS ymm, ymm, ymm/m256, imm8
            foreach (FloatComparisonMode mode in new FloatComparisonMode[] { FloatComparisonMode.OrderedEqualNonSignaling, FloatComparisonMode.OrderedLessThanSignaling, FloatComparisonMode.OrderedLessThanOrEqualSignaling }) {
                WriteLineFormat(tw, indent, "Compare - mode={0} (0x{0:X}):", mode);
                WriteLineFormat(tw, indentNext, "Compare(srcT_128_double, src0_128_double, mode):\t{0}", Avx.Compare(srcT_128_double, src0_128_double, mode));
                WriteLineFormat(tw, indentNext, "Compare(srcT_128_float, src0_128_float, mode):\t{0}", Avx.Compare(srcT_128_float, src0_128_float, mode));
                WriteLineFormat(tw, indentNext, "Compare(srcT_256_double, src0_256_double, mode):\t{0}", Avx.Compare(srcT_256_double, src0_256_double, mode));
                WriteLineFormat(tw, indentNext, "Compare(srcT_256_float, src0_256_float, mode):\t{0}", Avx.Compare(srcT_256_float, src0_256_float, mode));
            }

#if NET5_0_OR_GREATER
            // CompareEqual(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpeq_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(0)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareEqual(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpeq_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(0)
            // The above native signature does not exist. We provide this additional overload for completeness.

            // CompareGreaterThan(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpgt_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(14)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareGreaterThan(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpgt_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(14)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareGreaterThanOrEqual(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpge_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(13)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareGreaterThanOrEqual(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpge_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(13)
            // The above native signature does not exist. We provide this additional overload for completeness.

            // CompareLessThan(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmplt_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(1)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareLessThan(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmplt_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(1)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareLessThanOrEqual(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmple_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(2)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareLessThanOrEqual(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmple_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(2)
            // The above native signature does not exist. We provide this additional overload for completeness.
            WriteLineFormat(tw, indent, "CompareLessThan(srcT_256_double, src0_256_double):\t{0}", Avx.CompareLessThan(srcT_256_double, src0_256_double));
            WriteLineFormat(tw, indent, "CompareLessThan(srcT_256_float, src0_256_float):\t{0}", Avx.CompareLessThan(srcT_256_float, src0_256_float));

            // CompareNotEqual(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpneq_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(4)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareNotEqual(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpneq_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(4)
            // The above native signature does not exist. We provide this additional overload for completeness.

            // CompareNotGreaterThan(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpngt_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(10)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareNotGreaterThan(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpngt_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(10)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareNotGreaterThanOrEqual(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpnge_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(9)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareNotGreaterThanOrEqual(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpnge_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(9)
            // The above native signature does not exist. We provide this additional overload for completeness.

            // CompareNotLessThan(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpnlt_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(5)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareNotLessThan(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpnlt_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(5)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareNotLessThanOrEqual(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpnle_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(6)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareNotLessThanOrEqual(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpnle_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(6)
            // The above native signature does not exist. We provide this additional overload for completeness.

            // CompareOrdered(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpord_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(7)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareOrdered(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpord_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(7)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareScalar(Vector128<Double>, Vector128<Double>, FloatComparisonMode)	__m128d _mm_cmp_sd (__m128d a, __m128d b, const int imm8)
            // VCMPSS xmm, xmm, xmm/m32, imm8
            // CompareScalar(Vector128<Single>, Vector128<Single>, FloatComparisonMode)	__m128 _mm_cmp_ss (__m128 a, __m128 b, const int imm8)
            // VCMPSD xmm, xmm, xmm/m64, imm8
            // CompareUnordered(Vector256<Double>, Vector256<Double>)	__m256d _mm256_cmpunord_pd (__m256d a, __m256d b) CMPPD ymm, ymm/m256, imm8(3)
            // The above native signature does not exist. We provide this additional overload for completeness.
            // CompareUnordered(Vector256<Single>, Vector256<Single>)	__m256 _mm256_cmpunord_ps (__m256 a, __m256 b) CMPPS ymm, ymm/m256, imm8(3)
            // The above native signature does not exist. We provide this additional overload for completeness.
#endif // NET5_0_OR_GREATER

            // ConvertToVector128Int32(Vector256<Double>)	__m128i _mm256_cvtpd_epi32 (__m256d a)
            // VCVTPD2DQ xmm, ymm/m256
            // Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers, and store the results in dst.
            // ConvertToVector128Int32WithTruncation(Vector256<Double>)	__m128i _mm256_cvttpd_epi32 (__m256d a)
            // VCVTTPD2DQ xmm, ymm/m256
            // Convert packed double-precision (64-bit) floating-point elements in a to packed 32-bit integers with truncation, and store the results in dst.
            // ConvertToVector128Single(Vector256<Double>)	__m128 _mm256_cvtpd_ps (__m256d a)
            // VCVTPD2PS xmm, ymm/m256
            // ConvertToVector256Double(Vector128<Int32>)	__m256d _mm256_cvtepi32_pd (__m128i a)
            // VCVTDQ2PD ymm, xmm/m128
            // ConvertToVector256Double(Vector128<Single>)	__m256d _mm256_cvtps_pd (__m128 a)
            // VCVTPS2PD ymm, xmm/m128
            WriteLineFormat(tw, indent, "ConvertToVector128Int32(srcT_256_double):\t{0}", Avx.ConvertToVector128Int32(srcT_256_double));
            WriteLineFormat(tw, indent, "ConvertToVector128Int32WithTruncation(srcT_256_double):\t{0}", Avx.ConvertToVector128Int32WithTruncation(srcT_256_double));
            WriteLineFormat(tw, indent, "ConvertToVector128Single(srcT_256_double):\t{0}", Avx.ConvertToVector128Single(srcT_256_double));
            WriteLineFormat(tw, indent, "ConvertToVector256Double(srcT_128_int):\t{0}", Avx.ConvertToVector256Double(srcT_128_int));
            WriteLineFormat(tw, indent, "ConvertToVector256Double(srcT_128_float):\t{0}", Avx.ConvertToVector256Double(srcT_128_float));

            // ConvertToVector256Int32(Vector256<Single>)	__m256i _mm256_cvtps_epi32 (__m256 a)
            // VCVTPS2DQ ymm, ymm/m256
            // ConvertToVector256Int32WithTruncation(Vector256<Single>)	__m256i _mm256_cvttps_epi32 (__m256 a)
            // VCVTTPS2DQ ymm, ymm/m256
            // ConvertToVector256Single(Vector256<Int32>)	__m256 _mm256_cvtepi32_ps (__m256i a)
            // VCVTDQ2PS ymm, ymm/m256
            WriteLineFormat(tw, indent, "ConvertToVector256Int32(srcT_128_float):\t{0}", Avx.ConvertToVector256Int32(srcT_256_float));
            WriteLineFormat(tw, indent, "ConvertToVector256Int32WithTruncation(srcT_128_float):\t{0}", Avx.ConvertToVector256Int32WithTruncation(srcT_256_float));
            WriteLineFormat(tw, indent, "ConvertToVector256Single(srcT_128_int):\t{0}", Avx.ConvertToVector256Single(srcT_256_int));

            // Divide(Vector256<Double>, Vector256<Double>)	__m256d _mm256_div_pd (__m256d a, __m256d b)
            // VDIVPD ymm, ymm, ymm/m256
            // Divide(Vector256<Single>, Vector256<Single>)	__m256 _mm256_div_ps (__m256 a, __m256 b)
            // VDIVPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Divide(srcT_256_double, src2_256_double):\t{0}", Avx.Divide(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "Divide(srcT_256_float, src2_256_float):\t{0}", Avx.Divide(srcT_256_float, src2_256_float));

            // DotProduct(Vector256<Single>, Vector256<Single>, Byte)	__m256 _mm256_dp_ps (__m256 a, __m256 b, const int imm8)
            // VDPPS ymm, ymm, ymm/m256, imm8
            // Conditionally multiply the packed single-precision (32-bit) floating-point elements in a and b using the high 4 bits in imm8, sum the four products, and conditionally store the sum in dst using the low 4 bits of imm8. (使用imm8的高4位有条件地将a和b中的单精度（32位）浮点元素相乘，将四个乘积相加，并使用imm8的低4位有条件地将和存储在dst中。)
            // DEFINE DP(a[127:0], b[127:0], imm8[7:0]) {
            // 	FOR j := 0 to 3
            // 		i := j*32
            // 		IF imm8[(4+j)%8]
            // 			temp[i+31:i] := a[i+31:i] * b[i+31:i]
            // 		ELSE
            // 			temp[i+31:i] := FP32(0.0)
            // 		FI
            // 	ENDFOR
            // 	
            // 	sum[31:0] := (temp[127:96] + temp[95:64]) + (temp[63:32] + temp[31:0])
            // 	
            // 	FOR j := 0 to 3
            // 		i := j*32
            // 		IF imm8[j%8]
            // 			tmpdst[i+31:i] := sum[31:0]
            // 		ELSE
            // 			tmpdst[i+31:i] := FP32(0.0)
            // 		FI
            // 	ENDFOR
            // 	RETURN tmpdst[127:0]
            // }
            // dst[127:0] := DP(a[127:0], b[127:0], imm8[7:0])
            // dst[255:128] := DP(a[255:128], b[255:128], imm8[7:0])
            foreach (byte control in new byte[] { 0x81, 0xC1, 0x33 }) {
                WriteLineFormat(tw, indent, "DotProduct - control={0} (0x{0:X}):", control);
                WriteLineFormat(tw, indentNext, "DotProduct(srcT_256_float, src2_256_float, control):\t{0}", Avx.DotProduct(srcT_256_float, src2_256_float, control));
            }

            // DuplicateEvenIndexed(Vector256<Double>)	__m256d _mm256_movedup_pd (__m256d a)
            // VMOVDDUP ymm, ymm/m256
            // Duplicate even-indexed double-precision (64-bit) floating-point elements from a, and store the results in dst. (从a中复制偶数索引的双精度（64位）浮点元素，并将结果存储在dst中。)
            // dst[63:0] := a[63:0]
            // dst[127:64] := a[63:0]
            // dst[191:128] := a[191:128]
            // dst[255:192] := a[191:128]
            // DuplicateEvenIndexed(Vector256<Single>)	__m256 _mm256_moveldup_ps (__m256 a)
            // VMOVSLDUP ymm, ymm/m256
            // Duplicate even-indexed single-precision (32-bit) floating-point elements from a, and store the results in dst. (从a中复制偶数索引的单精度（32位）浮点元素，并将结果存入dst中。)
            // dst[31:0] := a[31:0] 
            // dst[63:32] := a[31:0] 
            // dst[95:64] := a[95:64] 
            // dst[127:96] := a[95:64]
            // dst[159:128] := a[159:128] 
            // dst[191:160] := a[159:128] 
            // dst[223:192] := a[223:192] 
            // dst[255:224] := a[223:192]
            // DuplicateOddIndexed(Vector256<Single>)	__m256 _mm256_movehdup_ps (__m256 a)
            // VMOVSHDUP ymm, ymm/m256
            // Duplicate odd-indexed single-precision (32-bit) floating-point elements from a, and store the results in dst. (从a中复制奇数索引的单精度（32位）浮点元素，并将结果存储在dst中。)
            // dst[31:0] := a[63:32] 
            // dst[63:32] := a[63:32] 
            // dst[95:64] := a[127:96] 
            // dst[127:96] := a[127:96]
            // dst[159:128] := a[191:160] 
            // dst[191:160] := a[191:160] 
            // dst[223:192] := a[255:224] 4
            // dst[255:224] := a[255:224]
            WriteLineFormat(tw, indent, "DuplicateEvenIndexed(srcT_256_double):\t{0}", Avx.DuplicateEvenIndexed(srcT_256_double));
            WriteLineFormat(tw, indent, "DuplicateEvenIndexed(srcT_256_float):\t{0}", Avx.DuplicateEvenIndexed(srcT_256_float));
            WriteLineFormat(tw, indent, "DuplicateOddIndexed(srcT_256_float):\t{0}", Avx.DuplicateOddIndexed(srcT_256_float));

            // ExtractVector128(Vector256<Byte>, Byte)	__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // Extract 128 bits (composed of integer data) from a, selected with imm8, and store the result in dst.
            // CASE imm8[0] OF
            // 0: dst[127:0] := a[127:0]
            // 1: dst[127:0] := a[255:128]
            // ESAC
            // ExtractVector128(Vector256<Double>, Byte)	__m128d _mm256_extractf128_pd (__m256d a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // Extract 128 bits (composed of 2 packed double-precision (64-bit) floating-point elements) from a, selected with imm8, and store the result in dst.
            // CASE imm8[0] OF
            // 0: dst[127:0] := a[127:0]
            // 1: dst[127:0] := a[255:128]
            // ESAC
            // ExtractVector128(Vector256<Int16>, Byte)	__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // ExtractVector128(Vector256<Int32>, Byte)	__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // ExtractVector128(Vector256<Int64>, Byte)	__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // ExtractVector128(Vector256<SByte>, Byte)	__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // ExtractVector128(Vector256<Single>, Byte)	__m128 _mm256_extractf128_ps (__m256 a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // Extract 128 bits (composed of 4 packed single-precision (32-bit) floating-point elements) from a, selected with imm8, and store the result in dst.
            // CASE imm8[0] OF
            // 0: dst[127:0] := a[127:0]
            // 1: dst[127:0] := a[255:128]
            // ESAC
            // ExtractVector128(Vector256<UInt16>, Byte)	__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // ExtractVector128(Vector256<UInt32>, Byte)	__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            // ExtractVector128(Vector256<UInt64>, Byte)	__m128i _mm256_extractf128_si256 (__m256i a, const int imm8)
            // VEXTRACTF128 xmm/m128, ymm, imm8
            foreach (byte idx in new byte[] { 0, 1 }) {
                WriteLineFormat(tw, indent, "ExtractVector128 - idx={0} (0x{0:X}):", idx);
                WriteLineFormat(tw, indentNext, "ExtractVector128(srcT_256_int, idx):\t{0}", Avx.ExtractVector128(srcT_256_int, idx));
                WriteLineFormat(tw, indentNext, "ExtractVector128(srcT_256_double, idx):\t{0}", Avx.ExtractVector128(srcT_256_double, idx));
                WriteLineFormat(tw, indentNext, "ExtractVector128(srcT_256_float, idx):\t{0}", Avx.ExtractVector128(srcT_256_float, idx));
            }

            // Floor(Vector256<Double>)	__m256d _mm256_floor_pd (__m256d a)
            // VROUNDPS ymm, ymm/m256, imm8(9)
            // Floor(Vector256<Single>)	__m256 _mm256_floor_ps (__m256 a)
            // VROUNDPS ymm, ymm/m256, imm8(9)
            WriteLineFormat(tw, indent, "Floor(srcT_256_double):\t{0}", Avx.Floor(srcT_256_double));
            WriteLineFormat(tw, indent, "Floor(srcT_256_float):\t{0}", Avx.Floor(srcT_256_float));

            // HorizontalAdd(Vector256<Double>, Vector256<Double>)	__m256d _mm256_hadd_pd (__m256d a, __m256d b)
            // VHADDPD ymm, ymm, ymm/m256
            // HorizontalAdd(Vector256<Single>, Vector256<Single>)	__m256 _mm256_hadd_ps (__m256 a, __m256 b)
            // VHADDPS ymm, ymm, ymm/m256
            // Horizontally add adjacent pairs of single-precision (32-bit) floating-point elements in a and b, and pack the results in dst.
            // dst[31:0] := a[63:32] + a[31:0]
            // dst[63:32] := a[127:96] + a[95:64]
            // dst[95:64] := b[63:32] + b[31:0]
            // dst[127:96] := b[127:96] + b[95:64]
            // dst[159:128] := a[191:160] + a[159:128]
            // dst[191:160] := a[255:224] + a[223:192]
            // dst[223:192] := b[191:160] + b[159:128]
            // dst[255:224] := b[255:224] + b[223:192]
            WriteLineFormat(tw, indent, "HorizontalAdd(srcT_256_double, src2_256_double):\t{0}", Avx.HorizontalAdd(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "HorizontalAdd(srcT_256_float, src2_256_float):\t{0}", Avx.HorizontalAdd(srcT_256_float, src2_256_float));

            // HorizontalSubtract(Vector256<Double>, Vector256<Double>)	__m256d _mm256_hsub_pd (__m256d a, __m256d b)
            // VHSUBPD ymm, ymm, ymm/m256
            // HorizontalSubtract(Vector256<Single>, Vector256<Single>)	__m256 _mm256_hsub_ps (__m256 a, __m256 b)
            // VHSUBPS ymm, ymm, ymm/m256
            // Horizontally subtract adjacent pairs of single-precision (32-bit) floating-point elements in a and b, and pack the results in dst.
            // dst[31:0] := a[31:0] - a[63:32]
            // dst[63:32] := a[95:64] - a[127:96]
            // dst[95:64] := b[31:0] - b[63:32]
            // dst[127:96] := b[95:64] - b[127:96]
            // dst[159:128] := a[159:128] - a[191:160]
            // dst[191:160] := a[223:192] - a[255:224]
            // dst[223:192] := b[159:128] - b[191:160]
            // dst[255:224] := b[223:192] - b[255:224]
            WriteLineFormat(tw, indent, "HorizontalSubtract(srcT_256_double, src2_256_double):\t{0}", Avx.HorizontalSubtract(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "HorizontalSubtract(srcT_256_float, src2_256_float):\t{0}", Avx.HorizontalSubtract(srcT_256_float, src2_256_float));

            // InsertVector128(Vector256<Byte>, Vector128<Byte>, Byte)	__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<Double>, Vector128<Double>, Byte)	__m256d _mm256_insertf128_pd (__m256d a, __m128d b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<Int16>, Vector128<Int16>, Byte)	__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<Int32>, Vector128<Int32>, Byte)	__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<Int64>, Vector128<Int64>, Byte)	__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<SByte>, Vector128<SByte>, Byte)	__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<Single>, Vector128<Single>, Byte)	__m256 _mm256_insertf128_ps (__m256 a, __m128 b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<UInt16>, Vector128<UInt16>, Byte)	__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<UInt32>, Vector128<UInt32>, Byte)	__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // InsertVector128(Vector256<UInt64>, Vector128<UInt64>, Byte)	__m256i _mm256_insertf128_si256 (__m256i a, __m128i b, int imm8)
            // VINSERTF128 ymm, ymm, xmm/m128, imm8
            // Copy a to dst, then insert 128 bits from b into dst at the location specified by imm8.
            // dst[255:0] := a[255:0]
            // CASE (imm8[0]) OF
            // 0: dst[127:0] := b[127:0]
            // 1: dst[255:128] := b[127:0]
            // ESAC
            foreach (byte idx in new byte[] { 0, 1 }) {
                WriteLineFormat(tw, indent, "InsertVector128 - idx={0} (0x{0:X}):", idx);
                WriteLineFormat(tw, indentNext, "InsertVector128(srcT_256_int, src2_128_int, idx):\t{0}", Avx.InsertVector128(srcT_256_int, src2_128_int, idx));
                WriteLineFormat(tw, indentNext, "InsertVector128(srcT_256_double, src2_128_double, idx):\t{0}", Avx.InsertVector128(srcT_256_double, src2_128_double, idx));
                WriteLineFormat(tw, indentNext, "InsertVector128(srcT_256_float, src2_128_float, idx):\t{0}", Avx.InsertVector128(srcT_256_float, src2_128_float, idx));
            }

            // LoadAlignedVector256(Byte*)	__m256i _mm256_load_si256 (__m256i const * mem_addr)
            // VMOVDQA ymm, m256
            // LoadAlignedVector256(Double*)	__m256d _mm256_load_pd (double const * mem_addr)
            // VMOVAPD ymm, ymm/m256
            // LoadAlignedVector256(Int16*)	__m256i _mm256_load_si256 (__m256i const * mem_addr)
            // VMOVDQA ymm, m256
            // LoadAlignedVector256(Int32*)	__m256i _mm256_load_si256 (__m256i const * mem_addr)
            // VMOVDQA ymm, m256
            // LoadAlignedVector256(Int64*)	__m256i _mm256_load_si256 (__m256i const * mem_addr)
            // VMOVDQA ymm, m256
            // LoadAlignedVector256(SByte*)	__m256i _mm256_load_si256 (__m256i const * mem_addr)
            // VMOVDQA ymm, m256
            // LoadAlignedVector256(Single*)	__m256 _mm256_load_ps (float const * mem_addr)
            // VMOVAPS ymm, ymm/m256
            // LoadAlignedVector256(UInt16*)	__m256i _mm256_load_si256 (__m256i const * mem_addr)
            // VMOVDQA ymm, m256
            // LoadAlignedVector256(UInt32*)	__m256i _mm256_load_si256 (__m256i const * mem_addr)
            // VMOVDQA ymm, m256
            // LoadAlignedVector256(UInt64*)	__m256i _mm256_load_si256 (__m256i const * mem_addr)
            // VMOVDQA ymm, m256
            // LoadDquVector256(Byte*)	__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
            // VLDDQU ymm, m256
            // LoadDquVector256(Int16*)	__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
            // VLDDQU ymm, m256
            // LoadDquVector256(Int32*)	__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
            // VLDDQU ymm, m256
            // LoadDquVector256(Int64*)	__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
            // VLDDQU ymm, m256
            // LoadDquVector256(SByte*)	__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
            // VLDDQU ymm, m256
            // LoadDquVector256(UInt16*)	__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
            // VLDDQU ymm, m256
            // LoadDquVector256(UInt32*)	__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
            // VLDDQU ymm, m256
            // LoadDquVector256(UInt64*)	__m256i _mm256_lddqu_si256 (__m256i const * mem_addr)
            // VLDDQU ymm, m256
            // LoadVector256(Byte*)	__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
            // VMOVDQU ymm, m256
            // LoadVector256(Double*)	__m256d _mm256_loadu_pd (double const * mem_addr)
            // VMOVUPD ymm, ymm/m256
            // LoadVector256(Int16*)	__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
            // VMOVDQU ymm, m256
            // LoadVector256(Int32*)	__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
            // VMOVDQU ymm, m256
            // LoadVector256(Int64*)	__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
            // VMOVDQU ymm, m256
            // LoadVector256(SByte*)	__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
            // VMOVDQU ymm, m256
            // LoadVector256(Single*)	__m256 _mm256_loadu_ps (float const * mem_addr)
            // VMOVUPS ymm, ymm/m256
            // LoadVector256(UInt16*)	__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
            // VMOVDQU ymm, m256
            // LoadVector256(UInt32*)	__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
            // VMOVDQU ymm, m256
            // LoadVector256(UInt64*)	__m256i _mm256_loadu_si256 (__m256i const * mem_addr)
            // VMOVDQU ymm, m256
            // (ignore)

            // MaskLoad(Double*, Vector128<Double>)	__m128d _mm_maskload_pd (double const * mem_addr, __m128i mask)
            // VMASKMOVPD xmm, xmm, m128
            // MaskLoad(Double*, Vector256<Double>)	__m256d _mm256_maskload_pd (double const * mem_addr, __m256i mask)
            // VMASKMOVPD ymm, ymm, m256
            // MaskLoad(Single*, Vector128<Single>)	__m128 _mm_maskload_ps (float const * mem_addr, __m128i mask)
            // VMASKMOVPS xmm, xmm, m128
            // MaskLoad(Single*, Vector256<Single>)	__m256 _mm256_maskload_ps (float const * mem_addr, __m256i mask)
            // VMASKMOVPS ymm, ymm, m256
            // Load packed single-precision (32-bit) floating-point elements from memory into dst using mask (elements are zeroed out when the high bit of the corresponding element is not set).
            // FOR j := 0 to 7
            // 	i := j*32
            // 	IF mask[i+31]
            // 		dst[i+31:i] := MEM[mem_addr+i+31:mem_addr+i]
            // 	ELSE
            // 		dst[i+31:i] := 0
            // 	FI
            // ENDFOR
            fixed (void* p = &src1_128_double) {
                WriteLineFormat(tw, indent, "MaskLoad(&src1_128_double, srcT_128_double):\t{0}", Avx.MaskLoad((double*)p, srcT_128_double));
            }
            fixed (void* p = &src1_256_double) {
                WriteLineFormat(tw, indent, "MaskLoad(&src1_256_double, srcT_256_double):\t{0}", Avx.MaskLoad((double*)p, srcT_256_double));
            }
            fixed (void* p = &src1_128_float) {
                WriteLineFormat(tw, indent, "MaskLoad(&src1_128_float, srcT_128_float):\t{0}", Avx.MaskLoad((float*)p, srcT_128_float));
            }
            fixed (void* p = &src1_256_float) {
                WriteLineFormat(tw, indent, "MaskLoad(&src1_256_float, srcT_256_float):\t{0}", Avx.MaskLoad((float*)p, srcT_256_float));
            }

            // MaskStore(Double*, Vector128<Double>, Vector128<Double>)	void _mm_maskstore_pd (double * mem_addr, __m128i mask, __m128d a)
            // VMASKMOVPD m128, xmm, xmm
            // MaskStore(Double*, Vector256<Double>, Vector256<Double>)	void _mm256_maskstore_pd (double * mem_addr, __m256i mask, __m256d a)
            // VMASKMOVPD m256, ymm, ymm
            // MaskStore(Single*, Vector128<Single>, Vector128<Single>)	void _mm_maskstore_ps (float * mem_addr, __m128i mask, __m128 a)
            // VMASKMOVPS m128, xmm, xmm
            // MaskStore(Single*, Vector256<Single>, Vector256<Single>)	void _mm256_maskstore_ps (float * mem_addr, __m256i mask, __m256 a)
            // VMASKMOVPS m256, ymm, ymm
            Vector128<double> srcS_128_double = src2_128_double;
            Avx.MaskStore((double*)&srcS_128_double, srcT_128_double, src1_128_double);
            WriteLineFormat(tw, indent, "MaskStore((double*)&srcS_128_double, srcT_128_double, src1_128_double):\t{0}", srcS_128_double);
            Vector256<double> srcS_256_double = src2_256_double;
            Avx.MaskStore((double*)&srcS_256_double, srcT_256_double, src1_256_double);
            WriteLineFormat(tw, indent, "MaskStore((double*)&srcS_256_double, srcT_256_double, src1_256_double):\t{0}", srcS_256_double);
            Vector128<float> srcS_128_float = src2_128_float;
            Avx.MaskStore((float*)&srcS_128_float, srcT_128_float, src1_128_float);
            WriteLineFormat(tw, indent, "MaskStore((float*)&srcS_128_float, srcT_128_float, src1_128_float):\t{0}", srcS_128_float);
            Vector256<float> srcS_256_float = src2_256_float;
            Avx.MaskStore((float*)&srcS_256_float, srcT_256_float, src1_256_float);
            WriteLineFormat(tw, indent, "MaskStore((float*)&srcS_256_float, srcT_256_float, src1_256_float):\t{0}", srcS_256_float);

            // Max(Vector256<Double>, Vector256<Double>)	__m256d _mm256_max_pd (__m256d a, __m256d b)
            // VMAXPD ymm, ymm, ymm/m256
            // Max(Vector256<Single>, Vector256<Single>)	__m256 _mm256_max_ps (__m256 a, __m256 b)
            // VMAXPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Max(srcT_256_double, src2_256_double):\t{0}", Avx.Max(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "Max(srcT_256_float, src2_256_float):\t{0}", Avx.Max(srcT_256_float, src2_256_float));

            // Min(Vector256<Double>, Vector256<Double>)	__m256d _mm256_min_pd (__m256d a, __m256d b)
            // VMINPD ymm, ymm, ymm/m256
            // Min(Vector256<Single>, Vector256<Single>)	__m256 _mm256_min_ps (__m256 a, __m256 b)
            // VMINPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Min(srcT_256_double, src2_256_double):\t{0}", Avx.Min(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "Min(srcT_256_float, src2_256_float):\t{0}", Avx.Min(srcT_256_float, src2_256_float));

            // MoveMask(Vector256<Double>)	int _mm256_movemask_pd (__m256d a)
            // VMOVMSKPD reg, ymm
            // MoveMask(Vector256<Single>)	int _mm256_movemask_ps (__m256 a)
            // VMOVMSKPS reg, ymm
            //Set each bit of mask dst based on the most significant bit of the corresponding packed single-precision (32-bit) floating-point element in a.
            //FOR j := 0 to 7
            //	i := j*32
            //	IF a[i+31]
            //		dst[j] := 1
            //	ELSE
            //		dst[j] := 0
            //	FI
            //ENDFOR
            //dst[MAX:8] := 0
            WriteLineFormat(tw, indent, "MoveMask(srcT_256_double):\t{0}\t# 0x{0:X}", Avx.MoveMask(srcT_256_double));
            WriteLineFormat(tw, indent, "MoveMask(srcT_256_float):\t{0}\t# 0x{0:X}", Avx.MoveMask(srcT_256_float));

            // Multiply(Vector256<Double>, Vector256<Double>)	__m256d _mm256_mul_pd (__m256d a, __m256d b)
            // VMULPD ymm, ymm, ymm/m256
            // Multiply(Vector256<Single>, Vector256<Single>)	__m256 _mm256_mul_ps (__m256 a, __m256 b)
            // VMULPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Multiply(srcT_256_double, src2_256_double):\t{0}", Avx.Multiply(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "Multiply(srcT_256_float, src2_256_float):\t{0}", Avx.Multiply(srcT_256_float, src2_256_float));

            // Or(Vector256<Double>, Vector256<Double>)	__m256d _mm256_or_pd (__m256d a, __m256d b)
            // VORPD ymm, ymm, ymm/m256
            // Or(Vector256<Single>, Vector256<Single>)	__m256 _mm256_or_ps (__m256 a, __m256 b)
            // VORPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Or(srcT_256_double, src2_256_double):\t{0}", Avx.Or(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "Or(srcT_256_float, src2_256_float):\t{0}", Avx.Or(srcT_256_float, src2_256_float));

            // Permute(Vector128<Double>, Byte)	__m128d _mm_permute_pd (__m128d a, int imm8)
            // VPERMILPD xmm, xmm, imm8
            // Shuffle double-precision (64-bit) floating-point elements in a using the control in imm8, and store the results in dst. (使用imm8中的控制码，对a中的双精度（64位）浮点元素进行洗牌，并将结果存储在dst中。)
            // IF (imm8[0] == 0) dst[63:0] := a[63:0]; FI
            // IF (imm8[0] == 1) dst[63:0] := a[127:64]; FI
            // IF (imm8[1] == 0) dst[127:64] := a[63:0]; FI
            // IF (imm8[1] == 1) dst[127:64] := a[127:64]; FI
            // Permute(Vector128<Single>, Byte)	__m128 _mm_permute_ps (__m128 a, int imm8)
            // VPERMILPS xmm, xmm, imm8
            // Shuffle single-precision (32-bit) floating-point elements in a using the control in imm8, and store the results in dst.
            // DEFINE SELECT4(src, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[31:0] := src[31:0]
            // 	1:	tmp[31:0] := src[63:32]
            // 	2:	tmp[31:0] := src[95:64]
            // 	3:	tmp[31:0] := src[127:96]
            // 	ESAC
            // 	RETURN tmp[31:0]
            // }
            // dst[31:0] := SELECT4(a[127:0], imm8[1:0])
            // dst[63:32] := SELECT4(a[127:0], imm8[3:2])
            // dst[95:64] := SELECT4(a[127:0], imm8[5:4])
            // dst[127:96] := SELECT4(a[127:0], imm8[7:6])
            // Permute(Vector256<Double>, Byte)	__m256d _mm256_permute_pd (__m256d a, int imm8)
            // VPERMILPD ymm, ymm, imm8
            // Shuffle double-precision (64-bit) floating-point elements in a within 128-bit lanes using the control in imm8, and store the results in dst.
            // IF (imm8[0] == 0) dst[63:0] := a[63:0]; FI
            // IF (imm8[0] == 1) dst[63:0] := a[127:64]; FI
            // IF (imm8[1] == 0) dst[127:64] := a[63:0]; FI
            // IF (imm8[1] == 1) dst[127:64] := a[127:64]; FI
            // IF (imm8[2] == 0) dst[191:128] := a[191:128]; FI
            // IF (imm8[2] == 1) dst[191:128] := a[255:192]; FI
            // IF (imm8[3] == 0) dst[255:192] := a[191:128]; FI
            // IF (imm8[3] == 1) dst[255:192] := a[255:192]; FI
            // Permute(Vector256<Single>, Byte)	__m256 _mm256_permute_ps (__m256 a, int imm8)
            // VPERMILPS ymm, ymm, imm8
            // Shuffle single-precision (32-bit) floating-point elements in a within 128-bit lanes using the control in imm8, and store the results in dst.
            // DEFINE SELECT4(src, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[31:0] := src[31:0]
            // 	1:	tmp[31:0] := src[63:32]
            // 	2:	tmp[31:0] := src[95:64]
            // 	3:	tmp[31:0] := src[127:96]
            // 	ESAC
            // 	RETURN tmp[31:0]
            // }
            // dst[31:0] := SELECT4(a[127:0], imm8[1:0])
            // dst[63:32] := SELECT4(a[127:0], imm8[3:2])
            // dst[95:64] := SELECT4(a[127:0], imm8[5:4])
            // dst[127:96] := SELECT4(a[127:0], imm8[7:6])
            // dst[159:128] := SELECT4(a[255:128], imm8[1:0])
            // dst[191:160] := SELECT4(a[255:128], imm8[3:2])
            // dst[223:192] := SELECT4(a[255:128], imm8[5:4])
            // dst[255:224] := SELECT4(a[255:128], imm8[7:6])
            // Permute - control: Reverse order based on 128 bits.
            WriteLineFormat(tw, indent, "Permute(srcT_128_double, 0b0000_0001):\t{0}", Avx.Permute(srcT_128_double, 0b0000_0001));
            WriteLineFormat(tw, indent, "Permute(srcT_128_float,  0b0001_1011):\t{0}", Avx.Permute(srcT_128_float,  0b0001_1011));
            WriteLineFormat(tw, indent, "Permute(srcT_256_double, 0b0000_0101):\t{0}", Avx.Permute(srcT_256_double, 0b0000_0101));
            WriteLineFormat(tw, indent, "Permute(srcT_256_float,  0b0001_1011):\t{0}", Avx.Permute(srcT_256_float,  0b0001_1011));

            // Permute2x128(Vector256<Byte>, Vector256<Byte>, Byte)	__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Shuffle 128-bits (composed of integer data) selected by imm8 from a and b, and store the results in dst. (通过imm8从a和b中选择128位（由整数数据组成）进行洗牌，并将结果存储在dst。)
            // DEFINE SELECT4(src1, src2, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[127:0] := src1[127:0]
            // 	1:	tmp[127:0] := src1[255:128]
            // 	2:	tmp[127:0] := src2[127:0]
            // 	3:	tmp[127:0] := src2[255:128]
            // 	ESAC
            // 	IF control[3]
            // 		tmp[127:0] := 0
            // 	FI
            // 	RETURN tmp[127:0]
            // }
            // dst[127:0] := SELECT4(a[255:0], b[255:0], imm8[3:0])
            // dst[255:128] := SELECT4(a[255:0], b[255:0], imm8[7:4])
            // Permute2x128(Vector256<Double>, Vector256<Double>, Byte)	__m256d _mm256_permute2f128_pd (__m256d a, __m256d b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Shuffle 128-bits (composed of 2 packed double-precision (64-bit) floating-point elements) selected by imm8 from a and b, and store the results in dst.
            // DEFINE SELECT4(src1, src2, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[127:0] := src1[127:0]
            // 	1:	tmp[127:0] := src1[255:128]
            // 	2:	tmp[127:0] := src2[127:0]
            // 	3:	tmp[127:0] := src2[255:128]
            // 	ESAC
            // 	IF control[3]
            // 		tmp[127:0] := 0
            // 	FI
            // 	RETURN tmp[127:0]
            // }
            // dst[127:0] := SELECT4(a[255:0], b[255:0], imm8[3:0])
            // dst[255:128] := SELECT4(a[255:0], b[255:0], imm8[7:4])
            // Permute2x128(Vector256<Int16>, Vector256<Int16>, Byte)	__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<Int32>, Vector256<Int32>, Byte)	__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<Int64>, Vector256<Int64>, Byte)	__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<SByte>, Vector256<SByte>, Byte)	__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<Single>, Vector256<Single>, Byte)	__m256 _mm256_permute2f128_ps (__m256 a, __m256 b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Shuffle 128-bits (composed of 4 packed single-precision (32-bit) floating-point elements) selected by imm8 from a and b, and store the results in dst.
            // DEFINE SELECT4(src1, src2, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[127:0] := src1[127:0]
            // 	1:	tmp[127:0] := src1[255:128]
            // 	2:	tmp[127:0] := src2[127:0]
            // 	3:	tmp[127:0] := src2[255:128]
            // 	ESAC
            // 	IF control[3]
            // 		tmp[127:0] := 0
            // 	FI
            // 	RETURN tmp[127:0]
            // }
            // dst[127:0] := SELECT4(a[255:0], b[255:0], imm8[3:0])
            // dst[255:128] := SELECT4(a[255:0], b[255:0], imm8[7:4])
            // Permute2x128(Vector256<UInt16>, Vector256<UInt16>, Byte)	__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<UInt32>, Vector256<UInt32>, Byte)	__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<UInt64>, Vector256<UInt64>, Byte)	__m256i _mm256_permute2f128_si256 (__m256i a, __m256i b, int imm8)
            // VPERM2F128 ymm, ymm, ymm/m256, imm8
            foreach (byte control in new byte[] { 0, 1, 2, 3, 0x23, 0xA3, 0x10 }) {
                WriteLineFormat(tw, indent, "Permute2x128 - control={0} (0x{0:X}):", control);
                WriteLineFormat(tw, indentNext, "Permute2x128(srcT_256_int, src2_256_int, control):\t{0}", Avx.Permute2x128(srcT_256_int, src2_256_int, control));
                WriteLineFormat(tw, indentNext, "Permute2x128(srcT_256_double, src2_256_double, control):\t{0}", Avx.Permute2x128(srcT_256_double, src2_256_double, control));
                WriteLineFormat(tw, indentNext, "Permute2x128(srcT_256_float, src2_256_float, control):\t{0}", Avx.Permute2x128(srcT_256_float, src2_256_float, control));
            }

            // PermuteVar(Vector128<Double>, Vector128<Int64>)	__m128d _mm_permutevar_pd (__m128d a, __m128i b)
            // VPERMILPD xmm, xmm, xmm/m128
            // Shuffle double-precision (64-bit) floating-point elements in a using the control in b, and store the results in dst.
            // IF (b[1] == 0) dst[63:0] := a[63:0]; FI
            // IF (b[1] == 1) dst[63:0] := a[127:64]; FI
            // IF (b[65] == 0) dst[127:64] := a[63:0]; FI
            // IF (b[65] == 1) dst[127:64] := a[127:64]; FI
            // PermuteVar(Vector128<Single>, Vector128<Int32>)	__m128 _mm_permutevar_ps (__m128 a, __m128i b)
            // VPERMILPS xmm, xmm, xmm/m128
            // DEFINE SELECT4(src, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[31:0] := src[31:0]
            // 	1:	tmp[31:0] := src[63:32]
            // 	2:	tmp[31:0] := src[95:64]
            // 	3:	tmp[31:0] := src[127:96]
            // 	ESAC
            // 	RETURN tmp[31:0]
            // }
            // dst[31:0] := SELECT4(a[127:0], b[1:0])
            // dst[63:32] := SELECT4(a[127:0], b[33:32])
            // dst[95:64] := SELECT4(a[127:0], b[65:64])
            // dst[127:96] := SELECT4(a[127:0], b[97:96])
            // PermuteVar(Vector256<Double>, Vector256<Int64>)	__m256d _mm256_permutevar_pd (__m256d a, __m256i b)
            // VPERMILPD ymm, ymm, ymm/m256
            // IF (b[1] == 0) dst[63:0] := a[63:0]; FI
            // IF (b[1] == 1) dst[63:0] := a[127:64]; FI
            // IF (b[65] == 0) dst[127:64] := a[63:0]; FI
            // IF (b[65] == 1) dst[127:64] := a[127:64]; FI
            // IF (b[129] == 0) dst[191:128] := a[191:128]; FI
            // IF (b[129] == 1) dst[191:128] := a[255:192]; FI
            // IF (b[193] == 0) dst[255:192] := a[191:128]; FI
            // IF (b[193] == 1) dst[255:192] := a[255:192]; FI
            // PermuteVar(Vector256<Single>, Vector256<Int32>)	__m256 _mm256_permutevar_ps (__m256 a, __m256i b)
            // VPERMILPS ymm, ymm, ymm/m256
            // DEFINE SELECT4(src, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[31:0] := src[31:0]
            // 	1:	tmp[31:0] := src[63:32]
            // 	2:	tmp[31:0] := src[95:64]
            // 	3:	tmp[31:0] := src[127:96]
            // 	ESAC
            // 	RETURN tmp[31:0]
            // }
            // dst[31:0] := SELECT4(a[127:0], b[1:0])
            // dst[63:32] := SELECT4(a[127:0], b[33:32])
            // dst[95:64] := SELECT4(a[127:0], b[65:64])
            // dst[127:96] := SELECT4(a[127:0], b[97:96])
            // dst[159:128] := SELECT4(a[255:128], b[129:128])
            // dst[191:160] := SELECT4(a[255:128], b[161:160])
            // dst[223:192] := SELECT4(a[255:128], b[193:192])
            // dst[255:224] := SELECT4(a[255:128], b[225:224])
            // PermuteVar - control: Reverse order based on 128 bits.
            WriteLineFormat(tw, indent, "PermuteVar(srcT_128_double, Vector128.Create(2L, 0L)):\t{0}", Avx.PermuteVar(srcT_128_double, Vector128.Create(2L, 0L)));
            WriteLineFormat(tw, indent, "PermuteVar(srcT_128_float, Vector128.Create(3, 2, 1, 0)):\t{0}", Avx.PermuteVar(srcT_128_float, Vector128.Create(3, 2, 1, 0)));
            WriteLineFormat(tw, indent, "PermuteVar(srcT_256_double, Vector256.Create(2L, 0L)):\t{0}", Avx.PermuteVar(srcT_256_double, Vector256.Create(2L, 0L, 2L, 0L)));
            WriteLineFormat(tw, indent, "PermuteVar(srcT_256_float, Vector256.Create(3, 2, 1, 0)):\t{0}", Avx.PermuteVar(srcT_256_float, Vector256.Create(3, 2, 1, 0, 3, 2, 1, 0)));

            // Reciprocal(Vector256<Single>)	__m256 _mm256_rcp_ps (__m256 a)
            // VRCPPS ymm, ymm/m256
            // Compute the approximate reciprocal of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. The maximum relative error for this approximation is less than 1.5*2^-12. (计算a中打包的单精度（32位）浮点元素的近似倒数，并将结果存储在dst中。这个近似值的最大相对误差小于1.5*2^-12。)
            WriteLineFormat(tw, indent, "Reciprocal(srcT_256_float):\t{0}", Avx.Reciprocal(srcT_256_float));

            // ReciprocalSqrt(Vector256<Single>)	__m256 _mm256_rsqrt_ps (__m256 a)
            // VRSQRTPS ymm, ymm/m256
            // Compute the approximate reciprocal square root of packed single-precision (32-bit) floating-point elements in a, and store the results in dst. The maximum relative error for this approximation is less than 1.5*2^-12. (计算a中打包的单精度（32位）浮点元素的近似平方根的倒数，并将结果存储在dst中。这个近似值的最大相对误差小于1.5*2^-12。)
            // FOR j := 0 to 7
            // 	i := j*32
            // 	dst[i+31:i] := (1.0 / SQRT(a[i+31:i]))
            // ENDFOR
            WriteLineFormat(tw, indent, "ReciprocalSqrt(srcT_256_float):\t{0}", Avx.ReciprocalSqrt(srcT_256_float));

            // RoundCurrentDirection(Vector256<Double>)	__m256d _mm256_round_pd (__m256d a, _MM_FROUND_CUR_DIRECTION)
            // VROUNDPD ymm, ymm/m256, imm8(4)
            // RoundCurrentDirection(Vector256<Single>)	__m256 _mm256_round_ps (__m256 a, _MM_FROUND_CUR_DIRECTION)
            // VROUNDPS ymm, ymm/m256, imm8(4)
            // RoundToNearestInteger(Vector256<Double>)	__m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_NEAREST_INT | _MM_FROUND_NO_EXC)
            // VROUNDPD ymm, ymm/m256, imm8(8)
            // RoundToNearestInteger(Vector256<Single>)	__m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_NEAREST_INT | _MM_FROUND_NO_EXC)
            // VROUNDPS ymm, ymm/m256, imm8(8)
            // RoundToNegativeInfinity(Vector256<Double>)	__m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_NEG_INF | _MM_FROUND_NO_EXC)
            // VROUNDPD ymm, ymm/m256, imm8(9)
            // RoundToNegativeInfinity(Vector256<Single>)	__m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_NEG_INF | _MM_FROUND_NO_EXC)
            // VROUNDPS ymm, ymm/m256, imm8(9)
            // RoundToPositiveInfinity(Vector256<Double>)	__m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_POS_INF | _MM_FROUND_NO_EXC)
            // VROUNDPD ymm, ymm/m256, imm8(10)
            // RoundToPositiveInfinity(Vector256<Single>)	__m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_POS_INF | _MM_FROUND_NO_EXC)
            // VROUNDPS ymm, ymm/m256, imm8(10)
            // RoundToZero(Vector256<Double>)	__m256d _mm256_round_pd (__m256d a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC)
            // VROUNDPD ymm, ymm/m256, imm8(11)
            // RoundToZero(Vector256<Single>)	__m256 _mm256_round_ps (__m256 a, _MM_FROUND_TO_ZERO | _MM_FROUND_NO_EXC)
            // VROUNDPS ymm, ymm/m256, imm8(11)
            WriteLineFormat(tw, indent, "RoundCurrentDirection(srcT_256_double):\t{0}", Avx.RoundCurrentDirection(srcT_256_double));
            WriteLineFormat(tw, indent, "RoundCurrentDirection(srcT_256_float):\t{0}", Avx.RoundCurrentDirection(srcT_256_float));
            WriteLineFormat(tw, indent, "RoundCurrentDirection(srcT_256_double):\t{0}", Avx.RoundCurrentDirection(srcT_256_double));
            WriteLineFormat(tw, indent, "RoundCurrentDirection(srcT_256_float):\t{0}", Avx.RoundCurrentDirection(srcT_256_float));
            WriteLineFormat(tw, indent, "RoundToNearestInteger(srcT_256_double):\t{0}", Avx.RoundToNearestInteger(srcT_256_double));
            WriteLineFormat(tw, indent, "RoundToNearestInteger(srcT_256_float):\t{0}", Avx.RoundToNearestInteger(srcT_256_float));
            WriteLineFormat(tw, indent, "RoundToNegativeInfinity(srcT_256_double):\t{0}", Avx.RoundToNegativeInfinity(srcT_256_double));
            WriteLineFormat(tw, indent, "RoundToNegativeInfinity(srcT_256_float):\t{0}", Avx.RoundToNegativeInfinity(srcT_256_float));
            WriteLineFormat(tw, indent, "RoundToPositiveInfinity(srcT_256_double):\t{0}", Avx.RoundToPositiveInfinity(srcT_256_double));
            WriteLineFormat(tw, indent, "RoundToPositiveInfinity(srcT_256_float):\t{0}", Avx.RoundToPositiveInfinity(srcT_256_float));
            WriteLineFormat(tw, indent, "RoundToZero(srcT_256_double):\t{0}", Avx.RoundToZero(srcT_256_double));
            WriteLineFormat(tw, indent, "RoundToZero(srcT_256_float):\t{0}", Avx.RoundToZero(srcT_256_float));

            // Shuffle(Vector256<Double>, Vector256<Double>, Byte)	__m256d _mm256_shuffle_pd (__m256d a, __m256d b, const int imm8)
            // VSHUFPD ymm, ymm, ymm/m256, imm8
            // Shuffle double-precision (64-bit) floating-point elements within 128-bit lanes using the control in imm8, and store the results in dst.
            // dst[63:0] := (imm8[0] == 0) ? a[63:0] : a[127:64]
            // dst[127:64] := (imm8[1] == 0) ? b[63:0] : b[127:64]
            // dst[191:128] := (imm8[2] == 0) ? a[191:128] : a[255:192]
            // dst[255:192] := (imm8[3] == 0) ? b[191:128] : b[255:192]
            // Shuffle(Vector256<Single>, Vector256<Single>, Byte)	__m256 _mm256_shuffle_ps (__m256 a, __m256 b, const int imm8)
            // VSHUFPS ymm, ymm, ymm/m256, imm8
            // Shuffle single-precision (32-bit) floating-point elements in a within 128-bit lanes using the control in imm8, and store the results in dst.
            // DEFINE SELECT4(src, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[31:0] := src[31:0]
            // 	1:	tmp[31:0] := src[63:32]
            // 	2:	tmp[31:0] := src[95:64]
            // 	3:	tmp[31:0] := src[127:96]
            // 	ESAC
            // 	RETURN tmp[31:0]
            // }
            // dst[31:0] := SELECT4(a[127:0], imm8[1:0])
            // dst[63:32] := SELECT4(a[127:0], imm8[3:2])
            // dst[95:64] := SELECT4(b[127:0], imm8[5:4])
            // dst[127:96] := SELECT4(b[127:0], imm8[7:6])
            // dst[159:128] := SELECT4(a[255:128], imm8[1:0])
            // dst[191:160] := SELECT4(a[255:128], imm8[3:2])
            // dst[223:192] := SELECT4(b[255:128], imm8[5:4])
            // dst[255:224] := SELECT4(b[255:128], imm8[7:6])
            // PermuteVar - control: Reverse order based on 128 bits.
            WriteLineFormat(tw, indent, "RoundToZero(srcT_256_double):\t{0}", Avx.Shuffle(srcT_256_double, srcT_256_double, 0b0000_0101));
            WriteLineFormat(tw, indent, "RoundToZero(srcT_256_float):\t{0}", Avx.Shuffle(srcT_256_float, srcT_256_float, 0b0001_1011));

            // Sqrt(Vector256<Double>)	__m256d _mm256_sqrt_pd (__m256d a)
            // VSQRTPD ymm, ymm/m256
            // Sqrt(Vector256<Single>)	__m256 _mm256_sqrt_ps (__m256 a)
            // VSQRTPS ymm, ymm/m256
            WriteLineFormat(tw, indent, "Sqrt(srcT_256_double):\t{0}", Avx.Sqrt(srcT_256_double));
            WriteLineFormat(tw, indent, "Sqrt(srcT_256_float):\t{0}", Avx.Sqrt(srcT_256_float));

            // Store(Byte*, Vector256<Byte>)	void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQU m256, ymm
            // Store(Double*, Vector256<Double>)	void _mm256_storeu_pd (double * mem_addr, __m256d a)
            // MOVUPD m256, ymm
            // Store(Int16*, Vector256<Int16>)	void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQU m256, ymm
            // Store(Int32*, Vector256<Int32>)	void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQU m256, ymm
            // Store(Int64*, Vector256<Int64>)	void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQU m256, ymm
            // Store(SByte*, Vector256<SByte>)	void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQU m256, ymm
            // Store(Single*, Vector256<Single>)	void _mm256_storeu_ps (float * mem_addr, __m256 a)
            // MOVUPS m256, ymm
            // Store(UInt16*, Vector256<UInt16>)	void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQU m256, ymm
            // Store(UInt32*, Vector256<UInt32>)	void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQU m256, ymm
            // Store(UInt64*, Vector256<UInt64>)	void _mm256_storeu_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQU m256, ymm
            // StoreAligned(Byte*, Vector256<Byte>)	void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQA m256, ymm
            // StoreAligned(Double*, Vector256<Double>)	void _mm256_store_pd (double * mem_addr, __m256d a)
            // VMOVAPD m256, ymm
            // StoreAligned(Int16*, Vector256<Int16>)	void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQA m256, ymm
            // StoreAligned(Int32*, Vector256<Int32>)	void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQA m256, ymm
            // StoreAligned(Int64*, Vector256<Int64>)	void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQA m256, ymm
            // StoreAligned(SByte*, Vector256<SByte>)	void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQA m256, ymm
            // StoreAligned(Single*, Vector256<Single>)	void _mm256_store_ps (float * mem_addr, __m256 a)
            // VMOVAPS m256, ymm
            // StoreAligned(UInt16*, Vector256<UInt16>)	void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQA m256, ymm
            // StoreAligned(UInt32*, Vector256<UInt32>)	void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQA m256, ymm
            // StoreAligned(UInt64*, Vector256<UInt64>)	void _mm256_store_si256 (__m256i * mem_addr, __m256i a)
            // MOVDQA m256, ymm
            // StoreAlignedNonTemporal(Byte*, Vector256<Byte>)	void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
            // VMOVNTDQ m256, ymm
            // StoreAlignedNonTemporal(Double*, Vector256<Double>)	void _mm256_stream_pd (double * mem_addr, __m256d a)
            // MOVNTPD m256, ymm
            // StoreAlignedNonTemporal(Int16*, Vector256<Int16>)	void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
            // VMOVNTDQ m256, ymm
            // StoreAlignedNonTemporal(Int32*, Vector256<Int32>)	void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
            // VMOVNTDQ m256, ymm
            // StoreAlignedNonTemporal(Int64*, Vector256<Int64>)	void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
            // VMOVNTDQ m256, ymm
            // StoreAlignedNonTemporal(SByte*, Vector256<SByte>)	void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
            // VMOVNTDQ m256, ymm
            // StoreAlignedNonTemporal(Single*, Vector256<Single>)	void _mm256_stream_ps (float * mem_addr, __m256 a)
            // MOVNTPS m256, ymm
            // StoreAlignedNonTemporal(UInt16*, Vector256<UInt16>)	void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
            // VMOVNTDQ m256, ymm
            // StoreAlignedNonTemporal(UInt32*, Vector256<UInt32>)	void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
            // VMOVNTDQ m256, ymm
            // StoreAlignedNonTemporal(UInt64*, Vector256<UInt64>)	void _mm256_stream_si256 (__m256i * mem_addr, __m256i a)
            // VMOVNTDQ m256, ymm
            // (ignore)

            // Subtract(Vector256<Double>, Vector256<Double>)	__m256d _mm256_sub_pd (__m256d a, __m256d b)
            // VSUBPD ymm, ymm, ymm/m256
            // Subtract(Vector256<Single>, Vector256<Single>)	__m256 _mm256_sub_ps (__m256 a, __m256 b)
            // VSUBPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Subtract(srcT_256_double, src2_256_double):\t{0}", Avx.Subtract(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "Subtract(srcT_256_float, src2_256_float):\t{0}", Avx.Subtract(srcT_256_float, src2_256_float));

            // TestC(Vector128<Double>, Vector128<Double>)	int _mm_testc_pd (__m128d a, __m128d b)
            // VTESTPD xmm, xmm/m128
            // Compute the bitwise AND of 128 bits (representing double-precision (64-bit) floating-point elements) in a and b, producing an intermediate 128-bit value, and set ZF to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set ZF to 0. Compute the bitwise NOT of a and then AND with b, producing an intermediate value, and set CF to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set CF to 0. Return the CF value. (计算a和b中128位（代表双精度（64位）浮点元素）的位与，产生一个128位的中间值，如果中间值中每个64位元素的符号位为0，则将ZF设置为1，否则将ZF设置为0。计算a的位数非，然后与b相与，产生一个中间值，如果中间值中每个64位元素的符号位为0，则将CF设置为1，否则将CF设置为0。)
            // tmp[127:0] := a[127:0] AND b[127:0]
            // IF (tmp[63] == 0 && tmp[127] == 0)
            // 	ZF := 1
            // ELSE
            // 	ZF := 0
            // FI
            // tmp[127:0] := (NOT a[127:0]) AND b[127:0]
            // IF (tmp[63] == 0 && tmp[127] == 0)
            // 	CF := 1
            // ELSE
            // 	CF := 0
            // FI
            // dst := CF
            // TestC(Vector128<Single>, Vector128<Single>)	int _mm_testc_ps (__m128 a, __m128 b)
            // VTESTPS xmm, xmm/m128
            // Compute the bitwise AND of 128 bits (representing single-precision (32-bit) floating-point elements) in a and b, producing an intermediate 128-bit value, and set ZF to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set ZF to 0. Compute the bitwise NOT of a and then AND with b, producing an intermediate value, and set CF to 1 if the sign bit of each 32-bit element in the intermediate value is zero, otherwise set CF to 0. Return the CF value.
            // tmp[127:0] := a[127:0] AND b[127:0]
            // IF (tmp[31] == 0 && tmp[63] == 0 && tmp[95] == 0 && tmp[127] == 0)
            // 	ZF := 1
            // ELSE
            // 	ZF := 0
            // FI
            // tmp[127:0] := (NOT a[127:0]) AND b[127:0]
            // IF (tmp[31] == 0 && tmp[63] == 0 && tmp[95] == 0 && tmp[127] == 0)
            // 	CF := 1
            // ELSE
            // 	CF := 0
            // FI
            // dst := CF
            // TestC(Vector256<Byte>, Vector256<Byte>)	int _mm256_testc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // Compute the bitwise AND of 256 bits (representing integer data) in a and b, and set ZF to 1 if the result is zero, otherwise set ZF to 0. Compute the bitwise NOT of a and then AND with b, and set CF to 1 if the result is zero, otherwise set CF to 0. Return the CF value.
            // IF ((a[255:0] AND b[255:0]) == 0)
            // 	ZF := 1
            // ELSE
            // 	ZF := 0
            // FI
            // IF (((NOT a[255:0]) AND b[255:0]) == 0)
            // 	CF := 1
            // ELSE
            // 	CF := 0
            // FI
            // RETURN CF
            // TestC(Vector256<Double>, Vector256<Double>)	int _mm256_testc_pd (__m256d a, __m256d b)
            // VTESTPS ymm, ymm/m256
            // Compute the bitwise AND of 256 bits (representing double-precision (64-bit) floating-point elements) in a and b, producing an intermediate 256-bit value, and set ZF to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set ZF to 0. Compute the bitwise NOT of a and then AND with b, producing an intermediate value, and set CF to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set CF to 0. Return the CF value.
            // tmp[255:0] := a[255:0] AND b[255:0]
            // IF (tmp[63] == 0 && tmp[127] == 0 && tmp[191] == 0 && tmp[255] == 0)
            // 	ZF := 1
            // ELSE
            // 	ZF := 0
            // FI
            // tmp[255:0] := (NOT a[255:0]) AND b[255:0]
            // IF (tmp[63] == 0 && tmp[127] == 0 && tmp[191] == 0 && tmp[255] == 0)
            // 	CF := 1
            // ELSE
            // 	CF := 0
            // FI
            // dst := CF
            // TestC(Vector256<Int16>, Vector256<Int16>)	int _mm256_testc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestC(Vector256<Int32>, Vector256<Int32>)	int _mm256_testc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestC(Vector256<Int64>, Vector256<Int64>)	int _mm256_testc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestC(Vector256<SByte>, Vector256<SByte>)	int _mm256_testc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestC(Vector256<Single>, Vector256<Single>)	int _mm256_testc_ps (__m256 a, __m256 b)
            // VTESTPS ymm, ymm/m256
            // TestC(Vector256<UInt16>, Vector256<UInt16>)	int _mm256_testc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestC(Vector256<UInt32>, Vector256<UInt32>)	int _mm256_testc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestC(Vector256<UInt64>, Vector256<UInt64>)	int _mm256_testc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            WriteLineFormat(tw, indent, "TestC(srcT_256_double, src2_256_double):\t{0}", Avx.TestC(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "TestC(srcT_256_float, src2_256_float):\t{0}", Avx.TestC(srcT_256_float, src2_256_float));

            // TestNotZAndNotC(Vector128<Double>, Vector128<Double>)	int _mm_testnzc_pd (__m128d a, __m128d b)
            // VTESTPD xmm, xmm/m128
            // Compute the bitwise AND of 128 bits (representing double-precision (64-bit) floating-point elements) in a and b, producing an intermediate 128-bit value, and set ZF to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set ZF to 0. Compute the bitwise NOT of a and then AND with b, producing an intermediate value, and set CF to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set CF to 0. Return 1 if both the ZF and CF values are zero, otherwise return 0.
            // tmp[127:0] := a[127:0] AND b[127:0]
            // IF (tmp[63] == 0 && tmp[127] == 0)
            // 	ZF := 1
            // ELSE
            // 	ZF := 0
            // FI
            // tmp[127:0] := (NOT a[127:0]) AND b[127:0]
            // IF (tmp[63] == 0 && tmp[127] == 0)
            // 	CF := 1
            // ELSE
            // 	CF := 0
            // FI
            // IF (ZF == 0 && CF == 0)
            // 	dst := 1
            // ELSE
            // 	dst := 0
            // FI
            // TestNotZAndNotC(Vector128<Single>, Vector128<Single>)	int _mm_testnzc_ps (__m128 a, __m128 b)
            // VTESTPS xmm, xmm/m128
            // TestNotZAndNotC(Vector256<Byte>, Vector256<Byte>)	int _mm256_testnzc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestNotZAndNotC(Vector256<Double>, Vector256<Double>)	int _mm256_testnzc_pd (__m256d a, __m256d b)
            // VTESTPD ymm, ymm/m256
            // TestNotZAndNotC(Vector256<Int16>, Vector256<Int16>)	int _mm256_testnzc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestNotZAndNotC(Vector256<Int32>, Vector256<Int32>)	int _mm256_testnzc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestNotZAndNotC(Vector256<Int64>, Vector256<Int64>)	int _mm256_testnzc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestNotZAndNotC(Vector256<SByte>, Vector256<SByte>)	int _mm256_testnzc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestNotZAndNotC(Vector256<Single>, Vector256<Single>)	int _mm256_testnzc_ps (__m256 a, __m256 b)
            // VTESTPS ymm, ymm/m256
            // TestNotZAndNotC(Vector256<UInt16>, Vector256<UInt16>)	int _mm256_testnzc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestNotZAndNotC(Vector256<UInt32>, Vector256<UInt32>)	int _mm256_testnzc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestNotZAndNotC(Vector256<UInt64>, Vector256<UInt64>)	int _mm256_testnzc_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            WriteLineFormat(tw, indent, "TestNotZAndNotC(srcT_256_double, src2_256_double):\t{0}", Avx.TestNotZAndNotC(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "TestNotZAndNotC(srcT_256_float, src2_256_float):\t{0}", Avx.TestNotZAndNotC(srcT_256_float, src2_256_float));

            // TestZ(Vector128<Double>, Vector128<Double>)	int _mm_testz_pd (__m128d a, __m128d b)
            // VTESTPD xmm, xmm/m128
            // Compute the bitwise AND of 128 bits (representing double-precision (64-bit) floating-point elements) in a and b, producing an intermediate 128-bit value, and set ZF to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set ZF to 0. Compute the bitwise NOT of a and then AND with b, producing an intermediate value, and set CF to 1 if the sign bit of each 64-bit element in the intermediate value is zero, otherwise set CF to 0. Return the ZF value.
            // Operation
            // tmp[127:0] := a[127:0] AND b[127:0]
            // IF (tmp[63] == 0 && tmp[127] == 0)
            // 	ZF := 1
            // ELSE
            // 	ZF := 0
            // FI
            // tmp[127:0] := (NOT a[127:0]) AND b[127:0]
            // IF (tmp[63] == 0 && tmp[127] == 0)
            // 	CF := 1
            // ELSE
            // 	CF := 0
            // FI
            // dst := ZF
            // TestZ(Vector128<Single>, Vector128<Single>)	int _mm_testz_ps (__m128 a, __m128 b)
            // VTESTPS xmm, xmm/m128
            // TestZ(Vector256<Byte>, Vector256<Byte>)	int _mm256_testz_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestZ(Vector256<Double>, Vector256<Double>)	int _mm256_testz_pd (__m256d a, __m256d b)
            // VTESTPD ymm, ymm/m256
            // TestZ(Vector256<Int16>, Vector256<Int16>)	int _mm256_testz_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestZ(Vector256<Int32>, Vector256<Int32>)	int _mm256_testz_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestZ(Vector256<Int64>, Vector256<Int64>)	int _mm256_testz_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestZ(Vector256<SByte>, Vector256<SByte>)	int _mm256_testz_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestZ(Vector256<Single>, Vector256<Single>)	int _mm256_testz_ps (__m256 a, __m256 b)
            // VTESTPS ymm, ymm/m256
            // TestZ(Vector256<UInt16>, Vector256<UInt16>)	int _mm256_testz_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestZ(Vector256<UInt32>, Vector256<UInt32>)	int _mm256_testz_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            // TestZ(Vector256<UInt64>, Vector256<UInt64>)	int _mm256_testz_si256 (__m256i a, __m256i b)
            // VPTEST ymm, ymm/m256
            WriteLineFormat(tw, indent, "TestZ(srcT_256_double, src2_256_double):\t{0}", Avx.TestZ(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "TestZ(srcT_256_float, src2_256_float):\t{0}", Avx.TestZ(srcT_256_float, src2_256_float));

            // UnpackHigh(Vector256<Double>, Vector256<Double>)	__m256d _mm256_unpackhi_pd (__m256d a, __m256d b)
            // VUNPCKHPD ymm, ymm, ymm/m256
            // Unpack and interleave double-precision (64-bit) floating-point elements from the high half of each 128-bit lane in a and b, and store the results in dst.
            // DEFINE INTERLEAVE_HIGH_QWORDS(src1[127:0], src2[127:0]) {
            // 	dst[63:0] := src1[127:64] 
            // 	dst[127:64] := src2[127:64] 
            // 	RETURN dst[127:0]	
            // }
            // dst[127:0] := INTERLEAVE_HIGH_QWORDS(a[127:0], b[127:0])
            // dst[255:128] := INTERLEAVE_HIGH_QWORDS(a[255:128], b[255:128])
            // UnpackHigh(Vector256<Single>, Vector256<Single>)	__m256 _mm256_unpackhi_ps (__m256 a, __m256 b)
            // VUNPCKHPS ymm, ymm, ymm/m256
            // Unpack and interleave single-precision (32-bit) floating-point elements from the high half of each 128-bit lane in a and b, and store the results in dst.
            // DEFINE INTERLEAVE_HIGH_DWORDS(src1[127:0], src2[127:0]) {
            // 	dst[31:0] := src1[95:64] 
            // 	dst[63:32] := src2[95:64] 
            // 	dst[95:64] := src1[127:96] 
            // 	dst[127:96] := src2[127:96] 
            // 	RETURN dst[127:0]	
            // }
            // dst[127:0] := INTERLEAVE_HIGH_DWORDS(a[127:0], b[127:0])
            // dst[255:128] := INTERLEAVE_HIGH_DWORDS(a[255:128], b[255:128])
            // dst[MAX:256] := 0
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_double, src2_256_double):\t{0}", Avx.UnpackHigh(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_float, src2_256_float):\t{0}", Avx.UnpackHigh(srcT_256_float, src2_256_float));

            // UnpackLow(Vector256<Double>, Vector256<Double>)	__m256d _mm256_unpacklo_pd (__m256d a, __m256d b)
            // VUNPCKLPD ymm, ymm, ymm/m256
            // UnpackLow(Vector256<Single>, Vector256<Single>)	__m256 _mm256_unpacklo_ps (__m256 a, __m256 b)
            // VUNPCKLPS ymm, ymm, ymm/m256
            // Unpack and interleave double-precision (64-bit) floating-point elements from the low half of each 128-bit lane in a and b, and store the results in dst.
            // DEFINE INTERLEAVE_QWORDS(src1[127:0], src2[127:0]) {
            // 	dst[63:0] := src1[63:0] 
            // 	dst[127:64] := src2[63:0] 
            // 	RETURN dst[127:0]
            // }
            // dst[127:0] := INTERLEAVE_QWORDS(a[127:0], b[127:0])
            // dst[255:128] := INTERLEAVE_QWORDS(a[255:128], b[255:128])
            // dst[MAX:256] := 0
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_double, src2_256_double):\t{0}", Avx.UnpackLow(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_float, src2_256_float):\t{0}", Avx.UnpackLow(srcT_256_float, src2_256_float));

            // Xor(Vector256<Double>, Vector256<Double>)	__m256d _mm256_xor_pd (__m256d a, __m256d b)
            // VXORPS ymm, ymm, ymm/m256
            // Xor(Vector256<Single>, Vector256<Single>)	__m256 _mm256_xor_ps (__m256 a, __m256 b)
            // VXORPS ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Xor(srcT_256_double, src2_256_double):\t{0}", Avx.Xor(srcT_256_double, src2_256_double));
            WriteLineFormat(tw, indent, "Xor(srcT_256_float, src2_256_float):\t{0}", Avx.Xor(srcT_256_float, src2_256_float));
        }

        /// <summary>
        /// Run x86 Avx2. https://docs.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx2?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx2(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + "\t";
            if (Avx.IsSupported) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("Avx2.IsSupported:\t{0}", Avx2.IsSupported));
            if (!Avx2.IsSupported) {
                return;
            }

            // Abs(Vector256<Int16>)	__m256i _mm256_abs_epi16 (__m256i a)
            // VPABSW ymm, ymm/m256
            // Abs(Vector256<Int32>)	__m256i _mm256_abs_epi32 (__m256i a)
            // VPABSD ymm, ymm/m256
            // Abs(Vector256<SByte>)	__m256i _mm256_abs_epi8 (__m256i a)
            // VPABSB ymm, ymm/m256
            // Add(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_add_epi8 (__m256i a, __m256i b)
            // VPADDB ymm, ymm, ymm/m256
            // Add(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_add_epi16 (__m256i a, __m256i b)
            // VPADDW ymm, ymm, ymm/m256
            // Add(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_add_epi32 (__m256i a, __m256i b)
            // VPADDD ymm, ymm, ymm/m256
            // Add(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_add_epi64 (__m256i a, __m256i b)
            // VPADDQ ymm, ymm, ymm/m256
            // Add(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_add_epi8 (__m256i a, __m256i b)
            // VPADDB ymm, ymm, ymm/m256
            // Add(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_add_epi16 (__m256i a, __m256i b)
            // VPADDW ymm, ymm, ymm/m256
            // Add(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_add_epi32 (__m256i a, __m256i b)
            // VPADDD ymm, ymm, ymm/m256
            // Add(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_add_epi64 (__m256i a, __m256i b)
            // VPADDQ ymm, ymm, ymm/m256
            // AddSaturate(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_adds_epu8 (__m256i a, __m256i b)
            // VPADDUSB ymm, ymm, ymm/m256
            // AddSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_adds_epi16 (__m256i a, __m256i b)
            // VPADDSW ymm, ymm, ymm/m256
            // AddSaturate(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_adds_epi8 (__m256i a, __m256i b)
            // VPADDSB ymm, ymm, ymm/m256
            // AddSaturate(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_adds_epu16 (__m256i a, __m256i b)
            // VPADDUSW ymm, ymm, ymm/m256
            // AlignRight(Vector256<Byte>, Vector256<Byte>, Byte)	__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
            // VPALIGNR ymm, ymm, ymm/m256, imm8
            // AlignRight(Vector256<Int16>, Vector256<Int16>, Byte)	__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
            // VPALIGNR ymm, ymm, ymm/m256, imm8
            // AlignRight(Vector256<Int32>, Vector256<Int32>, Byte)	__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
            // VPALIGNR ymm, ymm, ymm/m256, imm8
            // AlignRight(Vector256<Int64>, Vector256<Int64>, Byte)	__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
            // VPALIGNR ymm, ymm, ymm/m256, imm8
            // AlignRight(Vector256<SByte>, Vector256<SByte>, Byte)	__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
            // VPALIGNR ymm, ymm, ymm/m256, imm8
            // AlignRight(Vector256<UInt16>, Vector256<UInt16>, Byte)	__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
            // VPALIGNR ymm, ymm, ymm/m256, imm8
            // AlignRight(Vector256<UInt32>, Vector256<UInt32>, Byte)	__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
            // VPALIGNR ymm, ymm, ymm/m256, imm8
            // AlignRight(Vector256<UInt64>, Vector256<UInt64>, Byte)	__m256i _mm256_alignr_epi8 (__m256i a, __m256i b, const int count)
            // VPALIGNR ymm, ymm, ymm/m256, imm8
            // And(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_and_si256 (__m256i a, __m256i b)
            // VPAND ymm, ymm, ymm/m256
            // And(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_and_si256 (__m256i a, __m256i b)
            // VPAND ymm, ymm, ymm/m256
            // And(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_and_si256 (__m256i a, __m256i b)
            // VPAND ymm, ymm, ymm/m256
            // And(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_and_si256 (__m256i a, __m256i b)
            // VPAND ymm, ymm, ymm/m256
            // And(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_and_si256 (__m256i a, __m256i b)
            // VPAND ymm, ymm, ymm/m256
            // And(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_and_si256 (__m256i a, __m256i b)
            // VPAND ymm, ymm, ymm/m256
            // And(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_and_si256 (__m256i a, __m256i b)
            // VPAND ymm, ymm, ymm/m256
            // And(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_and_si256 (__m256i a, __m256i b)
            // VPAND ymm, ymm, ymm/m256
            // AndNot(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
            // VPANDN ymm, ymm, ymm/m256
            // AndNot(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
            // VPANDN ymm, ymm, ymm/m256
            // AndNot(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
            // VPANDN ymm, ymm, ymm/m256
            // AndNot(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
            // VPANDN ymm, ymm, ymm/m256
            // AndNot(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
            // VPANDN ymm, ymm, ymm/m256
            // AndNot(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
            // VPANDN ymm, ymm, ymm/m256
            // AndNot(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
            // VPANDN ymm, ymm, ymm/m256
            // AndNot(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_andnot_si256 (__m256i a, __m256i b)
            // VPANDN ymm, ymm, ymm/m256
            // Average(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_avg_epu8 (__m256i a, __m256i b)
            // VPAVGB ymm, ymm, ymm/m256
            // Average(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_avg_epu16 (__m256i a, __m256i b)
            // VPAVGW ymm, ymm, ymm/m256
            // Blend(Vector128<Int32>, Vector128<Int32>, Byte)	__m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8)
            // VPBLENDD xmm, xmm, xmm/m128, imm8
            // Blend(Vector128<UInt32>, Vector128<UInt32>, Byte)	__m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8)
            // VPBLENDD xmm, xmm, xmm/m128, imm8
            // Blend(Vector256<Int16>, Vector256<Int16>, Byte)	__m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8)
            // VPBLENDW ymm, ymm, ymm/m256, imm8
            // Blend(Vector256<Int32>, Vector256<Int32>, Byte)	__m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8)
            // VPBLENDD ymm, ymm, ymm/m256, imm8
            // Blend(Vector256<UInt16>, Vector256<UInt16>, Byte)	__m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8)
            // VPBLENDW ymm, ymm, ymm/m256, imm8
            // Blend(Vector256<UInt32>, Vector256<UInt32>, Byte)	__m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8)
            // VPBLENDD ymm, ymm, ymm/m256, imm8
            // BlendVariable(Vector256<Byte>, Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
            // VPBLENDVB ymm, ymm, ymm/m256, ymm
            // BlendVariable(Vector256<Int16>, Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
            // VPBLENDVB ymm, ymm, ymm/m256, ymm
            // BlendVariable(Vector256<Int32>, Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
            // VPBLENDVB ymm, ymm, ymm/m256, ymm
            // BlendVariable(Vector256<Int64>, Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
            // VPBLENDVB ymm, ymm, ymm/m256, ymm
            // BlendVariable(Vector256<SByte>, Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
            // VPBLENDVB ymm, ymm, ymm/m256, ymm
            // BlendVariable(Vector256<UInt16>, Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
            // VPBLENDVB ymm, ymm, ymm/m256, ymm
            // BlendVariable(Vector256<UInt32>, Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
            // VPBLENDVB ymm, ymm, ymm/m256, ymm
            // BlendVariable(Vector256<UInt64>, Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_blendv_epi8 (__m256i a, __m256i b, __m256i mask)
            // VPBLENDVB ymm, ymm, ymm/m256, ymm
            // BroadcastScalarToVector128(Byte*)	__m128i _mm_broadcastb_epi8 (__m128i a)
            // VPBROADCASTB xmm, m8
            // BroadcastScalarToVector128(Int16*)	__m128i _mm_broadcastw_epi16 (__m128i a)
            // VPBROADCASTW xmm, m16
            // BroadcastScalarToVector128(Int32*)	__m128i _mm_broadcastd_epi32 (__m128i a)
            // VPBROADCASTD xmm, m32
            // BroadcastScalarToVector128(Int64*)	__m128i _mm_broadcastq_epi64 (__m128i a)
            // VPBROADCASTQ xmm, m64
            // BroadcastScalarToVector128(SByte*)	__m128i _mm_broadcastb_epi8 (__m128i a)
            // VPBROADCASTB xmm, m8
            // BroadcastScalarToVector128(UInt16*)	__m128i _mm_broadcastw_epi16 (__m128i a)
            // VPBROADCASTW xmm, m16
            // BroadcastScalarToVector128(UInt32*)	__m128i _mm_broadcastd_epi32 (__m128i a)
            // VPBROADCASTD xmm, m32
            // BroadcastScalarToVector128(UInt64*)	__m128i _mm_broadcastq_epi64 (__m128i a)
            // VPBROADCASTQ xmm, m64
            // BroadcastScalarToVector128(Vector128<Byte>)	__m128i _mm_broadcastb_epi8 (__m128i a)
            // VPBROADCASTB xmm, xmm
            // BroadcastScalarToVector128(Vector128<Double>)	__m128d _mm_broadcastsd_pd (__m128d a)
            // VMOVDDUP xmm, xmm
            // BroadcastScalarToVector128(Vector128<Int16>)	__m128i _mm_broadcastw_epi16 (__m128i a)
            // VPBROADCASTW xmm, xmm
            // BroadcastScalarToVector128(Vector128<Int32>)	__m128i _mm_broadcastd_epi32 (__m128i a)
            // VPBROADCASTD xmm, xmm
            // BroadcastScalarToVector128(Vector128<Int64>)	__m128i _mm_broadcastq_epi64 (__m128i a)
            // VPBROADCASTQ xmm, xmm
            // BroadcastScalarToVector128(Vector128<SByte>)	__m128i _mm_broadcastb_epi8 (__m128i a)
            // VPBROADCASTB xmm, xmm
            // BroadcastScalarToVector128(Vector128<Single>)	__m128 _mm_broadcastss_ps (__m128 a)
            // VBROADCASTSS xmm, xmm
            // BroadcastScalarToVector128(Vector128<UInt16>)	__m128i _mm_broadcastw_epi16 (__m128i a)
            // VPBROADCASTW xmm, xmm
            // BroadcastScalarToVector128(Vector128<UInt32>)	__m128i _mm_broadcastd_epi32 (__m128i a)
            // VPBROADCASTD xmm, xmm
            // BroadcastScalarToVector128(Vector128<UInt64>)	__m128i _mm_broadcastq_epi64 (__m128i a)
            // VPBROADCASTQ xmm, xmm
            // BroadcastScalarToVector256(Byte*)	__m256i _mm256_broadcastb_epi8 (__m128i a)
            // VPBROADCASTB ymm, m8
            // BroadcastScalarToVector256(Int16*)	__m256i _mm256_broadcastw_epi16 (__m128i a)
            // VPBROADCASTW ymm, m16
            // BroadcastScalarToVector256(Int32*)	__m256i _mm256_broadcastd_epi32 (__m128i a)
            // VPBROADCASTD ymm, m32
            // BroadcastScalarToVector256(Int64*)	__m256i _mm256_broadcastq_epi64 (__m128i a)
            // VPBROADCASTQ ymm, m64
            // BroadcastScalarToVector256(SByte*)	__m256i _mm256_broadcastb_epi8 (__m128i a)
            // VPBROADCASTB ymm, m8
            // BroadcastScalarToVector256(UInt16*)	__m256i _mm256_broadcastw_epi16 (__m128i a)
            // VPBROADCASTW ymm, m16
            // BroadcastScalarToVector256(UInt32*)	__m256i _mm256_broadcastd_epi32 (__m128i a)
            // VPBROADCASTD ymm, m32
            // BroadcastScalarToVector256(UInt64*)	__m256i _mm256_broadcastq_epi64 (__m128i a)
            // VPBROADCASTQ ymm, m64
            // BroadcastScalarToVector256(Vector128<Byte>)	__m256i _mm256_broadcastb_epi8 (__m128i a)
            // VPBROADCASTB ymm, xmm
            // BroadcastScalarToVector256(Vector128<Double>)	__m256d _mm256_broadcastsd_pd (__m128d a)
            // VBROADCASTSD ymm, xmm
            // BroadcastScalarToVector256(Vector128<Int16>)	__m256i _mm256_broadcastw_epi16 (__m128i a)
            // VPBROADCASTW ymm, xmm
            // BroadcastScalarToVector256(Vector128<Int32>)	__m256i _mm256_broadcastd_epi32 (__m128i a)
            // VPBROADCASTD ymm, xmm
            // BroadcastScalarToVector256(Vector128<Int64>)	__m256i _mm256_broadcastq_epi64 (__m128i a)
            // VPBROADCASTQ ymm, xmm
            // BroadcastScalarToVector256(Vector128<SByte>)	__m256i _mm256_broadcastb_epi8 (__m128i a)
            // VPBROADCASTB ymm, xmm
            // BroadcastScalarToVector256(Vector128<Single>)	__m256 _mm256_broadcastss_ps (__m128 a)
            // VBROADCASTSS ymm, xmm
            // BroadcastScalarToVector256(Vector128<UInt16>)	__m256i _mm256_broadcastw_epi16 (__m128i a)
            // VPBROADCASTW ymm, xmm
            // BroadcastScalarToVector256(Vector128<UInt32>)	__m256i _mm256_broadcastd_epi32 (__m128i a)
            // VPBROADCASTD ymm, xmm
            // BroadcastScalarToVector256(Vector128<UInt64>)	__m256i _mm256_broadcastq_epi64 (__m128i a)
            // VPBROADCASTQ ymm, xmm
            // BroadcastVector128ToVector256(Byte*)	__m256i _mm256_broadcastsi128_si256 (__m128i a)
            // VBROADCASTI128 ymm, m128
            // BroadcastVector128ToVector256(Int16*)	__m256i _mm256_broadcastsi128_si256 (__m128i a)
            // VBROADCASTI128 ymm, m128
            // BroadcastVector128ToVector256(Int32*)	__m256i _mm256_broadcastsi128_si256 (__m128i a)
            // VBROADCASTI128 ymm, m128
            // BroadcastVector128ToVector256(Int64*)	__m256i _mm256_broadcastsi128_si256 (__m128i a)
            // VBROADCASTI128 ymm, m128
            // BroadcastVector128ToVector256(SByte*)	__m256i _mm256_broadcastsi128_si256 (__m128i a)
            // VBROADCASTI128 ymm, m128
            // BroadcastVector128ToVector256(UInt16*)	__m256i _mm256_broadcastsi128_si256 (__m128i a)
            // VBROADCASTI128 ymm, m128
            // BroadcastVector128ToVector256(UInt32*)	__m256i _mm256_broadcastsi128_si256 (__m128i a)
            // VBROADCASTI128 ymm, m128
            // BroadcastVector128ToVector256(UInt64*)	__m256i _mm256_broadcastsi128_si256 (__m128i a)
            // VBROADCASTI128 ymm, m128
            // CompareEqual(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_cmpeq_epi8 (__m256i a, __m256i b)
            // VPCMPEQB ymm, ymm, ymm/m256
            // CompareEqual(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b)
            // VPCMPEQW ymm, ymm, ymm/m256
            // CompareEqual(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_cmpeq_epi32 (__m256i a, __m256i b)
            // VPCMPEQD ymm, ymm, ymm/m256
            // CompareEqual(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b)
            // VPCMPEQQ ymm, ymm, ymm/m256
            // CompareEqual(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_cmpeq_epi8 (__m256i a, __m256i b)
            // VPCMPEQB ymm, ymm, ymm/m256
            // CompareEqual(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_cmpeq_epi16 (__m256i a, __m256i b)
            // VPCMPEQW ymm, ymm, ymm/m256
            // CompareEqual(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_cmpeq_epi32 (__m256i a, __m256i b)
            // VPCMPEQD ymm, ymm, ymm/m256
            // CompareEqual(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_cmpeq_epi64 (__m256i a, __m256i b)
            // VPCMPEQQ ymm, ymm, ymm/m256
            // CompareGreaterThan(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_cmpgt_epi16 (__m256i a, __m256i b)
            // VPCMPGTW ymm, ymm, ymm/m256
            // CompareGreaterThan(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b)
            // VPCMPGTD ymm, ymm, ymm/m256
            // CompareGreaterThan(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b)
            // VPCMPGTQ ymm, ymm, ymm/m256
            // CompareGreaterThan(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b)
            // VPCMPGTB ymm, ymm, ymm/m256
            // ConvertToInt32(Vector256<Int32>)	int _mm256_cvtsi256_si32 (__m256i a)
            // MOVD reg/m32, xmm
            // ConvertToUInt32(Vector256<UInt32>)	int _mm256_cvtsi256_si32 (__m256i a)
            // MOVD reg/m32, xmm
            // ConvertToVector256Int16(Byte*)	VPMOVZXBW ymm, m128
            // ConvertToVector256Int16(SByte*)	VPMOVSXBW ymm, m128
            // ConvertToVector256Int16(Vector128<Byte>)	__m256i _mm256_cvtepu8_epi16 (__m128i a)
            // VPMOVZXBW ymm, xmm
            // ConvertToVector256Int16(Vector128<SByte>)	__m256i _mm256_cvtepi8_epi16 (__m128i a)
            // VPMOVSXBW ymm, xmm/m128
            // ConvertToVector256Int32(Byte*)	VPMOVZXBD ymm, m64
            // ConvertToVector256Int32(Int16*)	VPMOVSXWD ymm, m128
            // ConvertToVector256Int32(SByte*)	VPMOVSXBD ymm, m64
            // ConvertToVector256Int32(UInt16*)	VPMOVZXWD ymm, m128
            // ConvertToVector256Int32(Vector128<Byte>)	__m256i _mm256_cvtepu8_epi32 (__m128i a)
            // VPMOVZXBD ymm, xmm
            // ConvertToVector256Int32(Vector128<Int16>)	__m256i _mm256_cvtepi16_epi32 (__m128i a)
            // VPMOVSXWD ymm, xmm/m128
            // ConvertToVector256Int32(Vector128<SByte>)	__m256i _mm256_cvtepi8_epi32 (__m128i a)
            // VPMOVSXBD ymm, xmm/m128
            // ConvertToVector256Int32(Vector128<UInt16>)	__m256i _mm256_cvtepu16_epi32 (__m128i a)
            // VPMOVZXWD ymm, xmm
            // ConvertToVector256Int64(Byte*)	VPMOVZXBQ ymm, m32
            // ConvertToVector256Int64(Int16*)	VPMOVSXWQ ymm, m64
            // ConvertToVector256Int64(Int32*)	VPMOVSXDQ ymm, m128
            // ConvertToVector256Int64(SByte*)	VPMOVSXBQ ymm, m32
            // ConvertToVector256Int64(UInt16*)	VPMOVZXWQ ymm, m64
            // ConvertToVector256Int64(UInt32*)	VPMOVZXDQ ymm, m128
            // ConvertToVector256Int64(Vector128<Byte>)	__m256i _mm256_cvtepu8_epi64 (__m128i a)
            // VPMOVZXBQ ymm, xmm
            // ConvertToVector256Int64(Vector128<Int16>)	__m256i _mm256_cvtepi16_epi64 (__m128i a)
            // VPMOVSXWQ ymm, xmm/m128
            // ConvertToVector256Int64(Vector128<Int32>)	__m256i _mm256_cvtepi32_epi64 (__m128i a)
            // VPMOVSXDQ ymm, xmm/m128
            // ConvertToVector256Int64(Vector128<SByte>)	__m256i _mm256_cvtepi8_epi64 (__m128i a)
            // VPMOVSXBQ ymm, xmm/m128
            // ConvertToVector256Int64(Vector128<UInt16>)	__m256i _mm256_cvtepu16_epi64 (__m128i a)
            // VPMOVZXWQ ymm, xmm
            // ConvertToVector256Int64(Vector128<UInt32>)	__m256i _mm256_cvtepu32_epi64 (__m128i a)
            // VPMOVZXDQ ymm, xmm
            // Equals(Object)	Determines whether the specified object is equal to the current object.
            // (Inherited from Object)
            // ExtractVector128(Vector256<Byte>, Byte)	__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
            // VEXTRACTI128 xmm, ymm, imm8
            // ExtractVector128(Vector256<Int16>, Byte)	__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
            // VEXTRACTI128 xmm, ymm, imm8
            // ExtractVector128(Vector256<Int32>, Byte)	__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
            // VEXTRACTI128 xmm, ymm, imm8
            // ExtractVector128(Vector256<Int64>, Byte)	__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
            // VEXTRACTI128 xmm, ymm, imm8
            // ExtractVector128(Vector256<SByte>, Byte)	__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
            // VEXTRACTI128 xmm, ymm, imm8
            // ExtractVector128(Vector256<UInt16>, Byte)	__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
            // VEXTRACTI128 xmm, ymm, imm8
            // ExtractVector128(Vector256<UInt32>, Byte)	__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
            // VEXTRACTI128 xmm, ymm, imm8
            // ExtractVector128(Vector256<UInt64>, Byte)	__m128i _mm256_extracti128_si256 (__m256i a, const int imm8)
            // VEXTRACTI128 xmm, ymm, imm8
            // GatherMaskVector128(Vector128<Double>, Double*, Vector128<Int32>, Vector128<Double>, Byte)	__m128d _mm_mask_i32gather_pd (__m128d src, double const* base_addr, __m128i vindex, __m128d mask, const int scale)
            // VGATHERDPD xmm, vm32x, xmm
            // GatherMaskVector128(Vector128<Double>, Double*, Vector128<Int64>, Vector128<Double>, Byte)	__m128d _mm_mask_i64gather_pd (__m128d src, double const* base_addr, __m128i vindex, __m128d mask, const int scale)
            // VGATHERQPD xmm, vm64x, xmm
            // GatherMaskVector128(Vector128<Int32>, Int32*, Vector128<Int32>, Vector128<Int32>, Byte)	__m128i _mm_mask_i32gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERDD xmm, vm32x, xmm
            // GatherMaskVector128(Vector128<Int32>, Int32*, Vector128<Int64>, Vector128<Int32>, Byte)	__m128i _mm_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERQD xmm, vm64x, xmm
            // GatherMaskVector128(Vector128<Int32>, Int32*, Vector256<Int64>, Vector128<Int32>, Byte)	__m128i _mm256_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m256i vindex, __m128i mask, const int scale)
            // VPGATHERQD xmm, vm32y, xmm
            // GatherMaskVector128(Vector128<Int64>, Int64*, Vector128<Int32>, Vector128<Int64>, Byte)	__m128i _mm_mask_i32gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERDQ xmm, vm32x, xmm
            // GatherMaskVector128(Vector128<Int64>, Int64*, Vector128<Int64>, Vector128<Int64>, Byte)	__m128i _mm_mask_i64gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERQQ xmm, vm64x, xmm
            // GatherMaskVector128(Vector128<Single>, Single*, Vector128<Int32>, Vector128<Single>, Byte)	__m128 _mm_mask_i32gather_ps (__m128 src, float const* base_addr, __m128i vindex, __m128 mask, const int scale)
            // VGATHERDPS xmm, vm32x, xmm
            // GatherMaskVector128(Vector128<Single>, Single*, Vector128<Int64>, Vector128<Single>, Byte)	__m128 _mm_mask_i64gather_ps (__m128 src, float const* base_addr, __m128i vindex, __m128 mask, const int scale)
            // VGATHERQPS xmm, vm64x, xmm
            // GatherMaskVector128(Vector128<Single>, Single*, Vector256<Int64>, Vector128<Single>, Byte)	__m128 _mm256_mask_i64gather_ps (__m128 src, float const* base_addr, __m256i vindex, __m128 mask, const int scale)
            // VGATHERQPS xmm, vm32y, xmm
            // GatherMaskVector128(Vector128<UInt32>, UInt32*, Vector128<Int32>, Vector128<UInt32>, Byte)	__m128i _mm_mask_i32gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERDD xmm, vm32x, xmm
            // GatherMaskVector128(Vector128<UInt32>, UInt32*, Vector128<Int64>, Vector128<UInt32>, Byte)	__m128i _mm_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERQD xmm, vm64x, xmm
            // GatherMaskVector128(Vector128<UInt32>, UInt32*, Vector256<Int64>, Vector128<UInt32>, Byte)	__m128i _mm256_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m256i vindex, __m128i mask, const int scale)
            // VPGATHERQD xmm, vm32y, xmm
            // GatherMaskVector128(Vector128<UInt64>, UInt64*, Vector128<Int32>, Vector128<UInt64>, Byte)	__m128i _mm_mask_i32gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERDQ xmm, vm32x, xmm
            // GatherMaskVector128(Vector128<UInt64>, UInt64*, Vector128<Int64>, Vector128<UInt64>, Byte)	__m128i _mm_mask_i64gather_epi64 (__m128i src, __int64 const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERQQ xmm, vm64x, xmm
            // GatherMaskVector256(Vector256<Double>, Double*, Vector128<Int32>, Vector256<Double>, Byte)	__m256d _mm256_mask_i32gather_pd (__m256d src, double const* base_addr, __m128i vindex, __m256d mask, const int scale)
            // VPGATHERDPD ymm, vm32y, ymm
            // GatherMaskVector256(Vector256<Double>, Double*, Vector256<Int64>, Vector256<Double>, Byte)	__m256d _mm256_mask_i64gather_pd (__m256d src, double const* base_addr, __m256i vindex, __m256d mask, const int scale)
            // VGATHERQPD ymm, vm32y, ymm
            // GatherMaskVector256(Vector256<Int32>, Int32*, Vector256<Int32>, Vector256<Int32>, Byte)	__m256i _mm256_mask_i32gather_epi32 (__m256i src, int const* base_addr, __m256i vindex, __m256i mask, const int scale)
            // VPGATHERDD ymm, vm32y, ymm
            // GatherMaskVector256(Vector256<Int64>, Int64*, Vector128<Int32>, Vector256<Int64>, Byte)	__m256i _mm256_mask_i32gather_epi64 (__m256i src, __int64 const* base_addr, __m128i vindex, __m256i mask, const int scale)
            // VPGATHERDQ ymm, vm32y, ymm
            // GatherMaskVector256(Vector256<Int64>, Int64*, Vector256<Int64>, Vector256<Int64>, Byte)	__m256i _mm256_mask_i64gather_epi64 (__m256i src, __int64 const* base_addr, __m256i vindex, __m256i mask, const int scale)
            // VPGATHERQQ ymm, vm32y, ymm
            // GatherMaskVector256(Vector256<Single>, Single*, Vector256<Int32>, Vector256<Single>, Byte)	__m256 _mm256_mask_i32gather_ps (__m256 src, float const* base_addr, __m256i vindex, __m256 mask, const int scale)
            // VPGATHERDPS ymm, vm32y, ymm
            // GatherMaskVector256(Vector256<UInt32>, UInt32*, Vector256<Int32>, Vector256<UInt32>, Byte)	__m256i _mm256_mask_i32gather_epi32 (__m256i src, int const* base_addr, __m256i vindex, __m256i mask, const int scale)
            // VPGATHERDD ymm, vm32y, ymm
            // GatherMaskVector256(Vector256<UInt64>, UInt64*, Vector128<Int32>, Vector256<UInt64>, Byte)	__m256i _mm256_mask_i32gather_epi64 (__m256i src, __int64 const* base_addr, __m128i vindex, __m256i mask, const int scale)
            // VPGATHERDQ ymm, vm32y, ymm
            // GatherMaskVector256(Vector256<UInt64>, UInt64*, Vector256<Int64>, Vector256<UInt64>, Byte)	__m256i _mm256_mask_i64gather_epi64 (__m256i src, __int64 const* base_addr, __m256i vindex, __m256i mask, const int scale)
            // VPGATHERQQ ymm, vm32y, ymm
            // GatherVector128(Double*, Vector128<Int32>, Byte)	__m128d _mm_i32gather_pd (double const* base_addr, __m128i vindex, const int scale)
            // VGATHERDPD xmm, vm32x, xmm
            // GatherVector128(Double*, Vector128<Int64>, Byte)	__m128d _mm_i64gather_pd (double const* base_addr, __m128i vindex, const int scale)
            // VGATHERQPD xmm, vm64x, xmm
            // GatherVector128(Int32*, Vector128<Int32>, Byte)	__m128i _mm_i32gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
            // VPGATHERDD xmm, vm32x, xmm
            // GatherVector128(Int32*, Vector128<Int64>, Byte)	__m128i _mm_i64gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
            // VPGATHERQD xmm, vm64x, xmm
            // GatherVector128(Int32*, Vector256<Int64>, Byte)	__m128i _mm256_i64gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
            // VPGATHERQD xmm, vm64y, xmm
            // GatherVector128(Int64*, Vector128<Int32>, Byte)	__m128i _mm_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
            // VPGATHERDQ xmm, vm32x, xmm
            // GatherVector128(Int64*, Vector128<Int64>, Byte)	__m128i _mm_i64gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
            // VPGATHERQQ xmm, vm64x, xmm
            // GatherVector128(Single*, Vector128<Int32>, Byte)	__m128 _mm_i32gather_ps (float const* base_addr, __m128i vindex, const int scale)
            // VGATHERDPS xmm, vm32x, xmm
            // GatherVector128(Single*, Vector128<Int64>, Byte)	__m128 _mm_i64gather_ps (float const* base_addr, __m128i vindex, const int scale)
            // VGATHERQPS xmm, vm64x, xmm
            // GatherVector128(Single*, Vector256<Int64>, Byte)	__m128 _mm256_i64gather_ps (float const* base_addr, __m256i vindex, const int scale)
            // VGATHERQPS xmm, vm64y, xmm
            // GatherVector128(UInt32*, Vector128<Int32>, Byte)	__m128i _mm_i32gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
            // VPGATHERDD xmm, vm32x, xmm
            // GatherVector128(UInt32*, Vector128<Int64>, Byte)	__m128i _mm_i64gather_epi32 (int const* base_addr, __m128i vindex, const int scale)
            // VPGATHERQD xmm, vm64x, xmm
            // GatherVector128(UInt32*, Vector256<Int64>, Byte)	__m128i _mm256_i64gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
            // VPGATHERQD xmm, vm64y, xmm
            // GatherVector128(UInt64*, Vector128<Int32>, Byte)	__m128i _mm_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
            // VPGATHERDQ xmm, vm32x, xmm
            // GatherVector128(UInt64*, Vector128<Int64>, Byte)	__m128i _mm_i64gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
            // VPGATHERQQ xmm, vm64x, xmm
            // GatherVector256(Double*, Vector128<Int32>, Byte)	__m256d _mm256_i32gather_pd (double const* base_addr, __m128i vindex, const int scale)
            // VGATHERDPD ymm, vm32y, ymm
            // GatherVector256(Double*, Vector256<Int64>, Byte)	__m256d _mm256_i64gather_pd (double const* base_addr, __m256i vindex, const int scale)
            // VGATHERQPD ymm, vm64y, ymm
            // GatherVector256(Int32*, Vector256<Int32>, Byte)	__m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
            // VPGATHERDD ymm, vm32y, ymm
            // GatherVector256(Int64*, Vector128<Int32>, Byte)	__m256i _mm256_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
            // VPGATHERDQ ymm, vm32y, ymm
            // GatherVector256(Int64*, Vector256<Int64>, Byte)	__m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale)
            // VPGATHERQQ ymm, vm64y, ymm
            // GatherVector256(Single*, Vector256<Int32>, Byte)	__m256 _mm256_i32gather_ps (float const* base_addr, __m256i vindex, const int scale)
            // VGATHERDPS ymm, vm32y, ymm
            // GatherVector256(UInt32*, Vector256<Int32>, Byte)	__m256i _mm256_i32gather_epi32 (int const* base_addr, __m256i vindex, const int scale)
            // VPGATHERDD ymm, vm32y, ymm
            // GatherVector256(UInt64*, Vector128<Int32>, Byte)	__m256i _mm256_i32gather_epi64 (__int64 const* base_addr, __m128i vindex, const int scale)
            // VPGATHERDQ ymm, vm32y, ymm
            // GatherVector256(UInt64*, Vector256<Int64>, Byte)	__m256i _mm256_i64gather_epi64 (__int64 const* base_addr, __m256i vindex, const int scale)
            // VPGATHERQQ ymm, vm64y, ymm
            // GetHashCode()	Serves as the default hash function.
            // (Inherited from Object)
            // GetType()	Gets the Type of the current instance.
            // (Inherited from Object)
            // HorizontalAdd(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_hadd_epi16 (__m256i a, __m256i b)
            // VPHADDW ymm, ymm, ymm/m256
            // HorizontalAdd(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_hadd_epi32 (__m256i a, __m256i b)
            // VPHADDD ymm, ymm, ymm/m256
            // HorizontalAddSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_hadds_epi16 (__m256i a, __m256i b)
            // VPHADDSW ymm, ymm, ymm/m256
            // HorizontalSubtract(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_hsub_epi16 (__m256i a, __m256i b)
            // VPHSUBW ymm, ymm, ymm/m256
            // HorizontalSubtract(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_hsub_epi32 (__m256i a, __m256i b)
            // VPHSUBD ymm, ymm, ymm/m256
            // HorizontalSubtractSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_hsubs_epi16 (__m256i a, __m256i b)
            // VPHSUBSW ymm, ymm, ymm/m256
            // InsertVector128(Vector256<Byte>, Vector128<Byte>, Byte)	__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
            // VINSERTI128 ymm, ymm, xmm, imm8
            // InsertVector128(Vector256<Int16>, Vector128<Int16>, Byte)	__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
            // VINSERTI128 ymm, ymm, xmm, imm8
            // InsertVector128(Vector256<Int32>, Vector128<Int32>, Byte)	__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
            // VINSERTI128 ymm, ymm, xmm, imm8
            // InsertVector128(Vector256<Int64>, Vector128<Int64>, Byte)	__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
            // VINSERTI128 ymm, ymm, xmm, imm8
            // InsertVector128(Vector256<SByte>, Vector128<SByte>, Byte)	__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
            // VINSERTI128 ymm, ymm, xmm, imm8
            // InsertVector128(Vector256<UInt16>, Vector128<UInt16>, Byte)	__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
            // VINSERTI128 ymm, ymm, xmm, imm8
            // InsertVector128(Vector256<UInt32>, Vector128<UInt32>, Byte)	__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
            // VINSERTI128 ymm, ymm, xmm, imm8
            // InsertVector128(Vector256<UInt64>, Vector128<UInt64>, Byte)	__m256i _mm256_inserti128_si256 (__m256i a, __m128i b, const int imm8)
            // VINSERTI128 ymm, ymm, xmm, imm8
            // LoadAlignedVector256NonTemporal(Byte*)	__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
            // VMOVNTDQA ymm, m256
            // LoadAlignedVector256NonTemporal(Int16*)	__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
            // VMOVNTDQA ymm, m256
            // LoadAlignedVector256NonTemporal(Int32*)	__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
            // VMOVNTDQA ymm, m256
            // LoadAlignedVector256NonTemporal(Int64*)	__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
            // VMOVNTDQA ymm, m256
            // LoadAlignedVector256NonTemporal(SByte*)	__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
            // VMOVNTDQA ymm, m256
            // LoadAlignedVector256NonTemporal(UInt16*)	__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
            // VMOVNTDQA ymm, m256
            // LoadAlignedVector256NonTemporal(UInt32*)	__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
            // VMOVNTDQA ymm, m256
            // LoadAlignedVector256NonTemporal(UInt64*)	__m256i _mm256_stream_load_si256 (__m256i const* mem_addr)
            // VMOVNTDQA ymm, m256
            // MaskLoad(Int32*, Vector128<Int32>)	__m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask)
            // VPMASKMOVD xmm, xmm, m128
            // MaskLoad(Int32*, Vector256<Int32>)	__m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask)
            // VPMASKMOVD ymm, ymm, m256
            // MaskLoad(Int64*, Vector128<Int64>)	__m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask)
            // VPMASKMOVQ xmm, xmm, m128
            // MaskLoad(Int64*, Vector256<Int64>)	__m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask)
            // VPMASKMOVQ ymm, ymm, m256
            // MaskLoad(UInt32*, Vector128<UInt32>)	__m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask)
            // VPMASKMOVD xmm, xmm, m128
            // MaskLoad(UInt32*, Vector256<UInt32>)	__m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask)
            // VPMASKMOVD ymm, ymm, m256
            // MaskLoad(UInt64*, Vector128<UInt64>)	__m128i _mm_maskload_epi64 (__int64 const* mem_addr, __m128i mask)
            // VPMASKMOVQ xmm, xmm, m128
            // MaskLoad(UInt64*, Vector256<UInt64>)	__m256i _mm256_maskload_epi64 (__int64 const* mem_addr, __m256i mask)
            // VPMASKMOVQ ymm, ymm, m256
            // MaskStore(Int32*, Vector128<Int32>, Vector128<Int32>)	void _mm_maskstore_epi32 (int* mem_addr, __m128i mask, __m128i a)
            // VPMASKMOVD m128, xmm, xmm
            // MaskStore(Int32*, Vector256<Int32>, Vector256<Int32>)	void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a)
            // VPMASKMOVD m256, ymm, ymm
            // MaskStore(Int64*, Vector128<Int64>, Vector128<Int64>)	void _mm_maskstore_epi64 (__int64* mem_addr, __m128i mask, __m128i a)
            // VPMASKMOVQ m128, xmm, xmm
            // MaskStore(Int64*, Vector256<Int64>, Vector256<Int64>)	void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a)
            // VPMASKMOVQ m256, ymm, ymm
            // MaskStore(UInt32*, Vector128<UInt32>, Vector128<UInt32>)	void _mm_maskstore_epi32 (int* mem_addr, __m128i mask, __m128i a)
            // VPMASKMOVD m128, xmm, xmm
            // MaskStore(UInt32*, Vector256<UInt32>, Vector256<UInt32>)	void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a)
            // VPMASKMOVD m256, ymm, ymm
            // MaskStore(UInt64*, Vector128<UInt64>, Vector128<UInt64>)	void _mm_maskstore_epi64 (__int64* mem_addr, __m128i mask, __m128i a)
            // VPMASKMOVQ m128, xmm, xmm
            // MaskStore(UInt64*, Vector256<UInt64>, Vector256<UInt64>)	void _mm256_maskstore_epi64 (__int64* mem_addr, __m256i mask, __m256i a)
            // VPMASKMOVQ m256, ymm, ymm
            // Max(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_max_epu8 (__m256i a, __m256i b)
            // VPMAXUB ymm, ymm, ymm/m256
            // Max(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_max_epi16 (__m256i a, __m256i b)
            // VPMAXSW ymm, ymm, ymm/m256
            // Max(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_max_epi32 (__m256i a, __m256i b)
            // VPMAXSD ymm, ymm, ymm/m256
            // Max(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_max_epi8 (__m256i a, __m256i b)
            // VPMAXSB ymm, ymm, ymm/m256
            // Max(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_max_epu16 (__m256i a, __m256i b)
            // VPMAXUW ymm, ymm, ymm/m256
            // Max(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_max_epu32 (__m256i a, __m256i b)
            // VPMAXUD ymm, ymm, ymm/m256
            // MemberwiseClone()	Creates a shallow copy of the current Object.
            // (Inherited from Object)
            // Min(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_min_epu8 (__m256i a, __m256i b)
            // VPMINUB ymm, ymm, ymm/m256
            // Min(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_min_epi16 (__m256i a, __m256i b)
            // VPMINSW ymm, ymm, ymm/m256
            // Min(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_min_epi32 (__m256i a, __m256i b)
            // VPMINSD ymm, ymm, ymm/m256
            // Min(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_min_epi8 (__m256i a, __m256i b)
            // VPMINSB ymm, ymm, ymm/m256
            // Min(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_min_epu16 (__m256i a, __m256i b)
            // VPMINUW ymm, ymm, ymm/m256
            // Min(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_min_epu32 (__m256i a, __m256i b)
            // VPMINUD ymm, ymm, ymm/m256
            // MoveMask(Vector256<Byte>)	int _mm256_movemask_epi8 (__m256i a)
            // VPMOVMSKB reg, ymm
            // MoveMask(Vector256<SByte>)	int _mm256_movemask_epi8 (__m256i a)
            // VPMOVMSKB reg, ymm
            // MultipleSumAbsoluteDifferences(Vector256<Byte>, Vector256<Byte>, Byte)	__m256i _mm256_mpsadbw_epu8 (__m256i a, __m256i b, const int imm8)
            // VMPSADBW ymm, ymm, ymm/m256, imm8
            // Multiply(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_mul_epi32 (__m256i a, __m256i b)
            // VPMULDQ ymm, ymm, ymm/m256
            // Multiply(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_mul_epu32 (__m256i a, __m256i b)
            // VPMULUDQ ymm, ymm, ymm/m256
            // MultiplyAddAdjacent(Vector256<Byte>, Vector256<SByte>)	__m256i _mm256_maddubs_epi16 (__m256i a, __m256i b)
            // VPMADDUBSW ymm, ymm, ymm/m256
            // MultiplyAddAdjacent(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_madd_epi16 (__m256i a, __m256i b)
            // VPMADDWD ymm, ymm, ymm/m256
            // MultiplyHigh(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_mulhi_epi16 (__m256i a, __m256i b)
            // VPMULHW ymm, ymm, ymm/m256
            // MultiplyHigh(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_mulhi_epu16 (__m256i a, __m256i b)
            // VPMULHUW ymm, ymm, ymm/m256
            // MultiplyHighRoundScale(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_mulhrs_epi16 (__m256i a, __m256i b)
            // VPMULHRSW ymm, ymm, ymm/m256
            // MultiplyLow(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_mullo_epi16 (__m256i a, __m256i b)
            // VPMULLW ymm, ymm, ymm/m256
            // MultiplyLow(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_mullo_epi32 (__m256i a, __m256i b)
            // VPMULLD ymm, ymm, ymm/m256
            // MultiplyLow(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_mullo_epi16 (__m256i a, __m256i b)
            // VPMULLW ymm, ymm, ymm/m256
            // MultiplyLow(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_mullo_epi32 (__m256i a, __m256i b)
            // VPMULLD ymm, ymm, ymm/m256
            // Or(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_or_si256 (__m256i a, __m256i b)
            // VPOR ymm, ymm, ymm/m256
            // Or(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_or_si256 (__m256i a, __m256i b)
            // VPOR ymm, ymm, ymm/m256
            // Or(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_or_si256 (__m256i a, __m256i b)
            // VPOR ymm, ymm, ymm/m256
            // Or(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_or_si256 (__m256i a, __m256i b)
            // VPOR ymm, ymm, ymm/m256
            // Or(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_or_si256 (__m256i a, __m256i b)
            // VPOR ymm, ymm, ymm/m256
            // Or(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_or_si256 (__m256i a, __m256i b)
            // VPOR ymm, ymm, ymm/m256
            // Or(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_or_si256 (__m256i a, __m256i b)
            // VPOR ymm, ymm, ymm/m256
            // Or(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_or_si256 (__m256i a, __m256i b)
            // VPOR ymm, ymm, ymm/m256
            // PackSignedSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_packs_epi16 (__m256i a, __m256i b)
            // VPACKSSWB ymm, ymm, ymm/m256
            // PackSignedSaturate(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_packs_epi32 (__m256i a, __m256i b)
            // VPACKSSDW ymm, ymm, ymm/m256
            // PackUnsignedSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_packus_epi16 (__m256i a, __m256i b)
            // VPACKUSWB ymm, ymm, ymm/m256
            // PackUnsignedSaturate(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_packus_epi32 (__m256i a, __m256i b)
            // VPACKUSDW ymm, ymm, ymm/m256
            // Permute2x128(Vector256<Byte>, Vector256<Byte>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<Int16>, Vector256<Int16>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<Int32>, Vector256<Int32>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<Int64>, Vector256<Int64>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<SByte>, Vector256<SByte>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<UInt16>, Vector256<UInt16>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<UInt32>, Vector256<UInt32>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Permute2x128(Vector256<UInt64>, Vector256<UInt64>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Permute4x64(Vector256<Double>, Byte)	__m256d _mm256_permute4x64_pd (__m256d a, const int imm8)
            // VPERMPD ymm, ymm/m256, imm8
            // Permute4x64(Vector256<Int64>, Byte)	__m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
            // VPERMQ ymm, ymm/m256, imm8
            // Permute4x64(Vector256<UInt64>, Byte)	__m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
            // VPERMQ ymm, ymm/m256, imm8
            // PermuteVar8x32(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
            // VPERMD ymm, ymm/m256, ymm
            // PermuteVar8x32(Vector256<Single>, Vector256<Int32>)	__m256 _mm256_permutevar8x32_ps (__m256 a, __m256i idx)
            // VPERMPS ymm, ymm/m256, ymm
            // PermuteVar8x32(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
            // VPERMD ymm, ymm/m256, ymm
            // ShiftLeftLogical(Vector256<Int16>, Byte)	__m256i _mm256_slli_epi16 (__m256i a, int imm8)
            // VPSLLW ymm, ymm, imm8
            // ShiftLeftLogical(Vector256<Int16>, Vector128<Int16>)	__m256i _mm256_sll_epi16 (__m256i a, __m128i count)
            // VPSLLW ymm, ymm, xmm/m128
            // ShiftLeftLogical(Vector256<Int32>, Byte)	__m256i _mm256_slli_epi32 (__m256i a, int imm8)
            // VPSLLD ymm, ymm, imm8
            // ShiftLeftLogical(Vector256<Int32>, Vector128<Int32>)	__m256i _mm256_sll_epi32 (__m256i a, __m128i count)
            // VPSLLD ymm, ymm, xmm/m128
            // ShiftLeftLogical(Vector256<Int64>, Byte)	__m256i _mm256_slli_epi64 (__m256i a, int imm8)
            // VPSLLQ ymm, ymm, imm8
            // ShiftLeftLogical(Vector256<Int64>, Vector128<Int64>)	__m256i _mm256_sll_epi64 (__m256i a, __m128i count)
            // VPSLLQ ymm, ymm, xmm/m128
            // ShiftLeftLogical(Vector256<UInt16>, Byte)	__m256i _mm256_slli_epi16 (__m256i a, int imm8)
            // VPSLLW ymm, ymm, imm8
            // ShiftLeftLogical(Vector256<UInt16>, Vector128<UInt16>)	__m256i _mm256_sll_epi16 (__m256i a, __m128i count)
            // VPSLLW ymm, ymm, xmm/m128
            // ShiftLeftLogical(Vector256<UInt32>, Byte)	__m256i _mm256_slli_epi32 (__m256i a, int imm8)
            // VPSLLD ymm, ymm, imm8
            // ShiftLeftLogical(Vector256<UInt32>, Vector128<UInt32>)	__m256i _mm256_sll_epi32 (__m256i a, __m128i count)
            // VPSLLD ymm, ymm, xmm/m128
            // ShiftLeftLogical(Vector256<UInt64>, Byte)	__m256i _mm256_slli_epi64 (__m256i a, int imm8)
            // VPSLLQ ymm, ymm, imm8
            // ShiftLeftLogical(Vector256<UInt64>, Vector128<UInt64>)	__m256i _mm256_sll_epi64 (__m256i a, __m128i count)
            // VPSLLQ ymm, ymm, xmm/m128
            // ShiftLeftLogical128BitLane(Vector256<Byte>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // ShiftLeftLogical128BitLane(Vector256<Int16>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // ShiftLeftLogical128BitLane(Vector256<Int32>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // ShiftLeftLogical128BitLane(Vector256<Int64>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // ShiftLeftLogical128BitLane(Vector256<SByte>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // ShiftLeftLogical128BitLane(Vector256<UInt16>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // ShiftLeftLogical128BitLane(Vector256<UInt32>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // ShiftLeftLogical128BitLane(Vector256<UInt64>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // ShiftLeftLogicalVariable(Vector128<Int32>, Vector128<UInt32>)	__m128i _mm_sllv_epi32 (__m128i a, __m128i count)
            // VPSLLVD xmm, xmm, xmm/m128
            // ShiftLeftLogicalVariable(Vector128<Int64>, Vector128<UInt64>)	__m128i _mm_sllv_epi64 (__m128i a, __m128i count)
            // VPSLLVQ xmm, xmm, xmm/m128
            // ShiftLeftLogicalVariable(Vector128<UInt32>, Vector128<UInt32>)	__m128i _mm_sllv_epi32 (__m128i a, __m128i count)
            // VPSLLVD xmm, xmm, xmm/m128
            // ShiftLeftLogicalVariable(Vector128<UInt64>, Vector128<UInt64>)	__m128i _mm_sllv_epi64 (__m128i a, __m128i count)
            // VPSLLVQ xmm, xmm, xmm/m128
            // ShiftLeftLogicalVariable(Vector256<Int32>, Vector256<UInt32>)	__m256i _mm256_sllv_epi32 (__m256i a, __m256i count)
            // VPSLLVD ymm, ymm, ymm/m256
            // ShiftLeftLogicalVariable(Vector256<Int64>, Vector256<UInt64>)	__m256i _mm256_sllv_epi64 (__m256i a, __m256i count)
            // VPSLLVQ ymm, ymm, ymm/m256
            // ShiftLeftLogicalVariable(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_sllv_epi32 (__m256i a, __m256i count)
            // VPSLLVD ymm, ymm, ymm/m256
            // ShiftLeftLogicalVariable(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_sllv_epi64 (__m256i a, __m256i count)
            // VPSLLVQ ymm, ymm, ymm/m256
            // ShiftRightArithmetic(Vector256<Int16>, Byte)	__m256i _mm256_srai_epi16 (__m256i a, int imm8)
            // VPSRAW ymm, ymm, imm8
            // ShiftRightArithmetic(Vector256<Int16>, Vector128<Int16>)	_mm256_sra_epi16 (__m256i a, __m128i count)
            // VPSRAW ymm, ymm, xmm/m128
            // ShiftRightArithmetic(Vector256<Int32>, Byte)	__m256i _mm256_srai_epi32 (__m256i a, int imm8)
            // VPSRAD ymm, ymm, imm8
            // ShiftRightArithmetic(Vector256<Int32>, Vector128<Int32>)	_mm256_sra_epi32 (__m256i a, __m128i count)
            // VPSRAD ymm, ymm, xmm/m128
            // ShiftRightArithmeticVariable(Vector128<Int32>, Vector128<UInt32>)	__m128i _mm_srav_epi32 (__m128i a, __m128i count)
            // VPSRAVD xmm, xmm, xmm/m128
            // ShiftRightArithmeticVariable(Vector256<Int32>, Vector256<UInt32>)	__m256i _mm256_srav_epi32 (__m256i a, __m256i count)
            // VPSRAVD ymm, ymm, ymm/m256
            // ShiftRightLogical(Vector256<Int16>, Byte)	__m256i _mm256_srli_epi16 (__m256i a, int imm8)
            // VPSRLW ymm, ymm, imm8
            // ShiftRightLogical(Vector256<Int16>, Vector128<Int16>)	__m256i _mm256_srl_epi16 (__m256i a, __m128i count)
            // VPSRLW ymm, ymm, xmm/m128
            // ShiftRightLogical(Vector256<Int32>, Byte)	__m256i _mm256_srli_epi32 (__m256i a, int imm8)
            // VPSRLD ymm, ymm, imm8
            // ShiftRightLogical(Vector256<Int32>, Vector128<Int32>)	__m256i _mm256_srl_epi32 (__m256i a, __m128i count)
            // VPSRLD ymm, ymm, xmm/m128
            // ShiftRightLogical(Vector256<Int64>, Byte)	__m256i _mm256_srli_epi64 (__m256i a, int imm8)
            // VPSRLQ ymm, ymm, imm8
            // ShiftRightLogical(Vector256<Int64>, Vector128<Int64>)	__m256i _mm256_srl_epi64 (__m256i a, __m128i count)
            // VPSRLQ ymm, ymm, xmm/m128
            // ShiftRightLogical(Vector256<UInt16>, Byte)	__m256i _mm256_srli_epi16 (__m256i a, int imm8)
            // VPSRLW ymm, ymm, imm8
            // ShiftRightLogical(Vector256<UInt16>, Vector128<UInt16>)	__m256i _mm256_srl_epi16 (__m256i a, __m128i count)
            // VPSRLW ymm, ymm, xmm/m128
            // ShiftRightLogical(Vector256<UInt32>, Byte)	__m256i _mm256_srli_epi32 (__m256i a, int imm8)
            // VPSRLD ymm, ymm, imm8
            // ShiftRightLogical(Vector256<UInt32>, Vector128<UInt32>)	__m256i _mm256_srl_epi32 (__m256i a, __m128i count)
            // VPSRLD ymm, ymm, xmm/m128
            // ShiftRightLogical(Vector256<UInt64>, Byte)	__m256i _mm256_srli_epi64 (__m256i a, int imm8)
            // VPSRLQ ymm, ymm, imm8
            // ShiftRightLogical(Vector256<UInt64>, Vector128<UInt64>)	__m256i _mm256_srl_epi64 (__m256i a, __m128i count)
            // VPSRLQ ymm, ymm, xmm/m128
            // ShiftRightLogical128BitLane(Vector256<Byte>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // ShiftRightLogical128BitLane(Vector256<Int16>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // ShiftRightLogical128BitLane(Vector256<Int32>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // ShiftRightLogical128BitLane(Vector256<Int64>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // ShiftRightLogical128BitLane(Vector256<SByte>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // ShiftRightLogical128BitLane(Vector256<UInt16>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // ShiftRightLogical128BitLane(Vector256<UInt32>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // ShiftRightLogical128BitLane(Vector256<UInt64>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // ShiftRightLogicalVariable(Vector128<Int32>, Vector128<UInt32>)	__m128i _mm_srlv_epi32 (__m128i a, __m128i count)
            // VPSRLVD xmm, xmm, xmm/m128
            // ShiftRightLogicalVariable(Vector128<Int64>, Vector128<UInt64>)	__m128i _mm_srlv_epi64 (__m128i a, __m128i count)
            // VPSRLVQ xmm, xmm, xmm/m128
            // ShiftRightLogicalVariable(Vector128<UInt32>, Vector128<UInt32>)	__m128i _mm_srlv_epi32 (__m128i a, __m128i count)
            // VPSRLVD xmm, xmm, xmm/m128
            // ShiftRightLogicalVariable(Vector128<UInt64>, Vector128<UInt64>)	__m128i _mm_srlv_epi64 (__m128i a, __m128i count)
            // VPSRLVQ xmm, xmm, xmm/m128
            // ShiftRightLogicalVariable(Vector256<Int32>, Vector256<UInt32>)	__m256i _mm256_srlv_epi32 (__m256i a, __m256i count)
            // VPSRLVD ymm, ymm, ymm/m256
            // ShiftRightLogicalVariable(Vector256<Int64>, Vector256<UInt64>)	__m256i _mm256_srlv_epi64 (__m256i a, __m256i count)
            // VPSRLVQ ymm, ymm, ymm/m256
            // ShiftRightLogicalVariable(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_srlv_epi32 (__m256i a, __m256i count)
            // VPSRLVD ymm, ymm, ymm/m256
            // ShiftRightLogicalVariable(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_srlv_epi64 (__m256i a, __m256i count)
            // VPSRLVQ ymm, ymm, ymm/m256
            // Shuffle(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
            // VPSHUFB ymm, ymm, ymm/m256
            // Shuffle(Vector256<Int32>, Byte)	__m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
            // VPSHUFD ymm, ymm/m256, imm8
            // Shuffle(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
            // VPSHUFB ymm, ymm, ymm/m256
            // Shuffle(Vector256<UInt32>, Byte)	__m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
            // VPSHUFD ymm, ymm/m256, imm8
            // ShuffleHigh(Vector256<Int16>, Byte)	__m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)
            // VPSHUFHW ymm, ymm/m256, imm8
            // ShuffleHigh(Vector256<UInt16>, Byte)	__m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)
            // VPSHUFHW ymm, ymm/m256, imm8
            // ShuffleLow(Vector256<Int16>, Byte)	__m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)
            // VPSHUFLW ymm, ymm/m256, imm8
            // ShuffleLow(Vector256<UInt16>, Byte)	__m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)
            // VPSHUFLW ymm, ymm/m256, imm8
            // Sign(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_sign_epi16 (__m256i a, __m256i b)
            // VPSIGNW ymm, ymm, ymm/m256
            // Sign(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_sign_epi32 (__m256i a, __m256i b)
            // VPSIGND ymm, ymm, ymm/m256
            // Sign(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_sign_epi8 (__m256i a, __m256i b)
            // VPSIGNB ymm, ymm, ymm/m256
            // Subtract(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_sub_epi8 (__m256i a, __m256i b)
            // VPSUBB ymm, ymm, ymm/m256
            // Subtract(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_sub_epi16 (__m256i a, __m256i b)
            // VPSUBW ymm, ymm, ymm/m256
            // Subtract(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_sub_epi32 (__m256i a, __m256i b)
            // VPSUBD ymm, ymm, ymm/m256
            // Subtract(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_sub_epi64 (__m256i a, __m256i b)
            // VPSUBQ ymm, ymm, ymm/m256
            // Subtract(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_sub_epi8 (__m256i a, __m256i b)
            // VPSUBB ymm, ymm, ymm/m256
            // Subtract(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_sub_epi16 (__m256i a, __m256i b)
            // VPSUBW ymm, ymm, ymm/m256
            // Subtract(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_sub_epi32 (__m256i a, __m256i b)
            // VPSUBD ymm, ymm, ymm/m256
            // Subtract(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_sub_epi64 (__m256i a, __m256i b)
            // VPSUBQ ymm, ymm, ymm/m256
            // SubtractSaturate(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_subs_epu8 (__m256i a, __m256i b)
            // VPSUBUSB ymm, ymm, ymm/m256
            // SubtractSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_subs_epi16 (__m256i a, __m256i b)
            // VPSUBSW ymm, ymm, ymm/m256
            // SubtractSaturate(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_subs_epi8 (__m256i a, __m256i b)
            // VPSUBSB ymm, ymm, ymm/m256
            // SubtractSaturate(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_subs_epu16 (__m256i a, __m256i b)
            // VPSUBUSW ymm, ymm, ymm/m256
            // SumAbsoluteDifferences(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_sad_epu8 (__m256i a, __m256i b)
            // VPSADBW ymm, ymm, ymm/m256
            // ToString()	Returns a string that represents the current object.
            // (Inherited from Object)
            // UnpackHigh(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b)
            // VPUNPCKHBW ymm, ymm, ymm/m256
            // UnpackHigh(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b)
            // VPUNPCKHWD ymm, ymm, ymm/m256
            // UnpackHigh(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b)
            // VPUNPCKHDQ ymm, ymm, ymm/m256
            // UnpackHigh(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b)
            // VPUNPCKHQDQ ymm, ymm, ymm/m256
            // UnpackHigh(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b)
            // VPUNPCKHBW ymm, ymm, ymm/m256
            // UnpackHigh(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_unpackhi_epi16 (__m256i a, __m256i b)
            // VPUNPCKHWD ymm, ymm, ymm/m256
            // UnpackHigh(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_unpackhi_epi32 (__m256i a, __m256i b)
            // VPUNPCKHDQ ymm, ymm, ymm/m256
            // UnpackHigh(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_unpackhi_epi64 (__m256i a, __m256i b)
            // VPUNPCKHQDQ ymm, ymm, ymm/m256
            // UnpackLow(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b)
            // VPUNPCKLBW ymm, ymm, ymm/m256
            // UnpackLow(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b)
            // VPUNPCKLWD ymm, ymm, ymm/m256
            // UnpackLow(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b)
            // VPUNPCKLDQ ymm, ymm, ymm/m256
            // UnpackLow(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b)
            // VPUNPCKLQDQ ymm, ymm, ymm/m256
            // UnpackLow(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b)
            // VPUNPCKLBW ymm, ymm, ymm/m256
            // UnpackLow(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_unpacklo_epi16 (__m256i a, __m256i b)
            // VPUNPCKLWD ymm, ymm, ymm/m256
            // UnpackLow(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_unpacklo_epi32 (__m256i a, __m256i b)
            // VPUNPCKLDQ ymm, ymm, ymm/m256
            // UnpackLow(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_unpacklo_epi64 (__m256i a, __m256i b)
            // VPUNPCKLQDQ ymm, ymm, ymm/m256
            // Xor(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_xor_si256 (__m256i a, __m256i b)
            // VPXOR ymm, ymm, ymm/m256
            // Xor(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_xor_si256 (__m256i a, __m256i b)
            // VPXOR ymm, ymm, ymm/m256
            // Xor(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_xor_si256 (__m256i a, __m256i b)
            // VPXOR ymm, ymm, ymm/m256
            // Xor(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_xor_si256 (__m256i a, __m256i b)
            // VPXOR ymm, ymm, ymm/m256
            // Xor(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_xor_si256 (__m256i a, __m256i b)
            // VPXOR ymm, ymm, ymm/m256
            // Xor(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_xor_si256 (__m256i a, __m256i b)
            // VPXOR ymm, ymm, ymm/m256
            // Xor(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_xor_si256 (__m256i a, __m256i b)
            // VPXOR ymm, ymm, ymm/m256
            // Xor(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_xor_si256 (__m256i a, __m256i b)
            // VPXOR ymm, ymm, ymm/m256

        }
    }
}

