using System;
using System.IO;

namespace MathDemo {
    class Program {
        static void Main(string[] args) {
            TextWriter writer = Console.Out;
            Console.WriteLine("MathDemo!");
            writer.WriteLine();
            //writer.WriteLine("(Press Any Key to Continue)");
            //Console.ReadKey();
            writer.WriteLine();
            NumberDivDemo.Run(writer);
        }
    }
}
