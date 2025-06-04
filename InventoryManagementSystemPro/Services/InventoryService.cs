using InventoryManagementSystemPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

// Define a namespace for the Inventory Management System's services
namespace InventoryManagementSystemPro.Services
{

   
    // Define a public class for managing inventory items
    public class InventoryService
    {
        // Initialize an empty list to store inventory items
        private List<Item> items = new List<Item>();
        // Initialize a counter to assign unique IDs to items
        private int IdCounter;
        private readonly string filePath = "inventory.json"; // Path to the JSON file

        public InventoryService()
        {
            items = LoadItems(); // Load the existing items from the inventory file into the 'items' list
            // If the list is not empty, find the maximum ID of the existing items and increment it by 1,
            // If the list is empty, set the 'IdCounter' to 1 (since there are no existing IDs to increment)
            IdCounter = items.Any() ? items.Max(i => i.Id) + 1 : 1; // Its the shorter version of an if statement
        }

        // Define a method to add a new item to the inventory
        public void AddItem(string name, int quantity)
        {
            // Create a new item with the given name, quantity, and a unique ID
            var item = new Item(IdCounter++, name, quantity );

            // Add the new item to the inventory list
            items.Add(item);
            SaveItems();

            // Print a success message to the console
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nItem added successfully!\n");
            Console.ResetColor();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // Define a method to list all items in the inventory
        public void ListItems()
        {
            // Check if the inventory is empty
            if (items.Count == 0)
            {
                // If empty, print a message to the console
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Inventory List");
                Console.WriteLine("-----------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No items found.\n");

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
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

                Console.WriteLine("\nPress any key to continue...\n");
                Console.ReadKey();
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
                SaveItems(); // Save the updated inventory

                // Print a success message to the console
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nItem quantity updated successfully!\n");
                Console.ResetColor();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                // If not found, print an error message to the console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nItem not found.\n");
                Console.ResetColor();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
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
                SaveItems(); // Save the updated inventory

                // Print a success message to the console
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nItem deleted successfully!\n");
                Console.ResetColor();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                // If not found, print an error message to the console
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nItem not found.\n");
                Console.ResetColor();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
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
                Console.Clear();
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine("Search Results");
                Console.WriteLine("-----------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No items found.\n");
                Console.ResetColor();

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
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

                Console.WriteLine("\nPress any key to continue...\n");
                Console.ReadKey();
            }
        }

        // Define a method to save the current list of items to a file
        private void SaveItems() 
        {
            // Serialize the list of items into a JSON string
            var json = JsonSerializer.Serialize(items);

            // Write the JSON string to the file specified by the filePath variable
            File.WriteAllText(filePath, json);
        }

        // Define a method to load a list of items from a file
        private List<Item> LoadItems()
        {
            // Check if the file specified by the filePath variable exists
            if (File.Exists(filePath))
            {
                // Read the contents of the file into a string
                var json = File.ReadAllText(filePath);

                // Deserialize the JSON string into a list of Item objects
                // If deserialization fails, return an empty list
                return JsonSerializer.Deserialize<List<Item>>(json) ?? new List<Item>();
            }

            // If the file does not exist, return an empty list
            return new List<Item>();
        }
    }
}