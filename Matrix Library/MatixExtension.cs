using System.Linq;
using System;
using System.Numerics;

namespace MatrixLibrary
{
    public static class MatixExtension
    {
        public static Matrix<T> TransposeMatrix<T>(this Matrix<T> matrix) where T : INumberBase<T>
        {
            Vector<T>[] newVectors = new Vector<T>[matrix[0].Dimension];
            for (int i = 0; i < newVectors.Length; i++)
            {
                T[] scalars =  new T[matrix.VectorCount];
                for (int j = 0; j < matrix.VectorCount; j++)
                {
                    scalars[j] = matrix[j][i];
                }
                newVectors[i] = new(scalars);
            }
            return new(newVectors);
        }

        public static Matrix<T> EasyAdd<T>(this Matrix<T> matrix, T scalar) where T : INumberBase<T>
        {
            var newValue = matrix.Vectors.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] = newValue[i].EasyAdd(scalar);
            }

            return new Matrix<T>(newValue);
        }

        public static Matrix<T> EasyAdd<T>(this Matrix<T> matrix, Vector<T> vector) where T : INumberBase<T>
        {
            if (matrix[0].Dimension != vector.Dimension)
                throw new ArgumentException($"{nameof(matrix)}矩阵中的向量维度({matrix[0].Dimension})与{nameof(vector)}向量维度({vector.Dimension})不一致。");

            var newValue = matrix.Vectors.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] += vector;
            }

            return new Matrix<T>(newValue);
        }

        public static Matrix<T> EasyMul<T>(this Matrix<T> matrix, Vector<T> vector) where T : INumberBase<T>
        {
            if (matrix[0].Dimension != vector.Dimension)
                throw new ArgumentException($"{nameof(matrix)}矩阵中的向量维度({matrix[0].Dimension})与{nameof(vector)}向量维度({vector.Dimension})不一致。");

            var newValue = matrix.Vectors.ToArray();
            for (int i = 0; i < newValue.Length; i++)
            {
                newValue[i] = newValue[i].EasyMul(vector);
            }

            return new Matrix<T>(newValue);
        }
    }
}