using Microsoft.AspNetCore.WebUtilities;
using RiotGames.Api.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Tavis.UriTemplates;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ApiService
    {
        private protected readonly HttpClient Client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="location"></param>
        private protected ApiService(HttpClient client, LocationEnum location)
        {
            client.BaseAddress = new Uri(String.Format("https://{0}.api.riotgames.com/", location.ToString().ToLower()));
            client.DefaultRequestHeaders.Add("Origin", "https://developer.riotgames.com");
            client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("ASPNETCORE_API_TOKEN"));
            client.DefaultRequestHeaders.Add("Accept-Language", "fr,en-US;q=0.9,en;q=0.8");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");

            Client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <param name="pathParameters"></param>
        /// <param name="queryParameters"></param>
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

            if(queryParameters != null)
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
