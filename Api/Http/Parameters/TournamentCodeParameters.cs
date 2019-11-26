using Newtonsoft.Json;
using RiotGames.Api.Enums;
using System.Collections.Generic;

namespace RiotGames.Api.Http.Parameters
{
    public class TournamentCodeParameters
    {
        public TournamentCodeParameters()
        {
            TeamSize = 0;
        }

        [JsonProperty("spectatorType")]
        public string SpectatorType { get; private set; }

        [JsonProperty("pickType")]
        public string PickType { get; private set; }

        [JsonProperty("mapType")]
        public string MapType { get; private set; }

        private int _teamSize;
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

        [JsonProperty("metadata")]
        public string Metadata { get; set; }

        [JsonProperty("AllowedSummonerIds")]
        public HashSet<string> AllowedSummonerIds { get; set; }


        public void SetSpectatorType(SpectatorTypeEnum value)
        {
            SpectatorType = value.ToString();
        }

        public void SetPickType(PickTypeEnum value)
        {
            PickType = value.ToString();
        }

        public void SetMapType(MapTypeEnum value)
        {
            MapType = value.ToString();
        }
    }
}
