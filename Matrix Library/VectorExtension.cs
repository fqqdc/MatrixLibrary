using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public static class VectorExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetLength<T>(this Vector<T> vector) where T : IRootFunctions<T>
        {
            return T.Sqrt(vector.GetLengthSquared());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetLengthSquared<T>(this Vector<T> vector) where T : IRootFunctions<T>
        {
            T result = T.Zero;
            for (int i = 0; i < vector.Length; i++)
            {
                result += vector[i] * vector[i];
            }
            return result;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Vector<T> Normalize<T>(this Vector<T> vector) where T : IRootFunctions<T>
        {
            return vector / vector.GetLength();
        }

        public static T Dot<T>(this Vector<T> vector1, Vector<T> vector2) where T : INumberBase<T>
        {
            if (vector1.Length != vector2.Length)
                throw new ArgumentException($"{nameof(vector1)}与{nameof(vector2)}的维度必须相等。");

            T sum = T.Zero;
            for (int i = 0; i < vector1.Length; i++)
            {
                sum += vector1[i] * vector2[i];
            }

            return sum;
        }

        public static Vector<T> Projection<T>(this Vector<T> vector1, Vector<T> vector2) where T : INumberBase<T>
        {
            return vector1.Dot(vector2) * vector2;
        }


        public static Vector<T> EasyAdd<T>(this Vector<T> vector, T scalar) where T : INumberBase<T>
        {
            var newValue = vector.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] += scalar;
            }

            return new Vector<T>(newValue);
        }

        public static Vector<T> EasyMul<T>(this Vector<T> vector1, Vector<T> vector2) where T : INumberBase<T>
        {
            if (vector1.Length != vector2.Length)
                throw new ArgumentException($"{nameof(vector1)}与{nameof(vector2)}的维度必须相等。");

            var newValue = vector1.Values.ToArray();
            for (int i = 0; i < vector1.Length; i++)
            {
                newValue[i] *= vector2[i];
            }

            return new(newValue);
        }
    }
}
