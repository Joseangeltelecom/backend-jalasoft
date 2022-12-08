using System.ComponentModel.DataAnnotations;

namespace EcommerceJala.Core.Entities
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}

