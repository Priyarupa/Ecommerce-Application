using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.DTO.OrderDTO
{
    public class OrderDTO
    {

        public int UserId { get; set; }
        public int AddressId { get; set; }
        public int TotalAmount { get; set; }
        public List<OrderItemDTO>? OrderItems { get; set; }
    }
}
