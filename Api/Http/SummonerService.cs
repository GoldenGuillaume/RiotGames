using RiotGames.Api.Enums;
using RiotGames.Api.Exceptions;
using RiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public sealed class SummonerService : ApiService
    {
        /// <summary>
        /// Setup service
        /// </summary>
        public SummonerService() : base() { }

        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="location">League of legends server location</param>
        public SummonerService(LocationEnum location) : base(location) { }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        /// <param name="location">League of legends server location</param>
        public SummonerService(HttpClient client) : base(client) { }

        /// <summary>
        /// Retrieve a summoner by his account id
        /// </summary>
        /// <param name="encryptedAccountId">Encrypted account id</param>
        /// <returns>Summoner value</returns>
        public async Task<Summoner> GetSummonerByAccountId(string encryptedAccountId)
        {
            if (base.ServiceConfigured)
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
                    throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client);
        }

        /// <summary>
        /// Retrieve a summoner by his name
        /// </summary>
        /// <param name="summonerName">Pseudo of the summoner</param>
        /// <returns>Summoner value</returns>
        public async Task<Summoner> GetSummonerBySummonerName(string summonerName)
        {
            if (base.ServiceConfigured)
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
                    throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client);
        }

        /// <summary>
        /// Retrieve a summoner by his Puuid
        /// </summary>
        /// <param name="encryptedPUUID">Puuid encrypted</param>
        /// <returns>Summoner value</returns>
        public async Task<Summoner> GetSummonerByPuuid(string encryptedPUUID)
        {
            if (base.ServiceConfigured)
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
                    throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client);
        }

        /// <summary>
        /// Retrieve a summoner by his id
        /// </summary>
        /// <param name="encryptedSummonerId">Encrypted summoner id</param>
        /// <returns>Summoner value</returns>
        public async Task<Summoner> GetSummonerBySummonerId(string encryptedSummonerId)
        {
            if (base.ServiceConfigured)
            {
                var pathParams = new Dictionary<string, object>()
                {
                    { nameof(encryptedSummonerId), encryptedSummonerId }
                };


                var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.SUMMONER_ID, pathParams)));

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<Summoner>();
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