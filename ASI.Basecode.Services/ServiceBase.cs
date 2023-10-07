using Microsoft.Extensions.Logging;

namespace ASI.Basecode.Services
{
    /// <summary>
    /// Service Base class implementation
    /// </summary>
    public class ServiceBase
    {
        protected ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the ServiceBase class.
        /// </summary>
        /// <param name="loggerFactory">Logger factory.</param>
        public ServiceBase(ILoggerFactory loggerFactory)
        {
            this._logger = loggerFactory.CreateLogger<ServiceBase>();
        }
    }
}
