using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using static ASI.Basecode.Resources.Constants.Enums;

namespace ASI.Basecode.WebApp.Models
{
    /// <summary>
    /// ApiResult
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        public object Response { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public byte[] data { get; set; }

        /// <summary>
        /// Initializes a new instance of the ApiResult{T} class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        public ApiResult(Status status, object model, string message)
        {
            this.Status = status;
            this.Response = model;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the ApiResult{T} class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        public ApiResult(Status status, byte[] data, string message)
        {
            this.Status = status;
            this.data = data;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the ApiResult{T} class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="name">The name.</param>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        public ApiResult(Status status, string name, object model, string message)
        {
            this.Status = status;
            this.Response = model;
            this.Message = message;
            this.Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the ApiResult{T} class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="message">The message.</param>
        public ApiResult(Status status, string message)
        {
            this.Status = status;
            this.Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the ApiResult{T} class.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        public ApiResult(Status status, T model, string message)
        {
            this.Status = status;
            this.Response = model;
            this.Message = message;
        }

        /// <summary>
        /// Creates the API success response.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        /// <returns>ApiResult object</returns>
        public static ApiResult<T> CreateSuccess(T model, string message)
        {
            return new ApiResult<T>(Status.Success, model, message);
        }

        /// <summary>
        /// Creates the API success response.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        /// <returns>ApiResult object</returns>
        public static ApiResult<object> CreateSuccess(object model, string message)
        {
            return new ApiResult<object>(Status.Success, model, message);
        }

        /// <summary>
        /// Creates the API success response.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="model">The model.</param>
        /// <param name="message">The message.</param>
        /// <returns>ApiResult object</returns>
        public static ApiResult<object> CreateSuccess(string name, object model, string message)
        {
            return new ApiResult<object>(Status.Success, name, model, message);
        }

        /// <summary>
        /// Creates the API success response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>ApiResult object</returns>
        public static ApiResult<object> CreateSuccess(string message)
        {
            return new ApiResult<object>(Status.Success, message);
        }

        /// <summary>
        /// Creates the API success response.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        /// <returns>ApiResult object</returns>
        public static ApiResult<T> CreateSuccess(byte[] data, string message)
        {
            return new ApiResult<T>(Status.Success, data, message);
        }

        /// <summary>
        /// Creates the API error response.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>ApiResult object</returns>
        public static ApiResult<T> CreateError(string message)
        {
            return new ApiResult<T>(Status.Error, message);
        }
        public static ApiResult<T> CreateError(Status status, string message)
        {
            return new ApiResult<T>(status, message);
        }
    }
}
