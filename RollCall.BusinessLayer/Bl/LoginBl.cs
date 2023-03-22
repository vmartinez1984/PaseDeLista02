using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RollCall.Core.Dtos;
using RollCall.Core.Entities;
using RollCall.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RollCall.BusinessLayer.Bl
{
    internal class LoginBl : BaseBl, ILoginBl
    {
        private readonly IConfiguration _configuration;

        public LoginBl(IRepository repository, IMapper mapper, IConfiguration configuration) : base(repository, mapper)
        {
            _configuration = configuration;
        }

        public async Task<TokenDto> LoginAsync(UserLoginDto userLoginDto)
        {
            User user;
            TokenDto token;

            user = await _repository.User.GetAsync(userLoginDto.Email);
            token = null;
            if (user != null)
            {
                if (IsValid(user.Password, userLoginDto.Password))
                {
                    token = new TokenDto
                    {
                        Token = GenerateJwt(user),
                        DateExpiration = DateTime.Now.AddMinutes(20),
                        Roles = user.Role.Name,
                        FullName = user.Person.Name + " " +user.Person.LastName
                    };
                }
            }

            return token;
        }

        private bool IsValid(string password1, string password2)
        {
            if(password1 == password2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GenerateJwt(User user)
        {
            //create claim
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Role, user.Role.Id.ToString()),
                new Claim("Rol",user.Role.Name),
                new Claim("IdUser",user.Id.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "http://localhost:5000",
                audience: "http://localhost:5000",
                claims,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: signIn
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
