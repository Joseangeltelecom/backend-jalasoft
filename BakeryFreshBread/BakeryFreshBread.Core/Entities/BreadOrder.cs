using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryFreshBread.Core.Entities
{
    public class BreadOrder
    {
        [Key]
        [Required]
        public int BreadOrderId { get; set; }
        [Required]
        public int BreadId { get; set; }
        public Bread Bread { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
