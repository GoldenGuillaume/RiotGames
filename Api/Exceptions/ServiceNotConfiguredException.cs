using System.Net.Http;

namespace RiotGames.Api.Exceptions
{
    /// <summary>
    /// Base address http client not configured 
    /// exception definition
    /// </summary>
    public class HttpServiceNotConfiguredException : System.ApplicationException
    {
        /// <summary>
        /// The HttpClient property who throwed the error
        /// </summary>
        public HttpClient Property;

        /// <summary>
        /// Build an custom exception
        /// </summary>
        /// <param name="client">Http client who throw the exception</param>
        public HttpServiceNotConfiguredException(HttpClient client) : base("The HttpClient BaseAddress property or required default headers has not been setted properly")
        {
            Property = client;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public HttpServiceNotConfiguredException()
        {
        }

        /// <summary>
        /// Default constructor with custom message
        /// </summary>
        /// <param name="message">Message content</param>
        public HttpServiceNotConfiguredException(string message) : base(message)
        {
        }

        /// <summary>
        /// Default constructor with custom message and exception
        /// </summary>
        /// <param name="message">Message content</param>
        /// <param name="innerException">Parent exception</param>
        public HttpServiceNotConfiguredException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
