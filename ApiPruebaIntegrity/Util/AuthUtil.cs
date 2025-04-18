using ApiPruebaIntegrity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiPruebaIntegrity.Util
{
    public class AuthUtil
    {

        public static string HashPassword(string plainTextPassword)
        {
            return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
        }
        public static bool VerifyPassword(string plainTextPassword, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(plainTextPassword, passwordHash);
        }

        public static string GenerateJwtToken(User user, IConfiguration configuration)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Rol),
            new Claim("companyId", user.Company.Id.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
