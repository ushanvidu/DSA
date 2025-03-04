using System;

namespace test
{
    public class Node

    {
        public string Data { get; set; }
        public int? Quantity { get; set; }
        public double? Price { get; set; }
        public Node? Next { get; set; }
        public Node? Previous { get; set; }

        public Node(string data)
        {
            Data = data;
            Next = null;
            Previous = null;
            Quantity = null;  
        }
        public Node(string data, int? quantity = null, double? price = null)
        {
            Data = data;
            Quantity = quantity;
            Price = price;
            Next = null;
            Previous = null;
        }

       
    }

    public class LinkedList
    {
        public Node? Head { get; set; }
        public Node? Tail { get; set; }
        public int Count { get; set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        
        public void AddFront(string val)
        {
            Node temp = new Node(val);
            if (Head == null)
            {
                Head = Tail = temp;
            }
            else
            {
                temp.Next = Head;
                Head.Previous = temp;
                Head = temp;
            }
            Count++;
        }


        public void AddFront(string val, int quantity, double price)
        {
            Node temp = new Node(val, quantity, price);
            if (Head == null)
            {
                Head = Tail = temp;
            }
            else
            {
                temp.Next = Head;
                Head.Previous = temp;
                Head = temp;
            }
            Count++;
        }

        
        public void AddLast(string val)
        {
            Node temp = new Node(val);
            if (Tail == null)
            {
                Head = Tail = temp;
            }
            else
            {
                Tail.Next = temp;
                Tail = temp;
            }
            Count++;
        }


        public void AddLast(string val, int quantity, double price)
        {
            Node temp = new Node(val, quantity, price);
            if (Tail == null)
            {
                Head = Tail = temp;
            }
            else
            {
                Tail.Next = temp;
                Tail = temp;
            }
            Count++;
        }

       
        public void AddAt(string val, int index)
        {
            if (index < 0 || index > Count)
            {
                Console.WriteLine("Invalid Index");
                return;
            }

            if (index == 0)
            {
                AddFront(val);
                return;
            }

            if (index == Count)
            {
                AddLast(val);
                return;
            }

            Node temp = new Node(val);
            Node current = Head;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            temp.Next = current.Next;
            if (current.Next != null)
            {
                current.Next.Previous = temp;
            }
            current.Next = temp;
            temp.Previous = current;
            Count++;
        }


        public void AddAt(string val, int quantity, double price, int index)
        {
            if (index < 0 || index > Count)
            {
                Console.WriteLine("Invalid Index");
                return;
            }

            if (index == 0)
            {
                AddFront(val, quantity, price);
                return;
            }

            if (index == Count)
            {
                AddLast(val, quantity, price);
                return;
            }

            Node temp = new Node(val, quantity, price);
            Node current = Head;

            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }

            temp.Next = current.Next;
            if (current.Next != null)
            {
                current.Next.Previous = temp;
            }
            current.Next = temp;
            temp.Previous = current;
            Count++;
        }
        
        
        
        //meka quntity eken adu wenna hdnna one . quentity eka iwara unama item eka ain wenna.

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                Console.WriteLine("Invalid Index");
                return;
            }

            if (index == 0)
            {
                Head = Head.Next;
                if (Head != null)
                    Head.Previous = null;
                else
                    Tail = null;
                Count--;
                return;
            }

            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            if (current.Previous != null)
                current.Previous.Next = current.Next;
            if (current.Next != null)
                current.Next.Previous = current.Previous;

            if (index == Count - 1)
                Tail = current.Previous;

            Count--;
        }

        public Node? Search(string val)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.Data == val)
                {
                    return current;
                }

                current = current.Next;
            }

            return null;
        }

        public int GetIndex(string val)
        {
            Node current = Head;
            int index = 0;
            while (current != null)
            {
                if (current.Data == val)
                    return index;
                current = current.Next;
                index++;
            }

            return -1;
        }

        public void printList()
        {
            Node current = Head;
            int i = 1;

            if (current == null)
            {
                Console.WriteLine("The list is empty.");
                return;
            }

            while (current != null) 
            {
                if (current.Quantity == null || current.Price == null)
                {
                    Console.WriteLine(current.Data);
                }
                else
                {
                    Console.WriteLine($"Item-{i}: {current.Data}, Quantity: {current.Quantity}, Price: {current.Price}");
                }

                current = current.Next;
                i++;
            }
        }
        
        public Node[] ToArray()
        {
            int count = GetCount();
            Node[] array = new Node[count];

            Node current = Head;
            int index = 0;
            while (current != null)
            {
                array[index++] = current;
                current = current.Next;
            }
            return array;
        }

        private int GetCount()
        {
            int count = 0;
            Node current = Head;
            while (current != null)
            {
                count++;
                current = current.Next;
            }
            return count;
        }

        public void ReduceQuantity(int index, int quantity)
        {
            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Quantity -= quantity;
            
        }
    }
}

    