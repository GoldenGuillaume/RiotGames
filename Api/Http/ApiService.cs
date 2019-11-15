using Microsoft.AspNetCore.WebUtilities;
using RiotGames.Api.Enums;
using RiotGames.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using Tavis.UriTemplates;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public abstract class ApiService
    {
        private protected readonly static string BaseAdressTemplate = "https://{0}.api.riotgames.com/";
        private static readonly Regex ValidBaseAdressRegex = new Regex("^https://[euw1 | eun1 | na1].api.riotgames.com/$", RegexOptions.Compiled | RegexOptions.Singleline);

        private protected readonly HttpClient Client;

        private protected bool ServiceConfigured 
        { 
            get 
            {
                return Client.BaseAddress != null && ValidBaseAdressRegex.IsMatch(Client.BaseAddress.AbsoluteUri) &&
                    Client.DefaultRequestHeaders.Contains("Origin") &&
                    Client.DefaultRequestHeaders.GetValues("Origin").SingleOrDefault().Contains("https://developer.riotgames.com") &&
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

            Client.DefaultRequestHeaders.Add("Origin", "https://developer.riotgames.com");
            Client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("RIOTGAMES_API_TOKEN") ?? throw new ArgumentNullException("The Api key wasn't setted properly in the environment variable", innerException: null));
            Client.DefaultRequestHeaders.Add("Accept-Language", "fr,en-US;q=0.9,en;q=0.8");
            Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");
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

            Client.DefaultRequestHeaders.Add("Origin", "https://developer.riotgames.com");
            Client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("RIOTGAMES_API_TOKEN") ?? throw new ArgumentNullException("The Api key wasn't setted properly in the environment variable", innerException: null));
            Client.DefaultRequestHeaders.Add("Accept-Language", "fr,en-US;q=0.9,en;q=0.8");
            Client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");
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

            client.DefaultRequestHeaders.Add("Origin", "https://developer.riotgames.com");
            client.DefaultRequestHeaders.Add("X-Riot-Token", apiKey ?? Environment.GetEnvironmentVariable("RIOTGAMES_API_TOKEN") ?? throw new ArgumentNullException("The Api key wasn't setted properly neither in HttpClient parameter or in the environment variable", innerException: null));
            client.DefaultRequestHeaders.Add("Accept-Language", "fr,en-US;q=0.9,en;q=0.8");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");

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
        ///     BuildUri("/template/uri", new Dictionary<string, object>(), new object());
        ///     // Use named arguments to reverse params order
        ///     BuildUri("/template/uri", queryParameters: new object(), pathParameters: new Dictionary<string, object>());
        ///     // with only one optionnal param 
        ///     BuildUri("/template/uri"), new Dictionary<string, object>());
        ///     // with only one optionnal param reversed order
        ///     BuildUri("/template/uri"), queryParameters: new object());
        /// </code>
        /// </example>
        /// <returns>Uri formatted</returns>
        private protected static Uri BuildUri(string template, Dictionary<string, object> pathParameters = null, object queryParameters = null)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template), "The parameter cannot be null");

            Uri uri;
            if (pathParameters != null)
            {
                UriTemplate templateBuilder = new UriTemplate(template);
                templateBuilder.AddParameters(pathParameters);
                uri = new Uri(templateBuilder.Resolve());
            }
            else
            {
                uri = new Uri(template);
            }

            if (queryParameters != null)
            {
                var builder = new UriBuilder(uri);
                var query = QueryHelpers.ParseQuery(uri.Query);

                foreach (FieldInfo field in queryParameters.GetType().GetFields())
                {
                    if (field.GetValue(queryParameters) != null)
                    {
                        query[field.Name] = field.GetValue(queryParameters).ToString();
                    }
                }
                builder.Query = query.ToString();
                uri = builder.Uri;
            }
            return uri;
        }
    }
}
