﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IntrinsicsLib {

    /// <summary>
    /// Common constants of any Vector types (任何向量类型的公用常量).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="T">The vector element type. T can be any primitive numeric type.</typeparam>
    public abstract class AbstractVectors<T> where T : struct {
        /// <summary>(Element) Zero (0).</summary>
        public static T ElementZero { get { return Scalars<T>.V0; } }
        /// <summary>(Element) Value 0 (0的值).</summary>
        public static T ElementV0 { get { return Scalars<T>.V0; } }
        /// <summary>(Element) All bit is 1 (所有位都是1的值).</summary>
        public static T ElementAllBitsSet { get { return Scalars<T>.AllBitsSet; } }
        // -- Number struct --
        /// <summary>(Element) Byte size (字节大小).</summary>
        public static int ElementByteSize { get { return Scalars<T>.ByteSize; } }
        /// <summary>(Element) Exponent bias (指数偏移值). When the type is an integer, the value is 0.</summary>
        public static int ElementExponentBias { get { return Scalars<T>.ExponentBias; } }
        /// <summary>(Element) Sign bit size (符号位数). When the type is an unsigned number, the value is 0.</summary>
        public static int ElementSignBits { get { return Scalars<T>.SignBits; } }
        /// <summary>(Element) Exponent bit size (指数位数). When the type is an integer, the value is 0.</summary>
        public static int ElementExponentBits { get { return Scalars<T>.ExponentBits; } }
        /// <summary>(Element) Mantissa bit size (尾数位数).</summary>
        public static int ElementMantissaBits { get { return Scalars<T>.MantissaBits; } }
        /// <summary>(Element) Sign shift bit (符号位移).</summary>
        public static int ElementSignShift { get { return Scalars<T>.SignShift; } }
        /// <summary>(Element) Exponent shift bit (指数位移).</summary>
        public static int ElementExponentShift { get { return Scalars<T>.ExponentShift; } }
        /// <summary>(Element) Mantissa shift bit (尾数位移).</summary>
        public static int ElementMantissaShift { get { return Scalars<T>.MantissaShift; } }
        /// <summary>(Element) Sign mask (符号掩码).</summary>
        public static T ElementSignMask { get { return Scalars<T>.SignMask; } }
        /// <summary>(Element) Exponent mask (指数掩码).</summary>
        public static T ElementExponentMask { get { return Scalars<T>.ExponentMask; } }
        /// <summary>(Element) Mantissa mast (尾数掩码)k.</summary>
        public static T ElementMantissaMask { get { return Scalars<T>.MantissaMask; } }
        /// <summary>(Element) Non-sign mask (非符号掩码).</summary>
        public static T ElementNonSignMask { get { return Scalars<T>.NonSignMask; } }
        /// <summary>(Element) Non-exponent mask (非指数掩码).</summary>
        public static T ElementNonExponentMask { get { return Scalars<T>.NonExponentMask; } }
        /// <summary>(Element) Non-mantissa mask (非尾数掩码).</summary>
        public static T ElementNonMantissaMask { get { return Scalars<T>.NonMantissaMask; } }
        /// <summary>(Element) Represents the smallest positive value that is greater than zero (表示大于零的最小正值). When the type is an integer, the value is 1 (当类型为整数时，该值为1).</summary>
        public static T ElementEpsilon { get { return Scalars<T>.Epsilon; } }
        /// <summary>(Element) Represents the largest possible value (表示最大可能值).</summary>
        public static T ElementMaxValue { get { return Scalars<T>.MaxValue; } }
        /// <summary>(Element) Represents the smallest possible value (表示最大可能值).</summary>
        public static T ElementMinValue { get { return Scalars<T>.MinValue; } }
        /// <summary>(Element) Represents not a number (NaN) (表示“非数(NaN)”的值). When the type is an integer, the value is 0 (当类型为整数时，该值为0).</summary>
        public static T ElementNaN { get { return Scalars<T>.NaN; } }
        /// <summary>(Element) Represents negative infinity (表示负无穷). When the type is an integer, the value is 0 (当类型为整数时，该值为0).</summary>
        public static T ElementNegativeInfinity { get { return Scalars<T>.NegativeInfinity; } }
        /// <summary>(Element) Represents positive infinity (表示正无穷). When the type is an integer, the value is 0 (当类型为整数时，该值为0).</summary>
        public static T ElementPositiveInfinity { get { return Scalars<T>.PositiveInfinity; } }
        // -- Math --
        /// <summary>(Element) Represents the natural logarithmic base, specified by the constant, e (表示自然对数的底，它由常数 e 指定).</summary>
        public static T ElementE { get { return Scalars<T>.E; } }
        /// <summary>(Element) Represents the ratio of the circumference of a circle to its diameter, specified by the constant, π (表示圆的周长与其直径的比值，由常数 π 指定).</summary>
        public static T ElementPi { get { return Scalars<T>.Pi; } }
        /// <summary>(Element) Represents the number of radians in one turn, specified by the constant, τ (表示转一圈的弧度数，由常量 τ 指定).</summary>
        public static T ElementTau { get { return Scalars<T>.Tau; } }
        // -- Mask --
        /// <summary>(Element) 1 bits mask (1位掩码).</summary>
        public static T ElementMaskBits1 { get { return Scalars<T>.MaskBits1; } }
        /// <summary>(Element) 2 bits mask (2位掩码).</summary>
        public static T ElementMaskBits2 { get { return Scalars<T>.MaskBits2; } }
        /// <summary>(Element) 4 bits mask (4位掩码).</summary>
        public static T ElementMaskBits4 { get { return Scalars<T>.MaskBits4; } }
        /// <summary>(Element) 8 bits mask (8位掩码).</summary>
        public static T ElementMaskBits8 { get { return Scalars<T>.MaskBits8; } }
        /// <summary>(Element) 16 bits mask (16位掩码).</summary>
        public static T ElementMaskBits16 { get { return Scalars<T>.MaskBits16; } }
        /// <summary>(Element) 32 bits mask (32位掩码).</summary>
        public static T ElementMaskBits32 { get { return Scalars<T>.MaskBits32; } }
        // -- Positive number --
        /// <summary>(Element) Value 1 .</summary>
        public static T ElementV1 { get { return Scalars<T>.V1; } }
        /// <summary>(Element) Value 2 .</summary>
        public static T ElementV2 { get { return Scalars<T>.V2; } }
        /// <summary>(Element) Value 3 .</summary>
        public static T ElementV3 { get { return Scalars<T>.V3; } }
        /// <summary>(Element) Value 4 .</summary>
        public static T ElementV4 { get { return Scalars<T>.V4; } }
        /// <summary>(Element) Value 5 .</summary>
        public static T ElementV5 { get { return Scalars<T>.V5; } }
        /// <summary>(Element) Value 6 .</summary>
        public static T ElementV6 { get { return Scalars<T>.V6; } }
        /// <summary>(Element) Value 7 .</summary>
        public static T ElementV7 { get { return Scalars<T>.V7; } }
        /// <summary>(Element) Value 8 .</summary>
        public static T ElementV8 { get { return Scalars<T>.V8; } }
        /// <summary>(Element) Value 127 (SByte.MaxValue).</summary>
        public static T ElementV127 { get { return Scalars<T>.V127; } }
        /// <summary>(Element) Value 255 (Byte.MaxValue).</summary>
        public static T ElementV255 { get { return Scalars<T>.V255; } }
        /// <summary>(Element) Value 32767 (Int16.MaxValue) .</summary>
        public static T ElementV32767 { get { return Scalars<T>.V32767; } }
        /// <summary>(Element) Value 65535 (UInt16.MaxValue) .</summary>
        public static T ElementV65535 { get { return Scalars<T>.V65535; } }
        /// <summary>(Element) Value 2147483647 (Int32.MaxValue) .</summary>
        public static T ElementV2147483647 { get { return Scalars<T>.V2147483647; } }
        /// <summary>(Element) Value 4294967295 (UInt32.MaxValue) .</summary>
        public static T ElementV4294967295 { get { return Scalars<T>.V4294967295; } }
        // -- Negative number  --
        /// <summary>(Element) Value -1 . When the type is unsigned integer, the value is a signed cast value (当类型为无符号整型时，值为带符号强制转换值). Example: '(Byte)(-1)=255' .</summary>
        public static T ElementV_1 { get { return Scalars<T>.V_1; } }
        /// <summary>(Element) Value -2 .</summary>
        public static T ElementV_2 { get { return Scalars<T>.V_2; } }
        /// <summary>(Element) Value -3 .</summary>
        public static T ElementV_3 { get { return Scalars<T>.V_3; } }
        /// <summary>(Element) Value -4 .</summary>
        public static T ElementV_4 { get { return Scalars<T>.V_4; } }
        /// <summary>(Element) Value -5 .</summary>
        public static T ElementV_5 { get { return Scalars<T>.V_5; } }
        /// <summary>(Element) Value -6 .</summary>
        public static T ElementV_6 { get { return Scalars<T>.V_6; } }
        /// <summary>(Element) Value -7 .</summary>
        public static T ElementV_7 { get { return Scalars<T>.V_7; } }
        /// <summary>(Element) Value -8 .</summary>
        public static T ElementV_8 { get { return Scalars<T>.V_8; } }
        /// <summary>(Element) Value -128 (SByte.MinValue).</summary>
        public static T ElementV_128 { get { return Scalars<T>.V_128; } }
        /// <summary>(Element) Value -32768 (Int16.MinValue) .</summary>
        public static T ElementV_32768 { get { return Scalars<T>.V_32768; } }
        /// <summary>(Element) Value -2147483648 (Int32.MinValue) .</summary>
        public static T ElementV_2147483648 { get { return Scalars<T>.V_2147483648; } }
    }

}
