using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class FeaturedGames
    {
        public long ClientRefreshInterval { get; set; }
        public List<FeaturedGameInfo> GameList { get; set; }
    }
}
