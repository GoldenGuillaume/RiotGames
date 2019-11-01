using RiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class SpectatorService : ApiService
    {
        public SpectatorService(HttpClient client) : base(client) { }

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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
		public async Task<FeaturedGames> GetFeaturedGames()
        {	
            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, RiotGames.Properties.Resources.SPECTATOR_ALL_GAMES));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<FeaturedGames>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}