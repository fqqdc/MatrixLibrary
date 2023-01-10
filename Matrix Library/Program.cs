using System;
using Vector2i = MatrixLibrary.Vector2<int>;


namespace MatrixLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> m1 = new((1, 3), (2, 4));
            Matrix<int> m2 = new((6, 8), (7, 9));

            Console.WriteLine(m1);
            Console.WriteLine(m2);
            Console.WriteLine(m1 * m2);
        }
    }
}