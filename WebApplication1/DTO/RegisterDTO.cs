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

        public string FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Hashpassword { get; set; }

    }
}
