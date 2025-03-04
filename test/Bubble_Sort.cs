namespace test;

class BubbleSortPrice
{
    

  public void BubbleSort(LinkedList list)
{
    int n = list.Count;
    
    Node icurrent = list.Head;
    for (int i = 0; i < n - 1; i++)
    {
        bool swapped = false;
        Node jcurrent = list.Head;
        for (int j = 0; j < n - i - 1; j++)
        {
            if (jcurrent.Price > jcurrent.Next.Price)
            {
                // Swap the data of the nodes
                double? tempPrice = jcurrent.Price;
                int? tempQuantity = jcurrent.Quantity;
                string tempData = jcurrent.Data;

                jcurrent.Price = jcurrent.Next.Price;
                jcurrent.Quantity = jcurrent.Next.Quantity;
                jcurrent.Data = jcurrent.Next.Data;

                jcurrent.Next.Price = tempPrice;
                jcurrent.Next.Quantity = tempQuantity;
                jcurrent.Next.Data = tempData;

                swapped = true;
            }
            jcurrent = jcurrent.Next;
        }
        icurrent = icurrent.Next;

        // If no elements were swapped, the list is sorted
        if (!swapped)
            break;
    }
}
}
