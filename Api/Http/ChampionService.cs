using RiotGames.Api.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class ChampionService : ApiService
    {
        public ChampionService(HttpClient client) : base(client) { }

        public async Task<ChampionInfo> GetChampionRotations()
        {
            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, RiotGames.Properties.Resources.CHAMPION_ROTATION));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ChampionInfo>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}
