using BakeryFreshBread.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BakeryFreshBread.Core.Entities
{
    public class Order : IModificationHistory
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        [Required]
        public float TotalCost { get; set; }
        [Required]
        public int OfficeId { get; set; }
        [Required]
        public string Status { get; set; }
        public virtual ICollection<BreadOrder> BreadOrder { get; set; } = null!;
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }
    }
}
