using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class ShardStatus
    {
        public string Name { get; set; }
        public string Region_tag { get; set; }
        public string Hostname { get; set; }
        public List<Service> Services { get; set; }
        public string Slug { get; set; }
        public List<string> Locales { get; set; }
    }
}
