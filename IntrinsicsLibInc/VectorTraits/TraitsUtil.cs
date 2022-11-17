﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Numerics;
using System.Runtime.CompilerServices;
#if NETCOREAPP3_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif
using System.Text;

[assembly: CLSCompliant(true)]

namespace Zyl.VectorTraits {
    /// <summary>
    /// Traits misc util.
    /// </summary>
    public static class TraitsUtil {

        /// <summary>The default end-of-line comment separator (默认的行尾注释分隔符). </summary>
        public static readonly string DefaultLineCommentSeparator = "\t# ";
        /// <summary>The default end-of-line comment item separator (默认的行尾注释条目分隔符). </summary>
        public static readonly string DefaultLineCommentItemSeparator = ", ";

        // == Array ==
        /// <summary>
        /// Assigns the given value of type T to each element of the specified array.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to be filled.</param>
        /// <param name="value">The value to assign to each array element.</param>
        /// <see cref="Array.Fill{T}(T[], T)"/>
        public static void Fill<T>(T[] array, T value) {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            Array.Fill(array, value);
#else
            Fill(array, value, 0, array.Length);
#endif
        }

        /// <summary>
        /// Assigns the given value of type T to the elements of the specified array which are within the range of startIndex (inclusive) and the next count number of indices.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The System.Array to be filled.</param>
        /// <param name="value">The new value for the elements in the specified range.</param>
        /// <param name="startIndex">A 32-bit integer that represents the index in the System.Array at which filling begins.</param>
        /// <param name="count">The number of elements to copy.</param>
        /// <see cref="Array.Fill{T}(T[], T, int, int)"/>
        public static void Fill<T>(T[] array, T value, int startIndex, int count) {
#if NETCOREAPP2_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            Array.Fill(array, value, startIndex, count);
#else
            for(int i=0, p=startIndex; i<count; ++i, ++p) {
                array[p] = value;
            }
#endif
        }


        // == Hex ==

        /// <summary>
        /// Gets a hexadecimal string and outputs it to <see cref="Action"/> (取得十六进制字符串, 并输出到 <see cref="Action"/> ).
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="src"/> value (源值的类型).</typeparam>
        /// <param name="action">Output action (输出动作).</param>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Ignore) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Ignore) No fix endian (不修正端序).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int GetHexTo<T>(Action<string> action, T src, string? separator = null, bool noFixEndian = false) {
            int rt = 0;
            string hex = GetHex<T>(src, separator, noFixEndian);
            if (!string.IsNullOrEmpty(hex)) {
                action(hex);
                rt += hex.Length;
            }
            return rt;
        }

        /// <summary>
        /// Gets a hexadecimal string of the <see cref="Vector"/> and outputs it to <see cref="Action"/> (取得 <see cref="Vector"/> 的十六进制字符串, 并输出到 <see cref="Action"/> ).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="action">Output action (输出动作).</param>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Optional) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Optional) No fix endian (不修正端序).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int GetHexTo<T>(Action<string> action, Vector<T> src, string? separator = null, bool noFixEndian = false) where T : struct {
            int rt = 0;
            string hex;
            Vector<byte> list = Vector.AsVectorByte(src);
            int unitCount = Vector<T>.Count;
            int unitSize = Vector<byte>.Count / unitCount;
            bool fixEndian = false;
            if (!noFixEndian && BitConverter.IsLittleEndian) fixEndian = true;
            if (fixEndian) {
                // IsLittleEndian.
                for (int i = 0; i < unitCount; ++i) {
                    if ((i > 0)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            action(separator!);
                            rt += separator!.Length;
                        }
                    }
                    int idx = unitSize * (i + 1) - 1;
                    for (int j = 0; j < unitSize; ++j) {
                        byte by = list[idx];
                        --idx;
                        hex = by.ToString("X2");
                        action(hex);
                        rt += hex.Length;
                    }
                }
            } else {
                for (int i = 0; i < Vector<byte>.Count; ++i) {
                    byte by = list[i];
                    if ((i > 0) && (0 == i % unitSize)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            action(separator!);
                            rt += separator!.Length;
                        }
                    }
                    hex = by.ToString("X2");
                    action(hex);
                    rt += hex.Length;
                }
            }
            return rt;
        }

