using Newtonsoft.Json;
using RiotGames.Api.Enums;
using RiotGames.Api.Exceptions;
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
    public sealed class TournamentStubService : ApiService
    {
        /// <summary>
        /// Setup service
        /// </summary>
        public TournamentStubService() : base() { }

        /// <summary>
        /// Setup service
        /// </summary>
        /// <param name="location">League of legends server location</param>
        public TournamentStubService(LocationEnum location) : base(location) { }

        /// <summary>
        /// Construct the Http client and set it depending
        /// on the League of legends server location
        /// </summary>
        /// <param name="client">Http client to provide</param>
        /// <param name="location">League of legends server location</param>
        public TournamentStubService(HttpClient client) : base(client) { }

        /// <summary>
        /// Create a tournament code
        /// </summary>
        /// <param name="queryParams">Tournament request parameters</param>
        /// <param name="body">Tournament code parameters</param>
        /// <returns>List of tournament codes</returns>
        public async Task<List<string>> CreateTournamentCode(TournamentRequestParameters queryParams, TournamentCodeParameters body)
        {
            if (base.LocationConfigured)
            {
                if (body == null) throw new Exception("The body must not be null");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ApiService.BuildUri(RiotGames.Properties.Resources.TOURNAMENT_STUB_CODE, queryParameters: queryParams))
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
            throw new HttpServiceNotConfiguredException(base.Client);
        }

        /// <summary>
        /// Retrieve a lobby event based on tournament code
        /// </summary>
        /// <param name="tournamentCode">code of the tournament</param>
        /// <returns>Lobby event object value</returns>
        public async Task<LobbyEventWrapper> GetLobbyEventWrapperByTournamentCode(string tournamentCode)
        {
            if (base.LocationConfigured)
            {
                var pathParams = new Dictionary<string, object>()
                {
                    { nameof(tournamentCode), tournamentCode }
                };

                var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.TOURNAMENT_STUB_TOURNAMENT_CODE, pathParams)));

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<LobbyEventWrapper>();
                }
                else
                {
                    throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, GetType().FullName, response.ReasonPhrase));
                }
            }
            throw new HttpServiceNotConfiguredException(base.Client);
        }

        /// <summary>
        /// Create a tournament provider
        /// </summary>
        /// <param name="body">Provider registration parameters</param>
        /// <returns>id of the provider created</returns>
        public async Task<int> CreateTournamentProvider(ProviderRegistrationParameters body)
        {
            if (base.LocationConfigured)
            {
                if (body == null) throw new Exception("The body must not be null");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, RiotGames.Properties.Resources.TOURNAMENT_STUB_PROVIDER)
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
            throw new HttpServiceNotConfiguredException(base.Client);
        }

        /// <summary>
        /// Create a tournament
        /// </summary>
        /// <param name="body">Tournament registration parameters</param>
        /// <returns>id of the tournament</returns>
        public async Task<int> CreateTournament(TournamentRegistrationParameters body)
        {
            if (base.LocationConfigured)
            {
                if (body == null) throw new Exception("The body must not be null");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, RiotGames.Properties.Resources.TOURNAMENT_STUB_TOURNAMENT)
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
            throw new HttpServiceNotConfiguredException(base.Client);
        }
    }
}