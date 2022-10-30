using System;
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
        public static ref readonly T ElementV0 { get { return ref Scalars<T>.V0; } }
        /// <summary>(Element) Exponent bias (指数偏移值). When the type is an integer, the value is 0.</summary>
        public static int ElementExponentBias { get { return Scalars<T>.ExponentBias; } }
    }
}
