using IntrinsicsLib;
using System;
using System.IO;

namespace IntrinsicsDemo30 {
    class Program {
        static void Main(string[] args) {
            string indent = "";
            TextWriter tw = Console.Out;
            tw.WriteLine("IntrinsicsDemo30");
            tw.WriteLine();
            IntrinsicsDemo.OutputEnvironment(tw, indent);
            tw.WriteLine();
            IntrinsicsDemo.Run(tw, indent);
        }
    }
}
