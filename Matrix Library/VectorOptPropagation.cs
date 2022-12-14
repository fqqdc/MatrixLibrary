using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

namespace MatrixLibrary
{
    public partial class Vector<T> where T : INumberBase<T>
    {
        public static Vector<T> operator +(Vector<T> vector, T scalar)
        {
            var newValue = vector.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] += scalar;
            }

            return new Vector<T>(newValue);
        }

        public static Vector<T> operator -(Vector<T> vector, T scalar)
        {
            var newValue = vector.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] -= scalar;
            }

            return new Vector<T>(newValue);
        }
    }
}