/*using CKK.Logic.Models;
using System;

namespace CKK
{
    class Program
    {
        private static int count = 0;
        static void Main(string[] args)
        {
            Store mikesGeneral = new Store();

            Console.WriteLine("Welcome to Corey's Knick Knacks");
            var input = "";
            while (input != "4")
            {
                Console.WriteLine(GetMenu());
                input = Console.ReadLine();
                Console.Clear();
                switch(input)
                {
                    case "1":
                        ShowItems(mikesGeneral);
                        break;
                    case "2":
                        CreateAndAddItem(mikesGeneral);
                        break;
                    case "3":
                        RemoveItem(mikesGeneral);
                        break;
                }
            }

            Console.WriteLine("Thanks for coming!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void ShowItems(Store store)
        {
            *//*Console.WriteLine("------------------");
            if (store.FindStoreItemById(1) == null && store.FindStoreItemById(2) == null && store.FindStoreItemById(3) == null)
            {
                Console.WriteLine("There is nothing in your store!");
                Console.WriteLine("------------------");
                return;
            }
            Console.WriteLine("The items in your store are:");
            if (store.FindStoreItemById(1) != null)
            {
                Console.WriteLine($"1. {store.FindStoreItemById(1).GetName()}: {store.FindStoreItemById(1).GetPrice():C}");
            }
            if (store.FindStoreItemById(2) != null)
            {
                Console.WriteLine($"2. {store.FindStoreItemById(2).GetName()}: {store.FindStoreItemById(2).GetPrice():C}");
            }
            if(store.FindStoreItemById(3) != null)
            {
                Console.WriteLine($"3. {store.FindStoreItemById(3).GetName()} : {store.FindStoreItemById(3).GetPrice():C}");
            }
            Console.WriteLine("------------------");*//*
        }

        public static void CreateAndAddItem(Store store)
        {
            Console.WriteLine("What is the name of the product?");
            var name = Console.ReadLine();
            Console.WriteLine("What is the price of the product?");
            decimal price = -1;
            while (price == -1)
            {
                try
                {
                    price = decimal.Parse(Console.ReadLine());
                    if(price < 0)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a valid value greater than or equal to 0");
                    price = -1;
                }
            }
            Product createdProduct = new Product();
            createdProduct.SetId(++count);
            createdProduct.SetName(name);
            createdProduct.SetPrice(price);
            store.AddStoreItem(createdProduct);
            Console.WriteLine("Store Product added.");
        }

        public static void RemoveItem(Store store)
        {
            int id = -1;
            while(id < 0)
            {
                try
                {
                    ShowItems(store);                    
                    Console.WriteLine("What item would you like to remove? (just the index number)");
                    id = int.Parse(Console.ReadLine());
                    if(id < 0)
                    {
                        throw new Exception();
                    }
                } catch (Exception)
                {
                    Console.WriteLine("Please enter a valid number choice.");
                }
            }
            //store.RemoveStoreItem(id);
            Console.WriteLine("Removed Item.");
        }

        public static string GetMenu()
        {
            return 
                "What would you like to do?\n" + 
                "1. View Products in store.\n" + 
                "2. Add Product in store\n" + 
                "3. Remove Product in store\n" + 
                "4. Exit";
        }
    }
}
*/