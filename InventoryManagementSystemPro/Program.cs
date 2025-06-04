using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagementSystemPro.Services;
using InventoryManagementSystemPro.Models;

namespace InventoryManagementSystemPro
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the InventoryService class
            InventoryService service = new();

            bool running = true;

            Console.Title = "Inventory Management System by Molefe Ramotsepane";

            while (running) { 

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("-----------------------------------------\n");

                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. List Items");
                Console.WriteLine("3. Update Quantity");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Search Item");
                Console.WriteLine("6. Exit");
                Console.WriteLine("-----------------------------------------\n");
                Console.WriteLine("\nChoose an option (1-6): \n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("Enter details:");
                        Console.WriteLine("-----------------------------------------\n");
                        Console.Write("Enter item name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter item quantity: ");
                        int qty = int.Parse(Console.ReadLine());
                        service.AddItem(name, qty);
                        break;
                    case "2":
                        service.ListItems();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("Enter details:");
                        Console.WriteLine("-----------------------------------------\n");
                        Console.Write("Enter item ID: ");
                        int updatedId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new quantity: ");
                        int newQty = int.Parse(Console.ReadLine());
                        service.UpdateQuantity(updatedId, newQty);
                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("Enter details:");
                        Console.WriteLine("-----------------------------------------\n");
                        Console.Write("Enter item to delete ID: ");
                        int deletedId = int.Parse(Console.ReadLine());
                        service.DeleteItem(deletedId);
                        break;
                    case "5":
                        Console.Clear();
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("Enter details:");
                        Console.WriteLine("-----------------------------------------\n");
                        Console.Write("Enter keyword to seacrh: ");
                        string keyword = Console.ReadLine();
                        service.SearchItem(keyword);
                        break;
                    case "6":
                        running = false;
                        break;


                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid option. Please try again.\n");
                        break;
                }

            }
        }
    }
}
