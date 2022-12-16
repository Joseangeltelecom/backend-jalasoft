using BakeryFreshBread.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BakeryFreshBread.Core.Entities
{
    public class Office
    {
        [Key]
        [Required]
        public int OfficeId { get; set; }
        [Required]
        public string OfficeName { get; set; } = null!;
        public int Capacity { get; set; } 
    }
}
