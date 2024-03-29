using Application.Abstractions.Services;
using Domain.Entities;
using Infrastructure.Authentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class JwtTokenService(AuthenticationSettings settings) : IJwtTokenService
    {
        private readonly AuthenticationSettings _settings = settings;

        public string GenerateToken(UserEntity user)
        {
            List<Claim> claims =
           [
                new (ClaimTypes.NameIdentifier, user.Id.ToString()),
                new (ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new (ClaimTypes.Role, user.Role.ToString()),
            ];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_settings.JwtExpireDay);

            var token = new JwtSecurityToken(
                _settings.JwtIssuer,
                _settings.JwtAudience,
                claims,
                expires: expires,
                signingCredentials: credentials);

            var tokenHanlder = new JwtSecurityTokenHandler();
            return tokenHanlder.WriteToken(token);
        }
    }
}
