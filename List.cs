using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwnList
{
    class MyList<T>
    {
        private T[] data;
        private int size = 0;
        private int capacity;

        public MyList(int initialCapacity = 8)
        {
            if (initialCapacity < 1) initialCapacity = 1;
            this.capacity = initialCapacity;
            data = new T[initialCapacity];
        }

        public int Size { get { return size; } }
        public bool IsEmpty { get { return size == 0; } }

        public T GetAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            return data[index];
        }

        public void SetAt(T newElement, int index)
        {
            ThrowIfIndexOutOfRange(index);
            data[index] = newElement;
        }

        public void InsertAt(T newElement, int index)
        {
            ThrowIfIndexOutOfRange(index);
            if (size == capacity)
            {
                Resize();
            }

            for (int i = size; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            data[index] = newElement;
            size++;
        }
        public string ToString()
        {
            string temp="";
            for (int i = 0; i < size; i++)
            {
                temp += $"{data[i]} ; ";
            }
            return temp;
        }

        public void DeleteAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            for (int i = index; i < size - 1; i++)
            {
                data[i] = data[i + 1];
            }

            data[size - 1] = default(T);
            size--;
        }

        public void Add(T newElement)
        {
            if (size == capacity)
            {
                Resize();
            }

            data[size] = newElement;
            size++;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < size; i++)
            {
                T currentValue = data[i];
                if (currentValue.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            data = new T[capacity];
            size = 0;
        }

        private void Resize()
        {
            T[] resized = new T[capacity * 2];
            for (int i = 0; i < capacity; i++)
            {
                resized[i] = data[i];
            }
            data = resized;
            capacity = capacity * 2;
        }

        public void ListsCombined(MyList<T> data2)
        {
            //if(this.GetType()!=data2.GetType())
            //{
            //    throw new TypeAccessException(string.Format("Cannot merge two lists because of unsuitable type"));
            //}
            T[] combined = new T[capacity * 2];
            while (this.capacity - this.size < data2.size)
            {
                this.Resize();
            }
            for (int i = 0; i < this.size; i++)
            {
                combined[i] = data[i];
            }

            for (int i = this.size, y=0; y < data2.size; y++,i++)
            {
                combined[i] = data2.GetAt(y);
            }
            data = combined;
            this.size += data2.size;
        }

        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > size - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("The current size of the array is {0}", size));
            }
        }
    }
}
