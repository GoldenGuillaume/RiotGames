using System.Collections.Generic;

namespace RiotGames.Api.Models
{
    public class MatchTimeline
    {
        public List<MatchFrame> Frames { get; set; }
        public long FrameInterval { get; set; }
    }
}
