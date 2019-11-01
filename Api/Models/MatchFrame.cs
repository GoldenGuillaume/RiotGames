using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class MatchFrame
    {
        public long Timestamp { get; set; }
        public Dictionary<string, MatchParticipantFrame> ParticipantFrame { get; set; }
        public List<MatchEvent> Events { get; set; }
    }
}
