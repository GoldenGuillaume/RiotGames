using System;
using System.Collections.Generic;

namespace RiotGames.Api.Http.Parameters
{
    /// <summary>
    /// Match request parameters model
    /// </summary>
    public class MatchRequestParameters
    {
        /// <summary>
        /// Champion parameter containing all the champions id 
        /// </summary>
        public HashSet<int> Champion { get; set; } = new HashSet<int>();
        /// <summary>
        /// Queue parameter containing all the queues id
        /// </summary>
        public HashSet<int> Queue { get; set; } = new HashSet<int>();
        /// <summary>
        /// Season parameter containing all the seasons id
        /// </summary>
        [ObsoleteAttribute("This field should not be considered reliable for the purposes of filtering matches by season.")]
        public HashSet<int> Season { get; set; } = new HashSet<int>();
        private long? _beginTime;
        /// <summary>
        /// BeginTime parameter were the value need to be
        /// inferior atleast 604 800 000 miliseconds to EndTime  
        /// </summary>
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
        /// <summary>
        /// EndTime parameter were the value need to be
        /// superior atleast 604 800 000 miliseconds to BeginTime  
        /// </summary>
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
        /// <summary>
        /// BeginIndex parameter were the value need to be inferior to 
        /// EndTime atleast of 100
        /// </summary>
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
        /// <summary>
        /// EndIndex parameter were the value need to be superior to 
        /// BeginIndex atleast of 100
        /// </summary>
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
