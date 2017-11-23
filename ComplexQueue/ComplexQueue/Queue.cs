using System;
using ClassComplex;

namespace ComplexQueue
{
    class Queue
    {
        private Node _first, _last;

        #region Добавляем элемент в очередь
        public void Engueue(Complex z)
        {
            Node temp = new Node(z);
            if(_last == null)
            {
                _last = temp;
                _first = temp;
            }
            else
            {
                _last.Next = temp;
                _last = _last.Next;
            }
        }
        #endregion Убираем элемент

        #region Убираем элемент
        public Complex Dequeue()
        {
            if (_first == null)
                return null;
            else
            {
                Complex z = _first.Data;
                _first = _first.Next;
                if (_first == null) _last = null;
                return z;
            }
        }
        #endregion

        #region Просто возвращаем 1ый элемент
        public Complex Peek()
        {
            return _first.Data;
        }
        #endregion

        #region Счётчик
        public int Count()
        {
            int i = 0;
            Node buf = _first;
            while(buf != null)
            {
                buf = buf.Next;
                i++;
            }
            return i;
        }
        #endregion

        #region Вывод
        public void Print1()
        {
            if (_first == null)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            Node buf = _first;
            while (buf != null)
            {
                if (buf.Next != null)
                    Console.Write("{0} --> ", buf.Data);
                else
                    Console.WriteLine(buf.Data.ToString());
                buf = buf.Next;
            }
        }

        public void Print2()
        {
            if (_first == null)
            {
                Console.WriteLine("Queue is empty");
                return;
            }

            Node buf = _first;
            while (buf != null)
            {
                if (buf.Next != null)
                    Console.Write("{0} --> ", buf.Data);
                else
                    Console.WriteLine(buf.Data);
                buf = buf.Next;
            }
        }
        #endregion

        #region элементы очереди
        private class Node
        {
            public Node(Complex data, Node next = null)
            {
                Data = data;
                Next = next;
            }

            public Complex Data { get; set;}
            public Node Next { get; set;}
        }
        #endregion

    }
}
