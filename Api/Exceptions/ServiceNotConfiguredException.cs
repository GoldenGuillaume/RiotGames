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
        /// <param name="message">Exception message</param>
        /// <param name="client">Http client who throw the exception</param>
        public HttpServiceNotConfiguredException(HttpClient client) : base("The HttpClient BaseAddress property or required default headers has not been setted properly") 
        {
            Property = client;
        }
    }
}
