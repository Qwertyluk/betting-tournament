using BettingTournament.Core.Exceptions;
using BettingTournament.Core.Models;
using BettingTournament.Data;
using BettingTournament.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BettingTournament.Core.Services
{
    public class ScoreService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly UserManager<ApplicationUser> _userManager;

        public ScoreService(IDbContextFactory<ApplicationDbContext> dbContextFactory, UserManager<ApplicationUser> userManager)
        {
            _dbContextFactory = dbContextFactory;
            _userManager = userManager;
        }

        public void CalculateScoreFor(int gameId)
        {
            using (var dbContext = _dbContextFactory.CreateDbContext())
            {
                var game = dbContext.ArchivedGames
                    .Include(x => x.ArchivedBets)
                    .ThenInclude(x => x.ApplicationUser)
                    .FirstOrDefault(x => x.Id == gameId)
                    ?? throw new CoreException("Cannot find game while finishing.");

                if (game.ScoreCalculated)
                {
                    throw new CoreException($"Score has been already calculated for the game with id {gameId}");
                }

                foreach (var bet in game.ArchivedBets)
                {
                    var homeTeamScore = bet.Game.HomeTeamScore;
                    var awayTeamScore = bet.Game.AwayTeamScore;
                    var homeTeamBet = bet.HomeTeamBet;
                    var awayTeamBet = bet.AwayTeamBet;
                    var user = bet.ApplicationUser;
                    var score = 0;

                    if (homeTeamScore == homeTeamBet && awayTeamScore == awayTeamBet)
                    {
                        // score match
                        score = 5;
                    }
                    else if (Math.Abs(homeTeamScore - awayTeamScore) == Math.Abs(homeTeamBet - awayTeamBet))
                    {
                        // goal diff match
                        score = 3;
                    }
                    else if ((homeTeamScore > awayTeamScore) && (homeTeamBet > awayTeamBet) ||
                        (homeTeamScore == awayTeamScore) && (homeTeamBet == awayTeamBet) ||
                        (homeTeamScore < awayTeamScore) && (homeTeamBet < awayTeamBet))
                    {
                        // winner/drawer match
                        score = 1;
                    }

                    user.Score += score;
                    game.ScoreCalculated = true;
                }

                dbContext.SaveChanges();
            }
        }

        public IEnumerable<ResultViewModel> GetScores()
        {
            var users = _userManager.Users.OrderByDescending(x => x.Score).ToList();
            var rank = 1;

            return users.Select(x => new ResultViewModel()
            {
                Rank = rank++,
                UserId = x.Id,
                UserName = x.UserName ?? string.Empty,
                Score = x.Score,
            }).ToList();
        }
    }
}
