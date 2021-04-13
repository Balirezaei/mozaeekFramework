using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MozaeekCore.RestAPI.Utility
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }

    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            using (RSA privateRsa = RSA.Create())
            {
                var privatekeyDir = Path.Combine(Directory.GetCurrentDirectory(),
                    "Keys",
                    this._configuration.GetValue<String>("PrivateKey")
                );
                privateRsa.FromXmlFile(privatekeyDir);
                var privateKey = new RsaSecurityKey(privateRsa);
                SigningCredentials signingCredentials = new SigningCredentials(privateKey, SecurityAlgorithms.RsaSha256);

                var jwtToken = new JwtSecurityToken(issuer: "Bahar",
                    audience: "Anyone",
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["accessTokenDurationInMinutes"])),
                    signingCredentials: signingCredentials
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);
            }



        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            using (RSA privateRsa = RSA.Create())
            {
                var pubKeyDir = Path.Combine(Directory.GetCurrentDirectory(),
                    "Keys",
                    this._configuration.GetValue<String>("PublicKey")
                );
                privateRsa.FromXmlFile(pubKeyDir);
                var pubKey = new RsaSecurityKey(privateRsa);
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = pubKey,
                    ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");
                return principal;
            }

        }
    }
}