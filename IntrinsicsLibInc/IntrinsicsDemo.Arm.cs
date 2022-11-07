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
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunArm(TextWriter tw, string indent) {
#if NET5_0_OR_GREATER
            // bool isSupported = ArmBase.IsSupported;
            // if (!isSupported) return;
            RunArmSupported(tw, indent);
#else
            return;
#endif // #if NET5_0_OR_GREATER
        }

#if NET5_0_OR_GREATER
        /// <summary>
        /// Run Arm Supported. https://learn.microsoft.com/zh-cn/dotnet/api/system.runtime.intrinsics.arm.armbase?view=net-7.0
        /// </summary>
        /// <param name="tw">Output <see cref="TextWriter"/>.</param>
        /// <param name="indent">The indent.</param>
        public static void RunArmSupported(TextWriter tw, string indent) {
            if (null == tw) return;
            if (null == indent) indent = "";
            tw.WriteLine();
            tw.WriteLine(indent + "[Intrinsics.Arm]");
            WriteLine(tw, indent, "AdvSimd.IsSupported:\t{0}", AdvSimd.IsSupported);
            WriteLine(tw, indent, "AdvSimd.Arm64.IsSupported:\t{0}", AdvSimd.Arm64.IsSupported);
            WriteLine(tw, indent, "Aes.IsSupported:\t{0}", Aes.IsSupported);
            WriteLine(tw, indent, "Aes.Arm64.IsSupported:\t{0}", Aes.Arm64.IsSupported);
            WriteLine(tw, indent, "ArmBase.IsSupported:\t{0}", ArmBase.IsSupported);
            WriteLine(tw, indent, "ArmBase.Arm64.IsSupported:\t{0}", ArmBase.Arm64.IsSupported);
            WriteLine(tw, indent, "Crc32.IsSupported:\t{0}", Crc32.IsSupported);
            WriteLine(tw, indent, "Crc32.Arm64.IsSupported:\t{0}", Crc32.Arm64.IsSupported);
            WriteLine(tw, indent, "Dp.IsSupported:\t{0}", Dp.IsSupported);
            WriteLine(tw, indent, "Dp.Arm64.IsSupported:\t{0}", Dp.Arm64.IsSupported);
            WriteLine(tw, indent, "Rdm.IsSupported:\t{0}", Rdm.IsSupported);
            WriteLine(tw, indent, "Rdm.Arm64.IsSupported:\t{0}", Rdm.Arm64.IsSupported);
            WriteLine(tw, indent, "Sha1.IsSupported:\t{0}", Sha1.IsSupported);
            WriteLine(tw, indent, "Sha1.Arm64.IsSupported:\t{0}", Sha1.Arm64.IsSupported);
            WriteLine(tw, indent, "Sha256.IsSupported:\t{0}", Sha256.IsSupported);
            WriteLine(tw, indent, "Sha256.Arm64.IsSupported:\t{0}", Sha256.Arm64.IsSupported);
        }
#endif // #if NET5_0_OR_GREATER
    }
}
