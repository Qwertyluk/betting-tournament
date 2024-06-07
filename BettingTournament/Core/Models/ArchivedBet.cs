using BettingTournament.Data;

namespace BettingTournament.Core.Models
{
    public class ArchivedBet
    {
        public int Id { get; set; }
        public ArchivedGame Game { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int HomeBetScore { get; set; }
        public int AwayBetScore { get; set; }
        public int Score { get; set; }
    }
}
