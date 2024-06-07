namespace BettingTournament.Core.Models
{
    public class ActiveGame
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; } = string.Empty;

        public string AwayTeam { get; set; } = string.Empty;

        public int HomeTeamScore { get; set; }

        public int AwayTeamScore { get; set; }

        public List<ActiveBet> ActiveBets { get; set; } = [];

        public DateTime DateTimeUTC { get; set; } = DateTime.UtcNow;

        public DateTime PolishDateTime
            => new DateTime(DateTimeUTC.Year, DateTimeUTC.Month, DateTimeUTC.Day, DateTimeUTC.Hour + 2, DateTimeUTC.Minute, DateTimeUTC.Second);

        public TimeSpan RemainingTime
        {
            get
            {
                var ts = DateTimeUTC - DateTime.UtcNow;
                if (ts.TotalSeconds < 0)
                {
                    return TimeSpan.Zero;
                }

                return ts;
            }
        }

        // TODO move formatting to UI layer?
        public string RemainingTimeAsString
        {
            get
            {
                var ts = RemainingTime;
                return string.Format("{0:D2}:{1:D2}:{2:D2}", (int)ts.TotalHours, ts.Minutes, ts.Seconds);
            }
        }

        public ArchivedGame Archive()
        {
            var archivedGame = new ArchivedGame()
            {
                HomeTeam = HomeTeam,
                AwayTeam = AwayTeam,
                DateTimeUTC = DateTimeUTC,
                HomeTeamScore = HomeTeamScore,
                AwayTeamScore = AwayTeamScore,
                ArchivedBets = ActiveBets.Select(x => x.Archive()).ToList(),
            };

            return archivedGame;
        }
    }
}
