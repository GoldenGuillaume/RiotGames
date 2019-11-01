using RiotGames.Api.Models;
using System.Collections.Generic;

namespace RiotGamesRiotGames.Api.Models
{
    public class MatchList
    {
        public List<MatchReference> Matches { get; set; }
        public int TotalGames { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
    }
}
