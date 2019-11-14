using System.Net.Http;

namespace RiotGames.Api.Exceptions
{
    /// <summary>
    /// Base address http client not configured 
    /// exception definition
    /// </summary>
    public class InvalidHttpClientInstantiationException : System.ApplicationException
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
        public InvalidHttpClientInstantiationException(HttpClient client) : base("The HttpClient header X-Riot-Token containing the API key is missing or his value isn't set")
        {
            Property = client;
        }
    }
}
