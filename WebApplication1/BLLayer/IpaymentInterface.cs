using WebApplication1.DTO.OrderDTO;

namespace WebApplication1.BLLayer
{
    public interface IpaymentInterface
    {
        Task<string> CreateCheckoutSession(OrderDTO order, int orderId);

    }
}
