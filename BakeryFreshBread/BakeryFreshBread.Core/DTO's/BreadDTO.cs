using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryFreshBread.Core.DTO_s
{
    public class BreadDTO
    {
        public string BreadName { get; set; } = string.Empty;
        public float Price { get; set; }
        public OfficeDTO Office { get; set; } = null!;
    }
}
