using BettingTournament.Core.Exceptions;
using BettingTournament.Data;

namespace BettingTournament.Core.Models
{
    public class ActiveBet
    {
        public int Id { get; set; }
        
        public ActiveGame Game { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;

        public ApplicationUser ApplicationUser { get; set; } = default!;

        public int HomeScore { get; private set; }
        
        public int AwayScore { get; private set; }

        public bool CanScoreBeUpdated
            => Game.RemainingTime > TimeSpan.Zero;

        public void SetUser(ApplicationUser user)
        {
            ApplicationUserId = user.Id;
            ApplicationUser = user;
        }

        public void SetScore(int homeTeamScore, int awayTeamScore)
        {
            if (!CanScoreBeUpdated)
            {
                throw new CoreException("The betting time has expired.");
            }

            HomeScore = homeTeamScore;
            AwayScore = awayTeamScore;
        }

        public ArchivedBet Archive()
            => new()
                {
                    ApplicationUserId = ApplicationUserId,
                    HomeBetScore = HomeScore,
                    AwayBetScore = AwayScore,
                };
    }
}
