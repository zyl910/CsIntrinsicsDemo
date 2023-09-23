using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using static MathDemo.StringUtil;

namespace MathDemo {
    /// <summary>
    /// Number div demo.
    /// </summary>
    public class NumberDivDemo {

        /// <summary>
        /// Run.
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        public static void Run(TextWriter writer) {
            Run_Int16(writer);
        }

        /// <summary>
        /// Run - Int16.
        /// </summary>
        /// <param name="writer">Output <see cref="TextWriter"/>.</param>
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public static void Run_Int16(TextWriter writer) {
            int showCount = 0;
            long total = 0;
            long totalOkY0 = 0;
            long totalOkY1 = 0;
            long totalOkY01 = 0;
            writer.WriteLine("## NumberDivDemo.Run_Int16");
            writer.WriteLine(StringUtil.JoinTab("x", "b", "yInt", "yFloat", "y0", "x0Diff", "x0Diff", "y0DiffInt", "y1", "x1Diff"));
            for (int i = 1; i<0xFFFF; ++i) {
                for (int j = 1; j < 0xFFFF; ++j) {
                    ++total;
                    // y = x/b = i/j
                    int yInt = i / j;
                    float x = (float)(i);
                    float b = (float)(j);
                    float d = 1.0f / b;
                    float yFloat = x / b; // y = x/b = x*(1/b) = x*d
                    float y0 = x * d;
                    float y0Diff = yFloat - y0;
                    float y0DiffInt = BitConverter.SingleToInt32Bits(yFloat) - BitConverter.SingleToInt32Bits(y0);
                    float x0Diff = x - (y0 * b);
                    float y1Fix = x0Diff * d;
                    float y1 = y0 + y1Fix;
                    float y1Diff = yFloat - y1;
                    float x1Diff = x - (y1 * b);
                    // Show.
                    if (0 == y0Diff) ++totalOkY0;
                    if (0 == y1Diff) ++totalOkY1;
                    if (!((0 != y0Diff) && (0 != y1Diff))) ++totalOkY01;
                    bool allowShow = true;
                    //allowShow = 0 != y0Diff;
                    //allowShow = 0 != y1Diff;
                    allowShow = (0 != y0Diff) && (0 != y1Diff);
                    if (allowShow) {
                        if (showCount < StringUtil.MaxShowCount) {
                            ++showCount;
                            string msg = StringUtil.JoinTab(x, b, yInt, ToStringWithHex(yFloat), ToStringWithHex(y0), x0Diff, y0DiffInt, ToStringWithHex(y1), x1Diff);
                            writer.WriteLine(msg);
                        }
                    }
                }
            }
            writer.WriteLine(string.Format("total:\t{0}", total));
            writer.WriteLine(string.Format("totalOkY0:\t{0}\t// {1:0.0000}%", totalOkY0, (double)(100.0 * totalOkY0) / total));
            writer.WriteLine(string.Format("totalOkY1:\t{0}\t// {1:0.0000}%", totalOkY1, (double)(100.0 * totalOkY1) / total));
            writer.WriteLine(string.Format("totalOkY01:\t{0}\t// {1:0.0000}%", totalOkY01, (double)(100.0 * totalOkY01) / total));
            writer.WriteLine();
            // total:  4294705156
            // totalOkY0:      3140785119      // 73.1316%
            // totalOkY1:      3793748365      // 88.3355%
            // totalOkY01:     4080388111      // 95.0097%
        }

    }
}
