using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryFreshBread.Core.DTO_s
{
    public class OrderDTO
    {
        public int TotalCost { get; set; }
        public int OfficeId { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public virtual ICollection<BreadOrderDTO> BreadOrder { get; set; } = null!;
    }
}