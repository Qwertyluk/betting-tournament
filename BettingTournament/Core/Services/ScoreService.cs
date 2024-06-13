using BettingTournament.Core.DomainServices;
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
        private readonly ScoreCalculator _scoreCalculator;

        public ScoreService(
            IDbContextFactory<ApplicationDbContext> dbContextFactory,
            UserManager<ApplicationUser> userManager,
            ScoreCalculator scoreCalculator)
        {
            _dbContextFactory = dbContextFactory;
            _userManager = userManager;
            _scoreCalculator = scoreCalculator;
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
                    var score = _scoreCalculator.CalculateScore(homeTeamScore, awayTeamScore, homeTeamBet, awayTeamBet);
                    bet.SetScore(score);
                }

                game.ScoreCalculated = true;

                dbContext.SaveChanges();
            }
        }

        public IEnumerable<ResultViewModel> GetScores()
        {
            var users = _userManager.Users
                .Include(x => x.ArchivedBets)
                .OrderByDescending(x => x.Score)
                .ToList();
            var rank = 1;

            return users.Select(x =>
            {
                var wrongBets = x.ArchivedBets.Count(x => x.Score == (int)Score.WrongBet);
                var winnerBets = x.ArchivedBets.Count(x => x.Score == (int)Score.Winner);
                var goalDiffBets = x.ArchivedBets.Count(x => x.Score == (int)Score.GoodGoalDiff);
                var exactResultBets = x.ArchivedBets.Count(x => x.Score == (int)Score.ExactResult);

                return new ResultViewModel()
                {
                    Rank = rank++,
                    UserId = x.Id,
                    UserName = x.UserName ?? string.Empty,
                    PersonalData = $"{x.FirstName} {x.LastName}",
                    Score = x.Score,
                    Bets = $"{wrongBets}-{winnerBets}-{goalDiffBets}-{exactResultBets}",
                };
            }).ToList();
        }
    }
}
