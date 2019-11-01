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

        public ApiService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://euw1.api.riotgames.com/");
            client.DefaultRequestHeaders.Add("Origin", "https://developer.riotgames.com");
            client.DefaultRequestHeaders.Add("X-Riot-Token", Environment.GetEnvironmentVariable("ASPNETCORE_API_TOKEN"));
            client.DefaultRequestHeaders.Add("Accept-Language", "fr,en-US;q=0.9,en;q=0.8");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.103 Safari/537.36");

            Client = client;
        }

        private protected static Uri BuildUri(string template, Dictionary<string, object> pathParameters, object queryParameters = null)
        {
            Uri uri;
            if(pathParameters != null)
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
