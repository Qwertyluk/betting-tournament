using BettingTournament.Core.Models;

namespace BettingTournament.Core.DomainServices
{
    public class ScoreCalculator
    {
        public int CalculateScore(int homeTeamScore, int awayTeamScore, int? homeTeamBet, int? awayTeamBet)
        {
            if (!homeTeamBet.HasValue || !awayTeamBet.HasValue)
            {
                return (int)Score.WrongBet;
            }

            if (homeTeamScore == homeTeamBet && awayTeamScore == awayTeamBet)
            {
                // score match
                return (int)Score.ExactResult;
            }
            else if (homeTeamScore - awayTeamScore == homeTeamBet - awayTeamBet)
            {
                // goal diff match
                return (int)Score.GoodGoalDiff;
            }
            else if ((homeTeamScore > awayTeamScore) && (homeTeamBet > awayTeamBet) ||
                (homeTeamScore == awayTeamScore) && (homeTeamBet == awayTeamBet) ||
                (homeTeamScore < awayTeamScore) && (homeTeamBet < awayTeamBet))
            {
                // winner/drawer match
                return (int)Score.Winner;
            }

            return (int)Score.WrongBet;
        }
    }
}
