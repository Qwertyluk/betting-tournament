namespace BettingTournament.Core.Models
{
    public class ArchivedGame : Entity
    {
        public string HomeTeam { get; set; } = string.Empty;

        public string AwayTeam { get; set; } = string.Empty;

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

        public bool ScoreCalculated { get; set; }

        public List<ArchivedBet> ArchivedBets { get; set; } = [];

        public DateTime DateTimeUTC { get; set; } = DateTime.UtcNow;

        public DateTime DateTimeCEST
        {
            get
            {
                var cestTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(DateTimeUTC, cestTimeZone);
            }
        }
    }
}
