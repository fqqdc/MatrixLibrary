using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MatrixLibrary
{
    public partial class Matrix<T> where T : INumberBase<T>
    {
        public static Matrix<T>operator+(Matrix<T> matrix, T scalar)
        {
            var newValue = matrix.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] += scalar;
            }

            return new Matrix<T>(newValue);
        }

        public static Matrix<T> operator -(Matrix<T> matrix, T scalar)
        {
            var newValue = matrix.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] -= scalar;
            }

            return new Matrix<T>(newValue);
        }

        public static Matrix<T> operator +(Matrix<T> matrix, Vector<T> vector)
        {
            if (matrix[0].Dimension != vector.Dimension)
                throw new ArgumentException($"{nameof(matrix)}矩阵中的向量维度({matrix[0].Dimension})与{nameof(vector)}向量维度({vector.Dimension})不一致。");

            var newValue = matrix.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] += vector;
            }

            return new Matrix<T>(newValue);
        }

        public static Matrix<T> operator -(Matrix<T> matrix, Vector<T> vector)
        {
            if (matrix[0].Dimension != vector.Dimension)
                throw new ArgumentException($"{nameof(matrix)}矩阵中的向量维度({matrix[0].Dimension})与{nameof(vector)}向量维度({vector.Dimension})不一致。");

            var newValue = matrix.Values.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] -= vector;
            }

            return new Matrix<T>(newValue);
        }
    }
}