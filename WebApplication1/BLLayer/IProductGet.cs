using WebApplication1.DTO;

namespace WebApplication1.BLLayer
{
    public interface IProductGet
    {
        Task<List<GetProductsDTO>> GetProducts();

        Task<int> InsertProducts(insertproductDto insertproductDto);
    }
}
