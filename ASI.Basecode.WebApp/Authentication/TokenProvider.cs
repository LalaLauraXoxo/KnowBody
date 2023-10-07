using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ASI.Basecode.WebApp.Authentication
{
    /// <summary>
    /// TokenProvider
    /// </summary>
    public class TokenProvider
    {
        private readonly TokenProviderOptions _options;
        private readonly JsonSerializerSettings _serializerSettings;

        /// <summary>
        /// Initializes a new instance of the TokenProvider class.
        /// </summary>
        /// <param name="options">The options.</param>
        public TokenProvider(IOptions<TokenProviderOptions> options)
        {
            _options = options.Value;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }

        /// <summary>
        /// Gets the JWT security token.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <param name="tokenProvider">The token provider.</param>
        /// <returns></returns>
        public string GetJwtSecurityToken(ClaimsIdentity identity, TokenProviderOptions tokenProvider)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                                            issuer: tokenProvider.Issuer,
                                            audience: tokenProvider.Audience,
                                            claims: identity.Claims,
                                            notBefore: now,
                                            expires: now.Add(_options.Expiration),
                                            signingCredentials: tokenProvider.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler()
                            .WriteToken(jwt);

            return encodedJwt;
        }
    }
}
