using BettingTournament.Core.Models;
using BettingTournament.Data;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Core.Services
{
    public class UpdateManager
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IFootballDataProvider _dataProvider;

        public UpdateManager(ApplicationDbContext dbContext, IFootballDataProvider gamesProvider)
        {
            _dbContext = dbContext;
            _dataProvider = gamesProvider;
        }

        public async Task UpdateSystemAsync()
        {
            var dbLeagues = _dbContext.Leagues.Include(x => x.Rounds).ThenInclude(x => x.Games).ToList();
            var leagues = _dataProvider.FetchLeagues();

            await AddNewLeaguesAsync(dbLeagues, leagues);
            await UpdateDataAsync(dbLeagues, leagues);
        }

        private async Task AddNewLeaguesAsync(IList<League> dbLeagues, IList<League> leagues)
        {
            var newLeagues = leagues.Except(dbLeagues);

            await _dbContext.Leagues.AddRangeAsync(newLeagues);
            await _dbContext.SaveChangesAsync();
        }

        private async Task UpdateDataAsync(IList<League> dbLeagues, IList<League> leagues)
        {
            foreach (var dbLeague in dbLeagues)
            {
                await UpdateLeaguesAsync(dbLeague, leagues.First(x => x.Id == dbLeague.Id));
            }
        }

        private async Task UpdateLeaguesAsync(League dbLeague, League league)
        {
            foreach (var dbRound in dbLeague.Rounds)
            {
                if (!dbRound.Completed)
                {
                    // TODO
                }
            }
        }
    }
}
