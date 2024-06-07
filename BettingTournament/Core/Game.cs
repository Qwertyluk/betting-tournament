using BettingTournament.Core.Exceptions;

namespace BettingTournament.Core
{
    public class Game
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
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
    }
}
