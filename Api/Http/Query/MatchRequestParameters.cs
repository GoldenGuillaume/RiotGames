using System.Collections.Generic;

namespace RiotGames.Api.Http.Query
{
    public class MatchRequestParameters
    {
        public HashSet<int> Champion { get; set; }
        public HashSet<int> Queue { get; set; }
        public HashSet<int> Season { get; set; }
        public long? EndTime { get; set; }
        public long? BeginTime { get; set; }
        public int? EndIndex { get; set; }
        public int? BeginIndex { get; set; }
    }
}
