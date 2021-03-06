using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DIMS_Core.DataAccessLayer.Models;

namespace DIMS_Core.Tests.DataAccessLayer.Infrastructure.Comparer
{
    class EqualityComparator<T> : IEqualityComparer<T>
    {
        private readonly Func<T, ITuple> _deconstruct;

        public EqualityComparator(Func<T, ITuple> deconstruct)
        {
            _deconstruct = deconstruct;
        }

        public bool Equals(T? x, T? y)
        {
            return _deconstruct(x).Equals(_deconstruct(y));
        }

        public int GetHashCode(T obj)
        {
            return _deconstruct(obj).GetHashCode();
        }
    }
}
