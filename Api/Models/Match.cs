using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class Match
    {
        public int SeasonId { get; set; }
        public int QueueId { get; set; }
        public long GameId { get; set; }
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }
        public string GameVersion { get; set; }
        public string PlatformId { get; set; }
        public string GameMode { get; set; }
        public int MapId { get; set; }
        public string GameType { get; set; }
        public List<TeamStats> Teams { get; set; }
        public List<Participant> Participants { get; set; }
        public long GameDuration { get; set; }
        public long GameCreation { get; set; }
    }
}
