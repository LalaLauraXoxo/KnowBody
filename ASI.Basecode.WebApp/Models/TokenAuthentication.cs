namespace ASI.Basecode.WebApp.Models
{
    /// <summary>
    /// Token Authentication
    /// </summary>
    public class TokenAuthentication
    {
        /// <summary>
        /// Gets or sets the secret key.
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// Gets or sets the audience.
        /// </summary>
        public string Audience { get; set; }
        /// <summary>
        /// Gets or sets the token path.
        /// </summary>
        public string TokenPath { get; set; }
        /// <summary>
        /// Gets or sets the name of the cookie.
        /// </summary>
        public string CookieName { get; set; }
        /// <summary>
        /// Gets or sets the expiration minutes.
        /// </summary>
        public int ExpirationMinutes { get; set; }
    }
}
