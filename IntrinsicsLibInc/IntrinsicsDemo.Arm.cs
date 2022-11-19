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
        /// Run Arm.
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunArm(TextWriter writer, string indent) {
#if NET5_0_OR_GREATER
            // bool isSupported = ArmBase.IsSupported;
            // if (!isSupported) return;
            RunArmSupported(writer, indent);
#else
            return;
#endif // #if NET5_0_OR_GREATER
        }

#if NET5_0_OR_GREATER
        /// <summary>
        /// Run Arm Supported. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.arm.armbase?view=net-7.0
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunArmSupported(TextWriter writer, string indent) {
            if (null == writer) return;
            if (null == indent) indent = "";
            writer.WriteLine();
            writer.WriteLine(indent + "[Intrinsics.Arm]");
            WriteLine(writer, indent, "AdvSimd.IsSupported:\t{0}", AdvSimd.IsSupported);
            WriteLine(writer, indent, "AdvSimd.Arm64.IsSupported:\t{0}", AdvSimd.Arm64.IsSupported);
            WriteLine(writer, indent, "Aes.IsSupported:\t{0}", Aes.IsSupported);
            WriteLine(writer, indent, "Aes.Arm64.IsSupported:\t{0}", Aes.Arm64.IsSupported);
            WriteLine(writer, indent, "ArmBase.IsSupported:\t{0}", ArmBase.IsSupported);
            WriteLine(writer, indent, "ArmBase.Arm64.IsSupported:\t{0}", ArmBase.Arm64.IsSupported);
            WriteLine(writer, indent, "Crc32.IsSupported:\t{0}", Crc32.IsSupported);
            WriteLine(writer, indent, "Crc32.Arm64.IsSupported:\t{0}", Crc32.Arm64.IsSupported);
            WriteLine(writer, indent, "Dp.IsSupported:\t{0}", Dp.IsSupported);
            WriteLine(writer, indent, "Dp.Arm64.IsSupported:\t{0}", Dp.Arm64.IsSupported);
            WriteLine(writer, indent, "Rdm.IsSupported:\t{0}", Rdm.IsSupported);
            WriteLine(writer, indent, "Rdm.Arm64.IsSupported:\t{0}", Rdm.Arm64.IsSupported);
            WriteLine(writer, indent, "Sha1.IsSupported:\t{0}", Sha1.IsSupported);
            WriteLine(writer, indent, "Sha1.Arm64.IsSupported:\t{0}", Sha1.Arm64.IsSupported);
            WriteLine(writer, indent, "Sha256.IsSupported:\t{0}", Sha256.IsSupported);
            WriteLine(writer, indent, "Sha256.Arm64.IsSupported:\t{0}", Sha256.Arm64.IsSupported);
        }
#endif // #if NET5_0_OR_GREATER
    }
}
