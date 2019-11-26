namespace RiotGames.Api.Http.Parameters
{
    public class LeagueRequestParameters
    {
        private int? _page;
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
