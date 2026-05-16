using Microsoft.AspNetCore.Mvc;
using WebApplication1.BLLayer;
using WebApplication1.DTO.OrderDTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly IorderBL _orderBL;
        private readonly IpaymentInterface _paymentInterface;

        public OrderController(IorderBL orderBL, IpaymentInterface paymentInterface)
        {
            _orderBL = orderBL;
            _paymentInterface = paymentInterface;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDTO orderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _orderBL.CreateOrder(orderDTO);
            var paymentUrl = await _paymentInterface.CreateCheckoutSession(orderDTO, result);
            return Ok(new
            {
                url = paymentUrl
            });

        }
    }
}
