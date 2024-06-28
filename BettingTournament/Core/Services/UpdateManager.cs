using BettingTournament.Core.Models;
using BettingTournament.Data;

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
            var dbLeagues = _dbContext.Leagues.ToList();
            var leagues = _dataProvider.FetchLeagues();

            await AddNewLeaguesAsync(dbLeagues, leagues);
            await UpdateExistingLeaguesAsync(dbLeagues, leagues);
        }

        private async Task AddNewLeaguesAsync(IList<League> dbLeagues, IList<League> leagues)
        {
            var newLeagues = leagues.Except(dbLeagues);

            await _dbContext.Leagues.AddRangeAsync(newLeagues);
            await _dbContext.SaveChangesAsync();
        }

        private async Task UpdateExistingLeaguesAsync(IList<League> dbLeagues, IList<League> leagues)
        {
            foreach (var dbLeague in dbLeagues)
            {
                await UpdateLeagueAsync(dbLeague, leagues.First(x => x.Equals(dbLeague)));
            }
        }

        private async Task UpdateLeagueAsync(League dbLeague, League league)
        {
            foreach (var dbRound in dbLeague.Rounds)
            {
                if (!dbRound.Completed)
                {
                    var round = league.Rounds.First(x => x.Equals(dbRound));
                    await UpdateRoundAsync(dbRound, round);
                }
            }
        }

        private async Task UpdateRoundAsync(Round dbRound, Round round)
        {
            foreach (var dbGame in dbRound.Games)
            {
                if (!dbGame.Completed)
                {
                    var game = round.Games.First(x => x.Equals(dbGame));
                    if (game.Completed)
                    {
                        dbGame.CompleteBasedOn(game);
                    }
                }
            }
        }
    }
}
