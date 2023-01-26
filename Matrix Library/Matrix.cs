using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;

namespace MatrixLibrary
{
    public partial class Matrix<T>
    {
        private int vectorDimension;
        private int vectorCount;
        private T[] values;

        public IEnumerable<Vector<T>> Vectors
        {
            get
            {
                for (int i = 0; i < vectorCount; i++)
                {
                    yield return this[i];
                }
            }
        }

        public Vector<T> this[int index] { get => new(values[(index * vectorDimension)..(index * vectorDimension + vectorDimension)]); }
        public ref T this[int row, int col] { get => ref values[col * vectorDimension + row]; }

        public int VectorDimension { get => vectorDimension; }
        public int VectorCount { get => vectorCount; }

        public Matrix(params Vector<T>[] vectors)
        {
            if (vectors.Length == 0)
                throw new ArgumentException($"{nameof(vectors)}中的向量数量为零。矩阵中的向量数量不能为零。");

            int dimension = vectors[0].Dimension;
            if (vectors.Any(value => value.Dimension != dimension))
                throw new ArgumentException($"{nameof(vectors)}中的向量维度必须相等。");

            vectorDimension = dimension;
            vectorCount = vectors.Length;
            values = new T[dimension * vectorCount];
            for (int i = 0; i < vectorCount; i++)
                Array.Copy(vectors[i].Values.ToArray(), 0, values, i * dimension, dimension);
        }

        public Matrix(int vectorDimension, int vectorCount)
        {
            this.vectorDimension = vectorDimension;
            this.vectorCount = vectorCount;
            values = new T[vectorDimension * vectorCount];
        }

        public Matrix(T[,] array)
        {
            vectorDimension = array.GetLength(0);
            vectorCount = array.GetLength(1);
            values = new T[vectorDimension * vectorCount];
            for (int j = 0; j < vectorCount; j++)
            {
                for (int i = 0; i < vectorDimension; i++)
                {
                    values[vectorDimension * j + i] = array[i, j];
                }
            }
        }

        public override string ToString()
        {
            return ToStringByRow();
        }

        public string ToStringByColumn()
        {
            return $"[ {string.Join(", ", Vectors)} ]";
        }

        public string ToStringByRow()
        {
            StringBuilder sb = new();
            sb.Append("{ ");
            for (int i = 0; i < vectorDimension; i++)
            {
                sb.Append("{ ");
                for (int j = 0; j < vectorCount; j++)
                {
                    sb.Append(values[j * vectorDimension + i]);
                    sb.Append(", ");
                }
                sb.Length -= 2;
                sb.Append(" } ");
            }
            sb.Length -= 1;
            sb.Append(" }");

            return sb.ToString();
        }
    }
}