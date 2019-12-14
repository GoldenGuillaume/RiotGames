using Newtonsoft.Json;
using RiotGames.Api.Enums;
using System.Collections.Generic;

namespace RiotGames.Api.Http.Parameters
{
    /// <summary>
    /// TournamentCode body parameters model
    /// </summary>
    public class TournamentCodeParameters
    {
        /// <summary>
        /// Construct the model with default value of 0
        /// for TeamSize
        /// </summary>
        public TournamentCodeParameters()
        {
            TeamSize = 0;
        }

        /// <summary>
        /// SpectatorType parameter
        /// </summary>
        [JsonProperty("spectatorType")]
        public string SpectatorType { get; private set; }

        /// <summary>
        /// PickType parameter
        /// </summary>
        [JsonProperty("pickType")]
        public string PickType { get; private set; }

        /// <summary>
        /// MapType parameter
        /// </summary>
        [JsonProperty("mapType")]
        public string MapType { get; private set; }

        private int _teamSize;
        /// <summary>
        /// TeamSize parameter where the value 
        /// need to be between 1 and 5
        /// </summary>
        [JsonProperty("teamSize")]
        public int TeamSize
        {
            get
            {
                return _teamSize;
            }
            set
            {
                if (value >= 1 && value <= 5)
                    _teamSize = value;
            }
        }

        /// <summary>
        /// Metadata parameter
        /// </summary>
        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        /// <summary>
        /// AllowedSummonerIds parameter who contain 
        /// a list of Summoners id
        /// </summary>
        [JsonProperty("AllowedSummonerIds")]
        public HashSet<string> AllowedSummonerIds { get; set; }

        /// <summary>
        /// Set the spectator type
        /// </summary>
        /// <param name="value">Spectator type enum value to set</param>
        public void SetSpectatorType(SpectatorTypeEnum value)
        {
            SpectatorType = value.ToString();
        }

        /// <summary>
        /// Set the pick type
        /// </summary>
        /// <param name="value">Pick type enum value to set</param>
        public void SetPickType(PickTypeEnum value)
        {
            PickType = value.ToString();
        }

        /// <summary>
        /// Set the map type
        /// </summary>
        /// <param name="value">Map type enum value to set</param>
        public void SetMapType(MapTypeEnum value)
        {
            MapType = value.ToString();
        }
    }
}
