using System;
using System.Collections;

namespace AVL_Tree
{
    public class Node<T> : IComparable<T> where T : IComparable
    {
        public BinaryTree<T> Data { get; set; }
        public Node<T> _Left { get; set; }
        public Node<T> _Right { get; set; }
        public Node<T> Parent { get; set; }
        public T Value { get; set; }


        public Node(T value, Node<T> parent, BinaryTree<T> data)
        {
            Value = value;
            Parent = parent;
            Data = data;
        }

        public Node<T> Left
        {
            get { return _Left; }
            set
            {
                _Left = value;
                if (_Left != null) { _Left.Parent = this; }
            }
        }

        public Node<T> Right
        {
            get { return _Right; }
            set
            {
                _Right = value;
                if (_Right != null) { _Right.Parent = this; }
            }
        }

        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }

        private int LeftHeight
        {
            get { return MaxChildHeight(Left); }
        }

        private int RightHeight
        {
            get { return MaxChildHeight(Right); }
        }

        enum TreeState
        {
            Balanced, LeftHeavy, RightHeavy
        }

        private TreeState State
        {
            get
            {
                if (LeftHeight - RightHeight > 1)
                    return TreeState.LeftHeavy;


                if (RightHeight - LeftHeight > 1)
                    return TreeState.RightHeavy;

                return TreeState.Balanced;
            }
        }

        private int BalanceFactor
        {
            get { return RightHeight - LeftHeight; }
        }

        private int MaxChildHeight(Node<T> item)
        {
            if (item != null)
            {
                return 1 + Math.Max(MaxChildHeight(item.Left), MaxChildHeight(item.Right));
            }

            return 0;
        }

        public void Balance()
        {
            if (State == TreeState.RightHeavy)
            {
                if (Right != null && Right.BalanceFactor < 0)
                {
                    LeftRightRotation();
                }
                else
                {
                    LeftRotation();
                }
            }
            else if (State == TreeState.LeftHeavy)
            {
                if (Left != null && Left.BalanceFactor > 0)
                    RightLeftRotation();
                else
                    RightRotation();
            }
        }

        private void LeftRotation()
        {
            Node<T> newRoot = Right;
            ReplaceBoot(newRoot);
            Right = newRoot.Left;
            newRoot.Left = this;
        }

        private void RightRotation()
        {
            Node<T> newRoot = Left;
            ReplaceBoot(newRoot);
            Left = newRoot.Right;
            newRoot.Right = this;
        }

        private void LeftRightRotation()
        {
            Right.RightRotation();
            LeftRotation();
        }

        private void RightLeftRotation()
        {
            Left.LeftRotation();
            RightRotation();
        }

        private void ReplaceBoot(Node<T> newRoot)
        {
            if (this.Parent != null)
            {
                if (this.Parent.Left == this)
                    this.Parent.Left = newRoot;
                else if (this.Parent.Right == this)
                    this.Parent.Right = newRoot;
            }
            else
                Data.Root = newRoot;

            newRoot.Parent = this.Parent;
            this.Parent = newRoot;
        }

    }
}