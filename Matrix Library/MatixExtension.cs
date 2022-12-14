using System.Numerics;

namespace MatrixLibrary
{
    public static class MatixExtension
    {
        public static Matrix<T> TransposeMatrix<T>(this Matrix<T> matrix) where T : INumberBase<T>
        {
            Vector<T>[] newVectors = new Vector<T>[matrix[0].Dimension];
            for (int i = 0; i < newVectors.Length; i++)
            {
                T[] scalars =  new T[matrix.VectorCount];
                for (int j = 0; j < matrix.VectorCount; j++)
                {
                    scalars[j] = matrix[j][i];
                }
                newVectors[i] = new(scalars);
            }
            return new(newVectors);
        }
    }
}