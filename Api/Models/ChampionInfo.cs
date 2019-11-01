using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class ChampionInfo
    {
        public List<int> FreeChampionIdsForNewPlayers { get; set; }
        public List<int> FreeChampionIds { get; set; }
        public int MaxNewPlayerLevel { get; set; }

    }
}
