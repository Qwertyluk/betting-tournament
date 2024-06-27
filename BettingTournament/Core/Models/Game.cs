namespace BettingTournament.Core.Models
{
    public class Game : Entity
    {
        public DateTime DateTimeUTC { get; set; }
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }

        public bool Completed 
            => HomeTeamScore is not null && AwayTeamScore is not null;
    }
}
