using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RiotGames.Api.Http
{
    public class ThirdPartyCodeService : ApiService
    {
        public ThirdPartyCodeService(HttpClient client) : base(client) { }

        public async Task<string> GetThirdPartyCodeBySummonerId(string encryptedSummonerId)
        {
            var pathParams = new Dictionary<string, object>()
            {
                { nameof(encryptedSummonerId), encryptedSummonerId }
            };
			
            var response = await base.Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, ApiService.BuildUri(RiotGames.Properties.Resources.THIRD_PARTY_CODE_SUMMONER_ID, pathParams)));

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<string>();
            }
            else
            {
                throw new HttpRequestException(string.Format("Code: {0}, Location: {1}, Description: {2}", response.StatusCode, this.GetType().FullName, response.ReasonPhrase));
            }
        }
    }
}