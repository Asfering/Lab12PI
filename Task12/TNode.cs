using System;

namespace Task12
{
    public class TNode<T> : IComparable
        where T : IComparable
    {
        public T Data { get; set; }
        public TNode<T> Left { get; set; }
        public TNode<T> Right { get; set; }
        

        public TNode(T data)
        {
            Data = data;
        }

        public TNode(T data, TNode<T> left, TNode<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        

        public int CompareTo(object obj)
        {
            return Data.CompareTo(obj);
        }
    }
}