using RiotGames.Api.Enums;
using RiotGames.Api.Http.Parameters;
using RiotGames.Api.Models;
using RiotGamesRiotGames.Api.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public class MatchService : ApiService
    {
        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="location">League of legends server location</param>
        public MatchService(LocationEnum location) : base(location) { }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        /// <param name="location">League of legends server location</param>
        public MatchService(HttpClient client, LocationEnum location) : base(client, location) { }

        /// <summary>
        /// Retrieve the match ids for specific tournament
        /// </summary>
        /// <param name="tournamentCode">Tournament code</param>
        /// <returns>List of ids</returns>
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve a match by his id
        /// </summary>
        /// <param name="matchId">Match id</param>
        /// <returns>Match value</returns>
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve a match by his id and his tournament code
        /// </summary>
        /// <param name="matchId">Match id</param>
        /// <param name="tournamentCode">Tournament code</param>
        /// <returns>Match value</returns>
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve all matchs by an user account id
        /// </summary>
        /// <param name="encryptedAccountId">Encrypted account id</param>
        /// <param name="queryParams">Match request parameters value</param>
        /// <returns>Match list</returns>
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve match timeline by his id
        /// </summary>
        /// <param name="matchId">Match id</param>
        /// <returns>Timeline of the specified match</returns>
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}