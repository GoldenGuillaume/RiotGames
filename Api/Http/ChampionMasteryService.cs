using RiotGames.Api.Enums;
using RiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class ChampionMasteryService : ApiService
    {
        public ChampionMasteryService(HttpClient client, LocationEnum location) : base(client, location) { }

        public async Task<List<ChampionMastery>> GetChampionMasteriesByEncryptedSummonerId(string encryptedSummonerId)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(encryptedSummonerId), encryptedSummonerId }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.CHAMPION_MASTERY_ALL_SUMMONER_ID, pathParams)));
            
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<ChampionMastery>>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<ChampionMastery> GetChampionMasteryByChampionIdAndEncryptedSummonerId(long championId, string encryptedSummonerId)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(encryptedSummonerId), encryptedSummonerId },
                { nameof(championId), championId }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.CHAMPION_MASTERY_SUMMONER_CHAMPION_ID, pathParams))); 

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ChampionMastery>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<int> GetTotalMasteriesScoreByEncryptedSummonerId(string encryptedSummonerId)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(encryptedSummonerId), encryptedSummonerId }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.CHAMPION_MASTERY_SCORE_SUMMONER_ID, pathParams))); 

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<int>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}
