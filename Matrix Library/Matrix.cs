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
        private int vectorLength;
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

        public IEnumerable<T> Values { get => values.AsEnumerable(); }

        public Vector<T> this[int index] { get => new(values[(index * vectorLength)..(index * vectorLength + vectorLength)]); }
        public ref T this[int row, int col] { get => ref values[col * vectorLength + row]; }

        public int VectorLength { get => vectorLength; }
        public int VectorCount { get => vectorCount; }        

        public Matrix(params Vector<T>[] vectors)
        {
            if (vectors.Length == 0)
                throw new ArgumentException($"{nameof(vectors)}中的向量数量为零。矩阵中的向量数量不能为零。");

            int dimension = vectors[0].Length;
            if (vectors.Any(value => value.Length != dimension))
                throw new ArgumentException($"{nameof(vectors)}中的向量维度必须相等。");

            vectorLength = dimension;
            vectorCount = vectors.Length;
            values = new T[dimension * vectorCount];
            for (int i = 0; i < vectorCount; i++)
                Array.Copy(vectors[i].Values.ToArray(), 0, values, i * dimension, dimension);
        }

        public Matrix(int vectorLength, int vectorCount)
        {
            this.vectorLength = vectorLength;
            this.vectorCount = vectorCount;
            values = new T[vectorLength * vectorCount];
        }

        public Matrix(int vectorLength, int vectorCount, params T[] values) 
            : this(vectorLength, vectorCount)
        {
            Array.Copy(values, this.values, values.Length);
        }

        public override string ToString()
        {
            return ToStringByColumn();
        }

        public string ToStringByColumn()
        {
            return $"[ {string.Join(", ", Vectors)} ]";
        }

        public string ToStringByRow()
        {
            StringBuilder sb = new();
            sb.Append("{ ");
            for (int i = 0; i < vectorLength; i++)
            {
                sb.Append("{ ");
                for (int j = 0; j < vectorCount; j++)
                {
                    sb.Append(values[j * vectorLength + i]);
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