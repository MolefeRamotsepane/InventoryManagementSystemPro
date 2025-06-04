using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Define a namespace to organize related classes and types
namespace InventoryManagementSystemPro.Models
{
    // Declare a public class named Item, which can be accessed from outside the assembly
    public class Item
    {
        // Define three public properties to store the item's id, name, and quantity
        // These properties have getter and setter accessors, allowing them to be read and modified
        public int Id { get; set; } // Unique identifier for the item
        public string Name { get; set; } // Human-readable name of the item
        public int Quantity { get; set; } // Current quantity of the item in stock

        // Define a constructor to initialize a new Item object with the given id, name, and quantity
        // This constructor takes three parameters and assigns them to the corresponding properties
        public Item(int id, string name, int quantity)
        {
            // Assign the id parameter to the Id property
            Id = id;
            // Assign the name parameter to the Name property
            Name = name;
            // Assign the quantity parameter to the Quantity property
            Quantity = quantity;
        }

        // Override the ToString method to provide a human-readable representation of the Item object
        // This method returns a string that includes the item's id, name, and quantity
        public override string ToString()
        {
            // Use string interpolation to format the string with the item's properties
            return $"ID: {Id} - Name: {Name} - Quantity: {Quantity}";
        }
    }
}