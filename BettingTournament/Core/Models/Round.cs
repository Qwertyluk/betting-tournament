using BettingTournament.Core.Models;

namespace BettingTournament.Core
{
    public class Round
    {
        public IEnumerable<ActiveGame> Games { get; set; } = [];
    }
}
