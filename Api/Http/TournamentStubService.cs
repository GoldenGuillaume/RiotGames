using Newtonsoft.Json;
using RiotGames.Api.Enums;
using RiotGames.Api.Http.Query;
using RiotGames.Api.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class TournamentStubService : ApiService
    {
        public TournamentStubService(HttpClient client, LocationEnum location) : base(client, location) { }

        public async Task<List<string>> CreateTournamentCode(TournamentRequestParameters queryParams, Dictionary<string, string> body)
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<LobbyEventWrapper> GetLobbyEventWrapperByTournamentCode(string tournamentCode)
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<int> CreateTournamentProvider(Dictionary<string, string> body)
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }

        public async Task<int> CreateTournament(Dictionary<string, string> body)
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
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}