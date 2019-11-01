using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class Participant
    {
        public ParticipantStats Stats { get; set; }
        public int ParticipantId { get; set; }
        public List<Rune> Runes { get; set; }
        public ParticipantTimeline Timeline { get; set; }
        public int TeamId { get; set; }
        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }
        public int ChampionId { get; set; }
        public List<Mastery> Masteries { get; set; }
        public string HighestAchievedSeasonTier { get; set; }


    }
}
