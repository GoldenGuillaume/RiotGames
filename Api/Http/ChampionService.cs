using RiotGames.Api.Enums;
using RiotGames.Api.Exceptions;
using RiotGames.Api.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Champion service provider
    /// </summary>
    public sealed class ChampionService : ApiService
    {
        /// <summary>
        /// Setup service
        /// </summary>
        public ChampionService() : base() { }

        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="location">League of legends server location</param>
        public ChampionService(LocationEnum location) : base(location) { }

        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="client">Http client to provide</param>
        public ChampionService(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieve the actual champion rotation
        /// </summary>
        /// <returns>Champion informations</returns>
        public async Task<ChampionInfo> GetChampionRotations()
        {
            if (base.LocationConfigured)
            {
                var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, RiotGames.Properties.Resources.CHAMPION_ROTATION));

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<ChampionInfo>();
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
