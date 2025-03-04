namespace test;

public class Quick_Sort
{
    private Node Partition(Node low, Node high, string criteria, bool ascending)
    {
        Node pivot = high;
        Node i = low.Previous;

        for (Node j = low; j != high; j = j.Next)
        {
            if (Compare(j, pivot, criteria, ascending))
            {
                i = (i == null) ? low : i.Next;
                Swap(i, j);
            }
        }

        i = (i == null) ? low : i.Next;
        Swap(i, high);
        return i;
    }

    private void Swap(Node a, Node b)
    {
        (a.Data, b.Data) = (b.Data, a.Data);
        (a.Quantity, b.Quantity) = (b.Quantity, a.Quantity);
        (a.Price, b.Price) = (b.Price, a.Price);
    }

    private void QuickSort(Node low, Node high, string criteria, bool ascending)
    {
        if (high != null && low != high && low != high.Next)
        {
            Node pivot = Partition(low, high, criteria, ascending);
            QuickSort(low, pivot.Previous, criteria, ascending);
            QuickSort(pivot.Next, high, criteria, ascending);
        }
    }

    public void Sort(LinkedList list, string criteria, bool ascending = true)
    {
        if (list.Head == null) return;
        Node lastNode = GetLastNode(list.Head);
        QuickSort(list.Head, lastNode, criteria, ascending);
    }

    private Node GetLastNode(Node node)
    {
        while (node.Next != null)
            node = node.Next;
        return node;
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
                double quantityA = a.Quantity ?? double.MaxValue;
                double quantityB = b.Quantity ?? double.MaxValue;
                result = quantityA.CompareTo(quantityB);
                break;
            case "price":
                double priceA = a.Price ?? double.MaxValue;
                double priceB = b.Price ?? double.MaxValue;
                result = priceA.CompareTo(priceB);
                break;
        }

        return ascending ? result < 0 : result > 0;
    }
}