using RiotGames.Api.Enums;
using RiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class SummonerService : ApiService
    {
        public SummonerService(HttpClient client, LocationEnum location) : base(client, location) { }

        public async Task<Summoner> GetSummonerByAccountId(string encryptedAccountId)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(encryptedAccountId), encryptedAccountId }
            };


            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.SUMMONER_ACCOUNT_ID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Summoner>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<Summoner> GetSummonerBySummonerName(string summonerName)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(summonerName), summonerName }
            };


            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.SUMMONER_NAME, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Summoner>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<Summoner> GetSummonerByPuuid(string encryptedPUUID)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(encryptedPUUID), encryptedPUUID }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.SUMMONER_PUUID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Summoner>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<Summoner> GetSummonerBySummonerId(string encryptedSummonerId)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(encryptedSummonerId), encryptedSummonerId }
            };


            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.SUMMONER_SUMMONER_ID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Summoner>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}