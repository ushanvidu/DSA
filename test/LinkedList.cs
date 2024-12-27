namespace test;

   
public class Node
{
    public string Data { get; set; }
    public Node? Next { get; set; } //refference variable , it store address in the node clz
    public Node? Previous { get; set; }
    public Node(string data)
    {
        Data = data;
        Next = null;
        Previous = null;
    }

    
}


public class LinkedList
{
   

    public Node? Head { get; set; }
    public Node? Tail { get; set; }
    public int count { get; set; }

    public LinkedList()
    {
        Head = null;    
        Tail = null;
        count = 0;
    }

    public void AddFront(string val)
    {
        Node temp=new Node(val);
        if (Head == null)   //check list is empty
        {
            Head = temp;
            Tail = temp;
            count++;
        }
        else
        {
            temp.Next = Head;
            Head = temp;
            count++;
        }
    }

    public void printList()
    {
        Node Current = Head;
        while (Current != null)
        {
            Console.WriteLine(Current.Data);
            Current = Current.Next;
        }
    }

    public void AddLast(string val)
    {
        Node temp = new Node(val);
        if (Tail == null)
        {
            Tail = temp;
           Head = temp;
            count++;
        }
        else
        {
            Tail.Next = temp;
            Tail = temp;
            count++;
        }
    }

    public void AddAt(string val, int index)
    {
        Node temp = new Node(val);
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Invalid Index");
        }

        if (index == 0)
        {
            AddFront(val);
            return;
        }

        if (index == count )
        {
            AddLast(val);
            return;
        }
        else
        {
            Node current = Head;
            
            for (int i = 0; i < index-1 ; i++)
            {
                current = current.Next;
            }
            temp.Next = current.Next;
            current.Next = temp;
            count++;
        }
    }

    public void RemoveAt(int index)
    {
        
        if (index < 0 || index >= count)
        {
            Console.WriteLine("Invalid Index");
            return;
        }

        if (index == 0)
        {
          Head= Head.Next;
        }

        if (Head == null)
        {
            Tail= null;
            count--;
            
        }
        else
        {
            Node current = Head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            if (index == count - 1)
            {
                Tail= current;
            }

            count--;
        }
    }

    public Node Search(string val)
    {
        Node current = Head;
        while (current != null)
        {
            if (current.Data == val)
            {
                Node node= new Node(current.Data);
                
                return node ;
            }
            current = current.Next;
        
        }
        
        return null;
    }
    public int GetIndex(string val)
    {
        Node? current = Head;
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
}

