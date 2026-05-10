using Microsoft.AspNetCore.Mvc;
using WebApplication1.BLLayer;
using WebApplication1.DTO;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]/[action]")]
    public class ProductController:ControllerBase
    {
        private readonly IProductGet _productGet;

        public ProductController(IProductGet productGet)
        {
            _productGet = productGet;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _productGet.GetProducts();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProducts(insertproductDto insertproductDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _productGet.InsertProducts(insertproductDto);

            return Ok(result);

        }
    }
}
