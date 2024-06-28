namespace BettingTournament.Core.Models
{
    public class Game : Entity
    {
        public DateTime DateTimeUTC { get; set; }
        public string HomeTeam { get; set; } = string.Empty;
        public string AwayTeam { get; set; } = string.Empty;
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public virtual ICollection<Bet> Bets { get; set; } = [];

        public bool Completed 
            => HomeTeamScore is not null && AwayTeamScore is not null;

        public void CompleteBasedOn(Game game)
        {
            HomeTeamScore = game.HomeTeamScore;
            AwayTeamScore = game.AwayTeamScore;

            AssignPoints();
        }

        private void AssignPoints()
        {
            foreach (var bet in Bets)
            {
                bet.AssignPointsForUser();
            }
        }
    }
}
