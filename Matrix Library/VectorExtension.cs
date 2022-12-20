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
            T sum = T.Zero;
            for (int i = 0; i < vector.Dimension; i++)
            {
                sum += vector.Values[i] * vector.Values[i];
            }
            return T.Sqrt(sum);
        }

        public static Vector<T> Normalized<T>(this Vector<T> vector) where T : IRootFunctions<T>
        {
            return vector / vector.GetLength();
        }

        public static Vector<T> Dot<T>(this Vector<T> vector1, Vector<T> vector2) where T : INumberBase<T>
        {
            if (vector1.Dimension != vector2.Dimension)
                throw new ArgumentException($"{nameof(vector1)}与{nameof(vector2)}的维度必须相等。");

            T[] newValue = new T[vector1.Dimension];
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] = vector1.Values[i] * vector2.Values[i];
            }

            return new Vector<T>(newValue);
        }
    }
}