#if NETCOREAPP3_0_OR_GREATER
        /// <summary>
        /// Gets a hexadecimal string of the <see cref="Vector64"/> and outputs it to <see cref="Action"/> (取得 <see cref="Vector64"/> 的十六进制字符串, 并输出到 <see cref="Action"/> ).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="action">Output action (输出动作).</param>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Optional) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Optional) No fix endian (不修正端序).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int GetHexTo<T>(Action<string> action, Vector64<T> src, string? separator = null, bool noFixEndian = false) where T : struct {
            int rt = 0;
            string hex;
            Vector64<byte> list = Vector64.AsByte(src);
            int unitCount = Vector64<T>.Count;
            int unitSize = Vector64<byte>.Count / unitCount;
            bool fixEndian = false;
            if (!noFixEndian && BitConverter.IsLittleEndian) fixEndian = true;
            if (fixEndian) {
                // IsLittleEndian.
                for (int i = 0; i < unitCount; ++i) {
                    if ((i > 0)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            action(separator);
                            rt += separator.Length;
                        }
                    }
                    int idx = unitSize * (i + 1) - 1;
                    for (int j = 0; j < unitSize; ++j) {
                        byte by = list.GetElement(idx);
                        --idx;
                        hex = by.ToString("X2");
                        action(hex);
                        rt += hex.Length;
                    }
                }
            } else {
                for (int i = 0; i < Vector64<byte>.Count; ++i) {
                    byte by = list.GetElement(i);
                    if ((i > 0) && (0 == i % unitSize)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            action(separator);
                            rt += separator.Length;
                        }
                    }
                    hex = by.ToString("X2");
                    action(hex);
                    rt += hex.Length;
                }
            }
            return rt;
        }

        /// <summary>
        /// Gets a hexadecimal string of the <see cref="Vector128"/> and outputs it to <see cref="Action"/> (取得 <see cref="Vector128"/> 的十六进制字符串, 并输出到 <see cref="Action"/> ).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="action">Output action (输出动作).</param>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Optional) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Optional) No fix endian (不修正端序).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int GetHexTo<T>(Action<string> action, Vector128<T> src, string? separator = null, bool noFixEndian = false) where T : struct {
            int rt = 0;
            string hex;
            Vector128<byte> list = Vector128.AsByte(src);
            int unitCount = Vector128<T>.Count;
            int unitSize = Vector128<byte>.Count / unitCount;
            bool fixEndian = false;
            if (!noFixEndian && BitConverter.IsLittleEndian) fixEndian = true;
            if (fixEndian) {
                // IsLittleEndian.
                for (int i = 0; i < unitCount; ++i) {
                    if ((i > 0)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            action(separator);
                            rt += separator.Length;
                        }
                    }
                    int idx = unitSize * (i + 1) - 1;
                    for (int j = 0; j < unitSize; ++j) {
                        byte by = list.GetElement(idx);
                        --idx;
                        hex = by.ToString("X2");
                        action(hex);
                        rt += hex.Length;
                    }
                }
            } else {
                for (int i = 0; i < Vector128<byte>.Count; ++i) {
                    byte by = list.GetElement(i);
                    if ((i > 0) && (0 == i % unitSize)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            action(separator);
                            rt += separator.Length;
                        }
                    }
                    hex = by.ToString("X2");
                    action(hex);
                    rt += hex.Length;
                }
            }
            return rt;
        }

        /// <summary>
        /// Gets a hexadecimal string of the <see cref="Vector256"/> and outputs it to <see cref="Action"/> (取得 <see cref="Vector256"/> 的十六进制字符串, 并输出到 <see cref="Action"/> ).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="action">Output action (输出动作).</param>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Optional) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Optional) No fix endian (不修正端序).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int GetHexTo<T>(Action<string> action, Vector256<T> src, string? separator = null, bool noFixEndian = false) where T : struct {
            int rt = 0;
            string hex;
            Vector256<byte> list = Vector256.AsByte(src);
            int unitCount = Vector256<T>.Count;
            int unitSize = Vector256<byte>.Count / unitCount;
            bool fixEndian = false;
            if (!noFixEndian && BitConverter.IsLittleEndian) fixEndian = true;
            if (fixEndian) {
                // IsLittleEndian.
                for (int i = 0; i < unitCount; ++i) {
                    if ((i > 0)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            action(separator);
                            rt += separator.Length;
                        }
                    }
                    int idx = unitSize * (i + 1) - 1;
                    for (int j = 0; j < unitSize; ++j) {
                        byte by = list.GetElement(idx);
                        --idx;
                        hex = by.ToString("X2");
                        action(hex);
                        rt += hex.Length;
                    }
                }
            } else {
                for (int i = 0; i < Vector256<byte>.Count; ++i) {
                    byte by = list.GetElement(i);
                    if ((i > 0) && (0 == i % unitSize)) {
                        if (!string.IsNullOrEmpty(separator)) {
                            action(separator);
                            rt += separator.Length;
                        }
                    }
                    hex = by.ToString("X2");
                    action(hex);
                    rt += hex.Length;
                }
            }
            return rt;
        }
