using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Vector2<T> : Vector<T>
        where T : INumberBase<T>
    {
        public Vector2() : base(T.Zero, T.Zero) { }
        public Vector2(T v) : base(v, v) { }
        public Vector2(T x, T y) : base(x, y) { }
        public ref T X { get => ref base[0]; }
        public ref T Y { get => ref base[1]; }

        public static implicit operator Vector2<T>(ValueTuple<T, T> value)
        {
            return new Vector2<T>(value.Item1, value.Item2);
        }
    }
}
