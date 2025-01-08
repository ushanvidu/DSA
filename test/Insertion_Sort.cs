using System;

namespace test;

public class Insertion_Sort
{
    static void InsertingSort(string[] array)
    {
        int n = array.Length;

        for (int i = 1; i < n; i++)
        {
            string key = array[i];
            int j = i - 1;

            
            while (j >= 0 && string.Compare(array[j], key, StringComparison.Ordinal) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
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