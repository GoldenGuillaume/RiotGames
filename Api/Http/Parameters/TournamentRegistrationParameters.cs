using Newtonsoft.Json;

namespace RiotGames.Api.Http.Parameters
{
    public class TournamentRegistrationParameters
    {
        public TournamentRegistrationParameters()
        {
            ProviderId = 0;
        }

        [JsonProperty("providerId")]
        public int ProviderId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
