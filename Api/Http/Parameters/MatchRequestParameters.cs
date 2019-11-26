using System.Collections.Generic;

namespace RiotGames.Api.Http.Parameters
{
    public class MatchRequestParameters
    {
        public HashSet<int> Champion { get; set; }
        public HashSet<int> Queue { get; set; }
        public HashSet<int> Season { get; set; }
        private long? _beginTime;
        public long? BeginTime
        {
            get
            {
                return _beginTime;
            }
            set
            {
                if (EndTime != null)
                {
                    if (value < EndTime && EndTime - value < 604800000)
                        _beginTime = value;
                }
                else
                {
                    _beginTime = value;
                }
            }
        }
        private long? _endTime;
        public long? EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                if (BeginTime != null)
                {
                    if (value > BeginTime && BeginTime + value < 604800000)
                        _endTime = value;
                }
                else
                {
                    _endTime = value;
                }
            }
        }
        private int? _beginIndex;
        public int? BeginIndex
        {
            get
            {
                return _beginIndex;
            }
            set
            {
                if (EndIndex != null)
                {
                    if (value < EndIndex && EndIndex - value < 100)
                        _beginIndex = value;
                }
                else
                {
                    _beginIndex = value;
                }
            }
        }
        private int? _endIndex;
        public int? EndIndex
        {
            get
            {
                return _endIndex;
            }
            set
            {
                if (BeginIndex != null)
                {
                    if (value > BeginIndex && value - BeginIndex < 100)
                        _endIndex = value;
                }
                else
                {
                    _endIndex = value;
                }
            }
        }
    }
}
