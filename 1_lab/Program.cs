using SecondLabWork;
using System.Collections;
using System.Collections.Generic;

    public class MyNode<T>
    {
        public T? Value { get; set; }
        public MyNode<T>? Next { get; set; }
        public MyNode(T? value, MyNode<T>? next = null) 
        {
            Value = value;
            Next = next;
        }
    }
    public class MyList<T> : IEnumerable<T>
    {
        public MyNode<T>? Head {  get; set; }
        public MyNode<T>? Tail { get; set; }

        public IEnumerator<T> GetEnumerator()
        {
            MyNode<T>? curr = Head;
            while (curr != null)
            {
                yield return curr.Value;
                curr = curr.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        public void AddToHead(T? value)
        {
            if(Head != null)
            {
                MyNode<T> NewHead = new(value, Head);
                Head = NewHead;
            }
            else
            {
                Head = new MyNode<T>(value);
                Tail = Head;
            }
        }

        public void DelFromHead()
        {
            if (Head != null)
            {
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }
            }
            else return;
        }

    }

namespace SecondLabWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<string> list = new();
            list.AddToHead("a");
            list.AddToHead("b");
            list.AddToHead("c");

            PrintCollection(list);

            list.DelFromHead();

            PrintCollection(list);
        }
        private static void PrintCollection<T>(MyList<T> collection)
        {
            foreach (var elem in collection)
                Console.Write(elem + " ");
            Console.Write('\n');
        }

    }
}

