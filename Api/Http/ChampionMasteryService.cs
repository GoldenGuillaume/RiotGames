using RiotGames.Api.Enums;
using RiotGames.Api.Exceptions;
using RiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Champion mastery service provider
    /// </summary>
    public sealed class ChampionMasteryService : ApiService
    {
        /// <summary>
        /// Setup service
        /// </summary>
        public ChampionMasteryService() : base() { }

        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="location">League of legends server location</param>
        public ChampionMasteryService(LocationEnum location) : base(location) { }

        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="client">Http client to provide</param>
        public ChampionMasteryService(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieve the masteries related to a specific summoner
        /// </summary>
        /// <param name="encryptedSummonerId">Summoner id encrypted</param>
        /// <returns>All masteries on champions</returns>
        public async Task<List<ChampionMastery>> GetChampionMasteriesByEncryptedSummonerId(string encryptedSummonerId)
        {
            if (base.LocationConfigured) 
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
                    throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client); 
        }

        /// <summary>
        /// Retrieve the masteries related to a specific summoner 
        /// and on a specific champion
        /// </summary>
        /// <param name="championId">Champion id</param>
        /// <param name="encryptedSummonerId">Summoner id encrypted</param>
        /// <returns>Mastery on champion</returns>
        public async Task<ChampionMastery> GetChampionMasteryByChampionIdAndEncryptedSummonerId(long championId, string encryptedSummonerId)
        {
            if (base.LocationConfigured)
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
                    throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client);
        }

        /// <summary>
        /// Retrieve the total masteries score for the related summoner
        /// </summary>
        /// <param name="encryptedSummonerId">Summoner id encrypted</param>
        /// <returns>Total number of masteries</returns>
        public async Task<int> GetTotalMasteriesScoreByEncryptedSummonerId(string encryptedSummonerId)
        {
            if (base.LocationConfigured)
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
                    throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client);
        }
    }
}
