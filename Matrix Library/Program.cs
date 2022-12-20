using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace MatrixLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var v2 = new Vector<float>(1, 1);
            Console.WriteLine(v2.GetLength());
            Console.WriteLine(v2.Normal());

            var v3 = new Vector<float>(1, 1, 1);
            Console.WriteLine(v3.GetLength());
            Console.WriteLine(v3.Normal());

            var v4 = new Vector<float>(1, 1, 1, 1);
            Console.WriteLine(v4.GetLength());
            Console.WriteLine(v4.Normal());
        }
    }
}