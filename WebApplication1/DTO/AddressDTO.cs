namespace WebApplication1.DTO
{
    public class AddressDTO
    {
        public string AddressLine1 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; }
        public string Country { get; set; }
         public string PostalCode { get; set; }
        public bool? IsDefault { get; set; }
    }
}
