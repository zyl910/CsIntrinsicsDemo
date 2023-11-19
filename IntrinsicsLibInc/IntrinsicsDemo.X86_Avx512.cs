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
#endif // NET6_0_OR_GREATER
        }

    }
}
