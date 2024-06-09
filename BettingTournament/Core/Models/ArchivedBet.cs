using BettingTournament.Core.Exceptions;
using BettingTournament.Data;

namespace BettingTournament.Core.Models
{
    public class ArchivedBet
    {
        public int Id { get; set; }
        public ArchivedGame Game { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int? HomeTeamBet { get; set; }
        public int? AwayTeamBet { get; set; }
        public int Score { get; private set; }

        public void SetScore(int score)
        {
            if (Game.ScoreCalculated)
            {
                throw new CoreException("Score cannot be set because game's score has been already calculated");
            }
            Score = score;
            ApplicationUser.Score += score;
        }
    }
}
