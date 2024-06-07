namespace BettingTournament.Core.Models
{
    public class ArchivedGame
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; } = string.Empty;

        public string AwayTeam { get; set; } = string.Empty;

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

        public bool ScoreCalculated { get; set; }

        public List<ArchivedBet> ArchivedBets { get; set; } = [];

        public DateTime DateTimeUTC { get; set; } = DateTime.UtcNow;

        public DateTime PolishDateTime
            => new DateTime(DateTimeUTC.Year, DateTimeUTC.Month, DateTimeUTC.Day, DateTimeUTC.Hour + 2, DateTimeUTC.Minute, DateTimeUTC.Second);
    }
}
