using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using WebApplication1.BLLayer;
using WebApplication1.DBContext;
using WebApplication1.DTO;

namespace WebApplication1.DALLayer
{
    public class UserDAL : IUserBL
    {
        private readonly EcommerceDBContext _dbContext;
        public UserDAL(EcommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> RegisterUser(RegisterDTO registerDTO)
        {
            try
            {
                string addressJson =
                               JsonSerializer.Serialize(registerDTO.addressDTOs);
                var res = await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Exec RegisterUser @Email={registerDTO.Email},@PasswordHash={registerDTO.Hashpassword},@FirstName={registerDTO.FirstName},@LastName={registerDTO.LastName},@Addresses={addressJson}");
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<HashDTO> Login(LoginDTO loginDTO)
        {
            try
            {
                var res = (await _dbContext.Database.SqlQuery<HashDTO>($"Exec dbo.GETHash @Email={loginDTO.Email}").ToListAsync()).FirstOrDefault();

                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public async Task<UserProfileDTO> GetUserProfile(int id)
        {
            try
            {
                var res = (await _dbContext.Database.SqlQuery<UserProfileDTO>($"Exec dbo.GetUsersProfile @UserId={id}").ToListAsync()).FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
