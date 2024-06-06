using BettingTournament.Core;
using BettingTournament.Data;

namespace BettingTournament.ViewModels
{
    public class BetViewModel
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
