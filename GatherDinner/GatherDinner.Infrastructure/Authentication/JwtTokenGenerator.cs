using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GatherDinner.Application;
using GatherDinner.Application.Common.Interfaces.Authentication;
using GatherDinner.Domain.Entities;
using GatherDinner.infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GatherDinner.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IDateTimeProvidor _dateTimeProvidor;
    private readonly jwtSettings _jwtSettings;
     public JwtTokenGenerator(IDateTimeProvidor dateTimeProvidor, IOptions<jwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
        _dateTimeProvidor = dateTimeProvidor;
    }
    public string GenerateToken(User user)
    {

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256

        );
       var claims = new[]
       {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
        new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

       };
       var securityToken = new JwtSecurityToken(
        issuer: _jwtSettings.Issuer,
        expires: _dateTimeProvidor.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
        claims: claims,
        signingCredentials: signingCredentials


       );
       return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}