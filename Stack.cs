﻿namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class StackExample<T> : IAbstractStack<T>
    {
        private class Node
        {
            public T Element { get; set; }
            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                this.Element = element;
                this.Next = next;
            }

            public Node(T element) : this(element, null)
            {
                this.Element = element;

            }
        }

        private Node top;

        public int Count  {get;set;}

        public void Push(T item)
        {
            Node node = new Node(item,this.top); 
            this.top = node;
            this.Count++;
        }

        public T Pop()
        {
            if (this.top== null)
            {
                throw new InvalidOperationException("Empty Stack");
            }

            var oldTop = this.top;
            this.top = oldTop.Next;
           
            Count--;
            return oldTop.Element;
        }

        public T Peek()
        {
            if (this.top == null)
            {
                throw new InvalidOperationException("Empty Stack");
            }
            return this.top.Element;
        }

        public bool Contains(T item)
        {
            var node = this.top;

            while (node != null)
            {
                if (node.Element.Equals(item)) 
                {
                    return true;
                }
                node = node.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = this.top;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
       
    }
}