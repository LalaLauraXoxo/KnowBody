using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASI.Basecode.WebApp.Authentication
{
    /// <summary>
    /// Token provider
    /// </summary>
    public class TokenProviderOptions
    {
        /// <summary>
        /// Gets or sets the path for token generation.
        /// </summary>
        public string Path { get; set; } = "api/token";
        /// <summary>
        /// Gets or sets the issuer.
        /// </summary>
        public string Issuer { get; set; }
        /// <summary>
        /// Gets or sets the audience.
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Gets or sets the expiration.
        /// </summary>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(5);
        /// <summary>
        /// Gets or sets the signing credentials.
        /// </summary>
        public SigningCredentials SigningCredentials { get; set; }
        /// <summary>
        /// Gets or sets the identity resolver.
        /// </summary>
        public Func<string, string, Task<ClaimsIdentity>> IdentityResolver { get; set; }
        /// <summary>
        /// Gets or sets the nonce generator.
        /// </summary>
        public Func<Task<string>> NonceGenerator { get; set; }
          = () => Task.FromResult(Guid.NewGuid().ToString());
    }
}
