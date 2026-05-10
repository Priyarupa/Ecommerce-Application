using Microsoft.AspNetCore.Mvc;
using WebApplication1.BLLayer;
using WebApplication1.DTO;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserBL _userBL;

        public UserController(IUserBL userBL, IConfiguration configuration)
        {
            _userBL = userBL;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var hashpassword = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password);

            registerDTO.Hashpassword = hashpassword;

            var result = await _userBL.RegisterUser(registerDTO);

            return Ok("user is created");
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("enterpassword and email");
            }
            var datahashpassword = await _userBL.Login(loginDTO);
            var hashpassword = BCrypt.Net.BCrypt.Verify(loginDTO.Password, datahashpassword.Hashpassword);
            if (!hashpassword)
            {
                return Unauthorized();
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signingCreditienals = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, loginDTO.Email),
                new Claim("role","Admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signingCreditienals
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new { Token = tokenString });
        }

    }


}
