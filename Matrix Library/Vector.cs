using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
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
            AliasFactory = new VectorAliasFactory<T>(this);
        }

        public override string ToString()
        {
            return $"< {string.Join(", ", values)} >";
        }

        public dynamic AliasFactory { get; init; }
    }

    internal class VectorAliasFactory<T> : DynamicObject
        where T : INumberBase<T>
    {
        static Dictionary<char, int> char2Index = new()
        {
            ['b'] = 0,
            ['g'] = 1,
            ['r'] = 2,
            ['a'] = 3,
            ['x'] = 0,
            ['y'] = 1,
            ['z'] = 2,
            ['w'] = 3,
        };

        private Vector<T> vector;

        public VectorAliasFactory(Vector<T> _vector) => vector = _vector;

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            string aliasName = binder.Name.ToLower();
            var names = aliasName.ToCharArray();

            T[] values = names.Select(c =>
            {
                if (!char2Index.ContainsKey(c))
                    return T.Zero;
                int index = char2Index[c];
                if(index >= vector.Length) 
                    return T.Zero;
                return vector[index];

                }).ToArray();

            result = new Vector<T>(values);
            return true;
        }
    }
}