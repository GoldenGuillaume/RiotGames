using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using Tavis.UriTemplates;

namespace RiotGames.Api.Http
{
    public abstract class ApiService
    {
        private protected readonly HttpClient Client;

        private protected ApiService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://euw1.api.riotgames.com/");
            client.DefaultRequestHeaders.Add("Origin", "https://developer.riotgames.com");
            client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("ASPNETCORE_API_TOKEN"));
            client.DefaultRequestHeaders.Add("Accept-Language", "fr,en-US;q=0.9,en;q=0.8");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");

            Client = client;
        }

        private protected static Uri BuildUri(string template, object queryParameters)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template), "The parameter cannot be null");
            if (queryParameters == null)
                throw new ArgumentNullException(nameof(queryParameters), "The parameter cannot be null");

            Uri uri = new Uri(template);
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
            return builder.Uri;
        }

        private protected static Uri BuildUri(string template, Dictionary<string, object> pathParameters, object queryParameters = null)
        {
            if (template == null)
                throw new ArgumentNullException(nameof(template), "The parameter cannot be null");
            if (pathParameters == null)
                throw new ArgumentNullException(nameof(pathParameters), "The parameter cannot be null");


            UriTemplate templateBuilder = new UriTemplate(template);
            templateBuilder.AddParameters(pathParameters);   
            Uri uri = new Uri(templateBuilder.Resolve());

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
