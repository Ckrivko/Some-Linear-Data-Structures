namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
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

        public void AddFirst(T item)
        {
            var node = new Node(item, this.head);
            this.head = node;
            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node(item);

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

                node.Next=newNode;
            }

            this.Count++;
        }


        public T GetFirst()
        {
            if (this.head == null)
            {
                throw new InvalidOperationException("Empty List");
            }
            return this.head.Element;
        }

        public T GetLast()
        {

            if (this.head == null)
            {
                throw new InvalidOperationException("Empty List");
            }

            var node = this.head;

            while (node.Next != null)
            {
                node = node.Next;
            }
            return node.Element;
        }

        public T RemoveFirst()
        {

            if (this.head == null)
            {
                throw new InvalidOperationException("Empty List");
            }

            var oldHead = this.head;
            this.head = oldHead.Next;

            this.Count--;
            return oldHead.Element;
        }

        public T RemoveLast()
        {

            if (this.head == null)
            {
                throw new InvalidOperationException("Empty List");
            }

            if (this.head.Next == null)
            {

                var currEl = this.head.Element;
                this.head = null; ;

                Count--;
                return currEl;
            }
            
            var node = this.head;

            while (node.Next.Next != null)
            {
                node=node.Next;
            }


            var el = node.Next.Element;
            node.Next = null; ;
           
            Count--;
            return el;
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