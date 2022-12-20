using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    public static class VectorExtension
    {
        public static T GetLength<T>(this Vector<T> vector) 
            where T : IRootFunctions<T>
        {
            T sum = T.Zero;
            for (int i = 0; i < vector.Dimension; i++)
            {
                sum += vector.Values[i] * vector.Values[i];
            }
            return T.Sqrt(sum);
        }
    }
}
