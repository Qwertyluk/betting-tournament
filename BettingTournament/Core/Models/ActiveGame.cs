using BettingTournament.Core.Exceptions;

namespace BettingTournament.Core.Models
{
    public class ActiveGame : Entity
    {
        public string HomeTeam { get; set; } = string.Empty;

        public string AwayTeam { get; set; } = string.Empty;

        public int? HomeTeamScore { get; set; }

        public int? AwayTeamScore { get; set; }

        public List<ActiveBet> ActiveBets { get; set; } = [];

        public DateTime DateTimeUTC { get; set; } = DateTime.UtcNow;

        public bool CanBeArchived
            => HomeTeamScore.HasValue && AwayTeamScore.HasValue;

        public DateTime DateTimeCEST
        {
            get
            {
                var cestTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
                return TimeZoneInfo.ConvertTimeFromUtc(DateTimeUTC, cestTimeZone);
            }
        }

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
            if (!HomeTeamScore.HasValue || !AwayTeamScore.HasValue)
            {
                throw new CoreException("Cannot archive game without score");
            }

            var archivedGame = new ArchivedGame()
            {
                HomeTeam = HomeTeam,
                AwayTeam = AwayTeam,
                DateTimeUTC = DateTimeUTC,
                HomeTeamScore = HomeTeamScore.Value,
                AwayTeamScore = AwayTeamScore.Value,
                ArchivedBets = ActiveBets.Select(x => x.Archive()).ToList(),
            };

            return archivedGame;
        }
    }
}
