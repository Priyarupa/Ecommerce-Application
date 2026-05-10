using Microsoft.EntityFrameworkCore;
using WebApplication1.BLLayer;
using WebApplication1.DBContext;
using WebApplication1.DTO;

namespace WebApplication1.DALLayer
{
    public class ProductGet:IProductGet
    {
        private readonly EcommerceDBContext _dbContext;
        public  ProductGet(EcommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GetProductsDTO>> GetProducts()
        {
            var products = await _dbContext.
                Database.SqlQuery<GetProductsDTO>
                ($"Exec dbo.GetProductsByCategory").ToListAsync();
            return products;
        }

        public async Task<int> InsertProducts(insertproductDto insertproductDto)
        {
            int rows = await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Exec InsertOrUpdateProduct @productId={insertproductDto.Id},@CategoryId={insertproductDto.CategoryId} ,@SKU={insertproductDto.ProductName},@price={insertproductDto.Price}");
            return rows;
        }
    }
}
