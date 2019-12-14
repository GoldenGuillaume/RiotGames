namespace RiotGames.Api.Http.Parameters
{
    /// <summary>
    /// Tournament request parameters model
    /// </summary>
    public class TournamentRequestParameters
    {
        /// <summary>
        /// Count parameter
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// TournamentId parameter
        /// </summary>
        public long TournamentId { get; set; }
    }
}
