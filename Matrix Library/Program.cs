using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace MatrixLibrary
{
    class Vector3F : Vector<float>
    {
        public Vector3F(float v) : base(v, v, v) { }
        public Vector3F(float v1, float v2, float v3) : base(v1,v2,v3) { }

        public static implicit operator Vector3F(float value)
        {
            return new Vector3F(value);
        }

        public static implicit operator Vector3F(ValueTuple<float> values)
        {
            return new Vector3F(values.Item1);
        }

        public static implicit operator Vector3F(ValueTuple<float, float, float> values)
        {
            return new Vector3F(values.Item1, values.Item2, values.Item3);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vector3F v = (1, 2, 3);
            Console.WriteLine(v);

            Matrix<int> m = new((1, 2), (2, 3), (3, 4));
            Console.WriteLine(m);

            Console.WriteLine(m.ToMultilineString());
        }
    }
}