#endif

        /// <summary>
        /// Get hexadecimal string (取得十六进制字符串).
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="src"/> value (源值的类型).</typeparam>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Ignore) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Ignore) No fix endian (不修正端序).</param>
        /// <returns>Returns hexadecimal string (返回十六进制字符串).</returns>
        public static string GetHex<T>(T? src, string? separator = null, bool noFixEndian = false) {
            string rt = string.Empty;
            if (null == src) return rt;
            if (null == separator) { } // Ignore warning disable 0168
            if (noFixEndian) { } // Ignore warning disable 0168
            if (src is IFormattable formattable) {
                rt = formattable.ToString("X", null);
            }
            return rt;
        }

        /// <summary>
        /// Gets a hexadecimal string of the <see cref="Vector"/> (取得 <see cref="Vector"/> 的十六进制字符串).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Optional) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Optional) No fix endian (不修正端序).</param>
        /// <returns>Returns hexadecimal string (返回十六进制字符串).</returns>
        public static string GetHex<T>(Vector<T> src, string? separator = null, bool noFixEndian = false) where T : struct {
            StringBuilder sb = new StringBuilder();
            GetHexTo(delegate (string str) {
                sb.Append(str);
            }, src, separator, noFixEndian);
            return sb.ToString();
        }

#if NETCOREAPP3_0_OR_GREATER
        /// <summary>
        /// Gets a hexadecimal string of the <see cref="Vector64"/> (取得 <see cref="Vector64"/> 的十六进制字符串).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Optional) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Optional) No fix endian (不修正端序).</param>
        /// <returns>Returns hexadecimal string (返回十六进制字符串).</returns>
        public static string GetHex<T>(Vector64<T> src, string? separator = null, bool noFixEndian = false) where T : struct {
            StringBuilder sb = new StringBuilder();
            GetHexTo(delegate (string str) {
                sb.Append(str);
            }, src, separator, noFixEndian);
            return sb.ToString();
        }

        /// <summary>
        /// Gets a hexadecimal string of the <see cref="Vector128"/> (取得 <see cref="Vector128"/> 的十六进制字符串).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Optional) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Optional) No fix endian (不修正端序).</param>
        /// <returns>Returns hexadecimal string (返回十六进制字符串).</returns>
        public static string GetHex<T>(Vector128<T> src, string? separator = null, bool noFixEndian = false) where T : struct {
            StringBuilder sb = new StringBuilder();
            GetHexTo(delegate (string str) {
                sb.Append(str);
            }, src, separator, noFixEndian);
            return sb.ToString();
        }

        /// <summary>
        /// Gets a hexadecimal string of the <see cref="Vector256"/> (取得 <see cref="Vector256"/> 的十六进制字符串).
        /// </summary>
        /// <typeparam name="T">The vector element type (向量中的元素的类型).</typeparam>
        /// <param name="src">Source value (源值).</param>
        /// <param name="separator">(Optional) The separator (分隔符).</param>
        /// <param name="noFixEndian">(Optional) No fix endian (不修正端序).</param>
        /// <returns>Returns hexadecimal string (返回十六进制字符串).</returns>
        public static string GetHex<T>(Vector256<T> src, string? separator = null, bool noFixEndian = false) where T : struct {
            StringBuilder sb = new StringBuilder();
            GetHexTo(delegate (string str) {
                sb.Append(str);
            }, src, separator, noFixEndian);
            return sb.ToString();
        }
