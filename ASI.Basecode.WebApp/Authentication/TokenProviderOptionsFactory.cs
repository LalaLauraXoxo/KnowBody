using ASI.Basecode.WebApp.Models;
using ASI.Basecode.Resources.Constants;
using Microsoft.IdentityModel.Tokens;
using System;

namespace ASI.Basecode.WebApp.Authentication
{
    /// <summary>
    /// Token provider factory
    /// </summary>
    public class TokenProviderOptionsFactory
    {
        /// <summary>
        /// Creates the token
        /// </summary>
        /// <param name="token">Token authentication</param>
        /// <param name="signingKey">Signing key</param>
        /// <returns>Token Provider Options</returns>
        public static TokenProviderOptions Create(TokenAuthentication token, SymmetricSecurityKey signingKey)
        {
            var options = new TokenProviderOptions
            {
                Path = token.TokenPath,
                Audience = token.Audience,
                Issuer = Const.Issuer,
                Expiration = TimeSpan.FromMinutes(token.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = new SignInManager(null, null).GetClaimsIdentity,
            };

            return options;
        }
    }
}
