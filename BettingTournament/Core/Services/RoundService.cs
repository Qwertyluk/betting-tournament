using BettingTournament.Data;
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
                return dbContext.CurrentGames.ToList();
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
                dbContext.CurrentGames.Add(game);
                dbContext.SaveChanges();
            }
        }

        public void Remove(int gameId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.CurrentGames.Find(gameId);
                if (game is not null)
                {
                    dbContext.CurrentGames.Remove(game);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
