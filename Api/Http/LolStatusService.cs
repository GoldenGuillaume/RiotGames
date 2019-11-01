using RiotGames.Api.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class LolStatusService : ApiService
    {
        public LolStatusService(HttpClient client) : base(client) { }

        public async Task<ShardStatus> GetLolStatus()
        {
            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, RiotGames.Properties.Resources.LOL_STATUS_SHARD));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<ShardStatus>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}