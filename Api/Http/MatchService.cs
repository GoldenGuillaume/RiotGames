using RiotGames.Api.Enums;
using RiotGames.Api.Http.Query;
using RiotGames.Api.Models;
using RiotGamesRiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class MatchService : ApiService
    {
        public MatchService(HttpClient client, LocationEnum location) : base(client, location) { }

        public async Task<List<long>> GetMatchIdsByTournamentCode(string tournamentCode)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(tournamentCode), tournamentCode }
            };


            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.MATCH_ID_TOURNAMENT_CODE, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<long>>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<Match> GetMatchById(long matchId)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(matchId), matchId }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.MATCH_MATCH_ID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Match>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<Match> GetMatchByTournamentCodeAndId(long matchId, string tournamentCode)
        {
            var pathParams = new Dictionary<string, object>
            {
                { nameof(matchId), matchId },
                { nameof(tournamentCode), tournamentCode }
            };


            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.MATCH_MATCH_ID_TOURNAMENT_CODE, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Match>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<MatchList> GetMatchListByEncryptedAccountId(string encryptedAccountId, MatchRequestParameters queryParams = null)
        {
            HttpRequestMessage requestMessage;
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(encryptedAccountId), encryptedAccountId }
            };

            if (queryParams == null)
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.MATCH_ALL_ACCOUNT_ID, pathParams));
            }
            else
            {
                requestMessage = new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.MATCH_ALL_ACCOUNT_ID, pathParams, queryParams));
            }

            var response = await base.Client.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<MatchList>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<MatchTimeline> GetMatchTimelineByMatchId(long matchId)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(matchId), matchId } 
            };


            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.MATCH_TIMELINE_MATCH_ID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<MatchTimeline>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}