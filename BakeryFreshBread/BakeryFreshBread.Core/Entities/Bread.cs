using BakeryFreshBread.Core.Enumerations;
using BakeryFreshBread.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BakeryFreshBread.Core.Entities
{
    public class Bread
    {
        [Key]
        public int BreadId { get; set; }
        [Required]
        public BreadType BreadType { get; set; }
        [Required]
        public float Price { get; set; }
    }
}