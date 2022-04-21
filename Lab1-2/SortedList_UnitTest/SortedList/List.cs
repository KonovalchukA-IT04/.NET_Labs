using System;
using System.Collections;
using System.Collections.Generic;

namespace SortedList
{
    public delegate void ListHandler();
    public class OwnList<T> : ICollection<T>
    {

        public event ListHandler ElementAdded;
        protected virtual void OnElementAdded()
        {
            if (ElementAdded != null)
                ElementAdded(); 
        }

        public event ListHandler ElementRemoved;
        protected virtual void OnElementRemoved()
        {
            if (ElementRemoved != null)
                ElementRemoved();
        }

        public event ListHandler CollectionCleared;
        protected virtual void OnCollectionCleared()
        {
            if (CollectionCleared != null)
                CollectionCleared();
        }

        public void ConnectEvents(bool flag)
        {
            if (flag && !CheckTheEvents())
            {
                this.ElementAdded += new ListHandler(ElementAddedMessage);
                this.ElementRemoved += new ListHandler(ElementRemovedMessage);
                this.CollectionCleared += new ListHandler(CollectionClearedMessage);
            }
            else if(!flag && CheckTheEvents())
            {
                this.ElementAdded -= new ListHandler(ElementAddedMessage);
                this.ElementRemoved -= new ListHandler(ElementRemovedMessage);
                this.CollectionCleared -= new ListHandler(CollectionClearedMessage);
            }
        }

        private bool CheckTheEvents()
        {
            if (ElementAdded != null && ElementRemoved != null && CollectionCleared != null)
                return true;
            else
                return false;
        }

        void ElementAddedMessage() => Console.WriteLine("Element has been added");
        void ElementRemovedMessage() => Console.WriteLine("Element has been removed");
        void CollectionClearedMessage() => Console.WriteLine("Collection has been cleared");

        private T[] _array;
        private int _size = 0;
        private int _capacity;

        public OwnList(int initialCapacity = 8)
        {
            if (initialCapacity < 1) initialCapacity = 1;
            this._capacity = initialCapacity;
            _array = new T[initialCapacity];
        }

        public int Size 
        {
            get 
            {
                return _size; 
            } 
        }
        public bool IsEmpty
        { 
            get 
            { 
                return _size == 0; 
            } 
        }

        public T GetAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            return _array[index];
        }

        public void SetAt(T item, int index)
        {
            ThrowIfIndexOutOfRange(index);
            ThrowIfArgumentNull(item);
            _array[index] = item;
        }

        public void InsertAt(T item, int index)
        {
            ThrowIfIndexOutOfRange(index);
            ThrowIfArgumentNull(item);
            if (_size == _capacity)
            {
                Resize();
            }

            for (int i = _size; i > index; i--)
            {
                _array[i] = _array[i - 1];
            }

            _array[index] = item;
            _size++;

            OnElementAdded();
        }

        public void RemoveAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            for (int i = index; i < _size - 1; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[_size - 1] = default(T);
            _size--;

            OnElementRemoved();
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_array, item, 0, Size);
        }

        public void CopyTo(T[] array)
        {
            CopyTo(array, 0);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(_array, 0, array, arrayIndex, Size);
        }

        public void Add(T item)
        {
            ThrowIfArgumentNull(item);

            if (_size == _capacity)
            {
                Resize();
            }

            _array[_size] = item;
            _size++;

            OnElementAdded();
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < _size; i++)
            {
                T currentValue = _array[i];
                if (currentValue.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            _array = new T[_capacity];
            _size = 0;

            OnCollectionCleared();
        }

        private void Resize()
        {
            T[] resized = new T[_capacity * 2];
            for (int i = 0; i < _capacity; i++)
            {
                resized[i] = _array[i];
            }
            _array = resized;
            _capacity = _capacity * 2;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public int Count
        {
            get
            {
                return Size;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        public T this[int index]
        {
            get
            {
                ThrowIfIndexOutOfRange(index);
                return _array[index];
            }
        }

        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > _size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("The current size of the array is {0}", _size));
            }
        }
        private void ThrowIfArgumentNull(T argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException("Null element is not valid");
            }
        }


        public struct Enumerator : IEnumerator<T>, IEnumerator
        {
            private OwnList<T> list;
            private int index;
            private int version;
            private T current;

            internal Enumerator(OwnList<T> list)
            {
                this.list = list;
                index = 0;
                version = list._size;
                current = default(T);
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {

                OwnList<T> localList = list;
                ThrowIfInvalidOperation(localList._size);
                if ((uint)index < (uint)localList._size)
                {
                    current = localList._array[index];
                    index++;
                    return true;
                }
                return MoveNextRare();
            }

            private bool MoveNextRare()
            {
                index = list._size + 1;
                current = default(T);
                return false;
            }

            public T Current
            {
                get
                {
                    return current;
                }
            }

            Object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            void IEnumerator.Reset()
            {
                index = 0;
                current = default(T);
            }

            private void ThrowIfInvalidOperation(int localsize)
            {
                if (version != localsize)
                {
                    throw new InvalidOperationException("Collection has been changed");
                }
            }
        }
    }
}
