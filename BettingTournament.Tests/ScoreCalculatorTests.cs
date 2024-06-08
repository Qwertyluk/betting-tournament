using BettingTournament.Core.DomainServices;
using FluentAssertions;

namespace BettingTournament.Tests
{
    public class ScoreCalculatorTests
    {
        [Theory]
        [InlineData(0, 0, 0, 0, 5)]
        [InlineData(1, 1, 1, 1, 5)]
        [InlineData(3, 1, 3, 1, 5)]
        [InlineData(1, 3, 1, 3, 5)]
        [InlineData(1, 1, 0, 0, 3)]
        [InlineData(1, 1, 2, 2, 3)]
        [InlineData(2, 1, 1, 0, 3)]
        [InlineData(1, 2, 0, 1, 3)]
        [InlineData(3, 2, 2, 1, 3)]
        [InlineData(2, 3, 1, 2, 3)]
        [InlineData(3, 2, 2, 0, 1)]
        [InlineData(2, 3, 0, 2, 1)]
        [InlineData(4, 2, 2, 1, 1)]
        [InlineData(2, 4, 1, 2, 1)]
        [InlineData(2, 1, 1, 2, 0)]
        [InlineData(1, 2, 2, 1, 0)]
        [InlineData(2, 0, 1, 2, 0)]
        [InlineData(0, 2, 2, 1, 0)]
        public void ShouldCalculateScore(
            int homeTeamScore,
            int awayTeamScore, 
            int homeTeamBet,
            int awayTeamBet,
            int expectedScore)
        {
            // Arrange
            var scoreCalculator = new ScoreCalculator();

            // Act
            var score = scoreCalculator.CalculateScore(homeTeamScore, awayTeamScore, homeTeamBet, awayTeamBet);

            // Assert
            score.Should().Be(expectedScore);
        }
    }
}