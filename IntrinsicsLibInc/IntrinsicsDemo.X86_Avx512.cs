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
        /// Run x86 Avx512BW. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512bw?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512BW(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512BW.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512BW.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512BW.VL. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512bw.vl?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512BW_VL(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512BW.VL.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512BW.VL.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512BW.X64. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512bw.x64?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512BW_X64(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512BW.X64.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512BW.X64.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512CD. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512cd?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512CD(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512CD.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512CD.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512CD.VL. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512cd.vl?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512CD_VL(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512CD.VL.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512CD.VL.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512CD.X64. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512cd.x64?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512CD_X64(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512CD.X64.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512CD.X64.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512DQ. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512dq?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512DQ(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512DQ.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512DQ.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512DQ.VL. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512dq.vl?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512DQ_VL(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512DQ.VL.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512DQ.VL.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512DQ.X64. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512dq.x64?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512DQ_X64(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512DQ.X64.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512DQ.X64.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512F. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512f?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512F(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512F.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512F.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512F.VL. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512f.vl?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512F_VL(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512F.VL.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512F.VL.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512F.X64. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512f.x64?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512F_X64(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512F.X64.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512F.X64.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512Vbmi. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512vbmi?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512Vbmi(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512Vbmi.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512Vbmi.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

            //PermuteVar64x8(Vector512<Byte>, Vector512<Byte>)	__m512i _mm512_permutevar64x8_epi8 (__m512i a£¬ __m512i b); VPERMB zmm1 {k1}{z}£¬ zmm2£¬ zmm3/m512
            //PermuteVar64x8(Vector512<SByte>, Vector512<SByte>)	__m512i _mm512_permutevar64x8_epi8 (__m512i a£¬ __m512i b); VPERMB zmm1 {k1}{z}£¬ zmm2£¬ zmm3/m512
            WriteLine(writer, indent, "PermuteVar64x8(Vector512s<Double>.Demo, Vector512s<Double>.V1):\t{0}", Avx512Vbmi.PermuteVar64x8(Vector512s<byte>.SerialNegative, Vector512s.CreateByDoubleLoop<byte>(0, 2)));
            // PermuteVar64x8(Vector512s<Double>.Demo, Vector512s<Double>.V1): <0, 254, 252, 250, 248, 246, 244, 242, 240, 238, 236, 234, 232, 230, 228, 226, 224, 222, 220, 218, 216, 214, 212, 210, 208, 206, 204, 202, 200, 198, 196, 194, 0, 254, 252, 250, 248, 246, 244, 242, 240, 238, 236, 234, 232, 230, 228, 226, 224, 222, 220, 218, 216, 214, 212, 210, 208, 206, 204, 202, 200, 198, 196, 194>

            //PermuteVar64x8x2(Vector512<Byte>, Vector512<Byte>, Vector512<Byte>)	__m512i _mm512_permutex2var_epi8 (__m512i a£¬__m512i idx£¬__m512i b); VPERMI2B zmm1 {k1}{z}£¬ zmm2£¬ zmm3/m512 VPERMT2B zmm1 {k1}{z}£¬ zmm2£¬ zmm3/m512
            //PermuteVar64x8x2(Vector512<SByte>, Vector512<SByte>, Vector512<SByte>)	__m512i _mm512_permutex2var_epi8 (__m512i a£¬__m512i idx£¬__m512i b); VPERMI2B zmm1 {k1}{z}£¬ zmm2£¬ zmm3/m512 VPERMT2B zmm1 {k1}{z}£¬ zmm2£¬ zmm3/m512

#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512Vbmi.VL. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512vbmi.vl?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512Vbmi_VL(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512Vbmi.VL.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512Vbmi.VL.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

            //PermuteVar16x8(Vector128<Byte>, Vector128<Byte>)	__m128i _mm_permutevar64x8_epi8 (__m128i a£¬ __m128i b); VPERMB xmm1 {k1}{z}£¬ xmm2£¬ xmm3/m128
            //PermuteVar16x8(Vector128<SByte>, Vector128<SByte>)	__m128i _mm_permutevar64x8_epi8 (__m128i a£¬ __m128i b); VPERMB xmm1 {k1}{z}£¬ xmm2£¬ xmm3/m128

            //PermuteVar16x8x2(Vector128<Byte>, Vector128<Byte>, Vector128<Byte>)	__m128i _mm_permutex2var_epi8 (__m128i a£¬ __m128i idx£¬ __m128i b); VPERMI2B xmm1 {k1}{z}£¬ xmm2£¬ xmm3/m128 VPERMT2B xmm1 {k1}{z}£¬ xmm2£¬ xmm3/m128
            //PermuteVar16x8x2(Vector128<SByte>, Vector128<SByte>, Vector128<SByte>)	__m128i _mm_permutex2var_epi8 (__m128i a£¬ __m128i idx£¬ __m128i b); VPERMI2B xmm1 {k1}{z}£¬ xmm2£¬ xmm3/m128 VPERMT2B xmm1 {k1}{z}£¬ xmm2£¬ xmm3/m128

            //PermuteVar32x8(Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_permutevar64x8_epi8 (__m256i a£¬ __m256i b); VPERMB ymm1 {k1}{z}£¬ ymm2£¬ ymm3/m256
            //PermuteVar32x8(Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_permutevar64x8_epi8 (__m256i a£¬ __m256i b); VPERMB ymm1 {k1}{z}£¬ ymm2£¬ ymm3/m256

            //PermuteVar32x8x2(Vector256<Byte>, Vector256<Byte>, Vector256<Byte>)	__m256i _mm256_permutex2var_epi8 (__m256i a£¬ __m256i idx£¬ __m256i b); VPERMI2B ymm1 {k1}{z}£¬ ymm2£¬ ymm3/m256 VPERMT2B ymm1 {k1}{z}£¬ ymm2£¬ ymm3/m256
            //PermuteVar32x8x2(Vector256<SByte>, Vector256<SByte>, Vector256<SByte>)	__m256i _mm256_permutex2var_epi8 (__m256i a£¬ __m256i idx£¬ __m256i b); VPERMI2B ymm1 {k1}{z}£¬ ymm2£¬ ymm3/m256 VPERMT2B ymm1 {k1}{z}£¬ ymm2£¬ ymm3/m256

#endif // NET8_0_OR_GREATER
        }

        /// <summary>
        /// Run x86 Avx512Vbmi.X64. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86.avx512vbmi.x64?view=net-8.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunX86Avx512Vbmi_X64(TextWriter writer, string indent) {
#if NET8_0_OR_GREATER
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Avx512Vbmi.X64.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Avx512Vbmi.X64.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }
#endif // NET8_0_OR_GREATER
        }

    }
}
