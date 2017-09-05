using System;
using System.Collections.Generic;

namespace Uppgift2
{
    public class Backpack
    {
        // Create a list of "Item" to hold all items
        public List<Item> packContent = new List<Item>();

        // Sets the total weight of the backpack
        public float BackpackWeight { get; set; }


        // Adds a new item or increases quantity and weight
        public void AddItem(string name)
        {
            int keyForDuplicate = IfItemExistGetIndex(name);

            // If there is no existing item with same name, ask user for weight.
            // Initialize new Item with name and weight as argument for the constructor
            if(keyForDuplicate == -1)
            {
                Console.Write("Ange vikt för en '{0}': ", name);
                float weight = Convert.ToSingle(Console.ReadLine());

                Item newItem = new Item(name, weight, 1);
                packContent.Add(newItem);
            }
            else
            {
                // If item already exist ,increase the items quantity with ONE
                Item existingItem = packContent[keyForDuplicate];
                existingItem.Quantity++;
            }
        }

        // Returns the Item-List if the backpack is not empty
        public List<Item> GetContent()
        {
            if (IsPackEmpty())
                throw new Exception("Din ryggsäck är tom!");
            
            return packContent;
        }   

        // Removes an item or a user specified quantity from the item
		public void RemoveItem(string itemToRemove)
		{
			int keyForDuplicate = IfItemExistGetIndex(itemToRemove);

            if (keyForDuplicate == -1)
            {
                throw new Exception(itemToRemove + " finns inte i din ryggsäck!");
            }

            Item existingItem = packContent[keyForDuplicate];

            // If there's 1 or less of the items quantity, remove the item
            if(existingItem.Quantity <= 1)
            {
                packContent.Remove(existingItem);
            }
            else
            {
                // Ask user how many to remove from quantity
                Console.Write("Hur många av '{0}' vill du ta bort: ", existingItem.Name);
                int quantity = Convert.ToInt32(Console.ReadLine());

                // Subtract user specified quantity
                existingItem.Quantity -= quantity;

                // If the quantity of the item is 0 or less than, remove item from packContent
                if(existingItem.Quantity <= 0)
                {
                    packContent.Remove(existingItem);
                }
            }
		}

        // Clears the backpack if not empty
		public void EmptyBackpack()
		{
			if (IsPackEmpty())
                throw new Exception("Din ryggsäck är redan tom!");

            packContent.Clear();
            Console.WriteLine("Du har tömt din ryggsäck!");
		}

        // Returns true if there is no item in packContent
		public bool IsPackEmpty()
		{
			if (packContent.Count <= 0)
                return true;
			
            return false;
        }

        // Bad name...
        // Searches packContent for matching name of items
        // If found, returns the index of the item in packContent
        // Returns -1 if not found
        private int IfItemExistGetIndex(string newItem)
        {
            foreach (Item item in packContent)
            {
                if (item.Name == newItem)
                {
                    return packContent.IndexOf(item);
                }
            }

            return -1;
        }
    }
}