using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class TournamentCode
    {
        public string Map { get; set; }
        public string Code { get; set; }
        public string Spectators { get; set; }
        public string Region { get; set; }
        public int ProviderId { get; set; }
        public int TeamSize { get; set; }
        public HashSet<string> Participants { get; set; }
        public string PickType { get; set; }
        public int TournamentId { get; set; }
        public string LobbyName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string MetaData { get; set; }


    }
}
