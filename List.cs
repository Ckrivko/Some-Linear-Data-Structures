namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] items;


        public List()
            : this(DEFAULT_CAPACITY)
        {

        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.items = new T[capacity];

        }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return items[index];
            }
            set
            {
                this.ValidateIndex(index);
                this.items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {

            this.Grow();
            this.items[this.Count] = item;
            this.Count++;
        }

        public bool Contains(T item)
        {
            foreach (var it in items.Take(Count))
            {
                if (item.Equals(it))
                {
                    return true;
                }

            }

            return false;
        }



        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {

                if (items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;

        }

        public void Insert(int index, T item)
        {
            ValidateIndex(index);

            this.Grow();


            for (int i = this.Count; i > index; i--)
            {

                items[i] = items[i - 1];
            }
            items[index] = item;
            Count++;


        }

        public bool Remove(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (items[i].Equals(item))
                {
                    this.RemoveAt(i);
                    return true;

                }

            }
            return false;

        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];

            }

            this.items[this.Count - 1] = default(T);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.items[i];
            }

        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void Grow()
        {
            if (this.Count == items.Length)
            {
                T[] itemsCopy = new T[items.Length * 2];
                // Array.Copy(items, itemsCopy, this.Count);

                for (int i = 0; i < items.Length; i++)
                {
                    itemsCopy[i] = this.items[i];

                }
                items = itemsCopy;
            }

        }
        private void Shrink()
        {

            if (items.Length / Count >= 2)
            {

                T[] CurrArray = new T[this.items.Length / 2];
                for (int i = 0; i < this.Count; i++)
                {
                    CurrArray[i] = items[i];
                }

                items = CurrArray;
            }

        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)

            {
                throw new IndexOutOfRangeException("Invalid index");
            }

        }


    }
}