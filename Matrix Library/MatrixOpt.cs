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
        public static Matrix<T> operator *(Matrix<T> matrix, T scalar)
        {
            var vectors = matrix.Vectors.ToArray();
            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i] *= scalar;
            }

            return new Matrix<T>(vectors);
        }

        public Matrix<T> Dot(Matrix<T> matrix2)
        {
            Matrix<T> matrix1 = this;

            if (matrix1.VectorLength != matrix2.VectorLength)
                throw new ArgumentException($"{nameof(matrix1)}矩阵行数({matrix1.VectorLength})与{nameof(matrix2)}矩阵行数({matrix2.VectorLength})不一致。");
            if (matrix1.VectorCount != matrix2.VectorCount)
                throw new ArgumentException($"{nameof(matrix1)}矩阵列数({matrix1.VectorCount})与{nameof(matrix2)}矩阵列数({matrix2.VectorCount})不一致。");


            Matrix<T> resultMatrix = new(matrix1.VectorLength, matrix1.VectorCount);

            for (int j = 0; j < resultMatrix.VectorCount; j++)
            {
                for (int i = 0; i < resultMatrix.VectorLength; i++)
                {
                    resultMatrix[i, j] = matrix1[i, j] * matrix2[i, j];
                }
            }

            return resultMatrix;
        }

        public Matrix<T> Cross(Matrix<T> matrix2)
        {
            Matrix<T> matrix1 = this;

            var m1row = matrix1[0].Length; //矩阵1中的向量维度
            var m2row = matrix2[0].Length; //矩阵2中的向量维度

            if (matrix1.VectorCount != m2row)
                throw new ArgumentException($"{nameof(matrix1)}矩阵列数({matrix1.VectorCount})与{nameof(matrix2)}矩阵行数({m2row})不一致。");

            // 结果矩阵中向量数量与矩阵2的向量数量相同
            Vector<T>[] resultVectors = new Vector<T>[matrix2.VectorCount];
            // 遍历矩阵2中的每一个向量
            for (int m2VectorIndex = 0; m2VectorIndex < matrix2.VectorCount; m2VectorIndex++)
            {
                //结果矩阵中的向量与矩阵1中的向量维度相同
                resultVectors[m2VectorIndex] = Vector<T>.GetZero(m1row);
                // 遍历矩阵1中的每一个向量
                for (int m1VectorIndex = 0; m1VectorIndex < matrix1.VectorCount; m1VectorIndex++)
                {
                    //矩阵2向量中的每一个标量对应矩阵1的向量，并且与之乘积
                    var v = matrix1[m1VectorIndex] * matrix2[row: m1VectorIndex, col: m2VectorIndex];
                    //结果矩阵中的向量等于乘积之和
                    resultVectors[m2VectorIndex] += v;
                }
            }

            return new(resultVectors);
        }

        public static Matrix<T> operator +(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            int m1row = 0; //矩阵1中的向量维度
            if (matrix1.VectorCount != 0)
                m1row = matrix1[0].Length;

            int m2row = 0; //矩阵2中的向量维度
            if (matrix2.VectorCount != 0)
                m2row = matrix2[0].Length;

            if (m1row != m2row || matrix1.VectorCount != matrix2.VectorCount)
                throw new ArgumentException($"{nameof(matrix1)}矩阵与{nameof(matrix2)}矩阵行列数必须相等。");

            int size = matrix1.values.Length;
            var newValue = new Vector<T>[size];
            for (int i = 0; i < size; i++)
            {
                newValue[i] = matrix1[i] + matrix2[i];
            }

            return new Matrix<T>(newValue);
        }

        public static Matrix<T> operator -(Matrix<T> matrix1)
        {
            int size = matrix1.values.Length;
            var newValue = new Vector<T>[size];
            for (int i = 0; i < size; i++)
            {
                newValue[i] = -matrix1[i];
            }

            return new Matrix<T>(newValue);
        }

        public static Matrix<T> operator -(Matrix<T> matrix1, Matrix<T> matrix2)
        {
            return matrix1 + (-matrix2);
        }

        public static Matrix<T> GetZero(int dimension)
        {
            Vector<T>[] vectors = new Vector<T>[dimension];
            Array.Fill(vectors, Vector<T>.GetZero(dimension));
            return new(vectors);
        }

        public static Matrix<T> GetIdentity(int dimension)
        {
            Vector<T>[] vectors = new Vector<T>[dimension];
            for (int i = 0; i < dimension; i++)
            {
                T[] scalars = new T[dimension];
                scalars[i] = T.One;
                vectors[i] = new(scalars);
            }
            return new(vectors);
        }
    }
}