using System;

namespace Uppgift2
{
    public class Item
    {
        // Variables for name, weight and quantity
		public string Name { get; set; }
		public float Weight { get; set; }

        public int Quantity { get; set; }

        public Item(string name, float weight, int quantity)
        {
            Name = name;
            Weight = weight;
            Quantity = quantity;
        }
    }
}
