using Newtonsoft.Json;
using RiotGames.Api.Enums;
using System;

namespace RiotGames.Api.Http.Parameters
{
    /// <summary>
    /// ProviderRegistration body parameters model
    /// </summary>
    public class ProviderRegistrationParameters
    {
        /// <summary>
        /// Region parameter
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; private set; }

        private string _url;

        /// <summary>
        /// Url parameter where the port need to be 
        /// 80 for Http and 443 for Https
        /// </summary>
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

        /// <summary>
        /// Set the region 
        /// </summary>
        /// <param name="value">Region enum value to set</param>
        public void SetRegion(RegionEnum value)
        {
            Region = value.ToString();
        }
    }
}
