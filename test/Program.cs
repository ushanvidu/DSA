using System;
using System.Dynamic;

namespace test;

class Program
{
    static void Main(string[] args)
    {
        LinkedList category = new LinkedList();
        //Function function = new Function();
        category.AddLast("Groceries");
        category.AddLast("Bevarages");
        category.AddLast("Dairy Products");
        category.AddLast("Frozen Foods");
        category.AddLast("Fresh Produce");
        category.AddLast("Bakery");
        

        var itemlist = new System.Collections.Generic.List<LinkedList>
        {
           new LinkedList(), //Groceries
           new LinkedList(), //Bevarages
           new LinkedList(), //Dairy Products
           new LinkedList(), //Frozen Foods
           new LinkedList(), //Fresh Produce
           new LinkedList(), //Bakery
        };
        itemlist[0].AddLast("a");
        itemlist[0].AddLast("b");
        itemlist[0].AddLast("c");
        
        itemlist[1].AddLast("d");
        itemlist[1].AddLast("e");
        itemlist[1].AddLast("f");
        
        
        itemlist[2].AddLast("d");
        itemlist[2].AddLast("e");
        itemlist[2].AddLast("f");
        
        itemlist[3].AddLast("d");
        itemlist[3].AddLast("e");
        itemlist[3].AddLast("f");
        
        itemlist[4].AddLast("d");
        itemlist[4].AddLast("e");
        itemlist[4].AddLast("f");
        
        itemlist[5].AddLast("g");
        itemlist[5].AddLast("h");
        itemlist[5].AddLast("i");

        


        while (true)
        {
            
            Console.WriteLine("Categories:");
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.WriteLine("1. View Categories");
            Console.WriteLine("2. View Items in a Category");
            Console.WriteLine("3. Add Item to a Category");
            Console.WriteLine("4. Remove Item from a Category");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();
            
            

            switch (choice)
            {
                  
                case "1":
                    ViewCategories(category);
                    
                
                    break;
                case "2":
                    ViewItems(category, itemlist);
                    break;
                case "3":
                    AddItems(category, itemlist);
                    break;
                case "4":
                    RemoveItem(category, itemlist);
                    break;
                case "5":
                    Console.WriteLine($"Exiting.....\n Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
                
            }
            

            


        }
        return;


        static void ViewCategories(LinkedList category)
        {
            Console.WriteLine("------- Categories -------:");
            category.printList();
            
        }

        static void ViewItems(LinkedList category, System.Collections.Generic.List<LinkedList> itemlist)
        {
            Console.Write("\nEnter the category name Index Number : ");
            int  CategoryName_Index = int.Parse(Console.ReadLine());
            if (CategoryName_Index >= itemlist.Count)
            {
                Console.WriteLine("There are no items in the list.");
            }
            else
            {
                Console.WriteLine(" Items in this category: ");
                itemlist[CategoryName_Index-1].printList();
            }
        }

        static void AddItems(LinkedList category, System.Collections.Generic.List<LinkedList> itemlist)
        {
            
            
        }

        static void RemoveItem(LinkedList category, System.Collections.Generic.List<LinkedList> itemlist)
        {
            
        }

    }
    
}

