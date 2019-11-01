using RiotGames.Api.Enums;
using RiotGames.Api.Http.Query;
using RiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class LeagueService : ApiService
    {
        public LeagueService(HttpClient client) : base(client) { }

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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }            
        }

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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}
