using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using Vector3F = MatrixLibrary.Vector3<float>;

namespace MatrixLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector3F v1 = (1.7f, 2, 3), v2 = (4, 5, 6.8f);

            Vector3 v31 = new(1.7f, 2, 3), v32 = new(4, 5, 6.8f);

            Console.WriteLine(v1.Cross(v2));
            Console.WriteLine(Vector3.Cross(v31, v32));

            Console.WriteLine(v2.Cross(v1));
            Console.WriteLine(Vector3.Cross(v32, v31));
        }
    }
}