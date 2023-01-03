using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

namespace MatrixLibrary
{
    public partial class Vector<T>
        where T : INumberBase<T>
    {
        public static Vector<T> operator *(Vector<T> vector, T scalar)
        {
            var newValue = vector.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] *= scalar;
            }

            return new Vector<T>(newValue);
        }
        public static Vector<T> operator /(Vector<T> vector, T scalar)
        {
            var newValue = vector.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] /= scalar;
            }

            return new Vector<T>(newValue);
        }

        public static Vector<T> operator +(Vector<T> vector1, Vector<T> vector2)
        {
            if (vector1.Dimension != vector2.Dimension)
                throw new ArgumentException($"{nameof(vector1)}与{nameof(vector2)}的维度必须相等。");

            int size = vector1.values.Length;
            T[] newValue = new T[size];
            for (int i = 0; i < size; i++)
            {
                newValue[i] = vector1.values[i] + vector2.values[i];
            }

            return new Vector<T>(newValue);
        }

        public static Vector<T> operator -(Vector<T> vector1)
        {
            int size = vector1.values.Length;
            T[] newValue = new T[size];
            for (int i = 0; i < size; i++)
            {
                newValue[i] = -vector1.values[i];
            }

            return new Vector<T>(newValue);
        }

        public static Vector<T> operator -(Vector<T> vector1, Vector<T> vector2)
        {
            return vector1 + (-vector2);
        }

        public static implicit operator Vector<T>(ValueTuple<T> value)
        {
            return new Vector<T>(value.Item1);
        }

        public static implicit operator Vector<T>(ValueTuple<T, T> value)
        {
            return new Vector<T>(value.Item1, value.Item2);
        }

        public static implicit operator Vector<T>(ValueTuple<T, T, T> value)
        {
            return new Vector<T>(value.Item1, value.Item2, value.Item3);
        }

        public static implicit operator Vector<T>(ValueTuple<T, T, T, T> value)
        {
            return new Vector<T>(value.Item1, value.Item2, value.Item3, value.Item4);
        }

        public static Vector<T> GetZero(int dimension)
        {
            T[] values = new T[dimension];
            Array.Fill(values, T.Zero);
            return new(values);
        }
    }
}