using BettingTournament.Data;

namespace BettingTournament.Core
{
    public class Bet
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        public void SetUser(ApplicationUser user)
        {
            ApplicationUserId = user.Id;
            ApplicationUser = user;
        }
    }
}
