using System;
using System.Collections.Generic;
using System.Text;

namespace BakeryFreshBread.Core.DTO_s
{
    public class BreadDTO
    {
        public string BreadName { get; set; } = string.Empty;
        public float Price { get; set; }
        public string CookingTime { get; set; } = string.Empty;
        public string RestingTime { get; set; } = string.Empty;
        public string FermentTime { get; set; } = string.Empty;
        public string CookingTemperature { get; set; } = string.Empty;
        public OfficeDTO Office { get; set; } = null!;
    }
}
