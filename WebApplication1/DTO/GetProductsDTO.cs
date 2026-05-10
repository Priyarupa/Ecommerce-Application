using System.Text.Json.Serialization;

namespace WebApplication1.DTO
{
    public class GetProductsDTO 
    {
    
        public string? ProductName { get; set; }

        public int Price { get; set; }

        public string? CategoryName { get; set; }

    }
}
