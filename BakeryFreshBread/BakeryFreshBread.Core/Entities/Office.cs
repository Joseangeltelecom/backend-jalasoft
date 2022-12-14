using BakeryFreshBread.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BakeryFreshBread.Core.Entities
{
    public class Office
    {
        [Key]
        public int OfficeId { get; set; }
        [Required]
        public string OfficeName { get; set; }
        [Required]
        public int BreadCapacity { get; set; }
        public List<Order> Orders { get; set; }

    }
}
