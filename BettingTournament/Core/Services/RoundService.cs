using BettingTournament.Components.Betting;
using BettingTournament.Data;
using BettingTournament.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Core.Services
{
    public class RoundService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly UserManager<ApplicationUser> _userManager;

        public RoundService(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            UserManager<ApplicationUser> userManager
            )
        {
            _dbContextFactory = dbContextFactory;
            _userManager = userManager;
        }

        public void AddGame(string homeTeam, string awayTeam, DateTime dt)
        {
            var game = new Game()
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                DateTimeUTC = dt,
            };

            var users = _userManager.Users.ToList();

            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Games.Add(game);

                foreach (var user in users)
                {
                    var bet = new Bet()
                    {
                        Game = game,
                        ApplicationUserId = user.Id,
                    };

                    dbContext.Bets.Add(bet);
                }

                dbContext.SaveChanges();
            }
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
                return dbContext.Bets
                    .Where(x => x.ApplicationUser.Id == user.Id)
                    .Include(x => x.Game)
                    .ToList();
            }
        }

        public void UpdateGame(int gameId, string homeTeam, string awayTeam, DateTime dt)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.Games.Find(gameId);

                if (game is not null)
                {
                    game.HomeTeam = homeTeam;
                    game.AwayTeam = awayTeam;
                    game.DateTimeUTC = dt;

                    dbContext.SaveChanges();
                }
            }
        }

        public void UpdateGame(int gameId, int homeScore, int awayScore)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.Games.Find(gameId);

                if (game is not null)
                {
                    game.HomeScore = homeScore;
                    game.AwayScore = awayScore;

                    dbContext.SaveChanges();
                }
            }
        }

        public void UpdateBet(int betId, int homeScore, int awayScore)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var bet = dbContext.Bets.Include(x => x.Game).FirstOrDefault(x => x.Id == betId);

                if (bet is not null)
                {
                    bet.SetScore(homeScore, awayScore);

                    dbContext.SaveChanges();
                }
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
