namespace RiotGames.Api.Http.Parameters
{
    /// <summary>
    /// League request parameters model
    /// </summary>
    public class LeagueRequestParameters
    {
        private int? _page;
        /// <summary>
        /// Page parameter that cannot be inferior to 1
        /// </summary>
        public int? Page
        {
            get
            {
                return _page;
            }
            set
            {
                if (value >= 1)
                {
                    _page = value;
                }
            }
        }
    }
}
