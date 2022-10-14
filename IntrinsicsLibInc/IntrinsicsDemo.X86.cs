using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace IntrinsicsLib {
    partial class IntrinsicsDemo {

        /// <summary>
        /// Run x86. https://www.intel.com/content/www/us/en/docs/intrinsics-guide/index.html
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunX86(TextWriter tw, string indent) {
#if NET5_0_OR_GREATER
            bool isSupported = X86Base.IsSupported;
#else
            bool isSupported = Sse.IsSupported;
#endif
            if (!isSupported) return;
            RunX86Supported(tw, indent);
            RunX86Avx(tw, indent);
            RunX86Avx2(tw, indent);
        }

        /// <summary>
        /// Run x86 Supported. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunX86Supported(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            tw.WriteLine();
            tw.WriteLine(indent + "[Intrinsics.X86]");
            WriteLineFormat(tw, indent, "Aes.IsSupported:\t{0}", Aes.IsSupported);
            WriteLineFormat(tw, indent, "Aes.X64.IsSupported:\t{0}", Aes.X64.IsSupported);
            WriteLineFormat(tw, indent, "Avx.IsSupported:\t{0}", Avx.IsSupported);
            WriteLineFormat(tw, indent, "Avx.X64.IsSupported:\t{0}", Avx.X64.IsSupported);
            WriteLineFormat(tw, indent, "Avx2.IsSupported:\t{0}", Avx2.IsSupported);
            WriteLineFormat(tw, indent, "Avx2.X64.IsSupported:\t{0}", Avx2.X64.IsSupported);
#if NET6_0_OR_GREATER
            WriteLineFormat(tw, indent, "AvxVnni.IsSupported:\t{0}", AvxVnni.IsSupported);
            WriteLineFormat(tw, indent, "AvxVnni.X64.IsSupported:\t{0}", AvxVnni.X64.IsSupported);
#endif
            WriteLineFormat(tw, indent, "Bmi1.IsSupported:\t{0}", Bmi1.IsSupported);
            WriteLineFormat(tw, indent, "Bmi1.X64.IsSupported:\t{0}", Bmi1.X64.IsSupported);
            WriteLineFormat(tw, indent, "Bmi2.IsSupported:\t{0}", Bmi2.IsSupported);
            WriteLineFormat(tw, indent, "Bmi2.X64.IsSupported:\t{0}", Bmi2.X64.IsSupported);
            WriteLineFormat(tw, indent, "Fma.IsSupported:\t{0}", Fma.IsSupported);
            WriteLineFormat(tw, indent, "Fma.X64.IsSupported:\t{0}", Fma.X64.IsSupported);
            WriteLineFormat(tw, indent, "Lzcnt.IsSupported:\t{0}", Lzcnt.IsSupported);
            WriteLineFormat(tw, indent, "Lzcnt.X64.IsSupported:\t{0}", Lzcnt.X64.IsSupported);
            WriteLineFormat(tw, indent, "Pclmulqdq.IsSupported:\t{0}", Pclmulqdq.IsSupported);
            WriteLineFormat(tw, indent, "Pclmulqdq.X64.IsSupported:\t{0}", Pclmulqdq.X64.IsSupported);
            WriteLineFormat(tw, indent, "Popcnt.IsSupported:\t{0}", Popcnt.IsSupported);
            WriteLineFormat(tw, indent, "Popcnt.X64.IsSupported:\t{0}", Popcnt.X64.IsSupported);
            WriteLineFormat(tw, indent, "Sse.IsSupported:\t{0}", Sse.IsSupported);
            WriteLineFormat(tw, indent, "Sse.X64.IsSupported:\t{0}", Sse.X64.IsSupported);
            WriteLineFormat(tw, indent, "Sse2.IsSupported:\t{0}", Sse2.IsSupported);
            WriteLineFormat(tw, indent, "Sse2.X64.IsSupported:\t{0}", Sse2.X64.IsSupported);
            WriteLineFormat(tw, indent, "Sse3.IsSupported:\t{0}", Sse3.IsSupported);
            WriteLineFormat(tw, indent, "Sse3.X64.IsSupported:\t{0}", Sse3.X64.IsSupported);
            WriteLineFormat(tw, indent, "Sse41.IsSupported:\t{0}", Sse41.IsSupported);
            WriteLineFormat(tw, indent, "Sse41.X64.IsSupported:\t{0}", Sse41.X64.IsSupported);
            WriteLineFormat(tw, indent, "Sse42.IsSupported:\t{0}", Sse42.IsSupported);
            WriteLineFormat(tw, indent, "Sse42.X64.IsSupported:\t{0}", Sse42.X64.IsSupported);
            WriteLineFormat(tw, indent, "Ssse3.IsSupported:\t{0}", Ssse3.IsSupported);
            WriteLineFormat(tw, indent, "Ssse3.X64.IsSupported:\t{0}", Ssse3.X64.IsSupported);
#if NET5_0_OR_GREATER
            WriteLineFormat(tw, indent, "X86Base.IsSupported:\t{0}", X86Base.IsSupported);
            WriteLineFormat(tw, indent, "X86Base.X64.IsSupported:\t{0}", X86Base.X64.IsSupported);
#endif
#if NET7_0_OR_GREATER
            WriteLineFormat(tw, indent, "X86Serialize.IsSupported:\t{0}", X86Serialize.IsSupported);
            WriteLineFormat(tw, indent, "X86Serialize.X64.IsSupported:\t{0}", X86Serialize.X64.IsSupported);
#endif
        }

        /// <summary>
        /// Run x86 Avx. https://docs.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            if (Avx.IsSupported) {
                tw.WriteLine();
            }
            tw.WriteLine(indent + string.Format("Avx.IsSupported:\t{0}", Avx.IsSupported));
            if (!Avx.IsSupported) {
                return;
            }

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
                //Debugger.Break();
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
            float f3 = 3.0f;
            double d3 = 3.0;
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
            // Shuffle - control: Reverse order based on 128 bits.
            WriteLineFormat(tw, indent, "Shuffle(srcT_256_double):\t{0}", Avx.Shuffle(srcT_256_double, srcT_256_double, 0b0000_0101));
            WriteLineFormat(tw, indent, "Shuffle(srcT_256_float):\t{0}", Avx.Shuffle(srcT_256_float, srcT_256_float, 0b0001_1011));

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
            string indentNext = indent + IndentNextSeparator;
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
            WriteLineFormat(tw, indent, "Abs(srcT_256_sbyte):\t{0}", Avx2.Abs(srcT_256_sbyte));
            WriteLineFormat(tw, indent, "Abs(srcT_256_short):\t{0}", Avx2.Abs(srcT_256_short));
            WriteLineFormat(tw, indent, "Abs(srcT_256_int):\t{0}", Avx2.Abs(srcT_256_int));

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
            WriteLineFormat(tw, indent, "Add(srcT_256_byte, src2_256_byte):\t{0}", Avx2.Add(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "Add(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.Add(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "Add(srcT_256_uint, src2_256_uint):\t{0}", Avx2.Add(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "Add(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.Add(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "Add(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.Add(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "Add(srcT_256_short, src2_256_short):\t{0}", Avx2.Add(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "Add(srcT_256_int, src2_256_int):\t{0}", Avx2.Add(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "Add(srcT_256_long, src2_256_long):\t{0}", Avx2.Add(srcT_256_long, src2_256_long));

            // AddSaturate(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_adds_epu8 (__m256i a, __m256i b)
            // VPADDUSB ymm, ymm, ymm/m256
            // AddSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_adds_epi16 (__m256i a, __m256i b)
            // VPADDSW ymm, ymm, ymm/m256
            // AddSaturate(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_adds_epi8 (__m256i a, __m256i b)
            // VPADDSB ymm, ymm, ymm/m256
            // AddSaturate(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_adds_epu16 (__m256i a, __m256i b)
            // VPADDUSW ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "AddSaturate(srcT_256_byte, src2_256_byte):\t{0}", Avx2.AddSaturate(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "AddSaturate(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.AddSaturate(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "AddSaturate(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.AddSaturate(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "AddSaturate(srcT_256_short, src2_256_short):\t{0}", Avx2.AddSaturate(srcT_256_short, src2_256_short));

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
            // Concatenate pairs of 16-byte blocks in a and b into a 32-byte temporary result, shift the result right by imm8 bytes, and store the low 16 bytes in dst. (将a和b中成对的16字节块串联成一个32字节的临时结果，将结果右移imm8字节，并将低16字节存储在dst中。) # 即128位元素的右移.
            // FOR j := 0 to 1
            // 	i := j*128
            // 	tmp[255:0] := ((a[i+127:i] << 128)[255:0] OR b[i+127:i]) >> (imm8*8)
            // 	dst[i+127:i] := tmp[127:0]
            // ENDFOR
            foreach (byte cnt in new byte[] { 0, 1, 2 }) {
                WriteLineFormat(tw, indent, "AlignRight - cnt={0} (0x{0:X}):", cnt);
                WriteLineFormat(tw, indentNext, "AlignRight(srcT_256_byte, src2_256_byte, cnt):\t{0}", Avx2.AlignRight(srcT_256_byte, src2_256_byte, cnt));
                WriteLineFormat(tw, indentNext, "AlignRight(srcT_256_short, src2_256_short, cnt):\t{0}", Avx2.AlignRight(srcT_256_short, src2_256_short, cnt));
                WriteLineFormat(tw, indentNext, "AlignRight(srcT_256_int, src2_256_int, cnt):\t{0}", Avx2.AlignRight(srcT_256_int, src2_256_int, cnt));
            }

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
            WriteLineFormat(tw, indent, "And(srcT_256_byte, src2_256_byte):\t{0}", Avx2.And(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "And(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.And(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "And(srcT_256_uint, src2_256_uint):\t{0}", Avx2.And(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "And(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.And(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "And(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.And(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "And(srcT_256_short, src2_256_short):\t{0}", Avx2.And(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "And(srcT_256_int, src2_256_int):\t{0}", Avx2.And(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "And(srcT_256_long, src2_256_long):\t{0}", Avx2.And(srcT_256_long, src2_256_long));

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
            WriteLineFormat(tw, indent, "AndNot(srcT_256_byte, src2_256_byte):\t{0}", Avx2.AndNot(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.AndNot(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_uint, src2_256_uint):\t{0}", Avx2.AndNot(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.AndNot(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.AndNot(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_short, src2_256_short):\t{0}", Avx2.AndNot(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_int, src2_256_int):\t{0}", Avx2.AndNot(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "AndNot(srcT_256_long, src2_256_long):\t{0}", Avx2.AndNot(srcT_256_long, src2_256_long));

            // Average(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_avg_epu8 (__m256i a, __m256i b)
            // VPAVGB ymm, ymm, ymm/m256
            // Average(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_avg_epu16 (__m256i a, __m256i b)
            // VPAVGW ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Average(srcT_256_byte, src2_256_byte):\t{0}", Avx2.Average(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "Average(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.Average(srcT_256_ushort, src2_256_ushort));

            // Blend(Vector128<Int32>, Vector128<Int32>, Byte)	__m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8)
            // VPBLENDD xmm, xmm, xmm/m128, imm8
            // Blend(Vector128<UInt32>, Vector128<UInt32>, Byte)	__m128i _mm_blend_epi32 (__m128i a, __m128i b, const int imm8)
            // VPBLENDD xmm, xmm, xmm/m128, imm8
            // Blend packed 32-bit integers from a and b using control mask imm8, and store the results in dst.
            // FOR j := 0 to 3
            // 	i := j*32
            // 	IF imm8[j]
            // 		dst[i+31:i] := b[i+31:i]
            // 	ELSE
            // 		dst[i+31:i] := a[i+31:i]
            // 	FI
            // ENDFOR
            // Blend(Vector256<Int16>, Vector256<Int16>, Byte)	__m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8)
            // VPBLENDW ymm, ymm, ymm/m256, imm8
            // Blend(Vector256<Int32>, Vector256<Int32>, Byte)	__m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8)
            // VPBLENDD ymm, ymm, ymm/m256, imm8
            // Blend(Vector256<UInt16>, Vector256<UInt16>, Byte)	__m256i _mm256_blend_epi16 (__m256i a, __m256i b, const int imm8)
            // VPBLENDW ymm, ymm, ymm/m256, imm8
            // Blend packed 16-bit integers from a and b within 128-bit lanes using control mask imm8, and store the results in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	IF imm8[j%8]
            // 		dst[i+15:i] := b[i+15:i]
            // 	ELSE
            // 		dst[i+15:i] := a[i+15:i]
            // 	FI
            // ENDFOR
            // dst[MAX:256] := 0
            // Blend(Vector256<UInt32>, Vector256<UInt32>, Byte)	__m256i _mm256_blend_epi32 (__m256i a, __m256i b, const int imm8)
            // VPBLENDD ymm, ymm, ymm/m256, imm8
            // Blend packed 32-bit integers from a and b using control mask imm8, and store the results in dst.
            // FOR j := 0 to 7
            // 	i := j*32
            // 	IF imm8[j]
            // 		dst[i+31:i] := b[i+31:i]
            // 	ELSE
            // 		dst[i+31:i] := a[i+31:i]
            // 	FI
            // ENDFOR
            foreach (byte control in new byte[] { 1, 3, 0xCB }) {
                WriteLineFormat(tw, indent, "Blend - control={0} (0x{0:X}):", control);
                WriteLineFormat(tw, indentNext, "Blend(srcT_128_int, src2_128_int, control):\t{0}", Avx2.Blend(srcT_128_int, src2_128_int, control));
                WriteLineFormat(tw, indentNext, "Blend(srcT_256_ushort, src2_256_ushort, control):\t{0}", Avx2.Blend(srcT_256_ushort, src2_256_ushort, control));
                WriteLineFormat(tw, indentNext, "Blend(srcT_256_int, src2_256_int, control):\t{0}", Avx2.Blend(srcT_256_int, src2_256_int, control));
            }

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
            // Blend packed 8-bit integers from a and b using mask, and store the results in dst.
            // FOR j := 0 to 31
            // 	i := j*8
            // 	IF mask[i+7]
            // 		dst[i+7:i] := b[i+7:i]
            // 	ELSE
            // 		dst[i+7:i] := a[i+7:i]
            // 	FI
            // ENDFOR
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_byte, src2_256_byte, srcT_256_byte):\t{0}", Avx2.BlendVariable(srcT_256_byte, src2_256_byte, srcT_256_byte));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_ushort, src2_256_ushort, srcT_256_ushort):\t{0}", Avx2.BlendVariable(srcT_256_ushort, src2_256_ushort, srcT_256_ushort));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_uint, src2_256_uint, srcT_256_uint):\t{0}", Avx2.BlendVariable(srcT_256_uint, src2_256_uint, srcT_256_uint));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_ulong, src2_256_ulong, srcT_256_ulong):\t{0}", Avx2.BlendVariable(srcT_256_ulong, src2_256_ulong, srcT_256_ulong));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_sbyte, src2_256_sbyte, srcT_256_sbyte):\t{0}", Avx2.BlendVariable(srcT_256_sbyte, src2_256_sbyte, srcT_256_sbyte));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_short, src2_256_short, srcT_256_short):\t{0}", Avx2.BlendVariable(srcT_256_short, src2_256_short, srcT_256_short));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_int, src2_256_int, srcT_256_int):\t{0}", Avx2.BlendVariable(srcT_256_int, src2_256_int, srcT_256_int));
            WriteLineFormat(tw, indent, "BlendVariable(srcT_256_long, src2_256_long, srcT_256_long):\t{0}", Avx2.BlendVariable(srcT_256_long, src2_256_long, srcT_256_long));

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
            fixed (void* p = &srcT_128_byte) {
                WriteLineFormat(tw, indent, "BroadcastScalarToVector128(&srcT_128_byte):\t{0}", Avx2.BroadcastScalarToVector128((byte*)p));
            }
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(srcT_128_byte):\t{0}", Avx2.BroadcastScalarToVector128(srcT_128_byte));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(srcT_128_ushort):\t{0}", Avx2.BroadcastScalarToVector128(srcT_128_ushort));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(srcT_128_uint):\t{0}", Avx2.BroadcastScalarToVector128(srcT_128_uint));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(srcT_128_ulong):\t{0}", Avx2.BroadcastScalarToVector128(srcT_128_ulong));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(srcT_128_sbyte):\t{0}", Avx2.BroadcastScalarToVector128(srcT_128_sbyte));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(srcT_128_short):\t{0}", Avx2.BroadcastScalarToVector128(srcT_128_short));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(srcT_128_int):\t{0}", Avx2.BroadcastScalarToVector128(srcT_128_int));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector128(srcT_128_long):\t{0}", Avx2.BroadcastScalarToVector128(srcT_128_long));

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
            fixed (void* p = &srcT_128_byte) {
                WriteLineFormat(tw, indent, "BroadcastScalarToVector256(&srcT_128_byte):\t{0}", Avx2.BroadcastScalarToVector256((byte*)p));
            }
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(srcT_128_byte):\t{0}", Avx2.BroadcastScalarToVector256(srcT_128_byte));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(srcT_128_ushort):\t{0}", Avx2.BroadcastScalarToVector256(srcT_128_ushort));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(srcT_128_uint):\t{0}", Avx2.BroadcastScalarToVector256(srcT_128_uint));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(srcT_128_ulong):\t{0}", Avx2.BroadcastScalarToVector256(srcT_128_ulong));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(srcT_128_sbyte):\t{0}", Avx2.BroadcastScalarToVector256(srcT_128_sbyte));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(srcT_128_short):\t{0}", Avx2.BroadcastScalarToVector256(srcT_128_short));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(srcT_128_int):\t{0}", Avx2.BroadcastScalarToVector256(srcT_128_int));
            WriteLineFormat(tw, indent, "BroadcastScalarToVector256(srcT_128_long):\t{0}", Avx2.BroadcastScalarToVector256(srcT_128_long));

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
            // Broadcast 128 bits of integer data from a to all 128-bit lanes in dst.
            // dst[127:0] := a[127:0]
            // dst[255:128] := a[127:0]
            fixed (void* p = &srcT_128_byte) {
                WriteLineFormat(tw, indent, "BroadcastVector128ToVector256(&srcT_128_byte):\t{0}", Avx2.BroadcastVector128ToVector256((byte*)p));
            }
            fixed (void* p = &srcT_128_long) {
                WriteLineFormat(tw, indent, "BroadcastVector128ToVector256(&srcT_128_long):\t{0}", Avx2.BroadcastVector128ToVector256((long*)p));
            }

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
            WriteLineFormat(tw, indent, "CompareEqual(srcT_256_byte, src2_256_byte):\t{0}", Avx2.CompareEqual(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "CompareEqual(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.CompareEqual(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "CompareEqual(srcT_256_uint, src2_256_uint):\t{0}", Avx2.CompareEqual(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "CompareEqual(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.CompareEqual(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "CompareEqual(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.CompareEqual(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "CompareEqual(srcT_256_short, src2_256_short):\t{0}", Avx2.CompareEqual(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "CompareEqual(srcT_256_int, src2_256_int):\t{0}", Avx2.CompareEqual(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "CompareEqual(srcT_256_long, src2_256_long):\t{0}", Avx2.CompareEqual(srcT_256_long, src2_256_long));

            // CompareGreaterThan(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_cmpgt_epi16 (__m256i a, __m256i b)
            // VPCMPGTW ymm, ymm, ymm/m256
            // CompareGreaterThan(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_cmpgt_epi32 (__m256i a, __m256i b)
            // VPCMPGTD ymm, ymm, ymm/m256
            // CompareGreaterThan(Vector256<Int64>, Vector256<Int64>)	__m256i _mm256_cmpgt_epi64 (__m256i a, __m256i b)
            // VPCMPGTQ ymm, ymm, ymm/m256
            // CompareGreaterThan(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_cmpgt_epi8 (__m256i a, __m256i b)
            // VPCMPGTB ymm, ymm, ymm/m256
            //WriteLineFormat(tw, indent, "CompareGreaterThan(srcT_256_byte, src2_256_byte):\t{0}", Avx2.CompareGreaterThan(srcT_256_byte, src2_256_byte));
            //WriteLineFormat(tw, indent, "CompareGreaterThan(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.CompareGreaterThan(srcT_256_ushort, src2_256_ushort));
            //WriteLineFormat(tw, indent, "CompareGreaterThan(srcT_256_uint, src2_256_uint):\t{0}", Avx2.CompareGreaterThan(srcT_256_uint, src2_256_uint));
            //WriteLineFormat(tw, indent, "CompareGreaterThan(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.CompareGreaterThan(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "CompareGreaterThan(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.CompareGreaterThan(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "CompareGreaterThan(srcT_256_short, src2_256_short):\t{0}", Avx2.CompareGreaterThan(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "CompareGreaterThan(srcT_256_int, src2_256_int):\t{0}", Avx2.CompareGreaterThan(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "CompareGreaterThan(srcT_256_long, src2_256_long):\t{0}", Avx2.CompareGreaterThan(srcT_256_long, src2_256_long));

            // ConvertToInt32(Vector256<Int32>)	int _mm256_cvtsi256_si32 (__m256i a)
            // MOVD reg/m32, xmm
            // ConvertToUInt32(Vector256<UInt32>)	int _mm256_cvtsi256_si32 (__m256i a)
            // MOVD reg/m32, xmm
            // Copy the lower 32-bit integer in a to dst.
            // dst[31:0] := a[31:0]
            WriteLineFormat(tw, indent, "ConvertToInt32(srcT_256_int):\t{0}", Avx2.ConvertToInt32(srcT_256_int));
            WriteLineFormat(tw, indent, "ConvertToUInt32(srcT_256_uint):\t{0}", Avx2.ConvertToUInt32(srcT_256_uint));

            // ConvertToVector256Int16(Byte*)	VPMOVZXBW ymm, m128
            // ConvertToVector256Int16(SByte*)	VPMOVSXBW ymm, m128
            // ConvertToVector256Int16(Vector128<Byte>)	__m256i _mm256_cvtepu8_epi16 (__m128i a)
            // VPMOVZXBW ymm, xmm
            // Zero extend packed unsigned 8-bit integers in a to packed 16-bit integers, and store the results in dst.
            // FOR j := 0 to 15
            // 	i := j*8
            // 	l := j*16
            // 	dst[l+15:l] := ZeroExtend16(a[i+7:i])
            // ENDFOR
            // ConvertToVector256Int16(Vector128<SByte>)	__m256i _mm256_cvtepi8_epi16 (__m128i a)
            // VPMOVSXBW ymm, xmm/m128
            // Sign extend packed 8-bit integers in a to packed 16-bit integers, and store the results in dst.
            // FOR j := 0 to 15
            // 	i := j*8
            // 	l := j*16
            // 	dst[l+15:l] := SignExtend16(a[i+7:i])
            // ENDFOR
            WriteLineFormat(tw, indent, "ConvertToVector256Int16(srcT_128_byte):\t{0}", Avx2.ConvertToVector256Int16(srcT_128_byte));
            WriteLineFormat(tw, indent, "ConvertToVector256Int16(srcT_128_sbyte):\t{0}", Avx2.ConvertToVector256Int16(srcT_128_sbyte));

            // ConvertToVector256Int32(Byte*)	VPMOVZXBD ymm, m64
            // ConvertToVector256Int32(Int16*)	VPMOVSXWD ymm, m128
            // ConvertToVector256Int32(SByte*)	VPMOVSXBD ymm, m64
            // ConvertToVector256Int32(UInt16*)	VPMOVZXWD ymm, m128
            // ConvertToVector256Int32(Vector128<Byte>)	__m256i _mm256_cvtepu8_epi32 (__m128i a)
            // VPMOVZXBD ymm, xmm
            // Zero extend packed unsigned 8-bit integers in a to packed 32-bit integers, and store the results in dst.
            // FOR j := 0 to 7
            // 	i := 32*j
            // 	k := 8*j
            // 	dst[i+31:i] := ZeroExtend32(a[k+7:k])
            // ENDFOR
            // ConvertToVector256Int32(Vector128<Int16>)	__m256i _mm256_cvtepi16_epi32 (__m128i a)
            // VPMOVSXWD ymm, xmm/m128
            // Sign extend packed 16-bit integers in a to packed 32-bit integers, and store the results in dst.
            // FOR j:= 0 to 7
            // 	i := 32*j
            // 	k := 16*j
            // 	dst[i+31:i] := SignExtend32(a[k+15:k])
            // ENDFOR
            // ConvertToVector256Int32(Vector128<SByte>)	__m256i _mm256_cvtepi8_epi32 (__m128i a)
            // VPMOVSXBD ymm, xmm/m128
            // ConvertToVector256Int32(Vector128<UInt16>)	__m256i _mm256_cvtepu16_epi32 (__m128i a)
            // VPMOVZXWD ymm, xmm
            WriteLineFormat(tw, indent, "ConvertToVector256Int32(srcT_128_byte):\t{0}", Avx2.ConvertToVector256Int32(srcT_128_byte));
            WriteLineFormat(tw, indent, "ConvertToVector256Int32(srcT_128_ushort):\t{0}", Avx2.ConvertToVector256Int32(srcT_128_ushort));
            WriteLineFormat(tw, indent, "ConvertToVector256Int32(srcT_128_sbyte):\t{0}", Avx2.ConvertToVector256Int32(srcT_128_sbyte));
            WriteLineFormat(tw, indent, "ConvertToVector256Int32(srcT_128_short):\t{0}", Avx2.ConvertToVector256Int32(srcT_128_short));

            // ConvertToVector256Int64(Byte*)	VPMOVZXBQ ymm, m32
            // ConvertToVector256Int64(Int16*)	VPMOVSXWQ ymm, m64
            // ConvertToVector256Int64(Int32*)	VPMOVSXDQ ymm, m128
            // ConvertToVector256Int64(SByte*)	VPMOVSXBQ ymm, m32
            // ConvertToVector256Int64(UInt16*)	VPMOVZXWQ ymm, m64
            // ConvertToVector256Int64(UInt32*)	VPMOVZXDQ ymm, m128
            // ConvertToVector256Int64(Vector128<Byte>)	__m256i _mm256_cvtepu8_epi64 (__m128i a)
            // VPMOVZXBQ ymm, xmm
            // Zero extend packed unsigned 8-bit integers in the low 8 byte sof a to packed 64-bit integers, and store the results in dst.
            // FOR j := 0 to 3
            // 	i := 64*j
            // 	k := 8*j
            // 	dst[i+63:i] := ZeroExtend64(a[k+7:k])
            // ENDFOR
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
            WriteLineFormat(tw, indent, "ConvertToVector256Int64(srcT_128_byte):\t{0}", Avx2.ConvertToVector256Int64(srcT_128_byte));
            WriteLineFormat(tw, indent, "ConvertToVector256Int64(srcT_128_ushort):\t{0}", Avx2.ConvertToVector256Int64(srcT_128_ushort));
            WriteLineFormat(tw, indent, "ConvertToVector256Int64(srcT_128_uint):\t{0}", Avx2.ConvertToVector256Int64(srcT_128_uint));
            WriteLineFormat(tw, indent, "ConvertToVector256Int64(srcT_128_sbyte):\t{0}", Avx2.ConvertToVector256Int64(srcT_128_sbyte));
            WriteLineFormat(tw, indent, "ConvertToVector256Int64(srcT_128_short):\t{0}", Avx2.ConvertToVector256Int64(srcT_128_short));
            WriteLineFormat(tw, indent, "ConvertToVector256Int64(srcT_128_int):\t{0}", Avx2.ConvertToVector256Int64(srcT_128_int));

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
            foreach (byte idx in new byte[] { 0, 1 }) {
                WriteLineFormat(tw, indent, "ExtractVector128 - idx={0} (0x{0:X}):", idx);
                WriteLineFormat(tw, indentNext, "ExtractVector128(srcT_256_byte, idx):\t{0}", Avx2.ExtractVector128(srcT_256_byte, idx));
                WriteLineFormat(tw, indentNext, "ExtractVector128(srcT_256_int, idx):\t{0}", Avx2.ExtractVector128(srcT_256_int, idx));
            }

            // GatherMaskVector128(Vector128<Double>, Double*, Vector128<Int32>, Vector128<Double>, Byte)	__m128d _mm_mask_i32gather_pd (__m128d src, double const* base_addr, __m128i vindex, __m128d mask, const int scale)
            // VGATHERDPD xmm, vm32x, xmm
            // Gather double-precision (64-bit) floating-point elements from memory using 32-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 32-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8. (使用32位索引从内存中收集双精度（64位）浮点元素。64位元素从base_addr开始加载，并通过vindex中的每个32位元素进行偏移（每个索引按scale中的因子进行缩放）。使用掩码将收集到的元素合并到dst中（当相应元素的最高位没有被设置时，元素从src中复制）。scale应该是1、2、4或8。)
            // FOR j := 0 to 1
            // 	i := j*64
            // 	m := j*32
            // 	IF mask[i+63]
            // 		addr := base_addr + SignExtend64(vindex[m+31:m]) * ZeroExtend64(scale) * 8
            // 		dst[i+63:i] := MEM[addr+63:addr]
            // 	ELSE
            // 		dst[i+63:i] := src[i+63:i]
            // 	FI
            // ENDFOR
            // GatherMaskVector128(Vector128<Double>, Double*, Vector128<Int64>, Vector128<Double>, Byte)	__m128d _mm_mask_i64gather_pd (__m128d src, double const* base_addr, __m128i vindex, __m128d mask, const int scale)
            // VGATHERQPD xmm, vm64x, xmm
            // Gather double-precision (64-bit) floating-point elements from memory using 64-bit indices. 64-bit elements are loaded from addresses starting at base_addr and offset by each 64-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8.
            // FOR j := 0 to 1
            // 	i := j*64
            // 	m := j*64
            // 	IF mask[i+63]
            // 		addr := base_addr + vindex[m+63:m] * ZeroExtend64(scale) * 8
            // 		dst[i+63:i] := MEM[addr+63:addr]
            // 	ELSE
            // 		dst[i+63:i] := src[i+63:i]
            // 	FI
            // ENDFOR
            fixed (double* p = &srcArray_double[0]) {
                WriteLineFormat(tw, indent, "GatherMaskVector128(src2_128_double, p, srcQ_128_int, srcT_128_double, sizeof(double)):\t{0}", Avx2.GatherMaskVector128(src2_128_double, p, srcQ_128_int, srcT_128_double, sizeof(double)));
                WriteLineFormat(tw, indent, "GatherMaskVector128(src2_128_double, p, srcQ_128_long, srcT_128_double, sizeof(double)):\t{0}", Avx2.GatherMaskVector128(src2_128_double, p, srcQ_128_long, srcT_128_double, sizeof(double)));
            }

            // GatherMaskVector128(Vector128<Int32>, Int32*, Vector128<Int32>, Vector128<Int32>, Byte)	__m128i _mm_mask_i32gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERDD xmm, vm32x, xmm
            // GatherMaskVector128(Vector128<Int32>, Int32*, Vector128<Int64>, Vector128<Int32>, Byte)	__m128i _mm_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m128i vindex, __m128i mask, const int scale)
            // VPGATHERQD xmm, vm64x, xmm
            // Gather 32-bit integers from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 64-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8.
            // FOR j := 0 to 1
            // 	i := j*32
            // 	m := j*64
            // 	IF mask[i+31]
            // 		addr := base_addr + vindex[m+63:m] * ZeroExtend64(scale) * 8
            // 		dst[i+31:i] := MEM[addr+31:addr]
            // 	ELSE
            // 		dst[i+31:i] := src[i+31:i]
            // 	FI
            // ENDFOR
            // GatherMaskVector128(Vector128<Int32>, Int32*, Vector256<Int64>, Vector128<Int32>, Byte)	__m128i _mm256_mask_i64gather_epi32 (__m128i src, int const* base_addr, __m256i vindex, __m128i mask, const int scale)
            // VPGATHERQD xmm, vm32y, xmm
            // Gather 32-bit integers from memory using 64-bit indices. 32-bit elements are loaded from addresses starting at base_addr and offset by each 64-bit element in vindex (each index is scaled by the factor in scale). Gathered elements are merged into dst using mask (elements are copied from src when the highest bit is not set in the corresponding element). scale should be 1, 2, 4 or 8.
            // FOR j := 0 to 3
            // 	i := j*32
            // 	m := j*64
            // 	IF mask[i+31]
            // 		addr := base_addr + vindex[m+63:m] * ZeroExtend64(scale) * 8
            // 		dst[i+31:i] := MEM[addr+31:addr]
            // 	ELSE
            // 		dst[i+31:i] := src[i+31:i]
            // 	FI
            // ENDFOR
            fixed (int* p = &srcArray_int[0]) {
                WriteLineFormat(tw, indent, "GatherMaskVector128(src2_128_int, p, srcQ_128_int, srcT_128_int, sizeof(int)):\t{0}", Avx2.GatherMaskVector128(src2_128_int, p, srcQ_128_int, srcT_128_int, sizeof(int)));
                WriteLineFormat(tw, indent, "GatherMaskVector128(src2_128_int, p, srcQ_128_long, srcT_128_int, sizeof(int)):\t{0}", Avx2.GatherMaskVector128(src2_128_int, p, srcQ_128_long, srcT_128_int, sizeof(int)));
                WriteLineFormat(tw, indent, "GatherMaskVector128(src2_128_int, p, srcQ_256_long, srcT_128_int, sizeof(int)):\t{0}", Avx2.GatherMaskVector128(src2_128_int, p, srcQ_256_long, srcT_128_int, sizeof(int)));
            }

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
            fixed (float* p = &srcArray_float[0]) {
                WriteLineFormat(tw, indent, "GatherMaskVector128(src2_128_float, p, srcQ_128_int, srcT_128_float, sizeof(float)):\t{0}", Avx2.GatherMaskVector128(src2_128_float, p, srcQ_128_int, srcT_128_float, sizeof(float)));
                WriteLineFormat(tw, indent, "GatherMaskVector128(src2_128_float, p, srcQ_128_long, srcT_128_float, sizeof(float)):\t{0}", Avx2.GatherMaskVector128(src2_128_float, p, srcQ_128_long, srcT_128_float, sizeof(float)));
                WriteLineFormat(tw, indent, "GatherMaskVector128(src2_128_float, p, srcQ_256_long, srcT_128_float, sizeof(float)):\t{0}", Avx2.GatherMaskVector128(src2_128_float, p, srcQ_256_long, srcT_128_float, sizeof(float)));
            }

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
            // (ignore)

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
            fixed (double* p = &srcArray_double[0]) {
                WriteLineFormat(tw, indent, "GatherMaskVector256(src2_256_double, p, srcQ_128_int, srcT_256_double, sizeof(double)):\t{0}", Avx2.GatherMaskVector256(src2_256_double, p, srcQ_128_int, srcT_256_double, sizeof(double)));
                WriteLineFormat(tw, indent, "GatherMaskVector256(src2_256_double, p, srcQ_256_long, srcT_256_double, sizeof(double)):\t{0}", Avx2.GatherMaskVector256(src2_256_double, p, srcQ_256_long, srcT_256_double, sizeof(double)));
            }
            fixed (int* p = &srcArray_int[0]) {
                WriteLineFormat(tw, indent, "GatherMaskVector256(src2_256_int, p, srcQ_256_long, srcT_256_int, sizeof(int)):\t{0}", Avx2.GatherMaskVector256(src2_256_int, p, srcQ_256_int, srcT_256_int, sizeof(int)));
            }
            fixed (float* p = &srcArray_float[0]) {
                WriteLineFormat(tw, indent, "GatherMaskVector256(src2_256_float, p, srcQ_256_long, srcT_256_float, sizeof(float)):\t{0}", Avx2.GatherMaskVector256(src2_256_float, p, srcQ_256_int, srcT_256_float, sizeof(float)));
            }

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
            fixed (double* p = &srcArray_double[0]) {
                WriteLineFormat(tw, indent, "GatherVector128(p, srcQ_128_int, sizeof(double)):\t{0}", Avx2.GatherVector128(p, srcQ_128_int, sizeof(double)));
                WriteLineFormat(tw, indent, "GatherVector128(p, srcQ_128_long, sizeof(double)):\t{0}", Avx2.GatherVector128(p, srcQ_128_long, sizeof(double)));
            }
            fixed (float* p = &srcArray_float[0]) {
                WriteLineFormat(tw, indent, "GatherVector128(p, srcQ_128_int, sizeof(float)):\t{0}", Avx2.GatherVector128(p, srcQ_128_int, sizeof(float)));
                WriteLineFormat(tw, indent, "GatherVector128(p, srcQ_256_long, sizeof(float)):\t{0}", Avx2.GatherVector128(p, srcQ_256_long, sizeof(float)));
            }
            fixed (int* p = &srcArray_int[0]) {
                WriteLineFormat(tw, indent, "GatherVector128(p, srcQ_128_int, sizeof(int)):\t{0}", Avx2.GatherVector128(p, srcQ_128_int, sizeof(int)));
                WriteLineFormat(tw, indent, "GatherVector128(p, srcQ_256_long, sizeof(int)):\t{0}", Avx2.GatherVector128(p, srcQ_256_long, sizeof(int)));
                try {
                    WriteLineFormat(tw, indent, "GatherVector128(p, Vector128.Create((int)0, 1, 0, 3), sizeof(int)):\t{0}", Avx2.GatherVector128(p, Vector128.Create((int)0, 1, 0, 3), sizeof(int)));
                    WriteLineFormat(tw, indent, "GatherVector128(p, Vector128.Create((int)0, 1, 0, -1), sizeof(int)):\t{0}", Avx2.GatherVector128(p, Vector128.Create((int)0, 1, 0, -1), sizeof(int)));
                } catch (Exception ex) {
                    WriteLineFormat(tw, indent, "GatherVector128 fail by srcArray_int! {0}", ex.Message);
                }
            }
            fixed (byte* p0 = &srcArray_byte[0]) {
                int* p = (int*)p0;
                try {
                    WriteLineFormat(tw, indent, "GatherVector128(p, srcQ_128_int, 1):\t{0}", Avx2.GatherVector128(p, srcQ_128_int, 1));
                    WriteLineFormat(tw, indent, "GatherVector128(p, srcQ_256_long, 1):\t{0}", Avx2.GatherVector128(p, srcQ_256_long, 1));
                    WriteLineFormat(tw, indent, "GatherVector128(p, Vector128.Create((int)0, 1, 0, 3), 1):\t{0}", Avx2.GatherVector128(p, Vector128.Create((int)0, 1, 0, 3), 1));
                    WriteLineFormat(tw, indent, "GatherVector128(p, Vector128.Create((int)0, 1, 0, -1), 1):\t{0}", Avx2.GatherVector128(p, Vector128.Create((int)0, 1, 0, -1), 1));
                    Vector128<int> vByteMask = Vector128.Create((int)0xFF);
                    WriteLineFormat(tw, indent, "GatherVector128 - vByteMask:\t{0}", vByteMask);
                    WriteLineFormat(tw, indent, "Avx2.And(vByteMask, GatherVector128(p, srcQ_128_int, 1)):\t{0}", Avx2.And(vByteMask, Avx2.GatherVector128(p, srcQ_128_int, 1)));
                    WriteLineFormat(tw, indent, "Avx2.And(vByteMask, GatherVector128(p, srcQ_256_long, 1)):\t{0}", Avx2.And(vByteMask, Avx2.GatherVector128(p, srcQ_256_long, 1)));
                    WriteLineFormat(tw, indent, "Avx2.And(vByteMask, GatherVector128(p, Vector128.Create((int)0, 1, 0, 3), 1)):\t{0}", Avx2.And(vByteMask, Avx2.GatherVector128(p, Vector128.Create((int)0, 1, 0, 3), 1)));
                    WriteLineFormat(tw, indent, "Avx2.And(vByteMask, GatherVector128(p, Vector128.Create((int)0, 1, 0, -1), 1)):\t{0}", Avx2.And(vByteMask, Avx2.GatherVector128(p, Vector128.Create((int)0, 1, 0, -1), 1)));
                } catch (Exception ex) {
                    WriteLineFormat(tw, indent, "GatherVector128 fail by srcArray_byte! {0}", ex.Message);
                }
            }

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
            fixed (double* p = &srcArray_double[0]) {
                WriteLineFormat(tw, indent, "GatherVector256(p, srcQ_128_int, sizeof(double)):\t{0}", Avx2.GatherVector256(p, srcQ_128_int, sizeof(double)));
                WriteLineFormat(tw, indent, "GatherVector256(p, srcQ_256_long, sizeof(double)):\t{0}", Avx2.GatherVector256(p, srcQ_256_long, sizeof(double)));
            }
            fixed (int* p = &srcArray_int[0]) {
                WriteLineFormat(tw, indent, "GatherVector256(p, srcQ_256_int, sizeof(int)):\t{0}", Avx2.GatherVector256(p, srcQ_256_int, sizeof(int)));
            }
            fixed (float* p = &srcArray_float[0]) {
                WriteLineFormat(tw, indent, "GatherVector256(p, srcQ_256_int, sizeof(float)):\t{0}", Avx2.GatherVector256(p, srcQ_256_int, sizeof(float)));
            }

            // HorizontalAdd(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_hadd_epi16 (__m256i a, __m256i b)
            // VPHADDW ymm, ymm, ymm/m256
            // HorizontalAdd(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_hadd_epi32 (__m256i a, __m256i b)
            // VPHADDD ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "HorizontalAdd(srcT_256_short, src2_256_short):\t{0}", Avx2.HorizontalAdd(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "HorizontalAdd(srcT_256_int, src2_256_int):\t{0}", Avx2.HorizontalAdd(srcT_256_int, src2_256_int));

            // HorizontalAddSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_hadds_epi16 (__m256i a, __m256i b)
            // VPHADDSW ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "HorizontalAddSaturate(srcT_256_short, src2_256_short):\t{0}", Avx2.HorizontalAddSaturate(srcT_256_short, src2_256_short));

            // HorizontalSubtract(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_hsub_epi16 (__m256i a, __m256i b)
            // VPHSUBW ymm, ymm, ymm/m256
            // HorizontalSubtract(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_hsub_epi32 (__m256i a, __m256i b)
            // VPHSUBD ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "HorizontalSubtract(srcT_256_short, src2_256_short):\t{0}", Avx2.HorizontalSubtract(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "HorizontalSubtract(srcT_256_int, src2_256_int):\t{0}", Avx2.HorizontalSubtract(srcT_256_int, src2_256_int));

            // HorizontalSubtractSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_hsubs_epi16 (__m256i a, __m256i b)
            // VPHSUBSW ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "HorizontalSubtractSaturate(srcT_256_short, src2_256_short):\t{0}", Avx2.HorizontalSubtractSaturate(srcT_256_short, src2_256_short));

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
            foreach (byte idx in new byte[] { 0, 1 }) {
                WriteLineFormat(tw, indent, "InsertVector128 - idx={0} (0x{0:X}):", idx);
                WriteLineFormat(tw, indentNext, "InsertVector128(srcT_256_byte, src2_128_byte, idx):\t{0}", Avx2.InsertVector128(srcT_256_byte, src2_128_byte, idx));
                WriteLineFormat(tw, indentNext, "InsertVector128(srcT_256_int, src2_128_int, idx):\t{0}", Avx2.InsertVector128(srcT_256_int, src2_128_int, idx));
            }

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
            // (ignore)

            // MaskLoad(Int32*, Vector128<Int32>)	__m128i _mm_maskload_epi32 (int const* mem_addr, __m128i mask)
            // VPMASKMOVD xmm, xmm, m128
            // Load packed 32-bit integers from memory into dst using mask (elements are zeroed out when the highest bit is not set in the corresponding element).
            // FOR j := 0 to 3
            // 	i := j*32
            // 	IF mask[i+31]
            // 		dst[i+31:i] := MEM[mem_addr+i+31:mem_addr+i]
            // 	ELSE
            // 		dst[i+31:i] := 0
            // 	FI
            // ENDFOR
            // MaskLoad(Int32*, Vector256<Int32>)	__m256i _mm256_maskload_epi32 (int const* mem_addr, __m256i mask)
            // VPMASKMOVD ymm, ymm, m256
            // FOR j := 0 to 7
            // 	i := j*32
            // 	IF mask[i+31]
            // 		dst[i+31:i] := MEM[mem_addr+i+31:mem_addr+i]
            // 	ELSE
            // 		dst[i+31:i] := 0
            // 	FI
            // ENDFOR
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
            // FOR j := 0 to 3
            // 	i := j*64
            // 	IF mask[i+63]
            // 		dst[i+63:i] := MEM[mem_addr+i+63:mem_addr+i]
            // 	ELSE
            // 		dst[i+63:i] := 0
            // 	FI
            // ENDFOR
            fixed (int* p = &srcArray_int[0]) {
                WriteLineFormat(tw, indent, "MaskLoad(p, srcT_128_int):\t{0}", Avx2.MaskLoad(p, srcT_128_int));
                WriteLineFormat(tw, indent, "MaskLoad(p, srcT_256_int):\t{0}", Avx2.MaskLoad(p, srcT_256_int));
            }
            fixed (long* p = &srcArray_long[0]) {
                WriteLineFormat(tw, indent, "MaskLoad(p, srcT_128_long):\t{0}", Avx2.MaskLoad(p, srcT_128_long));
                WriteLineFormat(tw, indent, "MaskLoad(p, srcT_256_long):\t{0}", Avx2.MaskLoad(p, srcT_256_long));
            }

            // MaskStore(Int32*, Vector128<Int32>, Vector128<Int32>)	void _mm_maskstore_epi32 (int* mem_addr, __m128i mask, __m128i a)
            // VPMASKMOVD m128, xmm, xmm
            // Store packed 32-bit integers from a into memory using mask (elements are not stored when the highest bit is not set in the corresponding element).
            // FOR j := 0 to 3
            // 	i := j*32
            // 	IF mask[i+31]
            // 		MEM[mem_addr+i+31:mem_addr+i] := a[i+31:i]
            // 	FI
            // ENDFOR
            // MaskStore(Int32*, Vector256<Int32>, Vector256<Int32>)	void _mm256_maskstore_epi32 (int* mem_addr, __m256i mask, __m256i a)
            // VPMASKMOVD m256, ymm, ymm
            // FOR j := 0 to 7
            // 	i := j*32
            // 	IF mask[i+31]
            // 		MEM[mem_addr+i+31:mem_addr+i] := a[i+31:i]
            // 	FI
            // ENDFOR
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
            // FOR j := 0 to 3
            // 	i := j*64
            // 	IF mask[i+63]
            // 		MEM[mem_addr+i+63:mem_addr+i] := a[i+63:i]
            // 	FI
            // ENDFOR
            Vector128<int> srcS_128_int = src2_128_int;
            Avx2.MaskStore((int*)&srcS_128_int, srcT_128_int, src1_128_int);
            WriteLineFormat(tw, indent, "MaskStore((int*)&srcS_128_int, srcT_128_int, src1_128_int):\t{0}", srcS_128_int);
            Vector256<int> srcS_256_int = src2_256_int;
            Avx2.MaskStore((int*)&srcS_256_int, srcT_256_int, src1_256_int);
            WriteLineFormat(tw, indent, "MaskStore((int*)&srcS_256_int, srcT_256_int, src1_256_int):\t{0}", srcS_256_int);
            Vector128<ulong> srcS_128_ulong = src2_128_ulong;
            Avx2.MaskStore((ulong*)&srcS_128_ulong, srcT_128_ulong, src1_128_ulong);
            WriteLineFormat(tw, indent, "MaskStore((ulong*)&srcS_128_ulong, srcT_128_ulong, src1_128_ulong):\t{0}", srcS_128_ulong);
            Vector256<ulong> srcS_256_ulong = src2_256_ulong;
            Avx2.MaskStore((ulong*)&srcS_256_ulong, srcT_256_ulong, src1_256_ulong);
            WriteLineFormat(tw, indent, "MaskStore((ulong*)&srcS_256_ulong, srcT_256_ulong, src1_256_ulong):\t{0}", srcS_256_ulong);

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
            WriteLineFormat(tw, indent, "Max(srcT_256_byte, src2_256_byte):\t{0}", Avx2.Max(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "Max(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.Max(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "Max(srcT_256_uint, src2_256_uint):\t{0}", Avx2.Max(srcT_256_uint, src2_256_uint));
            //WriteLineFormat(tw, indent, "Max(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.Max(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "Max(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.Max(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "Max(srcT_256_short, src2_256_short):\t{0}", Avx2.Max(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "Max(srcT_256_int, src2_256_int):\t{0}", Avx2.Max(srcT_256_int, src2_256_int));
            //WriteLineFormat(tw, indent, "Max(srcT_256_long, src2_256_long):\t{0}", Avx2.Max(srcT_256_long, src2_256_long));

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
            WriteLineFormat(tw, indent, "Min(srcT_256_byte, src2_256_byte):\t{0}", Avx2.Min(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "Min(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.Min(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "Min(srcT_256_uint, src2_256_uint):\t{0}", Avx2.Min(srcT_256_uint, src2_256_uint));
            //WriteLineFormat(tw, indent, "Min(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.Min(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "Min(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.Min(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "Min(srcT_256_short, src2_256_short):\t{0}", Avx2.Min(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "Min(srcT_256_int, src2_256_int):\t{0}", Avx2.Min(srcT_256_int, src2_256_int));
            //WriteLineFormat(tw, indent, "Min(srcT_256_long, src2_256_long):\t{0}", Avx2.Min(srcT_256_long, src2_256_long));

            // MoveMask(Vector256<Byte>)	int _mm256_movemask_epi8 (__m256i a)
            // VPMOVMSKB reg, ymm
            // MoveMask(Vector256<SByte>)	int _mm256_movemask_epi8 (__m256i a)
            // VPMOVMSKB reg, ymm
            // Create mask from the most significant bit of each 8-bit element in a, and store the result in dst.
            // FOR j := 0 to 31
            // 	i := j*8
            // 	dst[j] := a[i+7]
            // ENDFOR
            WriteLineFormat(tw, indent, "MoveMask(srcT_256_byte):\t{0}\t# 0x{0:X8}", Avx2.MoveMask(srcT_256_byte));
            WriteLineFormat(tw, indent, "MoveMask(srcT_256_sbyte):\t{0}\t# 0x{0:X8}", Avx2.MoveMask(srcT_256_sbyte));

            // MultipleSumAbsoluteDifferences(Vector256<Byte>, Vector256<Byte>, Byte)	__m256i _mm256_mpsadbw_epu8 (__m256i a, __m256i b, const int imm8)
            // VMPSADBW ymm, ymm, ymm/m256, imm8
            // Compute the sum of absolute differences (SADs) of quadruplets of unsigned 8-bit integers in a compared to those in b, and store the 16-bit results in dst. Eight SADs are performed for each 128-bit lane using one quadruplet from b and eight quadruplets from a. One quadruplet is selected from b starting at on the offset specified in imm8. Eight quadruplets are formed from sequential 8-bit integers selected from a starting at the offset specified in imm8. (计算a中无符号8位整数的四元组与b中的四元组的绝对差值之和（SAD），并将16位结果存储在dst中。每个128位通道使用b中的一个四元组和a中的八个四元组进行八个SAD。八个四元组从a中选择连续的8位整数，从imm8中指定的偏移量开始，形成四元组。)
            // DEFINE MPSADBW(a[127:0], b[127:0], imm8[2:0]) {
            // 	a_offset := imm8[2]*32
            // 	b_offset := imm8[1:0]*32
            // 	FOR j := 0 to 7
            // 		i := j*8
            // 		k := a_offset+i
            // 		l := b_offset
            // 		tmp[i*2+15:i*2] := ABS(Signed(a[k+7:k] - b[l+7:l])) + ABS(Signed(a[k+15:k+8] - b[l+15:l+8])) + 
            // 		                   ABS(Signed(a[k+23:k+16] - b[l+23:l+16])) + ABS(Signed(a[k+31:k+24] - b[l+31:l+24]))
            // 	ENDFOR
            // 	RETURN tmp[127:0]
            // }
            // dst[127:0] := MPSADBW(a[127:0], b[127:0], imm8[2:0])
            // dst[255:128] := MPSADBW(a[255:128], b[255:128], imm8[5:3])
            for(byte i =0; i<8; ++i) {
                byte mask = (byte)((i << 3) | i);
                string key = string.Format("0x{0:X2}", mask);
                WriteLineFormat(tw, indent, "MultipleSumAbsoluteDifferences(srcT_256_byte, srcQ_256_byte, " + key+"):\t{0}", Avx2.MultipleSumAbsoluteDifferences(srcT_256_byte, srcQ_256_byte, mask));
            }

            // Multiply(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_mul_epi32 (__m256i a, __m256i b)
            // VPMULDQ ymm, ymm, ymm/m256
            // Multiply(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_mul_epu32 (__m256i a, __m256i b)
            // VPMULUDQ ymm, ymm, ymm/m256
            // Multiply the low unsigned 32-bit integers from each packed 64-bit element in a and b, and store the unsigned 64-bit results in dst.
            // FOR j := 0 to 3
            // 	i := j*64
            // 	dst[i+63:i] := a[i+31:i] * b[i+31:i]
            // ENDFOR
            WriteLineFormat(tw, indent, "Multiply(srcT_256_int, src2_256_int):\t{0}", Avx2.Multiply(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "Multiply(srcT_256_uint, src2_256_uint):\t{0}", Avx2.Multiply(srcT_256_uint, src2_256_uint));

            // MultiplyAddAdjacent(Vector256<Byte>, Vector256<SByte>)	__m256i _mm256_maddubs_epi16 (__m256i a, __m256i b)
            // VPMADDUBSW ymm, ymm, ymm/m256
            // Vertically multiply each unsigned 8-bit integer from a with the corresponding signed 8-bit integer from b, producing intermediate signed 16-bit integers. Horizontally add adjacent pairs of intermediate signed 16-bit integers, and pack the saturated results in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	dst[i+15:i] := Saturate16( a[i+15:i+8]*b[i+15:i+8] + a[i+7:i]*b[i+7:i] )
            // ENDFOR
            // MultiplyAddAdjacent(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_madd_epi16 (__m256i a, __m256i b)
            // VPMADDWD ymm, ymm, ymm/m256
            // Multiply packed signed 16-bit integers in a and b, producing intermediate signed 32-bit integers. Horizontally add adjacent pairs of intermediate 32-bit integers, and pack the results in dst.
            // FOR j := 0 to 7
            // 	i := j*32
            // 	dst[i+31:i] := SignExtend32(a[i+31:i+16]*b[i+31:i+16]) + SignExtend32(a[i+15:i]*b[i+15:i])
            // ENDFOR
            WriteLineFormat(tw, indent, "MultiplyAddAdjacent(srcT_256_byte, src2_256_sbyte):\t{0}", Avx2.MultiplyAddAdjacent(srcT_256_byte, src2_256_sbyte));
            //WriteLineFormat(tw, indent, "MultiplyAddAdjacent(srcT_256_byte, src2_256_byte.AsSByte()):\t{0}", Avx2.MultiplyAddAdjacent(srcT_256_byte, src2_256_byte.AsSByte()));
            WriteLineFormat(tw, indent, "MultiplyAddAdjacent(src2_256_sbyte, srcT_256_sbyte):\t{0}", Avx2.MultiplyAddAdjacent(src2_256_byte, srcT_256_sbyte));
            //WriteLineFormat(tw, indent, "MultiplyAddAdjacent(src2_256_sbyte, srcT_256_byte.AsSByte()):\t{0}", Avx2.MultiplyAddAdjacent(src2_256_byte, srcT_256_byte.AsSByte()));
            WriteLineFormat(tw, indent, "MultiplyAddAdjacent(srcT_256_short, src2_256_short):\t{0}", Avx2.MultiplyAddAdjacent(srcT_256_short, src2_256_short));

            // MultiplyHigh(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_mulhi_epi16 (__m256i a, __m256i b)
            // VPMULHW ymm, ymm, ymm/m256
            // Multiply the packed signed 16-bit integers in a and b, producing intermediate 32-bit integers, and store the high 16 bits of the intermediate integers in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	tmp[31:0] := SignExtend32(a[i+15:i]) * SignExtend32(b[i+15:i])
            // 	dst[i+15:i] := tmp[31:16]
            // ENDFOR
            // MultiplyHigh(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_mulhi_epu16 (__m256i a, __m256i b)
            // VPMULHUW ymm, ymm, ymm/m256
            // Multiply the packed unsigned 16-bit integers in a and b, producing intermediate 32-bit integers, and store the high 16 bits of the intermediate integers in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	tmp[31:0] := a[i+15:i] * b[i+15:i]
            // 	dst[i+15:i] := tmp[31:16]
            // ENDFOR
            WriteLineFormat(tw, indent, "MultiplyHigh(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.MultiplyHigh(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "MultiplyHigh(srcT_256_short, src2_256_short):\t{0}", Avx2.MultiplyHigh(srcT_256_short, src2_256_short));

            // MultiplyHighRoundScale(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_mulhrs_epi16 (__m256i a, __m256i b)
            // VPMULHRSW ymm, ymm, ymm/m256
            // Multiply packed signed 16-bit integers in a and b, producing intermediate signed 32-bit integers. Truncate each intermediate integer to the 18 most significant bits, round by adding 1, and store bits [16:1] to dst. (将a和b中的16位有符号整数相乘，产生中间的32位有符号整数。将每个中间整数截断为18个最重要的位，通过加1进行四舍五入，并将位[16:1]存储到dst。)
            // FOR j := 0 to 15
            // 	i := j*16
            // 	tmp[31:0] := ((SignExtend32(a[i+15:i]) * SignExtend32(b[i+15:i])) >> 14) + 1
            // 	dst[i+15:i] := tmp[16:1]
            // ENDFOR
            WriteLineFormat(tw, indent, "MultiplyHighRoundScale(srcT_256_short, src2_256_short):\t{0}", Avx2.MultiplyHighRoundScale(srcT_256_short, src2_256_short));

            // MultiplyLow(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_mullo_epi16 (__m256i a, __m256i b)
            // VPMULLW ymm, ymm, ymm/m256
            // Multiply the packed signed 16-bit integers in a and b, producing intermediate 32-bit integers, and store the low 16 bits of the intermediate integers in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	tmp[31:0] := SignExtend32(a[i+15:i]) * SignExtend32(b[i+15:i])
            // 	dst[i+15:i] := tmp[15:0]
            // ENDFOR
            // MultiplyLow(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_mullo_epi32 (__m256i a, __m256i b)
            // VPMULLD ymm, ymm, ymm/m256
            // MultiplyLow(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_mullo_epi16 (__m256i a, __m256i b)
            // VPMULLW ymm, ymm, ymm/m256
            // MultiplyLow(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_mullo_epi32 (__m256i a, __m256i b)
            // VPMULLD ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "MultiplyLow(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.MultiplyLow(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "MultiplyLow(srcT_256_short, src2_256_short):\t{0}", Avx2.MultiplyLow(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "MultiplyLow(srcT_256_uint, src2_256_uint):\t{0}", Avx2.MultiplyLow(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "MultiplyLow(srcT_256_int, src2_256_int):\t{0}", Avx2.MultiplyLow(srcT_256_int, src2_256_int));

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
            WriteLineFormat(tw, indent, "Or(srcT_256_byte, src2_256_byte):\t{0}", Avx2.Or(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "Or(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.Or(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "Or(srcT_256_uint, src2_256_uint):\t{0}", Avx2.Or(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "Or(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.Or(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "Or(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.Or(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "Or(srcT_256_short, src2_256_short):\t{0}", Avx2.Or(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "Or(srcT_256_int, src2_256_int):\t{0}", Avx2.Or(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "Or(srcT_256_long, src2_256_long):\t{0}", Avx2.Or(srcT_256_long, src2_256_long));

            // PackSignedSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_packs_epi16 (__m256i a, __m256i b)
            // VPACKSSWB ymm, ymm, ymm/m256
            // PackSignedSaturate(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_packs_epi32 (__m256i a, __m256i b)
            // VPACKSSDW ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "PackSignedSaturate(srcT_256_short, src2_256_short):\t{0}", Avx2.PackSignedSaturate(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "PackSignedSaturate(srcT_256_int, src2_256_int):\t{0}", Avx2.PackSignedSaturate(srcT_256_int, src2_256_int));

            // PackUnsignedSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_packus_epi16 (__m256i a, __m256i b)
            // VPACKUSWB ymm, ymm, ymm/m256
            // PackUnsignedSaturate(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_packus_epi32 (__m256i a, __m256i b)
            // VPACKUSDW ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "PackUnsignedSaturate(srcT_256_short, src2_256_short):\t{0}", Avx2.PackUnsignedSaturate(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "PackUnsignedSaturate(srcT_256_int, src2_256_int):\t{0}", Avx2.PackUnsignedSaturate(srcT_256_int, src2_256_int));

            // Permute2x128(Vector256<Byte>, Vector256<Byte>, Byte)	__m256i _mm256_permute2x128_si256 (__m256i a, __m256i b, const int imm8)
            // VPERM2I128 ymm, ymm, ymm/m256, imm8
            // Shuffle 128-bits (composed of integer data) selected by imm8 from a and b, and store the results in dst.
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
            foreach (byte control in new byte[] { 0, 1, 2, 3, 0x23, 0xA3, 0x10 }) {
                WriteLineFormat(tw, indent, "Permute2x128 - control={0} (0x{0:X}):", control);
                WriteLineFormat(tw, indentNext, "Permute2x128(srcT_256_byte, src2_256_byte, control):\t{0}", Avx2.Permute2x128(srcT_256_byte, src2_256_byte, control));
                WriteLineFormat(tw, indentNext, "Permute2x128(srcT_256_int, src2_256_int, control):\t{0}", Avx2.Permute2x128(srcT_256_int, src2_256_int, control));
            }

            // Permute4x64(Vector256<Double>, Byte)	__m256d _mm256_permute4x64_pd (__m256d a, const int imm8)
            // VPERMPD ymm, ymm/m256, imm8
            // Shuffle double-precision (64-bit) floating-point elements in a across lanes using the control in imm8, and store the results in dst.
            // DEFINE SELECT4(src, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[63:0] := src[63:0]
            // 	1:	tmp[63:0] := src[127:64]
            // 	2:	tmp[63:0] := src[191:128]
            // 	3:	tmp[63:0] := src[255:192]
            // 	ESAC
            // 	RETURN tmp[63:0]
            // }
            // dst[63:0] := SELECT4(a[255:0], imm8[1:0])
            // dst[127:64] := SELECT4(a[255:0], imm8[3:2])
            // dst[191:128] := SELECT4(a[255:0], imm8[5:4])
            // dst[255:192] := SELECT4(a[255:0], imm8[7:6])
            // Permute4x64(Vector256<Int64>, Byte)	__m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
            // VPERMQ ymm, ymm/m256, imm8
            // Permute4x64(Vector256<UInt64>, Byte)	__m256i _mm256_permute4x64_epi64 (__m256i a, const int imm8)
            // VPERMQ ymm, ymm/m256, imm8
            // Shuffle 64-bit integers in a across lanes using the control in imm8, and store the results in dst.
            // DEFINE SELECT4(src, control) {
            // 	CASE(control[1:0]) OF
            // 	0:	tmp[63:0] := src[63:0]
            // 	1:	tmp[63:0] := src[127:64]
            // 	2:	tmp[63:0] := src[191:128]
            // 	3:	tmp[63:0] := src[255:192]
            // 	ESAC
            // 	RETURN tmp[63:0]
            // }
            // dst[63:0] := SELECT4(a[255:0], imm8[1:0])
            // dst[127:64] := SELECT4(a[255:0], imm8[3:2])
            // dst[191:128] := SELECT4(a[255:0], imm8[5:4])
            // dst[255:192] := SELECT4(a[255:0], imm8[7:6])
            foreach (byte control in new byte[] { 0, 1, 2, 3, 0x23, 0xA3, 0x10 }) {
                WriteLineFormat(tw, indent, "Permute4x64 - control={0} (0x{0:X}):", control);
                WriteLineFormat(tw, indentNext, "Permute4x64(srcT_256_double, control):\t{0}", Avx2.Permute4x64(srcT_256_double, control));
                WriteLineFormat(tw, indentNext, "Permute4x64(srcT_256_long, control):\t{0}", Avx2.Permute4x64(srcT_256_long, control));
            }

            // PermuteVar8x32(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
            // VPERMD ymm, ymm/m256, ymm
            // Shuffle 32-bit integers in a across lanes using the corresponding index in idx, and store the results in dst.
            // FOR j := 0 to 7
            // 	i := j*32
            // 	id := idx[i+2:i]*32
            // 	dst[i+31:i] := a[id+31:id]
            // ENDFOR
            // PermuteVar8x32(Vector256<Single>, Vector256<Int32>)	__m256 _mm256_permutevar8x32_ps (__m256 a, __m256i idx)
            // VPERMPS ymm, ymm/m256, ymm
            // PermuteVar8x32(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_permutevar8x32_epi32 (__m256i a, __m256i idx)
            // VPERMD ymm, ymm/m256, ymm
            WriteLineFormat(tw, indent, "PermuteVar8x32(srcT_256_float, srcQ_256_int):\t{0}", Avx2.PermuteVar8x32(srcT_256_float, srcQ_256_int));
            WriteLineFormat(tw, indent, "PermuteVar8x32(srcT_256_int, srcQ_256_int):\t{0}", Avx2.PermuteVar8x32(srcT_256_int, srcQ_256_int));
            WriteLineFormat(tw, indent, "PermuteVar8x32(srcT_256_uint, srcQ_256_uint):\t{0}", Avx2.PermuteVar8x32(srcT_256_uint, srcQ_256_uint));
            WriteLineFormat(tw, indent, "PermuteVar8x32(srcT_256_float, src1_256_int):\t{0}", Avx2.PermuteVar8x32(srcT_256_float, src1_256_int));
            WriteLineFormat(tw, indent, "PermuteVar8x32(srcT_256_int, src1_256_int):\t{0}", Avx2.PermuteVar8x32(srcT_256_int, src1_256_int));
            WriteLineFormat(tw, indent, "PermuteVar8x32(srcT_256_uint, src1_256_uint):\t{0}", Avx2.PermuteVar8x32(srcT_256_uint, src1_256_uint));

            // ShiftLeftLogical(Vector256<Int16>, Byte)	__m256i _mm256_slli_epi16 (__m256i a, int imm8)
            // VPSLLW ymm, ymm, imm8
            // Shift packed 16-bit integers in a left by imm8 while shifting in zeros, and store the results in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	IF imm8[7:0] > 15
            // 		dst[i+15:i] := 0
            // 	ELSE
            // 		dst[i+15:i] := ZeroExtend16(a[i+15:i] << imm8[7:0])
            // 	FI
            // ENDFOR
            // ShiftLeftLogical(Vector256<Int16>, Vector128<Int16>)	__m256i _mm256_sll_epi16 (__m256i a, __m128i count)
            // VPSLLW ymm, ymm, xmm/m128
            // Shift packed 16-bit integers in a left by count while shifting in zeros, and store the results in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	IF count[63:0] > 15
            // 		dst[i+15:i] := 0
            // 	ELSE
            // 		dst[i+15:i] := ZeroExtend16(a[i+15:i] << count[63:0])
            // 	FI
            // ENDFOR
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
            foreach (byte count in new byte[] { 1 }) {
                WriteLineFormat(tw, indent, "ShiftLeftLogical - count={0} (0x{0:X}):", count);
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical(srcT_256_ushort, Vector128.CreateScalar((ushort)count)):\t{0}", Avx2.ShiftLeftLogical(srcT_256_ushort, Vector128.CreateScalar((ushort)count)));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical(srcT_256_ushort, count):\t{0}", Avx2.ShiftLeftLogical(srcT_256_ushort, count));
                //Debugger.Break();
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical(srcT_256_uint, count):\t{0}", Avx2.ShiftLeftLogical(srcT_256_uint, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical(srcT_256_ulong, count):\t{0}", Avx2.ShiftLeftLogical(srcT_256_ulong, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical(srcT_256_short, count):\t{0}", Avx2.ShiftLeftLogical(srcT_256_short, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical(srcT_256_int, count):\t{0}", Avx2.ShiftLeftLogical(srcT_256_int, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical(srcT_256_long, count):\t{0}", Avx2.ShiftLeftLogical(srcT_256_long, count));
            }

            // ShiftLeftLogical128BitLane(Vector256<Byte>, Byte)	__m256i _mm256_bslli_epi128 (__m256i a, const int imm8)
            // VPSLLDQ ymm, ymm, imm8
            // Shift 128-bit lanes in a left by imm8 bytes while shifting in zeros, and store the results in dst. (将一个128位的通道左移imm8字节，同时移入0，并将结果存储在dst。)
            // tmp := imm8[7:0]
            // IF tmp > 15
            // 	tmp := 16
            // FI
            // dst[127:0] := a[127:0] << (tmp*8)
            // dst[255:128] := a[255:128] << (tmp*8)
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
            foreach (byte count in new byte[] { 1, 15 }) {
                WriteLineFormat(tw, indent, "ShiftLeftLogical128BitLane - count={0} (0x{0:X}):", count);
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical128BitLane(srcT_256_byte, count):\t{0}", Avx2.ShiftLeftLogical128BitLane(srcT_256_byte, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical128BitLane(srcT_256_ushort, count):\t{0}", Avx2.ShiftLeftLogical128BitLane(srcT_256_ushort, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical128BitLane(srcT_256_uint, count):\t{0}", Avx2.ShiftLeftLogical128BitLane(srcT_256_uint, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical128BitLane(srcT_256_ulong, count):\t{0}", Avx2.ShiftLeftLogical128BitLane(srcT_256_ulong, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical128BitLane(srcT_256_sbyte, count):\t{0}", Avx2.ShiftLeftLogical128BitLane(srcT_256_sbyte, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical128BitLane(srcT_256_short, count):\t{0}", Avx2.ShiftLeftLogical128BitLane(srcT_256_short, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical128BitLane(srcT_256_int, count):\t{0}", Avx2.ShiftLeftLogical128BitLane(srcT_256_int, count));
                WriteLineFormat(tw, indentNext, "ShiftLeftLogical128BitLane(srcT_256_long, count):\t{0}", Avx2.ShiftLeftLogical128BitLane(srcT_256_long, count));
            }

            // ShiftLeftLogicalVariable(Vector128<Int32>, Vector128<UInt32>)	__m128i _mm_sllv_epi32 (__m128i a, __m128i count)
            // VPSLLVD xmm, xmm, xmm/m128
            // Shift packed 32-bit integers in a left by the amount specified by the corresponding element in count while shifting in zeros, and store the results in dst.
            // Operation
            // FOR j := 0 to 3
            // 	i := j*32
            // 	IF count[i+31:i] < 32
            // 		dst[i+31:i] := ZeroExtend32(a[i+31:i] << count[i+31:i])
            // 	ELSE
            // 		dst[i+31:i] := 0
            // 	FI
            // ENDFOR
            // ShiftLeftLogicalVariable(Vector128<Int64>, Vector128<UInt64>)	__m128i _mm_sllv_epi64 (__m128i a, __m128i count)
            // VPSLLVQ xmm, xmm, xmm/m128
            // ShiftLeftLogicalVariable(Vector128<UInt32>, Vector128<UInt32>)	__m128i _mm_sllv_epi32 (__m128i a, __m128i count)
            // VPSLLVD xmm, xmm, xmm/m128
            // ShiftLeftLogicalVariable(Vector128<UInt64>, Vector128<UInt64>)	__m128i _mm_sllv_epi64 (__m128i a, __m128i count)
            // VPSLLVQ xmm, xmm, xmm/m128
            // Shift packed 64-bit integers in a left by the amount specified by the corresponding element in count while shifting in zeros, and store the results in dst.
            // FOR j := 0 to 1
            // 	i := j*64
            // 	IF count[i+63:i] < 64
            // 		dst[i+63:i] := ZeroExtend64(a[i+63:i] << count[i+63:i])
            // 	ELSE
            // 		dst[i+63:i] := 0
            // 	FI
            // ENDFOR
            WriteLineFormat(tw, indent, "ShiftLeftLogicalVariable(src2_128_int, srcQ_128_uint):\t{0}", Avx2.ShiftLeftLogicalVariable(src2_128_int, srcQ_128_uint));
            WriteLineFormat(tw, indent, "ShiftLeftLogicalVariable(src2_128_long, srcQ_128_ulong):\t{0}", Avx2.ShiftLeftLogicalVariable(src2_128_long, srcQ_128_ulong));

            // ShiftLeftLogicalVariable(Vector256<Int32>, Vector256<UInt32>)	__m256i _mm256_sllv_epi32 (__m256i a, __m256i count)
            // VPSLLVD ymm, ymm, ymm/m256
            // ShiftLeftLogicalVariable(Vector256<Int64>, Vector256<UInt64>)	__m256i _mm256_sllv_epi64 (__m256i a, __m256i count)
            // VPSLLVQ ymm, ymm, ymm/m256
            // ShiftLeftLogicalVariable(Vector256<UInt32>, Vector256<UInt32>)	__m256i _mm256_sllv_epi32 (__m256i a, __m256i count)
            // VPSLLVD ymm, ymm, ymm/m256
            // ShiftLeftLogicalVariable(Vector256<UInt64>, Vector256<UInt64>)	__m256i _mm256_sllv_epi64 (__m256i a, __m256i count)
            // VPSLLVQ ymm, ymm, ymm/m256
            // Shift packed 64-bit integers in a left by the amount specified by the corresponding element in count while shifting in zeros, and store the results in dst.
            // FOR j := 0 to 3
            // 	i := j*64
            // 	IF count[i+63:i] < 64
            // 		dst[i+63:i] := ZeroExtend64(a[i+63:i] << count[i+63:i])
            // 	ELSE
            // 		dst[i+63:i] := 0
            // 	FI
            // ENDFOR
            WriteLineFormat(tw, indent, "ShiftLeftLogicalVariable(src2_256_int, srcQ_256_uint):\t{0}", Avx2.ShiftLeftLogicalVariable(src2_256_int, srcQ_256_uint));
            WriteLineFormat(tw, indent, "ShiftLeftLogicalVariable(src2_256_long, srcQ_256_ulong):\t{0}", Avx2.ShiftLeftLogicalVariable(src2_256_long, srcQ_256_ulong));

            // ShiftRightArithmetic(Vector256<Int16>, Byte)	__m256i _mm256_srai_epi16 (__m256i a, int imm8)
            // VPSRAW ymm, ymm, imm8
            // Shift packed 16-bit integers in a right by imm8 while shifting in sign bits, and store the results in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	IF imm8[7:0] > 15
            // 		dst[i+15:i] := (a[i+15] ? 0xFFFF : 0x0)
            // 	ELSE
            // 		dst[i+15:i] := SignExtend16(a[i+15:i] >> imm8[7:0])
            // 	FI
            // ENDFOR
            // dst[MAX:256] := 0
            // ShiftRightArithmetic(Vector256<Int16>, Vector128<Int16>)	_mm256_sra_epi16 (__m256i a, __m128i count)
            // VPSRAW ymm, ymm, xmm/m128
            // Shift packed 16-bit integers in a right by count while shifting in sign bits, and store the results in dst.
            // FOR j := 0 to 15
            // 	i := j*16
            // 	IF count[63:0] > 15
            // 		dst[i+15:i] := (a[i+15] ? 0xFFFF : 0x0)
            // 	ELSE
            // 		dst[i+15:i] := SignExtend16(a[i+15:i] >> count[63:0])
            // 	FI
            // ENDFOR
            // ShiftRightArithmetic(Vector256<Int32>, Byte)	__m256i _mm256_srai_epi32 (__m256i a, int imm8)
            // VPSRAD ymm, ymm, imm8
            // ShiftRightArithmetic(Vector256<Int32>, Vector128<Int32>)	_mm256_sra_epi32 (__m256i a, __m128i count)
            // VPSRAD ymm, ymm, xmm/m128
            foreach (byte count in new byte[] { 1 }) {
                WriteLineFormat(tw, indent, "ShiftRightArithmetic - count={0} (0x{0:X}):", count);
                WriteLineFormat(tw, indentNext, "ShiftRightArithmetic(srcT_256_ushort, Vector128.CreateScalar((ushort)count)):\t{0}", Avx2.ShiftRightArithmetic(srcT_256_short, Vector128.CreateScalar((short)count)));
                WriteLineFormat(tw, indentNext, "ShiftRightArithmetic(srcT_256_short, count):\t{0}", Avx2.ShiftRightArithmetic(srcT_256_short, count));
                WriteLineFormat(tw, indentNext, "ShiftRightArithmetic(srcT_256_int, count):\t{0}", Avx2.ShiftRightArithmetic(srcT_256_int, count));
                //WriteLineFormat(tw, indentNext, "ShiftRightArithmetic(srcT_256_long, count):\t{0}", Avx2.ShiftRightArithmetic(srcT_256_long, count));
            }

            // ShiftRightArithmeticVariable(Vector128<Int32>, Vector128<UInt32>)	__m128i _mm_srav_epi32 (__m128i a, __m128i count)
            // VPSRAVD xmm, xmm, xmm/m128
            // Shift packed 32-bit integers in a right by the amount specified by the corresponding element in count while shifting in sign bits, and store the results in dst.
            // FOR j := 0 to 3
            // 	i := j*32
            // 	IF count[i+31:i] < 32
            // 		dst[i+31:i] := SignExtend32(a[i+31:i] >> count[i+31:i])
            // 	ELSE
            // 		dst[i+31:i] := (a[i+31] ? 0xFFFFFFFF : 0)
            // 	FI
            // ENDFOR
            // dst[MAX:128] := 0
            // ShiftRightArithmeticVariable(Vector256<Int32>, Vector256<UInt32>)	__m256i _mm256_srav_epi32 (__m256i a, __m256i count)
            // VPSRAVD ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "ShiftRightArithmeticVariable(src2_128_int, srcQ_128_uint):\t{0}", Avx2.ShiftRightArithmeticVariable(src2_128_int, srcQ_128_uint));
            WriteLineFormat(tw, indent, "ShiftRightArithmeticVariable(src2_256_int, srcQ_256_uint):\t{0}", Avx2.ShiftRightArithmeticVariable(src2_256_int, srcQ_256_uint));
            //WriteLineFormat(tw, indent, "ShiftRightArithmeticVariable(src2_256_long, srcQ_256_ulong):\t{0}", Avx2.ShiftRightArithmeticVariable(src2_256_long, srcQ_256_ulong));
            WriteLineFormat(tw, indent, "ShiftRightArithmeticVariable(srcT_256_int, srcQ_256_uint):\t{0}", Avx2.ShiftRightArithmeticVariable(srcT_256_int, srcQ_256_uint));

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
            foreach (byte count in new byte[] { 1 }) {
                WriteLineFormat(tw, indent, "ShiftRightLogical - count={0} (0x{0:X}):", count);
                WriteLineFormat(tw, indentNext, "ShiftRightLogical(srcT_256_ushort, Vector128.CreateScalar((ushort)count)):\t{0}", Avx2.ShiftRightLogical(srcT_256_ushort, Vector128.CreateScalar((ushort)count)));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical(srcT_256_ushort, count):\t{0}", Avx2.ShiftRightLogical(srcT_256_ushort, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical(srcT_256_uint, count):\t{0}", Avx2.ShiftRightLogical(srcT_256_uint, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical(srcT_256_ulong, count):\t{0}", Avx2.ShiftRightLogical(srcT_256_ulong, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical(srcT_256_short, count):\t{0}", Avx2.ShiftRightLogical(srcT_256_short, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical(srcT_256_int, count):\t{0}", Avx2.ShiftRightLogical(srcT_256_int, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical(srcT_256_long, count):\t{0}", Avx2.ShiftRightLogical(srcT_256_long, count));
            }

            // ShiftRightLogical128BitLane(Vector256<Byte>, Byte)	__m256i _mm256_bsrli_epi128 (__m256i a, const int imm8)
            // VPSRLDQ ymm, ymm, imm8
            // Shift 128-bit lanes in a right by imm8 bytes while shifting in zeros, and store the results in dst.
            // tmp := imm8[7:0]
            // IF tmp > 15
            // 	tmp := 16
            // FI
            // dst[127:0] := a[127:0] >> (tmp*8)
            // dst[255:128] := a[255:128] >> (tmp*8)
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
            foreach (byte count in new byte[] { 1, 15 }) {
                WriteLineFormat(tw, indent, "ShiftRightLogical128BitLane - count={0} (0x{0:X}):", count);
                WriteLineFormat(tw, indentNext, "ShiftRightLogical128BitLane(srcT_256_byte, count):\t{0}", Avx2.ShiftRightLogical128BitLane(srcT_256_byte, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical128BitLane(srcT_256_ushort, count):\t{0}", Avx2.ShiftRightLogical128BitLane(srcT_256_ushort, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical128BitLane(srcT_256_uint, count):\t{0}", Avx2.ShiftRightLogical128BitLane(srcT_256_uint, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical128BitLane(srcT_256_ulong, count):\t{0}", Avx2.ShiftRightLogical128BitLane(srcT_256_ulong, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical128BitLane(srcT_256_sbyte, count):\t{0}", Avx2.ShiftRightLogical128BitLane(srcT_256_sbyte, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical128BitLane(srcT_256_short, count):\t{0}", Avx2.ShiftRightLogical128BitLane(srcT_256_short, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical128BitLane(srcT_256_int, count):\t{0}", Avx2.ShiftRightLogical128BitLane(srcT_256_int, count));
                WriteLineFormat(tw, indentNext, "ShiftRightLogical128BitLane(srcT_256_long, count):\t{0}", Avx2.ShiftRightLogical128BitLane(srcT_256_long, count));
            }

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
            WriteLineFormat(tw, indent, "ShiftRightLogicalVariable(src2_128_int, srcQ_128_uint):\t{0}", Avx2.ShiftRightLogicalVariable(src2_128_int, srcQ_128_uint));
            WriteLineFormat(tw, indent, "ShiftRightLogicalVariable(src2_256_int, srcQ_256_uint):\t{0}", Avx2.ShiftRightLogicalVariable(src2_256_int, srcQ_256_uint));
            WriteLineFormat(tw, indent, "ShiftRightLogicalVariable(src2_256_long, srcQ_256_ulong):\t{0}", Avx2.ShiftRightLogicalVariable(src2_256_long, srcQ_256_ulong));
            WriteLineFormat(tw, indent, "ShiftRightLogicalVariable(srcT_256_int, srcQ_256_uint):\t{0}", Avx2.ShiftRightLogicalVariable(srcT_256_int, srcQ_256_uint));

            // Shuffle(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
            // VPSHUFB ymm, ymm, ymm/m256
            // Shuffle 8-bit integers in a within 128-bit lanes according to shuffle control mask in the corresponding 8-bit element of b, and store the results in dst. (根据洗牌控制掩码在b的相应8位元素中对a中的8位整数在128位通道中进行洗牌，并将结果存储在dst中。)
            // FOR j := 0 to 15
            // 	i := j*8
            // 	IF b[i+7] == 1
            // 		dst[i+7:i] := 0
            // 	ELSE
            // 		index[3:0] := b[i+3:i]
            // 		dst[i+7:i] := a[index*8+7:index*8]
            // 	FI
            // 	IF b[128+i+7] == 1
            // 		dst[128+i+7:128+i] := 0
            // 	ELSE
            // 		index[3:0] := b[128+i+3:128+i]
            // 		dst[128+i+7:128+i] := a[128+index*8+7:128+index*8]
            // 	FI
            // ENDFOR
            // Shuffle(Vector256<Int32>, Byte)	__m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
            // VPSHUFD ymm, ymm/m256, imm8
            // Shuffle 32-bit integers in a within 128-bit lanes using the control in imm8, and store the results in dst. (使用imm8中的控制在128位通道内洗刷32位整数，并将结果存储在dst中。)
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
            // Shuffle(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_shuffle_epi8 (__m256i a, __m256i b)
            // VPSHUFB ymm, ymm, ymm/m256
            // Shuffle(Vector256<UInt32>, Byte)	__m256i _mm256_shuffle_epi32 (__m256i a, const int imm8)
            // VPSHUFD ymm, ymm/m256, imm8
            WriteLineFormat(tw, indent, "Shuffle(srcT_256_byte, srcQ_256_byte):\t{0}", Avx2.Shuffle(srcT_256_byte, srcQ_256_byte));
            WriteLineFormat(tw, indent, "Shuffle(srcT_256_sbyte, srcQ_256_sbyte):\t{0}", Avx2.Shuffle(srcT_256_sbyte, srcQ_256_sbyte));
            // Shuffle int - control: Reverse order based on 128 bits.
            WriteLineFormat(tw, indent, "Shuffle(srcT_256_int, 0b0001_1011):\t{0}", Avx2.Shuffle(srcT_256_int, 0b0001_1011));
            WriteLineFormat(tw, indent, "Shuffle(srcT_256_uint, 0b0001_1011):\t{0}", Avx2.Shuffle(srcT_256_uint, 0b0001_1011));
            //Debugger.Break();

            // ShuffleHigh(Vector256<Int16>, Byte)	__m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)
            // VPSHUFHW ymm, ymm/m256, imm8
            // ShuffleHigh(Vector256<UInt16>, Byte)	__m256i _mm256_shufflehi_epi16 (__m256i a, const int imm8)
            // VPSHUFHW ymm, ymm/m256, imm8
            // Shuffle 16-bit integers in the high 64 bits of 128-bit lanes of a using the control in imm8. Store the results in the high 64 bits of 128-bit lanes of dst, with the low 64 bits of 128-bit lanes being copied from from a to dst.
            // dst[63:0] := a[63:0]
            // dst[79:64] := (a >> (imm8[1:0] * 16))[79:64]
            // dst[95:80] := (a >> (imm8[3:2] * 16))[79:64]
            // dst[111:96] := (a >> (imm8[5:4] * 16))[79:64]
            // dst[127:112] := (a >> (imm8[7:6] * 16))[79:64]
            // dst[191:128] := a[191:128]
            // dst[207:192] := (a >> (imm8[1:0] * 16))[207:192]
            // dst[223:208] := (a >> (imm8[3:2] * 16))[207:192]
            // dst[239:224] := (a >> (imm8[5:4] * 16))[207:192]
            // dst[255:240] := (a >> (imm8[7:6] * 16))[207:192]
            WriteLineFormat(tw, indent, "ShuffleHigh(srcT_256_short, 0b0001_1011):\t{0}", Avx2.ShuffleHigh(srcT_256_short, 0b0001_1011));

            // ShuffleLow(Vector256<Int16>, Byte)	__m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)
            // VPSHUFLW ymm, ymm/m256, imm8
            // ShuffleLow(Vector256<UInt16>, Byte)	__m256i _mm256_shufflelo_epi16 (__m256i a, const int imm8)
            // VPSHUFLW ymm, ymm/m256, imm8
            // Shuffle 16-bit integers in the low 64 bits of 128-bit lanes of a using the control in imm8. Store the results in the low 64 bits of 128-bit lanes of dst, with the high 64 bits of 128-bit lanes being copied from from a to dst.
            // dst[15:0] := (a >> (imm8[1:0] * 16))[15:0]
            // dst[31:16] := (a >> (imm8[3:2] * 16))[15:0]
            // dst[47:32] := (a >> (imm8[5:4] * 16))[15:0]
            // dst[63:48] := (a >> (imm8[7:6] * 16))[15:0]
            // dst[127:64] := a[127:64]
            // dst[143:128] := (a >> (imm8[1:0] * 16))[143:128]
            // dst[159:144] := (a >> (imm8[3:2] * 16))[143:128]
            // dst[175:160] := (a >> (imm8[5:4] * 16))[143:128]
            // dst[191:176] := (a >> (imm8[7:6] * 16))[143:128]
            // dst[255:192] := a[255:192]
            WriteLineFormat(tw, indent, "ShuffleLow(srcT_256_short, 0b0001_1011):\t{0}", Avx2.ShuffleLow(srcT_256_short, 0b0001_1011));

            // Sign(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_sign_epi16 (__m256i a, __m256i b)
            // VPSIGNW ymm, ymm, ymm/m256
            //  Negate packed signed 16-bit integers in a when the corresponding signed 16-bit integer in b is negative, and store the results in dst. Element in dst are zeroed out when the corresponding element in b is zero. (当b中对应的16位有符号整数为负数时，对a中的16位有符号整数进行否定，并将结果存储在dst中。当b中的相应元素为零时，dst中的元素被清零。)
            //  FOR j := 0 to 15
            //  	i := j*16
            //  	IF b[i+15:i] < 0
            //  		dst[i+15:i] := -(a[i+15:i])
            //  	ELSE IF b[i+15:i] == 0
            //  		dst[i+15:i] := 0
            //  	ELSE
            //  		dst[i+15:i] := a[i+15:i]
            //  	FI
            //  ENDFOR
            // Sign(Vector256<Int32>, Vector256<Int32>)	__m256i _mm256_sign_epi32 (__m256i a, __m256i b)
            // VPSIGND ymm, ymm, ymm/m256
            // Sign(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_sign_epi8 (__m256i a, __m256i b)
            // VPSIGNB ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "Sign(srcQ_256_sbyte, srcT_256_sbyte):\t{0}", Avx2.Sign(srcQ_256_sbyte, srcT_256_sbyte));
            WriteLineFormat(tw, indent, "Sign(srcQ_256_short, srcT_256_short):\t{0}", Avx2.Sign(srcQ_256_short, srcT_256_short));
            WriteLineFormat(tw, indent, "Sign(srcQ_256_int, srcT_256_int):\t{0}", Avx2.Sign(srcQ_256_int, srcT_256_int));

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
            WriteLineFormat(tw, indent, "Subtract(srcT_256_byte, src2_256_byte):\t{0}", Avx2.Subtract(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "Subtract(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.Subtract(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "Subtract(srcT_256_uint, src2_256_uint):\t{0}", Avx2.Subtract(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "Subtract(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.Subtract(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "Subtract(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.Subtract(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "Subtract(srcT_256_short, src2_256_short):\t{0}", Avx2.Subtract(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "Subtract(srcT_256_int, src2_256_int):\t{0}", Avx2.Subtract(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "Subtract(srcT_256_long, src2_256_long):\t{0}", Avx2.Subtract(srcT_256_long, src2_256_long));

            // SubtractSaturate(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_subs_epu8 (__m256i a, __m256i b)
            // VPSUBUSB ymm, ymm, ymm/m256
            // SubtractSaturate(Vector256<Int16>, Vector256<Int16>)	__m256i _mm256_subs_epi16 (__m256i a, __m256i b)
            // VPSUBSW ymm, ymm, ymm/m256
            // SubtractSaturate(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_subs_epi8 (__m256i a, __m256i b)
            // VPSUBSB ymm, ymm, ymm/m256
            // SubtractSaturate(Vector256<UInt16>, Vector256<UInt16>)	__m256i _mm256_subs_epu16 (__m256i a, __m256i b)
            // VPSUBUSW ymm, ymm, ymm/m256
            WriteLineFormat(tw, indent, "SubtractSaturate(srcT_256_byte, src2_256_byte):\t{0}", Avx2.SubtractSaturate(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "SubtractSaturate(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.SubtractSaturate(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "SubtractSaturate(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.SubtractSaturate(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "SubtractSaturate(srcT_256_short, src2_256_short):\t{0}", Avx2.SubtractSaturate(srcT_256_short, src2_256_short));

            // SumAbsoluteDifferences(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_sad_epu8 (__m256i a, __m256i b)
            // VPSADBW ymm, ymm, ymm/m256
            // Compute the absolute differences of packed unsigned 8-bit integers in a and b, then horizontally sum each consecutive 8 differences to produce four unsigned 16-bit integers, and pack these unsigned 16-bit integers in the low 16 bits of 64-bit elements in dst. (计算a和b中打包的无符号8位整数的绝对差值，然后将每个连续的8位差值水平相加，产生4个无符号16位整数，并将这些无符号16位整数打包到dst中64位元素的低16位。)
            // FOR j := 0 to 31
            // 	i := j*8
            // 	tmp[i+7:i] := ABS(a[i+7:i] - b[i+7:i])
            // ENDFOR
            // FOR j := 0 to 3
            // 	i := j*64
            // 	dst[i+15:i] := tmp[i+7:i] + tmp[i+15:i+8] + tmp[i+23:i+16] + tmp[i+31:i+24] + 
            // 	               tmp[i+39:i+32] + tmp[i+47:i+40] + tmp[i+55:i+48] + tmp[i+63:i+56]
            // 	dst[i+63:i+16] := 0
            // ENDFOR
            WriteLineFormat(tw, indent, "SumAbsoluteDifferences(srcT_256_byte, src2_256_byte):\t{0}", Avx2.SumAbsoluteDifferences(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "SumAbsoluteDifferences(srcQ_256_byte, src2_256_byte):\t{0}", Avx2.SumAbsoluteDifferences(srcQ_256_byte, src2_256_byte));

            // UnpackHigh(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_unpackhi_epi8 (__m256i a, __m256i b)
            // VPUNPCKHBW ymm, ymm, ymm/m256
            // Unpack and interleave 8-bit integers from the high half of each 128-bit lane in a and b, and store the results in dst.
            // DEFINE INTERLEAVE_HIGH_BYTES(src1[127:0], src2[127:0]) {
            // 	dst[7:0] := src1[71:64] 
            // 	dst[15:8] := src2[71:64] 
            // 	dst[23:16] := src1[79:72] 
            // 	dst[31:24] := src2[79:72] 
            // 	dst[39:32] := src1[87:80] 
            // 	dst[47:40] := src2[87:80] 
            // 	dst[55:48] := src1[95:88] 
            // 	dst[63:56] := src2[95:88] 
            // 	dst[71:64] := src1[103:96] 
            // 	dst[79:72] := src2[103:96] 
            // 	dst[87:80] := src1[111:104] 
            // 	dst[95:88] := src2[111:104] 
            // 	dst[103:96] := src1[119:112] 
            // 	dst[111:104] := src2[119:112] 
            // 	dst[119:112] := src1[127:120] 
            // 	dst[127:120] := src2[127:120] 
            // 	RETURN dst[127:0]	
            // }
            // dst[127:0] := INTERLEAVE_HIGH_BYTES(a[127:0], b[127:0])
            // dst[255:128] := INTERLEAVE_HIGH_BYTES(a[255:128], b[255:128])
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
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_byte, src2_256_byte):\t{0}", Avx2.UnpackHigh(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.UnpackHigh(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_uint, src2_256_uint):\t{0}", Avx2.UnpackHigh(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.UnpackHigh(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.UnpackHigh(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_short, src2_256_short):\t{0}", Avx2.UnpackHigh(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_int, src2_256_int):\t{0}", Avx2.UnpackHigh(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "UnpackHigh(srcT_256_long, src2_256_long):\t{0}", Avx2.UnpackHigh(srcT_256_long, src2_256_long));

            // UnpackLow(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_unpacklo_epi8 (__m256i a, __m256i b)
            // VPUNPCKLBW ymm, ymm, ymm/m256
            // Unpack and interleave 8-bit integers from the low half of each 128-bit lane in a and b, and store the results in dst.
            // DEFINE INTERLEAVE_BYTES(src1[127:0], src2[127:0]) {
            // 	dst[7:0] := src1[7:0] 
            // 	dst[15:8] := src2[7:0] 
            // 	dst[23:16] := src1[15:8] 
            // 	dst[31:24] := src2[15:8] 
            // 	dst[39:32] := src1[23:16] 
            // 	dst[47:40] := src2[23:16] 
            // 	dst[55:48] := src1[31:24] 
            // 	dst[63:56] := src2[31:24] 
            // 	dst[71:64] := src1[39:32]
            // 	dst[79:72] := src2[39:32] 
            // 	dst[87:80] := src1[47:40] 
            // 	dst[95:88] := src2[47:40] 
            // 	dst[103:96] := src1[55:48] 
            // 	dst[111:104] := src2[55:48] 
            // 	dst[119:112] := src1[63:56] 
            // 	dst[127:120] := src2[63:56] 
            // 	RETURN dst[127:0]
            // }
            // dst[127:0] := INTERLEAVE_BYTES(a[127:0], b[127:0])
            // dst[255:128] := INTERLEAVE_BYTES(a[255:128], b[255:128])
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
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_byte, src2_256_byte):\t{0}", Avx2.UnpackLow(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.UnpackLow(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_uint, src2_256_uint):\t{0}", Avx2.UnpackLow(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.UnpackLow(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.UnpackLow(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_short, src2_256_short):\t{0}", Avx2.UnpackLow(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_int, src2_256_int):\t{0}", Avx2.UnpackLow(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "UnpackLow(srcT_256_long, src2_256_long):\t{0}", Avx2.UnpackLow(srcT_256_long, src2_256_long));

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
            WriteLineFormat(tw, indent, "Xor(srcT_256_byte, src2_256_byte):\t{0}", Avx2.Xor(srcT_256_byte, src2_256_byte));
            WriteLineFormat(tw, indent, "Xor(srcT_256_ushort, src2_256_ushort):\t{0}", Avx2.Xor(srcT_256_ushort, src2_256_ushort));
            WriteLineFormat(tw, indent, "Xor(srcT_256_uint, src2_256_uint):\t{0}", Avx2.Xor(srcT_256_uint, src2_256_uint));
            WriteLineFormat(tw, indent, "Xor(srcT_256_ulong, src2_256_ulong):\t{0}", Avx2.Xor(srcT_256_ulong, src2_256_ulong));
            WriteLineFormat(tw, indent, "Xor(srcT_256_sbyte, src2_256_sbyte):\t{0}", Avx2.Xor(srcT_256_sbyte, src2_256_sbyte));
            WriteLineFormat(tw, indent, "Xor(srcT_256_short, src2_256_short):\t{0}", Avx2.Xor(srcT_256_short, src2_256_short));
            WriteLineFormat(tw, indent, "Xor(srcT_256_int, src2_256_int):\t{0}", Avx2.Xor(srcT_256_int, src2_256_int));
            WriteLineFormat(tw, indent, "Xor(srcT_256_long, src2_256_long):\t{0}", Avx2.Xor(srcT_256_long, src2_256_long));

        }
    }
}

