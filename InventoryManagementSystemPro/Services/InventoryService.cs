using InventoryManagementSystemPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Define a namespace for the Inventory Management System's services
namespace InventoryManagementSystemPro.Services
{
    // Define a public class for managing inventory items
    public class InventoryService
    {
        // Initialize an empty list to store inventory items
        private List<Item> items = new();

        // Initialize a counter to assign unique IDs to items
        private int IdCounter = 1;

        // Define a method to add a new item to the inventory
        public void AddItem(string name, int quantity)
        {
            // Create a new item with the given name, quantity, and a unique ID
            var item = new Item(IdCounter++, name, quantity);

            // Add the new item to the inventory list
            items.Add(item);

            // Print a success message to the console
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nItem added successfully!\n");
            Console.ResetColor();
        }

        // Define a method to list all items in the inventory
        public void ListItems()
        {
            // Check if the inventory is empty
            if (items.Count == 0)
            {
                // If empty, print a message to the console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo items found.\n");
                return;
            }
            else
            {
                // If not empty, print a header and list all items
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Inventory List");
                Console.WriteLine("-----------------------------------------\n");

                // Iterate over each item in the inventory and print its details
                foreach (var item in items)
                    Console.WriteLine(item);
            }
        }

        // Define a method to update the quantity of an existing item
        public void UpdateQuantity(int id, int newQuantity)
        {
            // Find the item with the given ID in the inventory
            var item = items.FirstOrDefault(i => i.Id == id);

            // Check if the item was found
            if (item != null)
            {
                // If found, update the item's quantity
                item.Quantity = newQuantity;

                // Print a success message to the console
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nItem quantity updated successfully!\n");
                Console.ResetColor();
            }
            else
            {
                // If not found, print an error message to the console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nItem not found.\n");
                Console.ResetColor();
            }
        }

        // Define a method to delete an existing item from the inventory
        public void DeleteItem(int id)
        {
            // Find the item with the given ID in the inventory
            var item = items.FirstOrDefault(i => i.Id == id);

            // Check if the item was found
            if (item != null)
            {
                // If found, remove the item from the inventory
                items.Remove(item);

                // Print a success message to the console
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nItem deleted successfully!\n");
                Console.ResetColor();
            }
            else
            {
                // If not found, print an error message to the console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nItem not found.\n");
                Console.ResetColor();
            }
        }

        // Define a method to search for items by keyword
        
        public void SearchItem(string keyword)
        {
            // Use LINQ to find items whose names contain the keyword (case-insensitive)
            var SearchResults = items.Where(i => i.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();

            // Check if any items were found
            if (SearchResults.Count == 0)
            {
                // If not found, print an error message to the console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNo items found.\n");
                Console.ResetColor();
            }
            else
            {
                // If found, print a header and list the search results
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Search Results");
                Console.WriteLine("-----------------------------------------\n");

                // Iterate over each search result and print its details
                foreach (var item in SearchResults)
                    Console.WriteLine(item);
            }
        }
    }
}