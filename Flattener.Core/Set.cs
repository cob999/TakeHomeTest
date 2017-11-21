using System;

namespace Flattener.Core
{
    public class Set<T>
    {
        private T[] _backingArray;

        private const int IncrementSize = 5;

        public Set()
        {
            _backingArray = new T[IncrementSize];
        }

        public int Count { get; private set; }

        public void Add(T value)
        {
            if (!Contains(value))
            {
                if (Count == _backingArray.Length)
                {
                    ExpandArray();
                }
                _backingArray[Count++] = value;
            }
        }

        public void Remove(T value)
        {
            if (Contains(value))
            {
            }
        }

        private void ExpandArray()
        {
            var oldSize = _backingArray.Length;
            var newSize = oldSize + 5;

            Array.Resize(ref _backingArray, newSize);
        }

        public bool Contains(T value)
        {
            foreach (var item in _backingArray)
            {
                if (item.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}