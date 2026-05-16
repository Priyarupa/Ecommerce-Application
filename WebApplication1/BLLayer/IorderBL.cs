using WebApplication1.DTO.OrderDTO;

namespace WebApplication1.BLLayer
{
    public interface IorderBL
    {
        Task<int> CreateOrder(OrderDTO orderDTO);
    }
}
