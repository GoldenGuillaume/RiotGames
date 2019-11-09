using RiotGames.Api.Enums;
using RiotGames.Api.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public sealed class LolStatusService : ApiService
    {
        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="location">League of legends server location</param>
        public LolStatusService(LocationEnum location) : base(location) { }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        /// <param name="location">League of legends server location</param>
        public LolStatusService(HttpClient client, LocationEnum location) : base(client, location) { }

        /// <summary>
        /// Retrieve current lol status
        /// </summary>
        /// <returns>Lol status details</returns>
        public async Task<ShardStatus> GetLolStatus()
        {
            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, RiotGames.Properties.Resources.LOL_STATUS_SHARD));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ShardStatus>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}