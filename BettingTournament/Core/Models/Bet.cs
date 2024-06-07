using BettingTournament.Core.Exceptions;
using BettingTournament.Data;

namespace BettingTournament.Core.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

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


    }
}
