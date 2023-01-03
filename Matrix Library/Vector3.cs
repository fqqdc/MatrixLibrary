using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public class Vector3<T> : Vector<T>
        where T : INumberBase<T>
    {
        public Vector3() : base(T.Zero, T.Zero, T.Zero) { }
        public Vector3(T v) : base(v, v, v) { }
        public Vector3(T x, T y, T z) : base(x, y, z) { }
        public ref T X { get => ref base[0]; }
        public ref T Y { get => ref base[1]; }
        public ref T Z { get => ref base[2]; }

        public static implicit operator Vector3<T>(ValueTuple<T, T, T> value)
        {
            return new Vector3<T>(value.Item1, value.Item2, value.Item3);
        }

        public Vector3<T> Cross(Vector3<T> vector)
        {
            return new(Y * vector.Z - Z * vector.Y, Z * vector.X - X * vector.Z, X * vector.Y - Y * vector.X);
        }
    }
}
