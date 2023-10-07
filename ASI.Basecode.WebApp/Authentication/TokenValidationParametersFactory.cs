using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using ASI.Basecode.WebApp.Extensions.Configuration;
using ASI.Basecode.Resources.Constants;

namespace ASI.Basecode.WebApp.Authentication
{
    /// <summary>
    /// Token Validation
    /// </summary>
    public class TokenValidationParametersFactory
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="configuration"></param>
        public TokenValidationParametersFactory(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Creates token validation instance
        /// </summary>
        /// <returns></returns>
        public TokenValidationParameters Create()
        {
            var tokenAuthentication = this._configuration.GetTokenAuthentication();
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenAuthentication.SecretKey));

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,

                //issuer signing key
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,

                ValidIssuer = Const.Issuer,

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,

                ValidAudience = tokenAuthentication.Audience,

                // Validate the token expiry
                ValidateLifetime = true,

                // If you want to allow a certain amount of clock drift, set that here:
                ClockSkew = TimeSpan.Zero
            };

            return tokenValidationParameters;
        }
    }
}
