using System.Collections;
using System.Collections.Generic;

namespace Task12
{
    public class DoubleList<T> : IEnumerable<T>
    {
        public DoubleItem<T> Head { get; set; }
        public DoubleItem<T> Tail { get; set; }
        public int count { get; set; }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public DoubleList()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        /// <summary>
        /// Конструктор с датой
        /// </summary>
        /// <param name="data"></param>
        public DoubleList(T data)
        {
            var item = new DoubleItem<T>(data);
            Head = item;
            Tail = item;
            count = 1;
        }

        /// <summary>
        /// Добавить в коллекцию
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            var item = new DoubleItem<T>(data);
            if (Head == null)
            {
                Head = item;
            }
            else
            {
                Tail.Next = item;
                item.Previous = Tail;
            }

            Tail = item;
            count++;
        }

        /// <summary>
        /// Добавить коллекцию элемент на 1 место
        /// </summary>
        /// <param name="data"></param>
        public void AddFirst(T data)
        {
            DoubleItem<T> item = new DoubleItem<T>(data);
            DoubleItem<T> temp = Head;
            item.Next = temp;
            Head = item;
            if (count == 0)
                Tail = Head;
            else
                temp.Previous = item;
            count++;
        }

        /// <summary>
        /// Само решение задания, поиск элемента по индексу (?)
        /// </summary>
        /// <returns></returns>
        public DoubleList<T> FindUnEven()
        {
            var result = new DoubleList<T>();
            var current = Head;
            int i = 0;

            while (current != null)
            {
                result.Add(current.Data);
                current = current.Next;
            }

            current = Head;

            while (current != null)
            {
                if (i % 2 == 0)
                {
                    result.Add(current.Data);
                }

                current = current.Next;
                i++;
            }

            return result;
        }


        /// <summary>
        /// Удаление элементов
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Delete(T data)
        {
            DoubleItem<T> current = Head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    break;
                }
                current = current.Next;
            }

            if (current != null)
            {
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    Tail = current.Previous;

                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    Head = current.Next;
                count--;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Количество
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Пустота
        /// </summary>
        public bool IsEmpty
        {
            get { return count == 0; }
        }

        /// <summary>
        /// Фулл удаление коллекции
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Contains(T data)
        {
            DoubleItem<T> current = Head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Обратка
        /// </summary>
        /// <returns></returns>
        public DoubleList<T> Reverse()
        {
            var result = new DoubleList<T>();
            var current = Tail;
            while (current != null)
            {
                result.Add(current.Data);
                current = current.Previous;
            }

            return result;
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

        /// <summary>
        /// Задний нумератор
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> BackEnumerator()
        {
            DoubleItem<T> current = Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }
    }
}