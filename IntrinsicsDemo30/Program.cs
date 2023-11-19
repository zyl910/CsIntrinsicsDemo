using IntrinsicsLib;
using System;
using System.IO;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace IntrinsicsDemo30 {
    class Program {
        static void Main(string[] args) {
            string indent = "";
            TextWriter writer = Console.Out;
//#if NET8_0_OR_GREATER
//            writer.WriteLine(string.Format("Vector512.IsHardwareAccelerated:\t{0}", Vector512.IsHardwareAccelerated));
//            writer.WriteLine(string.Format("Vector.IsHardwareAccelerated:\t{0}", Vector.IsHardwareAccelerated));
//            writer.WriteLine(string.Format("Vector<byte>.Count:\t{0}\t# {1}bit", Vector<byte>.Count, Vector<byte>.Count * sizeof(byte) * 8));
//#endif // NET8_0_OR_GREATER
            writer.WriteLine("IntrinsicsDemo30");
            writer.WriteLine();
            IntrinsicsDemo.OutputEnvironment(writer, indent);
            //writer.WriteLine("(Press Any Key to Continue)");
            //Console.ReadKey();
            writer.WriteLine();
            IntrinsicsDemo.Run(writer, indent);
        }
    }
}
