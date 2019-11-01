using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class Message
    {
        public string Severity { get; set; }
        public string Author { get; set; }
        public string Created_at { get; set; }
        public List<Translation> Translations { get; set; }
        public string Updated_at { get; set; }
        public string Content { get; set; }
        public string Id { get; set; }
    }
}
