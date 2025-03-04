using System;
using System.Diagnostics;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList category = new LinkedList();
            category.AddLast("1. Groceries");
            category.AddLast("2. Beverages");
            category.AddLast("3. Dairy Products");
            category.AddLast("4. Frozen Foods");
            category.AddLast("5. Fresh Produce");
            category.AddLast("6. Bakery");

            var itemlist = new System.Collections.Generic.List<LinkedList>
            {
                new LinkedList(), // Groceries
                new LinkedList(), // Beverages
                new LinkedList(), // Dairy Products
                new LinkedList(), // Frozen Foods
                new LinkedList(), // Fresh Produce
                new LinkedList()  // Bakery
            };

            
            itemlist[0].AddLast("Rice", 32, 200);
            itemlist[0].AddLast("Wheat", 89, 100);
            itemlist[0].AddLast("Sugar", 30, 550);
            itemlist[0].AddLast("Bread", 45, 500);
            itemlist[0].AddLast("Cheese", 3, 400);
            itemlist[0].AddLast("Jam", 40, 300);
            itemlist[0].AddLast("Pasta", 27, 450);
            itemlist[0].AddLast("Garlic", 6, 500);
            itemlist[0].AddLast("Egg", 20, 50);
            itemlist[0].AddLast("Sausage", 5, 500);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("         INVENTORY SYSTEM         ");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1. View Categories");
                Console.WriteLine("2. View Items in a Category");
                Console.WriteLine("3. Add Item to a Category");
                Console.WriteLine("4. Remove Item from a Category");
                Console.WriteLine("5. Exit");
                Console.WriteLine("----------------------------------");
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
                        Console.WriteLine("Exiting... Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }

        static void ViewCategories(LinkedList category)
        {
            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("           CATEGORIES             ");
            Console.WriteLine("----------------------------------");
            category.printList();
        }

        static void ViewItems(LinkedList category, System.Collections.Generic.List<LinkedList> itemlist)
        {
            ViewCategories(category);
            Console.Write("\nEnter the category number: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryIndex) || categoryIndex < 1 || categoryIndex > itemlist.Count)
            {
                Console.WriteLine("Invalid category number. Please try again.");
                return;
            }

            Console.WriteLine("\n----------------------------------");
            Console.WriteLine("        ITEMS IN CATEGORY         ");
            Console.WriteLine("----------------------------------");
            itemlist[categoryIndex - 1].printList();
            Console.WriteLine("\nWould you like to sort them?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.Write("Enter your choice: ");
            
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice != 1)
                return;

            Console.WriteLine("\nSort by:");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Price");
            Console.WriteLine("3. Quantity");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out int sortChoice) || sortChoice < 1 || sortChoice > 3)
            {
                Console.WriteLine("Invalid choice. Sorting aborted.");
                return;
            }

            string sortBy = sortChoice switch
            {
                1 => "name",
                2 => "price",
                3 => "quantity",
                _ => throw new InvalidOperationException()
            };
            
            //merge sort
            // Stopwatch timer = new Stopwatch();
            // timer.Start();
            // MergeSortLinkedList sorter = new MergeSortLinkedList();
            // itemlist[categoryIndex - 1].Head = sorter.Sort(itemlist[categoryIndex - 1].Head, sortBy);
            // timer.Stop();
            //
            // Console.WriteLine("\nSorted Items:");
            // itemlist[categoryIndex - 1].printList();
            // Console.WriteLine($"\nMerge Sort - Sorting completed in {timer.ElapsedMilliseconds} ms ({timer.ElapsedTicks} ticks).");
            //
            // insertion sort
               Stopwatch timer1 = new Stopwatch();
               timer1.Start();
               InsertionSort sort1 = new InsertionSort();
              itemlist[categoryIndex - 1]=sort1.InsersionSort(itemlist[categoryIndex - 1], sortBy,true);
               Console.WriteLine("\nSorted Items:");
               itemlist[categoryIndex - 1].printList();
               timer1.Stop();
               Console.WriteLine($"\n Insertion Sort - Sorting completed in {timer1.ElapsedMilliseconds} ms ({timer1.ElapsedTicks} ticks).");
              //  
              //Quick sort
              // Stopwatch timer2 = new Stopwatch();
              // timer2.Start();
              // Quick_Sort sort2 = new Quick_Sort();
              // sort2.Sort(itemlist[categoryIndex - 1], sortBy, true); 
              // Console.WriteLine("\nSorted Items:");
              // itemlist[categoryIndex - 1].printList(); 
              // timer2.Stop();
              // Console.WriteLine($"\nQuick Sort - Sorting completed in {timer2.ElapsedMilliseconds} ms ({timer2.ElapsedTicks} ticks).");
              //
        }

        static void AddItems(LinkedList category, System.Collections.Generic.List<LinkedList> itemlist)
        {
            ViewCategories(category);
            Console.Write("\nEnter the category number to add an item: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryIndex) || categoryIndex < 1 || categoryIndex > itemlist.Count)
            {
                Console.WriteLine("Invalid category number. Please try again.");
                return;
            }

            Console.Write("Enter the item name: ");
            string itemName = Console.ReadLine()?.Trim();
    
            if (string.IsNullOrWhiteSpace(itemName))
            {
                Console.WriteLine("Item name cannot be empty.");
                return;
            }

            Console.Write("Enter the quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive number.");
                return;
            }

            Console.Write("Enter the price: ");
            if (!double.TryParse(Console.ReadLine(), out double price) || price <= 0)
            {
                Console.WriteLine("Invalid price. Please enter a positive number.");
                return;
            }

            // Add the item to the selected category
            itemlist[categoryIndex - 1].AddLast(itemName, quantity, price);
    
            Console.WriteLine($"\nItem '{itemName}' added successfully!");

            // Display updated items in the category
            Console.WriteLine("\nUpdated Item List:");
            itemlist[categoryIndex - 1].printList();
        }
        static void RemoveItem(LinkedList category, System.Collections.Generic.List<LinkedList> itemlist)
        {
            ViewCategories(category);
            Console.Write("\nEnter the category number: ");
            if (!int.TryParse(Console.ReadLine(), out int categoryIndex) || categoryIndex < 1 || categoryIndex > itemlist.Count)
            {
                Console.WriteLine("Invalid category number. Please try again.");
                return;
            }

            Console.Write("\nEnter the item name to remove: ");
            string itemName = Console.ReadLine();

            Node itemNode = itemlist[categoryIndex - 1].Search(itemName);
            if (itemNode == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            Console.Write($"\nEnter quantity to remove (Current: {itemNode.Quantity}): ");
            if (!int.TryParse(Console.ReadLine(), out int removeQuantity) || removeQuantity < 1 || removeQuantity > itemNode.Quantity)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            itemNode.Quantity -= removeQuantity;

            if (itemNode.Quantity == 0)
            {
                int itemIndex = itemlist[categoryIndex - 1].GetIndex(itemName);
                itemlist[categoryIndex - 1].RemoveAt(itemIndex);
                Console.WriteLine($"Item '{itemName}' removed completely.");
            }
            else
            {
                Console.WriteLine($"Quantity of '{itemName}' updated to {itemNode.Quantity}.");
            }
        }
    }
}