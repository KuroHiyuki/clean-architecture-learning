using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using TechStore.Application.Common.Interfaces.Authentication;
using TechStore.Application.Common.Interfaces.DateProvider;
using TechStore.Domain.Entities;

namespace TechStore.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JwtSetting _jwtSetting;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtSetting> jwtSetting) 
        {
            _dateTimeProvider = dateTimeProvider;
            _jwtSetting = jwtSetting.Value;
        }
        public string GenerateToken(User user)
        {
            //var configuation
            var siginingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtSetting.Secret!)),
                SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var SecurityToken = new JwtSecurityToken(
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSetting.ExpiryMinutes),
                claims: claims,
                signingCredentials: siginingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(SecurityToken);
        }
    }
}
