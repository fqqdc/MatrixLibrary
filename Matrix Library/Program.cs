using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace MatrixLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> m1 = new(new(1), new(2), new(3));
            Console.WriteLine(m1);
            
            Matrix<int> m2 = new(new Vector<int>(1, 2, 3));
            Console.WriteLine(m2);

            Console.WriteLine(m1 * m2);
            Console.WriteLine(m2 * m1);
            //var m = (m2 * m1).TransposeMatrix() + new Vector<int>(10, 20, 30);
            var m = (m2 * m1).TransposeMatrix() * 100;
            Console.WriteLine(m.TransposeMatrix());

            Matrix<double> m3 = new(new(1.2, 2.3), new(3.4, 4.5));
            Console.WriteLine(m3);
            Console.WriteLine(m3 * m3);
            Console.WriteLine(m3 + m3);

            Console.WriteLine(Matrix<double>.GetIdentity(3));
            Console.WriteLine(Matrix<double>.GetIdentity(5));
        }
    }
}