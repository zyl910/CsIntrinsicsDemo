using System;
using System.Collections.Generic;
using System.IO;
#if NET5_0_OR_GREATER
using System.Runtime.Intrinsics.Arm;
#endif // #if NET5_0_OR_GREATER
using System.Text;

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

        }

        /// <summary>
        /// Run Arm Dp.Arm64 .
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public unsafe static void RunArm_Dp_64(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            string indentNext = indent + IndentNextSeparator;
            bool isSupported = Dp.Arm64.IsSupported;
            if (isSupported) {
                writer.WriteLine();
            }
            writer.WriteLine(indent + string.Format("-- Dp.Arm64.IsSupported:\t{0}", isSupported));
            if (!isSupported) {
                return;
            }

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

        }
    }

}