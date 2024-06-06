using BettingTournament.Data;
using BettingTournament.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Core.Services
{
    public class RoundService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public RoundService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<Game> GetGames()
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Games.ToList();
            }
        }

        public IEnumerable<Bet> GetBets(ApplicationUser user)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.Bets.Where(x => x.User.Id == user.Id).ToList();
            }
        }

        public void AddGame(string homeTeam, string awayTeam)
        {
            var game = new Game()
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam
            };

            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Games.Add(game);
                dbContext.SaveChanges();
            }
        }

        public void Remove(int gameId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.Games.Find(gameId);
                if (game is not null)
                {
                    dbContext.Games.Remove(game);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
