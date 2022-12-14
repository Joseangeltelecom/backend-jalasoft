using BakeryFreshBread.Core.Entities;
using BakeryFreshBread.Core.Enumerations;

namespace BakeryFreshBread.Core.DTO_s
{
    public class CreateOrderRequest
    {
        public BreadType Breadtype { get; set; }
        public int BreadQuantity { get; set; }
        public int BreadId { get; set; }
        public int OrderId { get; set; }
        public int BreadOrderId { get; set; }
    }
}
