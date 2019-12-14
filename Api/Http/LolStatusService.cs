using RiotGames.Api.Enums;
using RiotGames.Api.Exceptions;
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
        public LolStatusService() : base() { }

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
        public LolStatusService(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieve current lol status
        /// </summary>
        /// <returns>Lol status details</returns>
        public async Task<ShardStatus> GetLolStatus()
        {
            if (base.ServiceConfigured)
            {
                var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, RiotGames.Properties.Resources.LOL_STATUS_SHARD));

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ShardStatus>();
                }
                else
                {
                    throw new HttpRequestException($"Code: {(int)response.StatusCode}-{response.StatusCode}, Location: {GetType().FullName}, Description: {response.ReasonPhrase}");
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client);
        }
    }
}