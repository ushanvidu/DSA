namespace test;
using System;
public class MergeSortLinkedList
{
   
    
    private Node Merge(Node left, Node right, string sortBy)
    {
        Node result = null;

      
        if (left == null)
            return right;
        if (right == null)
            return left;

        
        if (CompareNodes(left, right, sortBy) <= 0)
        {
            result = left;
            result.Next = Merge(left.Next, right, sortBy);
        }
        else
        {
            result = right;
            result.Next = Merge(left, right.Next, sortBy);
        }

        return result;
    }

    
    private int CompareNodes(Node a, Node b, string sortBy)
    {
        switch (sortBy.ToLower())
        {
            case "price":
                double priceA = a.Price?? double.MaxValue;
                double priceB = b.Price?? double.MaxValue;
                int result = priceA.CompareTo(priceB);
                if (result != 0){

                    return result;}

                break;


            case "quantity":
                double QuantityA = a.Quantity?? double.MaxValue;
                double QuantityB = b.Quantity?? double.MaxValue;
                int resultQ = QuantityA.CompareTo(QuantityB);
                if (resultQ != 0)
                {

                    return resultQ;
                }

                break;


            case "name":
                return string.Compare(a.Data, b.Data, StringComparison.Ordinal);
            default:
                throw new ArgumentException("Invalid sorting key. Use 'Price', 'Quantity', or 'Name'.");
        }

        return 0;
    }

  
    private Node GetMiddle(Node head)
    {
        if (head == null)
            return head;

        Node slow = head;
        Node fast = head.Next;

        
        while (fast != null && fast.Next != null)
        {
            slow = slow.Next;
            fast = fast.Next.Next;
        }

        return slow;
    }


    public Node Sort(Node head, string sortBy)
    {
        
        if (head == null || head.Next == null)
            return head;

       
        Node middle = GetMiddle(head);
        Node nextOfMiddle = middle.Next;

        
        middle.Next = null;

        
        Node left = Sort(head, sortBy);
        Node right = Sort(nextOfMiddle, sortBy);

        
        return Merge(left, right, sortBy);
    }
}