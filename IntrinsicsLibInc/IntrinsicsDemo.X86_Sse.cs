using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Zyl.VectorTraits;

namespace IntrinsicsLib {
    partial class IntrinsicsDemo {

        /// <summary>
        /// Run x86 Avx. https://docs.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.sse?view=net-7.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Sse(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            if (Sse.IsSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Sse.IsSupported:\t{0}", Sse.IsSupported));
            if (!Sse.IsSupported) {
                return;
            }

            // Add(Vector128<Single>, Vector128<Single>)	__m128 _mm_add_ps (__m128 a, __m128 b); ADDPS xmm, xmm/m128
            // AddScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_add_ss (__m128 a, __m128 b); ADDSS xmm, xmm/m32
            // And(Vector128<Single>, Vector128<Single>)	__m128 _mm_and_ps (__m128 a, __m128 b); ANDPS xmm, xmm/m128
            // AndNot(Vector128<Single>, Vector128<Single>)	__m128 _mm_andnot_ps (__m128 a, __m128 b); ANDNPS xmm, xmm/m128

            // CompareEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpeq_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(0)

            // CompareGreaterThan(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpgt_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(6)

            // CompareGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpge_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(5)
            WriteLine(writer, indentNext, "CompareGreaterThanOrEqual(Vector128s<Single>.V1, Vector128s<Single>.Demo):\t{0}", Sse.CompareGreaterThanOrEqual(Vector128s<Single>.V1, Vector128s<Single>.Demo));
            WriteLine(writer, indentNext, "CompareGreaterThanOrEqual(Vector128s<Single>.V1, Vector128s<Single>.NaN):\t{0}", Sse.CompareGreaterThanOrEqual(Vector128s<Single>.V1, Vector128s<Single>.NaN));

            // CompareLessThan(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmplt_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(1)
            // CompareLessThanOrEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmple_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(2)
            // CompareNotEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpneq_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(4)
            // CompareNotGreaterThan(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpngt_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(2)
            // CompareNotGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpnge_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(1)
            // CompareNotLessThan(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpnlt_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(5)
            // CompareNotLessThanOrEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpnle_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(6)
            // CompareOrdered(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpord_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(7)
            // CompareScalarEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpeq_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(0)
            // CompareScalarGreaterThan(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpgt_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(6)
            // CompareScalarGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpge_ss (__m128 a, __m128 b); CMPPS xmm, xmm/m32, imm8(5)
            // CompareScalarLessThan(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmplt_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(1)
            // CompareScalarLessThanOrEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmple_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(2)
            // CompareScalarNotEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpneq_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(4)
            // CompareScalarNotGreaterThan(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpngt_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(2)
            // CompareScalarNotGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpnge_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(1)
            // CompareScalarNotLessThan(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpnlt_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(5)
            // CompareScalarNotLessThanOrEqual(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpnle_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(6)
            // CompareScalarOrdered(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpord_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(7)
            // CompareScalarOrderedEqual(Vector128<Single>, Vector128<Single>)	int _mm_comieq_ss (__m128 a, __m128 b); COMISS xmm, xmm/m32
            // CompareScalarOrderedGreaterThan(Vector128<Single>, Vector128<Single>)	int _mm_comigt_ss (__m128 a, __m128 b); COMISS xmm, xmm/m32
            // CompareScalarOrderedGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)	int _mm_comige_ss (__m128 a, __m128 b); COMISS xmm, xmm/m32
            // CompareScalarOrderedLessThan(Vector128<Single>, Vector128<Single>)	int _mm_comilt_ss (__m128 a, __m128 b); COMISS xmm, xmm/m32
            // CompareScalarOrderedLessThanOrEqual(Vector128<Single>, Vector128<Single>)	int _mm_comile_ss (__m128 a, __m128 b); COMISS xmm, xmm/m32
            // CompareScalarOrderedNotEqual(Vector128<Single>, Vector128<Single>)	int _mm_comineq_ss (__m128 a, __m128 b); COMISS xmm, xmm/m32
            // CompareScalarUnordered(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpunord_ss (__m128 a, __m128 b); CMPSS xmm, xmm/m32, imm8(3)
            // CompareScalarUnorderedEqual(Vector128<Single>, Vector128<Single>)	int _mm_ucomieq_ss (__m128 a, __m128 b); UCOMISS xmm, xmm/m32
            // CompareScalarUnorderedGreaterThan(Vector128<Single>, Vector128<Single>)	int _mm_ucomigt_ss (__m128 a, __m128 b); UCOMISS xmm, xmm/m32
            // CompareScalarUnorderedGreaterThanOrEqual(Vector128<Single>, Vector128<Single>)	int _mm_ucomige_ss (__m128 a, __m128 b); UCOMISS xmm, xmm/m32
            // CompareScalarUnorderedLessThan(Vector128<Single>, Vector128<Single>)	int _mm_ucomilt_ss (__m128 a, __m128 b); UCOMISS xmm, xmm/m32
            // CompareScalarUnorderedLessThanOrEqual(Vector128<Single>, Vector128<Single>)	int _mm_ucomile_ss (__m128 a, __m128 b); UCOMISS xmm, xmm/m32
            // CompareScalarUnorderedNotEqual(Vector128<Single>, Vector128<Single>)	int _mm_ucomineq_ss (__m128 a, __m128 b); UCOMISS xmm, xmm/m32
            // CompareUnordered(Vector128<Single>, Vector128<Single>)	__m128 _mm_cmpunord_ps (__m128 a, __m128 b); CMPPS xmm, xmm/m128, imm8(3)
            // ConvertScalarToVector128Single(Vector128<Single>, Int32)	__m128 _mm_cvtsi32_ss (__m128 a, int b); CVTSI2SS xmm, reg/m32
            // ConvertToInt32(Vector128<Single>)	int _mm_cvtss_si32 (__m128 a); CVTSS2SI r32, xmm/m32
            // ConvertToInt32WithTruncation(Vector128<Single>)	int _mm_cvttss_si32 (__m128 a); CVTTSS2SI r32, xmm/m32
            // Divide(Vector128<Single>, Vector128<Single>)	__m128 _mm_div_ps (__m128 a, __m128 b); DIVPS xmm, xmm/m128
            // DivideScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_div_ss (__m128 a, __m128 b); DIVSS xmm, xmm/m32

