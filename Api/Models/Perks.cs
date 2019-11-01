using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class Perks
    {
        public long PerkStyle { get; set; }
        public List<long> PerkIds { get; set; }
        public long PerkSubStyle { get; set; }
    }
}
