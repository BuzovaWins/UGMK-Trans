using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClosedList
{
    public class ClosedListImpl<T> : IClosedList<T>
    {
        private int currentIndex;
        private List<T> list;

        public ClosedListImpl()
        {
            currentIndex = 0;
            list = new List<T>();
            
            HeadReached += ClosedList_HeadReached;

            if (File.Exists("test.txt"))
                File.Delete("test.txt");
        }

        public T Head => this[0];

        public T Current { get { return list[currentIndex]; } set { } }

        public T Previous
        {
            get
            {
                if (list.Count == 0)
                    throw new Exception("Closed list is empty");
                if (currentIndex == 0)
                    currentIndex = list.Count;
                return this[--currentIndex];
            }
        }

        public T Next
        {
            get
            {
                if (list.Count == 0)
                    throw new Exception("Closed list is empty");
                if (currentIndex == list.Count - 1)
                    currentIndex = -1;
                return this[++currentIndex];
            }
        }

        public int Count => this.Count;

        public bool IsReadOnly => false;

        public T this[int index] { get => list[index]; set => list[index] = value; }

        public event EventHandler<T> HeadReached;

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public void MoveBack(int step = 1)
        {
            for (int index = 0; index < step; index++)
            {
                Current = Previous;
                if (currentIndex == 0)
                    HeadReached?.Invoke(this, this.Current);
            }
        }

        public void MoveNext(int step = 1)
        {
            for (int index = 0; index < step; index++)
            {
                Current = Next;
                if (currentIndex == 0)
                    HeadReached?.Invoke(this, this.Current);
            }
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        private void ClosedList_HeadReached(object sender, T e)
        {
            StreamWriter f = new StreamWriter("test.txt");
            f.WriteLine("We meet head item");
            f.Close();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