            // LoadAlignedVector128(Single*)	__m128 _mm_load_ps (float const* mem_address); MOVAPS xmm, m128
            // LoadHigh(Vector128<Single>, Single*)	__m128 _mm_loadh_pi (__m128 a, __m64 const* mem_addr); MOVHPS xmm, m64
            // LoadLow(Vector128<Single>, Single*)	__m128 _mm_loadl_pi (__m128 a, __m64 const* mem_addr); MOVLPS xmm, m64
            // LoadScalarVector128(Single*)	__m128 _mm_load_ss (float const* mem_address); MOVSS xmm, m32
            // LoadVector128(Single*)	__m128 _mm_loadu_ps (float const* mem_address); MOVUPS xmm, m128
            // Max(Vector128<Single>, Vector128<Single>)	__m128 _mm_max_ps (__m128 a, __m128 b); MAXPS xmm, xmm/m128
            // MaxScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_max_ss (__m128 a, __m128 b); MAXSS xmm, xmm/m32
            // MemberwiseClone()	Creates a shallow copy of the current Object.; (Inherited from Object)
            // Min(Vector128<Single>, Vector128<Single>)	__m128 _mm_min_ps (__m128 a, __m128 b); MINPS xmm, xmm/m128
            // MinScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_min_ss (__m128 a, __m128 b); MINSS xmm, xmm/m32
            // MoveHighToLow(Vector128<Single>, Vector128<Single>)	__m128 _mm_movehl_ps (__m128 a, __m128 b); MOVHLPS xmm, xmm
            // MoveLowToHigh(Vector128<Single>, Vector128<Single>)	__m128 _mm_movelh_ps (__m128 a, __m128 b); MOVLHPS xmm, xmm
            // MoveMask(Vector128<Single>)	int _mm_movemask_ps (__m128 a); MOVMSKPS reg, xmm
            // MoveScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_move_ss (__m128 a, __m128 b); MOVSS xmm, xmm
            // Multiply(Vector128<Single>, Vector128<Single>)	__m128 _mm_mul_ps (__m128 a, __m128 b); MULPS xmm, xmm/m128
            // MultiplyScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_mul_ss (__m128 a, __m128 b); MULPS xmm, xmm/m32
            // Or(Vector128<Single>, Vector128<Single>)	__m128 _mm_or_ps (__m128 a, __m128 b); ORPS xmm, xmm/m128
            // Prefetch0(Void*)	void _mm_prefetch(char* p, int i); PREFETCHT0 m8
            // Prefetch1(Void*)	void _mm_prefetch(char* p, int i); PREFETCHT1 m8
            // Prefetch2(Void*)	void _mm_prefetch(char* p, int i); PREFETCHT2 m8
            // PrefetchNonTemporal(Void*)	void _mm_prefetch(char* p, int i); PREFETCHNTA m8
            // Reciprocal(Vector128<Single>)	__m128 _mm_rcp_ps (__m128 a); RCPPS xmm, xmm/m128
            // ReciprocalScalar(Vector128<Single>)	__m128 _mm_rcp_ss (__m128 a); RCPSS xmm, xmm/m32
            // ReciprocalScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_rcp_ss (__m128 a, __m128 b); RCPSS xmm, xmm/m32
            // ReciprocalSqrt(Vector128<Single>)	__m128 _mm_rsqrt_ps (__m128 a); RSQRTPS xmm, xmm/m128
            // ReciprocalSqrtScalar(Vector128<Single>)	__m128 _mm_rsqrt_ss (__m128 a); RSQRTSS xmm, xmm/m32
            // ReciprocalSqrtScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_rsqrt_ss (__m128 a, __m128 b); RSQRTSS xmm, xmm/m32
            // Shuffle(Vector128<Single>, Vector128<Single>, Byte)	__m128 _mm_shuffle_ps (__m128 a, __m128 b, unsigned int control); SHUFPS xmm, xmm/m128, imm8
            // Sqrt(Vector128<Single>)	__m128 _mm_sqrt_ps (__m128 a); SQRTPS xmm, xmm/m128
            // SqrtScalar(Vector128<Single>)	__m128 _mm_sqrt_ss (__m128 a); SQRTSS xmm, xmm/m32
            // SqrtScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_sqrt_ss (__m128 a, __m128 b); SQRTSS xmm, xmm/m32
            // Store(Single*, Vector128<Single>)	void _mm_storeu_ps (float* mem_addr, __m128 a); MOVUPS m128, xmm
            // StoreAligned(Single*, Vector128<Single>)	void _mm_store_ps (float* mem_addr, __m128 a); MOVAPS m128, xmm
            // StoreAlignedNonTemporal(Single*, Vector128<Single>)	void _mm_stream_ps (float* mem_addr, __m128 a); MOVNTPS m128, xmm
            // StoreFence()	void _mm_sfence(void); SFENCE
            // StoreHigh(Single*, Vector128<Single>)	void _mm_storeh_pi (__m64* mem_addr, __m128 a); MOVHPS m64, xmm
            // StoreLow(Single*, Vector128<Single>)	void _mm_storel_pi (__m64* mem_addr, __m128 a); MOVLPS m64, xmm
            // StoreScalar(Single*, Vector128<Single>)	void _mm_store_ss (float* mem_addr, __m128 a); MOVSS m32, xmm
            // Subtract(Vector128<Single>, Vector128<Single>)	__m128d _mm_sub_ps (__m128d a, __m128d b); SUBPS xmm, xmm/m128
            // SubtractScalar(Vector128<Single>, Vector128<Single>)	__m128 _mm_sub_ss (__m128 a, __m128 b); SUBSS xmm, xmm/m32

            // UnpackHigh(Vector128<Single>, Vector128<Single>)	__m128 _mm_unpackhi_ps (__m128 a, __m128 b); UNPCKHPS xmm, xmm/m128
            // UnpackLow(Vector128<Single>, Vector128<Single>)	__m128 _mm_unpacklo_ps (__m128 a, __m128 b); UNPCKLPS xmm, xmm/m128
            // Xor(Vector128<Single>, Vector128<Single>)	__m128 _mm_xor_ps (__m128 a, __m128 b); XORPS xmm, xmm/m128

        }

    }
}
