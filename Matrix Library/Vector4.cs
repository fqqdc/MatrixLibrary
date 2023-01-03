using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Vector4<T> : Vector<T>
        where T : INumberBase<T>
    {
        public Vector4() : base(T.Zero, T.Zero, T.Zero, T.Zero) { }
        public Vector4(T v) : base(v, v, v, v) { }
        public Vector4(T x, T y, T z, T w) : base(x, y, z, w) { }
        public ref T X { get => ref base[0]; }
        public ref T Y { get => ref base[1]; }
        public ref T Z { get => ref base[2]; }
        public ref T W { get => ref base[3]; }

        public static implicit operator Vector4<T>(ValueTuple<T, T, T, T> value)
        {
            return new Vector4<T>(value.Item1, value.Item2, value.Item3, value.Item4);
        }
    }
}
