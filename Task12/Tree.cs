using System;
using System.Collections;
using System.Collections.Generic;

namespace Task12
{
    public class Tree<T> : IEnumerable<T>
        where T : IComparable
    {
        public TNode<T> Root { get; set; }
        public int CountAll;

        /// <summary>
        /// Добавление элементов
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new TNode<T>(value);
            }
            else
            {
                AddTo(Root, value);
            }

            CountAll++;
        }
        private void AddTo(TNode<T> item, T value)
        {
            if (value.CompareTo(item.Data) < 0)
            {
                if (item.Left == null)
                {
                    item.Left = new TNode<T>(value);
                }
                else
                {
                    AddTo(item.Left, value);
                }
            }
            else
            {
                if (item.Right == null)
                    item.Right = new TNode<T>(value);
                else
                {
                    AddTo(item.Right, value);
                }
            }
        }

        /// <summary>
        /// Подсчёт всех элементов
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return CountAll;
        }

        /// <summary>
        /// Префиксное добавление элементов (копир)
        /// </summary>
        /// <returns></returns>
        public List<T> Preorder()
        {
            var list = new List<T>();

            if (Root == null)
            {
                return list;
            }

            return Preorder(Root);
        }
        public List<T> Preorder(TNode<T> item)
        {
            var list = new List<T>();
            if (item != null)
            {
                list.Add(item.Data);
                if (item.Left != null)
                {
                    list.AddRange(Preorder(item.Left));
                }

                if (item.Right != null)
                {
                    list.AddRange(Preorder(item.Right));
                }
            }

            return list;
        }

        ///Подсчёт длины дерева
        public int MaxHeight(TNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(MaxHeight(node.Left), MaxHeight(node.Right));
        }

        /// <summary>
        /// Постфиксное добавление элементов (удал)
        /// </summary>
        /// <returns></returns>
        /// 
        public List<T> Postorder()
        {
            var list = new List<T>();

            if (Root == null)
            {
                return list;
            }

            return Postorder(Root);
        }
        public List<T> Postorder(TNode<T> item)
        {
            var list = new List<T>();
            if (item != null)
            {
                if (item.Left != null)
                {
                    list.AddRange(Postorder(item.Left));
                }

                if (item.Right != null)
                {
                    list.AddRange(Postorder(item.Right));
                }
                list.Add(item.Data);
            }

            return list;
        }

        /// <summary>
        /// Инфиксное добавление элементов (сорт) (1-2-3-4...)
        /// </summary>
        /// <returns></returns>
        public List<T> Inorder()
        {
            var list = new List<T>();

            if (Root == null)
            {
                return list;
            }

            return Inorder(Root);
        }
        public List<T> Inorder(TNode<T> item)
        {
            var list = new List<T>();
            if (item != null)
            {
                if (item.Left != null)
                {
                    list.AddRange(Inorder(item.Left));
                }
                list.Add(item.Data);
                if (item.Right != null)
                {
                    list.AddRange(Inorder(item.Right));
                }
            }
            return list;
        }

        /// <summary>
        /// Метод для сравнения
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return Find(value) != null;
        }
        private TNode<T> Find(T value)
        {
            TNode<T> current = Root;
            while (current != null)
            {
                int result = current.CompareTo(value);
                if (result > 0)
                    current = current.Left;
                else if (result < 0)
                    current = current.Right;
                else
                    break;
            }

            return current;
        }

        /// <summary>
        /// Фулл удаление
        /// </summary>
        public void Clear()
        {
            Root = null;
            CountAll = 0;
        }

        /// <summary>
        /// Нумераторы
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}