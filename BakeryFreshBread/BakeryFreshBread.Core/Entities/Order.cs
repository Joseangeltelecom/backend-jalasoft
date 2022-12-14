using BakeryFreshBread.Core.Enumerations;
using BakeryFreshBread.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BakeryFreshBread.Core.Entities
{
    public class Order: IModificationHistory
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public List<BreadOrder> BreadOrder { get; set; }
        [Required]
        public  StatusType Status { get; set; }
        [Required]
        public float TotalCost { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public DateTime DateModified { get; set; }
    }
}
