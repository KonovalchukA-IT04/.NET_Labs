using System;
using System.Collections;
using System.Collections.Generic;

namespace SortedList
{
    public class OwnSortedList<T> : ICollection<T>
    {
        private OwnList<T> _list;
        private Comparer<T> _comparer;

        public bool ConnectEvents(bool flag)
        {
            _list.ConnectEvents(flag);
            return flag;
        }

        public OwnSortedList() : this(Comparer<T>.Default)
        {
        }

        public OwnSortedList(Comparer<T> comparer)
        {
            _list = new OwnList<T>();
            _comparer = comparer;
        }

        public void Add(T item)
        {
            int insertIndex = FindIndex(_list, _comparer, item);
            if (insertIndex == _list.Size)
                _list.Add(item);
            else
                _list.InsertAt(item, insertIndex);
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public int IndexOf(T item)
        {
            int insertIndex = FindIndex(_list, _comparer, item);
            if (insertIndex == _list.Count)
            {
                return -1;
            }
            if (_comparer.Compare(item, _list[insertIndex]) == 0)
            {
                int index = insertIndex;
                while (index > 0 && _comparer.Compare(item, _list[index - 1]) == 0)
                {
                    index--;
                }
                return index;
            }
            return -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                _list.RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public void CopyTo(T[] array)
        {
            _list.CopyTo(array);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public T this[int index]
        {
            get
            {
                return _list[index];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public static int FindIndex(OwnList<T> list, Comparer<T> comparer, T item)
        {
            if (list.Count == 0)
            {
                return 0;
            }

            int lowerIndex = 0;
            int upperIndex = list.Count - 1;
            int comparisonResult;
            while (lowerIndex < upperIndex)
            {
                int middleIndex = (lowerIndex + upperIndex) / 2;
                T middle = list[middleIndex];
                comparisonResult = comparer.Compare(middle, item);
                if (comparisonResult == 0)
                {
                    return middleIndex;
                }
                else if (comparisonResult > 0)
                {
                    upperIndex = middleIndex - 1;
                }
                else
                {
                    lowerIndex = middleIndex + 1;
                }
            }

            comparisonResult = comparer.Compare(list[lowerIndex], item);
            if (comparisonResult < 0)
            {
                return lowerIndex + 1;
            }
            else
            {
                return lowerIndex;
            }
        }
    }
}
