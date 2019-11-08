using Newtonsoft.Json;
using RiotGames.Api.Enums;
using RiotGames.Api.Http.Parameters;
using RiotGames.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    /// <summary>
    /// Base class of the Riot Games API services providers
    /// </summary>
    public class TournamentService : ApiService
    {
        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        /// <param name="location">League of legends server location</param>
        public TournamentService(HttpClient client, LocationEnum location) : base(client, location) { }

        /// <summary>
        /// Create a tournament code
        /// </summary>
        /// <param name="queryParams">Tournament request parameters</param>
        /// <param name="body">Tournament code parameters</param>
        /// <returns>List of tournament codes</returns>
        public async Task<List<string>> CreateTournamentCode(TournamentRequestParameters queryParams, TournamentCodeParameters body)
        {
            if (body == null) throw new Exception("The body must not be null");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiService.BuildUri(RiotGames.Properties.Resources.TOURNAMENT_POST_TOURNAMENT_CODE, queryParameters: queryParams))
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            var response = await base.Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<List<string>>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve tournament code 
        /// </summary>
        /// <param name="tournamentCode">Code of the tournament</param>
        /// <returns>Tournament code value</returns>
        public async Task<TournamentCode> GetTournamentCode(string tournamentCode)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(tournamentCode), tournamentCode }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.TOURNAMENT_GET_TOURNAMENT_CODE, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TournamentCode>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Update the tournament code
        /// </summary>
        /// <param name="tournamentCode">Code of the tournament</param>
        /// <param name="body">Tournament code parameters</param>
        public async void UpdateTournamentCode(string tournamentCode, TournamentCodeParameters body)
        {
            if (body == null) throw new Exception("The body must not be null");

            var pathParams = new Dictionary<string, object>()
            {
                { nameof(tournamentCode), tournamentCode }
            };

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, ApiService.BuildUri(RiotGames.Properties.Resources.TOURNAMENT_PUT_TOURNAMENT_CODE, pathParams))
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            var response = await base.Client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Retrieve a lobby event based on tournament code
        /// </summary>
        /// <param name="tournamentCode">code of the tournament</param>
        /// <returns>Lobby event object value</returns>
        public async Task<LobbyEventWrapper> GetLobbyEventByTournamentCode(string tournamentCode)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(tournamentCode), tournamentCode }
            };

            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.TOURNAMENT_GET_LOBBY_EVENTS_TOURNAMENT_CODE, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<LobbyEventWrapper>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Create a tournament provider
        /// </summary>
        /// <param name="body">Provider registration parameters</param>
        /// <returns>id of the provider created</returns>
        public async Task<int> CreateTournamentProvider(ProviderRegistrationParameters body)
        {
            if (body == null) throw new Exception("The body must not be null");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, RiotGames.Properties.Resources.TOURNAMENT_POST_TOURNAMENT_CODE)
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            var response = await base.Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<int>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }

        /// <summary>
        /// Create a tournament
        /// </summary>
        /// <param name="body">Tournament registration parameters</param>
        /// <returns>id of the tournament</returns>
        public async Task<int> CreateTournament(TournamentRegistrationParameters body)
        {
            if (body == null) throw new Exception("The body must not be null");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, RiotGames.Properties.Resources.TOURNAMENT_PUT_TOURNAMENT)
            {
                Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json")
            };

            var response = await base.Client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<int>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}
