namespace RiotGames.Api.Models
{
    public class MatchParticipantFrame
    {
        public int TotalGold { get; set; }
        public int TeamScore { get; set; }
        public int ParticipantId { get; set; }
        public int Level { get; set; }
        public int CurrentGold { get; set; }
        public int MinionsKilled { get; set; }
        public int DominionScore { get; set; }
        public MatchPosition Position { get; set; }
        public int Xp { get; set; }
        public int JungleMinionsKilled { get; set; }
    }
}
