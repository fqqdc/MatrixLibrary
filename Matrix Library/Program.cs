using System;
using System.Dynamic;
using System.Runtime.InteropServices;
using Vector2i = MatrixLibrary.Vector2<int>;


namespace MatrixLibrary
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var v1 = new Vector3<float>(1, 2, 3);
            var v2 = new Vector3<float>(4, 5, 6);
            var v3 = v1.Cross(v2);

            Console.WriteLine(v1.Dot(v2));
            Console.WriteLine(v1.Normalize().Dot(v2.Normalize()));
            Console.WriteLine(v1.Dot(v2)/v1.GetLength()/v2.GetLength());
            Console.WriteLine(v1.Dot(v3));
            Console.WriteLine(v2.Dot(v3));
        }
    }
}