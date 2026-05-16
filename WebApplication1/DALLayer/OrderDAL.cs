using Microsoft.EntityFrameworkCore;
using WebApplication1.BLLayer;
using WebApplication1.DBContext;
using WebApplication1.DTO.OrderDTO;

namespace WebApplication1.DALLayer
{
    public class OrderDAL: IorderBL
    {

        private readonly EcommerceDBContext _dbContext;
   
        public OrderDAL(EcommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateOrder(OrderDTO orderDTO)
         {
            try
            {
                var orderItemsJson = System.Text.Json.JsonSerializer.Serialize(orderDTO.OrderItems);
                var res = await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Exec sp_PlaceOrder  @UserId={orderDTO.UserId}, @AddressId={orderDTO.AddressId}, @TotalAmount={orderDTO.TotalAmount}, @OrderItemsJSON={orderItemsJson} ");
                return res;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
