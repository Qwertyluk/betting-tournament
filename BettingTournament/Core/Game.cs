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

        public string RemainingTime
        {
            get
            {
                var ts = DateTime - DateTime.UtcNow - TimeSpan.FromMinutes(5);
                return string.Format("{0:D2}:{1:D2}:{2:D2}", (int)ts.TotalHours, ts.Minutes, ts.Seconds);
            }
        }
    }
}
