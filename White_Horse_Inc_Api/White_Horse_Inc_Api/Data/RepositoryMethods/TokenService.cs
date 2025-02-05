using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using White_Horse_Inc_Core;
using White_Horse_Inc_Core.Models;

namespace White_Horse_Inc_Api.Data.RepositoryMethods
{
    public class TokenService
    {
        private string Key { get; set; } = string.Empty;

        public TokenService()
        {
            Key = Configuration.JwtKey;
        }

        public string GenerateToken(UserInformations user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var encodedKey = Encoding.ASCII.GetBytes(Key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.CompanyRole.Name),
                }),

                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(encodedKey),
                    SecurityAlgorithms.HmacSha256Signature

                ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
