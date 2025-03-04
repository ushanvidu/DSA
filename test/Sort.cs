namespace test
{
    public class InsertionSort
    {
        
        public LinkedList InsersionSort(LinkedList list, string criteria, bool ascending = true)
        {
            if (list.Head == null) return list; 
            
            Node sorted = null; 
            Node current = list.Head;

            while (current != null)
            {
                Node next = current.Next; 
                sorted = SortedInsert(sorted, current, criteria, ascending);
                current = next;
            }

            list.Head = sorted;
            return list;
        }

        
        private Node SortedInsert(Node head, Node newNode, string criteria, bool ascending)
        {
            if (head == null || Compare(newNode, head, criteria, ascending))
            {
                newNode.Next = head;
                if (head != null) head.Previous = newNode;
                newNode.Previous = null;
                return newNode;
            }

            Node current = head;
            while (current.Next != null && !Compare(newNode, current.Next, criteria, ascending))
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            if (current.Next != null)
                current.Next.Previous = newNode;

            current.Next = newNode;
            newNode.Previous = current;

            return head;
        }

        
        private bool Compare(Node a, Node b, string criteria, bool ascending)
        {
            int result = 0;

            switch (criteria.ToLower())
            {
                case "name":
                    result = string.Compare(a.Data, b.Data, StringComparison.OrdinalIgnoreCase);
                    break;
                case "quantity":
                    result = (a.Quantity ?? 0).CompareTo(b.Quantity ?? 0);
                    break;
                case "price":
                    result = (a.Price ?? 0).CompareTo(b.Price ?? 0);
                    break;
            }

            return ascending ? result < 0 : result > 0;
        }
    }
}