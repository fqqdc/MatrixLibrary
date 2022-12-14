using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

namespace MatrixLibrary
{
    public partial class Vector<T> where T : INumberBase<T>
    {
        private T[] values;
        public IReadOnlyList<T> Values
        {
            get { return new ReadOnlyCollection<T>(values); }
        }

        public T this[int index] { get => values[index]; }

        public int Dimension { get => values.Length; }

        public Vector(params T[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException($"{nameof(values)}中的标量数量为零。向量中的标量数量不能为零。");
            this.values = (T[])values.Clone();
        }

        public override string ToString()
        {
            return $"[{string.Join(',', values)}]";
        }
    }
}