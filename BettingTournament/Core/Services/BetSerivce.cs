using BettingTournament.Core.Models;
using BettingTournament.Data;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Core.Services
{
    public class BetService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public BetService(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IEnumerable<ActiveBet> GetBets(string userId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.ActiveBets
                    .Where(x => x.ApplicationUser.Id == userId)
                    .Include(x => x.Game)
                    .ToList();
            }
        }

        public IEnumerable<ArchivedBet> GetArchivedBets(string userId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.ArchivedBets
                    .Where(x => x.ApplicationUser.Id == userId)
                    .OrderByDescending(x => x.Game.DateTimeUTC)
                    .ToList();
            }
        }

        public void UpdateBet(int betId, int homeScore, int awayScore)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var bet = dbContext.ActiveBets.Include(x => x.Game).FirstOrDefault(x => x.Id == betId);

                if (bet is not null)
                {
                    bet.SetScore(homeScore, awayScore);

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
