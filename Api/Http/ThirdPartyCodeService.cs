using RiotGames.Api.Enums;
using RiotGames.Api.Exceptions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public sealed class ThirdPartyCodeService : ApiService
    {
        /// <summary>
        /// Setup service
        /// </summary>
        public ThirdPartyCodeService() : base() { }

        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="location">League of legends server location</param>
        public ThirdPartyCodeService(LocationEnum location) : base(location) { }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        /// <param name="location">League of legends server location</param>
        public ThirdPartyCodeService(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieve third party code by summoner id
        /// </summary>
        /// <param name="encryptedSummonerId">Encrypted summoner id</param>
        /// <returns>Third party code</returns>
        public async Task<string> GetThirdPartyCodeBySummonerId(string encryptedSummonerId)
        {
            if (base.ServiceConfigured)
            {
                var pathParams = new Dictionary<string, object>()
                {
                    { nameof(encryptedSummonerId), encryptedSummonerId }
                };

                var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.THIRD_PARTY_CODE_SUMMONER_ID, pathParams)));

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<string>();
                }
                else
                {
                    throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client);
        }
    }
}