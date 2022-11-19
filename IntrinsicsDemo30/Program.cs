using IntrinsicsLib;
using System;
using System.IO;

namespace IntrinsicsDemo30 {
    class Program {
        static void Main(string[] args) {
            string indent = "";
            TextWriter writer = Console.Out;
            writer.WriteLine("IntrinsicsDemo30");
            writer.WriteLine();
            IntrinsicsDemo.OutputEnvironment(writer, indent);
            writer.WriteLine();
            IntrinsicsDemo.Run(writer, indent);
        }
    }
}
