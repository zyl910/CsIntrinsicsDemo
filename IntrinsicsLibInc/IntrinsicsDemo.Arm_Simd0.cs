using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Intrinsics;
#if NET5_0_OR_GREATER
using System.Runtime.Intrinsics.Arm;
#endif // #if NET5_0_OR_GREATER
using System.Text;

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

        }

    }
}
