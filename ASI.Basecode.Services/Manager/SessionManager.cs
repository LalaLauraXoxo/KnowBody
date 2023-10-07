using Microsoft.AspNetCore.Http;

namespace ASI.Basecode.Services.Manager
{
    /// <summary>
    /// Session Manager
    /// </summary>
    public class SessionManager
    {
        /// <summary>
        /// Initializes a new instance of the SessionManager class.
        /// </summary>
        /// <param name="session">Session</param>
        public SessionManager(ISession session)
        {
            this._session = session;
        }

        /// <summary>
        /// Gets or sets the session.
        /// </summary>
        protected ISession _session { get; set; }

        /// <summary>
        /// Clears the session instance.
        /// </summary>
        public void Clear()
        {
            this._session.Clear();
        }
    }
}
