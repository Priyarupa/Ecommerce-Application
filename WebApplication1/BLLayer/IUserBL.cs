using WebApplication1.DTO;

namespace WebApplication1.BLLayer
{
    public interface IUserBL
    {
        Task<int> RegisterUser(RegisterDTO registerDTO);
        Task<HashDTO> Login(LoginDTO loginDTO);

        Task<UserProfileDTO> GetUserProfile(int id);
    }
}
