using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class LeagueList
    {
        public string LeagueId { get; set; }
        public string Tier { get; set; }
        public List<LeagueItem> Entries { get; set; }
        public string Queue { get; set; }
        public string Name { get; set; }
    }
}
