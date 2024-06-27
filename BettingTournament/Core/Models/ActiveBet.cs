using BettingTournament.Core.Exceptions;
using BettingTournament.Data;

namespace BettingTournament.Core.Models
{
    public class ActiveBet : Entity
    {
        public ActiveGame Game { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;

        public ApplicationUser ApplicationUser { get; set; } = default!;

        public int? HomeTeamBet { get; private set; }

        public int? AwayTeamBet { get; private set; }

        public bool BetPlaced
            => HomeTeamBet.HasValue && AwayTeamBet.HasValue;

        public bool CanScoreBeUpdated
            => Game.RemainingTime > TimeSpan.Zero;

        public void SetUser(ApplicationUser user)
        {
            ApplicationUserId = user.Id;
            ApplicationUser = user;
        }

        public void UpdateBet(int homeTeamScore, int awayTeamScore)
        {
            if (!CanScoreBeUpdated)
            {
                throw new CoreException("The betting time has expired.");
            }

            HomeTeamBet = homeTeamScore;
            AwayTeamBet = awayTeamScore;
        }

        public ArchivedBet Archive()
            => new()
            {
                ApplicationUserId = ApplicationUserId,
                HomeTeamBet = HomeTeamBet,
                AwayTeamBet = AwayTeamBet,
            };
    }
}
