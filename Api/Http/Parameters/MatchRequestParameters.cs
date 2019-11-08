using System.Collections.Generic;

namespace RiotGames.Api.Http.Parameters
{
    public class MatchRequestParameters
    {
        public HashSet<int> Champion { get; set; }
        public HashSet<int> Queue { get; set; }
        public HashSet<int> Season { get; set; }
        public long? BeginTime
        {
            get
            {
                return BeginTime;
            }
            set
            {
                if (EndTime != null)
                {
                    if (value < EndTime && EndTime - value < 604800000)
                        BeginTime = value;
                }
                else
                {
                    BeginTime = value;
                }
            }
        }
        public long? EndTime
        {
            get
            {
                return EndTime;
            }
            set
            {
                if (BeginTime != null)
                {
                    if (value > BeginTime && BeginTime + value < 604800000)
                        EndTime = value;
                }
                else
                {
                    EndTime = value;
                }
            }
        }
        public int? BeginIndex
        {
            get
            {
                return BeginIndex;
            }
            set
            {
                if (EndIndex != null)
                {
                    if (value < EndIndex && EndIndex - value < 100)
                        BeginIndex = value;
                }
                else
                {
                    BeginIndex = value;
                }
            }
        }
        public int? EndIndex
        {
            get
            {
                return EndIndex;
            }
            set
            {
                if (BeginIndex != null)
                {
                    if (value > BeginIndex && value - BeginIndex < 100)
                        EndIndex = value;
                }
                else
                {
                    EndIndex = value;
                }
            }
        }
    }
}
