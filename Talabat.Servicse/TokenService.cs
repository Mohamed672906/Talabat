using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Talabat.Core.Entites.Identity;
using Talabat.Core.Services;

namespace Talabat.Servicse
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }






        public async Task<string> CreateTokenAsync(AppUser User, UserManager<AppUser> userManager)
        {

            //Payload 

            //Privat Claims

            var AuthClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName, User.DisplayName),
                new Claim (ClaimTypes.Email,User.Email)

            };

            var UserRole = await userManager.GetRolesAsync(User);
            foreach (var Role in UserRole)
            {
                AuthClaims.Add(new Claim(ClaimTypes.Role, Role));
            }

            var AutKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var Token = new JwtSecurityToken
                (
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT,ValidAudinece"],
                expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT,DurationInDays"])),
                claims: AuthClaims,
                signingCredentials: new SigningCredentials(AutKey, SecurityAlgorithms.HmacSha256Signature)

                );
            return new JwtSecurityTokenHandler().WriteToken(Token);

        }
    }
}
