using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BakeryFreshBread.Core.Entities
{
    public class Bread
    {
        [Key]
        public int BreadId { get; set; }
        [Required]
        public string BreadName { get; set; }
        [Required]
        public float Price { get; set; }

        public Office Office { get; set; } = null!;
        public virtual ICollection<BreadOrder> BreadOrder { get; set; }
    }
}   