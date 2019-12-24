using RiotGames.Api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using Tavis.UriTemplates;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public abstract class ApiService
    {
        /// <summary>
        /// Base adress template for the Riot Games API
        /// </summary>
        private const string BaseAdressTemplate = "https://{0}.api.riotgames.com/";
        /// <summary>
        /// Regex to verify the valid state of a Base adress
        /// </summary>
        private static readonly Regex ValidBaseAdressRegex = new Regex(@"^https://(euw1|eun1|na1).api.riotgames.com/$", RegexOptions.Compiled | RegexOptions.Singleline);
        /// <summary>
        /// HttpClient instance
        /// </summary>
        private protected readonly HttpClient Client;

        /// <summary>
        /// Determine if The base adress is setted and valid
        /// and if the HttpClient contains the right headers
        /// </summary>
        private protected bool ServiceConfigured
        {
            get
            {
                return Client.BaseAddress != null && ValidBaseAdressRegex.IsMatch(Client.BaseAddress.AbsoluteUri) &&
                    Client.DefaultRequestHeaders.Contains("X-Riot-Token") &&
                    Client.DefaultRequestHeaders.GetValues("X-Riot-Token").Count() == 1;
            }
        }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location        
        /// </summary>
        private protected ApiService()
        {
            Client = new HttpClient();

            Client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("RIOTGAMES_API_TOKEN"));
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="location">League of legends server location</param>
        private protected ApiService(LocationEnum location)
        {
            Client = new HttpClient()
            {
                BaseAddress = new Uri(string.Format(BaseAdressTemplate, location.ToString().ToLower()))
            };

            Client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("RIOTGAMES_API_TOKEN"));
            Client.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        private protected ApiService(HttpClient client)
        {
            string apiKey = null;
            if (client.DefaultRequestHeaders.TryGetValues("X-Riot-Token", out var value))
            {
                apiKey = value.First();
            }
            client.DefaultRequestHeaders.Clear();
            client.BaseAddress = (client.BaseAddress != null && ValidBaseAdressRegex.IsMatch(client.BaseAddress.AbsoluteUri)) ? client.BaseAddress : null;

            client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey ?? Environment.GetEnvironmentVariable("RIOTGAMES_API_TOKEN"));
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            Client = client;
        }


        /// <summary>
        /// Configure on each server the Api calls
        /// will be made
        /// </summary>
        /// <param name="location">Server location to set</param>
        public void ConfigureLocation(LocationEnum location)
            => Client.BaseAddress = new Uri(String.Format(BaseAdressTemplate, location.ToString().ToLower()));

        /// <summary>
        /// Utility method to build Uri by templating 
        /// </summary>
        /// <param name="template">The uri string template</param>
        /// <param name="pathParameters">A dictionary containing respectively as key the string value of the parameter and as value the value to insert in the uri</param>
        /// <param name="queryParameters">An object containing the queries parameters to provide</param>
        /// <example>
        /// How to use it:
        /// <code>
        ///     BuildUri("/template/uri", new Dictionary&lt;string, object&gt;(), new object());
        ///     // Use named arguments to reverse params order
        ///     BuildUri("/template/uri", queryParameters: new object(), pathParameters: new Dictionary&lt;string, object&gt;());
        ///     // with only one optionnal param 
        ///     BuildUri("/template/uri"), new Dictionary&lt;string, object&gt;());
        ///     // with only one optionnal param reversed order
        ///     BuildUri("/template/uri"), queryParameters: new object());
        /// </code>
        /// </example>
        /// <returns>Uri formatted</returns>
        private protected static Uri BuildUri(string template, Dictionary<string, object> pathParameters = null, object queryParameters = null)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template), "The parameter cannot be null");

            string uri;
            if (pathParameters != null)
            {
                UriTemplate templateBuilder = new UriTemplate(template);
                templateBuilder.AddParameters(pathParameters);
                uri = templateBuilder.Resolve();
            }
            else
            {
                uri = template;
            }

            if (queryParameters != null)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);

                foreach (PropertyInfo property in queryParameters.GetType().GetProperties())
                {
                    if (property.GetValue(queryParameters) != null)
                    {
                        query[property.Name] = property.GetValue(queryParameters).ToString();
                    }
                }
                Console.WriteLine(query.ToString());
                uri = $"{uri}?{query.ToString()}";
            }

            if (Uri.IsWellFormedUriString(uri, UriKind.Relative))
                return new Uri(uri, UriKind.Relative);
            else
                throw new UriFormatException("The template parameter is not a well formed Uri string");
        }
    }
}
