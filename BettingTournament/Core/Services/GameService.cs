using BettingTournament.Core.Exceptions;
using BettingTournament.Core.Models;
using BettingTournament.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Core.Services
{
    public class GameService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly UserManager<ApplicationUser> _userManager;

        public GameService(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            UserManager<ApplicationUser> userManager
            )
        {
            _dbContextFactory = dbContextFactory;
            _userManager = userManager;
        }

        public void AddGame(string homeTeam, string awayTeam, DateTime dt)
        {
            var game = new ActiveGame()
            {
                HomeTeam = homeTeam,
                AwayTeam = awayTeam,
                DateTimeUTC = dt,
            };

            var users = _userManager.Users.ToList();
            var bets = new List<ActiveBet>(users.Count);

            foreach (var user in users)
            {
                var bet = new ActiveBet()
                {
                    ApplicationUserId = user.Id,
                };

                bets.Add(bet);
            }

            game.ActiveBets = bets;

            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.ActiveGames.Add(game);
                dbContext.SaveChanges();
            }
        }

        public void ArchiveGame(int gameId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.ActiveGames
                    .Include(x => x.ActiveBets)
                    .FirstOrDefault(x => x.Id == gameId) ?? throw new CoreException("Cannot find game to be archived");

                var archivedGame = game.Archive();

                dbContext.ArchivedGames.Add(archivedGame);
                dbContext.ActiveGames.Remove(game);
                dbContext.SaveChanges();
            }
        }

        public IEnumerable<ActiveGame> GetBettingGames()
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.ActiveGames.ToList();
            }
        }

        public IEnumerable<ArchivedGame> GetArchivedGames()
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                return dbContext.ArchivedGames.ToList();
            }
        }

        public IEnumerable<ActiveGame> GetGamesInProgress()
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var games = dbContext.ActiveGames
                    .Include(x => x.ActiveBets)
                    .ThenInclude(x => x.ApplicationUser)
                    .ToList();

                return games.Where(x => x.DateTimeUTC <= DateTime.UtcNow).ToList();
            }
        }

        public void UpdateGame(int gameId, string homeTeam, string awayTeam, DateTime dt)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.ActiveGames.Find(gameId);

                if (game is not null)
                {
                    game.HomeTeam = homeTeam;
                    game.AwayTeam = awayTeam;
                    game.DateTimeUTC = dt;

                    dbContext.SaveChanges();
                }
            }
        }

        public void UpdateGame(int gameId, int homeTeamScore, int awayTeamScore)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.ActiveGames.Find(gameId);

                if (game is not null)
                {
                    game.HomeTeamScore = homeTeamScore;
                    game.AwayTeamScore = awayTeamScore;

                    dbContext.SaveChanges();
                }
            }
        }

        public void Remove(int gameId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.ActiveGames.Find(gameId);
                if (game is not null)
                {
                    dbContext.ActiveGames.Remove(game);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
