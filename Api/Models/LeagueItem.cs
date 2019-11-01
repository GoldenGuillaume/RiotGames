namespace RiotGames.Api.Models
{
    public class LeagueItem
    {
        public string SummonerName { get; set; }
        public bool HotStreak { get; set; }
        public MiniSeries MiniSeries { get; set; }
        public int Wins { get; set; }
        public bool Veteran { get; set; }
        public int Losses { get; set; }
        public bool FreshBlood { get; set; }
        public bool Inactive { get; set; }
        public string Rank { get; set; }
        public string SummonerId { get; set; }
        public int LeaguePoints { get; set; }
    }
}
