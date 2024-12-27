using System.ComponentModel;
using System.Collections.Generic;

namespace test;


public class Function
{
    LinkedList list = new LinkedList();
    
    public static void ViewCategories(LinkedList category)
    {
        Console.WriteLine("------- Categories -------:");
        category.printList();
        
    }

    public static void ViewItem(string category)
    {
        
    }
}