using RiotGames.Api.Enums;
using RiotGames.Api.Http.Parameters;
using RiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public sealed class LeagueService : ApiService
    {
        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="location">League of legends server location</param>
        public LeagueService(LocationEnum location) : base(location) { }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        /// <param name="location">League of legends server location</param>
        public LeagueService(HttpClient client, LocationEnum location) : base(client, location) { }

        /// <summary>
        /// Retrieve the challenger league based on the queue
        /// </summary>
        /// <param name="queue">Queue type</param>
        /// <returns>Content of the league</returns>
        public async Task<LeagueList> GetChallengerLeagueByQueue(QueueEnum queue)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(queue), queue.ToString() }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.LEAGUE_CHALLENGER_QUEUE, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<LeagueList>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve the grand master league based on queue
        /// </summary>
        /// <param name="queue">Queue type</param>
        /// <returns>Content of the league</returns>
        public async Task<LeagueList> GetGrandMasterLeagueByQueue(QueueEnum queue)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(queue), queue.ToString() }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.LEAGUE_GRANDMASTER_QUEUE, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<LeagueList>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve the master league based on queue
        /// </summary>
        /// <param name="queue">Queue type</param>
        /// <returns>Content of the league</returns>
        public async Task<LeagueList> GetMasterLeagueByQueue(QueueEnum queue)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(queue), queue.ToString() }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.LEAGUE_MASTER_QUEUE, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<LeagueList>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieves all the league entries for specific summoner
        /// </summary>
        /// <param name="encryptedSummonerId">Summoner id encrypted</param>
        /// <returns>All the league entries</returns>
        public async Task<HashSet<LeagueEntry>> GetAllLeagueEntriesBySummonerId(string encryptedSummonerId)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(encryptedSummonerId), encryptedSummonerId }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.LEAGUE_SUMMONER_ID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<HashSet<LeagueEntry>>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieves all the league entries
        /// </summary>
        /// <param name="queue">Queue type</param>
        /// <param name="tier">Tier value</param>
        /// <param name="division">Division value</param>
        /// <param name="queryParams">League request parameters value</param>
        /// <returns></returns>
        public async Task<HashSet<LeagueEntry>> GetAllLeagueEntries(QueueEnum queue, TierEnum tier, DivisionEnum division, LeagueRequestParameters queryParams = null)
        {
            HttpRequestMessage requestMessage;
            var pathParams = new Dictionary<string, object>
            {
                { nameof(queue), queue.ToString() },
                { nameof(tier), tier.ToString() },
                { nameof(division), division.ToString() }
            };

            if (queryParams == null)
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.LEAGUE_QUEUE_TIER_DIVISION, pathParams));
            }
            else
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.LEAGUE_QUEUE_TIER_DIVISION, pathParams, queryParams));
            }

            var response = await base.Client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<HashSet<LeagueEntry>>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve a specific league 
        /// </summary>
        /// <param name="leagueId">League id</param>
        /// <returns>League content</returns>
        public async Task<LeagueList> GetLeagueById(string leagueId)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(leagueId), leagueId }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.LEAGUE_ID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<LeagueList>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}
