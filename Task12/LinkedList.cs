using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;

namespace Task12
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public Item<T> Head { get; set; }
        public Item<T> Tail { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="data"></param>
        public LinkedList(T data)
        {
            var item = new Item<T>(data);
            SetHeadAndTail(data);
        }

        /// <summary>
        /// Добавление элементов в конец
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            var item = new Item<T>(data);

            if (Tail != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadAndTail(data);
            }
        }

        /// <summary>
        /// Поиск по значению
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            Item<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Поиск элемента по его ключу
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Item<T> FindEven(int size)
        {
            if (Head == null) return Head;
            if (Head.Next == null) return Head;
            Item<T> TSearch = Head;
            for (int i = 1; i < size; i++)
            {
                TSearch = TSearch.Next;
                if(TSearch == null)
                    throw new NullReferenceException();
            }
            
            return TSearch;
        }

        /// <summary>
        /// Удаление элементов
        /// </summary>
        /// <param name="data"></param>
        public bool Delete(T data)
        {
            Item<T> current = Head;
            Item<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    Count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        /// Очистить весь список
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        /// Добавление элементов на 1 позицию.
        /// </summary>
        /// <param name="data"></param>
        public void AppendHead(T data)
        {
            var item = new Item<T>(data);
            item.Next = Head;
            Head = item;
            Count++;
        }

        /// <summary>
        /// Вставить после Target элемент Data
        /// </summary>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public void InsertAfter(T target, T data)
        {
            if (Head != null)
            {
                var current = Head;
                while (current != null)
                {
                    if (current.Data.Equals(target))
                    {
                        var item = new Item<T>(data);
                        item.Next = current.Next;
                        current.Next = item;
                        Count++;
                        return;
                    }
                    else
                    {
                        current = current.Next;
                    }
                }
            }
            else
            {
                // Нужно для себя решить, если список пустой,
                // то либо не добавлять ничего, либо вставить данные
            }
        }

        /// <summary>
        /// Вспомогательный
        /// </summary>
        /// <param name="item"></param>
        private void SetHeadAndTail(T data)
        {
            var item = new Item<T>(data);
            Head = item;
            Tail = item;
            Count = 1;
        }

        /// <summary>
        /// Нумератор
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        /// <summary>
        /// Нумерейбл
        /// </summary>
        /// <returns></returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return (IEnumerator<T>)GetEnumerator();
        }
    }
}