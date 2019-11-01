using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class CurrentGameParticipant
    {
        public long ProfileIconId { get; set; }
        public long ChampionId { get; set; }
        public string SummonerName { get; set; }
        public List<GameCustomizationObject> GameCustomizationObjects { get; set; }
        public bool Bot { get; set; }
        public Perks Perks { get; set; }
        public long Spell2Id { get; set; }
        public long TeamId { get; set; }
        public long Spell1Id { get; set; }
        public string SummonerId { get; set; }
    }
}
