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
        private Vector<T>[] values;
        public IReadOnlyList<Vector<T>> Values
        {
            get { return new ReadOnlyCollection<Vector<T>>(values); }
        }

        public Vector<T> this[int index] { get => values[index]; }

        public int VectorCount { get => values.Length; }

        public Matrix(params Vector<T>[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException($"{nameof(values)}中的向量数量为零。矩阵中的向量数量不能为零。");

            int dimension = values[0].Dimension;
            if (values.Any(value => value.Dimension != dimension))
                throw new ArgumentException($"{nameof(values)}中的向量维度必须相等。");

            this.values = (Vector<T>[])values.Clone();
        }

        public string ToMultilineString ()
        {
            const string TAG = "M";

            StringBuilder sb = new();

            int nVector = values.Length;
            int nScalar = values[0].Dimension;

            int[] maxScalarLength = new int[nVector];
            for (int i = 0; i < nVector; i++)
            {
                for (int j = 0; j < nScalar; j++)
                {
                    maxScalarLength[i] = Math.Max(maxScalarLength[i], (this[i][j].ToString() ?? string.Empty).Length);
                }
            }

            for (int i = 0; i < nScalar; i++)
            {
                for (int j = 0; j < nVector; j++)
                {
                    if (j == 0)
                    {
                        if (i == 0) sb.Append(TAG);
                        else sb.Append("".PadLeft(TAG.Length));

                        sb.Append("|");
                    }
                    else sb.Append(" ");

                    string strScalar = (this[j][i].ToString() ?? string.Empty)
                        .PadRight(maxScalarLength[j]);
                    sb.Append(strScalar);
                }
                sb.Append("|");
                if (i < nScalar - 1) sb.AppendLine();
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return $"[ {string.Join(", ", (object[])values)} ]";
        }
    }
}