using RiotGames.Api.Enums;
using RiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public class SpectatorService : ApiService
    {
        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        /// <param name="location">League of legends server location</param>
        public SpectatorService(HttpClient client, LocationEnum location) : base(client, location) { }

        /// <summary>
        /// Retrieve current game info by the summoner id
        /// </summary>
        /// <param name="encryptedSummonerId">Encrypted summoner id</param>
        /// <returns>Current game info values</returns>
        public async Task<CurrentGameInfo> GetCurrentGameInfoBySummonerId(string encryptedSummonerId)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(encryptedSummonerId), encryptedSummonerId }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.SPECTATOR_CURRENT_GAME_SUMMONER_ID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<CurrentGameInfo>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }
        /// <summary>
        /// Retrieve the featured games
        /// </summary>
        /// <returns>Featured games value</returns>
		public async Task<FeaturedGames> GetFeaturedGames()
        {
            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, RiotGames.Properties.Resources.SPECTATOR_ALL_GAMES));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<FeaturedGames>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}