using System;

namespace GenericStack
{
    public class Stack<T>
    where T: ICloneable
    {
        private Node<T> _last;

        public void Push(T Element)
        {
            Node<T> temp = new Node<T>(Element);
            if (_last == null)
                _last = temp;
            else
            {
                temp.Next = _last;
                _last = temp;
            }
        }

        public void Print()
        {
            Node<T> temp = _last;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }

        public T Pop()
        {
            if (_last == null)
                return default(T);
            else
            {
                T buf = _last.Data;
                _last = _last.Next;
                return buf;
            }
        }

        public T Top()
        {
            return (T)_last.Data.Clone();
        }
        
        public int Count()
        {
            if (_last == null)
                return 0;
            int count = 0;
            Node<T> temp = _last;
            do
            {
                count++;
                temp = temp.Next;
            }
            while (temp != null);
            return count;
        }

        private class Node<U>
        {
            public Node(U data, Node<U> next = null)
            {
                Data = data;
                Next = next;
            }
            public U Data { get; set; }
            public Node<U> Next {get; set;}
        }
    }
}
