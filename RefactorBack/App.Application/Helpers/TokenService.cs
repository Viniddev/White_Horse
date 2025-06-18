using App.Domain.Entities;
using App.Domain;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace App.Application.Helpers;

public static class TokenService
{
    public static string GenerateToken(UserInformations user, IConfiguration configuration)
    {
        //aqui instanciamos um objeto jwt para manipulação do token e retemos o codigo
        var tokenHandler = new JwtSecurityTokenHandler();
        var encodedKey = Encoding.ASCII.GetBytes(Configuration.JwtKey);

        //aqui capturamos as claims do usuario pra inserir dentro do token
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name)
        };

        //aqui criamos uma chave simetrica pra validar o token publico e privado
        //alem disso identificamos qual o padrão de criptografia que será usado no processo
        var key = new SymmetricSecurityKey(encodedKey);
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //aqui ocorre a definição do token jwt para utilização
        var token = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(8),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
