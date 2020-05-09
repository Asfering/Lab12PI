using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab10Library;

namespace AVL_Tree
{
    public class BinaryTree<T> : IEnumerable<T>, ICloneable where T : IComparable
    {
        public Node<T> Root { get; set; }

        public int count { get; set; }

        public BinaryTree()
        {
            Root = null;
            count = 0;
        }

        public BinaryTree(int capacity, T data)    
        {
            BinaryTree<T> TCounstructor = new BinaryTree<T>();
            Root = null;
            count = 0;
            for (int i = 0; i < capacity; i++)
            {
                TCounstructor.Add(data);
            }
        }

        public BinaryTree(T data)     
        {
            BinaryTree<T> TCounstructor = new BinaryTree<T>();
            TCounstructor.Add(data);
        }

        /// <summary>
        /// Добавление
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node<T>(value, null, this);
            }
            else
            {
                AddTo(Root, value);
            }

            count++;
        }
        private void AddTo(Node<T> item, T value)
        {
            if (value.CompareTo(item.Value) < 0)
            {
                if (item.Left == null)
                {
                    item.Left = new Node<T>(value, item, this);
                }
                else
                    AddTo(item.Left, value);
            }
            else
            {
                if (item.Right == null)
                    item.Right = new Node<T>(value, item, this);
                else
                    AddTo(item.Right, value);
            }
        }

        /// <summary>
        /// Количество
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return count;
        }

        /// <summary>
        /// Поиск
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Contains(T value)
        {
            return Find(value) != null;
        }
        private Node<T> Find(T value)
        {
            Node<T> current = Root;
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
        /// Удаление
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            Node<T> current;
            current = Find(value);                                    

            if (current == null)                                     
                return false;
            

            Node<T> treeToBalance = current.Parent;    
            count--;                                                           

            #region Вариант 1: Если удаляемый узел не имеет правого потомка      

            if (current.Right == null) 
            {
                if (current.Parent == null) 
                {
                    Root = current.Left;    

                    if (Root != null)
                        Root.Parent = null; 
                    
                }
                else 
                {
                    int result = current.Parent.CompareTo(current.Value);

                    if (result > 0)
                        current.Parent.Left = current.Left;
                    
                    else if (result < 0)
                        current.Parent.Right = current.Left;
                    
                }
            }

            #endregion

            #region Вариант 2: Если правый потомок удаляемого узла не имеет левого потомка, тогда правый потомок удаляемого узла становится потомком родительского узла.     

            else if (current.Right.Left == null) 
            {
                current.Right.Left = current.Left;

                if (current.Parent == null) 
                {
                    Root = current.Right;

                    if (Root != null)
                        Root.Parent = null;
                    
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Value);
                    if (result > 0)
                        current.Parent.Left = current.Right;
                    

                    else if (result < 0)
                        current.Parent.Right = current.Right;
                    
                }
            }

            #endregion

            #region Вариант 3: Если правый потомок удаляемого узла имеет левого потомка,  заместить удаляемый узел, крайним левым потомком правого потомка.     

            else
            {
                Node<T> leftmost = current.Right.Left;

                while (leftmost.Left != null)
                {
                    leftmost = leftmost.Left;
                }
                leftmost.Parent.Left = leftmost.Right;
                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (current.Parent == null)
                {
                    Root = leftmost;

                    if (Root != null)
                        Root.Parent = null;
                    
                }
                else
                {
                    int result = current.Parent.CompareTo(current.Value);

                    if (result > 0)
                        current.Parent.Left = leftmost;
                    
                    else if (result < 0)
                        current.Parent.Right = leftmost;
                }
            }

            #endregion

            if (treeToBalance != null)
            {
                treeToBalance.Balance();
            }

            else
            {
                if (Root != null)
                {
                    Root.Balance();
                }
            }
            return true;
        }
        
        /// <summary>
        /// Фулл очистка
        /// </summary>
        public void Clear()
        {
            Root = null;
            count = 0;
        }

        /// <summary>
        /// Нумераторы
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> InOrderTraversal()
        {
            if (Root != null)
            {
                Stack<Node<T>> stack = new Stack<Node<T>>();
                Node<T> current = Root;
                bool goLeftNext = true;
                stack.Push(current);

                while (stack.Count > 0)
                {
                    
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    yield return current.Value;
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                    
                }
            }
        }
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Поверхностное копирование
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}