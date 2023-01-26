using System.Linq;
using System;
using System.Numerics;
using System.Runtime.Intrinsics;

namespace MatrixLibrary
{
    public static class MatixExtension
    {
        public static Matrix<T> Transpose<T>(this Matrix<T> matrix) where T : INumberBase<T>
        {
            Matrix<T> result = new(matrix.VectorCount, matrix.VectorDimension);
            for (int y = 0; y < matrix.VectorCount; y++)
            {
                for (int x = 0; x < matrix.VectorDimension; x++)
                {
                    result[y, x] = matrix[x, y];
                }
            }
            return result;
        }

        public static bool Invert<T>(this Matrix<T> matrix, out Matrix<T> result) where T : INumberBase<T>
        {
            if (matrix.VectorCount != matrix.VectorDimension)
                throw new ArgumentException($"{nameof(matrix)}矩阵不是方阵。");

            var m_rows = matrix.Transpose().Vectors.ToArray();

            var iMatrix = Matrix<T>.GetIdentity(matrix.VectorCount);
            var i_rows = iMatrix.Vectors.ToArray();
            bool bResult = false;
            try
            {
                for (int i = 0; i < iMatrix.VectorDimension; i++)
                {
                    var rowHeader = m_rows[i][i];
                    if (rowHeader == T.Zero)
                        return bResult = false;
                    m_rows[i] /= rowHeader;
                    i_rows[i] /= rowHeader;
                    for (int i2 = 0; i2 < iMatrix.VectorDimension; i2++)
                    {
                        if (i2 == i || m_rows[i2][i] == T.Zero) continue;
                        var rowHeader2 = m_rows[i2][i];
                        m_rows[i2] -= m_rows[i] * rowHeader2;
                        i_rows[i2] -= i_rows[i] * rowHeader2; ;
                    }
                }
                return bResult = true;
            }
            finally
            {
                if (bResult) result = new Matrix<T>(i_rows).Transpose();
                else result = Matrix<T>.GetZero(matrix.VectorCount);
            }
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