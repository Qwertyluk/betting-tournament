using BettingTournament.Data;

namespace BettingTournament.Core
{
    public class Bet
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        
        // TODO change to init
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }

        // TODO
        private bool CanBeUpdated => Game.RemainingTime.TotalSeconds > 0;

        public void SetUser(ApplicationUser user)
        {
            ApplicationUserId = user.Id;
            ApplicationUser = user;
        }

        public void Update(int homeScore, int awayScore)
        {
            // TODO
            if (CanBeUpdated)
            {
                // ...
            }
        }


    }
}
