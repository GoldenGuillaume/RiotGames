namespace RiotGames.Api.Http.Parameters
{
    public class LeagueRequestParameters
    {
        public int? Page 
        {
            get
            {
                return Page;
            }
            set 
            { 
                if (value >= 1)
                {
                    Page = value;
                }
            } 
        }
    }
}
