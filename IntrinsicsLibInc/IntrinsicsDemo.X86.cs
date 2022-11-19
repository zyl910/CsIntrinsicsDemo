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
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunX86(TextWriter writer, string indent) {
#if NET5_0_OR_GREATER
            bool isSupported = X86Base.IsSupported;
#else
            bool isSupported = Sse.IsSupported;
#endif
            RunX86Supported(writer, indent);
            if (!isSupported) return;
            // Sse
            // Avx
            RunX86Avx(writer, indent);
            RunX86Avx2(writer, indent);
            RunX86Fma(writer, indent);
            RunX86AvxVnni(writer, indent);
        }

        /// <summary>
        /// Run x86 Supported. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.x86?view=net-7.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunX86Supported(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            writer.WriteLine();
            writer.WriteLine(indent + "[Intrinsics.X86]");
            WriteLine(writer, indent, "Aes.IsSupported:\t{0}", Aes.IsSupported);
            WriteLine(writer, indent, "Aes.X64.IsSupported:\t{0}", Aes.X64.IsSupported);
            WriteLine(writer, indent, "Avx.IsSupported:\t{0}", Avx.IsSupported);
            WriteLine(writer, indent, "Avx.X64.IsSupported:\t{0}", Avx.X64.IsSupported);
            WriteLine(writer, indent, "Avx2.IsSupported:\t{0}", Avx2.IsSupported);
            WriteLine(writer, indent, "Avx2.X64.IsSupported:\t{0}", Avx2.X64.IsSupported);
#if NET6_0_OR_GREATER
            WriteLine(writer, indent, "AvxVnni.IsSupported:\t{0}", AvxVnni.IsSupported);
            WriteLine(writer, indent, "AvxVnni.X64.IsSupported:\t{0}", AvxVnni.X64.IsSupported);
#endif
            WriteLine(writer, indent, "Bmi1.IsSupported:\t{0}", Bmi1.IsSupported);
            WriteLine(writer, indent, "Bmi1.X64.IsSupported:\t{0}", Bmi1.X64.IsSupported);
            WriteLine(writer, indent, "Bmi2.IsSupported:\t{0}", Bmi2.IsSupported);
            WriteLine(writer, indent, "Bmi2.X64.IsSupported:\t{0}", Bmi2.X64.IsSupported);
            WriteLine(writer, indent, "Fma.IsSupported:\t{0}", Fma.IsSupported);
            WriteLine(writer, indent, "Fma.X64.IsSupported:\t{0}", Fma.X64.IsSupported);
            WriteLine(writer, indent, "Lzcnt.IsSupported:\t{0}", Lzcnt.IsSupported);
            WriteLine(writer, indent, "Lzcnt.X64.IsSupported:\t{0}", Lzcnt.X64.IsSupported);
            WriteLine(writer, indent, "Pclmulqdq.IsSupported:\t{0}", Pclmulqdq.IsSupported);
            WriteLine(writer, indent, "Pclmulqdq.X64.IsSupported:\t{0}", Pclmulqdq.X64.IsSupported);
            WriteLine(writer, indent, "Popcnt.IsSupported:\t{0}", Popcnt.IsSupported);
            WriteLine(writer, indent, "Popcnt.X64.IsSupported:\t{0}", Popcnt.X64.IsSupported);
            WriteLine(writer, indent, "Sse.IsSupported:\t{0}", Sse.IsSupported);
            WriteLine(writer, indent, "Sse.X64.IsSupported:\t{0}", Sse.X64.IsSupported);
            WriteLine(writer, indent, "Sse2.IsSupported:\t{0}", Sse2.IsSupported);
            WriteLine(writer, indent, "Sse2.X64.IsSupported:\t{0}", Sse2.X64.IsSupported);
            WriteLine(writer, indent, "Sse3.IsSupported:\t{0}", Sse3.IsSupported);
            WriteLine(writer, indent, "Sse3.X64.IsSupported:\t{0}", Sse3.X64.IsSupported);
            WriteLine(writer, indent, "Sse41.IsSupported:\t{0}", Sse41.IsSupported);
            WriteLine(writer, indent, "Sse41.X64.IsSupported:\t{0}", Sse41.X64.IsSupported);
            WriteLine(writer, indent, "Sse42.IsSupported:\t{0}", Sse42.IsSupported);
            WriteLine(writer, indent, "Sse42.X64.IsSupported:\t{0}", Sse42.X64.IsSupported);
            WriteLine(writer, indent, "Ssse3.IsSupported:\t{0}", Ssse3.IsSupported);
            WriteLine(writer, indent, "Ssse3.X64.IsSupported:\t{0}", Ssse3.X64.IsSupported);
#if NET5_0_OR_GREATER
            WriteLine(writer, indent, "X86Base.IsSupported:\t{0}", X86Base.IsSupported);
            WriteLine(writer, indent, "X86Base.X64.IsSupported:\t{0}", X86Base.X64.IsSupported);
#endif // NET5_0_OR_GREATER
#if NET7_0_OR_GREATER
            WriteLine(writer, indent, "X86Serialize.IsSupported:\t{0}", X86Serialize.IsSupported);
            WriteLine(writer, indent, "X86Serialize.X64.IsSupported:\t{0}", X86Serialize.X64.IsSupported);
#endif // NET7_0_OR_GREATER
        }
    }
}

