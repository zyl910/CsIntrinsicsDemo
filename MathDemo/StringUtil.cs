using System;
using System.Collections.Generic;
using System.Text;

namespace MathDemo {
    /// <summary>
    /// String util.
    /// </summary>
    public static class StringUtil {
        public const int MaxShowCount = 100;

        /// <summary>
        /// Join with tab.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>Returns string.</returns>
        public static string JoinTab(params object?[] values) {
            return string.Join('\t', values);
        }

        public static string ToStringWithHex(float x) {
            string rt = string.Format("{0}(0x{1:X8})", x, BitConverter.SingleToInt32Bits(x));
            return rt;
        }

    }
}
