using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace MatrixLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var v2 = new Vector<double>(1, 1);
            Console.WriteLine(v2.GetLength());

            var v3 = new Vector<double>(1, 1, 1);
            Console.WriteLine(v3.GetLength());

            var v4 = new Vector<double>(1, 0, 0, 1);
            Console.WriteLine(v4.GetLength());
        }
    }
}