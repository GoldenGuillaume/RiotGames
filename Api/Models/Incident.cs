using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class Incident
    {
        public bool Active { get; set; }
        public string Created_at { get; set; }
        public long Id { get; set; }
        public List<Message> Updates { get; set; }
    }
}
