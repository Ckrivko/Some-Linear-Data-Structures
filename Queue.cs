namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private class Node
        {
            public T Element { get; set; }

            public Node Next { get; set; }

            public Node(T element, Node next)
            {
                Element = element;
                this.Next = next;
            }

            public Node(T element) : this(element, null)
            {
                this.Element = element;
            }
        }

        private Node head;

        public int Count { get; set; }

        public void Enqueue(T item)
        {
            Node newNode = new Node(item);
            if (this.head == null)
            {
                this.head = newNode;

            }

            else
            {
                var node = this.head;

                while (node.Next != null)
                {
                    node = node.Next;
                }
                node.Next = newNode;

            }

            Count++;
        }

        public T Dequeue()
        {
            var node = this.head;
            if (node == null)
            {
                throw new InvalidOperationException("Empty Queue");
            }

            var elementToReturn = node.Element;

            this.head = node.Next;
            Count--;
            return elementToReturn;
        }

        public T Peek()
        {
            var node = this.head;

            if (node == null)
            {

                throw new InvalidOperationException("Empty Queue");
            }

            return node.Element;

        }

        public bool Contains(T item)
        {
            var node = this.head;
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
            var node = this.head;

            while (node != null)
            {
                yield return node.Element;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}