#endif

        /// <summary>
        /// Format a string, append a hexadecimal string intelligently to the end of the line, and output it to the <see cref="Action"/> (格式化字符串，智能在行尾追加十六进制字符串, 并会输出到 <see cref="Action"/> ). With these parameters: <paramref name="noHex"/>, <paramref name="lineCommentSeparator"/>, <paramref name="lineCommentItemSeparator"/> .
        /// </summary>
        /// <param name="action">Output action (输出动作).</param>
        /// <param name="noHex">(Optional) The comment separator at the end of a line (行尾注释分隔符).</param>
        /// <param name="lineCommentSeparator">(Optional) The end-of-line comment separator (行尾注释分隔符). Default value is <see cref="DefaultLineCommentSeparator"/> .</param>
        /// <param name="lineCommentItemSeparator">(Optional) The end-of-line comment item separator (行尾注释条目分隔符). Default value is <see cref="DefaultLineCommentItemSeparator"/> .</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int FormatTo(Action<string> action, bool? noHex, string? lineCommentSeparator, string? lineCommentItemSeparator, string format, params object?[] args) {
            int rt = 0;
            if (null == lineCommentSeparator) lineCommentSeparator = DefaultLineCommentSeparator;
            if (null == lineCommentItemSeparator) lineCommentItemSeparator = DefaultLineCommentItemSeparator;
            string str = string.Format(format, args);
            if (!string.IsNullOrEmpty(str)) {
                action(str);
                rt += str.Length;
            }
            if (!(noHex ?? false)) {
                if (args.Length > 0) {
                    int countHex = 0;
                    for (int i = 0; i < args.Length; ++i) {
                        object? src = args[i];
                        try {
                            bool isFirst = true;
                            Action<string> actionHex = delegate (string str) {
                                if (string.IsNullOrEmpty(str)) return;
                                if (isFirst) {
                                    isFirst = false;
                                    string separatorItem;
                                    if (countHex <= 0) {
                                        separatorItem = lineCommentSeparator;
                                    } else {
                                        separatorItem = lineCommentItemSeparator;
                                    }
                                    if (!string.IsNullOrEmpty(separatorItem)) {
                                        action(separatorItem);
                                        rt += separatorItem.Length;
                                    }
                                    // begin.
                                    ++countHex;
                                    action("(");
                                    ++rt;
                                }
                                // process str.
                                action(str);
                            };
                            int n = GetHexTo(actionHex, src as dynamic, " ", false);
                            rt += n;
                            if (n>0) {
                                // end.
                                action(")");
                                ++rt;
                            }

                        } catch (Exception ex) {
                            //Debug.WriteLine(src + ": " + ex);
                            if (null != ex) {
                                // [Debug] Use for Debugger.Break .
                            }
                        }
                    }
                }
            }
            return rt;
        }

        /// <summary>
        /// Format a string, append a hexadecimal string intelligently to the end of the line, and output it to the <see cref="Action"/> (格式化字符串，智能在行尾追加十六进制字符串, 并会输出到 <see cref="Action"/> ).
        /// </summary>
        /// <param name="action">Output action (输出动作).</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int FormatTo(Action<string> action, string format, params object?[] args) {
            return FormatTo(action, null, null, null, format, args);
        }

        /// <summary>
        /// Format a string, append a hexadecimal string intelligently to the end of the line (格式化字符串，智能在行尾追加十六进制字符串). With these parameters: <paramref name="noHex"/>, <paramref name="lineCommentSeparator"/>, <paramref name="lineCommentItemSeparator"/> .
        /// </summary>
        /// <param name="noHex">(Optional) The comment separator at the end of a line (行尾注释分隔符).</param>
        /// <param name="lineCommentSeparator">(Optional) The end-of-line comment separator (行尾注释分隔符). Default value is <see cref="DefaultLineCommentSeparator"/> .</param>
        /// <param name="lineCommentItemSeparator">(Optional) The end-of-line comment item separator (行尾注释条目分隔符). Default value is <see cref="DefaultLineCommentItemSeparator"/> .</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns a formatted string (返回格式化后的字符串).</returns>
        public static string Format(bool? noHex, string? lineCommentSeparator, string? lineCommentItemSeparator, string format, params object?[] args) {
            StringBuilder sb = new StringBuilder();
            FormatTo(delegate (string str) {
                sb.Append(str);
            }, noHex, lineCommentSeparator, lineCommentItemSeparator, format, args);
            return sb.ToString();
        }

        /// <summary>
        /// Format a string, append a hexadecimal string intelligently to the end of the line (格式化字符串，智能在行尾追加十六进制字符串).
        /// </summary>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns a formatted string (返回格式化后的字符串).</returns>
        public static string Format(string format, params object?[] args) {
            bool? noHex = null;
            return Format(noHex, null, null, format, args);
        }

        /// <summary>
        /// Writes a formatted string to the text stream, using the same semantics as the <see cref="Format(string, object?[])"/> method (使用与 Format 方法相同的语义，将格式化的字符串写入文本流). With these parameters: <paramref name="indent"/>, <paramref name="noHex"/>, <paramref name="lineCommentSeparator"/>, <paramref name="lineCommentItemSeparator"/> .
        /// </summary>
        /// <param name="indent">The indent.</param>
        /// <param name="textWriter">Output <see cref="TextWriter"/>.</param>
        /// <param name="noHex">(Optional) The comment separator at the end of a line (行尾注释分隔符).</param>
        /// <param name="lineCommentSeparator">(Optional) The end-of-line comment separator (行尾注释分隔符). Default value is <see cref="DefaultLineCommentSeparator"/> .</param>
        /// <param name="lineCommentItemSeparator">(Optional) The end-of-line comment item separator (行尾注释条目分隔符). Default value is <see cref="DefaultLineCommentItemSeparator"/> .</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int Write(string? indent, TextWriter textWriter, bool? noHex, string? lineCommentSeparator, string? lineCommentItemSeparator, string format, params object?[] args) {
            int rt = 0;
            bool isFirst = true;
            Action<string> action = delegate (string hex) {
                if (isFirst) {
                    isFirst = false;
                    if (!string.IsNullOrEmpty(indent)) {
                        textWriter.Write(indent);
                        rt += indent!.Length;
                    }
                }
                textWriter.Write(hex);
            };
            rt += FormatTo(action, noHex, lineCommentSeparator, lineCommentItemSeparator, format, args);
            return rt;
        }

        /// <summary>
        /// Writes a formatted string to the text stream, using the same semantics as the <see cref="Format(string, object?[])"/> method (使用与 Format 方法相同的语义，将格式化的字符串写入文本流). With these parameters: <paramref name="indent"/> .
        /// </summary>
        /// <param name="textWriter">Output <see cref="TextWriter"/>.</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int Write(string? indent, TextWriter textWriter, string format, params object?[] args) {
            bool? noHex = null;
            return Write(indent, textWriter, noHex, null, null, format, args);
        }

        /// <summary>
        /// Writes a formatted string to the text stream, using the same semantics as the <see cref="Format(string, object?[])"/> method (使用与 Format 方法相同的语义，将格式化的字符串写入文本流).
        /// </summary>
        /// <param name="textWriter">Output <see cref="TextWriter"/>.</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int Write(TextWriter textWriter, string format, params object?[] args) {
            return Write(null, textWriter, format, args);
        }

        /// <summary>
        /// Writes a formatted string and a new line to the text stream, using the same semantics as the <see cref="Format(string, object?[])"/> method (使用与 Format 方法相同的语义，将格式化的字符串和新行写入文本流). With these parameters: <paramref name="indent"/>, <paramref name="noHex"/>, <paramref name="lineCommentSeparator"/>, <paramref name="lineCommentItemSeparator"/> .
        /// </summary>
        /// <param name="indent">The indent.</param>
        /// <param name="textWriter">Output <see cref="TextWriter"/>.</param>
        /// <param name="noHex">(Optional) The comment separator at the end of a line (行尾注释分隔符).</param>
        /// <param name="lineCommentSeparator">(Optional) The end-of-line comment separator (行尾注释分隔符). Default value is <see cref="DefaultLineCommentSeparator"/> .</param>
        /// <param name="lineCommentItemSeparator">(Optional) The end-of-line comment item separator (行尾注释条目分隔符). Default value is <see cref="DefaultLineCommentItemSeparator"/> .</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int WriteLine(string? indent, TextWriter textWriter, bool? noHex, string? lineCommentSeparator, string? lineCommentItemSeparator, string format, params object?[] args) {
            int rt = Write(indent, textWriter, noHex, lineCommentSeparator, lineCommentItemSeparator, format, args);
            textWriter.WriteLine();
            return rt;
        }

        /// <summary>
        /// Writes a formatted string and a new line to the text stream, using the same semantics as the <see cref="Format(string, object?[])"/> method (使用与 Format 方法相同的语义，将格式化的字符串和新行写入文本流). With these parameters: <paramref name="indent"/> .
        /// </summary>
        /// <param name="indent">The indent.</param>
        /// <param name="textWriter">Output <see cref="TextWriter"/>.</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int WriteLine(string? indent, TextWriter textWriter, string format, params object?[] args) {
            bool? noHex = null;
            return WriteLine(indent, textWriter, noHex, null, null, format, args);
        }

        /// <summary>
        /// Writes a formatted string and a new line to the text stream, using the same semantics as the <see cref="Format(string, object?[])"/> method (使用与 Format 方法相同的语义，将格式化的字符串和新行写入文本流).
        /// </summary>
        /// <param name="textWriter">Output <see cref="TextWriter"/>.</param>
        /// <param name="format">Format string (格式化字符串).</param>
        /// <param name="args">The args (参数列表).</param>
        /// <returns>Returns the length of the output string (返回输出字符串的长度).</returns>
        public static int WriteLine(TextWriter textWriter, string format, params object?[] args) {
            return WriteLine(null, textWriter, format, args);
        }


    }
}
