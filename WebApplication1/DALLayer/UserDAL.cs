using Microsoft.EntityFrameworkCore;
using WebApplication1.BLLayer;
using WebApplication1.DBContext;
using WebApplication1.DTO;

namespace WebApplication1.DALLayer
{
    public class UserDAL:IUserBL
    {
        private readonly EcommerceDBContext _dbContext;
        public UserDAL(EcommerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> RegisterUser(RegisterDTO registerDTO)
        {
            var res=await _dbContext.Database.ExecuteSqlInterpolatedAsync($"Exec RegisterUser @Email={registerDTO.Email},@PasswordHash={registerDTO.Hashpassword},@FirstName={registerDTO.FirstName},@LastName={registerDTO.LastName}");
            return res;
        }

        public async Task<HashDTO> Login(LoginDTO loginDTO)
        {
            try
            {
                var res = (await  _dbContext.Database.SqlQuery<HashDTO>($"Exec dbo.GETHash @Email={loginDTO.Email}").ToListAsync()).FirstOrDefault();

                return res;
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }


    }
}
