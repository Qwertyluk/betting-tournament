using BettingTournament.Core;

namespace BettingTournament.ViewModels
{
    public class GameBet
    {
        public Game Game { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
