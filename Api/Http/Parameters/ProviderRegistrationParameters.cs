using Newtonsoft.Json;
using RiotGames.Api.Enums;
using System;

namespace RiotGames.Api.Http.Parameters
{
    public class ProviderRegistrationParameters
    {
        [JsonProperty("region")]
        public string Region { get; private set; }

        private string _url;

        [JsonProperty("url")]
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                if (Uri.TryCreate(value, UriKind.Absolute, out Uri resultUri) &&
                    (resultUri.Scheme == Uri.UriSchemeHttp && resultUri.Port == 80) ||
                    (resultUri.Scheme == Uri.UriSchemeHttps && resultUri.Port == 443))
                    _url = value;
            }
        }

        public void SetRegion(RegionEnum value)
        {
            Region = value.ToString();
        }
    }
}
