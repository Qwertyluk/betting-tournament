using BettingTournament.Core.Exceptions;
using BettingTournament.Core.Models;
using BettingTournament.Data;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Core.Services
{
    public class ScoreService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public ScoreService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void FinishGame(int gameId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.Games.Find(gameId) ?? throw new CoreException("Cannot find game while finishing.");

                var bets = dbContext.Bets
                    .Where(x => x.Game.Id == game.Id)
                    .Include(x => x.Game)
                    .Include(x => x.ApplicationUser)
                    .ToList();

                foreach (var bet in bets)
                {
                    var homeTeamScore = bet.Game.HomeScore;
                    var awayTeamScore = bet.Game.AwayScore;
                    var homeTeamBet = bet.HomeScore;
                    var awayTeamBet = bet.AwayScore;

                    if (homeTeamScore == homeTeamBet && awayTeamScore == awayTeamBet)
                    {
                        // score match
                        bet.ApplicationUser.Score += 5;
                    }
                    else if (Math.Abs(homeTeamScore - awayTeamScore) == Math.Abs(homeTeamBet - awayTeamBet))
                    {
                        // goal diff match
                        bet.ApplicationUser.Score += 3;
                    }
                    else if ((homeTeamScore > awayTeamScore) && (homeTeamBet > awayTeamBet) ||
                        (homeTeamScore == awayTeamScore) && (homeTeamBet == awayTeamBet) ||
                        (homeTeamScore < awayTeamScore) && (homeTeamBet < awayTeamBet))
                    {
                        // winner/drawer match
                        bet.ApplicationUser.Score += 1;
                    }
                }

                dbContext.Games.Remove(game);
                dbContext.ArchivedBets.AddRange(bets);
                dbContext.Bets.RemoveRange(bets);

                dbContext.SaveChanges();
            }
        }
    }
}
