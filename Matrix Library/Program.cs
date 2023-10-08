using System;
using System.Runtime.InteropServices;
using Vector2i = MatrixLibrary.Vector2<int>;


namespace MatrixLibrary
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Matrix<float> m = new((1, 2, 5), (4, 6, 7), (3, 8, 9));
            Console.WriteLine(m);
            if(!m.Invert(out var vm))
            {
                Console.WriteLine("Invert false");
                return;
            }
            Console.WriteLine(vm);
            Console.WriteLine(m.Cross(vm));
        }
    }
}