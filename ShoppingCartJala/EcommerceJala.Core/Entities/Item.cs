using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceJala.Core.Entities
{
    public class Item
    {
        public string Name { get; set; }
        public int ItemId { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public Item(string Name, int ItemId, float Price, string Description, int Quantity)
        {
            this.Name = Name;
            this.ItemId = ItemId;
            this.Price = Price;
            this.Description = Description;
            this.Quantity = Quantity;
        }
        public Item()
        {

        }
    }
}
