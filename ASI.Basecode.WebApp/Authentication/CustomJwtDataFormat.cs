using ASI.Basecode.WebApp.Extensions.Configuration;
using ASI.Basecode.Resources.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASI.Basecode.WebApp.Authentication
{
    /// <summary>
    /// CustomJwtDataFormat
    /// </summary>
    public class CustomJwtDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string algorithm;
        private readonly TokenValidationParameters validationParameters;
        private readonly TokenProviderOptionsFactory _tokenProviderOptionsFactory;

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the CustomJwtDataFormat class.
        /// </summary>
        /// <param name="algorithm">Algorithm</param>
        /// <param name="validationParameters">Validation parameters</param>
        /// <param name="configuration">Configuration</param>
        /// <param name="tokenProviderOptionsFactory">Token provider options factory</param>
        public CustomJwtDataFormat(string algorithm, TokenValidationParameters validationParameters, IConfiguration configuration, TokenProviderOptionsFactory tokenProviderOptionsFactory)
        {
            this.algorithm = algorithm;
            this.validationParameters = validationParameters;
            this._tokenProviderOptionsFactory = tokenProviderOptionsFactory;
            this._configuration = configuration;
        }

        /// <summary>
        /// Unprotects the specified <paramref name="protectedText" />.
        /// </summary>
        /// <param name="protectedText">Data protected value.</param>
        /// <returns>
        /// An instance of AuthenticationTicket.
        /// </returns>
        public AuthenticationTicket Unprotect(string protectedText)
            => Unprotect(protectedText, null);

        /// <summary>
        /// Unprotects the specified <paramref name="protectedText" /> using the specified <paramref name="purpose" />.
        /// </summary>
        /// <param name="protectedText">Data protected value</param>
        /// <param name="purpose">Purpose</param>
        /// <returns>
        /// An instance of AuthenticationTicket.
        /// </returns>
        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = null;
            SecurityToken validToken = null;

            try
            {
                principal = handler.ValidateToken(protectedText, this.validationParameters, out validToken);

                var validJwt = validToken as JwtSecurityToken;

                if (validJwt == null)
                {
                    throw new ArgumentException("Invalid JWT");
                }

                if (!validJwt.Header.Alg.Equals(algorithm, StringComparison.Ordinal))
                {
                    throw new ArgumentException($"Algorithm must be '{algorithm}'");
                }
            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }
            catch (ArgumentException)
            {
                return null;
            }

            var token = _configuration.GetTokenAuthentication();
            return new AuthenticationTicket(principal, new AuthenticationProperties(), Const.AuthenticationScheme);
        }

        /// <summary>
        /// Protects the specified ticket.
        /// </summary>
        /// <param name="ticket">The ticket.</param>
        /// <returns>A data protected value</returns>
        public string Protect(AuthenticationTicket ticket)
            => Protect(ticket, null);

        /// <summary>
        /// Protects the specified ticket.
        /// </summary>
        /// <param name="ticket">Ticket</param>
        /// <param name="purpose">Purpose</param>
        /// <returns>Encoded jwt token</returns>
        public string Protect(AuthenticationTicket ticket, string purpose)
        {
            var token = _configuration.GetTokenAuthentication();
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.SecretKey));

            var claimsPrincipal = ticket.Principal;
            var identity = (ClaimsIdentity)claimsPrincipal.Identity;
            var tokenProviderOptions = TokenProviderOptionsFactory.Create(token, signingKey);
            var tokenProvider = new TokenProvider(Options.Create(tokenProviderOptions));
            var encodedJwt = tokenProvider.GetJwtSecurityToken(identity, tokenProviderOptions);
            return encodedJwt;
        }
    }
}
