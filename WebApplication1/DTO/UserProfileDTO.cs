using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.DTO
{
    public class UserProfileDTO
    {
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        public string Email { get; set; }

        [JsonIgnore]
        public string AddressJson { get; set; }


        [NotMapped]
        public List<AddressDTO> addressDTOs
        {
            get => string.IsNullOrEmpty(AddressJson)
                   ? new()
                   : JsonSerializer.Deserialize<List<AddressDTO>>(AddressJson);
            set => AddressJson = JsonSerializer.Serialize(value);
        }
    }
}
