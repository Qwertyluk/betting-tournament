using BettingTournament.Core.DomainServices;
using BettingTournament.Data;

namespace BettingTournament.Core.Models
{
    public class Bet : Entity
    {
        public int HomeTeamBet { get; set; }
        public int AwayTeamBet { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Game Game { get; set; }

        public void AssignPointsForUser()
        {
            var homeTeamScore = Game.HomeTeamScore;
            var awayTeamScore = Game.AwayTeamScore;
            var score = 0;

            if (homeTeamScore == HomeTeamBet && awayTeamScore == AwayTeamBet)
            {
                // score match
                score = (int)Score.ExactResult;
            }
            else if (homeTeamScore - awayTeamScore == HomeTeamBet - AwayTeamBet)
            {
                // goal diff match
                score = (int)Score.GoodGoalDiff;
            }
            else if ((homeTeamScore > awayTeamScore) && (HomeTeamBet > AwayTeamBet) ||
                (homeTeamScore == awayTeamScore) && (HomeTeamBet == AwayTeamBet) ||
                (homeTeamScore < awayTeamScore) && (HomeTeamBet < AwayTeamBet))
            {
                // winner/drawer match
                score = (int)Score.Winner;
            }

            if (score > 0)
            {
                ApplicationUser.Score += score;
            }
        }
    }
}
