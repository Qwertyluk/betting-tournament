using static System.Formats.Asn1.AsnWriter;

namespace BettingTournament.Core.DomainServices
{
    public class ScoreCalculator
    {
        public int CalculateScore(int homeTeamScore, int awayTeamScore, int? homeTeamBet, int? awayTeamBet)
        {
            if (!homeTeamBet.HasValue || !awayTeamBet.HasValue)
            {
                return 0;
            }

            if (homeTeamScore == homeTeamBet && awayTeamScore == awayTeamBet)
            {
                // score match
                return 5;
            }
            else if (homeTeamScore - awayTeamScore == homeTeamBet - awayTeamBet)
            {
                // goal diff match
                return 3;
            }
            else if ((homeTeamScore > awayTeamScore) && (homeTeamBet > awayTeamBet) ||
                (homeTeamScore == awayTeamScore) && (homeTeamBet == awayTeamBet) ||
                (homeTeamScore < awayTeamScore) && (homeTeamBet < awayTeamBet))
            {
                // winner/drawer match
                return 1;
            }

            return 0;
        }
    }
}
