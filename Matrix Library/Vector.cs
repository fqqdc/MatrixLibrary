using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

namespace MatrixLibrary
{
    public partial class Vector<T>
    {
        private T[] values;
        public IEnumerable<T> Values
        {
            get => values.AsEnumerable();
        }

        public ref T this[int index] { get => ref values[index]; }

        public int Length { get => values.Length; }

        public Vector(params T[] values)
        {
            if (values.Length == 0)
                throw new ArgumentException($"{nameof(values)}中的标量数量为零。向量中的标量数量不能为零。");
            this.values = (T[])values.Clone();
        }

        public override string ToString()
        {
            return $"< {string.Join(", ", values)} >";
        }
    }
}