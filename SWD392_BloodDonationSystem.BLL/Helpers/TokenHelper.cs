﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SWD392_BloodDonationSystem.DAL.Data.Entities;
using SWD392_BloodDonationSystem.DAL.Data.Repositories;

namespace SWD392_BloodDonationSystem.BLL.Helpers;

public class TokenHelper()
{
    private IConfiguration _configuration;
    
    public TokenHelper(IConfiguration configuration) : this()
    {
        _configuration = configuration;
    }
    
    public string GenerateToken(string id, string citizenID,  string email, ICollection<UserRole> roles)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key =  Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
        var expiration = DateTime.UtcNow.AddHours(int.Parse(_configuration["JWT:TokenExpireInHours"]));
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, id),
            new Claim(ClaimTypes.Email, email),
            new Claim("citizen_id", citizenID)
        };
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role.Role.RoleName)));
        
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiration,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:ValidIssuers:0"],
            Audience = _configuration["JWT:ValidAudiences:0"]
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        return tokenString;
    }
}