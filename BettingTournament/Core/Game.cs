namespace BettingTournament.Core
{
    public class Game
    {
        public int Id { get; set; }
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        public DateTime PolishDateTime 
            => new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, DateTime.Hour + 2, DateTime.Minute, DateTime.Second);

        public string RemainingTime
        {
            get
            {
                var ts = DateTime - DateTime.UtcNow - TimeSpan.FromMinutes(5);
                if (ts.TotalSeconds < 0)
                {
                    ts = TimeSpan.Zero;
                }

                return string.Format("{0:D2}:{1:D2}:{2:D2}", (int)ts.TotalHours, ts.Minutes, ts.Seconds);
            }
        }
    }
}
