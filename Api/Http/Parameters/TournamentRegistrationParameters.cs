using Newtonsoft.Json;

namespace RiotGames.Api.Http.Parameters
{
    /// <summary>
    /// TournamentRegistration body parameters model
    /// </summary>
    public class TournamentRegistrationParameters
    {
        /// <summary>
        /// Construct the model with default value of 0
        /// for ProviderId
        /// </summary>
        public TournamentRegistrationParameters()
        {
            ProviderId = 0;
        }

        /// <summary>
        /// ProviderId parameter
        /// </summary>
        [JsonProperty("providerId")]
        public int ProviderId { get; set; }

        /// <summary>
        /// Name parameter
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
