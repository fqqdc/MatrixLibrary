using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public static class VectorExtension
    {
        public static T GetLength<T>(this Vector<T> vector) where T : IRootFunctions<T>
        {
            return T.Sqrt(vector.Dot(vector));
        }

        public static Vector<T> Normalize<T>(this Vector<T> vector) where T : IRootFunctions<T>
        {
            return vector / vector.GetLength();
        }

        public static T Dot<T>(this Vector<T> vector1, Vector<T> vector2) where T : INumberBase<T>
        {
            if (vector1.Dimension != vector2.Dimension)
                throw new ArgumentException($"{nameof(vector1)}与{nameof(vector2)}的维度必须相等。");

            T sum = T.Zero;
            for (int i = 0; i < vector1.Dimension; i++)
            {
                sum += vector1.Values[i] * vector2.Values[i];
            }

            return sum;
        }
    }
}
