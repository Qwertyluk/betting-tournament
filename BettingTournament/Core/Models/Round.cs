using BettingTournament.Core.Models;

namespace BettingTournament.Core
{
    public class Round
    {
        public IEnumerable<Game> Games { get; set; } = [];
    }
}
