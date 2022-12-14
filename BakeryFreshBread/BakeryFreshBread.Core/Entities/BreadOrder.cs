using System.ComponentModel.DataAnnotations;

namespace BakeryFreshBread.Core.Entities
{
    public class BreadOrder
    {
        [Key]
        public int BreadOrderId { get; set; }
        [Required]
        public Bread Bread { get; set; }
        public Order Order { get; set; }
        [Required]
        public int Quantity { get; set; }

  
    }
}
