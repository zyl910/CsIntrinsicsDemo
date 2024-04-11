using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics;
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics.Wasm;
using System.Runtime.Intrinsics.X86;

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

        }

#endif // NET8_0_OR_GREATER
    }
}

