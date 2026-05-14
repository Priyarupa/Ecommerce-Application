using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.DTO
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }

      
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]

        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        public string? Hashpassword { get; set; }

        public List<AddressDTO> addressDTOs { get; set; } = new List<AddressDTO>();
    }
}
