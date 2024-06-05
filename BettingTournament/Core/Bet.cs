using BettingTournament.Data;

namespace BettingTournament.Core
{
    public class Bet
    {
        public Game Game { get; set; }
        public ApplicationUser User { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
