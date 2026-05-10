using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{
    public class Login
    {

        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
