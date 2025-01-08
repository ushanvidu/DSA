namespace Test;

public class BubbleSortNames
{
    static void BubbleSort(string[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
               
                if (string.Compare(arr[j], arr[j + 1], StringComparison.Ordinal) > 0)
                {
                   
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    swapped = true;
                }
            }

            if (!swapped)
            {
               
                break;
            }
        }
    }
    static void PrintArray(string[] array)
    {
        foreach (string name in array)
        {
            Console.WriteLine(name);
        }
    }

}